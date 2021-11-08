Module ModVariable
    '***FOR REPORTS
    Public pLogo As New PictureBox
    Public pLogo_Complete As PictureBox
    Public rCompany As String = "First Standard Finance Corporation"
    '***FOR REPORTS

    '***FOR RUN TIME
    Public Salt As String
    Public User_ID As Integer
    Public User_Code As String
    Public Empl_Name As String
    Public Empl_ID As Integer
    Public Empl_Code As String
    Public Empl_Email As String
    Public Empl_Phone As String
    Public Empl_Extension As String
    Public Empl_Pic As New PictureBox
    Public Empl_Skin As String
    Public Empl_Position As String
    Public Empl_PositionID As Integer
    Public Empl_V2Position As String
    Public Empl_V2PositionID As Integer
    Public Empl_V3Position As String
    Public Empl_V3PositionID As Integer
    Public Empl_V4Position As String
    Public Empl_V4PositionID As Integer
    Public User_Type As String
    Public Company_ID As Integer
    Public Company_Code As String
    Public Company As String
    Public Branch_ID As Integer
    Public MFBranch_ID As String
    Public Branch_IDv2 As String
    Public RealBranchID As String
    Public Multiple_ID As String
    Public Multiple_Region As String
    Public Multiple_Province As String
    Public Branch_Code As String
    Public Branch As String
    Public RealBranchCode As String
    Public RealBranch As String
    Public Dept_ID As Integer
    Public Department As String
    Public DepartmentHead As Boolean
    Public Computer As String = Net.Dns.GetHostName.ToString
    Public IP_Address As String = If(Net.Dns.GetHostEntry(Computer).AddressList(1).ToString().Length < 20, Net.Dns.GetHostEntry(Computer).AddressList(1).ToString(), Net.Dns.GetHostEntry(Computer).AddressList(0).ToString())
    Public DefaultForm As Integer
    Public MotivationC As Integer
    Public Ext As String = "!@#"
    Public Round_Up As Boolean = False
    Public Max_Image As Integer = 15
    Public Max_Image_VE As Integer = 5
    Public Overstayed_Months As Integer = 18
    Public Overstayed As Boolean = True
    Public AmountLimit As Double
    Public MultipleBranch As Boolean
    Public PendingWork As Boolean
    Public Nickname As String
    Public New_Update As Boolean
    Public DefaultReservation As Integer = 7 'ROPOA Default Reservation
    Public DefaultPenalty As Double = 5 'Credit Application Default Penalty
    Public RedemptionMonth As Integer = 11 'Redemption Month System Notification
    Public cpuID As String = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "Identifier", "n/a")
    Public SMS_Notification As Boolean
    Public Email_Notification As Boolean
    Public AppraisedPercent As Double
    Public MultiAuthentication As Boolean
    Public DefaultBankID As Integer = 0
    Public Ping_Notification As Boolean
    Public Branch_DeferredIncome As Boolean
    Public Auto_Notification As Boolean
    Public Auto_Department As Boolean
    Public Auto_BusinessCenter As Boolean
    Public CIB_BDO As String = "111001"
    Public AdvanceOnPrinciapl As Boolean
    Public CVforJV As Boolean
    Public UseBankBranchID As String
    Public Auto_EmailSend As Boolean
    Public SendPendingEmailEvery As Integer = 300
    Public Auto_SMSSend As Boolean
    Public Auto_ROPA As Boolean
    Public Auto_Borrower As Boolean
    Public Auto_CreditApplication As Boolean
    Public Auto_CreditInvestigation As Boolean
    Public Auto_AlertNotification As Boolean
    Public Auto_BugReport As Boolean
    Public AllowPrintScreen As Boolean
    Public KeywordSearchWildcard As Boolean
    Public AllowDomainLogin As Boolean
    Public WithProgressBar As Boolean
    Public AllowFormHistory As Boolean
    Public AllowStandardUI As Boolean = True
    Public LastPWChange As Integer
    Public ChangePW As Boolean = True
    Public DTLoggedComputer As DataTable
    Public NotifyLoggedInToOthers As Boolean
    Public AutoRefreshData As Boolean
    Public AutoRefreshTime As Integer

    'SECURITY SETTINGS
    Public PWLength As Integer = 8
    Public PWAge As Integer = 90
    Public PWNotifyExpire As Integer = 7
    Public PWCase As Boolean = False
    Public PWSpecial As Boolean = False
    Public PWNumeric As Boolean = False
    Public PWForceChange As Boolean = True
    Public AccountThreshold As Integer = 5
    Public AccountLockDuration As Integer = 30
    Public AccountReset As Boolean = True
    Public OTACLength As Integer = 4
    Public OTACwithAlphabet As Boolean = False
    Public OTACCaseSensitive As Boolean = True
    Public OTACDuration As Integer = 5

    Public Suffix As New DataTable
    Public Prefix As New DataTable
    Public City As DataTable
    Public Nationality As DataTable
    Public Terms As DataTable
    Public Products As DataTable
    Public Collateral As DataTable
    Public Mortgage As DataTable
    Public DT_Employer As DataTable
    Public DT_Position As DataTable
    Public DT_Industry As DataTable
    Public DT_Signatory As DataTable
    Public DT_Employees As DataTable
    Public DT_Employees_Other As DataTable
    Public DT_Withholding_Individual As DataTable
    Public DT_Withholding_Corporate As DataTable

    Public DT_Accounts As DataTable
    Public DT_AccountsM As DataTable
    Public DT_Accounts_V2 As DataTable
    Public DT_AccountsM_V2 As DataTable

    Public DT_Accounts_WithCancel As DataTable
    Public DT_AccountsM_WithCancel As DataTable
    Public DT_Accounts_V2_WithCancel As DataTable
    Public DT_AccountsM_V2_WithCancel As DataTable

    Public DT_Department As DataTable
    Public DT_BusinessCenter As DataTable
    Public DT_BusinessCenter_V2 As DataTable
    Public DT_PCV_Approver As DataTable
    Public DT_CAS_Approver As DataTable
    Public DT_Temp_Account As New DataTable
    Public DT_SpecialAccess As DataTable
    Public DT_SpecialAccessDepartment As DataTable

    Public Bank As DataTable
    Public BankType As DataTable

    Public Fuel As New DataTable
    Public MileAge As New DataTable
    Public Make As DataTable
    Public CarClassification As DataTable

    Public Note As New DataTable
    Public Tariff As DataTable
    'Public Charges As New DataTable
    Public ServiceNew As DataTable
    Public ServiceRenew As DataTable
    Public DT_Holidays As DataTable

    Public ProvinceIDs As String
    Public RegionIDs As String
    Public DT_Region As DataTable
    Public DT_Province As DataTable

    Public Relation As DataTable
    Public DT_Remittance As DataTable
    'MESSAGE BOX
    'm Stands for MESSAGE
    Public Message As DataTable
    Public mClose1 As String = "Are you sure you want to close this form?"
    Public mClose As String = "Are you sure you want to close this form? All unsaved data will be removed."
    Public mSave As String = "Are you sure you want to save this data?"
    Public mUpdate As String = "Are you sure you want to update this data?"
    Public mModify As String = "Are you sure you want to modify this data?"
    'Public mModifyOn As String = "You can now modify the data"
    Public mDelete As String = "Are you sure you want to cancel this data?"
    Public mRefresh As String = "Are you sure you want to refresh this form? All unsaved data will be removed."
    Public mAccessDenied As String = "You don't have access with this button. Please contact administrator."

    Public RetrieveData As Boolean = False
    Public mRetrieve As String = "Do you want to activate the auto retrieve data? It function when you accidentally erase the triggering field and wish to retrieve the auto erased data."
    Public mRetrieveOff As String = "Do you want to deactivate the auto retrieve data?"

    'Public mEmail As String = " Email and SMS will be send to authorized personnel informing for the next step."
    Public mEmail As String = ""
    'Restriction
    Public Restriction As Boolean
    Public Restriction_DT As DataTable
    Public GroupRoleID As String
    Public allow_Access As Boolean
    Public allow_Save As Boolean
    Public allow_Update As Boolean
    Public allow_Delete As Boolean
    Public allow_Print As Boolean
    Public allow_Check As Boolean
    Public allow_Approve As Boolean

    Public mBox_Access As String = "You don't have permission to access this form. Please contact administrator."
    Public mBox_Save As String = "You don't have permission to add/save in this form. Please contact administrator."
    Public mBox_Update As String = "You don't have permission to update/modify in this form. Please contact administrator."
    Public mBox_Delete As String = "You don't have permission to cancel/delete in this form. Please contact administrator."
    Public mBox_Print As String = "You don't have permission to print/export in this form. Please contact administrator."
    Public mBox_SpecialAccess As String = "You do not have access with this function."

    'Directory
    Public RootFolder As String = "D:"
    Public MainFolder As String = "FSFC System"
    Public ReportFolder As String = "REPORTS"

    'Confidential
    Public IT_PW As String
    Public ConfiEmail As String
    Public ConfiPW As String

    Public Approver1ID As Integer
    Public Approver2ID As Integer
    Public Approver3ID As Integer
    Public Approver4ID As Integer

    Public Approver1Name As String
    Public Approver2Name As String
    Public Approver3Name As String
    Public Approver4Name As String

    Public Approver1Email As String
    Public Approver2Email As String
    Public Approver3Email As String
    Public Approver4Email As String

    Public Approver1Phone As String
    Public Approver2Phone As String
    Public Approver3Phone As String
    Public Approver4Phone As String

    Public Approver1_Credit As Double
    Public Approver2_Credit As Double
    Public Approver3_Credit As Double
    Public Approver4_Credit As Double

    Public Approver1_CashAdvance As Double
    Public Approver2_CashAdvance As Double
    Public Approver3_CashAdvance As Double
    Public Approver4_CashAdvance As Double

    Public CashApprovalHierarchy As Boolean
    Public CreditApprovalHierarchy As Boolean

    Public AvailedRPPD As Integer 'Days
    Public AvailedPenalty As Integer 'Days
    Public One As Integer = 1

    Public PettyCash As Double 'Budget

    Public Branch_TIN As String = ""
    Public Branch_Address As String = ""
    Public Branch_Contact As String = ""
    Public Branch_BM As String = ""
    Public Branch_Email As String = ""
    Public CompanyMode As Integer
    Public Prev_CompanyMode As Integer

    Public AllowFromOtherBranch As Boolean
    '***FOR RUN TIME

    Public EMessage As String = "The Ping Button is triggered please check immediately."
    Public ESubject As String = "Ping Button is Triggered!"

    'Official Color/Font/Font Size
    Public OfficialColor1 As Color = Color.FromArgb(0, 110, 242)
    Public OfficialColor2 As Color = Color.FromArgb(211, 47, 47)
    Public OfficialFont As String = "Roboto"
    Public OfficialFontSize As Double = 9.75
    Public OfficialFontSizeGrid As Double = 8.25

    Public CurrentVersion As String
    Public ASG_Email As String = "app.support@firststandard.ph"
    Public CredCommEmail As String = ""
End Module
