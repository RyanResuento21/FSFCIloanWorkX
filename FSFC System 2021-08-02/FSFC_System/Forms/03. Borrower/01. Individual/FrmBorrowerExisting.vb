Public Class FrmBorrowerExisting

    Dim FirstLoad As Boolean
    Public Type As String
    Public From_CoMaker As Boolean
    Public CoMaker As DataTable
    Public B_Type As String
    Public BorrowerID As String
    Public ReferenceID As String

    Private Sub FrmBorrowerExisting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
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

        LoadData()
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblBorrower, LabelX1})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B})

            GetComboBoxFontSettings({cbxBorrower, CbxPrefix_B, cbxSuffix_B})

            GetButtonFontSettings({btnSelect, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Borrower Existing - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = ""
        If Type = "Borrower" Then
            SQL = String.Format("SELECT ID, Prefix_C, FirstN_C, MiddleN_C, LastN_C, Suffix_C, CONCAT(IF(FirstN_C = '','',CONCAT(FirstN_C, ' ')), IF(MiddleN_C = '','',CONCAT(MiddleN_C, ' ')), IF(LastN_C = '','',CONCAT(LastN_C, ' ')), Suffix_C) AS 'Name', Branch_ID, ReferenceID, (SELECT `status` FROM profile_borrower WHERE profile_borrower.BorrowerID = credit_application_comaker.BorrowerID) AS 'Borrower Status', Borrower(BorrowerID) AS 'Borrower Name' FROM credit_application_comaker WHERE `status` = 'ACTIVE' GROUP BY `Name` ORDER BY `Name`", Branch_ID)
        ElseIf Type = "CoMaker1" Or Type = "CoMaker2" Then
            SQL = String.Format(" SELECT * FROM (SELECT BorrowerID AS 'ID', Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Name', 'Borrower', Branch_ID, BorrowerID AS 'ReferenceID', '' AS 'Borrower Status', '' AS 'Borrower Name' FROM profile_borrower WHERE `status` = 'ACTIVE' AND BorrowerID != '{1}'", If(Multiple_ID = "", Branch_ID, Multiple_ID), BorrowerID)
            SQL &= " UNION ALL"
            SQL &= String.Format(" SELECT ID, Prefix_C, FirstN_C, MiddleN_C, LastN_C, Suffix_C, CONCAT(IF(FirstN_C = '','',CONCAT(FirstN_C, ' ')), IF(MiddleN_C = '','',CONCAT(MiddleN_C, ' ')), IF(LastN_C = '','',CONCAT(LastN_C, ' ')), Suffix_C) AS 'Name', 'CoMaker', Branch_ID, ReferenceID, (SELECT `status` FROM profile_borrower WHERE profile_borrower.BorrowerID = credit_application_comaker.BorrowerID) AS 'Borrower Status', Borrower(BorrowerID) AS 'Borrower Name' FROM credit_application_comaker WHERE `status` = 'ACTIVE' AND ReferenceID != '') A GROUP BY `Name` ORDER BY `Name`", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        With cbxBorrower
            .DisplayMember = "Name"
            .ValueMember = "ID"
            .DataSource = DataSource(SQL)
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            FirstLoad = True
            LoadData()
            cbxBorrower.SelectedIndex = -1
            CbxPrefix_B.Text = ""
            TxtFirstN_B.Text = ""
            TxtMiddleN_B.Text = ""
            TxtLastN_B.Text = ""
            cbxSuffix_B.Text = ""
            FirstLoad = False
        End If
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If btnSelect.DialogResult = DialogResult.OK Then
        Else
            If cbxBorrower.SelectedIndex = -1 Or cbxBorrower.Text = "" Then
                MsgBox("Please select a comaker first.", MsgBoxStyle.Information, "Info")
                cbxBorrower.DroppedDown = True
                Exit Sub
            End If
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            If Branch_ID = drv("Branch_ID") Then
            Else
                If MsgBoxYes(String.Format("Selected Borrower/Co-Maker is from {0} Branch, would you like to proceed?", DataObject(String.Format("SELECT Branch('{0}');", drv("Branch_ID"))))) = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            End If
            If drv("Borrower Status") = "BLOCKED" Then
                MsgBox(String.Format("{0} is a CoMaker of a blacklisted borrower named {1}.", cbxBorrower.Text, drv("Borrower Name")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim Count_Active As Integer = 0
            Dim CreditNumberDT As DataTable = DataSource(String.Format("SELECT CreditNumber FROM credit_application_comaker WHERE `status` = 'ACTIVE' AND ReferenceID = '{0}';", drv("ReferenceID")))
            Dim CreditNumberComakers As String = ""
            For x As Integer = 0 To CreditNumberDT.Rows.Count - 1
                CreditNumberComakers &= CreditNumberDT(x)("CreditNumber") & "' ,'"
                If x = CreditNumberDT.Rows.Count - 1 Then
                    CreditNumberComakers = "'" & CreditNumberComakers.Substring(0, CreditNumberComakers.Length - 2)
                End If
            Next
            If CreditNumberComakers.Trim = "" Then
            Else
                Count_Active = DataObject(String.Format("SELECT COUNT(ID) FROM credit_application WHERE `status` = 'ACTIVE' AND PaymentRequest != 'CLOSED' AND CreditNumber IN ({0});", CreditNumberComakers))
                If Count_Active > 3 Then
                    If MsgBoxYes(String.Format("Selected Borrower/Co-Maker is already a COMAKER for {0} ACTIVE/RELEASING Accounts, would you like to proceed?", Count_Active)) = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                End If
            End If
            Dim SQL As String = ""
            If From_CoMaker Then '*****S H O R T C U T    F R O M   C O M A K E R**********************************
                If drv("Borrower") = "Borrower" Then
                    SQL = "SELECT BorrowerID, BorrowerID AS 'ReferenceID', Prefix_B AS 'Prefix',"
                    SQL &= "    FirstN_B AS 'FirstN',"
                    SQL &= "    MiddleN_B AS 'MiddleN',"
                    SQL &= "    LastN_B AS 'LastN',"
                    SQL &= "    Suffix_B AS 'Suffix',"
                    SQL &= "    NoC_B AS 'NoC',"
                    SQL &= "    StreetC_B AS 'StreetC',"
                    SQL &= "    BarangayC_B AS 'BarangayC',"
                    SQL &= "    AddressC_B AS 'AddressC',"
                    SQL &= "    NoP_B AS 'NoP',"
                    SQL &= "    StreetP_B AS 'StreetP',"
                    SQL &= "    BarangayP_B AS 'BarangayP',"
                    SQL &= "    AddressP_B AS 'AddressP',"
                    SQL &= "    Birth_B AS 'Birth',"
                    SQL &= "    PlaceBirth_B AS 'PlaceBirth',"
                    SQL &= "    Gender_B AS 'Gender',"
                    SQL &= "    Civil_B AS 'Civil',"
                    SQL &= "    Citizenship_B AS 'Citizenship',"
                    SQL &= "    TIN_B AS 'TIN',"
                    SQL &= "    Telephone_B AS 'Telephone',"
                    SQL &= "    SSS_B AS 'SSS',"
                    SQL &= "    Mobile_B AS 'Mobile',"
                    SQL &= "    Email_B AS 'Email',"
                    SQL &= "    House_B AS 'House',"
                    SQL &= "    Rent_B AS 'Rent',"
                    SQL &= "    Employer_B AS 'Employer',"
                    SQL &= "    EmployerAddress_B AS 'EmployerAddress',"
                    SQL &= "    EmployerTelephone_B AS 'EmployerTelephone',"
                    SQL &= "    Position_B AS 'Position',"
                    SQL &= "    EmploymentStat_B AS 'EmploymentStat',"
                    SQL &= "    Hired_B AS 'Hired',"
                    SQL &= "    Supervisor_B AS 'Supervisor',"
                    SQL &= "    Monthly_B AS 'Monthly',"
                    SQL &= "    BusinessName_B AS 'BusinessName',"
                    SQL &= "    BusinessAddress_B AS 'BusinessAddress',"
                    SQL &= "    BusinessTelephone_B AS 'BusinessTelephone',"
                    SQL &= "    NatureBusiness_B AS 'NatureBusiness',"
                    SQL &= "    YrsOperation_B AS 'YrsOperation',"
                    SQL &= "    BusinessIncome_B AS 'BusinessIncome',"
                    SQL &= "    NoEmployees_B AS 'NoEmployees',"
                    SQL &= "    Capital_B AS 'Capital',"
                    SQL &= "    Area_B AS 'Area',"
                    SQL &= "    Expiry_B AS 'Expiry',"
                    SQL &= "    Outlet_B AS 'Outlet',"
                    SQL &= "    OtherIncome_B AS 'OtherIncome',"
                    SQL &= "    `OtherIncome_B-Amount` AS 'OtherIncome-Amount', branch_code"
                    SQL &= String.Format(" FROM profile_borrower WHERE BorrowerID = '{0}'", cbxBorrower.SelectedValue)
                ElseIf drv("Borrower") = "CoMaker" Then
                    SQL = "SELECT BorrowerID, ReferenceID, Prefix_C AS 'Prefix',"
                    SQL &= "    FirstN_C AS 'FirstN',"
                    SQL &= "    MiddleN_C AS 'MiddleN',"
                    SQL &= "    LastN_C AS 'LastN',"
                    SQL &= "    Suffix_C AS 'Suffix',"
                    SQL &= "    NoC_C AS 'NoC',"
                    SQL &= "    StreetC_C AS 'StreetC',"
                    SQL &= "    BarangayC_C AS 'BarangayC',"
                    SQL &= "    AddressC_C AS 'AddressC',"
                    SQL &= "    NoP_C AS 'NoP',"
                    SQL &= "    StreetP_C AS 'StreetP',"
                    SQL &= "    BarangayP_C AS 'BarangayP',"
                    SQL &= "    AddressP_C AS 'AddressP',"
                    SQL &= "    Birth_C AS 'Birth',"
                    SQL &= "    PlaceBirth_C AS 'PlaceBirth',"
                    SQL &= "    Gender_C AS 'Gender',"
                    SQL &= "    Civil_C AS 'Civil',"
                    SQL &= "    Citizenship_C AS 'Citizenship',"
                    SQL &= "    TIN_C AS 'TIN',"
                    SQL &= "    Telephone_C AS 'Telephone',"
                    SQL &= "    SSS_C AS 'SSS',"
                    SQL &= "    Mobile_C AS 'Mobile',"
                    SQL &= "    Email_C AS 'Email',"
                    SQL &= "    House_C AS 'House',"
                    SQL &= "    Rent_C AS 'Rent',"
                    SQL &= "    Employer_C AS 'Employer',"
                    SQL &= "    EmployerAddress_C AS 'EmployerAddress',"
                    SQL &= "    EmployerTelephone_C AS 'EmployerTelephone',"
                    SQL &= "    Position_C AS 'Position',"
                    SQL &= "    EmploymentStat_C AS 'EmploymentStat',"
                    SQL &= "    Hired_C AS 'Hired',"
                    SQL &= "    Supervisor_C AS 'Supervisor',"
                    SQL &= "    Monthly_C AS 'Monthly',"
                    SQL &= "    BusinessName_C AS 'BusinessName',"
                    SQL &= "    BusinessAddress_C AS 'BusinessAddress',"
                    SQL &= "    BusinessTelephone_C AS 'BusinessTelephone',"
                    SQL &= "    NatureBusiness_C AS 'NatureBusiness',"
                    SQL &= "    YrsOperation_C AS 'YrsOperation',"
                    SQL &= "    BusinessIncome_C AS 'BusinessIncome',"
                    SQL &= "    NoEmployees_C AS 'NoEmployees',"
                    SQL &= "    Capital_C AS 'Capital',"
                    SQL &= "    Area_C AS 'Area',"
                    SQL &= "    Expiry_C AS 'Expiry',"
                    SQL &= "    Outlet_C AS 'Outlet',"
                    SQL &= "    OtherIncome_C AS 'OtherIncome',"
                    SQL &= "    `OtherIncome_C-Amount` AS 'OtherIncome-Amount'"
                    SQL &= String.Format(" FROM credit_application_comaker WHERE ID = '{0}' AND FirstN_C = '{1}' AND LastN_C = '{2}' AND Suffix_C = '{3}'", cbxBorrower.SelectedValue, TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text)
                End If
                B_Type = drv("Borrower")
                CoMaker = DataSource(SQL)
                btnSelect.DialogResult = DialogResult.OK
                btnSelect.PerformClick()
                '*****S H O R T C U T    F R O M   C O M A K E R**********************************
            Else
                If Type = "Borrower" Then
                    If MsgBoxYes(String.Format("Are you sure you want to select {0}? {1} information will be automatically fill up at borrower form.", cbxBorrower.Text, "His/Her")) = MsgBoxResult.Yes Then
                        SQL = "SELECT BorrowerID, ReferenceID,"
                        SQL &= " Prefix_C, "
                        SQL &= " FirstN_C,"
                        SQL &= " MiddleN_C,"
                        SQL &= " LastN_C,"
                        SQL &= " Suffix_C,"
                        SQL &= " NoC_C,"
                        SQL &= " StreetC_C,"
                        SQL &= " BarangayC_C,"
                        SQL &= " AddressC_C,"
                        SQL &= " NoP_C,"
                        SQL &= " StreetP_C,"
                        SQL &= " BarangayP_C,"
                        SQL &= " AddressP_C,"
                        SQL &= " Birth_C,"
                        SQL &= " PlaceBirth_C,"
                        SQL &= " Gender_C,"
                        SQL &= " Civil_C,"
                        SQL &= " Citizenship_C,"
                        SQL &= " TIN_C,"
                        SQL &= " Telephone_C,"
                        SQL &= " SSS_C,"
                        SQL &= " Mobile_C,"
                        SQL &= " Email_C,"
                        SQL &= " House_C,"
                        SQL &= " Rent_C,"
                        SQL &= " Employer_C,"
                        SQL &= " EmployerAddress_C,"
                        SQL &= " EmployerTelephone_C,"
                        SQL &= " Position_C,"
                        SQL &= " EmploymentStat_C,"
                        SQL &= " Hired_C,"
                        SQL &= " Supervisor_C,"
                        SQL &= " Monthly_C,"
                        SQL &= " BusinessName_C,"
                        SQL &= " BusinessAddress_C,"
                        SQL &= " BusinessTelephone_C,"
                        SQL &= " NatureBusiness_C,"
                        SQL &= " YrsOperation_C,"
                        SQL &= " BusinessIncome_C,"
                        SQL &= " NoEmployees_C,"
                        SQL &= " Capital_C,"
                        SQL &= " Area_C,"
                        SQL &= " Expiry_C,"
                        SQL &= " Outlet_C,"
                        SQL &= " OtherIncome_C,"
                        SQL &= " `OtherIncome_C-Amount`"
                        SQL &= String.Format(" FROM credit_application_comaker WHERE ID = '{0}';", cbxBorrower.SelectedValue)
                        CoMaker = DataSource(SQL)

                        With FrmBorrower
                            .CbxPrefix_B.Text = CoMaker(0)("Prefix_C")
                            .TxtFirstN_B.Text = CoMaker(0)("FirstN_C")
                            .TxtMiddleN_B.Text = CoMaker(0)("MiddleN_C")
                            .TxtLastN_B.Text = CoMaker(0)("LastN_C")
                            .cbxSuffix_B.Text = CoMaker(0)("Suffix_C")
                            .txtNoC_B.Text = CoMaker(0)("NoC_C")
                            .txtStreetC_B.Text = CoMaker(0)("StreetC_C")
                            .txtBarangayC_B.Text = CoMaker(0)("BarangayC_C")
                            .cbxAddressC_B.Text = CoMaker(0)("AddressC_C")
                            .txtNoP_B.Text = CoMaker(0)("NoP_C")
                            .txtStreetP_B.Text = CoMaker(0)("StreetP_C")
                            .txtBarangayP_B.Text = CoMaker(0)("BarangayP_C")
                            .cbxAddressP_B.Text = CoMaker(0)("AddressP_C")
                            .DtpBirth_B.Text = CoMaker(0)("Birth_C")
                            .cbxPlaceBirth_B.Text = CoMaker(0)("PlaceBirth_C")
                            If CoMaker(0)("Gender_C") = "Male" Then
                                .cbxMale_B.Checked = True
                            ElseIf CoMaker(0)("Gender_C") = "Female" Then
                                .cbxFemale_B.Checked = True
                            End If
                            If CoMaker(0)("Civil_C") = "Single" Then
                                .cbxSingle_B.Checked = True
                            ElseIf CoMaker(0)("Civil_C") = "Married" Then
                                .cbxMarried_B.Checked = True
                            ElseIf CoMaker(0)("Civil_C") = "Separated" Then
                                .cbxSeparated_B.Checked = True
                            ElseIf CoMaker(0)("Civil_C") = "Widowed" Then
                                .cbxWidowed_B.Checked = True
                            End If
                            .cbxCitizenship_B.Text = CoMaker(0)("Citizenship_C")
                            .txtTIN_B.Text = CoMaker(0)("TIN_C")
                            .txtTelephone_B.Text = CoMaker(0)("Telephone_C")
                            .txtSSS_B.Text = CoMaker(0)("SSS_C")
                            .txtMobile_B.Text = CoMaker(0)("Mobile_C")
                            .txtEmail_B.Text = CoMaker(0)("Email_C")
                            If CoMaker(0)("House_C") = "Owned" Then
                                .cbxOwned_B.Checked = True
                            ElseIf CoMaker(0)("House_C") = "Free" Then
                                .cbxFree_B.Checked = True
                            ElseIf CoMaker(0)("House_C") = "Rented" Then
                                .cbxRented_B.Checked = True
                                .dRent_B.Value = CoMaker(0)("Rent_C")
                            End If
                            Try
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Dim DT As DataTable = DataSource(String.Format("SELECT ID FROM credit_application_comaker WHERE BOrrowerID = '{0}' AND `status` = 'ACTIVE';", CoMaker(0)("BorrowerID")))
                                If DT.Rows.Count = 1 Then
                                    TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, CoMaker(0)("BorrowerID"), "CoMaker1.jpg"))
                                Else
                                    TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, CoMaker(0)("BorrowerID"), "CoMaker2.jpg"))
                                End If
                                ResizeImages(TempPB.Image.Clone, .pb_B, 650, 500)
                                .txtPath_B.Text = "Borrower.pjg"
                                TempPB.Dispose()
                            Catch ex As Exception
                                TriggerBugReport("Borrower Existing - Select", ex.Message.ToString)
                            End Try
                            .cbxEmployer_B.Text = CoMaker(0)("Employer_C")
                            .txtEmployerAddress_B.Text = CoMaker(0)("EmployerAddress_C")
                            .txtEmployerTelephone_B.Text = CoMaker(0)("EmployerTelephone_C")
                            .cbxPosition_B.Text = CoMaker(0)("Position_C")
                            If CoMaker(0)("EmploymentStat_C") = "Casual" Then
                                .cbxCasual_B.Checked = True
                            ElseIf CoMaker(0)("EmploymentStat_C") = "Temporary" Then
                                .cbxTemporary_B.Checked = True
                            ElseIf CoMaker(0)("EmploymentStat_C") = "Permanent" Then
                                .cbxPermanent_B.Checked = True
                            End If
                            .dtpHired_B.Text = CoMaker(0)("Hired_C")
                            .txtSupervisor_B.Text = CoMaker(0)("Supervisor_C")
                            .dMonthly_B.Value = CoMaker(0)("Monthly_C")
                            .txtBusinessName_B.Text = CoMaker(0)("BusinessName_C")
                            .txtBusinessAddress_B.Text = CoMaker(0)("BusinessAddress_C")
                            .txtBusinessTelephone_B.Text = CoMaker(0)("BusinessTelephone_C")
                            .cbxNatureBusiness_B.Text = CoMaker(0)("NatureBusiness_C")
                            .iYrsOperation_B.Value = CoMaker(0)("YrsOperation_C")
                            .dBusinessIncome_B.Value = CoMaker(0)("BusinessIncome_C")
                            .iNoEmployees_B.Value = CoMaker(0)("NoEmployees_C")
                            .dCapital_B.Value = CoMaker(0)("Capital_C")
                            .txtArea_B.Text = CoMaker(0)("Area_C")
                            .dtpExpiry_B.Text = CoMaker(0)("Expiry_C")
                            .iOutlet_B.Value = CoMaker(0)("Outlet_C")
                            .txtOtherIncome_B.Text = CoMaker(0)("OtherIncome_C")
                            .dOtherIncome_B.Value = CoMaker(0)("OtherIncome_C-Amount")
                        End With
                    Else
                        Exit Sub
                    End If
                ElseIf Type = "CoMaker1" Or Type = "CoMaker2" Then
                    If MsgBoxYes(String.Format("Are you sure you want to select {0}? {1} information will be automatically fill up at CoMaker form.", cbxBorrower.Text, "His/Her")) = MsgBoxResult.Yes Then
                        If drv("Borrower") = "Borrower" Then
                            SQL = "SELECT BorrowerID, BorrowerID AS 'ReferenceID', Prefix_B AS 'Prefix',"
                            SQL &= "    FirstN_B AS 'FirstN',"
                            SQL &= "    MiddleN_B AS 'MiddleN',"
                            SQL &= "    LastN_B AS 'LastN',"
                            SQL &= "    Suffix_B AS 'Suffix',"
                            SQL &= "    NoC_B AS 'NoC',"
                            SQL &= "    StreetC_B AS 'StreetC',"
                            SQL &= "    BarangayC_B AS 'BarangayC',"
                            SQL &= "    AddressC_B AS 'AddressC',"
                            SQL &= "    NoP_B AS 'NoP',"
                            SQL &= "    StreetP_B AS 'StreetP',"
                            SQL &= "    BarangayP_B AS 'BarangayP',"
                            SQL &= "    AddressP_B AS 'AddressP',"
                            SQL &= "    Birth_B AS 'Birth',"
                            SQL &= "    PlaceBirth_B AS 'PlaceBirth',"
                            SQL &= "    Gender_B AS 'Gender',"
                            SQL &= "    Civil_B AS 'Civil',"
                            SQL &= "    Citizenship_B AS 'Citizenship',"
                            SQL &= "    TIN_B AS 'TIN',"
                            SQL &= "    Telephone_B AS 'Telephone',"
                            SQL &= "    SSS_B AS 'SSS',"
                            SQL &= "    Mobile_B AS 'Mobile',"
                            SQL &= "    Email_B AS 'Email',"
                            SQL &= "    House_B AS 'House',"
                            SQL &= "    Rent_B AS 'Rent',"
                            SQL &= "    Employer_B AS 'Employer',"
                            SQL &= "    EmployerAddress_B AS 'EmployerAddress',"
                            SQL &= "    EmployerTelephone_B AS 'EmployerTelephone',"
                            SQL &= "    Position_B AS 'Position',"
                            SQL &= "    EmploymentStat_B AS 'EmploymentStat',"
                            SQL &= "    Hired_B AS 'Hired',"
                            SQL &= "    Supervisor_B AS 'Supervisor',"
                            SQL &= "    Monthly_B AS 'Monthly',"
                            SQL &= "    BusinessName_B AS 'BusinessName',"
                            SQL &= "    BusinessAddress_B AS 'BusinessAddress',"
                            SQL &= "    BusinessTelephone_B AS 'BusinessTelephone',"
                            SQL &= "    NatureBusiness_B AS 'NatureBusiness',"
                            SQL &= "    YrsOperation_B AS 'YrsOperation',"
                            SQL &= "    BusinessIncome_B AS 'BusinessIncome',"
                            SQL &= "    NoEmployees_B AS 'NoEmployees',"
                            SQL &= "    Capital_B AS 'Capital',"
                            SQL &= "    Area_B AS 'Area',"
                            SQL &= "    Expiry_B AS 'Expiry',"
                            SQL &= "    Outlet_B AS 'Outlet',"
                            SQL &= "    OtherIncome_B AS 'OtherIncome',"
                            SQL &= "    `OtherIncome_B-Amount` AS 'OtherIncome-Amount'"
                            SQL &= String.Format(" FROM profile_borrower WHERE BorrowerID = '{0}'", cbxBorrower.SelectedValue)
                        ElseIf drv("Borrower") = "CoMaker" Then
                            SQL = "SELECT BorrowerID, ReferenceID, Prefix_C AS 'Prefix',"
                            SQL &= "    FirstN_C AS 'FirstN',"
                            SQL &= "    MiddleN_C AS 'MiddleN',"
                            SQL &= "    LastN_C AS 'LastN',"
                            SQL &= "    Suffix_C AS 'Suffix',"
                            SQL &= "    NoC_C AS 'NoC',"
                            SQL &= "    StreetC_C AS 'StreetC',"
                            SQL &= "    BarangayC_C AS 'BarangayC',"
                            SQL &= "    AddressC_C AS 'AddressC',"
                            SQL &= "    NoP_C AS 'NoP',"
                            SQL &= "    StreetP_C AS 'StreetP',"
                            SQL &= "    BarangayP_C AS 'BarangayP',"
                            SQL &= "    AddressP_C AS 'AddressP',"
                            SQL &= "    Birth_C AS 'Birth',"
                            SQL &= "    PlaceBirth_C AS 'PlaceBirth',"
                            SQL &= "    Gender_C AS 'Gender',"
                            SQL &= "    Civil_C AS 'Civil',"
                            SQL &= "    Citizenship_C AS 'Citizenship',"
                            SQL &= "    TIN_C AS 'TIN',"
                            SQL &= "    Telephone_C AS 'Telephone',"
                            SQL &= "    SSS_C AS 'SSS',"
                            SQL &= "    Mobile_C AS 'Mobile',"
                            SQL &= "    Email_C AS 'Email',"
                            SQL &= "    House_C AS 'House',"
                            SQL &= "    Rent_C AS 'Rent',"
                            SQL &= "    Employer_C AS 'Employer',"
                            SQL &= "    EmployerAddress_C AS 'EmployerAddress',"
                            SQL &= "    EmployerTelephone_C AS 'EmployerTelephone',"
                            SQL &= "    Position_C AS 'Position',"
                            SQL &= "    EmploymentStat_C AS 'EmploymentStat',"
                            SQL &= "    Hired_C AS 'Hired',"
                            SQL &= "    Supervisor_C AS 'Supervisor',"
                            SQL &= "    Monthly_C AS 'Monthly',"
                            SQL &= "    BusinessName_C AS 'BusinessName',"
                            SQL &= "    BusinessAddress_C AS 'BusinessAddress',"
                            SQL &= "    BusinessTelephone_C AS 'BusinessTelephone',"
                            SQL &= "    NatureBusiness_C AS 'NatureBusiness',"
                            SQL &= "    YrsOperation_C AS 'YrsOperation',"
                            SQL &= "    BusinessIncome_C AS 'BusinessIncome',"
                            SQL &= "    NoEmployees_C AS 'NoEmployees',"
                            SQL &= "    Capital_C AS 'Capital',"
                            SQL &= "    Area_C AS 'Area',"
                            SQL &= "    Expiry_C AS 'Expiry',"
                            SQL &= "    Outlet_C AS 'Outlet',"
                            SQL &= "    OtherIncome_C AS 'OtherIncome',"
                            SQL &= "    `OtherIncome_C-Amount` AS 'OtherIncome-Amount'"
                            SQL &= String.Format(" FROM credit_application_comaker WHERE ID = '{0}' AND FirstN_C = '{1}' AND LastN_C = '{2}' AND Suffix_C = '{3}'", cbxBorrower.SelectedValue, TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text)
                        End If
                        CoMaker = DataSource(SQL)
                    End If
                End If
            End If
        End If
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
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

    Private Sub CbxBorrower_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBorrower.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
        If Type = "Borrower" Then
            CbxPrefix_B.Text = drv("Prefix_C")
            TxtFirstN_B.Text = drv("FirstN_C")
            TxtMiddleN_B.Text = drv("MiddleN_C")
            TxtLastN_B.Text = drv("LastN_C")
            cbxSuffix_B.Text = drv("Suffix_C")
        ElseIf Type = "CoMaker1" Or Type = "CoMaker2" Then
            CbxPrefix_B.Text = drv("Prefix_B")
            TxtFirstN_B.Text = drv("FirstN_B")
            TxtMiddleN_B.Text = drv("MiddleN_B")
            TxtLastN_B.Text = drv("LastN_B")
            cbxSuffix_B.Text = drv("Suffix_B")
        End If
    End Sub

    Private Sub CbxBorrower_TextChanged(sender As Object, e As EventArgs) Handles cbxBorrower.TextChanged
        If cbxBorrower.Text = "" Then
            CbxPrefix_B.Text = ""
            TxtFirstN_B.Text = ""
            TxtMiddleN_B.Text = ""
            TxtLastN_B.Text = ""
            cbxSuffix_B.Text = ""
        End If
    End Sub
End Class