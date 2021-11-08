Imports DevExpress.XtraReports.UI
Public Class FrmBulkMigrationv2

    ReadOnly ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public FirstLoad As Boolean = True
    Dim Temp_DT As DataTable
    Dim DT_Borrower As DataTable
    Dim DT_Bank As DataTable
    Dim DT_Products As DataTable
    Dim MigrationMode As Boolean
    Private Sub FrmBulkMigration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCode"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit1
            .DisplayMember = "BusinessCode"
            .ValueMember = "BusinessCode"
            .DataSource = DT_BusinessCenter.Copy
        End With

        With cbxProduct
            .ValueMember = "ID"
            .DisplayMember = "Product"
            DT_Products = DataSource(String.Format("SELECT ID, `Code` AS 'Product' FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}';", Branch_ID))
            .DataSource = DT_Products.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit2
            .DisplayMember = "Product"
            .ValueMember = "Product"
            .DataSource = DT_Products.Copy
        End With

        DT_Borrower = DataSource(String.Format("SELECT BorrowerID, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower' FROM profile_borrower WHERE branch_id = '{0}' AND `status` = 'ACTIVE'", Branch_ID))

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            DT_Bank = DataSource(String.Format("SELECT ID, `Code` AS 'Bank' FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
            .DataSource = DT_Bank.Copy
            If DefaultBankID > 0 Then
                .Enabled = False
            End If
        End With

        With RepositoryItemLookUpEdit3
            .DisplayMember = "Bank"
            .ValueMember = "Bank"
            .DataSource = DT_Bank.Copy
        End With

        With cbxIndustry
            .ValueMember = "ID"
            .DisplayMember = "Nature"
            '.DisplayMember = "Code"
            .DataSource = DT_Industry.Copy
        End With

        With RepositoryItemLookUpEdit4
            If cbxIndustry.DisplayMember = "Nature" Then
                .DisplayMember = "Nature"
                .ValueMember = "Nature"
            Else
                .DisplayMember = "Code"
                .ValueMember = "Code"
            End If
            .DataSource = DT_Industry.Copy
        End With

        LoadData()

        FirstLoad = False
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

            GetComboBoxFontSettings({cbxBusinessCenter, cbxProduct, cbxBank, cbxIndustry})

            GetButtonFontSettings({btnSave, btnVerify, btnRefresh, btnCancel, btnImport, btnExport, btnExportNotes})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit1, RepositoryItemLookUpEdit2, RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit4})
        Catch ex As Exception
            TriggerBugReport("Bulk Migration - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Bulk Migration", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT "
        SQL &= "    1 AS 'No',"
        SQL &= "    '' AS 'BorrowerID',"
        SQL &= "    '' AS 'Borrower',"
        SQL &= "    '' AS 'BusinessID',"
        SQL &= "    '' AS 'Business Center',"
        SQL &= "    '' AS 'ProductID',"
        SQL &= "    '' AS 'Product',"
        SQL &= "    '' AS 'Account Number',"
        SQL &= "    '' AS 'Collateral',"
        SQL &= "    '' AS 'Terms',"
        SQL &= "    '' AS 'Interest %',"
        SQL &= "    '' AS 'RPPD %',"
        SQL &= "    '' AS 'Date Availed',"
        SQL &= "    '' AS 'Last Payment',"
        SQL &= "    '' AS 'Due Date',"
        SQL &= "    0.0 AS 'Principal',"
        SQL &= "    0.0 AS 'Principal Balance',"
        SQL &= "    0.0 AS 'UDI',"
        SQL &= "    0.0 AS 'UDI Balance',"
        SQL &= "    0.0 AS 'RPPD',"
        SQL &= "    0.0 AS 'RPPD Balance',"
        SQL &= "    0.0 AS 'Unpaid Penalty',"
        SQL &= "    0.0 AS 'GMA',"
        SQL &= "    0.0 AS 'Monthly Rebate',"
        SQL &= "    '' AS 'BankID',"
        SQL &= "    '' AS 'Bank',"
        SQL &= "    '' AS 'IndustryID',"
        SQL &= "    '' AS 'Industry',"
        SQL &= "     0 AS 'MortgageID', '' AS 'Remarks'"
        Temp_DT = DataSource(SQL)
        GridControl1.DataSource = Temp_DT.Copy
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.I Then
            btnImport.Focus()
            btnImport.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.E Then
            btnExport.Focus()
            btnExport.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter And GridColumn1.OptionsColumn.AllowEdit Then
            If MsgBoxYes(String.Format("Are you sure you want to update the borrower at row {0}?", GridView1.GetFocusedRowCellValue("No"))) = MsgBoxResult.Yes Then
                GridView1.SetFocusedRowCellValue("Borrower", DataObject(String.Format("SELECT Borrower('{0}')", GridView1.GetFocusedRowCellValue("BorrowerID"))))
            End If
        ElseIf e.Control And e.KeyCode = Keys.D1 Then
            If GridColumn46.OptionsColumn.AllowEdit Then
                GridColumn46.OptionsColumn.AllowEdit = False
                GridColumn1.OptionsColumn.AllowEdit = False
                GridColumn2.OptionsColumn.AllowEdit = False
                GridColumn4.OptionsColumn.AllowEdit = False
                GridColumn6.OptionsColumn.AllowEdit = False
                GridColumn7.OptionsColumn.AllowEdit = False
                GridColumn8.OptionsColumn.AllowEdit = False
                GridColumn10.OptionsColumn.AllowEdit = False
                GridColumn11.OptionsColumn.AllowEdit = False
                GridColumn12.OptionsColumn.AllowEdit = False
                GridColumn13.OptionsColumn.AllowEdit = False
                GridColumn15.OptionsColumn.AllowEdit = False
                GridColumn16.OptionsColumn.AllowEdit = False
                GridColumn17.OptionsColumn.AllowEdit = False
                GridColumn18.OptionsColumn.AllowEdit = False
                GridColumn19.OptionsColumn.AllowEdit = False
                GridColumn20.OptionsColumn.AllowEdit = False
                GridColumn21.OptionsColumn.AllowEdit = False
                GridColumn22.OptionsColumn.AllowEdit = False
                GridColumn23.OptionsColumn.AllowEdit = False
                GridColumn24.OptionsColumn.AllowEdit = False
                GridColumn25.OptionsColumn.AllowEdit = False
                GridColumn27.OptionsColumn.AllowEdit = False
                GridColumn14.OptionsColumn.AllowEdit = False
                MsgBox("Table is now locked, edit is not allowed!", MsgBoxStyle.Information, "Info")
            Else
                GridColumn46.OptionsColumn.AllowEdit = True
                GridColumn1.OptionsColumn.AllowEdit = True
                GridColumn2.OptionsColumn.AllowEdit = True
                GridColumn4.OptionsColumn.AllowEdit = True
                GridColumn6.OptionsColumn.AllowEdit = True
                GridColumn7.OptionsColumn.AllowEdit = True
                GridColumn8.OptionsColumn.AllowEdit = True
                GridColumn10.OptionsColumn.AllowEdit = True
                GridColumn11.OptionsColumn.AllowEdit = True
                GridColumn12.OptionsColumn.AllowEdit = True
                GridColumn13.OptionsColumn.AllowEdit = True
                GridColumn15.OptionsColumn.AllowEdit = True
                GridColumn16.OptionsColumn.AllowEdit = True
                GridColumn17.OptionsColumn.AllowEdit = True
                GridColumn18.OptionsColumn.AllowEdit = True
                GridColumn19.OptionsColumn.AllowEdit = True
                GridColumn20.OptionsColumn.AllowEdit = True
                GridColumn21.OptionsColumn.AllowEdit = True
                GridColumn22.OptionsColumn.AllowEdit = True
                GridColumn23.OptionsColumn.AllowEdit = True
                GridColumn24.OptionsColumn.AllowEdit = True
                GridColumn25.OptionsColumn.AllowEdit = True
                GridColumn27.OptionsColumn.AllowEdit = True
                GridColumn14.OptionsColumn.AllowEdit = True
                MsgBox("Table is now open, edit is not allowed", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            FrmBulkMigration_Load(sender, e)

            Clear()
        End If
    End Sub

    Private Sub Clear()
        FirstLoad = True
        LoadData()
        btnVerify.Enabled = False
        btnSave.Enabled = False

        FirstLoad = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim Loans As New FrmLoanApplication

            Dim SQL As String
            For x As Integer = 0 To GridView1.RowCount - 1
FillAgain:
                Dim SQL_B As String = ""
                Dim CreditNumber As String = DataObject(String.Format("SELECT CONCAT('CA', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM credit_application WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyyMM"), Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd")))
                Dim ProductName As String = DataObject(String.Format("SELECT Product FROM product_setup WHERE ID = '{0}';", GridView1.GetRowCellValue(x, "ProductID")))
                If GridView1.GetRowCellValue(x, "BorrowerID").ToString.Contains("C") Then
                    SQL_B = "SELECT"
                    SQL_B &= " CONCAT('[ ', B.BorrowerID, ' ] - ', TradeName) AS 'Name',"
                    SQL_B &= " B.*, (SELECT BusinessCenter FROM business_center WHERE ID = B.BusinessID) AS 'BusinessCenter'"
                    SQL_B &= " FROM profile_corporation B"
                    SQL_B &= String.Format(" WHERE B.BorrowerID = '{0}' GROUP BY B.BorrowerID ORDER BY B.TradeName;", GridView1.GetRowCellValue(x, "BorrowerID"))
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
                    SQL_B &= String.Format("    WHERE B.BorrowerID = '{0}' GROUP BY B.BorrowerID ORDER BY B.LastN_B;", GridView1.GetRowCellValue(x, "BorrowerID"))
                End If
                Dim DT_Borrowers As DataTable = DataSource(SQL_B)

                '*************AMORTIZATION SCHEDULE 
                With Loans
                    .For_Schedule = True
                    .SendToBack()
                    .WindowState = FormWindowState.Minimized
                    .Show()
                    .dAmountApplied.Value = CDbl(GridView1.GetRowCellValue(x, "Principal"))
                    .iTerms.Value = GridView1.GetRowCellValue(x, "Terms")
                    .cbxProduct.Text = ProductName
                    .dtpDate.Value = If(IsDate(Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & GridView1.GetRowCellValue(x, "Due Date")), Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & GridView1.GetRowCellValue(x, "Due Date"), If(IsDate(Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & CInt(GridView1.GetRowCellValue(x, "Due Date")) - 1), Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & CInt(GridView1.GetRowCellValue(x, "Due Date")) - 1, If(IsDate(Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & CInt(GridView1.GetRowCellValue(x, "Due Date")) - 2), Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & CInt(GridView1.GetRowCellValue(x, "Due Date")) - 2, Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-") & Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "MM-") & CInt(GridView1.GetRowCellValue(x, "Due Date")) - 3)))
                    .dInterest_T.Value = CDbl(GridView1.GetRowCellValue(x, "Interest %"))
                    .dRPPDRate_T.Value = CDbl(GridView1.GetRowCellValue(x, "RPPD %"))
                    .dRPPD_C.Value = CDbl(GridView1.GetRowCellValue(x, "RPPD"))
                    .dUDI_C.Value = CDbl(GridView1.GetRowCellValue(x, "UDI"))
                    .LoadAmortization(GridControl2, True)
                End With
                SQL = ""
                For y As Integer = 0 To GridView2.RowCount - 2
                    If GridView2.GetRowCellValue(y, "No") = "" Then
                        SQL &= " INSERT INTO credit_schedule SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                        SQL &= String.Format(" `No` = '{0}', ", GridView2.GetRowCellValue(y, "No"))
                        SQL &= " DueDate = '', "
                        SQL &= " Monthly = 0, "
                        SQL &= " InterestIncome = 0, "
                        SQL &= " RPPD = 0, "
                        SQL &= " PrincipalAllocation = 0, "
                        SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Outstanding Principal")))
                        SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Total_RPPD")))
                        SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Unearn Income")))
                        If CDbl(GridView2.GetRowCellValue(y, "Loans Receivable")) > 0 Then 'ERROR HANDLING SA NOT A NUMBER, DLI MAN MAKAYA SA ISNUMERIC FUNCTION
                            SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(y, "Loans Receivable")))
                        Else
                            SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(y, "Outstanding Principal")) + CDbl(GridView2.GetRowCellValue(y, "Total_RPPD")) + CDbl(GridView2.GetRowCellValue(y, "Unearn Income")))
                        End If
                    Else
                        SQL &= " INSERT INTO credit_schedule SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                        SQL &= String.Format(" `No` = '{0}', ", GridView2.GetRowCellValue(y, "No"))
                        SQL &= String.Format(" DueDate = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(y, "Due Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" Monthly = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Monthly")))
                        SQL &= String.Format(" InterestIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Interest Income")))
                        SQL &= String.Format(" RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "RPPD")))
                        SQL &= String.Format(" PrincipalAllocation = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Principal Allocation")))
                        SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Outstanding Principal")))
                        SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Total_RPPD")))
                        SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(y, "Unearn Income")))
                        If CDbl(GridView2.GetRowCellValue(y, "Loans Receivable")) > 0 Then 'ERROR HANDLING SA NOT A NUMBER, DLI MAN MAKAYA SA ISNUMERIC FUNCTION
                            SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(y, "Loans Receivable")))
                        Else
                            SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(y, "Outstanding Principal")) + CDbl(GridView2.GetRowCellValue(y, "Total_RPPD")) + CDbl(GridView2.GetRowCellValue(y, "Unearn Income")))
                        End If
                    End If
                Next
                '*************AMORTIZATION SCHEDULE 

                'CREDIT APPLICATION
                SQL &= "INSERT INTO credit_application SET"
                SQL &= String.Format(" AmountApplied = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                SQL &= String.Format(" Terms = '{0}', ", GridView1.GetRowCellValue(x, "Terms"))
                SQL &= String.Format(" TermType = '{0}', ", "MONTH")
                SQL &= String.Format(" product_id = '{0}', ", GridView1.GetRowCellValue(x, "ProductID"))
                SQL &= String.Format(" product = '{0}', ", ProductName)
                SQL &= String.Format(" mortgage_id = '{0}', ", GridView1.GetRowCellValue(x, "MortgageID"))
                SQL &= " collateral_id = 0, "
                SQL &= String.Format(" collateral = '{0}', ", GridView1.GetRowCellValue(x, "Collateral").ToString.InsertQuote)
                SQL &= " purpose = '', "
                SQL &= String.Format(" trans_date = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= String.Format(" loan_type = '{0}', ", "MIGRATED")
                SQL &= String.Format(" AccountN = '{0}', ", GridView1.GetRowCellValue(x, "Account Number"))
                SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                SQL &= String.Format(" interest_rate = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Interest %")))
                SQL &= String.Format(" rppd_rate = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD %")))
                SQL &= String.Format(" face_amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")) + CDbl(GridView1.GetRowCellValue(x, "UDI")) + CDbl(GridView1.GetRowCellValue(x, "RPPD")))
                SQL &= String.Format(" net_proceeds = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "GMA")) + CDbl(GridView1.GetRowCellValue(x, "Monthly Rebate")))
                SQL &= " AdvancePayment_Count = 0, "
                SQL &= " Note = '', "
                SQL &= " Service_Charge = 0, "
                SQL &= " Appraisal_Fee = 0, "
                SQL &= " CI_Fee = 0, "
                SQL &= " Insurance = 0, "
                SQL &= " Miscellaneous_Income = 0, "
                SQL &= " Advance_Payment = 0, "
                SQL &= " Deduct_Balance = 0, "
                SQL &= String.Format(" Interest = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "UDI")))
                SQL &= String.Format(" RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD")))
                SQL &= String.Format(" GMA = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "GMA")))
                SQL &= String.Format(" Rebate = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Monthly Rebate")))

                SQL &= String.Format(" BorrowerID = '{0}', ", GridView1.GetRowCellValue(x, "BorrowerID"))
                If GridView1.GetRowCellValue(x, "BorrowerID").ToString.Contains("C") Then
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
                SQL &= String.Format(" DealerNo = '{0}', ", DT_Borrowers(0)("DealerNo"))
                SQL &= String.Format(" application_status = '{0}', ", "APPROVED")
                SQL &= String.Format(" CI_Status = '{0}', ", "APPROVED")
                SQL &= String.Format(" CI_ApprovedDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= String.Format(" PaymentRequest = '{0}', ", "RELEASED")
                SQL &= " Assigned_CI = 0, "
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" BusinessID = '{0}', ", If(GridView1.GetRowCellValue(x, "Business Center").ToString = "", 0, GridView1.GetRowCellValue(x, "BusinessID")))
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= " Interest_N = 0, "
                SQL &= " RPPD_N = 0, "
                SQL &= " Principal_N = 0, "
                'ANG credit_release data ari nalang dri i insert
                SQL &= String.Format(" Remarks = '{0}', ", GridView1.GetRowCellValue(x, "Remarks"))
                SQL &= String.Format(" AccountNumber = '{0}', ", GridView1.GetRowCellValue(x, "Account Number"))
                SQL &= String.Format(" CVNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" CVNumber = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" Released = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= String.Format(" PN = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                'SQL &= String.Format(" FDD = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "FDD")), "yyyy-MM-dd"))
                SQL &= String.Format(" FDD = '{0}', ", Format(CDate(GridView2.GetRowCellValue(1, "Due Date")), "yyyy-MM-dd"))
                SQL &= String.Format(" LDD = '{0}', ", Format(CDate(GridView2.GetRowCellValue(GridView2.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
                SQL &= String.Format(" Referred = '{0}', ", DT_Borrowers(0)("Marketing"))
                'ANG credit_release data ari nalang dri i insert
                SQL &= String.Format(" user_code = '{0}';", "")

                'CREDIT INDUSTRY
                SQL &= "INSERT INTO credit_application_industry SET"
                SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                SQL &= String.Format(" Industry_ID = '{0}', ", GridView1.GetRowCellValue(x, "IndustryID"))
                SQL &= String.Format(" Industry = '{0}', ", GridView1.GetRowCellValue(x, "Industry"))
                SQL &= " `Type` = 'Borrower';"

                'CREDIT INVESTIGATION
                If GridView1.GetRowCellValue(x, "MortgageID") = 1 Or GridView1.GetRowCellValue(x, "MortgageID") = 2 Then
                    SQL &= "INSERT INTO credit_investigation SET"
                    SQL &= String.Format(" CINumber = '{0}', ", DataObject(String.Format("SELECT CONCAT('CI', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM credit_investigation WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyyMM"), Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))))
                    SQL &= String.Format(" trans_date = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                    SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                    SQL &= String.Format(" BorrowerID = '{0}', ", GridView1.GetRowCellValue(x, "BorrowerID"))
                    If GridView1.GetRowCellValue(x, "BorrowerID").ToString.Contains("C") Then
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
                        SQL &= " RecommendationFor = '', "
                        SQL &= String.Format(" Rec_ApprovedAmount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                        SQL &= String.Format(" Rec_ApprovedTerms = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Terms")))
                        SQL &= String.Format(" Rec_ApprovedRate = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Interest %")))
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
                        SQL &= " VehicleRemarks_2 = '', "
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

                        SQL &= " CreditRating = '', "
                        SQL &= " RecommendationFor = '', "
                        SQL &= String.Format(" Rec_ApprovedAmount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                        SQL &= String.Format(" Rec_ApprovedTerms = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Terms")))
                        SQL &= String.Format(" Rec_ApprovedRate = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Interest %")))
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
                        SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", DT_Borrowers(0)("VehicleRemarks_2"))
                    End If
                    SQL &= " OtherProperties = '', "
                    SQL &= " Narrative = '', "
                    SQL &= " Ex_TotalDisposable = 0, "
                    SQL &= " Ex_Living = 0, "
                    SQL &= " Ex_Clothing = 0, "
                    SQL &= " Ex_Education = 0, "
                    SQL &= " Ex_Transportation = 0, "
                    SQL &= " Ex_Lights = 0, "
                    SQL &= " Ex_Insurance = 0, "
                    SQL &= " Ex_Amortization = 0, "
                    SQL &= " Ex_Miscellaneous = 0, "
                    SQL &= " Ex_TotalExpenses = 0, "
                    SQL &= " Ex_NetDisposable = 0, "
                    SQL &= " Ex_TMFI = 0, "
                    SQL &= " Ex_TMDI = 0, "
                    SQL &= " PurposeLoan = '', "
                    SQL &= " Others = '', "
                    SQL &= String.Format(" AmountApplied = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                    SQL &= String.Format(" LoanType = '{0}', ", DataObject(String.Format("SELECT Mortgage FROM mortgage_setup WHERE ID = '{0}';", GridView1.GetRowCellValue(x, "MortgageID"))))
                    SQL &= String.Format(" Product = '{0}', ", ProductName)
                    SQL &= String.Format(" Collateral = '{0}', ", GridView1.GetRowCellValue(x, "Collateral").ToString.InsertQuote)
                    SQL &= " TotalAppraised = 0, "
                    SQL &= String.Format(" Loanable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                    SQL &= String.Format(" Branch_ID = '{0}', ", Branch_ID)
                    SQL &= String.Format(" User_Code = '{0}', ", "") 'DataObject(String.Format("SELECT User_Code FROM users WHERE empl_id = '{0}';", 0)))
                    SQL &= String.Format(" ci_status = '{0}', ", "APPROVED")
                    SQL &= " C1 = '', "
                    SQL &= " C2 = '', "
                    SQL &= " C3 = '', "
                    SQL &= " C4 = '', "
                    SQL &= " C5 = '', "
                    SQL &= " C6 = '', "
                    SQL &= " C7 = '', "
                    SQL &= " C8 = '', "
                    SQL &= " C9 = '', "
                    SQL &= String.Format(" Branch_Code = '{0}';", Branch_Code)
                End If

                'PAYMENT REQUEST
                SQL &= "INSERT INTO check_received SET"
                SQL &= String.Format(" AssetNumber = '{0}', ", CreditNumber)
                SQL &= String.Format(" ORNumber = '{0}', ", "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL &= " Sold_ID = '', "
                SQL &= String.Format(" Buyer = '{0}', ", GridView1.GetRowCellValue(x, "Borrower"))
                SQL &= String.Format(" DateRequest = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= " Bank = '', "
                SQL &= " Branch = '', "
                SQL &= String.Format(" `Check` = '{0}', ", "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")))
                SQL &= String.Format(" Remarks = '{0}', ", "Migrated")
                SQL &= " check_type = 'P', "
                SQL &= String.Format(" CVNumber = '{0}',", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" CVDate = '{0}',", Format(CDate(GridView1.GetRowCellValue(x, "Date Availed")), "yyyy-MM-dd"))
                SQL &= String.Format(" BankID = '{0}',", GridView1.GetRowCellValue(x, "BankID"))
                SQL &= String.Format(" branch_id = '{0}',", Branch_ID)
                SQL &= String.Format(" user_code = '{0}';", "")

                'ACCOUNTING ENTRY
                'WALA NA NI APIL SA MIGRATION LOANS RECEIVABLE NALANG TANAN
                'SQL &= "INSERT INTO accounting_entry SET"
                'SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                'SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Last Payment")), "yyyy-MM-dd"))
                'SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                'SQL &= " EntryType = 'DEBIT',"
                'SQL &= " PostStatus = 'POSTED',"
                'SQL &= String.Format(" AccountCode = '{0}', ", DataObject(String.Format("SELECT AccountCode FROM branch_bank WHERE ID = '{0}';", GridView1.GetRowCellValue(x, "BankID")))) 'CASH IN BANK
                'SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode(AccountCode) FROM branch_bank WHERE ID = '{0}';", GridView1.GetRowCellValue(x, "BankID")))) 'CASH IN BANK
                'SQL &= String.Format(" Payable = '{0}', ", (CDbl(GridView1.GetRowCellValue(x, "Principal")) + CDbl(GridView1.GetRowCellValue(x, "UDI")) + CDbl(GridView1.GetRowCellValue(x, "RPPD"))) - (CDbl(GridView1.GetRowCellValue(x, "Principal Balance")) + CDbl(GridView1.GetRowCellValue(x, "UDI Balance")) + CDbl(GridView1.GetRowCellValue(x, "RPPD Balance"))))
                'SQL &= String.Format(" Amount = '{0}', ", (CDbl(GridView1.GetRowCellValue(x, "Principal")) + CDbl(GridView1.GetRowCellValue(x, "UDI")) + CDbl(GridView1.GetRowCellValue(x, "RPPD"))) - (CDbl(GridView1.GetRowCellValue(x, "Principal Balance")) + CDbl(GridView1.GetRowCellValue(x, "UDI Balance")) + CDbl(GridView1.GetRowCellValue(x, "RPPD Balance"))))
                'SQL &= " PaidFor = 'CIB', "
                'SQL &= String.Format(" Remarks = '{0}', ", "Migrated Account")
                'SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                'SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Last Payment")), "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420003", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420004", "420007"))) 'Interest Income-Past Due
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420003", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420004", "420007"))))) 'Interest Income-Past Due
                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unpaid Penalty")))
                SQL &= String.Format(" PenaltyPayable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unpaid Penalty")))
                SQL &= " Amount = 0, "
                SQL &= String.Format(" PaidFor = '{0}', ", "Penalty")
                SQL &= String.Format(" Remarks = '{0}', ", "Penalty Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Last Payment")), "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420003", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420004", "420007"))) 'Interest Income-Past Due
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420003", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420004", "420007"))))) 'Interest Income-Past Due
                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD")) - CDbl(GridView1.GetRowCellValue(x, "RPPD Balance")))
                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD")) - CDbl(GridView1.GetRowCellValue(x, "RPPD Balance")))
                SQL &= String.Format(" PaidFor = '{0}', ", "RPPD")
                SQL &= String.Format(" Remarks = '{0}', ", "RPPD Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Last Payment")), "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420001", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420002", "420006"))) 'Interest Income-Current
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "420001", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "420002", "420006"))))) 'Interest Income-Current
                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "UDI")) - CDbl(GridView1.GetRowCellValue(x, "UDI Balance")))
                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "UDI")) - CDbl(GridView1.GetRowCellValue(x, "UDI Balance")))
                SQL &= String.Format(" PaidFor = '{0}', ", "UDI")
                SQL &= String.Format(" Remarks = '{0}', ", "UDI Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Last Payment")), "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "112001", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "112002", "112003"))) 'Loans Receivable
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(GridView1.GetRowCellValue(x, "MortgageID") = 1, "112001", If(GridView1.GetRowCellValue(x, "MortgageID") = 2, "112002", "112003"))))) 'Loans Receivable
                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")) - CDbl(GridView1.GetRowCellValue(x, "Principal Balance")))
                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal")) - CDbl(GridView1.GetRowCellValue(x, "Principal Balance")))
                SQL &= String.Format(" PaidFor = '{0}', ", "Principal")
                SQL &= String.Format(" Remarks = '{0}', ", "Principal Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
                If Exist > 0 Then
                    GoTo FillAgain
                End If
                DataObject(SQL)
                Logs("Bulk Migration", "Save", String.Format("Add new Migrated Application with Credit Number {0}.", CreditNumber), "", "", GridView1.GetRowCellValue(x, "Borrower"), CreditNumber)
            Next

            Loans.Close()
            Loans.Dispose()
            Cursor = Cursors.Default
            Clear()
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If MsgBoxYes("Are you sure you want to export this to Excel Format?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Migration Format" & "-" & Format(Date.Now, "yyyy-MM-dd_HHmmss") & ".xlsx"
            Dim Report As New RptBulkMigration
            With Report
                Dim DT As DataTable = Temp_DT.Copy
                For x As Integer = 0 To 15
                    DT.Rows.Add(x + 1)
                Next
                .DataSource = DT
                .lblBorrowerID.DataBindings.Add("Text", DT, "BorrowerID")
                .lblBusinessCenter.DataBindings.Add("Text", DT, "Business Center")
                .lblProduct.DataBindings.Add("Text", DT, "Product")
                .lblAccountNumber.DataBindings.Add("Text", DT, "Account Number")
                .lblCollateral.DataBindings.Add("Text", DT, "Collateral")
                .lblTerms.DataBindings.Add("Text", DT, "Terms")
                .lblInterestRate.DataBindings.Add("Text", DT, "Interest %")
                .lblRPPDRate.DataBindings.Add("Text", DT, "RPPD %")
                .lblDateAvailed.DataBindings.Add("Text", DT, "Date Availed")
                .lblLastPayment.DataBindings.Add("Text", DT, "Last Payment")
                .lblDueDate.DataBindings.Add("Text", DT, "Due Date")
                .lblPrincipal.DataBindings.Add("Text", DT, "Principal")
                .lblPrincipalBalance.DataBindings.Add("Text", DT, "Principal Balance")
                .lblUDI.DataBindings.Add("Text", DT, "UDI")
                .lblUDIBalance.DataBindings.Add("Text", DT, "UDI Balance")
                .lblRPPD.DataBindings.Add("Text", DT, "RPPD")
                .lblRPPDBalance.DataBindings.Add("Text", DT, "RPPD Balance")
                .lblUnpaidPenalty.DataBindings.Add("Text", DT, "Unpaid Penalty")
                .lblGMA.DataBindings.Add("Text", DT, "GMA")
                .lblMonthlyRabate.DataBindings.Add("Text", DT, "Monthly Rebate")
                .lblBank.DataBindings.Add("Text", DT, "Bank")
                .lblIndustry.DataBindings.Add("Text", DT, "Industry")
                .ExportToXlsx(FName)
                Process.Start(FName)
            End With
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.)|*.*"
            If OFD.ShowDialog = DialogResult.OK Then
                Using con As New OleDb.OleDbConnection()
                    Try
                        Cursor = Cursors.WaitCursor
                        Temp_DT.Rows.Clear()
                        Dim DT_Excel As New DataTable
                        con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", OFD.FileName)
                        Using cmd As New OleDb.OleDbCommand("SELECT * FROM [Sheet$]", con)
                            Using da As New OleDb.OleDbDataAdapter(cmd)
                                con.Open()
                                da.Fill(DT_Excel)
                                con.Close()
                            End Using
                        End Using
                        For x As Integer = 0 To DT_Excel.Rows.Count - 1
                            If DT_Excel(x)("BorrowerID").ToString.Trim = "" Then
                            Else
                                Temp_DT.Rows.Add(x + 1,
                                                 DT_Excel(x)("BorrowerID").ToString.Trim,
                                                 DataObject(String.Format("SELECT Borrower('{0}');", DT_Excel(x)("BorrowerID").ToString.Trim)),
                                                 0,
                                                 DT_Excel(x)("Business Center"),
                                                 0,
                                                 DT_Excel(x)("Product"),
                                                 DT_Excel(x)("Account Number"),
                                                 DT_Excel(x)("Collateral"),
                                                 DT_Excel(x)("Terms"),
                                                 If(DT_Excel(x)("Interest %").ToString = "", 0, DT_Excel(x)("Interest %")),
                                                 If(DT_Excel(x)("RPPD %").ToString = "", 0, DT_Excel(x)("RPPD %")),
                                                 Format(DateValue(DT_Excel(x)("Date Availed")), "yyyy-MM-dd"),
                                                 Format(DateValue(If(DT_Excel(x)("Last Payment").ToString = "", DT_Excel(x)("Date Availed"), DT_Excel(x)("Last Payment"))), "yyyy-MM-dd"),
                                                 DT_Excel(x)("Due Date"),
                                                 If(DT_Excel(x)("Principal").ToString = "", 0, DT_Excel(x)("Principal")),
                                                 If(DT_Excel(x)("Principal Balance").ToString = "", 0, DT_Excel(x)("Principal Balance")),
                                                 If(DT_Excel(x)("UDI").ToString = "", 0, DT_Excel(x)("UDI")),
                                                 If(DT_Excel(x)("UDI Balance").ToString = "", 0, DT_Excel(x)("UDI Balance")),
                                                 If(DT_Excel(x)("RPPD").ToString = "", 0, DT_Excel(x)("RPPD")),
                                                 If(DT_Excel(x)("RPPD Balance").ToString = "", 0, DT_Excel(x)("RPPD Balance")),
                                                 If(DT_Excel(x)("Unpaid Penalty").ToString = "", 0, DT_Excel(x)("Unpaid Penalty")),
                                                 If(DT_Excel(x)("GMA").ToString = "", 0, DT_Excel(x)("GMA")),
                                                 If(DT_Excel(x)("Monthly Rebate").ToString = "", 0, DT_Excel(x)("Monthly Rebate")),
                                                 0,
                                                 DT_Excel(x)("Bank"),
                                                 0,
                                                 DT_Excel(x)("Industry"), 0, "") ', DT_Excel(x)("Remarks"))
                            End If
                        Next
                        GridControl1.DataSource = Temp_DT.Copy
                        MigrationMode = True
                        With GridView1
                            For x As Integer = 0 To .RowCount - 1
                                .SetRowCellValue(x, "Business Center", .GetRowCellValue(x, "Business Center"))
                                cbxBusinessCenter.Text = .GetRowCellDisplayText(x, "Business Center")
                                .SetRowCellValue(x, "BusinessID", cbxBusinessCenter.SelectedValue)

                                .SetRowCellValue(x, "Product", .GetRowCellValue(x, "Product"))
                                cbxProduct.Text = .GetRowCellDisplayText(x, "Product")
                                .SetRowCellValue(x, "ProductID", cbxProduct.SelectedValue)
                                Dim MortgageID As Integer = DataObject(String.Format("SELECT mortgage_ID FROM product_setup WHERE ID = '{0}';", cbxProduct.SelectedValue))
                                .SetRowCellValue(x, "MortgageID", MortgageID)

                                .SetRowCellValue(x, "Bank", .GetRowCellValue(x, "Bank"))
                                cbxBank.Text = .GetRowCellDisplayText(x, "Bank")
                                .SetRowCellValue(x, "BankID", cbxBank.SelectedValue)

                                .SetRowCellValue(x, "Industry", .GetRowCellValue(x, "Industry"))
                                cbxIndustry.Text = .GetRowCellDisplayText(x, "Industry")
                                .SetRowCellValue(x, "IndustryID", cbxIndustry.SelectedValue)
                            Next
                        End With
                        MigrationMode = False
                        btnVerify.Enabled = True
                        btnSave.Enabled = False
                        Cursor = Cursors.Default
                        MsgBox("Successfully filled the table, please validate to save.", MsgBoxStyle.Information, "Info")
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        TriggerBugReport("Bulk Migration - Import", ex.Message.ToString)
                    Finally
                        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                            con.Close()
                        End If
                    End Try
                End Using
            End If
            OFD.Dispose()
        End Using
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If MigrationMode Then
            Exit Sub
        End If

        If e.Column.FieldName = "Business Center" Then
            cbxBusinessCenter.Text = GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, "Business Center")
            CbxBusinessCenter_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Product" Then
            cbxProduct.Text = GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, "Product")
            CbxProduct_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Bank" Then
            cbxBank.Text = GridView1.GetRowCellDisplayText(GridView1.FocusedRowHandle, "Bank")
            CbxBank_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxBusinessCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBusinessCenter.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "BusinessID", cbxBusinessCenter.SelectedValue)
    End Sub

    Private Sub CbxProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProduct.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "ProductID", cbxProduct.SelectedValue)
        Dim MortgageID As Integer = DataObject(String.Format("SELECT mortgage_ID FROM product_setup WHERE ID = '{0}';", cbxProduct.SelectedValue))
        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "MortgageID", MortgageID)
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "BankID", cbxBank.SelectedValue)
    End Sub

    Private Sub BtnExportNotes_Click(sender As Object, e As EventArgs) Handles btnExportNotes.Click
        Dim Report As New RptBulkMigrationSample
        With Report
            Dim Borrower As New SubRptBorrowers
            With Borrower
                .DataSource = DT_Borrower
                Report.subRptBorrower.ReportSource = Borrower
                .lblBorrowerID.DataBindings.Add("Text", DT_Borrower, "BorrowerID")
                .lblBorrowerName.DataBindings.Add("Text", DT_Borrower, "Borrower")
            End With

            Dim Business As New SubRptBusiness
            With Business
                .DataSource = DT_BusinessCenter
                Report.subRptBusiness.ReportSource = Business
                .lblBusiness.DataBindings.Add("Text", DT_BusinessCenter, "BusinessCode")
            End With

            Dim Product As New SubRptBusiness
            With Product
                .DataSource = DT_Products
                Report.subRptProduct.ReportSource = Product
                .lblBusiness.DataBindings.Add("Text", DT_Products, "Product")
            End With

            Dim Bank As New SubRptBusiness
            With Bank
                .DataSource = DT_Bank
                Report.subRptBank.ReportSource = Bank
                .lblBusiness.DataBindings.Add("Text", DT_Bank, "Bank")
            End With

            Dim PD_Bank As New SubRptBusiness
            With PD_Bank
                .DataSource = DT_Industry
                Report.subRptBank_PD.ReportSource = PD_Bank
                .lblBusiness.DataBindings.Add("Text", DT_Industry, "Nature")
            End With
            Logs("Migration", "Print", "Print Migration Sample", "", "", "", "")

            .ShowPreview()
        End With
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim ErrorX As String = ""
        Dim Num As Integer = 1
        Dim WarningX As String = ""
        Dim WarningNum As Integer = 1
        If MsgBoxYes("Are you sure you want to Validate this migration data?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor

            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Account Number") = DataObject(String.Format("SELECT AccountNumber FROM credit_application WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND AccountNumber = '{1}';", Branch_ID, GridView1.GetRowCellValue(x, "Account Number"))) Then
                    ErrorX &= Num & ".) Account Number already exist at row " & x + 1 & " (Duplicate Data)" & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Account Number").ToString.Length > 15 Then
                    ErrorX &= Num & ".) Data too long for Account Number at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "BorrowerID") = "" Or GridView1.GetRowCellValue(x, "BorrowerID").ToString.Length < 12 Then
                    ErrorX &= Num & ".) Please check your data under column BorrowerID at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellDisplayText(x, "Borrower") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Borrower at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                'If GridView1.GetRowCellDisplayText(x, "Business Center") = "" Then
                '    ErrorX &= Num & ".) Please check your data under column Business Center at row " & x + 1 & vbCrLf
                '    Num += 1
                'End If
                If GridView1.GetRowCellDisplayText(x, "Product") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Product at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                Dim MaxTerms As Integer = DataObject(String.Format("SELECT IF(Max_Terms = 0,1000,Max_Terms) FROM product_setup WHERE ID = '{0}';", GridView1.GetRowCellValue(x, "ProductID")))
                If GridView1.GetRowCellDisplayText(x, "Terms") > MaxTerms Then
                    WarningX &= WarningNum & String.Format(".) Product is only allowed up to {0} Term(s) Please check your Terms at row ", MaxTerms) & x + 1 & vbCrLf
                    WarningNum += 1
                End If
                If GridView1.GetRowCellValue(x, "Account Number") = "" Then
                    ErrorX &= Num & ".) Please check your data under column Account Number at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Collateral").ToString = "" And (GridView1.GetRowCellValue(x, "MortgageID") = 1 Or GridView1.GetRowCellValue(x, "MortgageID") = 2) Then
                    ErrorX &= Num & ".) Please check your data under column Collateral Number at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Collateral").ToString.Length > 255 Then
                    ErrorX &= Num & ".) Data too long for Collateral at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Terms").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Terms")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Amount Terms at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Interest %").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Interest %")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Interest Rate at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "RPPD %").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "RPPD %")) = False Then
                    ErrorX &= Num & ".) Please check your data under column RPPD Rate at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Date Availed").ToString = "" Or IsDate(GridView1.GetRowCellValue(x, "Date Availed")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Date Availed at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If If(IsDate(GridView1.GetRowCellValue(x, "Date Availed")), CDate(GridView1.GetRowCellValue(x, "Date Availed")), Date.Now) > Date.Now Then
                    ErrorX &= Num & ".) Date Availed at row " & x + 1 & " is at the future." & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Last Payment") = "" Or IsDate(GridView1.GetRowCellValue(x, "Last Payment")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Last Payment at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If If(IsDate(GridView1.GetRowCellValue(x, "Last Payment")), CDate(GridView1.GetRowCellValue(x, "Last Payment")), Date.Now) > Date.Now Then
                    ErrorX &= Num & ".) Last Payment at row " & x + 1 & " is at the future." & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Due Date").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Due Date")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Due Date at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If If(IsNumeric(GridView1.GetRowCellValue(x, "Due Date")), GridView1.GetRowCellValue(x, "Due Date"), 32) > 31 Then
                    ErrorX &= Num & ".) Please check your data under column Due Date higher than 31 days at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Principal").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Principal")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Principal at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Principal Balance").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Principal Balance")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Principal Balance at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If IsNumeric(GridView1.GetRowCellValue(x, "Principal Balance")) And IsNumeric(GridView1.GetRowCellValue(x, "Principal")) Then
                    If CDbl(GridView1.GetRowCellValue(x, "Principal Balance")) > CDbl(GridView1.GetRowCellValue(x, "Principal")) Then
                        WarningX &= WarningNum & ".) Principal Balance is greater than Principal, Please check your data at row  " & x + 1 & vbCrLf
                        WarningNum += 1
                    End If
                End If
                If GridView1.GetRowCellValue(x, "UDI").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "UDI")) = False Then
                    ErrorX &= Num & ".) Please check your data under column UDI at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "UDI Balance").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "UDI Balance")) = False Then
                    ErrorX &= Num & ".) Please check your data under column UDI Balance at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If IsNumeric(GridView1.GetRowCellValue(x, "UDI Balance")) And IsNumeric(GridView1.GetRowCellValue(x, "UDI")) Then
                    If CDbl(GridView1.GetRowCellValue(x, "UDI Balance")) > CDbl(GridView1.GetRowCellValue(x, "UDI")) Then
                        WarningX &= WarningNum & ".) UDI Balance is greater than UDI, Please check your data at row  " & x + 1 & vbCrLf
                        WarningNum += 1
                    End If
                End If
                If GridView1.GetRowCellValue(x, "RPPD").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "RPPD")) = False Then
                    ErrorX &= Num & ".) Please check your data under column RPPD at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "RPPD Balance").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "RPPD Balance")) = False Then
                    ErrorX &= Num & ".) Please check your data under column RPPD Balance at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If IsNumeric(GridView1.GetRowCellValue(x, "RPPD Balance")) And IsNumeric(GridView1.GetRowCellValue(x, "RPPD")) Then
                    If CDbl(GridView1.GetRowCellValue(x, "RPPD Balance")) > CDbl(GridView1.GetRowCellValue(x, "RPPD")) Then
                        WarningX &= WarningNum & ".) RPPD Balance is greater than RPPD, Please check your data at row  " & x + 1 & vbCrLf
                        WarningNum += 1
                    End If
                End If
                If GridView1.GetRowCellValue(x, "Unpaid Penalty").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Unpaid Penalty")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Unpaid Penalty at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "GMA").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "GMA")) = False Then
                    ErrorX &= Num & ".) Please check your data under column GMA at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Monthly Rebate").ToString = "" Or IsNumeric(GridView1.GetRowCellValue(x, "Monthly Rebate")) = False Then
                    ErrorX &= Num & ".) Please check your data under column Monthly Rebate at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                If IsNumeric(GridView1.GetRowCellValue(x, "Monthly Rebate")) And IsNumeric(GridView1.GetRowCellValue(x, "GMA")) Then
                    If CDbl(GridView1.GetRowCellValue(x, "Monthly Rebate")) > CDbl(GridView1.GetRowCellValue(x, "GMA")) Then
                        ErrorX &= Num & ".) Monthly Rebate is greater than GMA, Please check your data at row  " & x + 1 & vbCrLf
                        Num += 1
                    End If
                End If
                If GridView1.GetRowCellDisplayText(x, "Bank").ToString = "" Then
                    ErrorX &= Num & ".) Please check your data under column Bank at row  " & x + 1 & vbCrLf
                    Num += 1
                End If
                'If (GridView1.GetRowCellDisplayText(x, "Product").ToString.Contains("PAYDAY") Or GridView1.GetRowCellDisplayText(x, "Product").ToString.Contains("SHOWMONEY")) And GridView1.GetRowCellDisplayText(x, "PDL/SML Bank").ToString = "" Then
                '    ErrorX &= Num & ".) Please check your data under column PDL/SML Bank at row " & x + 1 & vbCrLf
                '    Num += 1
                'End If
                'If (GridView1.GetRowCellDisplayText(x, "Product").ToString.Contains("PAYDAY") Or GridView1.GetRowCellDisplayText(x, "Product").ToString.Contains("SHOWMONEY")) And GridView1.GetRowCellDisplayText(x, "PDL/SML Account").ToString = "" Then
                '    ErrorX &= Num & ".) Please check your data under column PDL/SML Account at row " & x + 1 & vbCrLf
                '    Num += 1
                'End If
                If GridView1.GetRowCellValue(x, "Industry").ToString.Length > 50 Then
                    ErrorX &= Num & ".) Data too long for Industry at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView1.GetRowCellValue(x, "Remarks").ToString.Length > 255 Then
                    ErrorX &= Num & ".) Data too long for Remarks at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                For y As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Account Number") = GridView1.GetRowCellValue(y, "Account Number") And x < y Then
                        ErrorX &= Num & ".) Duplicate Account Number for row  " & x + 1 & " and row " & y + 1 & vbCrLf
                        Num += 1
                    End If
                Next
            Next

            Cursor = Cursors.Default
            If ErrorX = "" Then
                If WarningX = "" Then
                Else
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Batch Migration Warning Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                    IO.File.AppendAllText(FName, "*** W A R N I N G   I N   M I G R A T I O N ***" & vbCrLf & vbCrLf & WarningX & vbCrLf & vbCrLf & "*** W A R N I N G   I N   M I G R A T I O N ***", System.Text.Encoding.UTF8)
                    Process.Start(FName)
                End If
                MsgBox("Successfully Validated!", MsgBoxStyle.Information, "Info")
                btnSave.Enabled = True
            Else
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Batch Migration Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                IO.File.AppendAllText(FName, "*** E R R O R   I N   M I G R A T I O N ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   M I G R A T I O N ***", System.Text.Encoding.UTF8)
                Process.Start(FName)

                btnSave.Enabled = False
            End If
        End If
    End Sub
End Class