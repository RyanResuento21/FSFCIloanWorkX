
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Public Class FrmROPOARepricing 

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public FromReprice As Boolean
    Public Batch As Boolean
    Public AssetNumber As String
    Dim Path As String
    Dim TotalImage As Integer
    Public RePricing_Code As String
    Dim LastReprice As String
    Dim DT_VE As DataTable
    Dim DT_RE As DataTable

    Private Sub FrmROPOA_Repricing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If SuperTabControl1.SelectedTabIndex = 0 Then
            LastReprice = DataObject(String.Format("SELECT approved_date FROM tbl_repricing WHERE approved_date != '' AND `status` = 'ACTIVE' AND `status` != 'INACTIVE' AND ropoa_type = 'VE' AND branch_id = '{0}'", Branch_ID))

            LoadVehicle()
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LastReprice = DataObject(String.Format("SELECT approved_date FROM tbl_repricing WHERE approved_date != '' AND `status` = 'ACTIVE' AND `status` != 'INACTIVE' AND ropoa_type = 'RE' AND branch_id = '{0}'", Branch_ID))

            LoadRealEstate()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnSave, btnDraft, btnAttach, btnRefresh, btnPrint, btnPrintIndi, btnCancel, btnRemove, btnRemoveA})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("ROPA Reprincing - FixUI", ex.Message.ToString)
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
        OpenFormHistory("ROPOA Repricing", lblTitle.Text)
    End Sub

    Private Sub LoadVehicle()
        Dim SQL As String = "SELECT "
        SQL &= "     R.AssetNumber AS 'Asset Number', "
        SQL &= "     Make, "
        SQL &= "     `Type`, "
        SQL &= "     Model, "
        SQL &= "     Transmission, "
        SQL &= "     Fuel, "
        SQL &= "     TRIM(`Year`) AS 'Year', "
        SQL &= "     RimHoles AS 'Rim Holes', "
        SQL &= "     CONCAT(FORMAT(MileAge,0), ' ', MileAgeType) AS 'Mile Age', "
        SQL &= "     IF(`ConditionReason` = '', `Condition`, CONCAT(`Condition`, ' - ', ConditionReason)) AS 'Condition',"
        SQL &= "     L.Running AS 'ROPOA Value', "
        SQL &= "     R.Price AS 'Price', "
        SQL &= "     IFNULL(P.Price,0) AS 'Suggested Price', "
        SQL &= "     0 AS 'Approved Price', "
        SQL &= "     branch_code,PlateNum,account_count,accountNo "
        SQL &= String.Format(" FROM ropoa_vehicle R LEFT JOIN (SELECT AssetNumber, price, repricing_code FROM tbl_repricing WHERE approved_date = '' AND `status` = 'ACTIVE' AND ropoa_type = 'VE' AND branch_id = '{0}') P ON R.AssetNumber = P.AssetNumber", Branch_ID)
        SQL &= "    LEFT JOIN (SELECT GREATEST(IFNULL(SUM(CASE WHEN `Type` = 'Add' THEN Amount END),0) - IFNULL(SUM(CASE WHEN `Type` = 'Deduct' THEN Amount END),0),0) AS 'Running', ReferenceN FROM (SELECT IF(EntryType = 'DEBIT',IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR PostStatus = 'PENDING' OR AccountTitleCode(AccountCode) LIKE '%IMPAIRMENT%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%','','Add'),IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%' OR PostStatus = 'PENDING','','Deduct')) AS 'Type', Amount, ReferenceN FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND MotherCode != '111000' GROUP BY ReferenceN) A GROUP BY ReferenceN) L ON L.ReferenceN = R.AssetNumber"
        If FromReprice Then
            If Batch Then
                SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND P.AssetNumber != '' AND P.repricing_code = '{1}' AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY PlateNum, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), RePricing_Code)
            Else
                SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND P.AssetNumber = '{1}' AND P.repricing_code = '{2}' AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY PlateNum, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), AssetNumber, RePricing_Code)
            End If
        Else
            SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY PlateNum, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If

        DT_VE = DataSource(SQL)
        DT_VE.Columns.Add("Image", GetType(Image))
        Dim item As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {
            .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch,
            .NullText = " "
        }
        GridView1.Columns("Image").ColumnEdit = item
        GridControl1.DataSource = DT_VE
        For x As Integer = 0 To GridView1.RowCount - 1
            Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetRowCellValue(x, "branch_code").ToString, GridView1.GetRowCellValue(x, "Asset Number").ToString, "Front1" & ".jpg")
            If Not IO.File.Exists(Path) Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetRowCellValue(x, "branch_code").ToString, GridView1.GetRowCellValue(x, "Asset Number").ToString, "Back2" & ".jpg")
            End If
            If Not IO.File.Exists(Path) Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetRowCellValue(x, "branch_code").ToString, GridView1.GetRowCellValue(x, "Asset Number").ToString, "Interior3" & ".jpg")
            End If
            If Not IO.File.Exists(Path) Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetRowCellValue(x, "branch_code").ToString, GridView1.GetRowCellValue(x, "Asset Number").ToString, "Engine4" & ".jpg")
            End If
            If Not IO.File.Exists(Path) Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetRowCellValue(x, "branch_code").ToString, GridView1.GetRowCellValue(x, "Asset Number").ToString, "Odometer5" & ".jpg")
            End If
            Try
                GridView1.SetRowCellValue(x, "Image", Image.FromFile(Path))
            Catch ex As Exception
                'TriggerBugReport(ex.Message.ToString)
            End Try
        Next
        GridView1.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        'Dim DT_Info As New DataTable
        'DT_Info = DataSource(String.Format("SELECT attachment, repricing_code, approved_date FROM tbl_repricing WHERE approved_date = '' AND `status` = 'ACTIVE' AND ropoa_type = 'VE' AND branch_id = '{0}'", Branch_ID))
        'If DT_Info.Rows.Count > 0 Then
        '    RePricing_Code = DT_Info(0)("repricing_code")
        '    TotalImage = DT_Info(0)("attachment")
        '    LastReprice = DT_Info(0)("approved_date")
        '    btnDraft.Text = "Update   &Draft"
        '    'If TotalImage > 0 Then
        '    '    btnSave.Enabled = True
        '    'End If
        'Else
        '    RePricing_Code = ""
        '    btnDraft.Text = "&Draft"
        'End If
    End Sub

    Private Sub LoadRealEstate()
        Dim SQL As String = "SELECT "
        SQL &= "     R.AssetNumber AS 'Asset Number', "
        SQL &= "     TCT AS 'TCT No.', "
        SQL &= "     Location, "
        SQL &= "     CONCAT(`Area`, ' SQM') AS 'Area', "
        SQL &= "     Classification, "
        'SQL &= "     Running_Balance(IF(account_count = 1,R.AssetNumber,R.TCT)) AS 'ROPOA Value', "
        SQL &= "     L.Running AS 'ROPOA Value', "
        SQL &= "     R.Price AS 'Price', "
        SQL &= "     IFNULL(P.Price,0) AS 'Suggested Price', "
        SQL &= "     0 AS 'Approved Price', "
        SQL &= "     branch_code,account_count,accountNo "
        'SQL &= " FROM ropoa_realestate R "
        SQL &= String.Format(" FROM ropoa_realestate R LEFT JOIN (SELECT AssetNumber, price, repricing_code from tbl_repricing where approved_date = '' and `status` = 'ACTIVE' AND ropoa_type = 'RE' and branch_id = '{0}') P ON R.AssetNumber = P.AssetNumber", Branch_ID)
        SQL &= "    LEFT JOIN (SELECT GREATEST(IFNULL(SUM(CASE WHEN `Type` = 'Add' THEN Amount END),0) - IFNULL(SUM(CASE WHEN `Type` = 'Deduct' THEN Amount END),0),0) AS 'Running', ReferenceN FROM (SELECT IF(EntryType = 'DEBIT',IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR PostStatus = 'PENDING' OR AccountTitleCode(AccountCode) LIKE '%IMPAIRMENT%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%','','Add'),IF(AccountTitleCode(AccountCode) LIKE '%GAIN ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LOSS ON SALE%' OR AccountTitleCode(AccountCode) LIKE '%LAND%' OR AccountTitleCode(AccountCode) LIKE '%TRANSPORTATION%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS PAYABLE%' OR AccountTitleCode(AccountCode) LIKE '%ACCOUNTS RECEIVABLE%' OR AccountTitleCode(AccountCode) LIKE '%UNREALIZED%' OR PostStatus = 'PENDING','','Deduct')) AS 'Type', Amount, ReferenceN FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND MotherCode != '111000' GROUP BY ReferenceN) A GROUP BY ReferenceN) L ON L.ReferenceN = R.AssetNumber"
        If FromReprice Then
            If Batch Then
                SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND P.AssetNumber != '' AND P.repricing_code = '{1}' AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY TCT, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), RePricing_Code)
            Else
                SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND P.AssetNumber = '{1}' AND P.repricing_code = '{2}' AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY TCT, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), AssetNumber, RePricing_Code)
            End If
        Else
            SQL &= String.Format(" WHERE sell_status = 'SELL' AND L.Running > 0 AND `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY TCT, Sell_Status, AccountID ORDER BY `Asset Number`;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If

        DT_RE = DataSource(SQL)
        DT_RE.Columns.Add("Image", GetType(Image))
        Dim item As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit() With {
            .SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch,
            .NullText = " "
        }
        GridView2.Columns("Image").ColumnEdit = item
        GridControl2.DataSource = DT_RE
        For x As Integer = 0 To GridView2.RowCount - 1
            Try
                Dim files() As String = IO.Directory.GetFiles(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, GridView2.GetRowCellValue(x, "branch_code").ToString, GridView2.GetRowCellValue(x, "Asset Number").ToString))
                Dim text As String = ""
                For Each file As String In files
                    text = IO.Path.GetFileName(file)
                    Exit For
                Next
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView2.GetRowCellValue(x, "branch_code").ToString, GridView2.GetRowCellValue(x, "Asset Number").ToString, text)

                GridView2.SetRowCellValue(x, "Image", Image.FromFile(Path))
            Catch ex As Exception
                'TriggerBugReport(ex.Message.ToString)
            End Try
        Next
        GridView2.Columns("Asset Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Asset Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        'Dim DT_Info As New DataTable
        'DT_Info = DataSource(String.Format("SELECT attachment, repricing_code, approved_date from tbl_repricing where approved_date = '' and `status` = 'ACTIVE' AND ropoa_type = 'RE' and branch_id = '{0}'", Branch_ID))
        'If DT_Info.Rows.Count > 0 Then
        '    RePricing_Code = DT_Info(0)("repricing_code")
        '    TotalImage = DT_Info(0)("attachment")
        '    LastReprice = DT_Info(0)("approved_date")
        '    btnDraft.Text = "Update   &Draft"
        '    'If TotalImage > 0 Then
        '    '    btnSave.Enabled = True
        '    'End If
        'Else
        '    RePricing_Code = ""
        '    btnDraft.Text = "&Draft"
        'End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmROPOA_Repricing_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.I Then
            btnPrintIndi.Focus()
            btnPrintIndi.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAttach.Focus()
            btnAttach.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnRemove.Focus()
            btnRemove.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            LastReprice = DataObject(String.Format("SELECT approved_date from tbl_repricing where approved_date != '' and `status` = 'ACTIVE' AND ropoa_type = 'VE' and branch_id = '{0}'", Branch_ID))
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LastReprice = DataObject(String.Format("SELECT approved_date from tbl_repricing where approved_date != '' and `status` = 'ACTIVE' AND ropoa_type = 'RE' and branch_id = '{0}'", Branch_ID))
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If CDbl(GridView1.GetRowCellValue(x, "Approved Price")) = 0 Or GridView1.GetRowCellValue(x, "Approved Price").ToString = "" Then
                    GridView1.SetRowCellValue(x, "Approved Price", 0)
                End If
            Next
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA VL REPRICING LIST", GridControl1)
        Else
            For x As Integer = 0 To GridView2.RowCount - 1
                If CDbl(GridView2.GetRowCellValue(x, "Approved Price")) = 0 Or GridView2.GetRowCellValue(x, "Approved Price").ToString = "" Then
                    GridView2.SetRowCellValue(x, "Approved Price", 0)
                End If
            Next
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA RE REPRICING LIST", GridControl2)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If CDbl(GridView1.GetRowCellValue(x, "Approved Price")) = 0 Then
                    If MsgBoxYes("There is a zero approved price in this repricing, this will automatically set the ROPOA to scrap value, would you like to proceed?") = MsgBoxResult.Yes Then
                        Exit For
                    End If
                End If
            Next
            Dim SQL As String = ""
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If MsgBoxYes("Are you sure you want to save the approved price of ROPOA Vehicle?") = MsgBoxResult.Yes Then
                    'VEHICLE
                    Dim ApprovedDate As String = Format(Date.Now, "yyyy-MM-dd")
                    For x As Integer = 0 To GridView1.RowCount - 1
                        If CDbl(GridView1.GetRowCellValue(x, "Price")) = CDbl(GridView1.GetRowCellValue(x, "Approved Price")) Then
                            'If Price = Approved then wala ra impairment loss zero ang amount
                            Dim SQL_II As String = ""
                            Dim LedgerCode As String
                            If GridView1.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                Dim DT As New DataTable
                                DT = DataSource(String.Format("SELECT AssetNumber FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum")))
                                For y As Integer = 0 To DT.Rows.Count - 1
                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                    SQL_II &= " ropoa_type = 'Vehicle', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= " amount = 0, "
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)
                                Next
                                SQL &= String.Format("UPDATE tbl_repricing SET approved_date = '{1}', approved_price = '{2}' WHERE repricing_code = '{0}' AND AssetNumber = '{3}';", RePricing_Code, ApprovedDate, CDbl(GridView1.GetRowCellValue(x, "Approved Price")), GridView1.GetRowCellValue(x, "Asset Number"))
                            Else
                                LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                SQL_II = "INSERT INTO ledger_ropoa SET"
                                SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                SQL_II &= String.Format(" asset_number = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number").ToString)
                                SQL_II &= " ropoa_type = 'Vehicle', "
                                SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                SQL_II &= " trans_id = '2', "
                                SQL_II &= " `transaction` = 'Impairment Loss', "
                                SQL_II &= " remarks = '', "
                                SQL_II &= " `reference_number` = '', "
                                SQL_II &= " `type` = 'Deduct', "
                                SQL_II &= " amount = 0, "
                                SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                DataObject(SQL_II)
                                SQL &= String.Format("UPDATE tbl_repricing SET approved_date = '{1}', approved_price = '{2}' WHERE repricing_code = '{0}' AND AssetNumber = '{3}';", RePricing_Code, ApprovedDate, CDbl(GridView1.GetRowCellValue(x, "Approved Price")), GridView1.GetRowCellValue(x, "Asset Number"))
                            End If
                        Else
                            If RePricing_Code = "" Then
                                '#TBL_REPRICING Table
                                Dim RepricingNum As String = DataObject(String.Format("SELECT CONCAT('RP-VE[', '{1}', ']-', LPAD(COUNT(DISTINCT repricing_code) + 1,8,'0')) FROM tbl_repricing WHERE branch_id = '{0}' AND ropoa_type = 'VE'", Branch_ID, Branch_Code))
                                RePricing_Code = RepricingNum
                                SQL &= "INSERT INTO tbl_repricing SET "
                                SQL &= String.Format("  repricing_code = '{0}', ", RepricingNum)
                                SQL &= String.Format("  AssetNumber = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number"))
                                SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")))
                                SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Price")))
                                SQL &= String.Format("  price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Suggested Price")))
                                SQL &= String.Format("  approved_price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                SQL &= "  ropoa_type = 'VE', "
                                SQL &= String.Format("  approved_date = '{0}', ", ApprovedDate)
                                SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                                SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                            Else
                                SQL &= String.Format("UPDATE tbl_repricing SET approved_date = '{1}', approved_price = '{2}' WHERE repricing_code = '{0}' AND AssetNumber = '{3}';", RePricing_Code, ApprovedDate, CDbl(GridView1.GetRowCellValue(x, "Approved Price")), GridView1.GetRowCellValue(x, "Asset Number"))
                            End If

                            If CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) > CDbl(GridView1.GetRowCellValue(x, "Approved Price")) And CDbl(GridView1.GetRowCellValue(x, "Approved Price")) > 0 Then
                                'If ROPOA Value > Approved Price then Impairment Loss of difference sa ROPOA Value og Approved Price
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView1.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',PlateNum FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum")))

                                    Dim Distribute As New FrmAccountDistribute With {
                                        .DT_Account = DT,
                                        .Amount = CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price")),
                                        .Info = "[" & GridView1.GetRowCellValue(x, "Make").ToString & "][" & GridView1.GetRowCellValue(x, "Model").ToString & "][" & GridView1.GetRowCellValue(x, "PlateNum").ToString & "]"
                                     }
                                    If Distribute.ShowDialog = DialogResult.OK Then
                                        For y As Integer = 0 To Distribute.DT_Account.Rows.Count - 1
                                            For z As Integer = 0 To DT.Rows.Count - 1
                                                If DT(z)("AccountNo") = Distribute.DT_Account(y)("AccountNo") Then
                                                    DT(z)("Amount") = Distribute.DT_Account(y)("Amount")
                                                End If
                                            Next
                                        Next
                                    Else
                                        For y As Integer = 0 To DT.Rows.Count - 1
                                            DT(y)("Amount") = (CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price"))) / DT.Rows.Count
                                        Next
                                    End If
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        Dim Impairment As New FrmImpairmentSchedule
                                        Dim First_Date As String = ""
                                        Dim First_Amount As Double
                                        With Impairment
                                            .lblAssetN.Text = DT(y)("AssetNumber").ToString
                                            .lblPlateN.Text = DT(y)("PlateNum").ToString
                                            .lblAccountN.Text = DT(y)("AccountNo").ToString
                                            .dImpairment.Value = CDbl(DT(y)("Amount"))
                                            .Type = "VL"
                                            If .ShowDialog = DialogResult.OK Then
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            Else
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            End If
                                            Impairment.Dispose()
                                        End With

                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Vehicle', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}' WHERE PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                Else
                                    Dim Impairment As New FrmImpairmentSchedule
                                    Dim First_Date As String = ""
                                    Dim First_Amount As Double
                                    With Impairment
                                        .lblAssetN.Text = GridView1.GetRowCellValue(x, "Asset Number").ToString
                                        .lblPlateN.Text = GridView1.GetRowCellValue(x, "PlateNum").ToString
                                        .lblAccountN.Text = GridView1.GetRowCellValue(x, "accountNo").ToString
                                        .dImpairment.Value = CDbl(CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                        .Type = "VL"
                                        If .ShowDialog = DialogResult.OK Then
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        Else
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        End If
                                        .Dispose()
                                    End With

                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Vehicle', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)

                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}' WHERE AssetNumber = '{0}';", GridView1.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                End If
                            ElseIf CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) < CDbl(GridView1.GetRowCellValue(x, "Approved Price")) And CDbl(GridView1.GetRowCellValue(x, "Approved Price")) > 0 Then
                                'If ROPOA Value < Approved Price then wala ra impairment loss zero ang amount
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView1.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum")))
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Vehicle', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= " amount = 0, "
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}' WHERE PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                Else
                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Vehicle', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= " amount = 0, "
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)

                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}' WHERE AssetNumber = '{0}';", GridView1.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                End If
                            ElseIf CDbl(GridView1.GetRowCellValue(x, "Approved Price")) = 0 Then
                                'If Approved Price = 0 then scrap impairment loss ang ROPOA Value
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView1.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}', sell_status = 'SCRAP' WHERE PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',PlateNum FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", GridView1.GetRowCellValue(x, "PlateNum")))

                                    Dim Distribute As New FrmAccountDistribute
                                    With Distribute
                                        .DT_Account = DT
                                        .Amount = CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price"))
                                        .Info = "[" & GridView1.GetRowCellValue(x, "Make").ToString & "][" & GridView1.GetRowCellValue(x, "Model").ToString & "][" & GridView1.GetRowCellValue(x, "PlateNum").ToString & "]"

                                        If .ShowDialog = DialogResult.OK Then
                                            For y As Integer = 0 To .DT_Account.Rows.Count - 1
                                                For z As Integer = 0 To DT.Rows.Count - 1
                                                    If DT(z)("AccountNo") = .DT_Account(y)("AccountNo") Then
                                                        DT(z)("Amount") = .DT_Account(y)("Amount")
                                                    End If
                                                Next
                                            Next
                                        Else
                                            For y As Integer = 0 To DT.Rows.Count - 1
                                                DT(y)("Amount") = (CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price"))) / DT.Rows.Count
                                            Next
                                        End If
                                        .Dispose()
                                    End With
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        Dim Impairment As New FrmImpairmentSchedule
                                        Dim First_Date As String = ""
                                        Dim First_Amount As Double
                                        With Impairment
                                            .lblAssetN.Text = DT(y)("AssetNumber").ToString
                                            .lblPlateN.Text = DT(y)("PlateNum").ToString
                                            .lblAccountN.Text = DT(y)("AccountNo").ToString
                                            .dImpairment.Value = CDbl(DT(y)("Amount"))
                                            .Type = "VL"
                                            .iMonths.Value = 1
                                            If .ShowDialog = DialogResult.OK Then
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            Else
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            End If
                                            Impairment.Dispose()
                                        End With

                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Vehicle', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                Else
                                    Dim Impairment As New FrmImpairmentSchedule
                                    Dim First_Date As String = ""
                                    Dim First_Amount As Double
                                    With Impairment
                                        .lblAssetN.Text = GridView1.GetRowCellValue(x, "Asset Number").ToString
                                        .lblPlateN.Text = GridView1.GetRowCellValue(x, "PlateNum").ToString
                                        .lblAccountN.Text = GridView1.GetRowCellValue(x, "accountNo").ToString
                                        .dImpairment.Value = CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView1.GetRowCellValue(x, "Approved Price"))
                                        .Type = "VL"
                                        .iMonths.Value = 1
                                        If .ShowDialog = DialogResult.OK Then
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        Else
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        End If
                                        Impairment.Dispose()
                                    End With

                                    SQL &= String.Format("UPDATE ropoa_vehicle SET price = '{1}', sell_status = 'SCRAP' WHERE AssetNumber = '{0}';", GridView1.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView1.GetRowCellValue(x, "Approved Price")))

                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Vehicle', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView1.GetRowCellValue(x, "account_count").ToString > 1, GridView1.GetRowCellValue(x, "PlateNum").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)
                                End If
                                Logs("ROPOA Repricing", "Auto Scrap", String.Format("Repricing of ROPOA Vehicle Asset Number {0} from {1} to {2} and is now scrapped.", GridView1.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView1.GetRowCellValue(x, "Price")), CDbl(GridView1.GetRowCellValue(x, "Approved Price"))), "", "", "", "")
                            End If
                            '#ROPOA_VEHICLE Table
                            Logs("ROPOA Repricing", "Save", String.Format("Repricing of ROPOA Vehicle Asset Number {0} from {1} to {2}.", GridView1.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView1.GetRowCellValue(x, "Price")), CDbl(GridView1.GetRowCellValue(x, "Approved Price"))), "", "", "", "")
                        End If
                    Next
                    If SQL = "" Then
                    Else
                        DataObject(SQL)
                    End If
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                If MsgBoxYes("Are you sure you want to save the approved price of ROPOA Real Estate?") = MsgBoxResult.Yes Then
                    'Real Estate
                    Dim ApprovedDate As String = Format(Date.Now, "yyyy-MM-dd")
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If CDbl(GridView2.GetRowCellValue(x, "Price")) = CDbl(GridView2.GetRowCellValue(x, "Approved Price")) Then
                            'If Price = Approved then wala ra impairment loss zero ang amount
                            Dim SQL_II As String = ""
                            Dim LedgerCode As String
                            If GridView2.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.")))
                                For y As Integer = 0 To DT.Rows.Count - 1
                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                    SQL_II &= " ropoa_type = 'Real Estate', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= " amount = 0, "
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)
                                Next
                                SQL &= String.Format("UPDATE tbl_repricing SET approved_date = '{1}', approved_price = '{2}' WHERE repricing_code = '{0}' AND AssetNumber = '{3}';", RePricing_Code, ApprovedDate, CDbl(GridView2.GetRowCellValue(x, "Approved Price")), GridView2.GetRowCellValue(x, "Asset Number"))
                            Else
                                LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                SQL_II = "INSERT INTO ledger_ropoa SET"
                                SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                SQL_II &= String.Format(" asset_number = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number").ToString)
                                SQL_II &= " ropoa_type = 'Real Estate', "
                                SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                SQL_II &= " trans_id = '2', "
                                SQL_II &= " `transaction` = 'Impairment Loss', "
                                SQL_II &= " remarks = '', "
                                SQL_II &= " `reference_number` = '', "
                                SQL_II &= " `type` = 'Deduct', "
                                SQL_II &= " amount = 0, "
                                SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                DataObject(SQL_II)
                            End If
                        Else
                            If RePricing_Code = "" Then
                                '#TBL_REPRICING Table
                                Dim RepricingNum As String = DataObject(String.Format("SELECT CONCAT('RP-RE[', '{1}', ']-', LPAD(COUNT(DISTINCT repricing_code) + 1,8,'0')) FROM tbl_repricing WHERE branch_id = '{0}' AND ropoa_type = 'RE'", Branch_ID, Branch_Code))
                                RePricing_Code = RepricingNum
                                SQL &= "INSERT INTO tbl_repricing SET "
                                SQL &= String.Format("  repricing_code = '{0}', ", RepricingNum)
                                SQL &= String.Format("  AssetNumber = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number"))
                                SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")))
                                SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Price")))
                                SQL &= String.Format("  price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Suggested Price")))
                                SQL &= String.Format("  approved_price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                SQL &= "  ropoa_type = 'RE', "
                                SQL &= String.Format("  approved_date = '{0}', ", ApprovedDate)
                                SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                                SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                            Else
                                SQL &= String.Format("UPDATE tbl_repricing SET approved_date = '{1}', approved_price = '{2}' WHERE repricing_code = '{0}' AND AssetNumber = '{3}';", RePricing_Code, ApprovedDate, CDbl(GridView2.GetRowCellValue(x, "Approved Price")), GridView2.GetRowCellValue(x, "Asset Number"))
                            End If

                            If CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) > CDbl(GridView2.GetRowCellValue(x, "Approved Price")) And CDbl(GridView2.GetRowCellValue(x, "Approved Price")) > 0 Then
                                'If ROPOA Value > Approved Price then Impairment Loss of difference sa ROPOA Value og Approved Price
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView2.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',TCT FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.")))

                                    Dim Distribute As New FrmAccountDistribute
                                    With Distribute
                                        .DT_Account = DT
                                        .Amount = CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price"))
                                        .Info = "[" & GridView2.GetRowCellValue(x, "TCT No.").ToString & "][" & GridView2.GetRowCellValue(x, "Location").ToString & "][" & GridView2.GetRowCellValue(x, "Area").ToString & "]"

                                        If .ShowDialog = DialogResult.OK Then
                                            For y As Integer = 0 To .DT_Account.Rows.Count - 1
                                                For z As Integer = 0 To DT.Rows.Count - 1
                                                    If DT(z)("AccountNo") = .DT_Account(y)("AccountNo") Then
                                                        DT(z)("Amount") = .DT_Account(y)("Amount")
                                                    End If
                                                Next
                                            Next
                                        Else
                                            For y As Integer = 0 To DT.Rows.Count - 1
                                                DT(y)("Amount") = (CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price"))) / DT.Rows.Count
                                            Next
                                        End If
                                        .Dispose()
                                    End With
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        Dim Impairment As New FrmImpairmentSchedule
                                        Dim First_Date As String = ""
                                        Dim First_Amount As Double
                                        With Impairment
                                            .lblAssetN.Text = DT(y)("AssetNumber").ToString
                                            .lblPlateN.Text = DT(y)("TCT").ToString
                                            .lblAccountN.Text = DT(y)("AccountNo").ToString
                                            .dImpairment.Value = CDbl(DT(y)("Amount"))
                                            .Type = "RE"
                                            If .ShowDialog = DialogResult.OK Then
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            Else
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            End If
                                            .Dispose()
                                        End With

                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Real Estate', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                    SQL &= String.Format("UPDATE ropoa_realestate SET price = '{1}' WHERE TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                Else
                                    Dim Impairment As New FrmImpairmentSchedule
                                    Dim First_Date As String = ""
                                    Dim First_Amount As Double
                                    With Impairment
                                        .lblAssetN.Text = GridView2.GetRowCellValue(x, "Asset Number").ToString
                                        .lblPlateN.Text = GridView2.GetRowCellValue(x, "TCT No.").ToString
                                        .lblAccountN.Text = GridView2.GetRowCellValue(x, "accountNo").ToString
                                        .dImpairment.Value = CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price"))
                                        .Type = "RE"
                                        If .ShowDialog = DialogResult.OK Then
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        Else
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        End If
                                        .Dispose()
                                    End With

                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Real Estate', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)

                                    SQL &= String.Format("UPDATE ropoa_REALESTATE SET price = '{1}' WHERE AssetNumber = '{0}';", GridView2.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                End If
                            ElseIf CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) < CDbl(GridView2.GetRowCellValue(x, "Approved Price")) And CDbl(GridView2.GetRowCellValue(x, "Approved Price")) > 0 Then
                                'If ROPOA Value < Approved Price then wala ra impairment loss zero ang amount
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView2.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.")))
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Real Estate', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= " amount = 0, "
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                    SQL &= String.Format("UPDATE ropoa_realestate SET price = '{1}' WHERE TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                Else
                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Real Estate', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= " amount = 0, "
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)

                                    SQL &= String.Format("UPDATE ropoa_realestate SET price = '{1}' WHERE AssetNumber = '{0}';", GridView2.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                End If
                            ElseIf CDbl(GridView2.GetRowCellValue(x, "Approved Price")) = 0 Then
                                'If Approved Price = 0 then scrap impairment loss ang ROPOA Value
                                Dim SQL_II As String = ""
                                Dim LedgerCode As String
                                If GridView2.GetRowCellValue(x, "account_count") > 1 Then 'Multiple
                                    SQL &= String.Format("UPDATE ropoa_realestate SET price = '{1}', sell_status = 'SCRAP' WHERE TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                    Dim DT As DataTable = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',TCT FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", GridView2.GetRowCellValue(x, "TCT No.")))

                                    Dim Distribute As New FrmAccountDistribute
                                    With Distribute
                                        .DT_Account = DT
                                        .Amount = CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price"))
                                        .Info = "[" & GridView2.GetRowCellValue(x, "TCT No.").ToString & "][" & GridView2.GetRowCellValue(x, "Location").ToString & "][" & GridView2.GetRowCellValue(x, "Area").ToString & "]"

                                        If .ShowDialog = DialogResult.OK Then
                                            For y As Integer = 0 To .DT_Account.Rows.Count - 1
                                                For z As Integer = 0 To DT.Rows.Count - 1
                                                    If DT(z)("AccountNo") = .DT_Account(y)("AccountNo") Then
                                                        DT(z)("Amount") = .DT_Account(y)("Amount")
                                                    End If
                                                Next
                                            Next
                                        Else
                                            For y As Integer = 0 To DT.Rows.Count - 1
                                                DT(y)("Amount") = (CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price"))) / DT.Rows.Count
                                            Next
                                        End If
                                        .Dispose()
                                    End With
                                    For y As Integer = 0 To DT.Rows.Count - 1
                                        Dim Impairment As New FrmImpairmentSchedule
                                        Dim First_Date As String = ""
                                        Dim First_Amount As Double
                                        With Impairment
                                            .lblAssetN.Text = DT(y)("AssetNumber").ToString
                                            .lblPlateN.Text = DT(y)("TCT").ToString
                                            .lblAccountN.Text = DT(y)("AccountNo").ToString
                                            .dImpairment.Value = CDbl(DT(y)("Amount"))
                                            .Type = "RE"
                                            .iMonths.Value = 1
                                            If .ShowDialog = DialogResult.OK Then
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            Else
                                                First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                                First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                            End If
                                            .Dispose()
                                        End With

                                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                        SQL_II = "INSERT INTO ledger_ropoa SET"
                                        SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                        SQL_II &= String.Format(" asset_number = '{0}', ", DT(y)("AssetNumber").ToString)
                                        SQL_II &= " ropoa_type = 'Real Estate', "
                                        SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                        SQL_II &= " trans_id = '2', "
                                        SQL_II &= " `transaction` = 'Impairment Loss', "
                                        SQL_II &= " remarks = '', "
                                        SQL_II &= " `reference_number` = '', "
                                        SQL_II &= " `type` = 'Deduct', "
                                        SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                        SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                        SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                        SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                        SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                        DataObject(SQL_II)
                                    Next
                                Else
                                    Dim Impairment As New FrmImpairmentSchedule
                                    Dim First_Date As String = ""
                                    Dim First_Amount As Double
                                    With Impairment
                                        .lblAssetN.Text = GridView2.GetRowCellValue(x, "Asset Number").ToString
                                        .lblPlateN.Text = GridView2.GetRowCellValue(x, "TCT No.").ToString
                                        .lblAccountN.Text = GridView2.GetRowCellValue(x, "accountNo").ToString
                                        .dImpairment.Value = CDbl(CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")) - CDbl(GridView2.GetRowCellValue(x, "Approved Price")))
                                        .Type = "RE"
                                        .iMonths.Value = 1
                                        If .ShowDialog = DialogResult.OK Then
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        Else
                                            First_Date = Format(CDate(.GridView1.GetRowCellValue(0, "Month")), "yyyy-MM-dd")
                                            First_Amount = CDbl(.GridView1.GetRowCellValue(0, "Amount"))
                                        End If
                                        .Dispose()
                                    End With

                                    SQL &= String.Format("UPDATE ropoa_realestate SET price = '{1}', sell_status = 'SCRAP' WHERE AssetNumber = '{0}';", GridView2.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView2.GetRowCellValue(x, "Approved Price")))

                                    LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                                    SQL_II = "INSERT INTO ledger_ropoa SET"
                                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                                    SQL_II &= String.Format(" asset_number = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number").ToString)
                                    SQL_II &= " ropoa_type = 'Real Estate', "
                                    SQL_II &= String.Format(" trans_date = '{0}', ", First_Date)
                                    SQL_II &= " trans_id = '2', "
                                    SQL_II &= " `transaction` = 'Impairment Loss', "
                                    SQL_II &= " remarks = '', "
                                    SQL_II &= " `reference_number` = '', "
                                    SQL_II &= " `type` = 'Deduct', "
                                    SQL_II &= String.Format(" amount = '{0}', ", First_Amount)
                                    SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                                    SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                                    SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(GridView2.GetRowCellValue(x, "account_count").ToString > 1, GridView2.GetRowCellValue(x, "TCT No.").ToString, ""))
                                    SQL_II &= " approve_status = 'APPROVED', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '';"
                                    DataObject(SQL_II)
                                End If
                                Logs("ROPOA Repricing", "Auto Scrap", String.Format("Repricing of ROPOA Real Estate Asset Number {0} from {1} to {2} and is now scrapped.", GridView2.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView2.GetRowCellValue(x, "Price")), CDbl(GridView2.GetRowCellValue(x, "Approved Price"))), "", "", "", "")
                            End If
                            '#ROPOA_REALESTATE Table
                            Logs("ROPOA Repricing", "Save", String.Format("Repricing of ROPOA Real Estate Asset Number {0} from {1} to {2}.", GridView2.GetRowCellValue(x, "Asset Number").ToString, CDbl(GridView2.GetRowCellValue(x, "Price")), CDbl(GridView2.GetRowCellValue(x, "Approved Price"))), "", "", "", "")
                        End If
                    Next
                    If SQL = "" Then
                    Else
                        DataObject(SQL)
                    End If
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                LoadVehicle()
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                LoadRealEstate()
            End If
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.RowCount > 0 Then
            Dim DT As DataTable = DataSource(String.Format("SELECT trans_date AS 'Date', PlateNum AS 'Plate Number', Series, BodyColor AS 'Body Color', EngineNum AS 'Engine Number', ChassisNum AS 'Chassis Number', RegistryCert AS 'Registry Certificate', ORNum AS 'OR Number', GrossWeight AS 'Gross Weight', RimHoles AS 'Rim Holes', Remarks, Img, `Condition`, ConditionReason, DateRegistered, LTO FROM ropoa_vehicle WHERE AssetNumber = '{0}' LIMIT 1;", GridView1.GetFocusedRowCellValue("Asset Number").ToString))
            If DT.Rows.Count > 0 Then
                Dim Report As New RptVehicleROPOA
                With Report
                    .Name = GridView1.GetFocusedRowCellValue("Asset Number").ToString
                    .lblDate.Text = DT(0)("Date").ToString
                    .lblAssetNumber.Text = GridView1.GetFocusedRowCellValue("Asset Number").ToString
                    .lblSOLD.Visible = False
                    .lblCondition.Text = DT(0)("Condition").ToString
                    .lblReason.Text = DT(0)("ConditionReason").ToString
                    .lblMake.Text = GridView1.GetFocusedRowCellValue("Make").ToString
                    .lblType.Text = GridView1.GetFocusedRowCellValue("Type").ToString
                    .lblEngine.Text = GridView1.GetFocusedRowCellValue("Model").ToString & " " & DT(0)("Series").ToString
                    .lblPlateNumber.Text = DT(0)("Plate Number").ToString
                    .lblTransmission.Text = GridView1.GetFocusedRowCellValue("Transmission").ToString
                    .lblGasoline.Text = GridView1.GetFocusedRowCellValue("Fuel").ToString
                    .lblBodyColor.Text = DT(0)("Body Color").ToString
                    .lblYear.Text = GridView1.GetFocusedRowCellValue("Year").ToString
                    .lblMotorNumber.Text = DT(0)("Engine Number").ToString
                    .lblSerialNumber.Text = DT(0)("Chassis Number").ToString
                    .lblRegCertNumber.Text = DT(0)("Registry Certificate").ToString
                    .lblORNumber.Text = DT(0)("OR Number").ToString
                    .lblGrossWeight.Text = DT(0)("Gross Weight").ToString & " kgs"
                    .lblRim.Text = DT(0)("Rim Holes").ToString
                    .lblMileAge.Text = GridView1.GetFocusedRowCellValue("Mile Age").ToString
                    .lblPrice.Text = ""
                    .XrLabel35.Text = ""
                    .lblLastRegistered.Text = DT(0)("DateRegistered").ToString
                    .lblLTO.Text = DT(0)("LTO").ToString
                    .lblRemarks.Text = DT(0)("Remarks").ToString

                    Dim xPos As Integer = 1
                    If DT(0)("Img").ToString > 0 Then
                        For x As Integer = 1 To DT(0)("Img").ToString
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
                                .Sizing = ImageSizeMode.StretchImage,
                                .Borders = BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .Text = pB_Dev.Properties.NullText.ToString,
                                .SizeF = New Size(375, 15),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(412.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            Else
                                pB.Location = New Point(12.5, 225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                                lblImage.Location = New Point(12.5, (225 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                            End If
                            Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetFocusedRowCellValue("branch_code").ToString, GridView1.GetFocusedRowCellValue("Asset Number").ToString, pB_Dev.Properties.NullText & x & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("ROPA Repricing - DoubleClick", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                TempPB.Dispose()
                                xPos += 1
                            End If
                            .ShowPreview()
                        Next
                    End If
                    Logs("Vehicle ROPOA", "Print", String.Format("Print/Preview Vehicle ROPOA with Asset Number {0}", GridView1.GetFocusedRowCellValue("Asset Number").ToString), "", "", "", "")
                End With
            End If
        End If
    End Sub

    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        If GridView2.RowCount > 0 Then
            Dim DT As DataTable = DataSource(String.Format("SELECT trans_date AS 'Date', VacantLot AS 'Vacant Lot', Storey AS 'Storeys', Roofings, Flooring AS 'Floorings', TandB AS 'T and B', Frame, Beams, Doors, YearConstructed AS 'Yr Constructed', Walling AS 'Wallings', `Ceiling` AS 'Ceilings', Windows, FloorArea AS 'Floor Area', `Partitions`, Remarks, Img FROM ropoa_realestate WHERE AssetNumber = '{0}' LIMIT 1;", GridView2.GetFocusedRowCellValue("Asset Number").ToString))
            If DT.Rows.Count > 0 Then
                Dim Report As New RptRealEstateROPOA
                With Report
                    .Name = GridView2.GetFocusedRowCellValue("Asset Number").ToString
                    .lblDate.Text = DT(0)("Date").ToString
                    .lblAssetNumber.Text = GridView2.GetFocusedRowCellValue("Asset Number").ToString
                    .lblSOLD.Visible = False
                    .lblTCT.Text = GridView2.GetFocusedRowCellValue("TCT No.").ToString
                    .lblLocation.Text = GridView2.GetFocusedRowCellValue("Location").ToString
                    .lblArea.Text = GridView2.GetFocusedRowCellValue("Area").ToString
                    If GridView2.GetFocusedRowCellValue("Classification").ToString = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification").ToString = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification").ToString = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf GridView2.GetFocusedRowCellValue("Classification").ToString = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblPrice.Text = ""
                    .XrLabel7.Text = ""
                    If DT(0)("Vacant Lot").ToString = "YES" Then
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
                        .lblStorey.Text = DT(0)("Storeys").ToString
                        .lblRoofings.Text = DT(0)("Roofings").ToString
                        .lblFloorings.Text = DT(0)("Floorings").ToString
                        .lblTandB.Text = DT(0)("T and B").ToString
                        .lblFrames.Text = DT(0)("Frame").ToString
                        .lblBeams.Text = DT(0)("Beams").ToString
                        .lblDoors.Text = DT(0)("Doors").ToString
                        .lblYear.Text = DT(0)("Yr Constructed").ToString
                        .lblWalling.Text = DT(0)("Wallings").ToString
                        .lblCeiling.Text = DT(0)("Ceilings").ToString
                        .lblWindows.Text = DT(0)("Windows").ToString
                        .lblFloorArea.Text = DT(0)("Floor Area").ToString
                        .lblPartitions.Text = DT(0)("Partitions").ToString
                    End If
                    .lblRemarks.Text = DT(0)("Remarks").ToString

                    Dim xPos As Integer = 1
                    If DT(0)("Img").ToString > 0 Then
                        For x As Integer = 1 To DT(0)("Img").ToString
                            Dim pB As New XRPictureBox With {
                                .Size = New Size(375, 235),
                                .Sizing = ImageSizeMode.StretchImage,
                                .Borders = BorderSide.All
                            }
                            '***ADD LABEL***'
                            Dim lblImage As New XRLabel With {
                                .SizeF = New Size(375, 10),
                                .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                                .TextAlignment = TextAlignment.MiddleCenter
                            }
                            '***ADD LABEL***'
                            If xPos Mod 2 = 0 Then
                                pB.Location = New Point(412.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                lblImage.Location = New Point(412.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                            Else
                                pB.Location = New Point(12.5, 15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                                lblImage.Location = New Point(12.5, (15 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                            End If
                            Dim Path As String
                            Dim FileN As String = ""
                            If x > 5 Then
                                FileN = "Image" & x
                                lblImage.Text = ""
                            Else
                                If x Mod 5 = 1 Then
                                    FileN = "Picture of Property" & x
                                    lblImage.Text = "Picture of Property"
                                ElseIf x Mod 5 = 2 Then
                                    FileN = "Sketch Plan" & x
                                    lblImage.Text = "Sketch Plan"
                                ElseIf x Mod 5 = 3 Then
                                    FileN = "Location Map" & x
                                    lblImage.Text = "Location Map"
                                ElseIf x Mod 5 = 4 Then
                                    FileN = "Vicinity Map" & x
                                    lblImage.Text = "Vicinity Map"
                                ElseIf x Mod 5 = 0 Then
                                    FileN = "Right of Way" & x
                                    lblImage.Text = "Right of Way"
                                End If
                            End If
                            Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code").ToString, GridView2.GetFocusedRowCellValue("Asset Number").ToString, FileN & ".jpg")
                            If IO.File.Exists(Path) Then
                                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                                Try
                                    TempPB.Image = Image.FromFile(Path)
                                Catch ex As Exception
                                    TriggerBugReport("ROPA Repricing - DoubleClick", ex.Message.ToString)
                                End Try
                                pB.Image = TempPB.Image
                                TempPB.Dispose()
                                .Detail.Controls.Add(pB)
                                .Detail.Controls.Add(lblImage)
                                xPos += 1
                            End If
                        Next
                    Else
                    End If
                    Logs("Real Estate ROPOA", "Print", String.Format("Print/Preview Real Estate ROPOA with Asset Number {0}", GridView2.GetFocusedRowCellValue("Asset Number").ToString), "", "", "", "")
                    .ShowPreview()
                End With
            End If
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            If RePricing_Code = "" Then
                Dim RepricingNum As String = ""
                RepricingNum = DataObject(String.Format("SELECT CONCAT('RP-VE[', '{1}', ']-', LPAD(COUNT(repricing_code) + 1,8,'0')) FROM tbl_repricing WHERE branch_id = '{0}' AND ropoa_type = 'VE' GROUP BY repricing_code", Branch_ID, Branch_Code))
                .ID = RepricingNum
                .FolderName = RepricingNum
            Else
                .ID = RePricing_Code
                .FolderName = RePricing_Code
            End If
            .TotalImage = TotalImage
            .Type = "Repricing"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                btnSave.Enabled = True
                btnDraft.Enabled = False
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 0 Then
                    GridColumn21.OptionsColumn.AllowEdit = False
                    GridColumn9.OptionsColumn.AllowEdit = True
                Else
                    GridColumn27.OptionsColumn.AllowEdit = False
                    GridColumn23.OptionsColumn.AllowEdit = True
                End If
            ElseIf Result = DialogResult.Yes Then
                btnSave.Enabled = False
                btnDraft.Enabled = True
                TotalImage = .TotalImage
                If SuperTabControl1.SelectedTabIndex = 0 Then
                    GridColumn21.OptionsColumn.AllowEdit = True
                    GridColumn9.OptionsColumn.AllowEdit = False
                Else
                    GridColumn27.OptionsColumn.AllowEdit = True
                    GridColumn23.OptionsColumn.AllowEdit = False
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles btnDraft.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim SQL As String = ""
        For x As Integer = 0 To GridView1.RowCount - 1
            If CDbl(GridView1.GetRowCellValue(x, "Suggested Price")) = 0 Then
                If MsgBoxYes("There is a zero suggested price in this draft, would you like to proceed?") = MsgBoxResult.Yes Then
                    Exit For
                End If
            End If
        Next
        If btnDraft.Text = "&Draft" Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If MsgBoxYes("Are you sure you want to save the suggested price of ROPOA Vehicle?") = MsgBoxResult.Yes Then
                    'VEHICLE
                    Dim RepricingNum As String = DataObject(String.Format("SELECT CONCAT('RP-VE[', '{1}', ']-', LPAD(COUNT(DISTINCT repricing_code) + 1,8,'0')) FROM tbl_repricing WHERE branch_id = '{0}' AND ropoa_type = 'VE'", Branch_ID, Branch_Code))
                    RePricing_Code = RepricingNum
                    For x As Integer = 0 To GridView1.RowCount - 1
                        SQL &= "INSERT INTO tbl_repricing SET "
                        SQL &= String.Format("  repricing_code = '{0}', ", RepricingNum)
                        SQL &= String.Format("  AssetNumber = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number"))
                        SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                        SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")))
                        SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Price")))
                        SQL &= String.Format("  price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Suggested Price")))
                        SQL &= "  ropoa_type = 'VE', "
                        SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                        SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                    Next
                    DataObject(SQL)
                    Logs("ROPOA VE Repricing", "Draft", "Create ROPOA Vehicle repricing draft.", "", "", "", "")
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                If MsgBoxYes("Are you sure you want to save the suggested price of ROPOA Real Estate?") = MsgBoxResult.Yes Then
                    'REAL ESTATE
                    Dim RepricingNum As String = DataObject(String.Format("SELECT CONCAT('RP-RE[', '{1}', ']-', LPAD(COUNT(DISTINCT repricing_code) + 1,8,'0')) FROM tbl_repricing WHERE branch_id = '{0}' AND ropoa_type = 'RE'", Branch_ID, Branch_Code))
                    RePricing_Code = RepricingNum
                    For x As Integer = 0 To GridView2.RowCount - 1
                        SQL &= "INSERT INTO tbl_repricing SET "
                        SQL &= String.Format("  repricing_code = '{0}', ", RepricingNum)
                        SQL &= String.Format("  AssetNumber = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number"))
                        SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                        SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")))
                        SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Price")))
                        SQL &= String.Format("  price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Suggested Price")))
                        SQL &= "  ropoa_type = 'RE', "
                        SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                        SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                    Next
                    DataObject(SQL)
                    Logs("ROPOA RE Repricing", "Draft", "Create ROPOA Real Estate repricing draft.", "", "", "", "")
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            End If
        Else
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If MsgBoxYes("Are you sure you want to save the suggested price of ROPOA Vehicle?") = MsgBoxResult.Yes Then
                    'VEHICLE
                    For x As Integer = 0 To GridView1.RowCount - 1
                        SQL &= "INSERT INTO tbl_repricing SET "
                        SQL &= String.Format("  repricing_code = '{0}', ", RePricing_Code)
                        SQL &= String.Format("  AssetNumber = '{0}', ", GridView1.GetRowCellValue(x, "Asset Number"))
                        SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                        SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "ROPOA Value")))
                        SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Price")))
                        SQL &= String.Format("  price = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Suggested Price")))
                        SQL &= "  ropoa_type = 'VE', "
                        SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                        SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                    Next
                    DataObject(String.Format("UPDATE tbl_repricing SET `status` = 'INACTIVE' WHERE repricing_code = '{0}' AND ropoa_type = 'VE' AND approved_date = ''", RePricing_Code))
                    DataObject(SQL)
                    Logs("ROPOA VE Repricing", "Draft", "Create ROPOA Vehicle repricing draft.", "", "", "", "")
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                If MsgBoxYes("Are you sure you want to save the suggested price of ROPOA Real Estate?") = MsgBoxResult.Yes Then
                    'REAL ESTATE
                    For x As Integer = 0 To GridView2.RowCount - 1
                        SQL &= "INSERT INTO tbl_repricing SET "
                        SQL &= String.Format("  repricing_code = '{0}', ", RePricing_Code)
                        SQL &= String.Format("  AssetNumber = '{0}', ", GridView2.GetRowCellValue(x, "Asset Number"))
                        SQL &= String.Format("  trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                        SQL &= String.Format("  ropoa_value = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "ROPOA Value")))
                        SQL &= String.Format("  last_price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Price")))
                        SQL &= String.Format("  price = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Suggested Price")))
                        SQL &= "  ropoa_type = 'RE', "
                        SQL &= String.Format("  attachment = '{0}', ", TotalImage)
                        SQL &= String.Format("  branch_id = '{0}';", Branch_ID)
                    Next
                    DataObject(String.Format("UPDATE tbl_repricing SET `status` = 'INACTIVE' WHERE repricing_code = '{0}' AND ropoa_type = 'RE' AND approved_date = ''", RePricing_Code))
                    DataObject(SQL)
                    Logs("ROPOA RE Repricing", "Draft", "Create ROPOA Real Estate repricing draft.", "", "", "", "")
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If (e.Column.FieldName = "Suggested Price" Or e.Column.FieldName = "Approved Price") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("ROPA Repricing - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Suggested Price" Or e.Column.FieldName = "Approved Price") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("ROPA Repricing - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub BtnPrintIndi_Click(sender As Object, e As EventArgs) Handles btnPrintIndi.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            Dim Report As New RptRepricingVE
            With Report
                Dim Unit_Info As DataTable = DataSource(String.Format("SELECT Make, `Type`, Model, Series, PlateNum, Transmission, Fuel, BodyColor, TRIM(`Year`) AS 'Year', EngineNum, ChassisNum, RegistryCert, ORNum, FORMAT(GrossWeight,2) AS 'GrossWeight', RimHoles, CONCAT(CONVERT(FORMAT(MileAge,2),CHAR), ' ', MileAgeType) AS 'MileAge', Img FROM ropoa_vehicle WHERE AssetNumber = '{0}';", GridView1.GetFocusedRowCellValue("Asset Number").ToString))
                Dim Unit_Condition As DataTable = DataSource(String.Format("SELECT appraise_num, DATE_FORMAT(appraise_date,'%b.%d.%Y') AS 'Date', `Engine`, Engine_R, Steering, Steering_R, Clutch, Clutch_R, HeadLight, HeadLight_R, SignalLight, SignalLight_R, Shock, Shock_R, Underchassis, Underchassis_R, Upholstery, Upholstery_R, TempGauge, TempGauge_R, Odometer, Odometer_R, Transmission, Transmission_R, Tires, Tires_R, Acceleration, Acceleration_R, ParkLight, ParkLight_R, Horn, Horn_R, Chassis, Chassis_R, FrontBumper, FrontBumper_R, Ampheres, Ampheres_R, Fuel, Fuel_R, Starter, Starter_R, Differential, Differential_R, Brakes, Brakes_R, Wiper, Wiper_R, `BackUp`, BackUp_R, SideMirror, SideMirror_R, BodyFlooring, BodyFlooring_R, RearBumper, RearBumper_R, OilPressure, OilPressure_R, Speedometer, Speedometer_R, BodyPaint, BodyPaint_R, Remarks FROM appraise_ve WHERE `status` = 'ACTIVE' AND asset_number = '{0}' ORDER BY appraise_date DESC LIMIT 1;", GridView1.GetFocusedRowCellValue("Asset Number").ToString))

                .Name = "Repricing " & GridView1.GetFocusedRowCellValue("Asset Number")
                .lblMake.Text = Unit_Info(0)("Make")
                .lblType.Text = Unit_Info(0)("Type")
                .lblEngine.Text = Unit_Info(0)("Model") & " " & Unit_Info(0)("Series")
                .lblPlateNumber.Text = Unit_Info(0)("PlateNum")
                .lblTransmission.Text = Unit_Info(0)("Transmission")
                .lblGasoline.Text = Unit_Info(0)("Fuel")
                .lblBodyColor.Text = Unit_Info(0)("BodyColor")
                .lblYear.Text = Unit_Info(0)("Year")
                .lblMotorNumber.Text = Unit_Info(0)("EngineNum")
                .lblSerialNumber.Text = Unit_Info(0)("ChassisNum")
                .lblRegCertNumber.Text = Unit_Info(0)("RegistryCert")
                .lblORNumber.Text = Unit_Info(0)("ORNum")
                .lblGrossWeight.Text = Unit_Info(0)("GrossWeight") & " kgs"
                .lblRim.Text = Unit_Info(0)("RimHoles")
                .lblMileAge.Text = Unit_Info(0)("MileAge")

                If Unit_Condition.Rows.Count = 1 Then
                    .lblDate.Text = Unit_Condition(0)("Date")
                    .lblAppaiseNum.Text = Unit_Condition(0)("appraise_num")
                    .lblAppraiseFor.Text = "ROPOA"
                    .txtEngine.Text = Unit_Condition(0)("Engine")
                    .txtEngineR.Text = Unit_Condition(0)("Engine_R")
                    .txtSteering.Text = Unit_Condition(0)("Steering")
                    .txtSteeringR.Text = Unit_Condition(0)("Steering_R")
                    .txtClutch.Text = Unit_Condition(0)("Clutch")
                    .txtClutchR.Text = Unit_Condition(0)("Clutch_R")
                    .txtHeadLight.Text = Unit_Condition(0)("HeadLight")
                    .txtHeadLightR.Text = Unit_Condition(0)("HeadLight_R")
                    .txtSignalLight.Text = Unit_Condition(0)("SignalLight")
                    .txtSignalLightR.Text = Unit_Condition(0)("SignalLight_R")
                    .txtShock.Text = Unit_Condition(0)("Shock")
                    .txtShockR.Text = Unit_Condition(0)("Shock_R")
                    .txtUnderchassis.Text = Unit_Condition(0)("Underchassis")
                    .txtUnderchassisR.Text = Unit_Condition(0)("Underchassis_R")
                    .txtUpholstery.Text = Unit_Condition(0)("Upholstery")
                    .txtUpholsteryR.Text = Unit_Condition(0)("Upholstery_R")
                    .txtTempGauge.Text = Unit_Condition(0)("TempGauge")
                    .txtTempGaugeR.Text = Unit_Condition(0)("TempGauge_R")
                    .txtOdometer.Text = Unit_Condition(0)("Odometer")
                    .txtOdometerR.Text = Unit_Condition(0)("Odometer_R")
                    .txtTransmission.Text = Unit_Condition(0)("Transmission")
                    .txtTransmissionR.Text = Unit_Condition(0)("Transmission_R")
                    .txtTires.Text = Unit_Condition(0)("Tires") & "%"
                    .txtTiresR.Text = Unit_Condition(0)("Tires_R")
                    .txtAcceleration.Text = Unit_Condition(0)("Acceleration")
                    .txtAccelerationR.Text = Unit_Condition(0)("Acceleration_R")
                    .txtParkLight.Text = Unit_Condition(0)("ParkLight")
                    .txtParkLightR.Text = Unit_Condition(0)("ParkLight_R")
                    .txtHorn.Text = Unit_Condition(0)("Horn")
                    .txtHornR.Text = Unit_Condition(0)("Horn_R")
                    .txtChassis.Text = Unit_Condition(0)("Chassis")
                    .txtChassisR.Text = Unit_Condition(0)("Chassis_R")
                    .txtFrontBumper.Text = Unit_Condition(0)("FrontBumper")
                    .txtFrontBumperR.Text = Unit_Condition(0)("FrontBumper_R")
                    .txtAmpheres.Text = Unit_Condition(0)("Ampheres")
                    .txtAmpheresR.Text = Unit_Condition(0)("Ampheres_R")
                    .txtFuel.Text = Unit_Condition(0)("Fuel")
                    .txtFuelR.Text = Unit_Condition(0)("Fuel_R")
                    .txtStarter.Text = Unit_Condition(0)("Starter")
                    .txtStarterR.Text = Unit_Condition(0)("Starter_R")
                    .txtDifferential.Text = Unit_Condition(0)("Differential")
                    .txtDifferentialR.Text = Unit_Condition(0)("Differential_R")
                    .txtBrakes.Text = Unit_Condition(0)("Brakes")
                    .txtBrakesR.Text = Unit_Condition(0)("Brakes_R")
                    .txtWiper.Text = Unit_Condition(0)("Wiper")
                    .txtWiperR.Text = Unit_Condition(0)("Wiper_R")
                    .txtBackUp.Text = Unit_Condition(0)("BackUp")
                    .txtBackUpR.Text = Unit_Condition(0)("BackUp_R")
                    .txtSideMirror.Text = Unit_Condition(0)("SideMirror")
                    .txtSideMirrorR.Text = Unit_Condition(0)("SideMirror_R")
                    .txtBodyFlooring.Text = Unit_Condition(0)("BodyFlooring")
                    .txtBodyFlooringR.Text = Unit_Condition(0)("BodyFlooring_R")
                    .txtRearBumper.Text = Unit_Condition(0)("RearBumper")
                    .txtRearBumperR.Text = Unit_Condition(0)("RearBumper_R")
                    .txtOilPressure.Text = Unit_Condition(0)("OilPressure")
                    .txtOilPressureR.Text = Unit_Condition(0)("OilPressure_R")
                    .txtSpeedometer.Text = Unit_Condition(0)("Speedometer")
                    .txtSpeedometerR.Text = Unit_Condition(0)("Speedometer_R")
                    .txtBodyPaint.Text = Unit_Condition(0)("BodyPaint")
                    .txtBodyPaintR.Text = Unit_Condition(0)("BodyPaint_R")
                    .txtAppraisersRemarks.Text = Unit_Condition(0)("Remarks")
                Else
                    .lblDate.Text = ""
                    .lblAppaiseNum.Text = ""
                    .lblAppraiseFor.Text = ""
                    .txtEngine.Text = ""
                    .txtEngineR.Text = ""
                    .txtSteering.Text = ""
                    .txtSteeringR.Text = ""
                    .txtClutch.Text = ""
                    .txtClutchR.Text = ""
                    .txtHeadLight.Text = ""
                    .txtHeadLightR.Text = ""
                    .txtSignalLight.Text = ""
                    .txtSignalLightR.Text = ""
                    .txtShock.Text = ""
                    .txtShockR.Text = ""
                    .txtUnderchassis.Text = ""
                    .txtUnderchassisR.Text = ""
                    .txtUpholstery.Text = ""
                    .txtUpholsteryR.Text = ""
                    .txtTempGauge.Text = ""
                    .txtTempGaugeR.Text = ""
                    .txtOdometer.Text = ""
                    .txtOdometerR.Text = ""
                    .txtTransmission.Text = ""
                    .txtTransmissionR.Text = ""
                    .txtTires.Text = ""
                    .txtTiresR.Text = ""
                    .txtAcceleration.Text = ""
                    .txtAccelerationR.Text = ""
                    .txtParkLight.Text = ""
                    .txtParkLightR.Text = ""
                    .txtHorn.Text = ""
                    .txtHornR.Text = ""
                    .txtChassis.Text = ""
                    .txtChassisR.Text = ""
                    .txtFrontBumper.Text = ""
                    .txtFrontBumperR.Text = ""
                    .txtAmpheres.Text = ""
                    .txtAmpheresR.Text = ""
                    .txtFuel.Text = ""
                    .txtFuelR.Text = ""
                    .txtStarter.Text = ""
                    .txtStarterR.Text = ""
                    .txtDifferential.Text = ""
                    .txtDifferentialR.Text = ""
                    .txtBrakes.Text = ""
                    .txtBrakesR.Text = ""
                    .txtWiper.Text = ""
                    .txtWiperR.Text = ""
                    .txtBackUp.Text = ""
                    .txtBackUpR.Text = ""
                    .txtSideMirror.Text = ""
                    .txtSideMirrorR.Text = ""
                    .txtBodyFlooring.Text = ""
                    .txtBodyFlooringR.Text = ""
                    .txtRearBumper.Text = ""
                    .txtRearBumperR.Text = ""
                    .txtOilPressure.Text = ""
                    .txtOilPressureR.Text = ""
                    .txtSpeedometer.Text = ""
                    .txtSpeedometerR.Text = ""
                    .txtBodyPaint.Text = ""
                    .txtBodyPaintR.Text = ""
                    .txtAppraisersRemarks.Text = ""
                End If

                .txtBookValue.Text = "Php " & GridView1.GetFocusedRowCellValue("ROPOA Value")
                .txtSellingPrice.Text = "Php " & GridView1.GetFocusedRowCellValue("Price")
                .txtSuggested.Text = "Php " & FormatNumber(GridView1.GetFocusedRowCellValue("Suggested Price"), 2)
                .txtApproved.Text = "Php " & If(GridView1.GetFocusedRowCellValue("Approved Price") = 0, "", GridView1.GetFocusedRowCellValue("Approved Price"))
                .lblPrepared.Text = Empl_Name
                .lblNoted.Text = ""
                .lblApproved.Text = ""

                Dim xPos As Integer = 1
                If Unit_Info(0)("Img").ToString > 0 Then
                    For x As Integer = 1 To Unit_Info(0)("Img").ToString
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
                            .Size = New Size(250, 215),
                            .Sizing = ImageSizeMode.StretchImage,
                            .Borders = BorderSide.All
                        }
                        '***ADD LABEL***'
                        Dim lblImage As New XRLabel With {
                            .Text = pB_Dev.Properties.NullText.ToString,
                            .SizeF = New Size(250, 10),
                            .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                            .TextAlignment = TextAlignment.MiddleCenter
                        }
                        '***ADD LABEL***'
                        If xPos Mod 3 = 0 Then
                            pB.Location = New Point(537.5, 550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0))
                            lblImage.Location = New Point(537.5, (550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0)) - 10)
                        ElseIf xPos Mod 3 = 2 Then
                            pB.Location = New Point(275, 550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0))
                            lblImage.Location = New Point(275, (550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0)) - 10)
                        ElseIf xPos Mod 3 = 1 Then
                            pB.Location = New Point(12.5, 550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0))
                            lblImage.Location = New Point(12.5, (550 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 240), 0)) - 10)
                        End If
                        Dim Path As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView1.GetFocusedRowCellValue("branch_code").ToString, GridView1.GetFocusedRowCellValue("Asset Number").ToString, pB_Dev.Properties.NullText & x & ".jpg")
                        If IO.File.Exists(Path) Then
                            Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                            Try
                                TempPB.Image = Image.FromFile(Path)
                            Catch ex As Exception
                                TriggerBugReport("ROPA - Repricing", ex.Message.ToString)
                            End Try
                            pB.Image = TempPB.Image
                            .Detail.Controls.Add(pB)
                            .Detail.Controls.Add(lblImage)
                            TempPB.Dispose()
                            xPos += 1
                        End If
                        .ShowPreview()
                    Next
                End If
                Logs("Vehicle ROPOA", "Print", String.Format("Print/Preview Repricing VE with Asset Number {0}", GridView1.GetFocusedRowCellValue("Asset Number").ToString), "", "", "", "")

                .ShowPreview()
            End With
        Else
            Dim Report As New RptRepricingRE
            With Report
                .Name = "Repricing " & GridView2.GetFocusedRowCellValue("Asset Number").ToString

                Dim SQL As String = "SELECT"
                SQL &= "   A.appraise_num      AS 'Appraise Number',"
                SQL &= "   DATE_FORMAT(A.appraise_date,'%b %d, %Y') AS 'Date',"
                SQL &= "   A.asset_number      AS 'Credit Number',"
                SQL &= "   Land,"
                SQL &= "   FORMAT(A.land_area,2) AS 'Land Area',"
                SQL &= "   FORMAT(A.land_price,2) AS 'Land Price',"
                SQL &= "   FORMAT(A.land_price * land_area,2) AS 'Land Total',"
                SQL &= "   land_remarks_1 AS 'Land Remarks',"
                SQL &= "   FORMAT(A.land_area_2,2) AS 'Land Area 2',"
                SQL &= "   FORMAT(A.land_price_2,2) AS 'Land Price 2',"
                SQL &= "   FORMAT(A.land_price_2 * land_area_2,2) AS 'Land Total 2',"
                SQL &= "   land_remarks_2 AS 'Land Remarks 2',"
                SQL &= "   FORMAT(A.land_area_3,2) AS 'Land Area 3',"
                SQL &= "   FORMAT(A.land_price_3,2) AS 'Land Price 3',"
                SQL &= "   FORMAT(A.land_price_3 * land_area_3,2) AS 'Land Total 3',"
                SQL &= "   land_remarks_3 AS 'Land Remarks 3',"
                SQL &= "   FORMAT(A.land_area_4,2) AS 'Land Area 4',"
                SQL &= "   FORMAT(A.land_price_4,2) AS 'Land Price 4',"
                SQL &= "   FORMAT(A.land_price_4 * land_area_4,2) AS 'Land Total 4',"
                SQL &= "   land_remarks_4 AS 'Land Remarks 4',"
                SQL &= "   FORMAT(A.land_area_5,2) AS 'Land Area 5',"
                SQL &= "   FORMAT(A.land_price_5,2) AS 'Land Price 5',"
                SQL &= "   FORMAT(A.land_price_5 * land_area_5,2) AS 'Land Total 5',"
                SQL &= "   land_remarks_5 AS 'Land Remarks 5',"
                SQL &= "   Machine,"
                SQL &= "   FORMAT(A.Machine_area,2) AS 'Machine Area',"
                SQL &= "   FORMAT(A.Machine_price,2) AS 'Machine Price',"
                SQL &= "   FORMAT(A.Machine_price * Machine_area,2) AS 'Machine Total',"
                SQL &= "   Machine_remarks_1 AS 'Machine Remarks',"
                SQL &= "   FORMAT(A.Machine_area_2,2) AS 'Machine Area 2',"
                SQL &= "   FORMAT(A.Machine_price_2,2) AS 'Machine Price 2',"
                SQL &= "   FORMAT(A.Machine_price_2 * Machine_area_2,2) AS 'Machine Total 2',"
                SQL &= "   Machine_remarks_2 AS 'Machine Remarks 2',"
                SQL &= "   FORMAT(A.Machine_area_3,2) AS 'Machine Area 3',"
                SQL &= "   FORMAT(A.Machine_price_3,2) AS 'Machine Price 3',"
                SQL &= "   FORMAT(A.Machine_price_3 * Machine_area_3,2) AS 'Machine Total 3',"
                SQL &= "   Machine_remarks_3 AS 'Machine Remarks 3',"
                SQL &= "   FORMAT(A.Machine_area_4,2) AS 'Machine Area 4',"
                SQL &= "   FORMAT(A.Machine_price_4,2) AS 'Machine Price 4',"
                SQL &= "   FORMAT(A.Machine_price_4 * Machine_area_4,2) AS 'Machine Total 4',"
                SQL &= "   Machine_remarks_4 AS 'Machine Remarks 4',"
                SQL &= "   FORMAT(A.Machine_area_5,2) AS 'Machine Area 5',"
                SQL &= "   FORMAT(A.Machine_price_5,2) AS 'Machine Price 5',"
                SQL &= "   FORMAT(A.Machine_price_5 * Machine_area_5,2) AS 'Machine Total 5',"
                SQL &= "   Machine_remarks_5 AS 'Machine Remarks 5',"
                SQL &= "   Improvement,"
                SQL &= "   FORMAT(A.Improvement_area,2) AS 'Improvement Area',"
                SQL &= "   FORMAT(A.Improvement_price,2) AS 'Improvement Price',"
                SQL &= "   FORMAT(A.Improvement_price * Improvement_area,2) AS 'Improvement Total',"
                SQL &= "   Improvement_remarks_1 AS 'Improvement Remarks',"
                SQL &= "   FORMAT(A.Improvement_area_2,2) AS 'Improvement Area 2',"
                SQL &= "   FORMAT(A.Improvement_price_2,2) AS 'Improvement Price 2',"
                SQL &= "   FORMAT(A.Improvement_price_2 * Improvement_area_2,2) AS 'Improvement Total 2',"
                SQL &= "   Improvement_remarks_2 AS 'Improvement Remarks 2',"
                SQL &= "   FORMAT(A.Improvement_area_3,2) AS 'Improvement Area 3',"
                SQL &= "   FORMAT(A.Improvement_price_3,2) AS 'Improvement Price 3',"
                SQL &= "   FORMAT(A.Improvement_price_3 * Improvement_area_3,2) AS 'Improvement Total 3',"
                SQL &= "   Improvement_remarks_3 AS 'Improvement Remarks 3',"
                SQL &= "   FORMAT(A.Improvement_area_4,2) AS 'Improvement Area 4',"
                SQL &= "   FORMAT(A.Improvement_price_4,2) AS 'Improvement Price 4',"
                SQL &= "   FORMAT(A.Improvement_price_4 * Improvement_area_4,2) AS 'Improvement Total 4',"
                SQL &= "   Improvement_remarks_4 AS 'Improvement Remarks 4',"
                SQL &= "   FORMAT(A.Improvement_area_5,2) AS 'Improvement Area 5',"
                SQL &= "   FORMAT(A.Improvement_price_5,2) AS 'Improvement Price 5',"
                SQL &= "   FORMAT(A.Improvement_price_5 * Improvement_area_5,2) AS 'Improvement Total 5',"
                SQL &= "   Improvement_remarks_5 AS 'Improvement Remarks 5',"
                SQL &= "   FORMAT((A.land_price * A.land_area) + (A.land_price_2 * land_area_2) + (A.land_price_3 * land_area_3) + (A.land_price_4 * land_area_4) + (A.land_price_5 * land_area_5) + (A.machine_price * A.machine_area) + (A.machine_price_2 * machine_area_2) + (A.machine_price_3 * machine_area_3) + (A.machine_price_4 * machine_area_4) + (A.machine_price_5 * machine_area_5) + (A.improvement_price * A.improvement_area) + (A.improvement_price_2 * improvement_area_2) + (A.improvement_price_3 * improvement_area_3) + (A.improvement_price_4 * improvement_area_4) + (A.improvement_price_5 * improvement_area_5),2) AS 'Total',"
                SQL &= "   FORMAT(A.prevailing_selling,2) AS 'Prevailing Selling Price',"
                SQL &= "   FORMAT(A.rounded_to,2) AS 'Zonal Valuation',"
                SQL &= "   A.TCT               AS 'TCT No.',"
                SQL &= "   A.lot_block         AS 'Lot / Block No.',"
                SQL &= "   FORMAT(A.area_sqm,2) AS 'Area SQ.M.',"
                SQL &= "   A.registered_owner  AS 'Registered Owner',"
                SQL &= "   A.registry_deeds    AS 'Registry of Deeds',"
                SQL &= "   A.Location,"
                SQL &= "   A.vacant_lot        AS 'Vacant Lot',"
                SQL &= "   A.Classification,"
                SQL &= "   A.Storey_R          AS 'Storey',"
                SQL &= "   A.Roofing_R         AS 'Roofing',"
                SQL &= "   A.FLooring_R        AS 'Flooring',"
                SQL &= "   A.TandB_R           AS 'T and B',"
                SQL &= "   A.Frame_R           AS 'Frame',"
                SQL &= "   A.Beams_R           AS 'Beams',"
                SQL &= "   A.Doors_R           AS 'Door',"
                SQL &= "   A.YearConstructed_R AS 'Year Constructed',"
                SQL &= "   A.Walling_R         AS 'Walling',"
                SQL &= "   A.Ceiling_R         AS 'Ceiling',"
                SQL &= "   A.Windows_R         AS 'Windows',"
                SQL &= "   A.FloorArea_R       AS 'Floor Area',"
                SQL &= "   A.Partitions_R      AS 'Partitions',"
                SQL &= "   A.Remarks           AS 'Remarks',"
                SQL &= "   FORMAT(A.appraised_value,2) AS 'Appraised Value',"
                SQL &= "   Employee(A.Appraise_By) AS 'Appraised By',"
                SQL &= "   A.as_of             AS 'As of',"
                SQL &= "   FORMAT(A.loanable_value,2) AS 'Loanable Value',"
                SQL &= "   FORMAT(A.loanable_percent,2) AS 'Loanable Percent', Attach"
                SQL &= " FROM appraise_re A"
                SQL &= String.Format("   WHERE `status` = 'ACTIVE' AND asset_number = '{0}' ORDER BY appraise_date DESC LIMIT 1;", GridView2.GetFocusedRowCellValue("Asset Number").ToString)
                Dim Unit_Condition As DataTable = DataSource(SQL)
                'Unit_Condition = DataSource(String.Format("SELECT appraise_num, DATE_FORMAT(appraise_date,'%b.%d.%Y') AS 'Date', asset_number, land_area, land_price, land_remarks_1, land_area_2, land_price_2, land_remarks_2, land_area_3, land_price_3, land_remarks_3, Machine, 0 AS 'Machine_Amount', Improvement, prevailing_selling, rounded_to, TCT, lot_block, area_sqm, registered_owner, registry_deeds, location, vacant_lot, classification, Storey_R, Roofing_R, Flooring_R, TandB_R, Frame_R, Beams_R, Doors_R, YearConstructed_R, Walling_R, Ceiling_R, Windows_R, FloorArea_R, Partitions_R, Remarks FROM appraise_re WHERE `status` = 'ACTIVE' AND asset_number = '{0}' ORDER BY appraise_date DESC LIMIT 1;", GridView2.GetFocusedRowCellValue("Asset Number").ToString))
                If Unit_Condition.Rows.Count = 1 Then
                    .lblDate.Text = Unit_Condition(0)("Date")
                    .lblAppaiseNum.Text = Unit_Condition(0)("appraise_num")
                    .lblAppraiseFor.Text = "ROPOA"
                    .lblAppraisedBy.Text = Unit_Condition(0)("Appraised By")

                    .lblLand.Text = Unit_Condition(0)("Land")

                    .dLandArea.Text = Unit_Condition(0)("Land Area")
                    .dPrice_1.Text = Unit_Condition(0)("Land Price")
                    .dTotal_1.Text = "PHP " & Unit_Condition(0)("Land Total")
                    .lblRemarks_1.Text = Unit_Condition(0)("Land Remarks")

                    .dLandArea_2.Text = Unit_Condition(0)("Land Area 2")
                    .dPrice_2.Text = Unit_Condition(0)("Land Price 2")
                    .dTotal_2.Text = "PHP " & Unit_Condition(0)("Land Total 2")
                    .lblRemarks_2.Text = Unit_Condition(0)("Land Remarks 2")

                    .dLandArea_3.Text = Unit_Condition(0)("Land Area 3")
                    .dPrice_3.Text = Unit_Condition(0)("Land Price 3")
                    .dTotal_3.Text = "PHP " & Unit_Condition(0)("Land Total 3")
                    .lblRemarks_3.Text = Unit_Condition(0)("Land Remarks 3")

                    .dLandArea_4.Text = Unit_Condition(0)("Land Area 4")
                    .dPrice_4.Text = Unit_Condition(0)("Land Price 4")
                    .dTotal_4.Text = "PHP " & Unit_Condition(0)("Land Total 4")
                    .lblRemarks_4.Text = Unit_Condition(0)("Land Remarks 4")

                    .dLandArea_5.Text = Unit_Condition(0)("Land Area 5")
                    .dPrice_5.Text = Unit_Condition(0)("Land Price 5")
                    .dTotal_5.Text = "PHP " & Unit_Condition(0)("Land Total 5")
                    .lblRemarks_5.Text = Unit_Condition(0)("Land Remarks 5")
                    .dLandTotal_T.Text = "PHP " & FormatNumber(Unit_Condition(0)("Land Total") + Unit_Condition(0)("Land Total 2") + Unit_Condition(0)("Land Total 3") + Unit_Condition(0)("Land Total 4") + Unit_Condition(0)("Land Total 5"), 2)

                    .lblImprovements.Text = Unit_Condition(0)("Improvement")

                    .dImprovementArea_1.Text = Unit_Condition(0)("Improvement Area")
                    .dImprovementPrice_1.Text = Unit_Condition(0)("Improvement Price")
                    .dImprovementTotal_1.Text = "PHP " & Unit_Condition(0)("Improvement Total")
                    .lblImprovementRemarks_1.Text = Unit_Condition(0)("Improvement Remarks")

                    .dImprovementArea_2.Text = Unit_Condition(0)("Improvement Area 2")
                    .dImprovementPrice_2.Text = Unit_Condition(0)("Improvement Price 2")
                    .dImprovementTotal_2.Text = "PHP " & Unit_Condition(0)("Improvement Total 2")
                    .lblImprovementRemarks_2.Text = Unit_Condition(0)("Improvement Remarks 2")

                    .dImprovementArea_3.Text = Unit_Condition(0)("Improvement Area 3")
                    .dImprovementPrice_3.Text = Unit_Condition(0)("Improvement Price 3")
                    .dImprovementTotal_3.Text = "PHP " & Unit_Condition(0)("Improvement Total 3")
                    .lblImprovementRemarks_3.Text = Unit_Condition(0)("Improvement Remarks 3")

                    .dImprovementArea_4.Text = Unit_Condition(0)("Improvement Area 4")
                    .dImprovementPrice_4.Text = Unit_Condition(0)("Improvement Price 4")
                    .dImprovementTotal_4.Text = "PHP " & Unit_Condition(0)("Improvement Total 4")
                    .lblImprovementRemarks_4.Text = Unit_Condition(0)("Improvement Remarks 4")

                    .dImprovementArea_5.Text = Unit_Condition(0)("Improvement Area 5")
                    .dImprovementPrice_5.Text = Unit_Condition(0)("Improvement Price 5")
                    .dImprovementTotal_5.Text = "PHP " & Unit_Condition(0)("Improvement Total 5")
                    .lblImprovementRemarks_5.Text = Unit_Condition(0)("Improvement Remarks 5")
                    .dImprovementTotal_T.Text = "PHP " & FormatNumber(Unit_Condition(0)("Improvement Total") + Unit_Condition(0)("Improvement Total 2") + Unit_Condition(0)("Improvement Total 3") + Unit_Condition(0)("Improvement Total 4") + Unit_Condition(0)("Improvement Total 5"), 2)

                    .lblMachine.Text = Unit_Condition(0)("Machine")

                    .dMachineArea_1.Text = Unit_Condition(0)("Machine Area")
                    .dMachinePrice_1.Text = Unit_Condition(0)("Machine Price")
                    .dMachineTotal_1.Text = "PHP " & Unit_Condition(0)("Machine Total")
                    .lblMachineRemarks_1.Text = Unit_Condition(0)("Machine Remarks")

                    .dMachineArea_2.Text = Unit_Condition(0)("Machine Area 2")
                    .dMachinePrice_2.Text = Unit_Condition(0)("Machine Price 2")
                    .dMachineTotal_2.Text = "PHP " & Unit_Condition(0)("Machine Total 2")
                    .lblMachineRemarks_2.Text = Unit_Condition(0)("Machine Remarks 2")

                    .dMachineArea_3.Text = Unit_Condition(0)("Machine Area 3")
                    .dMachinePrice_3.Text = Unit_Condition(0)("Machine Price 3")
                    .dMachineTotal_3.Text = "PHP " & Unit_Condition(0)("Machine Total 3")
                    .lblMachineRemarks_3.Text = Unit_Condition(0)("Machine Remarks 3")

                    .dMachineArea_4.Text = Unit_Condition(0)("Machine Area 4")
                    .dMachinePrice_4.Text = Unit_Condition(0)("Machine Price 4")
                    .dMachineTotal_4.Text = "PHP " & Unit_Condition(0)("Machine Total 4")
                    .lblMachineRemarks_4.Text = Unit_Condition(0)("Machine Remarks 4")

                    .dMachineArea_5.Text = Unit_Condition(0)("Machine Area 5")
                    .dMachinePrice_5.Text = Unit_Condition(0)("Machine Price 5")
                    .dMachineTotal_5.Text = "PHP " & Unit_Condition(0)("Machine Total 5")
                    .lblMachineRemarks_5.Text = Unit_Condition(0)("Machine Remarks 5")
                    .dMachineTotal_T.Text = "PHP " & FormatNumber(Unit_Condition(0)("Machine Total") + Unit_Condition(0)("Machine Total 2") + Unit_Condition(0)("Machine Total 3") + Unit_Condition(0)("Machine Total 4") + Unit_Condition(0)("Machine Total 5"), 2)

                    .dTotalAmount.Text = "PHP " & FormatNumber((Unit_Condition(0)("land_area") * Unit_Condition(0)("land_price")) + (Unit_Condition(0)("land_area_2") * Unit_Condition(0)("land_price_2")) + (Unit_Condition(0)("land_area_3") * Unit_Condition(0)("land_price_3")) + Unit_Condition(0)("Machine_Amount"), 2)
                    .dPrevailingSellingPrice.Text = "PHP " & FormatNumber(Unit_Condition(0)("prevailing_selling"), 2)
                    .dZonalValuation.Text = "PHP " & FormatNumber(Unit_Condition(0)("rounded_to"), 2)

                    .txtTCT.Text = Unit_Condition(0)("TCT")
                    .txtLot.Text = Unit_Condition(0)("lot_block")
                    .dArea.Text = FormatNumber(Unit_Condition(0)("area_sqm"), 2)
                    .txtRegisteredOwner.Text = Unit_Condition(0)("registered_owner")
                    .txtRegistryOfDeeds.Text = Unit_Condition(0)("registry_deeds")
                    .txtLocation.Text = Unit_Condition(0)("location")
                    If Unit_Condition(0)("vacant_lot") = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel60.BackColor = Color.WhiteSmoke
                        .XrLabel59.BackColor = Color.WhiteSmoke
                        .XrLabel58.BackColor = Color.WhiteSmoke
                        .XrLabel57.BackColor = Color.WhiteSmoke
                        .XrLabel67.BackColor = Color.WhiteSmoke
                        .XrLabel69.BackColor = Color.WhiteSmoke
                        .XrLabel63.BackColor = Color.WhiteSmoke
                        .XrLabel65.BackColor = Color.WhiteSmoke
                        .XrLabel76.BackColor = Color.WhiteSmoke
                        .XrLabel84.BackColor = Color.WhiteSmoke
                        .XrLabel78.BackColor = Color.WhiteSmoke
                        .XrLabel80.BackColor = Color.WhiteSmoke
                        .XrLabel49.BackColor = Color.WhiteSmoke
                        .XrLabel52.BackColor = Color.WhiteSmoke

                        .lblStorey_R.BackColor = Color.WhiteSmoke
                        .lblRoofings_R.BackColor = Color.WhiteSmoke
                        .lblFloorings_R.BackColor = Color.WhiteSmoke
                        .lblTandB_R.BackColor = Color.WhiteSmoke
                        .lblFrames_R.BackColor = Color.WhiteSmoke
                        .lblBeams_R.BackColor = Color.WhiteSmoke
                        .lblDoors_R.BackColor = Color.WhiteSmoke
                        .lblYear_R.BackColor = Color.WhiteSmoke
                        .lblWalling_R.BackColor = Color.WhiteSmoke
                        .lblCeiling_R.BackColor = Color.WhiteSmoke
                        .lblWindows_R.BackColor = Color.WhiteSmoke
                        .lblFloorArea_R.BackColor = Color.WhiteSmoke
                        .lblPartitions_R.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                    End If
                    If Unit_Condition(0)("classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf Unit_Condition(0)("classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf Unit_Condition(0)("classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf Unit_Condition(0)("classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf Unit_Condition(0)("classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf Unit_Condition(0)("classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblStorey_R.Text = Unit_Condition(0)("Storey_R")
                    .lblRoofings_R.Text = Unit_Condition(0)("Roofing_R")
                    .lblFloorings_R.Text = Unit_Condition(0)("Flooring_R")
                    .lblTandB_R.Text = Unit_Condition(0)("TandB_R")
                    .lblFrames_R.Text = Unit_Condition(0)("Frame_R")
                    .lblBeams_R.Text = Unit_Condition(0)("Beams_R")
                    .lblDoors_R.Text = Unit_Condition(0)("Doors_R")
                    .lblYear_R.Text = Unit_Condition(0)("YearConstructed_R")
                    .lblWalling_R.Text = Unit_Condition(0)("Walling_R")
                    .lblCeiling_R.Text = Unit_Condition(0)("Ceiling_R")
                    .lblWindows_R.Text = Unit_Condition(0)("Windows_R")
                    .lblFloorArea_R.Text = Unit_Condition(0)("FloorArea_R")
                    .lblPartitions_R.Text = Unit_Condition(0)("Partitions_R")
                    .lblRemarks.Text = Unit_Condition(0)("Remarks")
                Else
                    Dim Unit_Info As DataTable = DataSource(String.Format("SELECT TCT, Location, `Area`, Classification, VacantLot, Storey, Roofings, Flooring, TandB, Frame, Beams, Doors, YearConstructed, Walling, `Ceiling`, Windows, FloorArea, `Partitions`, Remarks FROM ropoa_realestate WHERE AssetNumber = '{0}';", GridView2.GetFocusedRowCellValue("Asset Number")))

                    .lblDate.Text = ""
                    .lblAppaiseNum.Text = ""
                    .lblAppraiseFor.Text = ""

                    .dLandArea.Text = ""
                    .dPrice_1.Text = ""
                    .dTotal_1.Text = "PHP "
                    .lblRemarks_1.Text = ""
                    .dLandArea_2.Text = ""
                    .dPrice_2.Text = ""
                    .dTotal_2.Text = "PHP "
                    .lblRemarks_2.Text = ""
                    .dLandArea_3.Text = ""
                    .dPrice_3.Text = ""
                    .dTotal_3.Text = "PHP "
                    .lblRemarks_3.Text = ""
                    .lblMachine.Text = ""
                    .dTotal_4.Text = "PHP "
                    .lblImprovements.Text = ""
                    .dTotalAmount.Text = "PHP "
                    .dPrevailingSellingPrice.Text = "PHP "
                    .dZonalValuation.Text = "PHP "

                    .txtTCT.Text = Unit_Info(0)("TCT")
                    .txtLot.Text = ""
                    .dArea.Text = Unit_Info(0)("Area")
                    .txtRegisteredOwner.Text = ""
                    .txtRegistryOfDeeds.Text = ""
                    .txtLocation.Text = Unit_Info(0)("Location")
                    If Unit_Info(0)("VacantLot").ToString = "YES" Then
                        .cbxVacantLot.Checked = True
                        .XrLabel60.BackColor = Color.WhiteSmoke
                        .XrLabel59.BackColor = Color.WhiteSmoke
                        .XrLabel58.BackColor = Color.WhiteSmoke
                        .XrLabel57.BackColor = Color.WhiteSmoke
                        .XrLabel67.BackColor = Color.WhiteSmoke
                        .XrLabel69.BackColor = Color.WhiteSmoke
                        .XrLabel63.BackColor = Color.WhiteSmoke
                        .XrLabel65.BackColor = Color.WhiteSmoke
                        .XrLabel76.BackColor = Color.WhiteSmoke
                        .XrLabel84.BackColor = Color.WhiteSmoke
                        .XrLabel78.BackColor = Color.WhiteSmoke
                        .XrLabel80.BackColor = Color.WhiteSmoke
                        .XrLabel49.BackColor = Color.WhiteSmoke
                        .XrLabel52.BackColor = Color.WhiteSmoke

                        .lblStorey_R.BackColor = Color.WhiteSmoke
                        .lblRoofings_R.BackColor = Color.WhiteSmoke
                        .lblFloorings_R.BackColor = Color.WhiteSmoke
                        .lblTandB_R.BackColor = Color.WhiteSmoke
                        .lblFrames_R.BackColor = Color.WhiteSmoke
                        .lblBeams_R.BackColor = Color.WhiteSmoke
                        .lblDoors_R.BackColor = Color.WhiteSmoke
                        .lblYear_R.BackColor = Color.WhiteSmoke
                        .lblWalling_R.BackColor = Color.WhiteSmoke
                        .lblCeiling_R.BackColor = Color.WhiteSmoke
                        .lblWindows_R.BackColor = Color.WhiteSmoke
                        .lblFloorArea_R.BackColor = Color.WhiteSmoke
                        .lblPartitions_R.BackColor = Color.WhiteSmoke
                    Else
                        .cbxVacantLot.Checked = False
                    End If
                    If Unit_Info(0)("Classification") = "Residential" Then
                        .cbxResidential.Checked = True
                    ElseIf Unit_Info(0)("Classification") = "Commercial" Then
                        .cbxCommercial.Checked = True
                    ElseIf Unit_Info(0)("Classification") = "Agricultural" Then
                        .cbxAgricultural.Checked = True
                    ElseIf Unit_Info(0)("Classification") = "Tourism" Then
                        .cbxTourism.Checked = True
                    ElseIf Unit_Info(0)("Classification") = "Industrial" Then
                        .cbxIndustrial.Checked = True
                    ElseIf Unit_Info(0)("Classification") = "Others" Then
                        .cbxOthers.Checked = True
                    End If
                    .lblStorey_R.Text = Unit_Info(0)("Storey")
                    .lblRoofings_R.Text = Unit_Info(0)("Roofings")
                    .lblFloorings_R.Text = Unit_Info(0)("Flooring")
                    .lblTandB_R.Text = Unit_Info(0)("TandB")
                    .lblFrames_R.Text = Unit_Info(0)("Frame")
                    .lblBeams_R.Text = Unit_Info(0)("Beams")
                    .lblDoors_R.Text = Unit_Info(0)("Doors")
                    .lblYear_R.Text = Unit_Info(0)("YearConstructed")
                    .lblWalling_R.Text = Unit_Info(0)("Walling")
                    .lblCeiling_R.Text = Unit_Info(0)("Ceiling")
                    .lblWindows_R.Text = Unit_Info(0)("Windows")
                    .lblFloorArea_R.Text = Unit_Info(0)("FloorArea")
                    .lblPartitions_R.Text = Unit_Info(0)("Partitions")
                    .lblRemarks.Text = Unit_Info(0)("Remarks")
                End If

                .txtBookValue.Text = "Php " & GridView2.GetFocusedRowCellValue("ROPOA Value")
                .txtSellingPrice.Text = "Php " & GridView2.GetFocusedRowCellValue("Price")
                .txtSuggested.Text = "Php " & FormatNumber(GridView2.GetFocusedRowCellValue("Suggested Price"), 2)
                .txtApproved.Text = "Php " & If(GridView2.GetFocusedRowCellValue("Approved Price") = 0, "", GridView2.GetFocusedRowCellValue("Approved Price"))
                .lblPrepared.Text = Empl_Name
                .lblNoted.Text = ""
                .lblApproved.Text = ""

                Dim TotalImage As Integer = DataObject(String.Format("SELECT Img FROM ropoa_realestate WHERE AssetNumber = '{0}'", GridView2.GetFocusedRowCellValue("Asset Number")))
                Dim xPos As Integer = 1
                If TotalImage > 0 Then
                    For x As Integer = 1 To TotalImage
                        Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                        If x > 5 Then
                            pB_Dev.Properties.NullText = "No Image"
                        Else
                            If x Mod 5 = 1 Then
                                pB_Dev.Properties.NullText = "Picture of Property"
                            ElseIf x Mod 5 = 2 Then
                                pB_Dev.Properties.NullText = "Sketch Plan"
                            ElseIf x Mod 5 = 3 Then
                                pB_Dev.Properties.NullText = "Location Map"
                            ElseIf x Mod 5 = 4 Then
                                pB_Dev.Properties.NullText = "Vicinity Map"
                            ElseIf x Mod 5 = 0 Then
                                pB_Dev.Properties.NullText = "Right of Way"
                            End If
                        End If

                        Dim pB As New XRPictureBox With {
                            .Size = New Size(250, 175),
                            .Sizing = ImageSizeMode.StretchImage,
                            .Borders = BorderSide.All
                        }
                        '***ADD LABEL***'
                        Dim lblImage As New XRLabel With {
                            .Text = If(pB_Dev.Properties.NullText = "No Image", "", pB_Dev.Properties.NullText),
                            .SizeF = New Size(250, 10),
                            .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                            .TextAlignment = TextAlignment.MiddleCenter
                        }
                        '***ADD LABEL***'
                        If xPos Mod 3 = 0 Then
                            pB.Location = New Point(537.5, 10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0))
                            lblImage.Location = New Point(537.5, (10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0)) - 10)
                        ElseIf xPos Mod 3 = 2 Then
                            pB.Location = New Point(275, 10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0))
                            lblImage.Location = New Point(275, (10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0)) - 10)
                        ElseIf xPos Mod 3 = 1 Then
                            pB.Location = New Point(12.5, 10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0))
                            lblImage.Location = New Point(12.5, (10 + If(xPos > 3, (Math.Ceiling((xPos - 3) / 3) * 200), 0)) - 10)
                        End If
                        Dim Path As String
                        If x > 5 Then
                            Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code").ToString, GridView2.GetFocusedRowCellValue("Asset Number").ToString, "Image" & x & ".jpg")
                        Else
                            Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, GridView2.GetFocusedRowCellValue("branch_code").ToString, GridView2.GetFocusedRowCellValue("Asset Number").ToString, pB_Dev.Properties.NullText & x & ".jpg")
                        End If
                        If IO.File.Exists(Path) Then
                            Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                            Try
                                TempPB.Image = Image.FromFile(Path)
                            Catch ex As Exception
                                TriggerBugReport("ROPA Repricing - Print", ex.Message.ToString)
                            End Try
                            pB.Image = TempPB.Image
                            .Detail.Controls.Add(pB)
                            .Detail.Controls.Add(lblImage)
                            TempPB.Dispose()
                            xPos += 1
                        End If
                        .ShowPreview()
                    Next
                End If

                Logs("Real Estate ROPOA", "Print", String.Format("Print/Preview Repricing RE with Asset Number {0}", GridView2.GetFocusedRowCellValue("Asset Number").ToString), "", "", "", "")
                .ShowPreview()
            End With
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes("Are you sure you want to remove this ROPOA VL from the list, this will make this ROPOA not included for repricing.") = MsgBoxResult.Yes Then
                DT_VE.Rows.RemoveAt(GridView1.FocusedRowHandle)
                If GridView1.RowCount = 0 Then
                    Close()
                End If
            End If
        Else
            If MsgBoxYes("Are you sure you want to remove this ROPOA RE from the list, this will make this ROPOA not included for repricing.") = MsgBoxResult.Yes Then
                DT_RE.Rows.RemoveAt(GridView2.FocusedRowHandle)
                If GridView2.RowCount = 0 Then
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BtnRemoveA_Click(sender As Object, e As EventArgs) Handles btnRemoveA.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes("Are you sure you want to remove all the ROPOA VL except the this selected from the list, this will make this ROPOA not included for repricing.") = MsgBoxResult.Yes Then
Here:
                For x As Integer = 0 To GridView1.RowCount - 1
                    If x = GridView1.FocusedRowHandle Then
                    Else
                        Try
                            DT_VE.Rows.RemoveAt(x)
                        Catch ex As Exception
                            If GridView1.RowCount = 1 Then
                                Exit Sub
                            Else
                                GoTo Here
                            End If
                        End Try
                    End If
                Next
                If GridView1.RowCount = 0 Then
                    Close()
                End If
            End If
        Else
            If MsgBoxYes("Are you sure you want to remove all the ROPOA RE except the this selected from the list, this will make this ROPOA not included for repricing.") = MsgBoxResult.Yes Then
Here_II:
                For x As Integer = 0 To GridView2.RowCount - 1
                    If x = GridView2.FocusedRowHandle Then
                    Else
                        Try
                            DT_RE.Rows.RemoveAt(x)
                        Catch ex As Exception
                            If GridView2.RowCount = 1 Then
                                Exit Sub
                            Else
                                GoTo Here_II
                            End If
                        End Try
                    End If
                Next
                If GridView2.RowCount = 0 Then
                    Close()
                End If
            End If
        End If
    End Sub
End Class