Imports DevExpress.XtraReports.UI
Public Class FrmPaymentRequest

    Dim ID As String
    Dim ContactN As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    ReadOnly Flag As Boolean
    Dim DT As New DataTable
    Dim FirstLoad As Boolean = True
    Dim NetProceeds As Double
    Dim ORNumber As String
    Dim Checks As Integer
    Dim CVStatus As String
    Dim LoanStatus As String
    Private Sub FrmPaymentRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        dtpDate.Value = Date.Now
        cbxDisplay.SelectedIndex = 0

        Load_Bank()

        With DT
            .Columns.Add("ID")
            .Columns.Add("No")
            .Columns.Add("Payee")
            .Columns.Add("CV Number")
            .Columns.Add("CV Date")
            .Columns.Add("Bank")
            .Columns.Add("Branch")
            .Columns.Add("Check No")
            .Columns.Add("Date")
            .Columns.Add("Amount")
            .Columns.Add("Remarks")
            .Columns.Add("CVNumber_2")
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Check Preparation' AS 'Status' UNION SELECT 'CV For Checking' UNION SELECT 'CV For Approval' UNION SELECT 'For Releasing' UNION SELECT 'Booked' UNION SELECT 'Closed'")
        With cbxStatus
            .Location = New Point(553, 6)
            .Size = New Point(183, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Status.Rows.Count - 1
                .Properties.Items.Add(DT_Status(x)("Status"), DT_Status(x)("Status"), If(DT_Status(x)("Status") = "Cancelled", CheckState.Unchecked, CheckState.Checked), True)
            Next
            .Properties.SeparatorChar = ";"
        End With

        btnAddC.Enabled = False
        btnRemoveC.Enabled = False

        LoadApplication()
        LoadData()
        FirstLoad = False

        If CompareDepartment({"FINANCE"}, False) Then
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX155, LabelX7, LabelX5, LabelX8, LabelX9, LabelX10, lblInterest, LabelX13, LabelX12, LabelX14, LabelX2, LabelX1, LabelX16, LabelX23, LabelX20, LabelX15, LabelX18})

            GetLabelWithBackgroundFontSettings({LabelX6, LabelX3, LabelX17})

            GetLabelFontSettingsRedDefault({LabelX4, lblNetProceeds})

            GetTextBoxFontSettings({txtPayee})

            GetCheckBoxFontSettings({cbxDTS, cbxAll})

            GetComboBoxFontSettings({cbxApplication, cbxBank, cbxTerms, cbxTermsA, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDate, dtpFrom, dtpTo})

            GetButtonFontSettings({btnFixLoanStatus, btnAddC, btnRemoveC, btnUpdate, btnCheckVoucher, btnLedger, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnCheck, btnApprove, btnSearch})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetDoubleInputFontSettings({dPrincipal, dPrincipalA, dInterestRate, dInterestRateA, dServiceCharge, dServiceChargeA})

            GetIntegerInputFontSettings({iTerms, iTermsA})

            GetRickTextBoxFontSettings({rNote})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Payment Request-  FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Payment Request", lblTitle.Text)
    End Sub

    Public Sub Load_Bank()
        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            If CompanyMode = 0 Then
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_Code', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND branch_id = '{0}' AND `Code` = 1 ORDER BY `Code`;", Branch_ID))
                .Visible = False
                LabelX2.Visible = False
            Else
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_Code', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Code`;", Branch_ID))
                .Visible = True
                LabelX2.Visible = True
            End If
        End With
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "  ID,"
        SQL &= "  AssetNumber AS 'Credit Number',"
        SQL &= "  IFNULL(C.Borrower,Buyer) AS 'Borrower', BankID, CVNumber AS 'CV Number', IF(CVDate='','',DATE_FORMAT(`CVDate`,'%M %d, %Y')) AS 'CV Date', IFNULL((SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), ']') FROM branch_bank B WHERE B.ID = check_received.BankID),'') AS 'Bank', "
        SQL &= "  DATE_FORMAT(DateRequest,'%M %d, %Y') AS 'Date Request',"
        SQL &= "  COUNT(ID) AS 'Number of Checks',"
        SQL &= "  SUM(Amount) AS 'Total Amount', "
        SQL &= "  C.PaymentRequest AS 'Credit Status', IF(PaymentRequest = 'REQUEST','FOR CHECK PREPARATION',IF(PaymentRequest = 'REQUESTED','CV FOR CHECKING',IF(PaymentRequest = 'CHECKED REQUEST','CV FOR APPROVAL',IF(PaymentRequest = 'APPROVED REQUEST','FOR RELEASING',IF(PaymentRequest='RELEASED','BOOKED',PaymentRequest))))) AS 'Status',"
        SQL &= "  C.`status` AS 'Application Status', Branch(Branch_ID) AS 'Branch' "
        SQL &= "  FROM check_received LEFT JOIN (SELECT CreditNumber, PaymentRequest, `status`, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower' FROM credit_application) C ON C.CreditNumber = AssetNumber"
        SQL &= "  WHERE (check_received.`status` = 'ACTIVE' OR check_received.`status` = 'PENDING') AND check_type = 'P'"
        SQL &= String.Format("  AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= "  AND AssetNumber LIKE 'CA%' "
        Dim ForCheckPreparation As Boolean
        Dim Pending As Boolean
        Dim Checked As Boolean
        Dim Approved As Boolean
        Dim Released As Boolean
        Dim Closed As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Check Preparation" Then
                    ForCheckPreparation = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "CV For Checking" Then
                    Pending = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "CV For Approval" Then
                    Checked = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Releasing" Then
                    Approved = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Booked" Then
                    Released = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Closed" Then
                    Closed = True
                End If
            End If
        Next
        If ForCheckPreparation = False And Pending = False And Checked = False And Approved = False And Released = False And Closed = False Then
        Else
            SQL &= " AND ("
            If ForCheckPreparation Then
                SQL &= " C.PaymentRequest = 'REQUEST'"
                If Pending Or Checked Or Approved Or Released Or Closed Then
                    SQL &= " OR "
                End If
            End If
            If Pending Then
                SQL &= " C.PaymentRequest = 'REQUESTED'"
                If Checked Or Approved Or Released Or Closed Then
                    SQL &= " OR "
                End If
            End If
            If Checked Then
                SQL &= " C.PaymentRequest = 'CHECKED REQUEST'"
                If Approved Or Released Or Closed Then
                    SQL &= " OR "
                End If
            End If
            If Approved Then
                SQL &= " C.PaymentRequest = 'APPROVED REQUEST'"
                If Released Or Closed Then
                    SQL &= " OR "
                End If
            End If
            If Released Then
                SQL &= " C.PaymentRequest = 'RELEASED'"
                If Closed Then
                    SQL &= " OR "
                End If
            End If
            If Closed Then
                SQL &= " C.PaymentRequest = 'CLOSED'"
            End If
            SQL &= ")"
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DateRequest) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= "  GROUP BY AssetNumber "
        SQL &= "  ORDER BY DateRequest DESC, CreditNumber DESC;"

        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn100.Visible = True
            GridColumn100.VisibleIndex = 8
        End If
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 230
        Else
            GridColumn3.Width = 230 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadApplication()
        FirstLoad = True
        With cbxApplication
            .ValueMember = "CreditNumber"
            .DisplayMember = "Name"
            Dim SQL As String = "SELECT CreditNumber, "
            SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), IF(Borrower_S = 1,CONCAT(' AND ', CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S)),''), IF(Borrower_C1 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1)),''), IF(Borrower_C2 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2)),''), IF(Borrower_C3 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3)),''), IF(Borrower_C4 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4)),'')) AS 'Name', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B, IF(Borrower_S = 1,CONCAT(' AND ', CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S)),''), IF(Borrower_C1 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1)),''), IF(Borrower_C2 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2)),''), IF(Borrower_C3 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3)),''), IF(Borrower_C4 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4)),'')), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'FullN', Mobile_B, net_proceeds, AmountApplied, Terms, TermType, product_id, interest_rate, Service_charge, ServiceCharge_Rate, Appraisal_Fee, CI_Fee, Insurance, Miscellaneous_Income, Advance_Payment, AdvancePayment_Count, ROUND(Interest / Terms) AS 'InterestPayable', GMA - Rebate AS 'NMA', Rebate, Deduct_Balance, CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address', (SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE `status` = 'ACTIVE' AND credit_processing_fee.CreditNumber = C.CreditNumber) AS 'Processing_Fee', ForLP_Note, (SELECT UDI FROM product_setup WHERE ID = C.product_ID) AS 'Product_UDI', ApprovedAmount_Crecomm, ApprovedTerm_Crecomm, ApprovedInterest_Crecomm, ApprovedSC_Crecomm, ApprovedAmount_President, ApprovedTerm_President, ApprovedInterest_President, ApprovedSC_President, BM_Amount, BM_Terms, BM_Interest"
            SQL &= " FROM credit_application C"
            SQL &= String.Format("  WHERE FIND_IN_SET(C.Branch_ID,'{0}') AND C.`status` = 'ACTIVE' AND C.application_status = 'APPROVED' AND C.CI_Status = 'APPROVED' AND PaymentRequest = 'PENDING' AND ApproveStatus = 'APPROVED' AND Loan_Type IN ('NEW','RELOAN') AND From_ROPOA = 0 AND CVforJV = 0 ORDER BY C.CreditNumber;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            .DataSource = DataSource(SQL)
            .SelectedIndex = -1

            If .Items.Count = 0 Then
                GridControl2.DataSource = Nothing
            End If
        End With
        FirstLoad = False
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        Dim TotalA As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            TotalA += GridView2.GetRowCellValue(x, "Amount")
        Next
        If TotalA >= NetProceeds Then
            MsgBox("Total check(s) amount cannot be more than the net proceeds. Please check your data.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        Dim Bank As String = ""
        Dim Branch As String = ""
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
        Else
            Bank = drv("Bank_1")
            Branch = drv("Branch")
        End If
        DT.Rows.Add(0, GridView2.RowCount + 1, txtPayee.Text, "", "", Bank, Branch, "", Format(Date.Now, "MM.dd.yyyy"), NetProceeds - TotalA, "", "")

        If GridView2.RowCount = 5 Then
            btnAddC.Enabled = False
        End If
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If
        btnAddC.Enabled = True
        DT.Rows.RemoveAt(GridView2.RowCount - 1)
        If GridView2.RowCount = 1 Then
            btnRemoveC.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Save_Request("Save")
    End Sub

    Private Sub Save_Request(Trigger As String)
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text.Trim = "" Then
            MsgBox("Please select an application to request.", MsgBoxStyle.Information, "Info")
            cbxApplication.DroppedDown = True
            Exit Sub
        End If
        If dPrincipal.Value > dPrincipalA.Value Then
            MsgBox("Principal is higher than the Approved Principal, please update the computation.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dPrincipal.Value < dPrincipalA.Value Then
            If MsgBoxYes("Applied Principal lower than the Approved Principal, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If iTerms.Value > iTermsA.Value Then
            MsgBox("Terms is not equal with Approved Terms, please update the computation.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If iTerms.Value < iTermsA.Value Then
            If MsgBoxYes("Applied Terms lower than the Approved Terms, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dInterestRate.Value = dInterestRateA.Value Then
        Else
            MsgBox("Interest Rate is not equal with Approved Interest Rate, please update the computation.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dServiceCharge.Value = dServiceChargeA.Value Then
        Else
            MsgBox("Service Charge Rate is not equal with Approved Service Charge Rate, please update the computation.", MsgBoxStyle.Information, "Info")
        End If
        If GridView2.RowCount = 0 Then
            MsgBox("Please add check before saving.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If Trigger = "Save" Then
            If cbxDTS.Checked Then
                MsgBox("Reminder this will be a DTS Payment Request.", MsgBoxStyle.Information, "Info")
            End If
            Dim TotalNet As Double
            For x As Integer = 0 To GridView2.RowCount - 1
                TotalNet += CDbl(GridView2.GetRowCellValue(x, "Amount"))
            Next
            If NetProceeds < TotalNet Then
                MsgBox("Total Amount for check preparation is greater than the application net proceeds. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Else
            If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
                MsgBox("Please select bank.", MsgBoxStyle.Information, "Info")
                cbxBank.DroppedDown = True
                Exit Sub
            End If

            Dim TotalNet As Double
            For x As Integer = 0 To GridView2.RowCount - 1
                TotalNet += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                If GridView2.GetRowCellValue(x, "Payee") = "" Then
                    MsgBox(String.Format("Please fill a payee at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "CV Number") = "" Then
                    MsgBox(String.Format("Please fill CV Number at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "CV Date") = "" Then
                    MsgBox(String.Format("Please fill CV Date at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Bank") = "" Then
                    MsgBox(String.Format("Please select Bank at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Branch") = "" Then
                    MsgBox(String.Format("Please fill Branch at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                For y As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Check No") = GridView2.GetRowCellValue(y, "Check No") And x <> y Then
                        MsgBox(String.Format("Duplication of Check Number found at row {0} and row {1}, please check your data.", x + 1, y + 1), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Next
                If GridView2.GetRowCellValue(x, "Check No") = "" Then
                    MsgBox(String.Format("Please fill Check No at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Date") = "" Then
                    MsgBox(String.Format("Please fill Date at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If CDbl(GridView2.GetRowCellValue(x, "Amount")) = 0 Then
                    MsgBox(String.Format("Please fill Amount at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next
            If NetProceeds < TotalNet Then
                MsgBox("Total Amount for check preparation is greater than the application net proceeds. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        Dim Calculator As New FrmLoanApplication
        With Calculator
            .vSave = allow_Save
            .vUpdate = allow_Update
            .vDelete = allow_Delete
            .vPrint = allow_Print

            Logs("Payment Request", "Open", "Amortization Calculators", "", "", "", cbxApplication.SelectedValue)
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .WindowState = FormWindowState.Normal
            .From_CI = True
            .From_Request = True
            .CreditNumber = cbxApplication.SelectedValue
            .btnOpen.Visible = True
            .PanelEx3.Enabled = False
            .ShowDialog()
            .Dispose()
        End With

        If MsgBoxYes("Are you sure you want to save this payment request?") = MsgBoxResult.Yes Then
            If cbxApplication.Enabled Then
                Dim CheckAlreadySaved As Boolean = DataObject(String.Format("SELECT IF(PaymentRequest IN ('REQUEST','RELEASED','CLOSED','CHECKED REQUEST','APPROVED REQUEST','REQUESTED'),1,0) FROM credit_application WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue))
                If CheckAlreadySaved Then
                    MsgBox("Application status is already requested, please refresh your Payment Request Form.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
            Cursor = Cursors.WaitCursor
            Dim SQL As String
            ORNumber = "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss")
            If cbxApplication.Enabled = False Then
                SQL = String.Format(" UPDATE check_received SET `status` = 'CANCELLED' WHERE `status` = 'PENDING' AND AssetNumber = '{0}' AND check_type = 'P';", cbxApplication.SelectedValue)
                DataObject(SQL)
            End If
            For x As Integer = 0 To GridView2.RowCount - 1
                SQL = "INSERT INTO check_received SET"
                SQL &= String.Format(" AssetNumber = '{0}', ", cbxApplication.SelectedValue)
                SQL &= String.Format(" ORNumber = '{0}', ", ORNumber)
                SQL &= String.Format(" Sold_ID = '{0}',", "")
                SQL &= String.Format(" Buyer = '{0}', ", GridView2.GetRowCellValue(x, "Payee"))
                SQL &= String.Format(" DateRequest = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                SQL &= String.Format(" `Check` = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                SQL &= String.Format(" `Date` = '{0}', ", If(GridView2.GetRowCellValue(x, "Date").ToString = "", "", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd")))
                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                SQL &= String.Format(" Remarks = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Remarks")))
                SQL &= " `status` = 'PENDING', "
                SQL &= " check_type = 'P', "
                SQL &= String.Format(" CVNumber = '{0}',", GridView2.GetRowCellValue(x, "CV Number"))
                SQL &= String.Format(" CVNumber_2 = '{0}',", GridView2.GetRowCellValue(x, "CVNumber_2"))
                SQL &= String.Format(" CVDate = '{0}',", If(GridView2.GetRowCellValue(x, "CV Date") = "", "", Format(CDate(GridView2.GetRowCellValue(x, "CV Date")), "yyyy-MM-dd")))
                SQL &= String.Format(" BankID = '{0}',", ValidateComboBox(cbxBank))
                SQL &= String.Format(" branch_id = '{0}',", Branch_ID)
                SQL &= String.Format(" DTS = '{0}',", If(cbxDTS.Checked, 1, 0))
                SQL &= String.Format(" user_code = '{0}';", User_Code)
                DataObject(SQL)
            Next

            If Trigger = "Save" Then
                DataObject(String.Format("UPDATE credit_application SET `PaymentRequest` = 'REQUEST', BankID = '{1}' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue, ValidateComboBox(cbxBank)))
                Logs("Payment Request", "Save", String.Format("Prepare {1} checks for {2} for {0}", cbxApplication.SelectedValue, GridView2.RowCount, txtPayee.Text), "", "", "", cbxApplication.SelectedValue)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            ElseIf Trigger = "Check" Then
                Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
                Dim Code As String

                Code = GenerateOTAC()
                Dim Msg As String
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = 2 And DT_Signatory(x)("FormID") = 80 Then
                        Msg = String.Format("Good day {0}," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL for Check Voucher of {1} with the amount of {2}." & vbCrLf, Code, txtPayee.Text, lblNetProceeds.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            Dim Subject As String = "One Time Authorization Code " & Code & " [" & cbxApplication.SelectedValue & "]"
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & GridView2.GetFocusedRowCellValue("CVNumber_2") & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            FrmCheckVoucher.GenerateCV(False, FName, Empl_Name, "")
                            AttachmentFiles.Add(FName)
                            SendEmail(DT_Signatory(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                Next
                DataObject(String.Format("UPDATE check_voucher SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND voucher_status = 'PENDING';", cbxApplication.SelectedValue, Empl_ID, Code))
                'UPDATE CV - AUTO CHECKED ******************************************************************************
                DataObject(String.Format("UPDATE credit_application SET `PaymentRequest` = 'CHECKED REQUEST' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue))
                Logs("Payment Request", "Check", String.Format("Check Prepared {1} checks for {2} for {0}", cbxApplication.SelectedValue, GridView2.RowCount, txtPayee.Text), "", "", "", cbxApplication.SelectedValue)
                MsgBox("Successfully Checked!", MsgBoxStyle.Information, "Info")
                btnLedger.PerformClick()
            ElseIf Trigger = "Approve" Then
                'UPDATE CV - AUTO APPROVED ******************************************************************************
                DataObject(String.Format("UPDATE check_voucher SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}' WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND voucher_status = 'CHECKED';", cbxApplication.SelectedValue, Empl_ID))
                'UPDATE CV - AUTO APPROVED ******************************************************************************
                DataObject(String.Format("UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue))
                Logs("Payment Request", "Approve", String.Format("Approved Prepared {1} checks for {2} for {0}", cbxApplication.SelectedValue, GridView2.RowCount, txtPayee.Text), "", "", "", cbxApplication.SelectedValue)
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
            End If
            LoadData()
            LoadApplication()
            Clear()
            Cursor = Cursors.Default
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
            If GridView2.RowCount > 0 Then
                Dim Report As New RptPDCReceipt
                With Report
                    .Name = "Check Preparation"
                    .lblBorrower.Text = txtPayee.Text
                    .lblBorrower2.Text = Empl_Name
                    .lblContactN.Text = If(ContactN = "", "", "+63" & ContactN)

                    Dim Total As Double
                    For x As Integer = 0 To GridView2.RowCount - 1
                        GridView2.SetRowCellValue(x, "Amount", FormatNumber(GridView2.GetRowCellValue(x, "Amount"), 2))
                        Total += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                    Next
                    .DataSource = GridControl2.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                    .lblBank.DataBindings.Add("Text", GridControl2.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl2.DataSource, "Branch")
                    .lblCheckN.DataBindings.Add("Text", GridControl2.DataSource, "Check No")
                    .lblCheckD.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                    .lblRemarksC.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
                    .lblTotal.Text = FormatNumber(Total, 2)

                    .lblConfirmedD.Text = Format(Date.Now, "MM.dd.yyyy")
                    .lblReceivedBy.Text = txtPayee.Text
                    .lblReceivedD.Text = Format(Date.Now, "MM.dd.yyyy")

                    .lblTitle.Text = "CHECK PREPARATION"
                    .lblReceivedFrom.Text = "Borrower :"
                    .lblConfirmed.Text = "Prepared By :"
                    .lblBorrowerType.Text = "Authorized Representative"
                    .lblAuthorized.Text = "Borrower / Buyer"
                    Logs("Payment Request", "Print", "[SENSITIVE] Print Payment Request of " & txtPayee.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("PAYMENT REQUEST LIST", GridControl1)
            Logs("Payment Request", "Print", "[SENSITIVE] Print Payment Request List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If btnSave.Enabled And btnDelete.Enabled Then 'MODIFY MODE
            Else
                btnDelete.Enabled = False
            End If
            btnBack.Enabled = False
            btnAdd.Enabled = False
            If CompareDepartment({"FINANCE"}, False) Then
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
            btnModify.Enabled = False
            btnNext.Enabled = True

            iCheckVoucher.Visible = True
            iLedger.Visible = False
            iRename.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If btnSave.Enabled And btnDelete.Enabled Then 'MODIFY MODE
            Else
                Clear()
                LoadApplication()
            End If
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnBack.Enabled = True
            btnNext.Enabled = False

            iCheckVoucher.Visible = False
            iLedger.Visible = True
            iRename.Visible = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Clear()

                LoadApplication()
            Else
                LoadData()
            End If
        End If
    End Sub

    Private Sub Clear()
        GridColumn11.OptionsColumn.AllowEdit = True
        FirstLoad = True
        Checks = 0
        cbxDTS.Checked = False
        cbxApplication.Enabled = True
        PanelEx10.Enabled = True
        dtpDate.Value = Date.Now
        GridView2.OptionsBehavior.Editable = True
        CVStatus = ""
        LoanStatus = ""
        btnFixLoanStatus.Visible = False
        If CompareDepartment({"FINANCE"}, False) Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
        btnModify.Enabled = False
        btnDelete.Enabled = False
        txtPayee.Text = ""
        If cbxBank.Visible Then
            cbxBank.SelectedIndex = -1
        End If
        cbxBank.Enabled = True
        cbxDTS.Enabled = True
        txtPayee.Enabled = True
        ContactN = ""
        NetProceeds = 0
        lblNetProceeds.Text = "P 0.00"

        dPrincipal.Value = 0
        iTerms.Value = 0
        cbxTerms.Text = ""
        dInterestRate.Value = 0
        dServiceCharge.Value = 0

        dPrincipalA.Value = 0
        iTermsA.Value = 0
        cbxTermsA.Text = ""
        dInterestRateA.Value = 0
        dServiceChargeA.Value = 0
        rNote.Text = ""

        btnAddC.Enabled = False
        btnRemoveC.Enabled = False
        btnUpdate.Enabled = False
        btnCheckVoucher.Enabled = False
        btnLedger.Enabled = False
        btnCheck.Enabled = False
        btnApprove.Enabled = False
        FirstLoad = False
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            If btnCheck.Enabled Then
                If CompareDepartment({"FINANCE"}, False) Then
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If
            End If
            GridView2.OptionsBehavior.Editable = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            txtPayee.Enabled = True
            cbxBank.Enabled = True
            cbxDTS.Enabled = True
            dtpDate.Enabled = True
            btnAddC.Enabled = True
            btnRemoveC.Enabled = True
            btnUpdate.Enabled = True
            btnCheckVoucher.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE check_received SET `status` = 'DELETED' WHERE AssetNumber = '{0}' AND check_type = 'P';", cbxApplication.SelectedValue))
            DataObject(String.Format("UPDATE credit_application SET `PaymentRequest` = 'PENDING' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue))
            Logs("Payment Request", "Cancel", Reason, String.Format("Cancel Payment Request {0}", cbxApplication.SelectedValue), "", "", cbxApplication.SelectedValue)
            Clear()
            LoadData()
            LoadApplication()
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
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
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Cursor = Cursors.WaitCursor
        FirstLoad = True
        cbxApplication.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDate.Value = .GetFocusedRowCellValue("Date Request")
            dtpDate.Tag = .GetFocusedRowCellValue("Date Request")
            txtPayee.Text = .GetFocusedRowCellValue("Borrower")
            txtPayee.Tag = .GetFocusedRowCellValue("Borrower")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            CVStatus = DataObject(String.Format("SELECT IF(voucher_status = 'PENDING','REQUESTED',IF(voucher_status = 'CHECKED','CHECKED REQUEST',IF(voucher_status IN ('APPROVED','RECEIVED'),'APPROVED REQUEST',voucher_status))) FROM check_voucher WHERE DocumentNumber = '{0}';", .GetFocusedRowCellValue("CV Number")))
            LoanStatus = .GetFocusedRowCellValue("Credit Status")
            If CVStatus = "" Or CVStatus = "CANCELLED" Or CVStatus = "DELETED" Or CVStatus = LoanStatus Or LoanStatus = "CLOSED" Or LoanStatus = "RELEASED" Or LoanStatus = "BOOKED" Or LoanStatus = "JV Request" Or LoanStatus = "PENDING" Then
            ElseIf CVStatus <> "" Then
                If User_Type = "ADMIN" Then
                    btnFixLoanStatus.Visible = True
                End If
            End If
        End With
        Dim SQL As String = "SELECT CreditNumber, "
        SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Name', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'FullN', Mobile_B, net_proceeds, AmountApplied, Terms, TermType, product_id, interest_rate, Service_charge, ServiceCharge_Rate, Appraisal_Fee, CI_Fee, Insurance, Miscellaneous_Income, Advance_Payment, AdvancePayment_Count, ROUND(Interest / Terms) AS 'InterestPayable', GMA - Rebate AS 'NMA', Rebate, Deduct_Balance, CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address', (SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE `status` = 'ACTIVE' AND credit_processing_fee.CreditNumber = C.CreditNumber) AS 'Processing_Fee', ForLP_Note, (SELECT UDI FROM product_setup WHERE ID = C.product_ID) AS 'Product_UDI', ApprovedAmount_Crecomm, ApprovedTerm_Crecomm, ApprovedInterest_Crecomm, ApprovedSC_Crecomm, ApprovedAmount_President, ApprovedTerm_President, ApprovedInterest_President, ApprovedSC_President"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("  WHERE CreditNumber = '{0}';", GridView1.GetFocusedRowCellValue("Credit Number"))
        cbxApplication.DataSource = DataSource(SQL)
        Checks = GridView1.GetFocusedRowCellValue("Number of Checks")
        FirstLoad = False
        GridView2.OptionsBehavior.Editable = False

        CbxApplication_SelectedIndexChanged(sender, e)
        txtPayee.Enabled = False
        cbxBank.Enabled = False
        cbxDTS.Enabled = False
        dtpDate.Enabled = False
        btnAddC.Enabled = False
        btnRemoveC.Enabled = False
        btnUpdate.Enabled = False
        SuperTabControl1.SelectedTab = tabSetup
        If GridView1.GetFocusedRowCellValue("Credit Status") = "REQUEST" Then
            btnModify.Enabled = True
            btnCheck.Enabled = True

            GridColumn11.OptionsColumn.AllowEdit = True
        ElseIf GridView1.GetFocusedRowCellValue("Credit Status") = "CHECKED REQUEST" Then
            btnApprove.Enabled = True
        Else
            btnModify.Enabled = False
            btnCheck.Enabled = False
            btnApprove.Enabled = False
            GridColumn11.OptionsColumn.AllowEdit = False
        End If
        btnSave.Enabled = False
        If GridView1.GetFocusedRowCellValue("Application Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Application Status") = "HOLD" Then
            MsgBox(String.Format("Credit Application is now {0}.", GridView1.GetFocusedRowCellValue("Application Status")), MsgBoxStyle.Information, "Info")
            btnModify.Enabled = False
            btnCheckVoucher.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            DT.Rows.Clear()
            GridControl2.DataSource = DT
            Clear()
        Else
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            FirstLoad = True
            txtPayee.Text = drv("FullN")
            ContactN = drv("Mobile_B")
            NetProceeds = drv("net_proceeds")
            lblNetProceeds.Text = "P " & FormatNumber(NetProceeds, 2)

            'If drv("BM_Amount") > 0 Then
            '    dPrincipal.Value = drv("BM_Amount")
            '    iTerms.Value = drv("BM_Terms")
            '    dInterestRate.Value = drv("BM_Interest")
            'Else
            '    dPrincipal.Value = drv("AmountApplied")
            '    iTerms.Value = drv("Terms")
            '    dInterestRate.Value = drv("interest_rate")
            'End If
            dPrincipal.Value = drv("AmountApplied")
            iTerms.Value = drv("Terms")
            dInterestRate.Value = drv("interest_rate")
            cbxTerms.Text = drv("TermType")
            dServiceCharge.Value = drv("ServiceCharge_Rate")

            dPrincipalA.Value = If(drv("ApprovedAmount_President") > 0, drv("ApprovedAmount_President"), drv("ApprovedAmount_Crecomm"))
            iTermsA.Value = If(drv("ApprovedAmount_President") > 0, drv("ApprovedTerm_President"), drv("ApprovedTerm_Crecomm"))
            cbxTermsA.Text = drv("TermType")
            dInterestRateA.Value = If(drv("ApprovedAmount_President") > 0, drv("ApprovedInterest_President"), drv("ApprovedInterest_Crecomm"))
            dServiceChargeA.Value = If(drv("ApprovedAmount_President") > 0, drv("ApprovedSC_President"), drv("ApprovedSC_Crecomm"))

            Dim DT_CheckReceived As DataTable = DataSource(String.Format("SELECT BankID, DTS FROM check_received WHERE AssetNumber = '{0}' AND check_type = 'P' AND `status` NOT IN ('DELETED','CANCELLED')", cbxApplication.SelectedValue))
            Dim DefaultBank As String = ""
            If DT_CheckReceived.Rows.Count > 0 Then
                DefaultBank = DT_CheckReceived(0)("BankID")
                cbxDTS.Checked = DT_CheckReceived(0)("DTS")
            End If
            If DefaultBank = "" Then
            Else
                cbxBank.SelectedValue = DefaultBank
            End If

            If cbxBank.Items.Count >= 2 And cbxApplication.Enabled Then
                If dPrincipal.Value <= 500000 Then
                    cbxBank.SelectedIndex = 0
                Else
                    cbxBank.SelectedIndex = 1
                End If
            End If
            Checks = 1
            rNote.Text = drv("ForLP_Note")

            btnAddC.Enabled = True
            btnRemoveC.Enabled = True
            btnUpdate.Enabled = True
            btnCheckVoucher.Enabled = True
            btnLedger.Enabled = True
            FirstLoad = False
            LoadChecks()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            DT.Rows.Clear()
            GridControl2.DataSource = DT
            Clear()
        End If
    End Sub

    Public Sub LoadChecks()
        DT.Rows.Clear()
        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        Dim Bank As String = ""
        Dim Branch As String = ""
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
        Else
            Bank = drv("Bank_1")
            Branch = drv("Branch")
        End If
        If cbxApplication.Enabled Then
            For x As Integer = 0 To Checks - 1
                DT.Rows.Add(0, x + 1, txtPayee.Text, "", "", Bank, Branch, "", Format(Date.Now.AddMonths(x), "MM.dd.yyyy"), NetProceeds, "", "")
            Next
        Else
            DT = DataSource(String.Format("SELECT ID, ROW_NUMBER() OVER() AS 'No', Buyer AS 'Payee', CVNumber AS 'CV Number', IF(CVDate='','',DATE_FORMAT(`CVDate`,'%b %d, %Y')) AS 'CV Date', Bank, Branch, `Check`  AS 'Check No', DATE_FORMAT(`Date`,'%b %d, %Y') AS 'Date', Amount, Remarks, CVNumber_2 FROM check_received WHERE AssetNumber = '{0}' AND `status` NOT IN ('DELETED','CANCELLED') AND check_type = 'P';", cbxApplication.SelectedValue))
            For x As Integer = 0 To DT.Rows.Count - 1
                If DT(x)("Bank") = "" Then
                    DT(x)("Bank") = Bank
                    DT(x)("Branch") = Branch
                End If
            Next
        End If

        GridControl2.DataSource = DT
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
            End Try
        ElseIf (e.Column.FieldName = "Date" Or e.Column.FieldName = "CV Date") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = Format(DateValue(e.Value), "MM.dd.yyyy")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        If e.Column.FieldName = "Amount" And e.Column.FieldName = "CV Number" Then
            MsgBox("Amount is not editable anymore.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Public Function CountLeadingZeros(input As String) As String
        Dim count As Integer = 0
        For Each c As Char In input
            If c = "0"c Then
                count += 1
            Else
                Exit For
            End If
        Next
        Return count
    End Function

    Private Sub TxtPayee_Leave(sender As Object, e As EventArgs) Handles txtPayee.Leave
        txtPayee.Text = ReplaceText(txtPayee.Text)
    End Sub

    Private Sub CbxApplication_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxApplication.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPayee.Focus()
        End If
    End Sub

    Private Sub TxtPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MsgBoxYes("Are you sure you want to update the deduction?") = MsgBoxResult.Yes Then
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Calculator As New FrmLoanApplication
            With Calculator
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                '.Tag = 26
                'FormRestriction(.Tag)
                'If allow_Access Then
                '    .vSave = allow_Save
                '    .vUpdate = allow_Update
                '    .vDelete = allow_Delete
                '    .vPrint = allow_Print
                'Else
                '    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                '    Exit Sub
                'End If

                Logs("Payment Request", "Open", "Amortization Calculators", "", "", "", cbxApplication.SelectedValue)
                .ControlBox = False
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .WindowState = FormWindowState.Normal
                .From_CI = True
                .From_Request = True
                .CreditNumber = cbxApplication.SelectedValue
                .btnOpen.Visible = True
                .btnRefresh.Enabled = False
                .dAmountApplied.MaxValue = dPrincipalA.Value

                .ShowDialog()
                FrmLoanApplication.LoadData()
                .Dispose()

                Dim Old_Net As Double = NetProceeds
                Dim DT As DataTable = DataSource(String.Format("SELECT net_proceeds, AmountApplied, Terms, TermType, interest_rate, Service_charge, ServiceCharge_Rate, ApprovedAmount_Crecomm, ApprovedTerm_Crecomm, ApprovedInterest_Crecomm, ApprovedSC_Crecomm, ApprovedAmount_President, ApprovedTerm_President, ApprovedInterest_President, ApprovedSC_President FROM credit_application WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue))
                If DT.Rows.Count > 0 Then
                    NetProceeds = DT(0)("net_proceeds")
                    lblNetProceeds.Text = "P " & FormatNumber(NetProceeds, 2)

                    dPrincipal.Value = DT(0)("AmountApplied")
                    iTerms.Value = DT(0)("Terms")
                    cbxTerms.Text = DT(0)("TermType")
                    dInterestRate.Value = DT(0)("interest_rate")
                    dServiceCharge.Value = DT(0)("ServiceCharge_Rate")

                    dPrincipalA.Value = If(DT(0)("ApprovedAmount_President") > 0, DT(0)("ApprovedAmount_President"), DT(0)("ApprovedAmount_Crecomm"))
                    iTermsA.Value = If(DT(0)("ApprovedAmount_President") > 0, DT(0)("ApprovedTerm_President"), DT(0)("ApprovedTerm_Crecomm"))
                    cbxTermsA.Text = DT(0)("TermType")
                    dInterestRateA.Value = If(DT(0)("ApprovedAmount_President") > 0, DT(0)("ApprovedInterest_President"), DT(0)("ApprovedInterest_Crecomm"))
                    dServiceChargeA.Value = If(DT(0)("ApprovedAmount_President") > 0, DT(0)("ApprovedSC_President"), DT(0)("ApprovedSC_Crecomm"))

                    If GridView2.RowCount = 1 Then
                        GridView2.SetFocusedRowCellValue("Amount", NetProceeds)
                    ElseIf GridView2.RowCount > 0 Then
                        For x As Integer = 0 To GridView2.RowCount - 1
                            If cbxApplication.Text.Contains(GridView2.GetRowCellValue(x, "Payee")) Then
                                If Old_Net >= NetProceeds Then
                                    GridView2.SetRowCellValue(x, "Amount", GridView2.GetRowCellValue(x, "Amount") - (Old_Net - NetProceeds)) 'Minus Difference
                                Else
                                    GridView2.SetRowCellValue(x, "Amount", GridView2.GetRowCellValue(x, "Amount") + (NetProceeds - Old_Net)) 'Minus Difference
                                End If
                            End If
                        Next
                    End If
                    cbxApplication.Enabled = False
                End If
            End With
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
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

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
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

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Credit Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "RETURNED" Then
                e.Appearance.ForeColor = Color.Red
            End If
            'If Status = "REQUEST" Or Status = "REQUESTED" Or Status = "FOR CHECKING" Then
            '    e.Appearance.ForeColor = Color.IndianRed
            'ElseIf Status = "CHECKED REQUEST" Or Status = "FOR APPROVAL" Then
            '    e.Appearance.ForeColor = Color.RoyalBlue
            'ElseIf Status = "APPROVED REQUEST" Or Status = "FOR RELEASING" Then
            '    e.Appearance.ForeColor = Color.SeaGreen
            'ElseIf Status = "RELEASED" Or Status = "CLOSED" Then
            '    e.Appearance.ForeColor = Color.SeaGreen
            '    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            'End If
        End If
    End Sub

    Private Sub TxtPayee_TextChanged(sender As Object, e As EventArgs) Handles txtPayee.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If txtPayee.Text = "" Or GridView2.RowCount = 0 Then
        Else
            GridView2.SetFocusedRowCellValue("Payee", txtPayee.Text)
        End If
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        Dim Bank As String = ""
        Dim Branch As String = ""
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
        Else
            Bank = drv("Bank_1")
            Branch = drv("Branch")
        End If
        GridView2.SetFocusedRowCellValue("Bank", Bank)
        GridView2.SetFocusedRowCellValue("Branch", Branch)
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Save_Request("Check")
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Save_Request("Approve")
    End Sub

    Private Sub BtnCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnCheckVoucher.Click, iCheckVoucher.Click
        Try
            If GridView2.GetFocusedRowCellValue("No").ToString = "" Or GridView2.RowCount = 0 Then
                MsgBox("Please select a row to Check Voucher.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView2.RowCount = 0 Then
                MsgBox("Please add a check first then save.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView2.GetFocusedRowCellValue("ID") = 0 Then
                MsgBox("Please save the request first.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim CV As New FrmCheckVoucher
        With CV
            .Tag = 80
            FormRestriction(CV.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            Logs("Payment Request", "Open", "Check Voucher", "", "", "", "")
            .Clear(False)
            .FirstLoad = True
            .CreditNumber = cbxApplication.SelectedValue
            If GridView2.GetFocusedRowCellValue("CVNumber_2") <> "" Then
                .From_GeneralLedger = True
            End If
            .cbxPayee.Enabled = False
            .From_PaymentRequest = True
            .tabList.Visible = False
            .btnNext.Enabled = False
            .cbxLA.Enabled = False
            .cbxCAS.Enabled = False
            .cbxSUP.Enabled = False
            .cbxEMP.Enabled = False
            .cbxAP.Enabled = False
            .cbxAR.Enabled = False
            .cbxRC.Enabled = False
            .cbxDT.Enabled = False
            .cbxLA.Checked = True
            .CheckID = GridView2.GetFocusedRowCellValue("ID")
            .DefaultBank = cbxBank.SelectedValue
            .cbxDTS.Checked = cbxDTS.Checked
            .CheckCount = GridView2.RowCount
            If GridView2.FocusedRowHandle = GridView2.RowCount - 1 Then
                .LastRow = True
                .rExplanation.Text = "Full Release"
                Dim TotalPartial As Double
                For x As Integer = 0 To GridView2.RowCount - 2
                    TotalPartial += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                Next
                .TotalPartial = TotalPartial
                .CIB_Amount = CDbl(drv("AmountApplied")) - TotalPartial
            Else
                .LastRow = False
                .rExplanation.Text = "Partial Release"
                .CIB_Amount = CDbl(GridView2.GetFocusedRowCellValue("Amount"))
            End If
            .AccountNumber = GridView2.GetFocusedRowCellValue("CVNumber_2")
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView2.SetFocusedRowCellValue("CV Number", .txtDocumentNumber.Text)
                GridView2.SetFocusedRowCellValue("CV Date", Format(.dtpPostingDate.Value, "MM.dd.yyyy"))
                GridView2.SetFocusedRowCellValue("Check No", .txtCheckNumber.Text)
                GridView2.SetFocusedRowCellValue("Date", Format(.dtpCheck.Value))
                GridView2.SetFocusedRowCellValue("CVNumber_2", .txtDocumentNumber.Text)
                If .cbxBank.SelectedValue = 0 Then
                Else
                    cbxBank.SelectedValue = .cbxBank.SelectedValue
                End If
                btnModify.Enabled = False
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnAddC.Enabled = False
                btnRemoveC.Enabled = False
                btnUpdate.Enabled = False
                LoadData()
            ElseIf Result = DialogResult.Yes Then
                GridView2.SetFocusedRowCellValue("CV Number", "")
                GridView2.SetFocusedRowCellValue("CV Date", "")
                GridView2.SetFocusedRowCellValue("Check No", "")
                GridView2.SetFocusedRowCellValue("Date", "")
                GridView2.SetFocusedRowCellValue("CVNumber_2", "")
                btnModify.Enabled = False
                btnAddC.Enabled = False
                btnRemoveC.Enabled = False
                btnUpdate.Enabled = False
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = cbxApplication.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IRename_Click(sender As Object, e As EventArgs) Handles iRename.Click
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView2.GetFocusedRowCellValue("CV Number") <> "" Then
                MsgBox("Check is already have a check voucher.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Rename As New FrmRenamePayee
        With Rename
            .txtPayee.Text = GridView2.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                If btnDelete.Enabled Or btnModify.Enabled Then
                    'Dim SQL As String
                    'SQL = String.Format("UPDATE check_received SET Buyer = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), .txtPayee.Text.InsertQuote)
                    'DataSource(SQL)
                    'Logs("Payment Request", "Change Check", String.Format("Changed check for {0} from {1} to {2}", GridView2.GetFocusedRowCellValue("Payee").ToString.InsertQuote & " - " & cbxApplication.SelectedValue, GridView2.GetFocusedRowCellValue("Payee").ToString.InsertQuote, .txtPayee.Text.InsertQuote), "", "", "", "")
                    'cbxApplication_SelectedIndexChanged(sender, e)
                    'MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
                    GridView2.SetFocusedRowCellValue("Payee", .txtPayee.Text)
                    MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
                Else
                    GridView2.SetFocusedRowCellValue("Payee", .txtPayee.Text)
                    MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End With
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        btnCheckVoucher.PerformClick()
    End Sub

    Private Sub BtnFixLoanStatus_Click(sender As Object, e As EventArgs) Handles btnFixLoanStatus.Click
        If MsgBoxYes(String.Format("Are you sure you want to fix the loan status from {0} to {1}?", LoanStatus, If(CVStatus = "RECEIVED", "APPROVED REQUEST", CVStatus))) = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE credit_application SET PaymentRequest = '{1}' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue, If(CVStatus = "RECEIVED", "APPROVED REQUEST", CVStatus)))
            Logs("Payment Request", "Fix Status", "", String.Format("Fix Loan Status from {0} to {1} of {0}", LoanStatus, If(CVStatus = "RECEIVED", "APPROVED REQUEST", CVStatus), cbxApplication.Text), "", "", cbxApplication.SelectedValue)
            Clear()
            LoadData()
            LoadApplication()
            Cursor = Cursors.Default
            MsgBox("Successfully Fixed!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub
End Class