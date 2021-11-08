Imports DevExpress.XtraReports.UI
Public Class FrmBooksCD

    Dim Temp_DT As DataTable
    Public BankID As Integer
    Public xBranchID As String
    Public xBranchCode As String
    Dim MigrationMode As Boolean
    Public FirstLoad As Boolean = True

    Private Sub FrmImportBooksGJ_v2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadPayee()

        With cbxBank
            .ValueMember = "Code"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, `Code`, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, AccountCode FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), DefaultBankID))
            .SelectedValue = BankID
        End With

        With cbxBank
            .ValueMember = "Code"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, `Code`, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, AccountCode FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), DefaultBankID))
            .SelectedValue = BankID
        End With

        With RepositoryItemLookUpEdit5
            .ValueMember = "Bank"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), DefaultBankID))
        End With

        Dim DT_Employee As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee' FROM employee_setup WHERE `status` = 'ACTIVE' AND FIND_IN_SET(branch_id, '{0}') ORDER BY `Employee`;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        Dim DT_EmployeeNoID As DataTable = DataSource(String.Format("SELECT Employee(ID) AS 'Employee' FROM employee_setup WHERE `status` = 'ACTIVE' AND FIND_IN_SET(branch_id, '{0}') ORDER BY `Employee`;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employee.Copy
            .SelectedIndex = -1
        End With

        With cbxCheckedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employee.Copy
            .SelectedIndex = -1
        End With

        With cbxApprovedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employee.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit6
            .DisplayMember = "Employee"
            .ValueMember = "Employee"
            .DataSource = DT_EmployeeNoID.Copy
        End With

        With cbxAccount
            .DisplayMember = "Account"
            .ValueMember = "Account Code"
            .DataSource = DT_Accounts.Copy
        End With

        With RepositoryItemSearchLookUpEdit1
            .DisplayMember = "Account"
            .ValueMember = "Account"
            .DataSource = DT_Accounts_V2.Copy
        End With

        With cbxDepartment
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
        End With

        With RepositoryItemLookUpEdit3
            .DisplayMember = "Department"
            .ValueMember = "Department"
            .DataSource = DT_Department.Copy
        End With

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit4
            .DisplayMember = "BusinessCenter"
            .ValueMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter_V2.Copy
        End With

        Temp_DT = DataSource(String.Format("SELECT 0 AS 'No', '' AS 'Reference No','' AS 'Payee','' AS 'Document Date','' AS 'Posting Date', '' AS 'Check No','' AS 'Check Date','' AS 'Clear Date',0 AS 'BankID','' AS 'Bank','' AS 'Explanation','' AS 'Account Code','' AS 'Department Code','' AS 'Account','' AS 'Business Center','' AS 'Department',0.00 AS 'Debit',0.00 AS 'Credit','' AS 'PaidFor','' AS 'Remarks','' AS 'BusinessCode','' AS 'Type_ID','' AS 'MotherCode','' AS 'Prepared By','' AS 'Checked By','' AS 'Approved By', '' AS 'Received By', '' AS 'Received Date', False AS 'RequiredRemarks', 0 AS 'PreparedID', 0 AS 'CheckedID', 0 AS 'ApprovedID',0 AS 'PayeeID', '' AS 'PayeeType' LIMIT 0"))
        GridControl2.DataSource = Temp_DT
        FirstLoad = False
    End Sub

    Private Sub LoadPayee()
        cbxPayee.DisplayMember = "Supplier"
        cbxPayee.ValueMember = "ID"
        Dim SQL As String = " SELECT "
        SQL &= "    ID,"
        SQL &= "    UPPER(Branch) AS 'Supplier',"
        SQL &= "    'B' AS 'Type'"
        SQL &= " FROM branch WHERE `status` = 'ACTIVE'"

        SQL &= " UNION ALL"
        SQL &= " SELECT  ID,"
        SQL &= "    Employee (ID) AS 'Supplier',"
        SQL &= "    'E' AS 'Type'"
        SQL &= " FROM employee_setup"
        SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)

        SQL &= " UNION ALL"
        SQL &= " SELECT ID,"
        SQL &= "    UPPER(Supplier) AS 'Supplier',"
        SQL &= "    'S' AS 'Type'"
        SQL &= " FROM supplier_setup"
        SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)
        cbxPayee.DataSource = DataSource(SQL)

        With RepositoryItemLookUpEdit7
            .DisplayMember = "Supplier"
            .ValueMember = "Supplier"
            .DataSource = DataSource(SQL.Replace("ID,", ""))
        End With
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

            GetButtonFontSettings({btnSave, btnVerify, btnRefresh, btnCancel, btnImport, btnExport, btnAdd_Account, btnRemove_Account})

            GetComboBoxFontSettings({cbxPayee, cbxBank, cbxAccount, cbxDepartment, cbxBusinessCenter, cbxPreparedBy, cbxCheckedBy, cbxApprovedBy})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit2, RepositoryItemLookUpEdit1, RepositoryItemLookUpEdit4, RepositoryItemLookUpEdit5, RepositoryItemLookUpEdit6})
        Catch ex As Exception
            TriggerBugReport("Books CD - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Import Books of Account [Check Disbursement]", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.)|*.*"
        }
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
                        If DT_Excel(x)("Account Code").ToString <> "" Then
                            Temp_DT.Rows.Add(x + 1, DT_Excel(x)("Reference No").ToString.Trim, DT_Excel(x)("Payee").ToString.ToUpper.Trim, If(IsDate(DT_Excel(x)("Document Date")) = False, "", Format(CDate(DT_Excel(x)("Document Date")), "MMM dd, yyyy")), If(IsDate(DT_Excel(x)("Posting Date")) = False, "", Format(CDate(DT_Excel(x)("Posting Date")), "MMM dd, yyyy")), DT_Excel(x)("Check No"), If(IsDate(DT_Excel(x)("Check Date")) = False, "", Format(CDate(DT_Excel(x)("Check Date")), "MMM dd, yyyy")), If(IsDate(DT_Excel(x)("Clear Date")) = False, "", Format(CDate(DT_Excel(x)("Clear Date")), "MMM dd, yyyy")), DT_Excel(x)("Bank Code").ToString.Trim, "", DT_Excel(x)("Explanation"), DT_Excel(x)("Account Code").ToString.Trim, DT_Excel(x)("Department Code").ToString.ToUpper.Trim, "", "", "", If(DT_Excel(x)("Debit").ToString = "", 0, CDbl(DT_Excel(x)("Debit"))), If(DT_Excel(x)("Credit").ToString = "", 0, CDbl(DT_Excel(x)("Credit"))), "", DT_Excel(x)("Remarks"), DT_Excel(x)("Business Code").ToString.ToUpper.Trim, 0, "", DT_Excel(x)("Prepared By").ToString.ToUpper.Trim, DT_Excel(x)("Checked By").ToString.ToUpper.Trim, DT_Excel(x)("Approved By").ToString.ToUpper.Trim, DT_Excel(x)("Received By").ToString.ToUpper.Trim, If(IsDate(DT_Excel(x)("Received Date")) = False, "", Format(CDate(DT_Excel(x)("Received Date")), "MMM dd, yyyy")), False, 0, 0, 0, 0, "")
                        End If
                    Next
                    GridControl2.DataSource = Temp_DT
                    With GridView2
                        .Columns("Debit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
                        .Columns("Credit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                        .Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
                    End With
                    MigrationMode = True
                    With GridView2
                        For x As Integer = 0 To .RowCount - 1
                            .SetRowCellValue(x, "Payee", .GetRowCellValue(x, "Payee"))
                            cbxPayee.Text = .GetRowCellDisplayText(x, "Payee").ToString
                            If cbxPayee.SelectedIndex <> -1 Then
                                Dim drvP As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                                .SetRowCellValue(x, "PayeeID", cbxPayee.SelectedValue)
                                .SetRowCellValue(x, "PayeeType", drvP("Type").ToString)
                                cbxPayee.SelectedIndex = -1
                            End If

                            .SetRowCellValue(x, "BusinessCode", .GetRowCellValue(x, "BusinessCode"))
                            cbxBusinessCenter.SelectedValue = .GetRowCellDisplayText(x, "BusinessCode").ToString
                            .SetRowCellValue(x, "Business Center", cbxBusinessCenter.Text)

                            .SetRowCellValue(x, "BankID", .GetRowCellValue(x, "BankID"))
                            cbxBank.SelectedValue = .GetRowCellDisplayText(x, "BankID")
                            .SetRowCellValue(x, "Bank", cbxBank.Text)

                            .SetRowCellValue(x, "Department Code", .GetRowCellValue(x, "Department Code"))
                            cbxDepartment.SelectedValue = .GetRowCellDisplayText(x, "Department Code").ToString
                            .SetRowCellValue(x, "Department", cbxDepartment.Text)

                            .SetRowCellValue(x, "Account Code", .GetRowCellValue(x, "Account Code"))
                            cbxAccount.SelectedValue = .GetRowCellDisplayText(x, "Account Code").ToString
                            If cbxAccount.SelectedIndex <> -1 Then
                                Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
                                .SetRowCellValue(x, "Account", cbxAccount.Text)
                                .SetRowCellValue(x, "MotherCode", drv("MotherCode"))
                                .SetRowCellValue(x, "Type_ID", drv("Type_ID"))
                                .SetRowCellValue(x, "RequiredRemarks", CBool(drv("Remarks")))
                            End If

                            .SetRowCellValue(x, "Prepared By", .GetRowCellValue(x, "Prepared By"))
                            cbxPreparedBy.Text = .GetRowCellDisplayText(x, "Prepared By").ToString
                            .SetRowCellValue(x, "PreparedID", cbxPreparedBy.SelectedValue)
                            cbxPreparedBy.SelectedIndex = -1

                            .SetRowCellValue(x, "Checked By", .GetRowCellValue(x, "Checked By"))
                            cbxCheckedBy.Text = .GetRowCellDisplayText(x, "Checked By").ToString
                            .SetRowCellValue(x, "CheckedID", cbxCheckedBy.SelectedValue)
                            cbxCheckedBy.SelectedIndex = -1

                            .SetRowCellValue(x, "Approved By", .GetRowCellValue(x, "Approved By"))
                            cbxApprovedBy.Text = .GetRowCellDisplayText(x, "Approved By").ToString
                            .SetRowCellValue(x, "ApprovedID", cbxApprovedBy.SelectedValue)
                            cbxApprovedBy.SelectedIndex = -1
                        Next
                    End With
                    MigrationMode = False
                    btnVerify.Enabled = True
                    btnSave.Enabled = False
                    GridView2.OptionsBehavior.Editable = True
                    btnAdd_Account.Enabled = True
                    If GridView2.RowCount > 0 Then
                        btnRemove_Account.Enabled = True
                    End If
                    Cursor = Cursors.Default
                    btnVerify.PerformClick()
                Catch ex As Exception
                    Cursor = Cursors.Default
                    TriggerBugReport("Books CD - Import", ex.Message.ToString)
                Finally
                    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try
            End Using
        End If
        OFD.Dispose()
    End Sub

    Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
        Dim Rows As New ArrayList()
        With GridView2
            Dim selectedRowHandles As Integer() = .GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim TotalD As Double
                Dim TotalC As Double
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(x)
                    TotalD += .GetRowCellValue(selectedRowHandle, "Debit")
                    TotalC += .GetRowCellValue(selectedRowHandle, "Credit")
                Next
                .Columns("Debit").SummaryItem.DisplayFormat = FormatNumber(TotalD, 2)
                .Columns("Credit").SummaryItem.DisplayFormat = FormatNumber(TotalC, 2)
            Else
                .Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
            End If
        End With
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If MigrationMode Then
            Exit Sub
        End If

        If e.Column.FieldName = "BusinessCode" Then
            cbxBusinessCenter.SelectedValue = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "BusinessCode")
            CbxBusinessCenter_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "BankID" Then
            cbxBank.SelectedValue = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "BankID")
            CbxBank_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Account Code" Then
            cbxAccount.SelectedValue = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Account Code")
            CbxAccount_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Department Code" Then
            cbxDepartment.SelectedValue = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Department Code")
            CbxDepartment_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Prepared By" Then
            cbxPreparedBy.Text = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Prepared By")
            CbxPreparedBy_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Checked By" Then
            cbxCheckedBy.Text = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Checked By")
            CbxCheckedBy_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Approved By" Then
            cbxApprovedBy.Text = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Approved By")
            CbxApprovedBy_SelectedIndexChanged(sender, e)
        ElseIf e.Column.FieldName = "Payee" Then
            cbxPayee.Text = GridView2.GetRowCellDisplayText(GridView2.FocusedRowHandle, "Payee")
            CbxPayee_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim ErrorX As String = ""
        Dim WarningX As String = ""
        Dim Num As Integer = 1
        Dim WarningNum As Integer = 1
        If MsgBoxYes("Are you sure you want to Validate this data?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim TotalDR As Double
            Dim TotalCR As Double
            Dim PrevJV As String = ""
            Dim Payee As String = ""
            Dim DocDate As String = ""
            Dim PosDate As String = ""
            Dim CheckNo As String = ""
            Dim CheckDate As String = ""
            Dim ClearDate As String = ""
            Dim PrevPrep As String = ""
            Dim PrevCheck As String = ""
            Dim PrevApprove As String = ""
            Dim PrevReceive As String = ""
            Dim PrevReceiveDate As String = ""
            For x As Integer = 0 To GridView2.RowCount - 1
                If x = 0 Then
                    PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No")
                    Payee = GridView2.GetRowCellDisplayText(x, "Payee")
                    DocDate = GridView2.GetRowCellDisplayText(x, "Document Date")
                    PosDate = GridView2.GetRowCellDisplayText(x, "Posting Date")
                    CheckNo = GridView2.GetRowCellDisplayText(x, "Check No")
                    CheckDate = GridView2.GetRowCellDisplayText(x, "Check Date")
                    ClearDate = GridView2.GetRowCellDisplayText(x, "Clear Date")
                    PrevPrep = GridView2.GetRowCellDisplayText(x, "Prepared By")
                    PrevCheck = GridView2.GetRowCellDisplayText(x, "Checked By")
                    PrevApprove = GridView2.GetRowCellDisplayText(x, "Approved By")
                    PrevReceive = GridView2.GetRowCellDisplayText(x, "Received By")
                    PrevReceiveDate = GridView2.GetRowCellDisplayText(x, "Received Date")
                    TotalDR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Debit")), GridView2.GetRowCellDisplayText(x, "Debit"), 0)
                    TotalCR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Credit")), GridView2.GetRowCellDisplayText(x, "Credit"), 0)
                Else
                    If PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No") Then
                        TotalDR += If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Debit")), GridView2.GetRowCellDisplayText(x, "Debit"), 0)
                        TotalCR += If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Credit")), GridView2.GetRowCellDisplayText(x, "Credit"), 0)
                        If Payee <> GridView2.GetRowCellDisplayText(x, "Payee") Then
                            WarningX &= WarningNum & ".) Payee is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If DocDate <> GridView2.GetRowCellDisplayText(x, "Document Date") Then
                            WarningX &= WarningNum & ".) Document Date is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PosDate <> GridView2.GetRowCellDisplayText(x, "Posting Date") And GridView2.GetRowCellDisplayText(x, "Posting Date") <> "" And PosDate <> "" Then
                            WarningX &= WarningNum & ".) Posting Date is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If CheckNo <> GridView2.GetRowCellDisplayText(x, "Check No") Then
                            WarningX &= WarningNum & ".) Check No is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If CheckDate <> GridView2.GetRowCellDisplayText(x, "Check Date") Then
                            WarningX &= WarningNum & ".) Check Date is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If ClearDate <> GridView2.GetRowCellDisplayText(x, "Clear Date") And GridView2.GetRowCellDisplayText(x, "Clear Date") <> "" And ClearDate <> "" Then
                            WarningX &= WarningNum & ".) Clear Date is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PrevPrep <> GridView2.GetRowCellDisplayText(x, "Prepared By") Then
                            WarningX &= WarningNum & ".) Prepared By is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PrevCheck <> GridView2.GetRowCellDisplayText(x, "Checked By") And PrevCheck <> "" And GridView2.GetRowCellDisplayText(x, "Checked By") <> "" Then
                            WarningX &= WarningNum & ".) Checked By is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PrevApprove <> GridView2.GetRowCellDisplayText(x, "Approved By") And PrevApprove <> "" And GridView2.GetRowCellDisplayText(x, "Approved By") <> "" Then
                            WarningX &= WarningNum & ".) Approved By is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PrevReceive <> GridView2.GetRowCellDisplayText(x, "Received By") And PrevReceive <> "" And GridView2.GetRowCellDisplayText(x, "Received By") <> "" Then
                            WarningX &= WarningNum & ".) Received By is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                        If PrevReceiveDate <> GridView2.GetRowCellDisplayText(x, "Received Date") And GridView2.GetRowCellDisplayText(x, "Received Date") <> "" And PrevReceiveDate <> "" Then
                            WarningX &= WarningNum & ".) Received Date is not the same with the 1st row for Reference No " & PrevJV & " at row " & x & " (Only the first row for the each reference no will be used)" & vbCrLf
                            WarningNum += 1
                        End If
                    Else
                        If TotalDR = TotalCR Then
                        Else
                            ErrorX &= Num & ".) Total Debit and CR is not equal for Reference No " & PrevJV & " at row " & x & vbCrLf
                            Num += 1
                        End If
                        TotalDR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Debit")), GridView2.GetRowCellDisplayText(x, "Debit"), 0)
                        TotalCR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Credit")), GridView2.GetRowCellDisplayText(x, "Credit"), 0)
                        PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No")
                        Payee = GridView2.GetRowCellDisplayText(x, "Payee")
                        DocDate = GridView2.GetRowCellDisplayText(x, "Document Date")
                        PosDate = GridView2.GetRowCellDisplayText(x, "Posting Date")
                        CheckNo = GridView2.GetRowCellDisplayText(x, "Check No")
                        CheckDate = GridView2.GetRowCellDisplayText(x, "Check Date")
                        ClearDate = GridView2.GetRowCellDisplayText(x, "Clear Date")
                        PrevPrep = GridView2.GetRowCellDisplayText(x, "Prepared By")
                        PrevCheck = GridView2.GetRowCellDisplayText(x, "Checked By")
                        PrevApprove = GridView2.GetRowCellDisplayText(x, "Approved By")
                        PrevReceive = GridView2.GetRowCellDisplayText(x, "Received By")
                        PrevReceiveDate = GridView2.GetRowCellDisplayText(x, "Received Date")
                    End If
                End If

                Dim Open As String
                Open = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(DateValue(GridView2.GetRowCellDisplayText(x, "Posting Date")), "yyyy"), Format(DateValue(GridView2.GetRowCellDisplayText(x, "Posting Date")), "MMM")))
                If If(Open = "", "Open", Open) = "Open" Then
                Else
                    MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
                    Exit Sub
                    ErrorX &= Num & ".) " & String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))) & PrevJV & " at row " & x + 1 & vbCrLf
                    Num += 1
                End If

                If x = GridView2.RowCount - 1 Then
                    If TotalDR = TotalCR Then
                    Else
                        ErrorX &= Num & ".) Total Debit and CR is not equal for Reference No " & PrevJV & " at row " & x + 1 & vbCrLf
                        Num += 1
                    End If
                    TotalDR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Debit")), GridView2.GetRowCellDisplayText(x, "Debit"), 0)
                    TotalCR = If(IsNumeric(GridView2.GetRowCellDisplayText(x, "Credit")), GridView2.GetRowCellDisplayText(x, "Credit"), 0)
                    PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No")
                End If
                If GridView2.GetRowCellDisplayText(x, "Reference No") = "" Then
                    ErrorX &= Num & ".) Reference No is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Payee") = "" Then
                    ErrorX &= Num & ".) Payee is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Document Date").ToString = "" Then
                    ErrorX &= Num & ".) Document Date is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Check No") = "" Then
                    ErrorX &= Num & ".) Check No is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Check Date").ToString = "" Then
                    ErrorX &= Num & ".) Check Date is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Bank") = "" Then
                    ErrorX &= Num & ".) Bank is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Account").ToString = "" Then
                    ErrorX &= Num & ".) Account is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Debit") > 0 And GridView2.GetRowCellDisplayText(x, "Credit") > 0 Then
                    ErrorX &= Num & ".) Debit and Credit are filled at row" & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Prepared By").ToString = "" Then
                    ErrorX &= Num & ".) Prepared By is empty at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Checked By").ToString = "" And GridView2.GetRowCellDisplayText(x, "Approved By").ToString <> "" Then
                    ErrorX &= Num & ".) Checked By is empty but Approved By have a data, please check your data at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Checked By").ToString = "" And GridView2.GetRowCellDisplayText(x, "Approved By").ToString = "" Then
                    WarningX &= WarningNum & ".) Checked By and Approved By is Empty, status will be For Checking at row " & x + 1 & vbCrLf
                    WarningNum += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Checked By").ToString <> "" And GridView2.GetRowCellDisplayText(x, "Approved By").ToString = "" Then
                    WarningX &= WarningNum & ".) Approved By is empty, status will be For Approval at row " & x + 1 & vbCrLf
                    WarningNum += 1
                End If
                If GridView2.GetRowCellDisplayText(x, "Approved By").ToString <> "" And GridView2.GetRowCellDisplayText(x, "Received By").ToString = "" Then
                    WarningX &= WarningNum & ".) Received By is empty, status will be For Releasing at row " & x + 1 & vbCrLf
                    WarningNum += 1
                End If
                If DataObject(String.Format("SELECT IFNULL(`Code`,'') FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code").ToString)) <> GridView2.GetRowCellValue(x, "Account Code").ToString Then
                    ErrorX &= Num & ".) Account Code does not exist at row " & x + 1 & vbCrLf
                    Num += 1
                End If
                If GridView2.GetRowCellValue(x, "Account Code").ToString <> "" And GridView2.GetRowCellValue(x, "MotherCode").ToString = "" Then
                    ErrorX &= Num & ".) Please check your account code at row " & x + 1 & vbCrLf
                    Num += 1
                End If

                'WARNING
                If DataObject(String.Format("SELECT IFNULL(ReferenceNumber,'') FROM check_voucher WHERE ReferenceNumber = '{0}' AND DocumentDate = '{1}' AND Branch_ID = '{2}' AND `status` = 'ACTIVE'", GridView2.GetRowCellValue(x, "Reference No").ToString, Format(DateValue(GridView2.GetRowCellValue(x, "Document Date")), "yyyy-MM-dd"), Branch_ID)) = GridView2.GetRowCellValue(x, "Reference No").ToString Then
                    WarningX &= WarningNum & ".) Reference No " & GridView2.GetRowCellValue(x, "Reference No").ToString & " might already exist in the system, please check your data at row " & x + 1 & vbCrLf
                    WarningNum += 1
                End If
            Next

            Cursor = Cursors.Default
            If ErrorX = "" Then
                If WarningX = "" Then
                Else
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import Check Disbursement Warning Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                    IO.File.AppendAllText(FName, "*** W A R N I N G   I N   I M P O R T   C H E C K   D I S B U R S E M E N T ***" & vbCrLf & vbCrLf & WarningX & vbCrLf & vbCrLf & "*** W A R N I N G   I N   I M P O R T   C H E C K   D I S B U R S E M E N T ***", System.Text.Encoding.UTF8)
                    Process.Start(FName)
                End If
                MsgBox("Successfully Validated!", MsgBoxStyle.Information, "Info")
                GridView2.OptionsBehavior.Editable = False
                btnAdd_Account.Enabled = False
                btnRemove_Account.Enabled = False
                btnSave.Enabled = True
            Else
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Import Check Disbursement Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                IO.File.AppendAllText(FName, "*** E R R O R   I N   I M P O R T   C H E C K   D I S B U R S E M E N T ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   I M P O R T   C H E C K   D I S B U R S E M E N T ***", System.Text.Encoding.UTF8)
                Process.Start(FName)

                btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim SQL As String = ""
                Dim PrevJV As String = ""
                Dim DocumentNumber As String = ""
                Dim PrevDocumentNumber As String = ""
                Dim OTAC As String = Format(Date.Now, "MMddHHmm")
                For x As Integer = 0 To GridView2.RowCount - 1
                    If x = 0 Then
                        PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No")
                        DocumentNumber = DataObject(String.Format("SELECT CONCAT('CV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM check_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", xBranchID, xBranchCode, Format(DateValue(GridView2.GetRowCellDisplayText(x, "Document Date")), "yy"), Format(DateValue(GridView2.GetRowCellDisplayText(x, "Document Date")), "yyyy-MM-dd")))
                    Else
                        If PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No") Then
                            PrevDocumentNumber = DocumentNumber
                        Else
                            DataObject(SQL)
                            PrevJV = GridView2.GetRowCellDisplayText(x, "Reference No")
                            DocumentNumber = DataObject(String.Format("SELECT CONCAT('CV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM check_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", xBranchID, xBranchCode, Format(DateValue(GridView2.GetRowCellDisplayText(x, "Document Date")), "yy"), Format(DateValue(GridView2.GetRowCellDisplayText(x, "Document Date")), "yyyy-MM-dd")))
                        End If
                    End If

                    If DocumentNumber <> PrevDocumentNumber Then
                        SQL = "INSERT INTO check_voucher SET"
                        SQL &= String.Format(" Payee_ID = '{0}', ", GridView2.GetRowCellDisplayText(x, "PayeeID"))
                        SQL &= String.Format(" Payee = '{0}', ", GridView2.GetRowCellDisplayText(x, "Payee"))
                        SQL &= String.Format(" Payee_Type = '{0}', ", GridView2.GetRowCellDisplayText(x, "PayeeType").ToString.InsertQuote)
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Document Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", DocumentNumber)
                        SQL &= String.Format(" PostingDate = '{0}', ", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Posting Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" ReferenceNumber = '{0}', ", GridView2.GetRowCellDisplayText(x, "Reference No"))
                        SQL &= String.Format(" CheckNumber = '{0}', ", GridView2.GetRowCellDisplayText(x, "Check No"))
                        SQL &= String.Format(" CheckDate = '{0}', ", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Check Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" ClearedDate = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "Clear Date").ToString = "", "", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Clear Date")), "yyyy-MM-dd")))
                        SQL &= String.Format(" BankID = '{0}', ", BankID)
                        SQL &= String.Format(" Explanation = '{0}', ", GridView2.GetRowCellDisplayText(x, "Explanation").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}', ", 0)
                        SQL &= String.Format(" PreparedID = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "PreparedID").ToString = "", 0, GridView2.GetRowCellDisplayText(x, "PreparedID")))
                        SQL &= String.Format(" CheckedID = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString = "", 0, GridView2.GetRowCellDisplayText(x, "CheckedID")))
                        SQL &= String.Format(" ApprovedID = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", 0, GridView2.GetRowCellDisplayText(x, "ApprovedID")))
                        SQL &= String.Format(" ReceivedBy = '{0}', ", GridView2.GetRowCellDisplayText(x, "Received By"))
                        SQL &= String.Format(" ReceivedDate = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "Received Date").ToString = "", "", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Received Date")), "yyyy-MM-dd")))
                        SQL &= String.Format(" OTAC_Check = '{0}', ", OTAC)
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", OTAC)
                        SQL &= String.Format(" voucher_status = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString = "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "PENDING", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString <> "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "CHECKED", If(GridView2.GetRowCellDisplayText(x, "Received By").ToString <> "", "RECEIVED", "APPROVED"))))
                        SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                        SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" Branch_ID = '{0}';", xBranchID)
                    End If

                    SQL &= "INSERT INTO cv_details SET"
                    SQL &= String.Format(" DocumentNumber = '{0}', ", DocumentNumber)
                    SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                    SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                    SQL &= String.Format(" BusinessCode = '{0}', ", If(GridView2.GetRowCellValue(x, "BusinessCode").ToString = "", 0, GridView2.GetRowCellValue(x, "BusinessCode")))
                    SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                    SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                    SQL &= String.Format(" Required = '{0}', ", GridView2.GetRowCellValue(x, "RequiredRemarks"))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(If(GridView2.GetRowCellValue(x, "Debit").ToString = "" Or GridView2.GetRowCellValue(x, "Debit").ToString = 0, GridView2.GetRowCellValue(x, "Credit"), GridView2.GetRowCellValue(x, "Debit"))))
                    SQL &= String.Format(" `Type` = '{0}', ", If(GridView2.GetRowCellValue(x, "Debit").ToString = "" Or GridView2.GetRowCellValue(x, "Debit").ToString = 0, "C", "D"))
                    SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                    'Accounting Entries
                    SQL &= "INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" CVNum = '{0}', ", DocumentNumber)
                    SQL &= String.Format(" ORDate = '{0}', ", Format(DateValue(GridView2.GetRowCellDisplayText(x, "Posting Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellDisplayText(x, "PayeeID"))
                    SQL &= String.Format(" EntryType = '{0}', ", If(GridView2.GetRowCellValue(x, "Debit") > 0, "DEBIT", "CREDIT"))
                    SQL &= String.Format(" `status` = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString = "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "PENDING", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString <> "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "PENDING", "ACTIVE")))
                    SQL &= String.Format(" PostStatus = '{0}', ", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString = "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "PENDING", If(GridView2.GetRowCellDisplayText(x, "CheckedID").ToString <> "" And GridView2.GetRowCellDisplayText(x, "ApprovedID").ToString = "", "PENDING", "POSTED")))
                    SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                    SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                    SQL &= String.Format(" Payable = '{0}', ", CDbl(If(GridView2.GetRowCellValue(x, "Debit") > 0, GridView2.GetRowCellValue(x, "Debit"), GridView2.GetRowCellValue(x, "Credit"))))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(If(GridView2.GetRowCellValue(x, "Debit") > 0, GridView2.GetRowCellValue(x, "Debit"), GridView2.GetRowCellValue(x, "Credit"))))
                    SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                    SQL &= String.Format(" BankID = '{0}', ", GridView2.GetRowCellValue(x, "BankID"))
                    SQL &= String.Format(" branch_id = '{0}';", xBranchID)
                Next

                If SQL = "" Then
                Else
                    DataObject(SQL)
                    DataObject(String.Format("UPDATE check_voucher SET Amount = (SELECT SUM(Amount) FROM cv_details WHERE cv_details.DocumentNumber = check_voucher.DocumentNumber AND `Type` = 'D' AND `status` = 'ACTIVE') WHERE Amount = 0 AND OTAC_Check = '{0}' AND User_EmplID = {1};", OTAC, Empl_ID))
                End If
                Logs("Import Books [Check Disbursement]", "Save", "Import [Check Disbursement].", "", "", "", "")
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub Clear()
        LoadData()
        btnVerify.Enabled = False
        btnSave.Enabled = False
    End Sub

    Private Sub LoadData()

    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If MsgBoxYes("Are you sure you want to export this to Excel Format?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Check Disbursement Format" & "-" & Format(Date.Now, "yyyy-MM-dd_HHmmss") & ".xlsx"
            Dim Report As New RptImportCheckDisbursement
            With Report
                Dim DT As New DataTable
                With DT
                    .Columns.Add("Account Code")
                    .Columns.Add("Business Code")
                    .Columns.Add("Department Code")
                    .Columns.Add("Debit")
                    .Columns.Add("Credit")
                    .Columns.Add("Remarks")
                    For x As Integer = 0 To 15
                        .Rows.Add("", "", "", 0, 0, "")
                    Next
                End With
                .DataSource = DT
                .ExportToXlsx(FName)
                Process.Start(FName)
            End With

            Dim COA As New RptChartOfAccountsV2
            With COA
                Dim DT As DataTable = DataSource("SELECT IF(Main_ID = 0,`Code`,'') AS 'Code', IF(Main_ID = 0,Title,'') AS 'Mother Account', IF(Main_ID = 0,'',`Code`) AS 'Sub-Account Code', IF(Main_ID = 0,'',Title) AS 'Sub-Account' FROM account_chart WHERE `status` = 'ACTIVE' ORDER BY account_chart.`Code`")
                .DataSource = DT
                .lblMotherCode.DataBindings.Add("Text", DT, "Code")
                .lblMotherAccount.DataBindings.Add("Text", DT, "Mother Account")
                .lblSubcode.DataBindings.Add("Text", DT, "Sub-Account Code")
                .lblSubaccount.DataBindings.Add("Text", DT, "Sub-Account")
                .ShowPreview()
            End With
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PayeeID", cbxPayee.SelectedValue)
        Dim drvP As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PayeeType", drvP("Type"))
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Bank", cbxBank.Text)
    End Sub

    Private Sub CbxAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAccount.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Account", cbxAccount.Text)
        Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "MotherCode", drv("MotherCode"))
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Type_ID", drv("Type_ID"))
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "RequiredRemarks", CBool(drv("Remarks")))
    End Sub

    Private Sub CbxDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDepartment.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Department", cbxDepartment.Text)
    End Sub

    Private Sub CbxBusinessCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBusinessCenter.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Business Center", cbxBusinessCenter.Text)
    End Sub

    Private Sub CbxPreparedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPreparedBy.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "PreparedID", cbxPreparedBy.SelectedValue)
    End Sub

    Private Sub CbxCheckedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCheckedBy.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "CheckedID", cbxCheckedBy.SelectedValue)
    End Sub

    Private Sub CbxApprovedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprovedBy.SelectedIndexChanged
        If FirstLoad Or MigrationMode Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "ApprovedID", cbxApprovedBy.SelectedValue)
    End Sub

    Private Sub BtnAdd_Account_Click(sender As Object, e As EventArgs) Handles btnAdd_Account.Click
        btnRemove_Account.Enabled = True
        Dim Row As DataRow = Temp_DT.NewRow
        Row("No") = 0
        Row("Reference No") = ""
        Row("Payee") = ""
        Row("Document Date") = ""
        Row("Posting Date") = ""
        Row("Check No") = ""
        Row("Check Date") = ""
        Row("Clear Date") = ""
        Row("BankID") = 0
        Row("Bank") = ""
        Row("Explanation") = ""
        Row("Account Code") = ""
        Row("Department Code") = ""
        Row("Account") = ""
        Row("Business Center") = ""
        Row("Department") = ""
        Row("Debit") = 0.0
        Row("Credit") = 0.0
        Row("PaidFor") = ""
        Row("Remarks") = ""
        Row("BusinessCode") = ""
        Row("Type_ID") = ""
        Row("MotherCode") = ""
        Row("Prepared By") = ""
        Row("Checked By") = ""
        Row("Approved By") = ""
        Row("Received By") = ""
        Row("Received Date") = ""
        Row("RequiredRemarks") = False
        Row("PreparedID") = 0
        Row("CheckedID") = 0
        Row("ApprovedID") = 0
        Row("PayeeID") = 0
        Row("PayeeType") = ""

        Temp_DT.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        For x As Integer = 0 To GridView2.RowCount - 1
            GridView2.SetRowCellValue(x, "No", x + 1)
        Next
    End Sub

    Private Sub BtnRemove_Account_Click(sender As Object, e As EventArgs) Handles btnRemove_Account.Click
        If Temp_DT.Rows.Count = 0 Then
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure you want to remove row number {0}", GridView2.GetFocusedRowCellValue("No"))) = MsgBoxResult.Yes Then
            Temp_DT.Rows.RemoveAt(GridView2.FocusedRowHandle)

            For x As Integer = 0 To GridView2.RowCount - 1
                GridView2.SetRowCellValue(x, "No", x + 1)
            Next
        End If

        If GridView2.RowCount = 0 Then
            btnRemove_Account.Enabled = False
        End If
    End Sub
End Class