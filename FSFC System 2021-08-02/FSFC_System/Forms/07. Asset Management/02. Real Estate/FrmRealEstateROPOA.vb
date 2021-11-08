Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmRealEstateROPOA

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
    Dim TotalImage_F As Integer
    Dim FirstLoad As Boolean = True
    Dim RopoaBranchCode As String
    Dim AddImage As Boolean
    Dim HidePrice As Boolean
    Dim MultipleA As Boolean
    Public ReceivedCOS As Date = Date.Now
    Public ReceivedCOS_Tag As Date = Date.Now
    Public COS_Annotation As Date = Date.Now
    Public COS_Annotation_Tag As Date = Date.Now
    Public ConsolidationD As String
    Dim DT_Pictures As New DataTable

    Private Sub FrmRealEstate_ROPOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        RopoaBranchCode = Branch_Code
        GetROPOA()
        SuperTabControl1.SelectedTab = tabList
        dtpDate.Value = "1/1/1753"

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

        LoadData()
        LoadSold()
        LoadReserved()
        LoadReclassified()
        LoadImage()

        FirstLoad = False

        LabelX5.Visible = False
        dPrice.Visible = False
        LabelX6.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn7.Visible = False
        GridColumn42.Visible = False
        GridColumn89.Visible = False
        GridColumn121.Visible = False
        HidePrice = True
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX17, LabelX22, LabelX14, LabelX1, LabelX4, LabelX26, LabelX27, LabelX28, LabelX29, LabelX23, LabelX155, LabelX2, LabelX30, LabelX31, LabelX32, LabelX16, LabelX19, LabelX24, LabelX7, LabelX3, LabelX5, LabelX6, LabelX33, LabelX34, LabelX35, LabelX36, LabelX37, LabelX38})

            GetLabelFontSettingsDefault({lblBlack, lblRed, lblBlue, lblSold, lblLocation})

            GetTextBoxFontSettings({txtKeyword, txtTCT, txtStorey, txtFrame, txtWalling, txtPartitions, txtRoofings, txtBeams, txtCeilings, txtAssetNumber, txtLocation, txtOthers, txtFlooring, txtDoors, txtWindows, txtAccountNo, txtCoordinates, txtTandB, txtYearConstructed, txtFloorArea})

            GetCheckBoxFontSettings({cbxAdvance, cbxPublish, cbxRedemption, cbxResidential, cbxCommercial, cbxAgricultural, cbxTourism, cbxIndustrial, cbxCondominium, cbxOthers, cbxVacant})

            GetComboBoxFontSettings({cbxAccountName, cbxBank})

            GetComboBoxWinFormFontSettings({cbxNature})

            GetDateTimeInputFontSettings({dtpDate})

            GetDoubleInputFontSettings({dArea, dPrice, dBalanceTransferred})

            GetIntegerInputFontSettings({iFrom, iTo})

            GetRickTextBoxFontSettings({txtRemarks})

            GetButtonFontSettings({btnSearch, btnRedemption, btnAddImage, btnPurchase, btnHistory, btnReserve, btnReclassify, btnAppraise, btnMultipleA, btnVerify, btnMap, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnRepricing})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Real Estate ROPA - FixUI", ex.Message.ToString)
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
        OpenFormHistory("ROPOA Real Estate", lblTitle.Text)
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetROPOA()
    End Sub

    Private Sub GetROPOA()
        txtAssetNumber.Text = DataObject(String.Format("SELECT CONCAT('ANR', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM ropoa_realestate WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
    End Sub

    Private Sub CbxVacant_CheckedChanged(sender As Object, e As EventArgs) Handles cbxVacant.CheckedChanged
        If cbxVacant.Checked Then
            txtStorey.Enabled = False
            txtRoofings.Enabled = False
            txtFlooring.Enabled = False
            txtTandB.Enabled = False
            txtFrame.Enabled = False
            txtBeams.Enabled = False
            txtDoors.Enabled = False
            txtYearConstructed.Enabled = False
            txtWalling.Enabled = False
            txtCeilings.Enabled = False
            txtWindows.Enabled = False
            txtFloorArea.Enabled = False
            txtPartitions.Enabled = False

            txtStorey.Text = ""
            txtRoofings.Text = ""
            txtFlooring.Text = ""
            txtTandB.Text = ""
            txtFrame.Text = ""
            txtBeams.Text = ""
            txtDoors.Text = ""
            txtYearConstructed.Text = ""
            txtWalling.Text = ""
            txtCeilings.Text = ""
            txtWindows.Text = ""
            txtFloorArea.Text = ""
            txtPartitions.Text = ""
        Else
            txtStorey.Enabled = True
            txtRoofings.Enabled = True
            txtFlooring.Enabled = True
            txtTandB.Enabled = True
            txtFrame.Enabled = True
            txtBeams.Enabled = True
            txtDoors.Enabled = True
            txtYearConstructed.Enabled = True
            txtWalling.Enabled = True
            txtCeilings.Enabled = True
            txtWindows.Enabled = True
            txtFloorArea.Enabled = True
            txtPartitions.Enabled = True
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, DATE_FORMAT(trans_date,'%b %d, %Y') AS 'Date',COS_Received, COS_Annotation,Consolidation_Date,TCT_New,"
        SQL &= "    Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    AssetNumber AS 'Asset Number',"
        SQL &= "    TCT AS 'TCT Number',"
        SQL &= "    Location,"
        SQL &= "    `Area` AS 'Area',"
        SQL &= "    Classification,"
        SQL &= "    Price, BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    VacantLot AS 'Vacant Lot',"
        SQL &= "    Storey AS 'Storeys',"
        SQL &= "    Roofings,"
        SQL &= "    Flooring AS 'Floorings',"
        SQL &= "    TandB AS 'T and B',"
        SQL &= "    Frame,"
        SQL &= "    Beams,"
        SQL &= "    Doors,"
        SQL &= "    YearConstructed AS 'Yr Constructed',"
        SQL &= "    Walling AS 'Wallings',"
        SQL &= "    `Ceiling` AS 'Ceilings',"
        SQL &= "    Windows,"
        SQL &= "    FloorArea AS 'Floor Area',"
        SQL &= "    `Partitions`,"
        SQL &= "    Remarks,"
        SQL &= "    Img,"
        SQL &= "    Attach, Coordinates,"
        SQL &= "    branch_code, account_count, `Status`, Bank, BankID, Publish"
        SQL &= " FROM ropoa_realestate WHERE (`status` = 'ACTIVE' OR `status` = 'PENDING') AND sell_status = 'SELL'"
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
                    SQL &= String.Format(" `TCT` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(`Area`,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" `Classification` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Price,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" `VacantLot` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Roofings,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Flooring,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(TandB,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Frame,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Beams,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Doors,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" `YearConstructed` LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Walling,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(`Ceiling`,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(Windows,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(FloorArea,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" CONVERT(`Partitions`,CHAR) LIKE '%{0}%' OR", Key)
                    SQL &= String.Format(" `Remarks` LIKE '%{0}%' OR", Key)
                    If cbxAdvance.Checked Then
                        SQL &= String.Format(" (SELECT branch.branch FROM branch WHERE branch.branch_code = ropoa_realestate.branch_code) LIKE '%{0}%' OR Location LIKE '%{0}%')", Key)
                    Else
                        SQL &= String.Format(" Location LIKE '%{0}%')", Key)
                    End If
                Next
            Else
                Dim Key As String = txtKeyword.Text
                SQL &= String.Format(" AND (`Nature` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `AccountNo` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `TCT` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(`Area`,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `Classification` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Price,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `VacantLot` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Roofings,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Flooring,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(TandB,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Frame,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Beams,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Doors,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `YearConstructed` LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Walling,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(`Ceiling`,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(Windows,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(FloorArea,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" CONVERT(`Partitions`,CHAR) LIKE '%{0}%' OR", Key)
                SQL &= String.Format(" `Remarks` LIKE '%{0}%' OR", Key)
                If cbxAdvance.Checked Then
                    SQL &= String.Format(" (SELECT branch.branch FROM branch WHERE branch.branch_code = ropoa_realestate.branch_code) LIKE '%{0}%' OR Location LIKE '%{0}%')", Key)
                Else
                    SQL &= String.Format(" Location LIKE '%{0}%')", Key)
                End If
            End If
        End If
        SQL &= " GROUP BY TCT, Sell_Status, AccountID ORDER BY trans_date DESC"
        GridControl2.DataSource = DataSource(SQL)
        GridView2.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView2.RowCount > 22 Then
            GridColumn10.Width = 269 - 17
        Else
            GridColumn10.Width = 269
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadSold()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT R.ID, "
        SQL &= "    S.Amount AS 'Amount',"
        SQL &= "    GREATEST(S.Amount - ROPOA_Payment(S.AssetNumber,S.ID),0) AS 'Balance',"
        SQL &= "    IFNULL(CONCAT(IF(S.FirstN_B = '','',CONCAT(S.FirstN_B, ' ')), IF(S.MiddleN_B = '','',CONCAT(S.MiddleN_B, ' ')), S.LastN_B),'') AS 'Buyer',"
        SQL &= "    S.ID AS 'S_ID', S.Prefix_B,"
        SQL &= "    S.FirstN_B,"
        SQL &= "    S.MiddleN_B,"
        SQL &= "    S.LastN_B,"
        SQL &= "    S.Suffix_B,"
        SQL &= "    S.NoC_B,"
        SQL &= "    S.StreetC_B,"
        SQL &= "    S.BarangayC_B,"
        SQL &= "    S.AddressC_B,"
        SQL &= "    S.Contact_N, S.Reserved_Days, S.Remarks AS 'Sold Remarks', S.Referral, S.Referral_ID, "
        SQL &= "    DATE_FORMAT(R.trans_date,'%b %d, %Y') AS 'Date',R.COS_Received, R.COS_Annotation,R.Consolidation_Date,R.TCT_New,"
        SQL &= "    R.Nature,"
        SQL &= "    R.AccountName AS 'Account Name',"
        SQL &= "    R.AccountNo AS 'Account No',"
        SQL &= "    R.AssetNumber AS 'Asset Number',"
        SQL &= "    R.TCT AS 'TCT Number',"
        SQL &= "    R.Location,"
        SQL &= "    R.`Area` AS 'Area',"
        SQL &= "    R.Classification,"
        SQL &= "    R.Price, R.BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    R.VacantLot AS 'Vacant Lot',"
        SQL &= "    R.Storey AS 'Storeys',"
        SQL &= "    R.Roofings,"
        SQL &= "    R.Flooring AS 'Floorings',"
        SQL &= "    R.TandB AS 'T and B',"
        SQL &= "    R.Frame,"
        SQL &= "    R.Beams,"
        SQL &= "    R.Doors,"
        SQL &= "    R.YearConstructed AS 'Yr Constructed',"
        SQL &= "    R.Walling AS 'Wallings',"
        SQL &= "    R.`Ceiling` AS 'Ceilings',"
        SQL &= "    R.Windows,"
        SQL &= "    R.FloorArea AS 'Floor Area',"
        SQL &= "    R.`Partitions`,"
        SQL &= "    R.Remarks,"
        SQL &= "    R.Img,"
        SQL &= "    R.Attach, R.Coordinates,"
        SQL &= "    R.branch_code, R.account_count, R.Bank, R.BankID, R.Publish"
        SQL &= " FROM sold_ropoa S"
        SQL &= " INNER JOIN (SELECT MIN(ID) AS 'ID', Nature, GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'AccountName', GROUP_CONCAT(AccountNo) AS 'AccountNo', trans_date, COS_Received, COS_Annotation, Consolidation_Date, TCT_New, MIN(AssetNumber) AS 'AssetNumber', TCT, Location, `Area`, Classification, Price, BalanceTransferred, VacantLot, Storey, Roofings, Flooring, TandB, Frame, Beams, Doors, YearConstructed, Walling, `Ceiling`, Windows, FloorArea, `Partitions`, Remarks, Img, Attach, branch_code, account_count, Bank, Coordinates, BankID, Publish FROM ropoa_realestate WHERE sell_status = 'SOLD' AND `status` = 'ACTIVE' GROUP BY TCT, Sell_Status, AccountID) R"
        SQL &= "    ON S.AssetNumber = R.AssetNumber"
        SQL &= String.Format(" WHERE S.status = 'ACTIVE' AND SUBSTRING(S.AssetNumber,1,3) = 'ANR' AND FIND_IN_SET(S.Branch_ID,'{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID))
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
            GridColumn76.Width = 234 - 17
        Else
            GridColumn76.Width = 234
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadReserved()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT R.ID, "
        SQL &= "    IFNULL(S.Amount,0) AS 'Amount',"
        SQL &= "    GREATEST(IFNULL(S.Amount,0) - ROPOA_Payment(S.AssetNumber,S.ID),0) AS 'Balance',"
        SQL &= "    IFNULL(CONCAT(IF(S.FirstN_B = '','',CONCAT(S.FirstN_B, ' ')), IF(S.MiddleN_B = '','',CONCAT(S.MiddleN_B, ' ')), S.LastN_B),'') AS 'Buyer',"
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
        SQL &= "    DATE_FORMAT(R.trans_date,'%b %d, %Y') AS 'Date',R.COS_Received, R.COS_Annotation,R.Consolidation_Date,R.TCT_New,"
        SQL &= "    R.Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    R.AssetNumber AS 'Asset Number',"
        SQL &= "    R.TCT AS 'TCT Number',"
        SQL &= "    R.Location,"
        SQL &= "    R.`Area` AS 'Area',"
        SQL &= "    R.Classification,"
        SQL &= "    R.Price, R.BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    R.VacantLot AS 'Vacant Lot',"
        SQL &= "    R.Storey AS 'Storeys',"
        SQL &= "    R.Roofings,"
        SQL &= "    R.Flooring AS 'Floorings',"
        SQL &= "    R.TandB AS 'T and B',"
        SQL &= "    R.Frame,"
        SQL &= "    R.Beams,"
        SQL &= "    R.Doors,"
        SQL &= "    R.YearConstructed AS 'Yr Constructed',"
        SQL &= "    R.Walling AS 'Wallings',"
        SQL &= "    R.`Ceiling` AS 'Ceilings',"
        SQL &= "    R.Windows,"
        SQL &= "    R.FloorArea AS 'Floor Area',"
        SQL &= "    R.`Partitions`,"
        SQL &= "    R.Remarks,"
        SQL &= "    R.Img,"
        SQL &= "    R.Attach, R.Coordinates,"
        SQL &= "    IFNULL(S.reserved_days,0) AS 'reserved_days',"
        SQL &= "    IFNULL(S.reserved_status,'NO') AS 'reserved_status',"
        SQL &= "    R.`reserve_reason` AS 'Reserved Reason',"
        SQL &= "    R.branch_code, R.account_count, R.Bank, R.BankID, R.Publish"
        SQL &= " FROM ropoa_realestate R"
        SQL &= " LEFT JOIN (SELECT ID, Amount, AssetNumber, Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, NoC_B, StreetC_B, BarangayC_B, AddressC_B, Contact_N, reserved_days, reserved_status, Referral, Referral_ID  FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANR') S"
        SQL &= "    ON S.AssetNumber = R.AssetNumber"
        SQL &= String.Format(" WHERE (R.sell_status = 'SOLD' OR R.sell_status = 'RESERVED') AND `status` = 'ACTIVE' AND FIND_IN_SET(R.Branch_ID,'{0}') GROUP BY R.TCT", If(Multiple_ID = "", Branch_ID, Multiple_ID))
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
        GridControl1.DataSource = DT
        GridView1.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn82.Width = 234 - 17
        Else
            GridColumn82.Width = 234
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadReclassified()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, DATE_FORMAT(trans_date,'%b %d, %Y') AS 'Date',COS_Received, COS_Annotation,Consolidation_Date,TCT_New,"
        SQL &= "    Nature,"
        SQL &= "    GROUP_CONCAT(DISTINCT IF(AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = AccountID),Borrower(AccountID))) AS 'Account Name',"
        SQL &= "    GROUP_CONCAT(AccountNo) AS 'Account No',"
        SQL &= "    AssetNumber AS 'Asset Number',"
        SQL &= "    TCT AS 'TCT Number',"
        SQL &= "    Location,"
        SQL &= "    `Area` AS 'Area',"
        SQL &= "    Classification,"
        SQL &= "    Price, BalanceTransferred AS 'Balance Transferred', "
        SQL &= "    VacantLot AS 'Vacant Lot',"
        SQL &= "    Storey AS 'Storeys',"
        SQL &= "    Roofings,"
        SQL &= "    Flooring AS 'Floorings',"
        SQL &= "    TandB AS 'T and B',"
        SQL &= "    Frame,"
        SQL &= "    Beams,"
        SQL &= "    Doors,"
        SQL &= "    YearConstructed AS 'Yr Constructed',"
        SQL &= "    Walling AS 'Wallings',"
        SQL &= "    `Ceiling` AS 'Ceilings',"
        SQL &= "    Windows,"
        SQL &= "    FloorArea AS 'Floor Area',"
        SQL &= "    `Partitions`,"
        SQL &= "    Remarks,"
        SQL &= "    Img,"
        SQL &= "    Attach,"
        SQL &= "    `reserve_reason` AS 'Reserved Reason', Coordinates,"
        SQL &= "    branch_code, account_count, Bank, BankID, Publish"
        SQL &= String.Format(" FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND sell_status = 'RECLASSIFIED' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= " GROUP BY TCT, Sell_Status, AccountID ORDER BY trans_date DESC"
        GridControl4.DataSource = DataSource(SQL)
        GridView4.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView4.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView4.RowCount > 22 Then
            GridColumn118.Width = 269 - 17
        Else
            GridColumn118.Width = 269
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
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCoordinates.Focus()
        End If
    End Sub

    Private Sub TxtCoordinates_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCoordinates.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTCT.Focus()
        End If
    End Sub

    Private Sub TxtTCT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTCT.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLocation.Focus()
        End If
    End Sub

    Private Sub TxtLocation_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLocation.KeyDown
        If e.KeyCode = Keys.Enter Then
            dArea.Focus()
        End If
    End Sub

    Private Sub DArea_KeyDown(sender As Object, e As KeyEventArgs) Handles dArea.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxResidential.Focus()
        End If
    End Sub

    Private Sub CbxResidential_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxResidential.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCommercial.Focus()
        End If
    End Sub

    Private Sub CbxCommercial_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCommercial.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgricultural.Focus()
        End If
    End Sub

    Private Sub CbxAgricultural_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgricultural.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTourism.Focus()
        End If
    End Sub

    Private Sub CbxTourism_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTourism.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxIndustrial.Focus()
        End If
    End Sub

    Private Sub CbxIndustrial_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxIndustrial.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCondominium.Focus()
        End If
    End Sub

    Private Sub CbxCondominium_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCondominium.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOthers.Focus()
        End If
    End Sub

    Private Sub CbxOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOthers.Focus()
        End If
    End Sub

    Private Sub TxtOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dPrice.Visible Then
                dPrice.Focus()
            Else
                cbxVacant.Focus()
            End If
        End If
    End Sub

    Private Sub DPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles dPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalanceTransferred.Focus()
        End If
    End Sub

    Private Sub DBalanceTransferred_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalanceTransferred.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxVacant.Focus()
        End If
    End Sub

    Private Sub CbxVacant_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxVacant.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxVacant.Checked Then
                btnAddImage.Focus()
            Else
                txtStorey.Focus()
            End If
        End If
    End Sub

    Private Sub TxtStorey_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStorey.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRoofings.Focus()
        End If
    End Sub

    Private Sub TxtRoofings_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoofings.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFlooring.Focus()
        End If
    End Sub

    Private Sub TxtFlooring_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFlooring.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTandB.Focus()
        End If
    End Sub

    Private Sub TxtTandB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTandB.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFrame.Focus()
        End If
    End Sub

    Private Sub TxtFrame_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFrame.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBeams.Focus()
        End If
    End Sub

    Private Sub TxtBeams_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBeams.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDoors.Focus()
        End If
    End Sub

    Private Sub TxtDoors_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDoors.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtYearConstructed.Focus()
        End If
    End Sub

    Private Sub TxtYearConstructed_KeyDown(sender As Object, e As KeyEventArgs) Handles txtYearConstructed.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWalling.Focus()
        End If
    End Sub

    Private Sub TxtWalling_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWalling.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCeilings.Focus()
        End If
    End Sub

    Private Sub TxtCeilings_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCeilings.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWindows.Focus()
        End If
    End Sub

    Private Sub TxtWindows_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWindows.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFloorArea.Focus()
        End If
    End Sub

    Private Sub TxtFloorArea_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFloorArea.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPartitions.Focus()
        End If
    End Sub

    Private Sub TxtPartitions_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPartitions.KeyDown
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
        txtKeyword.Text = ReplaceText(txtKeyword.Text)
    End Sub

    Private Sub TxtCoordinates_Leave(sender As Object, e As EventArgs) Handles txtCoordinates.Leave
        'txtCoordinates.Text = ReplaceText(txtCoordinates.Text)
        'If txtCoordinates.Text = "" Then
        'Else
        '    If txtCoordinates.Text.Contains(",") = False Or txtCoordinates.Text.Trim.Length < 3 Or ContainsAlphabet(txtCoordinates.Text) Or ContainsSpecial(txtCoordinates.Text) Then
        '        MsgBox("Please fill a valid coordinates with Latitude and Longitude values.", MsgBoxStyle.Information, "Info")
        '        txtCoordinates.Focus()
        '    End If
        'End If
    End Sub

    Private Sub TxtTCT_Leave(sender As Object, e As EventArgs) Handles txtTCT.Leave
        txtTCT.Text = ReplaceText(txtTCT.Text)
    End Sub

    Private Sub TxtAccountNo_Leave(sender As Object, e As EventArgs) Handles txtAccountNo.Leave
        txtAccountNo.Text = ReplaceText(txtAccountNo.Text)
    End Sub

    Private Sub TxtLocation_Leave(sender As Object, e As EventArgs) Handles txtLocation.Leave
        txtLocation.Text = ReplaceText(txtLocation.Text)
    End Sub

    Private Sub TxtStorey_Leave(sender As Object, e As EventArgs) Handles txtStorey.Leave
        txtStorey.Text = ReplaceText(txtStorey.Text.Trim)
    End Sub

    Private Sub TxtRoofings_Leave(sender As Object, e As EventArgs) Handles txtRoofings.Leave
        txtRoofings.Text = ReplaceText(txtRoofings.Text.Trim)
    End Sub

    Private Sub TxtFlooring_Leave(sender As Object, e As EventArgs) Handles txtFlooring.Leave
        txtFlooring.Text = ReplaceText(txtFlooring.Text.Trim)
    End Sub

    Private Sub TxtTandB_Leave(sender As Object, e As EventArgs) Handles txtTandB.Leave
        txtTandB.Text = ReplaceText(txtTandB.Text.Trim)
    End Sub

    Private Sub TxtFrame_Leave(sender As Object, e As EventArgs) Handles txtFrame.Leave
        txtFrame.Text = ReplaceText(txtFrame.Text.Trim)
    End Sub

    Private Sub TxtBeams_Leave(sender As Object, e As EventArgs) Handles txtBeams.Leave
        txtBeams.Text = ReplaceText(txtBeams.Text.Trim)
    End Sub

    Private Sub TxtDoors_Leave(sender As Object, e As EventArgs) Handles txtDoors.Leave
        txtDoors.Text = ReplaceText(txtDoors.Text.Trim)
    End Sub

    Private Sub TxtYearConstructed_Leave(sender As Object, e As EventArgs) Handles txtYearConstructed.Leave
        txtYearConstructed.Text = ReplaceText(txtYearConstructed.Text.Trim)
    End Sub

    Private Sub TxtWalling_Leave(sender As Object, e As EventArgs) Handles txtWalling.Leave
        txtWalling.Text = ReplaceText(txtWalling.Text.Trim)
    End Sub

    Private Sub TxtCeilings_Leave(sender As Object, e As EventArgs) Handles txtCeilings.Leave
        txtCeilings.Text = ReplaceText(txtCeilings.Text.Trim)
    End Sub

    Private Sub TxtWindows_Leave(sender As Object, e As EventArgs) Handles txtWindows.Leave
        txtWindows.Text = ReplaceText(txtWindows.Text.Trim)
    End Sub

    Private Sub TxtFloorArea_Leave(sender As Object, e As EventArgs) Handles txtFloorArea.Leave
        txtFloorArea.Text = ReplaceText(txtFloorArea.Text.Trim)
    End Sub

    Private Sub TxtPartitions_Leave(sender As Object, e As EventArgs) Handles txtPartitions.Leave
        txtPartitions.Text = ReplaceText(txtPartitions.Text.Trim)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub
#End Region

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSold
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabReserve
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabReclassified
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabList
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabSold
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
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
            iDiscount.Visible = False
            iBuyer.Visible = False
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
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Then
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
            If SuperTabControl1.SelectedTabIndex = 3 Then
                iPDC.Visible = True
            Else
                iPDC.Visible = False
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnRepricing.Enabled = False

            If SuperTabControl1.SelectedTabIndex = 3 Then
                lblBlack.Text = ""
                lblRed.Text = "With Reservation Only"
                lblBlue.Text = "With Downpayment"
            Else
                lblBlack.Text = ""
                lblRed.Text = ""
                lblBlue.Text = ""
                iDiscount.Visible = False
            End If
            iBuyer.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
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
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            txtKeyword.Text = ""
            GridColumn33.Visible = True
            LoadData()
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            LoadSold()
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            LoadReserved()
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
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
        ReceivedCOS = Date.Now
        ReceivedCOS_Tag = Date.Now
        COS_Annotation = Date.Now
        COS_Annotation_Tag = Date.Now
        cbxRedemption.Checked = False
        btnRedemption.TextColor = Color.Black

        txtTCT.Text = Nothing
        txtLocation.Text = Nothing
        txtCoordinates.Text = Nothing
        dArea.Value = 0
        cbxResidential.Checked = False
        cbxCommercial.Checked = False
        cbxAgricultural.Checked = False
        cbxTourism.Checked = False
        cbxCondominium.Checked = False
        cbxOthers.Checked = False
        txtOthers.Enabled = False
        txtOthers.Text = ""
        dPrice.Value = 0
        dPrice.Enabled = True
        dBalanceTransferred.Value = 0
        dBalanceTransferred.Enabled = True
        cbxVacant.Checked = False
        txtRemarks.Text = Nothing

        txtRemarks.Text = ""
        btnPurchase.Enabled = False
        btnHistory.Enabled = False
        btnReserve.Enabled = False
        btnReclassify.Enabled = False
        btnAppraise.Enabled = False
        btnMultipleA.Enabled = False
        PanelEx2.Enabled = True
        lblSold.Visible = False

        LoadImage()
        AddImage = False
        TotalImage = 5
        TotalImage_F = TotalImage

        LabelX5.Visible = True
        dPrice.Visible = True
        LabelX6.Visible = True
        dBalanceTransferred.Visible = True
        GridColumn7.Visible = True
        GridColumn42.Visible = True
        GridColumn89.Visible = True
        GridColumn121.Visible = True
        HidePrice = False

        PanelEx4.Enabled = True
        cbxNature.Enabled = True
        cbxAccountName.Enabled = True
        txtAccountNo.Enabled = True
        txtTCT.Enabled = True
        txtLocation.Enabled = True
        dArea.Enabled = True
        cbxResidential.Enabled = True
        cbxCommercial.Enabled = True
        cbxAgricultural.Enabled = True
        cbxTourism.Enabled = True
        cbxIndustrial.Enabled = True
        cbxOthers.Enabled = True
        dPrice.Enabled = True
        cbxVacant.Enabled = True
        txtStorey.Enabled = True
        txtRoofings.Enabled = True
        txtFlooring.Enabled = True
        txtTandB.Enabled = True
        txtFrame.Enabled = True
        txtBeams.Enabled = True
        txtDoors.Enabled = True
        txtYearConstructed.Enabled = True
        txtWalling.Enabled = True
        txtCeilings.Enabled = True
        txtWindows.Enabled = True
        txtFloorArea.Enabled = True
        txtPartitions.Enabled = True
        txtRemarks.Enabled = True

        txtStorey.Text = ""
        txtRoofings.Text = ""
        txtFlooring.Text = ""
        txtTandB.Text = ""
        txtFrame.Text = ""
        txtBeams.Text = ""
        txtDoors.Text = ""
        txtYearConstructed.Text = ""
        txtWalling.Text = ""
        txtCeilings.Text = ""
        txtWindows.Text = ""
        txtFloorArea.Text = ""
        txtPartitions.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub CbxResidential_CheckedChanged(sender As Object, e As EventArgs) Handles cbxResidential.CheckedChanged
        If cbxResidential.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxResidential.Text))
            txtOthers.Enabled = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxCommercial_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCommercial.CheckedChanged
        If cbxCommercial.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxCommercial.Text))
            txtOthers.Enabled = False
            cbxResidential.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxAgricultural_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgricultural.CheckedChanged
        If cbxAgricultural.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxAgricultural.Text))
            txtOthers.Enabled = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxTourism_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTourism.CheckedChanged
        If cbxTourism.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxTourism.Text))
            txtOthers.Enabled = False
            cbxAgricultural.Checked = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxIndustrial_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIndustrial.CheckedChanged
        If cbxIndustrial.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxIndustrial.Text))
            txtOthers.Enabled = False
            cbxAgricultural.Checked = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxTourism.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxCondominium_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCondominium.CheckedChanged
        If cbxCondominium.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxCondominium.Text))
            txtOthers.Enabled = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxOthers.Checked = False

            LoadImage()
        End If
    End Sub

    Private Sub CbxOthers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOthers.CheckedChanged
        If cbxOthers.Checked Then
            DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", cbxOthers.Text))
            txtOthers.Enabled = True
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxCondominium.Checked = False
            cbxIndustrial.Checked = False

            LoadImage()
        End If
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
        If dtpDate.Value = "1/1/1753" Then
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
        If txtTCT.Text = "" Then
            MsgBox("Please fill TCT field.", MsgBoxStyle.Information, "Info")
            txtTCT.Focus()
            Exit Sub
        End If
        If txtLocation.Text = "" Then
            MsgBox("Please fill Location field.", MsgBoxStyle.Information, "Info")
            txtLocation.Focus()
            Exit Sub
        End If
        If dArea.Value = 0 Then
            MsgBox("Please fill Area field.", MsgBoxStyle.Information, "Info")
            dArea.Focus()
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

        Dim Classification As String = ""
        If cbxResidential.Checked Then
            Classification = "Residential"
        ElseIf cbxCommercial.Checked Then
            Classification = "Commercial"
        ElseIf cbxAgricultural.Checked Then
            Classification = "Agricultural"
        ElseIf cbxTourism.Checked Then
            Classification = "Tourism"
        ElseIf cbxIndustrial.Checked Then
            Classification = "Industrial"
        ElseIf cbxCondominium.Checked Then
            Classification = "Condominium"
        ElseIf cbxOthers.Checked Then
            Classification = txtOthers.Text
        End If
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                If MultipleA = False Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_realestate WHERE TCT = '{0}' AND (`status` = 'ACTIVE' OR `status` = 'PENDING') AND sell_status != 'SOLD'", txtTCT.Text))
                    If Exist > 0 Then
                        MsgBox(String.Format("TCT Number {0} already exist, Please check your data.", txtTCT.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                Cursor = Cursors.WaitCursor
                GetROPOA()

                Dim SQL As String = "INSERT INTO ropoa_realestate SET"
                SQL &= String.Format(" Nature = '{0}', ", cbxNature.Text)
                SQL &= String.Format(" Publish = '{0}', ", If(cbxPublish.Checked, 1, 0))
                SQL &= String.Format(" AccountID = '{0}', ", cbxAccountName.SelectedValue)
                SQL &= String.Format(" AccountNo = '{0}', ", txtAccountNo.Text)
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                If cbxRedemption.Checked Then
                    SQL &= String.Format(" COS_Received = '{0}', ", Format(ReceivedCOS, "yyyy-MM-dd"))
                    SQL &= String.Format(" COS_Annotation = '{0}', ", Format(COS_Annotation, "yyyy-MM-dd"))
                End If
                SQL &= String.Format(" AssetNumber = '{0}', ", txtAssetNumber.Text)
                SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                SQL &= String.Format(" Location = '{0}', ", txtLocation.Text)
                SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                SQL &= String.Format(" `Area` = '{0}', ", dArea.Value)
                SQL &= String.Format(" Classification = '{0}', ", Classification)
                SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
                SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
                SQL &= String.Format(" VacantLot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                SQL &= String.Format(" Storey = '{0}', ", txtStorey.Text)
                SQL &= String.Format(" Roofings = '{0}', ", txtRoofings.Text)
                SQL &= String.Format(" Flooring = '{0}', ", txtFlooring.Text)
                SQL &= String.Format(" TandB = '{0}', ", txtTandB.Text)
                SQL &= String.Format(" Frame = '{0}', ", txtFrame.Text)
                SQL &= String.Format(" Beams = '{0}', ", txtBeams.Text)
                SQL &= String.Format(" Doors = '{0}', ", txtDoors.Text)
                SQL &= String.Format(" YearConstructed = '{0}', ", txtYearConstructed.Text)
                SQL &= String.Format(" Walling = '{0}', ", txtWalling.Text)
                SQL &= String.Format(" `Ceiling` = '{0}', ", txtCeilings.Text)
                SQL &= String.Format(" Windows = '{0}', ", txtWindows.Text)
                SQL &= String.Format(" FloorArea = '{0}', ", txtFloorArea.Text)
                SQL &= String.Format(" `Partitions` = '{0}', ", txtPartitions.Text)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" Bank = '{0}', ", Bank)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Img = '{0}', ", TotalImage)
                If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                Else
                    If MultipleA Then
                        SQL &= String.Format(" `status` = '{0}', ", DataSource(String.Format("SELECT `status` FROM ropoa_realestate WHERE TCT = '{0}' AND (`status` = 'ACTIVE' OR `status` = 'PENDING') LIMIT 1;", txtTCT.Text)))
                    Else
                        SQL &= " `status` = 'PENDING', "
                    End If
                End If
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
                    SQL &= " AccountCode = '126001X', "
                    SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126001")))
                    If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                        SQL &= " PostStatus = 'POSTED', "
                    End If
                    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                    SQL &= String.Format(" ReferenceN = '{0}', ", txtAssetNumber.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" CVNumber = '{0}', ", txtTCT.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    'ACCOUNTING ENTRY *******************************************************************************************************
                End If
                DataObject(SQL)
                For x As Integer = 1 To TotalImage
                    Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                    If x > 5 Then
                        If pb.Image Is Nothing Then
                        Else
                            ResizeImages(pb.Image.Clone, pb, 850, 700)
                            SaveImage(pb, "Image" & x)
                        End If
                    Else
                        If pb.Image Is Nothing Then
                        Else
                            SaveImage(pb, pb.Properties.NullText & x)
                        End If
                    End If
                Next

                If MultipleA Then
                    DataObject(String.Format("UPDATE ropoa_realestate SET account_count = account_count + 1 WHERE TCT = '{0}'", txtTCT.Text))
                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber FROM ropoa_realestate WHERE TCT = '{0}' AND `status` = 'ACTIVE'", txtTCT.Text))
                    For x As Integer = 0 To DT.Rows.Count - 1
                        DataObject(String.Format("UPDATE ledger_ropoa SET ropoa_ref = '{0}' WHERE asset_number = '{1}'", txtTCT.Text, DT(x)("AssetNumber")))
                    Next
                End If
                Logs("ROPOA Real Estate", "Save", String.Format("Add new ROPOA Real Estate {0}", txtAssetNumber.Text), "", "", "", "")
                Clear()
                LoadData()
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                If MultipleA = False Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_realestate WHERE TCT = '{0}' AND (`status` = 'ACTIVE' OR `status` = 'PENDING') AND AssetNumber != '{1}' AND sell_status != 'SOLD'", txtTCT.Text, txtAssetNumber.Text))
                    If Exist > 0 Then
                        MsgBox(String.Format("TCT Number {0} already exist, Please check your data.", txtTCT.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE ropoa_realestate SET"
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
                If cbxRedemption.Checked Then
                    SQL &= String.Format(" COS_Received = '{0}', ", Format(ReceivedCOS, "yyyy-MM-dd"))
                    SQL &= String.Format(" COS_Annotation = '{0}', ", Format(COS_Annotation, "yyyy-MM-dd"))
                Else
                    SQL &= " COS_Received = '', "
                    SQL &= " COS_Annotation = '', "
                End If
                SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                SQL &= String.Format(" Location = '{0}', ", txtLocation.Text)
                SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                SQL &= String.Format(" `Area` = '{0}', ", dArea.Value)
                SQL &= String.Format(" Classification = '{0}', ", Classification)
                SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
                SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
                SQL &= String.Format(" VacantLot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                SQL &= String.Format(" Storey = '{0}', ", txtStorey.Text)
                SQL &= String.Format(" Roofings = '{0}', ", txtRoofings.Text)
                SQL &= String.Format(" Flooring = '{0}', ", txtFlooring.Text)
                SQL &= String.Format(" TandB = '{0}', ", txtTandB.Text)
                SQL &= String.Format(" Frame = '{0}', ", txtFrame.Text)
                SQL &= String.Format(" Beams = '{0}', ", txtBeams.Text)
                SQL &= String.Format(" Doors = '{0}', ", txtDoors.Text)
                SQL &= String.Format(" YearConstructed = '{0}', ", txtYearConstructed.Text)
                SQL &= String.Format(" Walling = '{0}', ", txtWalling.Text)
                SQL &= String.Format(" `Ceiling` = '{0}', ", txtCeilings.Text)
                SQL &= String.Format(" Windows = '{0}', ", txtWindows.Text)
                SQL &= String.Format(" FloorArea = '{0}', ", txtFloorArea.Text)
                SQL &= String.Format(" `Partitions` = '{0}', ", txtPartitions.Text)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" Bank = '{0}', ", Bank)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Img = '{0}' ", TotalImage)
                If MultipleA Then
                    SQL &= String.Format(" WHERE TCT = '{0}'", txtTCT.Text)
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
                    If x > 5 Then
                        If pb.Image Is Nothing Then
                        Else
                            ResizeImages(pb.Image.Clone, pb, 850, 700)
                            SaveImage(pb, "Image" & x)
                        End If
                    Else
                        If pb.Image Is Nothing Then
                        Else
                            SaveImage(pb, pb.Properties.NullText & x)
                        End If
                    End If
                Next
                If TotalImage < GridView2.GetFocusedRowCellValue("Img") Then
                    For x As Integer = TotalImage + 1 To GridView2.GetFocusedRowCellValue("Img")
                        Dim xPath As String
                        FileName = "Image" & x & ".jpg"
                        xPath = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, txtAssetNumber.Text, FileName)
                        If IO.File.Exists(xPath) Then
                            IO.File.Delete(xPath)
                        End If
                    Next
                End If

                Logs("ROPOA Real Estate", "Update", String.Format("Update ROPOA Real Estate {0}", txtAssetNumber.Text), Changes, "", "", "")
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
            If Format(dtpDate.Value, "MMM.dd.yyyy") = dtpDate.Tag Then
            Else
                Change &= String.Format("Change ROPOA Date from {0} to {1}. ", dtpDate.Tag, Format(dtpDate.Value, "MMM.dd.yyyy"))
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
            If Format(ReceivedCOS, "yyyy-MM-dd") = Format(ReceivedCOS_Tag, "yyyy-MM-dd") Then
            Else
                Change &= String.Format("Change Received COS Date from {0} to {1}. ", Format(ReceivedCOS_Tag, "yyyy-MM-dd"), Format(ReceivedCOS, "yyyy-MM-dd"))
            End If
            If Format(COS_Annotation, "yyyy-MM-dd") = Format(COS_Annotation_Tag, "yyyy-MM-dd") Then
            Else
                Change &= String.Format("Change COS Annotation Date from {0} to {1}. ", Format(COS_Annotation_Tag, "yyyy-MM-dd"), Format(COS_Annotation, "yyyy-MM-dd"))
            End If
            If txtTCT.Text = txtTCT.Tag Then
            Else
                Change &= String.Format("Change TCT from {0} to {1}. ", txtTCT.Tag, txtTCT.Text)
            End If
            If txtLocation.Text = txtLocation.Tag Then
            Else
                Change &= String.Format("Change Location from {0} to {1}. ", txtLocation.Tag, txtLocation.Text)
            End If
            If txtCoordinates.Text = txtCoordinates.Tag Then
            Else
                Change &= String.Format("Change Coordinates from {0} to {1}. ", txtCoordinates.Tag, txtCoordinates.Text)
            End If
            If dArea.Value = dArea.Tag Then
            Else
                Change &= String.Format("Change Area from {0} to {1}. ", dArea.Tag, dArea.Text)
            End If
            If cbxResidential.Tag <> "Residential" And cbxResidential.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxResidential.Tag, cbxResidential.Text)
            ElseIf cbxCommercial.Tag <> "Commercial" And cbxCommercial.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxCommercial.Tag, cbxCommercial.Text)
            ElseIf cbxAgricultural.Tag <> "Agricultural" And cbxAgricultural.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxAgricultural.Tag, cbxAgricultural.Text)
            ElseIf cbxTourism.Tag <> "Tourism" And cbxTourism.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxTourism.Tag, cbxTourism.Text)
            ElseIf cbxIndustrial.Tag <> "Industrial" And cbxIndustrial.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxIndustrial.Tag, cbxIndustrial.Text)
            ElseIf cbxCondominium.Tag <> "Condominium" And cbxCondominium.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxCondominium.Tag, cbxCondominium.Text)
            ElseIf cbxOthers.Tag <> "Others" And cbxOthers.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxOthers.Tag, txtOthers.Text)
            End If
            If dPrice.Value = dPrice.Tag Then
            Else
                Change &= String.Format("Change Price from {0} to {1}. ", dPrice.Tag, dPrice.Text)
            End If
            If If(cbxVacant.Checked, "YES", "NO") = cbxVacant.Tag Then
            Else
                Change &= String.Format("Change Vacant Lot from {0} to {1}. ", cbxVacant.Tag, If(cbxVacant.Checked, "YES", "NO"))
            End If
            If txtStorey.Text = txtStorey.Tag Then
            Else
                Change &= String.Format("Change Storey from {0} to {1}. ", txtStorey.Tag, txtStorey.Text)
            End If
            If txtRoofings.Text = txtRoofings.Tag Then
            Else
                Change &= String.Format("Change Roofing from {0} to {1}. ", txtRoofings.Tag, txtRoofings.Text)
            End If
            If txtFlooring.Text = txtFlooring.Tag Then
            Else
                Change &= String.Format("Change Flooring from {0} to {1}. ", txtFlooring.Tag, txtFlooring.Text)
            End If
            If txtTandB.Text = txtTandB.Tag Then
            Else
                Change &= String.Format("Change T and B from {0} to {1}. ", txtTandB.Tag, txtTandB.Text)
            End If
            If txtFrame.Text = txtFrame.Tag Then
            Else
                Change &= String.Format("Change Frame from {0} to {1}. ", txtFrame.Tag, txtFrame.Text)
            End If
            If txtBeams.Text = txtBeams.Tag Then
            Else
                Change &= String.Format("Change Beam from {0} to {1}. ", txtBeams.Tag, txtBeams.Text)
            End If
            If txtDoors.Text = txtDoors.Tag Then
            Else
                Change &= String.Format("Change Door from {0} to {1}. ", txtDoors.Tag, txtDoors.Text)
            End If
            If txtYearConstructed.Text.Trim = txtYearConstructed.Tag Then
            Else
                Change &= String.Format("Change Year Constructed from {0} to {1}. ", txtYearConstructed.Tag, txtYearConstructed.Text.Trim)
            End If
            If txtWalling.Text = txtWalling.Tag Then
            Else
                Change &= String.Format("Change Walling from {0} to {1}. ", txtWalling.Tag, txtWalling.Text)
            End If
            If txtCeilings.Text = txtCeilings.Tag Then
            Else
                Change &= String.Format("Change Ceiling from {0} to {1}. ", txtCeilings.Tag, txtCeilings.Text)
            End If
            If txtWindows.Text = txtWindows.Tag Then
            Else
                Change &= String.Format("Change Window from {0} to {1}. ", txtWindows.Tag, txtWindows.Text)
            End If
            If txtFloorArea.Text = txtFloorArea.Tag Then
            Else
                Change &= String.Format("Change Floor from {0} to {1}. ", txtFloorArea.Tag, txtFloorArea.Text)
            End If
            If txtPartitions.Text = txtPartitions.Tag Then
            Else
                Change &= String.Format("Change Partition from {0} to {1}. ", txtPartitions.Tag, txtPartitions.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
            If GridView2.GetFocusedRowCellValue("Img") <> TotalImage Then
                Change &= String.Format("Change Image(s) from {0} to {1}. ", GridView2.GetFocusedRowCellValue("Img"), TotalImage)
            ElseIf AddImage Then
                Change &= "Change Image(s). "
            End If
        Catch ex As Exception
            TriggerBugReport("Real Estate ROPA - Changes", ex.Message.ToString)
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
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            Dim Creator_Draft As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM ropoa_realestate WHERE `status` = 'PENDING' AND user_code = '{0}' AND AssetNumber = '{1}';", User_Code, txtAssetNumber.Text))
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
                DataObject(String.Format("UPDATE ropoa_realestate SET `status` = 'DELETED' WHERE TCT = '{0}';", txtTCT.Text))
            Else
                DataObject(String.Format("UPDATE ropoa_realestate SET `status` = 'DELETED' WHERE AssetNumber = '{0}';", txtAssetNumber.Text))
            End If
            Logs("ROPOA Real Estate", "Cancel", Reason, String.Format("Cancel ROPOA Real Estate with Asset Number {0}", txtAssetNumber.Text), "", "", "")
            LoadData()
            Clear()
            FrmMain.RealEstateCount = FrmMain.RealEstateCount - 1
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
            Dim Report As New RptRealEstateROPOA
            With Report
                .lblSOLD.Visible = False
                Dim xPos As Integer = 1
                DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", GridView2.GetFocusedRowCellValue("Classification")))

                Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code"), GridView2.GetFocusedRowCellValue("Asset Number"))
                If IO.Directory.Exists(PathX) Then
                    Dim files() As String = IO.Directory.GetFiles(PathX)
                    For Each file As String In files
                        Dim pB As New XRPictureBox With {
                            .Size = New Size(375, 235),
                            .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                            .Borders = DevExpress.XtraPrinting.BorderSide.All
                        }
                        '***ADD LABEL***'
                        Dim lblImage As New XRLabel With {
                            .SizeF = New Size(375, 10),
                            .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        }
                        '***ADD LABEL***'
                        If xPos Mod 2 = 0 Then
                            pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                            lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                        Else
                            pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                            lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                        End If
                        Dim FileN As String = ""

                        .Detail.Controls.Add(pB)
                        .Detail.Controls.Add(lblImage)
                        xPos += 1
                    Next
                End If
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView2.RowCount > 0 Then
                Try
                    If GridView2.GetFocusedRowCellValue("ID").ToString = "" Or GridView2.RowCount = 0 Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptRealEstateROPOA
                With Report
                    .Name = GridView2.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView2.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView2.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Visible = False
                    .lblTCT.Text = GridView2.GetFocusedRowCellValue("TCT Number")
                    .lblLocation.Text = GridView2.GetFocusedRowCellValue("Location")
                    .lblArea.Text = GridView2.GetFocusedRowCellValue("Area")
                    If GridView2.GetFocusedRowCellValue("Classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblPrice.Text = ""
                    .XrLabel7.Text = ""
                    If GridView2.GetFocusedRowCellValue("Vacant Lot") = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel10.BackColor = Color.WhiteSmoke
                        .XrLabel19.BackColor = Color.WhiteSmoke
                        .XrLabel29.BackColor = Color.WhiteSmoke
                        .XrLabel35.BackColor = Color.WhiteSmoke
                        .XrLabel13.BackColor = Color.WhiteSmoke
                        .XrLabel21.BackColor = Color.WhiteSmoke
                        .XrLabel27.BackColor = Color.WhiteSmoke
                        .XrLabel15.BackColor = Color.WhiteSmoke
                        .XrLabel23.BackColor = Color.WhiteSmoke
                        .XrLabel33.BackColor = Color.WhiteSmoke
                        .XrLabel17.BackColor = Color.WhiteSmoke
                        .XrLabel25.BackColor = Color.WhiteSmoke
                        .XrLabel31.BackColor = Color.WhiteSmoke

                        .lblStorey.BackColor = Color.WhiteSmoke
                        .lblRoofings.BackColor = Color.WhiteSmoke
                        .lblFloorings.BackColor = Color.WhiteSmoke
                        .lblTandB.BackColor = Color.WhiteSmoke
                        .lblFrames.BackColor = Color.WhiteSmoke
                        .lblBeams.BackColor = Color.WhiteSmoke
                        .lblDoors.BackColor = Color.WhiteSmoke
                        .lblYear.BackColor = Color.WhiteSmoke
                        .lblWalling.BackColor = Color.WhiteSmoke
                        .lblCeiling.BackColor = Color.WhiteSmoke
                        .lblWindows.BackColor = Color.WhiteSmoke
                        .lblFloorArea.BackColor = Color.WhiteSmoke
                        .lblPartitions.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                        .lblStorey.Text = GridView2.GetFocusedRowCellValue("Storeys")
                        .lblRoofings.Text = GridView2.GetFocusedRowCellValue("Roofings")
                        .lblFloorings.Text = GridView2.GetFocusedRowCellValue("Floorings")
                        .lblTandB.Text = GridView2.GetFocusedRowCellValue("T and B")
                        .lblFrames.Text = GridView2.GetFocusedRowCellValue("Frame")
                        .lblBeams.Text = GridView2.GetFocusedRowCellValue("Beams")
                        .lblDoors.Text = GridView2.GetFocusedRowCellValue("Doors")
                        .lblYear.Text = GridView2.GetFocusedRowCellValue("Yr Constructed")
                        .lblWalling.Text = GridView2.GetFocusedRowCellValue("Wallings")
                        .lblCeiling.Text = GridView2.GetFocusedRowCellValue("Ceilings")
                        .lblWindows.Text = GridView2.GetFocusedRowCellValue("Windows")
                        .lblFloorArea.Text = GridView2.GetFocusedRowCellValue("Floor Area")
                        .lblPartitions.Text = GridView2.GetFocusedRowCellValue("Partitions")
                    End If
                    If GridColumn33.Visible Then
                        .lblRemarks.Text = GridView2.GetFocusedRowCellValue("Remarks")
                    Else
                        .XrLabel37.Text = ""
                    End If

                    Dim xPos As Integer = 1
                    If GridView2.GetFocusedRowCellValue("Img") > 0 Then
                        DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", GridView2.GetFocusedRowCellValue("Classification")))
                        Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code"), GridView2.GetFocusedRowCellValue("Asset Number"))
                        If IO.Directory.Exists(PathX) Then
                            Dim files() As String = IO.Directory.GetFiles(PathX)
                            For Each file As String In files
                                Dim pB As New XRPictureBox With {
                                    .Size = New Size(375, 235),
                                    .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                    .Borders = DevExpress.XtraPrinting.BorderSide.All
                                }
                                '***ADD LABEL***'
                                Dim lblImage As New XRLabel With {
                                    .SizeF = New Size(375, 10),
                                    .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                                }
                                '***ADD LABEL***'
                                If xPos Mod 2 = 0 Then
                                    pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                Else
                                    pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                End If
                                Dim Path As String = file.ToString
                                If IO.File.Exists(Path) Then
                                    Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                    Try
                                        TempPB.Image = Image.FromFile(Path)
                                    Catch ex As Exception
                                        TriggerBugReport("Real Estate ROPOA- Print", ex.Message.ToString)
                                    End Try
                                    pB.Image = TempPB.Image.Clone
                                    TempPB.Dispose()
                                    .Detail.Controls.Add(pB)
                                    .Detail.Controls.Add(lblImage)
                                    xPos += 1
                                End If
                            Next
                        Else
                        End If
                    Else
                    End If
                    Logs("Real Estate ROPOA", "Print", String.Format("Print Real Estate ROPOA with Asset Number {0}", GridView2.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
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

                Dim Report As New RptRealEstateSold
                With Report
                    .Name = GridView3.GetFocusedRowCellValue("Asset Number") & "-SOLD"
                    .lblDate.Text = GridView3.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView3.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Visible = True
                    .lblTCT.Text = GridView3.GetFocusedRowCellValue("TCT Number")
                    .lblLocation.Text = GridView3.GetFocusedRowCellValue("Location")
                    .lblArea.Text = GridView3.GetFocusedRowCellValue("Area")
                    If GridView3.GetFocusedRowCellValue("Classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblPrice.Text = ""
                    .XrLabel7.Text = ""
                    If GridView3.GetFocusedRowCellValue("Vacant Lot") = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel10.BackColor = Color.WhiteSmoke
                        .XrLabel19.BackColor = Color.WhiteSmoke
                        .XrLabel29.BackColor = Color.WhiteSmoke
                        .XrLabel35.BackColor = Color.WhiteSmoke
                        .XrLabel13.BackColor = Color.WhiteSmoke
                        .XrLabel21.BackColor = Color.WhiteSmoke
                        .XrLabel27.BackColor = Color.WhiteSmoke
                        .XrLabel15.BackColor = Color.WhiteSmoke
                        .XrLabel23.BackColor = Color.WhiteSmoke
                        .XrLabel33.BackColor = Color.WhiteSmoke
                        .XrLabel17.BackColor = Color.WhiteSmoke
                        .XrLabel25.BackColor = Color.WhiteSmoke
                        .XrLabel31.BackColor = Color.WhiteSmoke

                        .lblStorey.BackColor = Color.WhiteSmoke
                        .lblRoofings.BackColor = Color.WhiteSmoke
                        .lblFloorings.BackColor = Color.WhiteSmoke
                        .lblTandB.BackColor = Color.WhiteSmoke
                        .lblFrames.BackColor = Color.WhiteSmoke
                        .lblBeams.BackColor = Color.WhiteSmoke
                        .lblDoors.BackColor = Color.WhiteSmoke
                        .lblYear.BackColor = Color.WhiteSmoke
                        .lblWalling.BackColor = Color.WhiteSmoke
                        .lblCeiling.BackColor = Color.WhiteSmoke
                        .lblWindows.BackColor = Color.WhiteSmoke
                        .lblFloorArea.BackColor = Color.WhiteSmoke
                        .lblPartitions.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                        .lblStorey.Text = GridView3.GetFocusedRowCellValue("Storeys")
                        .lblRoofings.Text = GridView3.GetFocusedRowCellValue("Roofings")
                        .lblFloorings.Text = GridView3.GetFocusedRowCellValue("Floorings")
                        .lblTandB.Text = GridView3.GetFocusedRowCellValue("T and B")
                        .lblFrames.Text = GridView3.GetFocusedRowCellValue("Frame")
                        .lblBeams.Text = GridView3.GetFocusedRowCellValue("Beams")
                        .lblDoors.Text = GridView3.GetFocusedRowCellValue("Doors")
                        .lblYear.Text = GridView3.GetFocusedRowCellValue("Yr Constructed")
                        .lblWalling.Text = GridView3.GetFocusedRowCellValue("Wallings")
                        .lblCeiling.Text = GridView3.GetFocusedRowCellValue("Ceilings")
                        .lblWindows.Text = GridView3.GetFocusedRowCellValue("Windows")
                        .lblFloorArea.Text = GridView3.GetFocusedRowCellValue("Floor Area")
                        .lblPartitions.Text = GridView3.GetFocusedRowCellValue("Partitions")
                    End If
                    .lblRemarks.Text = GridView3.GetFocusedRowCellValue("Remarks")
                    .lblBuyersName.Text = GridView3.GetFocusedRowCellValue("Buyer")
                    .lblAddress.Text = If(GridView3.GetFocusedRowCellValue("NoC_B") = "", "", GridView3.GetFocusedRowCellValue("NoC_B") & ", ") & If(GridView3.GetFocusedRowCellValue("StreetC_B") = "", "", GridView3.GetFocusedRowCellValue("StreetC_B") & ", ") & If(GridView3.GetFocusedRowCellValue("BarangayC_B") = "", "", GridView3.GetFocusedRowCellValue("BarangayC_B") & ", ") & GridView3.GetFocusedRowCellValue("AddressC_B")
                    .lblAmount.Text = GridView3.GetFocusedRowCellValue("Amount")

                    Dim xPos As Integer = 1
                    If GridView3.GetFocusedRowCellValue("Img") > 0 Then
                        DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", GridView3.GetFocusedRowCellValue("Classification")))
                        Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView3.GetFocusedRowCellValue("branch_code"), GridView3.GetFocusedRowCellValue("Asset Number"))
                        If IO.Directory.Exists(PathX) Then
                            Dim files() As String = IO.Directory.GetFiles(PathX)
                            For Each file As String In files
                                Dim pB As New XRPictureBox With {
                                    .Size = New Size(375, 235),
                                    .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                    .Borders = DevExpress.XtraPrinting.BorderSide.All
                                }
                                '***ADD LABEL***'
                                Dim lblImage As New XRLabel With {
                                    .SizeF = New Size(375, 10),
                                    .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                                }
                                '***ADD LABEL***'
                                If xPos Mod 2 = 0 Then
                                    pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                Else
                                    pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                End If
                                Dim Path As String = file.ToString
                                If IO.File.Exists(Path) Then
                                    Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                    Try
                                        TempPB.Image = Image.FromFile(Path)
                                    Catch ex As Exception
                                        TriggerBugReport("Real Estate ROPOA - Print", ex.Message.ToString)
                                    End Try
                                    pB.Image = TempPB.Image.Clone
                                    TempPB.Dispose()
                                    .Detail.Controls.Add(pB)
                                    .Detail.Controls.Add(lblImage)
                                    xPos += 1
                                End If
                            Next
                        Else
                        End If
                    Else
                    End If
                    Logs("Real Estate ROPOA", "Print", String.Format("Print Real Estate ROPOA with Asset Number {0}", GridView3.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView1.RowCount > 0 Then
                Try
                    If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptRealEstateROPOA
                With Report
                    .Name = GridView1.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView1.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView1.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = "RESERVED"
                    .lblTCT.Text = GridView1.GetFocusedRowCellValue("TCT Number")
                    .lblLocation.Text = GridView1.GetFocusedRowCellValue("Location")
                    .lblArea.Text = GridView1.GetFocusedRowCellValue("Area")
                    If GridView1.GetFocusedRowCellValue("Classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf GridView1.GetFocusedRowCellValue("Classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf GridView1.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf GridView1.GetFocusedRowCellValue("Classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf GridView1.GetFocusedRowCellValue("Classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf GridView1.GetFocusedRowCellValue("Classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblPrice.Text = ""
                    .XrLabel7.Text = ""
                    If GridView1.GetFocusedRowCellValue("Vacant Lot") = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel10.BackColor = Color.WhiteSmoke
                        .XrLabel19.BackColor = Color.WhiteSmoke
                        .XrLabel29.BackColor = Color.WhiteSmoke
                        .XrLabel35.BackColor = Color.WhiteSmoke
                        .XrLabel13.BackColor = Color.WhiteSmoke
                        .XrLabel21.BackColor = Color.WhiteSmoke
                        .XrLabel27.BackColor = Color.WhiteSmoke
                        .XrLabel15.BackColor = Color.WhiteSmoke
                        .XrLabel23.BackColor = Color.WhiteSmoke
                        .XrLabel33.BackColor = Color.WhiteSmoke
                        .XrLabel17.BackColor = Color.WhiteSmoke
                        .XrLabel25.BackColor = Color.WhiteSmoke
                        .XrLabel31.BackColor = Color.WhiteSmoke

                        .lblStorey.BackColor = Color.WhiteSmoke
                        .lblRoofings.BackColor = Color.WhiteSmoke
                        .lblFloorings.BackColor = Color.WhiteSmoke
                        .lblTandB.BackColor = Color.WhiteSmoke
                        .lblFrames.BackColor = Color.WhiteSmoke
                        .lblBeams.BackColor = Color.WhiteSmoke
                        .lblDoors.BackColor = Color.WhiteSmoke
                        .lblYear.BackColor = Color.WhiteSmoke
                        .lblWalling.BackColor = Color.WhiteSmoke
                        .lblCeiling.BackColor = Color.WhiteSmoke
                        .lblWindows.BackColor = Color.WhiteSmoke
                        .lblFloorArea.BackColor = Color.WhiteSmoke
                        .lblPartitions.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                        .lblStorey.Text = GridView1.GetFocusedRowCellValue("Storeys")
                        .lblRoofings.Text = GridView1.GetFocusedRowCellValue("Roofings")
                        .lblFloorings.Text = GridView1.GetFocusedRowCellValue("Floorings")
                        .lblTandB.Text = GridView1.GetFocusedRowCellValue("T and B")
                        .lblFrames.Text = GridView1.GetFocusedRowCellValue("Frame")
                        .lblBeams.Text = GridView1.GetFocusedRowCellValue("Beams")
                        .lblDoors.Text = GridView1.GetFocusedRowCellValue("Doors")
                        .lblYear.Text = GridView1.GetFocusedRowCellValue("Yr Constructed")
                        .lblWalling.Text = GridView1.GetFocusedRowCellValue("Wallings")
                        .lblCeiling.Text = GridView1.GetFocusedRowCellValue("Ceilings")
                        .lblWindows.Text = GridView1.GetFocusedRowCellValue("Windows")
                        .lblFloorArea.Text = GridView1.GetFocusedRowCellValue("Floor Area")
                        .lblPartitions.Text = GridView1.GetFocusedRowCellValue("Partitions")
                    End If
                    .lblRemarks.Text = GridView1.GetFocusedRowCellValue("Remarks")

                    Dim xPos As Integer = 1
                    If GridView1.GetFocusedRowCellValue("Img") > 0 Then
                        DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", GridView1.GetFocusedRowCellValue("Classification")))
                        Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView1.GetFocusedRowCellValue("branch_code"), GridView1.GetFocusedRowCellValue("Asset Number"))
                        If IO.Directory.Exists(PathX) Then
                            Dim files() As String = IO.Directory.GetFiles(PathX)
                            For Each file As String In files
                                Dim pB As New XRPictureBox With {
                                    .Size = New Size(375, 235),
                                    .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                    .Borders = DevExpress.XtraPrinting.BorderSide.All
                                }
                                '***ADD LABEL***'
                                Dim lblImage As New XRLabel With {
                                    .SizeF = New Size(375, 10),
                                    .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                                }
                                '***ADD LABEL***'
                                If xPos Mod 2 = 0 Then
                                    pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                Else
                                    pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                End If
                                Dim Path As String = file.ToString
                                If IO.File.Exists(Path) Then
                                    Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                    Try
                                        TempPB.Image = Image.FromFile(Path)
                                    Catch ex As Exception
                                        TriggerBugReport("Real Estate ROPA - Print", ex.Message.ToString)
                                    End Try
                                    pB.Image = TempPB.Image.Clone
                                    TempPB.Dispose()
                                    .Detail.Controls.Add(pB)
                                    .Detail.Controls.Add(lblImage)
                                    xPos += 1
                                End If
                            Next
                        Else
                        End If
                    Else
                    End If
                    Logs("Real Estate ROPOA", "Print", String.Format("Print Real Estate ROPOA with Asset Number {0}", GridView1.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView4.RowCount > 0 Then
                Try
                    If GridView4.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Report As New RptRealEstateROPOA
                With Report
                    .Name = GridView4.GetFocusedRowCellValue("Asset Number")
                    .lblDate.Text = GridView4.GetFocusedRowCellValue("Date")
                    .lblAssetNumber.Text = GridView4.GetFocusedRowCellValue("Asset Number")
                    .lblSOLD.Text = "RECLASSIFIED"
                    .lblTCT.Text = GridView4.GetFocusedRowCellValue("TCT Number")
                    .lblLocation.Text = GridView4.GetFocusedRowCellValue("Location")
                    .lblArea.Text = GridView4.GetFocusedRowCellValue("Area")
                    If GridView4.GetFocusedRowCellValue("Classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblPrice.Text = ""
                    .XrLabel7.Text = ""
                    If GridView4.GetFocusedRowCellValue("Vacant Lot") = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel10.BackColor = Color.WhiteSmoke
                        .XrLabel19.BackColor = Color.WhiteSmoke
                        .XrLabel29.BackColor = Color.WhiteSmoke
                        .XrLabel35.BackColor = Color.WhiteSmoke
                        .XrLabel13.BackColor = Color.WhiteSmoke
                        .XrLabel21.BackColor = Color.WhiteSmoke
                        .XrLabel27.BackColor = Color.WhiteSmoke
                        .XrLabel15.BackColor = Color.WhiteSmoke
                        .XrLabel23.BackColor = Color.WhiteSmoke
                        .XrLabel33.BackColor = Color.WhiteSmoke
                        .XrLabel17.BackColor = Color.WhiteSmoke
                        .XrLabel25.BackColor = Color.WhiteSmoke
                        .XrLabel31.BackColor = Color.WhiteSmoke

                        .lblStorey.BackColor = Color.WhiteSmoke
                        .lblRoofings.BackColor = Color.WhiteSmoke
                        .lblFloorings.BackColor = Color.WhiteSmoke
                        .lblTandB.BackColor = Color.WhiteSmoke
                        .lblFrames.BackColor = Color.WhiteSmoke
                        .lblBeams.BackColor = Color.WhiteSmoke
                        .lblDoors.BackColor = Color.WhiteSmoke
                        .lblYear.BackColor = Color.WhiteSmoke
                        .lblWalling.BackColor = Color.WhiteSmoke
                        .lblCeiling.BackColor = Color.WhiteSmoke
                        .lblWindows.BackColor = Color.WhiteSmoke
                        .lblFloorArea.BackColor = Color.WhiteSmoke
                        .lblPartitions.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                        .lblStorey.Text = GridView4.GetFocusedRowCellValue("Storeys")
                        .lblRoofings.Text = GridView4.GetFocusedRowCellValue("Roofings")
                        .lblFloorings.Text = GridView4.GetFocusedRowCellValue("Floorings")
                        .lblTandB.Text = GridView4.GetFocusedRowCellValue("T and B")
                        .lblFrames.Text = GridView4.GetFocusedRowCellValue("Frame")
                        .lblBeams.Text = GridView4.GetFocusedRowCellValue("Beams")
                        .lblDoors.Text = GridView4.GetFocusedRowCellValue("Doors")
                        .lblYear.Text = GridView4.GetFocusedRowCellValue("Yr Constructed")
                        .lblWalling.Text = GridView4.GetFocusedRowCellValue("Wallings")
                        .lblCeiling.Text = GridView4.GetFocusedRowCellValue("Ceilings")
                        .lblWindows.Text = GridView4.GetFocusedRowCellValue("Windows")
                        .lblFloorArea.Text = GridView4.GetFocusedRowCellValue("Floor Area")
                        .lblPartitions.Text = GridView4.GetFocusedRowCellValue("Partitions")
                    End If
                    .lblRemarks.Text = GridView4.GetFocusedRowCellValue("Remarks")

                    Dim xPos As Integer = 1
                    If GridView4.GetFocusedRowCellValue("Img") > 0 Then
                        DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", GridView4.GetFocusedRowCellValue("Classification")))
                        Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView4.GetFocusedRowCellValue("branch_code"), GridView4.GetFocusedRowCellValue("Asset Number"))
                        If IO.Directory.Exists(PathX) Then
                            Dim files() As String = IO.Directory.GetFiles(PathX)
                            For Each file As String In files
                                Dim pB As New XRPictureBox With {
                                    .Size = New Size(375, 235),
                                    .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                                    .Borders = DevExpress.XtraPrinting.BorderSide.All
                                }
                                '***ADD LABEL***'
                                Dim lblImage As New XRLabel With {
                                    .SizeF = New Size(375, 10),
                                    .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                    .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                                }
                                '***ADD LABEL***'
                                If xPos Mod 2 = 0 Then
                                    pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                Else
                                    pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                    lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                                End If
                                Dim Path As String = file.ToString
                                If IO.File.Exists(Path) Then
                                    Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                    Try
                                        TempPB.Image = Image.FromFile(Path)
                                    Catch ex As Exception
                                        TriggerBugReport("Real Estate ROPA - Print", ex.Message.ToString)
                                    End Try
                                    pB.Image = TempPB.Image.Clone
                                    TempPB.Dispose()
                                    .Detail.Controls.Add(pB)
                                    .Detail.Controls.Add(lblImage)
                                    xPos += 1
                                End If
                            Next
                        Else
                        End If
                    Else
                    End If
                    Logs("Real Estate ROPOA", "Print", String.Format("Print Real Estate ROPOA with Asset Number {0}", GridView4.GetFocusedRowCellValue("Asset Number")), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadImage()
        PanelEx4.Controls.Clear()
        TotalImage = 0
        For x As Integer = 1 To DT_Pictures.Rows.Count
            Dim pB As New DevExpress.XtraEditors.PictureEdit
            With pB
                .Properties.NullText = DT_Pictures(x - 1)("Picture")
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
        TotalImage_F = TotalImage
    End Sub

    Private Sub BtnAddImage_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Image File|*.jpg;*.jpeg;*.png",
            .Multiselect = True
        }
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                AddImage = True
                PanelEx4.AutoScroll = False
                For Each sFile As String In OFD.FileNames
                    Dim F_Info As New IO.FileInfo(sFile)
                    If F_Info.Length / 1024 > 1024 Then
                        MsgBox(String.Format("Selected File {0} have a size of {1}KB. Please limit up to 1024KB only.", sFile, CInt(F_Info.Length / 1000)), MsgBoxStyle.Information, "Info")
                        GoTo Here
                    End If
                    If TotalImage = Max_Image Then
                        MsgBox(String.Format("Maximum image to attach is up to {0} images only.", Max_Image), MsgBoxStyle.Information, "Info")
                        PanelEx4.AutoScroll = True
                        Exit Sub
                    End If
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        .Properties.Appearance.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
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
                PanelEx4.AutoScroll = True
            Catch ex As Exception
                PanelEx4.AutoScroll = True
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
                .Type = "ROPOA RE"
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
        If CType(sender, DevExpress.XtraEditors.PictureEdit).Properties.NullText <> "No Image" Then
            Try
            Catch ex As Exception
                TriggerBugReport("Real Estate ROPA - ImageChanged", ex.Message.ToString)
            End Try
        Else
            Try
                If CType(sender, DevExpress.XtraEditors.PictureEdit).Image Is Nothing Then
                    Dim ChangeTag As Boolean = False
                    Dim TempTotal As Integer = TotalImage
                    PanelEx4.AutoScroll = False
                    Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
                    PanelEx4.Controls.Remove(b)
                    TempTotal -= 1
                    ChangeTag = True
                    TotalImage = TempTotal

                    If ChangeTag Then
                        Dim Z As Integer = TotalImage
                        For Each PBox As DevExpress.XtraEditors.PictureEdit In PanelEx4.Controls
                            PBox.Tag = Z
                            Z -= 1
                            If Z >= 5 Then
                                If Z >= 10 Then
                                    If Z >= 15 Then
                                        If Z >= 20 Then
                                        Else
                                            PBox.Location = New Point(3 + (230 * (Z - 15)), 3 + 156 + 156 + 156)
                                        End If
                                    Else
                                        PBox.Location = New Point(3 + (230 * (Z - 10)), 3 + 156 + 156)
                                    End If
                                Else
                                    PBox.Location = New Point(3 + (230 * (Z - 5)), 3 + 156)
                                End If
                            Else
                            End If
                        Next
                    End If
                    PanelEx4.AutoScroll = True
                End If
            Catch ex As Exception
                TriggerBugReport("Real Estate ROPA - ImageChanged", ex.Message.ToString)
            End Try
        End If
    End Sub

    Public Sub SaveImage(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER Branch
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, RopoaBranchCode))
        End If
        '********CREATE FOLDER Borrowers
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode))
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
                LabelX5.Visible = False
                dPrice.Visible = False
                LabelX6.Visible = False
                dBalanceTransferred.Visible = False
                GridColumn7.Visible = False
                GridColumn42.Visible = False
                GridColumn89.Visible = False
                GridColumn121.Visible = False
                HidePrice = True
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        ElseIf e.Control And e.KeyCode = Keys.U Then
            FormRestriction(60) 'ROPOA Pricing
            If allow_Access Then
                LabelX5.Visible = True
                dPrice.Visible = True
                LabelX6.Visible = True
                dBalanceTransferred.Visible = True
                GridColumn7.Visible = True
                GridColumn42.Visible = True
                GridColumn89.Visible = True
                GridColumn121.Visible = True
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

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
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
            ElseIf ROPOA_Status = "Sold" Then
                GridView3.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView3)
            ElseIf ROPOA_Status = "Reserved" Then
                GridView1.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView1)
            ElseIf ROPOA_Status = "Reclassified" Then
                GridView4.FocusedRowHandle = iFrom.Value - 1
                PassData(GridView4)
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
        End If
    End Sub

    Private Sub BtnNext_2_Click(sender As Object, e As EventArgs) Handles btnNext_2.Click
        If ROPOA_Status = "Sell" Then
            GridView2.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Sold" Then
            GridView3.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reserved" Then
            GridView1.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reclassified" Then
            GridView4.ClearColumnsFilter()
        End If

        iFrom.Value = iFrom.Value + 1
    End Sub

    Private Sub BtnBack_2_Click(sender As Object, e As EventArgs) Handles btnBack_2.Click
        If ROPOA_Status = "Sell" Then
            GridView2.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Sold" Then
            GridView3.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reserved" Then
            GridView1.ClearColumnsFilter()
        ElseIf ROPOA_Status = "Reclassified" Then
            GridView4.ClearColumnsFilter()
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
        FirstLoad = True
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

        LabelX5.Visible = False
        dPrice.Visible = False
        LabelX6.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn7.Visible = False
        GridColumn42.Visible = False
        GridColumn89.Visible = False
        GridColumn121.Visible = False
        HidePrice = True
    End Sub

    Private Sub PassData(GV As DevExpress.XtraGrid.Views.Grid.GridView)
        Cursor = Cursors.WaitCursor
        If GV.RowCount = 0 Then
            Exit Sub
        End If
        With GV
            ID = .GetFocusedRowCellValue("ID")
            If cbxAdvance.Checked Then
                lblLocation.Text = DataObject(String.Format("SELECT branch FROM branch WHERE branch_code = '{0}';", GV.GetFocusedRowCellValue("branch_code")))
            End If
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
            If .GetFocusedRowCellValue("COS_Received") = "" Then
                cbxRedemption.Checked = False
                btnRedemption.TextColor = Color.Black
                ReceivedCOS = Date.Now
                ReceivedCOS_Tag = Date.Now
                COS_Annotation = Date.Now
                COS_Annotation_Tag = Date.Now
                ConsolidationD = ""
            Else
                cbxRedemption.Checked = True
                btnRedemption.TextColor = OfficialColor2 'Color.Red
                ReceivedCOS = .GetFocusedRowCellValue("COS_Received")
                ReceivedCOS_Tag = .GetFocusedRowCellValue("COS_Received")
                COS_Annotation = .GetFocusedRowCellValue("COS_Annotation")
                COS_Annotation_Tag = .GetFocusedRowCellValue("COS_Annotation")
                If .GetFocusedRowCellValue("Consolidation_Date") = "" Then
                    ConsolidationD = ""
                Else
                    ConsolidationD = .GetFocusedRowCellValue("Consolidation_Date")
                End If
            End If
            txtAssetNumber.Text = .GetFocusedRowCellValue("Asset Number")
            txtAssetNumber.Tag = .GetFocusedRowCellValue("Asset Number")

            txtTCT.Text = .GetFocusedRowCellValue("TCT Number")
            txtTCT.Tag = .GetFocusedRowCellValue("TCT Number")
            txtLocation.Text = .GetFocusedRowCellValue("Location")
            txtLocation.Tag = .GetFocusedRowCellValue("Location")
            txtCoordinates.Text = .GetFocusedRowCellValue("Coordinates")
            txtCoordinates.Tag = .GetFocusedRowCellValue("Coordinates")
            dArea.Value = .GetFocusedRowCellValue("Area")
            dArea.Tag = .GetFocusedRowCellValue("Area")
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxOthers.Checked = False
            If .GetFocusedRowCellValue("Classification") = "Residential" Then
                cbxResidential.Checked = True
            ElseIf .GetFocusedRowCellValue("Classification") = "Commercial" Then
                cbxCommercial.Checked = True
            ElseIf .GetFocusedRowCellValue("Classification") = "Agricultural" Then
                cbxAgricultural.Checked = True
            ElseIf .GetFocusedRowCellValue("Classification") = "Tourism" Then
                cbxTourism.Checked = True
            ElseIf .GetFocusedRowCellValue("Classification") = "Industrial" Then
                cbxIndustrial.Checked = True
            ElseIf .GetFocusedRowCellValue("Classification") = "Condominium" Then
                cbxCondominium.Checked = True
            Else
                cbxOthers.Checked = True
                txtOthers.Text = .GetFocusedRowCellValue("Classification")
            End If
            cbxResidential.Tag = .GetFocusedRowCellValue("Classification")
            cbxCommercial.Tag = .GetFocusedRowCellValue("Classification")
            cbxAgricultural.Tag = .GetFocusedRowCellValue("Classification")
            cbxTourism.Tag = .GetFocusedRowCellValue("Classification")
            cbxIndustrial.Tag = .GetFocusedRowCellValue("Classification")
            cbxCondominium.Tag = .GetFocusedRowCellValue("Classification")
            cbxOthers.Tag = .GetFocusedRowCellValue("Classification")
            dPrice.Value = .GetFocusedRowCellValue("Price")
            dPrice.Tag = .GetFocusedRowCellValue("Price")
            dBalanceTransferred.Value = .GetFocusedRowCellValue("Balance Transferred")
            dBalanceTransferred.Tag = .GetFocusedRowCellValue("Balance Transferred")
            If dPrice.Value > 1 Then
                If User_Type.ToUpper = "ADMIN" Then
                Else
                    dPrice.Enabled = False
                End If
            End If
            If .GetFocusedRowCellValue("Vacant Lot") = "YES" Then
                cbxVacant.Checked = True
            Else
                cbxVacant.Checked = False
            End If
            cbxVacant.Tag = .GetFocusedRowCellValue("Vacant Lot")
            txtStorey.Text = .GetFocusedRowCellValue("Storeys")
            txtStorey.Tag = .GetFocusedRowCellValue("Storeys")
            txtRoofings.Text = .GetFocusedRowCellValue("Roofings")
            txtRoofings.Tag = .GetFocusedRowCellValue("Roofings")
            txtFlooring.Text = .GetFocusedRowCellValue("Floorings")
            txtFlooring.Tag = .GetFocusedRowCellValue("Floorings")
            txtTandB.Text = .GetFocusedRowCellValue("T and B")
            txtTandB.Tag = .GetFocusedRowCellValue("T and B")
            txtFrame.Text = .GetFocusedRowCellValue("Frame")
            txtFrame.Tag = .GetFocusedRowCellValue("Frame")
            txtBeams.Text = .GetFocusedRowCellValue("Beams")
            txtBeams.Tag = .GetFocusedRowCellValue("Beams")
            txtDoors.Text = .GetFocusedRowCellValue("Doors")
            txtDoors.Tag = .GetFocusedRowCellValue("Doors")
            txtYearConstructed.Text = .GetFocusedRowCellValue("Yr Constructed")
            txtYearConstructed.Tag = .GetFocusedRowCellValue("Yr Constructed")
            txtWalling.Text = .GetFocusedRowCellValue("Wallings")
            txtWalling.Tag = .GetFocusedRowCellValue("Wallings")
            txtCeilings.Text = .GetFocusedRowCellValue("Ceilings")
            txtCeilings.Tag = .GetFocusedRowCellValue("Ceilings")
            txtWindows.Text = .GetFocusedRowCellValue("Windows")
            txtWindows.Tag = .GetFocusedRowCellValue("Windows")
            txtFloorArea.Text = .GetFocusedRowCellValue("Floor Area")
            txtFloorArea.Tag = .GetFocusedRowCellValue("Floor Area")
            txtPartitions.Text = .GetFocusedRowCellValue("Partitions")
            txtPartitions.Tag = .GetFocusedRowCellValue("Partitions")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            RopoaBranchCode = .GetFocusedRowCellValue("branch_code")
        End With
        If GV.GetFocusedRowCellValue("account_count") > 1 Then
            MultipleA = True
            txtTCT.Enabled = False
            cbxAccountName.Enabled = False
            txtAccountNo.Enabled = False
            btnMultipleA.TextColor = OfficialColor2 'Color.Red
        Else
            MultipleA = False
            txtTCT.Enabled = True
            cbxAccountName.Enabled = True
            txtAccountNo.Enabled = True
            btnMultipleA.TextColor = Color.Black
        End If
        Try
            LoadImage()
            TotalImage = 0
            Dim PathX As String = String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GV.GetFocusedRowCellValue("branch_code"), txtAssetNumber.Text)
            If IO.Directory.Exists(PathX) Then
                Dim files() As String = IO.Directory.GetFiles(PathX)
                For Each file As String In files
                    ' Do work, example
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        .Properties.Appearance.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
                        .Size = New Size(200, 150)
                        PanelEx4.Controls.Add(pB)
                        .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        If TotalImage >= 5 Then
                            If TotalImage >= 10 Then
                                If TotalImage >= 15 Then
                                    If TotalImage >= 20 Then
                                        If TotalImage >= 25 Then
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
                    Dim Path As String = file.ToString
                    If IO.File.Exists(Path) Then
                        Using TempPB As New DevExpress.XtraEditors.PictureEdit
                            TempPB.Image = Image.FromFile(Path)
                            ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                        End Using
                    End If
                Next
            End If
            TotalImage_F = TotalImage
        Catch ex As Exception
            Cursor = Cursors.Default
            TriggerBugReport("Real Estate ROPOA - FixUI", ex.Message.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        FirstLoad = True
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

        LabelX5.Visible = False
        dPrice.Visible = False
        LabelX6.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn7.Visible = False
        GridColumn42.Visible = False
        GridColumn89.Visible = False
        GridColumn121.Visible = False
        HidePrice = True
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        FirstLoad = True
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "RESERVED"
        ROPOA_Status = "Reserved"
        dBalanceTransferred.Enabled = False
        PassData(GridView1)

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
        If GridView1.GetFocusedRowCellValue("reserved_days") > 0 Or GridView1.GetFocusedRowCellValue("Balance") > 0 Then
            btnPurchase.Enabled = True
            btnReserve.Enabled = False
            btnAppraise.Enabled = False
        End If

        txtKeyword.Enabled = False
        cbxAdvance.Enabled = False
        btnSearch.Enabled = False
        iFrom.Value = GridView1.GetFocusedDataSourceRowIndex + 1
        iTo.Value = GridView1.RowCount
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

        LabelX5.Visible = False
        dPrice.Visible = False
        LabelX6.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn7.Visible = False
        GridColumn42.Visible = False
        GridColumn89.Visible = False
        GridColumn121.Visible = False
        HidePrice = True
    End Sub

    Private Sub GridView4_DoubleClick(sender As Object, e As EventArgs) Handles GridView4.DoubleClick
        FirstLoad = True
        Try
            If GridView4.GetFocusedRowCellValue("ID").ToString = "" Or GridView4.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        lblSold.Visible = True
        lblSold.Text = "RECLASSIFIED"
        ROPOA_Status = "Reclassified"
        dBalanceTransferred.Enabled = False
        PassData(GridView4)

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
        btnAppraise.Enabled = False
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

        LabelX5.Visible = False
        dPrice.Visible = False
        LabelX6.Visible = False
        dBalanceTransferred.Visible = False
        GridColumn7.Visible = False
        GridColumn42.Visible = False
        GridColumn89.Visible = False
        GridColumn121.Visible = False
        HidePrice = True
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
        Dim BalanceT As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE EntryType = 'DEBIT' AND PaidFor = 'Balance Transferred' AND PostStatus = 'POSTED';", txtAssetNumber.Text, txtTCT.Text))
        If BalanceT = 0 Then
            MsgBox("ROPA Approved Balance Transfer is not yet available. Please transact the approved balance transfer to proceed on purchasing the ROPOA.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If ROPOA_Status = "Sell" Then
            Dim Purchase As New FrmSoldROPOA
            With Purchase
                .AssetNumber = txtAssetNumber.Text
                .dSellingPrice.Value = dPrice.Value
                .ROPOA_Ref = txtTCT.Text
                .MultipleA = MultipleA
                .BankID = cbxBank.SelectedValue

                If .ShowDialog = DialogResult.OK Then
                    iFrom.Value = 0
                    iTo.Value = 0
                    OpenACR()
                    Clear()
                    txtKeyword.Text = ""
                    btnAddImage.Enabled = True
                    dtpDate.Enabled = True

                    btnNext_2.Enabled = False
                    btnBack_2.Enabled = False
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
                .ROPOA_Ref = txtTCT.Text
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

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim AssetNumber As String
        If MultipleA Then
            Dim AccountList As New FrmAccountList
            With AccountList
                .DT_Account = DataSource(String.Format("SELECT AccountNo, AssetNumber FROM ropoa_realestate WHERE TCT = '{0}' AND `status` = 'ACTIVE';", txtTCT.Text))
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
            .ROPOA_Ref = txtTCT.Text

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

            .tabVehicle.Visible = False
            .SuperTabControl1.SelectedTab = .tabRealEstate
            .ShowDialog()
            .Dispose()
        End With
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
                DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE TCT = '{0}'", txtTCT.Text))
                Logs("ROPOA RE", "For Sell", Reason, String.Format("Change ROPOA Real Estate status to FOR SELL with Asset Number {0}", txtAssetNumber.Text), "", "", "")
                LoadData()
                LoadReserved()
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully For Sell!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes("Are you sure you want this ROPOA to be RESERVE?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'RESERVED', reserve_reason = '{1}' WHERE TCT = '{0}'", txtTCT.Text, Reason))
                Logs("ROPOA RE", "Reserve", Reason, String.Format("Change ROPOA Real Estate status to RESERVED with Asset Number {0}", txtAssetNumber.Text), "", "", "")
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
                    DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", txtTCT.Text))
                    LoadData()
                    LoadReclassified()
                    Logs("ROPOA Real Estate", "For Sell", "", String.Format("ROPOA Real Estate status to FOR SELL from RECLASSIFIED with Asset Number {0}", txtAssetNumber.Text), "", "", "")

                    Clear()
                    MsgBox("Successfully For Sell!", MsgBoxStyle.Information, "Info")
                End If
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
                    DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'RECLASSIFIED' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", txtTCT.Text))
                    LoadData()
                    LoadReclassified()
                    Logs("ROPOA Real Estate", "Reclassify", "", String.Format("ROPOA Real Estate status to RECLASSIFIED from FOR SELL with Asset Number {0}", txtAssetNumber.Text), "", "", "")

                    Clear()
                    MsgBox("Successfully Reclassfied!", MsgBoxStyle.Information, "Info")
                End If
            End With
        End If
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
                    TriggerBugReport("Real Estate ROPA - RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
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
                TriggerBugReport("Real Estate ROPA - RowCellStyle", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub BtnMultipleA_Click(sender As Object, e As EventArgs) Handles btnMultipleA.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure that this ROPOA does have a multiple account?") = MsgBoxResult.Yes Then
            btnSave.Enabled = True
            btnModify.Enabled = False

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
            btnAddImage.Enabled = False
            btnPurchase.Enabled = False
            btnHistory.Enabled = False
            btnReserve.Enabled = False
            btnReclassify.Enabled = False
            btnAppraise.Enabled = False

            cbxNature.Enabled = False
            GetROPOA()

            txtTCT.Enabled = False
            txtLocation.Enabled = False
            dArea.Enabled = False
            cbxResidential.Enabled = False
            cbxCommercial.Enabled = False
            cbxAgricultural.Enabled = False
            cbxTourism.Enabled = False
            cbxIndustrial.Enabled = False
            cbxOthers.Enabled = False
            dPrice.Enabled = False
            cbxVacant.Enabled = False
            txtStorey.Enabled = False
            txtRoofings.Enabled = False
            txtFlooring.Enabled = False
            txtTandB.Enabled = False
            txtFrame.Enabled = False
            txtBeams.Enabled = False
            txtDoors.Enabled = False
            txtYearConstructed.Enabled = False
            txtWalling.Enabled = False
            txtCeilings.Enabled = False
            txtWindows.Enabled = False
            txtFloorArea.Enabled = False
            txtPartitions.Enabled = False
            txtRemarks.Enabled = False

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

    Private Sub BtnAppraise_Click(sender As Object, e As EventArgs) Handles btnAppraise.Click
        Dim Appraise As New FrmRealEstateAppraisal
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
            Dim DateResult As String = DataObject(String.Format("SELECT IFNULL(appraise_date,DATE(NOW())) FROM appraise_re WHERE appraise = 'ROPOA' AND asset_number = '{0}' AND `status` IN ('ACTIVE','PENDING') ORDER BY appraise_date DESC LIMIT 1;", txtAssetNumber.Text))
            If DateResult = "" Then
            Else
                MsgBox(String.Format("{0} Day(s) ago since last appraise for this ROPA", DateDiff(DateInterval.Day, CDate(DateResult), Date.Now)), MsgBoxStyle.Information, "Info")
            End If

            'Pass Value
            .From_RealEstate = True
            .AssetNumber = txtAssetNumber.Text
            .cbxAppraiseFor.Text = "ROPOA"

            .txtTCT.Text = txtTCT.Text
            .txtTCT.Enabled = False
            .dArea.Text = dArea.Value
            .dArea.Enabled = False
            .rLocation.Text = txtLocation.Text
            .txtCoordinates.Text = txtCoordinates.Text
            .cbxVacant.Checked = cbxVacant.Checked
            .cbxResidential.Checked = cbxResidential.Checked
            .cbxCommercial.Checked = cbxCommercial.Checked
            .cbxAgricultural.Checked = cbxAgricultural.Checked
            .cbxTourism.Checked = cbxTourism.Checked
            .cbxIndustrial.Checked = cbxIndustrial.Checked
            .cbxCondominium.Checked = cbxCondominium.Checked
            .cbxOthers.Checked = cbxOthers.Checked
            .txtOthers.Text = txtOthers.Text
            .txtStorey.Text = txtStorey.Text
            .txtRoofings.Text = txtRoofings.Text
            .txtFlooring.Text = txtFlooring.Text
            .txtTandB.Text = txtTandB.Text
            .txtFrame.Text = txtFrame.Text
            .txtBeams.Text = txtBeams.Text
            .txtDoors.Text = txtDoors.Text
            .txtYearConstructed.Text = txtYearConstructed.Text
            .txtWalling.Text = txtWalling.Text
            .txtCeilings.Text = txtCeilings.Text
            .txtWindows.Text = txtWindows.Text
            .txtFloorArea.Text = txtFloorArea.Text
            .txtPartitions.Text = txtPartitions.Text
            .rRemarks.Text = txtRemarks.Text
            If .ShowDialog = DialogResult.OK Then

            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "PENDING" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            Else
                e.Appearance.ForeColor = Color.DarkGreen
            End If
        End If
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
        If txtTCT.Text = "" Then
            MsgBox("Please fill TCT field.", MsgBoxStyle.Information, "Info")
            txtTCT.Focus()
            Exit Sub
        End If
        If txtLocation.Text = "" Then
            MsgBox("Please fill Location field.", MsgBoxStyle.Information, "Info")
            txtLocation.Focus()
            Exit Sub
        End If
        If IsDate(dtpDate.Text) = False Then
            MsgBox("Please fill the correct ROPOA Date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dArea.Value = 0 Then
            MsgBox("Please fill Area field.", MsgBoxStyle.Information, "Info")
            dArea.Focus()
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

        Dim Classification As String = ""
        If cbxResidential.Checked Then
            Classification = "Residential"
        ElseIf cbxCommercial.Checked Then
            Classification = "Commercial"
        ElseIf cbxAgricultural.Checked Then
            Classification = "Agricultural"
        ElseIf cbxTourism.Checked Then
            Classification = "Tourism"
        ElseIf cbxIndustrial.Checked Then
            Classification = "Industrial"
        ElseIf cbxOthers.Checked Then
            Classification = "Others"
        End If

        If MsgBoxYes("Are you sure you want to verify this ROPOA?") = MsgBoxResult.Yes Then
            Dim Reason As String = "Verify" 'Reason for change

            Cursor = Cursors.WaitCursor
            If MultipleA = False Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ropoa_realestate WHERE TCT = '{0}' AND `status` = 'ACTIVE' AND AssetNumber != '{1}' AND sell_status = 'SELL'", txtTCT.Text, txtAssetNumber.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("TCT Number {0} already exist, Please check your data.", txtTCT.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If

            Dim SQL As String = "UPDATE ropoa_realestate SET"
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
            If cbxRedemption.Checked Then
                SQL &= String.Format(" COS_Received = '{0}', ", Format(ReceivedCOS, "yyyy-MM-dd"))
                SQL &= String.Format(" COS_Annotation = '{0}', ", Format(COS_Annotation, "yyyy-MM-dd"))
            Else
                SQL &= " COS_Received = '', "
                SQL &= " COS_Annotation = '', "
            End If
            SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
            SQL &= String.Format(" Location = '{0}', ", txtLocation.Text)
            SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
            SQL &= String.Format(" `Area` = '{0}', ", dArea.Value)
            SQL &= String.Format(" Classification = '{0}', ", Classification)
            SQL &= String.Format(" Price = '{0}', ", dPrice.Value)
            SQL &= String.Format(" BalanceTransferred = '{0}', ", dBalanceTransferred.Value)
            SQL &= String.Format(" VacantLot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
            SQL &= String.Format(" Storey = '{0}', ", txtStorey.Text)
            SQL &= String.Format(" Roofings = '{0}', ", txtRoofings.Text)
            SQL &= String.Format(" Flooring = '{0}', ", txtFlooring.Text)
            SQL &= String.Format(" TandB = '{0}', ", txtTandB.Text)
            SQL &= String.Format(" Frame = '{0}', ", txtFrame.Text)
            SQL &= String.Format(" Beams = '{0}', ", txtBeams.Text)
            SQL &= String.Format(" Doors = '{0}', ", txtDoors.Text)
            SQL &= String.Format(" YearConstructed = '{0}', ", txtYearConstructed.Text)
            SQL &= String.Format(" Walling = '{0}', ", txtWalling.Text)
            SQL &= String.Format(" `Ceiling` = '{0}', ", txtCeilings.Text)
            SQL &= String.Format(" Windows = '{0}', ", txtWindows.Text)
            SQL &= String.Format(" FloorArea = '{0}', ", txtFloorArea.Text)
            SQL &= String.Format(" `Partitions` = '{0}', ", txtPartitions.Text)
            SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
            SQL &= String.Format(" Bank = '{0}', `status` = 'ACTIVE', ", Bank)
            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
            SQL &= String.Format(" Img = '{0}' ", TotalImage)
            If MultipleA Then
                SQL &= String.Format(" WHERE TCT = '{0}';", txtTCT.Text)
            Else
                If dtpDate.Enabled Then
                    SQL &= String.Format(" WHERE AssetNumber = '{0}';", txtAssetNumber.Tag)
                Else
                    SQL &= String.Format(" WHERE AssetNumber = '{0}';", txtAssetNumber.Text)
                End If
            End If
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                'ACCOUNTING ENTRY *******************************************************************************************************
                SQL &= " INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL &= " EntryType = 'DEBIT',"
                SQL &= String.Format(" Payable = '{0}', ", dBalanceTransferred.Value)
                SQL &= String.Format(" Amount = '{0}', ", dBalanceTransferred.Value)
                SQL &= " AccountCode = '126001X', "
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126001")))
                If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Then
                    SQL &= " PostStatus = 'POSTED', "
                End If
                SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                SQL &= String.Format(" ReferenceN = '{0}', ", txtAssetNumber.Text)
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" CVNumber = '{0}', ", txtTCT.Text)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                'ACCOUNTING ENTRY *******************************************************************************************************
            End If
            DataObject(SQL)
            For x As Integer = 1 To TotalImage
                Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                If x > 5 Then
                    If pb.Image Is Nothing Then
                    Else
                        ResizeImages(pb.Image.Clone, pb, 850, 700)
                        SaveImage(pb, "Image" & x)
                    End If
                Else
                    If pb.Image Is Nothing Then
                    Else
                        SaveImage(pb, pb.Properties.NullText & x)
                    End If
                End If
            Next
            If TotalImage < TotalImage_F Then
                For x As Integer = TotalImage + 1 To TotalImage_F
                    Dim xPath As String
                    FileName = "Image" & x & ".jpg"
                    xPath = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, txtAssetNumber.Text, FileName)
                    If IO.File.Exists(xPath) Then
                        IO.File.Delete(xPath)
                    End If
                Next
            End If
            Logs("ROPOA Real Estate", "Verify", Reason, String.Format("Verify ROPOA Real Estate with Asset Number {0}", txtAssetNumber.Text), "", "", "")
            LoadData()
            PanelEx2.Enabled = False
            btnModify.Enabled = True
            btnSave.Enabled = False

            btnAddImage.Enabled = True
            btnPurchase.Enabled = True
            btnHistory.Enabled = True
            btnReserve.Enabled = True
            btnReclassify.Enabled = True
            btnAppraise.Enabled = True
            btnMultipleA.Enabled = True
            btnVerify.Enabled = False
            FrmMain.RealEstateCount = FrmMain.RealEstateCount + 1
            Cursor = Cursors.Default
            MsgBox("Successfully Verified", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnRedemption_Click(sender As Object, e As EventArgs) Handles btnRedemption.Click
        Dim Redemption As New FrmRedemptionPeriod
        With Redemption
            .dtpReceived.Value = ReceivedCOS
            .dtpCOS.Value = COS_Annotation
            If ConsolidationD = "" Then
                .dtpConsolidation.Value = Date.Now
            Else
                .dtpConsolidation.Value = DateValue(ConsolidationD)
                .LabelX3.Visible = True
                .dtpConsolidation.Visible = True
                .btnSave.Enabled = False
                .btnRefresh.Enabled = False
                .btnDelete.Enabled = False
            End If
            If cbxRedemption.Checked Then
                .btnDelete.Enabled = True
            End If

            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                ReceivedCOS = .dtpReceived.Value
                COS_Annotation = .dtpCOS.Value
                cbxRedemption.Checked = True
                btnRedemption.TextColor = OfficialColor2 'Color.Red
            ElseIf Result = DialogResult.No Then
                cbxRedemption.Checked = False
                btnRedemption.TextColor = Color.Black
            Else
                If cbxRedemption.Checked Then
                    cbxRedemption.Checked = True
                Else
                    cbxRedemption.Checked = False
                End If
            End If
        End With
    End Sub

    Private Sub BtnPrint_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPrint.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            BtnPrint_Click(sender, e)
            Logs("Real Estate ROPA", "Print", "[SENSITIVE] Print Real Estate ROPA " & txtAssetNumber.Text, "", "", "", "")
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If vPrint Then
            Else
                MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If SuperTabControl1.SelectedTabIndex = 1 Then
                GridView2.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Real Estate List", GridControl2)
                Logs("Real Estate ROPA", "Print", "[SENSITIVE] Print Real Estate List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                GridView3.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Sold Real Estate List", GridControl3)
                Logs("Real Estate ROPA", "Print", "[SENSITIVE] Print Sold Real Estate List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                GridView1.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Reserved Real Estate List", GridControl1)
                Logs("Real Estate ROPA", "Print", "[SENSITIVE] Print Reserved Real Estate List", "", "", "", "")
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                GridView4.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Reclassified Real Estate List", GridControl4)
                Logs("Real Estate ROPA", "Print", "[SENSITIVE] Print Reclassified Real Estate List", "", "", "", "")
            End If
        End If
    End Sub

    Private Sub IDiscount_Click(sender As Object, e As EventArgs) Handles iDiscount.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Exist As DataTable = DataSource(String.Format("SELECT ID FROM ledger_ropoa WHERE `transaction` = 'Discount' AND `status` = 'ACTIVE' AND approve_status = 'PENDING' AND IF(ROPOA_REF = '',Asset_Number = '{0}',ROPOA_REF = '{1}');", GridView1.GetFocusedRowCellValue("Asset Number"), GridView1.GetFocusedRowCellValue("TCT Number")))
        If Exist.Rows.Count > 0 Then
            If MsgBoxYes("ROPOA already have a pending discount, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        Dim Discount As New FrmROPOADiscount
        With Discount
            .TransactionNo = GridView1.GetFocusedRowCellValue("transaction_no")
            .ROPOA_Type = "Real Estate"
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .MultipleA = If(GridView1.GetFocusedRowCellValue("account_count") > 1, True, False)
            .ROPOA_Ref = GridView1.GetFocusedRowCellValue("TCT Number")
            .CbxPrefix_B.Text = GridView1.GetFocusedRowCellValue("Prefix_B")
            .TxtFirstN_B.Text = GridView1.GetFocusedRowCellValue("FirstN_B")
            .TxtMiddleN_B.Text = GridView1.GetFocusedRowCellValue("MiddleN_B")
            .TxtLastN_B.Text = GridView1.GetFocusedRowCellValue("LastN_B")
            .cbxSuffix_B.Text = GridView1.GetFocusedRowCellValue("Suffix_B")
            .txtAssetNumber.Text = GridView1.GetFocusedRowCellValue("Asset Number")
            .txtAccountName.Text = GridView1.GetFocusedRowCellValue("Account Name")
            .txtAccountName.Text = GridView1.GetFocusedRowCellValue("Account No")
            .lblMake.Text = "TCT Number :"
            .txtMake.Text = GridView1.GetFocusedRowCellValue("TCT Number")
            .lblType.Text = "Location :"
            .txtType.Text = GridView1.GetFocusedRowCellValue("Location")
            .lblModel.Text = "Area :"
            .txtModel.Text = GridView1.GetFocusedRowCellValue("Area")
            .dPrice.Value = GridView1.GetFocusedRowCellValue("Price")
            .dROPOA_Value.Value = CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", GridView1.GetFocusedRowCellValue("Asset Number"))))
            .dSoldPrice.Value = GridView1.GetFocusedRowCellValue("Amount")
            .dBalance.Value = GridView1.GetFocusedRowCellValue("Balance")
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IRedemption_Click(sender As Object, e As EventArgs) Handles iRedemption.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView2.RowCount > 0 Then
                If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            Dim Redemption As New FrmRedemptionPeriod
            With Redemption
                .AssetNumber = GridView2.GetFocusedRowCellValue("Asset Number")
                .Type = "Real Estate"
                .dtpReceived.Enabled = False
                .dtpReceived.Value = If(GridView2.GetFocusedRowCellValue("COS_Received") = "", Date.Now, DateValue(GridView2.GetFocusedRowCellValue("COS_Received")))
                .dtpCOS.Enabled = False
                .dtpCOS.Value = If(GridView2.GetFocusedRowCellValue("COS_Annotation") = "", Date.Now, DateValue(GridView2.GetFocusedRowCellValue("COS_Annotation")))
                .LabelX3.Visible = True
                .dtpConsolidation.Visible = True
                .dtpConsolidation.Value = If(GridView2.GetFocusedRowCellValue("Consolidation_Date") = "", Date.Now, DateValue(GridView2.GetFocusedRowCellValue("Consolidation_Date")))
                .btnRefresh.Enabled = False
                .LabelX4.Visible = True
                .txtTCT.Visible = True
                .txtTCT.Text = GridView2.GetFocusedRowCellValue("TCT_New")
                .LabelX5.Visible = True
                .btnSave.Text = "Update"

                .LabelX6.Visible = True
                .lblAssetN.Visible = True
                .lblAssetN.Text = GridView2.GetFocusedRowCellValue("Asset Number")
                .LabelX7.Visible = True
                .lblAccountN.Visible = True
                .lblAccountN.Text = GridView2.GetFocusedRowCellValue("Account No")
                .LabelX8.Visible = True
                .lblTCTN.Visible = True
                .lblTCTN.Text = GridView2.GetFocusedRowCellValue("TCT Number")
                .LabelX9.Visible = True
                .lblArea.Visible = True
                .lblArea.Text = GridView2.GetFocusedRowCellValue("Area")

                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If GridView3.RowCount > 0 Then
                If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            Dim Redemption As New FrmRedemptionPeriod
            With Redemption
                .AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")
                .Type = "Real Estate"
                .dtpReceived.Enabled = False
                .dtpReceived.Value = If(GridView3.GetFocusedRowCellValue("COS_Received") = "", Date.Now, DateValue(GridView3.GetFocusedRowCellValue("COS_Received")))
                .dtpCOS.Enabled = False
                .dtpCOS.Value = If(GridView3.GetFocusedRowCellValue("COS_Annotation") = "", Date.Now, DateValue(GridView3.GetFocusedRowCellValue("COS_Annotation")))
                .LabelX3.Visible = True
                .dtpConsolidation.Visible = True
                .dtpConsolidation.Value = If(GridView3.GetFocusedRowCellValue("Consolidation_Date") = "", Date.Now, DateValue(GridView3.GetFocusedRowCellValue("Consolidation_Date")))
                .btnRefresh.Enabled = False
                .LabelX4.Visible = True
                .txtTCT.Visible = True
                .txtTCT.Text = GridView3.GetFocusedRowCellValue("TCT_New")
                .LabelX5.Visible = True
                .btnSave.Text = "Update"

                .LabelX6.Visible = True
                .lblAssetN.Visible = True
                .lblAssetN.Text = GridView3.GetFocusedRowCellValue("Asset Number")
                .LabelX7.Visible = True
                .lblAccountN.Visible = True
                .lblAccountN.Text = GridView3.GetFocusedRowCellValue("Account No")
                .LabelX8.Visible = True
                .lblTCTN.Visible = True
                .lblTCTN.Text = GridView3.GetFocusedRowCellValue("TCT Number")
                .LabelX9.Visible = True
                .lblArea.Visible = True
                .lblArea.Text = GridView3.GetFocusedRowCellValue("Area")

                If .ShowDialog = DialogResult.OK Then
                    LoadSold()
                End If
                .Dispose()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView1.RowCount > 0 Then
                If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            Dim Redemption As New FrmRedemptionPeriod
            With Redemption
                .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
                .Type = "Real Estate"
                .dtpReceived.Enabled = False
                .dtpReceived.Value = If(GridView1.GetFocusedRowCellValue("COS_Received") = "", Date.Now, DateValue(GridView1.GetFocusedRowCellValue("COS_Received")))
                .dtpCOS.Enabled = False
                .dtpCOS.Value = If(GridView1.GetFocusedRowCellValue("COS_Annotation") = "", Date.Now, DateValue(GridView1.GetFocusedRowCellValue("COS_Annotation")))
                .LabelX3.Visible = True
                .dtpConsolidation.Visible = True
                .dtpConsolidation.Value = If(GridView1.GetFocusedRowCellValue("Consolidation_Date") = "", Date.Now, DateValue(GridView1.GetFocusedRowCellValue("Consolidation_Date")))
                .btnRefresh.Enabled = False
                .LabelX4.Visible = True
                .txtTCT.Visible = True
                .txtTCT.Text = GridView1.GetFocusedRowCellValue("TCT_New")
                .LabelX5.Visible = True
                .btnSave.Text = "Update"

                .LabelX6.Visible = True
                .lblAssetN.Visible = True
                .lblAssetN.Text = GridView1.GetFocusedRowCellValue("Asset Number")
                .LabelX7.Visible = True
                .lblAccountN.Visible = True
                .lblAccountN.Text = GridView1.GetFocusedRowCellValue("Account No")
                .LabelX8.Visible = True
                .lblTCTN.Visible = True
                .lblTCTN.Text = GridView1.GetFocusedRowCellValue("TCT Number")
                .LabelX9.Visible = True
                .lblArea.Visible = True
                .lblArea.Text = GridView1.GetFocusedRowCellValue("Area")

                If .ShowDialog = DialogResult.OK Then
                    LoadReserved()
                End If
                .Dispose()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView4.RowCount > 0 Then
                If GridView4.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                End If
            Else
                Exit Sub
            End If

            Dim Redemption As New FrmRedemptionPeriod
            With Redemption
                .AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
                .Type = "Real Estate"
                .dtpReceived.Enabled = False
                .dtpReceived.Value = If(GridView4.GetFocusedRowCellValue("COS_Received") = "", Date.Now, DateValue(GridView4.GetFocusedRowCellValue("COS_Received")))
                .dtpCOS.Enabled = False
                .dtpCOS.Value = If(GridView4.GetFocusedRowCellValue("COS_Annotation") = "", Date.Now, DateValue(GridView4.GetFocusedRowCellValue("COS_Annotation")))
                .LabelX3.Visible = True
                .dtpConsolidation.Visible = True
                .dtpConsolidation.Value = If(GridView4.GetFocusedRowCellValue("Consolidation_Date") = "", Date.Now, DateValue(GridView4.GetFocusedRowCellValue("Consolidation_Date")))
                .btnRefresh.Enabled = False
                .LabelX4.Visible = True
                .txtTCT.Visible = True
                .txtTCT.Text = GridView4.GetFocusedRowCellValue("TCT_New")
                .LabelX5.Visible = True
                .btnSave.Text = "Update"

                .LabelX6.Visible = True
                .lblAssetN.Visible = True
                .lblAssetN.Text = GridView4.GetFocusedRowCellValue("Asset Number")
                .LabelX7.Visible = True
                .lblAccountN.Visible = True
                .lblAccountN.Text = GridView4.GetFocusedRowCellValue("Account No")
                .LabelX8.Visible = True
                .lblTCTN.Visible = True
                .lblTCTN.Text = GridView4.GetFocusedRowCellValue("TCT Number")
                .LabelX9.Visible = True
                .lblArea.Visible = True
                .lblArea.Text = GridView4.GetFocusedRowCellValue("Area")

                If .ShowDialog = DialogResult.OK Then
                    LoadReclassified()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub IBuyer_Click(sender As Object, e As EventArgs) Handles iBuyer.Click
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
                .AssetNumber = GridView3.GetFocusedRowCellValue("Asset Number")
                .ID = GridView3.GetFocusedRowCellValue("S_ID")

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
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            Try
                If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Buyer
                .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
                .ID = GridView1.GetFocusedRowCellValue("S_ID")

                .vPrefix = GridView1.GetFocusedRowCellValue("Prefix_B")
                .CbxPrefix_B.Tag = GridView1.GetFocusedRowCellValue("Prefix_B")
                .TxtFirstN_B.Text = GridView1.GetFocusedRowCellValue("FirstN_B")
                .TxtFirstN_B.Tag = GridView1.GetFocusedRowCellValue("FirstN_B")
                .TxtMiddleN_B.Text = GridView1.GetFocusedRowCellValue("MiddleN_B")
                .TxtMiddleN_B.Tag = GridView1.GetFocusedRowCellValue("MiddleN_B")
                .TxtLastN_B.Text = GridView1.GetFocusedRowCellValue("LastN_B")
                .TxtLastN_B.Tag = GridView1.GetFocusedRowCellValue("LastN_B")
                .vSuffix = GridView1.GetFocusedRowCellValue("Suffix_B")
                .cbxSuffix_B.Tag = GridView1.GetFocusedRowCellValue("Suffix_B")
                .txtNoC_B.Text = GridView1.GetFocusedRowCellValue("NoC_B")
                .txtNoC_B.Tag = GridView1.GetFocusedRowCellValue("NoC_B")
                .txtStreetC_B.Text = GridView1.GetFocusedRowCellValue("StreetC_B")
                .txtStreetC_B.Tag = GridView1.GetFocusedRowCellValue("StreetC_B")
                .txtBarangayC_B.Text = GridView1.GetFocusedRowCellValue("BarangayC_B")
                .txtBarangayC_B.Tag = GridView1.GetFocusedRowCellValue("BarangayC_B")
                .vAddress = GridView1.GetFocusedRowCellValue("AddressC_B")
                .cbxAddressC_B.Tag = GridView1.GetFocusedRowCellValue("AddressC_B")
                .txtContact_B.Text = GridView1.GetFocusedRowCellValue("Contact_N")
                .txtContact_B.Tag = GridView1.GetFocusedRowCellValue("Contact_N")

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
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            Try
                If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            With Referral
                .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
                .ID = GridView1.GetFocusedRowCellValue("S_ID")

                .vAgent = GridView1.GetFocusedRowCellValue("Referral_ID")
                .vMarketing = GridView1.GetFocusedRowCellValue("Referral_ID")
                .vDealer = GridView1.GetFocusedRowCellValue("Referral_ID")
                If GridView1.GetFocusedRowCellValue("Referral") = "A" Then
                    .cbxAgent.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Referral") = "M" Then
                    .cbxMarketing.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Referral") = "D" Then
                    .cbxDealer.Checked = True
                End If

                If .ShowDialog = DialogResult.OK Then
                    LoadReserved()
                End If
            End With
        End If
        Referral.Dispose()
    End Sub

    Private Sub IGoogle_Click(sender As Object, e As EventArgs) Handles iGoogle.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 1 Then
                If GridView2.GetFocusedRowCellValue("Coordinates") <> "" Then
                    Process.Start(GridView2.GetFocusedRowCellValue("Coordinates"))
                ElseIf GridView2.GetFocusedRowCellValue("Location") <> "" Then
                    Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView2.GetFocusedRowCellValue("Location")))
                Else
                    MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                If GridView3.GetFocusedRowCellValue("Coordinates") <> "" Then
                    Process.Start(GridView3.GetFocusedRowCellValue("Coordinates"))
                ElseIf GridView3.GetFocusedRowCellValue("Location") <> "" Then
                    Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView3.GetFocusedRowCellValue("Location")))
                Else
                    MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                If GridView1.GetFocusedRowCellValue("Coordinates") <> "" Then
                    Process.Start(GridView1.GetFocusedRowCellValue("Coordinates"))
                ElseIf GridView1.GetFocusedRowCellValue("Location") <> "" Then
                    Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView1.GetFocusedRowCellValue("Location")))
                Else
                    MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                If GridView4.GetFocusedRowCellValue("Coordinates") <> "" Then
                    Process.Start(GridView4.GetFocusedRowCellValue("Coordinates"))
                ElseIf GridView4.GetFocusedRowCellValue("Location") <> "" Then
                    Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView4.GetFocusedRowCellValue("Location")))
                Else
                    MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        If txtCoordinates.Text <> "" Then
            Process.Start(txtCoordinates.Text)
        ElseIf txtLocation.Text <> "" Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", txtLocation.Text))
        Else
            MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IPDC_Click(sender As Object, e As EventArgs) Handles iPDC.Click
        Dim Sched As New FrmPurchaseSched
        With Sched
            .Buyer = If(GridView1.GetFocusedRowCellValue("Prefix_B") = "", "", GridView1.GetFocusedRowCellValue("Prefix_B") & " ") & If(GridView1.GetFocusedRowCellValue("FirstN_B") = "", "", GridView1.GetFocusedRowCellValue("FirstN_B") & " ") & If(GridView1.GetFocusedRowCellValue("MiddleN_B") = "", "", GridView1.GetFocusedRowCellValue("MiddleN_B") & " ") & If(GridView1.GetFocusedRowCellValue("LastN_B") = "", "", GridView1.GetFocusedRowCellValue("LastN_B") & " ") & GridView1.GetFocusedRowCellValue("Suffix_B")
            .ContactN = GridView1.GetFocusedRowCellValue("Contact_N")
            .Months = 6
            .From_Reserve = True
            .xDate = Date.Now
            .Amount = 0
            .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
            .ORNumber = ""
            .TotalPayable = GridView1.GetFocusedRowCellValue("Amount")
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            If .ShowDialog = DialogResult.OK Then

            End If
        End With
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
            If GridView1.RowCount > 0 Then
                Try
                    If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If

            AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
            TotalImageSelected = GridView1.GetFocusedRowCellValue("Attach")
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
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
        End If
        Dim Attach As New FrmAttachFileV2
        With Attach
            .AllowOveright = False
            .FolderName = "Purchase-" & AssetNumber
            .TotalImage = TotalImageSelected
            .AssetNumber = AssetNumber
            .ID = AssetNumber
            .Type = "Purchase RE"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    GridView1.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    GridView4.SetFocusedRowCellValue("Attach", TotalImage)
                End If
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    GridView1.SetFocusedRowCellValue("Attach", TotalImage)
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    GridView4.SetFocusedRowCellValue("Attach", TotalImage)
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
            If GridView1.RowCount = 0 Then
                Exit Sub
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView4.RowCount = 0 Then
                Exit Sub
            End If
        End If

        Dim AssetNumber As String = ""
        If MultipleA Then
            Dim AccountList As New FrmAccountList
            With AccountList
                Dim TCT As String = ""
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    TCT = GridView2.GetFocusedRowCellValue("TCT Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    TCT = GridView3.GetFocusedRowCellValue("TCT Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    TCT = GridView1.GetFocusedRowCellValue("TCT Number")
                ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                    TCT = GridView4.GetFocusedRowCellValue("TCT Number")
                End If
                .DT_Account = DataSource(String.Format("SELECT AccountNo, AssetNumber FROM ropoa_realestate WHERE TCT = '{0}' AND `status` = 'ACTIVE';", TCT))
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
                AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
            End If
        End If

        Dim History As New FrmROPOALedger
        With History
            .Tag = 53
            .AssetNumber = AssetNumber
            .ROPOA_Status = ROPOA_Status
            .MultipleA = MultipleA
            .ROPOA_Ref = txtTCT.Text

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