Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmBorrower
    Public FirstLoad As Boolean = True
    Public ID As Integer
    Dim FileName As String
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public TotalImage As Integer

    Public SpouseID As String
    Public CoMakerID_1 As String
    Public CoMakerID_2 As String
    Public DependentID_1 As String
    Public DependentID_2 As String
    Public DependentID_3 As String
    Public DependentID_4 As String
    '*** D A T A   S T O R A G E ***'
    'Borrower Info
    Dim vRent_B As Double

    Dim vEmpAddress_B As String
    Dim vEmpTelephone_B As String
    Dim vPosition_B As String
    Dim vCasual_B As Boolean
    Dim vTemporary_B As Boolean
    Dim vPermanent_B As Boolean
    Dim vSupervisor_B As String
    Dim vSalary_B As Double

    Dim vBusinessAddress_B As String
    Dim vBusinessTelephone_B As String
    Dim vNatureBusiness_B As String
    Dim vYrsOperation_B As Integer
    Dim vBusinessIncome_B As Double
    Dim vNoEmployees_B As Integer
    Dim vCapital_B As Double
    Dim vArea_B As String
    Dim vOutlet_B As Integer
    Dim vOtherIncome_B As String

    Dim vOtherIncomeD_B As Double

    'Financial Info
    Dim vNatureLoan_1 As String
    Dim vAmountGranted_1 As Double
    Dim vTerm_1 As Double
    Dim vBalance_1 As Double
    Dim vCreditRemarks_1 As String
    Dim vCreditor_2 As String
    Dim vNatureLoan_2 As String
    Dim vAmountGranted_2 As Double
    Dim vTerm_2 As Double
    Dim vBalance_2 As Double
    Dim vCreditRemarks_2 As String
    Dim vCreditor_3 As String
    Dim vNatureLoan_3 As String
    Dim vAmountGranted_3 As Double
    Dim vTerm_3 As Double
    Dim vBalance_3 As Double
    Dim vCreditRemarks_3 As String

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
    Dim vBank_3 As String
    Dim vBranch_3 As String
    Dim vcSA_3 As Boolean
    Dim vcCA_3 As Boolean
    Dim vSA_3 As String
    Dim vAverageBalance_3 As Double
    Dim vPresentBalance_3 As Double
    Dim vBankRemarks_3 As String

    Dim vTCT_1 As String
    Dim vArea_1 As Double
    Dim vAcquired_1 As String
    Dim vPropertiesRemarks_1 As String
    Dim vLocation_2 As String
    Dim vTCT_2 As String
    Dim vArea_2 As Double
    Dim vAcquired_2 As String
    Dim vPropertiesRemarks_2 As String
    Dim vLocation_3 As String
    ReadOnly vTCT_3 As String
    ReadOnly vArea_3 As Double
    ReadOnly vAcquired_3 As String
    ReadOnly vPropertiesRemarks_3 As String

    Dim vWhomAcquired_1 As String
    Dim vVehicleRemarks_1 As String
    Dim vVehicle_2 As String
    Dim vWhomAcquired_2 As String
    Dim vVehicleRemarks_2 As String
    Dim vVehicle_3 As String
    Dim vWhomAcquired_3 As String
    Dim vVehicleRemarks_3 As String

    Dim vHomeAppliances_2 As String
    Dim vReferenceAddress_1 As String
    Dim vReferenceContact_1 As String
    Dim vReference_2 As String
    Dim vReferenceAddress_2 As String
    Dim vReferenceContact_2 As String
    Dim vReference_3 As String
    Dim vReferenceAddress_3 As String
    Dim vReferenceContact_3 As String

    Dim vPlaceIssue As String

    'Spouse Info
    Dim vRent_S As Double

    Dim vEmpAddress_S As String
    Dim vEmpTelephone_S As String
    Dim vPosition_S As String
    Dim vCasual_S As Boolean
    Dim vTemporary_S As Boolean
    Dim vPermanent_S As Boolean
    Dim vSupervisor_S As String
    Dim vSalary_S As Double

    Dim vBusinessAddress_S As String
    Dim vBusinessTelephone_S As String
    Dim vNatureBusiness_S As String
    Dim vYrsOperation_S As Integer
    Dim vBusinessIncome_S As Double
    Dim vNoEmployees_S As Integer
    Dim vCapital_S As Double
    Dim vArea_S As String
    Dim vOutlet_S As Integer
    Dim vOtherIncome_S As String

    Dim vOtherIncomeD_S As Double
    '*** D A T A   S T O R A G E ***'

    '*** I D E N T I F I C A T I O N ***
    Public GSIS As String
    Public PhilHealth As String
    Public Senior As String
    Public UMID As String
    Public SEC As String
    Public DTI As String
    Public CDA As String
    Public Cooperative As String
    Public Drivers As String
    Public dDrivers As String
    Public VIN As String
    Public dVIN As String
    Public Passport As String
    Public dPassport As String
    Public PRC As String
    Public dPRC As String
    Public NBI As String
    Public dNBI As String
    Public Police As String
    Public dPolice As String
    Public Postal As String
    Public dPostal As String
    Public Barangay As String
    Public dBarangay As String
    Public OWWA As String
    Public dOWWA As String
    Public OFW As String
    Public dOFW As String
    Public Seaman As String
    Public dSeaman As String
    Public PNP As String
    Public dPNP As String
    Public AFP As String
    Public dAFP As String
    Public HDMF As String
    Public dHDMF As String
    Public PWD As String
    Public dPWD As String
    Public DSWD As String
    Public dDSWD As String
    Public ACR As String
    Public dACR As String
    Public DTI_Business As String
    Public dDTI_Business As String
    Public IBP As String
    Public dIBP As String
    Public FireArms As String
    Public dFireArms As String
    Public Government As String
    Public dGovernment As String
    Public Diplomat As String
    Public dDiplomat As String
    Public National As String
    Public dNational As String
    Public Work As String
    Public dWork As String
    Public GOCC As String
    Public dGOCC As String
    Public PLRA As String
    Public dPLRA As String
    Public Major As String
    Public dMajor As String
    Public Media As String
    Public dMedia As String
    Public Student As String
    Public dStudent As String
    Public SIRV As String
    Public dSIRV As String

    Public GSIS_S As String
    Public PhilHealth_S As String
    Public Senior_S As String
    Public UMID_S As String
    Public SEC_S As String
    Public DTI_S As String
    Public CDA_S As String
    Public Cooperative_S As String
    Public Drivers_S As String
    Public dDrivers_S As String
    Public VIN_S As String
    Public dVIN_S As String
    Public Passport_S As String
    Public dPassport_S As String
    Public PRC_S As String
    Public dPRC_S As String
    Public NBI_S As String
    Public dNBI_S As String
    Public Police_S As String
    Public dPolice_S As String
    Public Postal_S As String
    Public dPostal_S As String
    Public Barangay_S As String
    Public dBarangay_S As String
    Public OWWA_S As String
    Public dOWWA_S As String
    Public OFW_S As String
    Public dOFW_S As String
    Public Seaman_S As String
    Public dSeaman_S As String
    Public PNP_S As String
    Public dPNP_S As String
    Public AFP_S As String
    Public dAFP_S As String
    Public HDMF_S As String
    Public dHDMF_S As String
    Public PWD_S As String
    Public dPWD_S As String
    Public DSWD_S As String
    Public dDSWD_S As String
    Public ACR_S As String
    Public dACR_S As String
    Public DTI_Business_S As String
    Public dDTI_Business_S As String
    Public IBP_S As String
    Public dIBP_S As String
    Public FireArms_S As String
    Public dFireArms_S As String
    Public Government_S As String
    Public dGovernment_S As String
    Public Diplomat_S As String
    Public dDiplomat_S As String
    Public National_S As String
    Public dNational_S As String
    Public Work_S As String
    Public dWork_S As String
    Public GOCC_S As String
    Public dGOCC_S As String
    Public PLRA_S As String
    Public dPLRA_S As String
    Public Major_S As String
    Public dMajor_S As String
    Public Media_S As String
    Public dMedia_S As String
    Public Student_S As String
    Public dStudent_S As String
    Public SIRV_S As String
    Public dSIRV_S As String

    Public TotalImage_TIN As Integer
    Public TotalImage_SSS As Integer
    Public TotalImage_GSIS As Integer
    Public TotalImage_PhilHealth As Integer
    Public TotalImage_Senior As Integer
    Public TotalImage_UMID As Integer
    Public TotalImage_SEC As Integer
    Public TotalImage_DTI As Integer
    Public TotalImage_CDA As Integer
    Public TotalImage_Cooperative As Integer
    Public TotalImage_Drivers As Integer
    Public TotalImage_VIN As Integer
    Public TotalImage_Passport As Integer
    Public TotalImage_PRC As Integer
    Public TotalImage_NBI As Integer
    Public TotalImage_Police As Integer
    Public TotalImage_Postal As Integer
    Public TotalImage_Barangay As Integer
    Public TotalImage_OWWA As Integer
    Public TotalImage_OFW As Integer
    Public TotalImage_Seaman As Integer
    Public TotalImage_PNP As Integer
    Public TotalImage_AFP As Integer
    Public TotalImage_HDMF As Integer
    Public TotalImage_PWD As Integer
    Public TotalImage_DSWD As Integer
    Public TotalImage_ACR As Integer
    Public TotalImage_DTI_Business As Integer
    Public TotalImage_IBP As Integer
    Public TotalImage_FireArms As Integer
    Public TotalImage_Government As Integer
    Public TotalImage_Diplomat As Integer
    Public TotalImage_National As Integer
    Public TotalImage_Work As Integer
    Public TotalImage_GOCC As Integer
    Public TotalImage_PLRA As Integer
    Public TotalImage_Major As Integer
    Public TotalImage_Media As Integer
    Public TotalImage_Student As Integer
    Public TotalImage_SIRV As Integer

    Public TotalImage_TIN_S As Integer
    Public TotalImage_SSS_S As Integer
    Public TotalImage_GSIS_S As Integer
    Public TotalImage_PhilHealth_S As Integer
    Public TotalImage_Senior_S As Integer
    Public TotalImage_UMID_S As Integer
    Public TotalImage_SEC_S As Integer
    Public TotalImage_DTI_S As Integer
    Public TotalImage_CDA_S As Integer
    Public TotalImage_Cooperative_S As Integer
    Public TotalImage_Drivers_S As Integer
    Public TotalImage_VIN_S As Integer
    Public TotalImage_Passport_S As Integer
    Public TotalImage_PRC_S As Integer
    Public TotalImage_NBI_S As Integer
    Public TotalImage_Police_S As Integer
    Public TotalImage_Postal_S As Integer
    Public TotalImage_Barangay_S As Integer
    Public TotalImage_OWWA_S As Integer
    Public TotalImage_OFW_S As Integer
    Public TotalImage_Seaman_S As Integer
    Public TotalImage_PNP_S As Integer
    Public TotalImage_AFP_S As Integer
    Public TotalImage_HDMF_S As Integer
    Public TotalImage_PWD_S As Integer
    Public TotalImage_DSWD_S As Integer
    Public TotalImage_ACR_S As Integer
    Public TotalImage_DTI_Business_S As Integer
    Public TotalImage_IBP_S As Integer
    Public TotalImage_FireArms_S As Integer
    Public TotalImage_Government_S As Integer
    Public TotalImage_Diplomat_S As Integer
    Public TotalImage_National_S As Integer
    Public TotalImage_Work_S As Integer
    Public TotalImage_GOCC_S As Integer
    Public TotalImage_PLRA_S As Integer
    Public TotalImage_Major_S As Integer
    Public TotalImage_Media_S As Integer
    Public TotalImage_Student_S As Integer
    Public TotalImage_SIRV_S As Integer
    '*** I D E N T I F I C A T I O N ***

    '*** D E P E N D E N T S ***
    Public Prefix_1 As String
    Public FirstN_1 As String
    Public MiddleN_1 As String
    Public LastN_1 As String
    Public Suffix_1 As String
    Public Birth_1 As String
    Public Grade_1 As String
    Public School_1 As String
    Public SchoolAddress_1 As String
    Public Prefix_2 As String
    Public FirstN_2 As String
    Public MiddleN_2 As String
    Public LastN_2 As String
    Public Suffix_2 As String
    Public Birth_2 As String
    Public Grade_2 As String
    Public School_2 As String
    Public SchoolAddress_2 As String
    Public Prefix_3 As String
    Public FirstN_3 As String
    Public MiddleN_3 As String
    Public LastN_3 As String
    Public Suffix_3 As String
    Public Birth_3 As String
    Public Grade_3 As String
    Public School_3 As String
    Public SchoolAddress_3 As String
    Public Prefix_4 As String
    Public FirstN_4 As String
    Public MiddleN_4 As String
    Public LastN_4 As String
    Public Suffix_4 As String
    Public Birth_4 As String
    Public Grade_4 As String
    Public School_4 As String
    Public SchoolAddress_4 As String
    Dim ChangeBorrowerPic As Boolean
    Dim ChangeSpousePic As Boolean
    '*** D E P E N D E N T S ***

    Private Sub FrmBorrower_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_B.Size = New Point(255, 256)
        pb_B.Location = New Point(892, 6)
        pb_S.Size = New Point(255, 256)
        pb_S.Location = New Point(892, 6)
        cbxNatureBusiness_B2.Size = New Point(182, 24)
        cbxNatureBusiness_B2.Location = New Point(142, 125)
        cbxNatureBusiness_S2.Size = New Point(182, 24)
        cbxNatureBusiness_S2.Location = New Point(142, 125)
        FirstLoad = True

        GetBorrower()
        DefaultImage.Image = pb_B.Image.Clone
        btnBack.Enabled = False

        DtpBirth_B.Value = Date.Now
        dtpHired_B.Value = Date.Now
        dtpHired_B.CustomFormat = ""
        dtpExpiry_B.Value = Date.Now
        dtpExpiry_B.CustomFormat = ""
        dtpYear_1.Value = Date.Now
        dtpYear_1.CustomFormat = ""
        dtpYear_2.Value = Date.Now
        dtpYear_2.CustomFormat = ""
        dtpYear_3.Value = Date.Now
        dtpYear_3.CustomFormat = ""
        dtpIssue.Value = Date.Now
        dtpIssue.CustomFormat = ""

        DtpBirth_S.Value = Date.Now
        dtpHired_S.Value = Date.Now
        dtpHired_S.CustomFormat = ""
        dtpExpiry_S.Value = Date.Now
        dtpExpiry_S.CustomFormat = ""

        'BusinessCenter
        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

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

        With cbxAddressP_B
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

        'Spouse
        With CbxPrefix_S
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_S
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_M
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_M
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxAddressC_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddressP_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxPlaceBirth_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAgentName
            .ValueMember = "AgentID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT AgentID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Name` DESC;", Branch_ID))
            .SelectedIndex = -1
        End With

        With cbxMarketingName
            .ValueMember = "emp_code"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, emp_code, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), IF(Last_Name = '','',Last_Name)) AS 'Name', Phone FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND department_id = 9 ORDER BY `Name`;", Branch_ID))
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

        With cbxPosition_B
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxEmployer_B
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition_S
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxEmployer_S
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
            .SelectedIndex = -1
        End With

        pb_B.Properties.ContextMenuStrip = New ContextMenuStrip()
        pb_S.Properties.ContextMenuStrip = New ContextMenuStrip()
        FirstLoad = False

        cbxNatureBusiness_B2.Properties.LookAndFeel.SkinName = "Blue"
        cbxNatureBusiness_S2.Properties.LookAndFeel.SkinName = "Blue"
        For x As Integer = 0 To DT_Industry.Rows.Count - 1
            cbxNatureBusiness_B2.Properties.Items.Add(DT_Industry(x)("ID"), DT_Industry(x)("Nature"), CheckState.Unchecked, True)
            cbxNatureBusiness_S2.Properties.Items.Add(DT_Industry(x)("ID"), DT_Industry(x)("Nature"), CheckState.Unchecked, True)
        Next
        cbxNatureBusiness_B2.Properties.SeparatorChar = ";"
        cbxNatureBusiness_S2.Properties.SeparatorChar = ";"
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

            GetLabelFontSettings({LabelX44, LabelX40, LabelX155, LabelX4, LabelX6, LabelX7, LabelX10, LabelX14, LabelX13, LabelX8, LabelX9, LabelX51, LabelX11, LabelX12, LabelX15, LabelX16, LabelX17, LabelX39, LabelX18, LabelX21, LabelX23, LabelX26, LabelX29, LabelX31, LabelX38, LabelX35, LabelX19, LabelX22, LabelX24, LabelX27, LabelX30, LabelX32, LabelX37, LabelX34, LabelX20, LabelX25, LabelX28, LabelX33, LabelX36, LabelX58, LabelX190, LabelX57, LabelX56, LabelX53, LabelX52, LabelX49, LabelX50, LabelX55, LabelX54, LabelX45, LabelX48, LabelX47, LabelX46, LabelX106, LabelX110, LabelX112, LabelX102, LabelX101, LabelX99, LabelX96, LabelX93, LabelX107, LabelX111, LabelX109, LabelX103, LabelX100, LabelX98, LabelX95, LabelX92, LabelX108, LabelX105, LabelX104, LabelX97, LabelX94})

            GetTextBoxFontSettings({txtBorrowerID, TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtNoC_B, txtStreetC_B, txtBarangayC_B, txtNoP_B, txtStreetP_B, txtBarangayP_B, txtTIN_B, txtTelephone_B, txtPlus63, TextBoxX2, txtMobile_B, txtMobile_B2, txtSSS_B, txtEmail_B, txtPath_B, txtEmployerAddress_B, txtEmployerTelephone_B, txtSupervisor_B, txtBusinessAddress_B, txtBusinessName_B, txtBusinessTelephone_B, txtArea_B, txtOtherIncome_B, txtCreditor_1, txtCreditor_2, txtCreditor_3, txtNatureLoan_1, txtNatureLoan_2, txtNatureLoan_3, txtCreditRemarks_1, txtCreditRemarks_2, txtCreditRemarks_3, txtBank_1, txtBank_2, txtBank_3, txtBranch_1, txtBranch_2, txtBranch_3, txtSA_1, txtSA_2, txtSA_3, txtOpened_1, txtOpened_2, txtOpened_3, txtBankRemarks_1, txtBankRemarks_2, txtBankRemarks_3, txtLocation_1, txtLocation_2, txtLocation_3, txtTCT_1, txtTCT_2, txtTCT_3, txtAcquired_1, txtAcquired_2, txtAcquired_3, txtPropertiesRemarks_1, txtPropertiesRemarks_2, txtPropertiesRemarks_3, txtVehicle_1, txtVehicle_2, txtVehicle_3, txtWhomAcquired_1, txtWhomAcquired_2, txtWhomAcquired_3, txtWhenAcquired_1, txtWhenAcquired_2, txtWhenAcquired_3, txtVehicleRemarks_1, txtVehicleRemarks_2, txtVehicleRemarks_3, txtHomeAppliances_1, txtHomeAppliances_2, txtReference_1, txtReference_2, txtReference_3, txtReferenceAddress_1, txtReferenceAddress_2, txtReferenceAddress_3, txtReferenceContact_1, txtReferenceContact_2, txtReferenceContact_3, txtCertificateNo, txtPlaceIssue, txtAgentContact, txtMarketingContact, txtWalkInOthers, txtDealersContact, TxtFirstN_S, TxtMiddleN_S, TxtLastN_S, TxtFirstN_M, TxtMiddleN_M, TxtLastN_M, txtNoC_S, txtStreetC_S, txtBarangayC_S, txtNoP_S, txtStreetP_S, txtBarangayP_S, txtCitizenship_S, txtTIN_S, txtTelephone_S, txtSSS_S, TextBoxX1, txtMobile_S, txtTIN_S, txtSSS_S, txtEmail_S, txtPath_S, txtEmployerTelephone_S, txtSupervisor_S, txtEmployerAddress_S, txtBusinessName_S, txtBusinessAddress_S, txtBusinessTelephone_S, txtArea_S, txtOtherIncome_S})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxAddressC_B, cbxAddressP_B, cbxPlaceBirth_B, cbxCitizenship_B, cbxEmployer_B, cbxPosition_B, CbxPrefix_S, CbxPrefix_M, cbxSuffix_S, cbxSuffix_M, cbxAddressC_S, cbxAddressP_S, cbxPlaceBirth_S, cbxEmployer_S, cbxPosition_S, cbxNatureBusiness_B, cbxBusinessCenter})

            GetCheckComboBoxFontSettings({cbxNatureBusiness_B2, cbxNatureBusiness_S2})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, CbxPrefix_S, cbxSuffix_S, cbxAddressC_B, cbxAddressP_B, cbxPlaceBirth_B, cbxCitizenship_B, cbxEmployer_B, cbxPosition_B, cbxNatureBusiness_B, cbxAgentName, cbxMarketingName, cbxWalkInType, cbxDealerName, cbxBusinessCenter})

            GetCheckBoxFontSettings({cbxMale_B, cbxFemale_B, cbxSingle_B, cbxMarried_B, cbxSeparated_B, cbxWidowed_B, cbxOwned_B, cbxFree_B, cbxRented_B, cbxCasual_B, cbxTemporary_B, cbxPermanent_B, cbxYearHired, cbxYearFranchise, cbxSA_1, cbxCA_1, cbxSA_2, cbxCA_2, cbxSA_3, cbxCA_3, cbxAgent, cbxMarketing, cbxWalkIn, cbxDealer, cbxMale_S, cbxFemale_S, cbxOwned_S, cbxFree_S, cbxRented_S, cbxCasual_S, cbxTemporary_S, cbxPermanent_S, cbxYearHired_S})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX156, LabelX5, LabelX163, LabelX165, LabelX167, LabelX168, LabelX166, LabelX164, LabelX157, LabelX189, LabelX159, LabelX161, LabelX160, LabelX162, LabelX158, LabelX169, LabelX176, LabelX178, LabelX180, LabelX179, LabelX177, LabelX171, LabelX173, LabelX175, LabelX174, LabelX172, LabelX170, LabelX184, LabelX181, LabelX182, LabelX183, LabelX185, LabelX186, LabelX187, LabelX188, LabelX42, LabelX43, LabelX41, LabelX89})

            GetDateTimeInputFontSettings({DtpBirth_B, dtpHired_B, dtpExpiry_B, dtpYear_1, dtpYear_2, dtpYear_3, dtpIssue, DtpBirth_S, dtpHired_S, dtpExpiry_S})

            GetDoubleInputFontSettings({dRent_B, dCapital_B, dOtherIncome_B, dBusinessIncome_B, dMonthly_B, dAmountGranted_1, dBalance_1, dAmountGranted_2, dBalance_2, dAmountGranted_3, dBalance_3, dAverageBalance_1, dPresentBalance_1, dAverageBalance_2, dPresentBalance_2, dAverageBalance_3, dPresentBalance_3, dArea_1, dArea_2, dArea_3, dRent_S, dMonthly_S, dBusinessIncome_S, dCapital_S, dOtherIncome_S})

            GetIntegerInputFontSettings({iNoEmployees_S, iYrsOperation_S, iOutlet_S, dTerm_1, dTerm_2, dTerm_3, iYrsOperation_B, iNoEmployees_B, iOutlet_B})

            GetButtonFontSettings({btnSave_F, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach, btnID, btnAddD_B, btnExisting_B, btnHit, btnBrowse_B, btnDefault, btnID_S, btnBrowse_S, btnDefault_S})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Borrower - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Borrower", lblTitle.Text)
    End Sub

    Private Sub GetBorrower()
        If Me.FormBorderStyle = FormBorderStyle.FixedDialog Then
            Exit Sub
        End If
        txtBorrowerID.Text = DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', 'I', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_borrower WHERE branch_id = '{0}';", Branch_ID))
    End Sub

    Private Sub BtnAddD_B_Click(sender As Object, e As EventArgs) Handles btnAddD_B.Click
        Dim Dependents As New FrmBorrowerDependents
        With Dependents
            .TxtFirstN_1.Text = FirstN_1
            .TxtMiddleN_1.Text = MiddleN_1
            .TxtLastN_1.Text = LastN_1
            .txtGrade_1.Text = Grade_1
            .txtSchool_1.Text = School_1
            .txtSchoolAddress_1.Text = SchoolAddress_1
            .TxtFirstN_2.Text = FirstN_2
            .TxtMiddleN_2.Text = MiddleN_2
            .TxtLastN_2.Text = LastN_2
            .txtGrade_2.Text = Grade_2
            .txtSchool_2.Text = School_2
            .txtSchoolAddress_2.Text = SchoolAddress_2
            .TxtFirstN_3.Text = FirstN_3
            .TxtMiddleN_3.Text = MiddleN_3
            .TxtLastN_3.Text = LastN_3
            .txtGrade_3.Text = Grade_3
            .txtSchool_3.Text = School_3
            .txtSchoolAddress_3.Text = SchoolAddress_3
            .TxtFirstN_4.Text = FirstN_4
            .TxtMiddleN_4.Text = MiddleN_4
            .TxtLastN_4.Text = LastN_4
            .txtGrade_4.Text = Grade_4
            .txtSchool_4.Text = School_4
            .txtSchoolAddress_4.Text = SchoolAddress_4
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnID_Click(sender As Object, e As EventArgs) Handles btnID.Click
        Dim ID As New FrmID
        With ID
            .TotalImage_TIN = TotalImage_TIN
            .TotalImage_SSS = TotalImage_SSS
            .TotalImage_GSIS = TotalImage_GSIS
            .TotalImage_PhilHealth = TotalImage_PhilHealth
            .TotalImage_Senior = TotalImage_Senior
            .TotalImage_UMID = TotalImage_UMID
            .TotalImage_SEC = TotalImage_SEC
            .TotalImage_DTI = TotalImage_DTI
            .TotalImage_CDA = TotalImage_CDA
            .TotalImage_Cooperative = TotalImage_Cooperative
            .TotalImage_Drivers = TotalImage_Drivers
            .TotalImage_VIN = TotalImage_VIN
            .TotalImage_Passport = TotalImage_Passport
            .TotalImage_PRC = TotalImage_PRC
            .TotalImage_NBI = TotalImage_NBI
            .TotalImage_Police = TotalImage_Police
            .TotalImage_Postal = TotalImage_Postal
            .TotalImage_Barangay = TotalImage_Barangay
            .TotalImage_OWWA = TotalImage_OWWA
            .TotalImage_OFW = TotalImage_OFW
            .TotalImage_Seaman = TotalImage_Seaman
            .TotalImage_PNP = TotalImage_PNP
            .TotalImage_AFP = TotalImage_AFP
            .TotalImage_HDMF = TotalImage_HDMF
            .TotalImage_PWD = TotalImage_PWD
            .TotalImage_DSWD = TotalImage_DSWD
            .TotalImage_ACR = TotalImage_ACR
            .TotalImage_DTI_Business = TotalImage_DTI_Business
            .TotalImage_IBP = TotalImage_IBP
            .TotalImage_FireArms = TotalImage_FireArms
            .TotalImage_Government = TotalImage_Government
            .TotalImage_Diplomat = TotalImage_Diplomat
            .TotalImage_National = TotalImage_National
            .TotalImage_Work = TotalImage_Work
            .TotalImage_GOCC = TotalImage_GOCC
            .TotalImage_PLRA = TotalImage_PLRA
            .TotalImage_Major = TotalImage_Major
            .TotalImage_Media = TotalImage_Media
            .TotalImage_Student = TotalImage_Student
            .TotalImage_SIRV = TotalImage_SIRV
            If btnSave_F.Text = "Update" Or btnModify.Enabled = True Then
                .btnAttach_TIN.Enabled = True
                .btnAttach_SSS.Enabled = True
                .btnAttach_GSIS.Enabled = True
                .btnAttach_PhilHealth.Enabled = True
                .btnAttach_Senior.Enabled = True
                .btnAttach_UMID.Enabled = True
                .btnAttach_SEC.Enabled = True
                .btnAttach_DTI.Enabled = True
                .btnAttach_CDA.Enabled = True
                .btnAttach_Cooperative.Enabled = True
                .btnAttach_Drivers.Enabled = True
                .btnAttach_VIN.Enabled = True
                .btnAttach_Passport.Enabled = True
                .btnAttach_PRC.Enabled = True
                .btnAttach_NBI.Enabled = True
                .btnAttach_Police.Enabled = True
                .btnAttach_Postal.Enabled = True
                .btnAttach_Barangay.Enabled = True
                .btnAttach_OWWA.Enabled = True
                .btnAttach_OFW.Enabled = True
                .btnAttach_Seaman.Enabled = True
                .btnAttach_PNP.Enabled = True
                .btnAttach_AFP.Enabled = True
                .btnAttach_HDMF.Enabled = True
                .btnAttach_PWD.Enabled = True
                .btnAttach_DSWD.Enabled = True
                .btnAttach_ACR.Enabled = True
                .btnAttach_DTI_Business.Enabled = True
                .btnAttach_IBP.Enabled = True
                .btnAttach_FireArms.Enabled = True
                .btnAttach_Government.Enabled = True
                .btnAttach_Diplomat.Enabled = True
                .btnAttach_National.Enabled = True
                .btnAttach_Work.Enabled = True
                .btnAttach_GOCC.Enabled = True
                .btnAttach_PLRA.Enabled = True
                .btnAttach_Major.Enabled = True
                .btnAttach_Media.Enabled = True
                .btnAttach_Student.Enabled = True
                .btnAttach_SIRV.Enabled = True
            End If
            .BorrowerID = txtBorrowerID.Text
            .txtTIN.Text = txtTIN_B.Text
            .txtSSS.Text = txtSSS_B.Text
            .txtGSIS.Text = GSIS
            .txtPhilHealth.Text = PhilHealth
            .txtSenior.Text = Senior
            .txtUMID.Text = UMID
            .txtSEC.Text = SEC
            .txtDTI.Text = DTI
            .txtCDA.Text = CDA
            .txtCooperative.Text = Cooperative
            .txtDrivers.Text = Drivers
            .txtVIN.Text = VIN
            .txtPassport.Text = Passport
            .txtPRC.Text = PRC
            .txtNBI.Text = NBI
            .txtPolice.Text = Police
            .txtPostal.Text = Postal
            .txtBarangay.Text = Barangay
            .txtOWWA.Text = OWWA
            .txtOFW.Text = OFW
            .txtSeaman.Text = Seaman
            .txtPNP.Text = PNP
            .txtAFP.Text = AFP
            .txtHDMF.Text = HDMF
            .txtPWD.Text = PWD
            .txtDSWD.Text = DSWD
            .txtACR.Text = ACR
            .txtDTI_Business.Text = DTI_Business
            .txtIBP.Text = IBP
            .txtFireArms.Text = FireArms
            .txtGovernment.Text = Government
            .txtDiplomat.Text = Diplomat
            .txtNational.Text = National
            .txtWork.Text = Work
            .txtGOCC.Text = GOCC
            .txtPLRA.Text = PLRA
            .txtMajor.Text = Major
            .txtMedia.Text = Media
            .txtStudent.Text = Student
            .txtSIRV.Text = SIRV
            If .ShowDialog = DialogResult.OK Then
                txtTIN_B.Text = .txtTIN.Text
                txtSSS_B.Text = .txtSSS.Text
                GSIS = .txtGSIS.Text
                PhilHealth = .txtPhilHealth.Text
                Senior = .txtSenior.Text
                UMID = .txtUMID.Text
                SEC = .txtSEC.Text
                DTI = .txtDTI.Text
                CDA = .txtCDA.Text
                Cooperative = .txtCooperative.Text
                Drivers = .txtDrivers.Text
                dDrivers = FormatDatePicker(.dtpDrivers)
                VIN = .txtVIN.Text
                dVIN = FormatDatePicker(.dtpVIN)
                Passport = .txtPassport.Text
                dPassport = FormatDatePicker(.dtpPassport)
                PRC = .txtPRC.Text
                dPRC = FormatDatePicker(.dtpPRC)
                NBI = .txtNBI.Text
                dNBI = FormatDatePicker(.dtpNBI)
                Police = .txtPolice.Text
                dPolice = FormatDatePicker(.dtpPolice)
                Postal = .txtPostal.Text
                dPostal = FormatDatePicker(.dtpPostal)
                Barangay = .txtBarangay.Text
                dBarangay = FormatDatePicker(.dtpBarangay)
                OWWA = .txtOWWA.Text
                dOWWA = FormatDatePicker(.dtpOWWA)
                OFW = .txtOFW.Text
                dOFW = FormatDatePicker(.dtpOFW)
                Seaman = .txtSeaman.Text
                dSeaman = FormatDatePicker(.dtpSeaman)
                PNP = .txtPNP.Text
                dPNP = FormatDatePicker(.dtpPNP)
                AFP = .txtAFP.Text
                dAFP = FormatDatePicker(.dtpAFP)
                HDMF = .txtHDMF.Text
                dHDMF = FormatDatePicker(.dtpHDMF)
                PWD = .txtPWD.Text
                dPWD = FormatDatePicker(.dtpPWD)
                DSWD = .txtDSWD.Text
                dDSWD = FormatDatePicker(.dtpDSWD)
                ACR = .txtACR.Text
                dACR = FormatDatePicker(.dtpACR)
                DTI_Business = .txtDTI_Business.Text
                dDTI_Business = FormatDatePicker(.dtpDTI_Business)
                IBP = .txtIBP.Text
                dIBP = FormatDatePicker(.dtpIBP)
                FireArms = .txtFireArms.Text
                dFireArms = FormatDatePicker(.dtpFireArms)
                Government = .txtGovernment.Text
                dGovernment = FormatDatePicker(.dtpGovernment)
                Diplomat = .txtDiplomat.Text
                dDiplomat = FormatDatePicker(.dtpDiplomat)
                National = .txtNational.Text
                dNational = FormatDatePicker(.dtpNational)
                Work = .txtWork.Text
                dWork = FormatDatePicker(.dtpWork)
                GOCC = .txtGOCC.Text
                dGOCC = FormatDatePicker(.dtpGOCC)
                PLRA = .txtPLRA.Text
                dPLRA = FormatDatePicker(.dtpPLRA)
                Major = .txtMajor.Text
                dMajor = FormatDatePicker(.dtpMajor)
                Media = .txtMedia.Text
                dMedia = FormatDatePicker(.dtpMedia)
                Student = .txtStudent.Text
                dStudent = FormatDatePicker(.dtpStudent)
                SIRV = .txtSIRV.Text
                dSIRV = FormatDatePicker(.dtpSIRV)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Public Sub Clear()
        'BORROWER
        PanelEx2.Enabled = True
        PanelEx4.Enabled = True
        PanelEx11.Enabled = True
        PanelEx12.Enabled = True
        PanelEx13.Enabled = True
        PanelEx14.Enabled = True
        PanelEx5.Enabled = True
        PanelEx8.Enabled = True
        btnHit.Visible = False

        GetBorrower()
        DependentID_1 = ""
        DependentID_2 = ""
        DependentID_3 = ""
        DependentID_4 = ""
        SpouseID = ""
        CoMakerID_1 = ""
        CoMakerID_2 = ""
        btnExisting_B.Enabled = True
        txtPath_B.Text = ""
        txtPath_S.Text = ""
        CbxPrefix_B.Text = ""
        TxtFirstN_B.Text = ""
        TxtMiddleN_B.Text = ""
        TxtLastN_B.Text = ""
        cbxSuffix_B.Text = ""
        txtNoC_B.Text = ""
        txtStreetC_B.Text = ""
        txtBarangayC_B.Text = ""
        cbxAddressC_B.Text = ""
        txtNoP_B.Text = ""
        txtStreetP_B.Text = ""
        txtBarangayP_B.Text = ""
        cbxAddressP_B.Text = ""
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
        txtMobile_B2.Text = ""
        txtEmail_B.Text = ""
        cbxOwned_B.Checked = False
        cbxFree_B.Checked = False
        cbxRented_B.Checked = False
        Try
            pb_B.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_B.Image = Nothing
        End Try
        cbxEmployer_B.Text = ""
        txtBusinessName_B.Text = ""
        txtCreditor_1.Text = ""
        txtBank_1.Text = ""
        txtLocation_1.Text = ""
        txtVehicle_1.Text = ""
        txtHomeAppliances_1.Text = ""
        txtReference_1.Text = ""
        txtCertificateNo.Text = ""
        cbxAgent.Checked = False
        cbxMarketing.Checked = False
        cbxWalkIn.Checked = False
        cbxDealer.Checked = False
        btnSave.Enabled = True
        btnSave_F.Enabled = True
        btnSave.Text = "Save Draft"
        btnSave_F.Text = "&Save"
        btnDelete.Enabled = False
        btnModify.Enabled = False
        btnAttach.Enabled = False
        ChangeBorrowerPic = False
        ChangeSpousePic = False

        TotalImage = 0
        TotalImage_TIN = 0
        TotalImage_SSS = 0
        TotalImage_GSIS = 0
        TotalImage_PhilHealth = 0
        TotalImage_Senior = 0
        TotalImage_UMID = 0
        TotalImage_SEC = 0
        TotalImage_DTI = 0
        TotalImage_CDA = 0
        TotalImage_Cooperative = 0
        TotalImage_Drivers = 0
        TotalImage_VIN = 0
        TotalImage_Passport = 0
        TotalImage_PRC = 0
        TotalImage_NBI = 0
        TotalImage_Police = 0
        TotalImage_Postal = 0
        TotalImage_Barangay = 0
        TotalImage_OWWA = 0
        TotalImage_OFW = 0
        TotalImage_Seaman = 0
        TotalImage_PNP = 0
        TotalImage_AFP = 0
        TotalImage_HDMF = 0
        TotalImage_PWD = 0
        TotalImage_DSWD = 0
        TotalImage_ACR = 0
        TotalImage_DTI_Business = 0
        TotalImage_IBP = 0
        TotalImage_FireArms = 0
        TotalImage_Government = 0
        TotalImage_Diplomat = 0
        TotalImage_National = 0
        TotalImage_Work = 0
        TotalImage_GOCC = 0
        TotalImage_PLRA = 0
        TotalImage_Major = 0
        TotalImage_Media = 0
        TotalImage_Student = 0
        TotalImage_SIRV = 0

        'SPOUSE
        TotalImage_TIN_S = 0
        TotalImage_SSS_S = 0
        TotalImage_GSIS_S = 0
        TotalImage_PhilHealth_S = 0
        TotalImage_Senior_S = 0
        TotalImage_UMID_S = 0
        TotalImage_SEC_S = 0
        TotalImage_DTI_S = 0
        TotalImage_CDA_S = 0
        TotalImage_Cooperative_S = 0
        TotalImage_Drivers_S = 0
        TotalImage_VIN_S = 0
        TotalImage_Passport_S = 0
        TotalImage_PRC_S = 0
        TotalImage_NBI_S = 0
        TotalImage_Police_S = 0
        TotalImage_Postal_S = 0
        TotalImage_Barangay_S = 0
        TotalImage_OWWA_S = 0
        TotalImage_OFW_S = 0
        TotalImage_Seaman_S = 0
        TotalImage_PNP_S = 0
        TotalImage_AFP_S = 0
        TotalImage_HDMF_S = 0
        TotalImage_PWD_S = 0
        TotalImage_DSWD_S = 0
        TotalImage_ACR_S = 0
        TotalImage_DTI_Business_S = 0
        TotalImage_IBP_S = 0
        TotalImage_FireArms_S = 0
        TotalImage_Government_S = 0
        TotalImage_Diplomat_S = 0
        TotalImage_National_S = 0
        TotalImage_Work_S = 0
        TotalImage_GOCC_S = 0
        TotalImage_PLRA_S = 0
        TotalImage_Major_S = 0
        TotalImage_Media_S = 0
        TotalImage_Student_S = 0
        TotalImage_SIRV_S = 0

        For x As Integer = 0 To cbxNatureBusiness_B2.Properties.Items.Count - 1
            cbxNatureBusiness_B2.Properties.Items.Item(x).CheckState = CheckState.Unchecked
        Next
        For x As Integer = 0 To cbxNatureBusiness_S2.Properties.Items.Count - 1
            cbxNatureBusiness_S2.Properties.Items.Item(x).CheckState = CheckState.Unchecked
        Next

        'SPOUSE
        CbxPrefix_S.Text = ""
        TxtFirstN_S.Text = ""
        TxtMiddleN_S.Text = ""
        TxtLastN_S.Text = ""
        cbxSuffix_S.Text = ""
        CbxPrefix_M.Text = ""
        TxtFirstN_M.Text = ""
        TxtMiddleN_M.Text = ""
        TxtLastN_M.Text = ""
        cbxSuffix_M.Text = ""
        txtNoC_S.Text = ""
        txtStreetC_S.Text = ""
        txtBarangayC_S.Text = ""
        cbxAddressC_S.Text = ""
        txtNoP_S.Text = ""
        txtStreetP_S.Text = ""
        txtBarangayP_S.Text = ""
        cbxAddressP_S.Text = ""
        DtpBirth_S.CustomFormat = ""
        cbxPlaceBirth_S.Text = ""
        cbxMale_S.Checked = False
        cbxFemale_S.Checked = False
        txtCitizenship_S.Text = ""
        txtTIN_S.Text = ""
        txtTelephone_S.Text = ""
        txtSSS_S.Text = ""
        txtMobile_S.Text = ""
        txtEmail_S.Text = ""
        cbxOwned_S.Checked = False
        cbxFree_S.Checked = False
        cbxRented_S.Checked = False
        Try
            pb_S.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_S.Image = Nothing
        End Try
        cbxEmployer_S.Text = ""
        txtBusinessName_S.Text = ""
        txtBusinessName_S.Tag = ""
        txtBusinessAddress_S.Tag = ""
        txtBusinessTelephone_S.Tag = ""
        cbxNatureBusiness_S.Tag = ""
        iYrsOperation_S.Tag = 0
        dBusinessIncome_S.Tag = 0
        iNoEmployees_S.Tag = 0
        dCapital_S.Tag = 0
        txtArea_S.Tag = ""
        dtpExpiry_S.Tag = ""
        iOutlet_S.Tag = 0
        dOtherIncome_S.Tag =
        txtOtherIncome_S.Tag = ""

        '*** I D E N T I F I C A T I O N ***
        GSIS = ""
        PhilHealth = ""
        Senior = ""
        UMID = ""
        SEC = ""
        DTI = ""
        CDA = ""
        Cooperative = ""
        Drivers = ""
        dDrivers = ""
        VIN = ""
        dVIN = ""
        Passport = ""
        dPassport = ""
        PRC = ""
        dPRC = ""
        NBI = ""
        dNBI = ""
        Police = ""
        dPolice = ""
        Postal = ""
        dPostal = ""
        Barangay = ""
        dBarangay = ""
        OWWA = ""
        dOWWA = ""
        OFW = ""
        dOFW = ""
        Seaman = ""
        dSeaman = ""
        PNP = ""
        dPNP = ""
        AFP = ""
        dAFP = ""
        HDMF = ""
        dHDMF = ""
        PWD = ""
        dPWD = ""
        DSWD = ""
        dDSWD = ""
        ACR = ""
        dACR = ""
        DTI_Business = ""
        dDTI_Business = ""
        IBP = ""
        dIBP = ""
        FireArms = ""
        dFireArms = ""
        Government = ""
        dGovernment = ""
        Diplomat = ""
        dDiplomat = ""
        National = ""
        dNational = ""
        Work = ""
        dWork = ""
        GOCC = ""
        dGOCC = ""
        PLRA = ""
        dPLRA = ""
        Major = ""
        dMajor = ""
        Media = ""
        dMedia = ""
        Student = ""
        dStudent = ""
        SIRV = ""
        dSIRV = ""
        'SPOUSE
        GSIS_S = ""
        PhilHealth_S = ""
        Senior_S = ""
        UMID_S = ""
        SEC_S = ""
        DTI_S = ""
        CDA_S = ""
        Cooperative_S = ""
        Drivers_S = ""
        dDrivers_S = ""
        VIN_S = ""
        dVIN_S = ""
        Passport_S = ""
        dPassport_S = ""
        PRC_S = ""
        dPRC_S = ""
        NBI_S = ""
        dNBI_S = ""
        Police_S = ""
        dPolice_S = ""
        Postal_S = ""
        dPostal_S = ""
        Barangay_S = ""
        dBarangay_S = ""
        OWWA_S = ""
        dOWWA_S = ""
        OFW_S = ""
        dOFW_S = ""
        Seaman_S = ""
        dSeaman_S = ""
        PNP_S = ""
        dPNP_S = ""
        AFP_S = ""
        dAFP_S = ""
        HDMF_S = ""
        dHDMF_S = ""
        PWD_S = ""
        dPWD_S = ""
        DSWD_S = ""
        dDSWD_S = ""
        ACR_S = ""
        dACR_S = ""
        DTI_Business_S = ""
        dDTI_Business_S = ""
        IBP_S = ""
        dIBP_S = ""
        FireArms_S = ""
        dFireArms_S = ""
        Government_S = ""
        dGovernment_S = ""
        Diplomat_S = ""
        dDiplomat_S = ""
        National_S = ""
        dNational_S = ""
        Work_S = ""
        dWork_S = ""
        GOCC_S = ""
        dGOCC_S = ""
        PLRA_S = ""
        dPLRA_S = ""
        Major_S = ""
        dMajor_S = ""
        Media_S = ""
        dMedia_S = ""
        Student_S = ""
        dStudent_S = ""
        SIRV_S = ""
        dSIRV_S = ""
        '*** I D E N T I F I C A T I O N ***

        '*** D E P E N D E N T S ***
        Prefix_1 = ""
        FirstN_1 = ""
        MiddleN_1 = ""
        LastN_1 = ""
        Suffix_1 = ""
        Birth_1 = ""
        Grade_1 = ""
        School_1 = ""
        SchoolAddress_1 = ""
        Prefix_2 = ""
        FirstN_2 = ""
        MiddleN_2 = ""
        LastN_2 = ""
        Suffix_2 = ""
        Birth_2 = ""
        Grade_2 = ""
        School_2 = ""
        SchoolAddress_2 = ""
        Prefix_3 = ""
        FirstN_3 = ""
        MiddleN_3 = ""
        LastN_3 = ""
        Suffix_3 = ""
        Birth_3 = ""
        Grade_3 = ""
        School_3 = ""
        SchoolAddress_3 = ""
        Prefix_4 = ""
        FirstN_4 = ""
        MiddleN_4 = ""
        LastN_4 = ""
        Suffix_4 = ""
        Birth_4 = ""
        Grade_4 = ""
        School_4 = ""
        SchoolAddress_4 = ""
        cbxBusinessCenter.Text = ""
        '*** D E P E N D E N T S ***
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If tabSpouse.Visible = True Then
                btnBack.Enabled = True
                btnNext.Enabled = True
            Else
                btnBack.Enabled = True
                btnNext.Enabled = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            btnBack.Enabled = True
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabFinancial
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If tabSpouse.Visible = True Then
                SuperTabControl1.SelectedTab = tabSpouse
            End If
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabFinancial
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabBorrower
        End If
    End Sub

    'Borrower
    Private Sub CbxSingle_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSingle_B.CheckedChanged
        If cbxSingle_B.Checked = True Then
            cbxMarried_B.Checked = False
            cbxSeparated_B.Checked = False
            cbxWidowed_B.Checked = False

            tabSpouse.Visible = False
        End If
    End Sub

    Private Sub CbxMarried_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarried_B.CheckedChanged
        If cbxMarried_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxSeparated_B.Checked = False
            cbxWidowed_B.Checked = False

            tabSpouse.Visible = True
        Else
            tabSpouse.Visible = False
        End If
    End Sub

    Private Sub CbxSeparated_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSeparated_B.CheckedChanged
        If cbxSeparated_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxMarried_B.Checked = False
            cbxWidowed_B.Checked = False

            tabSpouse.Visible = True
        Else
            tabSpouse.Visible = False
        End If
    End Sub

    Private Sub CbxWidowed_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWidowed_B.CheckedChanged
        If cbxWidowed_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxMarried_B.Checked = False
            cbxSeparated_B.Checked = False

            tabSpouse.Visible = False
        End If
    End Sub

    Private Sub CbxMale_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMale_B.CheckedChanged
        If cbxMale_B.Checked = True Then
            cbxFemale_B.Checked = False
            cbxFemale_S.Checked = True
        End If
    End Sub

    Private Sub CbxFemale_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFemale_B.CheckedChanged
        If cbxFemale_B.Checked = True Then
            cbxMale_B.Checked = False
            cbxMale_S.Checked = True
        End If
    End Sub

    Private Sub CbxOwned_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOwned_B.CheckedChanged
        If cbxOwned_B.Checked = True Then
            cbxFree_B.Checked = False
            cbxRented_B.Checked = False

            dRent_B.Enabled = False
            cbxOwned_S.Checked = True
        End If
    End Sub

    Private Sub CbxFree_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFree_B.CheckedChanged
        If cbxFree_B.Checked = True Then
            cbxOwned_B.Checked = False
            cbxRented_B.Checked = False

            dRent_B.Enabled = False
            cbxFree_S.Checked = True
        End If
    End Sub

    Private Sub CbxRented_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRented_B.CheckedChanged
        If cbxRented_B.Checked = True Then
            cbxFree_B.Checked = False
            cbxOwned_B.Checked = False

            dRent_B.Enabled = True
            cbxRented_S.Checked = True

            dRent_B.Value = vRent_B
        Else
            dRent_B.Enabled = False
            cbxRented_S.Checked = False

            vRent_B = dRent_B.Value
            dRent_B.Value = 0
        End If
    End Sub

    Private Sub DRent_B_ValueChanged(sender As Object, e As EventArgs) Handles dRent_B.ValueChanged
        If cbxRented_B.Checked = True Then
            dRent_S.Value = dRent_B.Value
        End If
    End Sub

    Private Sub CbxCasual_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCasual_B.CheckedChanged
        If cbxCasual_B.Checked = True Then
            cbxTemporary_B.Checked = False
            cbxPermanent_B.Checked = False
        End If
    End Sub

    Private Sub CbxTemporary_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTemporary_B.CheckedChanged
        If cbxTemporary_B.Checked = True Then
            cbxCasual_B.Checked = False
            cbxPermanent_B.Checked = False
        End If
    End Sub

    Private Sub CbxPermanent_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPermanent_B.CheckedChanged
        If cbxPermanent_B.Checked = True Then
            cbxCasual_B.Checked = False
            cbxTemporary_B.Checked = False
        End If
    End Sub

    'Spouse
    Private Sub CbxMale_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMale_S.CheckedChanged
        If cbxMale_S.Checked = True Then
            cbxFemale_S.Checked = False
        End If
    End Sub

    Private Sub CbxFemale_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFemale_S.CheckedChanged
        If cbxFemale_S.Checked = True Then
            cbxMale_S.Checked = False
        End If
    End Sub

    Private Sub CbxOwned_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOwned_S.CheckedChanged
        If cbxOwned_S.Checked = True Then
            cbxFree_S.Checked = False
            cbxRented_S.Checked = False

            dRent_S.Enabled = False
        End If
    End Sub

    Private Sub CbxFree_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFree_S.CheckedChanged
        If cbxFree_S.Checked = True Then
            cbxOwned_S.Checked = False
            cbxRented_S.Checked = False

            dRent_S.Enabled = False
        End If
    End Sub

    Private Sub CbxRented_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRented_S.CheckedChanged
        If cbxRented_S.Checked = True Then
            cbxFree_S.Checked = False
            cbxOwned_S.Checked = False

            dRent_S.Enabled = True

            dRent_S.Value = vRent_S
        Else
            dRent_S.Enabled = False

            vRent_S = dRent_S.Value
            dRent_S.Value = 0
        End If
    End Sub

    Private Sub CbxCasual_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCasual_S.CheckedChanged
        If cbxCasual_S.Checked = True Then
            cbxTemporary_S.Checked = False
            cbxPermanent_S.Checked = False
        End If
    End Sub

    Private Sub CbxTemporary_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTemporary_S.CheckedChanged
        If cbxTemporary_S.Checked = True Then
            cbxCasual_S.Checked = False
            cbxPermanent_S.Checked = False
        End If
    End Sub

    Private Sub CbxPermanent_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPermanent_S.CheckedChanged
        If cbxPermanent_S.Checked = True Then
            cbxCasual_S.Checked = False
            cbxTemporary_S.Checked = False
        End If
    End Sub

    Private Sub Check_HIT()
        If TxtFirstN_B.Text <> "" And TxtLastN_B.Text <> "" And btnSave_F.Text = "&Save" Then
            Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_borrower WHERE ((FirstN_B LIKE '%{0}%' AND LastN_B LIKE '%{1}%') OR (Birth_B LIKE '%{2}%' AND LastN_B LIKE '%{1}%') OR (PlaceBirth_B = '{3}' AND LastN_B LIKE '%{1}%')) AND `status` = 'ACTIVE'", TxtFirstN_B.Text, TxtLastN_B.Text, FormatDatePicker(DtpBirth_B), If(cbxPlaceBirth_B.Text = "", "FALSE", cbxPlaceBirth_B.Text)))
            If Exist > 0 Then
                btnHit.Visible = True
            Else
                btnHit.Visible = False
            End If
        Else
            btnHit.Visible = False
        End If
    End Sub

