Public Class FrmSelectBorrower

    Dim FirstLoad As Boolean
    Public CreditNumber As String
    Public CreditBorrower As String
    Public Principal As String
    Dim Code As String
    Dim Old_Code As String
    Dim BM As DataTable
    Private Sub FrmSelectBorrower_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        'Generate Code **************

        Code = GenerateOTAC()

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

        BM = GetBM(Branch_ID)
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

            GetCheckBoxFontSettings({cbxOtherBranch})

            GetButtonFontSettings({btnSelect, btnRefresh, btnCancel, btnProfile})
        Catch ex As Exception
            TriggerBugReport("Select Borrower - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = String.Format("SELECT BorrowerID, 'I' AS 'Type', Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, CONCAT('[', BorrowerID, '] ', CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B)) AS 'Name' FROM profile_borrower WHERE `status` = 'ACTIVE' AND Branch_ID LIKE '{0}'", If(cbxOtherBranch.Checked, "%", Branch_ID))
        SQL &= " UNION ALL "
        SQL &= String.Format("SELECT BorrowerID, 'C' AS 'Type', Prefix_R1, FirstN_R1, MiddleN_R1, LastN_R1, Suffix_R1, CONCAT('[', BorrowerID, '] ', TradeName) AS 'Name' FROM profile_corporation WHERE `status` = 'ACTIVE' AND Branch_ID LIKE '{0}' ORDER BY `Name`;", If(cbxOtherBranch.Checked, "%", Branch_ID))

        With cbxBorrower
            .DisplayMember = "Name"
            .ValueMember = "BorrowerID"
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

            If MsgBoxYes(String.Format("Are you sure you want to select {0} to update the borrower of the credit application {1} of {2} with amount applied of {3}.", cbxBorrower.Text, CreditNumber, CreditBorrower, Principal)) = MsgBoxResult.Yes Then
                If Code = Old_Code Then
                Else
                    Old_Code = Code
                    Dim EmailTo As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
                    Dim Msg As String = "Good day," & vbCrLf
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for changing the name of borrower for Credit Number {1} from {2} to {3} with Principal Amount of {4}.", Code, CreditNumber, CreditBorrower, cbxBorrower.Text, Principal)
                    Msg &= "Thank you!"
                    SendNotificationToBM(Branch_ID, Msg, Subject, False, False)
                End If

                Timer1.Start()
                Dim OTP As New FrmOneTimePassword
                With OTP
                    .OTP = Code
                    If .ShowDialog = DialogResult.OK Then
                        Dim Reason As String 'Reason for change
                        If FrmReason.ShowDialog = DialogResult.OK Then
                            Reason = FrmReason.txtReason.Text
                        Else
                            Exit Sub
                        End If

                        Dim SQL As String
                        Dim SQL_B As String = ""
                        Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
                        If drv("Type") = "C" Then
                            SQL_B = "SELECT"
                            SQL_B &= " CONCAT('[ ', B.BorrowerID, ' ] - ', TradeName) AS 'Name',"
                            SQL_B &= " B.*, (SELECT BusinessCenter FROM business_center WHERE ID = B.BusinessID) AS 'BusinessCenter'"
                            SQL_B &= " FROM profile_corporation B"
                            SQL_B &= String.Format(" WHERE B.BorrowerID = '{0}' GROUP BY B.BorrowerID ORDER BY B.TradeName;", cbxBorrower.SelectedValue)
                        Else
                            SQL_B = "SELECT B.BorrowerID, "
                            SQL_B &= "   CONCAT('[ ', B.BorrowerID, ' ] - ', IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')),  IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Name', CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), IF(AddressC_B = '','',CONCAT(AddressC_B, ', '))) AS 'Address',"
                            SQL_B &= "   B.*, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = B.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = B.BusinessID)) AS 'BusinessCenter',"
                            SQL_B &= "   S.*,"
                            SQL_B &= "   IFNULL(D1.Prefix_D,'') AS 'Prefix_D1',   "
                            SQL_B &= "   IFNULL(D1.FirstN_D,'') AS 'FirstN_D1',   "
                            SQL_B &= "   IFNULL(D1.MiddleN_D,'') AS 'MiddleN_D1',   "
                            SQL_B &= "   IFNULL(D1.LastN_D,'') AS 'LastN_D1',   "
                            SQL_B &= "   IFNULL(D1.Suffix_D,'') AS 'Suffix_D1',   "
                            SQL_B &= "   IFNULL(D1.Birth_D,'') AS 'Birth_D1',   "
                            SQL_B &= "   IFNULL(D1.Grade_D,'') AS 'Grade_D1',   "
                            SQL_B &= "   IFNULL(D1.School_D,'') AS 'School_D1',   "
                            SQL_B &= "   IFNULL(D1.SchoolAddress_D,'') AS 'SchoolAddress_D1',   "
                            SQL_B &= "   IFNULL(D2.Prefix_D,'') AS 'Prefix_D2',   "
                            SQL_B &= "   IFNULL(D2.FirstN_D,'') AS 'FirstN_D2',   "
                            SQL_B &= "   IFNULL(D2.MiddleN_D,'') AS 'MiddleN_D2',   "
                            SQL_B &= "   IFNULL(D2.LastN_D,'') AS 'LastN_D2',   "
                            SQL_B &= "   IFNULL(D2.Suffix_D,'') AS 'Suffix_D2',   "
                            SQL_B &= "   IFNULL(D2.Birth_D,'') AS 'Birth_D2',   "
                            SQL_B &= "   IFNULL(D2.Grade_D,'') AS 'Grade_D2',   "
                            SQL_B &= "   IFNULL(D2.School_D,'') AS 'School_D2',   "
                            SQL_B &= "   IFNULL(D2.SchoolAddress_D,'') AS 'SchoolAddress_D2',   "
                            SQL_B &= "   IFNULL(D3.Prefix_D,'') AS 'Prefix_D3',   "
                            SQL_B &= "   IFNULL(D3.FirstN_D,'') AS 'FirstN_D3',   "
                            SQL_B &= "   IFNULL(D3.MiddleN_D,'') AS 'MiddleN_D3',   "
                            SQL_B &= "   IFNULL(D3.LastN_D,'') AS 'LastN_D3',   "
                            SQL_B &= "   IFNULL(D3.Suffix_D,'') AS 'Suffix_D3',   "
                            SQL_B &= "   IFNULL(D3.Birth_D,'') AS 'Birth_D3',   "
                            SQL_B &= "   IFNULL(D3.Grade_D,'') AS 'Grade_D3',   "
                            SQL_B &= "   IFNULL(D3.School_D,'') AS 'School_D3',   "
                            SQL_B &= "   IFNULL(D3.SchoolAddress_D,'') AS 'SchoolAddress_D3',   "
                            SQL_B &= "   IFNULL(D4.Prefix_D,'') AS 'Prefix_D4',   "
                            SQL_B &= "   IFNULL(D4.FirstN_D,'') AS 'FirstN_D4',   "
                            SQL_B &= "   IFNULL(D4.MiddleN_D,'') AS 'MiddleN_D4',   "
                            SQL_B &= "   IFNULL(D4.LastN_D,'') AS 'LastN_D4',   "
                            SQL_B &= "   IFNULL(D4.Suffix_D,'') AS 'Suffix_D4',   "
                            SQL_B &= "   IFNULL(D4.Birth_D,'') AS 'Birth_D4',   "
                            SQL_B &= "   IFNULL(D4.Grade_D,'') AS 'Grade_D4',   "
                            SQL_B &= "   IFNULL(D4.School_D,'') AS 'School_D4',   "
                            SQL_B &= "   IFNULL(D4.SchoolAddress_D,'') AS 'SchoolAddress_D4' "
                            SQL_B &= " FROM profile_borrower B"
                            SQL_B &= " LEFT JOIN profile_spouse S"
                            SQL_B &= "    ON B.BorrowerID = S.BorrowerID AND S.`status` = 'ACTIVE'"
                            SQL_B &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 1) D1    "
                            SQL_B &= "    ON B.BorrowerID = D1.BorrowerID "
                            SQL_B &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 2) D2    "
                            SQL_B &= "    ON B.BorrowerID = D2.BorrowerID "
                            SQL_B &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 3) D3    "
                            SQL_B &= "    ON B.BorrowerID = D3.BorrowerID "
                            SQL_B &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 4) D4    "
                            SQL_B &= "    ON B.BorrowerID = D4.BorrowerID "
                            SQL_B &= String.Format("    WHERE B.BorrowerID = '{0}' GROUP BY B.BorrowerID ORDER BY B.LastN_B;", cbxBorrower.SelectedValue)
                        End If
                        Dim DT_Borrowers As DataTable = DataSource(SQL_B)
                        SQL = " UPDATE credit_application SET "
                        SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                        If drv("Type") = "C" Then
                            SQL &= " Prefix_B = '', "
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrowers(0)("TradeName"))
                            SQL &= " MiddleN_B = '', "
                            SQL &= " LastN_B = '', "
                            SQL &= " Suffix_B = '', "
                            SQL &= String.Format(" Prefix_S = '{0}', ", DT_Borrowers(0)("Prefix_R1"))
                            SQL &= String.Format(" FirstN_S = '{0}', ", DT_Borrowers(0)("FirstN_R1"))
                            SQL &= String.Format(" MiddleN_S = '{0}', ", DT_Borrowers(0)("MiddleN_R1"))
                            SQL &= String.Format(" LastN_S = '{0}', ", DT_Borrowers(0)("LastN_R1"))
                            SQL &= String.Format(" Suffix_S = '{0}', ", DT_Borrowers(0)("Suffix_R1"))
                            SQL &= String.Format(" Prefix_C1 = '{0}', ", DT_Borrowers(0)("Prefix_R2"))
                            SQL &= String.Format(" FirstN_C1 = '{0}', ", DT_Borrowers(0)("FirstN_R2"))
                            SQL &= String.Format(" MiddleN_C1 = '{0}', ", DT_Borrowers(0)("MiddleN_R2"))
                            SQL &= String.Format(" LastN_C1 = '{0}', ", DT_Borrowers(0)("LastN_R2"))
                            SQL &= String.Format(" Suffix_C1 = '{0}', ", DT_Borrowers(0)("Suffix_R2"))
                            SQL &= String.Format(" Prefix_C2 = '{0}', ", DT_Borrowers(0)("Prefix_R3"))
                            SQL &= String.Format(" FirstN_C2 = '{0}', ", DT_Borrowers(0)("FirstN_R3"))
                            SQL &= String.Format(" MiddleN_C2 = '{0}', ", DT_Borrowers(0)("MiddleN_R3"))
                            SQL &= String.Format(" LastN_C2 = '{0}', ", DT_Borrowers(0)("LastN_R3"))
                            SQL &= String.Format(" Suffix_C2 = '{0}', ", DT_Borrowers(0)("Suffix_R3"))
                            SQL &= String.Format(" Prefix_C3 = '{0}', ", DT_Borrowers(0)("Prefix_R4"))
                            SQL &= String.Format(" FirstN_C3 = '{0}', ", DT_Borrowers(0)("FirstN_R4"))
                            SQL &= String.Format(" MiddleN_C3 = '{0}', ", DT_Borrowers(0)("MiddleN_R4"))
                            SQL &= String.Format(" LastN_C3 = '{0}', ", DT_Borrowers(0)("LastN_R4"))
                            SQL &= String.Format(" Suffix_C3 = '{0}', ", DT_Borrowers(0)("Suffix_R4"))
                            SQL &= String.Format(" Prefix_C4 = '{0}', ", DT_Borrowers(0)("Prefix_R5"))
                            SQL &= String.Format(" FirstN_C4 = '{0}', ", DT_Borrowers(0)("FirstN_R5"))
                            SQL &= String.Format(" MiddleN_C4 = '{0}', ", DT_Borrowers(0)("MiddleN_R5"))
                            SQL &= String.Format(" LastN_C4 = '{0}', ", DT_Borrowers(0)("LastN_R5"))
                            SQL &= String.Format(" Suffix_C4 = '{0}', ", DT_Borrowers(0)("Suffix_R5"))
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrowers(0)("No"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrowers(0)("Street"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrowers(0)("Barangay"))
                            SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", DT_Borrowers(0)("Address-ID"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrowers(0)("Address"))
                            SQL &= " NoP_B = '', "
                            SQL &= " StreetP_B = '', "
                            SQL &= " BarangayP_B = '', "
                            SQL &= " `AddressP_B-ID` = 0, "
                            SQL &= " AddressP_B = '', "
                            SQL &= String.Format(" Birth_B = '{0}', ", DT_Borrowers(0)("Incorporation"))
                            SQL &= " `PlaceBirth_B-ID` = 0, "
                            SQL &= " PlaceBirth_B = '', "
                            SQL &= " Gender_B = '', "
                            SQL &= " Civil_B = '', "
                            SQL &= " Citizenship_B = '', "
                            SQL &= String.Format(" TIN_B = '{0}', ", DT_Borrowers(0)("TIN"))
                            SQL &= String.Format(" Telephone_B = '{0}', ", DT_Borrowers(0)("Telephone"))
                            SQL &= String.Format(" SSS_B = '{0}', ", DT_Borrowers(0)("SSS"))
                            SQL &= " Mobile_B = '', "
                            SQL &= String.Format(" Email_B = '{0}', ", DT_Borrowers(0)("Email"))
                            SQL &= " House_B = '', "
                            SQL &= " Rent_B = 0, "

                            SQL &= " Prefix_D1 = '', "
                            SQL &= " FirstN_D1 = '', "
                            SQL &= " MiddleN_D1 = '', "
                            SQL &= " LastN_D1 = '', "
                            SQL &= " Suffix_D1 = '', "
                            SQL &= " Birth_D1 = '', "
                            SQL &= " Grade_D1 = '', "
                            SQL &= " School_D1 = '', "
                            SQL &= " SchoolAddress_D1 = '', "
                            SQL &= " Prefix_D2 = '', "
                            SQL &= " FirstN_D2 = '', "
                            SQL &= " MiddleN_D2 = '', "
                            SQL &= " LastN_D2 = '', "
                            SQL &= " Suffix_D2 = '', "
                            SQL &= " Birth_D2 = '', "
                            SQL &= " Grade_D2 = '', "
                            SQL &= " School_D2 = '', "
                            SQL &= " SchoolAddress_D2 = '', "
                            SQL &= " Prefix_D3 = '', "
                            SQL &= " FirstN_D3 = '', "
                            SQL &= " MiddleN_D3 = '', "
                            SQL &= " LastN_D3 = '', "
                            SQL &= " Suffix_D3 = '', "
                            SQL &= " Birth_D3 = '', "
                            SQL &= " Grade_D3 = '', "
                            SQL &= " School_D3 = '', "
                            SQL &= " SchoolAddress_D3 = '', "
                            SQL &= " Prefix_D4 = '', "
                            SQL &= " FirstN_D4 = '', "
                            SQL &= " MiddleN_D4 = '', "
                            SQL &= " LastN_D4 = '', "
                            SQL &= " Suffix_D4 = '', "
                            SQL &= " Birth_D4 = '', "
                            SQL &= " Grade_D4 = '', "
                            SQL &= " School_D4 = '', "
                            SQL &= " SchoolAddress_D4 = '', "

                            SQL &= " Employer_B = '', "
                            SQL &= " EmployerAddress_B = '', "
                            SQL &= " EmployerTelephone_B = '', "
                            SQL &= " Position_B = '', "
                            SQL &= " EmploymentStat_B = '', "
                            SQL &= " Hired_B = '', "
                            SQL &= " Supervisor_B = '', "
                            SQL &= " Monthly_B = 0, "
                            SQL &= String.Format(" BusinessName_B = '{0}', ", DT_Borrowers(0)("TradeName"))
                            SQL &= String.Format(" BusinessAddress_B = '{0}', ", DT_Borrowers(0)("Address"))
                            SQL &= String.Format(" BusinessTelephone_B = '{0}', ", DT_Borrowers(0)("Telephone"))
                            SQL &= " NatureBusiness_B = '', "
                            SQL &= String.Format(" YrsOperation_B = '{0}', ", DT_Borrowers(0)("YearsOperation"))
                            SQL &= String.Format(" BusinessIncome_B = '{0}', ", DT_Borrowers(0)("Gross"))
                            SQL &= String.Format(" NoEmployees_B = '{0}', ", DT_Borrowers(0)("Employees"))
                            SQL &= " Capital_B = 0, "
                            SQL &= " Area_B = 0, "
                            SQL &= " Expiry_B = '', "
                            SQL &= " Outlet_B = 0, "
                            SQL &= " OtherIncome_B = '', "
                            SQL &= " `OtherIncome_B-Amount` = 0, "
                            SQL &= " Creditor_1 = '', "
                            SQL &= " NatureLoan_1 = '', "
                            SQL &= " AmountGranted_1 = 0, "
                            SQL &= " Term_1 = 0, "
                            SQL &= " Balance_1 = 0, "
                            SQL &= " CreditRemarks_1 = '', "
                            SQL &= " Creditor_2 = '', "
                            SQL &= " NatureLoan_2 = '', "
                            SQL &= " AmountGranted_2 = 0, "
                            SQL &= " Term_2 = 0, "
                            SQL &= " Balance_2 = 0, "
                            SQL &= " CreditRemarks_2 = '', "
                            SQL &= " Creditor_3 = '', "
                            SQL &= " NatureLoan_3 = '', "
                            SQL &= " AmountGranted_3 = 0, "
                            SQL &= " Term_3 = 0, "
                            SQL &= " Balance_3 = 0, "
                            SQL &= " CreditRemarks_3 = '', "
                            SQL &= " Bank_1 = '', "
                            SQL &= " Branch_1 = '', "
                            SQL &= " AccountT_1 = '', "
                            SQL &= " SA_1 = '', "
                            SQL &= " AverageBalance_1 = 0, "
                            SQL &= " PresentBalance_1 = 0, "
                            SQL &= " Opened_1 = '', "
                            SQL &= " BankRemarks_1 = '', "
                            SQL &= " Bank_2 = '', "
                            SQL &= " Branch_2 = '', "
                            SQL &= " AccountT_2 = '', "
                            SQL &= " SA_2 = '', "
                            SQL &= " AverageBalance_2 = 0, "
                            SQL &= " PresentBalance_2 = 0, "
                            SQL &= " Opened_2 = '', "
                            SQL &= " BankRemarks_2 = '', "
                            SQL &= " Bank_3 = '', "
                            SQL &= " Branch_3 = '', "
                            SQL &= " AccountT_3 = '', "
                            SQL &= " SA_3 = '', "
                            SQL &= " AverageBalance_3 = 0, "
                            SQL &= " PresentBalance_3 = 0, "
                            SQL &= " Opened_3 = '', "
                            SQL &= " BankRemarks_3 = '', "
                            SQL &= " Location_1 = '', "
                            SQL &= " TCT_1 = '', "
                            SQL &= " Area_1 = 0, "
                            SQL &= " Acquired_1 = '', "
                            SQL &= " PropertiesRemarks_1 = '', "
                            SQL &= " Location_2 = '', "
                            SQL &= " TCT_2 = '', "
                            SQL &= " Area_2 = 0, "
                            SQL &= " Acquired_2 = '', "
                            SQL &= " PropertiesRemarks_2 = '', "
                            SQL &= " Location_3 = '', "
                            SQL &= " TCT_3 = '', "
                            SQL &= " Area_3 = 0, "
                            SQL &= " Acquired_3 = '', "
                            SQL &= " PropertiesRemarks_3 = '', "
                            SQL &= " Vehicle_1 = '', "
                            SQL &= " Year_1 = '', "
                            SQL &= " WhomAcquired_1 = '', "
                            SQL &= " WhenAcquired_1 = '', "
                            SQL &= " VehicleRemarks_1 = '', "
                            SQL &= " Vehicle_2 = '', "
                            SQL &= " Year_2 = '', "
                            SQL &= " WhomAcquired_2 = '', "
                            SQL &= " WhenAcquired_2 = '', "
                            SQL &= " VehicleRemarks_2 = '', "
                            SQL &= " Vehicle_3 = '', "
                            SQL &= " Year_3 = '', "
                            SQL &= " WhomAcquired_3 = '', "
                            SQL &= " WhenAcquired_3 = '', "
                            SQL &= " VehicleRemarks_3 = '', "
                            SQL &= " HomeAppliances_1 = '', "
                            SQL &= " HomeAppliances_2 = '', "
                            SQL &= " Reference_1 = '', "
                            SQL &= " ReferenceAddress_1 = '', "
                            SQL &= " ReferenceContact_1 = '', "
                            SQL &= " Reference_2 = '', "
                            SQL &= " ReferenceAddress_2 = '', "
                            SQL &= " ReferenceContact_2 = '', "
                            SQL &= " Reference_3 = '', "
                            SQL &= " ReferenceAddress_3 = '', "
                            SQL &= " ReferenceContact_3 = '', "
                            SQL &= " CertificateNo = '', "
                            SQL &= " PlaceIssue = '', "
                            SQL &= " Issue = '', "
                        Else
                            SQL &= String.Format(" Prefix_B = '{0}', ", DT_Borrowers(0)("Prefix_B"))
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrowers(0)("FirstN_B"))
                            SQL &= String.Format(" MiddleN_B = '{0}', ", DT_Borrowers(0)("MiddleN_B"))
                            SQL &= String.Format(" LastN_B = '{0}', ", DT_Borrowers(0)("LastN_B"))
                            SQL &= String.Format(" Suffix_B = '{0}', ", DT_Borrowers(0)("Suffix_B"))
                            SQL &= String.Format(" Prefix_S = '{0}', ", DT_Borrowers(0)("Prefix_S"))
                            SQL &= String.Format(" FirstN_S = '{0}', ", DT_Borrowers(0)("FirstN_S"))
                            SQL &= String.Format(" MiddleN_S = '{0}', ", DT_Borrowers(0)("MiddleN_S"))
                            SQL &= String.Format(" LastN_S = '{0}', ", DT_Borrowers(0)("LastN_S"))
                            SQL &= String.Format(" Suffix_S = '{0}', ", DT_Borrowers(0)("Suffix_S"))
                            SQL &= " Prefix_C1 = '', "
                            SQL &= " FirstN_C1 = '', "
                            SQL &= " MiddleN_C1 = '', "
                            SQL &= " LastN_C1 = '', "
                            SQL &= " Suffix_C1 = '', "
                            SQL &= " Prefix_C2 = '', "
                            SQL &= " FirstN_C2 = '', "
                            SQL &= " MiddleN_C2 = '', "
                            SQL &= " LastN_C2 = '', "
                            SQL &= " Suffix_C2 = '', "
                            SQL &= " Prefix_C3 = '', "
                            SQL &= " FirstN_C3 = '', "
                            SQL &= " MiddleN_C3 = '', "
                            SQL &= " LastN_C3 = '', "
                            SQL &= " Suffix_C3 = '', "
                            SQL &= " Prefix_C4 = '', "
                            SQL &= " FirstN_C4 = '', "
                            SQL &= " MiddleN_C4 = '', "
                            SQL &= " LastN_C4 = '', "
                            SQL &= " Suffix_C4 = '', "
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrowers(0)("NoC_B"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrowers(0)("StreetC_B"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrowers(0)("BarangayC_B"))
                            SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", DT_Borrowers(0)("AddressC_B-ID"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrowers(0)("AddressC_B"))
                            SQL &= String.Format(" NoP_B = '{0}', ", DT_Borrowers(0)("NoP_B"))
                            SQL &= String.Format(" StreetP_B = '{0}', ", DT_Borrowers(0)("StreetP_B"))
                            SQL &= String.Format(" BarangayP_B = '{0}', ", DT_Borrowers(0)("BarangayP_B"))
                            SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", DT_Borrowers(0)("AddressP_B-ID"))
                            SQL &= String.Format(" AddressP_B = '{0}', ", DT_Borrowers(0)("AddressP_B"))
                            SQL &= String.Format(" Birth_B = '{0}', ", DT_Borrowers(0)("Birth_B"))
                            SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", DT_Borrowers(0)("PlaceBirth_B-ID"))
                            SQL &= String.Format(" PlaceBirth_B = '{0}', ", DT_Borrowers(0)("PlaceBirth_B"))
                            SQL &= String.Format(" Gender_B = '{0}', ", DT_Borrowers(0)("Gender_B"))
                            SQL &= String.Format(" Civil_B = '{0}', ", DT_Borrowers(0)("Civil_B"))
                            SQL &= String.Format(" Citizenship_B = '{0}', ", DT_Borrowers(0)("Citizenship_B"))
                            SQL &= String.Format(" TIN_B = '{0}', ", DT_Borrowers(0)("TIN_B"))
                            SQL &= String.Format(" Telephone_B = '{0}', ", DT_Borrowers(0)("Telephone_B"))
                            SQL &= String.Format(" SSS_B = '{0}', ", DT_Borrowers(0)("SSS_B"))
                            SQL &= String.Format(" Mobile_B = '{0}', ", DT_Borrowers(0)("Mobile_B"))
                            SQL &= String.Format(" Email_B = '{0}', ", DT_Borrowers(0)("Email_B"))
                            SQL &= String.Format(" House_B = '{0}', ", DT_Borrowers(0)("House_B"))
                            SQL &= String.Format(" Rent_B = '{0}', ", DT_Borrowers(0)("Rent_B"))

                            SQL &= String.Format(" Prefix_D1 = '{0}', ", DT_Borrowers(0)("Prefix_D1"))
                            SQL &= String.Format(" FirstN_D1 = '{0}', ", DT_Borrowers(0)("FirstN_D1"))
                            SQL &= String.Format(" MiddleN_D1 = '{0}', ", DT_Borrowers(0)("MiddleN_D1"))
                            SQL &= String.Format(" LastN_D1 = '{0}', ", DT_Borrowers(0)("LastN_D1"))
                            SQL &= String.Format(" Suffix_D1 = '{0}', ", DT_Borrowers(0)("Suffix_D1"))
                            SQL &= String.Format(" Birth_D1 = '{0}', ", DT_Borrowers(0)("Birth_D1"))
                            SQL &= String.Format(" Grade_D1 = '{0}', ", DT_Borrowers(0)("Grade_D1"))
                            SQL &= String.Format(" School_D1 = '{0}', ", DT_Borrowers(0)("School_D1"))
                            SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D1"))
                            SQL &= String.Format(" Prefix_D2 = '{0}', ", DT_Borrowers(0)("Prefix_D2"))
                            SQL &= String.Format(" FirstN_D2 = '{0}', ", DT_Borrowers(0)("FirstN_D2"))
                            SQL &= String.Format(" MiddleN_D2 = '{0}', ", DT_Borrowers(0)("MiddleN_D2"))
                            SQL &= String.Format(" LastN_D2 = '{0}', ", DT_Borrowers(0)("LastN_D2"))
                            SQL &= String.Format(" Suffix_D2 = '{0}', ", DT_Borrowers(0)("Suffix_D2"))
                            SQL &= String.Format(" Birth_D2 = '{0}', ", DT_Borrowers(0)("Birth_D2"))
                            SQL &= String.Format(" Grade_D2 = '{0}', ", DT_Borrowers(0)("Grade_D2"))
                            SQL &= String.Format(" School_D2 = '{0}', ", DT_Borrowers(0)("School_D2"))
                            SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D2"))
                            SQL &= String.Format(" Prefix_D3 = '{0}', ", DT_Borrowers(0)("Prefix_D3"))
                            SQL &= String.Format(" FirstN_D3 = '{0}', ", DT_Borrowers(0)("FirstN_D3"))
                            SQL &= String.Format(" MiddleN_D3 = '{0}', ", DT_Borrowers(0)("MiddleN_D3"))
                            SQL &= String.Format(" LastN_D3 = '{0}', ", DT_Borrowers(0)("LastN_D3"))
                            SQL &= String.Format(" Suffix_D3 = '{0}', ", DT_Borrowers(0)("Suffix_D3"))
                            SQL &= String.Format(" Birth_D3 = '{0}', ", DT_Borrowers(0)("Birth_D3"))
                            SQL &= String.Format(" Grade_D3 = '{0}', ", DT_Borrowers(0)("Grade_D3"))
                            SQL &= String.Format(" School_D3 = '{0}', ", DT_Borrowers(0)("School_D3"))
                            SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D3"))
                            SQL &= String.Format(" Prefix_D4 = '{0}', ", DT_Borrowers(0)("Prefix_D4"))
                            SQL &= String.Format(" FirstN_D4 = '{0}', ", DT_Borrowers(0)("FirstN_D4"))
                            SQL &= String.Format(" MiddleN_D4 = '{0}', ", DT_Borrowers(0)("MiddleN_D4"))
                            SQL &= String.Format(" LastN_D4 = '{0}', ", DT_Borrowers(0)("LastN_D4"))
                            SQL &= String.Format(" Suffix_D4 = '{0}', ", DT_Borrowers(0)("Suffix_D4"))
                            SQL &= String.Format(" Birth_D4 = '{0}', ", DT_Borrowers(0)("Birth_D4"))
                            SQL &= String.Format(" Grade_D4 = '{0}', ", DT_Borrowers(0)("Grade_D4"))
                            SQL &= String.Format(" School_D4 = '{0}', ", DT_Borrowers(0)("School_D4"))
                            SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D4"))

                            SQL &= String.Format(" Employer_B = '{0}', ", DT_Borrowers(0)("Employer_B"))
                            SQL &= String.Format(" EmployerAddress_B = '{0}', ", DT_Borrowers(0)("EmployerAddress_B"))
                            SQL &= String.Format(" EmployerTelephone_B = '{0}', ", DT_Borrowers(0)("EmployerTelephone_B"))
                            SQL &= String.Format(" Position_B = '{0}', ", DT_Borrowers(0)("Position_B"))
                            SQL &= String.Format(" EmploymentStat_B = '{0}', ", DT_Borrowers(0)("EmploymentStat_B"))
                            SQL &= String.Format(" Hired_B = '{0}', ", DT_Borrowers(0)("Hired_B"))
                            SQL &= String.Format(" Supervisor_B = '{0}', ", DT_Borrowers(0)("Supervisor_B"))
                            SQL &= String.Format(" Monthly_B = '{0}', ", DT_Borrowers(0)("Monthly_B"))
                            SQL &= String.Format(" BusinessName_B = '{0}', ", DT_Borrowers(0)("BusinessName_B"))
                            SQL &= String.Format(" BusinessAddress_B = '{0}', ", DT_Borrowers(0)("BusinessAddress_B"))
                            SQL &= String.Format(" BusinessTelephone_B = '{0}', ", DT_Borrowers(0)("BusinessTelephone_B"))
                            SQL &= String.Format(" NatureBusiness_B = '{0}', ", DT_Borrowers(0)("NatureBusiness_B"))
                            SQL &= String.Format(" YrsOperation_B = '{0}', ", DT_Borrowers(0)("YrsOperation_B"))
                            SQL &= String.Format(" BusinessIncome_B = '{0}', ", DT_Borrowers(0)("BusinessIncome_B"))
                            SQL &= String.Format(" NoEmployees_B = '{0}', ", DT_Borrowers(0)("NoEmployees_B"))
                            SQL &= String.Format(" Capital_B = '{0}', ", DT_Borrowers(0)("Capital_B"))
                            SQL &= String.Format(" Area_B = '{0}', ", DT_Borrowers(0)("Area_B"))
                            SQL &= String.Format(" Expiry_B = '{0}', ", DT_Borrowers(0)("Expiry_B"))
                            SQL &= String.Format(" Outlet_B = '{0}', ", DT_Borrowers(0)("Outlet_B"))
                            SQL &= String.Format(" OtherIncome_B = '{0}', ", DT_Borrowers(0)("OtherIncome_B"))
                            SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", DT_Borrowers(0)("OtherIncome_B-Amount"))
                            SQL &= String.Format(" Creditor_1 = '{0}', ", DT_Borrowers(0)("Creditor_1"))
                            SQL &= String.Format(" NatureLoan_1 = '{0}', ", DT_Borrowers(0)("NatureLoan_1"))
                            SQL &= String.Format(" AmountGranted_1 = '{0}', ", DT_Borrowers(0)("AmountGranted_1"))
                            SQL &= String.Format(" Term_1 = '{0}', ", DT_Borrowers(0)("Term_1"))
                            SQL &= String.Format(" Balance_1 = '{0}', ", DT_Borrowers(0)("Balance_1"))
                            SQL &= String.Format(" CreditRemarks_1 = '{0}', ", DT_Borrowers(0)("CreditRemarks_1"))
                            SQL &= String.Format(" Creditor_2 = '{0}', ", DT_Borrowers(0)("Creditor_2"))
                            SQL &= String.Format(" NatureLoan_2 = '{0}', ", DT_Borrowers(0)("NatureLoan_2"))
                            SQL &= String.Format(" AmountGranted_2 = '{0}', ", DT_Borrowers(0)("AmountGranted_2"))
                            SQL &= String.Format(" Term_2 = '{0}', ", DT_Borrowers(0)("Term_2"))
                            SQL &= String.Format(" Balance_2 = '{0}', ", DT_Borrowers(0)("Balance_2"))
                            SQL &= String.Format(" CreditRemarks_2 = '{0}', ", DT_Borrowers(0)("CreditRemarks_2"))
                            SQL &= String.Format(" Creditor_3 = '{0}', ", DT_Borrowers(0)("Creditor_3"))
                            SQL &= String.Format(" NatureLoan_3 = '{0}', ", DT_Borrowers(0)("NatureLoan_3"))
                            SQL &= String.Format(" AmountGranted_3 = '{0}', ", DT_Borrowers(0)("AmountGranted_3"))
                            SQL &= String.Format(" Term_3 = '{0}', ", DT_Borrowers(0)("Term_3"))
                            SQL &= String.Format(" Balance_3 = '{0}', ", DT_Borrowers(0)("Balance_3"))
                            SQL &= String.Format(" CreditRemarks_3 = '{0}', ", DT_Borrowers(0)("CreditRemarks_3"))
                            SQL &= String.Format(" Bank_1 = '{0}', ", DT_Borrowers(0)("Bank_1"))
                            SQL &= String.Format(" Branch_1 = '{0}', ", DT_Borrowers(0)("Branch_1"))
                            SQL &= String.Format(" AccountT_1 = '{0}', ", DT_Borrowers(0)("AccountT_1"))
                            SQL &= String.Format(" SA_1 = '{0}', ", DT_Borrowers(0)("SA_1"))
                            SQL &= String.Format(" AverageBalance_1 = '{0}', ", DT_Borrowers(0)("AverageBalance_1"))
                            SQL &= String.Format(" PresentBalance_1 = '{0}', ", DT_Borrowers(0)("PresentBalance_1"))
                            SQL &= String.Format(" Opened_1 = '{0}', ", DT_Borrowers(0)("Opened_1"))
                            SQL &= String.Format(" BankRemarks_1 = '{0}', ", DT_Borrowers(0)("BankRemarks_1"))
                            SQL &= String.Format(" Bank_2 = '{0}', ", DT_Borrowers(0)("Bank_2"))
                            SQL &= String.Format(" Branch_2 = '{0}', ", DT_Borrowers(0)("Branch_2"))
                            SQL &= String.Format(" AccountT_2 = '{0}', ", DT_Borrowers(0)("AccountT_2"))
                            SQL &= String.Format(" SA_2 = '{0}', ", DT_Borrowers(0)("SA_2"))
                            SQL &= String.Format(" AverageBalance_2 = '{0}', ", DT_Borrowers(0)("AverageBalance_2"))
                            SQL &= String.Format(" PresentBalance_2 = '{0}', ", DT_Borrowers(0)("PresentBalance_2"))
                            SQL &= String.Format(" Opened_2 = '{0}', ", DT_Borrowers(0)("Opened_2"))
                            SQL &= String.Format(" BankRemarks_2 = '{0}', ", DT_Borrowers(0)("BankRemarks_2"))
                            SQL &= String.Format(" Bank_3 = '{0}', ", DT_Borrowers(0)("Bank_3"))
                            SQL &= String.Format(" Branch_3 = '{0}', ", DT_Borrowers(0)("Branch_3"))
                            SQL &= String.Format(" AccountT_3 = '{0}', ", DT_Borrowers(0)("AccountT_3"))
                            SQL &= String.Format(" SA_3 = '{0}', ", DT_Borrowers(0)("SA_3"))
                            SQL &= String.Format(" AverageBalance_3 = '{0}', ", DT_Borrowers(0)("AverageBalance_3"))
                            SQL &= String.Format(" PresentBalance_3 = '{0}', ", DT_Borrowers(0)("PresentBalance_3"))
                            SQL &= String.Format(" Opened_3 = '{0}', ", DT_Borrowers(0)("Opened_3"))
                            SQL &= String.Format(" BankRemarks_3 = '{0}', ", DT_Borrowers(0)("BankRemarks_3"))
                            SQL &= String.Format(" Location_1 = '{0}', ", DT_Borrowers(0)("Location_1"))
                            SQL &= String.Format(" TCT_1 = '{0}', ", DT_Borrowers(0)("TCT_1"))
                            SQL &= String.Format(" Area_1 = '{0}', ", DT_Borrowers(0)("Area_1"))
                            SQL &= String.Format(" Acquired_1 = '{0}', ", DT_Borrowers(0)("Acquired_1"))
                            SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", DT_Borrowers(0)("PropertiesRemarks_1"))
                            SQL &= String.Format(" Location_2 = '{0}', ", DT_Borrowers(0)("Location_2"))
                            SQL &= String.Format(" TCT_2 = '{0}', ", DT_Borrowers(0)("TCT_2"))
                            SQL &= String.Format(" Area_2 = '{0}', ", DT_Borrowers(0)("Area_2"))
                            SQL &= String.Format(" Acquired_2 = '{0}', ", DT_Borrowers(0)("Acquired_2"))
                            SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", DT_Borrowers(0)("PropertiesRemarks_2"))
                            SQL &= String.Format(" Location_3 = '{0}', ", DT_Borrowers(0)("Location_3"))
                            SQL &= String.Format(" TCT_3 = '{0}', ", DT_Borrowers(0)("TCT_3"))
                            SQL &= String.Format(" Area_3 = '{0}', ", DT_Borrowers(0)("Area_3"))
                            SQL &= String.Format(" Acquired_3 = '{0}', ", DT_Borrowers(0)("Acquired_3"))
                            SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", DT_Borrowers(0)("PropertiesRemarks_3"))
                            SQL &= String.Format(" Vehicle_1 = '{0}', ", DT_Borrowers(0)("Vehicle_1"))
                            SQL &= String.Format(" Year_1 = '{0}', ", DT_Borrowers(0)("Year_1"))
                            SQL &= String.Format(" WhomAcquired_1 = '{0}', ", DT_Borrowers(0)("WhomAcquired_1"))
                            SQL &= String.Format(" WhenAcquired_1 = '{0}', ", DT_Borrowers(0)("WhenAcquired_1"))
                            SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", DT_Borrowers(0)("VehicleRemarks_1"))
                            SQL &= String.Format(" Vehicle_2 = '{0}', ", DT_Borrowers(0)("Vehicle_2"))
                            SQL &= String.Format(" Year_2 = '{0}', ", DT_Borrowers(0)("Year_2"))
                            SQL &= String.Format(" WhomAcquired_2 = '{0}', ", DT_Borrowers(0)("WhomAcquired_2"))
                            SQL &= String.Format(" WhenAcquired_2 = '{0}', ", DT_Borrowers(0)("WhenAcquired_2"))
                            SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", DT_Borrowers(0)("VehicleRemarks_2"))
                            SQL &= String.Format(" Vehicle_3 = '{0}', ", DT_Borrowers(0)("Vehicle_3"))
                            SQL &= String.Format(" Year_3 = '{0}', ", DT_Borrowers(0)("Year_3"))
                            SQL &= String.Format(" WhomAcquired_3 = '{0}', ", DT_Borrowers(0)("WhomAcquired_3"))
                            SQL &= String.Format(" WhenAcquired_3 = '{0}', ", DT_Borrowers(0)("WhenAcquired_3"))
                            SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", DT_Borrowers(0)("VehicleRemarks_3"))
                            SQL &= String.Format(" HomeAppliances_1 = '{0}', ", DT_Borrowers(0)("HomeAppliances_1"))
                            SQL &= String.Format(" HomeAppliances_2 = '{0}', ", DT_Borrowers(0)("HomeAppliances_2"))
                            SQL &= String.Format(" Reference_1 = '{0}', ", DT_Borrowers(0)("Reference_1"))
                            SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", DT_Borrowers(0)("ReferenceAddress_1"))
                            SQL &= String.Format(" ReferenceContact_1 = '{0}', ", DT_Borrowers(0)("ReferenceContact_1"))
                            SQL &= String.Format(" Reference_2 = '{0}', ", DT_Borrowers(0)("Reference_2"))
                            SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", DT_Borrowers(0)("ReferenceAddress_2"))
                            SQL &= String.Format(" ReferenceContact_2 = '{0}', ", DT_Borrowers(0)("ReferenceContact_2"))
                            SQL &= String.Format(" Reference_3 = '{0}', ", DT_Borrowers(0)("Reference_3"))
                            SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", DT_Borrowers(0)("ReferenceAddress_3"))
                            SQL &= String.Format(" ReferenceContact_3 = '{0}', ", DT_Borrowers(0)("ReferenceContact_3"))
                            SQL &= String.Format(" CertificateNo = '{0}', ", DT_Borrowers(0)("CertificateNo"))
                            SQL &= String.Format(" PlaceIssue = '{0}', ", DT_Borrowers(0)("PlaceIssue"))
                            SQL &= String.Format(" Issue = '{0}', ", DT_Borrowers(0)("Issue"))
                        End If

                        SQL &= String.Format(" `AgentID` = '{0}', ", DT_Borrowers(0)("AgentID"))
                        SQL &= String.Format(" Agent = '{0}', ", DT_Borrowers(0)("Agent"))
                        SQL &= String.Format(" AgentNo = '{0}', ", DT_Borrowers(0)("AgentNo"))
                        SQL &= String.Format(" `MarketingID` = '{0}', ", DT_Borrowers(0)("MarketingID"))
                        SQL &= String.Format(" Marketing = '{0}', ", DT_Borrowers(0)("Marketing"))
                        SQL &= String.Format(" MarketingNo = '{0}', ", DT_Borrowers(0)("MarketingNo"))
                        SQL &= String.Format(" `WalkinID` = '{0}', ", DT_Borrowers(0)("WalkinID"))
                        SQL &= String.Format(" WalkIn = '{0}', ", DT_Borrowers(0)("WalkIn"))
                        SQL &= String.Format(" WalkIn_Specify = '{0}', ", DT_Borrowers(0)("WalkIn_Specify"))
                        SQL &= String.Format(" `DealerID` = '{0}', ", DT_Borrowers(0)("DealerID"))
                        SQL &= String.Format(" Dealer = '{0}', ", DT_Borrowers(0)("Dealer"))
                        SQL &= String.Format(" DealerNo = '{0}' ", DT_Borrowers(0)("DealerNo"))
                        SQL &= String.Format(" WHERE CreditNumber = '{0}'; ", CreditNumber)

                        'CREDIT INVESTIGATION
                        SQL &= " UPDATE credit_investigation SET "
                        SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                        If drv("Type") = "C" Then
                            SQL &= " Prefix_B = '', "
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrowers(0)("TradeName"))
                            SQL &= " MiddleN_B = '', "
                            SQL &= " LastN_B = '', "
                            SQL &= " Suffix_B = '', "
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrowers(0)("No"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrowers(0)("Street"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrowers(0)("Barangay"))
                            SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", DT_Borrowers(0)("Address-ID"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrowers(0)("Address"))

                            SQL &= " Residence_B = '', "
                            SQL &= " House_B = '', "
                            SQL &= " Rent_B = 0, "
                            SQL &= " AsConfirmed = '', "
                            SQL &= " LenghtOfStay = '', "
                            SQL &= " Neighborhood = '', "
                            SQL &= String.Format(" Birth_B = '{0}', ", DT_Borrowers(0)("Incorporation"))
                            SQL &= " Civil_B = '', "

                            SQL &= " Prefix_D1 = '', "
                            SQL &= " FirstN_D1 = '', "
                            SQL &= " MiddleN_D1 = '', "
                            SQL &= " LastN_D1 = '', "
                            SQL &= " Suffix_D1 = '', "
                            SQL &= " Birth_D1 = '', "
                            SQL &= " Grade_D1 = '', "
                            SQL &= " School_D1 = '', "
                            SQL &= " SchoolAddress_D1 = '', "
                            SQL &= " Prefix_D2 = '', "
                            SQL &= " FirstN_D2 = '', "
                            SQL &= " MiddleN_D2 = '', "
                            SQL &= " LastN_D2 = '', "
                            SQL &= " Suffix_D2 = '', "
                            SQL &= " Birth_D2 = '', "
                            SQL &= " Grade_D2 = '', "
                            SQL &= " School_D2 = '', "
                            SQL &= " SchoolAddress_D2 = '', "
                            SQL &= " Prefix_D3 = '', "
                            SQL &= " FirstN_D3 = '', "
                            SQL &= " MiddleN_D3 = '', "
                            SQL &= " LastN_D3 = '', "
                            SQL &= " Suffix_D3 = '', "
                            SQL &= " Birth_D3 = '', "
                            SQL &= " Grade_D3 = '', "
                            SQL &= " School_D3 = '', "
                            SQL &= " SchoolAddress_D3 = '', "
                            SQL &= " Prefix_D4 = '', "
                            SQL &= " FirstN_D4 = '', "
                            SQL &= " MiddleN_D4 = '', "
                            SQL &= " LastN_D4 = '', "
                            SQL &= " Suffix_D4 = '', "
                            SQL &= " Birth_D4 = '', "
                            SQL &= " Grade_D4 = '', "
                            SQL &= " School_D4 = '', "
                            SQL &= " SchoolAddress_D4 = '', "

                            SQL &= " Employer_B = '', "
                            SQL &= " EmployerAddress_B = '', "
                            SQL &= " Hired_B = '', "
                            SQL &= " EmploymentStat_B = '', "
                            SQL &= " Position_B = '', "
                            SQL &= " Monthly_B = 0, "
                            SQL &= String.Format(" BusinessName_B = '{0}', ", DT_Borrowers(0)("TradeName"))
                            SQL &= " BusinessAddress_B = '', "
                            SQL &= " BusinessStarted = '', "
                            SQL &= " NatureBusiness_B = '', "
                            SQL &= " Capital_B = 0, "
                            SQL &= String.Format(" NoEmployees_B = '{0}', ", DT_Borrowers(0)("Employees"))
                            SQL &= " BusinessStock = 0, "
                            SQL &= " BusinessVehicle = '', "
                            SQL &= String.Format(" BusinessIncome_B = '{0}', ", DT_Borrowers(0)("Gross"))
                            SQL &= " BusinessPermit = '', "
                            SQL &= " OtherIncome_B = '', "
                            SQL &= " OtherIncome_B_Amount = 0, "
                            SQL &= " Creditor_1 = '', "
                            SQL &= " CreditAddress_1 = '', "
                            SQL &= " CreditGranted_1 = '', "
                            SQL &= " Term_1 = 0, "
                            SQL &= " AmountGranted_1 = 0, "
                            SQL &= " Balance_1 = 0, "
                            SQL &= " CreditPayment_1 = 0, "
                            SQL &= " CreditRemarks_1 = '', "
                            SQL &= " Creditor_2 = '', "
                            SQL &= " CreditAddress_2 = '', "
                            SQL &= " CreditGranted_2 = '', "
                            SQL &= " Term_2 = 0, "
                            SQL &= " AmountGranted_2 = 0, "
                            SQL &= " Balance_2 = 0, "
                            SQL &= " CreditPayment_2 = 0, "
                            SQL &= " CreditRemarks_2 = '', "

                            SQL &= " Bank_1 = '', "
                            SQL &= " Branch_1 = '', "
                            SQL &= " AccountT_1 = '', "
                            SQL &= " SA_1 = '', "
                            SQL &= " AverageBalance_1 = 0, "
                            SQL &= " Opened_1 = '', "
                            SQL &= " Bank_2 = '', "
                            SQL &= " Branch_2 = '', "
                            SQL &= " AccountT_2 = '', "
                            SQL &= " SA_2 = '', "
                            SQL &= " AverageBalance_2 = 0, "
                            SQL &= " Opened_2 = '', "

                            SQL &= " CreditRating = '', "
                            SQL &= " Rec_PDC = 1, "
                            SQL &= " Rec_NoPDC = 0, "
                            SQL &= " Rec_Remarks = '', "
                            SQL &= " Title = '', "
                            SQL &= " CaseNum = '', "
                            SQL &= " DateFilled = '', "
                            SQL &= " Court = '', "
                            SQL &= " CaseNature = '', "
                            SQL &= " AmountInvolved = 0, "
                            SQL &= " CaseStatus = '', "
                            SQL &= " Findings = '', "
                            SQL &= " FindingsStat = '', "
                            SQL &= " CACPI = '', "

                            SQL &= " Location_1 = '', "
                            SQL &= " TCT_1 = '', "
                            SQL &= " Area_1 = 0, "
                            SQL &= " PropertiesRemarks_1 = '', "
                            SQL &= " Location_2 = '', "
                            SQL &= " TCT_2 = '', "
                            SQL &= " Area_2 = 0, "
                            SQL &= " PropertiesRemarks_2 = '', "

                            SQL &= " Vehicle_1 = '', "
                            SQL &= " Year_1 = '', "
                            SQL &= " WhomAcquired_1 = '', "
                            SQL &= " VehicleRemarks_1 = '', "
                            SQL &= " Vehicle_2 = '', "
                            SQL &= " Year_2 = '', "
                            SQL &= " WhomAcquired_2 = '', "
                            SQL &= " VehicleRemarks_2 = '' "
                        Else
                            SQL &= String.Format(" Prefix_B = '{0}', ", DT_Borrowers(0)("Prefix_B"))
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrowers(0)("FirstN_B"))
                            SQL &= String.Format(" MiddleN_B = '{0}', ", DT_Borrowers(0)("MiddleN_B"))
                            SQL &= String.Format(" LastN_B = '{0}', ", DT_Borrowers(0)("LastN_B"))
                            SQL &= String.Format(" Suffix_B = '{0}', ", DT_Borrowers(0)("Suffix_B"))
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrowers(0)("NoC_B"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrowers(0)("StreetC_B"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrowers(0)("BarangayC_B"))
                            SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", DT_Borrowers(0)("AddressC_B-ID"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrowers(0)("AddressC_B"))

                            SQL &= " Residence_B = '', "
                            SQL &= String.Format(" House_B = '{0}', ", DT_Borrowers(0)("House_B"))
                            SQL &= String.Format(" Rent_B = '{0}', ", DT_Borrowers(0)("Rent_B"))
                            SQL &= " AsConfirmed = '', "
                            SQL &= " LenghtOfStay = '', "
                            SQL &= " Neighborhood = '', "
                            SQL &= String.Format(" Birth_B = '{0}', ", DT_Borrowers(0)("Birth_B"))
                            SQL &= String.Format(" Civil_B = '{0}', ", DT_Borrowers(0)("Civil_B"))

                            SQL &= String.Format(" Prefix_D1 = '{0}', ", DT_Borrowers(0)("Prefix_D1"))
                            SQL &= String.Format(" FirstN_D1 = '{0}', ", DT_Borrowers(0)("FirstN_D1"))
                            SQL &= String.Format(" MiddleN_D1 = '{0}', ", DT_Borrowers(0)("MiddleN_D1"))
                            SQL &= String.Format(" LastN_D1 = '{0}', ", DT_Borrowers(0)("LastN_D1"))
                            SQL &= String.Format(" Suffix_D1 = '{0}', ", DT_Borrowers(0)("Suffix_D1"))
                            SQL &= String.Format(" Birth_D1 = '{0}', ", DT_Borrowers(0)("Birth_D1"))
                            SQL &= String.Format(" Grade_D1 = '{0}', ", DT_Borrowers(0)("Grade_D1"))
                            SQL &= String.Format(" School_D1 = '{0}', ", DT_Borrowers(0)("School_D1"))
                            SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D1"))
                            SQL &= String.Format(" Prefix_D2 = '{0}', ", DT_Borrowers(0)("Prefix_D2"))
                            SQL &= String.Format(" FirstN_D2 = '{0}', ", DT_Borrowers(0)("FirstN_D2"))
                            SQL &= String.Format(" MiddleN_D2 = '{0}', ", DT_Borrowers(0)("MiddleN_D2"))
                            SQL &= String.Format(" LastN_D2 = '{0}', ", DT_Borrowers(0)("LastN_D2"))
                            SQL &= String.Format(" Suffix_D2 = '{0}', ", DT_Borrowers(0)("Suffix_D2"))
                            SQL &= String.Format(" Birth_D2 = '{0}', ", DT_Borrowers(0)("Birth_D2"))
                            SQL &= String.Format(" Grade_D2 = '{0}', ", DT_Borrowers(0)("Grade_D2"))
                            SQL &= String.Format(" School_D2 = '{0}', ", DT_Borrowers(0)("School_D2"))
                            SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D2"))
                            SQL &= String.Format(" Prefix_D3 = '{0}', ", DT_Borrowers(0)("Prefix_D3"))
                            SQL &= String.Format(" FirstN_D3 = '{0}', ", DT_Borrowers(0)("FirstN_D3"))
                            SQL &= String.Format(" MiddleN_D3 = '{0}', ", DT_Borrowers(0)("MiddleN_D3"))
                            SQL &= String.Format(" LastN_D3 = '{0}', ", DT_Borrowers(0)("LastN_D3"))
                            SQL &= String.Format(" Suffix_D3 = '{0}', ", DT_Borrowers(0)("Suffix_D3"))
                            SQL &= String.Format(" Birth_D3 = '{0}', ", DT_Borrowers(0)("Birth_D3"))
                            SQL &= String.Format(" Grade_D3 = '{0}', ", DT_Borrowers(0)("Grade_D3"))
                            SQL &= String.Format(" School_D3 = '{0}', ", DT_Borrowers(0)("School_D3"))
                            SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D3"))
                            SQL &= String.Format(" Prefix_D4 = '{0}', ", DT_Borrowers(0)("Prefix_D4"))
                            SQL &= String.Format(" FirstN_D4 = '{0}', ", DT_Borrowers(0)("FirstN_D4"))
                            SQL &= String.Format(" MiddleN_D4 = '{0}', ", DT_Borrowers(0)("MiddleN_D4"))
                            SQL &= String.Format(" LastN_D4 = '{0}', ", DT_Borrowers(0)("LastN_D4"))
                            SQL &= String.Format(" Suffix_D4 = '{0}', ", DT_Borrowers(0)("Suffix_D4"))
                            SQL &= String.Format(" Birth_D4 = '{0}', ", DT_Borrowers(0)("Birth_D4"))
                            SQL &= String.Format(" Grade_D4 = '{0}', ", DT_Borrowers(0)("Grade_D4"))
                            SQL &= String.Format(" School_D4 = '{0}', ", DT_Borrowers(0)("School_D4"))
                            SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", DT_Borrowers(0)("SchoolAddress_D4"))

                            SQL &= String.Format(" Employer_B = '{0}', ", DT_Borrowers(0)("Employer_B"))
                            SQL &= String.Format(" EmployerAddress_B = '{0}', ", DT_Borrowers(0)("EmployerAddress_B"))
                            SQL &= String.Format(" Hired_B = '{0}', ", DT_Borrowers(0)("Hired_B"))
                            SQL &= String.Format(" EmploymentStat_B = '{0}', ", DT_Borrowers(0)("EmploymentStat_B"))
                            SQL &= String.Format(" Position_B = '{0}', ", DT_Borrowers(0)("Position_B"))
                            SQL &= String.Format(" Monthly_B = '{0}', ", DT_Borrowers(0)("Monthly_B"))
                            SQL &= String.Format(" BusinessName_B = '{0}', ", DT_Borrowers(0)("BusinessName_B"))
                            SQL &= String.Format(" BusinessAddress_B = '{0}', ", DT_Borrowers(0)("BusinessAddress_B"))
                            SQL &= " BusinessStarted = '', "
                            SQL &= String.Format(" NatureBusiness_B = '{0}', ", DT_Borrowers(0)("NatureBusiness_B"))
                            SQL &= String.Format(" Capital_B = '{0}', ", DT_Borrowers(0)("Capital_B"))
                            SQL &= String.Format(" NoEmployees_B = '{0}', ", DT_Borrowers(0)("NoEmployees_B"))
                            SQL &= " BusinessStock = 0, "
                            SQL &= " BusinessVehicle = '', "
                            SQL &= String.Format(" BusinessIncome_B = '{0}', ", DT_Borrowers(0)("BusinessIncome_B"))
                            SQL &= " BusinessPermit = '', "
                            SQL &= String.Format(" OtherIncome_B = '{0}', ", DT_Borrowers(0)("OtherIncome_B"))
                            SQL &= String.Format(" OtherIncome_B_Amount = '{0}', ", DT_Borrowers(0)("OtherIncome_B-Amount"))
                            SQL &= String.Format(" Creditor_1 = '{0}', ", DT_Borrowers(0)("Creditor_1"))
                            SQL &= " CreditAddress_1 = '', "
                            SQL &= " CreditGranted_1 = '', "
                            SQL &= String.Format(" Term_1 = '{0}', ", DT_Borrowers(0)("Term_1"))
                            SQL &= String.Format(" AmountGranted_1 = '{0}', ", DT_Borrowers(0)("AmountGranted_1"))
                            SQL &= String.Format(" Balance_1 = '{0}', ", DT_Borrowers(0)("Balance_1"))
                            SQL &= " CreditPayment_1 = 0, "
                            SQL &= String.Format(" CreditRemarks_1 = '{0}', ", DT_Borrowers(0)("CreditRemarks_1"))
                            SQL &= String.Format(" Creditor_2 = '{0}', ", DT_Borrowers(0)("Creditor_2"))
                            SQL &= " CreditAddress_2 = '', "
                            SQL &= " CreditGranted_2 = '', "
                            SQL &= String.Format(" Term_2 = '{0}', ", DT_Borrowers(0)("Term_2"))
                            SQL &= String.Format(" AmountGranted_2 = '{0}', ", DT_Borrowers(0)("AmountGranted_2"))
                            SQL &= String.Format(" Balance_2 = '{0}', ", DT_Borrowers(0)("Balance_2"))
                            SQL &= " CreditPayment_2 = 0, "
                            SQL &= String.Format(" CreditRemarks_2 = '{0}', ", DT_Borrowers(0)("CreditRemarks_2"))

                            SQL &= String.Format(" Bank_1 = '{0}', ", DT_Borrowers(0)("Bank_1"))
                            SQL &= String.Format(" Branch_1 = '{0}', ", DT_Borrowers(0)("Branch_1"))
                            SQL &= String.Format(" AccountT_1 = '{0}', ", DT_Borrowers(0)("AccountT_1"))
                            SQL &= String.Format(" SA_1 = '{0}', ", DT_Borrowers(0)("SA_1"))
                            SQL &= String.Format(" AverageBalance_1 = '{0}', ", DT_Borrowers(0)("AverageBalance_1"))
                            SQL &= String.Format(" Opened_1 = '{0}', ", DT_Borrowers(0)("Opened_1"))
                            SQL &= String.Format(" Bank_2 = '{0}', ", DT_Borrowers(0)("Bank_2"))
                            SQL &= String.Format(" Branch_2 = '{0}', ", DT_Borrowers(0)("Branch_2"))
                            SQL &= String.Format(" AccountT_2 = '{0}', ", DT_Borrowers(0)("AccountT_2"))
                            SQL &= String.Format(" SA_2 = '{0}', ", DT_Borrowers(0)("SA_2"))
                            SQL &= String.Format(" AverageBalance_2 = '{0}', ", DT_Borrowers(0)("AverageBalance_2"))
                            SQL &= String.Format(" Opened_2 = '{0}', ", DT_Borrowers(0)("Opened_2"))

                            SQL &= String.Format(" Location_1 = '{0}', ", DT_Borrowers(0)("Location_1"))
                            SQL &= String.Format(" TCT_1 = '{0}', ", DT_Borrowers(0)("TCT_1"))
                            SQL &= String.Format(" Area_1 = '{0}', ", DT_Borrowers(0)("Area_1"))
                            SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", DT_Borrowers(0)("PropertiesRemarks_1"))
                            SQL &= String.Format(" Location_2 = '{0}', ", DT_Borrowers(0)("Location_2"))
                            SQL &= String.Format(" TCT_2 = '{0}', ", DT_Borrowers(0)("TCT_2"))
                            SQL &= String.Format(" Area_2 = '{0}', ", DT_Borrowers(0)("Area_2"))
                            SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", DT_Borrowers(0)("PropertiesRemarks_2"))

                            SQL &= String.Format(" Vehicle_1 = '{0}', ", DT_Borrowers(0)("Vehicle_1"))
                            SQL &= String.Format(" Year_1 = '{0}', ", DT_Borrowers(0)("Year_1"))
                            SQL &= String.Format(" WhomAcquired_1 = '{0}', ", DT_Borrowers(0)("WhomAcquired_1"))
                            SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", DT_Borrowers(0)("VehicleRemarks_1"))
                            SQL &= String.Format(" Vehicle_2 = '{0}', ", DT_Borrowers(0)("Vehicle_2"))
                            SQL &= String.Format(" Year_2 = '{0}', ", DT_Borrowers(0)("Year_2"))
                            SQL &= String.Format(" WhomAcquired_2 = '{0}', ", DT_Borrowers(0)("WhomAcquired_2"))
                            SQL &= String.Format(" VehicleRemarks_2 = '{0}' ", DT_Borrowers(0)("VehicleRemarks_2"))
                        End If
                        SQL &= String.Format(" WHERE CreditNumber = '{0}' AND (`status` = 'ACTIVE' OR `status` = 'DRAFT'); ", CreditNumber)

                        DataObject(SQL)
                        Logs("Select Borrower", "Select", Reason, String.Format("Change the name of borrower for Credit Number {1} from {2} to {3} with Principal Amount of {4}.", Code, CreditNumber, CreditBorrower, cbxBorrower.Text, Principal), "", "", CreditNumber)
                        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                        btnSelect.DialogResult = DialogResult.OK
                        btnSelect.PerformClick()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Generate Code **************

        Code = GenerateOTAC()
        Timer1.Stop()
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
        If cbxBorrower.Text = "" Then
            CbxPrefix_B.Text = ""
            TxtFirstN_B.Text = ""
            TxtMiddleN_B.Text = ""
            TxtLastN_B.Text = ""
            cbxSuffix_B.Text = ""
        Else
            CbxPrefix_B.Text = drv("Prefix_B")
            TxtFirstN_B.Text = drv("FirstN_B")
            TxtMiddleN_B.Text = drv("MiddleN_B")
            TxtLastN_B.Text = drv("LastN_B")
            cbxSuffix_B.Text = drv("Suffix_B")
            If drv("Type") = "I" Then
                LabelX1.Text = "Full Name :"
            Else
                LabelX1.Text = "Represented By :"
            End If
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

    Private Sub BtnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        If MsgBoxYes(String.Format("Are you sure you want to open the profile of {0}?", cbxBorrower.Text)) = MsgBoxResult.Yes Then
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            If drv("Type") = "I" Then
                Dim Profile As New FrmBorrower
                With Profile
                    Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_borrower.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_borrower.BusinessID)) AS 'BusinessCenter' FROM profile_borrower WHERE BorrowerID = '{0}'", cbxBorrower.SelectedValue))
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
                        .ID = BorrowerP(0)("ID")
                        .TotalImage = BorrowerP(0)("Attach")
                        .btnAttach.Enabled = True
                        .txtBorrowerID.Text = cbxBorrower.SelectedValue
                        .txtBorrowerID.Tag = cbxBorrower.SelectedValue
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
                        .txtTelephone_B.Text = BorrowerP(0)("Telephone_B")
                        .txtTelephone_B.Tag = BorrowerP(0)("Telephone_B")
                        .txtSSS_B.Text = BorrowerP(0)("SSS_B")
                        .txtSSS_B.Tag = BorrowerP(0)("SSS_B")
                        .txtMobile_B.Text = BorrowerP(0)("Mobile_B")
                        .txtMobile_B.Tag = BorrowerP(0)("Mobile_B")
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
                                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), cbxBorrower.SelectedValue, "Borrower.jpg"))
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
                        .txtBusinessName_B.Tag = BorrowerP(0)("BusinessName_B")
                        .txtBusinessAddress_B.Text = BorrowerP(0)("BusinessAddress_B")
                        .txtBusinessAddress_B.Tag = BorrowerP(0)("BusinessAddress_B")
                        .txtBusinessTelephone_B.Text = BorrowerP(0)("BusinessTelephone_B")
                        .txtBusinessTelephone_B.Tag = BorrowerP(0)("BusinessTelephone_B")
                        .cbxNatureBusiness_B.Text = BorrowerP(0)("NatureBusiness_B")
                        .cbxNatureBusiness_B.Tag = BorrowerP(0)("NatureBusiness_B")

                        .cbxNatureBusiness_B2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Borrower'", cbxBorrower.SelectedValue)))

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

                        '*** I D E N T I F I C A T I O N ***
                        Dim BorrowerID As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'B'", cbxBorrower.SelectedValue))
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
                        Dim BorrowerD As DataTable = DataSource(String.Format("SELECT * FROM profile_dependent WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", cbxBorrower.SelectedValue))
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
                            Dim SpouseP As DataTable = DataSource(String.Format("SELECT * FROM profile_spouse WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", cbxBorrower.SelectedValue))
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
                                        TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), cbxBorrower.SelectedValue, "Spouse.jpg"))
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

                                .cbxNatureBusiness_S2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Spouse'", cbxBorrower.SelectedValue)))

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
                                Dim BorrowerID_S As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'S'", cbxBorrower.SelectedValue))
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
                        If Branch_Code = BorrowerP(0)("Branch_Code") Then
                            .btnModify.Enabled = True
                        Else
                            .btnModify.Enabled = False
                        End If
                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = FormBorderStyle.FixedDialog
                        .ShowDialog()
                    End If
                End With
            Else
                Dim Corporation As New FrmBorrowerCorp
                With Corporation
                    Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_corporation.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_corporation.BusinessID)) AS 'BusinessCenter' FROM profile_corporation WHERE BorrowerID = '{0}'", cbxBorrower.SelectedValue))
                    If BorrowerP.Rows.Count > 0 Then
                        .PanelEx2.Enabled = False
                        .btnSave.Enabled = False
                        .btnSaveDraft.Enabled = False
                        If Branch_Code = BorrowerP(0)("BrancH_Code") Then
                            .btnModify.Enabled = True
                        Else
                            .btnModify.Enabled = False
                        End If
                        .cbxMicro.Tag = ""
                        .cbxSmall.Tag = ""
                        .cbxMedium.Tag = ""
                        .cbxLarge.Tag = ""
                        .ID = BorrowerP(0)("ID")
                        .TotalImage = BorrowerP(0)("Attach")
                        .btnAttach.Enabled = True
                        .txtBorrowerID.Text = cbxBorrower.SelectedValue
                        .txtBorrowerID.Tag = cbxBorrower.SelectedValue
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
                                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), cbxBorrower.SelectedValue, "Corporation.jpg"))
                                ResizeImages(TempPB.Image.Clone, .pb_Logo, 650, 500)
                            End Using
                        Catch ex As Exception
                        End Try

                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = FormBorderStyle.FixedDialog
                        .ShowDialog()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub CbxOtherBranch_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOtherBranch.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub
End Class