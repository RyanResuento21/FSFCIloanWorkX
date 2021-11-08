Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmCoMaker

    '**************CoBorrower1 Info
    Dim vRent_C1 As Double
    Public CINumber As String
    Dim vEmpAddress_C1 As String
    Dim vEmpTelephone_C1 As String
    Dim vPosition_C1 As String
    Dim vCasual_C1 As Boolean
    Dim vTemporary_C1 As Boolean
    Dim vPermanent_C1 As Boolean
    Dim vSupervisor_C1 As String
    Dim vSalary_C1 As Double
    Public AmountApplied As Double

    Dim vBusinessAddress_C1 As String
    Dim vBusinessTelephone_C1 As String
    Dim vNatureBusiness_C1 As String
    Dim vYrsOperation_C1 As Integer
    Dim vBusinessIncome_C1 As Double
    Dim vNoEmployees_C1 As Integer
    Dim vCapital_C1 As Double
    Dim vArea_C1 As String
    Dim vOutlet_C1 As Integer
    Dim vOtherIncome_C1 As String

    Dim vOtherIncomeD_C1 As Double
    '**************CoBorrower1 Info
    Public BorrowerID As String
    Public BorrowerName As String
    Public CreditNumber As String
    Public Rank As String
    Public LoanAmount As Double
    Public Borrower_Branch As String = Branch_Code
    Dim ChangeCoMaker1Pic As Boolean
    Public ChangeSketch As Boolean

    Dim FileName As String
    Dim FirstLoad As Boolean = True
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public CoMakerID_1 As String
    Public TotalImage As Integer
    Public FromCreditApplication As Boolean = True

    Dim TIN_C1 As String
    Dim SSS_C1 As String
    Dim GSIS_C1 As String
    Dim PhilHealth_C1 As String
    Dim Senior_C1 As String
    Dim UMID_C1 As String
    Dim SEC_C1 As String
    Dim DTI_C1 As String
    Dim CDA_C1 As String
    Dim Cooperative_C1 As String
    Dim Drivers_C1 As String
    Dim dDrivers_C1 As String
    Dim VIN_C1 As String
    Dim dVIN_C1 As String
    Dim Passport_C1 As String
    Dim dPassport_C1 As String
    Dim PRC_C1 As String
    Dim dPRC_C1 As String
    Dim NBI_C1 As String
    Dim dNBI_C1 As String
    Dim Police_C1 As String
    Dim dPolice_C1 As String
    Dim Postal_C1 As String
    Dim dPostal_C1 As String
    Dim Barangay_C1 As String
    Dim dBarangay_C1 As String
    Dim OWWA_C1 As String
    Dim dOWWA_C1 As String
    Dim OFW_C1 As String
    Dim dOFW_C1 As String
    Dim Seaman_C1 As String
    Dim dSeaman_C1 As String
    Dim PNP_C1 As String
    Dim dPNP_C1 As String
    Dim AFP_C1 As String
    Dim dAFP_C1 As String
    Dim HDMF_C1 As String
    Dim dHDMF_C1 As String
    Dim PWD_C1 As String
    Dim dPWD_C1 As String
    Dim DSWD_C1 As String
    Dim dDSWD_C1 As String
    Dim ACR_C1 As String
    Dim dACR_C1 As String
    Dim DTI_Business_C1 As String
    Dim dDTI_Business_C1 As String
    Dim IBP_C1 As String
    Dim dIBP_C1 As String
    Dim FireArms_C1 As String
    Dim dFireArms_C1 As String
    Dim Government_C1 As String
    Dim dGovernment_C1 As String
    Dim Diplomat_C1 As String
    Dim dDiplomat_C1 As String
    Dim National_C1 As String
    Dim dNational_C1 As String
    Dim Work_C1 As String
    Dim dWork_C1 As String
    Dim GOCC_C1 As String
    Dim dGOCC_C1 As String
    Dim PLRA_C1 As String
    Dim dPLRA_C1 As String
    Dim Major_C1 As String
    Dim dMajor_C1 As String
    Dim Media_C1 As String
    Dim dMedia_C1 As String
    Dim Student_C1 As String
    Dim dStudent_C1 As String
    Dim SIRV_C1 As String
    Dim dSIRV_C1 As String
    Dim ReferenceID As String
    Private Sub FrmCoMaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_C1.Size = New Point(255, 254)
        pb_C1.Location = New Point(892, 6)

        pbSketch.Size = New Point(436, 264)
        pbSketch.Location = New Point(695, 244)
        cbxNatureBusiness_C12.Size = New Point(182, 24)
        cbxNatureBusiness_C12.Location = New Point(142, 125)
        FirstLoad = True

        If TxtFirstN_C1.Text = "" Then
            DefaultImage.Image = pb_C1.Image.Clone
            DtpBirth_C1.Value = Date.Now
            dtpHired_C1.Value = Date.Now
            dtpHired_C1.CustomFormat = ""
            dtpExpiry_C1.Value = Date.Now
            dtpExpiry_C1.CustomFormat = ""
            btnID.Enabled = False

            dtpCreditGranted_1.Value = Date.Now
            dtpCreditGranted_2.Value = Date.Now
            dtpDateFilled.Value = Date.Now
            dtpYear_1.Value = Date.Now
            dtpYear_2.Value = Date.Now
        Else
            '*** I D E N T I F I C A T I O N ***
            Dim BorrowerID_C1 As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'C{1}'", BorrowerID, Rank))
            If BorrowerID_C1.Rows.Count > 0 Then
                TIN_C1 = BorrowerID_C1(0)("TIN")
                SSS_C1 = BorrowerID_C1(0)("SSS")
                GSIS_C1 = BorrowerID_C1(0)("GSIS")
                PhilHealth_C1 = BorrowerID_C1(0)("PhilHealth")
                Senior_C1 = BorrowerID_C1(0)("Senior")
                UMID_C1 = BorrowerID_C1(0)("UMID")
                SEC_C1 = BorrowerID_C1(0)("SEC")
                DTI_C1 = BorrowerID_C1(0)("DTI")
                CDA_C1 = BorrowerID_C1(0)("CDA")
                Cooperative_C1 = BorrowerID_C1(0)("Cooperative")
                Drivers_C1 = BorrowerID_C1(0)("Drivers")
                dDrivers_C1 = BorrowerID_C1(0)("dDrivers")
                VIN_C1 = BorrowerID_C1(0)("VIN")
                dVIN_C1 = BorrowerID_C1(0)("dVIN")
                Passport_C1 = BorrowerID_C1(0)("Passport")
                dPassport_C1 = BorrowerID_C1(0)("dPassport")
                PRC_C1 = BorrowerID_C1(0)("PRC")
                dPRC_C1 = BorrowerID_C1(0)("dPRC")
                NBI_C1 = BorrowerID_C1(0)("NBI")
                dNBI_C1 = BorrowerID_C1(0)("dNBI")
                Police_C1 = BorrowerID_C1(0)("Police")
                dPolice_C1 = BorrowerID_C1(0)("dPolice")
                Postal_C1 = BorrowerID_C1(0)("Postal")
                dPostal_C1 = BorrowerID_C1(0)("dPostal")
                Barangay_C1 = BorrowerID_C1(0)("Barangay")
                dBarangay_C1 = BorrowerID_C1(0)("dBarangay")
                OWWA_C1 = BorrowerID_C1(0)("OWWA")
                dOWWA_C1 = BorrowerID_C1(0)("dOWWA")
                OFW_C1 = BorrowerID_C1(0)("OFW")
                dOFW_C1 = BorrowerID_C1(0)("dOFW")
                Seaman_C1 = BorrowerID_C1(0)("Seaman")
                dSeaman_C1 = BorrowerID_C1(0)("dSeaman")
                PNP_C1 = BorrowerID_C1(0)("PNP")
                dPNP_C1 = BorrowerID_C1(0)("dPNP")
                AFP_C1 = BorrowerID_C1(0)("AFP")
                dAFP_C1 = BorrowerID_C1(0)("dAFP")
                HDMF_C1 = BorrowerID_C1(0)("HDMF")
                dHDMF_C1 = BorrowerID_C1(0)("dHDMF")
                PWD_C1 = BorrowerID_C1(0)("PWD")
                dPWD_C1 = BorrowerID_C1(0)("dPWD")
                DSWD_C1 = BorrowerID_C1(0)("DSWD")
                dDSWD_C1 = BorrowerID_C1(0)("dDSWD")
                ACR_C1 = BorrowerID_C1(0)("ACR")
                dACR_C1 = BorrowerID_C1(0)("dACR")
                DTI_Business_C1 = BorrowerID_C1(0)("DTI_Business")
                dDTI_Business_C1 = BorrowerID_C1(0)("dDTI_Business")
                IBP_C1 = BorrowerID_C1(0)("IBP")
                dIBP_C1 = BorrowerID_C1(0)("dIBP")
                FireArms_C1 = BorrowerID_C1(0)("FireArms")
                dFireArms_C1 = BorrowerID_C1(0)("dFireArms")
                Government_C1 = BorrowerID_C1(0)("Government")
                dGovernment_C1 = BorrowerID_C1(0)("dGovernment")
                Diplomat_C1 = BorrowerID_C1(0)("Diplomat")
                dDiplomat_C1 = BorrowerID_C1(0)("dDiplomat")
                National_C1 = BorrowerID_C1(0)("National")
                dNational_C1 = BorrowerID_C1(0)("dNational")
                Work_C1 = BorrowerID_C1(0)("Work")
                dWork_C1 = BorrowerID_C1(0)("dWork")
                GOCC_C1 = BorrowerID_C1(0)("GOCC")
                dGOCC_C1 = BorrowerID_C1(0)("dGOCC")
                PLRA_C1 = BorrowerID_C1(0)("PLRA")
                dPLRA_C1 = BorrowerID_C1(0)("dPLRA")
                Major_C1 = BorrowerID_C1(0)("Major")
                dMajor_C1 = BorrowerID_C1(0)("dMajor")
                Media_C1 = BorrowerID_C1(0)("Media")
                dMedia_C1 = BorrowerID_C1(0)("dMedia")
                Student_C1 = BorrowerID_C1(0)("Student")
                dStudent_C1 = BorrowerID_C1(0)("dStudent")
                SIRV_C1 = BorrowerID_C1(0)("SIRV")
                dSIRV_C1 = BorrowerID_C1(0)("dSIRV")
            End If
        End If

        'Co-Maker I
        With CbxPrefix_C1
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
        End With

        With cbxSuffix_C1
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
        End With

        With cbxAddressC_C1
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxAddressP_C1
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxPlaceBirth_C1
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxRelationship_C1
            .ValueMember = "ID"
            .DisplayMember = "Relation"
            .DataSource = Relation.Copy
        End With

        With cbxPosition_C1
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
        End With

        With cbxEmployer_C1
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
        End With

        With cbxNatureBusiness_C12
            .Properties.LookAndFeel.SkinName = "Blue"
            For x As Integer = 0 To DT_Industry.Rows.Count - 1
                .Properties.Items.Add(DT_Industry(x)("ID"), DT_Industry(x)("Nature"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
        End With
        If TxtFirstN_C1.Text = "" Then
            CbxPrefix_C1.SelectedIndex = -1
            cbxSuffix_C1.SelectedIndex = -1
            cbxAddressC_C1.SelectedIndex = -1
            cbxAddressP_C1.SelectedIndex = -1
            cbxPlaceBirth_C1.SelectedIndex = -1
            cbxRelationship_C1.SelectedIndex = -1
            cbxPosition_C1.SelectedIndex = -1
            cbxEmployer_C1.SelectedIndex = -1
        Else
            If FromCreditApplication Then
                With FrmLoanApplication
                    If Rank = 1 Then
                        CbxPrefix_C1.Text = .vPrefix_C1
                        cbxSuffix_C1.Text = .vSuffix_C1
                        cbxAddressC_C1.Text = .vAddressC_C1
                        cbxAddressP_C1.Text = .vAddressP_C1
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C1
                        cbxRelationship_C1.Text = .vRelationship_C1
                        cbxEmployer_C1.Text = .vEmployer_C1
                        cbxPosition_C1.Text = .vPosition_C1
                    ElseIf Rank = 2 Then
                        CbxPrefix_C1.Text = .vPrefix_C2
                        cbxSuffix_C1.Text = .vSuffix_C2
                        cbxAddressC_C1.Text = .vAddressC_C2
                        cbxAddressP_C1.Text = .vAddressP_C2
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C2
                        cbxRelationship_C1.Text = .vRelationship_C2
                        cbxEmployer_C1.Text = .vEmployer_C2
                        cbxPosition_C1.Text = .vPosition_C2
                    ElseIf Rank = 3 Then
                        CbxPrefix_C1.Text = .vPrefix_C3
                        cbxSuffix_C1.Text = .vSuffix_C3
                        cbxAddressC_C1.Text = .vAddressC_C3
                        cbxAddressP_C1.Text = .vAddressP_C3
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C3
                        cbxRelationship_C1.Text = .vRelationship_C3
                        cbxEmployer_C1.Text = .vEmployer_C3
                        cbxPosition_C1.Text = .vPosition_C3
                    ElseIf Rank = 4 Then
                        CbxPrefix_C1.Text = .vPrefix_C4
                        cbxSuffix_C1.Text = .vSuffix_C4
                        cbxAddressC_C1.Text = .vAddressC_C4
                        cbxAddressP_C1.Text = .vAddressP_C4
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C4
                        cbxRelationship_C1.Text = .vRelationship_C4
                        cbxEmployer_C1.Text = .vEmployer_C4
                        cbxPosition_C1.Text = .vPosition_C4
                    End If
                End With
            Else
                With FrmCreditInvestigation
                    If Rank = 1 Then
                        CbxPrefix_C1.Text = .vPrefix_C1
                        cbxSuffix_C1.Text = .vSuffix_C1
                        cbxAddressC_C1.Text = .vAddressC_C1
                        cbxAddressP_C1.Text = .vAddressP_C1
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C1
                        cbxRelationship_C1.Text = .vRelationship_C1
                        cbxEmployer_C1.Text = .vEmployer_C1
                        cbxPosition_C1.Text = .vPosition_C1
                    ElseIf Rank = 2 Then
                        CbxPrefix_C1.Text = .vPrefix_C2
                        cbxSuffix_C1.Text = .vSuffix_C2
                        cbxAddressC_C1.Text = .vAddressC_C2
                        cbxAddressP_C1.Text = .vAddressP_C2
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C2
                        cbxRelationship_C1.Text = .vRelationship_C2
                        cbxEmployer_C1.Text = .vEmployer_C2
                        cbxPosition_C1.Text = .vPosition_C2
                    ElseIf Rank = 3 Then
                        CbxPrefix_C1.Text = .vPrefix_C3
                        cbxSuffix_C1.Text = .vSuffix_C3
                        cbxAddressC_C1.Text = .vAddressC_C3
                        cbxAddressP_C1.Text = .vAddressP_C3
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C3
                        cbxRelationship_C1.Text = .vRelationship_C3
                        cbxEmployer_C1.Text = .vEmployer_C3
                        cbxPosition_C1.Text = .vPosition_C3
                    ElseIf Rank = 4 Then
                        CbxPrefix_C1.Text = .vPrefix_C4
                        cbxSuffix_C1.Text = .vSuffix_C4
                        cbxAddressC_C1.Text = .vAddressC_C4
                        cbxAddressP_C1.Text = .vAddressP_C4
                        cbxPlaceBirth_C1.Text = .vPlaceBirth_C4
                        cbxRelationship_C1.Text = .vRelationship_C4
                        cbxEmployer_C1.Text = .vEmployer_C4
                        cbxPosition_C1.Text = .vPosition_C4
                    End If
                End With
            End If
            cbxNatureBusiness_C12.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM credit_application_industry WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}' AND `Type` = 'CoMaker{1}'", CreditNumber, Rank)))
        End If
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

            GetLabelFontSettings({LabelX73, LabelX72, LabelX71, LabelX68, LabelX67, LabelX64, LabelX66, LabelX65, LabelX63, LabelX70, LabelX62, LabelX69, LabelX61, LabelX60, LabelX191, LabelX59, LabelX127, LabelX131, LabelX133, LabelX123, LabelX122, LabelX120, LabelX117, LabelX114, LabelX128, LabelX132, LabelX130, LabelX124, LabelX121, LabelX119, LabelX116, LabelX113, LabelX129, LabelX126, LabelX125, LabelX118, LabelX115, LabelX108, LabelX80, LabelX84, LabelX87, LabelX81, LabelX85, LabelX82, LabelX79, LabelX107, LabelX137, LabelX138, LabelX146, LabelX139, LabelX140, LabelX145, LabelX141, LabelX143, LabelX144, LabelX200, LabelX177, LabelX198, LabelX196, LabelX194, LabelX192, LabelX189, LabelX187, LabelX185, LabelX183, LabelX181, LabelX179, LabelX3, LabelX199, LabelX197, LabelX195, LabelX193, LabelX190, LabelX188, LabelX186, LabelX184, LabelX182, LabelX180, LabelX178, LabelX171, LabelX170, LabelX169})

            GetLabelFontSettings({LabelX201, LabelX172, LabelX164, LabelX112, LabelX110, LabelX109, LabelX136, LabelX96, LabelX95, LabelX91, LabelX89, LabelX76})

            GetLabelWithBackgroundFontSettings({LabelX42, LabelX90, LabelX104, LabelX103, LabelX102, LabelX101, LabelX100, LabelX99, LabelX98, LabelX97, LabelX75, LabelX94, LabelX93, LabelX92, LabelX168, LabelX165, LabelX167, LabelX166, LabelX163, LabelX161, LabelX111, LabelX162})

            GetTextBoxFontSettings({TxtFirstN_C1, TxtMiddleN_C1, TxtLastN_C1, txtNoC_C1, txtStreetC_C1, txtBarangayC_C1, txtNoP_C1, txtStreetP_C1, txtBarangayP_C1, txtCitizenship_C1, txtTelephone_C1, txtPlus63, txtMobile_C1, txtTIN_C1, txtSSS_C1, txtEmail_C1, txtPath_C1, txtEmployerAddress_C1, txtEmployerTelephone_C1, txtBusinessName_C1, txtArea_C1, txtOtherIncome_C1, txtSupervisor_C1, txtBusinessAddress_C1, txtBusinessTelephone_C1, txtCreditor_1, txtCreditor_2, txtCreditAddress_1, txtCreditAddress_2, txtCreditRemarks_1, txtCreditRemarks_2, txtBank_1, txtBank_2, txtBranch_1, txtBranch_2, txtSA_1, txtSA_2, txtOpened_1, txtOpened_2, txtTitle, txtCaseNum, txtFindings, txtCACPI, txtLocation_1, txtLocation_2, txtTCT_1, txtTCT_2, txtPropertiesRemarks_1, txtPropertiesRemarks_2, txtVehicle_1, txtVehicle_2, txtWhomAcquired_1, txtWhomAcquired_2, txtVehicleRemarks_1, txtVehicleRemarks_2, txtOtherProperties, txtC1, txtC2, txtC3, txtC4, txtC5, txtC6, txtC7, txtC8, txtC9})

            GetButtonFontSettings({btnID, btnExisting_C1, btnBrowse_C1, btnDefault, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnPrintCIR, btnAttach, btnAttachSketch})

            GetRickTextBoxFontSettings({rRecommendation, rNarrative, rPurposeLoan, rOthers, txtExpenseRemarks})

            GetComboBoxFontSettings({CbxPrefix_C1, cbxSuffix_C1, cbxAddressC_C1, cbxAddressP_C1, cbxPlaceBirth_C1, cbxRelationship_C1, cbxEmployer_C1, cbxPosition_C1, cbxNatureBusiness_C1, cbxCourt, cbxCaseNature, cbxCaseStatus})

            GetCheckBoxFontSettings({cbxSingle_C1, cbxMarried_C1, cbxSeparated_C1, cbxWidowed_C1, cbxMale_C1, cbxFemale_C1, cbxOwned_C1, cbxFree_C1, cbxRented_C1, cbxYearHired_C1, cbxCasual_C1, cbxTemporary_C1, cbxPermanent_C1, cbxSA_1, cbxCA_1, cbxSA_2, cbxCA_2, cbxPositive, cbxNegative, cbxUnestablished})

            GetCheckComboBoxFontSettings({cbxNatureBusiness_C12})

            GetDateTimeInputFontSettings({DtpBirth_C1, dtpHired_C1, dtpExpiry_C1, dtpCreditGranted_1, dtpCreditGranted_2, dtpDateFilled, dtpYear_1, dtpYear_2})

            GetDoubleInputFontSettings({dRent_C1, dCapital_C1, dOtherIncome_C1, dMonthly_C1, dBusinessIncome_C1, dAmountGranted_1, dBalance_1, dCreditPayment_1, dAmountGranted_2, dBalance_2, dCreditPayment_2, dAverageBalance_1, dAverageBalance_2, dAmountInvolved, dArea_1, dArea_2, dTotalDisposable, dLiving, dClothing, dEducation, dTransportation, dLighths, dInsurance, dAmortization, dMiscellaneous, dTotalExpenses, dNetDisposable})

            GetIntegerInputFontSettings({iNoEmployees_C1, iYrsOperation_C1, iOutlet_C1, iTerm_1, iTerm_2})

            GetTabControlFontSettings({SuperTabControl1, SuperTabControl2})
        Catch ex As Exception
            TriggerBugReport("CoMaker - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("CoMaker", lblTitle.Text)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        For x As Integer = 0 To cbxNatureBusiness_C12.Properties.Items.Count - 1
            cbxNatureBusiness_C12.Properties.Items.Item(x).CheckState = CheckState.Unchecked
        Next

        'CoMaker 1
        cbxRelationship_C1.Text = ""
        CbxPrefix_C1.Text = ""
        TxtFirstN_C1.Text = ""
        TxtMiddleN_C1.Text = ""
        TxtLastN_C1.Text = ""
        cbxSuffix_C1.Text = ""
        txtNoC_C1.Text = ""
        txtStreetC_C1.Text = ""
        txtBarangayC_C1.Text = ""
        cbxAddressC_C1.Text = ""
        txtNoP_C1.Text = ""
        txtStreetP_C1.Text = ""
        txtBarangayP_C1.Text = ""
        cbxAddressP_C1.Text = ""
        DtpBirth_C1.CustomFormat = ""
        cbxPlaceBirth_C1.Text = ""
        cbxMale_C1.Checked = False
        cbxFemale_C1.Checked = False
        cbxSingle_C1.Checked = False
        cbxMarried_C1.Checked = False
        cbxSeparated_C1.Checked = False
        cbxWidowed_C1.Checked = False
        txtCitizenship_C1.Text = ""
        txtTIN_C1.Text = ""
        txtTelephone_C1.Text = ""
        txtSSS_C1.Text = ""
        txtMobile_C1.Text = ""
        txtEmail_C1.Text = ""
        cbxOwned_C1.Checked = False
        cbxFree_C1.Checked = False
        cbxRented_C1.Checked = False
        Try
            pb_C1.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_C1.Image = Nothing
        End Try
        cbxEmployer_C1.Text = ""
        txtBusinessName_C1.Text = ""
        ChangeCoMaker1Pic = False

        txtCreditor_1.Text = ""
        txtBank_1.Text = ""
        txtLocation_1.Text = ""
        txtVehicle_1.Text = ""
        txtOtherProperties.Text = ""
        rNarrative.Text = ""

        cbxGood.Checked = False
        cbxFair.Checked = False
        cbxPoor.Checked = False

        rRecommendation.Text = ""
        txtC1.Text = ""
        txtTitle.Text = ""

        dTotalDisposable.Value = 0
        dLiving.Value = 0
        dClothing.Value = 0
        dEducation.Value = 0
        dTransportation.Value = 0
        dLighths.Value = 0
        dInsurance.Value = 0
        dAmortization.Value = 0
        dMiscellaneous.Value = 0
        dTotalExpenses.Value = 0
        dNetDisposable.Value = 0
        dTMFI.Value = 0
        dTMDI.Value = 0

        rPurposeLoan.Text = ""
        rOthers.Text = ""
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    '***COBORROWER 1
    Private Sub CbxEmployer_C1_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployer_C1.TextChanged
        If cbxEmployer_C1.Text.Trim = "" Then
            txtEmployerAddress_C1.Enabled = False
            txtEmployerTelephone_C1.Enabled = False
            cbxPosition_C1.Enabled = False
            cbxCasual_C1.Enabled = False
            cbxTemporary_C1.Enabled = False
            cbxPermanent_C1.Enabled = False
            dtpHired_C1.Enabled = False
            dtpHired_C1.CustomFormat = ""
            txtSupervisor_C1.Enabled = False
            dMonthly_C1.Enabled = False
            cbxYearHired_C1.Enabled = False
            cbxYearHired_C1.Checked = False

            vEmpAddress_C1 = txtEmployerAddress_C1.Text
            vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
            vPosition_C1 = cbxPosition_C1.Text
            vCasual_C1 = cbxCasual_C1.Checked
            vTemporary_C1 = cbxTemporary_C1.Checked
            vPermanent_C1 = cbxPermanent_C1.Checked
            vSupervisor_C1 = txtSupervisor_C1.Text
            vSalary_C1 = dMonthly_C1.Value

            txtEmployerAddress_C1.Text = ""
            txtEmployerTelephone_C1.Text = ""
            cbxPosition_C1.Text = ""
            cbxCasual_C1.Checked = False
            cbxTemporary_C1.Checked = False
            cbxPermanent_C1.Checked = False
            txtSupervisor_C1.Text = ""
            dMonthly_C1.Value = 0
        Else
            txtEmployerAddress_C1.Enabled = True
            txtEmployerTelephone_C1.Enabled = True
            cbxPosition_C1.Enabled = True
            cbxCasual_C1.Enabled = True
            cbxTemporary_C1.Enabled = True
            cbxPermanent_C1.Enabled = True
            dtpHired_C1.Enabled = True
            If cbxYearHired_C1.Checked Then
                dtpHired_C1.CustomFormat = "yyyy"
            Else
                dtpHired_C1.CustomFormat = "MMMM dd, yyyy"
            End If
            txtSupervisor_C1.Enabled = True
            dMonthly_C1.Enabled = True
            cbxYearHired_C1.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vEmpAddress_C1 = "" And vEmpTelephone_C1 = "" And vPosition_C1 = "" And vSupervisor_C1 = "" And vSalary_C1 = 0 Then
            Else
                If txtEmployerAddress_C1.Text = "" Then
                    txtEmployerAddress_C1.Text = vEmpAddress_C1
                End If
                If txtEmployerTelephone_C1.Text = "" Then
                    txtEmployerTelephone_C1.Text = vEmpTelephone_C1
                End If
                If cbxPosition_C1.Text = "" Then
                    cbxPosition_C1.Text = vPosition_C1
                End If
                If cbxCasual_C1.Checked = False Then
                    cbxCasual_C1.Checked = vCasual_C1
                End If
                If cbxTemporary_C1.Checked = False Then
                    cbxTemporary_C1.Checked = vTemporary_C1
                End If
                If cbxPermanent_C1.Checked = False Then
                    cbxPermanent_C1.Checked = vPermanent_C1
                End If
                If txtSupervisor_C1.Text = "" Then
                    txtSupervisor_C1.Text = vSupervisor_C1
                End If
                If dMonthly_C1.Value = 0 Then
                    dMonthly_C1.Value = vSalary_C1
                End If
            End If
        End If
    End Sub

    Private Sub TxtBusinessName_C1_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessName_C1.TextChanged
        If txtBusinessName_C1.Text.Trim = "" Then
            txtBusinessAddress_C1.Enabled = False
            txtBusinessTelephone_C1.Enabled = False
            cbxNatureBusiness_C1.Enabled = False
            cbxNatureBusiness_C12.Enabled = False
            iYrsOperation_C1.Enabled = False
            dBusinessIncome_C1.Enabled = False
            iNoEmployees_C1.Enabled = False
            dCapital_C1.Enabled = False
            txtArea_C1.Enabled = False
            dtpExpiry_C1.Enabled = False
            dtpExpiry_C1.CustomFormat = ""
            iOutlet_C1.Enabled = False
            txtOtherIncome_C1.Enabled = False

            vBusinessAddress_C1 = txtBusinessAddress_C1.Text
            vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
            vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
            vYrsOperation_C1 = iYrsOperation_C1.Value
            vBusinessIncome_C1 = dBusinessIncome_C1.Value
            vNoEmployees_C1 = iNoEmployees_C1.Value
            vCapital_C1 = dCapital_C1.Value
            vArea_C1 = txtArea_C1.Text
            vOutlet_C1 = iOutlet_C1.Value
            vOtherIncome_C1 = txtOtherIncome_C1.Text

            txtBusinessAddress_C1.Text = ""
            txtBusinessTelephone_C1.Text = ""
            cbxNatureBusiness_C1.Text = ""
            iYrsOperation_C1.Value = 0
            dBusinessIncome_C1.Value = 0
            iNoEmployees_C1.Value = 0
            dCapital_C1.Value = 0
            txtArea_C1.Text = ""
            iOutlet_C1.Value = 0
            txtOtherIncome_C1.Text = ""
        Else
            txtBusinessAddress_C1.Enabled = True
            txtBusinessTelephone_C1.Enabled = True
            cbxNatureBusiness_C1.Enabled = True
            cbxNatureBusiness_C12.Enabled = True
            iYrsOperation_C1.Enabled = True
            dBusinessIncome_C1.Enabled = True
            iNoEmployees_C1.Enabled = True
            dCapital_C1.Enabled = True
            txtArea_C1.Enabled = True
            dtpExpiry_C1.Enabled = True
            dtpExpiry_C1.CustomFormat = "MMMM dd, yyyy"
            iOutlet_C1.Enabled = True
            txtOtherIncome_C1.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBusinessAddress_C1 = "" And vBusinessTelephone_C1 = "" And vNatureBusiness_C1 = "" And vYrsOperation_C1 = 0 And vBusinessIncome_C1 = 0 And vNoEmployees_C1 = 0 And vCapital_C1 = 0 And vArea_C1 = "" And vOutlet_C1 = 0 And vOtherIncome_C1 = "" Then
            Else
                If txtBusinessAddress_C1.Text = "" Then
                    txtBusinessAddress_C1.Text = vBusinessAddress_C1
                End If
                If txtBusinessTelephone_C1.Text = "" Then
                    txtBusinessTelephone_C1.Text = vBusinessTelephone_C1
                End If
                If cbxNatureBusiness_C1.Text = "" Then
                    cbxNatureBusiness_C1.Text = vNatureBusiness_C1
                End If
                If iYrsOperation_C1.Value = 0 Then
                    iYrsOperation_C1.Value = vYrsOperation_C1
                End If
                If dBusinessIncome_C1.Value = 0 Then
                    dBusinessIncome_C1.Value = vBusinessIncome_C1
                End If
                If iNoEmployees_C1.Value = 0 Then
                    iNoEmployees_C1.Value = vNoEmployees_C1
                End If
                If dCapital_C1.Value = 0 Then
                    dCapital_C1.Value = vCapital_C1
                End If
                If txtArea_C1.Text = "" Then
                    txtArea_C1.Text = vArea_C1
                End If
                If iOutlet_C1.Value = 0 Then
                    iOutlet_C1.Value = vOutlet_C1
                End If
                If txtOtherIncome_C1.Text = "" Then
                    txtOtherIncome_C1.Text = vOtherIncome_C1
                End If
            End If
        End If
    End Sub

    Private Sub TxtOtherIncome_C1_TextChanged(sender As Object, e As EventArgs) Handles txtOtherIncome_C1.TextChanged
        If txtOtherIncome_C1.Text.Trim = "" Then
            dOtherIncome_C1.Enabled = False

            vOtherIncomeD_C1 = dOtherIncome_C1.Value

            dOtherIncome_C1.Value = 0
        Else
            dOtherIncome_C1.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vOtherIncomeD_C1 = 0 Then
            Else
                If dOtherIncome_C1.Value = 0 Then
                    dOtherIncome_C1.Value = vOtherIncomeD_C1
                End If
            End If
        End If
    End Sub

    Private Sub BtnExisting_C1_Click(sender As Object, e As EventArgs) Handles btnExisting_C1.Click
        Dim Existing As New FrmBorrowerExisting
        With Existing
            .From_CoMaker = True
            .Type = "CoMaker1"
            .BorrowerID = BorrowerID
            Dim CoMaker As DataTable
            If .ShowDialog = DialogResult.OK Then
                CoMaker = .CoMaker
                ReferenceID = CoMaker(0)("ReferenceID")
                CbxPrefix_C1.Text = CoMaker(0)("Prefix")
                TxtFirstN_C1.Text = CoMaker(0)("FirstN")
                TxtMiddleN_C1.Text = CoMaker(0)("MiddleN")
                TxtLastN_C1.Text = CoMaker(0)("LastN")
                cbxSuffix_C1.Text = CoMaker(0)("Suffix")
                txtNoC_C1.Text = CoMaker(0)("NoC")
                txtStreetC_C1.Text = CoMaker(0)("StreetC")
                txtBarangayC_C1.Text = CoMaker(0)("BarangayC")
                cbxAddressC_C1.Text = CoMaker(0)("AddressC")
                txtNoP_C1.Text = CoMaker(0)("NoP")
                txtStreetP_C1.Text = CoMaker(0)("StreetP")
                txtBarangayP_C1.Text = CoMaker(0)("BarangayP")
                cbxAddressP_C1.Text = CoMaker(0)("AddressP")
                DtpBirth_C1.Text = CoMaker(0)("Birth")
                cbxPlaceBirth_C1.Text = CoMaker(0)("PlaceBirth")
                If CoMaker(0)("Gender") = "Male" Then
                    cbxMale_C1.Checked = True
                ElseIf CoMaker(0)("Gender") = "Female" Then
                    cbxFemale_C1.Checked = True
                End If
                If CoMaker(0)("Civil") = "Single" Then
                    cbxSingle_C1.Checked = True
                ElseIf CoMaker(0)("Civil") = "Married" Then
                    cbxMarried_C1.Checked = True
                ElseIf CoMaker(0)("Civil") = "Separated" Then
                    cbxSeparated_C1.Checked = True
                ElseIf CoMaker(0)("Civil") = "Widowed" Then
                    cbxWidowed_C1.Checked = True
                End If
                txtCitizenship_C1.Text = CoMaker(0)("Citizenship")
                txtTIN_C1.Text = CoMaker(0)("TIN")
                txtTelephone_C1.Text = CoMaker(0)("Telephone")
                txtSSS_C1.Text = CoMaker(0)("SSS")
                txtMobile_C1.Text = CoMaker(0)("Mobile")
                txtEmail_C1.Text = CoMaker(0)("Email")
                If CoMaker(0)("House") = "Owned" Then
                    cbxOwned_C1.Checked = True
                ElseIf CoMaker(0)("House") = "Free" Then
                    cbxFree_C1.Checked = True
                ElseIf CoMaker(0)("House") = "Rented" Then
                    cbxRented_C1.Checked = True
                    dRent_C1.Value = CoMaker(0)("Rent")
                End If
                Try
                    Dim CM_Rank As String
                    Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                    If .B_Type = "Borrower" Then
                        TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, CoMaker(0)("branch_code"), CoMaker(0)("BorrowerID"), "Borrower.jpg"))
                    Else
                        CM_Rank = DataObject(String.Format("SELECT Rank FROM credit_application_comaker WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE';", CoMaker(0)("BorrowerID")))
                        If CM_Rank = 1 Then
                            TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, CoMaker(0)("branch_code"), CoMaker(0)("BorrowerID"), "CoMaker1.jpg"))
                        Else
                            TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, CoMaker(0)("branch_code"), CoMaker(0)("BorrowerID"), "CoMaker2.jpg"))
                        End If
                    End If
                    ResizeImages(TempPB.Image.Clone, pb_C1, 650, 500)
                    txtPath_C1.Text = "CoMaker1.pjg"
                    ChangeCoMaker1Pic = True
                    TempPB.Dispose()
                Catch ex As Exception
                    pb_C1.Image = DefaultImage.Image.Clone
                    txtPath_C1.Text = ""
                    ChangeCoMaker1Pic = False
                End Try
                cbxEmployer_C1.Text = CoMaker(0)("Employer")
                txtEmployerAddress_C1.Text = CoMaker(0)("EmployerAddress")
                txtEmployerTelephone_C1.Text = CoMaker(0)("EmployerTelephone")
                cbxPosition_C1.Text = CoMaker(0)("Position")
                If CoMaker(0)("EmploymentStat") = "Casual" Then
                    cbxCasual_C1.Checked = True
                ElseIf CoMaker(0)("EmploymentStat") = "Temporary" Then
                    cbxTemporary_C1.Checked = True
                ElseIf CoMaker(0)("EmploymentStat") = "Permanent" Then
                    cbxPermanent_C1.Checked = True
                End If
                dtpHired_C1.Text = CoMaker(0)("Hired")
                txtSupervisor_C1.Text = CoMaker(0)("Supervisor")
                dMonthly_C1.Value = CoMaker(0)("Monthly")
                txtBusinessName_C1.Text = CoMaker(0)("BusinessName")
                txtBusinessAddress_C1.Text = CoMaker(0)("BusinessAddress")
                txtBusinessTelephone_C1.Text = CoMaker(0)("BusinessTelephone")
                cbxNatureBusiness_C1.Text = CoMaker(0)("NatureBusiness")
                iYrsOperation_C1.Value = CoMaker(0)("YrsOperation")
                dBusinessIncome_C1.Value = CoMaker(0)("BusinessIncome")
                iNoEmployees_C1.Value = CoMaker(0)("NoEmployees")
                dCapital_C1.Value = CoMaker(0)("Capital")
                txtArea_C1.Text = CoMaker(0)("Area")
                dtpExpiry_C1.Text = CoMaker(0)("Expiry")
                iOutlet_C1.Value = CoMaker(0)("Outlet")
                txtOtherIncome_C1.Text = CoMaker(0)("OtherIncome")
                dOtherIncome_C1.Value = CoMaker(0)("OtherIncome-Amount")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxPlaceBirth_C1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlaceBirth_C1.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPlaceBirth_C1.SelectedItem, DataRowView)
        txtCitizenship_C1.Text = DataObject(String.Format("SELECT nationality FROM country WHERE ID = '{0}'", drv("Country ID")))
    End Sub

    'Co-Maker I
    Private Sub CbxPrefix_C1_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_C1.Leave
        CbxPrefix_C1.Text = ReplaceText(CbxPrefix_C1.Text.Trim)
    End Sub

    Private Sub TxtFirstN_C1_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_C1.Leave
        TxtFirstN_C1.Text = ReplaceText(TxtFirstN_C1.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_C1_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_C1.Leave
        TxtMiddleN_C1.Text = ReplaceText(TxtMiddleN_C1.Text.Trim)
    End Sub

    Private Sub TxtLastN_C1_Leave(sender As Object, e As EventArgs) Handles TxtLastN_C1.Leave
        TxtLastN_C1.Text = ReplaceText(TxtLastN_C1.Text.Trim)
    End Sub

    Private Sub CbxSuffix_C1_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_C1.Leave
        cbxSuffix_C1.Text = ReplaceText(cbxSuffix_C1.Text.Trim)
    End Sub

    Private Sub TxtNoC_C1_Leave(sender As Object, e As EventArgs) Handles txtNoC_C1.Leave
        txtNoC_C1.Text = ReplaceText(txtNoC_C1.Text.Trim)
    End Sub

    Private Sub TxtStreetC_C1_Leave(sender As Object, e As EventArgs) Handles txtStreetC_C1.Leave
        txtStreetC_C1.Text = ReplaceText(txtStreetC_C1.Text.Trim)
    End Sub

    Private Sub TxtBarangayC_C1_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_C1.Leave
        txtBarangayC_C1.Text = ReplaceText(txtBarangayC_C1.Text.Trim)
    End Sub

    Private Sub CbxAddressC_C1_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_C1.Leave
        cbxAddressC_C1.Text = ReplaceText(cbxAddressC_C1.Text.Trim)
    End Sub

    Private Sub TxtNoP_C1_Leave(sender As Object, e As EventArgs) Handles txtNoP_C1.Leave
        txtNoP_C1.Text = ReplaceText(txtNoP_C1.Text.Trim)
    End Sub

    Private Sub TxtStreetP_C1_Leave(sender As Object, e As EventArgs) Handles txtStreetP_C1.Leave
        txtStreetP_C1.Text = ReplaceText(txtStreetP_C1.Text.Trim)
    End Sub

    Private Sub TxtBarangayP_C1_Leave(sender As Object, e As EventArgs) Handles txtBarangayP_C1.Leave
        txtBarangayP_C1.Text = ReplaceText(txtBarangayP_C1.Text.Trim)
    End Sub

    Private Sub CbxAddressP_C1_Leave(sender As Object, e As EventArgs) Handles cbxAddressP_C1.Leave
        cbxAddressP_C1.Text = ReplaceText(cbxAddressP_C1.Text.Trim)
    End Sub

    Private Sub CbxPlaceBirth_C1_Leave(sender As Object, e As EventArgs) Handles cbxPlaceBirth_C1.Leave
        cbxPlaceBirth_C1.Text = ReplaceText(cbxPlaceBirth_C1.Text.Trim)
    End Sub

    Private Sub TxtCitizenship_C1_Leave(sender As Object, e As EventArgs) Handles txtCitizenship_C1.Leave
        txtCitizenship_C1.Text = ReplaceText(txtCitizenship_C1.Text.Trim)
    End Sub

    Private Sub TxtTIN_C1_Leave(sender As Object, e As EventArgs) Handles txtTIN_C1.Leave
        txtTIN_C1.Text = ReplaceText(txtTIN_C1.Text.Trim)
        If (txtTIN_C1.Text.Length <> 9 And txtTIN_C1.Text.Length > 0) Or (Not IsNumeric(txtTIN_C1.Text) And txtTIN_C1.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_C1.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_C1_Leave(sender As Object, e As EventArgs) Handles txtTelephone_C1.Leave
        txtTelephone_C1.Text = ReplaceText(txtTelephone_C1.Text.Trim)
    End Sub

    Private Sub TxtSSS_C1_Leave(sender As Object, e As EventArgs) Handles txtSSS_C1.Leave
        txtSSS_C1.Text = ReplaceText(txtSSS_C1.Text.Trim)
        If (txtSSS_C1.Text.Length <> 10 And txtSSS_C1.Text.Length > 0) Or (Not IsNumeric(txtSSS_C1.Text) And txtSSS_C1.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_C1.Focus()
        End If
    End Sub

    Private Sub TxtMobile_C1_Leave(sender As Object, e As EventArgs) Handles txtMobile_C1.Leave
        txtMobile_C1.Text = ReplaceText(txtMobile_C1.Text.Trim)
    End Sub

    Private Sub TxtEmail_C1_Leave(sender As Object, e As EventArgs) Handles txtEmail_C1.Leave
        txtEmail_C1.Text = ReplaceText(txtEmail_C1.Text.Trim)
    End Sub

    Private Sub CbxRelationship_C1_Leave(sender As Object, e As EventArgs) Handles cbxRelationship_C1.Leave
        cbxRelationship_C1.Text = ReplaceText(cbxRelationship_C1.Text.Trim)
    End Sub

    Private Sub CbxEmployer_C1_Leave(sender As Object, e As EventArgs) Handles cbxEmployer_C1.Leave
        cbxEmployer_C1.Text = ReplaceText(cbxEmployer_C1.Text.Trim)
    End Sub

    Private Sub TxtEmployerAddress_C1_Leave(sender As Object, e As EventArgs) Handles txtEmployerAddress_C1.Leave
        txtEmployerAddress_C1.Text = ReplaceText(txtEmployerAddress_C1.Text.Trim)
    End Sub

    Private Sub TxtEmployerTelephone_C1_Leave(sender As Object, e As EventArgs) Handles txtEmployerTelephone_C1.Leave
        txtEmployerTelephone_C1.Text = ReplaceText(txtEmployerTelephone_C1.Text.Trim)
    End Sub

    Private Sub CbxPosition_C1_Leave(sender As Object, e As EventArgs) Handles cbxPosition_C1.Leave
        cbxPosition_C1.Text = ReplaceText(cbxPosition_C1.Text.Trim)
    End Sub

    Private Sub TxtSupervisor_C1_Leave(sender As Object, e As EventArgs) Handles txtSupervisor_C1.Leave
        txtSupervisor_C1.Text = ReplaceText(txtSupervisor_C1.Text.Trim)
    End Sub

    Private Sub TxtBusinessName_C1_Leave(sender As Object, e As EventArgs) Handles txtBusinessName_C1.Leave
        txtBusinessName_C1.Text = ReplaceText(txtBusinessName_C1.Text.Trim)
    End Sub

    Private Sub TxtBusinessAddress_C1_Leave(sender As Object, e As EventArgs) Handles txtBusinessAddress_C1.Leave
        txtBusinessAddress_C1.Text = ReplaceText(txtBusinessAddress_C1.Text.Trim)
    End Sub

    Private Sub TxtBusinessTelephone_C1_Leave(sender As Object, e As EventArgs) Handles txtBusinessTelephone_C1.Leave
        txtBusinessTelephone_C1.Text = ReplaceText(txtBusinessTelephone_C1.Text.Trim)
    End Sub

    Private Sub CbxNatureBusiness_C1_Leave(sender As Object, e As EventArgs) Handles cbxNatureBusiness_C1.Leave
        cbxNatureBusiness_C1.Text = ReplaceText(cbxNatureBusiness_C1.Text.Trim)
    End Sub

    Private Sub TxtArea_C1_Leave(sender As Object, e As EventArgs) Handles txtArea_C1.Leave
        txtArea_C1.Text = ReplaceText(txtArea_C1.Text.Trim)
    End Sub

    Private Sub TxtOtherIncome_C1_Leave(sender As Object, e As EventArgs) Handles txtOtherIncome_C1.Leave
        txtOtherIncome_C1.Text = ReplaceText(txtOtherIncome_C1.Text.Trim)
    End Sub

    'Co-Maker 1
    Private Sub CbxPrefix_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_C1.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_C1.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_C1.Focus()
        End If
    End Sub

    Private Sub TxtLastN_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_C1.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_C1.Focus()
        End If
    End Sub

    Private Sub TxtNoC_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_C1.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_C1.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_C1.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoP_C1.Focus()
        End If
    End Sub

    Private Sub TxtNoP_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoP_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetP_C1.Focus()
        End If
    End Sub

    Private Sub TxtStreetP_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetP_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayP_C1.Focus()
        End If
    End Sub

    Private Sub TxtBarangayP_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayP_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressP_C1.Focus()
        End If
    End Sub

    Private Sub CbxAddressP_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressP_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_C1.Focus()
        End If
    End Sub

    Private Sub DtpBirth_C1_Click(sender As Object, e As EventArgs) Handles DtpBirth_C1.Click
        DtpBirth_C1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpBirth_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPlaceBirth_C1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_C1.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxPlaceBirth_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPlaceBirth_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMale_C1.Focus()
        End If
    End Sub

    Private Sub CbxMale_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMale_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFemale_C1.Focus()
        End If
    End Sub

    Private Sub CbxFemale_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFemale_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSingle_C1.Focus()
        End If
    End Sub

    Private Sub CbxSingle_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSingle_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarried_C1.Focus()
        End If
    End Sub

    Private Sub CbxMarried_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarried_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSeparated_C1.Focus()
        End If
    End Sub

    Private Sub CbxSeparated_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSeparated_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxWidowed_C1.Focus()
        End If
    End Sub

    Private Sub CbxWidowed_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWidowed_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCitizenship_C1.Focus()
        End If
    End Sub

    Private Sub TxtCitizenship_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCitizenship_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_C1.Focus()
        End If
    End Sub

    Private Sub TxtTIN_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone_C1.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_C1.Focus()
        End If
    End Sub

    Private Sub TxtSSS_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile_C1.Focus()
        End If
    End Sub

    Private Sub TxtMobile_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail_C1.Focus()
        End If
    End Sub

    Private Sub TxtEmail_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOwned_C1.Focus()
        End If
    End Sub

    Private Sub CbxOwned_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOwned_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFree_C1.Focus()
        End If
    End Sub

    Private Sub CbxFree_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFree_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRented_C1.Focus()
        End If
    End Sub

    Private Sub CbxRented_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRented_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRent_C1.Focus()
        End If
    End Sub

    Private Sub DRent_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dRent_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRelationship_C1.Focus()
        End If
    End Sub

    Private Sub CbxRelationship_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRelationship_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEmployer_C1.Focus()
        End If
    End Sub

    Private Sub CbxEmployer_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployer_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerAddress_C1.Focus()
        End If
    End Sub

    Private Sub TxtEmployerAddress_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerAddress_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerTelephone_C1.Focus()
        End If
    End Sub

    Private Sub TxtEmployerTelephone_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerTelephone_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPosition_C1.Focus()
        End If
    End Sub

    Private Sub CbxPosition_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCasual_C1.Focus()
        End If
    End Sub

    Private Sub CbxCasual_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCasual_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTemporary_C1.Focus()
        End If
    End Sub

    Private Sub CbxTemporary_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTemporary_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPermanent_C1.Focus()
        End If
    End Sub

    Private Sub CbxPermanent_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPermanent_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpHired_C1.Focus()
        End If
    End Sub

    Private Sub DtpHired_C1_Click(sender As Object, e As EventArgs) Handles dtpHired_C1.Click
        'dtpHired_C1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpHired_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHired_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSupervisor_C1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpHired_C1.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSupervisor_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupervisor_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMonthly_C1.Focus()
        End If
    End Sub

    Private Sub DMonthly_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dMonthly_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessName_C1.Focus()
        End If
    End Sub

    Private Sub TxtBusinessName_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessName_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessAddress_C1.Focus()
        End If
    End Sub

    Private Sub TxtBusinessAddress_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessAddress_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessTelephone_C1.Focus()
        End If
    End Sub

    Private Sub TxtBusinessTelephone_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessTelephone_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNatureBusiness_C1.Focus()
        End If
    End Sub

    Private Sub CbxNatureBusiness_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNatureBusiness_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            iYrsOperation_C1.Focus()
        End If
    End Sub

    Private Sub IYrsOperation_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles iYrsOperation_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBusinessIncome_C1.Focus()
        End If
    End Sub

    Private Sub DBusinessIncome_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dBusinessIncome_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            iNoEmployees_C1.Focus()
        End If
    End Sub

    Private Sub BtnNoEmployees_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles iNoEmployees_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCapital_C1.Focus()
        End If
    End Sub

    Private Sub DCapital_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dCapital_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtArea_C1.Focus()
        End If
    End Sub

    Private Sub TxtArea_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArea_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpExpiry_C1.Focus()
        End If
    End Sub

    Private Sub DtpExpiry_C1_Click(sender As Object, e As EventArgs) Handles dtpExpiry_C1.Click
        dtpExpiry_C1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpExpiry_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            iOutlet_C1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpExpiry_C1.CustomFormat = ""
        End If
    End Sub

    Private Sub IOutlet_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles iOutlet_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherIncome_C1.Focus()
        End If
    End Sub

    Private Sub TxtOtherIncome_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherIncome_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOtherIncome_C1.Focus()
        End If
    End Sub

    Private Sub DOtherIncome_C1_KeyDown(sender As Object, e As KeyEventArgs) Handles dOtherIncome_C1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnBrowse_C1_Click(sender As Object, e As EventArgs) Handles btnBrowse_C1.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_C1.Image.Dispose()
                    txtPath_C1.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath_C1.Text)
                        ResizeImages(TempPB.Image.Clone, pb_C1, 650, 500)
                    End Using

                    ChangeCoMaker1Pic = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_C1_Click(sender As Object, e As MouseEventArgs) Handles pb_C1.Click
        Using Camera As New FrmCamera
            With Camera
                If .ShowDialog = DialogResult.OK Then
                    pb_C1.Image = .pb_Picture.Image.Clone
                    txtPath_C1.Text = "From Camera"
                End If
            End With
        End Using
    End Sub

    'Co-Maker I
    Private Sub CbxSingle_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSingle_C1.CheckedChanged
        If cbxSingle_C1.Checked = True Then
            cbxMarried_C1.Checked = False
            cbxSeparated_C1.Checked = False
            cbxWidowed_C1.Checked = False
        End If
    End Sub

    Private Sub CbxMarried_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarried_C1.CheckedChanged
        If cbxMarried_C1.Checked = True Then
            cbxSingle_C1.Checked = False
            cbxSeparated_C1.Checked = False
            cbxWidowed_C1.Checked = False
        End If
    End Sub

    Private Sub CbxSeparated_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSeparated_C1.CheckedChanged
        If cbxSeparated_C1.Checked = True Then
            cbxSingle_C1.Checked = False
            cbxMarried_C1.Checked = False
            cbxWidowed_C1.Checked = False
        End If
    End Sub

    Private Sub CbxWidowed_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWidowed_C1.CheckedChanged
        If cbxWidowed_C1.Checked = True Then
            cbxSingle_C1.Checked = False
            cbxMarried_C1.Checked = False
            cbxSeparated_C1.Checked = False
        End If
    End Sub

    Private Sub CbxMale_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMale_C1.CheckedChanged
        If cbxMale_C1.Checked = True Then
            cbxFemale_C1.Checked = False
        End If
    End Sub

    Private Sub CbxFemale_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFemale_C1.CheckedChanged
        If cbxFemale_C1.Checked = True Then
            cbxMale_C1.Checked = False
        End If
    End Sub

    Private Sub CbxOwned_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOwned_C1.CheckedChanged
        If cbxOwned_C1.Checked = True Then
            cbxFree_C1.Checked = False
            cbxRented_C1.Checked = False

            dRent_C1.Enabled = False
        End If
    End Sub

    Private Sub CbxFree_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFree_C1.CheckedChanged
        If cbxFree_C1.Checked = True Then
            cbxOwned_C1.Checked = False
            cbxRented_C1.Checked = False

            dRent_C1.Enabled = False
        End If
    End Sub

    Private Sub CbxRented_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRented_C1.CheckedChanged
        If cbxRented_C1.Checked = True Then
            cbxFree_C1.Checked = False
            cbxOwned_C1.Checked = False

            dRent_C1.Enabled = True

            dRent_C1.Value = vRent_C1
        Else
            dRent_C1.Enabled = False

            vRent_C1 = dRent_C1.Value
            dRent_C1.Value = 0
        End If
    End Sub

    Private Sub CbxCasual_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCasual_C1.CheckedChanged
        If cbxCasual_C1.Checked = True Then
            cbxTemporary_C1.Checked = False
            cbxPermanent_C1.Checked = False
        End If
    End Sub

    Private Sub CbxTemporary_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTemporary_C1.CheckedChanged
        If cbxTemporary_C1.Checked = True Then
            cbxCasual_C1.Checked = False
            cbxPermanent_C1.Checked = False
        End If
    End Sub

    Private Sub CbxPermanent_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPermanent_C1.CheckedChanged
        If cbxPermanent_C1.Checked = True Then
            cbxCasual_C1.Checked = False
            cbxTemporary_C1.Checked = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
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
            If FromCreditApplication Then
                btnDelete.Enabled = True
            End If

            PanelEx6.Enabled = True
            PanelEx9.Enabled = True
            PanelEx7.Enabled = True
            PanelEx11.Enabled = True
            PanelEx12.Enabled = True

            If CoMakerID_1 = "" Then
                btnID.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnDelete.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If CoMakerID_1 = "" Then
                Else
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    DataObject(String.Format("UPDATE credit_application_comaker SET `status` = 'DELETED' WHERE CoMakerID = '{0}' AND `Rank` = '{1}'", CoMakerID_1, Rank))
                    DataObject(String.Format("UPDATE profile_borrowerid  SET `status` = 'DELETED' WHERE BorrowerID = '{0}' AND ID_Type = 'C{1}';", BorrowerID, Rank))
                    Logs("CoMaker", "Delete", Reason, String.Format("Delete CoMaker {0}", If(CbxPrefix_C1.Text = "", "", CbxPrefix_C1.Text & " ") & If(TxtFirstN_C1.Text = "", "", TxtFirstN_C1.Text & " ") & If(TxtMiddleN_C1.Text = "", "", TxtMiddleN_C1.Text & " ") & If(TxtLastN_C1.Text = "", "", TxtLastN_C1.Text & " ") & If(cbxSuffix_C1.Text = "", "", cbxSuffix_C1.Text)), BorrowerID, If(CbxPrefix_C1.Text = "", "", CbxPrefix_C1.Text & " ") & If(TxtFirstN_C1.Text = "", "", TxtFirstN_C1.Text & " ") & If(TxtMiddleN_C1.Text = "", "", TxtMiddleN_C1.Text & " ") & If(TxtLastN_C1.Text = "", "", TxtLastN_C1.Text & " ") & If(cbxSuffix_C1.Text = "", "", cbxSuffix_C1.Text), CreditNumber)
                End If
                If FromCreditApplication Then
                    With FrmLoanApplication
                        If Rank = 1 And .TxtFirstN_C2.Text <> "" Then
                            'Mu transfer ang data ni Comaker 2 to Comaker 1 kay na delete man ang original comaker 1
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 1 WHERE CreditNumber = '{1}' AND `Rank` = 2;UPDATE credit_application SET Prefix_C1 = Prefix_C2, FirstN_C1 = FirstN_C2, MiddleN_C1 = MiddleN_C2, LastN_C1 = LastN_C2, Suffix_C1 = Suffix_C2 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C1' WHERE BorrowerID = '{2}' AND ID_Type = 'C2';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C1.Text = .CbxPrefix_C2.Text
                            .TxtFirstN_C1.Text = .TxtFirstN_C2.Text
                            .TxtMiddleN_C1.Text = .TxtMiddleN_C2.Text
                            .TxtLastN_C1.Text = .TxtLastN_C2.Text
                            .cbxSuffix_C1.Text = .cbxSuffix_C2.Text

                            .vPrefix_C1 = .vPrefix_C2
                            .vFirstN_C1 = .vFirstN_C2
                            .vMiddleN_C1 = .vMiddleN_C2
                            .vLastN_C1 = .vLastN_C2
                            .vSuffix_C1 = .vSuffix_C2
                            .vNoC_C1 = .vNoC_C2
                            .vStreetC_C1 = .vStreetC_C2
                            .vBarangayC_C1 = .vBarangayC_C2
                            .vAddressC_C1 = .vAddressC_C2
                            .vAddressC_C1_ID = .vAddressC_C2_ID
                            .vNoP_C1 = .vNoP_C2
                            .vStreetP_C1 = .vStreetP_C2
                            .vBarangayP_C1 = .vBarangayP_C2
                            .vAddressP_C1 = .vAddressP_C2
                            .vAddressP_C1_ID = .vAddressP_C2_ID
                            .vBirth_C1 = .vBirth_C2
                            .vPlaceBirth_C1 = .vPlaceBirth_C2
                            .vPlaceBirth_C1_ID = .vPlaceBirth_C2_ID
                            .vMale_C1 = .vMale_C2
                            .vFemale_C1 = .vFemale_C2
                            .vSingle_C1 = .vSingle_C2
                            .vMarried_C1 = .vMarried_C2
                            .vSeparated_C1 = .vSeparated_C2
                            .vWidowed_C1 = .vWidowed_C2
                            .vCitizenship_C1 = .vCitizenship_C2
                            .vTIN_C1 = .vTIN_C2
                            .vTelephone_C1 = .vTelephone_C2
                            .vSSS_C1 = .vSSS_C2
                            .vMobile_C1 = .vMobile_C2
                            .vEmail_C1 = .vEmail_C2
                            .vOwned_C1 = .vOwned_C2
                            .vFree_C1 = .vFree_C2
                            .vRented_C1 = .vRented_C2
                            .vRent_C1 = .vRent_C2
                            .vRelationship_C1 = .vRelationship_C2
                            .vRelationship_C1_ID = .vRelationship_C2_ID
                            .vEmployer_C1 = .vEmployer_C2
                            .vEmpAddress_C1 = .vEmpAddress_C2
                            .vEmpTelephone_C1 = .vEmpTelephone_C2
                            .vPosition_C1 = .vPosition_C2
                            .vCasual_C1 = .vCasual_C2
                            .vTemporary_C1 = .vTemporary_C2
                            .vPermanent_C1 = .vPermanent_C2
                            .vHired_C1 = .vHired_C2
                            .vYearHired_C1 = .vYearHired_C2
                            .vSupervisor_C1 = .vSupervisor_C2
                            .vSalary_C1 = .vSalary_C2
                            .vBusinessName_C1 = .vBusinessName_C2
                            .vBusinessAddress_C1 = .vBusinessAddress_C2
                            .vBusinessTelephone_C1 = .vBusinessTelephone_C2
                            .vNatureBusiness_C1 = .vNatureBusiness_C2
                            .vYrsOperation_C1 = .vYrsOperation_C2
                            .vBusinessIncome_C1 = .vBusinessIncome_C2
                            .vNoEmployees_C1 = .vNoEmployees_C2
                            .vCapital_C1 = .vCapital_C2
                            .vArea_C1 = .vArea_C2
                            .vExpiry_C1 = .vExpiry_C2
                            .vOutlet_C1 = .vOutlet_C2
                            .vOtherIncome_C1 = .vOtherIncome_C2
                            .vOtherIncomeD_C1 = .vOtherIncomeD_C2
                            .ChangePic1 = .ChangePic2
                            .Industry_C1 = .Industry_C2
                            Rank = 2
                        End If
                        If Rank = 2 And .TxtFirstN_C3.Text <> "" Then
                            'Mu transfer ang data ni Comaker 3 to Comaker 2 kay na delete man ang original comaker 2
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 2 WHERE CreditNumber = '{1}' AND `Rank` = 3;UPDATE credit_application SET Prefix_C2 = Prefix_C3, FirstN_C2 = FirstN_C3, MiddleN_C2 = MiddleN_C3, LastN_C2 = LastN_C3, Suffix_C2 = Suffix_C3 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C2' WHERE BorrowerID = '{2}' AND ID_Type = 'C3';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C2.Text = .CbxPrefix_C3.Text
                            .TxtFirstN_C2.Text = .TxtFirstN_C3.Text
                            .TxtMiddleN_C2.Text = .TxtMiddleN_C3.Text
                            .TxtLastN_C2.Text = .TxtLastN_C3.Text
                            .cbxSuffix_C2.Text = .cbxSuffix_C3.Text

                            .vPrefix_C2 = .vPrefix_C3
                            .vFirstN_C2 = .vFirstN_C3
                            .vMiddleN_C2 = .vMiddleN_C3
                            .vLastN_C2 = .vLastN_C3
                            .vSuffix_C2 = .vSuffix_C3
                            .vNoC_C2 = .vNoC_C3
                            .vStreetC_C2 = .vStreetC_C3
                            .vBarangayC_C2 = .vBarangayC_C3
                            .vAddressC_C2 = .vAddressC_C3
                            .vAddressC_C2_ID = .vAddressC_C3_ID
                            .vNoP_C2 = .vNoP_C3
                            .vStreetP_C2 = .vStreetP_C3
                            .vBarangayP_C2 = .vBarangayP_C3
                            .vAddressP_C2 = .vAddressP_C3
                            .vAddressP_C2_ID = .vAddressP_C3_ID
                            .vBirth_C2 = .vBirth_C3
                            .vPlaceBirth_C2 = .vPlaceBirth_C3
                            .vPlaceBirth_C2_ID = .vPlaceBirth_C3_ID
                            .vMale_C2 = .vMale_C3
                            .vFemale_C2 = .vFemale_C3
                            .vSingle_C2 = .vSingle_C3
                            .vMarried_C2 = .vMarried_C3
                            .vSeparated_C2 = .vSeparated_C3
                            .vWidowed_C2 = .vWidowed_C3
                            .vCitizenship_C2 = .vCitizenship_C3
                            .vTIN_C2 = .vTIN_C3
                            .vTelephone_C2 = .vTelephone_C3
                            .vSSS_C2 = .vSSS_C3
                            .vMobile_C2 = .vMobile_C3
                            .vEmail_C2 = .vEmail_C3
                            .vOwned_C2 = .vOwned_C3
                            .vFree_C2 = .vFree_C3
                            .vRented_C2 = .vRented_C3
                            .vRent_C2 = .vRent_C3
                            .vRelationship_C2 = .vRelationship_C3
                            .vRelationship_C2_ID = .vRelationship_C3_ID
                            .vEmployer_C2 = .vEmployer_C3
                            .vEmpAddress_C2 = .vEmpAddress_C3
                            .vEmpTelephone_C2 = .vEmpTelephone_C3
                            .vPosition_C2 = .vPosition_C3
                            .vCasual_C2 = .vCasual_C3
                            .vTemporary_C2 = .vTemporary_C3
                            .vPermanent_C2 = .vPermanent_C3
                            .vHired_C2 = .vHired_C3
                            .vYearHired_C2 = .vYearHired_C3
                            .vSupervisor_C2 = .vSupervisor_C3
                            .vSalary_C2 = .vSalary_C3
                            .vBusinessName_C2 = .vBusinessName_C3
                            .vBusinessAddress_C2 = .vBusinessAddress_C3
                            .vBusinessTelephone_C2 = .vBusinessTelephone_C3
                            .vNatureBusiness_C2 = .vNatureBusiness_C3
                            .vYrsOperation_C2 = .vYrsOperation_C3
                            .vBusinessIncome_C2 = .vBusinessIncome_C3
                            .vNoEmployees_C2 = .vNoEmployees_C3
                            .vCapital_C2 = .vCapital_C3
                            .vArea_C2 = .vArea_C3
                            .vExpiry_C2 = .vExpiry_C3
                            .vOutlet_C2 = .vOutlet_C3
                            .vOtherIncome_C2 = .vOtherIncome_C3
                            .vOtherIncomeD_C2 = .vOtherIncomeD_C3
                            .ChangePic2 = .ChangePic3
                            .Industry_C2 = .Industry_C3
                            Rank = 3
                        End If
                        If Rank = 3 And .TxtFirstN_C4.Text <> "" Then
                            'Mu transfer ang data ni Comaker 4 to Comaker 3 kay na delete man ang original comaker 3
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 3 WHERE CreditNumber = '{1}' AND `Rank` = 4;UPDATE credit_application SET Prefix_C3 = Prefix_C4, FirstN_C3 = FirstN_C4, MiddleN_C3 = MiddleN_C4, LastN_C3 = LastN_C4, Suffix_C3 = Suffix_C4 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C3' WHERE BorrowerID = '{2}' AND ID_Type = 'C4';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C3.Text = .CbxPrefix_C4.Text
                            .TxtFirstN_C3.Text = .TxtFirstN_C4.Text
                            .TxtMiddleN_C3.Text = .TxtMiddleN_C4.Text
                            .TxtLastN_C3.Text = .TxtLastN_C4.Text
                            .cbxSuffix_C3.Text = .cbxSuffix_C4.Text

                            .vPrefix_C3 = .vPrefix_C4
                            .vFirstN_C3 = .vFirstN_C4
                            .vMiddleN_C3 = .vMiddleN_C4
                            .vLastN_C3 = .vLastN_C4
                            .vSuffix_C3 = .vSuffix_C4
                            .vNoC_C3 = .vNoC_C4
                            .vStreetC_C3 = .vStreetC_C4
                            .vBarangayC_C3 = .vBarangayC_C4
                            .vAddressC_C3 = .vAddressC_C4
                            .vAddressC_C3_ID = .vAddressC_C4_ID
                            .vNoP_C3 = .vNoP_C4
                            .vStreetP_C3 = .vStreetP_C4
                            .vBarangayP_C3 = .vBarangayP_C4
                            .vAddressP_C3 = .vAddressP_C4
                            .vAddressP_C3_ID = .vAddressP_C4_ID
                            .vBirth_C3 = .vBirth_C4
                            .vPlaceBirth_C3 = .vPlaceBirth_C4
                            .vPlaceBirth_C3_ID = .vPlaceBirth_C4_ID
                            .vMale_C3 = .vMale_C4
                            .vFemale_C3 = .vFemale_C4
                            .vSingle_C3 = .vSingle_C4
                            .vMarried_C3 = .vMarried_C4
                            .vSeparated_C3 = .vSeparated_C4
                            .vWidowed_C3 = .vWidowed_C4
                            .vCitizenship_C3 = .vCitizenship_C4
                            .vTIN_C3 = .vTIN_C4
                            .vTelephone_C3 = .vTelephone_C4
                            .vSSS_C3 = .vSSS_C4
                            .vMobile_C3 = .vMobile_C4
                            .vEmail_C3 = .vEmail_C4
                            .vOwned_C3 = .vOwned_C4
                            .vFree_C3 = .vFree_C4
                            .vRented_C3 = .vRented_C4
                            .vRent_C3 = .vRent_C4
                            .vRelationship_C3 = .vRelationship_C4
                            .vRelationship_C3_ID = .vRelationship_C4_ID
                            .vEmployer_C3 = .vEmployer_C4
                            .vEmpAddress_C3 = .vEmpAddress_C4
                            .vEmpTelephone_C3 = .vEmpTelephone_C4
                            .vPosition_C3 = .vPosition_C4
                            .vCasual_C3 = .vCasual_C4
                            .vTemporary_C3 = .vTemporary_C4
                            .vPermanent_C3 = .vPermanent_C4
                            .vHired_C3 = .vHired_C4
                            .vYearHired_C3 = .vYearHired_C4
                            .vSupervisor_C3 = .vSupervisor_C4
                            .vSalary_C3 = .vSalary_C4
                            .vBusinessName_C3 = .vBusinessName_C4
                            .vBusinessAddress_C3 = .vBusinessAddress_C4
                            .vBusinessTelephone_C3 = .vBusinessTelephone_C4
                            .vNatureBusiness_C3 = .vNatureBusiness_C4
                            .vYrsOperation_C3 = .vYrsOperation_C4
                            .vBusinessIncome_C3 = .vBusinessIncome_C4
                            .vNoEmployees_C3 = .vNoEmployees_C4
                            .vCapital_C3 = .vCapital_C4
                            .vArea_C3 = .vArea_C4
                            .vExpiry_C3 = .vExpiry_C4
                            .vOutlet_C3 = .vOutlet_C4
                            .vOtherIncome_C3 = .vOtherIncome_C4
                            .vOtherIncomeD_C3 = .vOtherIncomeD_C4
                            .ChangePic3 = .ChangePic4
                            .Industry_C3 = .Industry_C4
                            Rank = 4
                        End If
                    End With
                Else
                    'CREDIT INVESTIGATION ***********************************************************************************************************************************
                    With FrmCreditInvestigation
                        If Rank = 1 And .TxtFirstN_C2.Text <> "" Then
                            'Mu transfer ang data ni Comaker 2 to Comaker 1 kay na delete man ang original comaker 1
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 1 WHERE CreditNumber = '{1}' AND `Rank` = 2;UPDATE credit_application SET Prefix_C1 = Prefix_C2, FirstN_C1 = FirstN_C2, MiddleN_C1 = MiddleN_C2, LastN_C1 = LastN_C2, Suffix_C1 = Suffix_C2 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C1' WHERE BorrowerID = '{2}' AND ID_Type = 'C2';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C1.Text = .CbxPrefix_C2.Text
                            .TxtFirstN_C1.Text = .TxtFirstN_C2.Text
                            .TxtMiddleN_C1.Text = .TxtMiddleN_C2.Text
                            .TxtLastN_C1.Text = .TxtLastN_C2.Text
                            .cbxSuffix_C1.Text = .cbxSuffix_C2.Text

                            .vPrefix_C1 = .vPrefix_C2
                            .vFirstN_C1 = .vFirstN_C2
                            .vMiddleN_C1 = .vMiddleN_C2
                            .vLastN_C1 = .vLastN_C2
                            .vSuffix_C1 = .vSuffix_C2
                            .vNoC_C1 = .vNoC_C2
                            .vStreetC_C1 = .vStreetC_C2
                            .vBarangayC_C1 = .vBarangayC_C2
                            .vAddressC_C1 = .vAddressC_C2
                            .vAddressC_C1_ID = .vAddressC_C2_ID
                            .vNoP_C1 = .vNoP_C2
                            .vStreetP_C1 = .vStreetP_C2
                            .vBarangayP_C1 = .vBarangayP_C2
                            .vAddressP_C1 = .vAddressP_C2
                            .vAddressP_C1_ID = .vAddressP_C2_ID
                            .vBirth_C1 = .vBirth_C2
                            .vPlaceBirth_C1 = .vPlaceBirth_C2
                            .vPlaceBirth_C1_ID = .vPlaceBirth_C2_ID
                            .vMale_C1 = .vMale_C2
                            .vFemale_C1 = .vFemale_C2
                            .vSingle_C1 = .vSingle_C2
                            .vMarried_C1 = .vMarried_C2
                            .vSeparated_C1 = .vSeparated_C2
                            .vWidowed_C1 = .vWidowed_C2
                            .vCitizenship_C1 = .vCitizenship_C2
                            .vTIN_C1 = .vTIN_C2
                            .vTelephone_C1 = .vTelephone_C2
                            .vSSS_C1 = .vSSS_C2
                            .vMobile_C1 = .vMobile_C2
                            .vEmail_C1 = .vEmail_C2
                            .vOwned_C1 = .vOwned_C2
                            .vFree_C1 = .vFree_C2
                            .vRented_C1 = .vRented_C2
                            .vRent_C1 = .vRent_C2
                            .vRelationship_C1 = .vRelationship_C2
                            .vRelationship_C1_ID = .vRelationship_C2_ID
                            .vEmployer_C1 = .vEmployer_C2
                            .vEmpAddress_C1 = .vEmpAddress_C2
                            .vEmpTelephone_C1 = .vEmpTelephone_C2
                            .vPosition_C1 = .vPosition_C2
                            .vCasual_C1 = .vCasual_C2
                            .vTemporary_C1 = .vTemporary_C2
                            .vPermanent_C1 = .vPermanent_C2
                            .vHired_C1 = .vHired_C2
                            .vYearHired_C1 = .vYearHired_C2
                            .vSupervisor_C1 = .vSupervisor_C2
                            .vSalary_C1 = .vSalary_C2
                            .vBusinessName_C1 = .vBusinessName_C2
                            .vBusinessAddress_C1 = .vBusinessAddress_C2
                            .vBusinessTelephone_C1 = .vBusinessTelephone_C2
                            .vNatureBusiness_C1 = .vNatureBusiness_C2
                            .vYrsOperation_C1 = .vYrsOperation_C2
                            .vBusinessIncome_C1 = .vBusinessIncome_C2
                            .dSalary_C1.Value = .dSalary_C2.Value
                            .vNoEmployees_C1 = .vNoEmployees_C2
                            .vCapital_C1 = .vCapital_C2
                            .vArea_C1 = .vArea_C2
                            .vExpiry_C1 = .vExpiry_C2
                            .vOutlet_C1 = .vOutlet_C2
                            .vOtherIncome_C1 = .vOtherIncome_C2
                            .vOtherIncomeD_C1 = .vOtherIncomeD_C2
                            .ChangePic1 = .ChangePic2
                            .Industry_C1 = .Industry_C2

                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            .vCreditor_1_C1 = .vCreditor_1_C2
                            .vCreditAddress_1_C1 = .vCreditAddress_1_C2
                            .vCreditGranted_1_C1 = .vCreditGranted_1_C2
                            .vTerm_1_C1 = .vTerm_1_C2
                            .vAmountGranted_1_C1 = .vAmountGranted_1_C2
                            .vBalance_1_C1 = .vBalance_1_C2
                            .vCreditPayment_1_C1 = .vCreditPayment_1_C2
                            .vCreditRemarks_1_C1 = .vCreditRemarks_1_C2
                            .vCreditor_2_C1 = .vCreditor_2_C2
                            .vCreditAddress_2_C1 = .vCreditAddress_2_C2
                            .vCreditGranted_2_C1 = .vCreditGranted_2_C2
                            .vTerm_2_C1 = .vTerm_2_C2
                            .vAmountGranted_2_C1 = .vAmountGranted_2_C2
                            .vBalance_2_C1 = .vBalance_2_C2
                            .vCreditPayment_2_C1 = .vCreditPayment_2_C2
                            .vCreditRemarks_2_C1 = .vCreditRemarks_2_C2
                            .vBank_1_C1 = .vBank_1_C2
                            .vBranch_1_C1 = .vBranch_1_C2
                            .vAccountT_1_C1 = .vAccountT_1_C2
                            .vSA_1_C1 = .vSA_1_C2
                            .vAverageBalance_1_C1 = .vAverageBalance_1_C2
                            .vOpened_1_C1 = .vOpened_1_C2
                            .vBank_2_C1 = .vBank_2_C2
                            .vBranch_2_C1 = .vBranch_2_C2
                            .vAccountT_2_C1 = .vAccountT_2_C2
                            .vSA_2_C1 = .vSA_2_C2
                            .vAverageBalance_2_C1 = .vAverageBalance_2_C2
                            .vOpened_2_C1 = .vOpened_2_C2
                            .vCreditRating_C1 = .vCreditRating_C2
                            .vRec_Remarks_C1 = .vRec_Remarks_C2
                            .vTitle_C1 = .vTitle_C2
                            .vCaseNum_C1 = .vCaseNum_C2
                            .vDateFilled_C1 = .vDateFilled_C2
                            .vCourt_C1 = .vCourt_C2
                            .vCaseNature_C1 = .vCaseNature_C2
                            .vAmountInvolved_C1 = .vAmountInvolved_C2
                            .vCaseStatus_C1 = .vCaseStatus_C2
                            .vFindings_C1 = .vFindings_C2
                            .vFindingsStat_C1 = .vFindingsStat_C2
                            .vCACPI_C1 = .vCACPI_C2
                            .vLocation_1_C1 = .vLocation_1_C2
                            .vTCT_1_C1 = .vTCT_1_C2
                            .vArea_1_C1 = .vArea_1_C2
                            .vPropertiesRemarks_1_C1 = .vPropertiesRemarks_1_C2
                            .vLocation_2_C1 = .vLocation_2_C2
                            .vTCT_2_C1 = .vTCT_2_C2
                            .vArea_2_C1 = .vArea_2_C2
                            .vPropertiesRemarks_2_C1 = .vPropertiesRemarks_2_C2
                            .vVehicle_1_C1 = .vVehicle_1_C2
                            .vYear_1_C1 = .vYear_1_C2
                            .vWhomAcquired_1_C1 = .vWhomAcquired_1_C2
                            .vVehicleRemarks_1_C1 = .vVehicleRemarks_1_C2
                            .vVehicle_2_C1 = .vVehicle_2_C2
                            .vYear_2_C1 = .vYear_2_C2
                            .vWhomAcquired_2_C1 = .vWhomAcquired_2_C2
                            .vVehicleRemarks_2_C1 = .vVehicleRemarks_2_C2
                            .vOtherProperties_C1 = .vOtherProperties_C2
                            .vNarrative_C1 = .vNarrative_C2
                            .vEx_TotalDisposable_C1 = .vEx_TotalDisposable_C2
                            .vEx_Living_C1 = .vEx_Living_C2
                            .vEx_Clothing_C1 = .vEx_Clothing_C2
                            .vEx_Education_C1 = .vEx_Education_C2
                            .vEx_Transportation_C1 = .vEx_Transportation_C2
                            .vEx_Lights_C1 = .vEx_Lights_C2
                            .vEx_Insurance_C1 = .vEx_Insurance_C2
                            .vEx_Amortization_C1 = .vEx_Amortization_C2
                            .vEx_Miscellaneous_C1 = .vEx_Miscellaneous_C2
                            .vEx_TotalExpenses_C1 = .vEx_TotalExpenses_C2
                            .vEx_NetDisposable_C1 = .vEx_NetDisposable_C2
                            .vEx_TMFI_C1 = .vEx_TMFI_C2
                            .vEx_TMDI_C1 = .vEx_TMDI_C2
                            .vEx_Remarks_C1 = .vEx_Remarks_C2
                            .vPurposeLoan_C1 = .vPurposeLoan_C2
                            .vOthers_C1 = .vOthers_C2
                            .vC1_C1 = .vC1_C2
                            .vC2_C1 = .vC2_C2
                            .vC3_C1 = .vC3_C2
                            .vC4_C1 = .vC4_C2
                            .vC5_C1 = .vC5_C2
                            .vC6_C1 = .vC6_C2
                            .vC7_C1 = .vC7_C2
                            .vC8_C1 = .vC8_C2
                            .vC9_C1 = .vC9_C2
                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            Rank = 2
                        End If
                        If Rank = 2 And .TxtFirstN_C3.Text <> "" Then
                            'Mu transfer ang data ni Comaker 3 to Comaker 2 kay na delete man ang original comaker 2
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 2 WHERE CreditNumber = '{1}' AND `Rank` = 3;UPDATE credit_application SET Prefix_C2 = Prefix_C3, FirstN_C2 = FirstN_C3, MiddleN_C2 = MiddleN_C3, LastN_C2 = LastN_C3, Suffix_C2 = Suffix_C3 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C2' WHERE BorrowerID = '{2}' AND ID_Type = 'C3';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C2.Text = .CbxPrefix_C3.Text
                            .TxtFirstN_C2.Text = .TxtFirstN_C3.Text
                            .TxtMiddleN_C2.Text = .TxtMiddleN_C3.Text
                            .TxtLastN_C2.Text = .TxtLastN_C3.Text
                            .cbxSuffix_C2.Text = .cbxSuffix_C3.Text

                            .vPrefix_C2 = .vPrefix_C3
                            .vFirstN_C2 = .vFirstN_C3
                            .vMiddleN_C2 = .vMiddleN_C3
                            .vLastN_C2 = .vLastN_C3
                            .vSuffix_C2 = .vSuffix_C3
                            .vNoC_C2 = .vNoC_C3
                            .vStreetC_C2 = .vStreetC_C3
                            .vBarangayC_C2 = .vBarangayC_C3
                            .vAddressC_C2 = .vAddressC_C3
                            .vAddressC_C2_ID = .vAddressC_C3_ID
                            .vNoP_C2 = .vNoP_C3
                            .vStreetP_C2 = .vStreetP_C3
                            .vBarangayP_C2 = .vBarangayP_C3
                            .vAddressP_C2 = .vAddressP_C3
                            .vAddressP_C2_ID = .vAddressP_C3_ID
                            .vBirth_C2 = .vBirth_C3
                            .vPlaceBirth_C2 = .vPlaceBirth_C3
                            .vPlaceBirth_C2_ID = .vPlaceBirth_C3_ID
                            .vMale_C2 = .vMale_C3
                            .vFemale_C2 = .vFemale_C3
                            .vSingle_C2 = .vSingle_C3
                            .vMarried_C2 = .vMarried_C3
                            .vSeparated_C2 = .vSeparated_C3
                            .vWidowed_C2 = .vWidowed_C3
                            .vCitizenship_C2 = .vCitizenship_C3
                            .vTIN_C2 = .vTIN_C3
                            .vTelephone_C2 = .vTelephone_C3
                            .vSSS_C2 = .vSSS_C3
                            .vMobile_C2 = .vMobile_C3
                            .vEmail_C2 = .vEmail_C3
                            .vOwned_C2 = .vOwned_C3
                            .vFree_C2 = .vFree_C3
                            .vRented_C2 = .vRented_C3
                            .vRent_C2 = .vRent_C3
                            .vRelationship_C2 = .vRelationship_C3
                            .vRelationship_C2_ID = .vRelationship_C3_ID
                            .vEmployer_C2 = .vEmployer_C3
                            .vEmpAddress_C2 = .vEmpAddress_C3
                            .vEmpTelephone_C2 = .vEmpTelephone_C3
                            .vPosition_C2 = .vPosition_C3
                            .vCasual_C2 = .vCasual_C3
                            .vTemporary_C2 = .vTemporary_C3
                            .vPermanent_C2 = .vPermanent_C3
                            .vHired_C2 = .vHired_C3
                            .vYearHired_C2 = .vYearHired_C3
                            .vSupervisor_C2 = .vSupervisor_C3
                            .vSalary_C2 = .vSalary_C3
                            .vBusinessName_C2 = .vBusinessName_C3
                            .vBusinessAddress_C2 = .vBusinessAddress_C3
                            .vBusinessTelephone_C2 = .vBusinessTelephone_C3
                            .vNatureBusiness_C2 = .vNatureBusiness_C3
                            .vYrsOperation_C2 = .vYrsOperation_C3
                            .vBusinessIncome_C2 = .vBusinessIncome_C3
                            .dSalary_C2.Value = .dSalary_C3.Value
                            .vNoEmployees_C2 = .vNoEmployees_C3
                            .vCapital_C2 = .vCapital_C3
                            .vArea_C2 = .vArea_C3
                            .vExpiry_C2 = .vExpiry_C3
                            .vOutlet_C2 = .vOutlet_C3
                            .vOtherIncome_C2 = .vOtherIncome_C3
                            .vOtherIncomeD_C2 = .vOtherIncomeD_C3
                            .ChangePic2 = .ChangePic3
                            .Industry_C2 = .Industry_C3

                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            .vCreditor_1_C2 = .vCreditor_1_C3
                            .vCreditAddress_1_C2 = .vCreditAddress_1_C3
                            .vCreditGranted_1_C2 = .vCreditGranted_1_C3
                            .vTerm_1_C2 = .vTerm_1_C3
                            .vAmountGranted_1_C2 = .vAmountGranted_1_C3
                            .vBalance_1_C2 = .vBalance_1_C3
                            .vCreditPayment_1_C2 = .vCreditPayment_1_C3
                            .vCreditRemarks_1_C2 = .vCreditRemarks_1_C3
                            .vCreditor_2_C2 = .vCreditor_2_C3
                            .vCreditAddress_2_C2 = .vCreditAddress_2_C3
                            .vCreditGranted_2_C2 = .vCreditGranted_2_C3
                            .vTerm_2_C2 = .vTerm_2_C3
                            .vAmountGranted_2_C2 = .vAmountGranted_2_C3
                            .vBalance_2_C2 = .vBalance_2_C3
                            .vCreditPayment_2_C2 = .vCreditPayment_2_C3
                            .vCreditRemarks_2_C2 = .vCreditRemarks_2_C3
                            .vBank_1_C2 = .vBank_1_C3
                            .vBranch_1_C2 = .vBranch_1_C3
                            .vAccountT_1_C2 = .vAccountT_1_C3
                            .vSA_1_C2 = .vSA_1_C3
                            .vAverageBalance_1_C2 = .vAverageBalance_1_C3
                            .vOpened_1_C2 = .vOpened_1_C3
                            .vBank_2_C2 = .vBank_2_C3
                            .vBranch_2_C2 = .vBranch_2_C3
                            .vAccountT_2_C2 = .vAccountT_2_C3
                            .vSA_2_C2 = .vSA_2_C3
                            .vAverageBalance_2_C2 = .vAverageBalance_2_C3
                            .vOpened_2_C2 = .vOpened_2_C3
                            .vCreditRating_C2 = .vCreditRating_C3
                            .vRec_Remarks_C2 = .vRec_Remarks_C3
                            .vTitle_C2 = .vTitle_C3
                            .vCaseNum_C2 = .vCaseNum_C3
                            .vDateFilled_C2 = .vDateFilled_C3
                            .vCourt_C2 = .vCourt_C3
                            .vCaseNature_C2 = .vCaseNature_C3
                            .vAmountInvolved_C2 = .vAmountInvolved_C3
                            .vCaseStatus_C2 = .vCaseStatus_C3
                            .vFindings_C2 = .vFindings_C3
                            .vFindingsStat_C2 = .vFindingsStat_C3
                            .vCACPI_C2 = .vCACPI_C3
                            .vLocation_1_C2 = .vLocation_1_C3
                            .vTCT_1_C2 = .vTCT_1_C3
                            .vArea_1_C2 = .vArea_1_C3
                            .vPropertiesRemarks_1_C2 = .vPropertiesRemarks_1_C3
                            .vLocation_2_C2 = .vLocation_2_C3
                            .vTCT_2_C2 = .vTCT_2_C3
                            .vArea_2_C2 = .vArea_2_C3
                            .vPropertiesRemarks_2_C2 = .vPropertiesRemarks_2_C3
                            .vVehicle_1_C2 = .vVehicle_1_C3
                            .vYear_1_C2 = .vYear_1_C3
                            .vWhomAcquired_1_C2 = .vWhomAcquired_1_C3
                            .vVehicleRemarks_1_C2 = .vVehicleRemarks_1_C3
                            .vVehicle_2_C2 = .vVehicle_2_C3
                            .vYear_2_C2 = .vYear_2_C3
                            .vWhomAcquired_2_C2 = .vWhomAcquired_2_C3
                            .vVehicleRemarks_2_C2 = .vVehicleRemarks_2_C3
                            .vOtherProperties_C2 = .vOtherProperties_C3
                            .vNarrative_C2 = .vNarrative_C3
                            .vEx_TotalDisposable_C2 = .vEx_TotalDisposable_C3
                            .vEx_Living_C2 = .vEx_Living_C3
                            .vEx_Clothing_C2 = .vEx_Clothing_C3
                            .vEx_Education_C2 = .vEx_Education_C3
                            .vEx_Transportation_C2 = .vEx_Transportation_C3
                            .vEx_Lights_C2 = .vEx_Lights_C3
                            .vEx_Insurance_C2 = .vEx_Insurance_C3
                            .vEx_Amortization_C2 = .vEx_Amortization_C3
                            .vEx_Miscellaneous_C2 = .vEx_Miscellaneous_C3
                            .vEx_TotalExpenses_C2 = .vEx_TotalExpenses_C3
                            .vEx_NetDisposable_C2 = .vEx_NetDisposable_C3
                            .vEx_TMFI_C2 = .vEx_TMFI_C3
                            .vEx_TMDI_C2 = .vEx_TMDI_C3
                            .vEx_Remarks_C2 = .vEx_Remarks_C3
                            .vPurposeLoan_C2 = .vPurposeLoan_C3
                            .vOthers_C2 = .vOthers_C3
                            .vC1_C2 = .vC1_C3
                            .vC2_C2 = .vC2_C3
                            .vC3_C2 = .vC3_C3
                            .vC4_C2 = .vC4_C3
                            .vC5_C2 = .vC5_C3
                            .vC6_C2 = .vC6_C3
                            .vC7_C2 = .vC7_C3
                            .vC8_C2 = .vC8_C3
                            .vC9_C2 = .vC9_C3
                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            Rank = 3
                        End If
                        If Rank = 3 And .TxtFirstN_C4.Text <> "" Then
                            'Mu transfer ang data ni Comaker 4 to Comaker 3 kay na delete man ang original comaker 3
                            DataObject(String.Format("UPDATE credit_application_comaker SET `Rank` = 3 WHERE CreditNumber = '{1}' AND `Rank` = 4;UPDATE credit_application SET Prefix_C3 = Prefix_C4, FirstN_C3 = FirstN_C4, MiddleN_C3 = MiddleN_C4, LastN_C3 = LastN_C4, Suffix_C3 = Suffix_C4 WHERE CreditNumber = '{1}';UPDATE profile_borrowerid  SET ID_Type = 'C3' WHERE BorrowerID = '{2}' AND ID_Type = 'C4';", CoMakerID_1, CreditNumber, BorrowerID))
                            .CoMakerShift = True
                            .CbxPrefix_C3.Text = .CbxPrefix_C4.Text
                            .TxtFirstN_C3.Text = .TxtFirstN_C4.Text
                            .TxtMiddleN_C3.Text = .TxtMiddleN_C4.Text
                            .TxtLastN_C3.Text = .TxtLastN_C4.Text
                            .cbxSuffix_C3.Text = .cbxSuffix_C4.Text

                            .vPrefix_C3 = .vPrefix_C4
                            .vFirstN_C3 = .vFirstN_C4
                            .vMiddleN_C3 = .vMiddleN_C4
                            .vLastN_C3 = .vLastN_C4
                            .vSuffix_C3 = .vSuffix_C4
                            .vNoC_C3 = .vNoC_C4
                            .vStreetC_C3 = .vStreetC_C4
                            .vBarangayC_C3 = .vBarangayC_C4
                            .vAddressC_C3 = .vAddressC_C4
                            .vAddressC_C3_ID = .vAddressC_C4_ID
                            .vNoP_C3 = .vNoP_C4
                            .vStreetP_C3 = .vStreetP_C4
                            .vBarangayP_C3 = .vBarangayP_C4
                            .vAddressP_C3 = .vAddressP_C4
                            .vAddressP_C3_ID = .vAddressP_C4_ID
                            .vBirth_C3 = .vBirth_C4
                            .vPlaceBirth_C3 = .vPlaceBirth_C4
                            .vPlaceBirth_C3_ID = .vPlaceBirth_C4_ID
                            .vMale_C3 = .vMale_C4
                            .vFemale_C3 = .vFemale_C4
                            .vSingle_C3 = .vSingle_C4
                            .vMarried_C3 = .vMarried_C4
                            .vSeparated_C3 = .vSeparated_C4
                            .vWidowed_C3 = .vWidowed_C4
                            .vCitizenship_C3 = .vCitizenship_C4
                            .vTIN_C3 = .vTIN_C4
                            .vTelephone_C3 = .vTelephone_C4
                            .vSSS_C3 = .vSSS_C4
                            .vMobile_C3 = .vMobile_C4
                            .vEmail_C3 = .vEmail_C4
                            .vOwned_C3 = .vOwned_C4
                            .vFree_C3 = .vFree_C4
                            .vRented_C3 = .vRented_C4
                            .vRent_C3 = .vRent_C4
                            .vRelationship_C3 = .vRelationship_C4
                            .vRelationship_C3_ID = .vRelationship_C4_ID
                            .vEmployer_C3 = .vEmployer_C4
                            .vEmpAddress_C3 = .vEmpAddress_C4
                            .vEmpTelephone_C3 = .vEmpTelephone_C4
                            .vPosition_C3 = .vPosition_C4
                            .vCasual_C3 = .vCasual_C4
                            .vTemporary_C3 = .vTemporary_C4
                            .vPermanent_C3 = .vPermanent_C4
                            .vHired_C3 = .vHired_C4
                            .vYearHired_C3 = .vYearHired_C4
                            .vSupervisor_C3 = .vSupervisor_C4
                            .vSalary_C3 = .vSalary_C4
                            .vBusinessName_C3 = .vBusinessName_C4
                            .vBusinessAddress_C3 = .vBusinessAddress_C4
                            .vBusinessTelephone_C3 = .vBusinessTelephone_C4
                            .vNatureBusiness_C3 = .vNatureBusiness_C4
                            .vYrsOperation_C3 = .vYrsOperation_C4
                            .vBusinessIncome_C3 = .vBusinessIncome_C4
                            .dSalary_C3.Value = .dSalary_C4.Value
                            .vNoEmployees_C3 = .vNoEmployees_C4
                            .vCapital_C3 = .vCapital_C4
                            .vArea_C3 = .vArea_C4
                            .vExpiry_C3 = .vExpiry_C4
                            .vOutlet_C3 = .vOutlet_C4
                            .vOtherIncome_C3 = .vOtherIncome_C4
                            .vOtherIncomeD_C3 = .vOtherIncomeD_C4
                            .ChangePic3 = .ChangePic4
                            .Industry_C3 = .Industry_C4

                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            .vCreditor_1_C3 = .vCreditor_1_C4
                            .vCreditAddress_1_C3 = .vCreditAddress_1_C4
                            .vCreditGranted_1_C3 = .vCreditGranted_1_C4
                            .vTerm_1_C3 = .vTerm_1_C4
                            .vAmountGranted_1_C3 = .vAmountGranted_1_C4
                            .vBalance_1_C3 = .vBalance_1_C4
                            .vCreditPayment_1_C3 = .vCreditPayment_1_C4
                            .vCreditRemarks_1_C3 = .vCreditRemarks_1_C4
                            .vCreditor_2_C3 = .vCreditor_2_C4
                            .vCreditAddress_2_C3 = .vCreditAddress_2_C4
                            .vCreditGranted_2_C3 = .vCreditGranted_2_C4
                            .vTerm_2_C3 = .vTerm_2_C4
                            .vAmountGranted_2_C3 = .vAmountGranted_2_C4
                            .vBalance_2_C3 = .vBalance_2_C4
                            .vCreditPayment_2_C3 = .vCreditPayment_2_C4
                            .vCreditRemarks_2_C3 = .vCreditRemarks_2_C4
                            .vBank_1_C3 = .vBank_1_C4
                            .vBranch_1_C3 = .vBranch_1_C4
                            .vAccountT_1_C3 = .vAccountT_1_C4
                            .vSA_1_C3 = .vSA_1_C4
                            .vAverageBalance_1_C3 = .vAverageBalance_1_C4
                            .vOpened_1_C3 = .vOpened_1_C4
                            .vBank_2_C3 = .vBank_2_C4
                            .vBranch_2_C3 = .vBranch_2_C4
                            .vAccountT_2_C3 = .vAccountT_2_C4
                            .vSA_2_C3 = .vSA_2_C4
                            .vAverageBalance_2_C3 = .vAverageBalance_2_C4
                            .vOpened_2_C3 = .vOpened_2_C4
                            .vCreditRating_C3 = .vCreditRating_C4
                            .vRec_Remarks_C3 = .vRec_Remarks_C4
                            .vTitle_C3 = .vTitle_C4
                            .vCaseNum_C3 = .vCaseNum_C4
                            .vDateFilled_C3 = .vDateFilled_C4
                            .vCourt_C3 = .vCourt_C4
                            .vCaseNature_C3 = .vCaseNature_C4
                            .vAmountInvolved_C3 = .vAmountInvolved_C4
                            .vCaseStatus_C3 = .vCaseStatus_C4
                            .vFindings_C3 = .vFindings_C4
                            .vFindingsStat_C3 = .vFindingsStat_C4
                            .vCACPI_C3 = .vCACPI_C4
                            .vLocation_1_C3 = .vLocation_1_C4
                            .vTCT_1_C3 = .vTCT_1_C4
                            .vArea_1_C3 = .vArea_1_C4
                            .vPropertiesRemarks_1_C3 = .vPropertiesRemarks_1_C4
                            .vLocation_2_C3 = .vLocation_2_C4
                            .vTCT_2_C3 = .vTCT_2_C4
                            .vArea_2_C3 = .vArea_2_C4
                            .vPropertiesRemarks_2_C3 = .vPropertiesRemarks_2_C4
                            .vVehicle_1_C3 = .vVehicle_1_C4
                            .vYear_1_C3 = .vYear_1_C4
                            .vWhomAcquired_1_C3 = .vWhomAcquired_1_C4
                            .vVehicleRemarks_1_C3 = .vVehicleRemarks_1_C4
                            .vVehicle_2_C3 = .vVehicle_2_C4
                            .vYear_2_C3 = .vYear_2_C4
                            .vWhomAcquired_2_C3 = .vWhomAcquired_2_C4
                            .vVehicleRemarks_2_C3 = .vVehicleRemarks_2_C4
                            .vOtherProperties_C3 = .vOtherProperties_C4
                            .vNarrative_C3 = .vNarrative_C4
                            .vEx_TotalDisposable_C3 = .vEx_TotalDisposable_C4
                            .vEx_Living_C3 = .vEx_Living_C4
                            .vEx_Clothing_C3 = .vEx_Clothing_C4
                            .vEx_Education_C3 = .vEx_Education_C4
                            .vEx_Transportation_C3 = .vEx_Transportation_C4
                            .vEx_Lights_C3 = .vEx_Lights_C4
                            .vEx_Insurance_C3 = .vEx_Insurance_C4
                            .vEx_Amortization_C3 = .vEx_Amortization_C4
                            .vEx_Miscellaneous_C3 = .vEx_Miscellaneous_C4
                            .vEx_TotalExpenses_C3 = .vEx_TotalExpenses_C4
                            .vEx_NetDisposable_C3 = .vEx_NetDisposable_C4
                            .vEx_TMFI_C3 = .vEx_TMFI_C4
                            .vEx_TMDI_C3 = .vEx_TMDI_C4
                            .vEx_Remarks_C3 = .vEx_Remarks_C4
                            .vPurposeLoan_C3 = .vPurposeLoan_C4
                            .vOthers_C3 = .vOthers_C4
                            .vC1_C3 = .vC1_C4
                            .vC2_C3 = .vC2_C4
                            .vC3_C3 = .vC3_C4
                            .vC4_C3 = .vC4_C4
                            .vC5_C3 = .vC5_C4
                            .vC6_C3 = .vC6_C4
                            .vC7_C3 = .vC7_C4
                            .vC8_C3 = .vC8_C4
                            .vC9_C3 = .vC9_C4
                            'COMAKER CREDIT INVESTIGATION REPORT ************************************************************
                            Rank = 4
                        End If
                    End With
                End If
                Clear()
                If FromCreditApplication Then
                    With FrmLoanApplication
                        If Rank = 1 Then
                            DataObject(String.Format("UPDATE credit_application SET Prefix_C1 = '{1}', FirstN_C1 = '{2}', MiddleN_C1 = '{3}', LastN_C1 = '{4}', Suffix_C1 = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_C1.Text, TxtFirstN_C1.Text, TxtMiddleN_C1.Text, TxtLastN_C1.Text, cbxSuffix_C1.Text))
                            .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C1.Text = TxtLastN_C1.Text
                            .cbxSuffix_C1.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C1.Tag = ""
                            .TxtFirstN_C1.Tag = ""
                            .TxtMiddleN_C1.Tag = ""
                            .TxtLastN_C1.Tag = ""
                            .cbxSuffix_C1.Tag = ""

                            .vPrefix_C1 = CbxPrefix_C1.Text
                            .vFirstN_C1 = TxtFirstN_C1.Text
                            .vMiddleN_C1 = TxtMiddleN_C1.Text
                            .vLastN_C1 = TxtLastN_C1.Text
                            .vSuffix_C1 = cbxSuffix_C1.Text
                            .vNoC_C1 = txtNoC_C1.Text
                            .vStreetC_C1 = txtStreetC_C1.Text
                            .vBarangayC_C1 = txtBarangayC_C1.Text
                            .vAddressC_C1 = cbxAddressC_C1.Text
                            .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C1 = txtNoP_C1.Text
                            .vStreetP_C1 = txtStreetP_C1.Text
                            .vBarangayP_C1 = txtBarangayP_C1.Text
                            .vAddressP_C1 = cbxAddressP_C1.Text
                            .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C1 = DtpBirth_C1.Text
                            .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C1 = cbxMale_C1.Checked
                            .vFemale_C1 = cbxFemale_C1.Checked
                            .vSingle_C1 = cbxSingle_C1.Checked
                            .vMarried_C1 = cbxMarried_C1.Checked
                            .vSeparated_C1 = cbxSeparated_C1.Checked
                            .vWidowed_C1 = cbxWidowed_C1.Checked
                            .vCitizenship_C1 = txtCitizenship_C1.Text
                            .vTIN_C1 = txtTIN_C1.Text
                            .vTelephone_C1 = txtTelephone_C1.Text
                            .vSSS_C1 = txtSSS_C1.Text
                            .vMobile_C1 = txtMobile_C1.Text
                            .vEmail_C1 = txtEmail_C1.Text
                            .vOwned_C1 = cbxOwned_C1.Checked
                            .vFree_C1 = cbxFree_C1.Checked
                            .vRented_C1 = cbxRented_C1.Checked
                            .vRent_C1 = dRent_C1.Value
                            .vRelationship_C1 = cbxRelationship_C1.Text
                            .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C1 = cbxEmployer_C1.Text
                            .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                            .vPosition_C1 = cbxPosition_C1.Text
                            .vCasual_C1 = cbxCasual_C1.Checked
                            .vTemporary_C1 = cbxTemporary_C1.Checked
                            .vPermanent_C1 = cbxPermanent_C1.Checked
                            .vHired_C1 = dtpHired_C1.Value
                            .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C1 = txtSupervisor_C1.Text
                            .vSalary_C1 = dMonthly_C1.Value
                            .vBusinessName_C1 = txtBusinessName_C1.Text
                            .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C1 = iYrsOperation_C1.Value
                            .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                            .vNoEmployees_C1 = iNoEmployees_C1.Value
                            .vCapital_C1 = dCapital_C1.Value
                            .vArea_C1 = txtArea_C1.Text
                            .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C1 = iOutlet_C1.Value
                            .vOtherIncome_C1 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C1 = dOtherIncome_C1.Value
                            .ChangePic1 = False
                        ElseIf Rank = 2 Then
                            DataObject(String.Format("UPDATE credit_application SET Prefix_C2 = '{1}', FirstN_C2 = '{2}', MiddleN_C2 = '{3}', LastN_C2 = '{4}', Suffix_C2 = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_C1.Text, TxtFirstN_C1.Text, TxtMiddleN_C1.Text, TxtLastN_C1.Text, cbxSuffix_C1.Text))
                            .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C2.Text = TxtLastN_C1.Text
                            .cbxSuffix_C2.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C2.Tag = ""
                            .TxtFirstN_C2.Tag = ""
                            .TxtMiddleN_C2.Tag = ""
                            .TxtLastN_C2.Tag = ""
                            .cbxSuffix_C2.Tag = ""

                            .vPrefix_C2 = CbxPrefix_C1.Text
                            .vFirstN_C2 = TxtFirstN_C1.Text
                            .vMiddleN_C2 = TxtMiddleN_C1.Text
                            .vLastN_C2 = TxtLastN_C1.Text
                            .vSuffix_C2 = cbxSuffix_C1.Text
                            .vNoC_C2 = txtNoC_C1.Text
                            .vStreetC_C2 = txtStreetC_C1.Text
                            .vBarangayC_C2 = txtBarangayC_C1.Text
                            .vAddressC_C2 = cbxAddressC_C1.Text
                            .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C2 = txtNoP_C1.Text
                            .vStreetP_C2 = txtStreetP_C1.Text
                            .vBarangayP_C2 = txtBarangayP_C1.Text
                            .vAddressP_C2 = cbxAddressP_C1.Text
                            .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C2 = DtpBirth_C1.Text
                            .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C2 = cbxMale_C1.Checked
                            .vFemale_C2 = cbxFemale_C1.Checked
                            .vSingle_C2 = cbxSingle_C1.Checked
                            .vMarried_C2 = cbxMarried_C1.Checked
                            .vSeparated_C2 = cbxSeparated_C1.Checked
                            .vWidowed_C2 = cbxWidowed_C1.Checked
                            .vCitizenship_C2 = txtCitizenship_C1.Text
                            .vTIN_C2 = txtTIN_C1.Text
                            .vTelephone_C2 = txtTelephone_C1.Text
                            .vSSS_C2 = txtSSS_C1.Text
                            .vMobile_C2 = txtMobile_C1.Text
                            .vEmail_C2 = txtEmail_C1.Text
                            .vOwned_C2 = cbxOwned_C1.Checked
                            .vFree_C2 = cbxFree_C1.Checked
                            .vRented_C2 = cbxRented_C1.Checked
                            .vRent_C2 = dRent_C1.Value
                            .vRelationship_C2 = cbxRelationship_C1.Text
                            .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C2 = cbxEmployer_C1.Text
                            .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                            .vPosition_C2 = cbxPosition_C1.Text
                            .vCasual_C2 = cbxCasual_C1.Checked
                            .vTemporary_C2 = cbxTemporary_C1.Checked
                            .vPermanent_C2 = cbxPermanent_C1.Checked
                            .vHired_C2 = dtpHired_C1.Value
                            .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C2 = txtSupervisor_C1.Text
                            .vSalary_C2 = dMonthly_C1.Value
                            .vBusinessName_C2 = txtBusinessName_C1.Text
                            .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C2 = iYrsOperation_C1.Value
                            .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                            .vNoEmployees_C2 = iNoEmployees_C1.Value
                            .vCapital_C2 = dCapital_C1.Value
                            .vArea_C2 = txtArea_C1.Text
                            .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C2 = iOutlet_C1.Value
                            .vOtherIncome_C2 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C2 = dOtherIncome_C1.Value
                            .ChangePic2 = False
                        ElseIf Rank = 3 Then
                            DataObject(String.Format("UPDATE credit_application SET Prefix_C3 = '{1}', FirstN_C3 = '{2}', MiddleN_C3 = '{3}', LastN_C3 = '{4}', Suffix_C3 = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_C1.Text, TxtFirstN_C1.Text, TxtMiddleN_C1.Text, TxtLastN_C1.Text, cbxSuffix_C1.Text))
                            .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C3.Text = TxtLastN_C1.Text
                            .cbxSuffix_C3.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C3.Tag = ""
                            .TxtFirstN_C3.Tag = ""
                            .TxtMiddleN_C3.Tag = ""
                            .TxtLastN_C3.Tag = ""
                            .cbxSuffix_C3.Tag = ""

                            .vPrefix_C3 = CbxPrefix_C1.Text
                            .vFirstN_C3 = TxtFirstN_C1.Text
                            .vMiddleN_C3 = TxtMiddleN_C1.Text
                            .vLastN_C3 = TxtLastN_C1.Text
                            .vSuffix_C3 = cbxSuffix_C1.Text
                            .vNoC_C3 = txtNoC_C1.Text
                            .vStreetC_C3 = txtStreetC_C1.Text
                            .vBarangayC_C3 = txtBarangayC_C1.Text
                            .vAddressC_C3 = cbxAddressC_C1.Text
                            .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C3 = txtNoP_C1.Text
                            .vStreetP_C3 = txtStreetP_C1.Text
                            .vBarangayP_C3 = txtBarangayP_C1.Text
                            .vAddressP_C3 = cbxAddressP_C1.Text
                            .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C3 = DtpBirth_C1.Text
                            .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C3 = cbxMale_C1.Checked
                            .vFemale_C3 = cbxFemale_C1.Checked
                            .vSingle_C3 = cbxSingle_C1.Checked
                            .vMarried_C3 = cbxMarried_C1.Checked
                            .vSeparated_C3 = cbxSeparated_C1.Checked
                            .vWidowed_C3 = cbxWidowed_C1.Checked
                            .vCitizenship_C3 = txtCitizenship_C1.Text
                            .vTIN_C3 = txtTIN_C1.Text
                            .vTelephone_C3 = txtTelephone_C1.Text
                            .vSSS_C3 = txtSSS_C1.Text
                            .vMobile_C3 = txtMobile_C1.Text
                            .vEmail_C3 = txtEmail_C1.Text
                            .vOwned_C3 = cbxOwned_C1.Checked
                            .vFree_C3 = cbxFree_C1.Checked
                            .vRented_C3 = cbxRented_C1.Checked
                            .vRent_C3 = dRent_C1.Value
                            .vRelationship_C3 = cbxRelationship_C1.Text
                            .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C3 = cbxEmployer_C1.Text
                            .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                            .vPosition_C3 = cbxPosition_C1.Text
                            .vCasual_C3 = cbxCasual_C1.Checked
                            .vTemporary_C3 = cbxTemporary_C1.Checked
                            .vPermanent_C3 = cbxPermanent_C1.Checked
                            .vHired_C3 = dtpHired_C1.Value
                            .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C3 = txtSupervisor_C1.Text
                            .vSalary_C3 = dMonthly_C1.Value
                            .vBusinessName_C3 = txtBusinessName_C1.Text
                            .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C3 = iYrsOperation_C1.Value
                            .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                            .vNoEmployees_C3 = iNoEmployees_C1.Value
                            .vCapital_C3 = dCapital_C1.Value
                            .vArea_C3 = txtArea_C1.Text
                            .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C3 = iOutlet_C1.Value
                            .vOtherIncome_C3 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C3 = dOtherIncome_C1.Value
                            .ChangePic3 = False
                        ElseIf Rank = 4 Then
                            DataObject(String.Format("UPDATE credit_application SET Prefix_C4 = '{1}', FirstN_C4 = '{2}', MiddleN_C4 = '{3}', LastN_C4 = '{4}', Suffix_C4 = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_C1.Text, TxtFirstN_C1.Text, TxtMiddleN_C1.Text, TxtLastN_C1.Text, cbxSuffix_C1.Text))
                            .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C4.Text = TxtLastN_C1.Text
                            .cbxSuffix_C4.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C4.Tag = ""
                            .TxtFirstN_C4.Tag = ""
                            .TxtMiddleN_C4.Tag = ""
                            .TxtLastN_C4.Tag = ""
                            .cbxSuffix_C4.Tag = ""

                            .vPrefix_C4 = CbxPrefix_C1.Text
                            .vFirstN_C4 = TxtFirstN_C1.Text
                            .vMiddleN_C4 = TxtMiddleN_C1.Text
                            .vLastN_C4 = TxtLastN_C1.Text
                            .vSuffix_C4 = cbxSuffix_C1.Text
                            .vNoC_C4 = txtNoC_C1.Text
                            .vStreetC_C4 = txtStreetC_C1.Text
                            .vBarangayC_C4 = txtBarangayC_C1.Text
                            .vAddressC_C4 = cbxAddressC_C1.Text
                            .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C4 = txtNoP_C1.Text
                            .vStreetP_C4 = txtStreetP_C1.Text
                            .vBarangayP_C4 = txtBarangayP_C1.Text
                            .vAddressP_C4 = cbxAddressP_C1.Text
                            .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C4 = DtpBirth_C1.Text
                            .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C4 = cbxMale_C1.Checked
                            .vFemale_C4 = cbxFemale_C1.Checked
                            .vSingle_C4 = cbxSingle_C1.Checked
                            .vMarried_C4 = cbxMarried_C1.Checked
                            .vSeparated_C4 = cbxSeparated_C1.Checked
                            .vWidowed_C4 = cbxWidowed_C1.Checked
                            .vCitizenship_C4 = txtCitizenship_C1.Text
                            .vTIN_C4 = txtTIN_C1.Text
                            .vTelephone_C4 = txtTelephone_C1.Text
                            .vSSS_C4 = txtSSS_C1.Text
                            .vMobile_C4 = txtMobile_C1.Text
                            .vEmail_C4 = txtEmail_C1.Text
                            .vOwned_C4 = cbxOwned_C1.Checked
                            .vFree_C4 = cbxFree_C1.Checked
                            .vRented_C4 = cbxRented_C1.Checked
                            .vRent_C4 = dRent_C1.Value
                            .vRelationship_C4 = cbxRelationship_C1.Text
                            .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C4 = cbxEmployer_C1.Text
                            .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                            .vPosition_C4 = cbxPosition_C1.Text
                            .vCasual_C4 = cbxCasual_C1.Checked
                            .vTemporary_C4 = cbxTemporary_C1.Checked
                            .vPermanent_C4 = cbxPermanent_C1.Checked
                            .vHired_C4 = dtpHired_C1.Value
                            .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C4 = txtSupervisor_C1.Text
                            .vSalary_C4 = dMonthly_C1.Value
                            .vBusinessName_C4 = txtBusinessName_C1.Text
                            .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C4 = iYrsOperation_C1.Value
                            .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                            .vNoEmployees_C4 = iNoEmployees_C1.Value
                            .vCapital_C4 = dCapital_C1.Value
                            .vArea_C4 = txtArea_C1.Text
                            .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C4 = iOutlet_C1.Value
                            .vOtherIncome_C4 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C4 = dOtherIncome_C1.Value
                            .ChangePic4 = False
                        End If
                    End With
                Else
                    'CREDIT INVESTIGATION *********************************************************************************************************************************
                    With FrmCreditInvestigation
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

                        Dim CreditRating As String = ""
                        If cbxGood.Checked Then
                            CreditRating = "GOOD"
                        ElseIf cbxFair.Checked Then
                            CreditRating = "FAIR"
                        ElseIf cbxPoor.Checked Then
                            CreditRating = "POOR"
                        End If

                        Dim Findings As String = ""
                        If cbxPositive.Checked Then
                            Findings = "Positive"
                        ElseIf cbxNegative.Checked Then
                            Findings = "Negative"
                        ElseIf cbxUnestablished.Checked Then
                            Findings = "Unestablished"
                        End If
                        If Rank = 1 Then
                            .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C1.Text = TxtLastN_C1.Text
                            .cbxSuffix_C1.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C1.Tag = ""
                            .TxtFirstN_C1.Tag = ""
                            .TxtMiddleN_C1.Tag = ""
                            .TxtLastN_C1.Tag = ""
                            .cbxSuffix_C1.Tag = ""

                            .vPrefix_C1 = CbxPrefix_C1.Text
                            .vFirstN_C1 = TxtFirstN_C1.Text
                            .vMiddleN_C1 = TxtMiddleN_C1.Text
                            .vLastN_C1 = TxtLastN_C1.Text
                            .vSuffix_C1 = cbxSuffix_C1.Text
                            .vNoC_C1 = txtNoC_C1.Text
                            .vStreetC_C1 = txtStreetC_C1.Text
                            .vBarangayC_C1 = txtBarangayC_C1.Text
                            .vAddressC_C1 = cbxAddressC_C1.Text
                            .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C1 = txtNoP_C1.Text
                            .vStreetP_C1 = txtStreetP_C1.Text
                            .vBarangayP_C1 = txtBarangayP_C1.Text
                            .vAddressP_C1 = cbxAddressP_C1.Text
                            .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C1 = DtpBirth_C1.Text
                            .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C1 = cbxMale_C1.Checked
                            .vFemale_C1 = cbxFemale_C1.Checked
                            .vSingle_C1 = cbxSingle_C1.Checked
                            .vMarried_C1 = cbxMarried_C1.Checked
                            .vSeparated_C1 = cbxSeparated_C1.Checked
                            .vWidowed_C1 = cbxWidowed_C1.Checked
                            .vCitizenship_C1 = txtCitizenship_C1.Text
                            .vTIN_C1 = txtTIN_C1.Text
                            .vTelephone_C1 = txtTelephone_C1.Text
                            .vSSS_C1 = txtSSS_C1.Text
                            .vMobile_C1 = txtMobile_C1.Text
                            .vEmail_C1 = txtEmail_C1.Text
                            .vOwned_C1 = cbxOwned_C1.Checked
                            .vFree_C1 = cbxFree_C1.Checked
                            .vRented_C1 = cbxRented_C1.Checked
                            .vRent_C1 = dRent_C1.Value
                            .vRelationship_C1 = cbxRelationship_C1.Text
                            .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C1 = cbxEmployer_C1.Text
                            .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                            .vPosition_C1 = cbxPosition_C1.Text
                            .vCasual_C1 = cbxCasual_C1.Checked
                            .vTemporary_C1 = cbxTemporary_C1.Checked
                            .vPermanent_C1 = cbxPermanent_C1.Checked
                            .vHired_C1 = dtpHired_C1.Value
                            .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C1 = txtSupervisor_C1.Text
                            .vSalary_C1 = dMonthly_C1.Value
                            .vBusinessName_C1 = txtBusinessName_C1.Text
                            .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C1 = iYrsOperation_C1.Value
                            .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                            .dSalary_C1.Value = dNetDisposable.Value
                            .vNoEmployees_C1 = iNoEmployees_C1.Value
                            .vCapital_C1 = dCapital_C1.Value
                            .vArea_C1 = txtArea_C1.Text
                            .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C1 = iOutlet_C1.Value
                            .vOtherIncome_C1 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C1 = dOtherIncome_C1.Value

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C1 = txtCreditor_1.Text
                            .vCreditAddress_1_C1 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C1 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C1 = iTerm_1.Value
                            .vAmountGranted_1_C1 = dAmountGranted_1.Value
                            .vBalance_1_C1 = dBalance_1.Value
                            .vCreditPayment_1_C1 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C1 = txtCreditRemarks_1.Text
                            .vCreditor_2_C1 = txtCreditor_2.Text
                            .vCreditAddress_2_C1 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C1 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C1 = iTerm_2.Value
                            .vAmountGranted_2_C1 = dAmountGranted_2.Value
                            .vBalance_2_C1 = dBalance_2.Value
                            .vCreditPayment_2_C1 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C1 = txtCreditRemarks_2.Text
                            .vBank_1_C1 = txtBank_1.Text
                            .vBranch_1_C1 = txtBranch_1.Text
                            .vAccountT_1_C1 = AccountT_1
                            .vSA_1_C1 = txtSA_1.Text
                            .vAverageBalance_1_C1 = dAverageBalance_1.Value
                            .vOpened_1_C1 = txtOpened_1.Text
                            .vBank_2_C1 = txtBank_2.Text
                            .vBranch_2_C1 = txtBranch_2.Text
                            .vAccountT_2_C1 = AccountT_2
                            .vSA_2_C1 = txtSA_2.Text
                            .vAverageBalance_2_C1 = dAverageBalance_2.Value
                            .vOpened_2_C1 = txtOpened_2.Text
                            .vCreditRating_C1 = CreditRating
                            .vRec_Remarks_C1 = rRecommendation.Text
                            .vTitle_C1 = txtTitle.Text
                            .vCaseNum_C1 = txtCaseNum.Text
                            .vDateFilled_C1 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C1 = cbxCourt.Text
                            .vCaseNature_C1 = cbxCaseNature.Text
                            .vAmountInvolved_C1 = dAmountInvolved.Value
                            .vCaseStatus_C1 = cbxCaseStatus.Text
                            .vFindings_C1 = txtFindings.Text
                            .vFindingsStat_C1 = Findings
                            .vCACPI_C1 = txtCACPI.Text
                            .vLocation_1_C1 = txtLocation_1.Text
                            .vTCT_1_C1 = txtTCT_1.Text
                            .vArea_1_C1 = dArea_1.Value
                            .vPropertiesRemarks_1_C1 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C1 = txtLocation_2.Text
                            .vTCT_2_C1 = txtTCT_2.Text
                            .vArea_2_C1 = dArea_2.Value
                            .vPropertiesRemarks_2_C1 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C1 = txtVehicle_1.Text
                            .vYear_1_C1 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C1 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C1 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C1 = txtVehicle_2.Text
                            .vYear_2_C1 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C1 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C1 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C1 = txtOtherProperties.Text
                            .vNarrative_C1 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C1 = dTotalDisposable.Value
                            .vEx_Living_C1 = dLiving.Value
                            .vEx_Clothing_C1 = dClothing.Value
                            .vEx_Education_C1 = dEducation.Value
                            .vEx_Transportation_C1 = dTransportation.Value
                            .vEx_Lights_C1 = dLighths.Value
                            .vEx_Insurance_C1 = dInsurance.Value
                            .vEx_Amortization_C1 = dAmortization.Value
                            .vEx_Miscellaneous_C1 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C1 = dTotalExpenses.Value
                            .vEx_NetDisposable_C1 = dNetDisposable.Value
                            .vEx_TMFI_C1 = dTMFI.Value
                            .vEx_TMDI_C1 = dTMDI.Value
                            .vEx_Remarks_C1 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C1 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C1 = rOthers.Text.InsertQuote
                            .vC1_C1 = txtC1.Text
                            .vC2_C1 = txtC2.Text
                            .vC3_C1 = txtC3.Text
                            .vC4_C1 = txtC4.Text
                            .vC5_C1 = txtC5.Text
                            .vC6_C1 = txtC6.Text
                            .vC7_C1 = txtC7.Text
                            .vC8_C1 = txtC8.Text
                            .vC9_C1 = txtC9.Text

                            .ChangeSketchC1 = ChangeSketch
                            .SketchC1 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .ChangePic1 = False
                        ElseIf Rank = 2 Then
                            .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C2.Text = TxtLastN_C1.Text
                            .cbxSuffix_C2.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C2.Tag = ""
                            .TxtFirstN_C2.Tag = ""
                            .TxtMiddleN_C2.Tag = ""
                            .TxtLastN_C2.Tag = ""
                            .cbxSuffix_C2.Tag = ""

                            .vPrefix_C2 = CbxPrefix_C1.Text
                            .vFirstN_C2 = TxtFirstN_C1.Text
                            .vMiddleN_C2 = TxtMiddleN_C1.Text
                            .vLastN_C2 = TxtLastN_C1.Text
                            .vSuffix_C2 = cbxSuffix_C1.Text
                            .vNoC_C2 = txtNoC_C1.Text
                            .vStreetC_C2 = txtStreetC_C1.Text
                            .vBarangayC_C2 = txtBarangayC_C1.Text
                            .vAddressC_C2 = cbxAddressC_C1.Text
                            .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C2 = txtNoP_C1.Text
                            .vStreetP_C2 = txtStreetP_C1.Text
                            .vBarangayP_C2 = txtBarangayP_C1.Text
                            .vAddressP_C2 = cbxAddressP_C1.Text
                            .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C2 = DtpBirth_C1.Text
                            .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C2 = cbxMale_C1.Checked
                            .vFemale_C2 = cbxFemale_C1.Checked
                            .vSingle_C2 = cbxSingle_C1.Checked
                            .vMarried_C2 = cbxMarried_C1.Checked
                            .vSeparated_C2 = cbxSeparated_C1.Checked
                            .vWidowed_C2 = cbxWidowed_C1.Checked
                            .vCitizenship_C2 = txtCitizenship_C1.Text
                            .vTIN_C2 = txtTIN_C1.Text
                            .vTelephone_C2 = txtTelephone_C1.Text
                            .vSSS_C2 = txtSSS_C1.Text
                            .vMobile_C2 = txtMobile_C1.Text
                            .vEmail_C2 = txtEmail_C1.Text
                            .vOwned_C2 = cbxOwned_C1.Checked
                            .vFree_C2 = cbxFree_C1.Checked
                            .vRented_C2 = cbxRented_C1.Checked
                            .vRent_C2 = dRent_C1.Value
                            .vRelationship_C2 = cbxRelationship_C1.Text
                            .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C2 = cbxEmployer_C1.Text
                            .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                            .vPosition_C2 = cbxPosition_C1.Text
                            .vCasual_C2 = cbxCasual_C1.Checked
                            .vTemporary_C2 = cbxTemporary_C1.Checked
                            .vPermanent_C2 = cbxPermanent_C1.Checked
                            .vHired_C2 = dtpHired_C1.Value
                            .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C2 = txtSupervisor_C1.Text
                            .vSalary_C2 = dMonthly_C1.Value
                            .vBusinessName_C2 = txtBusinessName_C1.Text
                            .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C2 = iYrsOperation_C1.Value
                            .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                            .dSalary_C2.Value = dNetDisposable.Value
                            .vNoEmployees_C2 = iNoEmployees_C1.Value
                            .vCapital_C2 = dCapital_C1.Value
                            .vArea_C2 = txtArea_C1.Text
                            .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C2 = iOutlet_C1.Value
                            .vOtherIncome_C2 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C2 = dOtherIncome_C1.Value

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C2 = txtCreditor_1.Text
                            .vCreditAddress_1_C2 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C2 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C2 = iTerm_1.Value
                            .vAmountGranted_1_C2 = dAmountGranted_1.Value
                            .vBalance_1_C2 = dBalance_1.Value
                            .vCreditPayment_1_C2 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C2 = txtCreditRemarks_1.Text
                            .vCreditor_2_C2 = txtCreditor_2.Text
                            .vCreditAddress_2_C2 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C2 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C2 = iTerm_2.Value
                            .vAmountGranted_2_C2 = dAmountGranted_2.Value
                            .vBalance_2_C2 = dBalance_2.Value
                            .vCreditPayment_2_C2 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C2 = txtCreditRemarks_2.Text
                            .vBank_1_C2 = txtBank_1.Text
                            .vBranch_1_C2 = txtBranch_1.Text
                            .vAccountT_1_C2 = AccountT_1
                            .vSA_1_C2 = txtSA_1.Text
                            .vAverageBalance_1_C2 = dAverageBalance_1.Value
                            .vOpened_1_C2 = txtOpened_1.Text
                            .vBank_2_C2 = txtBank_2.Text
                            .vBranch_2_C2 = txtBranch_2.Text
                            .vAccountT_2_C2 = AccountT_2
                            .vSA_2_C2 = txtSA_2.Text
                            .vAverageBalance_2_C2 = dAverageBalance_2.Value
                            .vOpened_2_C2 = txtOpened_2.Text
                            .vCreditRating_C2 = CreditRating
                            .vRec_Remarks_C2 = rRecommendation.Text
                            .vTitle_C2 = txtTitle.Text
                            .vCaseNum_C2 = txtCaseNum.Text
                            .vDateFilled_C2 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C2 = cbxCourt.Text
                            .vCaseNature_C2 = cbxCaseNature.Text
                            .vAmountInvolved_C2 = dAmountInvolved.Value
                            .vCaseStatus_C2 = cbxCaseStatus.Text
                            .vFindings_C2 = txtFindings.Text
                            .vFindingsStat_C2 = Findings
                            .vCACPI_C2 = txtCACPI.Text
                            .vLocation_1_C2 = txtLocation_1.Text
                            .vTCT_1_C2 = txtTCT_1.Text
                            .vArea_1_C2 = dArea_1.Value
                            .vPropertiesRemarks_1_C2 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C2 = txtLocation_2.Text
                            .vTCT_2_C2 = txtTCT_2.Text
                            .vArea_2_C2 = dArea_2.Value
                            .vPropertiesRemarks_2_C2 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C2 = txtVehicle_1.Text
                            .vYear_1_C2 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C2 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C2 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C2 = txtVehicle_2.Text
                            .vYear_2_C2 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C2 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C2 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C2 = txtOtherProperties.Text
                            .vNarrative_C2 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C2 = dTotalDisposable.Value
                            .vEx_Living_C2 = dLiving.Value
                            .vEx_Clothing_C2 = dClothing.Value
                            .vEx_Education_C2 = dEducation.Value
                            .vEx_Transportation_C2 = dTransportation.Value
                            .vEx_Lights_C2 = dLighths.Value
                            .vEx_Insurance_C2 = dInsurance.Value
                            .vEx_Amortization_C2 = dAmortization.Value
                            .vEx_Miscellaneous_C2 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C2 = dTotalExpenses.Value
                            .vEx_NetDisposable_C2 = dNetDisposable.Value
                            .vEx_TMFI_C2 = dTMFI.Value
                            .vEx_TMDI_C2 = dTMDI.Value
                            .vEx_Remarks_C2 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C2 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C2 = rOthers.Text.InsertQuote
                            .vC1_C2 = txtC1.Text
                            .vC2_C2 = txtC2.Text
                            .vC3_C2 = txtC3.Text
                            .vC4_C2 = txtC4.Text
                            .vC5_C2 = txtC5.Text
                            .vC6_C2 = txtC6.Text
                            .vC7_C2 = txtC7.Text
                            .vC8_C2 = txtC8.Text
                            .vC9_C2 = txtC9.Text

                            .ChangeSketchC2 = ChangeSketch
                            .SketchC2 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .ChangePic2 = False
                        ElseIf Rank = 3 Then
                            .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C3.Text = TxtLastN_C1.Text
                            .cbxSuffix_C3.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C3.Tag = ""
                            .TxtFirstN_C3.Tag = ""
                            .TxtMiddleN_C3.Tag = ""
                            .TxtLastN_C3.Tag = ""
                            .cbxSuffix_C3.Tag = ""

                            .vPrefix_C3 = CbxPrefix_C1.Text
                            .vFirstN_C3 = TxtFirstN_C1.Text
                            .vMiddleN_C3 = TxtMiddleN_C1.Text
                            .vLastN_C3 = TxtLastN_C1.Text
                            .vSuffix_C3 = cbxSuffix_C1.Text
                            .vNoC_C3 = txtNoC_C1.Text
                            .vStreetC_C3 = txtStreetC_C1.Text
                            .vBarangayC_C3 = txtBarangayC_C1.Text
                            .vAddressC_C3 = cbxAddressC_C1.Text
                            .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C3 = txtNoP_C1.Text
                            .vStreetP_C3 = txtStreetP_C1.Text
                            .vBarangayP_C3 = txtBarangayP_C1.Text
                            .vAddressP_C3 = cbxAddressP_C1.Text
                            .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C3 = DtpBirth_C1.Text
                            .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C3 = cbxMale_C1.Checked
                            .vFemale_C3 = cbxFemale_C1.Checked
                            .vSingle_C3 = cbxSingle_C1.Checked
                            .vMarried_C3 = cbxMarried_C1.Checked
                            .vSeparated_C3 = cbxSeparated_C1.Checked
                            .vWidowed_C3 = cbxWidowed_C1.Checked
                            .vCitizenship_C3 = txtCitizenship_C1.Text
                            .vTIN_C3 = txtTIN_C1.Text
                            .vTelephone_C3 = txtTelephone_C1.Text
                            .vSSS_C3 = txtSSS_C1.Text
                            .vMobile_C3 = txtMobile_C1.Text
                            .vEmail_C3 = txtEmail_C1.Text
                            .vOwned_C3 = cbxOwned_C1.Checked
                            .vFree_C3 = cbxFree_C1.Checked
                            .vRented_C3 = cbxRented_C1.Checked
                            .vRent_C3 = dRent_C1.Value
                            .vRelationship_C3 = cbxRelationship_C1.Text
                            .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C3 = cbxEmployer_C1.Text
                            .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                            .vPosition_C3 = cbxPosition_C1.Text
                            .vCasual_C3 = cbxCasual_C1.Checked
                            .vTemporary_C3 = cbxTemporary_C1.Checked
                            .vPermanent_C3 = cbxPermanent_C1.Checked
                            .vHired_C3 = dtpHired_C1.Value
                            .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C3 = txtSupervisor_C1.Text
                            .vSalary_C3 = dMonthly_C1.Value
                            .vBusinessName_C3 = txtBusinessName_C1.Text
                            .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C3 = iYrsOperation_C1.Value
                            .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                            .dSalary_C3.Value = dNetDisposable.Value
                            .vNoEmployees_C3 = iNoEmployees_C1.Value
                            .vCapital_C3 = dCapital_C1.Value
                            .vArea_C3 = txtArea_C1.Text
                            .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C3 = iOutlet_C1.Value
                            .vOtherIncome_C3 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C3 = dOtherIncome_C1.Value

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C3 = txtCreditor_1.Text
                            .vCreditAddress_1_C3 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C3 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C3 = iTerm_1.Value
                            .vAmountGranted_1_C3 = dAmountGranted_1.Value
                            .vBalance_1_C3 = dBalance_1.Value
                            .vCreditPayment_1_C3 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C3 = txtCreditRemarks_1.Text
                            .vCreditor_2_C3 = txtCreditor_2.Text
                            .vCreditAddress_2_C3 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C3 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C3 = iTerm_2.Value
                            .vAmountGranted_2_C3 = dAmountGranted_2.Value
                            .vBalance_2_C3 = dBalance_2.Value
                            .vCreditPayment_2_C3 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C3 = txtCreditRemarks_2.Text
                            .vBank_1_C3 = txtBank_1.Text
                            .vBranch_1_C3 = txtBranch_1.Text
                            .vAccountT_1_C3 = AccountT_1
                            .vSA_1_C3 = txtSA_1.Text
                            .vAverageBalance_1_C3 = dAverageBalance_1.Value
                            .vOpened_1_C3 = txtOpened_1.Text
                            .vBank_2_C3 = txtBank_2.Text
                            .vBranch_2_C3 = txtBranch_2.Text
                            .vAccountT_2_C3 = AccountT_2
                            .vSA_2_C3 = txtSA_2.Text
                            .vAverageBalance_2_C3 = dAverageBalance_2.Value
                            .vOpened_2_C3 = txtOpened_2.Text
                            .vCreditRating_C3 = CreditRating
                            .vRec_Remarks_C3 = rRecommendation.Text
                            .vTitle_C3 = txtTitle.Text
                            .vCaseNum_C3 = txtCaseNum.Text
                            .vDateFilled_C3 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C3 = cbxCourt.Text
                            .vCaseNature_C3 = cbxCaseNature.Text
                            .vAmountInvolved_C3 = dAmountInvolved.Value
                            .vCaseStatus_C3 = cbxCaseStatus.Text
                            .vFindings_C3 = txtFindings.Text
                            .vFindingsStat_C3 = Findings
                            .vCACPI_C3 = txtCACPI.Text
                            .vLocation_1_C3 = txtLocation_1.Text
                            .vTCT_1_C3 = txtTCT_1.Text
                            .vArea_1_C3 = dArea_1.Value
                            .vPropertiesRemarks_1_C3 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C3 = txtLocation_2.Text
                            .vTCT_2_C3 = txtTCT_2.Text
                            .vArea_2_C3 = dArea_2.Value
                            .vPropertiesRemarks_2_C3 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C3 = txtVehicle_1.Text
                            .vYear_1_C3 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C3 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C3 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C3 = txtVehicle_2.Text
                            .vYear_2_C3 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C3 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C3 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C3 = txtOtherProperties.Text
                            .vNarrative_C3 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C3 = dTotalDisposable.Value
                            .vEx_Living_C3 = dLiving.Value
                            .vEx_Clothing_C3 = dClothing.Value
                            .vEx_Education_C3 = dEducation.Value
                            .vEx_Transportation_C3 = dTransportation.Value
                            .vEx_Lights_C3 = dLighths.Value
                            .vEx_Insurance_C3 = dInsurance.Value
                            .vEx_Amortization_C3 = dAmortization.Value
                            .vEx_Miscellaneous_C3 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C3 = dTotalExpenses.Value
                            .vEx_NetDisposable_C3 = dNetDisposable.Value
                            .vEx_TMFI_C3 = dTMFI.Value
                            .vEx_TMDI_C3 = dTMDI.Value
                            .vEx_Remarks_C3 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C3 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C3 = rOthers.Text.InsertQuote
                            .vC1_C3 = txtC1.Text
                            .vC2_C3 = txtC2.Text
                            .vC3_C3 = txtC3.Text
                            .vC4_C3 = txtC4.Text
                            .vC5_C3 = txtC5.Text
                            .vC6_C3 = txtC6.Text
                            .vC7_C3 = txtC7.Text
                            .vC8_C3 = txtC8.Text
                            .vC9_C3 = txtC9.Text

                            .ChangeSketchC3 = ChangeSketch
                            .SketchC3 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .ChangePic3 = False
                        ElseIf Rank = 4 Then
                            .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C4.Text = TxtLastN_C1.Text
                            .cbxSuffix_C4.Text = cbxSuffix_C1.Text
                            .CbxPrefix_C4.Tag = ""
                            .TxtFirstN_C4.Tag = ""
                            .TxtMiddleN_C4.Tag = ""
                            .TxtLastN_C4.Tag = ""
                            .cbxSuffix_C4.Tag = ""

                            .vPrefix_C4 = CbxPrefix_C1.Text
                            .vFirstN_C4 = TxtFirstN_C1.Text
                            .vMiddleN_C4 = TxtMiddleN_C1.Text
                            .vLastN_C4 = TxtLastN_C1.Text
                            .vSuffix_C4 = cbxSuffix_C1.Text
                            .vNoC_C4 = txtNoC_C1.Text
                            .vStreetC_C4 = txtStreetC_C1.Text
                            .vBarangayC_C4 = txtBarangayC_C1.Text
                            .vAddressC_C4 = cbxAddressC_C1.Text
                            .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C4 = txtNoP_C1.Text
                            .vStreetP_C4 = txtStreetP_C1.Text
                            .vBarangayP_C4 = txtBarangayP_C1.Text
                            .vAddressP_C4 = cbxAddressP_C1.Text
                            .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C4 = DtpBirth_C1.Text
                            .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C4 = cbxMale_C1.Checked
                            .vFemale_C4 = cbxFemale_C1.Checked
                            .vSingle_C4 = cbxSingle_C1.Checked
                            .vMarried_C4 = cbxMarried_C1.Checked
                            .vSeparated_C4 = cbxSeparated_C1.Checked
                            .vWidowed_C4 = cbxWidowed_C1.Checked
                            .vCitizenship_C4 = txtCitizenship_C1.Text
                            .vTIN_C4 = txtTIN_C1.Text
                            .vTelephone_C4 = txtTelephone_C1.Text
                            .vSSS_C4 = txtSSS_C1.Text
                            .vMobile_C4 = txtMobile_C1.Text
                            .vEmail_C4 = txtEmail_C1.Text
                            .vOwned_C4 = cbxOwned_C1.Checked
                            .vFree_C4 = cbxFree_C1.Checked
                            .vRented_C4 = cbxRented_C1.Checked
                            .vRent_C4 = dRent_C1.Value
                            .vRelationship_C4 = cbxRelationship_C1.Text
                            .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .vEmployer_C4 = cbxEmployer_C1.Text
                            .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                            .vPosition_C4 = cbxPosition_C1.Text
                            .vCasual_C4 = cbxCasual_C1.Checked
                            .vTemporary_C4 = cbxTemporary_C1.Checked
                            .vPermanent_C4 = cbxPermanent_C1.Checked
                            .vHired_C4 = dtpHired_C1.Value
                            .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C4 = txtSupervisor_C1.Text
                            .vSalary_C4 = dMonthly_C1.Value
                            .vBusinessName_C4 = txtBusinessName_C1.Text
                            .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C4 = iYrsOperation_C1.Value
                            .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                            .dSalary_C4.Value = dNetDisposable.Value
                            .vNoEmployees_C4 = iNoEmployees_C1.Value
                            .vCapital_C4 = dCapital_C1.Value
                            .vArea_C4 = txtArea_C1.Text
                            .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C4 = iOutlet_C1.Value
                            .vOtherIncome_C4 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C4 = dOtherIncome_C1.Value

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C4 = txtCreditor_1.Text
                            .vCreditAddress_1_C4 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C4 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C4 = iTerm_1.Value
                            .vAmountGranted_1_C4 = dAmountGranted_1.Value
                            .vBalance_1_C4 = dBalance_1.Value
                            .vCreditPayment_1_C4 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C4 = txtCreditRemarks_1.Text
                            .vCreditor_2_C4 = txtCreditor_2.Text
                            .vCreditAddress_2_C4 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C4 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C4 = iTerm_2.Value
                            .vAmountGranted_2_C4 = dAmountGranted_2.Value
                            .vBalance_2_C4 = dBalance_2.Value
                            .vCreditPayment_2_C4 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C4 = txtCreditRemarks_2.Text
                            .vBank_1_C4 = txtBank_1.Text
                            .vBranch_1_C4 = txtBranch_1.Text
                            .vAccountT_1_C4 = AccountT_1
                            .vSA_1_C4 = txtSA_1.Text
                            .vAverageBalance_1_C4 = dAverageBalance_1.Value
                            .vOpened_1_C4 = txtOpened_1.Text
                            .vBank_2_C4 = txtBank_2.Text
                            .vBranch_2_C4 = txtBranch_2.Text
                            .vAccountT_2_C4 = AccountT_2
                            .vSA_2_C4 = txtSA_2.Text
                            .vAverageBalance_2_C4 = dAverageBalance_2.Value
                            .vOpened_2_C4 = txtOpened_2.Text
                            .vCreditRating_C4 = CreditRating
                            .vRec_Remarks_C4 = rRecommendation.Text
                            .vTitle_C4 = txtTitle.Text
                            .vCaseNum_C4 = txtCaseNum.Text
                            .vDateFilled_C4 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C4 = cbxCourt.Text
                            .vCaseNature_C4 = cbxCaseNature.Text
                            .vAmountInvolved_C4 = dAmountInvolved.Value
                            .vCaseStatus_C4 = cbxCaseStatus.Text
                            .vFindings_C4 = txtFindings.Text
                            .vFindingsStat_C4 = Findings
                            .vCACPI_C4 = txtCACPI.Text
                            .vLocation_1_C4 = txtLocation_1.Text
                            .vTCT_1_C4 = txtTCT_1.Text
                            .vArea_1_C4 = dArea_1.Value
                            .vPropertiesRemarks_1_C4 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C4 = txtLocation_2.Text
                            .vTCT_2_C4 = txtTCT_2.Text
                            .vArea_2_C4 = dArea_2.Value
                            .vPropertiesRemarks_2_C4 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C4 = txtVehicle_1.Text
                            .vYear_1_C4 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C4 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C4 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C4 = txtVehicle_2.Text
                            .vYear_2_C4 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C4 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C4 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C4 = txtOtherProperties.Text
                            .vNarrative_C4 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C4 = dTotalDisposable.Value
                            .vEx_Living_C4 = dLiving.Value
                            .vEx_Clothing_C4 = dClothing.Value
                            .vEx_Education_C4 = dEducation.Value
                            .vEx_Transportation_C4 = dTransportation.Value
                            .vEx_Lights_C4 = dLighths.Value
                            .vEx_Insurance_C4 = dInsurance.Value
                            .vEx_Amortization_C4 = dAmortization.Value
                            .vEx_Miscellaneous_C4 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C4 = dTotalExpenses.Value
                            .vEx_NetDisposable_C4 = dNetDisposable.Value
                            .vEx_TMFI_C4 = dTMFI.Value
                            .vEx_TMDI_C4 = dTMDI.Value
                            .vEx_Remarks_C4 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C4 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C4 = rOthers.Text.InsertQuote
                            .vC1_C4 = txtC1.Text
                            .vC2_C4 = txtC2.Text
                            .vC3_C4 = txtC3.Text
                            .vC4_C4 = txtC4.Text
                            .vC5_C4 = txtC5.Text
                            .vC6_C4 = txtC6.Text
                            .vC7_C4 = txtC7.Text
                            .vC8_C4 = txtC8.Text
                            .vC9_C4 = txtC9.Text

                            .ChangeSketchC4 = ChangeSketch
                            .SketchC4 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .ChangePic4 = False
                        End If
                    End With
                End If

                MsgBox("Successfully Cancel", MsgBoxStyle.Information, "Info")
                If FromCreditApplication Then
                    FrmLoanApplication.LoadData()
                Else
                    FrmCreditInvestigation.LoadData()
                End If
                btnDelete.DialogResult = DialogResult.OK
                btnDelete.PerformClick()
                Cursor = Cursors.Default
                Close()
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
        Dim CoMaker As New RptCoMakersStatement
        With CoMaker
            .lblLoanNumber.Text = If(TxtFirstN_C1.Text.Trim = "", "", CreditNumber)
            .lblAmountWords.Text = If(TxtFirstN_C1.Text.Trim = "", "", ConvertNumberToWords(AmountApplied, False, False))
            .lblAmount.Text = If(TxtFirstN_C1.Text.Trim = "", "", FormatNumber(AmountApplied, 2))
            .p_CoMaker.Image = pb_C1.Image.Clone
            .lblBorrowerID.Text = If(TxtFirstN_C1.Text.Trim = "", "", BorrowerID)
            .lblBorrower.Text = If(TxtFirstN_C1.Text.Trim = "", "", BorrowerName)
            .lblComaker.Text = If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")
            .lblCompleteAdd.Text = If(txtNoC_C1.Text.Trim = "", "", txtNoC_C1.Text.Trim & " ") & If(txtStreetC_C1.Text.Trim = "", "", txtStreetC_C1.Text.Trim & " ") & If(txtBarangayC_C1.Text.Trim = "", "", txtBarangayC_C1.Text.Trim & " ") & If(cbxAddressC_C1.Text.Trim = "", "", cbxAddressC_C1.Text.Trim & " ")
            .lblProvincialAdd.Text = If(txtNoP_C1.Text.Trim = "", "", txtNoP_C1.Text.Trim & " ") & If(txtStreetP_C1.Text.Trim = "", "", txtStreetP_C1.Text.Trim & " ") & If(txtBarangayP_C1.Text.Trim = "", "", txtBarangayP_C1.Text.Trim & " ") & If(cbxAddressP_C1.Text.Trim = "", "", cbxAddressP_C1.Text.Trim & " ")
            .lblBirthDate.Text = DtpBirth_C1.Text
            .lblBirthPlace.Text = cbxPlaceBirth_C1.Text
            .cbxMale.Checked = cbxMale_C1.Checked
            .cbxFemale.Checked = cbxFemale_C1.Checked
            .cbxSingle.Checked = cbxSingle_C1.Checked
            .cbxMarried.Checked = cbxMarried_C1.Checked
            .cbxSeparated.Checked = cbxSeparated_C1.Checked
            .cbxWidowed.Checked = cbxWidowed_C1.Checked
            .lblCitizenship.Text = txtCitizenship_C1.Text
            .lblTIN.Text = txtTIN_C1.Text
            .lblTelephone.Text = txtTelephone_C1.Text
            .lblSSS.Text = txtSSS_C1.Text
            .lblMobile.Text = txtMobile_C1.Text
            .lblEmail.Text = txtEmail_C1.Text
            .cbxOwned.Checked = cbxOwned_C1.Checked
            .cbxFree.Checked = cbxFree_C1.Checked
            .cbxRented.Checked = cbxRented_C1.Checked
            .lblRent.Text = If(cbxRented_C1.Checked, dRent_C1.Text & " / month", "")
            .lblEmployer.Text = cbxEmployer_C1.Text
            .lblEmployerAddress.Text = txtEmployerAddress_C1.Text
            .lblEmployerTel.Text = txtEmployerTelephone_C1.Text
            .lblPosition.Text = cbxPosition_C1.Text
            .cbxCasual.Checked = cbxCasual_C1.Checked
            .cbxTemporary.Checked = cbxTemporary_C1.Checked
            .cbxPermanent.Checked = cbxPermanent_C1.Checked
            .lblDateHired.Text = dtpHired_C1.Text
            .lblSupervisor.Text = txtSupervisor_C1.Text
            .lblMonthlyIncome.Text = dMonthly_C1.Text
            .lblBusiness.Text = txtBusinessName_C1.Text
            .lblBusinessAddress.Text = txtBusinessAddress_C1.Text
            .lblBusinessTel.Text = txtBusinessTelephone_C1.Text
            .lblNature.Text = cbxNatureBusiness_C1.Text
            .lblYearsOperation.Text = iYrsOperation_C1.Text
            .lblBusinessIncome.Text = dBusinessIncome_C1.Text
            .lblNoEmployees.Text = iNoEmployees_C1.Text
            .lblCapital.Text = dCapital_C1.Text
            .lblCoverageArea.Text = txtArea_C1.Text
            .lblExpiry.Text = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
            .lblOutlet.Text = iOutlet_C1.Text
            .lblOtherIncome.Text = txtOtherIncome_C1.Text
            .lblOtherMonthlyIncome.Text = dOtherIncome_C1.Text
            .lblDateSigned.Text = ""
            .lblSignature_1.Text = ""
            .lblSignature_2.Text = ""
            '2nd Copy
            .p_CoMaker_2.Image = pb_C1.Image.Clone
            .lblLoanNumber_2.Text = If(TxtFirstN_C1.Text.Trim = "", "", CreditNumber)
            .lblBorrowerID_2.Text = If(TxtFirstN_C1.Text.Trim = "", "", BorrowerID)
            .lblComaker_2.Text = If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")
            .lblCompleteAdd_2.Text = If(txtNoC_C1.Text.Trim = "", "", txtNoC_C1.Text.Trim & " ") & If(txtStreetC_C1.Text.Trim = "", "", txtStreetC_C1.Text.Trim & " ") & If(txtBarangayC_C1.Text.Trim = "", "", txtBarangayC_C1.Text.Trim & " ") & If(cbxAddressC_C1.Text.Trim = "", "", cbxAddressC_C1.Text.Trim & " ")
            .lblProvincialAdd_2.Text = If(txtNoP_C1.Text.Trim = "", "", txtNoP_C1.Text.Trim & " ") & If(txtStreetP_C1.Text.Trim = "", "", txtStreetP_C1.Text.Trim & " ") & If(txtBarangayP_C1.Text.Trim = "", "", txtBarangayP_C1.Text.Trim & " ") & If(cbxAddressP_C1.Text.Trim = "", "", cbxAddressP_C1.Text.Trim & " ")
            .lblBirthDate_2.Text = DtpBirth_C1.Text
            .lblBirthPlace_2.Text = cbxPlaceBirth_C1.Text
            .cbxMale_2.Checked = cbxMale_C1.Checked
            .cbxFemale_2.Checked = cbxFemale_C1.Checked
            .cbxSingle_2.Checked = cbxSingle_C1.Checked
            .cbxMarried_2.Checked = cbxMarried_C1.Checked
            .cbxSeparated_2.Checked = cbxSeparated_C1.Checked
            .cbxWidowed_2.Checked = cbxWidowed_C1.Checked
            .lblCitizenship_2.Text = txtCitizenship_C1.Text
            .lblTIN_2.Text = txtTIN_C1.Text
            .lblTelephone_2.Text = txtTelephone_C1.Text
            .lblSSS_2.Text = txtSSS_C1.Text
            .lblMobile_2.Text = txtMobile_C1.Text
            .lblEmail_2.Text = txtEmail_C1.Text
            .cbxOwned_2.Checked = cbxOwned_C1.Checked
            .cbxFree_2.Checked = cbxFree_C1.Checked
            .cbxRented_2.Checked = cbxRented_C1.Checked
            .lblRent_2.Text = If(cbxRented_C1.Checked, dRent_C1.Text & " / month", "")
            .lblEmployer_2.Text = cbxEmployer_C1.Text
            .lblEmployerAddress_2.Text = txtEmployerAddress_C1.Text
            .lblEmployerTel_2.Text = txtEmployerTelephone_C1.Text
            .lblPosition_2.Text = cbxPosition_C1.Text
            .cbxCasual_2.Checked = cbxCasual_C1.Checked
            .cbxTemporary_2.Checked = cbxTemporary_C1.Checked
            .cbxPermanent_2.Checked = cbxPermanent_C1.Checked
            .lblDateHired_2.Text = dtpHired_C1.Text
            .lblSupervisor_2.Text = txtSupervisor_C1.Text
            .lblMonthlyIncome_2.Text = dMonthly_C1.Text
            .lblBusiness_2.Text = txtBusinessName_C1.Text
            .lblBusinessAddress_2.Text = txtBusinessAddress_C1.Text
            .lblBusinessTel_2.Text = txtBusinessTelephone_C1.Text
            .lblNature_2.Text = cbxNatureBusiness_C1.Text
            .lblYearsOperation_2.Text = iYrsOperation_C1.Text
            .lblBusinessIncome_2.Text = dBusinessIncome_C1.Text
            .lblNoEmployees_2.Text = iNoEmployees_C1.Text
            .lblCapital_2.Text = dCapital_C1.Text
            .lblCoverageArea_2.Text = txtArea_C1.Text
            .lblExpiry_2.Text = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
            .lblOutlet_2.Text = iOutlet_C1.Text
            .lblOtherIncome_2.Text = txtOtherIncome_C1.Text
            .lblOtherMonthlyIncome_2.Text = dOtherIncome_C1.Text
            .lblDateSigned_2.Text = ""
            .lblSignature_3.Text = ""
            .lblSignature_4.Text = ""
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.Yes Then
        Else
            If TxtFirstN_C1.Text = "" Then
                MsgBox("Please fill the comaker's first name.", MsgBoxStyle.Information, "Info")
                TxtFirstN_C1.Focus()
                Exit Sub
            End If
            If TxtLastN_C1.Text = "" Then
                MsgBox("Please fill the comaker's last name.", MsgBoxStyle.Information, "Info")
                TxtLastN_C1.Focus()
                Exit Sub
            End If
            If DateValue(DtpBirth_C1.Value.AddYears(18)) > DateValue(Date.Now) Then
                If MsgBoxYes("CoMaker's age is below 18 years old, are you sure you would like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            ElseIf DateValue(DtpBirth_C1.Value.AddYears(61)) <= DateValue(Date.Now) Then
                If MsgBoxYes("CoMaker's age is 61 or above, are you sure you would like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim Gender_C1 As String = ""
            If cbxMale_C1.Checked Then
                Gender_C1 = "Male"
            ElseIf cbxFemale_C1.Checked Then
                Gender_C1 = "Female"
            End If
            Dim Civil_C1 As String = ""
            If cbxSingle_C1.Checked Then
                Civil_C1 = "Single"
            ElseIf cbxMarried_C1.Checked Then
                Civil_C1 = "Married"
            ElseIf cbxSeparated_C1.Checked Then
                Civil_C1 = "Separated"
            ElseIf cbxWidowed_C1.Checked Then
                Civil_C1 = "Widowed"
            End If
            Dim House_C1 As String = ""
            If cbxOwned_C1.Checked Then
                House_C1 = "Owned"
            ElseIf cbxFree_C1.Checked Then
                House_C1 = "Free"
            ElseIf cbxRented_C1.Checked Then
                House_C1 = "Rented"
            End If
            Dim EmplStatus_C1 As String = ""
            If cbxCasual_C1.Checked Then
                EmplStatus_C1 = "Casual"
            ElseIf cbxTemporary_C1.Checked Then
                EmplStatus_C1 = "Temporary"
            ElseIf cbxPermanent_C1.Checked Then
                EmplStatus_C1 = "Permanent"
            End If

            Dim RelationID As Integer = 0
            If cbxRelationship_C1.SelectedIndex = -1 Or cbxRelationship_C1.Text = "" Then
            Else
                RelationID = cbxRelationship_C1.SelectedValue
            End If

            If btnSave.Text = "&Save" Then
                If FromCreditApplication Then
                    If Rank = 1 Then
                        If TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 2 Then
                        If TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 3 Then
                        If TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 4 Then
                        If TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmLoanApplication.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmLoanApplication.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmLoanApplication.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    End If
                Else
                    If Rank = 1 Then
                        If TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 2 Then
                        If TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 3 Then
                        If TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C4.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C4.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C4.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 4. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    ElseIf Rank = 4 Then
                        If TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C1.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C1.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C1.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 1. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C2.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C2.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C2.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 2. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        ElseIf TxtFirstN_C1.Text = FrmCreditInvestigation.TxtFirstN_C3.Text And TxtLastN_C1.Text = FrmCreditInvestigation.TxtLastN_C3.Text And cbxSuffix_C1.Text = FrmCreditInvestigation.cbxSuffix_C3.Text Then
                            MsgBox(String.Format("{0} is already saved as CoMaker 3. Please check your data.", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")))
                            Exit Sub
                        End If
                    End If
                End If
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    If Rank = 1 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C1.Text = TxtLastN_C1.Text
                            .cbxSuffix_C1.Text = cbxSuffix_C1.Text

                            .ReferenceID_1 = ReferenceID
                            .vPrefix_C1 = CbxPrefix_C1.Text
                            .vFirstN_C1 = TxtFirstN_C1.Text
                            .vMiddleN_C1 = TxtMiddleN_C1.Text
                            .vLastN_C1 = TxtLastN_C1.Text
                            .vSuffix_C1 = cbxSuffix_C1.Text
                            .vNoC_C1 = txtNoC_C1.Text
                            .vStreetC_C1 = txtStreetC_C1.Text
                            .vBarangayC_C1 = txtBarangayC_C1.Text
                            .vAddressC_C1 = cbxAddressC_C1.Text
                            .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C1 = txtNoP_C1.Text
                            .vStreetP_C1 = txtStreetP_C1.Text
                            .vBarangayP_C1 = txtBarangayP_C1.Text
                            .vAddressP_C1 = cbxAddressP_C1.Text
                            .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C1 = DtpBirth_C1.Text
                            .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C1 = cbxMale_C1.Checked
                            .vFemale_C1 = cbxFemale_C1.Checked
                            .vSingle_C1 = cbxSingle_C1.Checked
                            .vMarried_C1 = cbxMarried_C1.Checked
                            .vSeparated_C1 = cbxSeparated_C1.Checked
                            .vWidowed_C1 = cbxWidowed_C1.Checked
                            .vCitizenship_C1 = txtCitizenship_C1.Text
                            .vTIN_C1 = txtTIN_C1.Text
                            .vTelephone_C1 = txtTelephone_C1.Text
                            .vSSS_C1 = txtSSS_C1.Text
                            .vMobile_C1 = txtMobile_C1.Text
                            .vEmail_C1 = txtEmail_C1.Text
                            .vOwned_C1 = cbxOwned_C1.Checked
                            .vFree_C1 = cbxFree_C1.Checked
                            .vRented_C1 = cbxRented_C1.Checked
                            .vRent_C1 = dRent_C1.Value
                            .vRelationship_C1 = cbxRelationship_C1.Text
                            .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker1.Image = pb_C1.Image.Clone
                            .vEmployer_C1 = cbxEmployer_C1.Text
                            .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                            .vPosition_C1 = cbxPosition_C1.Text
                            .vCasual_C1 = cbxCasual_C1.Checked
                            .vTemporary_C1 = cbxTemporary_C1.Checked
                            .vPermanent_C1 = cbxPermanent_C1.Checked
                            .vHired_C1 = dtpHired_C1.Value
                            .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C1 = txtSupervisor_C1.Text
                            .vSalary_C1 = dMonthly_C1.Value
                            .vBusinessName_C1 = txtBusinessName_C1.Text
                            .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C1 = iYrsOperation_C1.Value
                            .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                            .vNoEmployees_C1 = iNoEmployees_C1.Value
                            .vCapital_C1 = dCapital_C1.Value
                            .vArea_C1 = txtArea_C1.Text
                            .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C1 = iOutlet_C1.Value
                            .vOtherIncome_C1 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C1 = dOtherIncome_C1.Value
                            .ChangePic1 = ChangeCoMaker1Pic
                            .Industry_C1 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 2 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C2.Text = TxtLastN_C1.Text
                            .cbxSuffix_C2.Text = cbxSuffix_C1.Text

                            .ReferenceID_2 = ReferenceID
                            .vPrefix_C2 = CbxPrefix_C1.Text
                            .vFirstN_C2 = TxtFirstN_C1.Text
                            .vMiddleN_C2 = TxtMiddleN_C1.Text
                            .vLastN_C2 = TxtLastN_C1.Text
                            .vSuffix_C2 = cbxSuffix_C1.Text
                            .vNoC_C2 = txtNoC_C1.Text
                            .vStreetC_C2 = txtStreetC_C1.Text
                            .vBarangayC_C2 = txtBarangayC_C1.Text
                            .vAddressC_C2 = cbxAddressC_C1.Text
                            .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C2 = txtNoP_C1.Text
                            .vStreetP_C2 = txtStreetP_C1.Text
                            .vBarangayP_C2 = txtBarangayP_C1.Text
                            .vAddressP_C2 = cbxAddressP_C1.Text
                            .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C2 = DtpBirth_C1.Text
                            .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C2 = cbxMale_C1.Checked
                            .vFemale_C2 = cbxFemale_C1.Checked
                            .vSingle_C2 = cbxSingle_C1.Checked
                            .vMarried_C2 = cbxMarried_C1.Checked
                            .vSeparated_C2 = cbxSeparated_C1.Checked
                            .vWidowed_C2 = cbxWidowed_C1.Checked
                            .vCitizenship_C2 = txtCitizenship_C1.Text
                            .vTIN_C2 = txtTIN_C1.Text
                            .vTelephone_C2 = txtTelephone_C1.Text
                            .vSSS_C2 = txtSSS_C1.Text
                            .vMobile_C2 = txtMobile_C1.Text
                            .vEmail_C2 = txtEmail_C1.Text
                            .vOwned_C2 = cbxOwned_C1.Checked
                            .vFree_C2 = cbxFree_C1.Checked
                            .vRented_C2 = cbxRented_C1.Checked
                            .vRent_C2 = dRent_C1.Value
                            .vRelationship_C2 = cbxRelationship_C1.Text
                            .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker2.Image = pb_C1.Image.Clone
                            .vEmployer_C2 = cbxEmployer_C1.Text
                            .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                            .vPosition_C2 = cbxPosition_C1.Text
                            .vCasual_C2 = cbxCasual_C1.Checked
                            .vTemporary_C2 = cbxTemporary_C1.Checked
                            .vPermanent_C2 = cbxPermanent_C1.Checked
                            .vHired_C2 = dtpHired_C1.Value
                            .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C2 = txtSupervisor_C1.Text
                            .vSalary_C2 = dMonthly_C1.Value
                            .vBusinessName_C2 = txtBusinessName_C1.Text
                            .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C2 = iYrsOperation_C1.Value
                            .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                            .vNoEmployees_C2 = iNoEmployees_C1.Value
                            .vCapital_C2 = dCapital_C1.Value
                            .vArea_C2 = txtArea_C1.Text
                            .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C2 = iOutlet_C1.Value
                            .vOtherIncome_C2 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C2 = dOtherIncome_C1.Value
                            .ChangePic2 = ChangeCoMaker1Pic
                            .Industry_C2 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 3 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C3.Text = TxtLastN_C1.Text
                            .cbxSuffix_C3.Text = cbxSuffix_C1.Text

                            .ReferenceID_3 = ReferenceID
                            .vPrefix_C3 = CbxPrefix_C1.Text
                            .vFirstN_C3 = TxtFirstN_C1.Text
                            .vMiddleN_C3 = TxtMiddleN_C1.Text
                            .vLastN_C3 = TxtLastN_C1.Text
                            .vSuffix_C3 = cbxSuffix_C1.Text
                            .vNoC_C3 = txtNoC_C1.Text
                            .vStreetC_C3 = txtStreetC_C1.Text
                            .vBarangayC_C3 = txtBarangayC_C1.Text
                            .vAddressC_C3 = cbxAddressC_C1.Text
                            .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C3 = txtNoP_C1.Text
                            .vStreetP_C3 = txtStreetP_C1.Text
                            .vBarangayP_C3 = txtBarangayP_C1.Text
                            .vAddressP_C3 = cbxAddressP_C1.Text
                            .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C3 = DtpBirth_C1.Text
                            .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C3 = cbxMale_C1.Checked
                            .vFemale_C3 = cbxFemale_C1.Checked
                            .vSingle_C3 = cbxSingle_C1.Checked
                            .vMarried_C3 = cbxMarried_C1.Checked
                            .vSeparated_C3 = cbxSeparated_C1.Checked
                            .vWidowed_C3 = cbxWidowed_C1.Checked
                            .vCitizenship_C3 = txtCitizenship_C1.Text
                            .vTIN_C3 = txtTIN_C1.Text
                            .vTelephone_C3 = txtTelephone_C1.Text
                            .vSSS_C3 = txtSSS_C1.Text
                            .vMobile_C3 = txtMobile_C1.Text
                            .vEmail_C3 = txtEmail_C1.Text
                            .vOwned_C3 = cbxOwned_C1.Checked
                            .vFree_C3 = cbxFree_C1.Checked
                            .vRented_C3 = cbxRented_C1.Checked
                            .vRent_C3 = dRent_C1.Value
                            .vRelationship_C3 = cbxRelationship_C1.Text
                            .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker3.Image = pb_C1.Image.Clone
                            .vEmployer_C3 = cbxEmployer_C1.Text
                            .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                            .vPosition_C3 = cbxPosition_C1.Text
                            .vCasual_C3 = cbxCasual_C1.Checked
                            .vTemporary_C3 = cbxTemporary_C1.Checked
                            .vPermanent_C3 = cbxPermanent_C1.Checked
                            .vHired_C3 = dtpHired_C1.Value
                            .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C3 = txtSupervisor_C1.Text
                            .vSalary_C3 = dMonthly_C1.Value
                            .vBusinessName_C3 = txtBusinessName_C1.Text
                            .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C3 = iYrsOperation_C1.Value
                            .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                            .vNoEmployees_C3 = iNoEmployees_C1.Value
                            .vCapital_C3 = dCapital_C1.Value
                            .vArea_C3 = txtArea_C1.Text
                            .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C3 = iOutlet_C1.Value
                            .vOtherIncome_C3 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C3 = dOtherIncome_C1.Value
                            .ChangePic3 = ChangeCoMaker1Pic
                            .Industry_C3 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 4 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C4.Text = TxtLastN_C1.Text
                            .cbxSuffix_C4.Text = cbxSuffix_C1.Text

                            .ReferenceID_4 = ReferenceID
                            .vPrefix_C4 = CbxPrefix_C1.Text
                            .vFirstN_C4 = TxtFirstN_C1.Text
                            .vMiddleN_C4 = TxtMiddleN_C1.Text
                            .vLastN_C4 = TxtLastN_C1.Text
                            .vSuffix_C4 = cbxSuffix_C1.Text
                            .vNoC_C4 = txtNoC_C1.Text
                            .vStreetC_C4 = txtStreetC_C1.Text
                            .vBarangayC_C4 = txtBarangayC_C1.Text
                            .vAddressC_C4 = cbxAddressC_C1.Text
                            .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C4 = txtNoP_C1.Text
                            .vStreetP_C4 = txtStreetP_C1.Text
                            .vBarangayP_C4 = txtBarangayP_C1.Text
                            .vAddressP_C4 = cbxAddressP_C1.Text
                            .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C4 = DtpBirth_C1.Text
                            .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C4 = cbxMale_C1.Checked
                            .vFemale_C4 = cbxFemale_C1.Checked
                            .vSingle_C4 = cbxSingle_C1.Checked
                            .vMarried_C4 = cbxMarried_C1.Checked
                            .vSeparated_C4 = cbxSeparated_C1.Checked
                            .vWidowed_C4 = cbxWidowed_C1.Checked
                            .vCitizenship_C4 = txtCitizenship_C1.Text
                            .vTIN_C4 = txtTIN_C1.Text
                            .vTelephone_C4 = txtTelephone_C1.Text
                            .vSSS_C4 = txtSSS_C1.Text
                            .vMobile_C4 = txtMobile_C1.Text
                            .vEmail_C4 = txtEmail_C1.Text
                            .vOwned_C4 = cbxOwned_C1.Checked
                            .vFree_C4 = cbxFree_C1.Checked
                            .vRented_C4 = cbxRented_C1.Checked
                            .vRent_C4 = dRent_C1.Value
                            .vRelationship_C4 = cbxRelationship_C1.Text
                            .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker4.Image = pb_C1.Image.Clone
                            .vEmployer_C4 = cbxEmployer_C1.Text
                            .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                            .vPosition_C4 = cbxPosition_C1.Text
                            .vCasual_C4 = cbxCasual_C1.Checked
                            .vTemporary_C4 = cbxTemporary_C1.Checked
                            .vPermanent_C4 = cbxPermanent_C1.Checked
                            .vHired_C4 = dtpHired_C1.Value
                            .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C4 = txtSupervisor_C1.Text
                            .vSalary_C4 = dMonthly_C1.Value
                            .vBusinessName_C4 = txtBusinessName_C1.Text
                            .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C4 = iYrsOperation_C1.Value
                            .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                            .vNoEmployees_C4 = iNoEmployees_C1.Value
                            .vCapital_C4 = dCapital_C1.Value
                            .vArea_C4 = txtArea_C1.Text
                            .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C4 = iOutlet_C1.Value
                            .vOtherIncome_C4 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C4 = dOtherIncome_C1.Value
                            .ChangePic4 = ChangeCoMaker1Pic
                            .Industry_C4 = cbxNatureBusiness_C12
                        End With
                        '*******************************************************************************************************************************************************
                    ElseIf FromCreditApplication = False Then 'FOR CREDIT INVESTIGATION
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

                        Dim CreditRating As String = ""
                        If cbxGood.Checked Then
                            CreditRating = "GOOD"
                        ElseIf cbxFair.Checked Then
                            CreditRating = "FAIR"
                        ElseIf cbxPoor.Checked Then
                            CreditRating = "POOR"
                        End If

                        Dim Findings As String = ""
                        If cbxPositive.Checked Then
                            Findings = "Positive"
                        ElseIf cbxNegative.Checked Then
                            Findings = "Negative"
                        ElseIf cbxUnestablished.Checked Then
                            Findings = "Unestablished"
                        End If
                        If Rank = 1 Then
                            With FrmCreditInvestigation
                                .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                                .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                                .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                                .TxtLastN_C1.Text = TxtLastN_C1.Text
                                .cbxSuffix_C1.Text = cbxSuffix_C1.Text

                                .ReferenceID_1 = ReferenceID
                                .vPrefix_C1 = CbxPrefix_C1.Text
                                .vFirstN_C1 = TxtFirstN_C1.Text
                                .vMiddleN_C1 = TxtMiddleN_C1.Text
                                .vLastN_C1 = TxtLastN_C1.Text
                                .vSuffix_C1 = cbxSuffix_C1.Text
                                .vNoC_C1 = txtNoC_C1.Text
                                .vStreetC_C1 = txtStreetC_C1.Text
                                .vBarangayC_C1 = txtBarangayC_C1.Text
                                .vAddressC_C1 = cbxAddressC_C1.Text
                                .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                                .vNoP_C1 = txtNoP_C1.Text
                                .vStreetP_C1 = txtStreetP_C1.Text
                                .vBarangayP_C1 = txtBarangayP_C1.Text
                                .vAddressP_C1 = cbxAddressP_C1.Text
                                .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                                .vBirth_C1 = DtpBirth_C1.Text
                                .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                                .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                                .vMale_C1 = cbxMale_C1.Checked
                                .vFemale_C1 = cbxFemale_C1.Checked
                                .vSingle_C1 = cbxSingle_C1.Checked
                                .vMarried_C1 = cbxMarried_C1.Checked
                                .vSeparated_C1 = cbxSeparated_C1.Checked
                                .vWidowed_C1 = cbxWidowed_C1.Checked
                                .vCitizenship_C1 = txtCitizenship_C1.Text
                                .vTIN_C1 = txtTIN_C1.Text
                                .vTelephone_C1 = txtTelephone_C1.Text
                                .vSSS_C1 = txtSSS_C1.Text
                                .vMobile_C1 = txtMobile_C1.Text
                                .vEmail_C1 = txtEmail_C1.Text
                                .vOwned_C1 = cbxOwned_C1.Checked
                                .vFree_C1 = cbxFree_C1.Checked
                                .vRented_C1 = cbxRented_C1.Checked
                                .vRent_C1 = dRent_C1.Value
                                .vRelationship_C1 = cbxRelationship_C1.Text
                                .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                                .CoMaker1.Image = pb_C1.Image.Clone
                                .vEmployer_C1 = cbxEmployer_C1.Text
                                .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                                .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                                .vPosition_C1 = cbxPosition_C1.Text
                                .vCasual_C1 = cbxCasual_C1.Checked
                                .vTemporary_C1 = cbxTemporary_C1.Checked
                                .vPermanent_C1 = cbxPermanent_C1.Checked
                                .vHired_C1 = dtpHired_C1.Value
                                .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                                .vSupervisor_C1 = txtSupervisor_C1.Text
                                .vSalary_C1 = dMonthly_C1.Value
                                .vBusinessName_C1 = txtBusinessName_C1.Text
                                .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                                .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                                .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                                .vYrsOperation_C1 = iYrsOperation_C1.Value
                                .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                                .dSalary_C1.Value = dNetDisposable.Value
                                .vNoEmployees_C1 = iNoEmployees_C1.Value
                                .vCapital_C1 = dCapital_C1.Value
                                .vArea_C1 = txtArea_C1.Text
                                .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                                .vOutlet_C1 = iOutlet_C1.Value
                                .vOtherIncome_C1 = txtOtherIncome_C1.Text
                                .vOtherIncomeD_C1 = dOtherIncome_C1.Value
                                .ChangePic1 = ChangeCoMaker1Pic
                                .Industry_C1 = cbxNatureBusiness_C12

                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                                .vCreditor_1_C1 = txtCreditor_1.Text
                                .vCreditAddress_1_C1 = txtCreditAddress_1.Text
                                .vCreditGranted_1_C1 = FormatDatePicker(dtpCreditGranted_1)
                                .vTerm_1_C1 = iTerm_1.Value
                                .vAmountGranted_1_C1 = dAmountGranted_1.Value
                                .vBalance_1_C1 = dBalance_1.Value
                                .vCreditPayment_1_C1 = dCreditPayment_1.Value
                                .vCreditRemarks_1_C1 = txtCreditRemarks_1.Text
                                .vCreditor_2_C1 = txtCreditor_2.Text
                                .vCreditAddress_2_C1 = txtCreditAddress_2.Text
                                .vCreditGranted_2_C1 = FormatDatePicker(dtpCreditGranted_2)
                                .vTerm_2_C1 = iTerm_2.Value
                                .vAmountGranted_2_C1 = dAmountGranted_2.Value
                                .vBalance_2_C1 = dBalance_2.Value
                                .vCreditPayment_2_C1 = dCreditPayment_2.Value
                                .vCreditRemarks_2_C1 = txtCreditRemarks_2.Text
                                .vBank_1_C1 = txtBank_1.Text
                                .vBranch_1_C1 = txtBranch_1.Text
                                .vAccountT_1_C1 = AccountT_1
                                .vSA_1_C1 = txtSA_1.Text
                                .vAverageBalance_1_C1 = dAverageBalance_1.Value
                                .vOpened_1_C1 = txtOpened_1.Text
                                .vBank_2_C1 = txtBank_2.Text
                                .vBranch_2_C1 = txtBranch_2.Text
                                .vAccountT_2_C1 = AccountT_2
                                .vSA_2_C1 = txtSA_2.Text
                                .vAverageBalance_2_C1 = dAverageBalance_2.Value
                                .vOpened_2_C1 = txtOpened_2.Text
                                .vCreditRating_C1 = CreditRating
                                .vRec_Remarks_C1 = rRecommendation.Text
                                .vTitle_C1 = txtTitle.Text
                                .vCaseNum_C1 = txtCaseNum.Text
                                .vDateFilled_C1 = FormatDatePicker(dtpDateFilled)
                                .vCourt_C1 = cbxCourt.Text
                                .vCaseNature_C1 = cbxCaseNature.Text
                                .vAmountInvolved_C1 = dAmountInvolved.Value
                                .vCaseStatus_C1 = cbxCaseStatus.Text
                                .vFindings_C1 = txtFindings.Text
                                .vFindingsStat_C1 = Findings
                                .vCACPI_C1 = txtCACPI.Text
                                .vLocation_1_C1 = txtLocation_1.Text
                                .vTCT_1_C1 = txtTCT_1.Text
                                .vArea_1_C1 = dArea_1.Value
                                .vPropertiesRemarks_1_C1 = txtPropertiesRemarks_1.Text
                                .vLocation_2_C1 = txtLocation_2.Text
                                .vTCT_2_C1 = txtTCT_2.Text
                                .vArea_2_C1 = dArea_2.Value
                                .vPropertiesRemarks_2_C1 = txtPropertiesRemarks_2.Text
                                .vVehicle_1_C1 = txtVehicle_1.Text
                                .vYear_1_C1 = FormatDatePicker(dtpYear_1)
                                .vWhomAcquired_1_C1 = txtWhomAcquired_1.Text
                                .vVehicleRemarks_1_C1 = txtVehicleRemarks_1.Text
                                .vVehicle_2_C1 = txtVehicle_2.Text
                                .vYear_2_C1 = FormatDatePicker(dtpYear_2)
                                .vWhomAcquired_2_C1 = txtWhomAcquired_2.Text
                                .vVehicleRemarks_2_C1 = txtVehicleRemarks_2.Text
                                .vOtherProperties_C1 = txtOtherProperties.Text
                                .vNarrative_C1 = rNarrative.Text.InsertQuote
                                .vEx_TotalDisposable_C1 = dTotalDisposable.Value
                                .vEx_Living_C1 = dLiving.Value
                                .vEx_Clothing_C1 = dClothing.Value
                                .vEx_Education_C1 = dEducation.Value
                                .vEx_Transportation_C1 = dTransportation.Value
                                .vEx_Lights_C1 = dLighths.Value
                                .vEx_Insurance_C1 = dInsurance.Value
                                .vEx_Amortization_C1 = dAmortization.Value
                                .vEx_Miscellaneous_C1 = dMiscellaneous.Value
                                .vEx_TotalExpenses_C1 = dTotalExpenses.Value
                                .vEx_NetDisposable_C1 = dNetDisposable.Value
                                .vEx_TMFI_C1 = dTMFI.Value
                                .vEx_TMDI_C1 = dTMDI.Value
                                .vEx_Remarks_C1 = txtExpenseRemarks.Text.InsertQuote
                                .vPurposeLoan_C1 = rPurposeLoan.Text.InsertQuote
                                .vOthers_C1 = rOthers.Text.InsertQuote
                                .vC1_C1 = txtC1.Text
                                .vC2_C1 = txtC2.Text
                                .vC3_C1 = txtC3.Text
                                .vC4_C1 = txtC4.Text
                                .vC5_C1 = txtC5.Text
                                .vC6_C1 = txtC6.Text
                                .vC7_C1 = txtC7.Text
                                .vC8_C1 = txtC8.Text
                                .vC9_C1 = txtC9.Text

                                .ChangeSketchC1 = ChangeSketch
                                .SketchC1 = pbSketch
                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            End With
                        ElseIf Rank = 2 Then
                            With FrmCreditInvestigation
                                .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                                .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                                .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                                .TxtLastN_C2.Text = TxtLastN_C1.Text
                                .cbxSuffix_C2.Text = cbxSuffix_C1.Text

                                .ReferenceID_2 = ReferenceID
                                .vPrefix_C2 = CbxPrefix_C1.Text
                                .vFirstN_C2 = TxtFirstN_C1.Text
                                .vMiddleN_C2 = TxtMiddleN_C1.Text
                                .vLastN_C2 = TxtLastN_C1.Text
                                .vSuffix_C2 = cbxSuffix_C1.Text
                                .vNoC_C2 = txtNoC_C1.Text
                                .vStreetC_C2 = txtStreetC_C1.Text
                                .vBarangayC_C2 = txtBarangayC_C1.Text
                                .vAddressC_C2 = cbxAddressC_C1.Text
                                .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                                .vNoP_C2 = txtNoP_C1.Text
                                .vStreetP_C2 = txtStreetP_C1.Text
                                .vBarangayP_C2 = txtBarangayP_C1.Text
                                .vAddressP_C2 = cbxAddressP_C1.Text
                                .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                                .vBirth_C2 = DtpBirth_C1.Text
                                .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                                .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                                .vMale_C2 = cbxMale_C1.Checked
                                .vFemale_C2 = cbxFemale_C1.Checked
                                .vSingle_C2 = cbxSingle_C1.Checked
                                .vMarried_C2 = cbxMarried_C1.Checked
                                .vSeparated_C2 = cbxSeparated_C1.Checked
                                .vWidowed_C2 = cbxWidowed_C1.Checked
                                .vCitizenship_C2 = txtCitizenship_C1.Text
                                .vTIN_C2 = txtTIN_C1.Text
                                .vTelephone_C2 = txtTelephone_C1.Text
                                .vSSS_C2 = txtSSS_C1.Text
                                .vMobile_C2 = txtMobile_C1.Text
                                .vEmail_C2 = txtEmail_C1.Text
                                .vOwned_C2 = cbxOwned_C1.Checked
                                .vFree_C2 = cbxFree_C1.Checked
                                .vRented_C2 = cbxRented_C1.Checked
                                .vRent_C2 = dRent_C1.Value
                                .vRelationship_C2 = cbxRelationship_C1.Text
                                .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                                .CoMaker2.Image = pb_C1.Image.Clone
                                .vEmployer_C2 = cbxEmployer_C1.Text
                                .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                                .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                                .vPosition_C2 = cbxPosition_C1.Text
                                .vCasual_C2 = cbxCasual_C1.Checked
                                .vTemporary_C2 = cbxTemporary_C1.Checked
                                .vPermanent_C2 = cbxPermanent_C1.Checked
                                .vHired_C2 = dtpHired_C1.Value
                                .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                                .vSupervisor_C2 = txtSupervisor_C1.Text
                                .vSalary_C2 = dMonthly_C1.Value
                                .vBusinessName_C2 = txtBusinessName_C1.Text
                                .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                                .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                                .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                                .vYrsOperation_C2 = iYrsOperation_C1.Value
                                .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                                .dSalary_C2.Value = dNetDisposable.Value
                                .vNoEmployees_C2 = iNoEmployees_C1.Value
                                .vCapital_C2 = dCapital_C1.Value
                                .vArea_C2 = txtArea_C1.Text
                                .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                                .vOutlet_C2 = iOutlet_C1.Value
                                .vOtherIncome_C2 = txtOtherIncome_C1.Text
                                .vOtherIncomeD_C2 = dOtherIncome_C1.Value
                                .ChangePic2 = ChangeCoMaker1Pic
                                .Industry_C2 = cbxNatureBusiness_C12

                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                                .vCreditor_1_C2 = txtCreditor_1.Text
                                .vCreditAddress_1_C2 = txtCreditAddress_1.Text
                                .vCreditGranted_1_C2 = FormatDatePicker(dtpCreditGranted_1)
                                .vTerm_1_C2 = iTerm_1.Value
                                .vAmountGranted_1_C2 = dAmountGranted_1.Value
                                .vBalance_1_C2 = dBalance_1.Value
                                .vCreditPayment_1_C2 = dCreditPayment_1.Value
                                .vCreditRemarks_1_C2 = txtCreditRemarks_1.Text
                                .vCreditor_2_C2 = txtCreditor_2.Text
                                .vCreditAddress_2_C2 = txtCreditAddress_2.Text
                                .vCreditGranted_2_C2 = FormatDatePicker(dtpCreditGranted_2)
                                .vTerm_2_C2 = iTerm_2.Value
                                .vAmountGranted_2_C2 = dAmountGranted_2.Value
                                .vBalance_2_C2 = dBalance_2.Value
                                .vCreditPayment_2_C2 = dCreditPayment_2.Value
                                .vCreditRemarks_2_C2 = txtCreditRemarks_2.Text
                                .vBank_1_C2 = txtBank_1.Text
                                .vBranch_1_C2 = txtBranch_1.Text
                                .vAccountT_1_C2 = AccountT_1
                                .vSA_1_C2 = txtSA_1.Text
                                .vAverageBalance_1_C2 = dAverageBalance_1.Value
                                .vOpened_1_C2 = txtOpened_1.Text
                                .vBank_2_C2 = txtBank_2.Text
                                .vBranch_2_C2 = txtBranch_2.Text
                                .vAccountT_2_C2 = AccountT_2
                                .vSA_2_C2 = txtSA_2.Text
                                .vAverageBalance_2_C2 = dAverageBalance_2.Value
                                .vOpened_2_C2 = txtOpened_2.Text
                                .vCreditRating_C2 = CreditRating
                                .vRec_Remarks_C2 = rRecommendation.Text
                                .vTitle_C2 = txtTitle.Text
                                .vCaseNum_C2 = txtCaseNum.Text
                                .vDateFilled_C2 = FormatDatePicker(dtpDateFilled)
                                .vCourt_C2 = cbxCourt.Text
                                .vCaseNature_C2 = cbxCaseNature.Text
                                .vAmountInvolved_C2 = dAmountInvolved.Value
                                .vCaseStatus_C2 = cbxCaseStatus.Text
                                .vFindings_C2 = txtFindings.Text
                                .vFindingsStat_C2 = Findings
                                .vCACPI_C2 = txtCACPI.Text
                                .vLocation_1_C2 = txtLocation_1.Text
                                .vTCT_1_C2 = txtTCT_1.Text
                                .vArea_1_C2 = dArea_1.Value
                                .vPropertiesRemarks_1_C2 = txtPropertiesRemarks_1.Text
                                .vLocation_2_C2 = txtLocation_2.Text
                                .vTCT_2_C2 = txtTCT_2.Text
                                .vArea_2_C2 = dArea_2.Value
                                .vPropertiesRemarks_2_C2 = txtPropertiesRemarks_2.Text
                                .vVehicle_1_C2 = txtVehicle_1.Text
                                .vYear_1_C2 = FormatDatePicker(dtpYear_1)
                                .vWhomAcquired_1_C2 = txtWhomAcquired_1.Text
                                .vVehicleRemarks_1_C2 = txtVehicleRemarks_1.Text
                                .vVehicle_2_C2 = txtVehicle_2.Text
                                .vYear_2_C2 = FormatDatePicker(dtpYear_2)
                                .vWhomAcquired_2_C2 = txtWhomAcquired_2.Text
                                .vVehicleRemarks_2_C2 = txtVehicleRemarks_2.Text
                                .vOtherProperties_C2 = txtOtherProperties.Text
                                .vNarrative_C2 = rNarrative.Text.InsertQuote
                                .vEx_TotalDisposable_C2 = dTotalDisposable.Value
                                .vEx_Living_C2 = dLiving.Value
                                .vEx_Clothing_C2 = dClothing.Value
                                .vEx_Education_C2 = dEducation.Value
                                .vEx_Transportation_C2 = dTransportation.Value
                                .vEx_Lights_C2 = dLighths.Value
                                .vEx_Insurance_C2 = dInsurance.Value
                                .vEx_Amortization_C2 = dAmortization.Value
                                .vEx_Miscellaneous_C2 = dMiscellaneous.Value
                                .vEx_TotalExpenses_C2 = dTotalExpenses.Value
                                .vEx_NetDisposable_C2 = dNetDisposable.Value
                                .vEx_TMFI_C2 = dTMFI.Value
                                .vEx_TMDI_C2 = dTMDI.Value
                                .vEx_Remarks_C2 = txtExpenseRemarks.Text.InsertQuote
                                .vPurposeLoan_C2 = rPurposeLoan.Text.InsertQuote
                                .vOthers_C2 = rOthers.Text.InsertQuote
                                .vC1_C2 = txtC1.Text
                                .vC2_C2 = txtC2.Text
                                .vC3_C2 = txtC3.Text
                                .vC4_C2 = txtC4.Text
                                .vC5_C2 = txtC5.Text
                                .vC6_C2 = txtC6.Text
                                .vC7_C2 = txtC7.Text
                                .vC8_C2 = txtC8.Text
                                .vC9_C2 = txtC9.Text

                                .ChangeSketchC2 = ChangeSketch
                                .SketchC2 = pbSketch
                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            End With
                        ElseIf Rank = 3 Then
                            With FrmCreditInvestigation
                                .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                                .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                                .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                                .TxtLastN_C3.Text = TxtLastN_C1.Text
                                .cbxSuffix_C3.Text = cbxSuffix_C1.Text

                                .ReferenceID_3 = ReferenceID
                                .vPrefix_C3 = CbxPrefix_C1.Text
                                .vFirstN_C3 = TxtFirstN_C1.Text
                                .vMiddleN_C3 = TxtMiddleN_C1.Text
                                .vLastN_C3 = TxtLastN_C1.Text
                                .vSuffix_C3 = cbxSuffix_C1.Text
                                .vNoC_C3 = txtNoC_C1.Text
                                .vStreetC_C3 = txtStreetC_C1.Text
                                .vBarangayC_C3 = txtBarangayC_C1.Text
                                .vAddressC_C3 = cbxAddressC_C1.Text
                                .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                                .vNoP_C3 = txtNoP_C1.Text
                                .vStreetP_C3 = txtStreetP_C1.Text
                                .vBarangayP_C3 = txtBarangayP_C1.Text
                                .vAddressP_C3 = cbxAddressP_C1.Text
                                .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                                .vBirth_C3 = DtpBirth_C1.Text
                                .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                                .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                                .vMale_C3 = cbxMale_C1.Checked
                                .vFemale_C3 = cbxFemale_C1.Checked
                                .vSingle_C3 = cbxSingle_C1.Checked
                                .vMarried_C3 = cbxMarried_C1.Checked
                                .vSeparated_C3 = cbxSeparated_C1.Checked
                                .vWidowed_C3 = cbxWidowed_C1.Checked
                                .vCitizenship_C3 = txtCitizenship_C1.Text
                                .vTIN_C3 = txtTIN_C1.Text
                                .vTelephone_C3 = txtTelephone_C1.Text
                                .vSSS_C3 = txtSSS_C1.Text
                                .vMobile_C3 = txtMobile_C1.Text
                                .vEmail_C3 = txtEmail_C1.Text
                                .vOwned_C3 = cbxOwned_C1.Checked
                                .vFree_C3 = cbxFree_C1.Checked
                                .vRented_C3 = cbxRented_C1.Checked
                                .vRent_C3 = dRent_C1.Value
                                .vRelationship_C3 = cbxRelationship_C1.Text
                                .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                                .CoMaker3.Image = pb_C1.Image.Clone
                                .vEmployer_C3 = cbxEmployer_C1.Text
                                .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                                .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                                .vPosition_C3 = cbxPosition_C1.Text
                                .vCasual_C3 = cbxCasual_C1.Checked
                                .vTemporary_C3 = cbxTemporary_C1.Checked
                                .vPermanent_C3 = cbxPermanent_C1.Checked
                                .vHired_C3 = dtpHired_C1.Value
                                .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                                .vSupervisor_C3 = txtSupervisor_C1.Text
                                .vSalary_C3 = dMonthly_C1.Value
                                .vBusinessName_C3 = txtBusinessName_C1.Text
                                .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                                .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                                .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                                .vYrsOperation_C3 = iYrsOperation_C1.Value
                                .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                                .dSalary_C3.Value = dNetDisposable.Value
                                .vNoEmployees_C3 = iNoEmployees_C1.Value
                                .vCapital_C3 = dCapital_C1.Value
                                .vArea_C3 = txtArea_C1.Text
                                .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                                .vOutlet_C3 = iOutlet_C1.Value
                                .vOtherIncome_C3 = txtOtherIncome_C1.Text
                                .vOtherIncomeD_C3 = dOtherIncome_C1.Value
                                .ChangePic3 = ChangeCoMaker1Pic
                                .Industry_C3 = cbxNatureBusiness_C12

                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                                .vCreditor_1_C3 = txtCreditor_1.Text
                                .vCreditAddress_1_C3 = txtCreditAddress_1.Text
                                .vCreditGranted_1_C3 = FormatDatePicker(dtpCreditGranted_1)
                                .vTerm_1_C3 = iTerm_1.Value
                                .vAmountGranted_1_C3 = dAmountGranted_1.Value
                                .vBalance_1_C3 = dBalance_1.Value
                                .vCreditPayment_1_C3 = dCreditPayment_1.Value
                                .vCreditRemarks_1_C3 = txtCreditRemarks_1.Text
                                .vCreditor_2_C3 = txtCreditor_2.Text
                                .vCreditAddress_2_C3 = txtCreditAddress_2.Text
                                .vCreditGranted_2_C3 = FormatDatePicker(dtpCreditGranted_2)
                                .vTerm_2_C3 = iTerm_2.Value
                                .vAmountGranted_2_C3 = dAmountGranted_2.Value
                                .vBalance_2_C3 = dBalance_2.Value
                                .vCreditPayment_2_C3 = dCreditPayment_2.Value
                                .vCreditRemarks_2_C3 = txtCreditRemarks_2.Text
                                .vBank_1_C3 = txtBank_1.Text
                                .vBranch_1_C3 = txtBranch_1.Text
                                .vAccountT_1_C3 = AccountT_1
                                .vSA_1_C3 = txtSA_1.Text
                                .vAverageBalance_1_C3 = dAverageBalance_1.Value
                                .vOpened_1_C3 = txtOpened_1.Text
                                .vBank_2_C3 = txtBank_2.Text
                                .vBranch_2_C3 = txtBranch_2.Text
                                .vAccountT_2_C3 = AccountT_2
                                .vSA_2_C3 = txtSA_2.Text
                                .vAverageBalance_2_C3 = dAverageBalance_2.Value
                                .vOpened_2_C3 = txtOpened_2.Text
                                .vCreditRating_C3 = CreditRating
                                .vRec_Remarks_C3 = rRecommendation.Text
                                .vTitle_C3 = txtTitle.Text
                                .vCaseNum_C3 = txtCaseNum.Text
                                .vDateFilled_C3 = FormatDatePicker(dtpDateFilled)
                                .vCourt_C3 = cbxCourt.Text
                                .vCaseNature_C3 = cbxCaseNature.Text
                                .vAmountInvolved_C3 = dAmountInvolved.Value
                                .vCaseStatus_C3 = cbxCaseStatus.Text
                                .vFindings_C3 = txtFindings.Text
                                .vFindingsStat_C3 = Findings
                                .vCACPI_C3 = txtCACPI.Text
                                .vLocation_1_C3 = txtLocation_1.Text
                                .vTCT_1_C3 = txtTCT_1.Text
                                .vArea_1_C3 = dArea_1.Value
                                .vPropertiesRemarks_1_C3 = txtPropertiesRemarks_1.Text
                                .vLocation_2_C3 = txtLocation_2.Text
                                .vTCT_2_C3 = txtTCT_2.Text
                                .vArea_2_C3 = dArea_2.Value
                                .vPropertiesRemarks_2_C3 = txtPropertiesRemarks_2.Text
                                .vVehicle_1_C3 = txtVehicle_1.Text
                                .vYear_1_C3 = FormatDatePicker(dtpYear_1)
                                .vWhomAcquired_1_C3 = txtWhomAcquired_1.Text
                                .vVehicleRemarks_1_C3 = txtVehicleRemarks_1.Text
                                .vVehicle_2_C3 = txtVehicle_2.Text
                                .vYear_2_C3 = FormatDatePicker(dtpYear_2)
                                .vWhomAcquired_2_C3 = txtWhomAcquired_2.Text
                                .vVehicleRemarks_2_C3 = txtVehicleRemarks_2.Text
                                .vOtherProperties_C3 = txtOtherProperties.Text
                                .vNarrative_C3 = rNarrative.Text.InsertQuote
                                .vEx_TotalDisposable_C3 = dTotalDisposable.Value
                                .vEx_Living_C3 = dLiving.Value
                                .vEx_Clothing_C3 = dClothing.Value
                                .vEx_Education_C3 = dEducation.Value
                                .vEx_Transportation_C3 = dTransportation.Value
                                .vEx_Lights_C3 = dLighths.Value
                                .vEx_Insurance_C3 = dInsurance.Value
                                .vEx_Amortization_C3 = dAmortization.Value
                                .vEx_Miscellaneous_C3 = dMiscellaneous.Value
                                .vEx_TotalExpenses_C3 = dTotalExpenses.Value
                                .vEx_NetDisposable_C3 = dNetDisposable.Value
                                .vEx_TMFI_C3 = dTMFI.Value
                                .vEx_TMDI_C3 = dTMDI.Value
                                .vEx_Remarks_C3 = txtExpenseRemarks.Text.InsertQuote
                                .vPurposeLoan_C3 = rPurposeLoan.Text.InsertQuote
                                .vOthers_C3 = rOthers.Text.InsertQuote
                                .vC1_C3 = txtC1.Text
                                .vC2_C3 = txtC2.Text
                                .vC3_C3 = txtC3.Text
                                .vC4_C3 = txtC4.Text
                                .vC5_C3 = txtC5.Text
                                .vC6_C3 = txtC6.Text
                                .vC7_C3 = txtC7.Text
                                .vC8_C3 = txtC8.Text
                                .vC9_C3 = txtC9.Text

                                .ChangeSketchC3 = ChangeSketch
                                .SketchC3 = pbSketch
                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            End With
                        ElseIf Rank = 4 Then
                            With FrmCreditInvestigation
                                .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                                .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                                .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                                .TxtLastN_C4.Text = TxtLastN_C1.Text
                                .cbxSuffix_C4.Text = cbxSuffix_C1.Text

                                .ReferenceID_4 = ReferenceID
                                .vPrefix_C4 = CbxPrefix_C1.Text
                                .vFirstN_C4 = TxtFirstN_C1.Text
                                .vMiddleN_C4 = TxtMiddleN_C1.Text
                                .vLastN_C4 = TxtLastN_C1.Text
                                .vSuffix_C4 = cbxSuffix_C1.Text
                                .vNoC_C4 = txtNoC_C1.Text
                                .vStreetC_C4 = txtStreetC_C1.Text
                                .vBarangayC_C4 = txtBarangayC_C1.Text
                                .vAddressC_C4 = cbxAddressC_C1.Text
                                .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                                .vNoP_C4 = txtNoP_C1.Text
                                .vStreetP_C4 = txtStreetP_C1.Text
                                .vBarangayP_C4 = txtBarangayP_C1.Text
                                .vAddressP_C4 = cbxAddressP_C1.Text
                                .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                                .vBirth_C4 = DtpBirth_C1.Text
                                .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                                .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                                .vMale_C4 = cbxMale_C1.Checked
                                .vFemale_C4 = cbxFemale_C1.Checked
                                .vSingle_C4 = cbxSingle_C1.Checked
                                .vMarried_C4 = cbxMarried_C1.Checked
                                .vSeparated_C4 = cbxSeparated_C1.Checked
                                .vWidowed_C4 = cbxWidowed_C1.Checked
                                .vCitizenship_C4 = txtCitizenship_C1.Text
                                .vTIN_C4 = txtTIN_C1.Text
                                .vTelephone_C4 = txtTelephone_C1.Text
                                .vSSS_C4 = txtSSS_C1.Text
                                .vMobile_C4 = txtMobile_C1.Text
                                .vEmail_C4 = txtEmail_C1.Text
                                .vOwned_C4 = cbxOwned_C1.Checked
                                .vFree_C4 = cbxFree_C1.Checked
                                .vRented_C4 = cbxRented_C1.Checked
                                .vRent_C4 = dRent_C1.Value
                                .vRelationship_C4 = cbxRelationship_C1.Text
                                .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                                .CoMaker4.Image = pb_C1.Image.Clone
                                .vEmployer_C4 = cbxEmployer_C1.Text
                                .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                                .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                                .vPosition_C4 = cbxPosition_C1.Text
                                .vCasual_C4 = cbxCasual_C1.Checked
                                .vTemporary_C4 = cbxTemporary_C1.Checked
                                .vPermanent_C4 = cbxPermanent_C1.Checked
                                .vHired_C4 = dtpHired_C1.Value
                                .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                                .vSupervisor_C4 = txtSupervisor_C1.Text
                                .vSalary_C4 = dMonthly_C1.Value
                                .vBusinessName_C4 = txtBusinessName_C1.Text
                                .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                                .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                                .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                                .vYrsOperation_C4 = iYrsOperation_C1.Value
                                .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                                .dSalary_C4.Value = dNetDisposable.Value
                                .vNoEmployees_C4 = iNoEmployees_C1.Value
                                .vCapital_C4 = dCapital_C1.Value
                                .vArea_C4 = txtArea_C1.Text
                                .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                                .vOutlet_C4 = iOutlet_C1.Value
                                .vOtherIncome_C4 = txtOtherIncome_C1.Text
                                .vOtherIncomeD_C4 = dOtherIncome_C1.Value
                                .ChangePic4 = ChangeCoMaker1Pic
                                .Industry_C4 = cbxNatureBusiness_C12

                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                                .vCreditor_1_C4 = txtCreditor_1.Text
                                .vCreditAddress_1_C4 = txtCreditAddress_1.Text
                                .vCreditGranted_1_C4 = FormatDatePicker(dtpCreditGranted_1)
                                .vTerm_1_C4 = iTerm_1.Value
                                .vAmountGranted_1_C4 = dAmountGranted_1.Value
                                .vBalance_1_C4 = dBalance_1.Value
                                .vCreditPayment_1_C4 = dCreditPayment_1.Value
                                .vCreditRemarks_1_C4 = txtCreditRemarks_1.Text
                                .vCreditor_2_C4 = txtCreditor_2.Text
                                .vCreditAddress_2_C4 = txtCreditAddress_2.Text
                                .vCreditGranted_2_C4 = FormatDatePicker(dtpCreditGranted_2)
                                .vTerm_2_C4 = iTerm_2.Value
                                .vAmountGranted_2_C4 = dAmountGranted_2.Value
                                .vBalance_2_C4 = dBalance_2.Value
                                .vCreditPayment_2_C4 = dCreditPayment_2.Value
                                .vCreditRemarks_2_C4 = txtCreditRemarks_2.Text
                                .vBank_1_C4 = txtBank_1.Text
                                .vBranch_1_C4 = txtBranch_1.Text
                                .vAccountT_1_C4 = AccountT_1
                                .vSA_1_C4 = txtSA_1.Text
                                .vAverageBalance_1_C4 = dAverageBalance_1.Value
                                .vOpened_1_C4 = txtOpened_1.Text
                                .vBank_2_C4 = txtBank_2.Text
                                .vBranch_2_C4 = txtBranch_2.Text
                                .vAccountT_2_C4 = AccountT_2
                                .vSA_2_C4 = txtSA_2.Text
                                .vAverageBalance_2_C4 = dAverageBalance_2.Value
                                .vOpened_2_C4 = txtOpened_2.Text
                                .vCreditRating_C4 = CreditRating
                                .vRec_Remarks_C4 = rRecommendation.Text
                                .vTitle_C4 = txtTitle.Text
                                .vCaseNum_C4 = txtCaseNum.Text
                                .vDateFilled_C4 = FormatDatePicker(dtpDateFilled)
                                .vCourt_C4 = cbxCourt.Text
                                .vCaseNature_C4 = cbxCaseNature.Text
                                .vAmountInvolved_C4 = dAmountInvolved.Value
                                .vCaseStatus_C4 = cbxCaseStatus.Text
                                .vFindings_C4 = txtFindings.Text
                                .vFindingsStat_C4 = Findings
                                .vCACPI_C4 = txtCACPI.Text
                                .vLocation_1_C4 = txtLocation_1.Text
                                .vTCT_1_C4 = txtTCT_1.Text
                                .vArea_1_C4 = dArea_1.Value
                                .vPropertiesRemarks_1_C4 = txtPropertiesRemarks_1.Text
                                .vLocation_2_C4 = txtLocation_2.Text
                                .vTCT_2_C4 = txtTCT_2.Text
                                .vArea_2_C4 = dArea_2.Value
                                .vPropertiesRemarks_2_C4 = txtPropertiesRemarks_2.Text
                                .vVehicle_1_C4 = txtVehicle_1.Text
                                .vYear_1_C4 = FormatDatePicker(dtpYear_1)
                                .vWhomAcquired_1_C4 = txtWhomAcquired_1.Text
                                .vVehicleRemarks_1_C4 = txtVehicleRemarks_1.Text
                                .vVehicle_2_C4 = txtVehicle_2.Text
                                .vYear_2_C4 = FormatDatePicker(dtpYear_2)
                                .vWhomAcquired_2_C4 = txtWhomAcquired_2.Text
                                .vVehicleRemarks_2_C4 = txtVehicleRemarks_2.Text
                                .vOtherProperties_C4 = txtOtherProperties.Text
                                .vNarrative_C4 = rNarrative.Text.InsertQuote
                                .vEx_TotalDisposable_C4 = dTotalDisposable.Value
                                .vEx_Living_C4 = dLiving.Value
                                .vEx_Clothing_C4 = dClothing.Value
                                .vEx_Education_C4 = dEducation.Value
                                .vEx_Transportation_C4 = dTransportation.Value
                                .vEx_Lights_C4 = dLighths.Value
                                .vEx_Insurance_C4 = dInsurance.Value
                                .vEx_Amortization_C4 = dAmortization.Value
                                .vEx_Miscellaneous_C4 = dMiscellaneous.Value
                                .vEx_TotalExpenses_C4 = dTotalExpenses.Value
                                .vEx_NetDisposable_C4 = dNetDisposable.Value
                                .vEx_TMFI_C4 = dTMFI.Value
                                .vEx_TMDI_C4 = dTMDI.Value
                                .vEx_Remarks_C4 = txtExpenseRemarks.Text.InsertQuote
                                .vPurposeLoan_C4 = rPurposeLoan.Text.InsertQuote
                                .vOthers_C4 = rOthers.Text.InsertQuote
                                .vC1_C4 = txtC1.Text
                                .vC2_C4 = txtC2.Text
                                .vC3_C4 = txtC3.Text
                                .vC4_C4 = txtC4.Text
                                .vC5_C4 = txtC5.Text
                                .vC6_C4 = txtC6.Text
                                .vC7_C4 = txtC7.Text
                                .vC8_C4 = txtC8.Text
                                .vC9_C4 = txtC9.Text

                                .ChangeSketchC4 = ChangeSketch
                                .SketchC4 = pbSketch
                                'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            End With
                        End If
                    End If

                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    If FromCreditApplication Then
                        Close()
                    Else
                        btnSave.DialogResult = DialogResult.Yes
                        btnSave.PerformClick()
                    End If
                    Cursor = Cursors.Default
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor

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

                    Dim CreditRating As String = ""
                    If cbxGood.Checked Then
                        CreditRating = "GOOD"
                    ElseIf cbxFair.Checked Then
                        CreditRating = "FAIR"
                    ElseIf cbxPoor.Checked Then
                        CreditRating = "POOR"
                    End If

                    Dim Findings As String = ""
                    If cbxPositive.Checked Then
                        Findings = "Positive"
                    ElseIf cbxNegative.Checked Then
                        Findings = "Negative"
                    ElseIf cbxUnestablished.Checked Then
                        Findings = "Unestablished"
                    End If
                    If Rank = 1 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C1.Text = TxtLastN_C1.Text
                            .cbxSuffix_C1.Text = cbxSuffix_C1.Text

                            .ReferenceID_1 = ReferenceID
                            .vPrefix_C1 = CbxPrefix_C1.Text
                            .vFirstN_C1 = TxtFirstN_C1.Text
                            .vMiddleN_C1 = TxtMiddleN_C1.Text
                            .vLastN_C1 = TxtLastN_C1.Text
                            .vSuffix_C1 = cbxSuffix_C1.Text
                            .vNoC_C1 = txtNoC_C1.Text
                            .vStreetC_C1 = txtStreetC_C1.Text
                            .vBarangayC_C1 = txtBarangayC_C1.Text
                            .vAddressC_C1 = cbxAddressC_C1.Text
                            .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C1 = txtNoP_C1.Text
                            .vStreetP_C1 = txtStreetP_C1.Text
                            .vBarangayP_C1 = txtBarangayP_C1.Text
                            .vAddressP_C1 = cbxAddressP_C1.Text
                            .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C1 = DtpBirth_C1.Text
                            .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C1 = cbxMale_C1.Checked
                            .vFemale_C1 = cbxFemale_C1.Checked
                            .vSingle_C1 = cbxSingle_C1.Checked
                            .vMarried_C1 = cbxMarried_C1.Checked
                            .vSeparated_C1 = cbxSeparated_C1.Checked
                            .vWidowed_C1 = cbxWidowed_C1.Checked
                            .vCitizenship_C1 = txtCitizenship_C1.Text
                            .vTIN_C1 = txtTIN_C1.Text
                            .vTelephone_C1 = txtTelephone_C1.Text
                            .vSSS_C1 = txtSSS_C1.Text
                            .vMobile_C1 = txtMobile_C1.Text
                            .vEmail_C1 = txtEmail_C1.Text
                            .vOwned_C1 = cbxOwned_C1.Checked
                            .vFree_C1 = cbxFree_C1.Checked
                            .vRented_C1 = cbxRented_C1.Checked
                            .vRent_C1 = dRent_C1.Value
                            .vRelationship_C1 = cbxRelationship_C1.Text
                            .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker1.Image = pb_C1.Image.Clone
                            .vEmployer_C1 = cbxEmployer_C1.Text
                            .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                            .vPosition_C1 = cbxPosition_C1.Text
                            .vCasual_C1 = cbxCasual_C1.Checked
                            .vTemporary_C1 = cbxTemporary_C1.Checked
                            .vPermanent_C1 = cbxPermanent_C1.Checked
                            .vHired_C1 = dtpHired_C1.Value
                            .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C1 = txtSupervisor_C1.Text
                            .vSalary_C1 = dMonthly_C1.Value
                            .vBusinessName_C1 = txtBusinessName_C1.Text
                            .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C1 = iYrsOperation_C1.Value
                            .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                            .vNoEmployees_C1 = iNoEmployees_C1.Value
                            .vCapital_C1 = dCapital_C1.Value
                            .vArea_C1 = txtArea_C1.Text
                            .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C1 = iOutlet_C1.Value
                            .vOtherIncome_C1 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C1 = dOtherIncome_C1.Value
                            .ChangePic1 = ChangeCoMaker1Pic
                            .Industry_C1 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 2 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C2.Text = TxtLastN_C1.Text
                            .cbxSuffix_C2.Text = cbxSuffix_C1.Text

                            .ReferenceID_2 = ReferenceID
                            .vPrefix_C2 = CbxPrefix_C1.Text
                            .vFirstN_C2 = TxtFirstN_C1.Text
                            .vMiddleN_C2 = TxtMiddleN_C1.Text
                            .vLastN_C2 = TxtLastN_C1.Text
                            .vSuffix_C2 = cbxSuffix_C1.Text
                            .vNoC_C2 = txtNoC_C1.Text
                            .vStreetC_C2 = txtStreetC_C1.Text
                            .vBarangayC_C2 = txtBarangayC_C1.Text
                            .vAddressC_C2 = cbxAddressC_C1.Text
                            .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C2 = txtNoP_C1.Text
                            .vStreetP_C2 = txtStreetP_C1.Text
                            .vBarangayP_C2 = txtBarangayP_C1.Text
                            .vAddressP_C2 = cbxAddressP_C1.Text
                            .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C2 = DtpBirth_C1.Text
                            .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C2 = cbxMale_C1.Checked
                            .vFemale_C2 = cbxFemale_C1.Checked
                            .vSingle_C2 = cbxSingle_C1.Checked
                            .vMarried_C2 = cbxMarried_C1.Checked
                            .vSeparated_C2 = cbxSeparated_C1.Checked
                            .vWidowed_C2 = cbxWidowed_C1.Checked
                            .vCitizenship_C2 = txtCitizenship_C1.Text
                            .vTIN_C2 = txtTIN_C1.Text
                            .vTelephone_C2 = txtTelephone_C1.Text
                            .vSSS_C2 = txtSSS_C1.Text
                            .vMobile_C2 = txtMobile_C1.Text
                            .vEmail_C2 = txtEmail_C1.Text
                            .vOwned_C2 = cbxOwned_C1.Checked
                            .vFree_C2 = cbxFree_C1.Checked
                            .vRented_C2 = cbxRented_C1.Checked
                            .vRent_C2 = dRent_C1.Value
                            .vRelationship_C2 = cbxRelationship_C1.Text
                            .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker2.Image = pb_C1.Image.Clone
                            .vEmployer_C2 = cbxEmployer_C1.Text
                            .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                            .vPosition_C2 = cbxPosition_C1.Text
                            .vCasual_C2 = cbxCasual_C1.Checked
                            .vTemporary_C2 = cbxTemporary_C1.Checked
                            .vPermanent_C2 = cbxPermanent_C1.Checked
                            .vHired_C2 = dtpHired_C1.Value
                            .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C2 = txtSupervisor_C1.Text
                            .vSalary_C2 = dMonthly_C1.Value
                            .vBusinessName_C2 = txtBusinessName_C1.Text
                            .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C2 = iYrsOperation_C1.Value
                            .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                            .vNoEmployees_C2 = iNoEmployees_C1.Value
                            .vCapital_C2 = dCapital_C1.Value
                            .vArea_C2 = txtArea_C1.Text
                            .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C2 = iOutlet_C1.Value
                            .vOtherIncome_C2 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C2 = dOtherIncome_C1.Value
                            .ChangePic2 = ChangeCoMaker1Pic
                            .Industry_C2 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 3 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C3.Text = TxtLastN_C1.Text
                            .cbxSuffix_C3.Text = cbxSuffix_C1.Text

                            .ReferenceID_3 = ReferenceID
                            .vPrefix_C3 = CbxPrefix_C1.Text
                            .vFirstN_C3 = TxtFirstN_C1.Text
                            .vMiddleN_C3 = TxtMiddleN_C1.Text
                            .vLastN_C3 = TxtLastN_C1.Text
                            .vSuffix_C3 = cbxSuffix_C1.Text
                            .vNoC_C3 = txtNoC_C1.Text
                            .vStreetC_C3 = txtStreetC_C1.Text
                            .vBarangayC_C3 = txtBarangayC_C1.Text
                            .vAddressC_C3 = cbxAddressC_C1.Text
                            .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C3 = txtNoP_C1.Text
                            .vStreetP_C3 = txtStreetP_C1.Text
                            .vBarangayP_C3 = txtBarangayP_C1.Text
                            .vAddressP_C3 = cbxAddressP_C1.Text
                            .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C3 = DtpBirth_C1.Text
                            .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C3 = cbxMale_C1.Checked
                            .vFemale_C3 = cbxFemale_C1.Checked
                            .vSingle_C3 = cbxSingle_C1.Checked
                            .vMarried_C3 = cbxMarried_C1.Checked
                            .vSeparated_C3 = cbxSeparated_C1.Checked
                            .vWidowed_C3 = cbxWidowed_C1.Checked
                            .vCitizenship_C3 = txtCitizenship_C1.Text
                            .vTIN_C3 = txtTIN_C1.Text
                            .vTelephone_C3 = txtTelephone_C1.Text
                            .vSSS_C3 = txtSSS_C1.Text
                            .vMobile_C3 = txtMobile_C1.Text
                            .vEmail_C3 = txtEmail_C1.Text
                            .vOwned_C3 = cbxOwned_C1.Checked
                            .vFree_C3 = cbxFree_C1.Checked
                            .vRented_C3 = cbxRented_C1.Checked
                            .vRent_C3 = dRent_C1.Value
                            .vRelationship_C3 = cbxRelationship_C1.Text
                            .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker3.Image = pb_C1.Image.Clone
                            .vEmployer_C3 = cbxEmployer_C1.Text
                            .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                            .vPosition_C3 = cbxPosition_C1.Text
                            .vCasual_C3 = cbxCasual_C1.Checked
                            .vTemporary_C3 = cbxTemporary_C1.Checked
                            .vPermanent_C3 = cbxPermanent_C1.Checked
                            .vHired_C3 = dtpHired_C1.Value
                            .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C3 = txtSupervisor_C1.Text
                            .vSalary_C3 = dMonthly_C1.Value
                            .vBusinessName_C3 = txtBusinessName_C1.Text
                            .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C3 = iYrsOperation_C1.Value
                            .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                            .vNoEmployees_C3 = iNoEmployees_C1.Value
                            .vCapital_C3 = dCapital_C1.Value
                            .vArea_C3 = txtArea_C1.Text
                            .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C3 = iOutlet_C1.Value
                            .vOtherIncome_C3 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C3 = dOtherIncome_C1.Value
                            .ChangePic3 = ChangeCoMaker1Pic
                            .Industry_C3 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 4 And FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C4.Text = TxtLastN_C1.Text
                            .cbxSuffix_C4.Text = cbxSuffix_C1.Text

                            .ReferenceID_4 = ReferenceID
                            .vPrefix_C4 = CbxPrefix_C1.Text
                            .vFirstN_C4 = TxtFirstN_C1.Text
                            .vMiddleN_C4 = TxtMiddleN_C1.Text
                            .vLastN_C4 = TxtLastN_C1.Text
                            .vSuffix_C4 = cbxSuffix_C1.Text
                            .vNoC_C4 = txtNoC_C1.Text
                            .vStreetC_C4 = txtStreetC_C1.Text
                            .vBarangayC_C4 = txtBarangayC_C1.Text
                            .vAddressC_C4 = cbxAddressC_C1.Text
                            .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C4 = txtNoP_C1.Text
                            .vStreetP_C4 = txtStreetP_C1.Text
                            .vBarangayP_C4 = txtBarangayP_C1.Text
                            .vAddressP_C4 = cbxAddressP_C1.Text
                            .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C4 = DtpBirth_C1.Text
                            .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C4 = cbxMale_C1.Checked
                            .vFemale_C4 = cbxFemale_C1.Checked
                            .vSingle_C4 = cbxSingle_C1.Checked
                            .vMarried_C4 = cbxMarried_C1.Checked
                            .vSeparated_C4 = cbxSeparated_C1.Checked
                            .vWidowed_C4 = cbxWidowed_C1.Checked
                            .vCitizenship_C4 = txtCitizenship_C1.Text
                            .vTIN_C4 = txtTIN_C1.Text
                            .vTelephone_C4 = txtTelephone_C1.Text
                            .vSSS_C4 = txtSSS_C1.Text
                            .vMobile_C4 = txtMobile_C1.Text
                            .vEmail_C4 = txtEmail_C1.Text
                            .vOwned_C4 = cbxOwned_C1.Checked
                            .vFree_C4 = cbxFree_C1.Checked
                            .vRented_C4 = cbxRented_C1.Checked
                            .vRent_C4 = dRent_C1.Value
                            .vRelationship_C4 = cbxRelationship_C1.Text
                            .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker4.Image = pb_C1.Image.Clone
                            .vEmployer_C4 = cbxEmployer_C1.Text
                            .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                            .vPosition_C4 = cbxPosition_C1.Text
                            .vCasual_C4 = cbxCasual_C1.Checked
                            .vTemporary_C4 = cbxTemporary_C1.Checked
                            .vPermanent_C4 = cbxPermanent_C1.Checked
                            .vHired_C4 = dtpHired_C1.Value
                            .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C4 = txtSupervisor_C1.Text
                            .vSalary_C4 = dMonthly_C1.Value
                            .vBusinessName_C4 = txtBusinessName_C1.Text
                            .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C4 = iYrsOperation_C1.Value
                            .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                            .vNoEmployees_C4 = iNoEmployees_C1.Value
                            .vCapital_C4 = dCapital_C1.Value
                            .vArea_C4 = txtArea_C1.Text
                            .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C4 = iOutlet_C1.Value
                            .vOtherIncome_C4 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C4 = dOtherIncome_C1.Value
                            .ChangePic4 = ChangeCoMaker1Pic
                            .Industry_C4 = cbxNatureBusiness_C12
                        End With
                    ElseIf Rank = 1 And FromCreditApplication = False Then
                        With FrmCreditInvestigation
                            .CbxPrefix_C1.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C1.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C1.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C1.Text = TxtLastN_C1.Text
                            .cbxSuffix_C1.Text = cbxSuffix_C1.Text

                            .ReferenceID_1 = ReferenceID
                            .vPrefix_C1 = CbxPrefix_C1.Text
                            .vFirstN_C1 = TxtFirstN_C1.Text
                            .vMiddleN_C1 = TxtMiddleN_C1.Text
                            .vLastN_C1 = TxtLastN_C1.Text
                            .vSuffix_C1 = cbxSuffix_C1.Text
                            .vNoC_C1 = txtNoC_C1.Text
                            .vStreetC_C1 = txtStreetC_C1.Text
                            .vBarangayC_C1 = txtBarangayC_C1.Text
                            .vAddressC_C1 = cbxAddressC_C1.Text
                            .vAddressC_C1_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C1 = txtNoP_C1.Text
                            .vStreetP_C1 = txtStreetP_C1.Text
                            .vBarangayP_C1 = txtBarangayP_C1.Text
                            .vAddressP_C1 = cbxAddressP_C1.Text
                            .vAddressP_C1_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C1 = DtpBirth_C1.Text
                            .vPlaceBirth_C1 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C1_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C1 = cbxMale_C1.Checked
                            .vFemale_C1 = cbxFemale_C1.Checked
                            .vSingle_C1 = cbxSingle_C1.Checked
                            .vMarried_C1 = cbxMarried_C1.Checked
                            .vSeparated_C1 = cbxSeparated_C1.Checked
                            .vWidowed_C1 = cbxWidowed_C1.Checked
                            .vCitizenship_C1 = txtCitizenship_C1.Text
                            .vTIN_C1 = txtTIN_C1.Text
                            .vTelephone_C1 = txtTelephone_C1.Text
                            .vSSS_C1 = txtSSS_C1.Text
                            .vMobile_C1 = txtMobile_C1.Text
                            .vEmail_C1 = txtEmail_C1.Text
                            .vOwned_C1 = cbxOwned_C1.Checked
                            .vFree_C1 = cbxFree_C1.Checked
                            .vRented_C1 = cbxRented_C1.Checked
                            .vRent_C1 = dRent_C1.Value
                            .vRelationship_C1 = cbxRelationship_C1.Text
                            .vRelationship_C1_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker1.Image = pb_C1.Image.Clone
                            .vEmployer_C1 = cbxEmployer_C1.Text
                            .vEmpAddress_C1 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C1 = txtEmployerTelephone_C1.Text
                            .vPosition_C1 = cbxPosition_C1.Text
                            .vCasual_C1 = cbxCasual_C1.Checked
                            .vTemporary_C1 = cbxTemporary_C1.Checked
                            .vPermanent_C1 = cbxPermanent_C1.Checked
                            .vHired_C1 = dtpHired_C1.Value
                            .vYearHired_C1 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C1 = txtSupervisor_C1.Text
                            .vSalary_C1 = dMonthly_C1.Value
                            .vBusinessName_C1 = txtBusinessName_C1.Text
                            .vBusinessAddress_C1 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C1 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C1 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C1 = iYrsOperation_C1.Value
                            .vBusinessIncome_C1 = dBusinessIncome_C1.Value
                            .dSalary_C1.Value = dNetDisposable.Value
                            .vNoEmployees_C1 = iNoEmployees_C1.Value
                            .vCapital_C1 = dCapital_C1.Value
                            .vArea_C1 = txtArea_C1.Text
                            .vExpiry_C1 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C1 = iOutlet_C1.Value
                            .vOtherIncome_C1 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C1 = dOtherIncome_C1.Value
                            .ChangePic1 = ChangeCoMaker1Pic
                            .Industry_C1 = cbxNatureBusiness_C12

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C1 = txtCreditor_1.Text
                            .vCreditAddress_1_C1 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C1 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C1 = iTerm_1.Value
                            .vAmountGranted_1_C1 = dAmountGranted_1.Value
                            .vBalance_1_C1 = dBalance_1.Value
                            .vCreditPayment_1_C1 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C1 = txtCreditRemarks_1.Text
                            .vCreditor_2_C1 = txtCreditor_2.Text
                            .vCreditAddress_2_C1 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C1 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C1 = iTerm_2.Value
                            .vAmountGranted_2_C1 = dAmountGranted_2.Value
                            .vBalance_2_C1 = dBalance_2.Value
                            .vCreditPayment_2_C1 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C1 = txtCreditRemarks_2.Text
                            .vBank_1_C1 = txtBank_1.Text
                            .vBranch_1_C1 = txtBranch_1.Text
                            .vAccountT_1_C1 = AccountT_1
                            .vSA_1_C1 = txtSA_1.Text
                            .vAverageBalance_1_C1 = dAverageBalance_1.Value
                            .vOpened_1_C1 = txtOpened_1.Text
                            .vBank_2_C1 = txtBank_2.Text
                            .vBranch_2_C1 = txtBranch_2.Text
                            .vAccountT_2_C1 = AccountT_2
                            .vSA_2_C1 = txtSA_2.Text
                            .vAverageBalance_2_C1 = dAverageBalance_2.Value
                            .vOpened_2_C1 = txtOpened_2.Text
                            .vCreditRating_C1 = CreditRating
                            .vRec_Remarks_C1 = rRecommendation.Text
                            .vTitle_C1 = txtTitle.Text
                            .vCaseNum_C1 = txtCaseNum.Text
                            .vDateFilled_C1 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C1 = cbxCourt.Text
                            .vCaseNature_C1 = cbxCaseNature.Text
                            .vAmountInvolved_C1 = dAmountInvolved.Value
                            .vCaseStatus_C1 = cbxCaseStatus.Text
                            .vFindings_C1 = txtFindings.Text
                            .vFindingsStat_C1 = Findings
                            .vCACPI_C1 = txtCACPI.Text
                            .vLocation_1_C1 = txtLocation_1.Text
                            .vTCT_1_C1 = txtTCT_1.Text
                            .vArea_1_C1 = dArea_1.Value
                            .vPropertiesRemarks_1_C1 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C1 = txtLocation_2.Text
                            .vTCT_2_C1 = txtTCT_2.Text
                            .vArea_2_C1 = dArea_2.Value
                            .vPropertiesRemarks_2_C1 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C1 = txtVehicle_1.Text
                            .vYear_1_C1 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C1 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C1 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C1 = txtVehicle_2.Text
                            .vYear_2_C1 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C1 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C1 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C1 = txtOtherProperties.Text
                            .vNarrative_C1 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C1 = dTotalDisposable.Value
                            .vEx_Living_C1 = dLiving.Value
                            .vEx_Clothing_C1 = dClothing.Value
                            .vEx_Education_C1 = dEducation.Value
                            .vEx_Transportation_C1 = dTransportation.Value
                            .vEx_Lights_C1 = dLighths.Value
                            .vEx_Insurance_C1 = dInsurance.Value
                            .vEx_Amortization_C1 = dAmortization.Value
                            .vEx_Miscellaneous_C1 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C1 = dTotalExpenses.Value
                            .vEx_NetDisposable_C1 = dNetDisposable.Value
                            .vEx_TMFI_C1 = dTMFI.Value
                            .vEx_TMDI_C1 = dTMDI.Value
                            .vEx_Remarks_C1 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C1 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C1 = rOthers.Text.InsertQuote
                            .vC1_C1 = txtC1.Text
                            .vC2_C1 = txtC2.Text
                            .vC3_C1 = txtC3.Text
                            .vC4_C1 = txtC4.Text
                            .vC5_C1 = txtC5.Text
                            .vC6_C1 = txtC6.Text
                            .vC7_C1 = txtC7.Text
                            .vC8_C1 = txtC8.Text
                            .vC9_C1 = txtC9.Text

                            .ChangeSketchC1 = ChangeSketch
                            .SketchC1 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                        End With
                    ElseIf Rank = 2 And FromCreditApplication = False Then
                        With FrmCreditInvestigation
                            .CbxPrefix_C2.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C2.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C2.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C2.Text = TxtLastN_C1.Text
                            .cbxSuffix_C2.Text = cbxSuffix_C1.Text

                            .ReferenceID_2 = ReferenceID
                            .vPrefix_C2 = CbxPrefix_C1.Text
                            .vFirstN_C2 = TxtFirstN_C1.Text
                            .vMiddleN_C2 = TxtMiddleN_C1.Text
                            .vLastN_C2 = TxtLastN_C1.Text
                            .vSuffix_C2 = cbxSuffix_C1.Text
                            .vNoC_C2 = txtNoC_C1.Text
                            .vStreetC_C2 = txtStreetC_C1.Text
                            .vBarangayC_C2 = txtBarangayC_C1.Text
                            .vAddressC_C2 = cbxAddressC_C1.Text
                            .vAddressC_C2_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C2 = txtNoP_C1.Text
                            .vStreetP_C2 = txtStreetP_C1.Text
                            .vBarangayP_C2 = txtBarangayP_C1.Text
                            .vAddressP_C2 = cbxAddressP_C1.Text
                            .vAddressP_C2_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C2 = DtpBirth_C1.Text
                            .vPlaceBirth_C2 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C2_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C2 = cbxMale_C1.Checked
                            .vFemale_C2 = cbxFemale_C1.Checked
                            .vSingle_C2 = cbxSingle_C1.Checked
                            .vMarried_C2 = cbxMarried_C1.Checked
                            .vSeparated_C2 = cbxSeparated_C1.Checked
                            .vWidowed_C2 = cbxWidowed_C1.Checked
                            .vCitizenship_C2 = txtCitizenship_C1.Text
                            .vTIN_C2 = txtTIN_C1.Text
                            .vTelephone_C2 = txtTelephone_C1.Text
                            .vSSS_C2 = txtSSS_C1.Text
                            .vMobile_C2 = txtMobile_C1.Text
                            .vEmail_C2 = txtEmail_C1.Text
                            .vOwned_C2 = cbxOwned_C1.Checked
                            .vFree_C2 = cbxFree_C1.Checked
                            .vRented_C2 = cbxRented_C1.Checked
                            .vRent_C2 = dRent_C1.Value
                            .vRelationship_C2 = cbxRelationship_C1.Text
                            .vRelationship_C2_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker2.Image = pb_C1.Image.Clone
                            .vEmployer_C2 = cbxEmployer_C1.Text
                            .vEmpAddress_C2 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C2 = txtEmployerTelephone_C1.Text
                            .vPosition_C2 = cbxPosition_C1.Text
                            .vCasual_C2 = cbxCasual_C1.Checked
                            .vTemporary_C2 = cbxTemporary_C1.Checked
                            .vPermanent_C2 = cbxPermanent_C1.Checked
                            .vHired_C2 = dtpHired_C1.Value
                            .vYearHired_C2 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C2 = txtSupervisor_C1.Text
                            .vSalary_C2 = dMonthly_C1.Value
                            .vBusinessName_C2 = txtBusinessName_C1.Text
                            .vBusinessAddress_C2 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C2 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C2 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C2 = iYrsOperation_C1.Value
                            .vBusinessIncome_C2 = dBusinessIncome_C1.Value
                            .dSalary_C2.Value = dNetDisposable.Value
                            .vNoEmployees_C2 = iNoEmployees_C1.Value
                            .vCapital_C2 = dCapital_C1.Value
                            .vArea_C2 = txtArea_C1.Text
                            .vExpiry_C2 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C2 = iOutlet_C1.Value
                            .vOtherIncome_C2 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C2 = dOtherIncome_C1.Value
                            .ChangePic2 = ChangeCoMaker1Pic
                            .Industry_C2 = cbxNatureBusiness_C12

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C2 = txtCreditor_1.Text
                            .vCreditAddress_1_C2 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C2 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C2 = iTerm_1.Value
                            .vAmountGranted_1_C2 = dAmountGranted_1.Value
                            .vBalance_1_C2 = dBalance_1.Value
                            .vCreditPayment_1_C2 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C2 = txtCreditRemarks_1.Text
                            .vCreditor_2_C2 = txtCreditor_2.Text
                            .vCreditAddress_2_C2 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C2 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C2 = iTerm_2.Value
                            .vAmountGranted_2_C2 = dAmountGranted_2.Value
                            .vBalance_2_C2 = dBalance_2.Value
                            .vCreditPayment_2_C2 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C2 = txtCreditRemarks_2.Text
                            .vBank_1_C2 = txtBank_1.Text
                            .vBranch_1_C2 = txtBranch_1.Text
                            .vAccountT_1_C2 = AccountT_1
                            .vSA_1_C2 = txtSA_1.Text
                            .vAverageBalance_1_C2 = dAverageBalance_1.Value
                            .vOpened_1_C2 = txtOpened_1.Text
                            .vBank_2_C2 = txtBank_2.Text
                            .vBranch_2_C2 = txtBranch_2.Text
                            .vAccountT_2_C2 = AccountT_2
                            .vSA_2_C2 = txtSA_2.Text
                            .vAverageBalance_2_C2 = dAverageBalance_2.Value
                            .vOpened_2_C2 = txtOpened_2.Text
                            .vCreditRating_C2 = CreditRating
                            .vRec_Remarks_C2 = rRecommendation.Text
                            .vTitle_C2 = txtTitle.Text
                            .vCaseNum_C2 = txtCaseNum.Text
                            .vDateFilled_C2 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C2 = cbxCourt.Text
                            .vCaseNature_C2 = cbxCaseNature.Text
                            .vAmountInvolved_C2 = dAmountInvolved.Value
                            .vCaseStatus_C2 = cbxCaseStatus.Text
                            .vFindings_C2 = txtFindings.Text
                            .vFindingsStat_C2 = Findings
                            .vCACPI_C2 = txtCACPI.Text
                            .vLocation_1_C2 = txtLocation_1.Text
                            .vTCT_1_C2 = txtTCT_1.Text
                            .vArea_1_C2 = dArea_1.Value
                            .vPropertiesRemarks_1_C2 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C2 = txtLocation_2.Text
                            .vTCT_2_C2 = txtTCT_2.Text
                            .vArea_2_C2 = dArea_2.Value
                            .vPropertiesRemarks_2_C2 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C2 = txtVehicle_1.Text
                            .vYear_1_C2 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C2 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C2 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C2 = txtVehicle_2.Text
                            .vYear_2_C2 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C2 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C2 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C2 = txtOtherProperties.Text
                            .vNarrative_C2 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C2 = dTotalDisposable.Value
                            .vEx_Living_C2 = dLiving.Value
                            .vEx_Clothing_C2 = dClothing.Value
                            .vEx_Education_C2 = dEducation.Value
                            .vEx_Transportation_C2 = dTransportation.Value
                            .vEx_Lights_C2 = dLighths.Value
                            .vEx_Insurance_C2 = dInsurance.Value
                            .vEx_Amortization_C2 = dAmortization.Value
                            .vEx_Miscellaneous_C2 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C2 = dTotalExpenses.Value
                            .vEx_NetDisposable_C2 = dNetDisposable.Value
                            .vEx_TMFI_C2 = dTMFI.Value
                            .vEx_TMDI_C2 = dTMDI.Value
                            .vEx_Remarks_C2 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C2 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C2 = rOthers.Text.InsertQuote
                            .vC1_C2 = txtC1.Text
                            .vC2_C2 = txtC2.Text
                            .vC3_C2 = txtC3.Text
                            .vC4_C2 = txtC4.Text
                            .vC5_C2 = txtC5.Text
                            .vC6_C2 = txtC6.Text
                            .vC7_C2 = txtC7.Text
                            .vC8_C2 = txtC8.Text
                            .vC9_C2 = txtC9.Text

                            .ChangeSketchC2 = ChangeSketch
                            .SketchC2 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                        End With
                    ElseIf Rank = 3 And FromCreditApplication = False Then
                        With FrmCreditInvestigation
                            .CbxPrefix_C3.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C3.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C3.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C3.Text = TxtLastN_C1.Text
                            .cbxSuffix_C3.Text = cbxSuffix_C1.Text

                            .ReferenceID_3 = ReferenceID
                            .vPrefix_C3 = CbxPrefix_C1.Text
                            .vFirstN_C3 = TxtFirstN_C1.Text
                            .vMiddleN_C3 = TxtMiddleN_C1.Text
                            .vLastN_C3 = TxtLastN_C1.Text
                            .vSuffix_C3 = cbxSuffix_C1.Text
                            .vNoC_C3 = txtNoC_C1.Text
                            .vStreetC_C3 = txtStreetC_C1.Text
                            .vBarangayC_C3 = txtBarangayC_C1.Text
                            .vAddressC_C3 = cbxAddressC_C1.Text
                            .vAddressC_C3_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C3 = txtNoP_C1.Text
                            .vStreetP_C3 = txtStreetP_C1.Text
                            .vBarangayP_C3 = txtBarangayP_C1.Text
                            .vAddressP_C3 = cbxAddressP_C1.Text
                            .vAddressP_C3_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C3 = DtpBirth_C1.Text
                            .vPlaceBirth_C3 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C3_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C3 = cbxMale_C1.Checked
                            .vFemale_C3 = cbxFemale_C1.Checked
                            .vSingle_C3 = cbxSingle_C1.Checked
                            .vMarried_C3 = cbxMarried_C1.Checked
                            .vSeparated_C3 = cbxSeparated_C1.Checked
                            .vWidowed_C3 = cbxWidowed_C1.Checked
                            .vCitizenship_C3 = txtCitizenship_C1.Text
                            .vTIN_C3 = txtTIN_C1.Text
                            .vTelephone_C3 = txtTelephone_C1.Text
                            .vSSS_C3 = txtSSS_C1.Text
                            .vMobile_C3 = txtMobile_C1.Text
                            .vEmail_C3 = txtEmail_C1.Text
                            .vOwned_C3 = cbxOwned_C1.Checked
                            .vFree_C3 = cbxFree_C1.Checked
                            .vRented_C3 = cbxRented_C1.Checked
                            .vRent_C3 = dRent_C1.Value
                            .vRelationship_C3 = cbxRelationship_C1.Text
                            .vRelationship_C3_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker3.Image = pb_C1.Image.Clone
                            .vEmployer_C3 = cbxEmployer_C1.Text
                            .vEmpAddress_C3 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C3 = txtEmployerTelephone_C1.Text
                            .vPosition_C3 = cbxPosition_C1.Text
                            .vCasual_C3 = cbxCasual_C1.Checked
                            .vTemporary_C3 = cbxTemporary_C1.Checked
                            .vPermanent_C3 = cbxPermanent_C1.Checked
                            .vHired_C3 = dtpHired_C1.Value
                            .vYearHired_C3 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C3 = txtSupervisor_C1.Text
                            .vSalary_C3 = dMonthly_C1.Value
                            .vBusinessName_C3 = txtBusinessName_C1.Text
                            .vBusinessAddress_C3 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C3 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C3 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C3 = iYrsOperation_C1.Value
                            .vBusinessIncome_C3 = dBusinessIncome_C1.Value
                            .dSalary_C3.Value = dNetDisposable.Value
                            .vNoEmployees_C3 = iNoEmployees_C1.Value
                            .vCapital_C3 = dCapital_C1.Value
                            .vArea_C3 = txtArea_C1.Text
                            .vExpiry_C3 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C3 = iOutlet_C1.Value
                            .vOtherIncome_C3 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C3 = dOtherIncome_C1.Value
                            .ChangePic3 = ChangeCoMaker1Pic
                            .Industry_C3 = cbxNatureBusiness_C12

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C3 = txtCreditor_1.Text
                            .vCreditAddress_1_C3 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C3 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C3 = iTerm_1.Value
                            .vAmountGranted_1_C3 = dAmountGranted_1.Value
                            .vBalance_1_C3 = dBalance_1.Value
                            .vCreditPayment_1_C3 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C3 = txtCreditRemarks_1.Text
                            .vCreditor_2_C3 = txtCreditor_2.Text
                            .vCreditAddress_2_C3 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C3 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C3 = iTerm_2.Value
                            .vAmountGranted_2_C3 = dAmountGranted_2.Value
                            .vBalance_2_C3 = dBalance_2.Value
                            .vCreditPayment_2_C3 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C3 = txtCreditRemarks_2.Text
                            .vBank_1_C3 = txtBank_1.Text
                            .vBranch_1_C3 = txtBranch_1.Text
                            .vAccountT_1_C3 = AccountT_1
                            .vSA_1_C3 = txtSA_1.Text
                            .vAverageBalance_1_C3 = dAverageBalance_1.Value
                            .vOpened_1_C3 = txtOpened_1.Text
                            .vBank_2_C3 = txtBank_2.Text
                            .vBranch_2_C3 = txtBranch_2.Text
                            .vAccountT_2_C3 = AccountT_2
                            .vSA_2_C3 = txtSA_2.Text
                            .vAverageBalance_2_C3 = dAverageBalance_2.Value
                            .vOpened_2_C3 = txtOpened_2.Text
                            .vCreditRating_C3 = CreditRating
                            .vRec_Remarks_C3 = rRecommendation.Text
                            .vTitle_C3 = txtTitle.Text
                            .vCaseNum_C3 = txtCaseNum.Text
                            .vDateFilled_C3 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C3 = cbxCourt.Text
                            .vCaseNature_C3 = cbxCaseNature.Text
                            .vAmountInvolved_C3 = dAmountInvolved.Value
                            .vCaseStatus_C3 = cbxCaseStatus.Text
                            .vFindings_C3 = txtFindings.Text
                            .vFindingsStat_C3 = Findings
                            .vCACPI_C3 = txtCACPI.Text
                            .vLocation_1_C3 = txtLocation_1.Text
                            .vTCT_1_C3 = txtTCT_1.Text
                            .vArea_1_C3 = dArea_1.Value
                            .vPropertiesRemarks_1_C3 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C3 = txtLocation_2.Text
                            .vTCT_2_C3 = txtTCT_2.Text
                            .vArea_2_C3 = dArea_2.Value
                            .vPropertiesRemarks_2_C3 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C3 = txtVehicle_1.Text
                            .vYear_1_C3 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C3 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C3 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C3 = txtVehicle_2.Text
                            .vYear_2_C3 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C3 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C3 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C3 = txtOtherProperties.Text
                            .vNarrative_C3 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C3 = dTotalDisposable.Value
                            .vEx_Living_C3 = dLiving.Value
                            .vEx_Clothing_C3 = dClothing.Value
                            .vEx_Education_C3 = dEducation.Value
                            .vEx_Transportation_C3 = dTransportation.Value
                            .vEx_Lights_C3 = dLighths.Value
                            .vEx_Insurance_C3 = dInsurance.Value
                            .vEx_Amortization_C3 = dAmortization.Value
                            .vEx_Miscellaneous_C3 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C3 = dTotalExpenses.Value
                            .vEx_NetDisposable_C3 = dNetDisposable.Value
                            .vEx_TMFI_C3 = dTMFI.Value
                            .vEx_TMDI_C3 = dTMDI.Value
                            .vEx_Remarks_C3 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C3 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C3 = rOthers.Text.InsertQuote
                            .vC1_C3 = txtC1.Text
                            .vC2_C3 = txtC2.Text
                            .vC3_C3 = txtC3.Text
                            .vC4_C3 = txtC4.Text
                            .vC5_C3 = txtC5.Text
                            .vC6_C3 = txtC6.Text
                            .vC7_C3 = txtC7.Text
                            .vC8_C3 = txtC8.Text
                            .vC9_C3 = txtC9.Text

                            .ChangeSketchC3 = ChangeSketch
                            .SketchC3 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                        End With
                    ElseIf Rank = 4 And FromCreditApplication = False Then
                        With FrmCreditInvestigation
                            .CbxPrefix_C4.Text = CbxPrefix_C1.Text
                            .TxtFirstN_C4.Text = TxtFirstN_C1.Text
                            .TxtMiddleN_C4.Text = TxtMiddleN_C1.Text
                            .TxtLastN_C4.Text = TxtLastN_C1.Text
                            .cbxSuffix_C4.Text = cbxSuffix_C1.Text

                            .ReferenceID_4 = ReferenceID
                            .vPrefix_C4 = CbxPrefix_C1.Text
                            .vFirstN_C4 = TxtFirstN_C1.Text
                            .vMiddleN_C4 = TxtMiddleN_C1.Text
                            .vLastN_C4 = TxtLastN_C1.Text
                            .vSuffix_C4 = cbxSuffix_C1.Text
                            .vNoC_C4 = txtNoC_C1.Text
                            .vStreetC_C4 = txtStreetC_C1.Text
                            .vBarangayC_C4 = txtBarangayC_C1.Text
                            .vAddressC_C4 = cbxAddressC_C1.Text
                            .vAddressC_C4_ID = If(cbxAddressC_C1.Text = "" Or cbxAddressC_C1.SelectedIndex = -1, 0, cbxAddressC_C1.SelectedValue)
                            .vNoP_C4 = txtNoP_C1.Text
                            .vStreetP_C4 = txtStreetP_C1.Text
                            .vBarangayP_C4 = txtBarangayP_C1.Text
                            .vAddressP_C4 = cbxAddressP_C1.Text
                            .vAddressP_C4_ID = If(cbxAddressP_C1.Text = "" Or cbxAddressP_C1.SelectedIndex = -1, 0, cbxAddressP_C1.SelectedValue)
                            .vBirth_C4 = DtpBirth_C1.Text
                            .vPlaceBirth_C4 = cbxPlaceBirth_C1.Text
                            .vPlaceBirth_C4_ID = If(cbxPlaceBirth_C1.Text = "" Or cbxPlaceBirth_C1.SelectedIndex = -1, 0, cbxPlaceBirth_C1.SelectedValue)
                            .vMale_C4 = cbxMale_C1.Checked
                            .vFemale_C4 = cbxFemale_C1.Checked
                            .vSingle_C4 = cbxSingle_C1.Checked
                            .vMarried_C4 = cbxMarried_C1.Checked
                            .vSeparated_C4 = cbxSeparated_C1.Checked
                            .vWidowed_C4 = cbxWidowed_C1.Checked
                            .vCitizenship_C4 = txtCitizenship_C1.Text
                            .vTIN_C4 = txtTIN_C1.Text
                            .vTelephone_C4 = txtTelephone_C1.Text
                            .vSSS_C4 = txtSSS_C1.Text
                            .vMobile_C4 = txtMobile_C1.Text
                            .vEmail_C4 = txtEmail_C1.Text
                            .vOwned_C4 = cbxOwned_C1.Checked
                            .vFree_C4 = cbxFree_C1.Checked
                            .vRented_C4 = cbxRented_C1.Checked
                            .vRent_C4 = dRent_C1.Value
                            .vRelationship_C4 = cbxRelationship_C1.Text
                            .vRelationship_C4_ID = If(cbxRelationship_C1.Text = "" Or cbxRelationship_C1.SelectedIndex = -1, 0, cbxRelationship_C1.SelectedValue)
                            .CoMaker4.Image = pb_C1.Image.Clone
                            .vEmployer_C4 = cbxEmployer_C1.Text
                            .vEmpAddress_C4 = txtEmployerAddress_C1.Text
                            .vEmpTelephone_C4 = txtEmployerTelephone_C1.Text
                            .vPosition_C4 = cbxPosition_C1.Text
                            .vCasual_C4 = cbxCasual_C1.Checked
                            .vTemporary_C4 = cbxTemporary_C1.Checked
                            .vPermanent_C4 = cbxPermanent_C1.Checked
                            .vHired_C4 = dtpHired_C1.Value
                            .vYearHired_C4 = If(cbxYearHired_C1.Checked, 1, 0)
                            .vSupervisor_C4 = txtSupervisor_C1.Text
                            .vSalary_C4 = dMonthly_C1.Value
                            .vBusinessName_C4 = txtBusinessName_C1.Text
                            .vBusinessAddress_C4 = txtBusinessAddress_C1.Text
                            .vBusinessTelephone_C4 = txtBusinessTelephone_C1.Text
                            .vNatureBusiness_C4 = cbxNatureBusiness_C1.Text
                            .vYrsOperation_C4 = iYrsOperation_C1.Value
                            .vBusinessIncome_C4 = dBusinessIncome_C1.Value
                            .dSalary_C4.Value = dNetDisposable.Value
                            .vNoEmployees_C4 = iNoEmployees_C1.Value
                            .vCapital_C4 = dCapital_C1.Value
                            .vArea_C4 = txtArea_C1.Text
                            .vExpiry_C4 = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
                            .vOutlet_C4 = iOutlet_C1.Value
                            .vOtherIncome_C4 = txtOtherIncome_C1.Text
                            .vOtherIncomeD_C4 = dOtherIncome_C1.Value
                            .ChangePic4 = ChangeCoMaker1Pic
                            .Industry_C4 = cbxNatureBusiness_C12

                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                            .vCreditor_1_C4 = txtCreditor_1.Text
                            .vCreditAddress_1_C4 = txtCreditAddress_1.Text
                            .vCreditGranted_1_C4 = FormatDatePicker(dtpCreditGranted_1)
                            .vTerm_1_C4 = iTerm_1.Value
                            .vAmountGranted_1_C4 = dAmountGranted_1.Value
                            .vBalance_1_C4 = dBalance_1.Value
                            .vCreditPayment_1_C4 = dCreditPayment_1.Value
                            .vCreditRemarks_1_C4 = txtCreditRemarks_1.Text
                            .vCreditor_2_C4 = txtCreditor_2.Text
                            .vCreditAddress_2_C4 = txtCreditAddress_2.Text
                            .vCreditGranted_2_C4 = FormatDatePicker(dtpCreditGranted_2)
                            .vTerm_2_C4 = iTerm_2.Value
                            .vAmountGranted_2_C4 = dAmountGranted_2.Value
                            .vBalance_2_C4 = dBalance_2.Value
                            .vCreditPayment_2_C4 = dCreditPayment_2.Value
                            .vCreditRemarks_2_C4 = txtCreditRemarks_2.Text
                            .vBank_1_C4 = txtBank_1.Text
                            .vBranch_1_C4 = txtBranch_1.Text
                            .vAccountT_1_C4 = AccountT_1
                            .vSA_1_C4 = txtSA_1.Text
                            .vAverageBalance_1_C4 = dAverageBalance_1.Value
                            .vOpened_1_C4 = txtOpened_1.Text
                            .vBank_2_C4 = txtBank_2.Text
                            .vBranch_2_C4 = txtBranch_2.Text
                            .vAccountT_2_C4 = AccountT_2
                            .vSA_2_C4 = txtSA_2.Text
                            .vAverageBalance_2_C4 = dAverageBalance_2.Value
                            .vOpened_2_C4 = txtOpened_2.Text
                            .vCreditRating_C4 = CreditRating
                            .vRec_Remarks_C4 = rRecommendation.Text
                            .vTitle_C4 = txtTitle.Text
                            .vCaseNum_C4 = txtCaseNum.Text
                            .vDateFilled_C4 = FormatDatePicker(dtpDateFilled)
                            .vCourt_C4 = cbxCourt.Text
                            .vCaseNature_C4 = cbxCaseNature.Text
                            .vAmountInvolved_C4 = dAmountInvolved.Value
                            .vCaseStatus_C4 = cbxCaseStatus.Text
                            .vFindings_C4 = txtFindings.Text
                            .vFindingsStat_C4 = Findings
                            .vCACPI_C4 = txtCACPI.Text
                            .vLocation_1_C4 = txtLocation_1.Text
                            .vTCT_1_C4 = txtTCT_1.Text
                            .vArea_1_C4 = dArea_1.Value
                            .vPropertiesRemarks_1_C4 = txtPropertiesRemarks_1.Text
                            .vLocation_2_C4 = txtLocation_2.Text
                            .vTCT_2_C4 = txtTCT_2.Text
                            .vArea_2_C4 = dArea_2.Value
                            .vPropertiesRemarks_2_C4 = txtPropertiesRemarks_2.Text
                            .vVehicle_1_C4 = txtVehicle_1.Text
                            .vYear_1_C4 = FormatDatePicker(dtpYear_1)
                            .vWhomAcquired_1_C4 = txtWhomAcquired_1.Text
                            .vVehicleRemarks_1_C4 = txtVehicleRemarks_1.Text
                            .vVehicle_2_C4 = txtVehicle_2.Text
                            .vYear_2_C4 = FormatDatePicker(dtpYear_2)
                            .vWhomAcquired_2_C4 = txtWhomAcquired_2.Text
                            .vVehicleRemarks_2_C4 = txtVehicleRemarks_2.Text
                            .vOtherProperties_C4 = txtOtherProperties.Text
                            .vNarrative_C4 = rNarrative.Text.InsertQuote
                            .vEx_TotalDisposable_C4 = dTotalDisposable.Value
                            .vEx_Living_C4 = dLiving.Value
                            .vEx_Clothing_C4 = dClothing.Value
                            .vEx_Education_C4 = dEducation.Value
                            .vEx_Transportation_C4 = dTransportation.Value
                            .vEx_Lights_C4 = dLighths.Value
                            .vEx_Insurance_C4 = dInsurance.Value
                            .vEx_Amortization_C4 = dAmortization.Value
                            .vEx_Miscellaneous_C4 = dMiscellaneous.Value
                            .vEx_TotalExpenses_C4 = dTotalExpenses.Value
                            .vEx_NetDisposable_C4 = dNetDisposable.Value
                            .vEx_TMFI_C4 = dTMFI.Value
                            .vEx_TMDI_C4 = dTMDI.Value
                            .vEx_Remarks_C4 = txtExpenseRemarks.Text.InsertQuote
                            .vPurposeLoan_C4 = rPurposeLoan.Text.InsertQuote
                            .vOthers_C4 = rOthers.Text.InsertQuote
                            .vC1_C4 = txtC1.Text
                            .vC2_C4 = txtC2.Text
                            .vC3_C4 = txtC3.Text
                            .vC4_C4 = txtC4.Text
                            .vC5_C4 = txtC5.Text
                            .vC6_C4 = txtC6.Text
                            .vC7_C4 = txtC7.Text
                            .vC8_C4 = txtC8.Text
                            .vC9_C4 = txtC9.Text

                            .ChangeSketchC4 = ChangeSketch
                            .SketchC4 = pbSketch
                            'COMAKER CREDIT INVESTIGATION REPORT ******************************************************************
                        End With
                    End If
                    If CoMakerID_1 = "" Then
                    Else
                        Dim SQL As String = "UPDATE credit_application_comaker SET"
                        SQL &= String.Format(" Prefix_C = '{0}', ", CbxPrefix_C1.Text)
                        SQL &= String.Format(" FirstN_C = '{0}', ", TxtFirstN_C1.Text)
                        SQL &= String.Format(" MiddleN_C = '{0}', ", TxtMiddleN_C1.Text)
                        SQL &= String.Format(" LastN_C = '{0}', ", TxtLastN_C1.Text)
                        SQL &= String.Format(" Suffix_C = '{0}', ", cbxSuffix_C1.Text)
                        SQL &= String.Format(" NoC_C = '{0}', ", txtNoC_C1.Text)
                        SQL &= String.Format(" StreetC_C = '{0}', ", txtStreetC_C1.Text)
                        SQL &= String.Format(" BarangayC_C = '{0}', ", txtBarangayC_C1.Text)
                        SQL &= String.Format(" `AddressC_C-ID` = '{0}', ", ValidateComboBox(cbxAddressC_C1))
                        SQL &= String.Format(" AddressC_C = '{0}', ", cbxAddressC_C1.Text)
                        SQL &= String.Format(" NoP_C = '{0}', ", txtNoP_C1.Text)
                        SQL &= String.Format(" StreetP_C = '{0}', ", txtStreetP_C1.Text)
                        SQL &= String.Format(" BarangayP_C = '{0}', ", txtBarangayP_C1.Text)
                        SQL &= String.Format(" `AddressP_C-ID` = '{0}', ", ValidateComboBox(cbxAddressP_C1))
                        SQL &= String.Format(" AddressP_C = '{0}', ", cbxAddressP_C1.Text)
                        SQL &= String.Format(" Birth_C = '{0}', ", FormatDatePicker(DtpBirth_C1))
                        SQL &= String.Format(" `PlaceBirth_C-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_C1))
                        SQL &= String.Format(" PlaceBirth_C = '{0}', ", cbxPlaceBirth_C1.Text)
                        SQL &= String.Format(" Gender_C = '{0}', ", Gender_C1)
                        SQL &= String.Format(" Civil_C = '{0}', ", Civil_C1)
                        SQL &= String.Format(" Citizenship_C = '{0}', ", txtCitizenship_C1.Text)
                        SQL &= String.Format(" TIN_C = '{0}', ", txtTIN_C1.Text)
                        SQL &= String.Format(" Telephone_C = '{0}', ", txtTelephone_C1.Text)
                        SQL &= String.Format(" SSS_C = '{0}', ", txtSSS_C1.Text)
                        SQL &= String.Format(" Mobile_C = '{0}', ", txtMobile_C1.Text)
                        SQL &= String.Format(" Email_C = '{0}', ", txtEmail_C1.Text)
                        SQL &= String.Format(" House_C = '{0}', ", House_C1)
                        SQL &= String.Format(" Rent_C = '{0}', ", dRent_C1.Value)
                        SQL &= String.Format(" Relation_ID = '{0}',", RelationID)
                        SQL &= String.Format(" Relation = '{0}',", cbxRelationship_C1.Text)
                        SQL &= String.Format(" Employer_C = '{0}', ", cbxEmployer_C1.Text)
                        SQL &= String.Format(" EmployerAddress_C = '{0}', ", txtEmployerAddress_C1.Text)
                        SQL &= String.Format(" EmployerTelephone_C = '{0}', ", txtEmployerTelephone_C1.Text)
                        SQL &= String.Format(" Position_C = '{0}', ", cbxPosition_C1.Text)
                        SQL &= String.Format(" EmploymentStat_C = '{0}', ", EmplStatus_C1)
                        SQL &= String.Format(" Hired_C = '{0}', ", FormatDatePicker(dtpHired_C1))
                        SQL &= String.Format(" Supervisor_C = '{0}', ", txtSupervisor_C1.Text)
                        SQL &= String.Format(" Monthly_C = '{0}', ", dMonthly_C1.Value)
                        SQL &= String.Format(" BusinessName_C = '{0}', ", txtBusinessName_C1.Text)
                        SQL &= String.Format(" BusinessAddress_C = '{0}', ", txtBusinessAddress_C1.Text)
                        SQL &= String.Format(" BusinessTelephone_C = '{0}', ", txtBusinessTelephone_C1.Text)
                        SQL &= String.Format(" NatureBusiness_C = '{0}', ", cbxNatureBusiness_C1.Text)
                        SQL &= String.Format(" YrsOperation_C = '{0}', ", iYrsOperation_C1.Value)
                        SQL &= String.Format(" BusinessIncome_C = '{0}', ", dBusinessIncome_C1.Value)
                        SQL &= String.Format(" NoEmployees_C = '{0}', ", iNoEmployees_C1.Value)
                        SQL &= String.Format(" Capital_C = '{0}', ", dCapital_C1.Value)
                        SQL &= String.Format(" Area_C = '{0}', ", txtArea_C1.Text)
                        SQL &= String.Format(" Expiry_C = '{0}', ", FormatDatePicker(dtpExpiry_C1))
                        SQL &= String.Format(" Outlet_C = '{0}', ", iOutlet_C1.Value)
                        SQL &= String.Format(" OtherIncome_C = '{0}', ", txtOtherIncome_C1.Text)

                        If FromCreditApplication = False Then
                            SQL &= String.Format(" Creditor_1 = '{0}', ", txtCreditor_1.Text)
                            SQL &= String.Format(" CreditAddress_1 = '{0}', ", txtCreditAddress_1.Text)
                            SQL &= String.Format(" CreditGranted_1 = '{0}', ", FormatDatePicker(dtpCreditGranted_1))
                            SQL &= String.Format(" Term_1 = '{0}', ", iTerm_1.Value)
                            SQL &= String.Format(" AmountGranted_1 = '{0}', ", dAmountGranted_1.Value)
                            SQL &= String.Format(" Balance_1 = '{0}', ", dBalance_1.Value)
                            SQL &= String.Format(" CreditPayment_1 = '{0}', ", dCreditPayment_1.Value)
                            SQL &= String.Format(" CreditRemarks_1 = '{0}', ", txtCreditRemarks_1.Text)
                            SQL &= String.Format(" Creditor_2 = '{0}', ", txtCreditor_2.Text)
                            SQL &= String.Format(" CreditAddress_2 = '{0}', ", txtCreditAddress_2.Text)
                            SQL &= String.Format(" CreditGranted_2 = '{0}', ", FormatDatePicker(dtpCreditGranted_2))
                            SQL &= String.Format(" Term_2 = '{0}', ", iTerm_2.Value)
                            SQL &= String.Format(" AmountGranted_2 = '{0}', ", dAmountGranted_2.Value)
                            SQL &= String.Format(" Balance_2 = '{0}', ", dBalance_2.Value)
                            SQL &= String.Format(" CreditPayment_2 = '{0}', ", dCreditPayment_2.Value)
                            SQL &= String.Format(" CreditRemarks_2 = '{0}', ", txtCreditRemarks_2.Text)

                            SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                            SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                            SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                            SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                            SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                            SQL &= String.Format(" Opened_1 = '{0}', ", txtOpened_1.Text)
                            SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                            SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                            SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                            SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                            SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                            SQL &= String.Format(" Opened_2 = '{0}', ", txtOpened_2.Text)

                            SQL &= String.Format(" CreditRating = '{0}', ", CreditRating)
                            SQL &= String.Format(" Rec_Remarks = '{0}', ", rRecommendation.Text)
                            SQL &= String.Format(" Title = '{0}', ", txtTitle.Text)
                            SQL &= String.Format(" CaseNum = '{0}', ", txtCaseNum.Text)
                            SQL &= String.Format(" DateFilled = '{0}', ", FormatDatePicker(dtpDateFilled))
                            SQL &= String.Format(" Court = '{0}', ", cbxCourt.Text)
                            SQL &= String.Format(" CaseNature = '{0}', ", cbxCaseNature.Text)
                            SQL &= String.Format(" AmountInvolved = '{0}', ", dAmountInvolved.Value)
                            SQL &= String.Format(" CaseStatus = '{0}', ", cbxCaseStatus.Text)
                            SQL &= String.Format(" Findings = '{0}', ", txtFindings.Text)
                            SQL &= String.Format(" FindingsStat = '{0}', ", Findings)
                            SQL &= String.Format(" CACPI = '{0}', ", txtCACPI.Text)

                            SQL &= String.Format(" Location_1 = '{0}', ", txtLocation_1.Text)
                            SQL &= String.Format(" TCT_1 = '{0}', ", txtTCT_1.Text)
                            SQL &= String.Format(" Area_1 = '{0}', ", dArea_1.Value)
                            SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", txtPropertiesRemarks_1.Text)
                            SQL &= String.Format(" Location_2 = '{0}', ", txtLocation_2.Text)
                            SQL &= String.Format(" TCT_2 = '{0}', ", txtTCT_2.Text)
                            SQL &= String.Format(" Area_2 = '{0}', ", dArea_2.Value)
                            SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", txtPropertiesRemarks_2.Text)

                            SQL &= String.Format(" Vehicle_1 = '{0}', ", txtVehicle_1.Text)
                            SQL &= String.Format(" Year_1 = '{0}', ", FormatDatePicker(dtpYear_1))
                            SQL &= String.Format(" WhomAcquired_1 = '{0}', ", txtWhomAcquired_1.Text)
                            SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", txtVehicleRemarks_1.Text)
                            SQL &= String.Format(" Vehicle_2 = '{0}', ", txtVehicle_2.Text)
                            SQL &= String.Format(" Year_2 = '{0}', ", FormatDatePicker(dtpYear_2))
                            SQL &= String.Format(" WhomAcquired_2 = '{0}', ", txtWhomAcquired_2.Text)
                            SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", txtVehicleRemarks_2.Text)

                            SQL &= String.Format(" OtherProperties = '{0}', ", txtOtherProperties.Text)
                            SQL &= String.Format(" Narrative = '{0}', ", rNarrative.Text.InsertQuote)
                            SQL &= String.Format(" Ex_TotalDisposable = '{0}', ", dTotalDisposable.Value)
                            SQL &= String.Format(" Ex_Living = '{0}', ", dLiving.Value)
                            SQL &= String.Format(" Ex_Clothing = '{0}', ", dClothing.Value)
                            SQL &= String.Format(" Ex_Education = '{0}', ", dEducation.Value)
                            SQL &= String.Format(" Ex_Transportation = '{0}', ", dTransportation.Value)
                            SQL &= String.Format(" Ex_Lights = '{0}', ", dLighths.Value)
                            SQL &= String.Format(" Ex_Insurance = '{0}', ", dInsurance.Value)
                            SQL &= String.Format(" Ex_Amortization = '{0}', ", dAmortization.Value)
                            SQL &= String.Format(" Ex_Miscellaneous = '{0}', ", dMiscellaneous.Value)
                            SQL &= String.Format(" Ex_TotalExpenses = '{0}', ", dTotalExpenses.Value)
                            SQL &= String.Format(" Ex_NetDisposable = '{0}', ", dNetDisposable.Value)
                            SQL &= String.Format(" Ex_TMFI = '{0}', ", dTMFI.Value)
                            SQL &= String.Format(" Ex_TMDI = '{0}', ", dTMDI.Value)
                            SQL &= String.Format(" Ex_Remarks = '{0}', ", txtExpenseRemarks.Text.InsertQuote)
                            SQL &= String.Format(" PurposeLoan = '{0}', ", rPurposeLoan.Text.InsertQuote)
                            SQL &= String.Format(" Others = '{0}', ", rOthers.Text.InsertQuote)
                        End If

                        SQL &= String.Format(" `OtherIncome_C-Amount` = '{0}' ", dOtherIncome_C1.Value)
                        SQL &= String.Format(" WHERE CoMakerID = '{0}' AND `Rank` = '{1}';", CoMakerID_1, Rank)

                        SQL &= String.Format("UPDATE credit_application SET Prefix_C{6} = '{0}', FirstN_C{6} = '{1}', MiddleN_C{6} = '{2}', LastN_C{6} = '{3}', Suffix_C{6} = '{4}' WHERE CreditNumber = '{5}';", CbxPrefix_C1.Text, TxtFirstN_C1.Text, TxtMiddleN_C1.Text, TxtLastN_C1.Text, cbxSuffix_C1.Text, CreditNumber, Rank)

                        If txtPath_C1.Text <> "" Then
                            SaveImage(pb_C1, String.Format("CoMaker{0}", Rank))
                        End If
                        If ChangeSketch Then
                            SaveImage(pbSketch, String.Format("Sketch C{0}", Rank))
                        End If

                        SQL &= String.Format("UPDATE credit_application_industry SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND `Type` = '{1}' AND CreditNumber = '{0}';", CreditNumber, String.Format("CoMaker{0}", Rank))
                        For x As Integer = 0 To cbxNatureBusiness_C12.Properties.Items.Count - 1
                            If cbxNatureBusiness_C12.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                                SQL &= "INSERT INTO credit_application_industry SET"
                                SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                                SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_C12.Properties.Items.Item(x).Value)
                                SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_C12.Properties.Items.Item(x).Description)
                                SQL &= String.Format(" `Type` = 'CoMaker{0}';", Rank)
                            End If
                        Next

                        SQL &= "UPDATE profile_borrowerid SET"
                        SQL &= String.Format(" TIN = '{0}', ", TIN_C1)
                        SQL &= String.Format(" SSS = '{0}', ", SSS_C1)
                        SQL &= String.Format(" GSIS = '{0}', ", GSIS_C1)
                        SQL &= String.Format(" PhilHealth = '{0}', ", PhilHealth_C1)
                        SQL &= String.Format(" Senior = '{0}', ", Senior_C1)
                        SQL &= String.Format(" UMID = '{0}', ", UMID_C1)
                        SQL &= String.Format(" SEC = '{0}', ", SEC_C1)
                        SQL &= String.Format(" DTI = '{0}', ", DTI_C1)
                        SQL &= String.Format(" CDA = '{0}', ", CDA_C1)
                        SQL &= String.Format(" Cooperative = '{0}', ", Cooperative_C1)
                        SQL &= String.Format(" Drivers = '{0}', ", Drivers_C1)
                        SQL &= String.Format(" dDrivers = '{0}', ", dDrivers_C1)
                        SQL &= String.Format(" VIN = '{0}', ", VIN_C1)
                        SQL &= String.Format(" dVIN = '{0}', ", dVIN_C1)
                        SQL &= String.Format(" Passport = '{0}', ", Passport_C1)
                        SQL &= String.Format(" dPassport = '{0}', ", dPassport_C1)
                        SQL &= String.Format(" PRC = '{0}', ", PRC_C1)
                        SQL &= String.Format(" dPRC = '{0}', ", dPRC_C1)
                        SQL &= String.Format(" NBI = '{0}', ", NBI_C1)
                        SQL &= String.Format(" dNBI = '{0}', ", dNBI_C1)
                        SQL &= String.Format(" Police = '{0}', ", Police_C1)
                        SQL &= String.Format(" dPolice = '{0}', ", dPolice_C1)
                        SQL &= String.Format(" Postal = '{0}', ", Postal_C1)
                        SQL &= String.Format(" dPostal = '{0}', ", dPostal_C1)
                        SQL &= String.Format(" Barangay = '{0}', ", Barangay_C1)
                        SQL &= String.Format(" dBarangay = '{0}', ", dBarangay_C1)
                        SQL &= String.Format(" OWWA = '{0}', ", OWWA_C1)
                        SQL &= String.Format(" dOWWA = '{0}', ", dOWWA_C1)
                        SQL &= String.Format(" OFW = '{0}', ", OFW_C1)
                        SQL &= String.Format(" dOFW = '{0}', ", dOFW_C1)
                        SQL &= String.Format(" Seaman = '{0}', ", Seaman_C1)
                        SQL &= String.Format(" dSeaman = '{0}', ", dSeaman_C1)
                        SQL &= String.Format(" PNP = '{0}', ", PNP_C1)
                        SQL &= String.Format(" dPNP = '{0}', ", dPNP_C1)
                        SQL &= String.Format(" AFP = '{0}', ", AFP_C1)
                        SQL &= String.Format(" dAFP = '{0}', ", dAFP_C1)
                        SQL &= String.Format(" HDMF = '{0}', ", HDMF_C1)
                        SQL &= String.Format(" dHDMF = '{0}', ", dHDMF_C1)
                        SQL &= String.Format(" PWD = '{0}', ", PWD_C1)
                        SQL &= String.Format(" dPWD = '{0}', ", dPWD_C1)
                        SQL &= String.Format(" DSWD = '{0}', ", DSWD_C1)
                        SQL &= String.Format(" dDSWD = '{0}', ", dDSWD_C1)
                        SQL &= String.Format(" ACR = '{0}', ", ACR_C1)
                        SQL &= String.Format(" dACR = '{0}', ", dACR_C1)
                        SQL &= String.Format(" DTI_Business = '{0}', ", DTI_Business_C1)
                        SQL &= String.Format(" dDTI_Business = '{0}', ", dDTI_Business_C1)
                        SQL &= String.Format(" IBP = '{0}', ", IBP_C1)
                        SQL &= String.Format(" dIBP = '{0}', ", dIBP_C1)
                        SQL &= String.Format(" FireArms = '{0}', ", FireArms_C1)
                        SQL &= String.Format(" dFireArms = '{0}', ", dFireArms_C1)
                        SQL &= String.Format(" Government = '{0}', ", Government_C1)
                        SQL &= String.Format(" dGovernment = '{0}', ", dGovernment_C1)
                        SQL &= String.Format(" Diplomat = '{0}', ", Diplomat_C1)
                        SQL &= String.Format(" dDiplomat = '{0}', ", dDiplomat_C1)
                        SQL &= String.Format(" `National` = '{0}', ", National_C1)
                        SQL &= String.Format(" dNational = '{0}', ", dNational_C1)
                        SQL &= String.Format(" `Work` = '{0}', ", Work_C1)
                        SQL &= String.Format(" dWork = '{0}', ", dWork_C1)
                        SQL &= String.Format(" GOCC = '{0}', ", GOCC_C1)
                        SQL &= String.Format(" dGOCC = '{0}', ", dGOCC_C1)
                        SQL &= String.Format(" PLRA = '{0}', ", PLRA_C1)
                        SQL &= String.Format(" dPLRA = '{0}', ", dPLRA_C1)
                        SQL &= String.Format(" Major = '{0}', ", Major_C1)
                        SQL &= String.Format(" dMajor = '{0}', ", dMajor_C1)
                        SQL &= String.Format(" Media = '{0}', ", Media_C1)
                        SQL &= String.Format(" dMedia = '{0}', ", dMedia_C1)
                        SQL &= String.Format(" Student = '{0}', ", Student_C1)
                        SQL &= String.Format(" dStudent = '{0}', ", dStudent_C1)
                        SQL &= String.Format(" SIRV = '{0}', ", SIRV_C1)
                        SQL &= String.Format(" dSIRV = '{0}'", dSIRV_C1)
                        SQL &= String.Format(" WHERE BorrowerID = '{0}' AND ID_Type = 'C{1}';", BorrowerID, Rank)
                        DataObject(SQL)
                        Logs("CoMaker", "Update", String.Format("Update CoMaker {0}", If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")), Changes(), BorrowerID, If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " "), CreditNumber)
                        Clear()
                    End If
                    Cursor = Cursors.Default
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxPrefix_C1.Text = CbxPrefix_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Prefix from {0} to {1}. ", CbxPrefix_C1.Tag, CbxPrefix_C1.Text)
            End If
            If TxtFirstN_C1.Text = TxtFirstN_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker First Name from {0} to {1}. ", TxtFirstN_C1.Tag, TxtFirstN_C1.Text)
            End If
            If TxtMiddleN_C1.Text = TxtMiddleN_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Middle Name from {0} to {1}. ", TxtMiddleN_C1.Tag, TxtMiddleN_C1.Text)
            End If
            If TxtLastN_C1.Text = TxtLastN_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Last Name from {0} to {1}. ", TxtLastN_C1.Tag, TxtLastN_C1.Text)
            End If
            If cbxSuffix_C1.Text = cbxSuffix_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Suffix from {0} to {1}. ", cbxSuffix_C1.Tag, cbxSuffix_C1.Text)
            End If
            If txtNoC_C1.Text = txtNoC_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Complete Address No from {0} to {1}. ", txtNoC_C1.Tag, txtNoC_C1.Text)
            End If
            If txtStreetC_C1.Text = txtStreetC_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Complete Address Street from {0} to {1}. ", txtStreetC_C1.Tag, txtStreetC_C1.Text)
            End If
            If txtBarangayC_C1.Text = txtBarangayC_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Complete Address Barangay from {0} to {1}. ", txtBarangayC_C1.Tag, txtBarangayC_C1.Text)
            End If
            If cbxAddressC_C1.Text = cbxAddressC_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Complete Address from {0} to {1}. ", cbxAddressC_C1.Tag, cbxAddressC_C1.Text)
            End If
            If txtNoP_C1.Text = txtNoP_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Provincial Address No  from {0} to {1}. ", txtNoP_C1.Tag, txtNoP_C1.Text)
            End If
            If txtStreetP_C1.Text = txtStreetP_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Provincial Address Street from {0} to {1}. ", txtStreetP_C1.Tag, txtStreetP_C1.Text)
            End If
            If txtBarangayP_C1.Text = txtBarangayP_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Provincial Address Barangay from {0} to {1}. ", txtBarangayP_C1.Tag, txtBarangayP_C1.Text)
            End If
            If cbxAddressP_C1.Text = cbxAddressP_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Provincial Address from {0} to {1}. ", cbxAddressP_C1.Tag, cbxAddressP_C1.Text)
            End If
            If FormatDatePicker(DtpBirth_C1) = DtpBirth_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Birthdate from {0} to {1}. ", DtpBirth_C1.Tag, FormatDatePicker(DtpBirth_C1))
            End If
            If cbxPlaceBirth_C1.Text = cbxPlaceBirth_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Place of Birth from {0} to {1}. ", cbxPlaceBirth_C1.Tag, cbxPlaceBirth_C1.Text)
            End If
            If cbxMale_C1.Tag <> "Male" And cbxMale_C1.Checked Then
                Change &= String.Format("Change CoMaker Gender from {0} to {1}. ", cbxMale_C1.Tag, cbxMale_C1.Text)
            ElseIf cbxFemale_C1.Tag <> "Female" And cbxFemale_C1.Checked Then
                Change &= String.Format("Change CoMaker Gender from {0} to {1}. ", cbxFemale_C1.Tag, cbxFemale_C1.Text)
            End If
            If cbxSingle_C1.Tag <> "Single" And cbxSingle_C1.Checked Then
                Change &= String.Format("Change CoMaker Civil Status from {0} to {1}. ", cbxSingle_C1.Tag, cbxSingle_C1.Text)
            ElseIf cbxMarried_C1.Tag <> "Married" And cbxMarried_C1.Checked Then
                Change &= String.Format("Change CoMaker Civil Status from {0} to {1}. ", cbxMarried_C1.Tag, cbxMarried_C1.Text)
            ElseIf cbxSeparated_C1.Tag <> "Separated" And cbxSeparated_C1.Checked Then
                Change &= String.Format("Change CoMaker Civil Status from {0} to {1}. ", cbxSeparated_C1.Tag, cbxSeparated_C1.Text)
            ElseIf cbxWidowed_C1.Tag <> "Widowed" And cbxWidowed_C1.Checked Then
                Change &= String.Format("Change CoMaker Civil Status from {0} to {1}. ", cbxWidowed_C1.Tag, cbxWidowed_C1.Text)
            End If
            If txtCitizenship_C1.Text = txtCitizenship_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Citizenship from {0} to {1}. ", txtCitizenship_C1.Tag, txtCitizenship_C1.Text)
            End If
            If txtTIN_C1.Text = txtTIN_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker TIN from {0} to {1}. ", txtTIN_C1.Tag, txtTIN_C1.Text)
            End If
            If txtTelephone_C1.Text = txtTelephone_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Telephone from {0} to {1}. ", txtTelephone_C1.Tag, txtTelephone_C1.Text)
            End If
            If txtSSS_C1.Text = txtSSS_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker SSS from {0} to {1}. ", txtSSS_C1.Tag, txtSSS_C1.Text)
            End If
            If txtMobile_C1.Text = txtMobile_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Mobile from {0} to {1}. ", txtMobile_C1.Tag, txtMobile_C1.Text)
            End If
            If txtEmail_C1.Text = txtEmail_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Email from {0} to {1}. ", txtEmail_C1.Tag, txtEmail_C1.Text)
            End If
            If cbxOwned_C1.Tag <> "Owned" And cbxOwned_C1.Checked Then
                Change &= String.Format("Change CoMaker House from {0} to {1}. ", cbxOwned_C1.Tag, cbxOwned_C1.Text)
            ElseIf cbxFree_C1.Tag <> "Free" And cbxFree_C1.Checked Then
                Change &= String.Format("Change CoMaker House from {0} to {1}. ", cbxFree_C1.Tag, cbxFree_C1.Text)
            ElseIf cbxRented_C1.Tag <> "Rented" And cbxRented_C1.Checked Then
                Change &= String.Format("Change CoMaker House from {0} to {1}. ", cbxRented_C1.Tag, cbxRented_C1.Text)
            End If
            If dRent_C1.Value = dRent_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Rent from {0} to {1}. ", dRent_C1.Tag, dRent_C1.Text)
            End If
            If cbxRelationship_C1.Text = cbxRelationship_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Relationship with the Borrower from {0} to {1}. ", cbxRelationship_C1.Tag, cbxRelationship_C1.Text)
            End If
            If cbxEmployer_C1.Text = cbxEmployer_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Employer from {0} to {1}. ", cbxEmployer_C1.Tag, cbxEmployer_C1.Text)
            End If
            If txtEmployerAddress_C1.Text = txtEmployerAddress_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Employer Address from {0} to {1}. ", txtEmployerAddress_C1.Tag, txtEmployerAddress_C1.Text)
            End If
            If txtEmployerTelephone_C1.Text = txtEmployerTelephone_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Employer Telephone from {0} to {1}. ", txtEmployerTelephone_C1.Tag, txtEmployerTelephone_C1.Text)
            End If
            If cbxPosition_C1.Text = cbxPosition_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Position from {0} to {1}. ", cbxPosition_C1.Tag, cbxPosition_C1.Text)
            End If
            If cbxCasual_C1.Tag.ToString <> "Casual" And cbxCasual_C1.Checked Then
                Change &= String.Format("Change CoMaker Employment Status from {0} to {1}. ", cbxCasual_C1.Tag, cbxCasual_C1.Text)
            ElseIf cbxTemporary_C1.Tag.ToString <> "Temporary" And cbxTemporary_C1.Checked Then
                Change &= String.Format("Change CoMaker Employment Status from {0} to {1}. ", cbxTemporary_C1.Tag, cbxTemporary_C1.Text)
            ElseIf cbxPermanent_C1.Tag.ToString <> "Permanent" And cbxPermanent_C1.Checked Then
                Change &= String.Format("Change CoMaker Employment Status from {0} to {1}. ", cbxPermanent_C1.Tag, cbxPermanent_C1.Text)
            End If
            If FormatDatePicker(dtpHired_C1) = dtpHired_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Date Hired from {0} to {1}. ", dtpHired_C1.Tag, FormatDatePicker(dtpHired_C1))
            End If
            If txtSupervisor_C1.Text = txtSupervisor_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Supervisor from {0} to {1}. ", txtSupervisor_C1.Tag, txtSupervisor_C1.Text)
            End If
            If dMonthly_C1.Value = dMonthly_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Gross Monthly Income as employed from {0} to {1}. ", dMonthly_C1.Tag, dMonthly_C1.Text)
            End If
            If txtBusinessName_C1.Text = txtBusinessName_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Business Name from {0} to {1}. ", txtBusinessName_C1.Tag, txtBusinessName_C1.Text)
            End If
            If txtBusinessAddress_C1.Text = txtBusinessAddress_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Business Address from {0} to {1}. ", txtBusinessAddress_C1.Tag, txtBusinessAddress_C1.Text)
            End If
            If txtBusinessTelephone_C1.Text = txtBusinessTelephone_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Business Telephone from {0} to {1}. ", txtBusinessTelephone_C1.Tag, txtBusinessTelephone_C1.Text)
            End If
            If cbxNatureBusiness_C1.Text = cbxNatureBusiness_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Nature of Business from {0} to {1}. ", cbxNatureBusiness_C1.Tag, cbxNatureBusiness_C1.Text)
            End If
            If iYrsOperation_C1.Value = iYrsOperation_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Years Operation from {0} to {1}. ", iYrsOperation_C1.Tag, iYrsOperation_C1.Text)
            End If
            If dBusinessIncome_C1.Value = dBusinessIncome_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Business Income from {0} to {1}. ", dBusinessIncome_C1.Tag, dBusinessIncome_C1.Text)
            End If
            If iNoEmployees_C1.Value = iNoEmployees_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker No of Employees from {0} to {1}. ", iNoEmployees_C1.Tag, iNoEmployees_C1.Text)
            End If
            If dCapital_C1.Value = dCapital_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Capital from {0} to {1}. ", dCapital_C1.Tag, dCapital_C1.Text)
            End If
            If txtArea_C1.Text = txtArea_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Area from {0} to {1}. ", txtArea_C1.Tag, txtArea_C1.Text)
            End If
            If FormatDatePicker(dtpExpiry_C1) = dtpExpiry_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Business Expiry from {0} to {1}. ", dtpExpiry_C1.Tag, FormatDatePicker(dtpExpiry_C1))
            End If
            If iOutlet_C1.Value = iOutlet_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker No of Outlet from {0} to {1}. ", iOutlet_C1.Tag, iOutlet_C1.Text)
            End If
            If txtOtherIncome_C1.Text = txtOtherIncome_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Other Income from {0} to {1}. ", txtOtherIncome_C1.Tag, txtOtherIncome_C1.Text)
            End If
            If dOtherIncome_C1.Value = dOtherIncome_C1.Tag Then
            Else
                Change &= String.Format("Change CoMaker Other Income Monthly from {0} to {1}. ", dOtherIncome_C1.Tag, dOtherIncome_C1.Text)
            End If
            If ChangeCoMaker1Pic Then
                Change &= "Change CoMaker Picture. "
            End If
            If FromCreditApplication = False Then
                If txtCreditor_1.Text = txtCreditor_1.Tag Then
                Else
                    Change &= String.Format("Change Creditor 1 from {0} to {1}. ", txtCreditor_1.Tag, txtCreditor_1.Text)
                End If
                If txtCreditAddress_1.Text = txtCreditAddress_1.Tag Then
                Else
                    Change &= String.Format("Change Creditor Address 1 from {0} to {1}. ", txtCreditAddress_1.Tag, txtCreditAddress_1.Text)
                End If
                If FormatDatePicker(dtpCreditGranted_1) = dtpCreditGranted_1.Tag Then
                Else
                    Change &= String.Format("Change Date Granted 1 from {0} to {1}. ", dtpCreditGranted_1.Tag, FormatDatePicker(dtpCreditGranted_1))
                End If
                If iTerm_1.Value = iTerm_1.Tag Then
                Else
                    Change &= String.Format("Change Term 1 from {0} to {1}. ", iTerm_1.Tag, iTerm_1.Text)
                End If
                If dAmountGranted_1.Value = dAmountGranted_1.Tag Then
                Else
                    Change &= String.Format("Change Principal 1 from {0} to {1}. ", dAmountGranted_1.Tag, dAmountGranted_1.Text)
                End If
                If dBalance_1.Value = dBalance_1.Tag Then
                Else
                    Change &= String.Format("Change Outstanding Balance 1 from {0} to {1}. ", dBalance_1.Tag, dBalance_1.Text)
                End If
                If dCreditPayment_1.Value = dCreditPayment_1.Tag Then
                Else
                    Change &= String.Format("Change Monthly Payment 1 from {0} to {1}. ", dCreditPayment_1.Tag, dCreditPayment_1.Text)
                End If
                If txtCreditRemarks_1.Text = txtCreditRemarks_1.Tag Then
                Else
                    Change &= String.Format("Change Credit Remarks 1 from {0} to {1}. ", txtCreditRemarks_1.Tag, txtCreditRemarks_1.Text)
                End If
                If txtCreditor_2.Text = txtCreditor_2.Tag Then
                Else
                    Change &= String.Format("Change Creditor 2 from {0} to {1}. ", txtCreditor_2.Tag, txtCreditor_2.Text)
                End If
                If txtCreditAddress_2.Text = txtCreditAddress_2.Tag Then
                Else
                    Change &= String.Format("Change Creditor Address 2 from {0} to {1}. ", txtCreditAddress_2.Tag, txtCreditAddress_2.Text)
                End If
                If FormatDatePicker(dtpCreditGranted_2) = dtpCreditGranted_2.Tag Then
                Else
                    Change &= String.Format("Change Date Granted 2 from {0} to {1}. ", dtpCreditGranted_2.Tag, FormatDatePicker(dtpCreditGranted_2))
                End If
                If iTerm_2.Value = iTerm_2.Tag Then
                Else
                    Change &= String.Format("Change Term 2 from {0} to {1}. ", iTerm_2.Tag, iTerm_2.Text)
                End If
                If dAmountGranted_2.Value = dAmountGranted_2.Tag Then
                Else
                    Change &= String.Format("Change Principal 2 from {0} to {1}. ", dAmountGranted_2.Tag, dAmountGranted_2.Text)
                End If
                If dBalance_2.Value = dBalance_2.Tag Then
                Else
                    Change &= String.Format("Change Outstanding Balance 2 from {0} to {1}. ", dBalance_2.Tag, dBalance_2.Text)
                End If
                If dCreditPayment_2.Value = dCreditPayment_2.Tag Then
                Else
                    Change &= String.Format("Change Monthly Payment 2 from {0} to {1}. ", dCreditPayment_2.Tag, dCreditPayment_2.Text)
                End If
                If txtCreditRemarks_2.Text = txtCreditRemarks_2.Tag Then
                Else
                    Change &= String.Format("Change Credit Remarks 2 from {0} to {1}. ", txtCreditRemarks_2.Tag, txtCreditRemarks_2.Text)
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
                If txtOpened_1.Text = txtOpened_1.Tag Then
                Else
                    Change &= String.Format("Change Date Opened 1 from {0} to {1}. ", txtOpened_1.Tag, txtOpened_1.Text)
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
                    Change &= String.Format("Change Average Balance 2 from {0} to {1}. ", dAverageBalance_2.Tag, dAverageBalance_2.Text)
                End If
                If txtOpened_2.Text = txtOpened_2.Tag Then
                Else
                    Change &= String.Format("Change Date Opened 2 from {0} to {1}. ", txtOpened_2.Tag, txtOpened_2.Text)
                End If
                If cbxGood.Tag <> "GOOD" And cbxGood.Checked Then
                    Change &= String.Format("Change Credit Rating from {0} to {1}. ", cbxGood.Tag, "GOOD")
                ElseIf cbxFair.Tag <> "FAIR" And cbxFair.Checked Then
                    Change &= String.Format("Change Credit Rating from {0} to {1}. ", cbxFair.Tag, "FAIR")
                ElseIf cbxPoor.Tag <> "POOR" And cbxPoor.Checked Then
                    Change &= String.Format("Change Credit Rating from {0} to {1}. ", cbxPoor.Tag, "POOR")
                End If
                If rRecommendation.Text = rRecommendation.Tag Then
                Else
                    Change &= String.Format("Change Recommendation from {0} to {1}. ", rRecommendation.Tag, rRecommendation.Text)
                End If
                If txtTitle.Text = txtTitle.Tag Then
                Else
                    Change &= String.Format("Change Case Title from {0} to {1}. ", txtTitle.Tag, txtTitle.Text)
                End If
                If txtCaseNum.Text = txtCaseNum.Tag Then
                Else
                    Change &= String.Format("Change Case Number from {0} to {1}. ", txtCaseNum.Tag, txtCaseNum.Text)
                End If
                If FormatDatePicker(dtpDateFilled) = dtpDateFilled.Tag Then
                Else
                    Change &= String.Format("Change Date Filled from {0} to {1}. ", dtpDateFilled.Tag, FormatDatePicker(dtpDateFilled))
                End If
                If cbxCourt.Text = cbxCourt.Tag Then
                Else
                    Change &= String.Format("Change Court from {0} to {1}. ", cbxCourt.Tag, cbxCourt.Text)
                End If
                If cbxCaseNature.Text = cbxCaseNature.Tag Then
                Else
                    Change &= String.Format("Change Case Nature from {0} to {1}. ", cbxCaseNature.Tag, cbxCaseNature.Text)
                End If
                If dAmountInvolved.Value = dAmountInvolved.Tag Then
                Else
                    Change &= String.Format("Change Amount Involved from {0} to {1}. ", dAmountInvolved.Tag, dAmountInvolved.Text)
                End If
                If cbxCaseStatus.Text = cbxCaseStatus.Tag Then
                Else
                    Change &= String.Format("Change Case Status from {0} to {1}. ", cbxCaseStatus.Tag, cbxCaseStatus.Text)
                End If
                If txtFindings.Text = txtFindings.Tag Then
                Else
                    Change &= String.Format("Change Case Findings from {0} to {1}. ", txtFindings.Tag, txtFindings.Text)
                End If
                If cbxPositive.Tag <> "Positive" And cbxPositive.Checked Then
                    Change &= String.Format("Change Case Findings Status from {0} to {1}. ", cbxPositive.Tag, "Positive")
                ElseIf cbxNegative.Tag <> "Negative" And cbxNegative.Checked Then
                    Change &= String.Format("Change Case Findings Status from {0} to {1}. ", cbxNegative.Tag, "Negative")
                ElseIf cbxUnestablished.Tag <> "Unestablished" And cbxUnestablished.Checked Then
                    Change &= String.Format("Change Case Findings Status from {0} to {1}. ", cbxUnestablished.Tag, "Unestablished")
                End If
                If txtCACPI.Text = txtCACPI.Tag Then
                Else
                    Change &= String.Format("Change Other Information Pertinent to the case from {0} to {1}. ", txtCACPI.Tag, txtCACPI.Text)
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
                If txtPropertiesRemarks_2.Text = txtPropertiesRemarks_2.Tag Then
                Else
                    Change &= String.Format("Change Properties Remarks 2 from {0} to {1}. ", txtPropertiesRemarks_2.Tag, txtPropertiesRemarks_2.Text)
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
                If txtVehicleRemarks_2.Text = txtVehicleRemarks_2.Tag Then
                Else
                    Change &= String.Format("Change Vehicle Remarks 2 from {0} to {1}. ", txtVehicleRemarks_2.Tag, txtVehicleRemarks_2.Text)
                End If
                If txtOtherProperties.Text = txtOtherProperties.Tag Then
                Else
                    Change &= String.Format("Change Other Properties from {0} to {1}. ", txtOtherProperties.Tag, txtOtherProperties.Text)
                End If
                If rNarrative.Text.InsertQuote = rNarrative.Tag Then
                Else
                    Change &= String.Format("Change Narrative CI Remarks from {0} to {1}. ", rNarrative.Tag, rNarrative.Text.InsertQuote)
                End If
                If txtC1.Text = txtC1.Tag Then
                Else
                    Change &= String.Format("Change Condition 1 from {0} to {1}. ", txtC1.Tag, txtC1.Text)
                End If
                If txtC2.Text = txtC2.Tag Then
                Else
                    Change &= String.Format("Change Condition 2 from {0} to {1}. ", txtC2.Tag, txtC2.Text)
                End If
                If txtC3.Text = txtC3.Tag Then
                Else
                    Change &= String.Format("Change Condition 3 from {0} to {1}. ", txtC3.Tag, txtC3.Text)
                End If
                If txtC4.Text = txtC4.Tag Then
                Else
                    Change &= String.Format("Change Condition 4 from {0} to {1}. ", txtC4.Tag, txtC4.Text)
                End If
                If txtC5.Text = txtC5.Tag Then
                Else
                    Change &= String.Format("Change Condition 5 from {0} to {1}. ", txtC5.Tag, txtC5.Text)
                End If
                If txtC6.Text = txtC6.Tag Then
                Else
                    Change &= String.Format("Change Condition 6 from {0} to {1}. ", txtC6.Tag, txtC6.Text)
                End If
                If txtC7.Text = txtC7.Tag Then
                Else
                    Change &= String.Format("Change Condition 7 from {0} to {1}. ", txtC7.Tag, txtC7.Text)
                End If
                If txtC8.Text = txtC8.Tag Then
                Else
                    Change &= String.Format("Change Condition 8 from {0} to {1}. ", txtC8.Tag, txtC8.Text)
                End If
                If txtC9.Text = txtC9.Tag Then
                Else
                    Change &= String.Format("Change Condition 9 from {0} to {1}. ", txtC9.Tag, txtC9.Text)
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("CoMaker - Changes", ex.Message.ToString)
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
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, CreditNumber)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, CreditNumber))
        End If
        '********CREATE File
        Try
            Dim xPath As String
            xPath = String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, CreditNumber, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = String.Format("CoMaker {0} Attachment", Rank)
            .Type = "Credit App Attachment CoMaker " & Rank
            .TotalImage = TotalImage
            .CreditNumber = CreditNumber
            .ID = CoMakerID_1
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                If FromCreditApplication Then
                    If Rank = 1 Then
                        FrmLoanApplication.TotalImageC1 = .TotalImage
                    ElseIf Rank = 2 Then
                        FrmLoanApplication.TotalImageC2 = .TotalImage
                    ElseIf Rank = 3 Then
                        FrmLoanApplication.TotalImageC3 = .TotalImage
                    ElseIf Rank = 4 Then
                        FrmLoanApplication.TotalImageC4 = .TotalImage
                    End If
                Else
                    If Rank = 1 Then
                        FrmCreditInvestigation.TotalImageC1 = .TotalImage
                    ElseIf Rank = 2 Then
                        FrmCreditInvestigation.TotalImageC2 = .TotalImage
                    ElseIf Rank = 3 Then
                        FrmCreditInvestigation.TotalImageC3 = .TotalImage
                    ElseIf Rank = 4 Then
                        FrmCreditInvestigation.TotalImageC4 = .TotalImage
                    End If
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnID_Click(sender As Object, e As EventArgs) Handles btnID.Click
        Dim ID As New FrmID
        With ID
            .ID_Type = "C" & Rank
            .BorrowerID = Me.BorrowerID
            .From_Borrower = False
            .txtTIN.Text = txtTIN_C1.Text
            .txtSSS.Text = txtSSS_C1.Text
            Dim BorrowerID As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = '{1}'", Me.BorrowerID, "C" & Rank))
            If BorrowerID.Rows.Count > 0 Then
                .txtGSIS.Text = BorrowerID(0)("GSIS")
                .txtPhilHealth.Text = BorrowerID(0)("PhilHealth")
                .txtSenior.Text = BorrowerID(0)("Senior")
                .txtUMID.Text = BorrowerID(0)("UMID")
                .txtSEC.Text = BorrowerID(0)("SEC")
                .txtDTI.Text = BorrowerID(0)("DTI")
                .txtCDA.Text = BorrowerID(0)("CDA")
                .txtCooperative.Text = BorrowerID(0)("Cooperative")
                .txtDrivers.Text = BorrowerID(0)("Drivers")
                If BorrowerID(0)("dDrivers") = "" Then
                Else
                    .dtpDrivers.Value = BorrowerID(0)("dDrivers")
                End If
                .txtVIN.Text = BorrowerID(0)("VIN")
                If BorrowerID(0)("dVIN") = "" Then
                Else
                    .dtpVIN.Value = BorrowerID(0)("dVIN")
                End If
                .txtPassport.Text = BorrowerID(0)("Passport")
                If BorrowerID(0)("dPassport") = "" Then
                Else
                    .dtpPassport.Value = BorrowerID(0)("dPassport")
                End If
                .txtPRC.Text = BorrowerID(0)("PRC")
                If BorrowerID(0)("dPRC") = "" Then
                Else
                    .dtpPRC.Value = BorrowerID(0)("dPRC")
                End If
                .txtNBI.Text = BorrowerID(0)("NBI")
                If BorrowerID(0)("dNBI") = "" Then
                Else
                    .dtpNBI.Value = BorrowerID(0)("dNBI")
                End If
                .txtPolice.Text = BorrowerID(0)("Police")
                If BorrowerID(0)("dPolice") = "" Then
                Else
                    .dtpPolice.Value = BorrowerID(0)("dPolice")
                End If
                .txtPostal.Text = BorrowerID(0)("Postal")
                If BorrowerID(0)("dPostal") = "" Then
                Else
                    .dtpPostal.Value = BorrowerID(0)("dPostal")
                End If
                .txtBarangay.Text = BorrowerID(0)("Barangay")
                If BorrowerID(0)("dBarangay") = "" Then
                Else
                    .dtpBarangay.Value = BorrowerID(0)("dBarangay")
                End If
                .txtOWWA.Text = BorrowerID(0)("OWWA")
                If BorrowerID(0)("dOWWA") = "" Then
                Else
                    .dtpOWWA.Value = BorrowerID(0)("dOWWA")
                End If
                .txtOFW.Text = BorrowerID(0)("OFW")
                If BorrowerID(0)("dOFW") = "" Then
                Else
                    .dtpOFW.Value = BorrowerID(0)("dOFW")
                End If
                .txtSeaman.Text = BorrowerID(0)("Seaman")
                If BorrowerID(0)("dSeaman") = "" Then
                Else
                    .dtpSeaman.Value = BorrowerID(0)("dSeaman")
                End If
                .txtPNP.Text = BorrowerID(0)("PNP")
                If BorrowerID(0)("dPNP") = "" Then
                Else
                    .dtpPNP.Value = BorrowerID(0)("dPNP")
                End If
                .txtAFP.Text = BorrowerID(0)("AFP")
                If BorrowerID(0)("dAFP") = "" Then
                Else
                    .dtpAFP.Value = BorrowerID(0)("dAFP")
                End If
                .txtHDMF.Text = BorrowerID(0)("HDMF")
                If BorrowerID(0)("dHDMF") = "" Then
                Else
                    .dtpHDMF.Value = BorrowerID(0)("dHDMF")
                End If
                .txtPWD.Text = BorrowerID(0)("PWD")
                If BorrowerID(0)("dPWD") = "" Then
                Else
                    .dtpPWD.Value = BorrowerID(0)("dPWD")
                End If
                .txtDSWD.Text = BorrowerID(0)("DSWD")
                If BorrowerID(0)("dDSWD") = "" Then
                Else
                    .dtpDSWD.Value = BorrowerID(0)("dDSWD")
                End If
                .txtACR.Text = BorrowerID(0)("ACR")
                If BorrowerID(0)("dACR") = "" Then
                Else
                    .dtpACR.Value = BorrowerID(0)("dACR")
                End If
                .txtDTI_Business.Text = BorrowerID(0)("DTI_Business")
                If BorrowerID(0)("dDTI_Business") = "" Then
                Else
                    .dtpDTI_Business.Value = BorrowerID(0)("dDTI_Business")
                End If
                .txtIBP.Text = BorrowerID(0)("IBP")
                If BorrowerID(0)("dIBP") = "" Then
                Else
                    .dtpIBP.Value = BorrowerID(0)("dIBP")
                End If
                .txtFireArms.Text = BorrowerID(0)("FireArms")
                If BorrowerID(0)("dFireArms") = "" Then
                Else
                    .dtpFireArms.Value = BorrowerID(0)("dFireArms")
                End If
                .txtGovernment.Text = BorrowerID(0)("Government")
                If BorrowerID(0)("dGovernment") = "" Then
                Else
                    .dtpGovernment.Value = BorrowerID(0)("dGovernment")
                End If
                .txtDiplomat.Text = BorrowerID(0)("Diplomat")
                If BorrowerID(0)("dDiplomat") = "" Then
                Else
                    .dtpDiplomat.Value = BorrowerID(0)("dDiplomat")
                End If
                .txtNational.Text = BorrowerID(0)("National")
                If BorrowerID(0)("dNational") = "" Then
                Else
                    .dtpNational.Value = BorrowerID(0)("dNational")
                End If
                .txtWork.Text = BorrowerID(0)("Work")
                If BorrowerID(0)("dWork") = "" Then
                Else
                    .dtpWork.Value = BorrowerID(0)("dWork")
                End If
                .txtGOCC.Text = BorrowerID(0)("GOCC")
                If BorrowerID(0)("dGOCC") = "" Then
                Else
                    .dtpGOCC.Value = BorrowerID(0)("dGOCC")
                End If
                .txtPLRA.Text = BorrowerID(0)("PLRA")
                If BorrowerID(0)("dPLRA") = "" Then
                Else
                    .dtpPLRA.Value = BorrowerID(0)("dPLRA")
                End If
                .txtMajor.Text = BorrowerID(0)("Major")
                If BorrowerID(0)("dMajor") = "" Then
                Else
                    .dtpMajor.Value = BorrowerID(0)("dMajor")
                End If
                .txtMedia.Text = BorrowerID(0)("Media")
                If BorrowerID(0)("dMedia") = "" Then
                Else
                    .dtpMedia.Value = BorrowerID(0)("dMedia")
                End If
                .txtStudent.Text = BorrowerID(0)("Student")
                If BorrowerID(0)("dStudent") = "" Then
                Else
                    .dtpStudent.Value = BorrowerID(0)("dStudent")
                End If
                .txtSIRV.Text = BorrowerID(0)("SIRV")
                If BorrowerID(0)("dSIRV") = "" Then
                Else
                    .dtpSIRV.Value = BorrowerID(0)("dSIRV")
                End If

                .TotalImage_TIN = BorrowerID(0)("Attach_TIN")
                .TotalImage_SSS = BorrowerID(0)("Attach_SSS")
                .TotalImage_GSIS = BorrowerID(0)("Attach_GSIS")
                .TotalImage_PhilHealth = BorrowerID(0)("Attach_PhilHealth")
                .TotalImage_Senior = BorrowerID(0)("Attach_Senior")
                .TotalImage_UMID = BorrowerID(0)("Attach_UMID")
                .TotalImage_SEC = BorrowerID(0)("Attach_SEC")
                .TotalImage_DTI = BorrowerID(0)("Attach_DTI")
                .TotalImage_CDA = BorrowerID(0)("Attach_CDA")
                .TotalImage_Cooperative = BorrowerID(0)("Attach_Cooperative")
                .TotalImage_Drivers = BorrowerID(0)("Attach_Drivers")
                .TotalImage_VIN = BorrowerID(0)("Attach_VIN")
                .TotalImage_Passport = BorrowerID(0)("Attach_Passport")
                .TotalImage_PRC = BorrowerID(0)("Attach_PRC")
                .TotalImage_NBI = BorrowerID(0)("Attach_NBI")
                .TotalImage_Police = BorrowerID(0)("Attach_Police")
                .TotalImage_Postal = BorrowerID(0)("Attach_Postal")
                .TotalImage_Barangay = BorrowerID(0)("Attach_Barangay")
                .TotalImage_OWWA = BorrowerID(0)("Attach_OWWA")
                .TotalImage_OFW = BorrowerID(0)("Attach_OFW")
                .TotalImage_Seaman = BorrowerID(0)("Attach_Seaman")
                .TotalImage_PNP = BorrowerID(0)("Attach_PNP")
                .TotalImage_AFP = BorrowerID(0)("Attach_AFP")
                .TotalImage_HDMF = BorrowerID(0)("Attach_HDMF")
                .TotalImage_PWD = BorrowerID(0)("Attach_PWD")
                .TotalImage_DSWD = BorrowerID(0)("Attach_DSWD")
                .TotalImage_ACR = BorrowerID(0)("Attach_ACR")
                .TotalImage_DTI_Business = BorrowerID(0)("Attach_DTI_Business")
                .TotalImage_IBP = BorrowerID(0)("Attach_IBP")
                .TotalImage_FireArms = BorrowerID(0)("Attach_FireArms")
                .TotalImage_Government = BorrowerID(0)("Attach_Government")
                .TotalImage_Diplomat = BorrowerID(0)("Attach_Diplomat")
                .TotalImage_National = BorrowerID(0)("Attach_National")
                .TotalImage_Work = BorrowerID(0)("Attach_Work")
                .TotalImage_GOCC = BorrowerID(0)("Attach_GOCC")
                .TotalImage_PLRA = BorrowerID(0)("Attach_PLRA")
                .TotalImage_Major = BorrowerID(0)("Attach_Major")
                .TotalImage_Media = BorrowerID(0)("Attach_Media")
                .TotalImage_Student = BorrowerID(0)("Attach_Student")
                .TotalImage_SIRV = BorrowerID(0)("Attach_SIRV")
            End If

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

            If .ShowDialog = DialogResult.OK Then
                txtTIN_C1.Text = .txtTIN.Text
                txtSSS_C1.Text = .txtSSS.Text
                TIN_C1 = .txtTIN.Text
                SSS_C1 = .txtTIN.Text
                GSIS_C1 = .txtGSIS.Text
                PhilHealth_C1 = .txtPhilHealth.Text
                Senior_C1 = .txtSenior.Text
                UMID_C1 = .txtUMID.Text
                SEC_C1 = .txtSEC.Text
                DTI_C1 = .txtDTI.Text
                CDA_C1 = .txtCDA.Text
                Cooperative_C1 = .txtCooperative.Text
                Drivers_C1 = .txtDrivers.Text
                dDrivers_C1 = FormatDatePicker(.dtpDrivers)
                VIN_C1 = .txtVIN.Text
                dVIN_C1 = FormatDatePicker(.dtpVIN)
                Passport_C1 = .txtPassport.Text
                dPassport_C1 = FormatDatePicker(.dtpPassport)
                PRC_C1 = .txtPRC.Text
                dPRC_C1 = FormatDatePicker(.dtpPRC)
                NBI_C1 = .txtNBI.Text
                dNBI_C1 = FormatDatePicker(.dtpNBI)
                Police_C1 = .txtPolice.Text
                dPolice_C1 = FormatDatePicker(.dtpPolice)
                Postal_C1 = .txtPostal.Text
                dPostal_C1 = FormatDatePicker(.dtpPostal)
                Barangay_C1 = .txtBarangay.Text
                dBarangay_C1 = FormatDatePicker(.dtpBarangay)
                OWWA_C1 = .txtOWWA.Text
                dOWWA_C1 = FormatDatePicker(.dtpOWWA)
                OFW_C1 = .txtOFW.Text
                dOFW_C1 = FormatDatePicker(.dtpOFW)
                Seaman_C1 = .txtSeaman.Text
                dSeaman_C1 = FormatDatePicker(.dtpSeaman)
                PNP_C1 = .txtPNP.Text
                dPNP_C1 = FormatDatePicker(.dtpPNP)
                AFP_C1 = .txtAFP.Text
                dAFP_C1 = FormatDatePicker(.dtpAFP)
                HDMF_C1 = .txtHDMF.Text
                dHDMF_C1 = FormatDatePicker(.dtpHDMF)
                PWD_C1 = .txtPWD.Text
                dPWD_C1 = FormatDatePicker(.dtpPWD)
                DSWD_C1 = .txtDSWD.Text
                dDSWD_C1 = FormatDatePicker(.dtpDSWD)
                ACR_C1 = .txtACR.Text
                dACR_C1 = FormatDatePicker(.dtpACR)
                DTI_Business_C1 = .txtDTI_Business.Text
                dDTI_Business_C1 = FormatDatePicker(.dtpDTI_Business)
                IBP_C1 = .txtIBP.Text
                dIBP_C1 = FormatDatePicker(.dtpIBP)
                FireArms_C1 = .txtFireArms.Text
                dFireArms_C1 = FormatDatePicker(.dtpFireArms)
                Government_C1 = .txtGovernment.Text
                dGovernment_C1 = FormatDatePicker(.dtpGovernment)
                Diplomat_C1 = .txtDiplomat.Text
                dDiplomat_C1 = FormatDatePicker(.dtpDiplomat)
                National_C1 = .txtNational.Text
                dNational_C1 = FormatDatePicker(.dtpNational)
                Work_C1 = .txtWork.Text
                dWork_C1 = FormatDatePicker(.dtpWork)
                GOCC_C1 = .txtGOCC.Text
                dGOCC_C1 = FormatDatePicker(.dtpGOCC)
                PLRA_C1 = .txtPLRA.Text
                dPLRA_C1 = FormatDatePicker(.dtpPLRA)
                Major_C1 = .txtMajor.Text
                dMajor_C1 = FormatDatePicker(.dtpMajor)
                Media_C1 = .txtMedia.Text
                dMedia_C1 = FormatDatePicker(.dtpMedia)
                Student_C1 = .txtStudent.Text
                dStudent_C1 = FormatDatePicker(.dtpStudent)
                SIRV_C1 = .txtSIRV.Text
                dSIRV_C1 = FormatDatePicker(.dtpSIRV)
            End If
            .Dispose()
        End With
    End Sub

    'ADDITIONAL FOR CREDIT INVESTIGATION REPORT ***************************************************************************************************

    Private Sub TxtCreditName_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditor_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditAddress_1.Focus()
        End If
    End Sub

    Private Sub TxtCreditAddress_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditAddress_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpCreditGranted_1.Focus()
        End If
    End Sub

    Private Sub DtpCreditGranted_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCreditGranted_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            iTerm_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpCreditGranted_1.CustomFormat = ""
        End If
    End Sub

    Private Sub ICreditTerm_1_KeyDown(sender As Object, e As KeyEventArgs) Handles iTerm_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountGranted_1.Focus()
        End If
    End Sub

    Private Sub DCreditPrincipal_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountGranted_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_1.Focus()
        End If
    End Sub

    Private Sub DCreditOutstanding_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCreditPayment_1.Focus()
        End If
    End Sub

    Private Sub DCreditPayment_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dCreditPayment_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditRemarks_1.Focus()
        End If
    End Sub

    Private Sub TxtCreditRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditor_2.Focus()
        End If
    End Sub

    Private Sub TxtCreditName_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditor_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditAddress_2.Focus()
        End If
    End Sub

    Private Sub TxtCreditAddress_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditAddress_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpCreditGranted_2.Focus()
        End If
    End Sub

    Private Sub DtpCreditGranted_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCreditGranted_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            iTerm_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpCreditGranted_2.CustomFormat = ""
        End If
    End Sub

    Private Sub ICreditTerm_2_KeyDown(sender As Object, e As KeyEventArgs) Handles iTerm_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountGranted_2.Focus()
        End If
    End Sub

    Private Sub DCreditPrincipal_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountGranted_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_2.Focus()
        End If
    End Sub

    Private Sub DCreditOutstanding_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCreditPayment_2.Focus()
        End If
    End Sub

    Private Sub DCreditPayment_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dCreditPayment_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCreditRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtCreditRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCreditRemarks_2.KeyDown
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

    Private Sub DADB_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAverageBalance_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOpened_1.Focus()
        End If
    End Sub

    Private Sub DtpOpened_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOpened_1.KeyDown
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

    Private Sub DADB_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAverageBalance_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOpened_2.Focus()
        End If
    End Sub

    Private Sub DtpOpened_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOpened_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxGood.Focus()
        End If
    End Sub

    Private Sub CbxGood_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGood.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFair.Focus()
        End If
    End Sub

    Private Sub CbxFair_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFair.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPoor.Focus()
        End If
    End Sub

    Private Sub CbxPoor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPoor.KeyDown
        If e.KeyCode = Keys.Enter Then
            rRecommendation.Focus()
        End If
    End Sub

    Private Sub RRecommendation_KeyDown(sender As Object, e As KeyEventArgs) Handles rRecommendation.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTitle.Focus()
        End If
    End Sub

    Private Sub TxtTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCaseNum.Focus()
        End If
    End Sub

    Private Sub TxtCaseNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCaseNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDateFilled.Focus()
        End If
    End Sub

    Private Sub DtpDateFilled_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDateFilled.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCourt.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpDateFilled.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxCourt_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCourt.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCaseNature.Focus()
        End If
    End Sub

    Private Sub CbxCaseNature_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCaseNature.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCaseStatus.Focus()
        End If
    End Sub

    Private Sub CbxCaseStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCaseStatus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFindings.Focus()
        End If
    End Sub

    Private Sub CbxFindings_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFindings.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPositive.Focus()
        End If
    End Sub

    Private Sub CbxPositive_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPositive.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNegative.Focus()
        End If
    End Sub

    Private Sub CbxNegative_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNegative.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxUnestablished.Focus()
        End If
    End Sub

    Private Sub CbxUnestablished_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxUnestablished.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCACPI.Focus()
        End If
    End Sub

    'PROPERTY CHECKING
    Private Sub TxtCACPI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCACPI.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabProperty
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
            txtPropertiesRemarks_1.Focus()
        End If
    End Sub

    Private Sub TxtRealEstateRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropertiesRemarks_1.KeyDown
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
            txtPropertiesRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtRealEstateRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPropertiesRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicle_1.Focus()
        End If
    End Sub

    Private Sub TxtVehicles_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicle_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear_1.Focus()
        End If
    End Sub

    Private Sub DtpModel_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhomAcquired_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear_1.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtAcquired_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhomAcquired_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicleRemarks_1.Focus()
        End If
    End Sub

    Private Sub TxtVehicleRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicleRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicle_2.Focus()
        End If
    End Sub

    Private Sub TxtVehicles_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicle_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear_2.Focus()
        End If
    End Sub

    Private Sub DtpModel_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWhomAcquired_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear_2.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtAcquired_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWhomAcquired_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVehicleRemarks_2.Focus()
        End If
    End Sub

    Private Sub TxtVehicleRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVehicleRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherProperties.Focus()
        End If
    End Sub

    Private Sub TxtOtherProperties_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherProperties.KeyDown
        If e.KeyCode = Keys.Enter Then
            rNarrative.Focus()
        End If
    End Sub

    'ADDITIONAL INFO
    Private Sub RNarrative_KeyDown(sender As Object, e As KeyEventArgs) Handles rNarrative.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtC1.Focus()
        End If
    End Sub

    Private Sub TxtC1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC2.Enabled Then
                txtC2.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC3.Enabled Then
                txtC3.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC4.Enabled Then
                txtC4.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC4.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC5.Enabled Then
                txtC5.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC5.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC6.Enabled Then
                txtC6.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC6_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC6.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC7.Enabled Then
                txtC7.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC7_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC7.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC8.Enabled Then
                txtC8.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC8_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC8.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtC9.Enabled Then
                txtC9.Focus()
            Else
                SuperTabControl2.SelectedTab = tabAdditional
                dLiving.Focus()
            End If
        End If
    End Sub

    Private Sub TxtC9_KeyDown(sender As Object, e As KeyEventArgs) Handles txtC9.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabAdditional
            dLiving.Focus()
        End If
    End Sub

    Private Sub DTotalDisposable_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalDisposable.KeyDown
        If e.KeyCode = Keys.Enter Then
            dLiving.Focus()
        End If
    End Sub

    Private Sub DLiving_KeyDown(sender As Object, e As KeyEventArgs) Handles dLiving.KeyDown
        If e.KeyCode = Keys.Enter Then
            dClothing.Focus()
        End If
    End Sub

    Private Sub DClothing_KeyDown(sender As Object, e As KeyEventArgs) Handles dClothing.KeyDown
        If e.KeyCode = Keys.Enter Then
            dEducation.Focus()
        End If
    End Sub

    Private Sub DEducation_KeyDown(sender As Object, e As KeyEventArgs) Handles dEducation.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTransportation.Focus()
        End If
    End Sub

    Private Sub DTransportation_KeyDown(sender As Object, e As KeyEventArgs) Handles dTransportation.KeyDown
        If e.KeyCode = Keys.Enter Then
            dLighths.Focus()
        End If
    End Sub

    Private Sub DLighths_KeyDown(sender As Object, e As KeyEventArgs) Handles dLighths.KeyDown
        If e.KeyCode = Keys.Enter Then
            dInsurance.Focus()
        End If
    End Sub

    Private Sub DInsurance_KeyDown(sender As Object, e As KeyEventArgs) Handles dInsurance.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmortization.Focus()
        End If
    End Sub

    Private Sub DAmortization_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmortization.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMiscellaneous.Focus()
        End If
    End Sub

    Private Sub DMiscellaneous_KeyDown(sender As Object, e As KeyEventArgs) Handles dMiscellaneous.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalExpenses.Focus()
        End If
    End Sub

    Private Sub DTotalExpenses_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalExpenses.KeyDown
        If e.KeyCode = Keys.Enter Then
            dNetDisposable.Focus()
        End If
    End Sub

    Private Sub DNetDisposable_KeyDown(sender As Object, e As KeyEventArgs) Handles dNetDisposable.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtExpenseRemarks.Focus()
        End If
    End Sub

    Private Sub TxtExpenseRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExpenseRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            rPurposeLoan.Focus()
        End If
    End Sub

    Private Sub DTMFI_KeyDown(sender As Object, e As KeyEventArgs) Handles dTMFI.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTMDI.Focus()
        End If
    End Sub

    Private Sub DTMDI_KeyDown(sender As Object, e As KeyEventArgs) Handles dTMDI.KeyDown
        If e.KeyCode = Keys.Enter Then
            rPurposeLoan.Focus()
        End If
    End Sub

    Private Sub RPurposeLoan_KeyDown(sender As Object, e As KeyEventArgs) Handles rPurposeLoan.KeyDown
        If e.KeyCode = Keys.Enter Then
            rOthers.Focus()
        End If
    End Sub

    Private Sub ROthers_KeyDown(sender As Object, e As KeyEventArgs) Handles rOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            pbSketch.Focus()
        End If
    End Sub

    'LEAVE **********************

    Private Sub TxtCreditName_1_Leave(sender As Object, e As EventArgs) Handles txtCreditor_1.Leave
        txtCreditor_1.Text = ReplaceText(txtCreditor_1.Text.Trim)
    End Sub

    Private Sub TxtCreditAddress_1_Leave(sender As Object, e As EventArgs) Handles txtCreditAddress_1.Leave
        txtCreditAddress_1.Text = ReplaceText(txtCreditAddress_1.Text.Trim)
    End Sub

    Private Sub TxtCreditRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtCreditRemarks_1.Leave
        txtCreditRemarks_1.Text = ReplaceText(txtCreditRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtCreditName_2_Leave(sender As Object, e As EventArgs) Handles txtCreditor_2.Leave
        txtCreditor_2.Text = ReplaceText(txtCreditor_2.Text.Trim)
    End Sub

    Private Sub TxtCreditAddress_2_Leave(sender As Object, e As EventArgs) Handles txtCreditAddress_2.Leave
        txtCreditAddress_2.Text = ReplaceText(txtCreditAddress_2.Text.Trim)
    End Sub

    Private Sub TxtCreditRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtCreditRemarks_2.Leave
        txtCreditRemarks_2.Text = ReplaceText(txtCreditRemarks_2.Text.Trim)
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

    Private Sub TxtBank_2_Leave(sender As Object, e As EventArgs) Handles txtBank_2.Leave
        txtBank_2.Text = ReplaceText(txtBank_2.Text.Trim)
    End Sub

    Private Sub TxtBranch_2_Leave(sender As Object, e As EventArgs) Handles txtBranch_2.Leave
        txtBranch_2.Text = ReplaceText(txtBranch_2.Text.Trim)
    End Sub

    Private Sub TxtAccountNum_2_Leave(sender As Object, e As EventArgs) Handles txtSA_2.Leave
        txtSA_2.Text = ReplaceText(txtSA_2.Text.Trim)
    End Sub

    Private Sub RRecommendation_Leave(sender As Object, e As EventArgs) Handles rRecommendation.Leave
        rRecommendation.Text = ReplaceText(rRecommendation.Text.Trim)
    End Sub

    Private Sub TxtTitle_Leave(sender As Object, e As EventArgs) Handles txtTitle.Leave
        txtTitle.Text = ReplaceText(txtTitle.Text.Trim)
    End Sub

    Private Sub TxtCaseNum_Leave(sender As Object, e As EventArgs) Handles txtCaseNum.Leave
        txtCaseNum.Text = ReplaceText(txtCaseNum.Text.Trim)
    End Sub

    Private Sub CbxCourt_Leave(sender As Object, e As EventArgs) Handles cbxCourt.Leave
        cbxCourt.Text = ReplaceText(cbxCourt.Text.Trim)
    End Sub

    Private Sub CbxCaseNature_Leave(sender As Object, e As EventArgs) Handles cbxCaseNature.Leave
        cbxCaseNature.Text = ReplaceText(cbxCaseNature.Text.Trim)
    End Sub

    Private Sub CbxCaseStatus_Leave(sender As Object, e As EventArgs) Handles cbxCaseStatus.Leave
        cbxCaseStatus.Text = ReplaceText(cbxCaseStatus.Text.Trim)
    End Sub

    Private Sub CbxFindings_Leave(sender As Object, e As EventArgs) Handles txtFindings.Leave
        txtFindings.Text = ReplaceText(txtFindings.Text.Trim)
    End Sub

    Private Sub TxtCACPI_Leave(sender As Object, e As EventArgs) Handles txtCACPI.Leave
        txtCACPI.Text = ReplaceText(txtCACPI.Text.Trim)
    End Sub

    Private Sub TxtLocation_1_Leave(sender As Object, e As EventArgs) Handles txtLocation_1.Leave
        txtLocation_1.Text = ReplaceText(txtLocation_1.Text.Trim)
    End Sub

    Private Sub TxtTCT_1_Leave(sender As Object, e As EventArgs) Handles txtTCT_1.Leave
        txtTCT_1.Text = ReplaceText(txtTCT_1.Text.Trim)
    End Sub

    Private Sub TxtRealEstateRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtPropertiesRemarks_1.Leave
        txtPropertiesRemarks_1.Text = ReplaceText(txtPropertiesRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtLocation_2_Leave(sender As Object, e As EventArgs) Handles txtLocation_2.Leave
        txtLocation_2.Text = ReplaceText(txtLocation_2.Text.Trim)
    End Sub

    Private Sub TxtTCT_2_Leave(sender As Object, e As EventArgs) Handles txtTCT_2.Leave
        txtTCT_2.Text = ReplaceText(txtTCT_2.Text.Trim)
    End Sub

    Private Sub TxtRealEstateRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtPropertiesRemarks_2.Leave
        txtPropertiesRemarks_2.Text = ReplaceText(txtPropertiesRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtVehicles_1_Leave(sender As Object, e As EventArgs) Handles txtVehicle_1.Leave
        txtVehicle_1.Text = ReplaceText(txtVehicle_1.Text.Trim)
    End Sub

    Private Sub TxtAcquired_1_Leave(sender As Object, e As EventArgs) Handles txtWhomAcquired_1.Leave
        txtWhomAcquired_1.Text = ReplaceText(txtWhomAcquired_1.Text.Trim)
    End Sub

    Private Sub TxtVehicleRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtVehicleRemarks_1.Leave
        txtVehicleRemarks_1.Text = ReplaceText(txtVehicleRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtVehicles_2_Leave(sender As Object, e As EventArgs) Handles txtVehicle_2.Leave
        txtVehicle_2.Text = ReplaceText(txtVehicle_2.Text.Trim)
    End Sub

    Private Sub TxtAcquired_2_Leave(sender As Object, e As EventArgs) Handles txtWhomAcquired_2.Leave
        txtWhomAcquired_2.Text = ReplaceText(txtWhomAcquired_2.Text.Trim)
    End Sub

    Private Sub TxtVehicleRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtVehicleRemarks_2.Leave
        txtVehicleRemarks_2.Text = ReplaceText(txtVehicleRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtOtherProperties_Leave(sender As Object, e As EventArgs) Handles txtOtherProperties.Leave
        txtOtherProperties.Text = ReplaceText(txtOtherProperties.Text.Trim)
    End Sub

    Private Sub RNarrative_Leave(sender As Object, e As EventArgs) Handles rNarrative.Leave
        rNarrative.Text = ReplaceTextWithQuote(rNarrative.Text.Trim)
    End Sub

    Private Sub TxtC1_Leave(sender As Object, e As EventArgs) Handles txtC1.Leave
        txtC1.Text = ReplaceTextWithQuote(txtC1.Text.Trim)
    End Sub

    Private Sub TxtC2_Leave(sender As Object, e As EventArgs) Handles txtC2.Leave
        txtC2.Text = ReplaceTextWithQuote(txtC2.Text.Trim)
    End Sub

    Private Sub TxtC3_Leave(sender As Object, e As EventArgs) Handles txtC3.Leave
        txtC3.Text = ReplaceTextWithQuote(txtC3.Text.Trim)
    End Sub

    Private Sub TxtC4_Leave(sender As Object, e As EventArgs) Handles txtC4.Leave
        txtC4.Text = ReplaceTextWithQuote(txtC4.Text.Trim)
    End Sub

    Private Sub TxtC5_Leave(sender As Object, e As EventArgs) Handles txtC5.Leave
        txtC5.Text = ReplaceTextWithQuote(txtC5.Text.Trim)
    End Sub

    Private Sub TxtC6_Leave(sender As Object, e As EventArgs) Handles txtC6.Leave
        txtC6.Text = ReplaceTextWithQuote(txtC6.Text.Trim)
    End Sub

    Private Sub TxtC7_Leave(sender As Object, e As EventArgs) Handles txtC7.Leave
        txtC7.Text = ReplaceTextWithQuote(txtC7.Text.Trim)
    End Sub

    Private Sub TxtC8_Leave(sender As Object, e As EventArgs) Handles txtC8.Leave
        txtC8.Text = ReplaceTextWithQuote(txtC8.Text.Trim)
    End Sub

    Private Sub TxtC9_Leave(sender As Object, e As EventArgs) Handles txtC9.Leave
        txtC9.Text = ReplaceTextWithQuote(txtC9.Text.Trim)
    End Sub

    Private Sub RPurposeLoan_Leave(sender As Object, e As EventArgs) Handles rPurposeLoan.Leave
        rPurposeLoan.Text = ReplaceTextWithQuote(rPurposeLoan.Text.Trim)
    End Sub

    Private Sub ROthers_Leave(sender As Object, e As EventArgs) Handles rOthers.Leave
        rOthers.Text = ReplaceTextWithQuote(rOthers.Text.Trim)
    End Sub

    Private Sub TxtCreditName_1_TextChanged(sender As Object, e As EventArgs) Handles txtCreditor_1.TextChanged
        If txtCreditor_1.Text.Trim = "" Then
            txtCreditAddress_1.Enabled = False
            dtpCreditGranted_1.Enabled = False
            iTerm_1.Enabled = False
            dAmountGranted_1.Enabled = False
            dBalance_1.Enabled = False
            dCreditPayment_1.Enabled = False
            txtCreditRemarks_1.Enabled = False
            txtCreditor_2.Enabled = False

            txtCreditAddress_1.Text = ""
            iTerm_1.Value = 0
            dAmountGranted_1.Value = 0
            dBalance_1.Value = 0
            dCreditPayment_1.Value = 0
            txtCreditRemarks_1.Text = ""
            txtCreditor_2.Text = ""

            dtpCreditGranted_1.CustomFormat = ""
        Else
            txtCreditAddress_1.Enabled = True
            dtpCreditGranted_1.Enabled = True
            iTerm_1.Enabled = True
            dAmountGranted_1.Enabled = True
            dBalance_1.Enabled = True
            dCreditPayment_1.Enabled = True
            txtCreditRemarks_1.Enabled = True
            txtCreditor_2.Enabled = True

            dtpCreditGranted_1.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtCreditName_2_TextChanged(sender As Object, e As EventArgs) Handles txtCreditor_2.TextChanged
        If txtCreditor_2.Text.Trim = "" Then
            txtCreditAddress_2.Enabled = False
            dtpCreditGranted_2.Enabled = False
            iTerm_2.Enabled = False
            dAmountGranted_2.Enabled = False
            dBalance_2.Enabled = False
            dCreditPayment_2.Enabled = False
            txtCreditRemarks_2.Enabled = False

            txtCreditAddress_2.Text = ""
            iTerm_2.Value = 0
            dAmountGranted_2.Value = 0
            dBalance_2.Value = 0
            dCreditPayment_2.Value = 0
            txtCreditRemarks_2.Text = ""

            dtpCreditGranted_2.CustomFormat = ""
        Else
            txtCreditAddress_2.Enabled = True
            dtpCreditGranted_2.Enabled = True
            iTerm_2.Enabled = True
            dAmountGranted_2.Enabled = True
            dBalance_2.Enabled = True
            dCreditPayment_2.Enabled = True
            txtCreditRemarks_2.Enabled = True

            dtpCreditGranted_2.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtBank_1_TextChanged(sender As Object, e As EventArgs) Handles txtBank_1.TextChanged
        If txtBank_1.Text.Trim = "" Then
            txtBranch_1.Enabled = False
            cbxSA_1.Enabled = False
            cbxCA_1.Enabled = False
            txtSA_1.Enabled = False
            dAverageBalance_1.Enabled = False
            txtOpened_1.Enabled = False
            txtBank_2.Enabled = False

            txtBranch_1.Text = ""
            cbxSA_1.Checked = False
            cbxCA_1.Checked = False
            txtSA_1.Text = ""
            dAverageBalance_1.Value = 0
            txtBank_2.Text = ""
        Else
            txtBranch_1.Enabled = True
            cbxSA_1.Enabled = True
            cbxCA_1.Enabled = True
            txtSA_1.Enabled = True
            dAverageBalance_1.Enabled = True
            txtOpened_1.Enabled = True
            txtBank_2.Enabled = True
        End If
    End Sub

    Private Sub TxtBank_2_TextChanged(sender As Object, e As EventArgs) Handles txtBank_2.TextChanged
        If txtBank_2.Text.Trim = "" Then
            txtBranch_2.Enabled = False
            cbxSA_2.Enabled = False
            cbxCA_2.Enabled = False
            txtSA_2.Enabled = False
            dAverageBalance_2.Enabled = False
            txtOpened_2.Enabled = False

            txtBranch_2.Text = ""
            cbxSA_2.Checked = False
            cbxCA_2.Checked = False
            txtSA_2.Text = ""
            dAverageBalance_2.Value = 0
        Else
            txtBranch_2.Enabled = True
            cbxSA_2.Enabled = True
            cbxCA_2.Enabled = True
            txtSA_2.Enabled = True
            dAverageBalance_2.Enabled = True
            txtOpened_2.Enabled = True
        End If
    End Sub

    Private Sub TxtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged
        If txtTitle.Text.Trim = "" Then
            txtCaseNum.Enabled = False
            dtpDateFilled.Enabled = False
            cbxCourt.Enabled = False
            cbxCaseNature.Enabled = False
            dAmountInvolved.Enabled = False
            cbxCaseStatus.Enabled = False
            txtFindings.Enabled = False
            cbxPositive.Enabled = False
            cbxNegative.Enabled = False
            cbxUnestablished.Enabled = False
            txtCACPI.Enabled = False

            txtCaseNum.Text = ""
            cbxCourt.Text = ""
            cbxCaseNature.Text = ""
            dAmountInvolved.Value = 0
            cbxCaseStatus.Text = ""
            txtFindings.Text = ""
            cbxPositive.Checked = False
            cbxNegative.Checked = False
            cbxUnestablished.Checked = False
            txtCACPI.Text = ""

            dtpDateFilled.CustomFormat = ""
        Else
            txtCaseNum.Enabled = True
            dtpDateFilled.Enabled = True
            cbxCourt.Enabled = True
            cbxCaseNature.Enabled = True
            dAmountInvolved.Enabled = True
            cbxCaseStatus.Enabled = True
            txtFindings.Enabled = True
            cbxPositive.Enabled = True
            cbxNegative.Enabled = True
            cbxUnestablished.Enabled = True
            txtCACPI.Enabled = True

            dtpDateFilled.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtLocation_1_TextChanged(sender As Object, e As EventArgs) Handles txtLocation_1.TextChanged
        If txtLocation_1.Text.Trim = "" Then
            txtTCT_1.Enabled = False
            dArea_1.Enabled = False
            txtPropertiesRemarks_1.Enabled = False
            txtLocation_2.Enabled = False

            txtTCT_1.Text = ""
            dArea_1.Value = 0
            txtPropertiesRemarks_1.Text = ""
            txtLocation_2.Text = ""
        Else
            txtTCT_1.Enabled = True
            dArea_1.Enabled = True
            txtPropertiesRemarks_1.Enabled = True
            txtLocation_2.Enabled = True
        End If
    End Sub

    Private Sub TxtLocation_2_TextChanged(sender As Object, e As EventArgs) Handles txtLocation_2.TextChanged
        If txtLocation_2.Text.Trim = "" Then
            txtTCT_2.Enabled = False
            dArea_2.Enabled = False
            txtPropertiesRemarks_2.Enabled = False

            txtTCT_2.Text = ""
            dArea_2.Value = 0
            txtPropertiesRemarks_2.Text = ""
        Else
            txtTCT_2.Enabled = True
            dArea_2.Enabled = True
            txtPropertiesRemarks_2.Enabled = True
        End If
    End Sub

    Private Sub TxtVehicles_1_TextChanged(sender As Object, e As EventArgs) Handles txtVehicle_1.TextChanged
        If txtVehicle_1.Text.Trim = "" Then
            dtpYear_1.Enabled = False
            txtWhomAcquired_1.Enabled = False
            txtVehicleRemarks_1.Enabled = False
            txtVehicle_2.Enabled = False

            dtpYear_1.CustomFormat = ""

            txtWhomAcquired_1.Text = ""
            txtVehicleRemarks_1.Text = ""
            txtVehicle_2.Text = ""
        Else
            dtpYear_1.Enabled = True
            txtWhomAcquired_1.Enabled = True
            txtVehicleRemarks_1.Enabled = True
            txtVehicle_2.Enabled = True

            dtpYear_1.CustomFormat = "     yyyy"
        End If
    End Sub

    Private Sub TxtVehicles_2_TextChanged(sender As Object, e As EventArgs) Handles txtVehicle_2.TextChanged
        If txtVehicle_2.Text.Trim = "" Then
            dtpYear_2.Enabled = False
            txtWhomAcquired_2.Enabled = False
            txtVehicleRemarks_2.Enabled = False

            dtpYear_2.CustomFormat = ""

            txtWhomAcquired_2.Text = ""
            txtVehicleRemarks_2.Text = ""
        Else
            dtpYear_2.Enabled = True
            txtWhomAcquired_2.Enabled = True
            txtVehicleRemarks_2.Enabled = True

            dtpYear_2.CustomFormat = "     yyyy"
        End If
    End Sub

    Private Sub DTotalDisposable_ValueChanged(sender As Object, e As EventArgs) Handles dTotalDisposable.ValueChanged
        dNetDisposable.Value = dTotalDisposable.Value - dTotalExpenses.Value
    End Sub

    Private Sub DLiving_ValueChanged(sender As Object, e As EventArgs) Handles dLiving.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DClothing_ValueChanged(sender As Object, e As EventArgs) Handles dClothing.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DEducation_ValueChanged(sender As Object, e As EventArgs) Handles dEducation.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DTransportation_ValueChanged(sender As Object, e As EventArgs) Handles dTransportation.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DLighths_ValueChanged(sender As Object, e As EventArgs) Handles dLighths.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DInsurance_ValueChanged(sender As Object, e As EventArgs) Handles dInsurance.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DAmortization_ValueChanged(sender As Object, e As EventArgs) Handles dAmortization.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DMiscellaneous_ValueChanged(sender As Object, e As EventArgs) Handles dMiscellaneous.ValueChanged
        dTotalExpenses.Value = dLiving.Value + dClothing.Value + dEducation.Value + dTransportation.Value + dLighths.Value + dInsurance.Value + dAmortization.Value + dMiscellaneous.Value
    End Sub

    Private Sub DTotalExpenses_ValueChanged(sender As Object, e As EventArgs) Handles dTotalExpenses.ValueChanged
        dNetDisposable.Value = dTotalDisposable.Value - dTotalExpenses.Value
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

    'RATING
    Private Sub CbxGood_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGood.CheckedChanged
        If cbxGood.Checked Then
            cbxFair.Checked = False
            cbxPoor.Checked = False
        End If
    End Sub

    Private Sub CbxFair_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFair.CheckedChanged
        If cbxFair.Checked Then
            cbxGood.Checked = False
            cbxPoor.Checked = False
        End If
    End Sub

    Private Sub CbxPoor_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPoor.CheckedChanged
        If cbxPoor.Checked Then
            cbxGood.Checked = False
            cbxFair.Checked = False
        End If
    End Sub

    'POSITIVE
    Private Sub CbxPositive_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPositive.CheckedChanged
        If cbxPositive.Checked Then
            cbxNegative.Checked = False
            cbxUnestablished.Checked = False
        End If
    End Sub

    Private Sub CbxNegative_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNegative.CheckedChanged
        If cbxNegative.Checked Then
            cbxPositive.Checked = False
            cbxUnestablished.Checked = False
        End If
    End Sub

    Private Sub CbxUnestablished_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUnestablished.CheckedChanged
        If cbxUnestablished.Checked Then
            cbxPositive.Checked = False
            cbxNegative.Checked = False
        End If
    End Sub

    Private Sub TxtC1_TextChanged(sender As Object, e As EventArgs) Handles txtC1.TextChanged
        If txtC1.Text = "" Then
            txtC2.Text = ""
            txtC3.Text = ""
            txtC4.Text = ""
            txtC5.Text = ""
            txtC6.Text = ""
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC2.Enabled = False
            txtC3.Enabled = False
            txtC4.Enabled = False
            txtC5.Enabled = False
            txtC6.Enabled = False
            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC2.Enabled = True
        End If
    End Sub

    Private Sub TxtC2_TextChanged(sender As Object, e As EventArgs) Handles txtC2.TextChanged
        If txtC2.Text = "" Then
            txtC3.Text = ""
            txtC4.Text = ""
            txtC5.Text = ""
            txtC6.Text = ""
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC3.Enabled = False
            txtC4.Enabled = False
            txtC5.Enabled = False
            txtC6.Enabled = False
            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC3.Enabled = True
        End If
    End Sub

    Private Sub TxtC3_TextChanged(sender As Object, e As EventArgs) Handles txtC3.TextChanged
        If txtC3.Text = "" Then
            txtC4.Text = ""
            txtC5.Text = ""
            txtC6.Text = ""
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC4.Enabled = False
            txtC5.Enabled = False
            txtC6.Enabled = False
            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC4.Enabled = True
        End If
    End Sub

    Private Sub TxtC4_TextChanged(sender As Object, e As EventArgs) Handles txtC4.TextChanged
        If txtC4.Text = "" Then
            txtC5.Text = ""
            txtC6.Text = ""
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC5.Enabled = False
            txtC6.Enabled = False
            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC5.Enabled = True
        End If
    End Sub

    Private Sub TxtC5_TextChanged(sender As Object, e As EventArgs) Handles txtC5.TextChanged
        If txtC5.Text = "" Then
            txtC6.Text = ""
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC6.Enabled = False
            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC6.Enabled = True
        End If
    End Sub

    Private Sub TxtC6_TextChanged(sender As Object, e As EventArgs) Handles txtC6.TextChanged
        If txtC6.Text = "" Then
            txtC7.Text = ""
            txtC8.Text = ""
            txtC9.Text = ""

            txtC7.Enabled = False
            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC7.Enabled = True
        End If
    End Sub

    Private Sub TxtC7_TextChanged(sender As Object, e As EventArgs) Handles txtC7.TextChanged
        If txtC7.Text = "" Then
            txtC8.Text = ""
            txtC9.Text = ""

            txtC8.Enabled = False
            txtC9.Enabled = False
        Else
            txtC8.Enabled = True
        End If
    End Sub

    Private Sub TxtC8_TextChanged(sender As Object, e As EventArgs) Handles txtC8.TextChanged
        If txtC8.Text = "" Then
            txtC9.Text = ""

            txtC9.Enabled = False
        Else
            txtC9.Enabled = True
        End If
    End Sub

    Private Sub BtnAttachSketch_Click(sender As Object, e As EventArgs) Handles btnAttachSketch.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(OFD.FileName)
                        ResizeImages(TempPB.Image.Clone, pbSketch, 650, 500)
                    End Using
                    ChangeSketch = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub DMonthly_C1_ValueChanged(sender As Object, e As EventArgs) Handles dMonthly_C1.ValueChanged, dOtherIncome_C1.ValueChanged, dBusinessIncome_C1.ValueChanged
        dTotalDisposable.Value = dMonthly_C1.Value + dBusinessIncome_C1.Value + dOtherIncome_C1.Value
    End Sub

    Private Sub BtnPrintCIR_Click(sender As Object, e As EventArgs) Handles btnPrintCIR.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GenerateCIR(True, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GenerateCIR(Show As Boolean, FName As String)
        Dim Report As New RptCoMakersStatementCIR
        With Report
            .Name = String.Format("Credit Investigation Report {0} Comaker for {1}", CINumber, If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim))
            .lblLoanNumber.Text = If(TxtFirstN_C1.Text.Trim = "", "", CreditNumber)
            .lblAmountWords.Text = If(TxtFirstN_C1.Text.Trim = "", "", ConvertNumberToWords(AmountApplied, False, False))
            .lblAmount.Text = If(TxtFirstN_C1.Text.Trim = "", "", FormatNumber(AmountApplied, 2))
            .p_CoMaker.Image = pb_C1.Image.Clone
            .lblBorrowerID.Text = If(TxtFirstN_C1.Text.Trim = "", "", BorrowerID)
            .lblBorrower.Text = If(TxtFirstN_C1.Text.Trim = "", "", BorrowerName)
            .lblComaker.Text = If(CbxPrefix_C1.Text.Trim = "", "", CbxPrefix_C1.Text.Trim & " ") & If(TxtFirstN_C1.Text.Trim = "", "", TxtFirstN_C1.Text.Trim & " ") & If(TxtMiddleN_C1.Text.Trim = "", "", TxtMiddleN_C1.Text.Trim & " ") & If(TxtLastN_C1.Text.Trim = "", "", TxtLastN_C1.Text.Trim & " ") & If(cbxSuffix_C1.Text.Trim = "", "", cbxSuffix_C1.Text.Trim & " ")
            .lblCompleteAdd.Text = If(txtNoC_C1.Text.Trim = "", "", txtNoC_C1.Text.Trim & " ") & If(txtStreetC_C1.Text.Trim = "", "", txtStreetC_C1.Text.Trim & " ") & If(txtBarangayC_C1.Text.Trim = "", "", txtBarangayC_C1.Text.Trim & " ") & If(cbxAddressC_C1.Text.Trim = "", "", cbxAddressC_C1.Text.Trim & " ")
            .lblProvincialAdd.Text = If(txtNoP_C1.Text.Trim = "", "", txtNoP_C1.Text.Trim & " ") & If(txtStreetP_C1.Text.Trim = "", "", txtStreetP_C1.Text.Trim & " ") & If(txtBarangayP_C1.Text.Trim = "", "", txtBarangayP_C1.Text.Trim & " ") & If(cbxAddressP_C1.Text.Trim = "", "", cbxAddressP_C1.Text.Trim & " ")
            .lblBirthDate.Text = DtpBirth_C1.Text
            .lblBirthPlace.Text = cbxPlaceBirth_C1.Text
            .cbxMale.Checked = cbxMale_C1.Checked
            .cbxFemale.Checked = cbxFemale_C1.Checked
            .cbxSingle.Checked = cbxSingle_C1.Checked
            .cbxMarried.Checked = cbxMarried_C1.Checked
            .cbxSeparated.Checked = cbxSeparated_C1.Checked
            .cbxWidowed.Checked = cbxWidowed_C1.Checked
            .lblCitizenship.Text = txtCitizenship_C1.Text
            .lblTIN.Text = txtTIN_C1.Text
            .lblTelephone.Text = txtTelephone_C1.Text
            .lblSSS.Text = txtSSS_C1.Text
            .lblMobile.Text = txtMobile_C1.Text
            .lblEmail.Text = txtEmail_C1.Text
            .cbxOwned.Checked = cbxOwned_C1.Checked
            .cbxFree.Checked = cbxFree_C1.Checked
            .cbxRented.Checked = cbxRented_C1.Checked
            .lblRent.Text = If(cbxRented_C1.Checked, dRent_C1.Text & " / month", "")
            .lblEmployer.Text = cbxEmployer_C1.Text
            .lblEmployerAddress.Text = txtEmployerAddress_C1.Text
            .lblEmployerTel.Text = txtEmployerTelephone_C1.Text
            .lblPosition.Text = cbxPosition_C1.Text
            .cbxCasual.Checked = cbxCasual_C1.Checked
            .cbxTemporary.Checked = cbxTemporary_C1.Checked
            .cbxPermanent.Checked = cbxPermanent_C1.Checked
            .lblDateHired.Text = dtpHired_C1.Text
            .lblSupervisor.Text = txtSupervisor_C1.Text
            .lblMonthlyIncome.Text = dMonthly_C1.Text
            .lblBusiness.Text = txtBusinessName_C1.Text
            .lblBusinessAddress.Text = txtBusinessAddress_C1.Text
            .lblBusinessTel.Text = txtBusinessTelephone_C1.Text
            .lblNature.Text = cbxNatureBusiness_C1.Text
            .lblYearsOperation.Text = iYrsOperation_C1.Text
            .lblBusinessIncome.Text = dBusinessIncome_C1.Text
            .lblNoEmployees.Text = iNoEmployees_C1.Text
            .lblCapital.Text = dCapital_C1.Text
            .lblCoverageArea.Text = txtArea_C1.Text
            .lblExpiry.Text = If(dtpExpiry_C1.CustomFormat = "", "", dtpExpiry_C1.Text)
            .lblOutlet.Text = iOutlet_C1.Text
            .lblOtherIncome.Text = txtOtherIncome_C1.Text
            .lblOtherMonthlyIncome.Text = dOtherIncome_C1.Text
            If txtCreditor_1.Text = "" Then
            Else
                .lblCredit1.Text = txtCreditor_1.Text & " " & txtCreditAddress_1.Text
                .lblGranted1.Text = dtpCreditGranted_1.Text
                .lblTerms1.Text = iTerm_1.Text
                .lblPrincipal1.Text = dAmountGranted_1.Text
                .lblOutstanding1.Text = dBalance_1.Text
                .lblMonthlyPay1.Text = dCreditPayment_1.Text
                .lblCreditRemarks1.Text = txtCreditRemarks_1.Text
            End If
            If txtCreditor_2.Text = "" Then
            Else
                .lblCredit2.Text = txtCreditor_2.Text & " " & txtCreditAddress_2.Text
                .lblGranted2.Text = dtpCreditGranted_2.Text
                .lblTerms2.Text = iTerm_2.Text
                .lblPrincipal2.Text = dAmountGranted_2.Text
                .lblOutstanding2.Text = dBalance_2.Text
                .lblMonthlyPay2.Text = dCreditPayment_2.Text
                .lblCreditRemarks2.Text = txtCreditRemarks_2.Text
            End If
            If txtBank_1.Text = "" Then
            Else
                .lblBank1.Text = txtBank_1.Text
                .lblBranch1.Text = txtBranch_1.Text
                .cbxSA1.Checked = cbxSA_1.Checked
                .cbxCA1.Checked = cbxCA_1.Checked
                .cbxAccountNum1.Text = txtSA_1.Text
                .lblDaily1.Text = dAverageBalance_1.Text
                .lblOpened1.Text = txtOpened_1.Text
            End If
            If txtBank_2.Text = "" Then
            Else
                .lblBank2.Text = txtBank_2.Text
                .lblBranch2.Text = txtBranch_2.Text
                .cbxSA2.Checked = cbxSA_2.Checked
                .cbxCA2.Checked = cbxCA_2.Checked
                .cbxAccountNum2.Text = txtSA_2.Text
                .lblDaily2.Text = dAverageBalance_2.Text
                .lblOpened2.Text = txtOpened_2.Text
            End If
            .cbxGood.Checked = cbxGood.Checked
            .cbxFair.Checked = cbxFair.Checked
            .cbxPoor.Checked = cbxPoor.Checked
            .lblRecommendation.Text = rRecommendation.Text
            If txtTitle.Text = "" Then
            Else
                .lblTitle.Text = txtTitle.Text
                .lblCaseNumber.Text = txtCaseNum.Text
                .lblDateFilled.Text = dtpDateFilled.Text
                .lblCourtBranch.Text = cbxCourt.Text
                .lblCaseNature.Text = cbxCaseNature.Text
                .lblAmountInvolved.Text = dAmountInvolved.Text
                .lblCaseStatus.Text = cbxCaseStatus.Text
                .lblFindings.Text = txtFindings.Text
                .cbxPositive.Checked = cbxPositive.Checked
                .cbxNegative.Checked = cbxNegative.Checked
                .cbxUnestablied.Checked = cbxUnestablished.Checked
                .lblOtherInfo.Text = txtCACPI.Text
            End If
            If txtLocation_1.Text = "" Then
            Else
                .lblLocation1.Text = txtLocation_1.Text
                .lblTCT1.Text = txtTCT_1.Text
                .lblArea1.Text = dArea_1.Text
                .lblRE_Remarks1.Text = txtPropertiesRemarks_1.Text
            End If
            If txtLocation_2.Text = "" Then
            Else
                .lblLocation2.Text = txtLocation_2.Text
                .lblTCT2.Text = txtTCT_2.Text
                .lblArea2.Text = dArea_2.Text
                .lblRE_Remarks2.Text = txtPropertiesRemarks_2.Text
            End If
            If txtVehicle_1.Text = "" Then
            Else
                .lblVehicle1.Text = txtVehicle_1.Text
                .lblModel1.Text = dtpYear_1.Text
                .lblAcquired1.Text = txtWhomAcquired_1.Text
                .lblVE_Remarks1.Text = txtVehicleRemarks_1.Text
            End If
            If txtVehicle_2.Text = "" Then
            Else
                .lblVehicle2.Text = txtVehicle_2.Text
                .lblModel2.Text = dtpYear_2.Text
                .lblAcquired2.Text = txtWhomAcquired_2.Text
                .lblVE_Remarks2.Text = txtVehicleRemarks_2.Text
            End If
            .lblOtherProperty.Text = txtOtherProperties.Text
            .lblNarrative.Text = rNarrative.Text
            .lblCondition1.Text = txtC1.Text
            .lblCondition2.Text = txtC2.Text
            .lblCondition3.Text = txtC3.Text
            .lblCondition4.Text = txtC4.Text
            .lblCondition5.Text = txtC5.Text
            .lblCondition6.Text = txtC6.Text
            .lblCondition7.Text = txtC7.Text
            .lblCondition8.Text = txtC8.Text
            .lblCondition9.Text = txtC9.Text
            .lblIncome.Text = dTotalDisposable.Text
            .lblLivingExpense.Text = dLiving.Text
            .lblClothing.Text = dClothing.Text
            .lblEducation.Text = dEducation.Text
            .lblTransportation.Text = dTransportation.Text
            .lblLight.Text = dLighths.Text
            .lblInsurance.Text = dInsurance.Text
            .lblAmortazation.Text = dAmortization.Text
            .lblMiscellaneous.Text = dMiscellaneous.Text
            .lblTotal.Text = dTotalExpenses.Text
            .lblNetDisposable.Text = dNetDisposable.Text
            .lblPurpose.Text = rPurposeLoan.Text
            .lblDeviations.Text = rOthers.Text
            .p_Sketch.Image = pbSketch.Image.Clone
            .lblDateSigned_2.Text = ""
            .lblSignature_3.Text = ""

            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        txtPath_C1.Text = " "
        ResizeImages(DefaultImage.Image.Clone, pb_C1, 650, 500)
    End Sub

    Private Sub CbxYearHired_C1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYearHired_C1.CheckedChanged
        If cbxYearHired_C1.Checked Then
            dtpHired_C1.CustomFormat = "yyyy"
        Else
            dtpHired_C1.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub
End Class