#Region "Leaves"
    'Borrower
    Private Sub CbxPrefix_B_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_B.Leave
        CbxPrefix_B.Text = ReplaceText(CbxPrefix_B.Text.Trim)
    End Sub

    Private Sub TxtFirstN_B_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_B.Leave
        TxtFirstN_B.Text = ReplaceText(TxtFirstN_B.Text.Trim)
        Check_HIT()
    End Sub

    Private Sub TxtMiddleN_B_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_B.Leave
        TxtMiddleN_B.Text = ReplaceText(TxtMiddleN_B.Text.Trim)
    End Sub

    Private Sub TxtLastN_B_Leave(sender As Object, e As EventArgs) Handles TxtLastN_B.Leave
        TxtLastN_B.Text = ReplaceText(TxtLastN_B.Text.Trim)
        Check_HIT()
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

    Private Sub TxtNoP_B_Leave(sender As Object, e As EventArgs) Handles txtNoP_B.Leave
        txtNoP_B.Text = ReplaceText(txtNoP_B.Text.Trim)
    End Sub

    Private Sub TxtStreetP_B_Leave(sender As Object, e As EventArgs) Handles txtStreetP_B.Leave
        txtStreetP_B.Text = ReplaceText(txtStreetP_B.Text.Trim)
    End Sub

    Private Sub TxtBarangayP_B_Leave(sender As Object, e As EventArgs) Handles txtBarangayP_B.Leave
        txtBarangayP_B.Text = ReplaceText(txtBarangayP_B.Text.Trim)
    End Sub

    Private Sub CbxAddressP_B_Leave(sender As Object, e As EventArgs) Handles cbxAddressP_B.Leave
        cbxAddressP_B.Text = ReplaceText(cbxAddressP_B.Text.Trim)
    End Sub

    Private Sub CbxPlaceBirth_B_Leave(sender As Object, e As EventArgs) Handles cbxPlaceBirth_B.Leave
        cbxPlaceBirth_B.Text = ReplaceText(cbxPlaceBirth_B.Text.Trim)
        Check_HIT()
    End Sub

    Private Sub CbxCitizenship_B_Leave(sender As Object, e As EventArgs) Handles cbxCitizenship_B.Leave
        cbxCitizenship_B.Text = ReplaceText(cbxCitizenship_B.Text.Trim)
    End Sub

    Private Sub TxtTIN_B_Leave(sender As Object, e As EventArgs) Handles txtTIN_B.Leave
        txtTIN_B.Text = ReplaceText(txtTIN_B.Text.Trim)
        If (txtTIN_B.Text.Length <> 9 And txtTIN_B.Text.Length > 0) Or (Not IsNumeric(txtTIN_B.Text) And txtTIN_B.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_B.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_B_Leave(sender As Object, e As EventArgs) Handles txtTelephone_B.Leave
        txtTelephone_B.Text = ReplaceText(txtTelephone_B.Text.Trim)
    End Sub

    Private Sub TxtSSS_B_Leave(sender As Object, e As EventArgs) Handles txtSSS_B.Leave
        txtSSS_B.Text = ReplaceText(txtSSS_B.Text.Trim)
        If (txtSSS_B.Text.Length <> 10 And txtSSS_B.Text.Length > 0) Or (Not IsNumeric(txtSSS_B.Text) And txtSSS_B.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_B.Focus()
        End If
    End Sub

    Private Sub TxtMobile_B_Leave(sender As Object, e As EventArgs) Handles txtMobile_B.Leave
        txtMobile_B.Text = ReplaceText(txtMobile_B.Text.Trim)
    End Sub

    Private Sub TxtMobile_B2_Leave(sender As Object, e As EventArgs) Handles txtMobile_B2.Leave
        txtMobile_B2.Text = ReplaceText(txtMobile_B2.Text.Trim)
    End Sub

    Private Sub TxtEmail_B_Leave(sender As Object, e As EventArgs) Handles txtEmail_B.Leave
        txtEmail_B.Text = ReplaceText(txtEmail_B.Text.Trim)
    End Sub

    Private Sub CbxEmployer_B_Leave(sender As Object, e As EventArgs) Handles cbxEmployer_B.Leave
        cbxEmployer_B.Text = ReplaceText(cbxEmployer_B.Text.Trim)
    End Sub

    Private Sub TxtEmployerAddress_B_Leave(sender As Object, e As EventArgs) Handles txtEmployerAddress_B.Leave
        txtEmployerAddress_B.Text = ReplaceText(txtEmployerAddress_B.Text.Trim)
    End Sub

    Private Sub TxtEmployerTelephone_B_Leave(sender As Object, e As EventArgs) Handles txtEmployerTelephone_B.Leave
        txtEmployerTelephone_B.Text = ReplaceText(txtEmployerTelephone_B.Text.Trim)
    End Sub

    Private Sub CbxPosition_B_Leave(sender As Object, e As EventArgs) Handles cbxPosition_B.Leave
        cbxPosition_B.Text = ReplaceText(cbxPosition_B.Text.Trim)
    End Sub

    Private Sub TxtSupervisor_B_Leave(sender As Object, e As EventArgs) Handles txtSupervisor_B.Leave
        txtSupervisor_B.Text = ReplaceText(txtSupervisor_B.Text.Trim)
    End Sub

    Private Sub TxtBusinessName_B_Leave(sender As Object, e As EventArgs) Handles txtBusinessName_B.Leave
        txtBusinessName_B.Text = ReplaceText(txtBusinessName_B.Text.Trim)
    End Sub

    Private Sub TxtBusinessAddress_B_Leave(sender As Object, e As EventArgs) Handles txtBusinessAddress_B.Leave
        txtBusinessAddress_B.Text = ReplaceText(txtBusinessAddress_B.Text.Trim)
    End Sub

    Private Sub TxtBusinessTelephone_B_Leave(sender As Object, e As EventArgs) Handles txtBusinessTelephone_B.Leave
        txtBusinessTelephone_B.Text = ReplaceText(txtBusinessTelephone_B.Text.Trim)
    End Sub

    Private Sub CbxNatureBusiness_B_Leave(sender As Object, e As EventArgs) Handles cbxNatureBusiness_B.Leave
        cbxNatureBusiness_B.Text = ReplaceText(cbxNatureBusiness_B.Text.Trim)
    End Sub

    Private Sub TxtArea_B_Leave(sender As Object, e As EventArgs) Handles txtArea_B.Leave
        txtArea_B.Text = ReplaceText(txtArea_B.Text.Trim)
    End Sub

    Private Sub TxtOtherIncome_B_Leave(sender As Object, e As EventArgs) Handles txtOtherIncome_B.Leave
        txtOtherIncome_B.Text = ReplaceText(txtOtherIncome_B.Text.Trim)
    End Sub

    Private Sub TxtCreditor_1_Leave(sender As Object, e As EventArgs) Handles txtCreditor_1.Leave
        txtCreditor_1.Text = ReplaceText(txtCreditor_1.Text.Trim)
    End Sub

    Private Sub TxtNatureLoan_1_Leave(sender As Object, e As EventArgs) Handles txtNatureLoan_1.Leave
        txtNatureLoan_1.Text = ReplaceText(txtNatureLoan_1.Text.Trim)
    End Sub

    Private Sub DCreditRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtCreditRemarks_1.Leave
        txtCreditRemarks_1.Text = ReplaceText(txtCreditRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtCreditor_2_Leave(sender As Object, e As EventArgs) Handles txtCreditor_2.Leave
        txtCreditor_2.Text = ReplaceText(txtCreditor_2.Text.Trim)
    End Sub

    Private Sub TxtNatureLoan_2_Leave(sender As Object, e As EventArgs) Handles txtNatureLoan_2.Leave
        txtNatureLoan_2.Text = ReplaceText(txtNatureLoan_2.Text.Trim)
    End Sub

    Private Sub DCreditRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtCreditRemarks_2.Leave
        txtCreditRemarks_2.Text = ReplaceText(txtCreditRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtCreditor_3_Leave(sender As Object, e As EventArgs) Handles txtCreditor_3.Leave
        txtCreditor_3.Text = ReplaceText(txtCreditor_3.Text.Trim)
    End Sub

    Private Sub TxtNatureLoan_3_Leave(sender As Object, e As EventArgs) Handles txtNatureLoan_3.Leave
        txtNatureLoan_3.Text = ReplaceText(txtNatureLoan_3.Text.Trim)
    End Sub

    Private Sub DCreditRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtCreditRemarks_3.Leave
        txtCreditRemarks_3.Text = ReplaceText(txtCreditRemarks_3.Text.Trim)
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

    Private Sub TxtBank_3_Leave(sender As Object, e As EventArgs) Handles txtBank_3.Leave
        txtBank_3.Text = ReplaceText(txtBank_3.Text.Trim)
    End Sub

    Private Sub TxtBranch_3_Leave(sender As Object, e As EventArgs) Handles txtBranch_3.Leave
        txtBranch_3.Text = ReplaceText(txtBranch_3.Text.Trim)
    End Sub

    Private Sub TxtSA_3_Leave(sender As Object, e As EventArgs) Handles txtSA_3.Leave
        txtSA_3.Text = ReplaceText(txtSA_3.Text.Trim)
    End Sub

    Private Sub TxtBankRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtBankRemarks_3.Leave
        txtBankRemarks_3.Text = ReplaceText(txtBankRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtLocation_1_Leave(sender As Object, e As EventArgs) Handles txtLocation_1.Leave
        txtLocation_1.Text = ReplaceText(txtLocation_1.Text.Trim)
    End Sub

    Private Sub TxtTCT_1_Leave(sender As Object, e As EventArgs) Handles txtTCT_1.Leave
        txtTCT_1.Text = ReplaceText(txtTCT_1.Text.Trim)
    End Sub

    Private Sub TxtAcquired_1_Leave(sender As Object, e As EventArgs) Handles txtAcquired_1.Leave
        txtAcquired_1.Text = ReplaceText(txtAcquired_1.Text.Trim)
    End Sub

    Private Sub TxtPropertiesRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtPropertiesRemarks_1.Leave
        txtPropertiesRemarks_1.Text = ReplaceText(txtPropertiesRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtLocation_2_Leave(sender As Object, e As EventArgs) Handles txtLocation_2.Leave
        txtLocation_2.Text = ReplaceText(txtLocation_2.Text.Trim)
    End Sub

    Private Sub TxtTCT_2_Leave(sender As Object, e As EventArgs) Handles txtTCT_2.Leave
        txtTCT_2.Text = ReplaceText(txtTCT_2.Text.Trim)
    End Sub

    Private Sub TxtAcquired_2_Leave(sender As Object, e As EventArgs) Handles txtAcquired_2.Leave
        txtAcquired_2.Text = ReplaceText(txtAcquired_2.Text.Trim)
    End Sub

    Private Sub TxtPropertiesRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtPropertiesRemarks_2.Leave
        txtPropertiesRemarks_2.Text = ReplaceText(txtPropertiesRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtLocation_3_Leave(sender As Object, e As EventArgs) Handles txtLocation_3.Leave
        txtLocation_3.Text = ReplaceText(txtLocation_3.Text.Trim)
    End Sub

    Private Sub TxtTCT_3_Leave(sender As Object, e As EventArgs) Handles txtTCT_3.Leave
        txtTCT_3.Text = ReplaceText(txtTCT_3.Text.Trim)
    End Sub

    Private Sub TxtAcquired_3_Leave(sender As Object, e As EventArgs) Handles txtAcquired_3.Leave
        txtAcquired_3.Text = ReplaceText(txtAcquired_3.Text.Trim)
    End Sub

    Private Sub TxtPropertiesRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtPropertiesRemarks_3.Leave
        txtPropertiesRemarks_3.Text = ReplaceText(txtPropertiesRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtVehicle_1_Leave(sender As Object, e As EventArgs) Handles txtVehicle_1.Leave
        txtVehicle_1.Text = ReplaceText(txtVehicle_1.Text.Trim)
    End Sub

    Private Sub TxtWhomAcquired_1_Leave(sender As Object, e As EventArgs) Handles txtWhomAcquired_1.Leave
        txtWhomAcquired_1.Text = ReplaceText(txtWhomAcquired_1.Text.Trim)
    End Sub

    Private Sub TxtVehicleRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtVehicleRemarks_1.Leave
        txtVehicleRemarks_1.Text = ReplaceText(txtVehicleRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtVehicle_2_Leave(sender As Object, e As EventArgs) Handles txtVehicle_2.Leave
        txtVehicle_2.Text = ReplaceText(txtVehicle_2.Text.Trim)
    End Sub

    Private Sub TxtWhomAcquired_2_Leave(sender As Object, e As EventArgs) Handles txtWhomAcquired_2.Leave
        txtWhomAcquired_2.Text = ReplaceText(txtWhomAcquired_2.Text.Trim)
    End Sub

    Private Sub TxtVehicleRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtVehicleRemarks_2.Leave
        txtVehicleRemarks_2.Text = ReplaceText(txtVehicleRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtVehicle_3_Leave(sender As Object, e As EventArgs) Handles txtVehicle_3.Leave
        txtVehicle_3.Text = ReplaceText(txtVehicle_3.Text.Trim)
    End Sub

    Private Sub TxtWhomAcquired_3_Leave(sender As Object, e As EventArgs) Handles txtWhomAcquired_3.Leave
        txtWhomAcquired_3.Text = ReplaceText(txtWhomAcquired_3.Text.Trim)
    End Sub

    Private Sub TxtVehicleRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtVehicleRemarks_3.Leave
        txtVehicleRemarks_3.Text = ReplaceText(txtVehicleRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtHomeAppliances_1_Leave(sender As Object, e As EventArgs) Handles txtHomeAppliances_1.Leave
        txtHomeAppliances_1.Text = ReplaceText(txtHomeAppliances_1.Text.Trim)
    End Sub

    Private Sub TxtHomeAppliances_2_Leave(sender As Object, e As EventArgs) Handles txtHomeAppliances_2.Leave
        txtHomeAppliances_2.Text = ReplaceText(txtHomeAppliances_2.Text.Trim)
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

    Private Sub TxtCertificateNo_Leave(sender As Object, e As EventArgs) Handles txtCertificateNo.Leave
        txtCertificateNo.Text = ReplaceText(txtCertificateNo.Text.Trim)
    End Sub

    Private Sub TxtPlaceIssue_Leave(sender As Object, e As EventArgs) Handles txtPlaceIssue.Leave
        txtPlaceIssue.Text = ReplaceText(txtPlaceIssue.Text.Trim)
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

    'Spouse
    Private Sub CbxPrefix_S_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_S.Leave
        CbxPrefix_S.Text = ReplaceText(CbxPrefix_S.Text.Trim)
    End Sub

    Private Sub TxtFirstN_S_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_S.Leave
        TxtFirstN_S.Text = ReplaceText(TxtFirstN_S.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_S_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_S.Leave
        TxtMiddleN_S.Text = ReplaceText(TxtMiddleN_S.Text.Trim)
    End Sub

    Private Sub TxtLastN_S_Leave(sender As Object, e As EventArgs) Handles TxtLastN_S.Leave
        TxtLastN_S.Text = ReplaceText(TxtLastN_S.Text.Trim)
    End Sub

    Private Sub CbxSuffix_S_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_S.Leave
        cbxSuffix_S.Text = ReplaceText(cbxSuffix_S.Text.Trim)
    End Sub

    Private Sub CbxPrefix_M_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_M.Leave
        CbxPrefix_M.Text = ReplaceText(CbxPrefix_M.Text.Trim)
    End Sub

    Private Sub TxtFirstN_M_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_M.Leave
        TxtFirstN_M.Text = ReplaceText(TxtFirstN_M.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_M_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_M.Leave
        TxtMiddleN_M.Text = ReplaceText(TxtMiddleN_M.Text.Trim)
    End Sub

    Private Sub TxtLastN_M_Leave(sender As Object, e As EventArgs) Handles TxtLastN_M.Leave
        TxtLastN_M.Text = ReplaceText(TxtLastN_M.Text.Trim)
    End Sub

    Private Sub CbxSuffix_M_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_M.Leave
        cbxSuffix_M.Text = ReplaceText(cbxSuffix_M.Text.Trim)
    End Sub

    Private Sub TxtNoC_S_Leave(sender As Object, e As EventArgs) Handles txtNoC_S.Leave
        txtNoC_S.Text = ReplaceText(txtNoC_S.Text.Trim)
    End Sub

    Private Sub TxtStreetC_S_Leave(sender As Object, e As EventArgs) Handles txtStreetC_S.Leave
        txtStreetC_S.Text = ReplaceText(txtStreetC_S.Text.Trim)
    End Sub

    Private Sub TxtBarangayC_S_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_S.Leave
        txtBarangayC_S.Text = ReplaceText(txtBarangayC_S.Text.Trim)
    End Sub

    Private Sub CbxAddressC_S_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_S.Leave
        cbxAddressC_S.Text = ReplaceText(cbxAddressC_S.Text.Trim)
    End Sub

    Private Sub TxtNoP_S_Leave(sender As Object, e As EventArgs) Handles txtNoP_S.Leave
        txtNoP_S.Text = ReplaceText(txtNoP_S.Text.Trim)
    End Sub

    Private Sub TxtStreetP_S_Leave(sender As Object, e As EventArgs) Handles txtStreetP_S.Leave
        txtStreetP_S.Text = ReplaceText(txtStreetP_S.Text.Trim)
    End Sub

    Private Sub TxtBarangayP_S_Leave(sender As Object, e As EventArgs) Handles txtBarangayP_S.Leave
        txtBarangayP_S.Text = ReplaceText(txtBarangayP_S.Text.Trim)
    End Sub

    Private Sub CbxAddressP_S_Leave(sender As Object, e As EventArgs) Handles cbxAddressP_S.Leave
        cbxAddressP_S.Text = ReplaceText(cbxAddressP_S.Text.Trim)
    End Sub

    Private Sub CbxPlaceBirth_S_Leave(sender As Object, e As EventArgs) Handles cbxPlaceBirth_S.Leave
        cbxPlaceBirth_S.Text = ReplaceText(cbxPlaceBirth_S.Text.Trim)
    End Sub

    Private Sub TxtCitizenship_S_Leave(sender As Object, e As EventArgs) Handles txtCitizenship_S.Leave
        txtCitizenship_S.Text = ReplaceText(txtCitizenship_S.Text.Trim)
    End Sub

    Private Sub TxtTIN_S_Leave(sender As Object, e As EventArgs) Handles txtTIN_S.Leave
        txtTIN_S.Text = ReplaceText(txtTIN_S.Text.Trim)
        If (txtTIN_S.Text.Length <> 9 And txtTIN_S.Text.Length > 0) Or (Not IsNumeric(txtTIN_S.Text) And txtTIN_S.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_S.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtTelephone_S.Leave
        txtTelephone_S.Text = ReplaceText(txtTelephone_S.Text.Trim)
    End Sub

    Private Sub TxtSSS_S_Leave(sender As Object, e As EventArgs) Handles txtSSS_S.Leave
        txtSSS_S.Text = ReplaceText(txtSSS_S.Text.Trim)
        If (txtSSS_S.Text.Length <> 10 And txtSSS_S.Text.Length > 0) Or (Not IsNumeric(txtSSS_S.Text) And txtSSS_S.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_S.Focus()
        End If
    End Sub

    Private Sub TxtMobile_S_Leave(sender As Object, e As EventArgs) Handles txtMobile_S.Leave
        txtMobile_S.Text = ReplaceText(txtMobile_S.Text.Trim)
    End Sub

    Private Sub TxtEmail_S_Leave(sender As Object, e As EventArgs) Handles txtEmail_S.Leave
        txtEmail_S.Text = ReplaceText(txtEmail_S.Text.Trim)
    End Sub

    Private Sub CbxEmployer_S_Leave(sender As Object, e As EventArgs) Handles cbxEmployer_S.Leave
        cbxEmployer_S.Text = ReplaceText(cbxEmployer_S.Text.Trim)
    End Sub

    Private Sub TxtEmployerAddress_S_Leave(sender As Object, e As EventArgs) Handles txtEmployerAddress_S.Leave
        txtEmployerAddress_S.Text = ReplaceText(txtEmployerAddress_S.Text.Trim)
    End Sub

    Private Sub TxtEmployerTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtEmployerTelephone_S.Leave
        txtEmployerTelephone_S.Text = ReplaceText(txtEmployerTelephone_S.Text.Trim)
    End Sub

    Private Sub CbxPosition_S_Leave(sender As Object, e As EventArgs) Handles cbxPosition_S.Leave
        cbxPosition_S.Text = ReplaceText(cbxPosition_S.Text.Trim)
    End Sub

    Private Sub TxtSupervisor_S_Leave(sender As Object, e As EventArgs) Handles txtSupervisor_S.Leave
        txtSupervisor_S.Text = ReplaceText(txtSupervisor_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessName_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessName_S.Leave
        txtBusinessName_S.Text = ReplaceText(txtBusinessName_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessAddress_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessAddress_S.Leave
        txtBusinessAddress_S.Text = ReplaceText(txtBusinessAddress_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessTelephone_S.Leave
        txtBusinessTelephone_S.Text = ReplaceText(txtBusinessTelephone_S.Text.Trim)
    End Sub

    Private Sub CbxNatureBusiness_S_Leave(sender As Object, e As EventArgs) Handles cbxNatureBusiness_S.Leave
        cbxNatureBusiness_S.Text = ReplaceText(cbxNatureBusiness_S.Text.Trim)
    End Sub

    Private Sub TxtArea_S_Leave(sender As Object, e As EventArgs) Handles txtArea_S.Leave
        txtArea_S.Text = ReplaceText(txtArea_S.Text.Trim)
    End Sub

    Private Sub TxtOtherIncome_S_Leave(sender As Object, e As EventArgs) Handles txtOtherIncome_S.Leave
        txtOtherIncome_S.Text = ReplaceText(txtOtherIncome_S.Text.Trim)
    End Sub
#End Region

#Region "Keydown"
    'Borrower
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
            txtNoP_B.Focus()
        End If
    End Sub

    Private Sub TxtNoP_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoP_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetP_B.Focus()
        End If
    End Sub

    Private Sub TxtStreetP_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetP_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayP_B.Focus()
        End If
    End Sub

    Private Sub TxtBarangayP_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayP_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressP_B.Focus()
        End If
    End Sub

    Private Sub CbxAddressP_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressP_B.KeyDown
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
            txtMobile_B2.Focus()
        End If
    End Sub

    Private Sub TxtMobile_B2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_B2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOwned_B.Focus()
        End If
    End Sub

    Private Sub CbxOwned_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOwned_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFree_B.Focus()
        End If
    End Sub

    Private Sub CbxFree_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFree_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRented_B.Focus()
        End If
    End Sub

    Private Sub CbxRented_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRented_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRent_B.Focus()
        End If
    End Sub

    Private Sub DRent_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dRent_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEmployer_B.Focus()
        End If
    End Sub

    Private Sub CbxEmployer_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployer_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerAddress_B.Focus()
        End If
    End Sub

    Private Sub TxtEmployerAddress_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerAddress_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerTelephone_B.Focus()
        End If
    End Sub

    Private Sub TxtEmployerTelephone_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerTelephone_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPosition_B.Focus()
        End If
    End Sub

    Private Sub CbxPosition_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCasual_B.Focus()
        End If
    End Sub

    Private Sub CbxCasual_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCasual_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTemporary_B.Focus()
        End If
    End Sub

    Private Sub CbxTemporary_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTemporary_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPermanent_B.Focus()
        End If
    End Sub

    Private Sub CbxPermanent_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPermanent_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpHired_B.Focus()
        End If
    End Sub

    Private Sub DtpHired_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHired_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSupervisor_B.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpHired_B.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSupervisor_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupervisor_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMonthly_B.Focus()
        End If
    End Sub

    Private Sub DMonthly_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dMonthly_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessName_B.Focus()
        End If
    End Sub

    Private Sub TxtBusinessName_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessName_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessAddress_B.Focus()
        End If
    End Sub

    Private Sub TxtBusinessAddress_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessAddress_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessTelephone_B.Focus()
        End If
    End Sub

    Private Sub TxtBusinessTelephone_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessTelephone_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNatureBusiness_B.Focus()
        End If
    End Sub

    Private Sub CbxNatureBusiness_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNatureBusiness_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            iYrsOperation_B.Focus()
        End If
    End Sub

    Private Sub IYrsOperation_B_KeyDown(sender As Object, e As KeyEventArgs) Handles iYrsOperation_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBusinessIncome_B.Focus()
        End If
    End Sub

    Private Sub DBusinessIncome_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dBusinessIncome_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            iNoEmployees_B.Focus()
        End If
    End Sub

    Private Sub BtnNoEmployees_B_KeyDown(sender As Object, e As KeyEventArgs) Handles iNoEmployees_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCapital_B.Focus()
        End If
    End Sub

    Private Sub DCapital_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dCapital_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtArea_B.Focus()
        End If
    End Sub

    Private Sub TxtArea_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArea_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpExpiry_B.Focus()
        End If
    End Sub

    Private Sub DtpExpiry_B_Click(sender As Object, e As EventArgs) Handles dtpExpiry_B.Click
        dtpExpiry_B.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpExpiry_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            iOutlet_B.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpExpiry_B.CustomFormat = ""
        End If
    End Sub

    Private Sub IOutlet_B_KeyDown(sender As Object, e As KeyEventArgs) Handles iOutlet_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherIncome_B.Focus()
        End If
    End Sub

    Private Sub TxtOtherIncome_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherIncome_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOtherIncome_B.Focus()
        End If
    End Sub

    Private Sub DOtherIncome_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dOtherIncome_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl1.SelectedTab = tabFinancial
            txtCreditor_1.Focus()
        End If
    End Sub

    Private Sub TxtCreditor_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditor_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNatureLoan_1.Focus()
        End If
    End Sub

    Private Sub TxtNatureLoan_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNatureLoan_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountGranted_1.Focus()
        End If
    End Sub

    Private Sub DAmountGranted_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountGranted_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTerm_1.Focus()
        End If
    End Sub

    Private Sub DTerm_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dTerm_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_1.Focus()
        End If
    End Sub

    Private Sub DBalance_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditRemarks_1.Focus()
        End If
    End Sub

    Private Sub DCreditRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditor_2.Focus()
        End If
    End Sub

    Private Sub TxtCreditor_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditor_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNatureLoan_2.Focus()
        End If
    End Sub

    Private Sub TxtNatureLoan_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNatureLoan_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountGranted_2.Focus()
        End If
    End Sub

    Private Sub DAmountGranted_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountGranted_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTerm_2.Focus()
        End If
    End Sub

    Private Sub DTerm_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dTerm_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_2.Focus()
        End If
    End Sub

    Private Sub DBalance_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditRemarks_2.Focus()
        End If
    End Sub

    Private Sub DCreditRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditor_3.Focus()
        End If
    End Sub

    Private Sub TxtCreditor_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditor_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNatureLoan_3.Focus()
        End If
    End Sub

    Private Sub TxtNatureLoan_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNatureLoan_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountGranted_3.Focus()
        End If
    End Sub

    Private Sub DAmountGranted_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountGranted_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTerm_3.Focus()
        End If
    End Sub

    Private Sub DTerm_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dTerm_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_3.Focus()
        End If
    End Sub

    Private Sub DBalance_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditRemarks_3.Focus()
        End If
    End Sub

    Private Sub DCreditRemarks_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditRemarks_3.KeyDown
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
            txtOpened_1.Focus()
        End If
    End Sub

    Private Sub DtpOpened_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOpened_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBankRemarks_1.Focus()
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
            txtOpened_2.Focus()
        End If
    End Sub

    Private Sub DtpOpened_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOpened_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBankRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtBankRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBankRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBank_3.Focus()
        End If
    End Sub

    Private Sub TxtBank_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBank_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranch_3.Focus()
        End If
    End Sub

    Private Sub TxtBranch_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSA_3.Focus()
        End If
    End Sub

    Private Sub CbxSA_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSA_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCA_3.Focus()
        End If
    End Sub

    Private Sub CbxCA_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCA_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSA_3.Focus()
        End If
    End Sub

    Private Sub TxtSA_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSA_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAverageBalance_3.Focus()
        End If
    End Sub

    Private Sub DAverageBalance_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dAverageBalance_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPresentBalance_3.Focus()
        End If
    End Sub

    Private Sub DPresentBalance_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dPresentBalance_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOpened_3.Focus()
        End If
    End Sub

    Private Sub DtpOpened_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOpened_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBankRemarks_3.Focus()
        End If
    End Sub

    Private Sub TxtBankRemarks_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBankRemarks_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLocation_1.Focus()
        End If
    End Sub

    Private Sub TxtLocation_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLocation_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTCT_1.Focus()
        End If
    End Sub

    Private Sub TxtTCT_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTCT_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dArea_1.Focus()
        End If
    End Sub

    Private Sub DArea_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dArea_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcquired_1.Focus()
        End If
    End Sub

    Private Sub TxtAcquired_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcquired_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPropertiesRemarks_1.Focus()
        End If
    End Sub

    Private Sub TxtPropertiesRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropertiesRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLocation_2.Focus()
        End If
    End Sub

    Private Sub TxtLocation_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLocation_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTCT_2.Focus()
        End If
    End Sub

    Private Sub TxtTCT_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTCT_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dArea_2.Focus()
        End If
    End Sub

    Private Sub DArea_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dArea_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcquired_2.Focus()
        End If
    End Sub

    Private Sub TxtAcquired_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcquired_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPropertiesRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtPropertiesRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropertiesRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLocation_3.Focus()
        End If
    End Sub

    Private Sub TxtLocation_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLocation_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTCT_3.Focus()
        End If
    End Sub

    Private Sub TxtTCT_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTCT_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dArea_3.Focus()
        End If
    End Sub

    Private Sub DArea_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dArea_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAcquired_3.Focus()
        End If
    End Sub

    Private Sub TxtAcquired_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAcquired_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPropertiesRemarks_3.Focus()
        End If
    End Sub

    Private Sub TxtPropertiesRemarks_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropertiesRemarks_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicle_1.Focus()
        End If
    End Sub

    Private Sub TxtVehicle_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicle_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear_1.Focus()
        End If
    End Sub

    Private Sub DtpYear_1_Click(sender As Object, e As EventArgs) Handles dtpYear_1.Click
        dtpYear_1.CustomFormat = "     yyyy"
    End Sub

    Private Sub DtpYear_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhomAcquired_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear_1.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtWhomAcquired_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhomAcquired_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhenAcquired_1.Focus()
        End If
    End Sub

    Private Sub DtpWhenAcquired_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhenAcquired_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicleRemarks_1.Focus()
        End If
    End Sub

    Private Sub TxtVehicleRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicleRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicle_2.Focus()
        End If
    End Sub

    Private Sub TxtVehicle_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicle_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear_2.Focus()
        End If
    End Sub

    Private Sub DtpYear_2_Click(sender As Object, e As EventArgs) Handles dtpYear_2.Click
        dtpYear_2.CustomFormat = "     yyyy"
    End Sub

    Private Sub DtpYear_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhomAcquired_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear_2.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtWhomAcquired_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhomAcquired_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhenAcquired_2.Focus()
        End If
    End Sub

    Private Sub DtpWhenAcquired_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhenAcquired_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicleRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtVehicleRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicleRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicle_3.Focus()
        End If
    End Sub

    Private Sub TxtVehicle_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicle_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear_3.Focus()
        End If
    End Sub

    Private Sub DtpYear_3_Click(sender As Object, e As EventArgs) Handles dtpYear_3.Click
        dtpYear_3.CustomFormat = "     yyyy"
    End Sub

    Private Sub DtpYear_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhomAcquired_3.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear_3.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtWhomAcquired_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhomAcquired_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhenAcquired_3.Focus()
        End If
    End Sub

    Private Sub DtpWhenAcquired_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhenAcquired_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicleRemarks_3.Focus()
        End If
    End Sub

    Private Sub TxtVehicleRemarks_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicleRemarks_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHomeAppliances_1.Focus()
        End If
    End Sub

    Private Sub TxtHomeAppliances_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHomeAppliances_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHomeAppliances_2.Focus()
        End If
    End Sub

    Private Sub TxtHomeAppliances_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHomeAppliances_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub TxtReference_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceAddress_1.Focus()
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
            txtReferenceAddress_2.Focus()
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
            txtReferenceAddress_3.Focus()
        End If
    End Sub

    Private Sub TxtReferenceAddress_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceAddress_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceContact_3.Focus()
        End If
    End Sub

    Private Sub TxtReferenceContact_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceContact_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCertificateNo.Focus()
        End If
    End Sub

    Private Sub TxtCertificateNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCertificateNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPlaceIssue.Focus()
        End If
    End Sub

    Private Sub TxtPlaceIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlaceIssue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpIssue.Focus()
        End If
    End Sub

    Private Sub DtpIssue_Click(sender As Object, e As EventArgs) Handles dtpIssue.Click
        dtpIssue.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpIssue.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgent.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpIssue.CustomFormat = ""
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
            cbxDealer.Focus()
        End If
    End Sub

    Private Sub TxtWalkInOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWalkInOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealer.Focus()
        End If
    End Sub

    'Spouse
    Private Sub CbxPrefix_S_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_S.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_S.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_S.Focus()
        End If
    End Sub

    Private Sub TxtLastN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_S.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_M.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_M_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_M.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_M.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_M.Focus()
        End If
    End Sub

    Private Sub TxtLastN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_M.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_M_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_S.Focus()
        End If
    End Sub

    Private Sub TxtNoC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_S.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_S.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_S.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoP_S.Focus()
        End If
    End Sub

    Private Sub TxtNoP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetP_S.Focus()
        End If
    End Sub

    Private Sub TxtStreetP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayP_S.Focus()
        End If
    End Sub

    Private Sub TxtBarangayP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressP_S.Focus()
        End If
    End Sub

    Private Sub CbxAddressP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_S.Focus()
        End If
    End Sub

    Private Sub DtpBirth_S_Click(sender As Object, e As EventArgs) Handles DtpBirth_S.Click
        DtpBirth_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpBirth_S_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPlaceBirth_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_S.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxPlaceBirth_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPlaceBirth_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMale_S.Focus()
        End If
    End Sub

    Private Sub CbxMale_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMale_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFemale_S.Focus()
        End If
    End Sub

    Private Sub CbxFemale_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFemale_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCitizenship_S.Focus()
        End If
    End Sub

    Private Sub TxtCitizenship_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCitizenship_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_S.Focus()
        End If
    End Sub

    Private Sub TxtTIN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_S.Focus()
        End If
    End Sub

    Private Sub TxtSSS_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile_S.Focus()
        End If
    End Sub

    Private Sub TxtMobile_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail_S.Focus()
        End If
    End Sub

    Private Sub TxtEmail_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOwned_S.Focus()
        End If
    End Sub

    Private Sub CbxOwned_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOwned_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFree_S.Focus()
        End If
    End Sub

    Private Sub CbxFree_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFree_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRented_S.Focus()
        End If
    End Sub

    Private Sub CbxRented_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRented_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRent_S.Focus()
        End If
    End Sub

    Private Sub DRent_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dRent_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEmployer_S.Focus()
        End If
    End Sub

    Private Sub CbxEmployer_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployer_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerAddress_S.Focus()
        End If
    End Sub

    Private Sub TxtEmployerAddress_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerAddress_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtEmployerTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPosition_S.Focus()
        End If
    End Sub

    Private Sub CbxPosition_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCasual_S.Focus()
        End If
    End Sub

    Private Sub CbxCasual_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCasual_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTemporary_S.Focus()
        End If
    End Sub

    Private Sub CbxTemporary_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTemporary_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPermanent_S.Focus()
        End If
    End Sub

    Private Sub CbxPermanent_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPermanent_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpHired_S.Focus()
        End If
    End Sub

    Private Sub DtpHired_S_Click(sender As Object, e As EventArgs) Handles dtpHired_S.Click
        'dtpHired_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpHired_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHired_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSupervisor_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpHired_S.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSupervisor_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupervisor_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMonthly_S.Focus()
        End If
    End Sub

    Private Sub DMonthly_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dMonthly_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessName_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessName_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessName_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessAddress_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessAddress_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessAddress_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNatureBusiness_S.Focus()
        End If
    End Sub

    Private Sub CbxNatureBusiness_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNatureBusiness_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iYrsOperation_S.Focus()
        End If
    End Sub

    Private Sub IYrsOperation_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iYrsOperation_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBusinessIncome_S.Focus()
        End If
    End Sub

    Private Sub DBusinessIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dBusinessIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iNoEmployees_S.Focus()
        End If
    End Sub

    Private Sub BtnNoEmployees_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iNoEmployees_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCapital_S.Focus()
        End If
    End Sub

    Private Sub DCapital_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dCapital_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtArea_S.Focus()
        End If
    End Sub

    Private Sub TxtArea_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArea_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpExpiry_S.Focus()
        End If
    End Sub

    Private Sub DtpExpiry_S_Click(sender As Object, e As EventArgs) Handles dtpExpiry_S.Click
        dtpExpiry_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpExpiry_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iOutlet_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpExpiry_S.CustomFormat = ""
        End If
    End Sub

    Private Sub IOutlet_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iOutlet_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherIncome_S.Focus()
        End If
    End Sub

    Private Sub TxtOtherIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOtherIncome_S.Focus()
        End If
    End Sub

    Private Sub DOtherIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dOtherIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

    Private Sub CbxPlaceBirth_B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlaceBirth_B.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPlaceBirth_B.SelectedItem, DataRowView)
        cbxCitizenship_B.SelectedValue = drv("Country ID")
    End Sub

    Private Sub CbxPlaceBirth_S_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlaceBirth_S.SelectedIndexChanged
        If FirstLoad Or cbxPlaceBirth_S.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPlaceBirth_S.SelectedItem, DataRowView)
        txtCitizenship_S.Text = DataObject(String.Format("SELECT nationality FROM country WHERE ID = '{0}'", drv("Country ID")))
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
        Using Camera As New FrmCamera
            With Camera
                If .ShowDialog = DialogResult.OK Then
                    pb_B.Image = .pb_Picture.Image.Clone
                    txtPath_B.Text = "From Camera"
                End If
            End With
        End Using
    End Sub

    Private Sub BtnBrowse_S_Click(sender As Object, e As EventArgs) Handles btnBrowse_S.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_S.Image.Dispose()
                    txtPath_S.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath_S.Text)
                        ResizeImages(TempPB.Image.Clone, pb_S, 650, 500)
                    End Using
                    ChangeSpousePic = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_S_Click(sender As Object, e As MouseEventArgs) Handles pb_S.Click
        Dim Camera As New FrmCamera
        With Camera
            If .ShowDialog = DialogResult.OK Then
                pb_S.Image = .pb_Picture.Image.Clone
                txtPath_S.Text = "From Camera"
            End If
        End With
    End Sub

    'ERROR PREVENTION
    '***BORROWER
    Private Sub CbxEmployer_B_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployer_B.TextChanged
        If cbxEmployer_B.Text.Trim = "" Then
            txtEmployerAddress_B.Enabled = False
            txtEmployerTelephone_B.Enabled = False
            cbxPosition_B.Enabled = False
            cbxCasual_B.Enabled = False
            cbxTemporary_B.Enabled = False
            cbxPermanent_B.Enabled = False
            dtpHired_B.Enabled = False
            dtpHired_B.CustomFormat = ""
            txtSupervisor_B.Enabled = False
            dMonthly_B.Enabled = False
            cbxYearHired.Enabled = False
            cbxYearHired.Checked = False

            vEmpAddress_B = txtEmployerAddress_B.Text
            vEmpTelephone_B = txtEmployerTelephone_B.Text
            vPosition_B = cbxPosition_B.Text
            vCasual_B = cbxCasual_B.Checked
            vTemporary_B = cbxTemporary_B.Checked
            vPermanent_B = cbxPermanent_B.Checked
            vSupervisor_B = txtSupervisor_B.Text
            vSalary_B = dMonthly_B.Value

            txtEmployerAddress_B.Text = ""
            txtEmployerTelephone_B.Text = ""
            cbxPosition_B.Text = ""
            cbxCasual_B.Checked = False
            cbxTemporary_B.Checked = False
            cbxPermanent_B.Checked = False
            txtSupervisor_B.Text = ""
            dMonthly_B.Value = 0
        Else
            txtEmployerAddress_B.Enabled = True
            txtEmployerTelephone_B.Enabled = True
            cbxPosition_B.Enabled = True
            cbxCasual_B.Enabled = True
            cbxTemporary_B.Enabled = True
            cbxPermanent_B.Enabled = True
            dtpHired_B.Enabled = True
            dtpHired_B.CustomFormat = "MMMM dd, yyyy"
            txtSupervisor_B.Enabled = True
            dMonthly_B.Enabled = True
            cbxYearHired.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vEmpAddress_B = "" And vEmpTelephone_B = "" And vPosition_B = "" And vSupervisor_B = "" And vSalary_B = 0 Then
            Else
                If txtEmployerAddress_B.Text = "" Then
                    txtEmployerAddress_B.Text = vEmpAddress_B
                End If
                If txtEmployerTelephone_B.Text = "" Then
                    txtEmployerTelephone_B.Text = vEmpTelephone_B
                End If
                If cbxPosition_B.Text = "" Then
                    cbxPosition_B.Text = vPosition_B
                End If
                If cbxCasual_B.Checked = False Then
                    cbxCasual_B.Checked = vCasual_B
                End If
                If cbxTemporary_B.Checked = False Then
                    cbxTemporary_B.Checked = vTemporary_B
                End If
                If cbxPermanent_B.Checked = False Then
                    cbxPermanent_B.Checked = vPermanent_B
                End If
                If txtSupervisor_B.Text = "" Then
                    txtSupervisor_B.Text = vSupervisor_B
                End If
                If dMonthly_B.Value = 0 Then
                    dMonthly_B.Value = vSalary_B
                End If
            End If
        End If
    End Sub

    Private Sub TxtBusinessName_B_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessName_B.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If txtBusinessName_B.Text.Trim = "" Then
            txtBusinessAddress_B.Enabled = False
            txtBusinessTelephone_B.Enabled = False
            cbxNatureBusiness_B.Enabled = False
            cbxNatureBusiness_B2.Enabled = False
            iYrsOperation_B.Enabled = False
            dBusinessIncome_B.Enabled = False
            iNoEmployees_B.Enabled = False
            dCapital_B.Enabled = False
            txtArea_B.Enabled = False
            dtpExpiry_B.Enabled = False
            dtpExpiry_B.CustomFormat = ""
            iOutlet_B.Enabled = False
            cbxYearFranchise.Enabled = False
            cbxYearFranchise.Checked = False
            txtOtherIncome_B.Enabled = False

            vBusinessAddress_B = txtBusinessAddress_B.Text
            vBusinessTelephone_B = txtBusinessTelephone_B.Text
            vNatureBusiness_B = cbxNatureBusiness_B.Text
            vYrsOperation_B = iYrsOperation_B.Value
            vBusinessIncome_B = dBusinessIncome_B.Value
            vNoEmployees_B = iNoEmployees_B.Value
            vCapital_B = dCapital_B.Value
            vArea_B = txtArea_B.Text
            vOutlet_B = iOutlet_B.Value
            vOtherIncome_B = txtOtherIncome_B.Text

            txtBusinessAddress_B.Text = ""
            txtBusinessTelephone_B.Text = ""
            cbxNatureBusiness_B.Text = ""
            iYrsOperation_B.Value = 0
            dBusinessIncome_B.Value = 0
            iNoEmployees_B.Value = 0
            dCapital_B.Value = 0
            txtArea_B.Text = ""
            iOutlet_B.Value = 0
            txtOtherIncome_B.Text = ""
        Else
            Try
                If txtBusinessName_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                    txtBusinessName_S.Text = txtBusinessName_B.Text
                End If
            Catch ex As Exception
            End Try

            txtBusinessAddress_B.Enabled = True
            txtBusinessTelephone_B.Enabled = True
            cbxNatureBusiness_B.Enabled = True
            cbxNatureBusiness_B2.Enabled = True
            iYrsOperation_B.Enabled = True
            dBusinessIncome_B.Enabled = True
            iNoEmployees_B.Enabled = True
            dCapital_B.Enabled = True
            txtArea_B.Enabled = True
            dtpExpiry_B.Enabled = True
            dtpExpiry_B.CustomFormat = "MMMM dd, yyyy"
            iOutlet_B.Enabled = True
            cbxYearFranchise.Enabled = True
            txtOtherIncome_B.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBusinessAddress_B = "" And vBusinessTelephone_B = "" And vNatureBusiness_B = "" And vYrsOperation_B = 0 And vBusinessIncome_B = 0 And vNoEmployees_B = 0 And vCapital_B = 0 And vArea_B = "" And vOutlet_B = 0 And vOtherIncome_B = "" Then
            Else
                If txtBusinessAddress_B.Text = "" Then
                    txtBusinessAddress_B.Text = vBusinessAddress_B
                End If
                If txtBusinessTelephone_B.Text = "" Then
                    txtBusinessTelephone_B.Text = vBusinessTelephone_B
                End If
                If cbxNatureBusiness_B.Text = "" Then
                    cbxNatureBusiness_B.Text = vNatureBusiness_B
                End If
                If iYrsOperation_B.Value = 0 Then
                    iYrsOperation_B.Value = vYrsOperation_B
                End If
                If dBusinessIncome_B.Value = 0 Then
                    dBusinessIncome_B.Value = vBusinessIncome_B
                End If
                If iNoEmployees_B.Value = 0 Then
                    iNoEmployees_B.Value = vNoEmployees_B
                End If
                If dCapital_B.Value = 0 Then
                    dCapital_B.Value = vCapital_B
                End If
                If txtArea_B.Text = "" Then
                    txtArea_B.Text = vArea_B
                End If
                If iOutlet_B.Value = 0 Then
                    iOutlet_B.Value = vOutlet_B
                End If
                If txtOtherIncome_B.Text = "" Then
                    txtOtherIncome_B.Text = vOtherIncome_B
                End If
            End If
        End If
    End Sub

    Private Sub TxtOtherIncome_B_TextChanged(sender As Object, e As EventArgs) Handles txtOtherIncome_B.TextChanged
        If txtOtherIncome_B.Text.Trim = "" Then
            dOtherIncome_B.Enabled = False

            vOtherIncomeD_B = dOtherIncome_B.Value

            dOtherIncome_B.Value = 0
        Else
            Try
                If txtOtherIncome_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                    txtOtherIncome_S.Text = txtOtherIncome_B.Text
                End If
            Catch ex As Exception
            End Try

            dOtherIncome_B.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vOtherIncomeD_B = 0 Then
            Else
                If dOtherIncome_B.Value = 0 Then
                    dOtherIncome_B.Value = vOtherIncomeD_B
                End If
            End If
        End If
    End Sub

    Private Sub TxtCreditor_1_TextChanged(sender As Object, e As EventArgs) Handles txtCreditor_1.TextChanged
        If txtCreditor_1.Text.Trim = "" Then
            txtNatureLoan_1.Enabled = False
            dAmountGranted_1.Enabled = False
            dTerm_1.Enabled = False
            dBalance_1.Enabled = False
            txtCreditRemarks_1.Enabled = False
            txtCreditor_2.Enabled = False

            txtNatureLoan_2.Enabled = False
            dAmountGranted_2.Enabled = False
            dTerm_2.Enabled = False
            dBalance_2.Enabled = False
            txtCreditRemarks_2.Enabled = False
            txtCreditor_3.Enabled = False
            txtNatureLoan_3.Enabled = False
            dAmountGranted_3.Enabled = False
            dTerm_3.Enabled = False
            dBalance_3.Enabled = False
            txtCreditRemarks_3.Enabled = False

            vNatureLoan_1 = txtNatureLoan_1.Text
            vAmountGranted_1 = dAmountGranted_1.Value
            vTerm_1 = dTerm_1.Value
            vBalance_1 = dBalance_1.Value
            vCreditRemarks_1 = txtCreditRemarks_1.Text

            vCreditor_2 = txtCreditor_2.Text

            txtNatureLoan_1.Text = ""
            dAmountGranted_1.Value = 0
            dTerm_1.Value = 0
            dBalance_1.Value = 0
            txtCreditRemarks_1.Text = ""

            txtCreditor_2.Text = ""
        Else
            txtNatureLoan_1.Enabled = True
            dAmountGranted_1.Enabled = True
            dTerm_1.Enabled = True
            dBalance_1.Enabled = True
            txtCreditRemarks_1.Enabled = True
            txtCreditor_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vNatureLoan_1 = "" And vAmountGranted_1 = 0 And vTerm_1 = 0 And vBalance_1 = 0 And vCreditRemarks_1 = "" And vCreditor_2 = "" Then
            Else
                If txtNatureLoan_1.Text = "" Then
                    txtNatureLoan_1.Text = vNatureLoan_1
                End If
                If dAmountGranted_1.Text = "" Then
                    dAmountGranted_1.Value = vAmountGranted_1
                End If
                If dTerm_1.Value = 0 Then
                    dTerm_1.Value = vTerm_1
                End If
                If dBalance_1.Value = 0 Then
                    dBalance_1.Value = vBalance_1
                End If
                If txtCreditRemarks_1.Text = "" Then
                    txtCreditRemarks_1.Text = vCreditRemarks_1
                End If

                If txtCreditor_2.Text = "" Then
                    txtCreditor_2.Text = vCreditor_2
                End If
            End If
        End If
    End Sub

    Private Sub TxtCreditor_2_TextChanged(sender As Object, e As EventArgs) Handles txtCreditor_2.TextChanged
        If txtCreditor_2.Text.Trim = "" Then
            txtNatureLoan_2.Enabled = False
            dAmountGranted_2.Enabled = False
            dTerm_2.Enabled = False
            dBalance_2.Enabled = False
            txtCreditRemarks_2.Enabled = False
            txtCreditor_3.Enabled = False

            txtNatureLoan_3.Enabled = False
            dAmountGranted_3.Enabled = False
            dTerm_3.Enabled = False
            dBalance_3.Enabled = False
            txtCreditRemarks_3.Enabled = False

            vNatureLoan_2 = txtNatureLoan_2.Text
            vAmountGranted_2 = dAmountGranted_2.Value
            vTerm_2 = dTerm_2.Value
            vBalance_2 = dBalance_2.Value
            vCreditRemarks_2 = txtCreditRemarks_2.Text

            vCreditor_3 = txtCreditor_3.Text

            txtNatureLoan_2.Text = ""
            dAmountGranted_2.Value = 0
            dTerm_2.Value = 0
            dBalance_2.Value = 0
            txtCreditRemarks_2.Text = ""

            txtCreditor_3.Text = ""
        Else
            txtNatureLoan_2.Enabled = True
            dAmountGranted_2.Enabled = True
            dTerm_2.Enabled = True
            dBalance_2.Enabled = True
            txtCreditRemarks_2.Enabled = True
            txtCreditor_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vNatureLoan_2 = "" And vAmountGranted_2 = 0 And vTerm_2 = 0 And vBalance_2 = 0 And vCreditRemarks_2 = "" And vCreditor_3 = "" Then
            Else
                If txtNatureLoan_2.Text = "" Then
                    txtNatureLoan_2.Text = vNatureLoan_2
                End If
                If dAmountGranted_2.Text = "" Then
                    dAmountGranted_2.Value = vAmountGranted_2
                End If
                If dTerm_2.Value = 0 Then
                    dTerm_2.Value = vTerm_2
                End If
                If dBalance_2.Value = 0 Then
                    dBalance_2.Value = vBalance_2
                End If
                If txtCreditRemarks_2.Text = "" Then
                    txtCreditRemarks_2.Text = vCreditRemarks_2
                End If

                If txtCreditor_3.Text = "" Then
                    txtCreditor_3.Text = vCreditor_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtCreditor_3_TextChanged(sender As Object, e As EventArgs) Handles txtCreditor_3.TextChanged
        If txtCreditor_3.Text.Trim = "" Then
            txtNatureLoan_3.Enabled = False
            dAmountGranted_3.Enabled = False
            dTerm_3.Enabled = False
            dBalance_3.Enabled = False
            txtCreditRemarks_3.Enabled = False

            vNatureLoan_3 = txtNatureLoan_3.Text
            vAmountGranted_3 = dAmountGranted_3.Value
            vTerm_3 = dTerm_3.Value
            vBalance_3 = dBalance_3.Value
            vCreditRemarks_3 = txtCreditRemarks_3.Text

            txtNatureLoan_3.Text = ""
            dAmountGranted_3.Value = 0
            dTerm_3.Value = 0
            dBalance_3.Value = 0
            txtCreditRemarks_3.Text = ""
        Else
            txtNatureLoan_3.Enabled = True
            dAmountGranted_3.Enabled = True
            dTerm_3.Enabled = True
            dBalance_3.Enabled = True
            txtCreditRemarks_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vNatureLoan_3 = "" And vAmountGranted_3 = 0 And vTerm_3 = 0 And vBalance_3 = 0 And vCreditRemarks_3 = "" Then
            Else
                If txtNatureLoan_3.Text = "" Then
                    txtNatureLoan_3.Text = vNatureLoan_3
                End If
                If dAmountGranted_3.Text = "" Then
                    dAmountGranted_3.Value = vAmountGranted_3
                End If
                If dTerm_3.Value = 0 Then
                    dTerm_3.Value = vTerm_3
                End If
                If dBalance_3.Value = 0 Then
                    dBalance_3.Value = vBalance_3
                End If
                If txtCreditRemarks_3.Text = "" Then
                    txtCreditRemarks_3.Text = vCreditRemarks_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtBank_1_TextChanged(sender As Object, e As EventArgs) Handles txtBank_1.TextChanged
        If txtBank_1.Text.Trim = "" Then
            txtBranch_1.Enabled = False
            cbxSA_1.Enabled = False
            cbxCA_1.Enabled = False
            txtSA_1.Enabled = False
            dAverageBalance_1.Enabled = False
            dPresentBalance_1.Enabled = False
            txtOpened_1.Enabled = False
            txtBankRemarks_1.Enabled = False
            txtBank_2.Enabled = False

            txtBranch_2.Enabled = False
            cbxSA_2.Enabled = False
            cbxCA_2.Enabled = False
            txtSA_2.Enabled = False
            dAverageBalance_2.Enabled = False
            dPresentBalance_2.Enabled = False
            txtOpened_2.Enabled = False
            txtBankRemarks_2.Enabled = False
            txtBank_3.Enabled = False
            txtBranch_3.Enabled = False
            cbxSA_3.Enabled = False
            cbxCA_3.Enabled = False
            txtSA_3.Enabled = False
            dAverageBalance_3.Enabled = False
            dPresentBalance_3.Enabled = False
            txtOpened_3.Enabled = False
            txtBankRemarks_3.Enabled = False

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
            txtOpened_1.Enabled = True
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
            txtOpened_2.Enabled = False
            txtBankRemarks_2.Enabled = False
            txtBank_3.Enabled = False

            txtSA_3.Enabled = False
            dAverageBalance_3.Enabled = False
            dPresentBalance_3.Enabled = False
            txtOpened_3.Enabled = False
            txtBankRemarks_3.Enabled = False

            vBranch_2 = txtBranch_2.Text
            vcSA_2 = cbxSA_2.Checked
            vcCA_2 = cbxCA_2.Checked
            vSA_2 = txtSA_2.Text
            vAverageBalance_2 = dAverageBalance_2.Value
            vPresentBalance_2 = dPresentBalance_2.Value
            vBankRemarks_2 = txtBankRemarks_2.Text

            vBank_3 = txtBank_3.Text

            txtBranch_2.Text = ""
            cbxSA_2.Checked = False
            cbxCA_2.Checked = False
            txtSA_2.Text = ""
            dAverageBalance_2.Value = 0
            dPresentBalance_2.Value = 0
            txtBankRemarks_2.Text = ""

            txtBank_3.Text = ""
        Else
            txtBranch_2.Enabled = True
            cbxSA_2.Enabled = True
            cbxCA_2.Enabled = True
            txtSA_2.Enabled = True
            dAverageBalance_2.Enabled = True
            dPresentBalance_2.Enabled = True
            txtOpened_2.Enabled = True
            txtBankRemarks_2.Enabled = True
            txtBank_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBranch_2 = "" And vcSA_2 = False And vcCA_2 = False And vSA_2 = "" And vAverageBalance_2 = 0 And vPresentBalance_2 = 0 And vBankRemarks_2 = "" And vBank_3 = "" Then
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

                If txtBank_3.Text = "" Then
                    txtBank_3.Text = vBank_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtBank_3_TextChanged(sender As Object, e As EventArgs) Handles txtBank_3.TextChanged
        If txtBank_3.Text.Trim = "" Then
            txtBranch_3.Enabled = False
            cbxSA_3.Enabled = False
            cbxCA_3.Enabled = False
            txtSA_3.Enabled = False
            dAverageBalance_3.Enabled = False
            dPresentBalance_3.Enabled = False
            txtOpened_3.Enabled = False
            txtBankRemarks_3.Enabled = False

            vBranch_3 = txtBranch_3.Text
            vcSA_3 = cbxSA_3.Checked
            vcCA_3 = cbxCA_3.Checked
            vSA_3 = txtSA_3.Text
            vAverageBalance_3 = dAverageBalance_3.Value
            vPresentBalance_3 = dPresentBalance_3.Value
            vBankRemarks_3 = txtBankRemarks_3.Text

            txtBranch_3.Text = ""
            cbxSA_3.Checked = False
            cbxCA_3.Checked = False
            txtSA_3.Text = ""
            dAverageBalance_3.Value = 0
            dPresentBalance_3.Value = 0
            txtBankRemarks_3.Text = ""
        Else
            txtBranch_3.Enabled = True
            cbxSA_3.Enabled = True
            cbxCA_3.Enabled = True
            txtSA_3.Enabled = True
            dAverageBalance_3.Enabled = True
            dPresentBalance_3.Enabled = True
            txtOpened_3.Enabled = True
            txtBankRemarks_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBranch_3 = "" And vcSA_3 = False And vcCA_3 = False And vSA_3 = "" And vAverageBalance_3 = 0 And vPresentBalance_3 = 0 And vBankRemarks_3 = "" Then
            Else
                If txtBranch_3.Text = "" Then
                    txtBranch_3.Text = vBranch_3
                End If
                If cbxSA_3.Checked = False Then
                    cbxSA_3.Checked = vcSA_3
                End If
                If cbxCA_3.Checked = False Then
                    cbxCA_3.Checked = vcCA_3
                End If
                If txtSA_3.Text = "" Then
                    txtSA_3.Text = vSA_3
                End If
                If dAverageBalance_3.Value = 0 Then
                    dAverageBalance_3.Value = vAverageBalance_3
                End If
                If dPresentBalance_3.Value = 0 Then
                    dPresentBalance_3.Value = vPresentBalance_3
                End If
                If txtBankRemarks_3.Text = "" Then
                    txtBankRemarks_3.Text = vBankRemarks_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtLocation_1_TextChanged(sender As Object, e As EventArgs) Handles txtLocation_1.TextChanged
        If txtLocation_1.Text.Trim = "" Then
            txtTCT_1.Enabled = False
            dArea_1.Enabled = False
            txtAcquired_1.Enabled = False
            txtPropertiesRemarks_1.Enabled = False
            txtLocation_2.Enabled = False

            txtTCT_2.Enabled = False
            dArea_2.Enabled = False
            txtAcquired_2.Enabled = False
            txtPropertiesRemarks_2.Enabled = False
            txtLocation_3.Enabled = False
            txtTCT_3.Enabled = False
            dArea_3.Enabled = False
            txtAcquired_3.Enabled = False
            txtPropertiesRemarks_3.Enabled = False

            vTCT_1 = txtTCT_1.Text
            vArea_1 = dArea_1.Value
            vAcquired_1 = txtAcquired_1.Text
            vPropertiesRemarks_1 = txtPropertiesRemarks_1.Text
            vLocation_2 = txtLocation_2.Text

            txtTCT_1.Text = ""
            dArea_1.Value = 0
            txtAcquired_1.Text = ""
            txtPropertiesRemarks_1.Text = ""
            txtLocation_2.Text = ""
        Else
            txtTCT_1.Enabled = True
            dArea_1.Enabled = True
            txtAcquired_1.Enabled = True
            txtPropertiesRemarks_1.Enabled = True
            txtLocation_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vTCT_1 = "" And vArea_1 = 0 And vAcquired_1 = "" And vPropertiesRemarks_1 = "" And vLocation_2 = "" Then
            Else
                If txtTCT_1.Text = "" Then
                    txtTCT_1.Text = vTCT_1
                End If
                If dArea_1.Value = 0 Then
                    dArea_1.Value = vArea_1
                End If
                If txtAcquired_1.Text = "" Then
                    txtAcquired_1.Text = vAcquired_1
                End If
                If txtPropertiesRemarks_1.Text = "" Then
                    txtPropertiesRemarks_1.Text = vPropertiesRemarks_1
                End If
                If txtLocation_2.Text = "" Then
                    txtLocation_2.Text = vLocation_2
                End If
            End If
        End If
    End Sub

    Private Sub TxtLocation_2_TextChanged(sender As Object, e As EventArgs) Handles txtLocation_2.TextChanged
        If txtLocation_2.Text.Trim = "" Then
            txtTCT_2.Enabled = False
            dArea_2.Enabled = False
            txtAcquired_2.Enabled = False
            txtPropertiesRemarks_2.Enabled = False
            txtLocation_3.Enabled = False

            txtTCT_3.Enabled = False
            dArea_3.Enabled = False
            txtAcquired_3.Enabled = False
            txtPropertiesRemarks_3.Enabled = False

            vTCT_2 = txtTCT_2.Text
            vArea_2 = dArea_2.Value
            vAcquired_2 = txtAcquired_2.Text
            vPropertiesRemarks_2 = txtPropertiesRemarks_2.Text
            vLocation_3 = txtLocation_3.Text

            txtTCT_2.Text = ""
            dArea_2.Value = 0
            txtAcquired_2.Text = ""
            txtPropertiesRemarks_2.Text = ""
            txtLocation_3.Text = ""
        Else
            txtTCT_2.Enabled = True
            dArea_2.Enabled = True
            txtAcquired_2.Enabled = True
            txtPropertiesRemarks_2.Enabled = True
            txtLocation_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vTCT_2 = "" And vArea_2 = 0 And vAcquired_2 = "" And vPropertiesRemarks_2 = "" And vLocation_3 = "" Then
            Else
                If txtTCT_2.Text = "" Then
                    txtTCT_2.Text = vTCT_2
                End If
                If dArea_2.Value = 0 Then
                    dArea_2.Value = vArea_2
                End If
                If txtAcquired_2.Text = "" Then
                    txtAcquired_2.Text = vAcquired_2
                End If
                If txtPropertiesRemarks_2.Text = "" Then
                    txtPropertiesRemarks_2.Text = vPropertiesRemarks_2
                End If
                If txtLocation_3.Text = "" Then
                    txtLocation_3.Text = vLocation_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtLocation_3_TextChanged(sender As Object, e As EventArgs) Handles txtLocation_3.TextChanged
        If txtLocation_3.Text.Trim = "" Then
            txtTCT_3.Enabled = False
            dArea_3.Enabled = False
            txtAcquired_3.Enabled = False
            txtPropertiesRemarks_3.Enabled = False

            txtTCT_3.Text = ""
            dArea_3.Value = 0
            txtAcquired_3.Text = ""
            txtPropertiesRemarks_3.Text = ""
        Else
            txtTCT_3.Enabled = True
            dArea_3.Enabled = True
            txtAcquired_3.Enabled = True
            txtPropertiesRemarks_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vTCT_3 = "" And vArea_3 = 0 And vAcquired_3 = "" And vPropertiesRemarks_3 = "" Then
            Else
                If txtTCT_3.Text = "" Then
                    txtTCT_3.Text = vTCT_3
                End If
                If dArea_3.Value = 0 Then
                    dArea_3.Value = vArea_3
                End If
                If txtAcquired_3.Text = "" Then
                    txtAcquired_3.Text = vAcquired_3
                End If
                If txtPropertiesRemarks_3.Text = "" Then
                    txtPropertiesRemarks_3.Text = vPropertiesRemarks_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtVehicle_1_TextChanged(sender As Object, e As EventArgs) Handles txtVehicle_1.TextChanged
        If txtVehicle_1.Text.Trim = "" Then
            dtpYear_1.Enabled = False
            dtpYear_1.CustomFormat = ""
            txtWhomAcquired_1.Enabled = False
            txtWhenAcquired_1.Enabled = False
            txtVehicleRemarks_1.Enabled = False
            txtVehicle_2.Enabled = False

            dtpYear_2.Enabled = False
            dtpYear_2.CustomFormat = ""
            txtWhomAcquired_2.Enabled = False
            txtWhenAcquired_2.Enabled = False
            txtVehicleRemarks_2.Enabled = False
            txtVehicle_3.Enabled = False
            dtpYear_3.Enabled = False
            dtpYear_3.CustomFormat = ""
            txtWhomAcquired_3.Enabled = False
            txtWhenAcquired_3.Enabled = False
            txtVehicleRemarks_3.Enabled = False

            vWhomAcquired_1 = txtWhomAcquired_1.Text
            vVehicleRemarks_1 = txtVehicleRemarks_1.Text
            vVehicle_2 = txtVehicle_2.Text

            txtWhomAcquired_1.Text = ""
            txtVehicleRemarks_1.Text = ""
            txtVehicle_2.Text = ""
        Else
            dtpYear_1.Enabled = True
            dtpYear_1.CustomFormat = "     yyyy"
            txtWhomAcquired_1.Enabled = True
            txtWhenAcquired_1.Enabled = True
            txtVehicleRemarks_1.Enabled = True
            txtVehicle_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vWhomAcquired_1 = "" And vVehicleRemarks_1 = "" And vVehicle_2 = "" Then
            Else
                If txtWhomAcquired_1.Text = "" Then
                    txtWhomAcquired_1.Text = vWhomAcquired_1
                End If
                If txtVehicleRemarks_1.Text = "" Then
                    txtVehicleRemarks_1.Text = vVehicleRemarks_1
                End If
                If txtVehicle_2.Text = "" Then
                    txtVehicle_2.Text = vVehicle_2
                End If
            End If
        End If
    End Sub

    Private Sub TxtVehicle_2_TextChanged(sender As Object, e As EventArgs) Handles txtVehicle_2.TextChanged
        If txtVehicle_2.Text.Trim = "" Then
            dtpYear_2.Enabled = False
            dtpYear_2.CustomFormat = ""
            txtWhomAcquired_2.Enabled = False
            txtWhenAcquired_2.Enabled = False
            txtVehicleRemarks_2.Enabled = False
            txtVehicle_3.Enabled = False

            dtpYear_3.Enabled = False
            dtpYear_3.CustomFormat = ""
            txtWhomAcquired_3.Enabled = False
            txtWhenAcquired_3.Enabled = False
            txtVehicleRemarks_3.Enabled = False

            vWhomAcquired_2 = txtWhomAcquired_2.Text
            vVehicleRemarks_2 = txtVehicleRemarks_2.Text
            vVehicle_3 = txtVehicle_3.Text

            txtWhomAcquired_2.Text = ""
            txtVehicleRemarks_2.Text = ""
            txtVehicle_3.Text = ""
        Else
            dtpYear_2.Enabled = True
            dtpYear_2.CustomFormat = "     yyyy"
            txtWhomAcquired_2.Enabled = True
            txtWhenAcquired_2.Enabled = True
            txtVehicleRemarks_2.Enabled = True
            txtVehicle_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vWhomAcquired_2 = "" And vVehicleRemarks_2 = "" And vVehicle_3 = "" Then
            Else
                If txtWhomAcquired_2.Text = "" Then
                    txtWhomAcquired_2.Text = vWhomAcquired_2
                End If
                If txtVehicleRemarks_2.Text = "" Then
                    txtVehicleRemarks_2.Text = vVehicleRemarks_2
                End If
                If txtVehicle_3.Text = "" Then
                    txtVehicle_3.Text = vVehicle_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtVehicle_3_TextChanged(sender As Object, e As EventArgs) Handles txtVehicle_3.TextChanged
        If txtVehicle_3.Text.Trim = "" Then
            dtpYear_3.Enabled = False
            dtpYear_3.CustomFormat = ""
            txtWhomAcquired_3.Enabled = False
            txtWhenAcquired_3.Enabled = False
            txtVehicleRemarks_3.Enabled = False

            vWhomAcquired_3 = txtWhomAcquired_3.Text
            vVehicleRemarks_3 = txtVehicleRemarks_3.Text

            txtWhomAcquired_3.Text = ""
            txtVehicleRemarks_3.Text = ""
        Else
            dtpYear_3.Enabled = True
            dtpYear_3.CustomFormat = "     yyyy"
            txtWhomAcquired_3.Enabled = True
            txtWhenAcquired_3.Enabled = True
            txtVehicleRemarks_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vWhomAcquired_3 = "" And vVehicleRemarks_3 = "" Then
            Else
                If txtWhomAcquired_3.Text = "" Then
                    txtWhomAcquired_3.Text = vWhomAcquired_3
                End If
                If txtVehicleRemarks_3.Text = "" Then
                    txtVehicleRemarks_3.Text = vVehicleRemarks_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtHomeAppliances_1_TextChanged(sender As Object, e As EventArgs) Handles txtHomeAppliances_1.TextChanged
        If txtHomeAppliances_1.Text.Trim = "" Then
            txtHomeAppliances_2.Enabled = False

            vHomeAppliances_2 = txtHomeAppliances_2.Text

            txtHomeAppliances_2.Text = ""
        Else
            txtHomeAppliances_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            txtHomeAppliances_2.Text = vHomeAppliances_2
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

    Private Sub TxtCertificateNo_TextChanged(sender As Object, e As EventArgs) Handles txtCertificateNo.TextChanged
        If txtCertificateNo.Text.Trim = "" Then
            txtPlaceIssue.Enabled = False
            dtpIssue.Enabled = False
            dtpIssue.CustomFormat = ""

            vPlaceIssue = txtPlaceIssue.Text

            txtPlaceIssue.Text = ""
        Else
            txtPlaceIssue.Enabled = True
            dtpIssue.Enabled = True
            dtpIssue.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            txtPlaceIssue.Text = vPlaceIssue
        End If
    End Sub

    '***SPOUSE
    Private Sub CbxEmployer_S_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployer_S.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxEmployer_S.Text.Trim = "" Then
            txtEmployerAddress_S.Enabled = False
            txtEmployerTelephone_S.Enabled = False
            cbxPosition_S.Enabled = False
            cbxCasual_S.Enabled = False
            cbxTemporary_S.Enabled = False
            cbxPermanent_S.Enabled = False
            dtpHired_S.Enabled = False
            dtpHired_S.CustomFormat = ""
            txtSupervisor_S.Enabled = False
            dMonthly_S.Enabled = False
            cbxYearHired_S.Enabled = False
            cbxYearHired_S.Checked = False

            vEmpAddress_S = txtEmployerAddress_S.Text
            vEmpTelephone_S = txtEmployerTelephone_S.Text
            vPosition_S = cbxPosition_S.Text
            vCasual_S = cbxCasual_S.Checked
            vTemporary_S = cbxTemporary_S.Checked
            vPermanent_S = cbxPermanent_S.Checked
            vSupervisor_S = txtSupervisor_S.Text
            vSalary_S = dMonthly_S.Value

            txtEmployerAddress_S.Text = ""
            txtEmployerTelephone_S.Text = ""
            cbxPosition_S.Text = ""
            cbxCasual_S.Checked = False
            cbxTemporary_S.Checked = False
            cbxPermanent_S.Checked = False
            txtSupervisor_S.Text = ""
            dMonthly_S.Value = 0
        Else
            txtEmployerAddress_S.Enabled = True
            txtEmployerTelephone_S.Enabled = True
            cbxPosition_S.Enabled = True
            cbxCasual_S.Enabled = True
            cbxTemporary_S.Enabled = True
            cbxPermanent_S.Enabled = True
            dtpHired_S.Enabled = True
            dtpHired_S.CustomFormat = "MMMM dd, yyyy"
            txtSupervisor_S.Enabled = True
            dMonthly_S.Enabled = True
            cbxYearHired_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vEmpAddress_S = "" And vEmpTelephone_S = "" And vPosition_S = "" And vSupervisor_S = "" And vSalary_S = 0 Then
            Else
                If txtEmployerAddress_S.Text = "" Then
                    txtEmployerAddress_S.Text = vEmpAddress_S
                End If
                If txtEmployerTelephone_S.Text = "" Then
                    txtEmployerTelephone_S.Text = vEmpTelephone_S
                End If
                If cbxPosition_S.Text = "" Then
                    cbxPosition_S.Text = vPosition_S
                End If
                If cbxCasual_S.Checked = False Then
                    cbxCasual_S.Checked = vCasual_S
                End If
                If cbxTemporary_S.Checked = False Then
                    cbxTemporary_S.Checked = vTemporary_S
                End If
                If cbxPermanent_S.Checked = False Then
                    cbxPermanent_S.Checked = vPermanent_S
                End If
                If txtSupervisor_S.Text = "" Then
                    txtSupervisor_S.Text = vSupervisor_S
                End If
                If dMonthly_S.Value = 0 Then
                    dMonthly_S.Value = vSalary_S
                End If
            End If
        End If
    End Sub

    Private Sub TxtBusinessName_S_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessName_S.TextChanged
        If txtBusinessName_S.Text.Trim = "" Then
            txtBusinessAddress_S.Enabled = False
            txtBusinessTelephone_S.Enabled = False
            cbxNatureBusiness_S.Enabled = False
            cbxNatureBusiness_S2.Enabled = False
            iYrsOperation_S.Enabled = False
            dBusinessIncome_S.Enabled = False
            iNoEmployees_S.Enabled = False
            dCapital_S.Enabled = False
            txtArea_S.Enabled = False
            dtpExpiry_S.Enabled = False
            dtpExpiry_S.CustomFormat = ""
            iOutlet_S.Enabled = False
            txtOtherIncome_S.Enabled = False

            vBusinessAddress_S = txtBusinessAddress_S.Text
            vBusinessTelephone_S = txtBusinessTelephone_S.Text
            vNatureBusiness_S = cbxNatureBusiness_S.Text
            vYrsOperation_S = iYrsOperation_S.Value
            vBusinessIncome_S = dBusinessIncome_S.Value
            vNoEmployees_S = iNoEmployees_S.Value
            vCapital_S = dCapital_S.Value
            vArea_S = txtArea_S.Text
            vOutlet_S = iOutlet_S.Value
            vOtherIncome_S = txtOtherIncome_S.Text

            txtBusinessAddress_S.Text = ""
            txtBusinessTelephone_S.Text = ""
            cbxNatureBusiness_S.Text = ""
            iYrsOperation_S.Value = 0
            dBusinessIncome_S.Value = 0
            iNoEmployees_S.Value = 0
            dCapital_S.Value = 0
            txtArea_S.Text = ""
            iOutlet_S.Value = 0
            txtOtherIncome_S.Text = ""
        Else
            txtBusinessAddress_S.Enabled = True
            txtBusinessTelephone_S.Enabled = True
            cbxNatureBusiness_S.Enabled = True
            cbxNatureBusiness_S2.Enabled = True
            iYrsOperation_S.Enabled = True
            dBusinessIncome_S.Enabled = True
            iNoEmployees_S.Enabled = True
            dCapital_S.Enabled = True
            txtArea_S.Enabled = True
            dtpExpiry_S.Enabled = True
            dtpExpiry_S.CustomFormat = "MMMM dd, yyyy"
            iOutlet_S.Enabled = True
            txtOtherIncome_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBusinessAddress_S = "" And vBusinessTelephone_S = "" And vNatureBusiness_S = "" And vYrsOperation_S = 0 And vBusinessIncome_S = 0 And vNoEmployees_S = 0 And vCapital_S = 0 And vArea_S = "" And vOutlet_S = 0 And vOtherIncome_S = "" Then
            Else
                If txtBusinessAddress_S.Text = "" Then
                    txtBusinessAddress_S.Text = vBusinessAddress_S
                End If
                If txtBusinessTelephone_S.Text = "" Then
                    txtBusinessTelephone_S.Text = vBusinessTelephone_S
                End If
                If cbxNatureBusiness_S.Text = "" Then
                    cbxNatureBusiness_S.Text = vNatureBusiness_S
                End If
                If iYrsOperation_S.Value = 0 Then
                    iYrsOperation_S.Value = vYrsOperation_S
                End If
                If dBusinessIncome_S.Value = 0 Then
                    dBusinessIncome_S.Value = vBusinessIncome_S
                End If
                If iNoEmployees_S.Value = 0 Then
                    iNoEmployees_S.Value = vNoEmployees_S
                End If
                If dCapital_S.Value = 0 Then
                    dCapital_S.Value = vCapital_S
                End If
                If txtArea_S.Text = "" Then
                    txtArea_S.Text = vArea_S
                End If
                If iOutlet_S.Value = 0 Then
                    iOutlet_S.Value = vOutlet_S
                End If
                If txtOtherIncome_S.Text = "" Then
                    txtOtherIncome_S.Text = vOtherIncome_S
                End If
            End If
        End If
    End Sub

    Private Sub TxtOtherIncome_S_TextChanged(sender As Object, e As EventArgs) Handles txtOtherIncome_S.TextChanged
        If txtOtherIncome_S.Text.Trim = "" Then
            dOtherIncome_S.Enabled = False

            vOtherIncomeD_S = dOtherIncome_S.Value

            dOtherIncome_S.Value = 0
        Else
            dOtherIncome_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vOtherIncomeD_S = 0 Then
            Else
                If dOtherIncome_S.Value = 0 Then
                    dOtherIncome_S.Value = vOtherIncomeD_S
                End If
            End If
        End If
    End Sub

    Private Sub BtnExisting_B_Click(sender As Object, e As EventArgs) Handles btnExisting_B.Click
        Dim Existing As New FrmBorrowerExisting
        With Existing
            .Type = "Borrower"
            .ShowDialog()
            .Dispose()
        End With
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
            MsgBox("Please fill the borrower's first name.", MsgBoxStyle.Information, "Info")
            TxtFirstN_B.Focus()
            Exit Sub
        End If
        If TxtLastN_B.Text = "" Then
            MsgBox("Please fill the borrower's last name.", MsgBoxStyle.Information, "Info")
            TxtLastN_B.Focus()
            Exit Sub
        End If
        If DtpBirth_B.CustomFormat = "" Then
            MsgBox("Please fill the borrower's date of birth.", MsgBoxStyle.Information, "Info")
            DtpBirth_B.Focus()
            Exit Sub
        End If
        If cbxPlaceBirth_B.SelectedIndex = -1 Then
            MsgBox("Please fill the borrower's place of birth.", MsgBoxStyle.Information, "Info")
            cbxPlaceBirth_B.DroppedDown = True
            Exit Sub
        End If
        If DateValue(DtpBirth_B.Value.AddYears(18)) > DateValue(Date.Now) Then
            If MsgBoxYes("Borrower's age is below 18 years old, are you sure you would like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf datevalue(DtpBirth_B.Value.AddYears(61)) <= Datevalue(Date.Now) Then
            If MsgBoxYes("Borrower's age is 61 or above, are you sure you would like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If txtMobile_B.Text <> "" And (txtMobile_B.Text.Trim.Length <> 10 Or IsNumeric(txtMobile_B.Text.Trim) = False Or If(txtMobile_B.Text.Length > 1, txtMobile_B.Text.Substring(0, 1) = 0, 0)) And tabBorrower.Visible = True Then
            MsgBox("Please fill a correct Mobile Number field.", MsgBoxStyle.Information, "Info")
            txtMobile_B.Focus()
            Exit Sub
        End If
        If txtMobile_B2.Text <> "" And (txtMobile_B2.Text.Trim.Length <> 10 Or IsNumeric(txtMobile_B2.Text.Trim) = False Or If(txtMobile_B2.Text.Length > 1, txtMobile_B2.Text.Substring(0, 1) = 0, 0)) And tabBorrower.Visible = True Then
            MsgBox("Please fill a correct Alternate Mobile Number field.", MsgBoxStyle.Information, "Info")
            txtMobile_B2.Focus()
            Exit Sub
        End If
        If cbxBusinessCenter.SelectedIndex = -1 Or cbxBusinessCenter.Text = "" Then
            MsgBox("Please select a business center.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabFinancial
            cbxBusinessCenter.Focus()
            cbxBusinessCenter.DroppedDown = True
            Exit Sub
        End If
        If tabSpouse.Visible And cbxMarried_B.Checked Then
            If TxtFirstN_S.Text = "" Then
                MsgBox("Please fill the spouse's first name.", MsgBoxStyle.Information, "Info")
                TxtFirstN_S.Focus()
                Exit Sub
            End If
            If TxtLastN_S.Text = "" Then
                MsgBox("Please fill the spouse's last name.", MsgBoxStyle.Information, "Info")
                TxtLastN_S.Focus()
                Exit Sub
            End If
        End If

        '*** B O R R O W E R ***
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
        Dim House_B As String = ""
        If cbxOwned_B.Checked Then
            House_B = "Owned"
        ElseIf cbxFree_B.Checked Then
            House_B = "Free"
        ElseIf cbxRented_B.Checked Then
            House_B = "Rented"
        End If
        Dim EmplStatus_B As String = ""
        If cbxCasual_B.Checked Then
            EmplStatus_B = "Casual"
        ElseIf cbxTemporary_B.Checked Then
            EmplStatus_B = "Temporary"
        ElseIf cbxPermanent_B.Checked Then
            EmplStatus_B = "Permanent"
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
        Dim AccountT_3 As String = ""
        If cbxSA_3.Checked Then
            AccountT_3 = "SA"
        ElseIf cbxCA_3.Checked Then
            AccountT_3 = "CA"
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

        If btnSave.Text = "Save Draft" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_borrower WHERE (FirstN_B = '{0}' AND LastN_B = '{1}' AND Suffix_B = '{2}' AND Birth_B = '{3}' AND PlaceBirth_B = '{4}') AND `status` = 'ACTIVE'", TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text, Format(DtpBirth_B.Value, "yyyy-MM-dd"), cbxPlaceBirth_B.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Borrower {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Exist = DataObject(String.Format("SELECT ID FROM profile_borrower WHERE (FirstN_B = '{0}' AND LastN_B = '{1}' AND Suffix_B = '{2}') AND `status` = 'ACTIVE'", TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text))
                If Exist > 0 Then
                    If MsgBox(String.Format("Borrower {0} might already exist, please check the birthdate and place of birth of the existing {0}. Would you like to proceed?", BorrowerN), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                Cursor = Cursors.WaitCursor
                GetBorrower()

                '***BORROWER
                Dim SQL As String
                Try
                    SQL = "INSERT INTO profile_borrower SET"
                    SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                    SQL &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                    SQL &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                    SQL &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                    SQL &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                    SQL &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                    If tabSpouse.Visible Then
                        SQL &= String.Format(" Prefix_S = '{0}', ", CbxPrefix_S.Text)
                        SQL &= String.Format(" FirstN_S = '{0}', ", TxtFirstN_S.Text)
                        SQL &= String.Format(" MiddleN_S = '{0}', ", TxtMiddleN_S.Text)
                        SQL &= String.Format(" LastN_S = '{0}', ", TxtLastN_S.Text)
                        SQL &= String.Format(" Suffix_S = '{0}', ", cbxSuffix_S.Text)
                    End If
                    SQL &= String.Format(" NoC_B = '{0}', ", txtNoC_B.Text)
                    SQL &= String.Format(" StreetC_B = '{0}', ", txtStreetC_B.Text)
                    SQL &= String.Format(" BarangayC_B = '{0}', ", txtBarangayC_B.Text)
                    SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", ValidateComboBox(cbxAddressC_B))
                    SQL &= String.Format(" AddressC_B = '{0}', ", cbxAddressC_B.Text)
                    SQL &= String.Format(" NoP_B = '{0}', ", txtNoP_B.Text)
                    SQL &= String.Format(" StreetP_B = '{0}', ", txtStreetP_B.Text)
                    SQL &= String.Format(" BarangayP_B = '{0}', ", txtBarangayP_B.Text)
                    SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", ValidateComboBox(cbxAddressP_B))
                    SQL &= String.Format(" AddressP_B = '{0}', ", cbxAddressP_B.Text)
                    SQL &= String.Format(" Birth_B = '{0}', ", FormatDatePicker(DtpBirth_B))
                    SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_B))
                    SQL &= String.Format(" PlaceBirth_B = '{0}', ", cbxPlaceBirth_B.Text)
                    SQL &= String.Format(" Gender_B = '{0}', ", Gender_B)
                    SQL &= String.Format(" Civil_B = '{0}', ", Civil_B)
                    SQL &= String.Format(" Citizenship_B = '{0}', ", cbxCitizenship_B.Text)
                    SQL &= String.Format(" TIN_B = '{0}', ", txtTIN_B.Text)
                    SQL &= String.Format(" Telephone_B = '{0}', ", txtTelephone_B.Text)
                    SQL &= String.Format(" SSS_B = '{0}', ", txtSSS_B.Text)
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile_B.Text)
                    SQL &= String.Format(" Mobile_B2 = '{0}', ", txtMobile_B2.Text)
                    SQL &= String.Format(" Email_B = '{0}', ", txtEmail_B.Text)
                    SQL &= String.Format(" House_B = '{0}', ", House_B)
                    SQL &= String.Format(" Rent_B = '{0}', ", dRent_B.Value)

                    SQL &= String.Format(" Employer_B = '{0}', ", cbxEmployer_B.Text)
                    SQL &= String.Format(" EmployerAddress_B = '{0}', ", txtEmployerAddress_B.Text)
                    SQL &= String.Format(" EmployerTelephone_B = '{0}', ", txtEmployerTelephone_B.Text)
                    SQL &= String.Format(" Position_B = '{0}', ", cbxPosition_B.Text)
                    SQL &= String.Format(" EmploymentStat_B = '{0}', ", EmplStatus_B)
                    SQL &= String.Format(" Hired_B = '{0}', ", FormatDatePicker(dtpHired_B))
                    SQL &= String.Format(" Supervisor_B = '{0}', ", txtSupervisor_B.Text)
                    SQL &= String.Format(" Monthly_B = '{0}', ", dMonthly_B.Value)
                    SQL &= String.Format(" BusinessName_B = '{0}', ", txtBusinessName_B.Text)
                    SQL &= String.Format(" BusinessAddress_B = '{0}', ", txtBusinessAddress_B.Text)
                    SQL &= String.Format(" BusinessTelephone_B = '{0}', ", txtBusinessTelephone_B.Text)
                    SQL &= String.Format(" NatureBusiness_B = '{0}', ", cbxNatureBusiness_B.Text)
                    SQL &= String.Format(" YrsOperation_B = '{0}', ", iYrsOperation_B.Value)
                    SQL &= String.Format(" BusinessIncome_B = '{0}', ", dBusinessIncome_B.Value)
                    SQL &= String.Format(" NoEmployees_B = '{0}', ", iNoEmployees_B.Value)
                    SQL &= String.Format(" Capital_B = '{0}', ", dCapital_B.Value)
                    SQL &= String.Format(" Area_B = '{0}', ", txtArea_B.Text)
                    SQL &= String.Format(" Expiry_B = '{0}', ", FormatDatePicker(dtpExpiry_B))
                    SQL &= String.Format(" Outlet_B = '{0}', ", iOutlet_B.Value)
                    SQL &= String.Format(" OtherIncome_B = '{0}', ", txtOtherIncome_B.Text)
                    SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", dOtherIncome_B.Value)
                    SQL &= String.Format(" Creditor_1 = '{0}', ", txtCreditor_1.Text)
                    SQL &= String.Format(" NatureLoan_1 = '{0}', ", txtNatureLoan_1.Text)
                    SQL &= String.Format(" AmountGranted_1 = '{0}', ", dAmountGranted_1.Value)
                    SQL &= String.Format(" Term_1 = '{0}', ", dTerm_1.Value)
                    SQL &= String.Format(" Balance_1 = '{0}', ", dBalance_1.Value)
                    SQL &= String.Format(" CreditRemarks_1 = '{0}', ", txtCreditRemarks_1.Text)
                    SQL &= String.Format(" Creditor_2 = '{0}', ", txtCreditor_2.Text)
                    SQL &= String.Format(" NatureLoan_2 = '{0}', ", txtNatureLoan_2.Text)
                    SQL &= String.Format(" AmountGranted_2 = '{0}', ", dAmountGranted_2.Value)
                    SQL &= String.Format(" Term_2 = '{0}', ", dTerm_2.Value)
                    SQL &= String.Format(" Balance_2 = '{0}', ", dBalance_2.Value)
                    SQL &= String.Format(" CreditRemarks_2 = '{0}', ", txtCreditRemarks_2.Text)
                    SQL &= String.Format(" Creditor_3 = '{0}', ", txtCreditor_3.Text)
                    SQL &= String.Format(" NatureLoan_3 = '{0}', ", txtNatureLoan_3.Text)
                    SQL &= String.Format(" AmountGranted_3 = '{0}', ", dAmountGranted_3.Value)
                    SQL &= String.Format(" Term_3 = '{0}', ", dTerm_3.Value)
                    SQL &= String.Format(" Balance_3 = '{0}', ", dBalance_3.Value)
                    SQL &= String.Format(" CreditRemarks_3 = '{0}', ", txtCreditRemarks_3.Text)
                    SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                    SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                    SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                    SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                    SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                    SQL &= String.Format(" PresentBalance_1 = '{0}', ", dPresentBalance_1.Value)
                    SQL &= String.Format(" Opened_1 = '{0}', ", txtOpened_1.Text)
                    SQL &= String.Format(" BankRemarks_1 = '{0}', ", txtBankRemarks_1.Text)
                    SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                    SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                    SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                    SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                    SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                    SQL &= String.Format(" PresentBalance_2 = '{0}', ", dPresentBalance_2.Value)
                    SQL &= String.Format(" Opened_2 = '{0}', ", txtOpened_2.Text)
                    SQL &= String.Format(" BankRemarks_2 = '{0}', ", txtBankRemarks_2.Text)
                    SQL &= String.Format(" Bank_3 = '{0}', ", txtBank_3.Text)
                    SQL &= String.Format(" Branch_3 = '{0}', ", txtBranch_3.Text)
                    SQL &= String.Format(" AccountT_3 = '{0}', ", AccountT_3)
                    SQL &= String.Format(" SA_3 = '{0}', ", txtSA_3.Text)
                    SQL &= String.Format(" AverageBalance_3 = '{0}', ", dAverageBalance_3.Value)
                    SQL &= String.Format(" PresentBalance_3 = '{0}', ", dPresentBalance_3.Value)
                    SQL &= String.Format(" Opened_3 = '{0}', ", txtOpened_3.Text)
                    SQL &= String.Format(" BankRemarks_3 = '{0}', ", txtBankRemarks_3.Text)
                    SQL &= String.Format(" Location_1 = '{0}', ", txtLocation_1.Text)
                    SQL &= String.Format(" TCT_1 = '{0}', ", txtTCT_1.Text)
                    SQL &= String.Format(" Area_1 = '{0}', ", dArea_1.Value)
                    SQL &= String.Format(" Acquired_1 = '{0}', ", txtAcquired_1.Text)
                    SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", txtPropertiesRemarks_1.Text)
                    SQL &= String.Format(" Location_2 = '{0}', ", txtLocation_2.Text)
                    SQL &= String.Format(" TCT_2 = '{0}', ", txtTCT_2.Text)
                    SQL &= String.Format(" Area_2 = '{0}', ", dArea_2.Value)
                    SQL &= String.Format(" Acquired_2 = '{0}', ", txtAcquired_2.Text)
                    SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", txtPropertiesRemarks_2.Text)
                    SQL &= String.Format(" Location_3 = '{0}', ", txtLocation_3.Text)
                    SQL &= String.Format(" TCT_3 = '{0}', ", txtTCT_3.Text)
                    SQL &= String.Format(" Area_3 = '{0}', ", dArea_3.Value)
                    SQL &= String.Format(" Acquired_3 = '{0}', ", txtAcquired_3.Text)
                    SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", txtPropertiesRemarks_3.Text)
                    SQL &= String.Format(" Vehicle_1 = '{0}', ", txtVehicle_1.Text)
                    SQL &= String.Format(" Year_1 = '{0}', ", FormatDatePicker(dtpYear_1))
                    SQL &= String.Format(" WhomAcquired_1 = '{0}', ", txtWhomAcquired_1.Text)
                    SQL &= String.Format(" WhenAcquired_1 = '{0}', ", txtWhenAcquired_1.Text)
                    SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", txtVehicleRemarks_1.Text)
                    SQL &= String.Format(" Vehicle_2 = '{0}', ", txtVehicle_2.Text)
                    SQL &= String.Format(" Year_2 = '{0}', ", FormatDatePicker(dtpYear_2))
                    SQL &= String.Format(" WhomAcquired_2 = '{0}', ", txtWhomAcquired_2.Text)
                    SQL &= String.Format(" WhenAcquired_2 = '{0}', ", txtWhenAcquired_2.Text)
                    SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", txtVehicleRemarks_2.Text)
                    SQL &= String.Format(" Vehicle_3 = '{0}', ", txtVehicle_3.Text)
                    SQL &= String.Format(" Year_3 = '{0}', ", FormatDatePicker(dtpYear_3))
                    SQL &= String.Format(" WhomAcquired_3 = '{0}', ", txtWhomAcquired_3.Text)
                    SQL &= String.Format(" WhenAcquired_3 = '{0}', ", txtWhenAcquired_3.Text)
                    SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", txtVehicleRemarks_3.Text)
                    SQL &= String.Format(" HomeAppliances_1 = '{0}', ", txtHomeAppliances_1.Text)
                    SQL &= String.Format(" HomeAppliances_2 = '{0}', ", txtHomeAppliances_2.Text)
                    SQL &= String.Format(" Reference_1 = '{0}', ", txtReference_1.Text)
                    SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", txtReferenceAddress_1.Text)
                    SQL &= String.Format(" ReferenceContact_1 = '{0}', ", txtReferenceContact_1.Text)
                    SQL &= String.Format(" Reference_2 = '{0}', ", txtReference_2.Text)
                    SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", txtReferenceAddress_2.Text)
                    SQL &= String.Format(" ReferenceContact_2 = '{0}', ", txtReferenceContact_2.Text)
                    SQL &= String.Format(" Reference_3 = '{0}', ", txtReference_3.Text)
                    SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", txtReferenceAddress_3.Text)
                    SQL &= String.Format(" ReferenceContact_3 = '{0}', ", txtReferenceContact_3.Text)
                    SQL &= String.Format(" CertificateNo = '{0}', ", txtCertificateNo.Text)
                    SQL &= String.Format(" PlaceIssue = '{0}', ", txtPlaceIssue.Text)
                    SQL &= String.Format(" Issue = '{0}', ", FormatDatePicker(dtpIssue))
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
                    SQL &= String.Format(" YearHired = '{0}', ", If(cbxYearHired.Checked, 1, 0))
                    SQL &= String.Format(" YearFranchise = '{0}', ", If(cbxYearFranchise.Checked, 1, 0))
                    SQL &= String.Format(" user_code = '{0}';", User_Code)
                    If txtPath_B.Text <> "" Then
                        SaveImage(pb_B, "Borrower")
                    End If

                    For x As Integer = 0 To cbxNatureBusiness_B2.Properties.Items.Count - 1
                        If cbxNatureBusiness_B2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                            SQL &= "INSERT INTO profile_borrower_industry SET"
                            SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                            SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Value)
                            SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Description)
                            SQL &= " `Type` = 'Borrower';"
                        End If
                    Next
                Catch ex As Exception
                    Cursor = Cursors.Default
                    TriggerBugReport("Borrower - Save", ex.Message.ToString)
                    Exit Sub
                End Try

                'DEPENDENTS
                If FirstN_1 <> "" Then
                    SQL &= "INSERT INTO profile_dependent SET"
                    SQL &= String.Format(" DependentID = '{0}', ", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                    SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                    SQL &= String.Format(" Prefix_D = '{0}', ", Prefix_1)
                    SQL &= String.Format(" FirstN_D = '{0}', ", FirstN_1)
                    SQL &= String.Format(" MiddleN_D = '{0}', ", MiddleN_1)
                    SQL &= String.Format(" LastN_D = '{0}', ", LastN_1)
                    SQL &= String.Format(" Suffix_D = '{0}', ", Suffix_1)
                    SQL &= String.Format(" Birth_D = '{0}', ", Birth_1)
                    SQL &= String.Format(" Grade_D = '{0}', ", Grade_1)
                    SQL &= String.Format(" School_D = '{0}', ", School_1)
                    SQL &= String.Format(" SchoolAddress_D = '{0}', ", SchoolAddress_1)
                    SQL &= " `Rank` = 1, "
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    If FirstN_2 <> "" Then
                        SQL &= "INSERT INTO profile_dependent SET"
                        SQL &= String.Format(" DependentID = '{0}', ", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                        SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                        SQL &= String.Format(" Prefix_D = '{0}', ", Prefix_2)
                        SQL &= String.Format(" FirstN_D = '{0}', ", FirstN_2)
                        SQL &= String.Format(" MiddleN_D = '{0}', ", MiddleN_2)
                        SQL &= String.Format(" LastN_D = '{0}', ", LastN_2)
                        SQL &= String.Format(" Suffix_D = '{0}', ", Suffix_2)
                        SQL &= String.Format(" Birth_D = '{0}', ", Birth_2)
                        SQL &= String.Format(" Grade_D = '{0}', ", Grade_2)
                        SQL &= String.Format(" School_D = '{0}', ", School_2)
                        SQL &= String.Format(" SchoolAddress_D = '{0}', ", SchoolAddress_2)
                        SQL &= " `Rank` = 2, "
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        If FirstN_3 <> "" Then
                            SQL &= "INSERT INTO profile_dependent SET"
                            SQL &= String.Format(" DependentID = '{0}', ", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                            SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                            SQL &= String.Format(" Prefix_D = '{0}', ", Prefix_3)
                            SQL &= String.Format(" FirstN_D = '{0}', ", FirstN_3)
                            SQL &= String.Format(" MiddleN_D = '{0}', ", MiddleN_3)
                            SQL &= String.Format(" LastN_D = '{0}', ", LastN_3)
                            SQL &= String.Format(" Suffix_D = '{0}', ", Suffix_3)
                            SQL &= String.Format(" Birth_D = '{0}', ", Birth_3)
                            SQL &= String.Format(" Grade_D = '{0}', ", Grade_3)
                            SQL &= String.Format(" School_D = '{0}', ", School_3)
                            SQL &= String.Format(" SchoolAddress_D = '{0}', ", SchoolAddress_3)
                            SQL &= " `Rank` = 3, "
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            If FirstN_4 <> "" Then
                                SQL &= "INSERT INTO profile_dependent SET"
                                SQL &= String.Format(" DependentID = '{0}', ", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                                SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                                SQL &= String.Format(" Prefix_D = '{0}', ", Prefix_4)
                                SQL &= String.Format(" FirstN_D = '{0}', ", FirstN_4)
                                SQL &= String.Format(" MiddleN_D = '{0}', ", MiddleN_4)
                                SQL &= String.Format(" LastN_D = '{0}', ", LastN_4)
                                SQL &= String.Format(" Suffix_D = '{0}', ", Suffix_4)
                                SQL &= String.Format(" Birth_D = '{0}', ", Birth_4)
                                SQL &= String.Format(" Grade_D = '{0}', ", Grade_4)
                                SQL &= String.Format(" School_D = '{0}', ", School_4)
                                SQL &= String.Format(" SchoolAddress_D = '{0}', ", SchoolAddress_4)
                                SQL &= " `Rank` = 4, "
                                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            End If
                        End If
                    End If
                End If

                'IDENTIFICATION
                SQL &= "INSERT INTO profile_borrowerid SET"
                SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_B.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_B.Text)
                SQL &= String.Format(" GSIS = '{0}', ", GSIS)
                SQL &= String.Format(" PhilHealth = '{0}', ", PhilHealth)
                SQL &= String.Format(" Senior = '{0}', ", Senior)
                SQL &= String.Format(" UMID = '{0}', ", UMID)
                SQL &= String.Format(" SEC = '{0}', ", SEC)
                SQL &= String.Format(" DTI = '{0}', ", DTI)
                SQL &= String.Format(" CDA = '{0}', ", CDA)
                SQL &= String.Format(" Cooperative = '{0}', ", Cooperative)
                SQL &= String.Format(" Drivers = '{0}', ", Drivers)
                SQL &= String.Format(" dDrivers = '{0}', ", dDrivers)
                SQL &= String.Format(" VIN = '{0}', ", VIN)
                SQL &= String.Format(" dVIN = '{0}', ", dVIN)
                SQL &= String.Format(" Passport = '{0}', ", Passport)
                SQL &= String.Format(" dPassport = '{0}', ", dPassport)
                SQL &= String.Format(" PRC = '{0}', ", PRC)
                SQL &= String.Format(" dPRC = '{0}', ", dPRC)
                SQL &= String.Format(" NBI = '{0}', ", NBI)
                SQL &= String.Format(" dNBI = '{0}', ", dNBI)
                SQL &= String.Format(" Police = '{0}', ", Police)
                SQL &= String.Format(" dPolice = '{0}', ", dPolice)
                SQL &= String.Format(" Postal = '{0}', ", Postal)
                SQL &= String.Format(" dPostal = '{0}', ", dPostal)
                SQL &= String.Format(" Barangay = '{0}', ", Barangay)
                SQL &= String.Format(" dBarangay = '{0}', ", dBarangay)
                SQL &= String.Format(" OWWA = '{0}', ", OWWA)
                SQL &= String.Format(" dOWWA = '{0}', ", dOWWA)
                SQL &= String.Format(" OFW = '{0}', ", OFW)
                SQL &= String.Format(" dOFW = '{0}', ", dOFW)
                SQL &= String.Format(" Seaman = '{0}', ", Seaman)
                SQL &= String.Format(" dSeaman = '{0}', ", dSeaman)
                SQL &= String.Format(" PNP = '{0}', ", PNP)
                SQL &= String.Format(" dPNP = '{0}', ", dPNP)
                SQL &= String.Format(" AFP = '{0}', ", AFP)
                SQL &= String.Format(" dAFP = '{0}', ", dAFP)
                SQL &= String.Format(" HDMF = '{0}', ", HDMF)
                SQL &= String.Format(" dHDMF = '{0}', ", dHDMF)
                SQL &= String.Format(" PWD = '{0}', ", PWD)
                SQL &= String.Format(" dPWD = '{0}', ", dPWD)
                SQL &= String.Format(" DSWD = '{0}', ", DSWD)
                SQL &= String.Format(" dDSWD = '{0}', ", dDSWD)
                SQL &= String.Format(" ACR = '{0}', ", ACR)
                SQL &= String.Format(" dACR = '{0}', ", dACR)
                SQL &= String.Format(" DTI_Business = '{0}', ", DTI_Business)
                SQL &= String.Format(" dDTI_Business = '{0}', ", dDTI_Business)
                SQL &= String.Format(" IBP = '{0}', ", IBP)
                SQL &= String.Format(" dIBP = '{0}', ", dIBP)
                SQL &= String.Format(" FireArms = '{0}', ", FireArms)
                SQL &= String.Format(" dFireArms = '{0}', ", dFireArms)
                SQL &= String.Format(" Government = '{0}', ", Government)
                SQL &= String.Format(" dGovernment = '{0}', ", dGovernment)
                SQL &= String.Format(" Diplomat = '{0}', ", Diplomat)
                SQL &= String.Format(" dDiplomat = '{0}', ", dDiplomat)
                SQL &= String.Format(" `National` = '{0}', ", National)
                SQL &= String.Format(" dNational = '{0}', ", dNational)
                SQL &= String.Format(" `Work` = '{0}', ", Work)
                SQL &= String.Format(" dWork = '{0}', ", dWork)
                SQL &= String.Format(" GOCC = '{0}', ", GOCC)
                SQL &= String.Format(" dGOCC = '{0}', ", dGOCC)
                SQL &= String.Format(" PLRA = '{0}', ", PLRA)
                SQL &= String.Format(" dPLRA = '{0}', ", dPLRA)
                SQL &= String.Format(" Major = '{0}', ", Major)
                SQL &= String.Format(" dMajor = '{0}', ", dMajor)
                SQL &= String.Format(" Media = '{0}', ", Media)
                SQL &= String.Format(" dMedia = '{0}', ", dMedia)
                SQL &= String.Format(" Student = '{0}', ", Student)
                SQL &= String.Format(" dStudent = '{0}', ", dStudent)
                SQL &= String.Format(" SIRV = '{0}', ", SIRV)
                SQL &= String.Format(" dSIRV = '{0}', ", dSIRV)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                If tabSpouse.Visible Then
                    '***SPOUSE
                    Dim Gender_S As String = ""
                    If cbxMale_S.Checked Then
                        Gender_S = "Male"
                    ElseIf cbxFemale_S.Checked Then
                        Gender_S = "Female"
                    End If
                    Dim House_S As String = ""
                    If cbxOwned_S.Checked Then
                        House_S = "Owned"
                    ElseIf cbxFree_S.Checked Then
                        House_S = "Free"
                    ElseIf cbxRented_S.Checked Then
                        House_S = "Rented"
                    End If
                    Dim EmplStatus_S As String = ""
                    If cbxCasual_S.Checked Then
                        EmplStatus_S = "Casual"
                    ElseIf cbxTemporary_S.Checked Then
                        EmplStatus_S = "Temporary"
                    ElseIf cbxPermanent_S.Checked Then
                        EmplStatus_S = "Permanent"
                    End If

                    SQL &= "INSERT INTO profile_spouse SET"
                    SQL &= String.Format(" SpouseID = '{0}', ", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_spouse WHERE branch_id = '{0}';", Branch_ID)))
                    SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                    SQL &= String.Format(" Prefix_S = '{0}', ", CbxPrefix_S.Text)
                    SQL &= String.Format(" FirstN_S = '{0}', ", TxtFirstN_S.Text)
                    SQL &= String.Format(" MiddleN_S = '{0}', ", TxtMiddleN_S.Text)
                    SQL &= String.Format(" LastN_S = '{0}', ", TxtLastN_S.Text)
                    SQL &= String.Format(" Suffix_S = '{0}', ", cbxSuffix_S.Text)
                    SQL &= String.Format(" Prefix_M = '{0}', ", CbxPrefix_M.Text)
                    SQL &= String.Format(" FirstN_M = '{0}', ", TxtFirstN_M.Text)
                    SQL &= String.Format(" MiddleN_M = '{0}', ", TxtMiddleN_M.Text)
                    SQL &= String.Format(" LastN_M = '{0}', ", TxtLastN_M.Text)
                    SQL &= String.Format(" Suffix_M = '{0}', ", cbxSuffix_M.Text)
                    SQL &= String.Format(" NoC_S = '{0}', ", txtNoC_S.Text)
                    SQL &= String.Format(" StreetC_S = '{0}', ", txtStreetC_S.Text)
                    SQL &= String.Format(" BarangayC_S = '{0}', ", txtBarangayC_S.Text)
                    SQL &= String.Format(" `AddressC_S-ID` = '{0}', ", ValidateComboBox(cbxAddressC_S))
                    SQL &= String.Format(" AddressC_S = '{0}', ", cbxAddressC_S.Text)
                    SQL &= String.Format(" NoP_S = '{0}', ", txtNoP_S.Text)
                    SQL &= String.Format(" StreetP_S = '{0}', ", txtStreetP_S.Text)
                    SQL &= String.Format(" BarangayP_S = '{0}', ", txtBarangayP_S.Text)
                    SQL &= String.Format(" `AddressP_S-ID` = '{0}', ", ValidateComboBox(cbxAddressP_S))
                    SQL &= String.Format(" AddressP_S = '{0}', ", cbxAddressP_S.Text)
                    SQL &= String.Format(" Birth_S = '{0}', ", FormatDatePicker(DtpBirth_S))
                    SQL &= String.Format(" `PlaceBirth_S-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_S))
                    SQL &= String.Format(" PlaceBirth_S = '{0}', ", cbxPlaceBirth_S.Text)
                    SQL &= String.Format(" Gender_S = '{0}', ", Gender_S)
                    SQL &= String.Format(" Citizenship_S = '{0}', ", txtCitizenship_S.Text)
                    SQL &= String.Format(" TIN_S = '{0}', ", txtTIN_S.Text)
                    SQL &= String.Format(" Telephone_S = '{0}', ", txtTelephone_S.Text)
                    SQL &= String.Format(" SSS_S = '{0}', ", txtSSS_S.Text)
                    SQL &= String.Format(" Mobile_S = '{0}', ", txtMobile_S.Text)
                    SQL &= String.Format(" Email_S = '{0}', ", txtEmail_S.Text)
                    SQL &= String.Format(" House_S = '{0}', ", House_S)
                    SQL &= String.Format(" Rent_S = '{0}', ", dRent_S.Value)
                    SQL &= String.Format(" Employer_S = '{0}', ", cbxEmployer_S.Text)
                    SQL &= String.Format(" EmployerAddress_S = '{0}', ", txtEmployerAddress_S.Text)
                    SQL &= String.Format(" EmployerTelephone_S = '{0}', ", txtEmployerTelephone_S.Text)
                    SQL &= String.Format(" Position_S = '{0}', ", cbxPosition_S.Text)
                    SQL &= String.Format(" EmploymentStat_S = '{0}', ", EmplStatus_S)
                    SQL &= String.Format(" Hired_S = '{0}', ", FormatDatePicker(dtpHired_S))
                    SQL &= String.Format(" YearHired_S = '{0}', ", If(cbxYearHired_S.Checked, 1, 0))
                    SQL &= String.Format(" Supervisor_S = '{0}', ", txtSupervisor_S.Text)
                    SQL &= String.Format(" Monthly_S = '{0}', ", dMonthly_S.Value)
                    SQL &= String.Format(" BusinessName_S = '{0}', ", txtBusinessName_S.Text)
                    SQL &= String.Format(" BusinessAddress_S = '{0}', ", txtBusinessAddress_S.Text)
                    SQL &= String.Format(" BusinessTelephone_S = '{0}', ", txtBusinessTelephone_S.Text)
                    SQL &= String.Format(" NatureBusiness_S = '{0}', ", cbxNatureBusiness_S.Text)
                    SQL &= String.Format(" YrsOperation_S = '{0}', ", iYrsOperation_S.Value)
                    SQL &= String.Format(" BusinessIncome_S = '{0}', ", dBusinessIncome_S.Value)
                    SQL &= String.Format(" NoEmployees_S = '{0}', ", iNoEmployees_S.Value)
                    SQL &= String.Format(" Capital_S = '{0}', ", dCapital_S.Value)
                    SQL &= String.Format(" Area_S = '{0}', ", txtArea_S.Text)
                    SQL &= String.Format(" Expiry_S = '{0}', ", FormatDatePicker(dtpExpiry_S))
                    SQL &= String.Format(" Outlet_S = '{0}', ", iOutlet_S.Value)
                    SQL &= String.Format(" OtherIncome_S = '{0}', ", txtOtherIncome_S.Text)
                    SQL &= String.Format(" `OtherIncome_S-Amount` = '{0}', ", dOtherIncome_S.Value)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    If txtPath_S.Text <> "" Then
                        SaveImage(pb_S, "Spouse")
                    End If

                    SQL &= "INSERT profile_borrowerid SET"
                    SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                    SQL &= String.Format(" TIN = '{0}', ", txtTIN_S.Text)
                    SQL &= String.Format(" SSS = '{0}', ", txtSSS_S.Text)
                    SQL &= String.Format(" GSIS = '{0}', ", GSIS_S)
                    SQL &= String.Format(" PhilHealth = '{0}', ", PhilHealth_S)
                    SQL &= String.Format(" Senior = '{0}', ", Senior_S)
                    SQL &= String.Format(" UMID = '{0}', ", UMID_S)
                    SQL &= String.Format(" SEC = '{0}', ", SEC_S)
                    SQL &= String.Format(" DTI = '{0}', ", DTI_S)
                    SQL &= String.Format(" CDA = '{0}', ", CDA_S)
                    SQL &= String.Format(" Cooperative = '{0}', ", Cooperative_S)
                    SQL &= String.Format(" Drivers = '{0}', ", Drivers_S)
                    SQL &= String.Format(" dDrivers = '{0}', ", dDrivers_S)
                    SQL &= String.Format(" VIN = '{0}', ", VIN_S)
                    SQL &= String.Format(" dVIN = '{0}', ", dVIN_S)
                    SQL &= String.Format(" Passport = '{0}', ", Passport_S)
                    SQL &= String.Format(" dPassport = '{0}', ", dPassport_S)
                    SQL &= String.Format(" PRC = '{0}', ", PRC_S)
                    SQL &= String.Format(" dPRC = '{0}', ", dPRC_S)
                    SQL &= String.Format(" NBI = '{0}', ", NBI_S)
                    SQL &= String.Format(" dNBI = '{0}', ", dNBI_S)
                    SQL &= String.Format(" Police = '{0}', ", Police_S)
                    SQL &= String.Format(" dPolice = '{0}', ", dPolice_S)
                    SQL &= String.Format(" Postal = '{0}', ", Postal_S)
                    SQL &= String.Format(" dPostal = '{0}', ", dPostal_S)
                    SQL &= String.Format(" Barangay = '{0}', ", Barangay_S)
                    SQL &= String.Format(" dBarangay = '{0}', ", dBarangay_S)
                    SQL &= String.Format(" OWWA = '{0}', ", OWWA_S)
                    SQL &= String.Format(" dOWWA = '{0}', ", dOWWA_S)
                    SQL &= String.Format(" OFW = '{0}', ", OFW_S)
                    SQL &= String.Format(" dOFW = '{0}', ", dOFW_S)
                    SQL &= String.Format(" Seaman = '{0}', ", Seaman_S)
                    SQL &= String.Format(" dSeaman = '{0}', ", dSeaman_S)
                    SQL &= String.Format(" PNP = '{0}', ", PNP_S)
                    SQL &= String.Format(" dPNP = '{0}', ", dPNP_S)
                    SQL &= String.Format(" AFP = '{0}', ", AFP_S)
                    SQL &= String.Format(" dAFP = '{0}', ", dAFP_S)
                    SQL &= String.Format(" HDMF = '{0}', ", HDMF_S)
                    SQL &= String.Format(" dHDMF = '{0}', ", dHDMF_S)
                    SQL &= String.Format(" PWD = '{0}', ", PWD_S)
                    SQL &= String.Format(" dPWD = '{0}', ", dPWD_S)
                    SQL &= String.Format(" DSWD = '{0}', ", DSWD_S)
                    SQL &= String.Format(" dDSWD = '{0}', ", dDSWD_S)
                    SQL &= String.Format(" ACR = '{0}', ", ACR_S)
                    SQL &= String.Format(" dACR = '{0}', ", dACR_S)
                    SQL &= String.Format(" DTI_Business = '{0}', ", DTI_Business_S)
                    SQL &= String.Format(" dDTI_Business = '{0}', ", dDTI_Business_S)
                    SQL &= String.Format(" IBP = '{0}', ", IBP_S)
                    SQL &= String.Format(" dIBP = '{0}', ", dIBP_S)
                    SQL &= String.Format(" FireArms = '{0}', ", FireArms_S)
                    SQL &= String.Format(" dFireArms = '{0}', ", dFireArms_S)
                    SQL &= String.Format(" Government = '{0}', ", Government_S)
                    SQL &= String.Format(" dGovernment = '{0}', ", dGovernment_S)
                    SQL &= String.Format(" Diplomat = '{0}', ", Diplomat_S)
                    SQL &= String.Format(" dDiplomat = '{0}', ", dDiplomat_S)
                    SQL &= String.Format(" `National` = '{0}', ", National_S)
                    SQL &= String.Format(" dNational = '{0}', ", dNational_S)
                    SQL &= String.Format(" `Work` = '{0}', ", Work_S)
                    SQL &= String.Format(" dWork = '{0}', ", dWork_S)
                    SQL &= String.Format(" GOCC = '{0}', ", GOCC_S)
                    SQL &= String.Format(" dGOCC = '{0}', ", dGOCC_S)
                    SQL &= String.Format(" PLRA = '{0}', ", PLRA_S)
                    SQL &= String.Format(" dPLRA = '{0}', ", dPLRA_S)
                    SQL &= String.Format(" Major = '{0}', ", Major_S)
                    SQL &= String.Format(" dMajor = '{0}', ", dMajor_S)
                    SQL &= String.Format(" Media = '{0}', ", Media_S)
                    SQL &= String.Format(" dMedia = '{0}', ", dMedia_S)
                    SQL &= String.Format(" Student = '{0}', ", Student_S)
                    SQL &= String.Format(" dStudent = '{0}', ", dStudent_S)
                    SQL &= String.Format(" SIRV = '{0}', ", SIRV_S)
                    SQL &= String.Format(" dSIRV = '{0}', ", dSIRV_S)
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    SQL &= "ID_Type = 'S';"

                    For x As Integer = 0 To cbxNatureBusiness_S2.Properties.Items.Count - 1
                        If cbxNatureBusiness_S2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                            SQL &= "INSERT INTO profile_borrower_industry SET"
                            SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                            SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Value)
                            SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Description)
                            SQL &= " `Type` = 'Spouse';"
                        End If
                    Next
                End If

                DataObject(SQL)
                Cursor = Cursors.Default
                Logs("Borrower", "Save", String.Format("Add new borrower {0}", BorrowerN), "", txtBorrowerID.Text, BorrowerN, "")
                Clear()
                FrmBorrowerList.LoadData()
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_borrower WHERE (FirstN_B = '{0}' AND LastN_B = '{1}' AND Suffix_B = '{2}' AND Birth_B = '{4}' AND PlaceBirth_B = '{5}') AND `status` = 'ACTIVE' AND BorrowerID != '{3}'", TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text, txtBorrowerID.Text, Format(DtpBirth_B.Value, "yyyy-MM-dd"), cbxPlaceBirth_B.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Borrower {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                '***BORROWER
                Cursor = Cursors.WaitCursor
                Dim SQL As String
                Try
                    SQL = "UPDATE profile_borrower SET"
                    SQL &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                    SQL &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                    SQL &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                    SQL &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                    SQL &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                    If tabSpouse.Visible Then
                        SQL &= String.Format(" Prefix_S = '{0}', ", CbxPrefix_S.Text)
                        SQL &= String.Format(" FirstN_S = '{0}', ", TxtFirstN_S.Text)
                        SQL &= String.Format(" MiddleN_S = '{0}', ", TxtMiddleN_S.Text)
                        SQL &= String.Format(" LastN_S = '{0}', ", TxtLastN_S.Text)
                        SQL &= String.Format(" Suffix_S = '{0}', ", cbxSuffix_S.Text)
                    End If
                    SQL &= String.Format(" NoC_B = '{0}', ", txtNoC_B.Text)
                    SQL &= String.Format(" StreetC_B = '{0}', ", txtStreetC_B.Text)
                    SQL &= String.Format(" BarangayC_B = '{0}', ", txtBarangayC_B.Text)
                    SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", ValidateComboBox(cbxAddressC_B))
                    SQL &= String.Format(" AddressC_B = '{0}', ", cbxAddressC_B.Text)
                    SQL &= String.Format(" NoP_B = '{0}', ", txtNoP_B.Text)
                    SQL &= String.Format(" StreetP_B = '{0}', ", txtStreetP_B.Text)
                    SQL &= String.Format(" BarangayP_B = '{0}', ", txtBarangayP_B.Text)
                    SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", ValidateComboBox(cbxAddressP_B))
                    SQL &= String.Format(" AddressP_B = '{0}', ", cbxAddressP_B.Text)
                    SQL &= String.Format(" Birth_B = '{0}', ", FormatDatePicker(DtpBirth_B))
                    SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_B))
                    SQL &= String.Format(" PlaceBirth_B = '{0}', ", cbxPlaceBirth_B.Text)
                    SQL &= String.Format(" Gender_B = '{0}', ", Gender_B)
                    SQL &= String.Format(" Civil_B = '{0}', ", Civil_B)
                    SQL &= String.Format(" Citizenship_B = '{0}', ", cbxCitizenship_B.Text)
                    SQL &= String.Format(" TIN_B = '{0}', ", txtTIN_B.Text)
                    SQL &= String.Format(" Telephone_B = '{0}', ", txtTelephone_B.Text)
                    SQL &= String.Format(" SSS_B = '{0}', ", txtSSS_B.Text)
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile_B.Text)
                    SQL &= String.Format(" Mobile_B2 = '{0}', ", txtMobile_B2.Text)
                    SQL &= String.Format(" Email_B = '{0}', ", txtEmail_B.Text)
                    SQL &= String.Format(" House_B = '{0}', ", House_B)
                    SQL &= String.Format(" Rent_B = '{0}', ", dRent_B.Value)

                    SQL &= String.Format(" Employer_B = '{0}', ", cbxEmployer_B.Text)
                    SQL &= String.Format(" EmployerAddress_B = '{0}', ", txtEmployerAddress_B.Text)
                    SQL &= String.Format(" EmployerTelephone_B = '{0}', ", txtEmployerTelephone_B.Text)
                    SQL &= String.Format(" Position_B = '{0}', ", cbxPosition_B.Text)
                    SQL &= String.Format(" EmploymentStat_B = '{0}', ", EmplStatus_B)
                    SQL &= String.Format(" Hired_B = '{0}', ", FormatDatePicker(dtpHired_B))
                    SQL &= String.Format(" Supervisor_B = '{0}', ", txtSupervisor_B.Text)
                    SQL &= String.Format(" Monthly_B = '{0}', ", dMonthly_B.Value)
                    SQL &= String.Format(" BusinessName_B = '{0}', ", txtBusinessName_B.Text)
                    SQL &= String.Format(" BusinessAddress_B = '{0}', ", txtBusinessAddress_B.Text)
                    SQL &= String.Format(" BusinessTelephone_B = '{0}', ", txtBusinessTelephone_B.Text)
                    SQL &= String.Format(" NatureBusiness_B = '{0}', ", cbxNatureBusiness_B.Text)
                    SQL &= String.Format(" YrsOperation_B = '{0}', ", iYrsOperation_B.Value)
                    SQL &= String.Format(" BusinessIncome_B = '{0}', ", dBusinessIncome_B.Value)
                    SQL &= String.Format(" NoEmployees_B = '{0}', ", iNoEmployees_B.Value)
                    SQL &= String.Format(" Capital_B = '{0}', ", dCapital_B.Value)
                    SQL &= String.Format(" Area_B = '{0}', ", txtArea_B.Text)
                    SQL &= String.Format(" Expiry_B = '{0}', ", FormatDatePicker(dtpExpiry_B))
                    SQL &= String.Format(" Outlet_B = '{0}', ", iOutlet_B.Value)
                    SQL &= String.Format(" OtherIncome_B = '{0}', ", txtOtherIncome_B.Text)
                    SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", dOtherIncome_B.Value)
                    SQL &= String.Format(" Creditor_1 = '{0}', ", txtCreditor_1.Text)
                    SQL &= String.Format(" NatureLoan_1 = '{0}', ", txtNatureLoan_1.Text)
                    SQL &= String.Format(" AmountGranted_1 = '{0}', ", dAmountGranted_1.Value)
                    SQL &= String.Format(" Term_1 = '{0}', ", dTerm_1.Value)
                    SQL &= String.Format(" Balance_1 = '{0}', ", dBalance_1.Value)
                    SQL &= String.Format(" CreditRemarks_1 = '{0}', ", txtCreditRemarks_1.Text)
                    SQL &= String.Format(" Creditor_2 = '{0}', ", txtCreditor_2.Text)
                    SQL &= String.Format(" NatureLoan_2 = '{0}', ", txtNatureLoan_2.Text)
                    SQL &= String.Format(" AmountGranted_2 = '{0}', ", dAmountGranted_2.Value)
                    SQL &= String.Format(" Term_2 = '{0}', ", dTerm_2.Value)
                    SQL &= String.Format(" Balance_2 = '{0}', ", dBalance_2.Value)
                    SQL &= String.Format(" CreditRemarks_2 = '{0}', ", txtCreditRemarks_2.Text)
                    SQL &= String.Format(" Creditor_3 = '{0}', ", txtCreditor_3.Text)
                    SQL &= String.Format(" NatureLoan_3 = '{0}', ", txtNatureLoan_3.Text)
                    SQL &= String.Format(" AmountGranted_3 = '{0}', ", dAmountGranted_3.Value)
                    SQL &= String.Format(" Term_3 = '{0}', ", dTerm_3.Value)
                    SQL &= String.Format(" Balance_3 = '{0}', ", dBalance_3.Value)
                    SQL &= String.Format(" CreditRemarks_3 = '{0}', ", txtCreditRemarks_3.Text)
                    SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                    SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                    SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                    SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                    SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                    SQL &= String.Format(" PresentBalance_1 = '{0}', ", dPresentBalance_1.Value)
                    SQL &= String.Format(" Opened_1 = '{0}', ", txtOpened_1.Text)
                    SQL &= String.Format(" BankRemarks_1 = '{0}', ", txtBankRemarks_1.Text)
                    SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                    SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                    SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                    SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                    SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                    SQL &= String.Format(" PresentBalance_2 = '{0}', ", dPresentBalance_2.Value)
                    SQL &= String.Format(" Opened_2 = '{0}', ", txtOpened_2.Text)
                    SQL &= String.Format(" BankRemarks_2 = '{0}', ", txtBankRemarks_2.Text)
                    SQL &= String.Format(" Bank_3 = '{0}', ", txtBank_3.Text)
                    SQL &= String.Format(" Branch_3 = '{0}', ", txtBranch_3.Text)
                    SQL &= String.Format(" AccountT_3 = '{0}', ", AccountT_3)
                    SQL &= String.Format(" SA_3 = '{0}', ", txtSA_3.Text)
                    SQL &= String.Format(" AverageBalance_3 = '{0}', ", dAverageBalance_3.Value)
                    SQL &= String.Format(" PresentBalance_3 = '{0}', ", dPresentBalance_3.Value)
                    SQL &= String.Format(" Opened_3 = '{0}', ", txtOpened_3.Text)
                    SQL &= String.Format(" BankRemarks_3 = '{0}', ", txtBankRemarks_3.Text)
                    SQL &= String.Format(" Location_1 = '{0}', ", txtLocation_1.Text)
                    SQL &= String.Format(" TCT_1 = '{0}', ", txtTCT_1.Text)
                    SQL &= String.Format(" Area_1 = '{0}', ", dArea_1.Value)
                    SQL &= String.Format(" Acquired_1 = '{0}', ", txtAcquired_1.Text)
                    SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", txtPropertiesRemarks_1.Text)
                    SQL &= String.Format(" Location_2 = '{0}', ", txtLocation_2.Text)
                    SQL &= String.Format(" TCT_2 = '{0}', ", txtTCT_2.Text)
                    SQL &= String.Format(" Area_2 = '{0}', ", dArea_2.Value)
                    SQL &= String.Format(" Acquired_2 = '{0}', ", txtAcquired_2.Text)
                    SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", txtPropertiesRemarks_2.Text)
                    SQL &= String.Format(" Location_3 = '{0}', ", txtLocation_3.Text)
                    SQL &= String.Format(" TCT_3 = '{0}', ", txtTCT_3.Text)
                    SQL &= String.Format(" Area_3 = '{0}', ", dArea_3.Value)
                    SQL &= String.Format(" Acquired_3 = '{0}', ", txtAcquired_3.Text)
                    SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", txtPropertiesRemarks_3.Text)
                    SQL &= String.Format(" Vehicle_1 = '{0}', ", txtVehicle_1.Text)
                    SQL &= String.Format(" Year_1 = '{0}', ", FormatDatePicker(dtpYear_1))
                    SQL &= String.Format(" WhomAcquired_1 = '{0}', ", txtWhomAcquired_1.Text)
                    SQL &= String.Format(" WhenAcquired_1 = '{0}', ", txtWhenAcquired_1.Text)
                    SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", txtVehicleRemarks_1.Text)
                    SQL &= String.Format(" Vehicle_2 = '{0}', ", txtVehicle_2.Text)
                    SQL &= String.Format(" Year_2 = '{0}', ", FormatDatePicker(dtpYear_2))
                    SQL &= String.Format(" WhomAcquired_2 = '{0}', ", txtWhomAcquired_2.Text)
                    SQL &= String.Format(" WhenAcquired_2 = '{0}', ", txtWhenAcquired_2.Text)
                    SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", txtVehicleRemarks_2.Text)
                    SQL &= String.Format(" Vehicle_3 = '{0}', ", txtVehicle_3.Text)
                    SQL &= String.Format(" Year_3 = '{0}', ", FormatDatePicker(dtpYear_3))
                    SQL &= String.Format(" WhomAcquired_3 = '{0}', ", txtWhomAcquired_3.Text)
                    SQL &= String.Format(" WhenAcquired_3 = '{0}', ", txtWhenAcquired_3.Text)
                    SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", txtVehicleRemarks_3.Text)
                    SQL &= String.Format(" HomeAppliances_1 = '{0}', ", txtHomeAppliances_1.Text)
                    SQL &= String.Format(" HomeAppliances_2 = '{0}', ", txtHomeAppliances_2.Text)
                    SQL &= String.Format(" Reference_1 = '{0}', ", txtReference_1.Text)
                    SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", txtReferenceAddress_1.Text)
                    SQL &= String.Format(" ReferenceContact_1 = '{0}', ", txtReferenceContact_1.Text)
                    SQL &= String.Format(" Reference_2 = '{0}', ", txtReference_2.Text)
                    SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", txtReferenceAddress_2.Text)
                    SQL &= String.Format(" ReferenceContact_2 = '{0}', ", txtReferenceContact_2.Text)
                    SQL &= String.Format(" Reference_3 = '{0}', ", txtReference_3.Text)
                    SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", txtReferenceAddress_3.Text)
                    SQL &= String.Format(" ReferenceContact_3 = '{0}', ", txtReferenceContact_3.Text)
                    SQL &= String.Format(" CertificateNo = '{0}', ", txtCertificateNo.Text)
                    SQL &= String.Format(" PlaceIssue = '{0}', ", txtPlaceIssue.Text)
                    SQL &= String.Format(" Issue = '{0}', ", FormatDatePicker(dtpIssue))
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
                    SQL &= String.Format(" YearHired = '{0}', ", If(cbxYearHired.Checked, 1, 0))
                    SQL &= String.Format(" YearFranchise = '{0}', ", If(cbxYearFranchise.Checked, 1, 0))
                    SQL &= String.Format(" DealerNo = '{0}' ", DealerNo)
                    SQL &= String.Format(" WHERE BorrowerID = '{0}';", txtBorrowerID.Text)

                    'UPDATE PROFILE OF CREDIT APPLICATION WHICH IS NOT YET RELEASED ****************************************************
                    SQL &= "UPDATE credit_application SET"
                    SQL &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                    SQL &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                    SQL &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                    SQL &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                    SQL &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                    SQL &= String.Format(" Prefix_S = '{0}', ", CbxPrefix_S.Text)
                    SQL &= String.Format(" FirstN_S = '{0}', ", TxtFirstN_S.Text)
                    SQL &= String.Format(" MiddleN_S = '{0}', ", TxtMiddleN_S.Text)
                    SQL &= String.Format(" LastN_S = '{0}', ", TxtLastN_S.Text)
                    SQL &= String.Format(" Suffix_S = '{0}', ", cbxSuffix_S.Text)
                    SQL &= String.Format(" NoC_B = '{0}', ", txtNoC_B.Text)
                    SQL &= String.Format(" StreetC_B = '{0}', ", txtStreetC_B.Text)
                    SQL &= String.Format(" BarangayC_B = '{0}', ", txtBarangayC_B.Text)
                    SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", ValidateComboBox(cbxAddressC_B))
                    SQL &= String.Format(" AddressC_B = '{0}', ", cbxAddressC_B.Text)
                    SQL &= String.Format(" NoP_B = '{0}', ", txtNoP_B.Text)
                    SQL &= String.Format(" StreetP_B = '{0}', ", txtStreetP_B.Text)
                    SQL &= String.Format(" BarangayP_B = '{0}', ", txtBarangayP_B.Text)
                    SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", ValidateComboBox(cbxAddressP_B))
                    SQL &= String.Format(" AddressP_B = '{0}', ", cbxAddressP_B.Text)
                    SQL &= String.Format(" Birth_B = '{0}', ", FormatDatePicker(DtpBirth_B))
                    SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_B))
                    SQL &= String.Format(" PlaceBirth_B = '{0}', ", cbxPlaceBirth_B.Text)
                    SQL &= String.Format(" Gender_B = '{0}', ", Gender_B)
                    SQL &= String.Format(" Civil_B = '{0}', ", Civil_B)
                    SQL &= String.Format(" Citizenship_B = '{0}', ", cbxCitizenship_B.Text)
                    SQL &= String.Format(" TIN_B = '{0}', ", txtTIN_B.Text)
                    SQL &= String.Format(" Telephone_B = '{0}', ", txtTelephone_B.Text)
                    SQL &= String.Format(" SSS_B = '{0}', ", txtSSS_B.Text)
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile_B.Text)
                    SQL &= String.Format(" Mobile_B2 = '{0}', ", txtMobile_B2.Text)
                    SQL &= String.Format(" Email_B = '{0}', ", txtEmail_B.Text)
                    SQL &= String.Format(" House_B = '{0}', ", House_B)
                    SQL &= String.Format(" Rent_B = '{0}', ", dRent_B.Value)

                    SQL &= String.Format(" Prefix_D1 = '{0}', ", Prefix_1)
                    SQL &= String.Format(" FirstN_D1 = '{0}', ", FirstN_1)
                    SQL &= String.Format(" MiddleN_D1 = '{0}', ", MiddleN_1)
                    SQL &= String.Format(" LastN_D1 = '{0}', ", LastN_1)
                    SQL &= String.Format(" Suffix_D1 = '{0}', ", Suffix_1)
                    SQL &= String.Format(" Birth_D1 = '{0}', ", Birth_1)
                    SQL &= String.Format(" Grade_D1 = '{0}', ", Grade_1)
                    SQL &= String.Format(" School_D1 = '{0}', ", School_1)
                    SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", SchoolAddress_1)
                    SQL &= String.Format(" Prefix_D2 = '{0}', ", Prefix_2)
                    SQL &= String.Format(" FirstN_D2 = '{0}', ", FirstN_2)
                    SQL &= String.Format(" MiddleN_D2 = '{0}', ", MiddleN_2)
                    SQL &= String.Format(" LastN_D2 = '{0}', ", LastN_2)
                    SQL &= String.Format(" Suffix_D2 = '{0}', ", Suffix_2)
                    SQL &= String.Format(" Birth_D2 = '{0}', ", Birth_2)
                    SQL &= String.Format(" Grade_D2 = '{0}', ", Grade_2)
                    SQL &= String.Format(" School_D2 = '{0}', ", School_2)
                    SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", SchoolAddress_2)
                    SQL &= String.Format(" Prefix_D3 = '{0}', ", Prefix_3)
                    SQL &= String.Format(" FirstN_D3 = '{0}', ", FirstN_3)
                    SQL &= String.Format(" MiddleN_D3 = '{0}', ", MiddleN_3)
                    SQL &= String.Format(" LastN_D3 = '{0}', ", LastN_3)
                    SQL &= String.Format(" Suffix_D3 = '{0}', ", Suffix_3)
                    SQL &= String.Format(" Birth_D3 = '{0}', ", Birth_3)
                    SQL &= String.Format(" Grade_D3 = '{0}', ", Grade_3)
                    SQL &= String.Format(" School_D3 = '{0}', ", School_3)
                    SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", SchoolAddress_3)
                    SQL &= String.Format(" Prefix_D4 = '{0}', ", Prefix_4)
                    SQL &= String.Format(" FirstN_D4 = '{0}', ", FirstN_4)
                    SQL &= String.Format(" MiddleN_D4 = '{0}', ", MiddleN_4)
                    SQL &= String.Format(" LastN_D4 = '{0}', ", LastN_4)
                    SQL &= String.Format(" Suffix_D4 = '{0}', ", Suffix_4)
                    SQL &= String.Format(" Birth_D4 = '{0}', ", Birth_4)
                    SQL &= String.Format(" Grade_D4 = '{0}', ", Grade_4)
                    SQL &= String.Format(" School_D4 = '{0}', ", School_4)
                    SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", SchoolAddress_4)

                    SQL &= String.Format(" Employer_B = '{0}', ", cbxEmployer_B.Text)
                    SQL &= String.Format(" Employer_B_ID = '{0}', ", ValidateComboBox(cbxEmployer_B))
                    SQL &= String.Format(" EmployerAddress_B = '{0}', ", txtEmployerAddress_B.Text)
                    SQL &= String.Format(" EmployerTelephone_B = '{0}', ", txtEmployerTelephone_B.Text)
                    SQL &= String.Format(" Position_B = '{0}', ", cbxPosition_B.Text)
                    SQL &= String.Format(" EmploymentStat_B = '{0}', ", EmplStatus_B)
                    SQL &= String.Format(" Hired_B = '{0}', ", FormatDatePicker(dtpHired_B))
                    SQL &= String.Format(" Supervisor_B = '{0}', ", txtSupervisor_B.Text)
                    SQL &= String.Format(" Monthly_B = '{0}', ", dMonthly_B.Value)
                    SQL &= String.Format(" BusinessName_B = '{0}', ", txtBusinessName_B.Text)
                    SQL &= String.Format(" BusinessAddress_B = '{0}', ", txtBusinessAddress_B.Text)
                    SQL &= String.Format(" BusinessTelephone_B = '{0}', ", txtBusinessTelephone_B.Text)
                    SQL &= String.Format(" NatureBusiness_B = '{0}', ", cbxNatureBusiness_B.Text)
                    SQL &= String.Format(" YrsOperation_B = '{0}', ", iYrsOperation_B.Value)
                    SQL &= String.Format(" BusinessIncome_B = '{0}', ", dBusinessIncome_B.Value)
                    SQL &= String.Format(" NoEmployees_B = '{0}', ", iNoEmployees_B.Value)
                    SQL &= String.Format(" Capital_B = '{0}', ", dCapital_B.Value)
                    SQL &= String.Format(" Area_B = '{0}', ", txtArea_B.Text)
                    SQL &= String.Format(" Expiry_B = '{0}', ", FormatDatePicker(dtpExpiry_B))
                    SQL &= String.Format(" Outlet_B = '{0}', ", iOutlet_B.Value)
                    SQL &= String.Format(" OtherIncome_B = '{0}', ", txtOtherIncome_B.Text)
                    SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", dOtherIncome_B.Value)
                    SQL &= String.Format(" Creditor_1 = '{0}', ", txtCreditor_1.Text)
                    SQL &= String.Format(" NatureLoan_1 = '{0}', ", txtNatureLoan_1.Text)
                    SQL &= String.Format(" AmountGranted_1 = '{0}', ", dAmountGranted_1.Value)
                    SQL &= String.Format(" Term_1 = '{0}', ", dTerm_1.Value)
                    SQL &= String.Format(" Balance_1 = '{0}', ", dBalance_1.Value)
                    SQL &= String.Format(" CreditRemarks_1 = '{0}', ", txtCreditRemarks_1.Text)
                    SQL &= String.Format(" Creditor_2 = '{0}', ", txtCreditor_2.Text)
                    SQL &= String.Format(" NatureLoan_2 = '{0}', ", txtNatureLoan_2.Text)
                    SQL &= String.Format(" AmountGranted_2 = '{0}', ", dAmountGranted_2.Value)
                    SQL &= String.Format(" Term_2 = '{0}', ", dTerm_2.Value)
                    SQL &= String.Format(" Balance_2 = '{0}', ", dBalance_2.Value)
                    SQL &= String.Format(" CreditRemarks_2 = '{0}', ", txtCreditRemarks_2.Text)
                    SQL &= String.Format(" Creditor_3 = '{0}', ", txtCreditor_3.Text)
                    SQL &= String.Format(" NatureLoan_3 = '{0}', ", txtNatureLoan_3.Text)
                    SQL &= String.Format(" AmountGranted_3 = '{0}', ", dAmountGranted_3.Value)
                    SQL &= String.Format(" Term_3 = '{0}', ", dTerm_3.Value)
                    SQL &= String.Format(" Balance_3 = '{0}', ", dBalance_3.Value)
                    SQL &= String.Format(" CreditRemarks_3 = '{0}', ", txtCreditRemarks_3.Text)
                    SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                    SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                    SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                    SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                    SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                    SQL &= String.Format(" PresentBalance_1 = '{0}', ", dPresentBalance_1.Value)
                    SQL &= String.Format(" Opened_1 = '{0}', ", txtOpened_1.Text)
                    SQL &= String.Format(" BankRemarks_1 = '{0}', ", txtBankRemarks_1.Text)
                    SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                    SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                    SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                    SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                    SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                    SQL &= String.Format(" PresentBalance_2 = '{0}', ", dPresentBalance_2.Value)
                    SQL &= String.Format(" Opened_2 = '{0}', ", txtOpened_2.Text)
                    SQL &= String.Format(" BankRemarks_2 = '{0}', ", txtBankRemarks_2.Text)
                    SQL &= String.Format(" Bank_3 = '{0}', ", txtBank_3.Text)
                    SQL &= String.Format(" Branch_3 = '{0}', ", txtBranch_3.Text)
                    SQL &= String.Format(" AccountT_3 = '{0}', ", AccountT_3)
                    SQL &= String.Format(" SA_3 = '{0}', ", txtSA_3.Text)
                    SQL &= String.Format(" AverageBalance_3 = '{0}', ", dAverageBalance_3.Value)
                    SQL &= String.Format(" PresentBalance_3 = '{0}', ", dPresentBalance_3.Value)
                    SQL &= String.Format(" Opened_3 = '{0}', ", txtOpened_3.Text)
                    SQL &= String.Format(" BankRemarks_3 = '{0}', ", txtBankRemarks_3.Text)
                    SQL &= String.Format(" Location_1 = '{0}', ", txtLocation_1.Text)
                    SQL &= String.Format(" TCT_1 = '{0}', ", txtTCT_1.Text)
                    SQL &= String.Format(" Area_1 = '{0}', ", dArea_1.Value)
                    SQL &= String.Format(" Acquired_1 = '{0}', ", txtAcquired_1.Text)
                    SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", txtPropertiesRemarks_1.Text)
                    SQL &= String.Format(" Location_2 = '{0}', ", txtLocation_2.Text)
                    SQL &= String.Format(" TCT_2 = '{0}', ", txtTCT_2.Text)
                    SQL &= String.Format(" Area_2 = '{0}', ", dArea_2.Value)
                    SQL &= String.Format(" Acquired_2 = '{0}', ", txtAcquired_2.Text)
                    SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", txtPropertiesRemarks_2.Text)
                    SQL &= String.Format(" Location_3 = '{0}', ", txtLocation_3.Text)
                    SQL &= String.Format(" TCT_3 = '{0}', ", txtTCT_3.Text)
                    SQL &= String.Format(" Area_3 = '{0}', ", dArea_3.Value)
                    SQL &= String.Format(" Acquired_3 = '{0}', ", txtAcquired_3.Text)
                    SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", txtPropertiesRemarks_3.Text)
                    SQL &= String.Format(" Vehicle_1 = '{0}', ", txtVehicle_1.Text)
                    SQL &= String.Format(" Year_1 = '{0}', ", FormatDatePicker(dtpYear_1))
                    SQL &= String.Format(" WhomAcquired_1 = '{0}', ", txtWhomAcquired_1.Text)
                    SQL &= String.Format(" WhenAcquired_1 = '{0}', ", txtWhenAcquired_1.Text)
                    SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", txtVehicleRemarks_1.Text)
                    SQL &= String.Format(" Vehicle_2 = '{0}', ", txtVehicle_2.Text)
                    SQL &= String.Format(" Year_2 = '{0}', ", FormatDatePicker(dtpYear_2))
                    SQL &= String.Format(" WhomAcquired_2 = '{0}', ", txtWhomAcquired_2.Text)
                    SQL &= String.Format(" WhenAcquired_2 = '{0}', ", txtWhenAcquired_2.Text)
                    SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", txtVehicleRemarks_2.Text)
                    SQL &= String.Format(" Vehicle_3 = '{0}', ", txtVehicle_3.Text)
                    SQL &= String.Format(" Year_3 = '{0}', ", FormatDatePicker(dtpYear_3))
                    SQL &= String.Format(" WhomAcquired_3 = '{0}', ", txtWhomAcquired_3.Text)
                    SQL &= String.Format(" WhenAcquired_3 = '{0}', ", txtWhenAcquired_3.Text)
                    SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", txtVehicleRemarks_3.Text)
                    SQL &= String.Format(" HomeAppliances_1 = '{0}', ", txtHomeAppliances_1.Text)
                    SQL &= String.Format(" HomeAppliances_2 = '{0}', ", txtHomeAppliances_2.Text)
                    SQL &= String.Format(" Reference_1 = '{0}', ", txtReference_1.Text)
                    SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", txtReferenceAddress_1.Text)
                    SQL &= String.Format(" ReferenceContact_1 = '{0}', ", txtReferenceContact_1.Text)
                    SQL &= String.Format(" Reference_2 = '{0}', ", txtReference_2.Text)
                    SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", txtReferenceAddress_2.Text)
                    SQL &= String.Format(" ReferenceContact_2 = '{0}', ", txtReferenceContact_2.Text)
                    SQL &= String.Format(" Reference_3 = '{0}', ", txtReference_3.Text)
                    SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", txtReferenceAddress_3.Text)
                    SQL &= String.Format(" ReferenceContact_3 = '{0}', ", txtReferenceContact_3.Text)
                    SQL &= String.Format(" CertificateNo = '{0}', ", txtCertificateNo.Text)
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
                    SQL &= String.Format(" BusinessID = '{0}', ", ValidateComboBox(cbxBusinessCenter))
                    SQL &= String.Format(" PlaceIssue = '{0}', ", txtPlaceIssue.Text)
                    SQL &= String.Format(" Issue = '{0}'", FormatDatePicker(dtpIssue))
                    SQL &= String.Format(" WHERE BorrowerID = '{0}' AND PaymentRequest NOT IN ('CLOSED','RELEASED');", txtBorrowerID.Text)
                    'UPDATE PROFILE OF CREDIT APPLICATION WHICH IS NOT YET RELEASED ****************************************************

                    If txtPath_B.Text <> "" Then
                        SaveImage(pb_B, "Borrower")
                    End If

                    SQL &= String.Format("UPDATE profile_borrower_industry SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower' AND BorrowerID = '{0}';", txtBorrowerID.Text)
                    For x As Integer = 0 To cbxNatureBusiness_B2.Properties.Items.Count - 1
                        If cbxNatureBusiness_B2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                            SQL &= "INSERT INTO profile_borrower_industry SET"
                            SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                            SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Value)
                            SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Description)
                            SQL &= " `Type` = 'Borrower';"
                        End If
                    Next
                Catch ex As Exception
                    Cursor = Cursors.Default
                    TriggerBugReport("Borrower Save", ex.Message.ToString)
                    Exit Sub
                End Try

                'DEPENDENTS
                If FirstN_1 <> "" Then
                    If DependentID_1 = "" Then
                        SQL &= "INSERT INTO profile_dependent SET"
                        SQL &= String.Format(" DependentID = '{0}',", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                        SQL &= String.Format(" BorrowerID = '{0}',", txtBorrowerID.Text)
                    Else
                        SQL &= "UPDATE profile_dependent SET"
                    End If
                    SQL &= String.Format(" Prefix_D = '{0}',", Prefix_1)
                    SQL &= String.Format(" FirstN_D = '{0}',", FirstN_1)
                    SQL &= String.Format(" MiddleN_D = '{0}',", MiddleN_1)
                    SQL &= String.Format(" LastN_D = '{0}',", LastN_1)
                    SQL &= String.Format(" Suffix_D = '{0}',", Suffix_1)
                    SQL &= String.Format(" Birth_D = '{0}',", Birth_1)
                    SQL &= String.Format(" Grade_D = '{0}',", Grade_1)
                    SQL &= String.Format(" School_D = '{0}',", School_1)
                    SQL &= String.Format(" SchoolAddress_D = '{0}'", SchoolAddress_1)
                    If DependentID_1 = "" Then
                        SQL &= ", `Rank` = 1 "
                        SQL &= String.Format(", branch_id = '{0}';", Branch_ID)
                    Else
                        SQL &= String.Format(" WHERE ID = '{0}';", DependentID_1)
                    End If
                    If FirstN_2 <> "" Then
                        If DependentID_2 = "" Then
                            SQL &= "INSERT INTO profile_dependent SET"
                            SQL &= String.Format(" DependentID = '{0}',", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                            SQL &= String.Format(" BorrowerID = '{0}',", txtBorrowerID.Text)
                        Else
                            SQL &= "UPDATE profile_dependent SET"
                        End If
                        SQL &= String.Format(" Prefix_D = '{0}',", Prefix_2)
                        SQL &= String.Format(" FirstN_D = '{0}',", FirstN_2)
                        SQL &= String.Format(" MiddleN_D = '{0}',", MiddleN_2)
                        SQL &= String.Format(" LastN_D = '{0}',", LastN_2)
                        SQL &= String.Format(" Suffix_D = '{0}',", Suffix_2)
                        SQL &= String.Format(" Birth_D = '{0}',", Birth_2)
                        SQL &= String.Format(" Grade_D = '{0}',", Grade_2)
                        SQL &= String.Format(" School_D = '{0}',", School_2)
                        SQL &= String.Format(" SchoolAddress_D = '{0}'", SchoolAddress_2)
                        If DependentID_2 = "" Then
                            SQL &= ", `Rank` = 2 "
                            SQL &= String.Format(", branch_id = '{0}';", Branch_ID)
                        Else
                            SQL &= String.Format(" WHERE ID = '{0}';", DependentID_2)
                        End If
                        If FirstN_3 <> "" Then
                            If DependentID_3 = "" Then
                                SQL &= "INSERT INTO profile_dependent SET"
                                SQL &= String.Format(" DependentID = '{0}',", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                                SQL &= String.Format(" BorrowerID = '{0}',", txtBorrowerID.Text)
                            Else
                                SQL &= "UPDATE profile_dependent SET"
                            End If
                            SQL &= String.Format(" Prefix_D = '{0}',", Prefix_3)
                            SQL &= String.Format(" FirstN_D = '{0}',", FirstN_3)
                            SQL &= String.Format(" MiddleN_D = '{0}',", MiddleN_3)
                            SQL &= String.Format(" LastN_D = '{0}',", LastN_3)
                            SQL &= String.Format(" Suffix_D = '{0}',", Suffix_3)
                            SQL &= String.Format(" Birth_D = '{0}',", Birth_3)
                            SQL &= String.Format(" Grade_D = '{0}',", Grade_3)
                            SQL &= String.Format(" School_D = '{0}',", School_3)
                            SQL &= String.Format(" SchoolAddress_D = '{0}'", SchoolAddress_3)
                            If DependentID_3 = "" Then
                                SQL &= ", `Rank` = 3 "
                                SQL &= String.Format(", branch_id = '{0}';", Branch_ID)
                            Else
                                SQL &= String.Format(" WHERE ID = '{0}';", DependentID_3)
                            End If
                            If FirstN_4 <> "" Then
                                If DependentID_4 = "" Then
                                    SQL &= "INSERT INTO profile_dependent SET"
                                    SQL &= String.Format(" DependentID = '{0}',", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dependent WHERE branch_id = '{0}';", Branch_ID)))
                                    SQL &= String.Format(" BorrowerID = '{0}',", txtBorrowerID.Text)
                                Else
                                    SQL &= "UPDATE profile_dependent SET"
                                End If
                                SQL &= String.Format(" Prefix_D = '{0}',", Prefix_4)
                                SQL &= String.Format(" FirstN_D = '{0}',", FirstN_4)
                                SQL &= String.Format(" MiddleN_D = '{0}',", MiddleN_4)
                                SQL &= String.Format(" LastN_D = '{0}',", LastN_4)
                                SQL &= String.Format(" Suffix_D = '{0}',", Suffix_4)
                                SQL &= String.Format(" Birth_D = '{0}',", Birth_4)
                                SQL &= String.Format(" Grade_D = '{0}',", Grade_4)
                                SQL &= String.Format(" School_D = '{0}',", School_4)
                                SQL &= String.Format(" SchoolAddress_D = '{0}'", SchoolAddress_4)
                                If DependentID_4 = "" Then
                                    SQL &= ", `Rank` = 4 "
                                    SQL &= String.Format(", branch_id = '{0}';", Branch_ID)
                                Else
                                    SQL &= String.Format(" WHERE ID = '{0}';", DependentID_4)
                                End If
                            ElseIf FirstN_4 = "" And DependentID_4 <> "" Then
                                DataObject(String.Format("UPDATE profile_dependent SET `status` = 'INACTIVE' WHERE ID = '{0}';", DependentID_4))
                            End If
                        ElseIf FirstN_3 = "" And DependentID_3 <> "" Then
                            DataObject(String.Format("UPDATE profile_dependent SET `status` = 'INACTIVE' WHERE ID IN ('{0}','{1}');", DependentID_3, DependentID_4))
                        End If
                    ElseIf FirstN_2 = "" And DependentID_2 <> "" Then
                        DataObject(String.Format("UPDATE profile_dependent SET `status` = 'INACTIVE' WHERE ID IN ('{0}','{1}','{2}');", DependentID_2, DependentID_3, DependentID_4))
                    End If
                ElseIf FirstN_1 = "" And DependentID_1 <> "" Then
                    DataObject(String.Format("UPDATE profile_dependent SET `status` = 'INACTIVE' WHERE ID IN ('{0}','{1}','{2}','{3}');", DependentID_1, DependentID_2, DependentID_3, DependentID_4))
                End If

                'IDENTIFICATION
                SQL &= "UPDATE profile_borrowerid SET"
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_B.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_B.Text)
                SQL &= String.Format(" GSIS = '{0}', ", GSIS)
                SQL &= String.Format(" PhilHealth = '{0}', ", PhilHealth)
                SQL &= String.Format(" Senior = '{0}', ", Senior)
                SQL &= String.Format(" UMID = '{0}', ", UMID)
                SQL &= String.Format(" SEC = '{0}', ", SEC)
                SQL &= String.Format(" DTI = '{0}', ", DTI)
                SQL &= String.Format(" CDA = '{0}', ", CDA)
                SQL &= String.Format(" Cooperative = '{0}', ", Cooperative)
                SQL &= String.Format(" Drivers = '{0}', ", Drivers)
                SQL &= String.Format(" dDrivers = '{0}', ", dDrivers)
                SQL &= String.Format(" VIN = '{0}', ", VIN)
                SQL &= String.Format(" dVIN = '{0}', ", dVIN)
                SQL &= String.Format(" Passport = '{0}', ", Passport)
                SQL &= String.Format(" dPassport = '{0}', ", dPassport)
                SQL &= String.Format(" PRC = '{0}', ", PRC)
                SQL &= String.Format(" dPRC = '{0}', ", dPRC)
                SQL &= String.Format(" NBI = '{0}', ", NBI)
                SQL &= String.Format(" dNBI = '{0}', ", dNBI)
                SQL &= String.Format(" Police = '{0}', ", Police)
                SQL &= String.Format(" dPolice = '{0}', ", dPolice)
                SQL &= String.Format(" Postal = '{0}', ", Postal)
                SQL &= String.Format(" dPostal = '{0}', ", dPostal)
                SQL &= String.Format(" Barangay = '{0}', ", Barangay)
                SQL &= String.Format(" dBarangay = '{0}', ", dBarangay)
                SQL &= String.Format(" OWWA = '{0}', ", OWWA)
                SQL &= String.Format(" dOWWA = '{0}', ", dOWWA)
                SQL &= String.Format(" OFW = '{0}', ", OFW)
                SQL &= String.Format(" dOFW = '{0}', ", dOFW)
                SQL &= String.Format(" Seaman = '{0}', ", Seaman)
                SQL &= String.Format(" dSeaman = '{0}', ", dSeaman)
                SQL &= String.Format(" PNP = '{0}', ", PNP)
                SQL &= String.Format(" dPNP = '{0}', ", dPNP)
                SQL &= String.Format(" AFP = '{0}', ", AFP)
                SQL &= String.Format(" dAFP = '{0}', ", dAFP)
                SQL &= String.Format(" HDMF = '{0}', ", HDMF)
                SQL &= String.Format(" dHDMF = '{0}', ", dHDMF)
                SQL &= String.Format(" PWD = '{0}', ", PWD)
                SQL &= String.Format(" dPWD = '{0}', ", dPWD)
                SQL &= String.Format(" DSWD = '{0}', ", DSWD)
                SQL &= String.Format(" dDSWD = '{0}', ", dDSWD)
                SQL &= String.Format(" ACR = '{0}', ", ACR)
                SQL &= String.Format(" dACR = '{0}', ", dACR)
                SQL &= String.Format(" DTI_Business = '{0}', ", DTI_Business)
                SQL &= String.Format(" dDTI_Business = '{0}', ", dDTI_Business)
                SQL &= String.Format(" IBP = '{0}', ", IBP)
                SQL &= String.Format(" dIBP = '{0}', ", dIBP)
                SQL &= String.Format(" FireArms = '{0}', ", FireArms)
                SQL &= String.Format(" dFireArms = '{0}', ", dFireArms)
                SQL &= String.Format(" Government = '{0}', ", Government)
                SQL &= String.Format(" dGovernment = '{0}', ", dGovernment)
                SQL &= String.Format(" Diplomat = '{0}', ", Diplomat)
                SQL &= String.Format(" dDiplomat = '{0}', ", dDiplomat)
                SQL &= String.Format(" `National` = '{0}', ", National)
                SQL &= String.Format(" dNational = '{0}', ", dNational)
                SQL &= String.Format(" `Work` = '{0}', ", Work)
                SQL &= String.Format(" dWork = '{0}', ", dWork)
                SQL &= String.Format(" GOCC = '{0}', ", GOCC)
                SQL &= String.Format(" dGOCC = '{0}', ", dGOCC)
                SQL &= String.Format(" PLRA = '{0}', ", PLRA)
                SQL &= String.Format(" dPLRA = '{0}', ", dPLRA)
                SQL &= String.Format(" Major = '{0}', ", Major)
                SQL &= String.Format(" dMajor = '{0}', ", dMajor)
                SQL &= String.Format(" Media = '{0}', ", Media)
                SQL &= String.Format(" dMedia = '{0}', ", dMedia)
                SQL &= String.Format(" Student = '{0}', ", Student)
                SQL &= String.Format(" dStudent = '{0}', ", dStudent)
                SQL &= String.Format(" SIRV = '{0}', ", SIRV)
                SQL &= String.Format(" dSIRV = '{0}' ", dSIRV)
                SQL &= String.Format(" WHERE BorrowerID = '{0}' AND ID_Type = 'B';", txtBorrowerID.Text)

                If tabSpouse.Visible Then
                    '***SPOUSE
                    Dim Gender_S As String = ""
                    If cbxMale_S.Checked Then
                        Gender_S = "Male"
                    ElseIf cbxFemale_S.Checked Then
                        Gender_S = "Female"
                    End If
                    Dim House_S As String = ""
                    If cbxOwned_S.Checked Then
                        House_S = "Owned"
                    ElseIf cbxFree_S.Checked Then
                        House_S = "Free"
                    ElseIf cbxRented_S.Checked Then
                        House_S = "Rented"
                    End If
                    Dim EmplStatus_S As String = ""
                    If cbxCasual_S.Checked Then
                        EmplStatus_S = "Casual"
                    ElseIf cbxTemporary_S.Checked Then
                        EmplStatus_S = "Temporary"
                    ElseIf cbxPermanent_S.Checked Then
                        EmplStatus_S = "Permanent"
                    End If

                    If SpouseID = "" Then
                        SQL &= "INSERT INTO profile_spouse SET"
                        SQL &= String.Format(" SpouseID = '{0}',", DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_spouse WHERE branch_id = '{0}';", Branch_ID)))
                        SQL &= String.Format(" BorrowerID = '{0}',", txtBorrowerID.Text)
                    Else
                        SQL &= "UPDATE profile_spouse SET"
                    End If
                    SQL &= String.Format(" Prefix_S = '{0}',", CbxPrefix_S.Text)
                    SQL &= String.Format(" FirstN_S = '{0}',", TxtFirstN_S.Text)
                    SQL &= String.Format(" MiddleN_S = '{0}',", TxtMiddleN_S.Text)
                    SQL &= String.Format(" LastN_S = '{0}',", TxtLastN_S.Text)
                    SQL &= String.Format(" Suffix_S = '{0}',", cbxSuffix_S.Text)
                    SQL &= String.Format(" Prefix_M = '{0}',", CbxPrefix_M.Text)
                    SQL &= String.Format(" FirstN_M = '{0}',", TxtFirstN_M.Text)
                    SQL &= String.Format(" MiddleN_M = '{0}',", TxtMiddleN_M.Text)
                    SQL &= String.Format(" LastN_M = '{0}',", TxtLastN_M.Text)
                    SQL &= String.Format(" Suffix_M = '{0}',", cbxSuffix_M.Text)
                    SQL &= String.Format(" NoC_S = '{0}',", txtNoC_S.Text)
                    SQL &= String.Format(" StreetC_S = '{0}',", txtStreetC_S.Text)
                    SQL &= String.Format(" BarangayC_S = '{0}',", txtBarangayC_S.Text)
                    SQL &= String.Format(" `AddressC_S-ID` = '{0}',", ValidateComboBox(cbxAddressC_S))
                    SQL &= String.Format(" AddressC_S = '{0}',", cbxAddressC_S.Text)
                    SQL &= String.Format(" NoP_S = '{0}',", txtNoP_S.Text)
                    SQL &= String.Format(" StreetP_S = '{0}',", txtStreetP_S.Text)
                    SQL &= String.Format(" BarangayP_S = '{0}',", txtBarangayP_S.Text)
                    SQL &= String.Format(" `AddressP_S-ID` = '{0}',", ValidateComboBox(cbxAddressP_S))
                    SQL &= String.Format(" AddressP_S = '{0}',", cbxAddressP_S.Text)
                    SQL &= String.Format(" Birth_S = '{0}',", FormatDatePicker(DtpBirth_S))
                    SQL &= String.Format(" `PlaceBirth_S-ID` = '{0}',", ValidateComboBox(cbxPlaceBirth_S))
                    SQL &= String.Format(" PlaceBirth_S = '{0}',", cbxPlaceBirth_S.Text)
                    SQL &= String.Format(" Gender_S = '{0}',", Gender_S)
                    SQL &= String.Format(" Citizenship_S = '{0}',", txtCitizenship_S.Text)
                    SQL &= String.Format(" TIN_S = '{0}',", txtTIN_S.Text)
                    SQL &= String.Format(" Telephone_S = '{0}',", txtTelephone_S.Text)
                    SQL &= String.Format(" SSS_S = '{0}',", txtSSS_S.Text)
                    SQL &= String.Format(" Mobile_S = '{0}',", txtMobile_S.Text)
                    SQL &= String.Format(" Email_S = '{0}',", txtEmail_S.Text)
                    SQL &= String.Format(" House_S = '{0}',", House_S)
                    SQL &= String.Format(" Rent_S = '{0}',", dRent_S.Value)
                    SQL &= String.Format(" Employer_S = '{0}',", cbxEmployer_S.Text)
                    SQL &= String.Format(" EmployerAddress_S = '{0}',", txtEmployerAddress_S.Text)
                    SQL &= String.Format(" EmployerTelephone_S = '{0}',", txtEmployerTelephone_S.Text)
                    SQL &= String.Format(" Position_S = '{0}',", cbxPosition_S.Text)
                    SQL &= String.Format(" EmploymentStat_S = '{0}',", EmplStatus_S)
                    SQL &= String.Format(" Hired_S = '{0}',", FormatDatePicker(dtpHired_S))
                    SQL &= String.Format(" Supervisor_S = '{0}',", txtSupervisor_S.Text)
                    SQL &= String.Format(" Monthly_S = '{0}',", dMonthly_S.Value)
                    SQL &= String.Format(" BusinessName_S = '{0}',", txtBusinessName_S.Text)
                    SQL &= String.Format(" BusinessAddress_S = '{0}',", txtBusinessAddress_S.Text)
                    SQL &= String.Format(" BusinessTelephone_S = '{0}',", txtBusinessTelephone_S.Text)
                    SQL &= String.Format(" NatureBusiness_S = '{0}',", cbxNatureBusiness_S.Text)
                    SQL &= String.Format(" YrsOperation_S = '{0}',", iYrsOperation_S.Value)
                    SQL &= String.Format(" BusinessIncome_S = '{0}',", dBusinessIncome_S.Value)
                    SQL &= String.Format(" NoEmployees_S = '{0}',", iNoEmployees_S.Value)
                    SQL &= String.Format(" Capital_S = '{0}',", dCapital_S.Value)
                    SQL &= String.Format(" Area_S = '{0}',", txtArea_S.Text)
                    SQL &= String.Format(" Expiry_S = '{0}',", FormatDatePicker(dtpExpiry_S))
                    SQL &= String.Format(" Outlet_S = '{0}',", iOutlet_S.Value)
                    SQL &= String.Format(" OtherIncome_S = '{0}',", txtOtherIncome_S.Text)
                    SQL &= String.Format(" `OtherIncome_S-Amount` = '{0}'", dOtherIncome_S.Value)
                    If SpouseID = "" Then
                        SQL &= String.Format(", branch_id = '{0}';", Branch_ID)
                    Else
                        SQL &= String.Format(" WHERE SpouseID = '{0}';", SpouseID)
                    End If
                    If txtPath_S.Text <> "" Then
                        SaveImage(pb_S, "Spouse")
                    End If

                    SQL &= String.Format("UPDATE profile_borrower_industry SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND `Type` = 'Spouse' AND BorrowerID = '{0}';", txtBorrowerID.Text)
                    For x As Integer = 0 To cbxNatureBusiness_S2.Properties.Items.Count - 1
                        If cbxNatureBusiness_S2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                            SQL &= "INSERT INTO profile_borrower_industry SET"
                            SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                            SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Value)
                            SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Description)
                            SQL &= " `Type` = 'Spouse';"
                        End If
                    Next

                    If SpouseID = "" Then
                        SQL &= "INSERT profile_borrowerid SET"
                        SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                    Else
                        SQL &= "UPDATE profile_borrowerid SET"
                    End If
                    SQL &= String.Format(" TIN = '{0}', ", txtTIN_S.Text)
                    SQL &= String.Format(" SSS = '{0}', ", txtSSS_S.Text)
                    SQL &= String.Format(" GSIS = '{0}', ", GSIS_S)
                    SQL &= String.Format(" PhilHealth = '{0}', ", PhilHealth_S)
                    SQL &= String.Format(" Senior = '{0}', ", Senior_S)
                    SQL &= String.Format(" UMID = '{0}', ", UMID_S)
                    SQL &= String.Format(" SEC = '{0}', ", SEC_S)
                    SQL &= String.Format(" DTI = '{0}', ", DTI_S)
                    SQL &= String.Format(" CDA = '{0}', ", CDA_S)
                    SQL &= String.Format(" Cooperative = '{0}', ", Cooperative_S)
                    SQL &= String.Format(" Drivers = '{0}', ", Drivers_S)
                    SQL &= String.Format(" dDrivers = '{0}', ", dDrivers_S)
                    SQL &= String.Format(" VIN = '{0}', ", VIN_S)
                    SQL &= String.Format(" dVIN = '{0}', ", dVIN_S)
                    SQL &= String.Format(" Passport = '{0}', ", Passport_S)
                    SQL &= String.Format(" dPassport = '{0}', ", dPassport_S)
                    SQL &= String.Format(" PRC = '{0}', ", PRC_S)
                    SQL &= String.Format(" dPRC = '{0}', ", dPRC_S)
                    SQL &= String.Format(" NBI = '{0}', ", NBI_S)
                    SQL &= String.Format(" dNBI = '{0}', ", dNBI_S)
                    SQL &= String.Format(" Police = '{0}', ", Police_S)
                    SQL &= String.Format(" dPolice = '{0}', ", dPolice_S)
                    SQL &= String.Format(" Postal = '{0}', ", Postal_S)
                    SQL &= String.Format(" dPostal = '{0}', ", dPostal_S)
                    SQL &= String.Format(" Barangay = '{0}', ", Barangay_S)
                    SQL &= String.Format(" dBarangay = '{0}', ", dBarangay_S)
                    SQL &= String.Format(" OWWA = '{0}', ", OWWA_S)
                    SQL &= String.Format(" dOWWA = '{0}', ", dOWWA_S)
                    SQL &= String.Format(" OFW = '{0}', ", OFW_S)
                    SQL &= String.Format(" dOFW = '{0}', ", dOFW_S)
                    SQL &= String.Format(" Seaman = '{0}', ", Seaman_S)
                    SQL &= String.Format(" dSeaman = '{0}', ", dSeaman_S)
                    SQL &= String.Format(" PNP = '{0}', ", PNP_S)
                    SQL &= String.Format(" dPNP = '{0}', ", dPNP_S)
                    SQL &= String.Format(" AFP = '{0}', ", AFP_S)
                    SQL &= String.Format(" dAFP = '{0}', ", dAFP_S)
                    SQL &= String.Format(" HDMF = '{0}', ", HDMF_S)
                    SQL &= String.Format(" dHDMF = '{0}', ", dHDMF_S)
                    SQL &= String.Format(" PWD = '{0}', ", PWD_S)
                    SQL &= String.Format(" dPWD = '{0}', ", dPWD_S)
                    SQL &= String.Format(" DSWD = '{0}', ", DSWD_S)
                    SQL &= String.Format(" dDSWD = '{0}', ", dDSWD_S)
                    SQL &= String.Format(" ACR = '{0}', ", ACR_S)
                    SQL &= String.Format(" dACR = '{0}', ", dACR_S)
                    SQL &= String.Format(" DTI_Business = '{0}', ", DTI_Business_S)
                    SQL &= String.Format(" dDTI_Business = '{0}', ", dDTI_Business_S)
                    SQL &= String.Format(" IBP = '{0}', ", IBP_S)
                    SQL &= String.Format(" dIBP = '{0}', ", dIBP_S)
                    SQL &= String.Format(" FireArms = '{0}', ", FireArms_S)
                    SQL &= String.Format(" dFireArms = '{0}', ", dFireArms_S)
                    SQL &= String.Format(" Government = '{0}', ", Government_S)
                    SQL &= String.Format(" dGovernment = '{0}', ", dGovernment_S)
                    SQL &= String.Format(" Diplomat = '{0}', ", Diplomat_S)
                    SQL &= String.Format(" dDiplomat = '{0}', ", dDiplomat_S)
                    SQL &= String.Format(" `National` = '{0}', ", National_S)
                    SQL &= String.Format(" dNational = '{0}', ", dNational_S)
                    SQL &= String.Format(" `Work` = '{0}', ", Work_S)
                    SQL &= String.Format(" dWork = '{0}', ", dWork_S)
                    SQL &= String.Format(" GOCC = '{0}', ", GOCC_S)
                    SQL &= String.Format(" dGOCC = '{0}', ", dGOCC_S)
                    SQL &= String.Format(" PLRA = '{0}', ", PLRA_S)
                    SQL &= String.Format(" dPLRA = '{0}', ", dPLRA_S)
                    SQL &= String.Format(" Major = '{0}', ", Major_S)
                    SQL &= String.Format(" dMajor = '{0}', ", dMajor_S)
                    SQL &= String.Format(" Media = '{0}', ", Media_S)
                    SQL &= String.Format(" dMedia = '{0}', ", dMedia_S)
                    SQL &= String.Format(" Student = '{0}', ", Student_S)
                    SQL &= String.Format(" dStudent = '{0}', ", dStudent_S)
                    SQL &= String.Format(" SIRV = '{0}', ", SIRV_S)
                    SQL &= String.Format(" dSIRV = '{0}'", dSIRV_S)
                    If SpouseID = "" Then
                        SQL &= String.Format(" ,branch_id = '{0}',", Branch_ID)
                        SQL &= " ID_Type = 'S';"
                    Else
                        SQL &= String.Format(" WHERE BorrowerID = '{0}' AND ID_Type = 'S';", txtBorrowerID.Text)
                    End If
                ElseIf tabSpouse.Visible = False And SpouseID <> "" Then
                    DataObject(String.Format("UPDATE profile_spouse SET `status` = 'INACTIVE' WHERE SpouseID = '{0}';", SpouseID))
                    DataObject(String.Format("UPDATE profile_borrowerid  SET `status` = 'DELETED' WHERE BorrowerID = '{0}' AND ID_Type = 'S';", txtBorrowerID.Text))
                End If

                DataObject(SQL)
                Cursor = Cursors.Default
                Logs("Borrower", "Update", String.Format("Update borrower {0}", BorrowerN), Changes(), txtBorrowerID.Text, BorrowerN, "")
                Clear()
                FrmBorrowerList.LoadData()
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnSave_F_Click(sender As Object, e As EventArgs) Handles btnSave_F.Click
        btnSave.PerformClick()
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            '*** B O R R O W E R ***
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
            If txtNoP_B.Text = txtNoP_B.Tag Then
            Else
                Change &= String.Format("Change Provincial Address No  from {0} to {1}. ", txtNoP_B.Tag, txtNoP_B.Text)
            End If
            If txtStreetP_B.Text = txtStreetP_B.Tag Then
            Else
                Change &= String.Format("Change Provincial Address Street from {0} to {1}. ", txtStreetP_B.Tag, txtStreetP_B.Text)
            End If
            If txtBarangayP_B.Text = txtBarangayP_B.Tag Then
            Else
                Change &= String.Format("Change Provincial Address Barangay from {0} to {1}. ", txtBarangayP_B.Tag, txtBarangayP_B.Text)
            End If
            If cbxAddressP_B.Text = cbxAddressP_B.Tag Then
            Else
                Change &= String.Format("Change Provincial Address from {0} to {1}. ", cbxAddressP_B.Tag, cbxAddressP_B.Text)
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
            If txtMobile_B2.Text = txtMobile_B2.Tag Then
            Else
                Change &= String.Format("Change Alternate Mobile Number from {0} to {1}. ", txtMobile_B2.Tag, txtMobile_B2.Text)
            End If
            If txtEmail_B.Text = txtEmail_B.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmail_B.Tag, txtEmail_B.Text)
            End If
            If cbxOwned_B.Tag <> "Owned" And cbxOwned_B.Checked Then
                Change &= String.Format("Change House from {0} to {1}. ", cbxOwned_B.Tag, cbxOwned_B.Text)
            ElseIf cbxFree_B.Tag <> "Free" And cbxFree_B.Checked Then
                Change &= String.Format("Change House from {0} to {1}. ", cbxFree_B.Tag, cbxFree_B.Text)
            ElseIf cbxRented_B.Tag <> "Rented" And cbxRented_B.Checked Then
                Change &= String.Format("Change House from {0} to {1}. ", cbxRented_B.Tag, cbxRented_B.Text)
            End If
            If dRent_B.Value = dRent_B.Tag Then
            Else
                Change &= String.Format("Change Rent from {0} to {1}. ", dRent_B.Tag, dRent_B.Text)
            End If
            If cbxEmployer_B.Text = cbxEmployer_B.Tag Then
            Else
                Change &= String.Format("Change Employer from {0} to {1}. ", cbxEmployer_B.Tag, cbxEmployer_B.Text)
            End If
            If txtEmployerAddress_B.Text = txtEmployerAddress_B.Tag Then
            Else
                Change &= String.Format("Change Employer Address from {0} to {1}. ", txtEmployerAddress_B.Tag, txtEmployerAddress_B.Text)
            End If
            If txtEmployerTelephone_B.Text = txtEmployerTelephone_B.Tag Then
            Else
                Change &= String.Format("Change Employer Telephone from {0} to {1}. ", txtEmployerTelephone_B.Tag, txtEmployerTelephone_B.Text)
            End If
            If cbxPosition_B.Text = cbxPosition_B.Tag Then
            Else
                Change &= String.Format("Change Position from {0} to {1}. ", cbxPosition_B.Tag, cbxPosition_B.Text)
            End If
            If cbxCasual_B.Tag.ToString <> "Casual" And cbxCasual_B.Checked Then
                Change &= String.Format("Change Employment Status from {0} to {1}. ", cbxCasual_B.Tag, cbxCasual_B.Text)
            ElseIf cbxTemporary_B.Tag.ToString <> "Temporary" And cbxTemporary_B.Checked Then
                Change &= String.Format("Change Employment Status from {0} to {1}. ", cbxTemporary_B.Tag, cbxTemporary_B.Text)
            ElseIf cbxPermanent_B.Tag.ToString <> "Permanent" And cbxPermanent_B.Checked Then
                Change &= String.Format("Change Employment Status from {0} to {1}. ", cbxPermanent_B.Tag, cbxPermanent_B.Text)
            End If
            If FormatDatePicker(dtpHired_B) = dtpHired_B.Tag Then
            Else
                Change &= String.Format("Change Date Hired from {0} to {1}. ", dtpHired_B.Tag, FormatDatePicker(dtpHired_B))
            End If
            If txtSupervisor_B.Text = txtSupervisor_B.Tag Then
            Else
                Change &= String.Format("Change Supervisor from {0} to {1}. ", txtSupervisor_B.Tag, txtSupervisor_B.Text)
            End If
            If dMonthly_B.Value = dMonthly_B.Tag Then
            Else
                Change &= String.Format("Change Gross Monthly Income as employed from {0} to {1}. ", dMonthly_B.Tag, dMonthly_B.Text)
            End If
            If txtBusinessName_B.Text = txtBusinessName_B.Tag Then
            Else
                Change &= String.Format("Change Business Name from {0} to {1}. ", txtBusinessName_B.Tag, txtBusinessName_B.Text)
            End If
            If txtBusinessAddress_B.Text = txtBusinessAddress_B.Tag Then
            Else
                Change &= String.Format("Change Business Address from {0} to {1}. ", txtBusinessAddress_B.Tag, txtBusinessAddress_B.Text)
            End If
            If txtBusinessTelephone_B.Text = txtBusinessTelephone_B.Tag Then
            Else
                Change &= String.Format("Change Business Telephone from {0} to {1}. ", txtBusinessTelephone_B.Tag, txtBusinessTelephone_B.Text)
            End If
            If cbxNatureBusiness_B.Text = cbxNatureBusiness_B.Tag Then
            Else
                Change &= String.Format("Change Nature of Business from {0} to {1}. ", cbxNatureBusiness_B.Tag, cbxNatureBusiness_B.Text)
            End If
            If iYrsOperation_B.Value = iYrsOperation_B.Tag Then
            Else
                Change &= String.Format("Change Years Operation from {0} to {1}. ", iYrsOperation_B.Tag, iYrsOperation_B.Text)
            End If
            If dBusinessIncome_B.Value = dBusinessIncome_B.Tag Then
            Else
                Change &= String.Format("Change Business Income from {0} to {1}. ", dBusinessIncome_B.Tag, dBusinessIncome_B.Text)
            End If
            If iNoEmployees_B.Value = iNoEmployees_B.Tag Then
            Else
                Change &= String.Format("Change No of Employees from {0} to {1}. ", iNoEmployees_B.Tag, iNoEmployees_B.Text)
            End If
            If dCapital_B.Value = dCapital_B.Tag Then
            Else
                Change &= String.Format("Change Capital from {0} to {1}. ", dCapital_B.Tag, dCapital_B.Text)
            End If
            If txtArea_B.Text = txtArea_B.Tag Then
            Else
                Change &= String.Format("Change Area from {0} to {1}. ", txtArea_B.Tag, txtArea_B.Text)
            End If
            If FormatDatePicker(dtpExpiry_B) = dtpExpiry_B.Tag Then
            Else
                Change &= String.Format("Change Business Expiry from {0} to {1}. ", dtpExpiry_B.Tag, FormatDatePicker(dtpExpiry_B))
            End If
            If iOutlet_B.Value = iOutlet_B.Tag Then
            Else
                Change &= String.Format("Change No of Outlet from {0} to {1}. ", iOutlet_B.Tag, iOutlet_B.Text)
            End If
            If txtOtherIncome_B.Text = txtOtherIncome_B.Tag Then
            Else
                Change &= String.Format("Change Other Income from {0} to {1}. ", txtOtherIncome_B.Tag, txtOtherIncome_B.Text)
            End If
            If dOtherIncome_B.Value = dOtherIncome_B.Tag Then
            Else
                Change &= String.Format("Change Other Income Monthly from {0} to {1}. ", dOtherIncome_B.Tag, dOtherIncome_B.Text)
            End If
            If txtCreditor_1.Text = txtCreditor_1.Tag Then
            Else
                Change &= String.Format("Change Creditor 1 from {0} to {1}. ", txtCreditor_1.Tag, txtCreditor_1.Text)
            End If
            If txtNatureLoan_1.Text = txtNatureLoan_1.Tag Then
            Else
                Change &= String.Format("Change Nature Loan 1 from {0} to {1}. ", txtNatureLoan_1.Tag, txtNatureLoan_1.Text)
            End If
            If dAmountGranted_1.Value = dAmountGranted_1.Tag Then
            Else
                Change &= String.Format("Change Amount Granted 1 from {0} to {1}. ", dAmountGranted_1.Tag, dAmountGranted_1.Text)
            End If
            If dTerm_1.Value = dTerm_1.Tag Then
            Else
                Change &= String.Format("Change Term 1 from {0} to {1}. ", dTerm_1.Tag, dTerm_1.Text)
            End If
            If dBalance_1.Value = dBalance_1.Tag Then
            Else
                Change &= String.Format("Change Balance 1 from {0} to {1}. ", dBalance_1.Tag, dBalance_1.Text)
            End If
            If txtCreditRemarks_1.Text = txtCreditRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Credit Remarks 1 from {0} to {1}. ", txtCreditRemarks_1.Tag, txtCreditRemarks_1.Text)
            End If
            If txtCreditor_2.Text = txtCreditor_2.Tag Then
            Else
                Change &= String.Format("Change Creditor 2 from {0} to {1}. ", txtCreditor_2.Tag, txtCreditor_2.Text)
            End If
            If txtNatureLoan_2.Text = txtNatureLoan_2.Tag Then
            Else
                Change &= String.Format("Change Nature Loan 2 from {0} to {1}. ", txtNatureLoan_2.Tag, txtNatureLoan_2.Text)
            End If
            If dAmountGranted_2.Value = dAmountGranted_2.Tag Then
            Else
                Change &= String.Format("Change Amount Granted 2 from {0} to {1}. ", dAmountGranted_2.Tag, dAmountGranted_2.Text)
            End If
            If dTerm_2.Value = dTerm_2.Tag Then
            Else
                Change &= String.Format("Change Term 2 from {0} to {1}. ", dTerm_2.Tag, dTerm_2.Text)
            End If
            If dBalance_2.Value = dBalance_2.Tag Then
            Else
                Change &= String.Format("Change Balance 2 from {0} to {1}. ", dBalance_2.Tag, dBalance_2.Text)
            End If
            If txtCreditRemarks_2.Text = txtCreditRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Credit Remarks 2 from {0} to {1}. ", txtCreditRemarks_2.Tag, txtCreditRemarks_2.Text)
            End If
            If txtCreditor_3.Text = txtCreditor_3.Tag Then
            Else
                Change &= String.Format("Change Creditor 3 from {0} to {1}. ", txtCreditor_3.Tag, txtCreditor_3.Text)
            End If
            If txtNatureLoan_3.Text = txtNatureLoan_3.Tag Then
            Else
                Change &= String.Format("Change Nature Loan 3 from {0} to {1}. ", txtNatureLoan_3.Tag, txtNatureLoan_3.Text)
            End If
            If dAmountGranted_3.Value = dAmountGranted_3.Tag Then
            Else
                Change &= String.Format("Change Amount Granted 3 from {0} to {1}. ", dAmountGranted_3.Tag, dAmountGranted_3.Text)
            End If
            If dTerm_3.Value = dTerm_3.Tag Then
            Else
                Change &= String.Format("Change Term 3 from {0} to {1}. ", dTerm_3.Tag, dTerm_3.Text)
            End If
            If dBalance_3.Value = dBalance_3.Tag Then
            Else
                Change &= String.Format("Change Balance 3 from {0} to {1}. ", dBalance_3.Tag, dBalance_3.Text)
            End If
            If txtCreditRemarks_3.Text = txtCreditRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Credit Remarks 3 from {0} to {1}. ", txtCreditRemarks_3.Tag, txtCreditRemarks_3.Text)
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
                Change &= String.Format("Change Account No. 1 from {0} to {1}. ", txtSA_1.Tag, txtSA_1.Text)
            End If
            If dAverageBalance_1.Value = dAverageBalance_1.Tag Then
            Else
                Change &= String.Format("Change Average Balance 1 from {0} to {1}. ", dAverageBalance_1.Tag, dAverageBalance_1.Text)
            End If
            If dPresentBalance_1.Value = dPresentBalance_1.Tag Then
            Else
                Change &= String.Format("Change Present Balance 1 from {0} to {1}. ", dPresentBalance_1.Tag, dPresentBalance_1.Text)
            End If
            If txtOpened_1.Text = txtOpened_1.Tag Then
            Else
                Change &= String.Format("Change Date Opened 1 from {0} to {1}. ", txtOpened_1.Tag, txtOpened_1.Text)
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
                Change &= String.Format("Change Account No. 2 from {0} to {1}. ", txtSA_2.Tag, txtSA_2.Text)
            End If
            If dAverageBalance_2.Value = dAverageBalance_2.Tag Then
            Else
                Change &= String.Format("Change Averange Balance 2 from {0} to {1}. ", dAverageBalance_2.Tag, dAverageBalance_2.Text)
            End If
            If dPresentBalance_2.Value = dPresentBalance_2.Tag Then
            Else
                Change &= String.Format("Change Present Balance 2 from {0} to {1}. ", dPresentBalance_2.Tag, dPresentBalance_2.Text)
            End If
            If txtOpened_2.Text = txtOpened_2.Tag Then
            Else
                Change &= String.Format("Change Date Opened 2 from {0} to {1}. ", txtOpened_2.Tag, txtOpened_2.Text)
            End If
            If txtBankRemarks_2.Text = txtBankRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Bank Remarks 2 from {0} to {1}. ", txtBankRemarks_2.Tag, txtBankRemarks_2.Text)
            End If
            If txtBank_3.Text = txtBank_3.Tag Then
            Else
                Change &= String.Format("Change Bank 3 from {0} to {1}. ", txtBank_3.Tag, txtBank_3.Text)
            End If
            If txtBranch_3.Text = txtBranch_3.Tag Then
            Else
                Change &= String.Format("Change Branch 3 from {0} to {1}. ", txtBranch_3.Tag, txtBranch_3.Text)
            End If
            If cbxSA_3.Tag <> "SA" And cbxSA_3.Checked Then
                Change &= String.Format("Change Account Type 3 from {0} to {1}. ", cbxSA_3.Tag, "SA")
            ElseIf cbxCA_3.Tag <> "CA" And cbxCA_3.Checked Then
                Change &= String.Format("Change Account Type 3 from {0} to {1}. ", cbxCA_3.Tag, "CA")
            End If
            If txtSA_3.Text = txtSA_3.Tag Then
            Else
                Change &= String.Format("Change Account No. from {0} to {1}. ", txtSA_3.Tag, txtSA_3.Text)
            End If
            If dAverageBalance_3.Value = dAverageBalance_3.Tag Then
            Else
                Change &= String.Format("Change Average Balance 3 from {0} to {1}. ", dAverageBalance_3.Tag, dAverageBalance_3.Text)
            End If
            If dPresentBalance_3.Value = dPresentBalance_3.Tag Then
            Else
                Change &= String.Format("Change Present Balance 3 from {0} to {1}. ", dPresentBalance_3.Tag, dPresentBalance_3.Text)
            End If
            If txtOpened_3.Text = txtOpened_3.Tag Then
            Else
                Change &= String.Format("Change Date Opened 3 from {0} to {1}. ", txtOpened_3.Tag, txtOpened_3.Text)
            End If
            If txtBankRemarks_3.Text = txtBankRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Bank Remarks 3 from {0} to {1}. ", txtBankRemarks_3.Tag, txtBankRemarks_3.Text)
            End If
            If txtLocation_1.Text = txtLocation_1.Tag Then
            Else
                Change &= String.Format("Change Location 1 from {0} to {1}. ", txtLocation_1.Tag, txtLocation_1.Text)
            End If
            If txtTCT_1.Text = txtTCT_1.Tag Then
            Else
                Change &= String.Format("Change TCT 1 from {0} to {1}. ", txtTCT_1.Tag, txtTCT_1.Text)
            End If
            If dArea_1.Value = dArea_1.Tag Then
            Else
                Change &= String.Format("Change Area 1 from {0} to {1}. ", dArea_1.Tag, dArea_1.Text)
            End If
            If txtAcquired_1.Text = txtAcquired_1.Tag Then
            Else
                Change &= String.Format("Change Acquired 1 from {0} to {1}. ", txtAcquired_1.Tag, txtAcquired_1.Text)
            End If
            If txtPropertiesRemarks_1.Text = txtPropertiesRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Properties Remarks 1 from {0} to {1}. ", txtPropertiesRemarks_1.Tag, txtPropertiesRemarks_1.Text)
            End If
            If txtLocation_2.Text = txtLocation_2.Tag Then
            Else
                Change &= String.Format("Change Location 2 from {0} to {1}. ", txtLocation_2.Tag, txtLocation_2.Text)
            End If
            If txtTCT_2.Text = txtTCT_2.Tag Then
            Else
                Change &= String.Format("Change TCT 2 from {0} to {1}. ", txtTCT_2.Tag, txtTCT_2.Text)
            End If
            If dArea_2.Value = dArea_2.Tag Then
            Else
                Change &= String.Format("Change Area 2 from {0} to {1}. ", dArea_2.Tag, dArea_2.Text)
            End If
            If txtAcquired_2.Text = txtAcquired_2.Tag Then
            Else
                Change &= String.Format("Change Acquired 2 from {0} to {1}. ", txtAcquired_2.Tag, txtAcquired_2.Text)
            End If
            If txtPropertiesRemarks_2.Text = txtPropertiesRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Properties Remarks 2 from {0} to {1}. ", txtPropertiesRemarks_2.Tag, txtPropertiesRemarks_2.Text)
            End If
            If txtLocation_3.Text = txtLocation_3.Tag Then
            Else
                Change &= String.Format("Change Location 3 from {0} to {1}. ", txtLocation_3.Tag, txtLocation_3.Text)
            End If
            If txtTCT_3.Text = txtTCT_3.Tag Then
            Else
                Change &= String.Format("Change TCT 3 from {0} to {1}. ", txtTCT_3.Tag, txtTCT_3.Text)
            End If
            If dArea_3.Value = dArea_3.Tag Then
            Else
                Change &= String.Format("Change Area 3 from {0} to {1}. ", dArea_3.Tag, dArea_3.Text)
            End If
            If txtAcquired_3.Text = txtAcquired_3.Tag Then
            Else
                Change &= String.Format("Change Acquired 3 from {0} to {1}. ", txtAcquired_3.Tag, txtAcquired_3.Text)
            End If
            If txtPropertiesRemarks_3.Text = txtPropertiesRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Properties Remarks 3 from {0} to {1}. ", txtPropertiesRemarks_3.Tag, txtPropertiesRemarks_3.Text)
            End If
            If txtVehicle_1.Text = txtVehicle_1.Tag Then
            Else
                Change &= String.Format("Change Vehicle 1 from {0} to {1}. ", txtVehicle_1.Tag, txtVehicle_1.Text)
            End If
            If If(dtpYear_1.Tag = "", dtpYear_1.Text.Trim = dtpYear_1.Tag, Format(dtpYear_1.Value, "yyyy-MM-dd") = dtpYear_1.Tag) Then
            Else
                Change &= String.Format("Change Year Model 1 from {0} to {1}. ", dtpYear_1.Tag, dtpYear_1.Text.Trim)
            End If
            If txtWhomAcquired_1.Text = txtWhomAcquired_1.Tag Then
            Else
                Change &= String.Format("Change Whom Acquired 1  from {0} to {1}. ", txtWhomAcquired_1.Tag, txtWhomAcquired_1.Text)
            End If
            If txtWhenAcquired_1.Text = txtWhenAcquired_1.Tag Then
            Else
                Change &= String.Format("Change When Acquired 1 from {0} to {1}. ", txtWhenAcquired_1.Tag, txtWhenAcquired_1.Text)
            End If
            If txtVehicleRemarks_1.Text = txtVehicleRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Vehicle Remark 1 from {0} to {1}. ", txtVehicleRemarks_1.Tag, txtVehicleRemarks_1.Text)
            End If
            If txtVehicle_2.Text = txtVehicle_2.Tag Then
            Else
                Change &= String.Format("Change Vehicle 2 from {0} to {1}. ", txtVehicle_2.Tag, txtVehicle_2.Text)
            End If
            If If(dtpYear_2.Tag = "", dtpYear_2.Text.Trim = dtpYear_2.Tag, Format(dtpYear_2.Value, "yyyy-MM-dd") = dtpYear_2.Tag) Then
            Else
                Change &= String.Format("Change Year Model 2 from {0} to {1}. ", dtpYear_2.Tag, dtpYear_2.Text.Trim)
            End If
            If txtWhomAcquired_2.Text = txtWhomAcquired_2.Tag Then
            Else
                Change &= String.Format("Change Whom Acquired 2 from {0} to {1}. ", txtWhomAcquired_2.Tag, txtWhomAcquired_2.Text)
            End If
            If txtWhenAcquired_2.Text = txtWhenAcquired_2.Tag Then
            Else
                Change &= String.Format("Change When Acquired 2 from {0} to {1}. ", txtWhenAcquired_2.Tag, txtWhenAcquired_1.Text)
            End If
            If txtVehicleRemarks_2.Text = txtVehicleRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Vehicle Remarks 2 from {0} to {1}. ", txtVehicleRemarks_2.Tag, txtVehicleRemarks_2.Text)
            End If
            If txtVehicle_3.Text = txtVehicle_3.Tag Then
            Else
                Change &= String.Format("Change Vehicle 3 from {0} to {1}. ", txtVehicle_3.Tag, txtVehicle_3.Text)
            End If
            If If(dtpYear_3.Tag = "", dtpYear_3.Text.Trim = dtpYear_3.Tag, Format(dtpYear_3.Value, "yyyy-MM-dd") = dtpYear_3.Tag) Then
            Else
                Change &= String.Format("Change Year 3 from {0} to {1}. ", dtpYear_3.Tag, dtpYear_3.Text.Trim)
            End If
            If txtWhomAcquired_3.Text = txtWhomAcquired_3.Tag Then
            Else
                Change &= String.Format("Change Whom Acquired 3 from {0} to {1}. ", txtWhomAcquired_3.Tag, txtWhomAcquired_3.Text)
            End If
            If txtWhenAcquired_3.Text = txtWhenAcquired_3.Tag Then
            Else
                Change &= String.Format("Change When Acquired 3 from {0} to {1}. ", txtWhenAcquired_3.Tag, txtWhenAcquired_3.Text)
            End If
            If txtVehicleRemarks_3.Text = txtVehicleRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Vehicle Remarks 3 from {0} to {1}. ", txtVehicleRemarks_3.Tag, txtVehicleRemarks_3.Text)
            End If
            If txtHomeAppliances_1.Text = txtHomeAppliances_1.Tag Then
            Else
                Change &= String.Format("Change Home Appliances 1 from {0} to {1}. ", txtHomeAppliances_1.Tag, txtHomeAppliances_1.Text)
            End If
            If txtHomeAppliances_2.Text = txtHomeAppliances_2.Tag Then
            Else
                Change &= String.Format("Change Home Appliances 2 from {0} to {1}. ", txtHomeAppliances_2.Tag, txtHomeAppliances_2.Text)
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
            If txtCertificateNo.Text = txtCertificateNo.Tag Then
            Else
                Change &= String.Format("Change Certification No from {0} to {1}. ", txtCertificateNo.Tag, txtCertificateNo.Text)
            End If
            If txtPlaceIssue.Text = txtPlaceIssue.Tag Then
            Else
                Change &= String.Format("Change Place Issue from {0} to {1}. ", txtPlaceIssue.Tag, txtPlaceIssue.Text)
            End If
            If FormatDatePicker(dtpIssue) = dtpIssue.Tag Then
            Else
                Change &= String.Format("Change Date Issue from {0} to {1}. ", dtpIssue.Tag, FormatDatePicker(dtpIssue))
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

            '*** S P O U S E ***
            If tabSpouse.Visible And SpouseID <> "" Then
                If CbxPrefix_S.Text = CbxPrefix_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Prefix from {0} to {1}. ", CbxPrefix_S.Tag, CbxPrefix_S.Text)
                End If
                If TxtFirstN_S.Text = TxtFirstN_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse First Name from {0} to {1}. ", TxtFirstN_S.Tag, TxtFirstN_S.Text)
                End If
                If TxtMiddleN_S.Text = TxtMiddleN_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Middle Name from {0} to {1}. ", TxtMiddleN_S.Tag, TxtMiddleN_S.Text)
                End If
                If TxtLastN_S.Text = TxtLastN_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Last Name from {0} to {1}. ", TxtLastN_S.Tag, TxtLastN_S.Text)
                End If
                If cbxSuffix_S.Text = cbxSuffix_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Suffix from {0} to {1}. ", cbxSuffix_S.Tag, cbxSuffix_S.Text)
                End If
                If CbxPrefix_M.Text = CbxPrefix_M.Tag Then
                Else
                    Change &= String.Format("Change Spouse Maiden Prefix from {0} to {1}. ", CbxPrefix_M.Tag, CbxPrefix_M.Text)
                End If
                If TxtFirstN_M.Text = TxtFirstN_M.Tag Then
                Else
                    Change &= String.Format("Change Spouse Maiden First Name from {0} to {1}. ", TxtFirstN_M.Tag, TxtFirstN_M.Text)
                End If
                If TxtMiddleN_M.Text = TxtMiddleN_M.Tag Then
                Else
                    Change &= String.Format("Change Spouse Maiden Middle Name from {0} to {1}. ", TxtMiddleN_M.Tag, TxtMiddleN_M.Text)
                End If
                If TxtLastN_M.Text = TxtLastN_M.Tag Then
                Else
                    Change &= String.Format("Change Spouse Maiden Last Name from {0} to {1}. ", TxtLastN_M.Tag, TxtLastN_M.Text)
                End If
                If cbxSuffix_M.Text = cbxSuffix_M.Tag Then
                Else
                    Change &= String.Format("Change Spouse Maiden Suffix from {0} to {1}. ", cbxSuffix_M.Tag, cbxSuffix_M.Text)
                End If
                If txtNoC_S.Text = txtNoC_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Complete Address No from {0} to {1}. ", txtNoC_S.Tag, txtNoC_S.Text)
                End If
                If txtStreetC_S.Text = txtStreetC_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Complete Address Street from {0} to {1}. ", txtStreetC_S.Tag, txtStreetC_S.Text)
                End If
                If txtBarangayC_S.Text = txtBarangayC_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Complete Address Barangay from {0} to {1}. ", txtBarangayC_S.Tag, txtBarangayC_S.Text)
                End If
                If cbxAddressC_S.Text = cbxAddressC_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Complete Address from {0} to {1}. ", cbxAddressC_S.Tag, cbxAddressC_S.Text)
                End If
                If txtNoP_S.Text = txtNoP_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Provincial Address No  from {0} to {1}. ", txtNoP_S.Tag, txtNoP_S.Text)
                End If
                If txtStreetP_S.Text = txtStreetP_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Provincial Address Street from {0} to {1}. ", txtStreetP_S.Tag, txtStreetP_S.Text)
                End If
                If txtBarangayP_S.Text = txtBarangayP_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Provincial Address Barangay from {0} to {1}. ", txtBarangayP_S.Tag, txtBarangayP_S.Text)
                End If
                If cbxAddressP_S.Text = cbxAddressP_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Provincial Address from {0} to {1}. ", cbxAddressP_S.Tag, cbxAddressP_S.Text)
                End If
                If FormatDatePicker(DtpBirth_S) = DtpBirth_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Birthdate from {0} to {1}. ", DtpBirth_S.Tag, FormatDatePicker(DtpBirth_S))
                End If
                If cbxPlaceBirth_S.Text = cbxPlaceBirth_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Place of Birth from {0} to {1}. ", cbxPlaceBirth_S.Tag, cbxPlaceBirth_S.Text)
                End If
                If tabSpouse.Visible = True Then
                    If cbxMale_S.Tag <> "Male" And cbxMale_S.Checked Then
                        Change &= String.Format("Change Spouse Gender from {0} to {1}. ", cbxMale_S.Tag, cbxMale_S.Text)
                    ElseIf cbxFemale_S.Tag <> "Female" And cbxFemale_S.Checked Then
                        Change &= String.Format("Change Spouse Gender from {0} to {1}. ", cbxFemale_S.Tag, cbxFemale_S.Text)
                    End If
                End If
                If txtCitizenship_S.Text = txtCitizenship_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Citizenship from {0} to {1}. ", txtCitizenship_S.Tag, txtCitizenship_S.Text)
                End If
                If txtTIN_S.Text = txtTIN_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse TIN from {0} to {1}. ", txtTIN_S.Tag, txtTIN_S.Text)
                End If
                If txtTelephone_S.Text = txtTelephone_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Telephone from {0} to {1}. ", txtTelephone_S.Tag, txtTelephone_S.Text)
                End If
                If txtSSS_S.Text = txtSSS_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse SSS from {0} to {1}. ", txtSSS_S.Tag, txtSSS_S.Text)
                End If
                If txtMobile_S.Text = txtMobile_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Mobile from {0} to {1}. ", txtMobile_S.Tag, txtMobile_S.Text)
                End If
                If txtEmail_S.Text = txtEmail_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Email from {0} to {1}. ", txtEmail_S.Tag, txtEmail_S.Text)
                End If
                If tabSpouse.Visible = True Then
                    If cbxOwned_S.Tag <> "Owned" And cbxOwned_S.Checked Then
                        Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxOwned_S.Tag, cbxOwned_S.Text)
                    ElseIf cbxFree_S.Tag <> "Free" And cbxFree_S.Checked Then
                        Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxFree_S.Tag, cbxFree_S.Text)
                    ElseIf cbxRented_S.Tag <> "Rented" And cbxRented_S.Checked Then
                        Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxRented_S.Tag, cbxRented_S.Text)
                    End If
                    If dRent_S.Value = dRent_S.Tag Then
                    Else
                        Change &= String.Format("Change Spouse Rent from {0} to {1}. ", dRent_S.Tag, dRent_S.Text)
                    End If
                End If
                If cbxEmployer_S.Text = cbxEmployer_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Employer from {0} to {1}. ", cbxEmployer_S.Tag, cbxEmployer_S.Text)
                End If
                If txtEmployerAddress_S.Text = txtEmployerAddress_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Employer Address from {0} to {1}. ", txtEmployerAddress_S.Tag, txtEmployerAddress_S.Text)
                End If
                If txtEmployerTelephone_S.Text = txtEmployerTelephone_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Employer Telephone from {0} to {1}. ", txtEmployerTelephone_S.Tag, txtEmployerTelephone_S.Text)
                End If
                If cbxPosition_S.Text = cbxPosition_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Position from {0} to {1}. ", cbxPosition_S.Tag, cbxPosition_S.Text)
                End If
                If cbxCasual_S.Tag.ToString <> "Casual" And cbxCasual_S.Checked Then
                    Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxCasual_S.Tag, cbxCasual_S.Text)
                ElseIf cbxTemporary_S.Tag.ToString <> "Temporary" And cbxTemporary_S.Checked Then
                    Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxTemporary_S.Tag, cbxTemporary_S.Text)
                ElseIf cbxPermanent_S.Tag.ToString <> "Permanent" And cbxPermanent_S.Checked Then
                    Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxPermanent_S.Tag, cbxPermanent_S.Text)
                End If
                If FormatDatePicker(dtpHired_S) = dtpHired_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Date Hired from {0} to {1}. ", dtpHired_S.Tag, FormatDatePicker(dtpHired_S))
                End If
                If txtSupervisor_S.Text = txtSupervisor_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Supervisor from {0} to {1}. ", txtSupervisor_S.Tag, txtSupervisor_S.Text)
                End If
                If dMonthly_S.Value = dMonthly_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Gross Monthly Income as employed from {0} to {1}. ", dMonthly_S.Tag, dMonthly_S.Text)
                End If
                If txtBusinessName_S.Text = txtBusinessName_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Business Name from {0} to {1}. ", txtBusinessName_S.Tag, txtBusinessName_S.Text)
                End If
                If txtBusinessAddress_S.Text = txtBusinessAddress_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Business Address from {0} to {1}. ", txtBusinessAddress_S.Tag, txtBusinessAddress_S.Text)
                End If
                If txtBusinessTelephone_S.Text = txtBusinessTelephone_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Business Telephone from {0} to {1}. ", txtBusinessTelephone_S.Tag, txtBusinessTelephone_S.Text)
                End If
                If cbxNatureBusiness_S.Text = cbxNatureBusiness_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Nature of Business from {0} to {1}. ", cbxNatureBusiness_S.Tag, cbxNatureBusiness_S.Text)
                End If
                If iYrsOperation_S.Value = iYrsOperation_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Years Operation from {0} to {1}. ", iYrsOperation_S.Tag, iYrsOperation_S.Text)
                End If
                If dBusinessIncome_S.Value = dBusinessIncome_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Business Income from {0} to {1}. ", dBusinessIncome_S.Tag, dBusinessIncome_S.Text)
                End If
                If iNoEmployees_S.Value = iNoEmployees_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse No of Employees from {0} to {1}. ", iNoEmployees_S.Tag, iNoEmployees_S.Text)
                End If
                If dCapital_S.Value = dCapital_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Capital from {0} to {1}. ", dCapital_S.Tag, dCapital_S.Text)
                End If
                If txtArea_S.Text = txtArea_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Area from {0} to {1}. ", txtArea_S.Tag, txtArea_S.Text)
                End If
                If FormatDatePicker(dtpExpiry_S) = dtpExpiry_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Business Expiry from {0} to {1}. ", dtpExpiry_S.Tag, FormatDatePicker(dtpExpiry_S))
                End If
                If iOutlet_S.Value = iOutlet_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse No of Outlet from {0} to {1}. ", iOutlet_S.Tag, iOutlet_S.Text)
                End If
                If txtOtherIncome_S.Text = txtOtherIncome_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Other Income from {0} to {1}. ", txtOtherIncome_S.Tag, txtOtherIncome_S.Text)
                End If
                If dOtherIncome_S.Value = dOtherIncome_S.Tag Then
                Else
                    Change &= String.Format("Change Spouse Other Income Monthly from {0} to {1}. ", dOtherIncome_S.Tag, dOtherIncome_S.Text)
                End If
            End If
            If ChangeBorrowerPic Then
                Change &= "Change Borrower Picture. "
            End If
            If ChangeSpousePic Then
                Change &= "Change Spouse Picture. "
            End If
            If DependentID_1 = "" And FirstN_1 <> "" Then
                Change &= "Add Dependent 1 Info."
            End If
            If DependentID_2 = "" And FirstN_2 <> "" Then
                Change &= "Add Dependent 2 Info."
            End If
            If DependentID_3 = "" And FirstN_3 <> "" Then
                Change &= "Add Dependent 3 Info."
            End If
            If DependentID_4 = "" And FirstN_4 <> "" Then
                Change &= "Add Dependent 4 Info."
            End If
            If DependentID_1 <> "" And FirstN_1 = "" Then
                Change &= "Remove Dependent 1 Info. "
            End If
            If DependentID_1 <> "" And FirstN_1 = "" Then
                Change &= "Remove Dependent 1 Info. "
            End If
            If DependentID_2 <> "" And FirstN_2 = "" Then
                Change &= "Remove Dependent 2 Info. "
            End If
            If DependentID_3 <> "" And FirstN_3 = "" Then
                Change &= "Remove Dependent 3 Info. "
            End If
            If DependentID_4 <> "" And FirstN_4 = "" Then
                Change &= "Remove Dependent 4 Info. "
            End If
            If SpouseID <> "" And tabSpouse.Visible = False Then
                Change &= "Remove Spouse Info. "
            End If
            If SpouseID = "" And tabSpouse.Visible Then
                Change &= "Add Spouse Info. "
            End If
            If cbxBusinessCenter.Text = cbxBusinessCenter.Tag Then
            Else
                Change &= String.Format("Change Business Center from {0} to {1}. ", cbxBusinessCenter.Tag, cbxBusinessCenter.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Borrower - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave_F.Focus()
            btnSave_F.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.E Then
            btnAddD_B.Focus()
            btnAddD_B.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(Me.FormBorderStyle = FormBorderStyle.FixedDialog, e.KeyCode = Keys.Escape, 0) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
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
            Dim xPath As String
            xPath = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, txtBorrowerID.Text, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
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
            Dim BorrowerName As String = If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text)
            Dim CreditApplicationCount As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM credit_application WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE';", txtBorrowerID.Text))
            If CreditApplicationCount > 0 Then
                MsgBox(String.Format("Borrower {0} have existing {1} active credit application accounts, cancellation is not allowed.", BorrowerName, CreditApplicationCount), MsgBoxStyle.Information, "Info")
                Cursor = Cursors.Default
                Exit Sub
            End If
            DataObject(String.Format("UPDATE profile_borrower SET `status` = 'DELETED' WHERE BorrowerID = '{0}'", txtBorrowerID.Text))
            Logs("Borrower", "Cancel", Reason, String.Format("Cancel borrower {0}", BorrowerName), txtBorrowerID.Text, BorrowerName, "")
            Clear()
            Cursor = Cursors.Default
            FrmBorrowerList.btnSearch.PerformClick()
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update Draft"
            btnSave_F.Text = "Update"
            btnSave_F.Enabled = True
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True

            PanelEx2.Enabled = True
            PanelEx4.Enabled = True
            PanelEx11.Enabled = True
            PanelEx12.Enabled = True
            PanelEx13.Enabled = True
            PanelEx14.Enabled = True
            PanelEx5.Enabled = True
            PanelEx8.Enabled = True
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptLoanApplication
        With Report
            If TxtFirstN_B.Text = "" And TxtLastN_B.Text = "" Then
                Cursor = Cursors.Default
                Logs("Borrower", "Print", "", "Print Empty Form", txtBorrowerID.Text, "", "")
                .ShowPreview()
                Exit Sub
            End If
            .Name = txtBorrowerID.Text
            .tAmount.Text = ""
            .tTerms.Text = ""
            .tCollateral.Text = ""
            .tPurpose.Text = ""
            .tDate.Text = Format(Date.Now, "MMM. dd, yyyy")
            .p_Borrower.Image = pb_B.Image.Clone
            .lblLoanNumber.Text = ""
            .lblBorrowerID.Text = txtBorrowerID.Text
            .lblBorrower.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & " ") & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & If(cbxSuffix_B.Text.Trim = "", "", cbxSuffix_B.Text.Trim & " ")
            .lblSpouse.Text = If(CbxPrefix_S.Text.Trim = "", "", CbxPrefix_S.Text.Trim & " ") & If(TxtFirstN_S.Text.Trim = "", "", TxtFirstN_S.Text.Trim & " ") & If(TxtMiddleN_S.Text.Trim = "", "", TxtMiddleN_S.Text.Trim & " ") & If(TxtLastN_S.Text.Trim = "", "", TxtLastN_S.Text.Trim & " ") & If(cbxSuffix_S.Text.Trim = "", "", cbxSuffix_S.Text.Trim & " ")
            .lblCoMaker1.Text = ""
            .lblCoMakerII.Text = ""
            .lblCompleteAdd.Text = If(txtNoC_B.Text.Trim = "", "", txtNoC_B.Text.Trim & " ") & If(txtStreetC_B.Text.Trim = "", "", txtStreetC_B.Text.Trim & " ") & If(txtBarangayC_B.Text.Trim = "", "", txtBarangayC_B.Text.Trim & " ") & If(cbxAddressC_B.Text.Trim = "", "", cbxAddressC_B.Text.Trim & " ")
            .lblProvincialAdd.Text = If(txtNoP_B.Text.Trim = "", "", txtNoP_B.Text.Trim & " ") & If(txtStreetP_B.Text.Trim = "", "", txtStreetP_B.Text.Trim & " ") & If(txtBarangayP_B.Text.Trim = "", "", txtBarangayP_B.Text.Trim & " ") & If(cbxAddressP_B.Text.Trim = "", "", cbxAddressP_B.Text.Trim & " ")
            .lblBirthDate.Text = DtpBirth_B.Text
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
            .cbxOwned.Checked = cbxOwned_B.Checked
            .cbxFree.Checked = cbxFree_B.Checked
            .cbxRented.Checked = cbxRented_B.Checked
            .lblRent.Text = If(cbxRented_B.Checked, dRent_B.Text & " / month", "")
            .lblDependent_1.Text = If(Prefix_1 = "", "", Prefix_1 & " ") & If(FirstN_1 = "", "", FirstN_1 & " ") & If(MiddleN_1 = "", "", MiddleN_1 & " ") & If(LastN_1 = "", "", LastN_1 & " ") & If(Suffix_1 = "", "", Suffix_1 & " ")
            .lblBirthDate_1.Text = Birth_1
            .lblGrade_1.Text = If(Grade_1 = "", "", Grade_1 & " ") & If(School_1 = "", "", School_1 & " ") & If(SchoolAddress_1 = "", "", SchoolAddress_1 & " ")
            .lblDependent_2.Text = If(Prefix_2 = "", "", Prefix_2 & " ") & If(FirstN_2 = "", "", FirstN_2 & " ") & If(MiddleN_2 = "", "", MiddleN_2 & " ") & If(LastN_2 = "", "", LastN_2 & " ") & If(Suffix_2 = "", "", Suffix_2 & " ")
            .lblBirthDate_2.Text = Birth_2
            .lblGrade_2.Text = If(Grade_2 = "", "", Grade_2 & " ") & If(School_2 = "", "", School_2 & " ") & If(SchoolAddress_2 = "", "", SchoolAddress_2 & " ")
            .lblDependent_3.Text = If(Prefix_3 = "", "", Prefix_3 & " ") & If(FirstN_3 = "", "", FirstN_3 & " ") & If(MiddleN_3 = "", "", MiddleN_3 & " ") & If(LastN_3 = "", "", LastN_3 & " ") & If(Suffix_3 = "", "", Suffix_3 & " ")
            .lblBirthDate_3.Text = Birth_3
            .lblGrade_3.Text = If(Grade_3 = "", "", Grade_3 & " ") & If(School_3 = "", "", School_3 & " ") & If(SchoolAddress_3 = "", "", SchoolAddress_3 & " ")
            .lblDependent_4.Text = If(Prefix_4 = "", "", Prefix_4 & " ") & If(FirstN_4 = "", "", FirstN_4 & " ") & If(MiddleN_4 = "", "", MiddleN_4 & " ") & If(LastN_4 = "", "", LastN_4 & " ") & If(Suffix_4 = "", "", Suffix_4 & " ")
            .lblBirthDate_4.Text = Birth_4
            .lblGrade_4.Text = If(Grade_4 = "", "", Grade_4 & " ") & If(School_4 = "", "", School_4 & " ") & If(SchoolAddress_4 = "", "", SchoolAddress_4 & " ")
            .lblEmployer.Text = cbxEmployer_B.Text
            .lblEmployerAddress.Text = txtEmployerAddress_B.Text
            .lblEmployerTel.Text = txtEmployerTelephone_B.Text
            .lblPosition.Text = cbxPosition_B.Text
            .cbxCasual.Checked = cbxCasual_B.Checked
            .cbxTemporary.Checked = cbxTemporary_B.Checked
            .cbxPermanent.Checked = cbxPermanent_B.Checked
            .lblDateHired.Text = dtpHired_B.Text
            .lblSupervisor.Text = txtSupervisor_B.Text
            .lblMonthlyIncome.Text = dMonthly_B.Text

            .lblEmployer_S.Text = cbxEmployer_S.Text
            .lblEmployerAddress_S.Text = txtEmployerAddress_S.Text
            .lblEmployerTel_S.Text = txtEmployerTelephone_S.Text
            .lblPosition_S.Text = cbxPosition_S.Text
            .cbxCasual_S.Checked = cbxCasual_S.Checked
            .cbxTemporary_S.Checked = cbxTemporary_S.Checked
            .cbxPermanent_S.Checked = cbxPermanent_S.Checked
            .lblDateHired_S.Text = dtpHired_S.Text
            .lblSupervisor_S.Text = txtSupervisor_S.Text
            .lblMonthlyIncome_S.Text = dMonthly_S.Text

            .lblBusiness.Text = txtBusinessName_B.Text
            .lblBusinessAddress.Text = txtBusinessAddress_B.Text
            .lblBusinessTel.Text = txtBusinessTelephone_B.Text
            .lblNature.Text = cbxNatureBusiness_B.Text
            .lblYearsOperation.Text = iYrsOperation_B.Text
            .lblBusinessIncome.Text = dBusinessIncome_B.Text
            .lblNoEmployees.Text = iNoEmployees_B.Text
            .lblCapital.Text = dCapital_B.Text
            .lblCoverageArea.Text = txtArea_B.Text
            .lblExpiry.Text = dtpExpiry_B.Text
            .lblOutlet.Text = iOutlet_B.Text
            .lblOtherIncome.Text = txtOtherIncome_B.Text
            .lblOtherMonthlyIncome.Text = dOtherIncome_B.Text
            .lblCreditor_1.Text = txtCreditor_1.Text
            .lblNature_1.Text = txtNatureLoan_1.Text
            .lblAmount_1.Text = dAmountGranted_1.Text
            .lblTerm_1.Text = dTerm_1.Text
            .lblBalance_1.Text = dBalance_1.Text
            .lblRemarks_1.Text = txtCreditRemarks_1.Text
            .lblCreditor_2.Text = txtCreditor_2.Text
            .lblNature_2.Text = txtNatureLoan_2.Text
            .lblAmount_2.Text = dAmountGranted_2.Text
            .lblTerm_2.Text = dTerm_2.Text
            .lblBalance_2.Text = dBalance_2.Text
            .lblRemarks_2.Text = txtCreditRemarks_2.Text
            .lblCreditor_3.Text = txtCreditor_3.Text
            .lblNature_3.Text = txtNatureLoan_3.Text
            .lblAmount_3.Text = dAmountGranted_3.Text
            .lblTerm_3.Text = dTerm_3.Text
            .lblBalance_3.Text = dBalance_3.Text
            .lblRemarks_3.Text = txtCreditRemarks_3.Text
            .lblBank_1.Text = txtBank_1.Text
            .lblBranch_1.Text = txtBranch_1.Text
            .lblSA_1.Text = If(cbxSA_1.Checked, "SA - ", If(cbxCA_1.Checked, "CA - ", "")) & txtSA_1.Text
            .lblAverage_1.Text = dAverageBalance_1.Text
            .lblPresent_1.Text = dPresentBalance_1.Text
            .lblDateOpened_1.Text = txtOpened_1.Text
            .lblBankRemarks_1.Text = txtBankRemarks_1.Text
            .lblBank_2.Text = txtBank_2.Text
            .lblBranch_2.Text = txtBranch_2.Text
            .lblSA_2.Text = If(cbxSA_2.Checked, "SA - ", If(cbxCA_2.Checked, "CA - ", "")) & txtSA_2.Text
            .lblAverage_2.Text = dAverageBalance_2.Text
            .lblPresent_2.Text = dPresentBalance_2.Text
            .lblDateOpened_2.Text = txtOpened_2.Text
            .lblBankRemarks_2.Text = txtBankRemarks_2.Text
            .lblBank_3.Text = txtBank_3.Text
            .lblBranch_3.Text = txtBranch_3.Text
            .lblSA_3.Text = If(cbxSA_3.Checked, "SA - ", If(cbxCA_3.Checked, "CA - ", "")) & txtSA_3.Text
            .lblAverage_3.Text = dAverageBalance_3.Text
            .lblPresent_3.Text = dPresentBalance_3.Text
            .lblDateOpened_3.Text = txtOpened_3.Text
            .lblBankRemarks_3.Text = txtBankRemarks_3.Text
            .lblLocation_1.Text = txtLocation_1.Text
            .lblTCT_1.Text = txtTCT_1.Text
            .lblArea_1.Text = dArea_1.Text
            .lblAcquired_1.Text = txtAcquired_1.Text
            .lblEstateRemarks_1.Text = txtPropertiesRemarks_1.Text
            .lblLocation_2.Text = txtLocation_2.Text
            .lblTCT_2.Text = txtTCT_2.Text
            .lblArea_2.Text = dArea_2.Text
            .lblAcquired_2.Text = txtAcquired_2.Text
            .lblEstateRemarks_2.Text = txtPropertiesRemarks_2.Text
            .lblLocation_3.Text = txtLocation_3.Text
            .lblTCT_3.Text = txtTCT_3.Text
            .lblArea_3.Text = dArea_3.Text
            .lblAcquired_3.Text = txtAcquired_3.Text
            .lblEstateRemarks_3.Text = txtPropertiesRemarks_3.Text
            .lblVehicle_1.Text = txtVehicle_1.Text
            .lblYear_1.Text = dtpYear_1.Text
            .lblWhom_1.Text = txtWhomAcquired_1.Text
            .lblWhen_1.Text = txtWhenAcquired_1.Text
            .lblVehicleRemarks_1.Text = txtVehicleRemarks_1.Text
            .lblVehicle_2.Text = txtVehicle_2.Text
            .lblYear_2.Text = dtpYear_2.Text
            .lblWhom_2.Text = txtWhomAcquired_2.Text
            .lblWhen_2.Text = txtWhenAcquired_2.Text
            .lblVehicleRemarks_2.Text = txtVehicleRemarks_2.Text
            .lblVehicle_3.Text = txtVehicle_3.Text
            .lblYear_3.Text = dtpYear_3.Text
            .lblWhom_3.Text = txtWhomAcquired_3.Text
            .lblWhen_3.Text = txtWhenAcquired_3.Text
            .lblVehicleRemarks_3.Text = txtVehicleRemarks_3.Text
            .lblAppliances_1.Text = txtHomeAppliances_1.Text
            .lblAppliances_2.Text = txtHomeAppliances_2.Text
            .lblReference_1.Text = txtReference_1.Text
            .lblReferenceAdd_1.Text = txtReferenceAddress_1.Text
            .lblReferenceTel_1.Text = txtReferenceContact_1.Text
            .lblReference_2.Text = txtReference_2.Text
            .lblReferenceAdd_2.Text = txtReferenceAddress_2.Text
            .lblReferenceTel_2.Text = txtReferenceContact_2.Text
            .lblReference_3.Text = txtReference_3.Text
            .lblReferenceAdd_3.Text = txtReferenceAddress_3.Text
            .lblReferenceTel_3.Text = txtReferenceContact_3.Text
            .lblDateSigned.Text = ""
            .lblSignature_1.Text = ""
            .lblSignature_2.Text = ""
            .tResidence.Text = txtCertificateNo.Text
            .tPlaceIssue.Text = txtPlaceIssue.Text
            .tDateIssue.Text = dtpIssue.Text
            .cbxAgent.Checked = cbxAgent.Checked
            .txtAgent.Text = cbxAgentName.Text & " " & If(txtAgentContact.Text = "", "", "(" & txtAgentContact.Text & ")")
            .cbxMarketing.Checked = cbxMarketing.Checked
            .txtMarketing.Text = cbxMarketingName.Text & " " & If(txtMarketingContact.Text = "", "", "(" & txtMarketingContact.Text & ")")
            .cbxWalkIn.Checked = cbxWalkIn.Checked
            .txtWalkIn.Text = cbxWalkInType.Text & " " & If(txtWalkInOthers.Text = "", "", "(" & txtWalkInOthers.Text & ")")
            .cbxDealer.Checked = cbxDealer.Checked
            .txtDealer.Text = cbxDealerName.Text & " " & If(txtDealersContact.Text = "", "", "(" & txtDealersContact.Text & ")")
            Logs("Borrower", "Print", "[SENSITIVE]", String.Format("Print borrower {0}", If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text)), txtBorrowerID.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text), "")
            .ShowPreview()
            Cursor = Cursors.Default
        End With
    End Sub

    Private Sub TxtNoC_B_TextChanged(sender As Object, e As EventArgs) Handles txtNoC_B.TextChanged
        txtNoC_S.Text = txtNoC_B.Text
    End Sub

    Private Sub TxtStreetC_B_TextChanged(sender As Object, e As EventArgs) Handles txtStreetC_B.TextChanged
        txtStreetC_S.Text = txtStreetC_B.Text
    End Sub

    Private Sub TxtBarangayC_B_TextChanged(sender As Object, e As EventArgs) Handles txtBarangayC_B.TextChanged
        txtBarangayC_S.Text = txtBarangayC_B.Text
    End Sub

    Private Sub CbxAddressC_B_TextChanged(sender As Object, e As EventArgs) Handles cbxAddressC_B.TextChanged
        cbxAddressC_S.Text = cbxAddressC_B.Text
    End Sub

    Private Sub TxtBusinessAddress_B_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessAddress_B.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If txtBusinessAddress_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                txtBusinessAddress_S.Text = txtBusinessAddress_B.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtBusinessTelephone_B_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessTelephone_B.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If txtBusinessTelephone_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                txtBusinessTelephone_S.Text = txtBusinessTelephone_B.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CbxNatureBusiness_B_TextChanged(sender As Object, e As EventArgs) Handles cbxNatureBusiness_B.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If cbxNatureBusiness_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                cbxNatureBusiness_S.Text = cbxNatureBusiness_B.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IYrsOperation_B_ValueChanged(sender As Object, e As EventArgs) Handles iYrsOperation_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If iYrsOperation_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                iYrsOperation_S.Value = iYrsOperation_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DBusinessIncome_B_ValueChanged(sender As Object, e As EventArgs) Handles dBusinessIncome_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If dBusinessIncome_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                dBusinessIncome_S.Value = dBusinessIncome_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub INoEmployees_B_ValueChanged(sender As Object, e As EventArgs) Handles iNoEmployees_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If iNoEmployees_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                iNoEmployees_S.Value = iNoEmployees_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DCapital_B_ValueChanged(sender As Object, e As EventArgs) Handles dCapital_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If dCapital_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                dCapital_S.Value = dCapital_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtArea_B_TextChanged(sender As Object, e As EventArgs) Handles txtArea_B.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If txtArea_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                txtArea_S.Text = txtArea_B.Text
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DtpExpiry_B_ValueChanged(sender As Object, e As EventArgs) Handles dtpExpiry_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If dtpExpiry_S.Tag = "" Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                dtpExpiry_S.Value = dtpExpiry_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IOutlet_B_ValueChanged(sender As Object, e As EventArgs) Handles iOutlet_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If iOutlet_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                iOutlet_S.Value = iOutlet_B.Value
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DOtherIncome_B_ValueChanged(sender As Object, e As EventArgs) Handles dOtherIncome_B.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If dOtherIncome_S.Tag = 0 Or (txtBusinessName_B.Tag = txtBusinessName_S.Tag And txtBusinessAddress_B.Tag = txtBusinessAddress_S.Tag And txtBusinessTelephone_B.Tag = txtBusinessTelephone_S.Tag And cbxNatureBusiness_B.Tag = cbxNatureBusiness_S.Tag And iYrsOperation_B.Tag = iYrsOperation_S.Tag And dBusinessIncome_B.Tag = dBusinessIncome_S.Tag And iNoEmployees_B.Tag = iNoEmployees_S.Tag And dCapital_B.Tag = dCapital_S.Tag And txtArea_B.Tag = txtArea_S.Tag And dtpExpiry_B.Tag = dtpExpiry_S.Tag And iOutlet_B.Tag = iOutlet_S.Tag And txtOtherIncome_B.Tag = txtOtherIncome_S.Tag And dOtherIncome_B.Tag = dOtherIncome_S.Tag) Then
                dOtherIncome_S.Value = dOtherIncome_B.Value
            End If
        Catch ex As Exception
        End Try
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

    Private Sub CbxNatureBusiness_B2_TextChanged(sender As Object, e As EventArgs) Handles cbxNatureBusiness_B2.TextChanged
        cbxNatureBusiness_B.Text = If(cbxNatureBusiness_B2.Text.Length > 60, cbxNatureBusiness_B2.Text.Substring(1, 60), cbxNatureBusiness_B2.Text)
    End Sub

    Private Sub CbxNatureBusiness_S2_TextChanged(sender As Object, e As EventArgs) Handles cbxNatureBusiness_S2.TextChanged
        cbxNatureBusiness_S.Text = If(cbxNatureBusiness_S2.Text.Length > 60, cbxNatureBusiness_S2.Text.Substring(1, 60), cbxNatureBusiness_S2.Text)
    End Sub

    Private Sub CbxEmployer_B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmployer_B.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxEmployer_B.SelectedItem, DataRowView)
        txtEmployerAddress_B.Text = drv("EmployerAddress_B")
        txtEmployerTelephone_B.Text = drv("EmployerTelephone_B")
    End Sub

    Private Sub CbxEmployer_S_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmployer_S.SelectedIndexChanged
        If FirstLoad Or cbxEmployer_S.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxEmployer_S.SelectedItem, DataRowView)
        txtEmployerAddress_S.Text = drv("EmployerAddress_B")
        txtEmployerTelephone_S.Text = drv("EmployerTelephone_B")
    End Sub

    Private Sub CbxSA_1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSA_1.CheckedChanged
        If cbxSA_1.Checked Then
            txtSA_1.Enabled = True
            cbxCA_1.Checked = False
        End If
    End Sub

    Private Sub CbxCA_1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCA_1.CheckedChanged
        If cbxCA_1.Checked Then
            txtSA_1.Enabled = True
            cbxSA_1.Checked = False
        End If
    End Sub

    Private Sub CbxSA_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSA_2.CheckedChanged
        If cbxSA_2.Checked Then
            txtSA_2.Enabled = True
            cbxCA_2.Checked = False
        End If
    End Sub

    Private Sub CbxCA_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCA_2.CheckedChanged
        If cbxCA_2.Checked Then
            txtSA_2.Enabled = True
            cbxSA_2.Checked = False
        End If
    End Sub

    Private Sub CbxSA_3_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSA_3.CheckedChanged
        If cbxSA_3.Checked Then
            txtSA_3.Enabled = True
            cbxCA_3.Checked = False
        End If
    End Sub

    Private Sub CbxCA_3_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCA_3.CheckedChanged
        If cbxCA_3.Checked Then
            txtSA_3.Enabled = True
            cbxSA_3.Checked = False
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            .Type = "Borrower's Attachment I"
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

    Private Sub BtnID_S_Click(sender As Object, e As EventArgs) Handles btnID_S.Click
        Dim ID As New FrmID
        With ID
            .ID_Type = "S"
            .TotalImage_TIN = TotalImage_TIN_S
            .TotalImage_SSS = TotalImage_SSS_S
            .TotalImage_GSIS = TotalImage_GSIS_S
            .TotalImage_PhilHealth = TotalImage_PhilHealth_S
            .TotalImage_Senior = TotalImage_Senior_S
            .TotalImage_UMID = TotalImage_UMID_S
            .TotalImage_SEC = TotalImage_SEC_S
            .TotalImage_DTI = TotalImage_DTI_S
            .TotalImage_CDA = TotalImage_CDA_S
            .TotalImage_Cooperative = TotalImage_Cooperative_S
            .TotalImage_Drivers = TotalImage_Drivers_S
            .TotalImage_VIN = TotalImage_VIN_S
            .TotalImage_Passport = TotalImage_Passport_S
            .TotalImage_PRC = TotalImage_PRC_S
            .TotalImage_NBI = TotalImage_NBI_S
            .TotalImage_Police = TotalImage_Police_S
            .TotalImage_Postal = TotalImage_Postal_S
            .TotalImage_Barangay = TotalImage_Barangay_S
            .TotalImage_OWWA = TotalImage_OWWA_S
            .TotalImage_OFW = TotalImage_OFW_S
            .TotalImage_Seaman = TotalImage_Seaman_S
            .TotalImage_PNP = TotalImage_PNP_S
            .TotalImage_AFP = TotalImage_AFP_S
            .TotalImage_HDMF = TotalImage_HDMF_S
            .TotalImage_PWD = TotalImage_PWD_S
            .TotalImage_DSWD = TotalImage_DSWD_S
            .TotalImage_ACR = TotalImage_ACR_S
            .TotalImage_DTI_Business = TotalImage_DTI_Business_S
            .TotalImage_IBP = TotalImage_IBP_S
            .TotalImage_FireArms = TotalImage_FireArms_S
            .TotalImage_Government = TotalImage_Government_S
            .TotalImage_Diplomat = TotalImage_Diplomat_S
            .TotalImage_National = TotalImage_National_S
            .TotalImage_Work = TotalImage_Work_S
            .TotalImage_GOCC = TotalImage_GOCC_S
            .TotalImage_PLRA = TotalImage_PLRA_S
            .TotalImage_Major = TotalImage_Major_S
            .TotalImage_Media = TotalImage_Media_S
            .TotalImage_Student = TotalImage_Student_S
            .TotalImage_SIRV = TotalImage_SIRV_S
            If btnSave_F.Text = "Update" Or btnModify.Enabled = True Then
                .btnAttach_TIN.Enabled = True
                .btnAttach_SSS.Enabled = True
                .btnAttach_GSIS.Enabled = True
                .btnAttach_PhilHealth.Enabled = True
                .btnAttach_Senior.Enabled = True
                .btnAttach_UMID.Enabled = True
                .btnAttach_SEC.Enabled = True
                .btnAttach_DTI.Enabled = True
                .btnAttach_CDA.Enabled = True
                .btnAttach_Cooperative.Enabled = True
                .btnAttach_Drivers.Enabled = True
                .btnAttach_VIN.Enabled = True
                .btnAttach_Passport.Enabled = True
                .btnAttach_PRC.Enabled = True
                .btnAttach_NBI.Enabled = True
                .btnAttach_Police.Enabled = True
                .btnAttach_Postal.Enabled = True
                .btnAttach_Barangay.Enabled = True
                .btnAttach_OWWA.Enabled = True
                .btnAttach_OFW.Enabled = True
                .btnAttach_Seaman.Enabled = True
                .btnAttach_PNP.Enabled = True
                .btnAttach_AFP.Enabled = True
                .btnAttach_HDMF.Enabled = True
                .btnAttach_PWD.Enabled = True
                .btnAttach_DSWD.Enabled = True
                .btnAttach_ACR.Enabled = True
                .btnAttach_DTI_Business.Enabled = True
                .btnAttach_IBP.Enabled = True
                .btnAttach_FireArms.Enabled = True
                .btnAttach_Government.Enabled = True
                .btnAttach_Diplomat.Enabled = True
                .btnAttach_National.Enabled = True
                .btnAttach_Work.Enabled = True
                .btnAttach_GOCC.Enabled = True
                .btnAttach_PLRA.Enabled = True
                .btnAttach_Major.Enabled = True
                .btnAttach_Media.Enabled = True
                .btnAttach_Student.Enabled = True
                .btnAttach_SIRV.Enabled = True
            End If
            .BorrowerID = txtBorrowerID.Text
            .txtTIN.Text = txtTIN_S.Text
            .txtSSS.Text = txtSSS_S.Text
            .txtGSIS.Text = GSIS_S
            .txtPhilHealth.Text = PhilHealth_S
            .txtSenior.Text = Senior_S
            .txtUMID.Text = UMID_S
            .txtSEC.Text = SEC_S
            .txtDTI.Text = DTI_S
            .txtCDA.Text = CDA_S
            .txtCooperative.Text = Cooperative_S
            .txtDrivers.Text = Drivers_S
            .txtVIN.Text = VIN_S
            .txtPassport.Text = Passport_S
            .txtPRC.Text = PRC_S
            .txtNBI.Text = NBI_S
            .txtPolice.Text = Police_S
            .txtPostal.Text = Postal_S
            .txtBarangay.Text = Barangay_S
            .txtOWWA.Text = OWWA_S
            .txtOFW.Text = OFW_S
            .txtSeaman.Text = Seaman_S
            .txtPNP.Text = PNP_S
            .txtAFP.Text = AFP_S
            .txtHDMF.Text = HDMF_S
            .txtPWD.Text = PWD_S
            .txtDSWD.Text = DSWD_S
            .txtACR.Text = ACR_S
            .txtDTI_Business.Text = DTI_Business_S
            .txtIBP.Text = IBP_S
            .txtFireArms.Text = FireArms_S
            .txtGovernment.Text = Government_S
            .txtDiplomat.Text = Diplomat_S
            .txtNational.Text = National_S
            .txtWork.Text = Work_S
            .txtGOCC.Text = GOCC_S
            .txtPLRA.Text = PLRA_S
            .txtMajor.Text = Major_S
            .txtMedia.Text = Media_S
            .txtStudent.Text = Student_S
            .txtSIRV.Text = SIRV_S
            If .ShowDialog = DialogResult.OK Then
                txtTIN_S.Text = .txtTIN.Text
                txtSSS_S.Text = .txtSSS.Text
                GSIS_S = .txtGSIS.Text
                PhilHealth_S = .txtPhilHealth.Text
                Senior_S = .txtSenior.Text
                UMID_S = .txtUMID.Text
                SEC_S = .txtSEC.Text
                DTI_S = .txtDTI.Text
                CDA_S = .txtCDA.Text
                Cooperative_S = .txtCooperative.Text
                Drivers_S = .txtDrivers.Text
                dDrivers_S = FormatDatePicker(.dtpDrivers)
                VIN_S = .txtVIN.Text
                dVIN_S = FormatDatePicker(.dtpVIN)
                Passport_S = .txtPassport.Text
                dPassport_S = FormatDatePicker(.dtpPassport)
                PRC_S = .txtPRC.Text
                dPRC_S = FormatDatePicker(.dtpPRC)
                NBI_S = .txtNBI.Text
                dNBI_S = FormatDatePicker(.dtpNBI)
                Police_S = .txtPolice.Text
                dPolice_S = FormatDatePicker(.dtpPolice)
                Postal_S = .txtPostal.Text
                dPostal_S = FormatDatePicker(.dtpPostal)
                Barangay_S = .txtBarangay.Text
                dBarangay_S = FormatDatePicker(.dtpBarangay)
                OWWA_S = .txtOWWA.Text
                dOWWA_S = FormatDatePicker(.dtpOWWA)
                OFW_S = .txtOFW.Text
                dOFW_S = FormatDatePicker(.dtpOFW)
                Seaman_S = .txtSeaman.Text
                dSeaman_S = FormatDatePicker(.dtpSeaman)
                PNP_S = .txtPNP.Text
                dPNP_S = FormatDatePicker(.dtpPNP)
                AFP_S = .txtAFP.Text
                dAFP_S = FormatDatePicker(.dtpAFP)
                HDMF_S = .txtHDMF.Text
                dHDMF_S = FormatDatePicker(.dtpHDMF)
                PWD_S = .txtPWD.Text
                dPWD_S = FormatDatePicker(.dtpPWD)
                DSWD_S = .txtDSWD.Text
                dDSWD_S = FormatDatePicker(.dtpDSWD)
                ACR_S = .txtACR.Text
                dACR_S = FormatDatePicker(.dtpACR)
                DTI_Business_S = .txtDTI_Business.Text
                dDTI_Business_S = FormatDatePicker(.dtpDTI_Business)
                IBP_S = .txtIBP.Text
                dIBP_S = FormatDatePicker(.dtpIBP)
                FireArms_S = .txtFireArms.Text
                dFireArms_S = FormatDatePicker(.dtpFireArms)
                Government_S = .txtGovernment.Text
                dGovernment_S = FormatDatePicker(.dtpGovernment)
                Diplomat_S = .txtDiplomat.Text
                dDiplomat_S = FormatDatePicker(.dtpDiplomat)
                National_S = .txtNational.Text
                dNational_S = FormatDatePicker(.dtpNational)
                Work_S = .txtWork.Text
                dWork_S = FormatDatePicker(.dtpWork)
                GOCC_S = .txtGOCC.Text
                dGOCC_S = FormatDatePicker(.dtpGOCC)
                PLRA_S = .txtPLRA.Text
                dPLRA_S = FormatDatePicker(.dtpPLRA)
                Major_S = .txtMajor.Text
                dMajor_S = FormatDatePicker(.dtpMajor)
                Media_S = .txtMedia.Text
                dMedia_S = FormatDatePicker(.dtpMedia)
                Student_S = .txtStudent.Text
                dStudent_S = FormatDatePicker(.dtpStudent)
                SIRV_S = .txtSIRV.Text
                dSIRV_S = FormatDatePicker(.dtpSIRV)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxMarketingName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMarketingName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxMarketingName.SelectedIndex = -1 Or cbxMarketingName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxMarketingName.SelectedItem, DataRowView)
            txtMarketingContact.Text = drv("Phone")
        End If
    End Sub

    Private Sub CbxMarketingName_TextChanged(sender As Object, e As EventArgs) Handles cbxMarketingName.TextChanged
        If cbxMarketingName.Text = "" Then
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxDealerName_TextChanged(sender As Object, e As EventArgs) Handles cbxDealerName.TextChanged
        If cbxDealerName.Text = "" Then
            txtDealersContact.Text = ""
        End If
    End Sub

    Private Sub CbxYearHired_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYearHired.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxYearHired.Checked Then
            dtpHired_B.CustomFormat = "yyyy"
        Else
            dtpHired_B.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxYearFranchise_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYearFranchise.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxYearFranchise.Checked Then
            dtpExpiry_B.CustomFormat = "yyyy"
        Else
            dtpExpiry_B.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnDefault_S_Click(sender As Object, e As EventArgs) Handles btnDefault_S.Click
        txtPath_S.Text = " "
        ResizeImages(DefaultImage.Image.Clone, pb_S, 650, 500)
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        txtPath_B.Text = " "
        ResizeImages(DefaultImage.Image.Clone, pb_B, 650, 500)
    End Sub

    Private Sub CbxYearHired_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYearHired_S.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxYearHired_S.Checked Then
            dtpHired_S.CustomFormat = "yyyy"
        Else
            dtpHired_S.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpBirth_B_Leave(sender As Object, e As EventArgs) Handles DtpBirth_B.Leave
        Check_HIT()
    End Sub

    Private Sub BtnHit_Click(sender As Object, e As EventArgs) Handles btnHit.Click
        Dim Hit As New FrmHitNameList
        With Hit
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class