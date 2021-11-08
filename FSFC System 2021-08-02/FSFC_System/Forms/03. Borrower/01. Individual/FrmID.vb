Public Class FrmID

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
    Public BorrowerID As String
    Public ID_Type = "B"
    Public From_Borrower As Boolean = True

    Private Sub FrmID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        dtpDrivers.Value = Date.Now
        dtpVIN.Value = Date.Now
        dtpPassport.Value = Date.Now
        dtpPRC.Value = Date.Now
        dtpNBI.Value = Date.Now
        dtpPolice.Value = Date.Now
        dtpPostal.Value = Date.Now
        dtpBarangay.Value = Date.Now
        dtpOWWA.Value = Date.Now
        dtpOFW.Value = Date.Now
        dtpSeaman.Value = Date.Now
        dtpPNP.Value = Date.Now
        dtpAFP.Value = Date.Now
        dtpHDMF.Value = Date.Now
        dtpPWD.Value = Date.Now
        dtpDSWD.Value = Date.Now
        dtpACR.Value = Date.Now
        dtpDTI_Business.Value = Date.Now
        dtpIBP.Value = Date.Now
        dtpFireArms.Value = Date.Now
        dtpGovernment.Value = Date.Now
        dtpDiplomat.Value = Date.Now
        dtpNational.Value = Date.Now
        dtpWork.Value = Date.Now
        dtpGOCC.Value = Date.Now
        dtpPLRA.Value = Date.Now
        dtpMajor.Value = Date.Now
        dtpMedia.Value = Date.Now
        dtpStudent.Value = Date.Now
        dtpSIRV.Value = Date.Now
        If From_Borrower Then
            With FrmBorrower
                If ID_Type = "B" Then
                    If .dDrivers = "" Then
                    Else
                        dtpDrivers.Value = .dDrivers
                    End If
                    If .dVIN = "" Then
                    Else
                        dtpVIN.Value = .dVIN
                    End If
                    If .dPassport = "" Then
                    Else
                        dtpPassport.Value = .dPassport
                    End If
                    If .dPRC = "" Then
                    Else
                        dtpPRC.Value = .dPRC
                    End If
                    If .dNBI = "" Then
                    Else
                        dtpNBI.Value = .dNBI
                    End If
                    If .dPolice = "" Then
                    Else
                        dtpPolice.Value = .dPolice
                    End If
                    If .dPostal = "" Then
                    Else
                        dtpPostal.Value = .dPostal
                    End If
                    If .dBarangay = "" Then
                    Else
                        dtpBarangay.Value = .dBarangay
                    End If
                    If .dOWWA = "" Then
                    Else
                        dtpOWWA.Value = .dOWWA
                    End If
                    If .dOFW = "" Then
                    Else
                        dtpOFW.Value = .dOFW
                    End If
                    If .dSeaman = "" Then
                    Else
                        dtpSeaman.Value = .dSeaman
                    End If
                    If .dPNP = "" Then
                    Else
                        dtpPNP.Value = .dPNP
                    End If
                    If .dAFP = "" Then
                    Else
                        dtpAFP.Value = .dAFP
                    End If
                    If .dHDMF = "" Then
                    Else
                        dtpHDMF.Value = .dHDMF
                    End If
                    If .dPWD = "" Then
                    Else
                        dtpPWD.Value = .dPWD
                    End If
                    If .dDSWD = "" Then
                    Else
                        dtpDSWD.Value = .dDSWD
                    End If
                    If .dACR = "" Then
                    Else
                        dtpACR.Value = .dACR
                    End If
                    If .dDTI_Business = "" Then
                    Else
                        dtpDTI_Business.Value = .dDTI_Business
                    End If
                    If .dIBP = "" Then
                    Else
                        dtpIBP.Value = .dIBP
                    End If
                    If .dFireArms = "" Then
                    Else
                        dtpFireArms.Value = .dFireArms
                    End If
                    If .dGovernment = "" Then
                    Else
                        dtpGovernment.Value = .dGovernment
                    End If
                    If .dDiplomat = "" Then
                    Else
                        dtpDiplomat.Value = .dDiplomat
                    End If
                    If .dNational = "" Then
                    Else
                        dtpNational.Value = .dNational
                    End If
                    If .dWork = "" Then
                    Else
                        dtpWork.Value = .dWork
                    End If
                    If .dGOCC = "" Then
                    Else
                        dtpGOCC.Value = .dGOCC
                    End If
                    If .dPLRA = "" Then
                    Else
                        dtpPLRA.Value = .dPLRA
                    End If
                    If .dMajor = "" Then
                    Else
                        dtpMajor.Value = .dMajor
                    End If
                    If .dMedia = "" Then
                    Else
                        dtpMedia.Value = .dMedia
                    End If
                    If .dStudent = "" Then
                    Else
                        dtpStudent.Value = .dStudent
                    End If
                    If .dSIRV = "" Then
                    Else
                        dtpSIRV.Value = .dSIRV
                    End If
                Else
                    If .dDrivers_S = "" Then
                    Else
                        dtpDrivers.Value = .dDrivers_S
                    End If
                    If .dVIN_S = "" Then
                    Else
                        dtpVIN.Value = .dVIN_S
                    End If
                    If .dPassport_S = "" Then
                    Else
                        dtpPassport.Value = .dPassport_S
                    End If
                    If .dPRC_S = "" Then
                    Else
                        dtpPRC.Value = .dPRC_S
                    End If
                    If .dNBI_S = "" Then
                    Else
                        dtpNBI.Value = .dNBI_S
                    End If
                    If .dPolice_S = "" Then
                    Else
                        dtpPolice.Value = .dPolice_S
                    End If
                    If .dPostal_S = "" Then
                    Else
                        dtpPostal.Value = .dPostal_S
                    End If
                    If .dBarangay_S = "" Then
                    Else
                        dtpBarangay.Value = .dBarangay_S
                    End If
                    If .dOWWA_S = "" Then
                    Else
                        dtpOWWA.Value = .dOWWA_S
                    End If
                    If .dOFW_S = "" Then
                    Else
                        dtpOFW.Value = .dOFW_S
                    End If
                    If .dSeaman_S = "" Then
                    Else
                        dtpSeaman.Value = .dSeaman_S
                    End If
                    If .dPNP_S = "" Then
                    Else
                        dtpPNP.Value = .dPNP_S
                    End If
                    If .dAFP_S = "" Then
                    Else
                        dtpAFP.Value = .dAFP_S
                    End If
                    If .dHDMF_S = "" Then
                    Else
                        dtpHDMF.Value = .dHDMF_S
                    End If
                    If .dPWD_S = "" Then
                    Else
                        dtpPWD.Value = .dPWD_S
                    End If
                    If .dDSWD_S = "" Then
                    Else
                        dtpDSWD.Value = .dDSWD_S
                    End If
                    If .dACR_S = "" Then
                    Else
                        dtpACR.Value = .dACR_S
                    End If
                    If .dDTI_Business_S = "" Then
                    Else
                        dtpDTI_Business.Value = .dDTI_Business_S
                    End If
                    If .dIBP_S = "" Then
                    Else
                        dtpIBP.Value = .dIBP_S
                    End If
                    If .dFireArms_S = "" Then
                    Else
                        dtpFireArms.Value = .dFireArms_S
                    End If
                    If .dGovernment_S = "" Then
                    Else
                        dtpGovernment.Value = .dGovernment_S
                    End If
                    If .dDiplomat_S = "" Then
                    Else
                        dtpDiplomat.Value = .dDiplomat_S
                    End If
                    If .dNational_S = "" Then
                    Else
                        dtpNational.Value = .dNational_S
                    End If
                    If .dWork_S = "" Then
                    Else
                        dtpWork.Value = .dWork_S
                    End If
                    If .dGOCC_S = "" Then
                    Else
                        dtpGOCC.Value = .dGOCC_S
                    End If
                    If .dPLRA_S = "" Then
                    Else
                        dtpPLRA.Value = .dPLRA_S
                    End If
                    If .dMajor_S = "" Then
                    Else
                        dtpMajor.Value = .dMajor_S
                    End If
                    If .dMedia_S = "" Then
                    Else
                        dtpMedia.Value = .dMedia_S
                    End If
                    If .dStudent_S = "" Then
                    Else
                        dtpStudent.Value = .dStudent_S
                    End If
                    If .dSIRV_S = "" Then
                    Else
                        dtpSIRV.Value = .dSIRV_S
                    End If
                End If
            End With
        Else 'From Credit Application
            With FrmLoanApplication
                If ID_Type = "B" Then
                    If .dDrivers = "" Then
                    Else
                        dtpDrivers.Value = .dDrivers
                    End If
                    If .dVIN = "" Then
                    Else
                        dtpVIN.Value = .dVIN
                    End If
                    If .dPassport = "" Then
                    Else
                        dtpPassport.Value = .dPassport
                    End If
                    If .dPRC = "" Then
                    Else
                        dtpPRC.Value = .dPRC
                    End If
                    If .dNBI = "" Then
                    Else
                        dtpNBI.Value = .dNBI
                    End If
                    If .dPolice = "" Then
                    Else
                        dtpPolice.Value = .dPolice
                    End If
                    If .dPostal = "" Then
                    Else
                        dtpPostal.Value = .dPostal
                    End If
                    If .dBarangay = "" Then
                    Else
                        dtpBarangay.Value = .dBarangay
                    End If
                    If .dOWWA = "" Then
                    Else
                        dtpOWWA.Value = .dOWWA
                    End If
                    If .dOFW = "" Then
                    Else
                        dtpOFW.Value = .dOFW
                    End If
                    If .dSeaman = "" Then
                    Else
                        dtpSeaman.Value = .dSeaman
                    End If
                    If .dPNP = "" Then
                    Else
                        dtpPNP.Value = .dPNP
                    End If
                    If .dAFP = "" Then
                    Else
                        dtpAFP.Value = .dAFP
                    End If
                    If .dHDMF = "" Then
                    Else
                        dtpHDMF.Value = .dHDMF
                    End If
                    If .dPWD = "" Then
                    Else
                        dtpPWD.Value = .dPWD
                    End If
                    If .dDSWD = "" Then
                    Else
                        dtpDSWD.Value = .dDSWD
                    End If
                    If .dACR = "" Then
                    Else
                        dtpACR.Value = .dACR
                    End If
                    If .dDTI_Business = "" Then
                    Else
                        dtpDTI_Business.Value = .dDTI_Business
                    End If
                    If .dIBP = "" Then
                    Else
                        dtpIBP.Value = .dIBP
                    End If
                    If .dFireArms = "" Then
                    Else
                        dtpFireArms.Value = .dFireArms
                    End If
                    If .dGovernment = "" Then
                    Else
                        dtpGovernment.Value = .dGovernment
                    End If
                    If .dDiplomat = "" Then
                    Else
                        dtpDiplomat.Value = .dDiplomat
                    End If
                    If .dNational = "" Then
                    Else
                        dtpNational.Value = .dNational
                    End If
                    If .dWork = "" Then
                    Else
                        dtpWork.Value = .dWork
                    End If
                    If .dGOCC = "" Then
                    Else
                        dtpGOCC.Value = .dGOCC
                    End If
                    If .dPLRA = "" Then
                    Else
                        dtpPLRA.Value = .dPLRA
                    End If
                    If .dMajor = "" Then
                    Else
                        dtpMajor.Value = .dMajor
                    End If
                    If .dMedia = "" Then
                    Else
                        dtpMedia.Value = .dMedia
                    End If
                    If .dStudent = "" Then
                    Else
                        dtpStudent.Value = .dStudent
                    End If
                    If .dSIRV = "" Then
                    Else
                        dtpSIRV.Value = .dSIRV
                    End If
                ElseIf ID_Type = "S" Then
                    If .dDrivers_S = "" Then
                    Else
                        dtpDrivers.Value = .dDrivers_S
                    End If
                    If .dVIN_S = "" Then
                    Else
                        dtpVIN.Value = .dVIN_S
                    End If
                    If .dPassport_S = "" Then
                    Else
                        dtpPassport.Value = .dPassport_S
                    End If
                    If .dPRC_S = "" Then
                    Else
                        dtpPRC.Value = .dPRC_S
                    End If
                    If .dNBI_S = "" Then
                    Else
                        dtpNBI.Value = .dNBI_S
                    End If
                    If .dPolice_S = "" Then
                    Else
                        dtpPolice.Value = .dPolice_S
                    End If
                    If .dPostal_S = "" Then
                    Else
                        dtpPostal.Value = .dPostal_S
                    End If
                    If .dBarangay_S = "" Then
                    Else
                        dtpBarangay.Value = .dBarangay_S
                    End If
                    If .dOWWA_S = "" Then
                    Else
                        dtpOWWA.Value = .dOWWA_S
                    End If
                    If .dOFW_S = "" Then
                    Else
                        dtpOFW.Value = .dOFW_S
                    End If
                    If .dSeaman_S = "" Then
                    Else
                        dtpSeaman.Value = .dSeaman_S
                    End If
                    If .dPNP_S = "" Then
                    Else
                        dtpPNP.Value = .dPNP_S
                    End If
                    If .dAFP_S = "" Then
                    Else
                        dtpAFP.Value = .dAFP_S
                    End If
                    If .dHDMF_S = "" Then
                    Else
                        dtpHDMF.Value = .dHDMF_S
                    End If
                    If .dPWD_S = "" Then
                    Else
                        dtpPWD.Value = .dPWD_S
                    End If
                    If .dDSWD_S = "" Then
                    Else
                        dtpDSWD.Value = .dDSWD_S
                    End If
                    If .dACR_S = "" Then
                    Else
                        dtpACR.Value = .dACR_S
                    End If
                    If .dDTI_Business_S = "" Then
                    Else
                        dtpDTI_Business.Value = .dDTI_Business_S
                    End If
                    If .dIBP_S = "" Then
                    Else
                        dtpIBP.Value = .dIBP_S
                    End If
                    If .dFireArms_S = "" Then
                    Else
                        dtpFireArms.Value = .dFireArms_S
                    End If
                    If .dGovernment_S = "" Then
                    Else
                        dtpGovernment.Value = .dGovernment_S
                    End If
                    If .dDiplomat_S = "" Then
                    Else
                        dtpDiplomat.Value = .dDiplomat_S
                    End If
                    If .dNational_S = "" Then
                    Else
                        dtpNational.Value = .dNational_S
                    End If
                    If .dWork_S = "" Then
                    Else
                        dtpWork.Value = .dWork_S
                    End If
                    If .dGOCC_S = "" Then
                    Else
                        dtpGOCC.Value = .dGOCC_S
                    End If
                    If .dPLRA_S = "" Then
                    Else
                        dtpPLRA.Value = .dPLRA_S
                    End If
                    If .dMajor_S = "" Then
                    Else
                        dtpMajor.Value = .dMajor_S
                    End If
                    If .dMedia_S = "" Then
                    Else
                        dtpMedia.Value = .dMedia_S
                    End If
                    If .dStudent_S = "" Then
                    Else
                        dtpStudent.Value = .dStudent_S
                    End If
                    If .dSIRV_S = "" Then
                    Else
                        dtpSIRV.Value = .dSIRV_S
                    End If
                End If
            End With
        End If

        If TotalImage_TIN > 0 Then
            btnAttach_TIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_SSS > 0 Then
            btnAttach_SSS.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_GSIS > 0 Then
            btnAttach_GSIS.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_PhilHealth > 0 Then
            btnAttach_PhilHealth.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Senior > 0 Then
            btnAttach_Senior.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_UMID > 0 Then
            btnAttach_UMID.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_SEC > 0 Then
            btnAttach_SEC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_DTI > 0 Then
            btnAttach_DTI.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_CDA > 0 Then
            btnAttach_CDA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Cooperative > 0 Then
            btnAttach_Cooperative.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Drivers > 0 Then
            btnAttach_Drivers.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_VIN > 0 Then
            btnAttach_VIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Passport > 0 Then
            btnAttach_Passport.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_PRC > 0 Then
            btnAttach_PRC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_NBI > 0 Then
            btnAttach_NBI.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Police > 0 Then
            btnAttach_Police.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Postal > 0 Then
            btnAttach_Postal.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Barangay > 0 Then
            btnAttach_Barangay.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_OWWA > 0 Then
            btnAttach_OWWA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_OFW > 0 Then
            btnAttach_OFW.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Seaman > 0 Then
            btnAttach_Seaman.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_PNP > 0 Then
            btnAttach_PNP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_AFP > 0 Then
            btnAttach_AFP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_HDMF > 0 Then
            btnAttach_HDMF.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_PWD > 0 Then
            btnAttach_PWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_DSWD > 0 Then
            btnAttach_DSWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_ACR > 0 Then
            btnAttach_ACR.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_DTI_Business > 0 Then
            btnAttach_DTI_Business.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_IBP > 0 Then
            btnAttach_IBP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_FireArms > 0 Then
            btnAttach_FireArms.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Government > 0 Then
            btnAttach_Government.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Diplomat > 0 Then
            btnAttach_Diplomat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_National > 0 Then
            btnAttach_National.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Work > 0 Then
            btnAttach_Work.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_GOCC > 0 Then
            btnAttach_GOCC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_PLRA > 0 Then
            btnAttach_PLRA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Major > 0 Then
            btnAttach_Major.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Media > 0 Then
            btnAttach_Media.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_Student > 0 Then
            btnAttach_Student.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
        If TotalImage_SIRV > 0 Then
            btnAttach_SIRV.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX142, LabelX1, LabelX2, LabelX3, LabelX5, LabelX6, LabelX7, LabelX8, LabelX9, LabelX10, LabelX20, LabelX19, LabelX18, LabelX17, LabelX16, LabelX15, LabelX14, LabelX13, LabelX12, LabelX11, LabelX26, LabelX25, LabelX24, LabelX23, LabelX22, LabelX41, LabelX40, LabelX39, LabelX38, LabelX37, LabelX36, LabelX35, LabelX34, LabelX33, LabelX32, LabelX31, LabelX30, LabelX29, LabelX28, LabelX27})

            GetLabelWithBackgroundFontSettings({LabelX4, LabelX21})

            GetTextBoxFontSettings({txtTIN, txtSSS, txtGSIS, txtPhilHealth, txtSenior, txtUMID, txtSEC, txtDTI, txtCDA, txtCooperative, txtDrivers, txtVIN, txtPassport, txtPRC, txtNBI, txtPolice, txtPostal, txtBarangay, txtOWWA, txtOFW, txtSeaman, txtPNP, txtAFP, txtHDMF, txtPWD, txtDSWD, txtACR, txtDTI_Business, txtIBP, txtFireArms, txtGovernment, txtDiplomat, txtNational, txtWork, txtGOCC, txtPLRA, txtMajor, txtMedia, txtStudent, txtSIRV})

            GetDateTimeInputFontSettings({dtpDrivers, dtpVIN, dtpPassport, dtpPRC, dtpNBI, dtpPolice, dtpPostal, dtpBarangay, dtpOWWA, dtpOFW, dtpSeaman, dtpPNP, dtpAFP, dtpHDMF, dtpPWD, dtpDSWD, dtpACR, dtpDTI_Business, dtpIBP, dtpFireArms, dtpGovernment, dtpDiplomat, dtpNational, dtpWork, dtpGOCC, dtpPLRA, dtpMajor, dtpMedia, dtpStudent, dtpSIRV})

            GetButtonFontSettings({btnDone, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("ID - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            txtTIN.Text = ""
            txtSSS.Text = ""
            txtGSIS.Text = ""
            txtPhilHealth.Text = ""
            txtSenior.Text = ""
            txtUMID.Text = ""
            txtSEC.Text = ""
            txtDTI.Text = ""
            txtCDA.Text = ""
            txtCooperative.Text = ""
            txtDrivers.Text = ""
            txtVIN.Text = ""
            txtPassport.Text = ""
            txtPRC.Text = ""
            txtNBI.Text = ""
            txtPolice.Text = ""
            txtPostal.Text = ""
            txtBarangay.Text = ""
            txtOWWA.Text = ""
            txtOFW.Text = ""
            txtSeaman.Text = ""
            txtPNP.Text = ""
            txtAFP.Text = ""
            txtHDMF.Text = ""
            txtPWD.Text = ""
            txtDSWD.Text = ""
            txtACR.Text = ""
            txtDTI_Business.Text = ""
            txtIBP.Text = ""
            txtFireArms.Text = ""
            txtGovernment.Text = ""
            txtDiplomat.Text = ""
            txtNational.Text = ""
            txtWork.Text = ""
            txtGOCC.Text = ""
            txtPLRA.Text = ""
            txtMajor.Text = ""
            txtMedia.Text = ""
            txtStudent.Text = ""
            txtSIRV.Text = ""

            'DATE
            dtpDrivers.Value = Date.Now
            dtpVIN.Value = Date.Now
            dtpPassport.Value = Date.Now
            dtpPRC.Value = Date.Now
            dtpNBI.Value = Date.Now
            dtpPolice.Value = Date.Now
            dtpPostal.Value = Date.Now
            dtpBarangay.Value = Date.Now
            dtpOWWA.Value = Date.Now
            dtpOFW.Value = Date.Now
            dtpSeaman.Value = Date.Now
            dtpPNP.Value = Date.Now
            dtpAFP.Value = Date.Now
            dtpHDMF.Value = Date.Now
            dtpPWD.Value = Date.Now
            dtpDSWD.Value = Date.Now
            dtpACR.Value = Date.Now
            dtpDTI_Business.Value = Date.Now
            dtpIBP.Value = Date.Now
            dtpFireArms.Value = Date.Now
            dtpGovernment.Value = Date.Now
            dtpDiplomat.Value = Date.Now
            dtpNational.Value = Date.Now
            dtpWork.Value = Date.Now
            dtpGOCC.Value = Date.Now
            dtpPLRA.Value = Date.Now
            dtpMajor.Value = Date.Now
            dtpMedia.Value = Date.Now
            dtpStudent.Value = Date.Now
            dtpSIRV.Value = Date.Now
        End If
    End Sub

#Region "Leave"
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

    Private Sub TxtGSIS_Leave(sender As Object, e As EventArgs) Handles txtGSIS.Leave
        txtGSIS.Text = ReplaceText(txtGSIS.Text.Trim)
    End Sub

    Private Sub TxtPhilHealth_Leave(sender As Object, e As EventArgs) Handles txtPhilHealth.Leave
        txtPhilHealth.Text = ReplaceText(txtPhilHealth.Text.Trim)
    End Sub

    Private Sub TxtSenior_Leave(sender As Object, e As EventArgs) Handles txtSenior.Leave
        txtSenior.Text = ReplaceText(txtSenior.Text.Trim)
    End Sub

    Private Sub TxtUMID_Leave(sender As Object, e As EventArgs) Handles txtUMID.Leave
        txtUMID.Text = ReplaceText(txtUMID.Text.Trim)
    End Sub

    Private Sub TxtSEC_Leave(sender As Object, e As EventArgs) Handles txtSEC.Leave
        txtSEC.Text = ReplaceText(txtSEC.Text.Trim)
    End Sub

    Private Sub TxtDTI_Leave(sender As Object, e As EventArgs) Handles txtDTI.Leave
        txtDTI.Text = ReplaceText(txtDTI.Text.Trim)
    End Sub

    Private Sub TxtCDA_Leave(sender As Object, e As EventArgs) Handles txtCDA.Leave
        txtCDA.Text = ReplaceText(txtCDA.Text.Trim)
    End Sub

    Private Sub TxtCooperative_Leave(sender As Object, e As EventArgs) Handles txtCooperative.Leave
        txtCooperative.Text = ReplaceText(txtCooperative.Text.Trim)
    End Sub

    Private Sub TxtDrivers_Leave(sender As Object, e As EventArgs) Handles txtDrivers.Leave
        txtDrivers.Text = ReplaceText(txtDrivers.Text.Trim)
    End Sub

    Private Sub TxtVIN_Leave(sender As Object, e As EventArgs) Handles txtVIN.Leave
        txtVIN.Text = ReplaceText(txtVIN.Text.Trim)
    End Sub

    Private Sub TxtPassport_Leave(sender As Object, e As EventArgs) Handles txtPassport.Leave
        txtPassport.Text = ReplaceText(txtPassport.Text.Trim)
    End Sub

    Private Sub TxtPRC_Leave(sender As Object, e As EventArgs) Handles txtPRC.Leave
        txtPRC.Text = ReplaceText(txtPRC.Text.Trim)
    End Sub

    Private Sub TxtNBI_Leave(sender As Object, e As EventArgs) Handles txtNBI.Leave
        txtNBI.Text = ReplaceText(txtNBI.Text.Trim)
    End Sub

    Private Sub TxtPolice_Leave(sender As Object, e As EventArgs) Handles txtPolice.Leave
        txtPolice.Text = ReplaceText(txtPolice.Text.Trim)
    End Sub

    Private Sub TxtPostal_Leave(sender As Object, e As EventArgs) Handles txtPostal.Leave
        txtPostal.Text = ReplaceText(txtPostal.Text.Trim)
    End Sub

    Private Sub TxtBarangay_Leave(sender As Object, e As EventArgs) Handles txtBarangay.Leave
        txtBarangay.Text = ReplaceText(txtBarangay.Text.Trim)
    End Sub

    Private Sub TxtOWWA_Leave(sender As Object, e As EventArgs) Handles txtOWWA.Leave
        txtOWWA.Text = ReplaceText(txtOWWA.Text.Trim)
    End Sub

    Private Sub TxtOFW_Leave(sender As Object, e As EventArgs) Handles txtOFW.Leave
        txtOFW.Text = ReplaceText(txtOFW.Text.Trim)
    End Sub

    Private Sub TxtSeaman_Leave(sender As Object, e As EventArgs) Handles txtSeaman.Leave
        txtSeaman.Text = ReplaceText(txtSeaman.Text.Trim)
    End Sub

    Private Sub TxtPNP_Leave(sender As Object, e As EventArgs) Handles txtPNP.Leave
        txtPNP.Text = ReplaceText(txtPNP.Text.Trim)
    End Sub

    Private Sub TxtAFP_Leave(sender As Object, e As EventArgs) Handles txtAFP.Leave
        txtAFP.Text = ReplaceText(txtAFP.Text.Trim)
    End Sub

    Private Sub TxtHDMF_Leave(sender As Object, e As EventArgs) Handles txtHDMF.Leave
        txtHDMF.Text = ReplaceText(txtHDMF.Text.Trim)
    End Sub

    Private Sub TxtPWD_Leave(sender As Object, e As EventArgs) Handles txtPWD.Leave
        txtPWD.Text = ReplaceText(txtPWD.Text.Trim)
    End Sub

    Private Sub TxtDSWD_Leave(sender As Object, e As EventArgs) Handles txtDSWD.Leave
        txtDSWD.Text = ReplaceText(txtDSWD.Text.Trim)
    End Sub

    Private Sub TxtACR_Leave(sender As Object, e As EventArgs) Handles txtACR.Leave
        txtACR.Text = ReplaceText(txtACR.Text.Trim)
    End Sub

    Private Sub TxtDTI_Business_Leave(sender As Object, e As EventArgs) Handles txtDTI_Business.Leave
        txtDTI_Business.Text = ReplaceText(txtDTI_Business.Text.Trim)
    End Sub

    Private Sub TxtIBP_Leave(sender As Object, e As EventArgs) Handles txtIBP.Leave
        txtIBP.Text = ReplaceText(txtIBP.Text.Trim)
    End Sub

    Private Sub TxtFireArms_Leave(sender As Object, e As EventArgs) Handles txtFireArms.Leave
        txtFireArms.Text = ReplaceText(txtFireArms.Text.Trim)
    End Sub

    Private Sub TxtGovernment_Leave(sender As Object, e As EventArgs) Handles txtGovernment.Leave
        txtGovernment.Text = ReplaceText(txtGovernment.Text.Trim)
    End Sub

    Private Sub TxtDiplomat_Leave(sender As Object, e As EventArgs) Handles txtDiplomat.Leave
        txtDiplomat.Text = ReplaceText(txtDiplomat.Text.Trim)
    End Sub

    Private Sub TxtNational_Leave(sender As Object, e As EventArgs) Handles txtNational.Leave
        txtNational.Text = ReplaceText(txtNational.Text.Trim)
    End Sub

    Private Sub TxtWork_Leave(sender As Object, e As EventArgs) Handles txtWork.Leave
        txtWork.Text = ReplaceText(txtWork.Text.Trim)
    End Sub

    Private Sub TxtGOCC_Leave(sender As Object, e As EventArgs) Handles txtGOCC.Leave
        txtGOCC.Text = ReplaceText(txtGOCC.Text.Trim)
    End Sub

    Private Sub TxtPLRA_Leave(sender As Object, e As EventArgs) Handles txtPLRA.Leave
        txtPLRA.Text = ReplaceText(txtPLRA.Text.Trim)
    End Sub

    Private Sub TxtMajor_Leave(sender As Object, e As EventArgs) Handles txtMajor.Leave
        txtMajor.Text = ReplaceText(txtMajor.Text.Trim)
    End Sub

    Private Sub TxtMedia_Leave(sender As Object, e As EventArgs) Handles txtMedia.Leave
        txtMedia.Text = ReplaceText(txtMedia.Text.Trim)
    End Sub

    Private Sub TxtStudent_Leave(sender As Object, e As EventArgs) Handles txtStudent.Leave
        txtStudent.Text = ReplaceText(txtStudent.Text.Trim)
    End Sub

    Private Sub TxtSIRV_Leave(sender As Object, e As EventArgs) Handles txtSIRV.Leave
        txtSIRV.Text = ReplaceText(txtSIRV.Text.Trim)
    End Sub
#End Region

#Region "Date Leave"
    Private Sub DtpDrivers_Leave(sender As Object, e As EventArgs) Handles dtpDrivers.Leave
        If dtpDrivers.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtDrivers.WatermarkText, DateDiff(DateInterval.Day, dtpDrivers.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpDrivers.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpVIN_Leave(sender As Object, e As EventArgs) Handles dtpVIN.Leave
        If dtpVIN.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtVIN.WatermarkText, DateDiff(DateInterval.Day, dtpVIN.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpVIN.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPassport_Leave(sender As Object, e As EventArgs) Handles dtpPassport.Leave
        If dtpPassport.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPassport.WatermarkText, DateDiff(DateInterval.Day, dtpPassport.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPassport.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPRC_Leave(sender As Object, e As EventArgs) Handles dtpPRC.Leave
        If dtpPRC.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPRC.WatermarkText, DateDiff(DateInterval.Day, dtpPRC.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPRC.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpNBI_Leave(sender As Object, e As EventArgs) Handles dtpNBI.Leave
        If dtpNBI.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtNBI.WatermarkText, DateDiff(DateInterval.Day, dtpNBI.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpNBI.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPolice_Leave(sender As Object, e As EventArgs) Handles dtpPolice.Leave
        If dtpPolice.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPolice.WatermarkText, DateDiff(DateInterval.Day, dtpPolice.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPolice.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPostal_Leave(sender As Object, e As EventArgs) Handles dtpPostal.Leave
        If dtpPostal.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPostal.WatermarkText, DateDiff(DateInterval.Day, dtpPostal.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPostal.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpBarangay_Leave(sender As Object, e As EventArgs) Handles dtpBarangay.Leave
        If dtpBarangay.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtBarangay.WatermarkText, DateDiff(DateInterval.Day, dtpBarangay.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpBarangay.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpOWWA_Leave(sender As Object, e As EventArgs) Handles dtpOWWA.Leave
        If dtpOWWA.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtOWWA.WatermarkText, DateDiff(DateInterval.Day, dtpOWWA.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpOWWA.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpOFW_Leave(sender As Object, e As EventArgs) Handles dtpOFW.Leave
        If dtpOFW.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtOFW.WatermarkText, DateDiff(DateInterval.Day, dtpOFW.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpOFW.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpSeaman_Leave(sender As Object, e As EventArgs) Handles dtpSeaman.Leave
        If dtpSeaman.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtSeaman.WatermarkText, DateDiff(DateInterval.Day, dtpSeaman.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpSeaman.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPNP_Leave(sender As Object, e As EventArgs) Handles dtpPNP.Leave
        If dtpPNP.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPNP.WatermarkText, DateDiff(DateInterval.Day, dtpPNP.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPNP.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpAFP_Leave(sender As Object, e As EventArgs) Handles dtpAFP.Leave
        If dtpAFP.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtAFP.WatermarkText, DateDiff(DateInterval.Day, dtpAFP.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpAFP.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpHDMF_Leave(sender As Object, e As EventArgs) Handles dtpHDMF.Leave
        If dtpHDMF.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtHDMF.WatermarkText, DateDiff(DateInterval.Day, dtpHDMF.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpHDMF.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPWD_Leave(sender As Object, e As EventArgs) Handles dtpPWD.Leave
        If dtpPWD.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPWD.WatermarkText, DateDiff(DateInterval.Day, dtpPWD.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPWD.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpDSWD_Leave(sender As Object, e As EventArgs) Handles dtpDSWD.Leave
        If dtpDSWD.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtDSWD.WatermarkText, DateDiff(DateInterval.Day, dtpDSWD.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpDSWD.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpACR_Leave(sender As Object, e As EventArgs) Handles dtpACR.Leave
        If dtpACR.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtACR.WatermarkText, DateDiff(DateInterval.Day, dtpACR.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpACR.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpDTI_Business_Leave(sender As Object, e As EventArgs) Handles dtpDTI_Business.Leave
        If dtpDTI_Business.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtDTI_Business.WatermarkText, DateDiff(DateInterval.Day, dtpDTI_Business.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpDTI_Business.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpIBP_Leave(sender As Object, e As EventArgs) Handles dtpIBP.Leave
        If dtpIBP.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtIBP.WatermarkText, DateDiff(DateInterval.Day, dtpDrivers.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpIBP.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpFireArms_Leave(sender As Object, e As EventArgs) Handles dtpFireArms.Leave
        If dtpFireArms.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtFireArms.WatermarkText, DateDiff(DateInterval.Day, dtpFireArms.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpFireArms.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpGovernment_Leave(sender As Object, e As EventArgs) Handles dtpGovernment.Leave
        If dtpGovernment.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtGovernment.WatermarkText, DateDiff(DateInterval.Day, dtpGovernment.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpGovernment.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpDiplomat_Leave(sender As Object, e As EventArgs) Handles dtpDiplomat.Leave
        If dtpDiplomat.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtDiplomat.WatermarkText, DateDiff(DateInterval.Day, dtpDiplomat.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpDiplomat.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpNational_Leave(sender As Object, e As EventArgs) Handles dtpNational.Leave
        If dtpNational.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtNational.WatermarkText, DateDiff(DateInterval.Day, dtpNational.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpNational.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpWork_Leave(sender As Object, e As EventArgs) Handles dtpWork.Leave
        If dtpWork.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtWork.WatermarkText, DateDiff(DateInterval.Day, dtpWork.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpWork.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpGOCC_Leave(sender As Object, e As EventArgs) Handles dtpGOCC.Leave
        If dtpGOCC.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtGOCC.WatermarkText, DateDiff(DateInterval.Day, dtpGOCC.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpGOCC.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpPLRA_Leave(sender As Object, e As EventArgs) Handles dtpPLRA.Leave
        If dtpPLRA.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtPLRA.WatermarkText, DateDiff(DateInterval.Day, dtpPLRA.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpPLRA.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpMajor_Leave(sender As Object, e As EventArgs) Handles dtpMajor.Leave
        If dtpMajor.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtMajor.WatermarkText, DateDiff(DateInterval.Day, dtpMajor.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpMajor.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpMedia_Leave(sender As Object, e As EventArgs) Handles dtpMedia.Leave
        If dtpMedia.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtMedia.WatermarkText, DateDiff(DateInterval.Day, dtpMedia.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpMedia.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpStudent_Leave(sender As Object, e As EventArgs) Handles dtpStudent.Leave
        If dtpStudent.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtStudent.WatermarkText, DateDiff(DateInterval.Day, dtpStudent.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpStudent.Value = Date.Now
            End If
        End If
    End Sub

    Private Sub DtpSIRV_Leave(sender As Object, e As EventArgs) Handles dtpSIRV.Leave
        If dtpSIRV.Value < DateValue(Date.Now) Then
            If MsgBox(String.Format("Your {0} is already expired {1} day(s) ago, Are you sure you want to continue?", txtSIRV.WatermarkText, DateDiff(DateInterval.Day, dtpSIRV.Value, Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                dtpSIRV.Value = Date.Now
            End If
        End If
    End Sub
#End Region

#Region "Keydown"
    Private Sub FrmID_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnDone.Focus()
            btnDone.PerformClick()
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

    Private Sub TxtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS.Focus()
        End If
    End Sub

    Private Sub TxtSSS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGSIS.Focus()
        End If
    End Sub

    Private Sub TxtGSIS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGSIS.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPhilHealth.Focus()
        End If
    End Sub

    Private Sub TxtPhilHealth_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPhilHealth.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSenior.Focus()
        End If
    End Sub

    Private Sub TxtSenior_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSenior.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUMID.Focus()
        End If
    End Sub

    Private Sub TxtUMID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUMID.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSEC.Focus()
        End If
    End Sub

    Private Sub TxtSEC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSEC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDTI.Focus()
        End If
    End Sub

    Private Sub TxtDTI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDTI.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCDA.Focus()
        End If
    End Sub

    Private Sub TxtCDA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCDA.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCooperative.Focus()
        End If
    End Sub

    Private Sub TxtCooperative_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCooperative.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDrivers.Focus()
        End If
    End Sub

    Private Sub TxtDrivers_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDrivers.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDrivers.Text.Trim = "" Then
                txtVIN.Focus()
            Else
                dtpDrivers.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDrivers_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDrivers.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtVIN.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpDrivers.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtVIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtVIN.Text.Trim = "" Then
                txtPassport.Focus()
            Else
                dtpVIN.Focus()
            End If
        End If
    End Sub

    Private Sub DtpVIN_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpVIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassport.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpVIN.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPassport_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassport.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassport.Text.Trim = "" Then
                txtPRC.Focus()
            Else
                dtpPassport.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPassport_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPassport.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPRC.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPassport.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPRC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPRC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPRC.Text.Trim = "" Then
                txtNBI.Focus()
            Else
                dtpPRC.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPRC_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPRC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNBI.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPRC.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtNBI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNBI.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNBI.Text.Trim = "" Then
                txtPolice.Focus()
            Else
                dtpNBI.Focus()
            End If
        End If
    End Sub

    Private Sub DtpNBI_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpNBI.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPolice.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpNBI.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPolice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPolice.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPolice.Text.Trim = "" Then
                txtPostal.Focus()
            Else
                dtpPolice.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPolice_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPolice.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPostal.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPolice.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPostal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPostal.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPostal.Text.Trim = "" Then
                txtBarangay.Focus()
            Else
                dtpPostal.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPostal_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPostal.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPostal.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtBarangay_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtBarangay.Text.Trim = "" Then
                txtOWWA.Focus()
            Else
                dtpBarangay.Focus()
            End If
        End If
    End Sub

    Private Sub DtpBarangay_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpBarangay.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOWWA.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpBarangay.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtOWWA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOWWA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtOWWA.Text.Trim = "" Then
                txtOFW.Focus()
            Else
                dtpOWWA.Focus()
            End If
        End If
    End Sub

    Private Sub DtpOWWA_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOWWA.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOFW.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpOWWA.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtOFW_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOFW.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtOFW.Text.Trim = "" Then
                txtSeaman.Focus()
            Else
                dtpOFW.Focus()
            End If
        End If
    End Sub

    Private Sub DtpOFW_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOFW.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSeaman.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpOFW.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSeaman_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeaman.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtSeaman.Text.Trim = "" Then
                txtPNP.Focus()
            Else
                dtpSeaman.Focus()
            End If
        End If
    End Sub

    Private Sub DtpSeaman_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpSeaman.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPNP.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpSeaman.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPNP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPNP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPNP.Text.Trim = "" Then
                txtAFP.Focus()
            Else
                dtpPNP.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPNP_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPNP.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAFP.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPNP.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtAFP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAFP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtAFP.Text.Trim = "" Then
                txtHDMF.Focus()
            Else
                dtpAFP.Focus()
            End If
        End If
    End Sub

    Private Sub DtpAFP_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAFP.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtHDMF.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpAFP.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtHDMF_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHDMF.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtHDMF.Text.Trim = "" Then
                txtPWD.Focus()
            Else
                dtpHDMF.Focus()
            End If
        End If
    End Sub

    Private Sub DtpHDMF_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHDMF.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPWD.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpHDMF.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPWD.Text.Trim = "" Then
                txtDSWD.Focus()
            Else
                dtpPWD.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPWD_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDSWD.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPWD.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtDSWD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDSWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDSWD.Text.Trim = "" Then
                txtACR.Focus()
            Else
                dtpDSWD.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDSWD_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDSWD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtACR.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpDSWD.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtACR_KeyDown(sender As Object, e As KeyEventArgs) Handles txtACR.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtACR.Text.Trim = "" Then
                txtDTI_Business.Focus()
            Else
                dtpACR.Focus()
            End If
        End If
    End Sub

    Private Sub DtpACR_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpACR.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDTI_Business.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpACR.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtDTI_Business_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDTI_Business.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDTI_Business.Text.Trim = "" Then
                txtIBP.Focus()
            Else
                dtpDTI_Business.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDTI_Business_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDTI_Business.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIBP.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpDTI_Business.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtIBP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIBP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIBP.Text.Trim = "" Then
                txtFireArms.Focus()
            Else
                dtpIBP.Focus()
            End If
        End If
    End Sub

    Private Sub DtpIBP_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpIBP.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFireArms.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpIBP.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtFireArms_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFireArms.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtFireArms.Text.Trim = "" Then
                txtGovernment.Focus()
            Else
                dtpFireArms.Focus()
            End If
        End If
    End Sub

    Private Sub DtpFireArms_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFireArms.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGovernment.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpFireArms.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGovernment_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGovernment.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtGovernment.Text.Trim = "" Then
                txtDiplomat.Focus()
            Else
                dtpGovernment.Focus()
            End If
        End If
    End Sub

    Private Sub DtpGovernment_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpGovernment.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDiplomat.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpGovernment.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtDiplomat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiplomat.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtDiplomat.Text.Trim = "" Then
                txtNational.Focus()
            Else
                dtpDiplomat.Focus()
            End If
        End If
    End Sub

    Private Sub DtpDiplomat_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDiplomat.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNational.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpDiplomat.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtNational_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNational.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNational.Text.Trim = "" Then
                txtWork.Focus()
            Else
                dtpNational.Focus()
            End If
        End If
    End Sub

    Private Sub DtpNational_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpNational.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWork.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpNational.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtWork_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWork.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtWork.Text.Trim = "" Then
                txtGOCC.Focus()
            Else
                dtpWork.Focus()
            End If
        End If
    End Sub

    Private Sub DtpWork_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpWork.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGOCC.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpWork.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGOCC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGOCC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtGOCC.Text.Trim = "" Then
                txtPLRA.Focus()
            Else
                dtpGOCC.Focus()
            End If
        End If
    End Sub

    Private Sub DtpGOCC_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpGOCC.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPLRA.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpGOCC.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtPLRA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPLRA.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPLRA.Text.Trim = "" Then
                txtMajor.Focus()
            Else
                dtpPLRA.Focus()
            End If
        End If
    End Sub

    Private Sub DtpPLRA_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPLRA.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMajor.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpPLRA.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtMajor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMajor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtMajor.Text.Trim = "" Then
                txtMedia.Focus()
            Else
                dtpMajor.Focus()
            End If
        End If
    End Sub

    Private Sub DtpMajor_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpMajor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMedia.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpMajor.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtMedia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMedia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtMedia.Text.Trim = "" Then
                txtStudent.Focus()
            Else
                dtpMedia.Focus()
            End If
        End If
    End Sub

    Private Sub DtpMedia_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpMedia.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStudent.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpMedia.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtStudent_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtStudent.Text.Trim = "" Then
                txtSIRV.Focus()
            Else
                dtpStudent.Focus()
            End If
        End If
    End Sub

    Private Sub DtpStudent_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpStudent.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSIRV.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpStudent.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSIRV_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSIRV.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtSIRV.Text.Trim = "" Then
                btnDone.Focus()
            Else
                dtpSIRV.Focus()
            End If
        End If
    End Sub

    Private Sub DtpSIRV_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpSIRV.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnDone.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpSIRV.CustomFormat = ""
        End If
    End Sub
#End Region

    'TEXTCHANGE
    Private Sub TxtDrivers_TextChanged(sender As Object, e As EventArgs) Handles txtDrivers.TextChanged
        If txtDrivers.Text.Trim = "" Then
            dtpDrivers.CustomFormat = ""
            dtpDrivers.Enabled = False
        Else
            dtpDrivers.Enabled = True
            dtpDrivers.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtVIN_TextChanged(sender As Object, e As EventArgs) Handles txtVIN.TextChanged
        If txtVIN.Text.Trim = "" Then
            dtpVIN.CustomFormat = ""
            dtpVIN.Enabled = False
        Else
            dtpVIN.Enabled = True
            dtpVIN.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPassport_TextChanged(sender As Object, e As EventArgs) Handles txtPassport.TextChanged
        If txtPassport.Text.Trim = "" Then
            dtpPassport.CustomFormat = ""
            dtpPassport.Enabled = False
        Else
            dtpPassport.Enabled = True
            dtpPassport.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPRC_TextChanged(sender As Object, e As EventArgs) Handles txtPRC.TextChanged
        If txtPRC.Text.Trim = "" Then
            dtpPRC.CustomFormat = ""
            dtpPRC.Enabled = False
        Else
            dtpPRC.Enabled = True
            dtpPRC.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtNBI_TextChanged(sender As Object, e As EventArgs) Handles txtNBI.TextChanged
        If txtNBI.Text.Trim = "" Then
            dtpNBI.CustomFormat = ""
            dtpNBI.Enabled = False
        Else
            dtpNBI.Enabled = True
            dtpNBI.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPolice_TextChanged(sender As Object, e As EventArgs) Handles txtPolice.TextChanged
        If txtPolice.Text.Trim = "" Then
            dtpPolice.CustomFormat = ""
            dtpPolice.Enabled = False
        Else
            dtpPolice.Enabled = True
            dtpPolice.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPostal_TextChanged(sender As Object, e As EventArgs) Handles txtPostal.TextChanged
        If txtPostal.Text.Trim = "" Then
            dtpPostal.CustomFormat = ""
            dtpPostal.Enabled = False
        Else
            dtpPostal.Enabled = True
            dtpPostal.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtBarangay_TextChanged(sender As Object, e As EventArgs) Handles txtBarangay.TextChanged
        If txtBarangay.Text.Trim = "" Then
            dtpBarangay.CustomFormat = ""
            dtpBarangay.Enabled = False
        Else
            dtpBarangay.Enabled = True
            dtpBarangay.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtOWWA_TextChanged(sender As Object, e As EventArgs) Handles txtOWWA.TextChanged
        If txtOWWA.Text.Trim = "" Then
            dtpOWWA.CustomFormat = ""
            dtpOWWA.Enabled = False
        Else
            dtpOWWA.Enabled = True
            dtpOWWA.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtOFW_TextChanged(sender As Object, e As EventArgs) Handles txtOFW.TextChanged
        If txtOFW.Text.Trim = "" Then
            dtpOFW.CustomFormat = ""
            dtpOFW.Enabled = False
        Else
            dtpOFW.Enabled = True
            dtpOFW.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtSeaman_TextChanged(sender As Object, e As EventArgs) Handles txtSeaman.TextChanged
        If txtSeaman.Text.Trim = "" Then
            dtpSeaman.CustomFormat = ""
            dtpSeaman.Enabled = False
        Else
            dtpSeaman.Enabled = True
            dtpSeaman.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPNP_TextChanged(sender As Object, e As EventArgs) Handles txtPNP.TextChanged
        If txtPNP.Text.Trim = "" Then
            dtpPNP.CustomFormat = ""
            dtpPNP.Enabled = False
        Else
            dtpPNP.Enabled = True
            dtpPNP.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtAFP_TextChanged(sender As Object, e As EventArgs) Handles txtAFP.TextChanged
        If txtAFP.Text.Trim = "" Then
            dtpAFP.CustomFormat = ""
            dtpAFP.Enabled = False
        Else
            dtpAFP.Enabled = True
            dtpAFP.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtHDMF_TextChanged(sender As Object, e As EventArgs) Handles txtHDMF.TextChanged
        If txtHDMF.Text.Trim = "" Then
            dtpHDMF.CustomFormat = ""
            dtpHDMF.Enabled = False
        Else
            dtpHDMF.Enabled = True
            dtpHDMF.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPWD_TextChanged(sender As Object, e As EventArgs) Handles txtPWD.TextChanged
        If txtPWD.Text.Trim = "" Then
            dtpPWD.CustomFormat = ""
            dtpPWD.Enabled = False
        Else
            dtpPWD.Enabled = True
            dtpPWD.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtDSWD_TextChanged(sender As Object, e As EventArgs) Handles txtDSWD.TextChanged
        If txtDSWD.Text.Trim = "" Then
            dtpDSWD.CustomFormat = ""
            dtpDSWD.Enabled = False
        Else
            dtpDSWD.Enabled = True
            dtpDSWD.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtACR_TextChanged(sender As Object, e As EventArgs) Handles txtACR.TextChanged
        If txtACR.Text.Trim = "" Then
            dtpACR.CustomFormat = ""
            dtpACR.Enabled = False
        Else
            dtpACR.Enabled = True
            dtpACR.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtDTI_Business_TextChanged(sender As Object, e As EventArgs) Handles txtDTI_Business.TextChanged
        If txtDTI_Business.Text.Trim = "" Then
            dtpDTI_Business.CustomFormat = ""
            dtpDTI_Business.Enabled = False
        Else
            dtpDTI_Business.Enabled = True
            dtpDTI_Business.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtIBP_TextChanged(sender As Object, e As EventArgs) Handles txtIBP.TextChanged
        If txtIBP.Text.Trim = "" Then
            dtpIBP.CustomFormat = ""
            dtpIBP.Enabled = False
        Else
            dtpIBP.Enabled = True
            dtpIBP.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtFireArms_TextChanged(sender As Object, e As EventArgs) Handles txtFireArms.TextChanged
        If txtFireArms.Text.Trim = "" Then
            dtpFireArms.CustomFormat = ""
            dtpFireArms.Enabled = False
        Else
            dtpFireArms.Enabled = True
            dtpFireArms.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtGovernment_TextChanged(sender As Object, e As EventArgs) Handles txtGovernment.TextChanged
        If txtGovernment.Text.Trim = "" Then
            dtpGovernment.CustomFormat = ""
            dtpGovernment.Enabled = False
        Else
            dtpGovernment.Enabled = True
            dtpGovernment.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtDiplomat_TextChanged(sender As Object, e As EventArgs) Handles txtDiplomat.TextChanged
        If txtDiplomat.Text.Trim = "" Then
            dtpDiplomat.CustomFormat = ""
            dtpDiplomat.Enabled = False
        Else
            dtpDiplomat.Enabled = True
            dtpDiplomat.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtNational_TextChanged(sender As Object, e As EventArgs) Handles txtNational.TextChanged
        If txtNational.Text.Trim = "" Then
            dtpNational.CustomFormat = ""
            dtpNational.Enabled = False
        Else
            dtpNational.Enabled = True
            dtpNational.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtWork_TextChanged(sender As Object, e As EventArgs) Handles txtWork.TextChanged
        If txtWork.Text.Trim = "" Then
            dtpWork.CustomFormat = ""
            dtpWork.Enabled = False
        Else
            dtpWork.Enabled = True
            dtpWork.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtGOCC_TextChanged(sender As Object, e As EventArgs) Handles txtGOCC.TextChanged
        If txtGOCC.Text.Trim = "" Then
            dtpGOCC.CustomFormat = ""
            dtpGOCC.Enabled = False
        Else
            dtpGOCC.Enabled = True
            dtpGOCC.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtPLRA_TextChanged(sender As Object, e As EventArgs) Handles txtPLRA.TextChanged
        If txtPLRA.Text.Trim = "" Then
            dtpPLRA.CustomFormat = ""
            dtpPLRA.Enabled = False
        Else
            dtpPLRA.Enabled = True
            dtpPLRA.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtMajor_TextChanged(sender As Object, e As EventArgs) Handles txtMajor.TextChanged
        If txtMajor.Text.Trim = "" Then
            dtpMajor.CustomFormat = ""
            dtpMajor.Enabled = False
        Else
            dtpMajor.Enabled = True
            dtpMajor.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtMedia_TextChanged(sender As Object, e As EventArgs) Handles txtMedia.TextChanged
        If txtMedia.Text.Trim = "" Then
            dtpMedia.CustomFormat = ""
            dtpMedia.Enabled = False
        Else
            dtpMedia.Enabled = True
            dtpMedia.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtStudent_TextChanged(sender As Object, e As EventArgs) Handles txtStudent.TextChanged
        If txtStudent.Text.Trim = "" Then
            dtpStudent.CustomFormat = ""
            dtpStudent.Enabled = False
        Else
            dtpStudent.Enabled = True
            dtpStudent.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub TxtSIRV_TextChanged(sender As Object, e As EventArgs) Handles txtSIRV.TextChanged
        If txtSIRV.Text.Trim = "" Then
            dtpSIRV.CustomFormat = ""
            dtpSIRV.Enabled = False
        Else
            dtpSIRV.Enabled = True
            dtpSIRV.CustomFormat = "MMM. dd, yyyy"
        End If
    End Sub

    Private Sub DtpDrivers_Click(sender As Object, e As EventArgs) Handles dtpDrivers.Click
        dtpDrivers.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpVIN_Click(sender As Object, e As EventArgs) Handles dtpVIN.Click
        dtpVIN.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPassport_Click(sender As Object, e As EventArgs) Handles dtpPassport.Click
        dtpPassport.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPRC_Click(sender As Object, e As EventArgs) Handles dtpPRC.Click
        dtpPRC.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpNBI_Click(sender As Object, e As EventArgs) Handles dtpNBI.Click
        dtpNBI.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPolice_Click(sender As Object, e As EventArgs) Handles dtpPolice.Click
        dtpPolice.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPostal_Click(sender As Object, e As EventArgs) Handles dtpPostal.Click
        dtpPostal.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpBarangay_Click(sender As Object, e As EventArgs) Handles dtpBarangay.Click
        dtpBarangay.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpOWWA_Click(sender As Object, e As EventArgs) Handles dtpOWWA.Click
        dtpOWWA.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpOFW_Click(sender As Object, e As EventArgs) Handles dtpOFW.Click
        dtpOFW.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpSeaman_Click(sender As Object, e As EventArgs) Handles dtpSeaman.Click
        dtpSeaman.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPNP_Click(sender As Object, e As EventArgs) Handles dtpPNP.Click
        dtpPNP.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpAFP_Click(sender As Object, e As EventArgs) Handles dtpAFP.Click
        dtpAFP.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpHDMF_Click(sender As Object, e As EventArgs) Handles dtpHDMF.Click
        dtpHDMF.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPWD_Click(sender As Object, e As EventArgs) Handles dtpPWD.Click
        dtpPWD.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpDSWD_Click(sender As Object, e As EventArgs) Handles dtpDSWD.Click
        dtpDSWD.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpACR_Click(sender As Object, e As EventArgs) Handles dtpACR.Click
        dtpACR.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpDTI_Business_Click(sender As Object, e As EventArgs) Handles dtpDTI_Business.Click
        dtpDTI_Business.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpIBP_Click(sender As Object, e As EventArgs) Handles dtpIBP.Click
        dtpIBP.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpFireArms_Click(sender As Object, e As EventArgs) Handles dtpFireArms.Click
        dtpFireArms.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpGovernment_Click(sender As Object, e As EventArgs) Handles dtpGovernment.Click
        dtpGovernment.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpDiplomat_Click(sender As Object, e As EventArgs) Handles dtpDiplomat.Click
        dtpDiplomat.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpNational_Click(sender As Object, e As EventArgs) Handles dtpNational.Click
        dtpNational.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpWork_Click(sender As Object, e As EventArgs) Handles dtpWork.Click
        dtpWork.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpGOCC_Click(sender As Object, e As EventArgs) Handles dtpGOCC.Click
        dtpGOCC.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpPLRA_Click(sender As Object, e As EventArgs) Handles dtpPLRA.Click
        dtpPLRA.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpMajor_Click(sender As Object, e As EventArgs) Handles dtpMajor.Click
        dtpMajor.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpMedia_Click(sender As Object, e As EventArgs) Handles dtpMedia.Click
        dtpMedia.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpStudent_Click(sender As Object, e As EventArgs) Handles dtpStudent.Click
        dtpStudent.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpSIRV_Click(sender As Object, e As EventArgs) Handles dtpSIRV.Click
        dtpSIRV.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If btnDone.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                btnDone.DialogResult = DialogResult.OK
                btnDone.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnAttach_TIN_Click(sender As Object, e As EventArgs) Handles btnAttach_TIN.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment TIN" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment TIN"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_TIN
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_TIN = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_TIN = .TotalImage
                    Else
                        FrmBorrower.TotalImage_TIN_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_TIN > 0 Then
                btnAttach_TIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_TIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_SSS_Click(sender As Object, e As EventArgs) Handles btnAttach_SSS.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment SSS" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SSS"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_SSS
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_SSS = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_SSS = .TotalImage
                    Else
                        FrmBorrower.TotalImage_SSS_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_SSS > 0 Then
                btnAttach_SSS.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_SSS.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_GSIS_Click(sender As Object, e As EventArgs) Handles btnAttach_GSIS.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment GSIS" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GSIS"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_GSIS
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_GSIS = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_GSIS = .TotalImage
                    Else
                        FrmBorrower.TotalImage_GSIS_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_GSIS > 0 Then
                btnAttach_GSIS.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_GSIS.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_PhilHealth_Click(sender As Object, e As EventArgs) Handles btnAttach_PhilHealth.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment PhilHealth" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PhilHealth"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_PhilHealth
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_PhilHealth = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_PhilHealth = .TotalImage
                    Else
                        FrmBorrower.TotalImage_PhilHealth_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_PhilHealth > 0 Then
                btnAttach_PhilHealth.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_PhilHealth.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Senior_Click(sender As Object, e As EventArgs) Handles btnAttach_Senior.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Senior" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Senior"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Senior
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Senior = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Senior = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Senior_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Senior > 0 Then
                btnAttach_Senior.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Senior.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_UMID_Click(sender As Object, e As EventArgs) Handles btnAttach_UMID.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment UMID" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment UMID"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_UMID
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_UMID = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_UMID = .TotalImage
                    Else
                        FrmBorrower.TotalImage_UMID_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_UMID > 0 Then
                btnAttach_UMID.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_UMID.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_SEC_Click(sender As Object, e As EventArgs) Handles btnAttach_SEC.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment SEC" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SEC"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_SEC
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_SEC = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_SEC = .TotalImage
                    Else
                        FrmBorrower.TotalImage_SEC_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_SEC > 0 Then
                btnAttach_SEC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_SEC.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_DTI_Click(sender As Object, e As EventArgs) Handles btnAttach_DTI.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment DTI" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_DTI
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_DTI = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_DTI = .TotalImage
                    Else
                        FrmBorrower.TotalImage_DTI_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_DTI > 0 Then
                btnAttach_DTI.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_DTI.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_CDA_Click(sender As Object, e As EventArgs) Handles btnAttach_CDA.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment CDA" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment CDA"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_CDA
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_CDA = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_CDA = .TotalImage
                    Else
                        FrmBorrower.TotalImage_CDA_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_CDA > 0 Then
                btnAttach_CDA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_CDA.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Cooperative_Click(sender As Object, e As EventArgs) Handles btnAttach_Cooperative.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Cooperative" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Cooperative"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Cooperative
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Cooperative = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Cooperative = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Cooperative_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Cooperative > 0 Then
                btnAttach_Cooperative.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Cooperative.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Drivers_Click(sender As Object, e As EventArgs) Handles btnAttach_Drivers.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Drivers" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Drivers"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Drivers
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Drivers = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Drivers = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Drivers_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Drivers > 0 Then
                btnAttach_Drivers.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Drivers.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_VIN_Click(sender As Object, e As EventArgs) Handles btnAttach_VIN.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment VIN" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment VIN"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_VIN
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_VIN = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_VIN = .TotalImage
                    Else
                        FrmBorrower.TotalImage_VIN_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_VIN > 0 Then
                btnAttach_VIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_VIN.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Passport_Click(sender As Object, e As EventArgs) Handles btnAttach_Passport.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Passport" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Passport"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Passport
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Passport = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Passport = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Passport_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Passport > 0 Then
                btnAttach_Passport.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Passport.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_PRC_Click(sender As Object, e As EventArgs) Handles btnAttach_PRC.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment PRC" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PRC"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_PRC
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_PRC = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_PRC = .TotalImage
                    Else
                        FrmBorrower.TotalImage_PRC_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_PRC > 0 Then
                btnAttach_PRC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_PRC.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_NBI_Click(sender As Object, e As EventArgs) Handles btnAttach_NBI.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment NBI" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment NBI"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_NBI
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_NBI = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_NBI = .TotalImage
                    Else
                        FrmBorrower.TotalImage_NBI_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_NBI > 0 Then
                btnAttach_NBI.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_NBI.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Police_Click(sender As Object, e As EventArgs) Handles btnAttach_Police.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Police" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Police"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Police
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Police = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Police = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Police_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Police > 0 Then
                btnAttach_Police.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Police.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Postal_Click(sender As Object, e As EventArgs) Handles btnAttach_Postal.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Postal" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Postal"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Postal
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Postal = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Postal = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Postal_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Postal > 0 Then
                btnAttach_Postal.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Postal.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Barangay_Click(sender As Object, e As EventArgs) Handles btnAttach_Barangay.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Barangay" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Barangay"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Barangay
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Barangay = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Barangay = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Barangay_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Barangay > 0 Then
                btnAttach_Barangay.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Barangay.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_OWWA_Click(sender As Object, e As EventArgs) Handles btnAttach_OWWA.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment OWWA" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OWWA"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_OWWA
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_OWWA = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_OWWA = .TotalImage
                    Else
                        FrmBorrower.TotalImage_OWWA_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_OWWA > 0 Then
                btnAttach_OWWA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_OWWA.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_OFW_Click(sender As Object, e As EventArgs) Handles btnAttach_OFW.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment OFW" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OFW"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_OFW
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_OFW = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_OFW = .TotalImage
                    Else
                        FrmBorrower.TotalImage_OFW_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_OFW > 0 Then
                btnAttach_OFW.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_OFW.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Seaman_Click(sender As Object, e As EventArgs) Handles btnAttach_Seaman.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Seaman" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Seaman"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Seaman
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Seaman = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Seaman = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Seaman_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Seaman > 0 Then
                btnAttach_Seaman.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Seaman.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_PNP_Click(sender As Object, e As EventArgs) Handles btnAttach_PNP.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment PNP" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PNP"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_PNP
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_PNP = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_PNP = .TotalImage
                    Else
                        FrmBorrower.TotalImage_PNP_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_PNP > 0 Then
                btnAttach_PNP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_PNP.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_AFP_Click(sender As Object, e As EventArgs) Handles btnAttach_AFP.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment AFP" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment AFP"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_AFP
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_AFP = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_AFP = .TotalImage
                    Else
                        FrmBorrower.TotalImage_AFP_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_AFP > 0 Then
                btnAttach_AFP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_AFP.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_HDMF_Click(sender As Object, e As EventArgs) Handles btnAttach_HDMF.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment HDMF" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment HDMF"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_HDMF
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_HDMF = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_HDMF = .TotalImage
                    Else
                        FrmBorrower.TotalImage_HDMF_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_HDMF > 0 Then
                btnAttach_HDMF.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_HDMF.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_PWD_Click(sender As Object, e As EventArgs) Handles btnAttach_PWD.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment PWD" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PWD"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_PWD
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_PWD = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_PWD = .TotalImage
                    Else
                        FrmBorrower.TotalImage_PWD_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_PWD > 0 Then
                btnAttach_PWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_PWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_DSWD_Click(sender As Object, e As EventArgs) Handles btnAttach_DSWD.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment DSWD" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DSWD"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_DSWD
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_DSWD = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_DSWD = .TotalImage
                    Else
                        FrmBorrower.TotalImage_DSWD_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_DSWD > 0 Then
                btnAttach_DSWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_DSWD.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_ACR_Click(sender As Object, e As EventArgs) Handles btnAttach_ACR.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment ACR" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment ACR"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_ACR
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_ACR = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_ACR = .TotalImage
                    Else
                        FrmBorrower.TotalImage_ACR_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_ACR > 0 Then
                btnAttach_ACR.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_ACR.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_DTI_Business_Click(sender As Object, e As EventArgs) Handles btnAttach_DTI_Business.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment DTI_Business" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI_Business"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_DTI_Business
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_DTI_Business = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_DTI_Business = .TotalImage
                    Else
                        FrmBorrower.TotalImage_DTI_Business_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_DTI_Business > 0 Then
                btnAttach_DTI_Business.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_DTI_Business.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_IBP_Click(sender As Object, e As EventArgs) Handles btnAttach_IBP.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment IBP" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment IBP"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_IBP
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_IBP = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_IBP = .TotalImage
                    Else
                        FrmBorrower.TotalImage_IBP_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_IBP > 0 Then
                btnAttach_IBP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_IBP.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_FireArms_Click(sender As Object, e As EventArgs) Handles btnAttach_FireArms.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment FireArms" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment FireArms"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_FireArms
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_FireArms = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_FireArms = .TotalImage
                    Else
                        FrmBorrower.TotalImage_FireArms_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_FireArms > 0 Then
                btnAttach_FireArms.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_FireArms.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Government_Click(sender As Object, e As EventArgs) Handles btnAttach_Government.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Government" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Government"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Government
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Government = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Government = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Government_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Government > 0 Then
                btnAttach_Government.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Government.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Diplomat_Click(sender As Object, e As EventArgs) Handles btnAttach_Diplomat.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Diplomat" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Diplomat"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Diplomat
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Diplomat = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Diplomat = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Diplomat_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Diplomat > 0 Then
                btnAttach_Diplomat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Diplomat.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_National_Click(sender As Object, e As EventArgs) Handles btnAttach_National.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment National" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment National"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_National
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_National = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_National = .TotalImage
                    Else
                        FrmBorrower.TotalImage_National_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_National > 0 Then
                btnAttach_National.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_National.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Work_Click(sender As Object, e As EventArgs) Handles btnAttach_Work.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Work" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Work"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Work
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Work = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Work = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Work_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Work > 0 Then
                btnAttach_Work.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Work.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_GOCC_Click(sender As Object, e As EventArgs) Handles btnAttach_GOCC.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment GOCC" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GOCC"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_GOCC
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_GOCC = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_GOCC = .TotalImage
                    Else
                        FrmBorrower.TotalImage_GOCC_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_GOCC > 0 Then
                btnAttach_GOCC.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_GOCC.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Major_Click(sender As Object, e As EventArgs) Handles btnAttach_Major.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Major" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Major"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Major
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Major = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Major = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Major_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Major > 0 Then
                btnAttach_Major.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Major.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Media_Click(sender As Object, e As EventArgs) Handles btnAttach_Media.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Media" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Media"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Media
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Media = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Media = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Media_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Media > 0 Then
                btnAttach_Media.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Media.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Student_Click(sender As Object, e As EventArgs) Handles btnAttach_Student.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment Student" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Student"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_Student
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_Student = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_Student = .TotalImage
                    Else
                        FrmBorrower.TotalImage_Student_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_Student > 0 Then
                btnAttach_Student.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_Student.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_SIRV_Click(sender As Object, e As EventArgs) Handles btnAttach_SIRV.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment SIRV" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SIRV"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_SIRV
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_SIRV = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_SIRV = .TotalImage
                    Else
                        FrmBorrower.TotalImage_SIRV_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_SIRV > 0 Then
                btnAttach_SIRV.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_SIRV.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_PLRA_Click(sender As Object, e As EventArgs) Handles btnAttach_PLRA.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment PLRA" & If(ID_Type = "S", " [Spouse]", If(ID_Type = "B", "", "[" & ID_Type & "]"))
            .Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PLRA"
            .ID_Type = ID_Type
            .TotalImage = TotalImage_PLRA
            .BorrowerNumber = BorrowerID
            .ID = BorrowerID
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_PLRA = .TotalImage
                If From_Borrower Then
                    If ID_Type = "B" Then
                        FrmBorrower.TotalImage_PLRA = .TotalImage
                    Else
                        FrmBorrower.TotalImage_PLRA_S = .TotalImage
                    End If
                End If
            End If
            If TotalImage_PLRA > 0 Then
                btnAttach_PLRA.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            Else
                btnAttach_PLRA.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
            End If
            .Dispose()
        End With
    End Sub
End Class