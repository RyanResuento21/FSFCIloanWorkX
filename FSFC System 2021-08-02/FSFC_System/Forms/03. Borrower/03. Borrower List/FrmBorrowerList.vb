Public Class FrmBorrowerList

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    ReadOnly Show_Dialog As Boolean = True

    Private Sub FrmBorrowerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0
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

            GetLabelFontSettings({LabelX155, LabelX10, LabelX1})

            GetComboBoxFontSettings({cbxDisplay})

            GetButtonFontSettings({btnSearch, btnPrint, btnCancel, btnCIC, btnAttach, btnBlock})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetCheckBoxFontSettings({cbxAll, cbxAdvanced})

            GetCheckBoxFontSettingsRed({cbxBlocked})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Borrower List - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Borrowers List", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String

        If SuperTabControl1.SelectedTabIndex = 0 Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    BorrowerID AS 'Borrowers ID',"
            SQL &= "    CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower',"
            SQL &= "    CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Complete Address',"
            SQL &= "    DATE_FORMAT(Birth_B,'%m.%d.%Y') AS 'Date of Birth',"
            SQL &= "    IF(Gender_B = 'Male','M',IF(Gender_B = 'Female','F','')) AS 'Gender',"
            SQL &= "    Civil_B AS 'Civil Status',"
            SQL &= String.Format("    IFNULL(IF(branch_id = '{0}',Telephone_B,IF(Telephone_B = '','','********')),'') AS 'Telephone No.',", Branch_ID)
            SQL &= String.Format("    IFNULL(IF(branch_id = '{0}',Mobile_B,IF(Mobile_B = '','','********')),'') AS 'Mobile No.', ", Branch_ID)
            SQL &= "    Attach, branch_code, (SELECT branch FROM branch WHERE branch.branch_code = profile_borrower.branch_code) AS 'Branch', `Status`, (SELECT BusinessCenter FROM business_center WHERE ID = profile_borrower.BusinessID) AS 'Business Center', IF(`status` = 'BLOCKED',Branch(BlockedBranchID),'') AS 'Blocked By'"
            SQL &= " FROM profile_borrower "
            If cbxAdvanced.Checked Then
                SQL &= "    WHERE TRUE"
            Else
                SQL &= String.Format("    WHERE Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            End If
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(timestamp) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            If cbxAdvanced.Checked Then
                If FrmAdvancedSearch.txtKeyword.Text.Trim = "" Then
                Else
                    Dim Words As String() = FrmAdvancedSearch.txtKeyword.Text.Trim.Split(New Char() {" "c})
                    If KeywordSearchWildcard Then
                        Dim Key As String
                        For Each Key In Words
                            SQL &= String.Format(" AND (`Prefix_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_S` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_S` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_S` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_S` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_S` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NoC_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `StreetC_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BarangayC_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AddressC_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NoP_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `StreetP_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BarangayP_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AddressP_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Gender_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Civil_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Citizenship_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Telephone_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Mobile_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Mobile_B2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Email_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `House_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Rent_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Employer_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `EmployerAddress_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `EmployerTelephone_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PositioN_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `EmploymentStat_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Hired_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Supervisor_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Monthly_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BusinessName_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BusinessAddress_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BusinessTelephone_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NatureBusiness_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `YrsOperation_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BusinessIncome_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NoEmployees_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Capital_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Area_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Expiry_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Outlet_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `OtherIncome_B` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `OtherIncome_B-Amount` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Creditor_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NatureLoan_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AmountGranted_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Term_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Balance_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `CreditRemarks_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Creditor_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NatureLoan_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AmountGranted_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Term_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Balance_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `CreditRemarks_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Creditor_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `NatureLoan_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AmountGranted_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Term_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Balance_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `CreditRemarks_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Bank_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Branch_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AccountT_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SA_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AverageBalance_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PresentBalance_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Opened_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BankRemarks_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Bank_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Branch_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AccountT_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SA_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AverageBalance_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PresentBalance_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Opened_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BankRemarks_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Bank_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Branch_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AccountT_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SA_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AverageBalance_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PresentBalance_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Opened_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BankRemarks_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Location_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TCT_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Area_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Acquired_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PropertiesRemarks_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Location_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TCT_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Area_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Acquired_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PropertiesRemarks_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Location_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TCT_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Area_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Acquired_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PropertiesRemarks_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Vehicle_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Year_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhomAcquired_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhenAcquired_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `VehicleRemarks_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Vehicle_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Year_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhomAcquired_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhenAcquired_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `VehicleRemarks_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Vehicle_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Year_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhomAcquired_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WhenAcquired_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `VehicleRemarks_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `HomeAppliances_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `HomeAppliances_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Reference_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceAddress_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceContact_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Reference_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceAddress_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceContact_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Reference_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceAddress_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `ReferenceContact_3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `CertificateNo` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PlaceIssue` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Issue` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Agent` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AgentNo` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Marketing` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MarketingNo` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WalkIn` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WalkIn_Specify` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Dealer` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `DealerNo` LIKE '%{0}%')", Key)
                        Next
                    Else
                        Dim key As String = FrmAdvancedSearch.txtKeyword.Text
                        SQL &= String.Format(" AND (`Prefix_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `FirstN_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `MiddleN_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `LastN_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Suffix_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Prefix_S` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `FirstN_S` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `MiddleN_S` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `LastN_S` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Suffix_S` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NoC_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `StreetC_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BarangayC_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AddressC_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NoP_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `StreetP_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BarangayP_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AddressP_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Gender_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Civil_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Citizenship_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `TIN_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Telephone_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `SSS_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Mobile_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Mobile_B2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Email_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `House_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Rent_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Employer_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `EmployerAddress_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `EmployerTelephone_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PositioN_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `EmploymentStat_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Hired_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Supervisor_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Monthly_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BusinessName_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BusinessAddress_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BusinessTelephone_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NatureBusiness_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `YrsOperation_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BusinessIncome_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NoEmployees_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Capital_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Area_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Expiry_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Outlet_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `OtherIncome_B` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `OtherIncome_B-Amount` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Creditor_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NatureLoan_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AmountGranted_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Term_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Balance_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `CreditRemarks_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Creditor_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NatureLoan_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AmountGranted_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Term_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Balance_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `CreditRemarks_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Creditor_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `NatureLoan_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AmountGranted_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Term_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Balance_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `CreditRemarks_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Bank_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Branch_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AccountT_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `SA_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AverageBalance_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PresentBalance_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Opened_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BankRemarks_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Bank_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Branch_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AccountT_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `SA_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AverageBalance_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PresentBalance_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Opened_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BankRemarks_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Bank_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Branch_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AccountT_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `SA_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AverageBalance_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PresentBalance_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Opened_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `BankRemarks_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Location_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `TCT_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Area_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Acquired_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PropertiesRemarks_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Location_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `TCT_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Area_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Acquired_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PropertiesRemarks_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Location_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `TCT_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Area_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Acquired_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PropertiesRemarks_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Vehicle_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Year_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhomAcquired_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhenAcquired_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `VehicleRemarks_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Vehicle_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Year_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhomAcquired_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhenAcquired_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `VehicleRemarks_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Vehicle_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Year_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhomAcquired_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WhenAcquired_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `VehicleRemarks_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `HomeAppliances_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `HomeAppliances_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Reference_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceAddress_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceContact_1` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Reference_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceAddress_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceContact_2` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Reference_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceAddress_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `ReferenceContact_3` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `CertificateNo` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `PlaceIssue` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Issue` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Agent` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `AgentNo` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Marketing` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `MarketingNo` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WalkIn` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `WalkIn_Specify` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `Dealer` LIKE '%{0}%' OR", key)
                        SQL &= String.Format(" `DealerNo` LIKE '%{0}%')", key)
                    End If
                End If
                With FrmAdvancedSearch
                    If .cbxMale_B.Checked And .cbxFemale_B.Checked Then
                    Else
                        If .cbxMale_B.Checked Then
                            SQL &= " AND (`Gender_B` = 'Male')"
                        ElseIf .cbxFemale_B.Checked Then
                            SQL &= " AND (`Gender_B` = 'Female')"
                        End If
                    End If
                    If .iFrom.Value = 0 And .iTo.Value = 0 Then
                    Else
                        SQL &= String.Format(" AND AGE(IF(Birth_B='',DATE(NOW()),Birth_B)) BETWEEN '{0}' AND '{1}'", .iFrom.Value, .iTo.Value)
                    End If
                    If .cbxSingle_B.Checked And .cbxMarried_B.Checked And .cbxSeparated_B.Checked And .cbxWidowed_B.Checked Then
                    ElseIf .cbxSingle_B.Checked = False And .cbxMarried_B.Checked = False And .cbxSeparated_B.Checked = False And .cbxWidowed_B.Checked = False Then
                    Else
                        SQL &= " AND ("
                        If .cbxSingle_B.Checked Then
                            SQL &= " `Civil_B` = 'Single'"
                            If .cbxMarried_B.Checked Or .cbxSeparated_B.Checked Or .cbxWidowed_B.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxMarried_B.Checked Then
                            SQL &= " `Civil_B` = 'Married'"
                            If .cbxSeparated_B.Checked Or .cbxWidowed_B.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxSeparated_B.Checked Then
                            SQL &= " `Civil_B` = 'Separated'"
                            If .cbxWidowed_B.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxWidowed_B.Checked Then
                            SQL &= " `Civil_B` = 'Widowed'"
                        End If
                        SQL &= ") "
                    End If
                End With
            End If
            SQL &= String.Format("    AND `status` IN ('ACTIVE','{0}') ORDER BY `Borrower` ASC;", If(cbxBlocked.Checked, "BLOCKED", ""))
            GridControl1.DataSource = DataSource(SQL)
            If cbxBlocked.Checked Then
                GridColumn26.Visible = True
            Else
                GridColumn26.Visible = False
            End If
            GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    BorrowerID AS 'Borrowers ID',"
            SQL &= "    TradeName AS 'Trade Name',"
            SQL &= "    CONCAT(IF(`No` = '','',CONCAT(`No`, ', ')), IF(Street = '','',CONCAT(Street, ', ')), IF(Barangay = '','',CONCAT(Barangay, ', ')), Address) AS 'Complete Address',"
            SQL &= "    TIN,"
            SQL &= "    SSS,"
            SQL &= "    Telephone AS 'Telephone No.',"
            SQL &= "    Email AS 'Email Address', Attach, branch_code, (SELECT branch FROM branch WHERE branch.branch_code = profile_corporation.branch_code) AS 'Branch', `Status`, (SELECT BusinessCenter FROM business_center WHERE ID = profile_corporation.BusinessID) AS 'Business Center', IF(`status` = 'BLOCKED',Branch(BlockedBranchID),'') AS 'Blocked By'"
            SQL &= " FROM profile_corporation "
            If cbxAdvanced.Checked Then
                SQL &= "    WHERE TRUE"
            Else
                SQL &= String.Format("    WHERE Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            End If
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(timestamp) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            If cbxAdvanced.Checked Then
                If FrmAdvancedSearch.txtKeyword.Text.Trim = "" Then
                Else
                    If KeywordSearchWildcard Then
                        Dim Words As String() = FrmAdvancedSearch.txtKeyword.Text.Trim.Split(New Char() {" "c})
                        Dim Key As String
                        For Each Key In Words
                            SQL &= String.Format(" AND (`TradeName` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Telephone` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Email` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Fax` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Website` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Incorporation` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `YearsOperation` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Employees` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirmSize` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Gross` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Net` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Birthdate_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `GMI_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Position_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Contact_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Years_R1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Birthdate_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `GMI_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Position_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Contact_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Years_R2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Birthdate_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `GMI_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Position_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Contact_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Years_R3` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Birthdate_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `GMI_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Position_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Contact_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Years_R4` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Prefix_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `FirstN_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MiddleN_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `LastN_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Suffix_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Birthdate_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `TIN_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SSS_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `GMI_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `No_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Street_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Barangay_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Address_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Position_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Contact_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Years_R5` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Bank_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AccountT_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SA_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AverageBalance_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PresentBalance_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Opened_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BankRemarks_1` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Bank_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AccountT_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `SA_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AverageBalance_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `PresentBalance_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Opened_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `BankRemarks_2` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Agent` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `AgentNo` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Marketing` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `MarketingNo` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WalkIn` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `WalkIn_Specify` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `Dealer` LIKE '%{0}%' OR", Key)
                            SQL &= String.Format(" `DealerNo` LIKE '%{0}%')", Key)
                        Next
                    Else
                        Dim Key As String = FrmAdvancedSearch.txtKeyword.Text
                        SQL &= String.Format(" AND (`TradeName` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Telephone` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Email` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Fax` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Website` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Incorporation` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `YearsOperation` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Employees` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirmSize` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Gross` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Net` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Prefix_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirstN_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MiddleN_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `LastN_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Suffix_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Birthdate_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `GMI_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Position_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Contact_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Years_R1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Prefix_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirstN_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MiddleN_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `LastN_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Suffix_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Birthdate_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `GMI_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Position_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Contact_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Years_R2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Prefix_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirstN_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MiddleN_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `LastN_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Suffix_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Birthdate_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `GMI_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Position_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Contact_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Years_R3` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Prefix_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirstN_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MiddleN_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `LastN_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Suffix_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Birthdate_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `GMI_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Position_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Contact_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Years_R4` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Prefix_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `FirstN_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MiddleN_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `LastN_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Suffix_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Birthdate_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `TIN_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SSS_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `GMI_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `No_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Street_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Barangay_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Address_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Position_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Contact_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Years_R5` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Bank_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `AccountT_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SA_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `AverageBalance_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `PresentBalance_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Opened_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `BankRemarks_1` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Bank_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `AccountT_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `SA_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `AverageBalance_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `PresentBalance_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Opened_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `BankRemarks_2` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Agent` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `AgentNo` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Marketing` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `MarketingNo` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `WalkIn` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `WalkIn_Specify` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `Dealer` LIKE '%{0}%' OR", Key)
                        SQL &= String.Format(" `DealerNo` LIKE '%{0}%')", Key)
                    End If
                End If
                With FrmAdvancedSearch
                    If .cbxMicro.Checked And .cbxSmall.Checked And .cbxMedium.Checked And .cbxLarge.Checked Then
                    ElseIf .cbxMicro.Checked = False And .cbxSmall.Checked = False And .cbxMedium.Checked = False And .cbxLarge.Checked = False Then
                    Else
                        SQL &= " AND ("
                        If .cbxMicro.Checked Then
                            SQL &= " `FirmSize` = 'Micro'"
                            If .cbxSmall.Checked Or .cbxMedium.Checked Or .cbxLarge.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxSmall.Checked Then
                            SQL &= " `FirmSize` = 'Small'"
                            If .cbxMedium.Checked Or .cbxLarge.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxMedium.Checked Then
                            SQL &= " `FirmSize` = 'Medium'"
                            If .cbxLarge.Checked Then
                                SQL &= " OR "
                            End If
                        End If
                        If .cbxLarge.Checked Then
                            SQL &= " `FirmSize` = 'Large'"
                        End If
                        SQL &= ") "
                    End If
                End With
            End If
            SQL &= String.Format("    AND `status` IN ('ACTIVE','{0}') ORDER BY `Trade Name` ASC;", If(cbxBlocked.Checked, "BLOCKED", ""))
            GridControl2.DataSource = DataSource(SQL)
            If cbxBlocked.Checked Then
                GridColumn27.Visible = True
            Else
                GridColumn27.Visible = False
            End If
            GridView2.Columns("Trade Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView2.Columns("Trade Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cbxAdvanced.Checked Then
            With FrmAdvancedSearch
                If SuperTabControl1.SelectedTabIndex = 0 Then
                    .lblFirm.Visible = False
                    .cbxMicro.Visible = False
                    .cbxSmall.Visible = False
                    .cbxMedium.Visible = False
                    .cbxLarge.Visible = False

                    .lblAge.Visible = True
                    .iFrom.Visible = True
                    .lblTo.Visible = True
                    .iTo.Visible = True

                    .lblGender.Visible = True
                    .cbxMale_B.Visible = True
                    .cbxFemale_B.Visible = True

                    .lblCivil.Visible = True
                    .cbxSingle_B.Visible = True
                    .cbxMarried_B.Visible = True
                    .cbxSeparated_B.Visible = True
                    .cbxWidowed_B.Visible = True
                ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                    .lblFirm.Visible = True
                    .cbxMicro.Visible = True
                    .cbxSmall.Visible = True
                    .cbxMedium.Visible = True
                    .cbxLarge.Visible = True

                    .lblAge.Visible = False
                    .iFrom.Visible = False
                    .lblTo.Visible = False
                    .iTo.Visible = False

                    .lblGender.Visible = False
                    .cbxMale_B.Visible = False
                    .cbxFemale_B.Visible = False

                    .lblCivil.Visible = False
                    .cbxSingle_B.Visible = False
                    .cbxMarried_B.Visible = False
                    .cbxSeparated_B.Visible = False
                    .cbxWidowed_B.Visible = False
                End If
                .ShowDialog()
            End With
        Else
            LoadData()
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
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("INDIVIDUAL BORROWER LIST", GridControl1)
            Logs("Borrowers List", "Print", "[SENSITIVE] Print Borrower List", "", "", "", "")
        Else
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CORPORATE BORROWER LIST", GridControl2)
            Logs("Borrowers List", "Print", "[SENSITIVE] Print Corporate Borrower List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Borrowers ID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Cursor = Cursors.WaitCursor
        With FrmBorrower
            .Tag = 15
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If Show_Dialog Then
                Forms(FrmBorrower, FrmMain.PanelControl3)
            Else
                .ControlBox = True
                .WindowState = FormWindowState.Normal
                .MinimizeBox = True
                .MaximizeBox = True
                .Show()
                .BringToFront()
                SendToBack()
            End If

            .Clear()
            Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_borrower.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_borrower.BusinessID)) AS 'BusinessCenter' FROM profile_borrower WHERE BorrowerID = '{0}'", GridView1.GetFocusedRowCellValue("Borrowers ID")))
            If BorrowerP.Rows.Count > 0 Then
                .PanelEx2.Enabled = False
                .PanelEx4.Enabled = False
                .PanelEx11.Enabled = False
                .PanelEx12.Enabled = False
                .PanelEx13.Enabled = False
                .PanelEx14.Enabled = False
                .PanelEx5.Enabled = False
                .PanelEx8.Enabled = False
                .cbxMale_S.Tag = ""
                .cbxFemale_S.Tag = ""
                .cbxOwned_S.Tag = ""
                .cbxFree_S.Tag = ""
                .cbxRented_S.Tag = ""
                .cbxCasual_S.Tag = ""
                .cbxTemporary_S.Tag = ""
                .cbxPermanent_S.Tag = ""
                .btnExisting_B.Enabled = False
                .ID = GridView1.GetFocusedRowCellValue("ID")
                .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
                .btnAttach.Enabled = True
                .txtBorrowerID.Text = GridView1.GetFocusedRowCellValue("Borrowers ID")
                .txtBorrowerID.Tag = GridView1.GetFocusedRowCellValue("Borrowers ID")
                .CbxPrefix_B.Text = BorrowerP(0)("Prefix_B")
                .CbxPrefix_B.Tag = BorrowerP(0)("Prefix_B")
                .TxtFirstN_B.Text = BorrowerP(0)("FirstN_B")
                .TxtFirstN_B.Tag = BorrowerP(0)("FirstN_B")
                .TxtMiddleN_B.Text = BorrowerP(0)("MiddleN_B")
                .TxtMiddleN_B.Tag = BorrowerP(0)("MiddleN_B")
                .TxtLastN_B.Text = BorrowerP(0)("LastN_B")
                .TxtLastN_B.Tag = BorrowerP(0)("LastN_B")
                .cbxSuffix_B.Text = BorrowerP(0)("Suffix_B")
                .cbxSuffix_B.Tag = BorrowerP(0)("Suffix_B")
                .txtNoC_B.Text = BorrowerP(0)("NoC_B")
                .txtNoC_B.Tag = BorrowerP(0)("NoC_B")
                .txtStreetC_B.Text = BorrowerP(0)("StreetC_B")
                .txtStreetC_B.Tag = BorrowerP(0)("StreetC_B")
                .txtBarangayC_B.Text = BorrowerP(0)("BarangayC_B")
                .txtBarangayC_B.Tag = BorrowerP(0)("BarangayC_B")
                .cbxAddressC_B.Text = BorrowerP(0)("AddressC_B")
                .cbxAddressC_B.Tag = BorrowerP(0)("AddressC_B")
                .txtNoP_B.Text = BorrowerP(0)("NoP_B")
                .txtNoP_B.Tag = BorrowerP(0)("NoP_B")
                .txtStreetP_B.Text = BorrowerP(0)("StreetP_B")
                .txtStreetP_B.Tag = BorrowerP(0)("StreetP_B")
                .txtBarangayP_B.Text = BorrowerP(0)("BarangayP_B")
                .txtBarangayP_B.Tag = BorrowerP(0)("BarangayP_B")
                .cbxAddressP_B.Text = BorrowerP(0)("AddressP_B")
                .cbxAddressP_B.Tag = BorrowerP(0)("AddressP_B")
                If BorrowerP(0)("Birth_B") = "0001-01-01" Or BorrowerP(0)("Birth_B") = "" Then
                    .DtpBirth_B.CustomFormat = ""
                    .DtpBirth_B.Tag = ""
                Else
                    .DtpBirth_B.CustomFormat = "MMMM dd, yyyy"
                    .DtpBirth_B.Text = BorrowerP(0)("Birth_B")
                    .DtpBirth_B.Tag = BorrowerP(0)("Birth_B")
                End If
                .cbxPlaceBirth_B.Text = BorrowerP(0)("PlaceBirth_B")
                .cbxPlaceBirth_B.Tag = BorrowerP(0)("PlaceBirth_B")
                If BorrowerP(0)("Gender_B") = "Male" Then
                    .cbxMale_B.Checked = True
                ElseIf BorrowerP(0)("Gender_B") = "Female" Then
                    .cbxFemale_B.Checked = True
                End If
                .cbxMale_B.Tag = BorrowerP(0)("Gender_B")
                .cbxFemale_B.Tag = BorrowerP(0)("Gender_B")
                If BorrowerP(0)("Civil_B") = "Single" Then
                    .cbxSingle_B.Checked = True
                ElseIf BorrowerP(0)("Civil_B") = "Married" Then
                    .cbxMarried_B.Checked = True
                ElseIf BorrowerP(0)("Civil_B") = "Separated" Then
                    .cbxSeparated_B.Checked = True
                ElseIf BorrowerP(0)("Civil_B") = "Widowed" Then
                    .cbxWidowed_B.Checked = True
                End If
                .cbxSingle_B.Tag = BorrowerP(0)("Civil_B")
                .cbxMarried_B.Tag = BorrowerP(0)("Civil_B")
                .cbxSeparated_B.Tag = BorrowerP(0)("Civil_B")
                .cbxWidowed_B.Tag = BorrowerP(0)("Civil_B")
                .cbxCitizenship_B.Text = BorrowerP(0)("Citizenship_B")
                .cbxCitizenship_B.Tag = BorrowerP(0)("Citizenship_B")
                .txtTIN_B.Text = BorrowerP(0)("TIN_B")
                .txtTIN_B.Tag = BorrowerP(0)("TIN_B")
                If GridView1.GetFocusedRowCellValue("Telephone No.").ToString.Contains("***") Or GridView1.GetFocusedRowCellValue("Mobile No.").ToString.Contains("***") Then
                Else
                    .txtTelephone_B.Text = BorrowerP(0)("Telephone_B")
                    .txtTelephone_B.Tag = BorrowerP(0)("Telephone_B")
                    .txtMobile_B.Text = BorrowerP(0)("Mobile_B")
                    .txtMobile_B.Tag = BorrowerP(0)("Mobile_B")
                    .txtMobile_B2.Text = BorrowerP(0)("Mobile_B2")
                    .txtMobile_B2.Tag = BorrowerP(0)("Mobile_B2")

                    .cbxAgent.Tag = If(BorrowerP(0)("Agent") = "", "No", "Yes")
                    .cbxAgent.Checked = If(BorrowerP(0)("Agent") = "", False, True)
                    .cbxAgentName.Text = BorrowerP(0)("Agent")
                    .cbxAgentName.Tag = BorrowerP(0)("Agent")
                    .txtAgentContact.Text = BorrowerP(0)("AgentNo")
                    .txtAgentContact.Tag = BorrowerP(0)("AgentNo")
                End If
                .txtSSS_B.Text = BorrowerP(0)("SSS_B")
                .txtSSS_B.Tag = BorrowerP(0)("SSS_B")
                .txtEmail_B.Text = BorrowerP(0)("Email_B")
                .txtEmail_B.Tag = BorrowerP(0)("Email_B")
                If BorrowerP(0)("House_B") = "Owned" Then
                    .cbxOwned_B.Checked = True
                ElseIf BorrowerP(0)("House_B") = "Free" Then
                    .cbxFree_B.Checked = True
                ElseIf BorrowerP(0)("House_B") = "Rented" Then
                    .cbxRented_B.Checked = True
                    .dRent_B.Value = BorrowerP(0)("Rent_B")
                End If
                .cbxOwned_B.Tag = BorrowerP(0)("House_B")
                .cbxFree_B.Tag = BorrowerP(0)("House_B")
                .cbxRented_B.Tag = BorrowerP(0)("House_B")
                .dRent_B.Tag = BorrowerP(0)("Rent_B")
                Try
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), GridView1.GetFocusedRowCellValue("Borrowers ID"), "Borrower.jpg"))
                        ResizeImages(TempPB.Image.Clone, .pb_B, 650, 500)
                    End Using
                Catch ex As Exception
                End Try
                .cbxEmployer_B.Text = BorrowerP(0)("Employer_B")
                .cbxEmployer_B.Tag = BorrowerP(0)("Employer_B")
                .txtEmployerAddress_B.Text = BorrowerP(0)("EmployerAddress_B")
                .txtEmployerAddress_B.Tag = BorrowerP(0)("EmployerAddress_B")
                .txtEmployerTelephone_B.Text = BorrowerP(0)("EmployerTelephone_B")
                .txtEmployerTelephone_B.Tag = BorrowerP(0)("EmployerTelephone_B")
                .cbxPosition_B.Text = BorrowerP(0)("Position_B")
                .cbxPosition_B.Tag = BorrowerP(0)("Position_B")
                If BorrowerP(0)("EmploymentStat_B") = "Casual" Then
                    .cbxCasual_B.Checked = True
                ElseIf BorrowerP(0)("EmploymentStat_B") = "Temporary" Then
                    .cbxTemporary_B.Checked = True
                ElseIf BorrowerP(0)("EmploymentStat_B") = "Permanent" Then
                    .cbxPermanent_B.Checked = True
                End If
                .cbxCasual_B.Tag = BorrowerP(0)("EmploymentStat_B")
                .cbxTemporary_B.Tag = BorrowerP(0)("EmploymentStat_B")
                .cbxPermanent_B.Tag = BorrowerP(0)("EmploymentStat_B")
                .dtpHired_B.Text = BorrowerP(0)("Hired_B")
                .dtpHired_B.Tag = BorrowerP(0)("Hired_B")
                .txtSupervisor_B.Text = BorrowerP(0)("Supervisor_B")
                .txtSupervisor_B.Tag = BorrowerP(0)("Supervisor_B")
                .dMonthly_B.Value = BorrowerP(0)("Monthly_B")
                .dMonthly_B.Tag = BorrowerP(0)("Monthly_B")
                .txtBusinessName_B.Text = BorrowerP(0)("BusinessName_B")
                .FirstLoad = True
                .txtBusinessName_B.Tag = BorrowerP(0)("BusinessName_B")
                .txtBusinessAddress_B.Text = BorrowerP(0)("BusinessAddress_B")
                .txtBusinessAddress_B.Tag = BorrowerP(0)("BusinessAddress_B")
                .txtBusinessTelephone_B.Text = BorrowerP(0)("BusinessTelephone_B")
                .txtBusinessTelephone_B.Tag = BorrowerP(0)("BusinessTelephone_B")
                .cbxNatureBusiness_B.Text = BorrowerP(0)("NatureBusiness_B")
                .cbxNatureBusiness_B.Tag = BorrowerP(0)("NatureBusiness_B")

                .cbxNatureBusiness_B2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Borrower'", GridView1.GetFocusedRowCellValue("Borrowers ID"))))

                .iYrsOperation_B.Value = BorrowerP(0)("YrsOperation_B")
                .iYrsOperation_B.Tag = BorrowerP(0)("YrsOperation_B")
                .dBusinessIncome_B.Value = BorrowerP(0)("BusinessIncome_B")
                .dBusinessIncome_B.Tag = BorrowerP(0)("BusinessIncome_B")
                .iNoEmployees_B.Value = BorrowerP(0)("NoEmployees_B")
                .iNoEmployees_B.Tag = BorrowerP(0)("NoEmployees_B")
                .dCapital_B.Value = BorrowerP(0)("Capital_B")
                .dCapital_B.Tag = BorrowerP(0)("Capital_B")
                .txtArea_B.Text = BorrowerP(0)("Area_B")
                .txtArea_B.Tag = BorrowerP(0)("Area_B")
                .dtpExpiry_B.Text = BorrowerP(0)("Expiry_B")
                .dtpExpiry_B.Tag = BorrowerP(0)("Expiry_B")
                .iOutlet_B.Value = BorrowerP(0)("Outlet_B")
                .iOutlet_B.Tag = BorrowerP(0)("Outlet_B")
                .txtOtherIncome_B.Text = BorrowerP(0)("OtherIncome_B")
                .txtOtherIncome_B.Tag = BorrowerP(0)("OtherIncome_B")
                .dOtherIncome_B.Value = BorrowerP(0)("OtherIncome_B-Amount")
                .dOtherIncome_B.Tag = BorrowerP(0)("OtherIncome_B-Amount")
                .FirstLoad = False

                .txtCreditor_1.Text = BorrowerP(0)("Creditor_1")
                .txtCreditor_1.Tag = BorrowerP(0)("Creditor_1")
                .txtNatureLoan_1.Text = BorrowerP(0)("NatureLoan_1")
                .txtNatureLoan_1.Tag = BorrowerP(0)("NatureLoan_1")
                .dAmountGranted_1.Value = BorrowerP(0)("AmountGranted_1")
                .dAmountGranted_1.Tag = BorrowerP(0)("AmountGranted_1")
                .dTerm_1.Value = BorrowerP(0)("Term_1")
                .dTerm_1.Tag = BorrowerP(0)("Term_1")
                .dBalance_1.Value = BorrowerP(0)("Balance_1")
                .dBalance_1.Tag = BorrowerP(0)("Balance_1")
                .txtCreditRemarks_1.Text = BorrowerP(0)("CreditRemarks_1")
                .txtCreditRemarks_1.Tag = BorrowerP(0)("CreditRemarks_1")
                .txtCreditor_2.Text = BorrowerP(0)("Creditor_2")
                .txtCreditor_2.Tag = BorrowerP(0)("Creditor_2")
                .txtNatureLoan_2.Text = BorrowerP(0)("NatureLoan_2")
                .txtNatureLoan_2.Tag = BorrowerP(0)("NatureLoan_2")
                .dAmountGranted_2.Value = BorrowerP(0)("AmountGranted_2")
                .dAmountGranted_2.Tag = BorrowerP(0)("AmountGranted_2")
                .dTerm_2.Value = BorrowerP(0)("Term_2")
                .dTerm_2.Tag = BorrowerP(0)("Term_2")
                .dBalance_2.Value = BorrowerP(0)("Balance_2")
                .dBalance_2.Tag = BorrowerP(0)("Balance_2")
                .txtCreditRemarks_2.Text = BorrowerP(0)("CreditRemarks_2")
                .txtCreditRemarks_2.Tag = BorrowerP(0)("CreditRemarks_2")
                .txtCreditor_3.Text = BorrowerP(0)("Creditor_3")
                .txtCreditor_3.Tag = BorrowerP(0)("Creditor_3")
                .txtNatureLoan_3.Text = BorrowerP(0)("NatureLoan_3")
                .txtNatureLoan_3.Tag = BorrowerP(0)("NatureLoan_3")
                .dAmountGranted_3.Value = BorrowerP(0)("AmountGranted_3")
                .dAmountGranted_3.Tag = BorrowerP(0)("AmountGranted_3")
                .dTerm_3.Value = BorrowerP(0)("Term_3")
                .dTerm_3.Tag = BorrowerP(0)("Term_3")
                .dBalance_3.Value = BorrowerP(0)("Balance_3")
                .dBalance_3.Tag = BorrowerP(0)("Balance_3")
                .txtCreditRemarks_3.Text = BorrowerP(0)("CreditRemarks_3")
                .txtCreditRemarks_3.Tag = BorrowerP(0)("CreditRemarks_3")
                .txtBank_1.Text = BorrowerP(0)("Bank_1")
                .txtBank_1.Tag = BorrowerP(0)("Bank_1")
                .txtBranch_1.Text = BorrowerP(0)("Branch_1")
                .txtBranch_1.Tag = BorrowerP(0)("Branch_1")
                If BorrowerP(0)("AccountT_1") = "SA" Then
                    .cbxSA_1.Checked = True
                ElseIf BorrowerP(0)("AccountT_1") = "CA" Then
                    .cbxCA_1.Checked = True
                End If
                .cbxSA_1.Tag = BorrowerP(0)("AccountT_1")
                .cbxCA_1.Tag = BorrowerP(0)("AccountT_1")
                .txtSA_1.Text = BorrowerP(0)("SA_1")
                .txtSA_1.Tag = BorrowerP(0)("SA_1")
                .dAverageBalance_1.Value = BorrowerP(0)("AverageBalance_1")
                .dAverageBalance_1.Tag = BorrowerP(0)("AverageBalance_1")
                .dPresentBalance_1.Value = BorrowerP(0)("PresentBalance_1")
                .dPresentBalance_1.Tag = BorrowerP(0)("PresentBalance_1")
                .txtOpened_1.Text = BorrowerP(0)("Opened_1")
                .txtOpened_1.Tag = BorrowerP(0)("Opened_1")
                .txtBankRemarks_1.Text = BorrowerP(0)("BankRemarks_1")
                .txtBankRemarks_1.Tag = BorrowerP(0)("BankRemarks_1")
                .txtBank_2.Text = BorrowerP(0)("Bank_2")
                .txtBank_2.Tag = BorrowerP(0)("Bank_2")
                .txtBranch_2.Text = BorrowerP(0)("Branch_2")
                .txtBranch_2.Tag = BorrowerP(0)("Branch_2")
                If BorrowerP(0)("AccountT_2") = "SA" Then
                    .cbxSA_2.Checked = True
                ElseIf BorrowerP(0)("AccountT_2") = "CA" Then
                    .cbxCA_2.Checked = True
                End If
                .cbxSA_2.Tag = BorrowerP(0)("AccountT_2")
                .cbxCA_2.Tag = BorrowerP(0)("AccountT_2")
                .txtSA_2.Text = BorrowerP(0)("SA_2")
                .txtSA_2.Tag = BorrowerP(0)("SA_2")
                .dAverageBalance_2.Value = BorrowerP(0)("AverageBalance_2")
                .dAverageBalance_2.Tag = BorrowerP(0)("AverageBalance_2")
                .dPresentBalance_2.Value = BorrowerP(0)("PresentBalance_2")
                .dPresentBalance_2.Tag = BorrowerP(0)("PresentBalance_2")
                .txtOpened_2.Text = BorrowerP(0)("Opened_2")
                .txtOpened_2.Tag = BorrowerP(0)("Opened_2")
                .txtBankRemarks_2.Text = BorrowerP(0)("BankRemarks_2")
                .txtBankRemarks_2.Tag = BorrowerP(0)("BankRemarks_2")
                .txtBank_3.Text = BorrowerP(0)("Bank_3")
                .txtBank_3.Tag = BorrowerP(0)("Bank_3")
                .txtBranch_3.Text = BorrowerP(0)("Branch_3")
                .txtBranch_3.Tag = BorrowerP(0)("Branch_3")
                If BorrowerP(0)("AccountT_3") = "SA" Then
                    .cbxSA_3.Checked = True
                ElseIf BorrowerP(0)("AccountT_3") = "CA" Then
                    .cbxCA_3.Checked = True
                End If
                .cbxSA_3.Tag = BorrowerP(0)("AccountT_3")
                .cbxCA_3.Tag = BorrowerP(0)("AccountT_3")
                .txtSA_3.Text = BorrowerP(0)("SA_3")
                .txtSA_3.Tag = BorrowerP(0)("SA_3")
                .dAverageBalance_3.Value = BorrowerP(0)("AverageBalance_3")
                .dAverageBalance_3.Tag = BorrowerP(0)("AverageBalance_3")
                .dPresentBalance_3.Value = BorrowerP(0)("PresentBalance_3")
                .dPresentBalance_3.Tag = BorrowerP(0)("PresentBalance_3")
                .txtOpened_3.Text = BorrowerP(0)("Opened_3")
                .txtOpened_3.Tag = BorrowerP(0)("Opened_3")
                .txtBankRemarks_3.Text = BorrowerP(0)("BankRemarks_3")
                .txtBankRemarks_3.Tag = BorrowerP(0)("BankRemarks_3")
                .txtLocation_1.Text = BorrowerP(0)("Location_1")
                .txtLocation_1.Tag = BorrowerP(0)("Location_1")
                .txtTCT_1.Text = BorrowerP(0)("TCT_1")
                .txtTCT_1.Tag = BorrowerP(0)("TCT_1")
                .dArea_1.Value = BorrowerP(0)("Area_1")
                .dArea_1.Tag = BorrowerP(0)("Area_1")
                .txtAcquired_1.Text = BorrowerP(0)("Acquired_1")
                .txtAcquired_1.Tag = BorrowerP(0)("Acquired_1")
                .txtPropertiesRemarks_1.Text = BorrowerP(0)("PropertiesRemarks_1")
                .txtPropertiesRemarks_1.Tag = BorrowerP(0)("PropertiesRemarks_1")
                .txtLocation_2.Text = BorrowerP(0)("Location_2")
                .txtLocation_2.Tag = BorrowerP(0)("Location_2")
                .txtTCT_2.Text = BorrowerP(0)("TCT_2")
                .txtTCT_2.Tag = BorrowerP(0)("TCT_2")
                .dArea_2.Value = BorrowerP(0)("Area_2")
                .dArea_2.Tag = BorrowerP(0)("Area_2")
                .txtAcquired_2.Text = BorrowerP(0)("Acquired_2")
                .txtAcquired_2.Tag = BorrowerP(0)("Acquired_2")
                .txtPropertiesRemarks_2.Text = BorrowerP(0)("PropertiesRemarks_2")
                .txtPropertiesRemarks_2.Tag = BorrowerP(0)("PropertiesRemarks_2")
                .txtLocation_3.Text = BorrowerP(0)("Location_3")
                .txtLocation_3.Tag = BorrowerP(0)("Location_3")
                .txtTCT_3.Text = BorrowerP(0)("TCT_3")
                .txtTCT_3.Tag = BorrowerP(0)("TCT_3")
                .dArea_3.Value = BorrowerP(0)("Area_3")
                .dArea_3.Tag = BorrowerP(0)("Area_3")
                .txtAcquired_3.Text = BorrowerP(0)("Acquired_3")
                .txtAcquired_3.Tag = BorrowerP(0)("Acquired_3")
                .txtPropertiesRemarks_3.Text = BorrowerP(0)("PropertiesRemarks_3")
                .txtPropertiesRemarks_3.Tag = BorrowerP(0)("PropertiesRemarks_3")
                .txtVehicle_1.Text = BorrowerP(0)("Vehicle_1")
                .txtVehicle_1.Tag = BorrowerP(0)("Vehicle_1")
                .dtpYear_1.Text = BorrowerP(0)("Year_1")
                .dtpYear_1.Tag = BorrowerP(0)("Year_1")
                .txtWhomAcquired_1.Text = BorrowerP(0)("WhomAcquired_1")
                .txtWhomAcquired_1.Tag = BorrowerP(0)("WhomAcquired_1")
                .txtWhenAcquired_1.Text = BorrowerP(0)("WhenAcquired_1")
                .txtWhenAcquired_1.Tag = BorrowerP(0)("WhenAcquired_1")
                .txtVehicleRemarks_1.Text = BorrowerP(0)("VehicleRemarks_1")
                .txtVehicleRemarks_1.Tag = BorrowerP(0)("VehicleRemarks_1")
                .txtVehicle_2.Text = BorrowerP(0)("Vehicle_2")
                .txtVehicle_2.Tag = BorrowerP(0)("Vehicle_2")
                .dtpYear_2.Text = BorrowerP(0)("Year_2")
                .dtpYear_2.Tag = BorrowerP(0)("Year_2")
                .txtWhomAcquired_2.Text = BorrowerP(0)("WhomAcquired_2")
                .txtWhomAcquired_2.Tag = BorrowerP(0)("WhomAcquired_2")
                .txtWhenAcquired_2.Text = BorrowerP(0)("WhenAcquired_2")
                .txtWhenAcquired_2.Tag = BorrowerP(0)("WhenAcquired_2")
                .txtVehicleRemarks_2.Text = BorrowerP(0)("VehicleRemarks_2")
                .txtVehicleRemarks_2.Tag = BorrowerP(0)("VehicleRemarks_2")
                .txtVehicle_3.Text = BorrowerP(0)("Vehicle_3")
                .txtVehicle_3.Tag = BorrowerP(0)("Vehicle_3")
                .dtpYear_3.Text = BorrowerP(0)("Year_3")
                .dtpYear_3.Tag = BorrowerP(0)("Year_3")
                .txtWhomAcquired_3.Text = BorrowerP(0)("WhomAcquired_3")
                .txtWhomAcquired_3.Tag = BorrowerP(0)("WhomAcquired_3")
                .txtWhenAcquired_3.Text = BorrowerP(0)("WhenAcquired_3")
                .txtWhenAcquired_3.Tag = BorrowerP(0)("WhenAcquired_3")
                .txtVehicleRemarks_3.Text = BorrowerP(0)("VehicleRemarks_3")
                .txtVehicleRemarks_3.Tag = BorrowerP(0)("VehicleRemarks_3")
                .txtHomeAppliances_1.Text = BorrowerP(0)("HomeAppliances_1")
                .txtHomeAppliances_1.Tag = BorrowerP(0)("HomeAppliances_1")
                .txtHomeAppliances_2.Text = BorrowerP(0)("HomeAppliances_2")
                .txtHomeAppliances_2.Tag = BorrowerP(0)("HomeAppliances_2")
                .txtReference_1.Text = BorrowerP(0)("Reference_1")
                .txtReference_1.Tag = BorrowerP(0)("Reference_1")
                .txtReferenceAddress_1.Text = BorrowerP(0)("ReferenceAddress_1")
                .txtReferenceAddress_1.Tag = BorrowerP(0)("ReferenceAddress_1")
                .txtReferenceContact_1.Text = BorrowerP(0)("ReferenceContact_1")
                .txtReferenceContact_1.Tag = BorrowerP(0)("ReferenceContact_1")
                .txtReference_2.Text = BorrowerP(0)("Reference_2")
                .txtReference_2.Tag = BorrowerP(0)("Reference_2")
                .txtReferenceAddress_2.Text = BorrowerP(0)("ReferenceAddress_2")
                .txtReferenceAddress_2.Tag = BorrowerP(0)("ReferenceAddress_2")
                .txtReferenceContact_2.Text = BorrowerP(0)("ReferenceContact_2")
                .txtReferenceContact_2.Tag = BorrowerP(0)("ReferenceContact_2")
                .txtReference_3.Text = BorrowerP(0)("Reference_3")
                .txtReference_3.Tag = BorrowerP(0)("Reference_3")
                .txtReferenceAddress_3.Text = BorrowerP(0)("ReferenceAddress_3")
                .txtReferenceAddress_3.Tag = BorrowerP(0)("ReferenceAddress_3")
                .txtReferenceContact_3.Text = BorrowerP(0)("ReferenceContact_3")
                .txtReferenceContact_3.Tag = BorrowerP(0)("ReferenceContact_3")
                .txtCertificateNo.Text = BorrowerP(0)("CertificateNo")
                .txtCertificateNo.Tag = BorrowerP(0)("CertificateNo")
                .txtPlaceIssue.Text = BorrowerP(0)("PlaceIssue")
                .txtPlaceIssue.Tag = BorrowerP(0)("PlaceIssue")
                .dtpIssue.Text = BorrowerP(0)("Issue")
                .dtpIssue.Tag = BorrowerP(0)("Issue")
                .cbxMarketing.Checked = If(BorrowerP(0)("Marketing") = "", False, True)
                .cbxMarketing.Tag = If(BorrowerP(0)("Marketing") = "", "No", "Yes")
                .cbxMarketingName.Text = BorrowerP(0)("Marketing")
                .cbxMarketingName.Tag = BorrowerP(0)("Marketing")
                .txtMarketingContact.Text = BorrowerP(0)("MarketingNo")
                .txtMarketingContact.Tag = BorrowerP(0)("MarketingNo")
                .cbxWalkIn.Checked = If(BorrowerP(0)("WalkIn") = "", False, True)
                .cbxWalkIn.Tag = If(BorrowerP(0)("WalkIn") = "", "No", "Yes")
                .cbxWalkInType.Text = BorrowerP(0)("WalkIn")
                .cbxWalkInType.Tag = BorrowerP(0)("WalkIn")
                .txtWalkInOthers.Text = BorrowerP(0)("WalkIn_Specify")
                .txtWalkInOthers.Tag = BorrowerP(0)("WalkIn_Specify")
                .cbxDealer.Checked = If(BorrowerP(0)("Dealer") = "", False, True)
                .cbxDealer.Tag = If(BorrowerP(0)("Dealer") = "", "No", "Yes")
                .cbxDealerName.Text = BorrowerP(0)("Dealer")
                .cbxDealerName.Tag = BorrowerP(0)("Dealer")
                .txtDealersContact.Text = BorrowerP(0)("DealerNo")
                .txtDealersContact.Tag = BorrowerP(0)("DealerNo")
                .cbxBusinessCenter.Text = BorrowerP(0)("BusinessCenter")
                .cbxBusinessCenter.Tag = BorrowerP(0)("BusinessCenter")
                .cbxYearHired.Checked = BorrowerP(0)("YearHired")
                .cbxYearFranchise.Checked = BorrowerP(0)("YearFranchise")
                '*** I D E N T I F I C A T I O N ***
                Dim BorrowerID As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'B'", GridView1.GetFocusedRowCellValue("Borrowers ID")))
                If BorrowerID.Rows.Count > 0 Then
                    .GSIS = BorrowerID(0)("GSIS")
                    .PhilHealth = BorrowerID(0)("PhilHealth")
                    .Senior = BorrowerID(0)("Senior")
                    .UMID = BorrowerID(0)("UMID")
                    .SEC = BorrowerID(0)("SEC")
                    .DTI = BorrowerID(0)("DTI")
                    .CDA = BorrowerID(0)("CDA")
                    .Cooperative = BorrowerID(0)("Cooperative")
                    .Drivers = BorrowerID(0)("Drivers")
                    .dDrivers = BorrowerID(0)("dDrivers")
                    .VIN = BorrowerID(0)("VIN")
                    .dVIN = BorrowerID(0)("dVIN")
                    .Passport = BorrowerID(0)("Passport")
                    .dPassport = BorrowerID(0)("dPassport")
                    .PRC = BorrowerID(0)("PRC")
                    .dPRC = BorrowerID(0)("dPRC")
                    .NBI = BorrowerID(0)("NBI")
                    .dNBI = BorrowerID(0)("dNBI")
                    .Police = BorrowerID(0)("Police")
                    .dPolice = BorrowerID(0)("dPolice")
                    .Postal = BorrowerID(0)("Postal")
                    .dPostal = BorrowerID(0)("dPostal")
                    .Barangay = BorrowerID(0)("Barangay")
                    .dBarangay = BorrowerID(0)("dBarangay")
                    .OWWA = BorrowerID(0)("OWWA")
                    .dOWWA = BorrowerID(0)("dOWWA")
                    .OFW = BorrowerID(0)("OFW")
                    .dOFW = BorrowerID(0)("dOFW")
                    .Seaman = BorrowerID(0)("Seaman")
                    .dSeaman = BorrowerID(0)("dSeaman")
                    .PNP = BorrowerID(0)("PNP")
                    .dPNP = BorrowerID(0)("dPNP")
                    .AFP = BorrowerID(0)("AFP")
                    .dAFP = BorrowerID(0)("dAFP")
                    .HDMF = BorrowerID(0)("HDMF")
                    .dHDMF = BorrowerID(0)("dHDMF")
                    .PWD = BorrowerID(0)("PWD")
                    .dPWD = BorrowerID(0)("dPWD")
                    .DSWD = BorrowerID(0)("DSWD")
                    .dDSWD = BorrowerID(0)("dDSWD")
                    .ACR = BorrowerID(0)("ACR")
                    .dACR = BorrowerID(0)("dACR")
                    .DTI_Business = BorrowerID(0)("DTI_Business")
                    .dDTI_Business = BorrowerID(0)("dDTI_Business")
                    .IBP = BorrowerID(0)("IBP")
                    .dIBP = BorrowerID(0)("dIBP")
                    .FireArms = BorrowerID(0)("FireArms")
                    .dFireArms = BorrowerID(0)("dFireArms")
                    .Government = BorrowerID(0)("Government")
                    .dGovernment = BorrowerID(0)("dGovernment")
                    .Diplomat = BorrowerID(0)("Diplomat")
                    .dDiplomat = BorrowerID(0)("dDiplomat")
                    .National = BorrowerID(0)("National")
                    .dNational = BorrowerID(0)("dNational")
                    .Work = BorrowerID(0)("Work")
                    .dWork = BorrowerID(0)("dWork")
                    .GOCC = BorrowerID(0)("GOCC")
                    .dGOCC = BorrowerID(0)("dGOCC")
                    .PLRA = BorrowerID(0)("PLRA")
                    .dPLRA = BorrowerID(0)("dPLRA")
                    .Major = BorrowerID(0)("Major")
                    .dMajor = BorrowerID(0)("dMajor")
                    .Media = BorrowerID(0)("Media")
                    .dMedia = BorrowerID(0)("dMedia")
                    .Student = BorrowerID(0)("Student")
                    .dStudent = BorrowerID(0)("dStudent")
                    .SIRV = BorrowerID(0)("SIRV")
                    .dSIRV = BorrowerID(0)("dSIRV")

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
                '*** I D E N T I F I C A T I O N ***

                '*** D E P E N D E N T S ***
                Dim BorrowerD As DataTable = DataSource(String.Format("SELECT * FROM profile_dependent WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", GridView1.GetFocusedRowCellValue("Borrowers ID")))
                If BorrowerD.Rows.Count > 0 Then
                    .DependentID_1 = BorrowerD(0)("ID")
                    .Prefix_1 = BorrowerD(0)("Prefix_D")
                    .FirstN_1 = BorrowerD(0)("FirstN_D")
                    .MiddleN_1 = BorrowerD(0)("MiddleN_D")
                    .LastN_1 = BorrowerD(0)("LastN_D")
                    .Suffix_1 = BorrowerD(0)("Suffix_D")
                    .Birth_1 = BorrowerD(0)("Birth_D")
                    .Grade_1 = BorrowerD(0)("Grade_D")
                    .School_1 = BorrowerD(0)("School_D")
                    .SchoolAddress_1 = BorrowerD(0)("SchoolAddress_D")
                    If BorrowerD.Rows.Count > 1 Then
                        .DependentID_2 = BorrowerD(1)("ID")
                        .Prefix_2 = BorrowerD(1)("Prefix_D")
                        .FirstN_2 = BorrowerD(1)("FirstN_D")
                        .MiddleN_2 = BorrowerD(1)("MiddleN_D")
                        .LastN_2 = BorrowerD(1)("LastN_D")
                        .Suffix_2 = BorrowerD(1)("Suffix_D")
                        .Birth_2 = BorrowerD(1)("Birth_D")
                        .Grade_2 = BorrowerD(1)("Grade_D")
                        .School_2 = BorrowerD(1)("School_D")
                        .SchoolAddress_2 = BorrowerD(1)("SchoolAddress_D")
                        If BorrowerD.Rows.Count > 2 Then
                            .DependentID_3 = BorrowerD(2)("ID")
                            .Prefix_3 = BorrowerD(2)("Prefix_D")
                            .FirstN_3 = BorrowerD(2)("FirstN_D")
                            .MiddleN_3 = BorrowerD(2)("MiddleN_D")
                            .LastN_3 = BorrowerD(2)("LastN_D")
                            .Suffix_3 = BorrowerD(2)("Suffix_D")
                            .Birth_3 = BorrowerD(2)("Birth_D")
                            .Grade_3 = BorrowerD(2)("Grade_D")
                            .School_3 = BorrowerD(2)("School_D")
                            .SchoolAddress_3 = BorrowerD(2)("SchoolAddress_D")
                            If BorrowerD.Rows.Count > 3 Then
                                .DependentID_4 = BorrowerD(3)("ID")
                                .Prefix_4 = BorrowerD(3)("Prefix_D")
                                .FirstN_4 = BorrowerD(3)("FirstN_D")
                                .MiddleN_4 = BorrowerD(3)("MiddleN_D")
                                .LastN_4 = BorrowerD(3)("LastN_D")
                                .Suffix_4 = BorrowerD(3)("Suffix_D")
                                .Birth_4 = BorrowerD(3)("Birth_D")
                                .Grade_4 = BorrowerD(3)("Grade_D")
                                .School_4 = BorrowerD(3)("School_D")
                                .SchoolAddress_4 = BorrowerD(3)("SchoolAddress_D")
                            End If
                        End If
                    End If
                End If
                '*** D E P E N D E N T S ***

                If BorrowerP(0)("FirstN_S").ToString.Trim <> "" And BorrowerP(0)("LastN_S").ToString.Trim <> "" And (BorrowerP(0)("Civil_B") = "Married" Or BorrowerP(0)("Civil_B") = "Separated") Then
                    Dim SpouseP As DataTable = DataSource(String.Format("SELECT * FROM profile_spouse WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", GridView1.GetFocusedRowCellValue("Borrowers ID")))
                    If SpouseP.Rows.Count > 0 Then
                        .SpouseID = SpouseP(0)("SpouseID")
                        .CbxPrefix_S.Text = SpouseP(0)("Prefix_S")
                        .CbxPrefix_S.Tag = SpouseP(0)("Prefix_S")
                        .TxtFirstN_S.Text = SpouseP(0)("FirstN_S")
                        .TxtFirstN_S.Tag = SpouseP(0)("FirstN_S")
                        .TxtMiddleN_S.Text = SpouseP(0)("MiddleN_S")
                        .TxtMiddleN_S.Tag = SpouseP(0)("MiddleN_S")
                        .TxtLastN_S.Text = SpouseP(0)("LastN_S")
                        .TxtLastN_S.Tag = SpouseP(0)("LastN_S")
                        .cbxSuffix_S.Text = SpouseP(0)("Suffix_S")
                        .cbxSuffix_S.Tag = SpouseP(0)("Suffix_S")
                        .CbxPrefix_M.Text = SpouseP(0)("Prefix_M")
                        .CbxPrefix_M.Tag = SpouseP(0)("Prefix_M")
                        .TxtFirstN_M.Text = SpouseP(0)("FirstN_M")
                        .TxtFirstN_M.Tag = SpouseP(0)("FirstN_M")
                        .TxtMiddleN_M.Text = SpouseP(0)("MiddleN_M")
                        .TxtMiddleN_M.Tag = SpouseP(0)("MiddleN_M")
                        .TxtLastN_M.Text = SpouseP(0)("LastN_M")
                        .TxtLastN_M.Tag = SpouseP(0)("LastN_M")
                        .cbxSuffix_M.Text = SpouseP(0)("Suffix_M")
                        .cbxSuffix_M.Tag = SpouseP(0)("Suffix_M")
                        .txtNoC_S.Text = SpouseP(0)("NoC_S")
                        .txtNoC_S.Tag = SpouseP(0)("NoC_S")
                        .txtStreetC_S.Text = SpouseP(0)("StreetC_S")
                        .txtStreetC_S.Tag = SpouseP(0)("StreetC_S")
                        .txtBarangayC_S.Text = SpouseP(0)("BarangayC_S")
                        .txtBarangayC_S.Tag = SpouseP(0)("BarangayC_S")
                        .cbxAddressC_S.Text = SpouseP(0)("AddressC_S")
                        .cbxAddressC_S.Tag = SpouseP(0)("AddressC_S")
                        .txtNoP_S.Text = SpouseP(0)("NoP_S")
                        .txtNoP_S.Tag = SpouseP(0)("NoP_S")
                        .txtStreetP_S.Text = SpouseP(0)("StreetP_S")
                        .txtStreetP_S.Tag = SpouseP(0)("StreetP_S")
                        .txtBarangayP_S.Text = SpouseP(0)("BarangayP_S")
                        .txtBarangayP_S.Tag = SpouseP(0)("BarangayP_S")
                        .cbxAddressP_S.Text = SpouseP(0)("AddressP_S")
                        .cbxAddressP_S.Tag = SpouseP(0)("AddressP_S")
                        If SpouseP(0)("Birth_S") = "0001-01-01" Or SpouseP(0)("Birth_S") = "" Then
                            .DtpBirth_S.CustomFormat = ""
                            .DtpBirth_S.Tag = ""
                        Else
                            .DtpBirth_S.CustomFormat = "MMMM dd, yyyy"
                            .DtpBirth_S.Text = SpouseP(0)("Birth_S")
                            .DtpBirth_S.Tag = SpouseP(0)("Birth_S")
                        End If
                        .cbxPlaceBirth_S.Text = SpouseP(0)("PlaceBirth_S")
                        .cbxPlaceBirth_S.Tag = SpouseP(0)("PlaceBirth_S")
                        If SpouseP(0)("Gender_S") = "Male" Then
                            .cbxMale_S.Checked = True
                        ElseIf SpouseP(0)("Gender_S") = "Female" Then
                            .cbxFemale_S.Checked = True
                        End If
                        .cbxMale_S.Tag = SpouseP(0)("Gender_S")
                        .cbxFemale_S.Tag = SpouseP(0)("Gender_S")
                        .txtCitizenship_S.Text = SpouseP(0)("Citizenship_S")
                        .txtCitizenship_S.Tag = SpouseP(0)("Citizenship_S")
                        .txtTIN_S.Text = SpouseP(0)("TIN_S")
                        .txtTIN_S.Tag = SpouseP(0)("TIN_S")
                        .txtTelephone_S.Text = SpouseP(0)("Telephone_S")
                        .txtTelephone_S.Tag = SpouseP(0)("Telephone_S")
                        .txtSSS_S.Text = SpouseP(0)("SSS_S")
                        .txtSSS_S.Tag = SpouseP(0)("SSS_S")
                        .txtMobile_S.Text = SpouseP(0)("Mobile_S")
                        .txtMobile_S.Tag = SpouseP(0)("Mobile_S")
                        .txtEmail_S.Text = SpouseP(0)("Email_S")
                        .txtEmail_S.Tag = SpouseP(0)("Email_S")
                        If SpouseP(0)("House_S") = "Owned" Then
                            .cbxOwned_S.Checked = True
                        ElseIf SpouseP(0)("House_S") = "Free" Then
                            .cbxFree_S.Checked = True
                        ElseIf SpouseP(0)("House_S") = "Rented" Then
                            .cbxRented_S.Checked = True
                            .dRent_S.Value = SpouseP(0)("Rent_S")
                        End If
                        .cbxOwned_S.Tag = SpouseP(0)("House_S")
                        .cbxFree_S.Tag = SpouseP(0)("House_S")
                        .cbxRented_S.Tag = SpouseP(0)("House_S")
                        .dRent_S.Tag = SpouseP(0)("Rent_S")
                        Try
                            Using TempPB As New DevExpress.XtraEditors.PictureEdit
                                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), GridView1.GetFocusedRowCellValue("Borrowers ID"), "Spouse.jpg"))
                                ResizeImages(TempPB.Image.Clone, .pb_S, 650, 500)
                            End Using
                        Catch ex As Exception
                        End Try
                        .cbxEmployer_S.Text = SpouseP(0)("Employer_S")
                        .cbxEmployer_S.Tag = SpouseP(0)("Employer_S")
                        .txtEmployerAddress_S.Text = SpouseP(0)("EmployerAddress_S")
                        .txtEmployerAddress_S.Tag = SpouseP(0)("EmployerAddress_S")
                        .txtEmployerTelephone_S.Text = SpouseP(0)("EmployerTelephone_S")
                        .txtEmployerTelephone_S.Tag = SpouseP(0)("EmployerTelephone_S")
                        .cbxPosition_S.Text = SpouseP(0)("Position_S")
                        .cbxPosition_S.Tag = SpouseP(0)("Position_S")
                        If SpouseP(0)("EmploymentStat_S") = "Casual" Then
                            .cbxCasual_S.Checked = True
                        ElseIf SpouseP(0)("EmploymentStat_S") = "Temporary" Then
                            .cbxTemporary_S.Checked = True
                        ElseIf SpouseP(0)("EmploymentStat_S") = "Permanent" Then
                            .cbxPermanent_S.Checked = True
                        End If
                        .cbxCasual_S.Tag = SpouseP(0)("EmploymentStat_S")
                        .cbxTemporary_S.Tag = SpouseP(0)("EmploymentStat_S")
                        .cbxPermanent_S.Tag = SpouseP(0)("EmploymentStat_S")
                        .dtpHired_S.Text = SpouseP(0)("Hired_S")
                        .dtpHired_S.Tag = SpouseP(0)("Hired_S")
                        .cbxYearHired_S.Checked = SpouseP(0)("YearHired_S")
                        .txtSupervisor_S.Text = SpouseP(0)("Supervisor_S")
                        .txtSupervisor_S.Tag = SpouseP(0)("Supervisor_S")
                        .dMonthly_S.Value = SpouseP(0)("Monthly_S")
                        .dMonthly_S.Tag = SpouseP(0)("Monthly_S")
                        .txtBusinessName_S.Text = SpouseP(0)("BusinessName_S")
                        .txtBusinessName_S.Tag = SpouseP(0)("BusinessName_S")
                        .txtBusinessAddress_S.Text = SpouseP(0)("BusinessAddress_S")
                        .txtBusinessAddress_S.Tag = SpouseP(0)("BusinessAddress_S")
                        .txtBusinessTelephone_S.Text = SpouseP(0)("BusinessTelephone_S")
                        .txtBusinessTelephone_S.Tag = SpouseP(0)("BusinessTelephone_S")
                        .cbxNatureBusiness_S.Text = SpouseP(0)("NatureBusiness_S")
                        .cbxNatureBusiness_S.Tag = SpouseP(0)("NatureBusiness_S")

                        .cbxNatureBusiness_S2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Spouse'", GridView1.GetFocusedRowCellValue("Borrowers ID"))))

                        .iYrsOperation_S.Value = SpouseP(0)("YrsOperation_S")
                        .iYrsOperation_S.Tag = SpouseP(0)("YrsOperation_S")
                        .dBusinessIncome_S.Value = SpouseP(0)("BusinessIncome_S")
                        .dBusinessIncome_S.Tag = SpouseP(0)("BusinessIncome_S")
                        .iNoEmployees_S.Value = SpouseP(0)("NoEmployees_S")
                        .iNoEmployees_S.Tag = SpouseP(0)("NoEmployees_S")
                        .dCapital_S.Value = SpouseP(0)("Capital_S")
                        .dCapital_S.Tag = SpouseP(0)("Capital_S")
                        .txtArea_S.Text = SpouseP(0)("Area_S")
                        .txtArea_S.Tag = SpouseP(0)("Area_S")
                        .dtpExpiry_S.Text = SpouseP(0)("Expiry_S")
                        .dtpExpiry_S.Tag = SpouseP(0)("Expiry_S")
                        .iOutlet_S.Value = SpouseP(0)("Outlet_S")
                        .iOutlet_S.Tag = SpouseP(0)("Outlet_S")
                        .txtOtherIncome_S.Text = SpouseP(0)("OtherIncome_S")
                        .txtOtherIncome_S.Tag = SpouseP(0)("OtherIncome_S")
                        .dOtherIncome_S.Value = SpouseP(0)("OtherIncome_S-Amount")
                        .dOtherIncome_S.Tag = SpouseP(0)("OtherIncome_S-Amount")

                        '*** I D E N T I F I C A T I O N ***
                        Dim BorrowerID_S As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'S'", GridView1.GetFocusedRowCellValue("Borrowers ID")))
                        If BorrowerID_S.Rows.Count > 0 Then
                            .GSIS_S = BorrowerID_S(0)("GSIS")
                            .PhilHealth_S = BorrowerID_S(0)("PhilHealth")
                            .Senior_S = BorrowerID_S(0)("Senior")
                            .UMID_S = BorrowerID_S(0)("UMID")
                            .SEC_S = BorrowerID_S(0)("SEC")
                            .DTI_S = BorrowerID_S(0)("DTI")
                            .CDA_S = BorrowerID_S(0)("CDA")
                            .Cooperative_S = BorrowerID_S(0)("Cooperative")
                            .Drivers_S = BorrowerID_S(0)("Drivers")
                            .dDrivers_S = BorrowerID_S(0)("dDrivers")
                            .VIN_S = BorrowerID_S(0)("VIN")
                            .dVIN_S = BorrowerID_S(0)("dVIN")
                            .Passport_S = BorrowerID_S(0)("Passport")
                            .dPassport_S = BorrowerID_S(0)("dPassport")
                            .PRC_S = BorrowerID_S(0)("PRC")
                            .dPRC_S = BorrowerID_S(0)("dPRC")
                            .NBI_S = BorrowerID_S(0)("NBI")
                            .dNBI_S = BorrowerID_S(0)("dNBI")
                            .Police_S = BorrowerID_S(0)("Police")
                            .dPolice_S = BorrowerID_S(0)("dPolice")
                            .Postal_S = BorrowerID_S(0)("Postal")
                            .dPostal_S = BorrowerID_S(0)("dPostal")
                            .Barangay_S = BorrowerID_S(0)("Barangay")
                            .dBarangay_S = BorrowerID_S(0)("dBarangay")
                            .OWWA_S = BorrowerID_S(0)("OWWA")
                            .dOWWA_S = BorrowerID_S(0)("dOWWA")
                            .OFW_S = BorrowerID_S(0)("OFW")
                            .dOFW_S = BorrowerID_S(0)("dOFW")
                            .Seaman_S = BorrowerID_S(0)("Seaman")
                            .dSeaman_S = BorrowerID_S(0)("dSeaman")
                            .PNP_S = BorrowerID_S(0)("PNP")
                            .dPNP_S = BorrowerID_S(0)("dPNP")
                            .AFP_S = BorrowerID_S(0)("AFP")
                            .dAFP_S = BorrowerID_S(0)("dAFP")
                            .HDMF_S = BorrowerID_S(0)("HDMF")
                            .dHDMF_S = BorrowerID_S(0)("dHDMF")
                            .PWD_S = BorrowerID_S(0)("PWD")
                            .dPWD_S = BorrowerID_S(0)("dPWD")
                            .DSWD_S = BorrowerID_S(0)("DSWD")
                            .dDSWD_S = BorrowerID_S(0)("dDSWD")
                            .ACR_S = BorrowerID_S(0)("ACR")
                            .dACR_S = BorrowerID_S(0)("dACR")
                            .DTI_Business_S = BorrowerID_S(0)("DTI_Business")
                            .dDTI_Business_S = BorrowerID_S(0)("dDTI_Business")
                            .IBP_S = BorrowerID_S(0)("IBP")
                            .dIBP_S = BorrowerID_S(0)("dIBP")
                            .FireArms_S = BorrowerID_S(0)("FireArms")
                            .dFireArms_S = BorrowerID_S(0)("dFireArms")
                            .Government_S = BorrowerID_S(0)("Government")
                            .dGovernment_S = BorrowerID_S(0)("dGovernment")
                            .Diplomat_S = BorrowerID_S(0)("Diplomat")
                            .dDiplomat_S = BorrowerID_S(0)("dDiplomat")
                            .National_S = BorrowerID_S(0)("National")
                            .dNational_S = BorrowerID_S(0)("dNational")
                            .Work_S = BorrowerID_S(0)("Work")
                            .dWork_S = BorrowerID_S(0)("dWork")
                            .GOCC_S = BorrowerID_S(0)("GOCC")
                            .dGOCC_S = BorrowerID_S(0)("dGOCC")
                            .PLRA_S = BorrowerID_S(0)("PLRA")
                            .dPLRA_S = BorrowerID_S(0)("dPLRA")
                            .Major_S = BorrowerID_S(0)("Major")
                            .dMajor_S = BorrowerID_S(0)("dMajor")
                            .Media_S = BorrowerID_S(0)("Media")
                            .dMedia_S = BorrowerID_S(0)("dMedia")
                            .Student_S = BorrowerID_S(0)("Student")
                            .dStudent_S = BorrowerID_S(0)("dStudent")
                            .SIRV_S = BorrowerID_S(0)("SIRV")
                            .dSIRV_S = BorrowerID_S(0)("dSIRV")

                            .TotalImage_TIN_S = BorrowerID_S(0)("Attach_TIN")
                            .TotalImage_SSS_S = BorrowerID_S(0)("Attach_SSS")
                            .TotalImage_GSIS_S = BorrowerID_S(0)("Attach_GSIS")
                            .TotalImage_PhilHealth_S = BorrowerID_S(0)("Attach_PhilHealth")
                            .TotalImage_Senior_S = BorrowerID_S(0)("Attach_Senior")
                            .TotalImage_UMID_S = BorrowerID_S(0)("Attach_UMID")
                            .TotalImage_SEC_S = BorrowerID_S(0)("Attach_SEC")
                            .TotalImage_DTI_S = BorrowerID_S(0)("Attach_DTI")
                            .TotalImage_CDA_S = BorrowerID_S(0)("Attach_CDA")
                            .TotalImage_Cooperative_S = BorrowerID_S(0)("Attach_Cooperative")
                            .TotalImage_Drivers_S = BorrowerID_S(0)("Attach_Drivers")
                            .TotalImage_VIN_S = BorrowerID_S(0)("Attach_VIN")
                            .TotalImage_Passport_S = BorrowerID_S(0)("Attach_Passport")
                            .TotalImage_PRC_S = BorrowerID_S(0)("Attach_PRC")
                            .TotalImage_NBI_S = BorrowerID_S(0)("Attach_NBI")
                            .TotalImage_Police_S = BorrowerID_S(0)("Attach_Police")
                            .TotalImage_Postal_S = BorrowerID_S(0)("Attach_Postal")
                            .TotalImage_Barangay_S = BorrowerID_S(0)("Attach_Barangay")
                            .TotalImage_OWWA_S = BorrowerID_S(0)("Attach_OWWA")
                            .TotalImage_OFW_S = BorrowerID_S(0)("Attach_OFW")
                            .TotalImage_Seaman_S = BorrowerID_S(0)("Attach_Seaman")
                            .TotalImage_PNP_S = BorrowerID_S(0)("Attach_PNP")
                            .TotalImage_AFP_S = BorrowerID_S(0)("Attach_AFP")
                            .TotalImage_HDMF_S = BorrowerID_S(0)("Attach_HDMF")
                            .TotalImage_PWD_S = BorrowerID_S(0)("Attach_PWD")
                            .TotalImage_DSWD_S = BorrowerID_S(0)("Attach_DSWD")
                            .TotalImage_ACR_S = BorrowerID_S(0)("Attach_ACR")
                            .TotalImage_DTI_Business_S = BorrowerID_S(0)("Attach_DTI_Business")
                            .TotalImage_IBP_S = BorrowerID_S(0)("Attach_IBP")
                            .TotalImage_FireArms_S = BorrowerID_S(0)("Attach_FireArms")
                            .TotalImage_Government_S = BorrowerID_S(0)("Attach_Government")
                            .TotalImage_Diplomat_S = BorrowerID_S(0)("Attach_Diplomat")
                            .TotalImage_National_S = BorrowerID_S(0)("Attach_National")
                            .TotalImage_Work_S = BorrowerID_S(0)("Attach_Work")
                            .TotalImage_GOCC_S = BorrowerID_S(0)("Attach_GOCC")
                            .TotalImage_PLRA_S = BorrowerID_S(0)("Attach_PLRA")
                            .TotalImage_Major_S = BorrowerID_S(0)("Attach_Major")
                            .TotalImage_Media_S = BorrowerID_S(0)("Attach_Media")
                            .TotalImage_Student_S = BorrowerID_S(0)("Attach_Student")
                            .TotalImage_SIRV_S = BorrowerID_S(0)("Attach_SIRV")
                        End If
                        '*** I D E N T I F I C A T I O N ***
                    End If
                End If

                .btnSave.Enabled = False
                .btnSave_F.Enabled = False
                If Branch_Code = GridView1.GetFocusedRowCellValue("branch_code") Then
                    .btnModify.Enabled = True
                Else
                    .btnModify.Enabled = False
                End If
            Else
                MsgBox("No borrower found. Please check your data.", MsgBoxStyle.Information, "Info")
            End If
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("Borrowers ID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Cursor = Cursors.WaitCursor
        With FrmBorrowerCorp
            .Tag = 15
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If Show_Dialog Then
                Forms(FrmBorrowerCorp, FrmMain.PanelControl3)
            Else
                .ControlBox = True
                .WindowState = FormWindowState.Normal
                .MinimizeBox = True
                .MaximizeBox = True
                .Show()
                .BringToFront()
                SendToBack()
            End If

            .Clear()
            Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_corporation.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_corporation.BusinessID)) AS 'BusinessCenter' FROM profile_corporation WHERE BorrowerID = '{0}'", GridView2.GetFocusedRowCellValue("Borrowers ID")))
            If BorrowerP.Rows.Count > 0 Then
                .PanelEx2.Enabled = False
                .btnSave.Enabled = False
                .btnSaveDraft.Enabled = False
                If Branch_Code = GridView2.GetFocusedRowCellValue("branch_code") Then
                    .btnModify.Enabled = True
                Else
                    .btnModify.Enabled = False
                End If
                .cbxMicro.Tag = ""
                .cbxSmall.Tag = ""
                .cbxMedium.Tag = ""
                .cbxLarge.Tag = ""
                .ID = GridView2.GetFocusedRowCellValue("ID")
                .TotalImage = GridView2.GetFocusedRowCellValue("Attach")
                .btnAttach.Enabled = True
                .txtBorrowerID.Text = GridView2.GetFocusedRowCellValue("Borrowers ID")
                .txtBorrowerID.Tag = GridView2.GetFocusedRowCellValue("Borrowers ID")
                .txtTradeName.Text = BorrowerP(0)("TradeName")
                .txtTradeName.Tag = BorrowerP(0)("TradeName")
                .txtNo.Text = BorrowerP(0)("No")
                .txtNo.Tag = BorrowerP(0)("No")
                .txtStreet.Text = BorrowerP(0)("Street")
                .txtStreet.Tag = BorrowerP(0)("Street")
                .txtBarangay.Text = BorrowerP(0)("Barangay")
                .txtBarangay.Tag = BorrowerP(0)("Barangay")
                .cbxAddress.Text = BorrowerP(0)("Address")
                .cbxAddress.Tag = BorrowerP(0)("Address")
                .txtTIN.Text = BorrowerP(0)("TIN")
                .txtTIN.Tag = BorrowerP(0)("TIN")
                .txtSSS.Text = BorrowerP(0)("SSS")
                .txtSSS.Tag = BorrowerP(0)("SSS")
                .txtTelephone.Text = BorrowerP(0)("Telephone")
                .txtTelephone.Tag = BorrowerP(0)("Telephone")
                .txtEmail.Text = BorrowerP(0)("Email")
                .txtEmail.Tag = BorrowerP(0)("Email")
                .txtFax.Text = BorrowerP(0)("Fax")
                .txtFax.Tag = BorrowerP(0)("Fax")
                .txtWebsite.Text = BorrowerP(0)("Website")
                .txtWebsite.Tag = BorrowerP(0)("Website")
                .dtpIncorporation.Text = BorrowerP(0)("Incorporation")
                .dtpIncorporation.Tag = BorrowerP(0)("Incorporation")
                .iYears.Value = BorrowerP(0)("YearsOperation")
                .iYears.Tag = BorrowerP(0)("YearsOperation")
                .iEmployees.Value = BorrowerP(0)("Employees")
                .iEmployees.Tag = BorrowerP(0)("Employees")
                If BorrowerP(0)("FirmSize") = "Micro" Then
                    .cbxMicro.Checked = True
                ElseIf BorrowerP(0)("FirmSize") = "Small" Then
                    .cbxSmall.Checked = True
                ElseIf BorrowerP(0)("FirmSize") = "Medium" Then
                    .cbxMedium.Checked = True
                ElseIf BorrowerP(0)("FirmSize") = "Large" Then
                    .cbxLarge.Checked = True
                End If
                .cbxMicro.Tag = BorrowerP(0)("FirmSize")
                .cbxSmall.Tag = BorrowerP(0)("FirmSize")
                .cbxMedium.Tag = BorrowerP(0)("FirmSize")
                .cbxLarge.Tag = BorrowerP(0)("FirmSize")
                .dGross.Value = BorrowerP(0)("Gross")
                .dGross.Tag = BorrowerP(0)("Gross")
                .dNet.Value = BorrowerP(0)("Net")
                .dNet.Tag = BorrowerP(0)("Net")

                .vPrefix_S1 = BorrowerP(0)("Prefix_S1")
                .vFirstN_S1 = BorrowerP(0)("FirstN_S1")
                .vMiddleN_S1 = BorrowerP(0)("MiddleN_S1")
                .vLastN_S1 = BorrowerP(0)("LastN_S1")
                .vSuffix_S1 = BorrowerP(0)("Suffix_S1")

                .vPrefix_S2 = BorrowerP(0)("Prefix_S2")
                .vFirstN_S2 = BorrowerP(0)("FirstN_S2")
                .vMiddleN_S2 = BorrowerP(0)("MiddleN_S2")
                .vLastN_S2 = BorrowerP(0)("LastN_S2")
                .vSuffix_S2 = BorrowerP(0)("Suffix_S2")

                .vPrefix_S3 = BorrowerP(0)("Prefix_S3")
                .vFirstN_S3 = BorrowerP(0)("FirstN_S3")
                .vMiddleN_S3 = BorrowerP(0)("MiddleN_S3")
                .vLastN_S3 = BorrowerP(0)("LastN_S3")
                .vSuffix_S3 = BorrowerP(0)("Suffix_S3")

                .vPrefix_S4 = BorrowerP(0)("Prefix_S4")
                .vFirstN_S4 = BorrowerP(0)("FirstN_S4")
                .vMiddleN_S4 = BorrowerP(0)("MiddleN_S4")
                .vLastN_S4 = BorrowerP(0)("LastN_S4")
                .vSuffix_S4 = BorrowerP(0)("Suffix_S4")

                .CbxPrefix_R1.Text = BorrowerP(0)("Prefix_R1")
                .CbxPrefix_R1.Tag = BorrowerP(0)("Prefix_R1")
                If BorrowerP(0)("FirstN_R1") = "" Then
                Else
                    .btnAttach_R1B.Visible = True
                End If
                .TxtFirstN_R1.Text = BorrowerP(0)("FirstN_R1")
                .TxtFirstN_R1.Tag = BorrowerP(0)("FirstN_R1")
                .TxtMiddleN_R1.Text = BorrowerP(0)("MiddleN_R1")
                .TxtMiddleN_R1.Tag = BorrowerP(0)("MiddleN_R1")
                .TxtLastN_R1.Text = BorrowerP(0)("LastN_R1")
                .TxtLastN_R1.Tag = BorrowerP(0)("LastN_R1")
                .cbxSuffix_R1.Text = BorrowerP(0)("Suffix_R1")
                .cbxSuffix_R1.Tag = BorrowerP(0)("Suffix_R1")
                .DtpBirth_R1.Text = BorrowerP(0)("Birthdate_R1")
                .DtpBirth_R1.Tag = BorrowerP(0)("Birthdate_R1")
                .txtTIN_R1.Text = BorrowerP(0)("TIN_R1")
                .txtTIN_R1.Tag = BorrowerP(0)("TIN_R1")
                .txtSSS_R1.Text = BorrowerP(0)("SSS_R1")
                .txtSSS_R1.Tag = BorrowerP(0)("SSS_R1")
                .dGMI_R1.Value = BorrowerP(0)("GMI_R1")
                .dGMI_R1.Tag = BorrowerP(0)("GMI_R1")
                .dYears_R1.Value = BorrowerP(0)("Years_R1")
                .dYears_R1.Tag = BorrowerP(0)("Years_R1")
                .TotalImage_R1 = BorrowerP(0)("Attach_R1")
                .txtNo_R1.Text = BorrowerP(0)("No_R1")
                .txtNo_R1.Tag = BorrowerP(0)("No_R1")
                .txtStreet_R1.Text = BorrowerP(0)("Street_R1")
                .txtStreet_R1.Tag = BorrowerP(0)("Street_R1")
                .txtBarangay_R1.Text = BorrowerP(0)("Barangay_R1")
                .txtBarangay_R1.Tag = BorrowerP(0)("Barangay_R1")
                .cbxAddress_R1.Text = BorrowerP(0)("Address_R1")
                .cbxAddress_R1.Tag = BorrowerP(0)("Address_R1")
                .txtPosition_R1.Text = BorrowerP(0)("Position_R1")
                .txtPosition_R1.Tag = BorrowerP(0)("Position_R1")
                .txtContact_R1.Text = BorrowerP(0)("Contact_R1")
                .txtContact_R1.Tag = BorrowerP(0)("Contact_R1")

                .CbxPrefix_R2.Text = BorrowerP(0)("Prefix_R2")
                .CbxPrefix_R2.Tag = BorrowerP(0)("Prefix_R2")
                If BorrowerP(0)("FirstN_R2") = "" Then
                Else
                    .btnAttach_R2B.Visible = True
                End If
                .TxtFirstN_R2.Text = BorrowerP(0)("FirstN_R2")
                .TxtFirstN_R2.Tag = BorrowerP(0)("FirstN_R2")
                .TxtMiddleN_R2.Text = BorrowerP(0)("MiddleN_R2")
                .TxtMiddleN_R2.Tag = BorrowerP(0)("MiddleN_R2")
                .TxtLastN_R2.Text = BorrowerP(0)("LastN_R2")
                .TxtLastN_R2.Tag = BorrowerP(0)("LastN_R2")
                .cbxSuffix_R2.Text = BorrowerP(0)("Suffix_R2")
                .cbxSuffix_R2.Tag = BorrowerP(0)("Suffix_R2")
                .DtpBirth_R2.Text = BorrowerP(0)("Birthdate_R2")
                .DtpBirth_R2.Tag = BorrowerP(0)("Birthdate_R2")
                .txtTIN_R2.Text = BorrowerP(0)("TIN_R2")
                .txtTIN_R2.Tag = BorrowerP(0)("TIN_R2")
                .txtSSS_R2.Text = BorrowerP(0)("SSS_R2")
                .txtSSS_R2.Tag = BorrowerP(0)("SSS_R2")
                .dGMI_R2.Value = BorrowerP(0)("GMI_R2")
                .dGMI_R2.Tag = BorrowerP(0)("GMI_R2")
                .dYears_R2.Value = BorrowerP(0)("Years_R2")
                .dYears_R2.Tag = BorrowerP(0)("Years_R2")
                .TotalImage_R2 = BorrowerP(0)("Attach_R2")
                .txtNo_R2.Text = BorrowerP(0)("No_R2")
                .txtNo_R2.Tag = BorrowerP(0)("No_R2")
                .txtStreet_R2.Text = BorrowerP(0)("Street_R2")
                .txtStreet_R2.Tag = BorrowerP(0)("Street_R2")
                .txtBarangay_R2.Text = BorrowerP(0)("Barangay_R2")
                .txtBarangay_R2.Tag = BorrowerP(0)("Barangay_R2")
                .cbxAddress_R2.Text = BorrowerP(0)("Address_R2")
                .cbxAddress_R2.Tag = BorrowerP(0)("Address_R2")
                .txtPosition_R2.Text = BorrowerP(0)("Position_R2")
                .txtPosition_R2.Tag = BorrowerP(0)("Position_R2")
                .txtContact_R2.Text = BorrowerP(0)("Contact_R2")
                .txtContact_R2.Tag = BorrowerP(0)("Contact_R2")

                .CbxPrefix_R3.Text = BorrowerP(0)("Prefix_R3")
                .CbxPrefix_R3.Tag = BorrowerP(0)("Prefix_R3")
                If BorrowerP(0)("FirstN_R3") = "" Then
                Else
                    .btnAttach_R3B.Visible = True
                End If
                .TxtFirstN_R3.Text = BorrowerP(0)("FirstN_R3")
                .TxtFirstN_R3.Tag = BorrowerP(0)("FirstN_R3")
                .TxtMiddleN_R3.Text = BorrowerP(0)("MiddleN_R3")
                .TxtMiddleN_R3.Tag = BorrowerP(0)("MiddleN_R3")
                .TxtLastN_R3.Text = BorrowerP(0)("LastN_R3")
                .TxtLastN_R3.Tag = BorrowerP(0)("LastN_R3")
                .cbxSuffix_R3.Text = BorrowerP(0)("Suffix_R3")
                .cbxSuffix_R3.Tag = BorrowerP(0)("Suffix_R3")
                .DtpBirth_R3.Text = BorrowerP(0)("Birthdate_R3")
                .DtpBirth_R3.Tag = BorrowerP(0)("Birthdate_R3")
                .txtTIN_R3.Text = BorrowerP(0)("TIN_R3")
                .txtTIN_R3.Tag = BorrowerP(0)("TIN_R3")
                .txtSSS_R3.Text = BorrowerP(0)("SSS_R3")
                .txtSSS_R3.Tag = BorrowerP(0)("SSS_R3")
                .dGMI_R3.Value = BorrowerP(0)("GMI_R3")
                .dGMI_R3.Tag = BorrowerP(0)("GMI_R3")
                .dYears_R3.Value = BorrowerP(0)("Years_R3")
                .dYears_R3.Tag = BorrowerP(0)("Years_R3")
                .TotalImage_R3 = BorrowerP(0)("Attach_R3")
                .txtNo_R3.Text = BorrowerP(0)("No_R3")
                .txtNo_R3.Tag = BorrowerP(0)("No_R3")
                .txtStreet_R3.Text = BorrowerP(0)("Street_R3")
                .txtStreet_R3.Tag = BorrowerP(0)("Street_R3")
                .txtBarangay_R3.Text = BorrowerP(0)("Barangay_R3")
                .txtBarangay_R3.Tag = BorrowerP(0)("Barangay_R3")
                .cbxAddress_R3.Text = BorrowerP(0)("Address_R3")
                .cbxAddress_R3.Tag = BorrowerP(0)("Address_R3")
                .txtPosition_R3.Text = BorrowerP(0)("Position_R3")
                .txtPosition_R3.Tag = BorrowerP(0)("Position_R3")
                .txtContact_R3.Text = BorrowerP(0)("Contact_R3")
                .txtContact_R3.Tag = BorrowerP(0)("Contact_R3")

                .CbxPrefix_R4.Text = BorrowerP(0)("Prefix_R4")
                .CbxPrefix_R4.Tag = BorrowerP(0)("Prefix_R4")
                If BorrowerP(0)("FirstN_R4") = "" Then
                Else
                    .btnAttach_R4B.Visible = True
                End If
                .TxtFirstN_R4.Text = BorrowerP(0)("FirstN_R4")
                .TxtFirstN_R4.Tag = BorrowerP(0)("FirstN_R4")
                .TxtMiddleN_R4.Text = BorrowerP(0)("MiddleN_R4")
                .TxtMiddleN_R4.Tag = BorrowerP(0)("MiddleN_R4")
                .TxtLastN_R4.Text = BorrowerP(0)("LastN_R4")
                .TxtLastN_R4.Tag = BorrowerP(0)("LastN_R4")
                .cbxSuffix_R4.Text = BorrowerP(0)("Suffix_R4")
                .cbxSuffix_R4.Tag = BorrowerP(0)("Suffix_R4")
                .DtpBirth_R4.Text = BorrowerP(0)("Birthdate_R4")
                .DtpBirth_R4.Tag = BorrowerP(0)("Birthdate_R4")
                .txtTIN_R4.Text = BorrowerP(0)("TIN_R4")
                .txtTIN_R4.Tag = BorrowerP(0)("TIN_R4")
                .txtSSS_R4.Text = BorrowerP(0)("SSS_R4")
                .txtSSS_R4.Tag = BorrowerP(0)("SSS_R4")
                .dGMI_R4.Value = BorrowerP(0)("GMI_R4")
                .dGMI_R4.Tag = BorrowerP(0)("GMI_R4")
                .dYears_R4.Value = BorrowerP(0)("Years_R4")
                .dYears_R4.Tag = BorrowerP(0)("Years_R4")
                .TotalImage_R4 = BorrowerP(0)("Attach_R4")
                .txtNo_R4.Text = BorrowerP(0)("No_R4")
                .txtNo_R4.Tag = BorrowerP(0)("No_R4")
                .txtStreet_R4.Text = BorrowerP(0)("Street_R4")
                .txtStreet_R4.Tag = BorrowerP(0)("Street_R4")
                .txtBarangay_R4.Text = BorrowerP(0)("Barangay_R4")
                .txtBarangay_R4.Tag = BorrowerP(0)("Barangay_R4")
                .cbxAddress_R4.Text = BorrowerP(0)("Address_R4")
                .cbxAddress_R4.Tag = BorrowerP(0)("Address_R4")
                .txtPosition_R4.Text = BorrowerP(0)("Position_R4")
                .txtPosition_R4.Tag = BorrowerP(0)("Position_R4")
                .txtContact_R4.Text = BorrowerP(0)("Contact_R4")
                .txtContact_R4.Tag = BorrowerP(0)("Contact_R4")

                .CbxPrefix_R5.Text = BorrowerP(0)("Prefix_R5")
                .CbxPrefix_R5.Tag = BorrowerP(0)("Prefix_R5")
                If BorrowerP(0)("FirstN_R5") = "" Then
                Else
                    .btnAttach_R5B.Visible = True
                End If
                .TxtFirstN_R5.Text = BorrowerP(0)("FirstN_R5")
                .TxtFirstN_R5.Tag = BorrowerP(0)("FirstN_R5")
                .TxtMiddleN_R5.Text = BorrowerP(0)("MiddleN_R5")
                .TxtMiddleN_R5.Tag = BorrowerP(0)("MiddleN_R5")
                .TxtLastN_R5.Text = BorrowerP(0)("LastN_R5")
                .TxtLastN_R5.Tag = BorrowerP(0)("LastN_R5")
                .cbxSuffix_R5.Text = BorrowerP(0)("Suffix_R5")
                .cbxSuffix_R5.Tag = BorrowerP(0)("Suffix_R5")
                .DtpBirth_R5.Text = BorrowerP(0)("Birthdate_R5")
                .DtpBirth_R5.Tag = BorrowerP(0)("Birthdate_R5")
                .txtTIN_R5.Text = BorrowerP(0)("TIN_R5")
                .txtTIN_R5.Tag = BorrowerP(0)("TIN_R5")
                .txtSSS_R5.Text = BorrowerP(0)("SSS_R5")
                .txtSSS_R5.Tag = BorrowerP(0)("SSS_R5")
                .dGMI_R5.Value = BorrowerP(0)("GMI_R5")
                .dGMI_R5.Tag = BorrowerP(0)("GMI_R5")
                .dYears_R5.Value = BorrowerP(0)("Years_R5")
                .dYears_R5.Tag = BorrowerP(0)("Years_R5")
                .TotalImage_R5 = BorrowerP(0)("Attach_R5")
                .txtNo_R5.Text = BorrowerP(0)("No_R5")
                .txtNo_R5.Tag = BorrowerP(0)("No_R5")
                .txtStreet_R5.Text = BorrowerP(0)("Street_R5")
                .txtStreet_R5.Tag = BorrowerP(0)("Street_R5")
                .txtBarangay_R5.Text = BorrowerP(0)("Barangay_R5")
                .txtBarangay_R5.Tag = BorrowerP(0)("Barangay_R5")
                .cbxAddress_R5.Text = BorrowerP(0)("Address_R5")
                .cbxAddress_R5.Tag = BorrowerP(0)("Address_R5")
                .txtPosition_R5.Text = BorrowerP(0)("Position_R5")
                .txtPosition_R5.Tag = BorrowerP(0)("Position_R5")
                .txtContact_R5.Text = BorrowerP(0)("Contact_R5")
                .txtContact_R5.Tag = BorrowerP(0)("Contact_R5")

                .txtBank_1.Text = BorrowerP(0)("Bank_1")
                .txtBank_1.Tag = BorrowerP(0)("Bank_1")
                .txtBranch_1.Text = BorrowerP(0)("Branch_1")
                .txtBranch_1.Tag = BorrowerP(0)("Branch_1")
                If BorrowerP(0)("AccountT_1") = "SA" Then
                    .cbxSA_1.Checked = True
                ElseIf BorrowerP(0)("AccountT_1") = "CA" Then
                    .cbxCA_1.Checked = True
                End If
                .cbxSA_1.Tag = BorrowerP(0)("AccountT_1")
                .cbxCA_1.Tag = BorrowerP(0)("AccountT_1")
                .txtSA_1.Text = BorrowerP(0)("SA_1")
                .txtSA_1.Tag = BorrowerP(0)("SA_1")
                .dAverageBalance_1.Value = BorrowerP(0)("AverageBalance_1")
                .dAverageBalance_1.Tag = BorrowerP(0)("AverageBalance_1")
                .dPresentBalance_1.Value = BorrowerP(0)("PresentBalance_1")
                .dPresentBalance_1.Tag = BorrowerP(0)("PresentBalance_1")
                .dtpOpened_1.Text = BorrowerP(0)("Opened_1")
                .dtpOpened_1.Tag = BorrowerP(0)("Opened_1")
                .txtBankRemarks_1.Text = BorrowerP(0)("BankRemarks_1")
                .txtBankRemarks_1.Tag = BorrowerP(0)("BankRemarks_1")

                .txtBank_2.Text = BorrowerP(0)("Bank_2")
                .txtBank_2.Tag = BorrowerP(0)("Bank_2")
                .txtBranch_2.Text = BorrowerP(0)("Branch_2")
                .txtBranch_2.Tag = BorrowerP(0)("Branch_2")
                If BorrowerP(0)("AccountT_2") = "SA" Then
                    .cbxSA_2.Checked = True
                ElseIf BorrowerP(0)("AccountT_2") = "CA" Then
                    .cbxCA_2.Checked = True
                End If
                .cbxSA_2.Tag = BorrowerP(0)("AccountT_1")
                .cbxCA_2.Tag = BorrowerP(0)("AccountT_1")
                .txtSA_2.Text = BorrowerP(0)("SA_2")
                .txtSA_2.Tag = BorrowerP(0)("SA_2")
                .dAverageBalance_2.Value = BorrowerP(0)("AverageBalance_2")
                .dAverageBalance_2.Tag = BorrowerP(0)("AverageBalance_2")
                .dPresentBalance_2.Value = BorrowerP(0)("PresentBalance_2")
                .dPresentBalance_2.Tag = BorrowerP(0)("PresentBalance_2")
                .dtpOpened_2.Text = BorrowerP(0)("Opened_2")
                .dtpOpened_2.Tag = BorrowerP(0)("Opened_2")
                .txtBankRemarks_2.Text = BorrowerP(0)("BankRemarks_2")
                .txtBankRemarks_2.Tag = BorrowerP(0)("BankRemarks_2")
                .cbxAgent.Tag = If(BorrowerP(0)("Agent") = "", "No", "Yes")
                .cbxAgent.Checked = If(BorrowerP(0)("Agent") = "", False, True)
                .cbxAgentName.Text = BorrowerP(0)("Agent")
                .cbxAgentName.Tag = BorrowerP(0)("Agent")
                .txtAgentContact.Text = BorrowerP(0)("AgentNo")
                .txtAgentContact.Tag = BorrowerP(0)("AgentNo")
                .cbxMarketing.Checked = If(BorrowerP(0)("Marketing") = "", False, True)
                .cbxMarketing.Tag = If(BorrowerP(0)("Marketing") = "", "No", "Yes")
                .cbxMarketingName.Text = BorrowerP(0)("Marketing")
                .cbxMarketingName.Tag = BorrowerP(0)("Marketing")
                .txtMarketingContact.Text = BorrowerP(0)("MarketingNo")
                .txtMarketingContact.Tag = BorrowerP(0)("MarketingNo")
                .cbxWalkIn.Checked = If(BorrowerP(0)("WalkIn") = "", False, True)
                .cbxWalkIn.Tag = If(BorrowerP(0)("WalkIn") = "", "No", "Yes")
                .cbxWalkInType.Text = BorrowerP(0)("WalkIn")
                .cbxWalkInType.Tag = BorrowerP(0)("WalkIn")
                .txtWalkInOthers.Text = BorrowerP(0)("WalkIn_Specify")
                .txtWalkInOthers.Tag = BorrowerP(0)("WalkIn_Specify")
                .cbxDealer.Checked = If(BorrowerP(0)("Dealer") = "", False, True)
                .cbxDealer.Tag = If(BorrowerP(0)("Dealer") = "", "No", "Yes")
                .cbxDealerName.Text = BorrowerP(0)("Dealer")
                .cbxDealerName.Tag = BorrowerP(0)("Dealer")
                .txtDealersContact.Text = BorrowerP(0)("DealerNo")
                .txtDealersContact.Tag = BorrowerP(0)("DealerNo")
                .cbxBusinessCenter.Text = BorrowerP(0)("BusinessCenter")
                .cbxBusinessCenter.Tag = BorrowerP(0)("BusinessCenter")
                Try
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), GridView2.GetFocusedRowCellValue("Borrowers ID"), "Corporation.jpg"))
                        ResizeImages(TempPB.Image.Clone, .pb_Logo, 650, 500)
                    End Using
                Catch ex As Exception
                End Try
            End If
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub BtnCIC_Click(sender As Object, e As EventArgs) Handles btnCIC.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to open this file?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim SQL As String
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If GridView1.RowCount = 0 Then
                    Exit Sub
                End If

                SQL = "SELECT"
                SQL &= "    'ID' AS 'Record Type',"
                SQL &= "    'LS006660' AS 'Provider Code',"
                SQL &= "    '005' AS 'Branch Code',"
                SQL &= "    DATE_FORMAT(B.timestamp,'%d%m%Y') AS 'Subject Reference Date',"
                SQL &= "    B.BorrowerID AS 'Provider Subject No',"
                SQL &= "    IF(B.Prefix_B='MR',10,IF(B.Prefix_B='MS',11,IF(B.Prefix_B='MISS',12,IF(B.Prefix_B='MRS',13,IF(B.Prefix_B='DR',14,IF(B.Prefix_B='PROF',15,IF(B.Prefix_B='HON',16,IF(B.Prefix_B='LADY',17,IF(B.Prefix_B='MAJOR',18,IF(B.Prefix_B='SIR',19,IF(B.Prefix_B='MADAM',20,''))))))))))) AS 'Title',"
                SQL &= "    B.FirstN_B AS 'First Name',"
                SQL &= "    B.LastN_B AS 'Last Name',"
                SQL &= "    B.MiddleN_B AS 'Middle Name',"
                SQL &= "    B.Suffix_B AS 'Suffix',"
                SQL &= "    B.FirstN_B AS 'Nickname',"
                SQL &= "    '' AS 'Previous Last Name',"
                SQL &= "    IF(B.Gender_B='Male','M',IF(B.Gender_B='Female','F','')) AS 'Gender',"
                SQL &= "    DATE_FORMAT(B.Birth_B,'%d%m%Y') AS 'Date of Birth',"
                SQL &= "    B.PlaceBirth_B AS 'Place of Birth',"
                SQL &= "    IFNULL((SELECT iso FROM country WHERE ID = (SELECT countryID FROM city_municipality WHERE citymunCode = B.`PlaceBirth_B-ID`)),'') AS 'Country of Birth(Code)',"
                SQL &= "    IFNULL((SELECT iso FROM country WHERE ID = (SELECT countryID FROM city_municipality WHERE citymunCode = B.`PlaceBirth_B-ID`)),'') AS 'Nationality',"
                SQL &= "    IF(B.Citizenship_B='FILIPINO',1,0) AS 'Resident',"
                SQL &= "    IF(B.Civil_B='Single',1,IF(B.Civil_B='Married',2,IF(B.Civil_B='Separated',3,IF(B.Civil_B='Widowed',4,'')))) AS 'Civil Status',"
                SQL &= "    (SELECT COUNT(ID) FROM profile_dependent WHERE `status` = 'ACTIVE' AND profile_dependent.BorrowerID = B.BorrowerID) AS 'Number of Dependents',"
                SQL &= "    0 AS 'Car/s Owned',"
                SQL &= "    S.FirstN_S AS 'Spouse First Name',"
                SQL &= "    S.LastN_S AS 'Spouse Last Name',"
                SQL &= "    S.MiddleN_S AS 'Spouse Middle Name',"
                SQL &= "    S.FirstN_M AS 'Mother`s Maiden First Name',"
                SQL &= "    S.LastN_M AS 'Mother`s Maiden Last Name',"
                SQL &= "    S.MiddleN_M AS 'Mother`s Maiden Middle Name',"
                SQL &= "    '' AS 'Father First Name',"
                SQL &= "    '' AS 'Father Last Name',"
                SQL &= "    '' AS 'Father Middle Name',"
                SQL &= "    '' AS 'Father Suffix',"
                SQL &= "    'MI' AS 'Address 1: Address Type',"
                SQL &= "    B.AddressC_B AS 'Address 1: Full Address', "
                SQL &= "    '' AS 'Address 1: StreetNo',"
                SQL &= "    '' AS 'Address 1: PostalCode',"
                SQL &= "    '' AS 'Address 1: Subdivision',"
                SQL &= "    '' AS 'Address 1: Barangay',"
                SQL &= "    '' AS 'Address 1: City',"
                SQL &= "    '' AS 'Address 1: Province',"
                SQL &= "    IFNULL((SELECT iso FROM country WHERE ID = (SELECT countryID FROM city_municipality WHERE citymunCode = B.`AddressC_B-ID`)),'') AS 'Address 1: Country',"
                SQL &= "    IF(House_B='Owned',1,IF(House_B='Rented',2,IF(House_B='Free' OR House_B='',3,''))) AS 'Address 1: House Owner/Lessee',"
                SQL &= "    '' AS 'Address 1: Occupied Since',"
                SQL &= "    'AI' AS 'Address 2: Address Type',"
                SQL &= "    B.AddressP_B AS 'Address 2: Full Address', "
                SQL &= "    '' AS 'Address 2: StreetNo',"
                SQL &= "    '' AS 'Address 2: PostalCode',"
                SQL &= "    '' AS 'Address 2: Subdivision',"
                SQL &= "    '' AS 'Address 2: Barangay',"
                SQL &= "    '' AS 'Address 2: City',"
                SQL &= "    '' AS 'Address 2: Province',"
                SQL &= "    IFNULL((SELECT iso FROM country WHERE ID = (SELECT countryID FROM city_municipality WHERE citymunCode = B.`AddressP_B-ID`)),'') AS 'Address 2: Country',"
                SQL &= "    '' AS 'Address 2: House Owner/Lessee',"
                SQL &= "    '' AS 'Address 2: Occupied Since',"
                SQL &= "    IF(D.TIN!='',10,IF(D.SSS!='',11,IF(D.GSIS!='',12,IF(D.PhilHealth!='',13,IF(D.Senior!='',14,IF(D.UMID!='',15,IF(D.SEC!='',16,IF(D.DTI!='',17,IF(D.CDA!='',18,IF(D.Cooperative!='',19,'')))))))))) AS 'Identification 1: Type',"
                SQL &= "    REPLACE(IF(D.TIN!='',D.TIN,IF(D.SSS!='',D.SSS,IF(D.GSIS!='',D.GSIS,IF(D.PhilHealth!='',D.PhilHealth,IF(D.Senior!='',D.Senior,IF(D.UMID!='',D.UMID,IF(D.SEC!='',D.SEC,IF(D.DTI!='',D.DTI,IF(D.CDA!='',D.CDA,IF(D.Cooperative!='',D.Cooperative,'')))))))))),'-','') AS 'Identification 1: Number',"
                SQL &= "    '' AS 'Identification 2: Type',"
                SQL &= "    '' AS 'Identification 2: Number',"
                SQL &= "    '' AS 'Identification 3: Type',"
                SQL &= "    '' AS 'Identification 3: Number',"
                SQL &= "    IF(D.Drivers!='',10,IF(D.VIN!='',11,IF(D.Passport!='',12,IF(D.PRC!='',13,IF(D.NBI!='',14,IF(D.Police!='',15,IF(D.Postal!='',16,IF(D.Barangay!='',17,IF(D.OWWA!='',18,IF(D.OFW!='',19,IF(D.Seaman!='',20,IF(D.PNP!='',21,IF(D.AFP!='',22,IF(D.HDMF!='',23,IF(D.PWD!='',24,IF(D.DSWD!='',25,IF(D.ACR!='',26,IF(D.DTI_Business!='',27,IF(D.IBP!='',28,IF(D.FireArms!='',29,IF(D.Government!='',30,IF(D.Diplomat!='',31,IF(D.`National`!='',32,IF(D.`Work`!='',33,IF(D.GOCC!='',34,IF(D.PLRA!='',35,IF(D.Major!='',36,IF(D.Media!='',37,IF(D.Student!='',38,IF(D.SIRV!='',39,'')))))))))))))))))))))))))))))) AS 'ID 1: Type',"
                SQL &= "    REPLACE(IF(D.Drivers!='',D.Drivers,IF(D.VIN!='',D.VIN,IF(D.Passport!='',D.Passport,IF(D.PRC!='',D.PRC,IF(D.NBI!='',D.NBI,IF(D.Police!='',D.Police,IF(D.Postal!='',D.Postal,IF(D.Barangay!='',D.Barangay,IF(D.OWWA!='',D.OWWA,IF(D.OFW!='',D.OFW,IF(D.Seaman!='',D.Seaman,IF(D.PNP!='',D.PNP,IF(D.AFP!='',D.AFP,IF(D.HDMF!='',D.HDMF,IF(D.PWD!='',D.PWD,IF(D.DSWD!='',D.DSWD,IF(D.ACR!='',D.ACR,IF(D.DTI_Business!='',D.DTI_Business,IF(D.IBP!='',D.IBP,IF(D.FireArms!='',D.FireArms,IF(D.Government!='',D.Government,IF(D.Diplomat!='',D.Diplomat,IF(D.`National`!='',D.`National`,IF(D.`Work`!='',D.`Work`,IF(D.GOCC!='',D.GOCC,IF(D.PLRA!='',D.PLRA,IF(D.Major!='',D.Major,IF(D.Media!='',D.Media,IF(D.Student!='',D.Student,IF(D.SIRV!='',D.SIRV,'')))))))))))))))))))))))))))))),'-','') AS 'ID 1: Number',"
                SQL &= "    '' AS 'ID 1: IssuedDate',"
                SQL &= "    IF(D.Drivers!='','PH',IF(D.VIN!='','PH',IF(D.Passport!='','PH',IF(D.PRC!='','PH',IF(D.NBI!='','PH',IF(D.Police!='','PH',IF(D.Postal!='','PH',IF(D.Barangay!='','PH',IF(D.OWWA!='','PH',IF(D.OFW!='','PH',IF(D.Seaman!='','PH',IF(D.PNP!='','PH',IF(D.AFP!='','PH',IF(D.HDMF!='','PH',IF(D.PWD!='','PH',IF(D.DSWD!='','PH',IF(D.ACR!='','PH',IF(D.DTI_Business!='','PH',IF(D.IBP!='','PH',IF(D.FireArms!='','PH',IF(D.Government!='','PH',IF(D.Diplomat!='','PH',IF(D.`National`!='','PH',IF(D.`Work`!='','PH',IF(D.GOCC!='','PH',IF(D.PLRA!='','PH',IF(D.Major!='','PH',IF(D.Media!='','PH',IF(D.Student!='','PH',IF(D.SIRV!='','PH','')))))))))))))))))))))))))))))) AS 'ID 1: IssuedCountry',"
                SQL &= "    IF(D.Drivers!='',DATE_FORMAT(D.dDrivers,'%d%m%Y'),IF(D.VIN!='',DATE_FORMAT(D.dVIN,'%d%m%Y'),IF(D.Passport!='',DATE_FORMAT(D.dPassport,'%d%m%Y'),IF(D.PRC!='',DATE_FORMAT(D.dPRC,'%d%m%Y'),IF(D.NBI!='',DATE_FORMAT(D.dNBI,'%d%m%Y'),IF(D.Police!='',DATE_FORMAT(D.dPolice,'%d%m%Y'),IF(D.Postal!='',DATE_FORMAT(D.dPostal,'%d%m%Y'),IF(D.Barangay!='',DATE_FORMAT(D.dBarangay,'%d%m%Y'),IF(D.OWWA!='',DATE_FORMAT(D.dOWWA,'%d%m%Y'),IF(D.OFW!='',DATE_FORMAT(D.dOFW,'%d%m%Y'),IF(D.Seaman!='',DATE_FORMAT(D.dSeaman,'%d%m%Y'),IF(D.PNP!='',DATE_FORMAT(D.dPNP,'%d%m%Y'),IF(D.AFP!='',DATE_FORMAT(D.dAFP,'%d%m%Y'),IF(D.HDMF!='',DATE_FORMAT(D.dHDMF,'%d%m%Y'),IF(D.PWD!='',DATE_FORMAT(D.dPWD,'%d%m%Y'),IF(D.DSWD!='',DATE_FORMAT(D.dDSWD,'%d%m%Y'),IF(D.ACR!='',DATE_FORMAT(D.dACR,'%d%m%Y'),IF(D.DTI_Business!='',DATE_FORMAT(D.dDTI_Business,'%d%m%Y'),IF(D.IBP!='',DATE_FORMAT(D.dIBP,'%d%m%Y'),IF(D.FireArms!='',DATE_FORMAT(D.dFireArms,'%d%m%Y'),IF(D.Government!='',DATE_FORMAT(D.dGovernment,'%d%m%Y'),IF(D.Diplomat!='',DATE_FORMAT(D.dDiplomat,'%d%m%Y'),IF(D.`National`!='',DATE_FORMAT(D.`dNational`,'%d%m%Y'),IF(D.`Work`!='',DATE_FORMAT(D.`dWork`,'%d%m%Y'),IF(D.GOCC!='',DATE_FORMAT(D.dGOCC,'%d%m%Y'),IF(D.PLRA!='',DATE_FORMAT(D.dPLRA,'%d%m%Y'),IF(D.Major!='',DATE_FORMAT(D.dMajor,'%d%m%Y'),IF(D.Media!='',DATE_FORMAT(D.dMedia,'%d%m%Y'),IF(D.Student!='',DATE_FORMAT(D.dStudent,'%d%m%Y'),IF(D.SIRV!='',DATE_FORMAT(D.dSIRV,'%d%m%Y'),'')))))))))))))))))))))))))))))) AS 'ID 1: ExpiryDate',"
                SQL &= "    '' AS 'ID 1: Issued By',"
                SQL &= "    '' AS 'ID 2: Type',"
                SQL &= "    '' AS 'ID 2: Number',"
                SQL &= "    '' AS 'ID 2: IssuedDate',"
                SQL &= "    '' AS 'ID 2: IssuedCountry',"
                SQL &= "    '' AS 'ID 2: ExpiryDate',"
                SQL &= "    '' AS 'ID 2: Issued By',"
                SQL &= "    '' AS 'ID 3: Type',"
                SQL &= "    '' AS 'ID 3: Number',"
                SQL &= "    '' AS 'ID 3: IssuedDate',"
                SQL &= "    '' AS 'ID 3: IssuedCountry',"
                SQL &= "    '' AS 'ID 3: ExpiryDate',"
                SQL &= "    '' AS 'ID 3: Issued By',"
                SQL &= "    IF(B.Mobile_B!='',3,IF(B.Telephone_B!='',1,'')) AS 'Contact 1: Type',"
                SQL &= "    IF(B.Mobile_B!='',B.Mobile_B,IF(B.Telephone_B!='',B.Telephone_B,'')) AS 'Contact 1: Value',"
                SQL &= "    '' AS 'Contact 2: Type',"
                SQL &= "    '' AS 'Contact 2: Value',"
                SQL &= "    B.Employer_B AS 'Employment: Trade Name',"
                SQL &= "    '' AS 'Employment: TIN',"
                SQL &= "    B.EmployerTelephone_B AS 'Employment: Phone Number',"
                SQL &= "    '' AS 'Employment: PSIC',"
                SQL &= "    B.Monthly_B AS 'Employment: GrossIncome',"
                SQL &= "    'M' AS 'Employment: Annual/Monthly Indicator',"
                SQL &= "    'PHP' AS 'Employment: Currency',"
                SQL &= "    IF(B.EmploymentStat_B='Permanent',1,IF(B.EmploymentStat_B='Temporary',2,IF(B.EmploymentStat_B='Casual',9,''))) AS 'Employment: OccupationStatus',"
                SQL &= "    DATE_FORMAT(B.Hired_B,'%d%m%Y') AS 'Employment: DateHiredFrom',"
                SQL &= "    '' AS 'Employment: DateHiredTo',"
                SQL &= "    '' AS 'Employment: Occupation',"
                SQL &= "    B.BusinessName_B AS 'Sole Trader: TradeName',"
                SQL &= "    'MI' AS 'Sole Trader 1: Address Type',"
                SQL &= "    B.BusinessAddress_B AS 'Sole Trader 1: FullAddress',"
                SQL &= "    '' AS 'Sole Trader 1: StreetNo',"
                SQL &= "    '' AS 'Sole Trader 1: PostalCode',"
                SQL &= "    '' AS 'Sole Trader 1: Subdivision',"
                SQL &= "    '' AS 'Sole Trader 1: Barangay',"
                SQL &= "    '' AS 'Sole Trader 1: City',"
                SQL &= "    '' AS 'Sole Trader 1: Province',"
                SQL &= "    '' AS 'Sole Trader 1: Country',"
                SQL &= "    '' AS 'Sole Trader 1: House Owner/Lessee',"
                SQL &= "    '' AS 'Sole Trader 1: Occupied Since',"
                SQL &= "    '' AS 'Sole Trader 2: Address Type',"
                SQL &= "    '' AS 'Sole Trader 2: FullAddress',"
                SQL &= "    '' AS 'Sole Trader 2: StreetNo',"
                SQL &= "    '' AS 'Sole Trader 2: PostalCode',"
                SQL &= "    '' AS 'Sole Trader 2: Subdivision',"
                SQL &= "    '' AS 'Sole Trader 2: Barangay',"
                SQL &= "    '' AS 'Sole Trader 2: City',"
                SQL &= "    '' AS 'Sole Trader 2: Province',"
                SQL &= "    '' AS 'Sole Trader 2: Country',"
                SQL &= "    '' AS 'Sole Trader 2: House Owner/Lessee',"
                SQL &= "    '' AS 'Sole Trader 2: Occupied Since',"
                SQL &= "    '' AS 'Sole Trader 1:  Identification Type',"
                SQL &= "    '' AS 'Sole Trader 1:  Identification Number',"
                SQL &= "    '' AS 'Sole Trader 2:  Identification Type',"
                SQL &= "    '' AS 'Sole Trader 2: Identification Number',"
                SQL &= "    B.BusinessTelephone_B AS 'Sole Trader 1: Contact Type',"
                SQL &= "    '' AS 'Sole Trader 1: Contact Value',"
                SQL &= "    '' AS 'Sole Trader 2: Contact Type',"
                SQL &= "    '' AS 'Sole Trader 2: Contact Value'"
                SQL &= " FROM profile_borrower B "
                SQL &= " LEFT JOIN profile_spouse S ON B.BorrowerID = S.BorrowerID"
                SQL &= " LEFT JOIN profile_borrowerid D ON B.BorrowerID = D.BorrowerID"
                SQL &= String.Format("    WHERE FIND_IN_SET(B.Branch_ID,'{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID))
                If cbxAll.Checked Then
                Else
                    SQL &= String.Format("    AND DATE(B.timestamp) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
                End If
                GridControl3.DataSource = DataSource(SQL)

                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\CIC-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".xlsx"
                GridView3.BestFitColumns()
                GridView3.OptionsPrint.AutoWidth = False
                GridControl3.ExportToXlsx(FName)
                MsgBox("Successfully Saved! File will open automatically.", MsgBoxStyle.Information, "Info")
                Process.Start(FName)
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView1.GetFocusedRowCellValue("Borrowers ID") = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                .Type = "Borrower's Attachment I"
                .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
                .BorrowerNumber = GridView1.GetFocusedRowCellValue("Borrowers ID")
                .ID = GridView1.GetFocusedRowCellValue("Borrowers ID")
            Else
                Try
                    If GridView2.GetFocusedRowCellValue("Borrowers ID") = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                .Type = "Borrower's Attachment C"
                .TotalImage = GridView2.GetFocusedRowCellValue("Attach")
                .BorrowerNumber = GridView2.GetFocusedRowCellValue("Borrowers ID")
                .ID = GridView2.GetFocusedRowCellValue("Borrowers ID")
            End If
            Dim Result = .ShowDialog
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If Result = DialogResult.OK Then
                    GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
                ElseIf Result = DialogResult.Yes Then
                    GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
                End If
            Else
                If Result = DialogResult.OK Then
                    GridView2.SetFocusedRowCellValue("Attach", .TotalImage)
                ElseIf Result = DialogResult.Yes Then
                    GridView2.SetFocusedRowCellValue("Attach", .TotalImage)
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxAdvanced_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdvanced.CheckedChanged
        If cbxAdvanced.Checked Then
            With FrmAdvancedSearch
                If SuperTabControl1.SelectedTabIndex = 0 Then
                    .lblFirm.Visible = False
                    .cbxMicro.Visible = False
                    .cbxSmall.Visible = False
                    .cbxMedium.Visible = False
                    .cbxLarge.Visible = False

                    .lblAge.Visible = True
                    .iFrom.Visible = True
                    .lblTo.Visible = True
                    .iTo.Visible = True

                    .lblGender.Visible = True
                    .cbxMale_B.Visible = True
                    .cbxFemale_B.Visible = True

                    .lblCivil.Visible = True
                    .cbxSingle_B.Visible = True
                    .cbxMarried_B.Visible = True
                    .cbxSeparated_B.Visible = True
                    .cbxWidowed_B.Visible = True
                ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                    .lblFirm.Visible = True
                    .cbxMicro.Visible = True
                    .cbxSmall.Visible = True
                    .cbxMedium.Visible = True
                    .cbxLarge.Visible = True

                    .lblAge.Visible = False
                    .iFrom.Visible = False
                    .lblTo.Visible = False
                    .iTo.Visible = False

                    .lblGender.Visible = False
                    .cbxMale_B.Visible = False
                    .cbxFemale_B.Visible = False

                    .lblCivil.Visible = False
                    .cbxSingle_B.Visible = False
                    .cbxMarried_B.Visible = False
                    .cbxSeparated_B.Visible = False
                    .cbxWidowed_B.Visible = False
                End If
                .ShowDialog()
            End With
            GridColumn20.Visible = True
            GridColumn21.Visible = True
        Else
            GridColumn20.Visible = False
            GridColumn21.Visible = False
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "BLOCKED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "BLOCKED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub BtnBlock_Click(sender As Object, e As EventArgs) Handles btnBlock.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            Try
                If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                ElseIf If(GridView1.GetFocusedRowCellValue("branch_code") <> Branch_Code, If(DataObject(String.Format("SELECT CreditNumber FROM credit_application WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND PaymentRequest IN ('CLOSED','RELEASED') LIMIT 1;", GridView1.GetFocusedRowCellValue("Borrowers ID"))) = "", True, False), False) Then
                    MsgBox("Selected borrower is from different Branch or dont have a transaction with this branch.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim SQL As String
            If GridView1.GetFocusedRowCellValue("Status") = "BLOCKED" Then
                If MsgBoxYes("Are you sure you want to unblock this borrower?") = MsgBoxResult.Yes Then
                    SQL = String.Format("UPDATE profile_borrower SET `Status` = 'ACTIVE', BlockedBranchID = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), Branch_ID)
                    DataObject(SQL)
                    Logs("Borrowers List", "Unlock", String.Format("Unblocked borrower {0}.", GridView1.GetFocusedRowCellValue("Borrower")), "", "", "", "")
                    MsgBox("Successfully Unblocked!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes("Are you sure you want to block this borrower?") = MsgBoxResult.Yes Then
                    SQL = String.Format("UPDATE profile_borrower SET `Status` = 'BLOCKED', BlockedBranchID = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), Branch_ID)
                    DataObject(SQL)
                    Logs("Borrowers List", "Block", String.Format("Blocked borrower {0}.", GridView1.GetFocusedRowCellValue("Borrower")), "", "", "", "")
                    MsgBox("Successfully Blocked!", MsgBoxStyle.Information, "Info")
                End If
            End If
            LoadData()
        Else
            Try
                If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                ElseIf If(GridView2.GetFocusedRowCellValue("branch_code") <> Branch_Code, If(DataObject(String.Format("SELECT CreditNumber FROM credit_application WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND PaymentRequest IN ('CLOSED','RELEASED') LIMIT 1;", GridView2.GetFocusedRowCellValue("Borrowers ID"))) = "", True, False), False) Then
                    MsgBox("Selected borrower is from different Branch or dont have a transaction with this branch.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim SQL As String
            If GridView2.GetFocusedRowCellValue("Status") = "BLOCKED" Then
                If MsgBoxYes("Are you sure you want to unblock this borrower?") = MsgBoxResult.Yes Then
                    SQL = String.Format("UPDATE profile_corporation SET `Status` = 'ACTIVE', BlockedBranchID = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), Branch_ID)
                    DataObject(SQL)
                    Logs("Borrowers List", "Unblocked", String.Format("Unblocked borrower {0}.", GridView2.GetFocusedRowCellValue("Trade Name")), "", "", "", "")
                    MsgBox("Successfully Unblocked!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes("Are you sure you want to block this borrower?") = MsgBoxResult.Yes Then
                    SQL = String.Format("UPDATE profile_corporation SET `Status` = 'BLOCKED', BlockedBranchID = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), Branch_ID)
                    DataObject(SQL)
                    Logs("Borrowers List", "Block", String.Format("Blocked borrower {0}.", GridView2.GetFocusedRowCellValue("Trade Name")), "", "", "", "")
                    MsgBox("Successfully Blocked!", MsgBoxStyle.Information, "Info")
                End If
            End If
            LoadData()
        End If
    End Sub

    Private Sub IBlock_Click(sender As Object, e As EventArgs) Handles iBlock.Click
        btnBlock.PerformClick()
    End Sub

    Private Sub IAttach_Click(sender As Object, e As EventArgs) Handles iAttach.Click
        btnAttach.PerformClick()
    End Sub

    Private Sub IHistory_Click(sender As Object, e As EventArgs) Handles iHistory.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Try
                If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim History As New FrmBorrowersHistory
            With History
                .BorrowerID = GridView1.GetFocusedRowCellValue("Borrowers ID")
                If GridView1.GetFocusedRowCellValue("branch_code") = Branch_Code Then
                    .SameBranch = True
                Else
                    .SameBranch = False
                End If
                .ShowDialog()
                .Dispose()
            End With
        Else
            Try
                If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim History As New FrmBorrowersHistory
            With History
                .Corporate = True
                .BorrowerID = GridView2.GetFocusedRowCellValue("Borrowers ID")
                If GridView2.GetFocusedRowCellValue("branch_code") = Branch_Code Then
                    .SameBranch = True
                Else
                    .SameBranch = False
                End If
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Try
            If GridView1.GetFocusedRowCellValue("Status") = "BLOCKED" Then
                iBlock.Text = "Unblock"
                btnBlock.Text = "Un&block"
            Else
                iBlock.Text = "Block"
                btnBlock.Text = "&Block"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
        Try
            If GridView2.GetFocusedRowCellValue("Status") = "BLOCKED" Then
                iBlock.Text = "Unblock"
                btnBlock.Text = "Un&block"
            Else
                iBlock.Text = "Block"
                btnBlock.Text = "&Block"
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class