Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmVehicleROPOA

    Dim ID As Integer
    Dim ROPOA_Status As String = "Sell"
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FileName As String
    Dim TotalImage As Integer
    Dim TotalImage_II As Integer
    Dim FirstLoad As Boolean = True
    Dim RopoaBranchCode As String
    Dim AddImage As Boolean
    Dim HidePrice As Boolean
    Dim MultipleA As Boolean

    Private Sub FrmVehicle_ROPOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5, GridView6})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        RopoaBranchCode = Branch_Code
        GetROPOA()
        SuperTabControl1.SelectedTab = tabList_2
        dtpDate.Value = CDate("1/1/1753")
        dtpYear.Value = Date.Now
        dtpRegistered.Value = Date.Now

        Dim SQL As String = " SELECT * FROM ("
        SQL &= String.Format("    SELECT BorrowerID, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower' FROM profile_borrower WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= "    UNION"
        SQL &= String.Format("    SELECT BorrowerID, TradeName FROM profile_corporation WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0})) A", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= " ORDER BY A.Borrower, A.BorrowerID"

        With cbxAccountName
            .DisplayMember = "Borrower"
            .DataSource = DataSource(SQL)
            .ValueMember = "BorrowerID"
        End With

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, `Code` FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
            If DefaultBankID > 0 Then
                .Enabled = False
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxFuel
            .DisplayMember = "Fuel"
            .DataSource = Fuel.Copy
            .SelectedIndex = -1
        End With

        With cbxMileAge
            .DisplayMember = "Mileage"
            .DataSource = MileAge.Copy
            .SelectedIndex = -1
        End With

        With cbxMake
            .ValueMember = "ID"
            .DisplayMember = "Make"
            .DataSource = Make.Copy
            .SelectedIndex = -1
        End With

        With cbxType
            .ValueMember = "ID"
            .DisplayMember = "Classification"
            .DataSource = CarClassification.Copy
            .SelectedIndex = -1
        End With

        With cbxModel
            .ValueMember = "ID"
            .DisplayMember = "Model"
            .DataSource = DataSource(String.Format("SELECT ID, Model FROM model_setup WHERE `status` = 'ACTIVE' GROUP BY Model ORDER BY Model;", cbxMake.SelectedValue))
            .SelectedIndex = -1
        End With

        With cbxYard
            .ValueMember = "ID"
            .DisplayMember = "Address"
            .DataSource = DataSource(String.Format("SELECT 1 AS 'Rank', ID, CONCAT(YardCode, '[',Address,']') AS 'Address', YardCode, ContactNumber, `Default` FROM yard_setup WHERE BranchID = 5 AND `status` = 'ACTIVE' UNION ALL SELECT 2 AS 'Rank', ID, CONCAT(YardCode, '[',Address,']') AS 'Address', YardCode, ContactNumber, `Default` FROM yard_setup WHERE BranchID != 5 AND `status` = 'ACTIVE' ORDER BY `Rank` ASC, `Default` DESC, YardCode ASC;;", cbxMake.SelectedValue))
        End With

        LoadData()
        LoadSold()
        LoadScrap()
        LoadReserved()
        LoadReclassified()
        LoadImage()
        btnBack_2.Enabled = False
        btnNext_2.Enabled = False
        iFrom.Enabled = False
        iTo.Enabled = False
        iFrom.Value = 0
        iTo.Value = 0

        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX17, LabelX22, LabelX14, LabelX43, LabelX3, LabelX6, LabelX9, LabelX15, LabelX27, LabelX23, LabelX155, LabelX4, LabelX57, LabelX7, LabelX10, LabelX25, LabelX16, LabelX12, LabelX1, LabelX20, LabelX19, LabelX24, LabelX21, LabelX2, LabelX5, LabelX56, LabelX8, LabelX13, LabelX26, LabelX11})

            GetLabelFontSettingsDefault({lblOverstay, lblLocation, lblSold, lblBlack, lblRed, lblBlue})

            GetTextBoxFontSettings({txtKeyword, txtAssetNumber, txtAccountNo, txtReason, txtSeries, txtRegistryCert, txtLTO, txtPlateNum, txtChassis, txtORNum})

            GetCheckBoxFontSettings({cbxAdvance, cbxPublish, cbxNA})

            GetCheckBoxFontSettingsRed({cbxRedemption})

            GetComboBoxWinFormFontSettings({cbxNature, cbxMake, cbxType, cbxUsed, cbxTransmission, cbxFuel, cbxCondition, cbxMileAge})

            GetComboBoxFontSettings({cbxAccountName, cbxEngine, cbxBank, cbxModel, cbxBodyColor, cbxYard})

            GetDateTimeInputFontSettings({dtpDate, dtpYear, dtpRegistered})

            GetDoubleInputFontSettings({dPrice, dBalanceTransferred, dGrossWeight, dMileAge})

            GetIntegerInputFontSettings({iFrom, iTo, iRim})

            GetRickTextBoxFontSettings({txtRemarks})

            GetButtonFontSettings({btnSearch, btnPurchase, btnHistory, btnReserve, btnReclassify, btnAppraise, btnMultipleA, btnVerify, btnAttach, btnAddImages, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnRepricing})

            GetContextMenuBarFontSettings({ContextMenuBar1})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Vehicle ROPA - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("ROPOA Vehicle", lblTitle.Text)
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetROPOA()
    End Sub

    Private Sub GetROPOA()
        txtAssetNumber.Text = DataObject(String.Format("SELECT CONCAT('ANV', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM ropoa_vehicle WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, DATE_FORMAT(trans_date,'%b %d, %Y') AS 'Date',"
        SQL &= "    Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    AssetNumber AS 'Asset Number',"
        SQL &= "    Make,"
        SQL &= "    `Type`,"
        SQL &= "    `Used`,"
        SQL &= "    Model,"
        SQL &= "    Series,"
        SQL &= "    PlateNum AS 'Plate Number',"
        SQL &= "    Transmission,"
        SQL &= "    Fuel,"
        SQL &= "    BodyColor AS 'Body Color',"
        SQL &= "    TRIM(`Year`) AS 'Year',"
        SQL &= "    EngineNum AS 'Engine Number',"
        SQL &= "    ChassisNum AS 'Chassis Number',"
        SQL &= "    RegistryCert AS 'Registry Certificate',"
        SQL &= "    ORNum AS 'OR Number',"
        SQL &= "    GrossWeight AS 'Gross Weight',"
        SQL &= "    RimHoles AS 'Rim Holes',"
        SQL &= "    CONCAT(FORMAT(MileAge,0), ' ', MileAgeType) AS 'Mile Age',"
        SQL &= "    MileAge,"
        SQL &= "    MileAgeType,"
        SQL &= "    Price, BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    IF(DateRegistered = '','',DATE_FORMAT(DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
        SQL &= "    LTO AS 'LTO Office',"
        SQL &= "    Remarks,"
        SQL &= "    Img,"
        SQL &= "    Attach,"
        SQL &= "    `Condition`,"
        SQL &= "    `ConditionReason` AS 'Reason',"
        SQL &= "    branch_code, account_count, `Status`, Bank, BankID, Attach_2, Publish, YardID, Yard(YardID) AS 'Yard'"
        SQL &= " FROM ropoa_vehicle WHERE (`status` = 'ACTIVE' OR `status` = 'PENDING') AND sell_status = 'SELL'"
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        If cbxAdvance.Checked Then
        Else
            SQL &= String.Format(" AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        If txtKeyword.Text.Trim = "" Then
        Else
            If KeywordSearchWildcard Then
                Dim Words As String() = txtKeyword.Text.Trim.Split(New Char() {" "c})
                Dim Key As String
                For Each Key In Words
                    SQL &= String.Format(" AND (`Nature` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" `AccountNo` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Make LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Model LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Series LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" PlateNum LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Transmission LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Fuel LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" BodyColor LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" TRIM(`Year`) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" EngineNum LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" ChassisNum LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" RegistryCert LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" ORNum LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Grossweight,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(RimHoles,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(MileAge,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" MileAgeType LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Price,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" Remarks LIKE '%{0}%' OR", Key)
                    If cbxAdvance.Checked Then
                        SQL &= String.Format(" `Type` LIKE '%{0}%' OR (SELECT branch.branch FROM branch WHERE branch.branch_code = ropoa_vehicle.branch_code) LIKE '%{0}%')", Key)
                    Else
                        SQL &= String.Format(" `Type` LIKE '%{0}%')", Key)
                    End If
                Next
            Else
                Dim Key As String = txtKeyword.Text
                SQL &= String.Format(" AND (`Nature` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `AccountNo` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Make LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Model LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Series LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" PlateNum LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Transmission LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Fuel LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" BodyColor LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" TRIM(`Year`) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" EngineNum LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" ChassisNum LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" RegistryCert LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" ORNum LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Grossweight,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(RimHoles,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(MileAge,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" MileAgeType LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Price,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" Remarks LIKE '%{0}%' OR", Key)
                If cbxAdvance.Checked Then
                    SQL &= String.Format(" `Type` LIKE '%{0}%' OR (SELECT branch.branch FROM branch WHERE branch.branch_code = ropoa_vehicle.branch_code) LIKE '%{0}%')", Key)
                Else
                    SQL &= String.Format(" `Type` LIKE '%{0}%')", Key)
                End If
            End If
        End If
        SQL &= " GROUP BY PlateNum, Sell_Status, AccountID ORDER BY trans_date DESC"
        GridControl2.DataSource = DataSource(SQL)
        GridView2.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView2.RowCount > 22 Then
            GridColumn115.Width = 219 - 17
        Else
            GridColumn115.Width = 219
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadSold()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT R.ID, "
        SQL &= "    S.Amount AS 'Amount',"
        SQL &= "    GREATEST(S.Amount - ROPOA_Payment(S.AssetNumber,S.ID),0) AS 'Balance',"
        SQL &= "    IFNULL(CONCAT(IF(S.Prefix_B = '','',CONCAT(S.Prefix_B, ' ')), IF(S.FirstN_B = '','',CONCAT(S.FirstN_B, ' ')), IF(S.MiddleN_B = '','',CONCAT(S.MiddleN_B, ' ')), IF(S.LastN_B = '','',CONCAT(S.LastN_B, ' ')), S.Suffix_B),'') AS 'Buyer',"
        SQL &= "    S.ID AS 'S_ID', S.Prefix_B,"
        SQL &= "    S.FirstN_B,"
        SQL &= "    S.MiddleN_B,"
        SQL &= "    S.LastN_B,"
        SQL &= "    S.Suffix_B,"
        SQL &= "    S.NoC_B,"
        SQL &= "    S.StreetC_B,"
        SQL &= "    S.BarangayC_B,"
        SQL &= "    S.AddressC_B,"
        SQL &= "    S.Contact_N, S.Reserved_Days, S.Remarks AS 'Sold Remarks', S.Referral, S.Referral_ID,"
        SQL &= "    DATE_FORMAT(R.trans_date,'%b %d, %Y') AS 'Date',"
        SQL &= "    R.Nature,"
        SQL &= "    R.AccountName AS 'Account Name',"
        SQL &= "    R.AccountNo AS 'Account No',"
        SQL &= "    R.AssetNumber AS 'Asset Number',"
        SQL &= "    R.Make,"
        SQL &= "    R.`Type`,"
        SQL &= "    R.`Used`,"
        SQL &= "    R.Model,"
        SQL &= "    R.Series,"
        SQL &= "    R.PlateNum AS 'Plate Number',"
        SQL &= "    R.Transmission,"
        SQL &= "    R.Fuel,"
        SQL &= "    R.BodyColor AS 'Body Color',"
        SQL &= "    TRIM(R.`Year`) AS 'Year',"
        SQL &= "    R.EngineNum AS 'Engine Number',"
        SQL &= "    R.ChassisNum AS 'Chassis Number',"
        SQL &= "    R.RegistryCert AS 'Registry Certificate',"
        SQL &= "    R.ORNum AS 'OR Number',"
        SQL &= "    R.GrossWeight AS 'Gross Weight',"
        SQL &= "    R.RimHoles AS 'Rim Holes',"
        SQL &= "    CONCAT(FORMAT(R.MileAge,0), ' ', R.MileAgeType) AS 'Mile Age',"
        SQL &= "    R.MileAge,"
        SQL &= "    R.MileAgeType,"
        SQL &= "    R.Price AS 'Price', R.BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    IF(R.DateRegistered = '','',DATE_FORMAT(R.DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
        SQL &= "    R.LTO AS 'LTO Office',"
        SQL &= "    R.Remarks,"
        SQL &= "    R.Img,"
        SQL &= "    R.Attach,"
        SQL &= "    R.`Condition`,"
        SQL &= "    R.`ConditionReason` AS 'Reason',"
        SQL &= "    R.branch_code, R.account_count, R.Bank, R.BankID, R.Attach_2, R.Publish, R.YardID, Yard(R.YardID) AS 'Yard'"
        SQL &= " FROM sold_ropoa S"
        SQL &= " INNER JOIN (SELECT MIN(ID) AS 'ID', Nature, GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'AccountName', GROUP_CONCAT(AccountNo) AS 'AccountNo', trans_date, MIN(AssetNumber) AS 'AssetNumber', Make, `Type`, Used, Model, Series, PLateNum, Transmission, Fuel, BodyColor, `Year`, EngineNum, ChassisNum, RegistryCert, ORNum, GrossWeight, RimHoles, MileAge, MileAgeType, Price, BalanceTransferred, DateRegistered, LTO, Remarks, Img, Attach, branch_code, `Condition`, `ConditionReason`, account_count, Bank, BankID, Attach_2, Publish, YardID FROM ropoa_vehicle WHERE sell_status = 'SOLD' AND `status` = 'ACTIVE' GROUP BY PlateNum, Sell_Status, AccountID) R"
        SQL &= "    ON S.AssetNumber = R.AssetNumber"
        SQL &= String.Format(" WHERE S.status = 'ACTIVE' AND SUBSTRING(S.AssetNumber,1,3) = 'ANV' AND FIND_IN_SET(S.Branch_ID,'{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND R.BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " ORDER BY `Buyer` DESC;"
        Dim DT_Temp As DataTable = DataSource(SQL)
Here:
        For x As Integer = 0 To DT_Temp.Rows.Count - 1
            If CDbl(DT_Temp(x)("Balance")) > 0 And CDbl(DT_Temp(x)("Balance")) > CDbl(DT_Temp(x)("Amount")) * 0.2 Then
                DT_Temp.Rows.RemoveAt(x)
                GoTo Here
            End If
        Next
        GridControl3.DataSource = DT_Temp
        GridView3.Columns("Buyer").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.Columns("Buyer").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView3.RowCount > 22 Then
            GridColumn118.Width = 244 - 17
        Else
            GridColumn118.Width = 244
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadScrap()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, DATE_FORMAT(trans_date,'%b %d, %Y') AS 'Date',"
        SQL &= "    Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    AssetNumber AS 'Asset Number',"
        SQL &= "    Make,"
        SQL &= "    `Type`,"
        SQL &= "    `Used`,"
        SQL &= "    Model,"
        SQL &= "    Series,"
        SQL &= "    PlateNum AS 'Plate Number',"
        SQL &= "    Transmission,"
        SQL &= "    Fuel,"
        SQL &= "    BodyColor AS 'Body Color',"
        SQL &= "    TRIM(`Year`) AS 'Year',"
        SQL &= "    EngineNum AS 'Engine Number',"
        SQL &= "    ChassisNum AS 'Chassis Number',"
        SQL &= "    RegistryCert AS 'Registry Certificate',"
        SQL &= "    ORNum AS 'OR Number',"
        SQL &= "    GrossWeight AS 'Gross Weight',"
        SQL &= "    RimHoles AS 'Rim Holes',"
        SQL &= "    CONCAT(FORMAT(MileAge,0), ' ', MileAgeType) AS 'Mile Age',"
        SQL &= "    MileAge,"
        SQL &= "    MileAgeType,"
        SQL &= "    Price, BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    IF(DateRegistered = '','',DATE_FORMAT(DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
        SQL &= "    LTO AS 'LTO Office',"
        SQL &= "    Remarks,"
        SQL &= "    Img,"
        SQL &= "    Attach,"
        SQL &= "    `Condition`,"
        SQL &= "    `ConditionReason` AS 'Reason',"
        SQL &= "    branch_code, account_count, Bank, BankID, Attach_2, Publish, YardID, Yard(YardID) AS 'Yard'"
        SQL &= String.Format(" FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND sell_status = 'SCRAP' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " GROUP BY PlateNum, Sell_Status, AccountID ORDER BY trans_date DESC"
        GridControl4.DataSource = DataSource(SQL)
        GridView4.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView4.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView4.RowCount > 22 Then
            GridColumn121.Width = 219 - 17
        Else
            GridColumn121.Width = 219
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadReserved()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT R.ID, "
        SQL &= "    IFNULL(S.Amount,0) AS 'Amount',"
        SQL &= "    GREATEST(IFNULL(S.Amount,0) - ROPOA_Payment(S.AssetNumber,S.ID),0) AS 'Balance',"
        SQL &= "    ROPOA_Buyer(R.AssetNumber) AS 'Buyer',"
        SQL &= "    S.ID AS 'S_ID', S.Prefix_B,"
        SQL &= "    S.FirstN_B,"
        SQL &= "    S.MiddleN_B,"
        SQL &= "    S.LastN_B,"
        SQL &= "    S.Suffix_B,"
        SQL &= "    S.NoC_B,"
        SQL &= "    S.StreetC_B,"
        SQL &= "    S.BarangayC_B,"
        SQL &= "    S.AddressC_B,"
        SQL &= "    S.Contact_N, S.Referral, S.Referral_ID, "
        SQL &= "    DATE_FORMAT(R.trans_date,'%b %d, %Y') AS 'Date',"
        SQL &= "    R.Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    R.AssetNumber AS 'Asset Number',"
        SQL &= "    R.Make,"
        SQL &= "    R.`Type`,"
        SQL &= "    R.`Used`,"
        SQL &= "    R.Model,"
        SQL &= "    R.Series,"
        SQL &= "    R.PlateNum AS 'Plate Number',"
        SQL &= "    R.Transmission,"
        SQL &= "    R.Fuel,"
        SQL &= "    R.BodyColor AS 'Body Color',"
        SQL &= "    TRIM(R.`Year`) AS 'Year',"
        SQL &= "    R.EngineNum AS 'Engine Number',"
        SQL &= "    R.ChassisNum AS 'Chassis Number',"
        SQL &= "    R.RegistryCert AS 'Registry Certificate',"
        SQL &= "    R.ORNum AS 'OR Number',"
        SQL &= "    R.GrossWeight AS 'Gross Weight',"
        SQL &= "    R.RimHoles AS 'Rim Holes',"
        SQL &= "    CONCAT(FORMAT(R.MileAge,0), ' ', R.MileAgeType) AS 'Mile Age',"
        SQL &= "    R.MileAge,"
        SQL &= "    R.MileAgeType,"
        SQL &= "    R.Price AS 'Price', R.BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    IF(R.DateRegistered = '','',DATE_FORMAT(R.DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
        SQL &= "    R.LTO AS 'LTO Office',"
        SQL &= "    R.Remarks,"
        SQL &= "    R.Img,"
        SQL &= "    R.Attach,"
        SQL &= "    R.`Condition`,"
        SQL &= "    R.`ConditionReason` AS 'Reason',"
        SQL &= "    IFNULL(S.reserved_days,0) AS 'reserved_days',"
        SQL &= "    IFNULL(S.reserved_status,'NO') AS 'reserved_status',"
        SQL &= "    R.`reserve_reason` AS 'Reserved Reason',"
        SQL &= "    R.branch_code, R.account_count, R.Bank, R.BankID, R.Attach_2, R.Publish, YardID, Yard(YardID) AS 'Yard'"
        SQL &= " FROM ropoa_vehicle R"
        SQL &= " LEFT JOIN (SELECT ID, Amount, AssetNumber, Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, NoC_B, StreetC_B, BarangayC_B, AddressC_B, Contact_N, reserved_days, reserved_status, Referral, Referral_ID FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANV') S"
        SQL &= "    ON S.AssetNumber = R.AssetNumber"
        SQL &= String.Format(" WHERE (R.sell_status = 'SOLD' OR R.sell_status = 'RESERVED') AND `status` = 'ACTIVE' AND FIND_IN_SET(R.Branch_ID,'{0}') GROUP BY PlateNum, Sell_Status", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND R.BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " ORDER BY trans_date DESC;"

        Dim DT As DataTable = DataSource(SQL)
Here:
        For x As Integer = 0 To DT.Rows.Count - 1
            If (CDbl(DT(x)("Amount")) * 0.2 >= CDbl(DT(x)("Balance")) Or CDbl(DT(x)("Balance")) = 0) And DT(x)("Buyer") <> "" Then
                DT.Rows.RemoveAt(x)
                GoTo Here
            End If
        Next
        GridControl5.DataSource = DT
        GridView5.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView5.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView5.RowCount > 22 Then
            GridColumn126.Width = 244 - 17
        Else
            GridColumn126.Width = 244
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadReclassified()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, DATE_FORMAT(trans_date,'%b %d, %Y') AS 'Date',"
        SQL &= "    Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    AssetNumber AS 'Asset Number',"
        SQL &= "    Make,"
        SQL &= "    `Type`,"
        SQL &= "    `Used`,"
        SQL &= "    Model,"
        SQL &= "    Series,"
        SQL &= "    PlateNum AS 'Plate Number',"
        SQL &= "    Transmission,"
        SQL &= "    Fuel,"
        SQL &= "    BodyColor AS 'Body Color',"
        SQL &= "    TRIM(`Year`) AS 'Year',"
        SQL &= "    EngineNum AS 'Engine Number',"
        SQL &= "    ChassisNum AS 'Chassis Number',"
        SQL &= "    RegistryCert AS 'Registry Certificate',"
        SQL &= "    ORNum AS 'OR Number',"
        SQL &= "    GrossWeight AS 'Gross Weight',"
        SQL &= "    RimHoles AS 'Rim Holes',"
        SQL &= "    CONCAT(FORMAT(MileAge,0), ' ', MileAgeType) AS 'Mile Age',"
        SQL &= "    MileAge,"
        SQL &= "    MileAgeType,"
        SQL &= "    Price, BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    IF(DateRegistered = '','',DATE_FORMAT(DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
        SQL &= "    LTO AS 'LTO Office',"
        SQL &= "    Remarks,"
        SQL &= "    Img,"
        SQL &= "    Attach,"
        SQL &= "    `Condition`,"
        SQL &= "    `ConditionReason` AS 'Reason',"
        SQL &= "    `reserve_reason` AS 'Reserved Reason',"
        SQL &= "    branch_code, account_count, Bank, BankID, Attach_2, Publish, YardID, Yard(YardID) AS 'Yard'"
        SQL &= String.Format(" FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND sell_status = 'RECLASSIFIED' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " GROUP BY PlateNum, Sell_Status, AccountID ORDER BY trans_date DESC"
        GridControl6.DataSource = DataSource(SQL)
        GridView6.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView6.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView6.RowCount > 22 Then
            GridColumn160.Width = 219 - 17
        Else
            GridColumn160.Width = 219
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxNature_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNature.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAccountName.Focus()
            cbxAccountName.DroppedDown = True
        End If
    End Sub

    Private Sub CbxAccountName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAccountName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountNo.Focus()
        End If
    End Sub

    Private Sub TxtAccountNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCondition.Focus()
            cbxCondition.DroppedDown = True
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCondition.Focus()
            cbxCondition.DroppedDown = True
        End If
    End Sub

    Private Sub CbxCondition_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCondition.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReason.Focus()
        End If
    End Sub

    Private Sub TxtReason_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMake.Focus()
            cbxMake.DroppedDown = True
        End If
    End Sub

    Private Sub CbxMake_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMake.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxType.Focus()
            cbxType.DroppedDown = True
        End If
    End Sub

    Private Sub CbxType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxModel.Focus()
            cbxModel.DroppedDown = True
        End If
    End Sub

    Private Sub CbxModel_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxModel.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSeries.Focus()
        End If
    End Sub

    Private Sub TxtSeries_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeries.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPlateNum.Focus()
        End If
    End Sub

    Private Sub TxtPlateNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlateNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTransmission.Focus()
            cbxTransmission.DroppedDown = True
        End If
    End Sub

    Private Sub CbxTransmission_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTransmission.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFuel.Focus()
            cbxFuel.DroppedDown = True
        End If
    End Sub

    Private Sub CbxFuel_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFuel.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBodyColor.Focus()
        End If
    End Sub

    Private Sub CbxBodyColor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBodyColor.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear.Focus()
        End If
    End Sub

    Private Sub DtpYear_Click(sender As Object, e As EventArgs) Handles dtpYear.Click
        dtpYear.CustomFormat = "     yyyy"
    End Sub

    Private Sub DtpYear_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEngine.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpYear.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxMotorNum_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEngine.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtChassis.Focus()
        End If
    End Sub

    Private Sub TxtSerialNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChassis.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRegistryCert.Focus()
        End If
    End Sub

    Private Sub TxtRegistryCert_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRegistryCert.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtORNum.Focus()
        End If
    End Sub

    Private Sub TxtORNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtORNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGrossWeight.Focus()
        End If
    End Sub

    Private Sub DGrossWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles dGrossWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            iRim.Focus()
        End If
    End Sub

    Private Sub IRim_KeyDown(sender As Object, e As KeyEventArgs) Handles iRim.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMileAge.Focus()
        End If
    End Sub

    Private Sub DMileAge_KeyDown(sender As Object, e As KeyEventArgs) Handles dMileAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dPrice.Visible Then
                dPrice.Focus()
            Else
                dtpRegistered.Focus()
            End If
        End If
    End Sub

    Private Sub DPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles dPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpRegistered.Focus()
        End If
    End Sub

    Private Sub DtpRegistered_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRegistered.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLTO.Focus()
        End If
    End Sub

    Private Sub TxtLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dBalanceTransferred.Visible Then
                dBalanceTransferred.Focus()
            Else
                txtRemarks.Focus()
            End If
        End If
    End Sub

    Private Sub DROPOA_Value_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalanceTransferred.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddImage.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtKeyword_Leave(sender As Object, e As EventArgs) Handles txtKeyword.Leave
        txtKeyword.Text = ReplaceText(txtKeyword.Text.Trim)
    End Sub

    Private Sub TxtReason_Leave(sender As Object, e As EventArgs) Handles txtReason.Leave
        txtReason.Text = ReplaceText(txtReason.Text.Trim)
    End Sub

    Private Sub TxtAccountNo_Leave(sender As Object, e As EventArgs) Handles txtAccountNo.Leave
        txtAccountNo.Text = ReplaceText(txtAccountNo.Text.Trim)
    End Sub

    Private Sub CbxMake_Leave(sender As Object, e As EventArgs) Handles cbxMake.Leave
        cbxMake.Text = ReplaceText(cbxMake.Text.Trim)
    End Sub

    Private Sub CbxType_Leave(sender As Object, e As EventArgs) Handles cbxType.Leave
        cbxType.Text = ReplaceText(cbxType.Text.Trim)
    End Sub

    Private Sub CbxModel_Leave(sender As Object, e As EventArgs) Handles cbxModel.Leave
        cbxModel.Text = ReplaceText(cbxModel.Text.Trim)
    End Sub

    Private Sub TxtSeries_Leave(sender As Object, e As EventArgs) Handles txtSeries.Leave
        txtSeries.Text = ReplaceText(txtSeries.Text.Trim)
    End Sub

    Private Sub TxtPlateNum_Leave(sender As Object, e As EventArgs) Handles txtPlateNum.Leave
        txtPlateNum.Text = ReplaceText(txtPlateNum.Text.Trim)
    End Sub

    Private Sub CbxTransmission_Leave(sender As Object, e As EventArgs) Handles cbxTransmission.Leave
        cbxTransmission.Text = ReplaceText(cbxTransmission.Text.Trim)
    End Sub

    Private Sub CbxFuel_Leave(sender As Object, e As EventArgs) Handles cbxFuel.Leave
        cbxFuel.Text = ReplaceText(cbxFuel.Text.Trim)
    End Sub

    Private Sub CbxBodyColor_Leave(sender As Object, e As EventArgs) Handles cbxBodyColor.Leave
        cbxBodyColor.Text = ReplaceText(cbxBodyColor.Text.Trim)
    End Sub

    Private Sub CbxMotorNum_Leave(sender As Object, e As EventArgs) Handles cbxEngine.Leave
        cbxEngine.Text = ReplaceText(cbxEngine.Text.Trim).ToString.ToUpper
    End Sub

    Private Sub TxtSerialNum_Leave(sender As Object, e As EventArgs) Handles txtChassis.Leave
        txtChassis.Text = ReplaceText(txtChassis.Text.Trim)
    End Sub

    Private Sub TxtRegistryCert_Leave(sender As Object, e As EventArgs) Handles txtRegistryCert.Leave
        txtRegistryCert.Text = ReplaceText(txtRegistryCert.Text.Trim)
    End Sub

    Private Sub TxtORNum_Leave(sender As Object, e As EventArgs) Handles txtORNum.Leave
        txtORNum.Text = ReplaceText(txtORNum.Text.Trim)
    End Sub

    Private Sub CbxMileAge_Leave(sender As Object, e As EventArgs) Handles cbxMileAge.Leave
        cbxMileAge.Text = ReplaceText(cbxMileAge.Text.Trim)
    End Sub

    Private Sub TxtLTO_Leave(sender As Object, e As EventArgs) Handles txtLTO.Leave
        txtLTO.Text = ReplaceText(txtLTO.Text.Trim)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text.Trim)
    End Sub
#End Region

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList_2
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSold
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabScrap
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabReserve
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            SuperTabControl1.SelectedTab = tabReclassified
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabList_2
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabSold
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            SuperTabControl1.SelectedTab = tabScrap
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            SuperTabControl1.SelectedTab = tabReserve
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            txtKeyword.Enabled = True
            cbxAdvance.Enabled = True
            btnSearch.Enabled = True
            btnBack.Enabled = False
            btnAdd.Enabled = False

            If iFrom.Value = 0 Or iTo.Value = 0 Or btnVerify.Enabled = True Then
                btnSave.Enabled = True
                btnModify.Enabled = False
                btnPurchase.Enabled = False
                btnHistory.Enabled = False
                btnReserve.Enabled = False
                btnReclassify.Enabled = False
                btnAppraise.Enabled = False
                btnMultipleA.Enabled = False
            Else
                btnSave.Enabled = False
                btnModify.Enabled = True
                btnPurchase.Enabled = True
                btnHistory.Enabled = True
                btnReserve.Enabled = True
                btnReclassify.Enabled = True
                btnAppraise.Enabled = True
                btnMultipleA.Enabled = True
            End If
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnRepricing.Enabled = False

            lblBlack.Text = ""
            lblRed.Text = ""
            lblBlue.Text = ""
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If txtKeyword.Enabled = True Then
            Else
                Clear()
                btnSave.Enabled = False
                btnModify.Enabled = True
                btnBack_2.Enabled = False
                btnNext_2.Enabled = False
                iFrom.Enabled = False
                iTo.Enabled = False
                iTo.Value = 0
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnRepricing.Enabled = True

            lblBlack.Text = "Verified ROPA"
            lblRed.Text = "Pending ROPA (for Verification)"
            lblBlue.Text = "Overstayed ROPA"

            iDiscount.Visible = False
            iBuyer.Visible = False
            iReferral.Visible = False
            iPDC.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Or SuperTabControl1.SelectedTabIndex = 4 Then
            If txtKeyword.Enabled = True Then
            Else
                Clear()
                btnSave.Enabled = False
                btnModify.Enabled = True
                btnBack_2.Enabled = False
                btnNext_2.Enabled = False
                iFrom.Enabled = False
                iTo.Enabled = False
                iTo.Value = 0
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnRepricing.Enabled = False

            iDiscount.Visible = False
            If SuperTabControl1.SelectedTabIndex = 4 Then
                iPDC.Visible = True
            Else
                iPDC.Visible = False
            End If
            If SuperTabControl1.SelectedTabIndex = 4 Then
                lblBlack.Text = ""
                lblRed.Text = "With Reservation Only"
                lblBlue.Text = "With Downpayment"
            Else
                lblBlack.Text = ""
                lblRed.Text = ""
                lblBlue.Text = ""
            End If

            If SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 4 Then
                iBuyer.Visible = True
                iReferral.Visible = True
                iPDC.Visible = True
            Else
                iDiscount.Visible = False
                iBuyer.Visible = False
                iReferral.Visible = False
                iPDC.Visible = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            If txtKeyword.Enabled = True Then
            Else
                Clear()
                btnSave.Enabled = False
                btnModify.Enabled = True
                btnBack_2.Enabled = False
                btnNext_2.Enabled = False
                iFrom.Enabled = False
                iTo.Enabled = False
                iTo.Value = 0
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnRepricing.Enabled = False

            lblBlack.Text = ""
            lblRed.Text = ""
            lblBlue.Text = ""

            iDiscount.Visible = False
            iBuyer.Visible = False
            iReferral.Visible = False
            iPDC.Visible = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                iFrom.Value = 0
                iTo.Value = 0
                Clear()
                txtKeyword.Text = ""
                btnNext_2.Enabled = False
                btnBack_2.Enabled = False
                btnAddImage.Enabled = True
                dtpDate.Enabled = True

                Dim SQL As String = " SELECT * FROM ("
                SQL &= "    SELECT BorrowerID, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',IF(Suffix_B = '',LastN_B,CONCAT(LastN_B, ' '))), Suffix_B) AS 'Borrower' FROM profile_borrower WHERE `status` = 'ACTIVE'"
                SQL &= "    UNION"
                SQL &= "    SELECT BorrowerID, TradeName FROM profile_corporation WHERE `status` = 'ACTIVE' ) A"
                SQL &= " ORDER BY A.Borrower, A.BorrowerID"

                With cbxAccountName
                    .DisplayMember = "Borrower"
                    .DataSource = DataSource(SQL)
                    .ValueMember = "BorrowerID"
                    .Text = ""
                End With

                With cbxBank
                    .ValueMember = "ID"
                    .DisplayMember = "Bank"
                    .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, `Code` FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
                    If DefaultBankID > 0 Then
                        .Enabled = False
                    Else
                        .SelectedIndex = -1
                    End If
                End With

                Make = DataSource("SELECT ID, Make FROM make_setup WHERE `status` = 'ACTIVE' ORDER BY make")
                CarClassification = DataSource("SELECT ID, Classification FROM automotive_setup WHERE `status` = 'ACTIVE' ORDER BY Classification")
                With cbxMake
                    .ValueMember = "ID"
                    .DisplayMember = "Make"
                    .DataSource = Make.Copy
                    .SelectedIndex = -1
                End With

                With cbxType
                    .ValueMember = "ID"
                    .DisplayMember = "Classification"
                    .DataSource = CarClassification.Copy
                    .SelectedIndex = -1
                End With

                With cbxYard
                    .ValueMember = "ID"
                    .DisplayMember = "Address"
                    .DataSource = DataSource(String.Format("SELECT 1 AS 'Rank', ID, CONCAT(YardCode, '[',Address,']') AS 'Address', YardCode, ContactNumber, `Default` FROM yard_setup WHERE BranchID = 5 AND `status` = 'ACTIVE' UNION ALL SELECT 2 AS 'Rank', ID, CONCAT(YardCode, '[',Address,']') AS 'Address', YardCode, ContactNumber, `Default` FROM yard_setup WHERE BranchID != 5 AND `status` = 'ACTIVE' ORDER BY `Rank` ASC, `Default` DESC, YardCode ASC;;", cbxMake.SelectedValue))
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            txtKeyword.Text = ""
            GridColumn33.Visible = True
            LoadData()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            LoadSold()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            LoadScrap()
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            LoadReserved()
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            LoadReclassified()
        End If
    End Sub

    Public Sub Clear()
        cbxAdvance.Checked = False
        cbxAdvance.Enabled = True
        cbxPublish.Checked = True
        txtKeyword.Enabled = True
        btnSearch.Enabled = True
        RopoaBranchCode = Branch_Code
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnVerify.Enabled = False
        cbxNature.SelectedIndex = -1
        cbxAccountName.Text = ""
        txtAccountNo.Text = ""
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        dtpDate.CustomFormat = ""
        dtpDate.Value = "1/1/1753"
        cbxCondition.SelectedIndex = -1
        txtReason.Text = ""
        cbxMake.SelectedIndex = -1
        cbxType.SelectedIndex = -1
        cbxUsed.SelectedIndex = -1
        cbxModel.SelectedIndex = -1
        txtSeries.Text = ""
        txtPlateNum.Text = ""
        cbxTransmission.SelectedIndex = -1
        cbxFuel.SelectedIndex = -1
        cbxBodyColor.Text = ""
        dtpYear.Value = Date.Now
        cbxEngine.Text = ""
        txtChassis.Text = ""
        txtRegistryCert.Text = ""
        txtORNum.Text = ""
        dGrossWeight.Value = 0
        iRim.Value = 0
        dMileAge.Value = 0
        cbxMileAge.SelectedIndex = -1
        dPrice.Value = 0
        dPrice.Enabled = True
        dBalanceTransferred.Value = 0
        dBalanceTransferred.Enabled = True
        dtpRegistered.Value = Date.Now
        txtLTO.Text = ""
        txtRemarks.Text = ""
        btnPurchase.Enabled = False
        btnHistory.Enabled = False
        btnReserve.Enabled = False
        btnReclassify.Enabled = False
        btnAppraise.Enabled = False
        btnMultipleA.Enabled = False
        PanelEx2.Enabled = True
        lblSold.Visible = False
        For Each Pic As DevExpress.XtraEditors.PictureEdit In PanelEx4.Controls
            Pic.Image = Nothing
        Next
        AddImage = False
        TotalImage_II = 0
        btnAttach.Enabled = False
        LabelX15.Visible = True
        dPrice.Visible = True
        LabelX27.Visible = True
        dBalanceTransferred.Visible = True
        GridColumn32.Visible = True
        GridColumn55.Visible = True
        GridColumn98.Visible = True
        GridColumn146.Visible = True
        GridColumn180.Visible = True
        HidePrice = False

        PanelEx4.Enabled = True
        cbxNature.Enabled = True
        cbxAccountName.Enabled = True
        txtAccountNo.Enabled = True
        cbxCondition.Enabled = True
        txtReason.Enabled = True
        cbxMake.Enabled = True
        cbxType.Enabled = True
        cbxModel.Enabled = True
        txtPlateNum.Enabled = True
        cbxTransmission.Enabled = True
        cbxFuel.Enabled = True
        cbxBodyColor.Enabled = True
        dtpYear.Enabled = True
        cbxEngine.Enabled = True
        txtChassis.Enabled = True
        txtRegistryCert.Enabled = True
        txtORNum.Enabled = True
        dGrossWeight.Enabled = True
        iRim.Enabled = True
        dMileAge.Enabled = True
        dPrice.Enabled = True
        txtRemarks.Enabled = True

        MultipleA = False
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

        If cbxNature.Text = "" Or cbxNature.SelectedIndex = -1 Then
            MsgBox("Please select nature of ROPOA.", MsgBoxStyle.Information, "Info")
            cbxNature.DroppedDown = True
            Exit Sub
        End If
        If cbxAccountName.Text.Trim = "" Or cbxAccountName.SelectedIndex = -1 Then
            MsgBox("Selected Account Name is not in the list, please check you data.", MsgBoxStyle.Information, "Info")
            cbxAccountName.DroppedDown = True
            Exit Sub
        End If
        If txtAccountNo.Text.Trim = "" Then
            MsgBox("Please fill the account no", MsgBoxStyle.Information, "Info")
            txtAccountNo.Focus()
            Exit Sub
        End If
        If dtpDate.CustomFormat = "" Then
            MsgBox("Please fill the correct ROPOA Date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If IsDate(dtpDate.Text) = False Then
            MsgBox("Please fill the correct ROPOA Date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dtpDate.Value = CDate("1/1/1753") Then
            MsgBox("Please fill the correct ROPOA Date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dtpDate.Value = Date.Now Then
            If MsgBoxYes("Are you sure that the ROPOA Date is today?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dtpDate.Value >= Date.Now Then
            If MsgBoxYes(String.Format("Are you sure that the ROPOA Date is on {0}?", dtpDate.Text)) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxCondition.Text = "" Or cbxCondition.SelectedIndex = -1 Then
            MsgBox("Please select condition.", MsgBoxStyle.Information, "Info")
            cbxCondition.DroppedDown = True
            Exit Sub
        End If
        If cbxCondition.Text = "Not Running" Then
            If txtReason.Text = "" Then
                MsgBox("Please fill reason for condition not running.", MsgBoxStyle.Information, "Info")
                txtReason.Focus()
                Exit Sub
            End If
        End If
        If cbxMake.Text = "" Or cbxMake.SelectedIndex = -1 Then
            MsgBox("Please select maker.", MsgBoxStyle.Information, "Info")
            cbxMake.DroppedDown = True
            Exit Sub
        End If
        If cbxType.Text = "" Or cbxType.SelectedIndex = -1 Then
            MsgBox("Please select type.", MsgBoxStyle.Information, "Info")
            cbxType.DroppedDown = True
            Exit Sub
        End If
        If cbxModel.Text = "" Then
            If MsgBoxYes("Model is empty, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                cbxModel.DroppedDown = True
                Exit Sub
            End If
        End If
        If txtPlateNum.Text = "" Then
            MsgBox("Please fill Plate Number field.", MsgBoxStyle.Information, "Info")
            txtPlateNum.Focus()
            Exit Sub
        End If
        If cbxTransmission.Text = "" Or cbxTransmission.SelectedIndex = -1 Then
            MsgBox("Please select transmission.", MsgBoxStyle.Information, "Info")
            cbxTransmission.DroppedDown = True
            Exit Sub
        End If
        If cbxFuel.Text = "" Or cbxFuel.SelectedIndex = -1 Then
            MsgBox("Please select fuel.", MsgBoxStyle.Information, "Info")
            cbxFuel.DroppedDown = True
            Exit Sub
        End If
        If dPrice.Value = 0 Then
            dPrice.Value = 1
        End If
        If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
            If dBalanceTransferred.Value = 0 Then
                MsgBox("Please fill Balance Transfer.", MsgBoxStyle.Information, "Info")
                dBalanceTransferred.Focus()
                Exit Sub
            End If
        End If
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            MsgBox("Please select a bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        Dim Bank As Integer = drv("Code")

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                If MultipleA = False Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_vehicle WHERE (PlateNum = '{0}' OR RegistryCert = '{1}' OR ORNum = '{2}') AND (`status` = 'ACTIVE' OR `status` = 'PENDING') AND sell_status != 'SOLD'", txtPlateNum.Text, txtRegistryCert.Text, txtORNum.Text))
                    If Exist > 0 Then
                        MsgBox(String.Format("Either Plate Number, Registry Certificate or OR Number already exist, Please check your data.", txtPlateNum.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                Cursor = Cursors.WaitCursor
                GetROPOA()

                Dim SQL As String = "INSERT INTO ropoa_vehicle SET"
                SQL &= String.Format(" Nature = '{0}', ", cbxNature.Text)
                SQL &= String.Format(" Publish = '{0}', ", If(cbxPublish.Checked, 1, 0))
                SQL &= String.Format(" AccountID = '{0}', ", cbxAccountName.SelectedValue)
                SQL &= String.Format(" AccountNo = '{0}', ", txtAccountNo.Text)
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AssetNumber = '{0}', ", txtAssetNumber.Text)
                SQL &= String.Format(" `Condition` = '{0}', ", cbxCondition.Text)
                SQL &= String.Format(" `ConditionReason` = '{0}', ", txtReason.Text)
                SQL &= String.Format(" Make = '{0}', ", cbxMake.Text)
                SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                SQL &= String.Format(" `Used` = '{0}', ", cbxUsed.Text)
                SQL &= String.Format(" Model = '{0}', ", cbxModel.Text)
                SQL &= String.Format(" Series = '{0}', ", txtSeries.Text)
                SQL &= String.Format(" PlateNum = '{0}', ", txtPlateNum.Text)
                SQL &= String.Format(" Transmission = '{0}', ", cbxTransmission.Text)
                SQL &= String.Format(" Fuel = '{0}', ", cbxFuel.Text)
                SQL &= String.Format(" BodyColor = '{0}', ", cbxBodyColor.Text)
                SQL &= String.Format(" `Year` = '{0}', ", If(dtpYear.CustomFormat = "", "", dtpYear.Text))
                SQL &= String.Format(" EngineNum = '{0}', ", cbxEngine.Text)
                SQL &= String.Format(" ChassisNum = '{0}', ", txtChassis.Text)
                SQL &= String.Format(" RegistryCert = '{0}', ", txtRegistryCert.Text)
                SQL &= String.Format(" ORNum = '{0}', ", txtORNum.Text)
                SQL &= String.Format(" GrossWeight = '{0}', ", dGrossWeight.Value)
                SQL &= String.Format(" RimHoles = '{0}', ", iRim.Value)
                SQL &= String.Format(" MileAge = '{0}', ", dMileAge.Value)
                SQL &= String.Format(" MileAgeType = '{0}', ", cbxMileAge.Text)
                SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
                SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
                SQL &= String.Format(" DateRegistered = '{0}', ", FormatDatePicker(dtpRegistered))
                SQL &= String.Format(" LTO = '{0}', ", txtLTO.Text)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" Img = '{0}', ", TotalImage)
                SQL &= String.Format(" Bank = '{0}', ", Bank)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                Else
                    If MultipleA Then
                        SQL &= String.Format(" `status` = '{0}', ", DataObject(String.Format("SELECT `status` FROM ropoa_vehicle WHERE PlateNum = '{0}' AND RegistryCert = '{1}' AND ORNum = '{2}' AND (`status` = 'ACTIVE' OR `status` = 'PENDING') LIMIT 1;", txtPlateNum.Text, txtRegistryCert.Text, txtORNum.Text)))
                    Else
                        SQL &= " `status` = 'PENDING', "
                    End If
                End If
                SQL &= String.Format(" YardID = '{0}', ", ValidateComboBox(cbxYard))
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" branch_code = '{0}', ", RopoaBranchCode)
                SQL &= String.Format(" User_Code = '{0}';", User_Code)

                If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                    'ACCOUNTING ENTRY *******************************************************************************************************
                    SQL &= " INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    SQL &= " EntryType = 'DEBIT',"
                    SQL &= String.Format(" Payable = '{0}', ", dBalanceTransferred.Value)
                    SQL &= String.Format(" Amount = '{0}', ", dBalanceTransferred.Value)
                    SQL &= " AccountCode = '126002X', "
                    SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126002")))
                    If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                        SQL &= " PostStatus = 'POSTED', "
                    End If
                    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                    SQL &= String.Format(" ReferenceN = '{0}', ", txtAssetNumber.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" CVNumber = '{0}', ", txtPlateNum.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    'ACCOUNTING ENTRY *******************************************************************************************************
                End If
                DataObject(SQL)
                For x As Integer = 1 To TotalImage
                    Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                    If pb.Image Is Nothing Then
                    Else
                        ResizeImages(pb.Image.Clone, pb, 850, 700)
                        SaveImage(pb, pb.Properties.NullText & x)
                    End If
                Next

                If MultipleA Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET account_count = account_count + 1 WHERE PlateNum = '{0}' AND RegistryCert = '{1}' AND ORNum = '{2}';", txtPlateNum.Text, txtRegistryCert.Text, txtORNum.Text))
                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber FROM ropoa_vehicle WHERE PlateNum = '{0}' AND `status` = 'ACTIVE'", txtPlateNum.Text))
                    For x As Integer = 0 To DT.Rows.Count - 1
                        DataObject(String.Format("UPDATE ledger_ropoa SET ropoa_ref = '{0}' WHERE asset_number = '{1}'", txtPlateNum.Text, DT(x)("AssetNumber")))
                    Next
                End If
                Logs("ROPOA Vehicle", "Save", String.Format("Add new ROPOA Vehicle {0}", txtAssetNumber.Text), "", "", "", "")
                Clear()
                LoadData()
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                If MultipleA = False Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_vehicle WHERE (PlateNum = '{0}' OR RegistryCert = '{1}' OR ORNum = '{2}') AND (`status` = 'ACTIVE' OR `status` = 'PENDING') AND AssetNumber != '{3}' AND sell_status != 'SOLD'", txtPlateNum.Text, txtRegistryCert.Text, txtORNum.Text, txtAssetNumber.Text))
                    If Exist > 0 Then
                        MsgBox(String.Format("Either Plate Number, Registry Certificate or OR Number already exist, Please check your data.", txtPlateNum.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                Cursor = Cursors.WaitCursor

                Dim SQL As String = "UPDATE ropoa_vehicle SET"
                SQL &= String.Format(" Nature = '{0}', ", cbxNature.Text)
                SQL &= String.Format(" Publish = '{0}', ", If(cbxPublish.Checked, 1, 0))
                If MultipleA = False Then
                    SQL &= String.Format(" AccountID = '{0}', ", cbxAccountName.SelectedValue)
                    SQL &= String.Format(" AccountNo = '{0}', ", txtAccountNo.Text)
                End If
                If dtpDate.Enabled Then
                    SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                    SQL &= String.Format(" AssetNumber = '{0}', ", txtAssetNumber.Text)
                End If
                SQL &= String.Format(" `Condition` = '{0}', ", cbxCondition.Text)
                SQL &= String.Format(" `ConditionReason` = '{0}', ", txtReason.Text)
                SQL &= String.Format(" Make = '{0}', ", cbxMake.Text)
                SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                SQL &= String.Format(" `Used` = '{0}', ", cbxUsed.Text)
                SQL &= String.Format(" Model = '{0}', ", cbxModel.Text)
                SQL &= String.Format(" Series = '{0}', ", txtSeries.Text)
                SQL &= String.Format(" PlateNum = '{0}', ", txtPlateNum.Text)
                SQL &= String.Format(" Transmission = '{0}', ", cbxTransmission.Text)
                SQL &= String.Format(" Fuel = '{0}', ", cbxFuel.Text)
                SQL &= String.Format(" BodyColor = '{0}', ", cbxBodyColor.Text)
                SQL &= String.Format(" `Year` = '{0}', ", If(dtpYear.CustomFormat = "", "", dtpYear.Text))
                SQL &= String.Format(" EngineNum = '{0}', ", cbxEngine.Text)
                SQL &= String.Format(" ChassisNum = '{0}', ", txtChassis.Text)
                SQL &= String.Format(" RegistryCert = '{0}', ", txtRegistryCert.Text)
                SQL &= String.Format(" ORNum = '{0}', ", txtORNum.Text)
                SQL &= String.Format(" GrossWeight = '{0}', ", dGrossWeight.Value)
                SQL &= String.Format(" RimHoles = '{0}', ", iRim.Value)
                SQL &= String.Format(" MileAge = '{0}', ", dMileAge.Value)
                SQL &= String.Format(" MileAgeType = '{0}', ", cbxMileAge.Text)
                SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
                SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
                SQL &= String.Format(" DateRegistered = '{0}', ", FormatDatePicker(dtpRegistered))
                SQL &= String.Format(" LTO = '{0}', ", txtLTO.Text)
                SQL &= String.Format(" Img = '{0}', ", TotalImage)
                SQL &= String.Format(" Bank = '{0}', ", Bank)
                SQL &= String.Format(" YardID = '{0}', ", ValidateComboBox(cbxYard))
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Remarks = '{0}' ", txtRemarks.Text)
                If MultipleA Then
                    SQL &= String.Format(" WHERE PlateNum = '{0}'", txtPlateNum.Text)
                Else
                    If dtpDate.Enabled Then
                        SQL &= String.Format(" WHERE AssetNumber = '{0}'", txtAssetNumber.Tag)
                    Else
                        SQL &= String.Format(" WHERE AssetNumber = '{0}'", txtAssetNumber.Text)
                    End If
                End If
                DataObject(SQL)
                For x As Integer = 1 To TotalImage
                    Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                    If pb.Image Is Nothing Then
                    Else
                        ResizeImages(pb.Image.Clone, pb, 850, 700)
                        SaveImage(pb, pb.Properties.NullText & x)
                    End If
                Next

                Logs("ROPOA Vehicle", "Update", String.Format("Update ROPOA Vehicle {0}", txtAssetNumber.Text), Changes, "", "", "")
                Clear()
                LoadData()
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If Format(dtpDate.Value, "MMMM dd, yyyy") = Format(CDate(dtpDate.Tag), "MMMM dd, yyyy") Then
            Else
                Change &= String.Format("Change ROPOA Date from {0} to {1}. ", Format(CDate(dtpDate.Tag), "MMMM dd, yyyy"), Format(dtpDate.Value, "MMMM dd, yyyy"))
            End If
            If txtAssetNumber.Text = txtAssetNumber.Tag Then
            Else
                Change &= String.Format("Change Asset Number from {0} to {1}. ", txtAssetNumber.Tag, txtAssetNumber.Text)
            End If
            If cbxNature.Text = cbxNature.Tag Then
            Else
                Change &= String.Format("Change Nature of ROPOA from {0} to {1}. ", cbxNature.Tag, cbxNature.Text)
            End If
            If cbxAccountName.Text = cbxAccountName.Tag Then
            Else
                Change &= String.Format("Change Account Name from {0} to {1}. ", cbxAccountName.Tag, cbxAccountName.Text)
            End If
            If txtAccountNo.Text = txtAccountNo.Tag Then
            Else
                Change &= String.Format("Change Account No. from {0} to {1}. ", txtAccountNo.Tag, txtAccountNo.Text)
            End If
            If cbxBank.Text.Substring(0, 6) = cbxBank.Tag Then
            Else
                Change &= String.Format("Change Bank from {0} to {1}. ", cbxBank.Tag, cbxBank.Text)
            End If
            If cbxCondition.Text = cbxCondition.Tag Then
            Else
                Change &= String.Format("Change Condition from {0} to {1}. ", cbxCondition.Tag, cbxCondition.Text)
            End If
            If txtReason.Text = txtReason.Tag Then
            Else
                Change &= String.Format("Change Condition Reason from {0} to {1}. ", txtReason.Tag, txtReason.Text)
            End If
            If cbxMake.Text = cbxMake.Tag Then
            Else
                Change &= String.Format("Change Make from {0} to {1}. ", cbxMake.Tag, cbxMake.Text)
            End If
            If cbxType.Text = cbxType.Tag Then
            Else
                Change &= String.Format("Change Type from {0} to {1}. ", cbxType.Tag, cbxType.Text)
            End If
            If cbxUsed.Text = cbxUsed.Tag Then
            Else
                Change &= String.Format("Change Used from {0} to {1}. ", cbxUsed.Tag, cbxUsed.Text)
            End If
            If cbxModel.Text = cbxModel.Tag Then
            Else
                Change &= String.Format("Change Model from {0} to {1}. ", cbxModel.Tag, cbxModel.Text)
            End If
            If txtSeries.Text = txtSeries.Tag Then
            Else
                Change &= String.Format("Change Series from {0} to {1}. ", txtSeries.Tag, txtSeries.Text)
            End If
            If txtPlateNum.Text = txtPlateNum.Tag Then
            Else
                Change &= String.Format("Change Plate Number from {0} to {1}. ", txtPlateNum.Tag, txtPlateNum.Text)
            End If
            If cbxTransmission.Text = cbxTransmission.Tag Then
            Else
                Change &= String.Format("Change Transmission from {0} to {1}. ", cbxTransmission.Tag, cbxTransmission.Text)
            End If
            If cbxFuel.Text = cbxFuel.Tag Then
            Else
                Change &= String.Format("Change Fuel from {0} to {1}. ", cbxFuel.Tag, cbxFuel.Text)
            End If
            If cbxBodyColor.Text = cbxBodyColor.Tag Then
            Else
                Change &= String.Format("Change Body Color from {0} to {1}. ", cbxBodyColor.Tag, cbxBodyColor.Text)
            End If
            If dtpYear.Text.Trim = dtpYear.Tag Then
            Else
                Change &= String.Format("Change Year from {0} to {1}. ", dtpYear.Tag, dtpYear.Text.Trim)
            End If
            If cbxEngine.Text = cbxEngine.Tag Then
            Else
                Change &= String.Format("Change Engine Number from {0} to {1}. ", cbxEngine.Tag, cbxEngine.Text)
            End If
            If txtChassis.Text = txtChassis.Tag Then
            Else
                Change &= String.Format("Change Chassis Number from {0} to {1}. ", txtChassis.Tag, txtChassis.Text)
            End If
            If txtRegistryCert.Text = txtRegistryCert.Tag Then
            Else
                Change &= String.Format("Change Registry Certificate from {0} to {1}. ", txtRegistryCert.Tag, txtRegistryCert.Text)
            End If
            If txtORNum.Text = txtORNum.Tag Then
            Else
                Change &= String.Format("Change OR Number from {0} to {1}. ", txtORNum.Tag, txtORNum.Text)
            End If
            If dGrossWeight.Value = dGrossWeight.Tag Then
            Else
                Change &= String.Format("Change Gross Weight from {0} to {1}. ", dGrossWeight.Tag, dGrossWeight.Text)
            End If
            If iRim.Value = iRim.Tag Then
            Else
                Change &= String.Format("Change Rim Holes from {0} to {1}. ", iRim.Tag, iRim.Text)
            End If
            If dMileAge.Value = dMileAge.Tag Then
            Else
                Change &= String.Format("Change Mile Age from {0} to {1}. ", dMileAge.Tag, dMileAge.Text)
            End If
            If cbxMileAge.Text = cbxMileAge.Tag Then
            Else
                Change &= String.Format("Change Mile Age Type from {0} to {1}. ", cbxMileAge.Tag, cbxMileAge.Text)
            End If
            If dPrice.Value = dPrice.Tag Then
            Else
                Change &= String.Format("Change Price from {0} to {1}. ", dPrice.Tag, dPrice.Text)
            End If
            If dBalanceTransferred.Value = dBalanceTransferred.Tag Then
            Else
                Change &= String.Format("Change Balance Transferred from {0} to {1}. ", dBalanceTransferred.Tag, dBalanceTransferred.Text)
            End If
            If dtpRegistered.Tag = "" And cbxNA.Checked Then
            Else
                If Format(dtpRegistered.Value, "MMMM dd, yyyy") = dtpRegistered.Tag Then
                Else
                    Change &= String.Format("Change Last Date Registered from {0} to {1}. ", dtpRegistered.Tag, Format(dtpRegistered.Value, "MMMM dd, yyyy"))
                End If
            End If
            If txtLTO.Text = txtLTO.Tag Then
            Else
                Change &= String.Format("Change LTO Office from {0} to {1}. ", txtLTO.Tag, txtLTO.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
            If cbxYard.Text = cbxYard.Tag.ToString Then
            Else
                Change &= String.Format("Change Yard from {0} to {1}. ", cbxYard.Tag, cbxYard.Text)
            End If
            If GridView2.GetFocusedRowCellValue("Img") <> TotalImage Then
                Change &= String.Format("Change Image(s) from {0} to {1}. ", GridView2.GetFocusedRowCellValue("Img"), TotalImage)
            ElseIf AddImage Then
                Change &= "Change Image(s). "
            End If
        Catch ex As Exception
            TriggerBugReport("Vehicle ROPA - Changes", ex.Message.ToString)
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
            btnAddImage.Enabled = True
            btnDelete.Enabled = True

            PanelEx2.Enabled = True
            txtKeyword.Text = ""
            txtKeyword.Enabled = False
            cbxAdvance.Enabled = False
            btnSearch.Enabled = False
            btnBack_2.Enabled = False
            iFrom.Enabled = False
            iTo.Enabled = False
            iTo.Value = 0
            btnNext_2.Enabled = False
            btnMultipleA.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            Dim Creator_Draft As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM ropoa_vehicle WHERE `status` = 'PENDING' AND user_code = '{0}' AND AssetNumber = '{1}';", User_Code, txtAssetNumber.Text))
            If Creator_Draft > 0 Then
            Else
                MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            If MultipleA Then
                DataObject(String.Format("UPDATE ropoa_vehicle SET `status` = 'DELETED' WHERE PlateNum = '{0}'", txtPlateNum.Text))
            Else
                DataObject(String.Format("UPDATE ropoa_vehicle SET `status` = 'DELETED' WHERE AssetNumber = '{0}'", txtAssetNumber.Text))
            End If
            Logs("ROPOA Vehicle", "Cancel", Reason, String.Format("Cancel ROPOA Vehicle with Asset Number {0}", txtAssetNumber.Text), "", "", "")
            LoadData()
            Clear()
            FrmMain.VehicleCount = FrmMain.VehicleCount - 1
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs)
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Dim Report As New RptVehicleROPOA
            With Report
                .lblSOLD.Visible = False

                Dim xPos As Integer = 1
                For x As Integer = 1 To TotalImage
                    Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                    If x Mod 5 = 1 Then
                        pB_Dev.Properties.NullText = "Front"
                    ElseIf x Mod 5 = 2 Then
                        pB_Dev.Properties.NullText = "Back"
                    ElseIf x Mod 5 = 3 Then
                        pB_Dev.Properties.NullText = "Interior"
                    ElseIf x Mod 5 = 4 Then
                        pB_Dev.Properties.NullText = "Engine"
                    ElseIf x Mod 5 = 0 Then
                        pB_Dev.Properties.NullText = "Odometer"
                    End If

                    Dim pB As New XRPictureBox With {
                        .Size = New Size(375, 250)
                    }
                    '***ADD LABEL***'
                    Dim lblImage As New XRLabel
                    With lblImage
                        .Text = pB_Dev.Properties.NullText.ToString
                        .SizeF = New Size(375, 15)
                        .Font = New Font(OfficialFont, 8, FontStyle.Bold)
                        .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    End With
                    '***ADD LABEL***'
                    If xPos Mod 2 = 0 Then
                        pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                        lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                    Else
                        pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                        lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                    End If
                    pB.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
                    pB.Borders = DevExpress.XtraPrinting.BorderSide.All
                    .Detail.Controls.Add(pB)
                    .Detail.Controls.Add(lblImage)
                    xPos += 1
                Next
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView2.RowCount > 0 Then
                Try
                    If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptVehicleROPOA
                With Report
                    .Name = GridView2.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView2.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView2.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = ""
                    .lblCondition.Text = GridView2.GetFocusedRowCellValue("Condition")
                    .lblReason.Text = GridView2.GetFocusedRowCellValue("Reason")
                    .lblMake.Text = GridView2.GetFocusedRowCellValue("Make")
                    .lblType.Text = GridView2.GetFocusedRowCellValue("Type")
                    .lblEngine.Text = GridView2.GetFocusedRowCellValue("Model") & " " & GridView2.GetFocusedRowCellValue("Series")
                    .lblPlateNumber.Text = GridView2.GetFocusedRowCellValue("Plate Number")
                    .lblTransmission.Text = GridView2.GetFocusedRowCellValue("Transmission")
                    .lblGasoline.Text = GridView2.GetFocusedRowCellValue("Fuel")
                    .lblBodyColor.Text = GridView2.GetFocusedRowCellValue("Body Color")
                    .lblYear.Text = GridView2.GetFocusedRowCellValue("Year")
                    .lblMotorNumber.Text = GridView2.GetFocusedRowCellValue("Engine Number")
                    .lblSerialNumber.Text = GridView2.GetFocusedRowCellValue("Chassis Number")
                    .lblRegCertNumber.Text = GridView2.GetFocusedRowCellValue("Registry Certificate")
                    .lblORNumber.Text = GridView2.GetFocusedRowCellValue("OR Number")
                    .lblGrossWeight.Text = GridView2.GetFocusedRowCellValue("Gross Weight") & " kgs"
                    .lblRim.Text = GridView2.GetFocusedRowCellValue("Rim Holes")
                    .lblMileAge.Text = GridView2.GetFocusedRowCellValue("Mile Age")
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    .lblLastRegistered.Text = GridView2.GetFocusedRowCellValue("Last Registered")
                    .lblLTO.Text = GridView2.GetFocusedRowCellValue("LTO Office")
                    If GridColumn33.Visible Then
                        .lblRemarks.Text = GridView2.GetFocusedRowCellValue("Remarks")
                    Else
                        .XrLabel36.Text = ""
                    End If

                    Dim xPos As Integer = 1
                    If GridView2.GetFocusedRowCellValue("Img") > 0 Then
                        For x As Integer = 1 To GridView2.GetFocusedRowCellValue("Img")
                            Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Front"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Back"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Interior"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Engine"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Odometer"
                            End If

                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 250),
                                .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                .Borders = DevExpress.XtraPrinting.BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code"), GridView2.GetFocusedRowCellValue("Asset Number"), pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("Vehicle ROPA - Print", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                TempPB.Dispose()
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print Vehicle ROPOA with Asset Number {0}", GridView2.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If GridView3.RowCount > 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptVehicleSold
                With Report
                    .Name = GridView3.GetFocusedRowCellValue("Asset Number") & "-SOLD"
                    .lblDate.Text = GridView3.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView3.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Visible = True
                    .lblCondition.Text = GridView3.GetFocusedRowCellValue("Condition")
                    .lblReason.Text = GridView3.GetFocusedRowCellValue("Reason")
                    .lblMake.Text = GridView3.GetFocusedRowCellValue("Make")
                    .lblType.Text = GridView3.GetFocusedRowCellValue("Type")
                    .lblEngine.Text = GridView3.GetFocusedRowCellValue("Model") & " " & GridView3.GetFocusedRowCellValue("Series")
                    .lblPlateNumber.Text = GridView3.GetFocusedRowCellValue("Plate Number")
                    .lblTransmission.Text = GridView3.GetFocusedRowCellValue("Transmission")
                    .lblGasoline.Text = GridView3.GetFocusedRowCellValue("Fuel")
                    .lblBodyColor.Text = GridView3.GetFocusedRowCellValue("Body Color")
                    .lblYear.Text = GridView3.GetFocusedRowCellValue("Year")
                    .lblMotorNumber.Text = GridView3.GetFocusedRowCellValue("Engine Number")
                    .lblSerialNumber.Text = GridView3.GetFocusedRowCellValue("Chassis Number")
                    .lblRegCertNumber.Text = GridView3.GetFocusedRowCellValue("Registry Certificate")
                    .lblORNumber.Text = GridView3.GetFocusedRowCellValue("OR Number")
                    .lblGrossWeight.Text = GridView3.GetFocusedRowCellValue("Gross Weight") & " kgs"
                    .lblRim.Text = GridView3.GetFocusedRowCellValue("Rim Holes")
                    .lblMileAge.Text = GridView3.GetFocusedRowCellValue("Mile Age")
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    .lblLastRegistered.Text = GridView3.GetFocusedRowCellValue("Last Registered")
                    .lblLTO.Text = GridView3.GetFocusedRowCellValue("LTO Office")
                    If GridColumn56.Visible = True Then
                        .lblRemarks.Text = GridView3.GetFocusedRowCellValue("Remarks")
                    End If
                    .lblBuyersName.Text = GridView3.GetFocusedRowCellValue("Buyer")
                    .lblAddress.Text = If(GridView3.GetFocusedRowCellValue("NoC_B") = "", "", GridView3.GetFocusedRowCellValue("NoC_B") & ", ") & If(GridView3.GetFocusedRowCellValue("StreetC_B") = "", "", GridView3.GetFocusedRowCellValue("StreetC_B") & ", ") & If(GridView3.GetFocusedRowCellValue("BarangayC_B") = "", "", GridView3.GetFocusedRowCellValue("BarangayC_B") & ", ") & GridView3.GetFocusedRowCellValue("AddressC_B")
                    .lblORNumber_2.Text = ""
                    .lblORDate.Text = ""
                    .lblAmount.Text = GridView3.GetFocusedRowCellValue("Amount")

                    Dim xPos As Integer = 1
                    If GridView3.GetFocusedRowCellValue("Img") > 0 Then
                        For x As Integer = 1 To GridView3.GetFocusedRowCellValue("Img")
                            Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Front"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Back"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Interior"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Engine"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Odometer"
                            End If

                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 210),
                                .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                .Borders = DevExpress.XtraPrinting.BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 355 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 225), 0))
                                lblImage.Location = New Point(412.5, (355 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 225), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 355 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 225), 0))
                                lblImage.Location = New Point(12.5, (355 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 225), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView3.GetFocusedRowCellValue("branch_code"), GridView3.GetFocusedRowCellValue("Asset Number"), pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("Vehicle ROPA - Print", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                TempPB.Dispose()
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print Vehicle ROPOA with Asset Number {0}", GridView3.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView4.RowCount > 0 Then
                Try
                    If GridView4.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptVehicleROPOA
                With Report
                    .Name = GridView4.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView4.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView4.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = "SCRAP"
                    .lblCondition.Text = GridView4.GetFocusedRowCellValue("Condition")
                    .lblReason.Text = GridView4.GetFocusedRowCellValue("Reason")
                    .lblMake.Text = GridView4.GetFocusedRowCellValue("Make")
                    .lblType.Text = GridView4.GetFocusedRowCellValue("Type")
                    .lblEngine.Text = GridView4.GetFocusedRowCellValue("Model") & " " & GridView4.GetFocusedRowCellValue("Series")
                    .lblPlateNumber.Text = GridView4.GetFocusedRowCellValue("Plate Number")
                    .lblTransmission.Text = GridView4.GetFocusedRowCellValue("Transmission")
                    .lblGasoline.Text = GridView4.GetFocusedRowCellValue("Fuel")
                    .lblBodyColor.Text = GridView4.GetFocusedRowCellValue("Body Color")
                    .lblYear.Text = GridView4.GetFocusedRowCellValue("Year")
                    .lblMotorNumber.Text = GridView4.GetFocusedRowCellValue("Engine Number")
                    .lblSerialNumber.Text = GridView4.GetFocusedRowCellValue("Chassis Number")
                    .lblRegCertNumber.Text = GridView4.GetFocusedRowCellValue("Registry Certificate")
                    .lblORNumber.Text = GridView4.GetFocusedRowCellValue("OR Number")
                    .lblGrossWeight.Text = GridView4.GetFocusedRowCellValue("Gross Weight") & " kgs"
                    .lblRim.Text = GridView4.GetFocusedRowCellValue("Rim Holes")
                    .lblMileAge.Text = GridView4.GetFocusedRowCellValue("Mile Age")
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    'End If
                    .lblLastRegistered.Text = GridView4.GetFocusedRowCellValue("Last Registered")
                    .lblLTO.Text = GridView4.GetFocusedRowCellValue("LTO Office")
                    .lblRemarks.Text = GridView4.GetFocusedRowCellValue("Remarks")

                    Dim xPos As Integer = 1
                    If GridView4.GetFocusedRowCellValue("Img") > 0 Then
                        For x As Integer = 1 To GridView4.GetFocusedRowCellValue("Img")
                            Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Front"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Back"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Interior"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Engine"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Odometer"
                            End If

                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 250),
                                .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                .Borders = DevExpress.XtraPrinting.BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView4.GetFocusedRowCellValue("branch_code"), GridView4.GetFocusedRowCellValue("Asset Number"), pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Using TempPB As New DevExpress.XtraEditors.PictureEdit
                                    Try
                                        TempPB.Image = Image.FromFile(Path)
                                    Catch ex As Exception
                                        TriggerBugReport("Vehicle ROA - Print", ex.Message.ToString)
                                    End Try
                                    pB.Image = TempPB.Image
                                    .Detail.Controls.Add(pB)
                                    .Detail.Controls.Add(lblImage)
                                End Using
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print Vehicle ROPOA with Asset Number {0}", GridView4.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView5.RowCount > 0 Then
                Try
                    If GridView5.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptVehicleROPOA
                With Report
                    .Name = GridView5.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView5.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView5.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = "RESERVED"
                    .lblCondition.Text = GridView5.GetFocusedRowCellValue("Condition")
                    .lblReason.Text = GridView5.GetFocusedRowCellValue("Reason")
                    .lblMake.Text = GridView5.GetFocusedRowCellValue("Make")
                    .lblType.Text = GridView5.GetFocusedRowCellValue("Type")
                    .lblEngine.Text = GridView5.GetFocusedRowCellValue("Model") & " " & GridView5.GetFocusedRowCellValue("Series")
                    .lblPlateNumber.Text = GridView5.GetFocusedRowCellValue("Plate Number")
                    .lblTransmission.Text = GridView5.GetFocusedRowCellValue("Transmission")
                    .lblGasoline.Text = GridView5.GetFocusedRowCellValue("Fuel")
                    .lblBodyColor.Text = GridView5.GetFocusedRowCellValue("Body Color")
                    .lblYear.Text = GridView5.GetFocusedRowCellValue("Year")
                    .lblMotorNumber.Text = GridView5.GetFocusedRowCellValue("Engine Number")
                    .lblSerialNumber.Text = GridView5.GetFocusedRowCellValue("Chassis Number")
                    .lblRegCertNumber.Text = GridView5.GetFocusedRowCellValue("Registry Certificate")
                    .lblORNumber.Text = GridView5.GetFocusedRowCellValue("OR Number")
                    .lblGrossWeight.Text = GridView5.GetFocusedRowCellValue("Gross Weight") & " kgs"
                    .lblRim.Text = GridView5.GetFocusedRowCellValue("Rim Holes")
                    .lblMileAge.Text = GridView5.GetFocusedRowCellValue("Mile Age")
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    'End If
                    .lblLastRegistered.Text = GridView5.GetFocusedRowCellValue("Last Registered")
                    .lblLTO.Text = GridView5.GetFocusedRowCellValue("LTO Office")
                    .lblRemarks.Text = GridView5.GetFocusedRowCellValue("Remarks")

                    Dim xPos As Integer = 1
                    If GridView5.GetFocusedRowCellValue("Img") > 0 Then
                        For x As Integer = 1 To GridView5.GetFocusedRowCellValue("Img")
                            Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Front"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Back"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Interior"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Engine"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Odometer"
                            End If

                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 250),
                                .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                .Borders = DevExpress.XtraPrinting.BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView5.GetFocusedRowCellValue("branch_code"), GridView5.GetFocusedRowCellValue("Asset Number"), pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("Vehicle ROPA - Print", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                TempPB.Dispose()
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print Vehicle ROPOA with Asset Number {0}", GridView5.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            If GridView6.RowCount > 0 Then
                Try
                    If GridView6.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptVehicleROPOA
                With Report
                    .Name = GridView6.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView6.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView6.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = "RECLASSIFIED"
                    .lblCondition.Text = GridView6.GetFocusedRowCellValue("Condition")
                    .lblReason.Text = GridView6.GetFocusedRowCellValue("Reason")
                    .lblMake.Text = GridView6.GetFocusedRowCellValue("Make")
                    .lblType.Text = GridView6.GetFocusedRowCellValue("Type")
                    .lblEngine.Text = GridView6.GetFocusedRowCellValue("Model") & " " & GridView6.GetFocusedRowCellValue("Series")
                    .lblPlateNumber.Text = GridView6.GetFocusedRowCellValue("Plate Number")
                    .lblTransmission.Text = GridView6.GetFocusedRowCellValue("Transmission")
                    .lblGasoline.Text = GridView6.GetFocusedRowCellValue("Fuel")
                    .lblBodyColor.Text = GridView6.GetFocusedRowCellValue("Body Color")
                    .lblYear.Text = GridView6.GetFocusedRowCellValue("Year")
                    .lblMotorNumber.Text = GridView6.GetFocusedRowCellValue("Engine Number")
                    .lblSerialNumber.Text = GridView6.GetFocusedRowCellValue("Chassis Number")
                    .lblRegCertNumber.Text = GridView6.GetFocusedRowCellValue("Registry Certificate")
                    .lblORNumber.Text = GridView6.GetFocusedRowCellValue("OR Number")
                    .lblGrossWeight.Text = GridView6.GetFocusedRowCellValue("Gross Weight") & " kgs"
                    .lblRim.Text = GridView6.GetFocusedRowCellValue("Rim Holes")
                    .lblMileAge.Text = GridView6.GetFocusedRowCellValue("Mile Age")
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    'End If
                    .lblLastRegistered.Text = GridView6.GetFocusedRowCellValue("Last Registered")
                    .lblLTO.Text = GridView6.GetFocusedRowCellValue("LTO Office")
                    .lblRemarks.Text = GridView6.GetFocusedRowCellValue("Remarks")

                    Dim xPos As Integer = 1
                    If GridView6.GetFocusedRowCellValue("Img") > 0 Then
                        For x As Integer = 1 To GridView6.GetFocusedRowCellValue("Img")
                            Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Front"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Back"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Interior"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Engine"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Odometer"
                            End If

                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 250),
                                .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                .Borders = DevExpress.XtraPrinting.BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView6.GetFocusedRowCellValue("branch_code"), GridView6.GetFocusedRowCellValue("Asset Number"), pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("Vehicle ROPA - Print", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                TempPB.Dispose()
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print Vehicle ROPOA with Asset Number {0}", GridView6.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadImage()
        For x As Integer = 1 To Max_Image_VE
            Dim pB As New DevExpress.XtraEditors.PictureEdit
            With pB
                If x Mod 5 = 1 Then
                    .Properties.NullText = "Front"
                ElseIf x Mod 5 = 2 Then
                    .Properties.NullText = "Back"
                ElseIf x Mod 5 = 3 Then
                    .Properties.NullText = "Interior"
                ElseIf x Mod 5 = 4 Then
                    .Properties.NullText = "Engine"
                ElseIf x Mod 5 = 0 Then
                    .Properties.NullText = "Odometer"
                End If
                .Properties.Appearance.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
                .Size = New Size(200, 150)
                PanelEx4.Controls.Add(pB)
                .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                If TotalImage >= 5 Then
                    If TotalImage >= 10 Then
                        If TotalImage >= 15 Then
                            If TotalImage >= 20 Then
                                If TotalImage >= 25 Then
                                    If TotalImage >= 30 Then
                                        If TotalImage >= 35 Then
                                            If TotalImage >= 40 Then
                                                If TotalImage >= 45 Then
                                                    If TotalImage >= 50 Then
                                                        .Location = New Point(3 + (230 * (TotalImage - 50)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    Else
                                                        .Location = New Point(3 + (230 * (TotalImage - 45)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    End If
                                                Else
                                                    .Location = New Point(3 + (230 * (TotalImage - 40)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                End If
                                            Else
                                                .Location = New Point(3 + (230 * (TotalImage - 35)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                            End If
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 30)), 3 + 156 + 156 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 25)), 3 + 156 + 156 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                        End If
                    Else
                        .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                    End If
                Else
                    .Location = New Point(3 + (230 * TotalImage), 3)
                End If
                TotalImage += 1
                .Visible = True
                .Tag = TotalImage
                .BorderStyle = BorderStyle.FixedSingle
                AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                AddHandler .Click, AddressOf Pb_Click
                .BringToFront()
            End With
        Next
    End Sub

    Private Sub BtnAddImage_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Image File|*.jpg;*.jpeg;*.png",
            .Multiselect = True
        }
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                AddImage = True
                For Each sFile As String In OFD.FileNames
                    Dim F_Info As New IO.FileInfo(sFile)
                    If F_Info.Length / 1024 > 1024 Then
                        MsgBox(String.Format("Selected File {0} have a size of {1}KB. Please limit up to 1024KB only.", sFile, CInt(F_Info.Length / 1000)), MsgBoxStyle.Information, "Info")
                        GoTo Here
                    End If
                    If TotalImage = Max_Image_VE Then
                        MsgBox(String.Format("Maximum image to attach is up to {0} images only.", Max_Image_VE), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        .Properties.NullText = "No Image"
                        .Size = New Size(200, 150)
                        PanelEx4.Controls.Add(pB)
                        .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        If TotalImage >= 5 Then
                            If TotalImage >= 10 Then
                                If TotalImage >= 15 Then
                                    If TotalImage >= 20 Then
                                        If TotalImage >= 25 Then
                                            If TotalImage >= 30 Then
                                                If TotalImage >= 35 Then
                                                    If TotalImage >= 40 Then
                                                        If TotalImage >= 45 Then
                                                            If TotalImage >= 50 Then
                                                                .Location = New Point(3 + (230 * (TotalImage - 50)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            Else
                                                                .Location = New Point(3 + (230 * (TotalImage - 45)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            End If
                                                        Else
                                                            .Location = New Point(3 + (230 * (TotalImage - 40)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                        End If
                                                    Else
                                                        .Location = New Point(3 + (230 * (TotalImage - 35)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    End If
                                                Else
                                                    .Location = New Point(3 + (230 * (TotalImage - 30)), 3 + 156 + 156 + 156 + 156 + 156 + 156)
                                                End If
                                            Else
                                                .Location = New Point(3 + (230 * (TotalImage - 25)), 3 + 156 + 156 + 156 + 156 + 156)
                                            End If
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * TotalImage), 3)
                        End If
                        TotalImage += 1
                        .Visible = True
                        .Tag = TotalImage
                        .BorderStyle = BorderStyle.FixedSingle
                        AddHandler .Click, AddressOf Pb_Click
                        AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                        .BringToFront()
                    End With
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(sFile)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
Here:
                Next
            Catch ex As Exception
                MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub Pb_Click(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
            If b.Image Is Nothing Then
                Exit Sub
            End If
            Dim Zoom As New FrmZoomImage
            With Zoom
                .TotalImage = TotalImage
                .Type = "ROPOA VL"
                .CurrentImage = b.Tag
                .pbZoom.Image = b.Image
                .ShowDialog()
                If b.Tag = .CurrentImage Then
                    b.Image = .pbZoom.Image
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub Pb_ImageChanged(sender As Object, e As EventArgs)
        If FirstLoad Then
            Exit Sub
        End If
    End Sub

    Public Sub SaveImage(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER Branch
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode))
        End If
        '********CREATE FOLDER Borrowers
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, RopoaBranchCode))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, RopoaBranchCode, txtAssetNumber.Text)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, RopoaBranchCode, txtAssetNumber.Text))
        End If
        '********CREATE File
        Try
            Dim xPath As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, txtAssetNumber.Text, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
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
        ElseIf e.Control And e.KeyCode = Keys.X Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.H Then
            FormRestriction(60) 'ROPOA Pricing
            If allow_Access Then
                LabelX15.Visible = False
                dPrice.Visible = False
                LabelX27.Visible = False
                dBalanceTransferred.Visible = False
                GridColumn32.Visible = False
                GridColumn55.Visible = False
                GridColumn98.Visible = False
                GridColumn146.Visible = False
                GridColumn180.Visible = False
                HidePrice = True
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        ElseIf e.Control And e.KeyCode = Keys.U Then
            FormRestriction(60) 'ROPOA Pricing
            If allow_Access Then
                LabelX15.Visible = True
                dPrice.Visible = True
                LabelX27.Visible = True
                dBalanceTransferred.Visible = True
                GridColumn32.Visible = True
                GridColumn55.Visible = True
                GridColumn98.Visible = True
                GridColumn146.Visible = True
                GridColumn180.Visible = True
                HidePrice = False
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
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

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView2_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView3_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView4_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView4.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView4_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView5.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView5_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView6_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView6.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView6_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        txtKeyword.Text = ""
        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = 0
        iTo.Value = 0
        iFrom.Enabled = False
        iTo.Enabled = False
        btnBack_2.Enabled = False
        btnNext_2.Enabled = False
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub IFrom_ValueChanged(sender As Object, e As EventArgs) Handles iFrom.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        If iFrom.Value <= 1 And iTo.Value <= 1 Then
            btnBack_2.Enabled = False
            btnNext_2.Enabled = False
        ElseIf iFrom.Value = 1 Then
            btnBack_2.Enabled = False
            btnNext_2.Enabled = True
        ElseIf iFrom.Value = iTo.Value Then
            btnBack_2.Enabled = True
            btnNext_2.Enabled = False
        Else
            btnBack_2.Enabled = True
            btnNext_2.Enabled = True
        End If

        If iFrom.Value = 0 Then
        Else
            If ROPOA_Status = "Sell" Then
                GridView2.FocusedRowHandle = iFrom.Value - 1
                If GridView2.GetFocusedRowCellValue("Status") = "PENDING" Then
                    btnPurchase.Enabled = False
                    btnHistory.Enabled = False
                    btnReserve.Enabled = False
                    btnReclassify.Enabled = False
                    btnAppraise.Enabled = False
                    btnMultipleA.Enabled = False
                    If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                        btnVerify.Enabled = True
                    Else
                        btnVerify.Enabled = False
                    End If
                Else
                    btnPurchase.Enabled = True
                    btnHistory.Enabled = True
                    btnReserve.Enabled = True
                    btnReclassify.Enabled = True
                    btnAppraise.Enabled = True
                    btnMultipleA.Enabled = True
                    btnVerify.Enabled = False
                End If
                PassData(GridView2)

                If CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) = Overstayed_Months And Overstayed Then
                    lblOverstay.Text = "Over stayed ROPA"
                ElseIf CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) > Overstayed_Months And Overstayed Then
                    lblOverstay.Text = String.Format("Over stayed ROPA for {0} months", CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) - Overstayed_Months)
                Else
                    lblOverstay.Text = ""
                End If
            ElseIf ROPOA_Status = "Sold" Then
                GridView3.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView3)
                lblOverstay.Text = ""
            ElseIf ROPOA_Status = "Scrap" Then
                GridView4.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView4)
                lblOverstay.Text = ""
            ElseIf ROPOA_Status = "Reserved" Then
                GridView5.FocusedRowHandle = iFrom.Value - 1

                PanelEx2.Enabled = False
                SuperTabControl1.SelectedTab = tabSetup
                btnModify.Enabled = True
                btnSave.Enabled = False
                btnAddImage.Enabled = False
                btnPurchase.Enabled = False
                btnHistory.Enabled = True
                btnReserve.Enabled = True
                btnReserve.Text = "For Sell"
                btnReclassify.Enabled = False
                btnAppraise.Enabled = True
                btnMultipleA.Enabled = False
                btnVerify.Enabled = False
                If GridView5.GetFocusedRowCellValue("reserved_days") > 0 Or GridView5.GetFocusedRowCellValue("Balance") > 0 Then
                    btnPurchase.Enabled = True
                    btnReserve.Enabled = False
                    btnAppraise.Enabled = False
                End If

                PassData(GridView5)
                lblOverstay.Text = ""
            ElseIf ROPOA_Status = "Reclassified" Then
                GridView6.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView6)
                lblOverstay.Text = ""
            End If

            If cbxAdvance.Checked Then
                If Branch_Code = GridView2.GetFocusedRowCellValue("branch_code") Then
                    btnModify.Enabled = True

                    btnPurchase.Enabled = True
                    btnHistory.Enabled = True
                    btnReserve.Enabled = True
                    btnReclassify.Enabled = True
                    btnAppraise.Enabled = True
                    btnMultipleA.Enabled = True
                    lblOverstay.Visible = True
                Else
                    btnModify.Enabled = False

                    btnPurchase.Enabled = False
                    btnHistory.Enabled = False
                    btnReserve.Enabled = False
                    btnReclassify.Enabled = False
                    btnAppraise.Enabled = False
                    btnMultipleA.Enabled = False
                End If
            Else
                btnModify.Enabled = True

                btnPurchase.Enabled = True
                btnHistory.Enabled = True
                'btnReserve.Enabled = True
                'btnReclassify.Enabled = True
                'btnAppraise.Enabled = True
                'btnMultipleA.Enabled = True
                lblOverstay.Visible = True
            End If
        End If
    End Sub

    Private Sub BtnNext_2_Click(sender As Object, e As EventArgs) Handles btnNext_2.Click
        If ROPOA_Status = "Sell" Then
            GridView2.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Sold" Then
            GridView3.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Scrap" Then
            GridView4.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reserved" Then
            GridView5.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reclassified" Then
            GridView6.ClearColumnsFilter()
        End If

        iFrom.Value = iFrom.Value + 1
    End Sub

    Private Sub BtnBack_2_Click(sender As Object, e As EventArgs) Handles btnBack_2.Click
        If ROPOA_Status = "Sell" Then
            GridView2.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Sold" Then
            GridView3.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Scrap" Then
            GridView4.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reserved" Then
            GridView5.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reclassified" Then
            GridView6.ClearColumnsFilter()
        End If

        iFrom.Value = iFrom.Value - 1
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keydata As Keys) As Boolean
        If keydata = Keys.Right Then
            btnNext_2.PerformClick()
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        ElseIf keydata = Keys.Left Then
            btnBack_2.PerformClick()
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        Else
            ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
        End If
    End Function

    Public Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = False
        dtpDate.Enabled = False
        ROPOA_Status = "Sell"
        PassData(GridView2)
        FirstLoad = True

        PanelEx2.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        btnAddImage.Enabled = False
        btnReserve.Text = "Reserve"
        btnReclassify.Text = "Reclassify"
        If GridView2.GetFocusedRowCellValue("Status") = "PENDING" Then
            btnPurchase.Enabled = False
            btnHistory.Enabled = False
            btnReserve.Enabled = False
            btnReclassify.Enabled = False
            btnAppraise.Enabled = False
            btnMultipleA.Enabled = True
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                btnVerify.Enabled = True
            Else
                btnVerify.Enabled = False
            End If
            dBalanceTransferred.Enabled = True
        Else
            btnPurchase.Enabled = True
            btnHistory.Enabled = True
            btnReserve.Enabled = True
            btnReclassify.Enabled = True
            btnAppraise.Enabled = True
            btnMultipleA.Enabled = True
            btnVerify.Enabled = False
            dBalanceTransferred.Enabled = False
        End If

        txtKeyword.Enabled = True
        cbxAdvance.Enabled = True
        btnSearch.Enabled = True
        iFrom.Value = GridView2.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView2.RowCount
        If iFrom.Value > 1 Then
            btnBack_2.Enabled = True
        Else
            btnBack_2.Enabled = False
        End If
        If iFrom.Value = iTo.Value Then
            btnNext_2.Enabled = False
        Else
            btnNext_2.Enabled = True
        End If
        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True

        If CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) = Overstayed_Months And Overstayed Then
            lblOverstay.Text = "Over stayed ROPOA"
        ElseIf CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) > Overstayed_Months And Overstayed Then
            lblOverstay.Text = String.Format("Over stayed ROPOA for {0} months", CompleteMonthsBetweenA(DateValue(GridView2.GetFocusedRowCellValue("Date")), Date.Now) - Overstayed_Months)
        Else
            lblOverstay.Text = ""
        End If
    End Sub

    Private Sub PassData(GV As DevExpress.XtraGrid.Views.Grid.GridView)
        Cursor = Cursors.WaitCursor
        If GV.RowCount = 0 Then
            Exit Sub
        End If
        ID = GV.GetFocusedRowCellValue("ID")
        If cbxAdvance.Checked Then
            lblLocation.Text = DataObject(String.Format("SELECT branch FROM branch WHERE branch_code = '{0}';", GV.GetFocusedRowCellValue("branch_code")))
        End If
        With GV
            cbxNature.Text = .GetFocusedRowCellValue("Nature")
            cbxNature.Tag = .GetFocusedRowCellValue("Nature")
            If .GetFocusedRowCellValue("Publish") = 1 Then
                cbxPublish.Checked = True
            Else
                cbxPublish.Checked = False
            End If
            cbxPublish.Tag = .GetFocusedRowCellValue("Publish")
            cbxAccountName.Text = .GetFocusedRowCellValue("Account Name").ToString
            cbxAccountName.Tag = .GetFocusedRowCellValue("Account Name")
            txtAccountNo.Text = .GetFocusedRowCellValue("Account No")
            txtAccountNo.Tag = .GetFocusedRowCellValue("Account No")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = "Bank " & .GetFocusedRowCellValue("Bank")
            dtpDate.CustomFormat = "MMMM dd, yyyy"
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            txtAssetNumber.Text = .GetFocusedRowCellValue("Asset Number")
            txtAssetNumber.Tag = .GetFocusedRowCellValue("Asset Number")
            cbxCondition.Text = .GetFocusedRowCellValue("Condition")
            cbxCondition.Tag = .GetFocusedRowCellValue("Condition")
            txtReason.Text = .GetFocusedRowCellValue("Reason")
            txtReason.Tag = .GetFocusedRowCellValue("Reason")
            cbxMake.Text = .GetFocusedRowCellValue("Make")
            cbxMake.Tag = .GetFocusedRowCellValue("Make")
            Dim sender As New Object
            Dim e As New EventArgs
            CbxMake_SelectedIndexChanged(sender, e)
            cbxType.Text = .GetFocusedRowCellValue("Type")
            cbxType.Tag = .GetFocusedRowCellValue("Type")
            If .GetFocusedRowCellValue("Used") = "" Then
                cbxUsed.SelectedIndex = -1
                cbxUsed.Tag = ""
            Else
                cbxUsed.Text = .GetFocusedRowCellValue("Used")
                cbxUsed.Tag = .GetFocusedRowCellValue("Used")
            End If
            cbxModel.Text = .GetFocusedRowCellValue("Model")
            cbxModel.Tag = .GetFocusedRowCellValue("Model")
            txtSeries.Text = .GetFocusedRowCellValue("Series")
            txtSeries.Tag = .GetFocusedRowCellValue("Series")
            txtPlateNum.Text = .GetFocusedRowCellValue("Plate Number")
            txtPlateNum.Tag = .GetFocusedRowCellValue("Plate Number")
            cbxTransmission.Text = .GetFocusedRowCellValue("Transmission")
            cbxTransmission.Tag = .GetFocusedRowCellValue("Transmission")
            cbxFuel.Text = .GetFocusedRowCellValue("Fuel")
            cbxFuel.Tag = .GetFocusedRowCellValue("Fuel")
            cbxBodyColor.Text = .GetFocusedRowCellValue("Body Color")
            cbxBodyColor.Tag = .GetFocusedRowCellValue("Body Color")
            If .GetFocusedRowCellValue("Year") = "" Then
                dtpYear.CustomFormat = ""
            Else
                dtpYear.CustomFormat = "     yyyy"
                dtpYear.Value = .GetFocusedRowCellValue("Year") & "-01-01"
                dtpYear.Tag = .GetFocusedRowCellValue("Year")
            End If
            cbxEngine.Text = .GetFocusedRowCellValue("Engine Number")
            cbxEngine.Tag = .GetFocusedRowCellValue("Engine Number")
            txtChassis.Text = .GetFocusedRowCellValue("Chassis Number")
            txtChassis.Tag = .GetFocusedRowCellValue("Chassis Number")
            txtRegistryCert.Text = .GetFocusedRowCellValue("Registry Certificate")
            txtRegistryCert.Tag = .GetFocusedRowCellValue("Registry Certificate")
            txtORNum.Text = .GetFocusedRowCellValue("OR Number")
            txtORNum.Tag = .GetFocusedRowCellValue("OR Number")
            dGrossWeight.Value = .GetFocusedRowCellValue("Gross Weight")
            dGrossWeight.Tag = .GetFocusedRowCellValue("Gross Weight")
            iRim.Value = .GetFocusedRowCellValue("Rim Holes")
            iRim.Tag = .GetFocusedRowCellValue("Rim Holes")
            dMileAge.Value = .GetFocusedRowCellValue("MileAge")
            dMileAge.Tag = .GetFocusedRowCellValue("MileAge")
            cbxMileAge.Text = .GetFocusedRowCellValue("MileAgeType")
            cbxMileAge.Tag = .GetFocusedRowCellValue("MileAgeType")
            dPrice.Value = .GetFocusedRowCellValue("Price")
            dPrice.Tag = .GetFocusedRowCellValue("Price")
            dBalanceTransferred.Value = .GetFocusedRowCellValue("Balance Transferred")
            dBalanceTransferred.Tag = .GetFocusedRowCellValue("Balance Transferred")
            If .GetFocusedRowCellValue("Last Registered") = "" Then
                cbxNA.Checked = True
                dtpRegistered.CustomFormat = ""
                dtpRegistered.Tag = ""
            Else
                cbxNA.Checked = False
                dtpRegistered.CustomFormat = "MMMM dd, yyyy"
                dtpRegistered.Value = .GetFocusedRowCellValue("Last Registered")
                dtpRegistered.Tag = .GetFocusedRowCellValue("Last Registered")
            End If
            txtLTO.Text = .GetFocusedRowCellValue("LTO Office")
            txtLTO.Tag = .GetFocusedRowCellValue("LTO Office")
            If dPrice.Value > 1 Then
                If User_Type.ToUpper = "ADMIN" Then
                Else
                    dPrice.Enabled = False
                End If
            End If
            cbxYard.SelectedValue = .GetFocusedRowCellValue("YardID")
            cbxYard.Tag = .GetFocusedRowCellValue("Yard")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            RopoaBranchCode = .GetFocusedRowCellValue("branch_code")
            btnAttach.Enabled = True
            TotalImage_II = .GetFocusedRowCellValue("Attach_2")
        End With
        If GV.GetFocusedRowCellValue("account_count") > 1 Then
            MultipleA = True
            txtPlateNum.Enabled = False
            cbxAccountName.Enabled = False
            txtAccountNo.Enabled = False
            btnMultipleA.TextColor = OfficialColor2 'Color.Red
        Else
            MultipleA = False
            txtPlateNum.Enabled = True
            cbxAccountName.Enabled = True
            txtAccountNo.Enabled = True
            btnMultipleA.TextColor = Color.Black
        End If

        Try
            For x As Integer = 1 To TotalImage
                ClearPictureEdit(PanelEx4, x)
            Next
            TotalImage = 0
            For x As Integer = 1 To Max_Image_VE
                Dim pB As New DevExpress.XtraEditors.PictureEdit
                With pB
                    If x Mod 5 = 1 Then
                        .Properties.NullText = "Front"
                    ElseIf x Mod 5 = 2 Then
                        .Properties.NullText = "Back"
                    ElseIf x Mod 5 = 3 Then
                        .Properties.NullText = "Interior"
                    ElseIf x Mod 5 = 4 Then
                        .Properties.NullText = "Engine"
                    ElseIf x Mod 5 = 0 Then
                        .Properties.NullText = "Odometer"
                    End If
                    .Size = New Size(200, 150)
                    PanelEx4.Controls.Add(pB)
                    .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                    If TotalImage >= 5 Then
                        If TotalImage >= 10 Then
                            If TotalImage >= 15 Then
                                If TotalImage >= 20 Then
                                    If TotalImage >= 25 Then
                                        If TotalImage >= 30 Then
                                            If TotalImage >= 35 Then
                                                If TotalImage >= 40 Then
                                                    If TotalImage >= 45 Then
                                                        If TotalImage >= 50 Then
                                                            .Location = New Point(3 + (230 * (TotalImage - 50)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                        Else
                                                            .Location = New Point(3 + (230 * (TotalImage - 45)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                        End If
                                                    Else
                                                        .Location = New Point(3 + (230 * (TotalImage - 40)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    End If
                                                Else
                                                    .Location = New Point(3 + (230 * (TotalImage - 35)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                End If
                                            Else
                                                .Location = New Point(3 + (230 * (TotalImage - 30)), 3 + 156 + 156 + 156 + 156 + 156 + 156)
                                            End If
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 25)), 3 + 156 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                        End If
                    Else
                        .Location = New Point(3 + (230 * TotalImage), 3)
                    End If
                    TotalImage += 1
                    .Visible = True
                    .Tag = TotalImage
                    .BorderStyle = BorderStyle.FixedSingle
                    AddHandler .Click, AddressOf Pb_Click
                    FirstLoad = True
                    AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                    .BringToFront()
                End With
                Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GV.GetFocusedRowCellValue("branch_code"), txtAssetNumber.Text, pB.Properties.NullText & x & ".jpg")
                If IO.File.Exists(Path) Then
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(Path)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
                End If
                FirstLoad = False
            Next
        Catch ex As Exception
            Cursor = Cursors.Default
            TriggerBugReport("Vehicle ROPA - PassData", ex.Message.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        Try
            If GridView3.GetFocusedRowCellValue("ID").ToString = "" Or GridView3.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "SOLD"
        ROPOA_Status = "Sold"
        dBalanceTransferred.Enabled = False
        PassData(GridView3)
        FirstLoad = True

        PanelEx2.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = False
        btnSave.Enabled = False
        btnAddImage.Enabled = False
        btnPurchase.Enabled = True
        btnHistory.Enabled = True
        btnReserve.Enabled = False
        btnReclassify.Enabled = False
        btnAppraise.Enabled = False
        btnMultipleA.Enabled = False
        btnVerify.Enabled = False

        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = GridView3.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView3.RowCount
        If iFrom.Value > 1 Then
            btnBack_2.Enabled = True
        Else
            btnBack_2.Enabled = False
        End If
        If iFrom.Value = iTo.Value Then
            btnNext_2.Enabled = False
        Else
            btnNext_2.Enabled = True
        End If
        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True
        lblOverstay.Text = ""
    End Sub

    Private Sub GridView4_DoubleClick(sender As Object, e As EventArgs) Handles GridView4.DoubleClick
        Try
            If GridView4.GetFocusedRowCellValue("ID").ToString = "" Or GridView4.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "SCRAP"
        ROPOA_Status = "Scrap"
        dBalanceTransferred.Enabled = False
        PassData(GridView4)
        FirstLoad = True

        PanelEx2.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = False
        btnSave.Enabled = False
        btnAddImage.Enabled = False
        btnPurchase.Enabled = True
        btnHistory.Enabled = True
        btnReserve.Enabled = False
        btnReclassify.Enabled = False
        btnAppraise.Enabled = True
        btnMultipleA.Enabled = False
        btnVerify.Enabled = False

        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = GridView4.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView4.RowCount
        If iFrom.Value > 1 Then
            btnBack_2.Enabled = True
        Else
            btnBack_2.Enabled = False
        End If
        If iFrom.Value = iTo.Value Then
            btnNext_2.Enabled = False
        Else
            btnNext_2.Enabled = True
        End If
        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True
        lblOverstay.Text = ""
    End Sub

    Public Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
        Try
            If GridView5.GetFocusedRowCellValue("ID").ToString = "" Or GridView5.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "RESERVED"
        ROPOA_Status = "Reserved"
        dBalanceTransferred.Enabled = False
        PassData(GridView5)
        FirstLoad = True

        PanelEx2.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        btnAddImage.Enabled = False
        btnPurchase.Enabled = False
        btnHistory.Enabled = True
        btnReserve.Enabled = True
        btnReserve.Text = "For Sell"
        btnReclassify.Enabled = False
        btnAppraise.Enabled = True
        btnMultipleA.Enabled = False
        btnVerify.Enabled = False
        If GridView5.GetFocusedRowCellValue("reserved_days") > 0 Or GridView5.GetFocusedRowCellValue("Balance") > 0 Then
            btnPurchase.Enabled = True
            btnReserve.Enabled = False
            btnAppraise.Enabled = False
        End If

        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = GridView5.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView5.RowCount
        If iFrom.Value > 1 Then
            btnBack_2.Enabled = True
        Else
            btnBack_2.Enabled = False
        End If
        If iFrom.Value = iTo.Value Then
            btnNext_2.Enabled = False
        Else
            btnNext_2.Enabled = True
        End If
        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True
        lblOverstay.Text = ""
    End Sub

    Private Sub GridView6_DoubleClick(sender As Object, e As EventArgs) Handles GridView6.DoubleClick
        Try
            If GridView6.GetFocusedRowCellValue("ID").ToString = "" Or GridView6.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "RECLASSIFIED"
        ROPOA_Status = "Reclassified"
        dBalanceTransferred.Enabled = False
        PassData(GridView6)
        FirstLoad = True

        PanelEx2.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        btnAddImage.Enabled = False
        btnPurchase.Enabled = False
        btnHistory.Enabled = True
        btnReserve.Enabled = False
        If User_Type = "ADMIN" Then
            btnReclassify.Enabled = True
        Else
            btnReclassify.Enabled = False
        End If
        btnReclassify.Text = "For Sell"
        btnAppraise.Enabled = True
        btnMultipleA.Enabled = False
        btnVerify.Enabled = False

        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = GridView6.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView6.RowCount
        If iFrom.Value > 1 Then
            btnBack_2.Enabled = True
        Else
            btnBack_2.Enabled = False
        End If
        If iFrom.Value = iTo.Value Then
            btnNext_2.Enabled = False
        Else
            btnNext_2.Enabled = True
        End If
        FirstLoad = False

        LabelX15.Visible = False
        dPrice.Visible = False
        LabelX27.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn32.Visible = False
        GridColumn55.Visible = False
        GridColumn98.Visible = False
        GridColumn146.Visible = False
        GridColumn180.Visible = False
        HidePrice = True
        lblOverstay.Text = ""
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        GridView2.ClearColumnsFilter()

        LoadData()
        If GridView2.RowCount > 0 Then
            iFrom.Value = GridView2.GetFocusedDataSourceRowIndex + 1
            iTo.Value = GridView2.RowCount
            IFrom_ValueChanged(sender, e)

            btnSave.Enabled = False
            If cbxAdvance.Checked Then
                If Branch_Code = GridView2.GetFocusedRowCellValue("branch_code") Then
                    btnModify.Enabled = True

                    btnPurchase.Enabled = True
                    btnHistory.Enabled = True
                    btnReserve.Enabled = True
                    btnReclassify.Enabled = True
                    btnAppraise.Enabled = True
                    btnMultipleA.Enabled = True
                Else
                    btnModify.Enabled = False

                    btnPurchase.Enabled = False
                    btnHistory.Enabled = False
                    btnReserve.Enabled = False
                    btnReclassify.Enabled = False
                    btnAppraise.Enabled = False
                    btnMultipleA.Enabled = False
                End If
            End If
        Else
            Clear()
            MsgBox("No data found in the record.", MsgBoxStyle.Information, "Info")
            lblLocation.Text = ""
            btnBack_2.Enabled = False
            btnNext_2.Enabled = False
            iFrom.Enabled = False
            iTo.Enabled = False
            iFrom.Value = 0
            iTo.Value = 0
        End If
    End Sub

    Private Sub TxtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub BtnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
        Dim BalanceT As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE EntryType = 'DEBIT' AND PaidFor = 'Balance Transferred' AND PostStatus = 'POSTED';", txtAssetNumber.Text, txtPlateNum.Text))
        If BalanceT = 0 Then
            MsgBox("ROPA Approved Balance Transfer is not yet available. Please transact the approved balance transfer to proceed on purchasing the ROPOA.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If ROPOA_Status = "Sell" Then
            Dim Purchase As New FrmSoldROPOA
            With Purchase
                .AssetNumber = txtAssetNumber.Text
                .dSellingPrice.Value = dPrice.Value
                .ROPOA_Ref = txtPlateNum.Text
                .MultipleA = MultipleA
                .BankID = cbxBank.SelectedValue

                If .ShowDialog = DialogResult.OK Then
                    iFrom.Value = 0
                    iTo.Value = 0
                    OpenACR()
                    Clear()
                    txtKeyword.Text = ""
                    btnNext_2.Enabled = False
                    btnBack_2.Enabled = False
                    btnAddImage.Enabled = True
                    dtpDate.Enabled = True

                    LoadData()
                    LoadSold()
                    LoadReserved()
                End If
                .Dispose()
            End With
        ElseIf ROPOA_Status = "Sold" Then
            Dim Purchase As New FrmSoldROPOA
            With Purchase
                .AssetNumber = txtAssetNumber.Text
                .dSellingPrice.Value = dPrice.Value
                .ROPOA_Ref = txtPlateNum.Text
                .MultipleA = MultipleA
                .BankID = cbxBank.SelectedValue
                .btnSave.Enabled = False
                .btnRefresh.Enabled = False

                .CbxPrefix_B.Text = GridView3.GetFocusedRowCellValue("Prefix_B")
                .TxtFirstN_B.Text = GridView3.GetFocusedRowCellValue("FirstN_B")
                .TxtMiddleN_B.Text = GridView3.GetFocusedRowCellValue("MiddleN_B")
                .TxtLastN_B.Text = GridView3.GetFocusedRowCellValue("LastN_B")
                .cbxSuffix_B.Text = GridView3.GetFocusedRowCellValue("Suffix_B")
                .txtNoC_B.Text = GridView3.GetFocusedRowCellValue("NoC_B")
                .txtStreetC_B.Text = GridView3.GetFocusedRowCellValue("StreetC_B")
                .txtBarangayC_B.Text = GridView3.GetFocusedRowCellValue("BarangayC_B")
                .cbxAddressC_B.Text = GridView3.GetFocusedRowCellValue("AddressC_B")
                .txtContact_B.Text = GridView3.GetFocusedRowCellValue("Contact_N")

                .dSoldAmount.Value = GridView3.GetFocusedRowCellValue("Amount")
                .iDays.Value = GridView3.GetFocusedRowCellValue("Reserved_Days")
                .txtRemarks.Text = GridView3.GetFocusedRowCellValue("Sold Remarks")

                .cbxAgent.Enabled = False
                .cbxMarketing.Enabled = False
                .cbxDealer.Enabled = False
                .vAgent = GridView3.GetFocusedRowCellValue("Referral_ID")
                .vMarketing = GridView3.GetFocusedRowCellValue("Referral_ID")
                .vDealer = GridView3.GetFocusedRowCellValue("Referral_ID")
                If GridView3.GetFocusedRowCellValue("Referral") = "A" Then
                    .cbxAgent.Checked = True
                ElseIf GridView3.GetFocusedRowCellValue("Referral") = "M" Then
                    .cbxMarketing.Checked = True
                ElseIf GridView3.GetFocusedRowCellValue("Referral") = "D" Then
                    .cbxDealer.Checked = True
                End If

                .CbxPrefix_B.Enabled = False
                .TxtFirstN_B.Enabled = False
                .TxtMiddleN_B.Enabled = False
                .TxtLastN_B.Enabled = False
                .cbxSuffix_B.Enabled = False
                .txtNoC_B.Enabled = False
                .txtStreetC_B.Enabled = False
                .txtBarangayC_B.Enabled = False
                .cbxAddressC_B.Enabled = False
                .txtContact_B.Enabled = False
                .dSoldAmount.Enabled = False
                .dSellingPrice.Enabled = False
                .dROPOAValue.Enabled = False
                .iDays.Enabled = False
                .txtRemarks.Enabled = False

                .ShowDialog()
                .Dispose()
            End With
        Else
            OpenACR()
        End If
    End Sub

    Private Sub OpenACR()
        Dim ACR As New FrmAcknowledgement
        With ACR
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .Tag = 84
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
            .From_Check = True
            .AssetNumber = txtAssetNumber.Text
            .cbxCash.Checked = True
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxPayee.Enabled = False
            .cbxCheckNumber.Enabled = False
            .dtpDeposit.Enabled = False
            .cbxLOE.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxITL.Enabled = False
            .cbxRO.Enabled = False
            .cbxLOE.Checked = False
            .cbxAR.Checked = False
            .cbxAP.Checked = False
            .cbxITL.Checked = False
            .cbxRO.Checked = True
            .cbxLA.Enabled = False
            .cbxLA.Checked = False
            .cbxCAS.Enabled = False
            .cbxCAS.Checked = False
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Try
            If GridView2.RowCount > 0 Then
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ROPOA_Date As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Date"))
                Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
                If Status = "PENDING" Then
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                Else
                    If ROPOA_Date = "" Or IsDate(ROPOA_Date) = False Then
                    Else
                        Try
                            If CompleteMonthsBetweenA(DateValue(ROPOA_Date), Date.Now) >= Overstayed_Months And Overstayed Then
                                e.Appearance.ForeColor = Color.DarkBlue
                            Else
                                e.Appearance.ForeColor = Color.DarkGreen
                            End If
                        Catch ex As Exception
                            TriggerBugReport("Vehicle ROPA - RowCellStyle", ex.Message.ToString)
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        If GridView3.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Balance As Double = View.GetRowCellValue(e.RowHandle, View.Columns("Balance"))
            If e.Column.FieldName = "Balance" Then
                Try
                    If Balance > 0 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                    End If
                Catch ex As Exception
                    TriggerBugReport("Vehicle ROPA - RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView5_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView5.RowCellStyle
        If GridView5.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ReservedD As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("reserved_days"))
            Dim ReservedS As String = View.GetRowCellValue(e.RowHandle, View.Columns("reserved_status"))
            Dim ReservedB As Double = View.GetRowCellValue(e.RowHandle, View.Columns("Balance"))
            Try
                If ReservedD > 0 And ReservedS = "YES" Then
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                ElseIf (ReservedD > 0 Or ReservedB > 0) And ReservedS = "NO" Then
                    e.Appearance.ForeColor = Color.DarkBlue
                Else
                    e.Appearance.ForeColor = Color.DarkGreen
                End If
            Catch ex As Exception
                TriggerBugReport("Vehicle ROPA - RowCellStyle", ex.Message.ToString)
            End Try
            'End If
        End If
    End Sub

    Private Sub CbxMake_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMake.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If
    End Sub

    Private Sub CbxMake_TextChanged(sender As Object, e As EventArgs) Handles cbxMake.TextChanged
        If cbxMake.Text.Trim = "" Then
            cbxModel.Text = ""
        End If
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim AssetNumber As String
        If MultipleA Then
            Dim AccountList As New FrmAccountList
            With AccountList
                .DT_Account = DataSource(String.Format("SELECT AccountNo, AssetNumber FROM ropoa_vehicle WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", txtPlateNum.Text))
                If .ShowDialog = DialogResult.OK Then
                    AssetNumber = .AssetNumber
                Else
                    Exit Sub
                End If
                .Dispose()
            End With
        Else
            AssetNumber = txtAssetNumber.Text
        End If

        Dim History As New FrmROPOALedger
        With History
            .Tag = 53
            .AssetNumber = AssetNumber
            .ROPOA_Status = ROPOA_Status
            .MultipleA = MultipleA
            .ROPOA_Ref = txtPlateNum.Text

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

            If .ShowDialog = DialogResult.OK Then
                Clear()
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnRepricing_Click(sender As Object, e As EventArgs) Handles btnRepricing.Click
        Dim Repricing As New FrmROPOARepricing
        With Repricing
            .Tag = 55
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

            .tabRealEstate.Visible = False
            .SuperTabControl1.SelectedTab = .tabVehicle
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If cbxType.Text.ToUpper.Contains("TRUCK") Or cbxType.Text.ToUpper.Contains("Dropside") Then
            iRim.Enabled = True
        Else
            iRim.Enabled = False
        End If
    End Sub

    Private Sub CbxAccountName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAccountName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If
    End Sub

    Private Sub CbxAccountName_TextChanged(sender As Object, e As EventArgs) Handles cbxAccountName.TextChanged
        If cbxAccountName.Text = "" Then
            txtAccountNo.Text = ""
        End If
    End Sub

    Private Sub BtnReserve_Click(sender As Object, e As EventArgs) Handles btnReserve.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnReserve.Text = "For Sell" Then
            If MsgBoxYes("Are you sure you want this ROPOA to be available?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE PlateNum = '{0}'", txtPlateNum.Text))
                Logs("ROPOA Vehicle", "For Sell", Reason, String.Format("Change ROPOA Vehicle status to FOR SELL with Asset Number {0}", txtAssetNumber.Text), "", "", "")
                LoadData()
                LoadReserved()
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully For Sell!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes("Are you sure you want this ROPOA to be RESERVED?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'RESERVED', reserve_reason = '{1}' WHERE PlateNum = '{0}'", txtPlateNum.Text, Reason))
                Logs("ROPOA Vehicle", "Reserve", Reason, String.Format("Change ROPOA Vehicle status to RESERVED with Asset Number {0}", txtAssetNumber.Text), "", "", "")
                LoadData()
                LoadReserved()
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Reserved!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnReclassify_Click(sender As Object, e As EventArgs) Handles btnReclassify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim JV As New FrmJournalVoucher
        If btnReclassify.Text = "For Sell" Then
            With JV
                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                .Tag = 25
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

                .From_ROPOA = True
                .ROPOA_ForSell = True
                .CheckAmount = DataObject(String.Format("SELECT Running_Balance('{0}')", txtAssetNumber.Text))
                .BankID = cbxBank.SelectedValue
                .rExplanation.Text = "FOR SELL RECLASSIFIED"
                .cbxPayee.Tag = cbxAccountName.Text
                .txtReferenceNumber.Text = txtAssetNumber.Text
                .txtReferenceNumber.Tag = txtAssetNumber.Text
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", txtPlateNum.Text))
                    LoadData()
                    LoadReclassified()
                    Logs("ROPOA Vehicle", "For Sell", "", String.Format("ROPOA Vehicle status to FOR SELL from RECLASSIFIED with Asset Number {0}", txtAssetNumber.Text), "", "", "")

                    Clear()
                    MsgBox("Successfully For Sell!", MsgBoxStyle.Information, "Info")
                End If
                .Dispose()
            End With
        Else
            With JV
                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                .Tag = 25
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

                .From_ROPOA = True
                .CheckAmount = DataObject(String.Format("SELECT Running_Balance('{0}')", txtAssetNumber.Text))
                .BankID = cbxBank.SelectedValue
                .rExplanation.Text = "Reclassified ROPOA"
                .cbxPayee.Tag = cbxAccountName.Text
                .txtReferenceNumber.Text = txtAssetNumber.Text
                .txtReferenceNumber.Tag = txtAssetNumber.Text
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'RECLASSIFIED' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", txtPlateNum.Text))
                    LoadData()
                    LoadReclassified()
                    Logs("ROPOA Vehicle", "Reclassify", "", String.Format("ROPOA Vehicle status to RECLASSIFIED from FOR SELL with Asset Number {0}", txtAssetNumber.Text), "", "", "")

                    Clear()
                    MsgBox("Successfully Reclassfied!", MsgBoxStyle.Information, "Info")
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnAppraise_Click(sender As Object, e As EventArgs) Handles btnAppraise.Click
        Dim Appraise As New FrmVehicleAppraisal
        With Appraise
            .Tag = 54
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
            Dim DateResult As String = DataObject(String.Format("SELECT IFNULL(appraise_date,DATE(NOW())) FROM appraise_ve WHERE appraise = 'ROPOA' AND asset_number = '{0}' AND `status` IN ('ACTIVE','PENDING') ORDER BY appraise_date DESC LIMIT 1;", txtAssetNumber.Text))
            If DateResult = "" Then
            Else
                MsgBox(String.Format("{0} Day(s) ago since last appraise for this ROPA", DateDiff(DateInterval.Day, CDate(DateResult), Date.Now)), MsgBoxStyle.Information, "Info")
            End If

            'Pass Value
            .From_Vehicle = True
            .AssetNumber = txtAssetNumber.Text
            .cbxAppraiseFor.Text = "ROPOA"
            .vMake = cbxMake.Text
            .vType = cbxType.Text
            .cbxUsed.Text = cbxUsed.Text
            .vModel = cbxModel.Text
            .txtSeries.Text = txtSeries.Text
            .txtPlateNum.Text = txtPlateNum.Text
            .cbxTransmission.Text = cbxTransmission.Text
            .vFuel = cbxFuel.Text
            .cbxBodyColor.Text = cbxBodyColor.Text
            If dtpYear.CustomFormat = "" Then
                .dtpYear.CustomFormat = ""
            Else
                .dtpYear.CustomFormat = "     yyyy"
                .dtpYear.Value = dtpYear.Value
            End If
            .cbxEngineNumber.Text = cbxEngine.Text
            .txtChassisNum.Text = txtChassis.Text
            .txtRegistryCert.Text = txtRegistryCert.Text
            .txtORNum.Text = txtORNum.Text
            .dGrossWeight.Value = dGrossWeight.Value
            .iRim.Value = iRim.Value
            .dMileAge.Value = dMileAge.Value
            .vMileAge = cbxMileAge.Text
            .dtpRegistered.Value = dtpRegistered.Value
            .cbxNA.Checked = cbxNA.Checked
            .txtLTO.Text = txtLTO.Text

            .PanelEx1.Enabled = False
            If .ShowDialog = DialogResult.OK Then

            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnMultileA_Click(sender As Object, e As EventArgs) Handles btnMultipleA.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure that this ROPOA does have a multiple account?") = MsgBoxResult.Yes Then
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnAddImage.Enabled = True

            PanelEx2.Enabled = True
            txtKeyword.Text = ""
            txtKeyword.Enabled = False
            cbxAdvance.Enabled = False
            btnSearch.Enabled = False
            btnBack_2.Enabled = False
            iFrom.Enabled = False
            iTo.Enabled = False
            iTo.Value = 0
            btnNext_2.Enabled = False

            PanelEx4.Enabled = False
            btnPurchase.Enabled = False
            btnHistory.Enabled = False
            btnReserve.Enabled = False
            btnReclassify.Enabled = False
            btnAppraise.Enabled = False

            cbxNature.Enabled = False
            GetROPOA()
            cbxCondition.Enabled = False
            txtReason.Enabled = False
            cbxMake.Enabled = False
            cbxType.Enabled = False
            cbxModel.Enabled = False
            txtPlateNum.Enabled = False
            cbxTransmission.Enabled = False
            cbxFuel.Enabled = False
            cbxBodyColor.Enabled = False
            dtpYear.Enabled = False
            cbxEngine.Enabled = False
            txtChassis.Enabled = False
            txtRegistryCert.Enabled = False
            txtORNum.Enabled = False
            dGrossWeight.Enabled = False
            iRim.Enabled = False
            dMileAge.Enabled = False
            dPrice.Enabled = False
            txtRemarks.Enabled = False
            dtpRegistered.Enabled = False
            cbxNA.Enabled = False
            txtLTO.Enabled = False

            cbxAccountName.Enabled = True
            cbxAccountName.Text = ""
            txtAccountNo.Text = ""
            dBalanceTransferred.Value = 0
            dBalanceTransferred.Enabled = True
            txtAccountNo.Enabled = True
            cbxAccountName.DroppedDown = True
            cbxAccountName.Focus()

            btnMultipleA.Enabled = False
            MultipleA = True
        End If
    End Sub

    Private Sub CbxAdvance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdvance.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAdvance.Checked Then
            lblLocation.Visible = True
        Else
            lblLocation.Visible = False
        End If
        btnSearch.PerformClick()
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxNature.Text = "" Or cbxNature.SelectedIndex = -1 Then
            MsgBox("Please select nature of ROPOA.", MsgBoxStyle.Information, "Info")
            cbxNature.DroppedDown = True
            Exit Sub
        End If
        If cbxAccountName.Text.Trim = "" Or cbxAccountName.SelectedIndex = -1 Then
            MsgBox("Selected Account Name is not in the list, please check you data.", MsgBoxStyle.Information, "Info")
            cbxAccountName.DroppedDown = True
            Exit Sub
        End If
        If txtAccountNo.Text.Trim = "" Then
            MsgBox("Please fill the account no", MsgBoxStyle.Information, "Info")
            txtAccountNo.Focus()
            Exit Sub
        End If
        If cbxCondition.Text = "" Or cbxCondition.SelectedIndex = -1 Then
            MsgBox("Please select condition.", MsgBoxStyle.Information, "Info")
            cbxCondition.DroppedDown = True
            Exit Sub
        End If
        If cbxCondition.Text = "Not Running" Then
            If txtReason.Text = "" Then
                MsgBox("Please fill reason for condition not running.", MsgBoxStyle.Information, "Info")
                txtReason.Focus()
                Exit Sub
            End If
        End If
        If cbxMake.Text = "" Or cbxMake.SelectedIndex = -1 Then
            MsgBox("Please select maker.", MsgBoxStyle.Information, "Info")
            cbxMake.DroppedDown = True
            Exit Sub
        End If
        If cbxType.Text = "" Or cbxType.SelectedIndex = -1 Then
            MsgBox("Please select type.", MsgBoxStyle.Information, "Info")
            cbxType.DroppedDown = True
            Exit Sub
        End If
        If cbxModel.Text = "" Then
            If MsgBoxYes("Model is empty, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                cbxModel.DroppedDown = True
                Exit Sub
            End If
        End If
        If txtPlateNum.Text = "" Then
            MsgBox("Please fill Plate Number field.", MsgBoxStyle.Information, "Info")
            txtPlateNum.Focus()
            Exit Sub
        End If
        If cbxTransmission.Text = "" Or cbxTransmission.SelectedIndex = -1 Then
            MsgBox("Please select transmission.", MsgBoxStyle.Information, "Info")
            cbxTransmission.DroppedDown = True
            Exit Sub
        End If
        If cbxFuel.Text = "" Or cbxFuel.SelectedIndex = -1 Then
            MsgBox("Please select fuel.", MsgBoxStyle.Information, "Info")
            cbxFuel.DroppedDown = True
            Exit Sub
        End If
        If dPrice.Value = 0 Then
            dPrice.Value = 1
        End If
        If IsDate(dtpDate.Text) = False Then
            MsgBox("Please fill the correct ROPOA Date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dBalanceTransferred.Value = 0 Then
            MsgBox("Please fill Balance Transfer.", MsgBoxStyle.Information, "Info")
            dBalanceTransferred.Focus()
            Exit Sub
        End If
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            MsgBox("Please select a bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        Dim Bank As Integer = drv("Code")

        If MsgBoxYes("Are you sure you want to verify this ROPOA?") = MsgBoxResult.Yes Then
            Dim Reason As String = "Verify" 'Reason for change

            Cursor = Cursors.WaitCursor
            If MultipleA = False Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_vehicle WHERE (PlateNum = '{0}' OR RegistryCert = '{1}' OR ORNum = '{2}') AND `status` = 'ACTIVE' AND AssetNumber != '{3}'", txtPlateNum.Text, txtRegistryCert.Text, txtORNum.Text, txtAssetNumber.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Plate Number, Registry Certificate or OR Number already exist, Please check your data.", txtPlateNum.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If

            Dim SQL As String = "UPDATE ropoa_vehicle SET"
            SQL &= String.Format(" Nature = '{0}', ", cbxNature.Text)
            SQL &= String.Format(" Publish = '{0}', ", If(cbxPublish.Checked, 1, 0))
            If MultipleA = False Then
                SQL &= String.Format(" AccountID = '{0}', ", cbxAccountName.SelectedValue)
                SQL &= String.Format(" AccountNo = '{0}', ", txtAccountNo.Text)
            End If
            If dtpDate.Enabled Then
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AssetNumber = '{0}', ", txtAssetNumber.Text)
            End If
            SQL &= String.Format(" `Condition` = '{0}', ", cbxCondition.Text)
            SQL &= String.Format(" `ConditionReason` = '{0}', ", txtReason.Text)
            SQL &= String.Format(" Make = '{0}', ", cbxMake.Text)
            SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
            SQL &= String.Format(" Model = '{0}', ", cbxModel.Text)
            SQL &= String.Format(" Series = '{0}', ", txtSeries.Text)
            SQL &= String.Format(" PlateNum = '{0}', ", txtPlateNum.Text)
            SQL &= String.Format(" Transmission = '{0}', ", cbxTransmission.Text)
            SQL &= String.Format(" Fuel = '{0}', ", cbxFuel.Text)
            SQL &= String.Format(" BodyColor = '{0}', ", cbxBodyColor.Text)
            SQL &= String.Format(" `Year` = '{0}', ", If(dtpYear.CustomFormat = "", "", dtpYear.Text))
            SQL &= String.Format(" EngineNum = '{0}', ", cbxEngine.Text)
            SQL &= String.Format(" ChassisNum = '{0}', ", txtChassis.Text)
            SQL &= String.Format(" RegistryCert = '{0}', ", txtRegistryCert.Text)
            SQL &= String.Format(" ORNum = '{0}', ", txtORNum.Text)
            SQL &= String.Format(" GrossWeight = '{0}', ", dGrossWeight.Value)
            SQL &= String.Format(" RimHoles = '{0}', ", iRim.Value)
            SQL &= String.Format(" MileAge = '{0}', ", dMileAge.Value)
            SQL &= String.Format(" MileAgeType = '{0}', ", cbxMileAge.Text)
            SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
            SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
            SQL &= String.Format(" Img = '{0}', ", TotalImage)
            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
            SQL &= String.Format(" YardID = '{0}', ", ValidateComboBox(cbxYard))
            SQL &= String.Format(" Bank = '{0}', `status` = 'ACTIVE', ", Bank)
            SQL &= String.Format(" Remarks = '{0}' ", txtRemarks.Text)
            If MultipleA Then
                SQL &= String.Format(" WHERE PlateNum = '{0}';", txtPlateNum.Text)
            Else
                If dtpDate.Enabled Then
                    SQL &= String.Format(" WHERE AssetNumber = '{0}';", txtAssetNumber.Tag)
                Else
                    SQL &= String.Format(" WHERE AssetNumber = '{0}';", txtAssetNumber.Text)
                End If
            End If
            'ACCOUNTING ENTRY *******************************************************************************************************
            SQL &= "INSERT INTO accounting_entry SET"
            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
            SQL &= " EntryType = 'DEBIT',"
            SQL &= String.Format(" Payable = '{0}', ", dBalanceTransferred.Value)
            SQL &= String.Format(" Amount = '{0}', ", dBalanceTransferred.Value)
            SQL &= " AccountCode = '126002X', "
            SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126002")))
            SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
            SQL &= " PostStatus = 'POSTED', "
            SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
            SQL &= String.Format(" ReferenceN = '{0}', ", txtAssetNumber.Text)
            SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
            SQL &= String.Format(" CVNumber = '{0}', ", txtPlateNum.Text)
            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
            'ACCOUNTING ENTRY *******************************************************************************************************
            DataObject(SQL)
            For x As Integer = 1 To TotalImage
                Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                If pb.Image Is Nothing Then
                Else
                    ResizeImages(pb.Image.Clone, pb, 850, 700)
                    SaveImage(pb, pb.Properties.NullText & x)
                End If
            Next
            Logs("ROPOA Vehicle", "Verify", Reason, String.Format("Verify ROPOA Vehicle with Asset Number {0}", txtAssetNumber.Text), "", "", "")
            LoadData()
            btnPurchase.Enabled = True
            btnHistory.Enabled = True
            btnReserve.Enabled = True
            btnReclassify.Enabled = True
            btnAppraise.Enabled = True
            btnMultipleA.Enabled = True
            btnVerify.Enabled = False
            PanelEx2.Enabled = False
            btnModify.Enabled = True
            btnSave.Enabled = False
            FrmMain.VehicleCount = FrmMain.VehicleCount + 1
            Cursor = Cursors.Default
            MsgBox("Successfully Verified", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxRedemption_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRedemption.CheckedChanged
        If cbxRedemption.Checked Then

        End If
    End Sub

    Private Sub LabelX20_MouseClick(sender As Object, e As MouseEventArgs) Handles LabelX20.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If iRim.Enabled = False Then
                iRim.Enabled = True
            Else
                iRim.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnPrint_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPrint.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            BtnPrint_Click(sender, e)
            Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Vehicle ROPA " & txtAssetNumber.Text, "", "", "", "")
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If vPrint Then
            Else
                MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If SuperTabControl1.SelectedTabIndex = 1 Then
                GridView2.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Vehicle List", GridControl2)
                Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Vehicle List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                GridView3.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Sold Vehicle List", GridControl3)
                Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Sold Vehicle List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                GridView4.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Scrap Vehicle List", GridControl4)
                Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Scrap Vehicle List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                GridView5.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Reserved Vehicle List", GridControl5)
                Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Reserved Vehicle List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                GridView6.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Reclassified Vehicle List", GridControl6)
                Logs("Vehicle ROPA", "Print", "[SENSITIVE] Print Reclassified Vehicle List", "", "", "", "")
            End If
        End If
    End Sub

    Private Sub IDiscount_Click(sender As Object, e As EventArgs) Handles iDiscount.Click
        Try
            If GridView5.GetFocusedRowCellValue("ID").ToString = "" Or GridView5.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Exist As DataTable = DataSource(String.Format("SELECT ID FROM ledger_ropoa WHERE `transaction` = 'Discount' AND `status` = 'ACTIVE' AND approve_status = 'PENDING' AND IF(ROPOA_REF = '',Asset_Number = '{0}',ROPOA_REF = '{1}');", GridView5.GetFocusedRowCellValue("Asset Number"), GridView5.GetFocusedRowCellValue("Plate Number")))
        If Exist.Rows.Count > 0 Then
            If MsgBoxYes("ROPOA already have a pending discount, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        Dim Discount As New FrmROPOADiscount
        With Discount
            .TransactionNo = GridView5.GetFocusedRowCellValue("transaction_no")
            .TotalImage = GridView5.GetFocusedRowCellValue("Attach")
            .ROPOA_Type = "Vehicle"
            .MultipleA = If(GridView5.GetFocusedRowCellValue("account_count") > 1, True, False)
            .ROPOA_Ref = GridView5.GetFocusedRowCellValue("Plate Number")
            .CbxPrefix_B.Text = GridView5.GetFocusedRowCellValue("Prefix_B")
            .TxtFirstN_B.Text = GridView5.GetFocusedRowCellValue("FirstN_B")
            .TxtMiddleN_B.Text = GridView5.GetFocusedRowCellValue("MiddleN_B")
            .TxtLastN_B.Text = GridView5.GetFocusedRowCellValue("LastN_B")
            .cbxSuffix_B.Text = GridView5.GetFocusedRowCellValue("Suffix_B")
            .txtAssetNumber.Text = GridView5.GetFocusedRowCellValue("Asset Number")
            .txtAccountName.Text = GridView5.GetFocusedRowCellValue("Account Name")
            .txtAccountName.Text = GridView5.GetFocusedRowCellValue("Account No")
            .lblMake.Text = "Make :"
            .txtMake.Text = GridView5.GetFocusedRowCellValue("Make")
            .lblType.Text = "Type :"
            .txtType.Text = GridView5.GetFocusedRowCellValue("Type")
            .lblModel.Text = "Model :"
            .txtModel.Text = GridView5.GetFocusedRowCellValue("Model")
            .dPrice.Value = GridView5.GetFocusedRowCellValue("Price")
            .dROPOA_Value.Value = CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", GridView5.GetFocusedRowCellValue("Asset Number"))))
            .dSoldPrice.Value = GridView5.GetFocusedRowCellValue("Amount")
            .dBalance.Value = GridView5.GetFocusedRowCellValue("Balance")
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IModifyBuyer_Click(sender As Object, e As EventArgs) Handles iBuyer.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Buyer As New FrmROPOABuyer
        If SuperTabControl1.SelectedTabIndex = 2 Then
            Try
                If GridView3.GetFocusedRowCellValue("ID").ToString = "" Or GridView3.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Buyer
                .ID = GridView3.GetFocusedRowCellValue("S_ID")
                .AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")

                .vPrefix = GridView3.GetFocusedRowCellValue("Prefix_B")
                .CbxPrefix_B.Tag = GridView3.GetFocusedRowCellValue("Prefix_B")
                .TxtFirstN_B.Text = GridView3.GetFocusedRowCellValue("FirstN_B")
                .TxtFirstN_B.Tag = GridView3.GetFocusedRowCellValue("FirstN_B")
                .TxtMiddleN_B.Text = GridView3.GetFocusedRowCellValue("MiddleN_B")
                .TxtMiddleN_B.Tag = GridView3.GetFocusedRowCellValue("MiddleN_B")
                .TxtLastN_B.Text = GridView3.GetFocusedRowCellValue("LastN_B")
                .TxtLastN_B.Tag = GridView3.GetFocusedRowCellValue("LastN_B")
                .vSuffix = GridView3.GetFocusedRowCellValue("Suffix_B")
                .cbxSuffix_B.Tag = GridView3.GetFocusedRowCellValue("Suffix_B")
                .txtNoC_B.Text = GridView3.GetFocusedRowCellValue("NoC_B")
                .txtNoC_B.Tag = GridView3.GetFocusedRowCellValue("NoC_B")
                .txtStreetC_B.Text = GridView3.GetFocusedRowCellValue("StreetC_B")
                .txtStreetC_B.Tag = GridView3.GetFocusedRowCellValue("StreetC_B")
                .txtBarangayC_B.Text = GridView3.GetFocusedRowCellValue("BarangayC_B")
                .txtBarangayC_B.Tag = GridView3.GetFocusedRowCellValue("BarangayC_B")
                .vAddress = GridView3.GetFocusedRowCellValue("AddressC_B")
                .cbxAddressC_B.Tag = GridView3.GetFocusedRowCellValue("AddressC_B")
                .txtContact_B.Text = GridView3.GetFocusedRowCellValue("Contact_N")
                .txtContact_B.Tag = GridView3.GetFocusedRowCellValue("Contact_N")

                .btnSave.Enabled = False
                If .ShowDialog = DialogResult.OK Then
                    LoadSold()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            Try
                If GridView5.GetFocusedRowCellValue("ID").ToString = "" Or GridView5.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Buyer
                .ID = GridView5.GetFocusedRowCellValue("S_ID")
                .AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")

                .vPrefix = GridView5.GetFocusedRowCellValue("Prefix_B")
                .CbxPrefix_B.Tag = GridView5.GetFocusedRowCellValue("Prefix_B")
                .TxtFirstN_B.Text = GridView5.GetFocusedRowCellValue("FirstN_B")
                .TxtFirstN_B.Tag = GridView5.GetFocusedRowCellValue("FirstN_B")
                .TxtMiddleN_B.Text = GridView5.GetFocusedRowCellValue("MiddleN_B")
                .TxtMiddleN_B.Tag = GridView5.GetFocusedRowCellValue("MiddleN_B")
                .TxtLastN_B.Text = GridView5.GetFocusedRowCellValue("LastN_B")
                .TxtLastN_B.Tag = GridView5.GetFocusedRowCellValue("LastN_B")
                .vSuffix = GridView5.GetFocusedRowCellValue("Suffix_B")
                .cbxSuffix_B.Tag = GridView5.GetFocusedRowCellValue("Suffix_B")
                .txtNoC_B.Text = GridView5.GetFocusedRowCellValue("NoC_B")
                .txtNoC_B.Tag = GridView5.GetFocusedRowCellValue("NoC_B")
                .txtStreetC_B.Text = GridView5.GetFocusedRowCellValue("StreetC_B")
                .txtStreetC_B.Tag = GridView5.GetFocusedRowCellValue("StreetC_B")
                .txtBarangayC_B.Text = GridView5.GetFocusedRowCellValue("BarangayC_B")
                .txtBarangayC_B.Tag = GridView5.GetFocusedRowCellValue("BarangayC_B")
                .vAddress = GridView5.GetFocusedRowCellValue("AddressC_B")
                .cbxAddressC_B.Tag = GridView5.GetFocusedRowCellValue("AddressC_B")
                .txtContact_B.Text = GridView5.GetFocusedRowCellValue("Contact_N")
                .txtContact_B.Tag = GridView5.GetFocusedRowCellValue("Contact_N")

                If .ShowDialog = DialogResult.OK Then
                    LoadReserved()
                End If
            End With
        End If
        Buyer.Dispose()
    End Sub

    Private Sub DtpDate_Enter(sender As Object, e As EventArgs) Handles dtpDate.Enter
        dtpDate.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        If cbxNA.Checked Then
            dtpRegistered.Enabled = False
            dtpRegistered.CustomFormat = ""
        Else
            dtpRegistered.Enabled = True
            dtpRegistered.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "ROPOA Attachments"
            .TotalImage = TotalImage_II
            .AssetNumber = txtAssetNumber.Text
            .ID = txtAssetNumber.Text
            .Type = "VE Attachment 1"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_II = Attach.TotalImage
                If ROPOA_Status = "Sell" Then
                    LoadData()
                ElseIf ROPOA_Status = "Sold" Then
                    LoadSold()
                ElseIf ROPOA_Status = "Scrap" Then
                    LoadScrap()
                ElseIf ROPOA_Status = "Reserved" Then
                    LoadReserved()
                ElseIf ROPOA_Status = "Reclassified" Then
                    LoadReclassified()
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IReferral_Click(sender As Object, e As EventArgs) Handles iReferral.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Referral As New FrmROPOAReferral
        If SuperTabControl1.SelectedTabIndex = 2 Then
            Try
                If GridView3.GetFocusedRowCellValue("ID").ToString = "" Or GridView3.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Referral
                .AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")
                .ID = GridView3.GetFocusedRowCellValue("S_ID")

                .vAgent = GridView3.GetFocusedRowCellValue("Referral_ID")
                .vMarketing = GridView3.GetFocusedRowCellValue("Referral_ID")
                .vDealer = GridView3.GetFocusedRowCellValue("Referral_ID")
                If GridView3.GetFocusedRowCellValue("Referral") = "A" Then
                    .cbxAgent.Checked = True
                ElseIf GridView3.GetFocusedRowCellValue("Referral") = "M" Then
                    .cbxMarketing.Checked = True
                ElseIf GridView3.GetFocusedRowCellValue("Referral") = "D" Then
                    .cbxDealer.Checked = True
                End If

                .btnSave.Enabled = False
                .cbxAgent.Enabled = False
                .cbxMarketing.Enabled = False
                .cbxDealer.Enabled = False
                .cbxAgentName.Enabled = False
                .cbxMarketingName.Enabled = False
                .cbxDealerName.Enabled = False
                .txtAgentContact.Enabled = False
                .txtMarketingContact.Enabled = False
                .txtDealersContact.Enabled = False
                If .ShowDialog = DialogResult.OK Then
                    LoadSold()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            Try
                If GridView5.GetFocusedRowCellValue("ID").ToString = "" Or GridView5.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Referral
                .AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")
                .ID = GridView5.GetFocusedRowCellValue("S_ID")

                .vAgent = GridView5.GetFocusedRowCellValue("Referral_ID")
                .vMarketing = GridView5.GetFocusedRowCellValue("Referral_ID")
                .vDealer = GridView5.GetFocusedRowCellValue("Referral_ID")
                If GridView5.GetFocusedRowCellValue("Referral") = "A" Then
                    .cbxAgent.Checked = True
                ElseIf GridView5.GetFocusedRowCellValue("Referral") = "M" Then
                    .cbxMarketing.Checked = True
                ElseIf GridView5.GetFocusedRowCellValue("Referral") = "D" Then
                    .cbxDealer.Checked = True
                End If

                If .ShowDialog = DialogResult.OK Then
                    LoadReserved()
                End If
            End With
        End If
        Referral.Dispose()
    End Sub

    Private Sub IPDC_Click(sender As Object, e As EventArgs) Handles iPDC.Click
        Dim Sched As New FrmPurchaseSched
        With Sched
            .Buyer = If(GridView5.GetFocusedRowCellValue("Prefix_B") = "", "", GridView5.GetFocusedRowCellValue("Prefix_B") & " ") & If(GridView5.GetFocusedRowCellValue("FirstN_B") = "", "", GridView5.GetFocusedRowCellValue("FirstN_B") & " ") & If(GridView5.GetFocusedRowCellValue("MiddleN_B") = "", "", GridView5.GetFocusedRowCellValue("MiddleN_B") & " ") & If(GridView5.GetFocusedRowCellValue("LastN_B") = "", "", GridView5.GetFocusedRowCellValue("LastN_B") & " ") & GridView5.GetFocusedRowCellValue("Suffix_B")
            .ContactN = GridView5.GetFocusedRowCellValue("Contact_N")
            .Months = 6
            .From_Reserve = True
            .xDate = Date.Now
            .Amount = 0
            .AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")
            .ORNumber = ""
            .TotalPayable = GridView5.GetFocusedRowCellValue("Amount")
            .BankID = GridView5.GetFocusedRowCellValue("BankID")
            If .ShowDialog = DialogResult.OK Then

            End If
        End With
    End Sub

    Private Sub BtnAddImages_Click(sender As Object, e As EventArgs) Handles btnAddImages.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Image File|*.jpg;*.jpeg;*.png",
            .Multiselect = True
        }
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                TotalImage = 0
                Dim x As Integer = 1
                For Each sFile As String In OFD.FileNames
                    If x = 6 Then 'PARA DLI RA MANOBRA ANG I UPLOAD
                        Exit Sub
                    End If
                    ClearPictureEdit(PanelEx4, x)
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        If x Mod 5 = 1 Then
                            .Properties.NullText = "Front"
                        ElseIf x Mod 5 = 2 Then
                            .Properties.NullText = "Back"
                        ElseIf x Mod 5 = 3 Then
                            .Properties.NullText = "Interior"
                        ElseIf x Mod 5 = 4 Then
                            .Properties.NullText = "Engine"
                        ElseIf x Mod 5 = 0 Then
                            .Properties.NullText = "Odometer"
                        End If
                        .Size = New Size(200, 150)
                        PanelEx4.Controls.Add(pB)
                        .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        If TotalImage >= 5 Then
                            If TotalImage >= 10 Then
                                If TotalImage >= 15 Then
                                    If TotalImage >= 20 Then
                                        If TotalImage >= 25 Then
                                            If TotalImage >= 30 Then
                                                If TotalImage >= 35 Then
                                                    If TotalImage >= 40 Then
                                                        If TotalImage >= 45 Then
                                                            If TotalImage >= 50 Then
                                                                .Location = New Point(3 + (230 * (TotalImage - 50)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            Else
                                                                .Location = New Point(3 + (230 * (TotalImage - 45)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            End If
                                                        Else
                                                            .Location = New Point(3 + (230 * (TotalImage - 40)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                        End If
                                                    Else
                                                        .Location = New Point(3 + (230 * (TotalImage - 35)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    End If
                                                Else
                                                    .Location = New Point(3 + (230 * (TotalImage - 30)), 3 + 156 + 156 + 156 + 156 + 156 + 156)
                                                End If
                                            Else
                                                .Location = New Point(3 + (230 * (TotalImage - 25)), 3 + 156 + 156 + 156 + 156 + 156)
                                            End If
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * TotalImage), 3)
                        End If
                        TotalImage += 1
                        .Visible = True
                        .Tag = TotalImage
                        .BorderStyle = BorderStyle.FixedSingle
                        AddHandler .Click, AddressOf Pb_Click
                        FirstLoad = True
                        AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                        .BringToFront()
                    End With
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(sFile)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
                    x += 1
                    FirstLoad = False
                Next
            Catch ex As Exception
                PanelEx4.AutoScroll = True
                MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub IAttach_Click(sender As Object, e As EventArgs) Handles iAttach.Click
        Dim AssetNumber As String = ""
        Dim TotalImageSelected As Integer = 0
        If SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView2.RowCount > 0 Then
                Try
                    If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView2.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView2.GetFocusedRowCellValue("Attach")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If GridView3.RowCount > 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView3.GetFocusedRowCellValue("Attach")
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView4.RowCount > 0 Then
                Try
                    If GridView4.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView4.GetFocusedRowCellValue("Attach")
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView5.RowCount > 0 Then
                Try
                    If GridView5.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView5.GetFocusedRowCellValue("Attach")
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            If GridView6.RowCount > 0 Then
                Try
                    If GridView6.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView6.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView6.GetFocusedRowCellValue("Attach")
        End If
        Dim Attach As New FrmAttachFileV2
        With Attach
            .AllowOveright = False
            .FolderName = "Purchase-" & AssetNumber
            .TotalImage = TotalImageSelected
            .AssetNumber = AssetNumber
            .ID = AssetNumber
            .Type = "Purchase VE"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    GridView4.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    GridView5.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                    GridView6.SetFocusedRowCellValue("Attach", TotalImage)
                End If
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    GridView4.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    GridView5.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                    GridView6.SetFocusedRowCellValue("Attach", TotalImage)
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView2.RowCount = 0 Then
                Exit Sub
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If GridView3.RowCount = 0 Then
                Exit Sub
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView4.RowCount = 0 Then
                Exit Sub
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView5.RowCount = 0 Then
                Exit Sub
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            If GridView6.RowCount = 0 Then
                Exit Sub
            End If
        End If

        Dim AssetNumber As String = ""
        If MultipleA Then
            Dim AccountList As New FrmAccountList
            With AccountList
                Dim PlateNumber As String = ""
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    PlateNumber = GridView2.GetFocusedRowCellValue("Plate Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    PlateNumber = GridView3.GetFocusedRowCellValue("Plate Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    PlateNumber = GridView4.GetFocusedRowCellValue("Plate Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    PlateNumber = GridView5.GetFocusedRowCellValue("Plate Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                    PlateNumber = GridView6.GetFocusedRowCellValue("Plate Number")
                End If
                .DT_Account = DataSource(String.Format("SELECT AccountNo, AssetNumber FROM ropoa_vehicle WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", PlateNumber))
                If .ShowDialog = DialogResult.OK Then
                    AssetNumber = .AssetNumber
                Else
                    Exit Sub
                End If
                .Dispose()
            End With
        Else
            If SuperTabControl1.SelectedTabIndex = 1 Then
                AssetNumber = GridView2.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                AssetNumber = GridView6.GetFocusedRowCellValue("Asset Number")
            End If
        End If

        Dim History As New FrmROPOALedger
        With History
            .Tag = 53
            .AssetNumber = AssetNumber
            .ROPOA_Status = ROPOA_Status
            .MultipleA = MultipleA
            .ROPOA_Ref = txtPlateNum.Text

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

            If .ShowDialog = DialogResult.OK Then
                Clear()
                LoadData()
            End If
            .Dispose()
        End With
    End Sub
End Class