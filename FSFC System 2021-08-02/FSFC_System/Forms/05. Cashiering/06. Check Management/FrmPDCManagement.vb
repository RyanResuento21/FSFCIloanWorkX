Imports DevExpress.XtraReports.UI
Imports word = Microsoft.Office.Interop.Word
Public Class FrmPDCManagement

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DueFrom_Payable As Double
    Dim DueTo_Payable As Double
    Dim DT_Borrower As DataTable
    Public FromInsurance As Boolean
    Public CreditNumber As String
    Private Sub FrmPDCManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView10, GridView11, GridView12, GridView2, GridView3, GridView4, GridView5, GridView6, GridView7, GridView8, GridView9})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True
        dtpReceivedDate.Value = Date.Now
        dtpDocument.Value = Date.Now

        With cbxApplication
            .ValueMember = "CreditNumber"
            .DisplayMember = "Name"
        End With
        LoadApplication()
        If FromInsurance Then
            FirstLoad = False
            Exit Sub
        End If

        With cbxAssetNumber
            .ValueMember = "AssetNumber"
            .DisplayMember = "Description"
        End With
        LoadAsset()

        Dim Bank As DataTable = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = Bank.Copy
        End With

        With cbxBankV2
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = Bank.Copy
        End With

        With cbxBankV3
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = Bank.Copy
        End With

        With cbxPayor
            .ValueMember = "DF_ID"
            .DisplayMember = "Name"
        End With
        LoadDueFrom()

        With cbxPayee
            .ValueMember = "DT_ID"
            .DisplayMember = "Name"
        End With
        LoadDueTo()

        With cbxPayeeV5
            .ValueMember = "ID"
            .DisplayMember = "Name"
        End With
        LoadLoansPayable()

        With cbxPayorOthers
            .ValueMember = "ID"
            .DisplayMember = "Name"
        End With
        LoadOthers()

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

            GetLabelFontSettings({LabelX5, LabelX4, LabelX2, LabelX23, LabelX155, LabelX3, lblPayor, LabelX6, LabelX1, LabelX81, LabelX18, LabelX10, LabelX82, lblInterest, LabelX7, LabelX9, LabelX89, LabelX19, LabelX13, LabelX12, LabelX22, LabelX14, LabelX17, LabelX21, LabelX20, LabelX16, LabelX15, LabelX8, LabelX49, LabelX44, LabelX43, LabelX52, LabelX45, LabelX48, LabelX51, LabelX50, LabelX47, LabelX46, LabelX42, LabelX31, LabelX24, LabelX27, LabelX26, LabelX29, LabelX25, LabelX28})

            GetTextBoxFontSettings({txtBorrower, TextBoxX3, txtContactN_2, txtBuyer, txtPlus63, txtContactN, txtDocumentNumber, txtReferenceNumber, txtDocumentNumberV2, txtReferenceNumberV2, txtDocumentNumberV5, txtReferenceNumberV5, txtDocumentNumberV3, txtReferenceNumberV3, txtKeyword})

            GetComboBoxFontSettings({cbxApplication, cbxAssetNumber, cbxPayor, cbxBank, cbxPayee, cbxBankV2, cbxPayeeV5, cbxBankV5, cbxPayorOthers, cbxBankV3})

            GetDateTimeInputFontSettings({dtpDocument, dtpReceivedDate, dtpDocumentV2, dtpReceivedDateV2, dtpDocumentV5, dtpReceivedDateV5, dtpDocumentV3, dtpReceivedDateV3})

            GetDoubleInputFontSettings({dPrincipal, dInterest_T, dUDI_C, dPrincipalV2, dInterest_TV2, dUDI_CV2, dPrincipalV5, dInterest_TV5, dUDI_CV5})

            GetIntegerInputFontSettings({iTerms_C, iTerms_CV2, iTerms_CV5})

            GetButtonFontSettings({btnModify, btnPDC, btnImportPDC, btnPayment, btnCheckRegistry, btnRenewal, btnSearch, btnRefresh, btnCancel, btnPrint, btnReturn, btnReturnedNotice, btnJournalVoucher, btnCheckVoucher, btnReplace, btnRemove, btnLedger, btnHold, btnBounce})

            GetContextMenuBarFontSettings({ContextMenuBar1})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("PDC Management - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("PDC Management", lblTitle.Text)
    End Sub

    Public Sub LoadAsset()
        With cbxAssetNumber
            .DataSource = DataSource(String.Format("SELECT Amount, AssetNumber, CONCAT(AssetNumber, ' - ', CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), LastN_B), ' [', ReferenceN, ']') AS 'Description', CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), LastN_B) AS 'Buyer', Prefix_B, LastN_B, Contact_N, CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ' ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ' ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ' ')), AddressC_B) AS 'Address' FROM sold_ropoa WHERE branch_id = '{0}' AND `status` = 'ACTIVE' AND Amount - ROPOA_Payment(AssetNumber,sold_ropoa.ID) > 0 AND (SELECT COUNT(ID) FROM check_received WHERE check_received.AssetNumber = sold_ropoa.AssetNumber AND `Status` NOT IN ('PENDING','DELETED','CANCELLED') AND check_type = 'R') > 0 ORDER BY AssetNumber;", Branch_ID))
            .SelectedIndex = -1
        End With
    End Sub

    Public Sub LoadDueFrom()
        Dim SQL As String = String.Format("SELECT (SELECT ID FROM due_from WHERE due_from.DocumentNumber = due_check.DocumentNumber) AS 'DF_ID', CONCAT('[',DocumentNumber,'] ', Payor) AS 'Name', due_check.* FROM due_check WHERE SUBSTRING(DocumentNumber,1,2) = 'DF' AND `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Payor`;", Branch_ID)
        FirstLoad = True
        cbxPayor.DataSource = DataSource(SQL)
        FirstLoad = False
        cbxPayor.SelectedIndex = -1
    End Sub

    Public Sub LoadDueTo()
        Dim SQL As String = String.Format("SELECT (SELECT ID FROM due_to WHERE due_to.DocumentNumber = due_check.DocumentNumber) AS 'DT_ID', CONCAT('[',DocumentNumber,'] ', Payor) AS 'Name', due_check.* FROM due_check WHERE SUBSTRING(DocumentNumber,1,2) = 'DT' AND `status` = 'ACTIVE' AND Branch_ID = '{0}' AND DueStatus = 'VERIFIED' ORDER BY `Payor`;", Branch_ID)
        FirstLoad = True
        cbxPayee.DataSource = DataSource(SQL)
        FirstLoad = False
        cbxPayee.SelectedIndex = -1
    End Sub

    Public Sub LoadLoansPayable()
        Dim SQL As String = String.Format("SELECT CONCAT('[',DocumentNumber,'] ', Payor) AS 'Name', due_check.* FROM due_check WHERE SUBSTRING(DocumentNumber,1,2) = 'LP' AND `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Payor`;", Branch_ID)
        FirstLoad = True
        cbxPayeeV5.DataSource = DataSource(SQL)
        FirstLoad = False
        cbxPayeeV5.SelectedIndex = -1
    End Sub

    Public Sub LoadOthers()
        Dim SQL As String = String.Format("SELECT CONCAT('[',DocumentNumber,'] ', Payor) AS 'Name', pdc_others.* FROM pdc_others WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Payor`;", Branch_ID)
        FirstLoad = True
        cbxPayorOthers.DataSource = DataSource(SQL)
        FirstLoad = False
        cbxPayorOthers.SelectedIndex = -1
        If cbxPayorOthers.Items.Count = 0 Then
            cbxPayorOthers.Text = ""
            dtpDocumentV3.Value = Date.Now
            txtDocumentNumberV3.Text = ""
            cbxBankV3.SelectedIndex = -1
            dtpReceivedDateV3.Value = Date.Now
            txtReferenceNumberV3.Text = ""

            GridControl4.DataSource = Nothing
            GridControl4.Enabled = True
        End If
    End Sub

    Public Sub LoadApplication()
        Dim SQL As String = "SELECT"
        SQL &= "    CONCAT('[ ',AccountNumber,' ] - ',IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Name',"
        SQL &= "    IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'FName',"
        SQL &= "    CreditNumber, Prefix_B, LastN_B, CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ' ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ' ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ' ')), AddressC_B) AS 'Address', "
        SQL &= "    AccountNumber,"
        SQL &= "    Mobile_B,"
        SQL &= "    PN, PaymentRequest, Branch_Code"
        SQL &= "  FROM credit_application"
        SQL &= String.Format("  WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If FromInsurance Then
            SQL &= String.Format("  AND CreditNumber = '{0}';", CreditNumber)
            FirstLoad = False
            cbxApplication.DataSource = DataSource(SQL)
            Exit Sub
        End If
        FirstLoad = True
        cbxApplication.DataSource = DataSource(SQL)
        FirstLoad = False
        cbxApplication.SelectedIndex = -1
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM check_received WHERE ID = '{0}';", GridView3.GetFocusedRowCellValue("ID")))
            If GridView3.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView3.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET remarks = '{1}' WHERE ID = '{0}';", GridView3.GetFocusedRowCellValue("ID"), GridView3.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView3.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxApplication.Text, GridView3.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnPayment.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM check_received WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID")))
            If GridView1.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET remarks = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxAssetNumber.Text, GridView1.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnPayment.PerformClick()
            End If
        End If
    End Sub

    Public Sub LoadData()
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If FirstLoad Or cbxApplication.Text = "" Or cbxApplication.SelectedIndex = -1 Then
                Exit Sub
            End If

            Dim SQL As String = "SELECT"
            SQL &= "    ID,"
            SQL &= "    ROW_NUMBER() OVER() AS 'No', "
            SQL &= "    Buyer AS 'Payee',"
            SQL &= "    Bank,"
            SQL &= "    Branch,"
            SQL &= "    `Check`  AS 'Check No',"
            SQL &= "    DATE_FORMAT(`Date`,'%m.%d.%Y') AS 'Date',"
            SQL &= "    Amount,"
            SQL &= "    Remarks, AccountNum AS 'Account Number', IFNULL(IFNULL((CASE WHEN A.JVNumber = '' THEN A.DocumentNumber END),A.DocumentNumber),'') AS 'ORNum', "
            SQL &= "    check_received.`Status`, attach, ReDeposit, ORNumber, BankID, Hold, IFNULL(IFNULL((CASE WHEN A.JVNumber = '' THEN A.DocumentNumber END),A.Status),'NOT CHECK') AS 'PostStatus', IFNULL(IFNULL(A.DocumentNumber,B.DocumentNumber),'') AS 'Document Number', IFNULL(IFNULL(DATE_FORMAT(A.ORDate,'%M %d, %Y'),DATE_FORMAT(B.PostingDate,'%M %d, %Y')),'') AS 'OR Date'"
            SQL &= " FROM check_received LEFT JOIN (SELECT Payee_ID, DocumentNumber, ORDate, IF(Voucher_Status = 'APPROVED','POSTED',Voucher_Status) AS 'Status', CheckID, JVNumber FROM official_receipt WHERE `status` = 'ACTIVE' AND Type_Payment = 'CHECK') A ON A.Payee_ID = check_received.AssetNumber AND A.CheckID = check_received.ID"
            SQL &= "                     LEFT JOIN (SELECT Payee_ID, DocumentNumber, PostingDate, IF(Voucher_Status = 'APPROVED','POSTED',Voucher_Status) AS 'Status', CheckID, JVNumber FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND Type_Payment = 'CHECK') B ON B.Payee_ID = check_received.AssetNumber AND B.CheckID = check_received.ID"
            SQL &= " WHERE check_received.`Status` NOT IN ('PENDING','DELETED','CANCELLED','REMOVED') AND check_type = 'R'"
            SQL &= String.Format(" AND AssetNumber = '{0}'", cbxApplication.SelectedValue)
            SQL &= " ORDER BY Date(`Date`);"
            GridControl3.DataSource = DataSource(SQL)
        Else
            If FirstLoad Or cbxAssetNumber.Text = "" Or cbxAssetNumber.SelectedIndex = -1 Then
                Exit Sub
            End If

            Dim SQL As String = "SELECT"
            SQL &= "    ID,"
            SQL &= "    ROW_NUMBER() OVER()  AS 'No', "
            SQL &= "    Bank,"
            SQL &= "    Branch,"
            SQL &= "    `Check`  AS 'Check No',"
            SQL &= "    DATE_FORMAT(`Date`,'%m.%d.%Y') AS 'Date',"
            SQL &= "    Amount,"
            SQL &= "    Remarks,"
            SQL &= "    `Status`, attach, ReDeposit, ORNumber, BankID, Hold"
            SQL &= " FROM check_received"
            SQL &= " WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED') AND check_type = 'R'"
            SQL &= String.Format(" AND AssetNumber = '{0}'", cbxAssetNumber.SelectedValue)
            SQL &= " ORDER BY Date(`Date`);"
            GridControl1.DataSource = DataSource(SQL)
        End If
    End Sub

    Private Sub CbxAssetNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAssetNumber.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv_B As DataRowView = DirectCast(cbxAssetNumber.SelectedItem, DataRowView)
        If cbxAssetNumber.SelectedIndex = -1 Or cbxAssetNumber.Text = "" Then
            txtBuyer.Text = ""
            txtContactN.Text = ""

            GridControl1.DataSource = Nothing
        Else
            txtBuyer.Text = drv_B("Buyer")
            txtContactN.Text = drv_B("Contact_N")

            LoadData()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            FirstLoad = True
            If SuperTabControl1.SelectedTabIndex = 0 Then
                LoadApplication()
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                LoadAsset()
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                LoadDueFrom()
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                LoadDueTo()
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                LoadLoansPayable()
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                LoadOthers()
            ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
                txtKeyword.Text = ""
                GridControl9.DataSource = Nothing
            End If
            FirstLoad = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If GridView3.RowCount > 0 Then
                Dim Report As New RptPDCReceipt
                With Report
                    .Name = "PDC Receipt"
                    .lblBorrower.Text = txtBorrower.Text
                    .lblBorrower2.Text = txtBorrower.Text
                    .lblContactN.Text = If(txtContactN_2.Text = "", "", "+63" & txtContactN_2.Text)

                    .DataSource = GridControl3.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl3.DataSource, "No")
                    .lblBank.DataBindings.Add("Text", GridControl3.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl3.DataSource, "Branch")
                    .lblCheckN.DataBindings.Add("Text", GridControl3.DataSource, "Check No")
                    .lblCheckD.DataBindings.Add("Text", GridControl3.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl3.DataSource, "Amount")
                    .lblRemarksC.DataBindings.Add("Text", GridControl3.DataSource, "Remarks")
                    Dim Total As Double
                    For x As Integer = 0 To GridView3.RowCount - 1
                        Total += CDbl(GridView3.GetRowCellValue(x, "Amount"))
                    Next

                    .lblTotal.Text = FormatNumber(Total, 2)

                    .lblConfirmedD.Text = Format(Date.Now, "MM.dd.yyyy")
                    .lblReceivedBy.Text = Empl_Name
                    .lblReceivedD.Text = Format(Date.Now, "MM.dd.yyyy")
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & txtBorrower.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If GridView1.RowCount > 0 Then
                Dim Report As New RptPDCReceipt
                With Report
                    .Name = "PDC Receipt"
                    .lblBorrower.Text = txtBuyer.Text
                    .lblBorrower2.Text = txtBuyer.Text
                    .lblContactN.Text = If(txtContactN.Text = "", "", "+63" & txtContactN.Text)

                    .DataSource = GridControl1.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl1.DataSource, "No")
                    .lblBank.DataBindings.Add("Text", GridControl1.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl1.DataSource, "Branch")
                    .lblCheckN.DataBindings.Add("Text", GridControl1.DataSource, "Check No")
                    .lblCheckD.DataBindings.Add("Text", GridControl1.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl1.DataSource, "Amount")
                    .lblRemarksC.DataBindings.Add("Text", GridControl1.DataSource, "Remarks")
                    Dim Total As Double
                    For x As Integer = 0 To GridView1.RowCount - 1
                        Total += CDbl(GridView1.GetRowCellValue(x, "Amount"))
                    Next

                    .lblTotal.Text = FormatNumber(Total, 2)

                    .lblConfirmedD.Text = Format(Date.Now, "MM.dd.yyyy")
                    .lblReceivedBy.Text = Empl_Name
                    .lblReceivedD.Text = Format(Date.Now, "MM.dd.yyyy")
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & txtBuyer.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If GridView2.RowCount > 0 Then
                Dim Report As New RptCheckRegistry
                With Report
                    .Name = "Check Registry"

                    .lblSupplier.Text = cbxPayor.Text
                    .lblDocumentDate.Text = dtpDocument.Text
                    .lblDocumentNumber.Text = txtDocumentNumber.Text
                    .lblPostingDate.Text = dtpReceivedDate.Text
                    .lblReferenceNumber.Text = txtReferenceNumber.Text
                    .lblBank.Text = cbxBank.Text
                    .lblPrincipal.Text = dPrincipal.Text
                    .lblTerms.Text = iTerms_C.Text
                    .lblInterestRate.Text = dInterest_T.Text
                    .lblInterest.Text = dUDI_C.Text
                    Dim Total As Double
                    For x As Integer = 0 To GridView2.RowCount - 1
                        GridView2.SetRowCellValue(x, "Amount", FormatNumber(GridView2.GetRowCellValue(x, "Amount"), 2))
                        Total += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                    Next
                    .DataSource = GridControl2.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                    .lblBankV2.DataBindings.Add("Text", GridControl2.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl2.DataSource, "Branch")
                    .lblCheckNumber.DataBindings.Add("Text", GridControl2.DataSource, "Check No")
                    .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                    .lblRemarks.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
                    .lblAmountT.Text = FormatNumber(Total, 2)
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & cbxPayor.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If GridView5.RowCount > 0 Then
                Dim Report As New RptCheckRegistry
                With Report
                    .Name = "Check Registry"

                    .lblSupplier.Text = cbxPayee.Text
                    .lblDocumentDate.Text = dtpDocumentV2.Text
                    .lblDocumentNumber.Text = txtDocumentNumberV2.Text
                    .lblPostingDate.Text = dtpReceivedDateV2.Text
                    .lblReferenceNumber.Text = txtReferenceNumberV2.Text
                    .lblBank.Text = cbxBankV2.Text
                    .lblPrincipal.Text = dPrincipalV2.Text
                    .lblTerms.Text = iTerms_CV2.Text
                    .lblInterestRate.Text = dInterest_TV2.Text
                    .lblInterest.Text = dUDI_CV2.Text
                    Dim Total As Double
                    For x As Integer = 0 To GridView5.RowCount - 1
                        GridView5.SetRowCellValue(x, "Amount", FormatNumber(GridView5.GetRowCellValue(x, "Amount"), 2))
                        Total += CDbl(GridView5.GetRowCellValue(x, "Amount"))
                    Next
                    .DataSource = GridControl5.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl5.DataSource, "No")
                    .lblBankV2.DataBindings.Add("Text", GridControl5.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl5.DataSource, "Branch")
                    .lblCheckNumber.DataBindings.Add("Text", GridControl5.DataSource, "Check No")
                    .lblDate.DataBindings.Add("Text", GridControl5.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl5.DataSource, "Amount")
                    .lblRemarks.DataBindings.Add("Text", GridControl5.DataSource, "Remarks")
                    .lblAmountT.Text = FormatNumber(Total, 2)
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & cbxPayee.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            If GridView11.RowCount > 0 Then
                Dim Report As New RptCheckRegistry
                With Report
                    .Name = "Check Registry"

                    .lblSupplier.Text = cbxPayeeV5.Text
                    .lblDocumentDate.Text = dtpDocumentV5.Text
                    .lblDocumentNumber.Text = txtDocumentNumberV5.Text
                    .lblPostingDate.Text = dtpReceivedDateV5.Text
                    .lblReferenceNumber.Text = txtReferenceNumberV5.Text
                    .lblBank.Text = cbxBankV5.Text
                    .lblPrincipal.Text = dPrincipalV5.Text
                    .lblTerms.Text = iTerms_CV5.Text
                    .lblInterestRate.Text = dInterest_TV5.Text
                    .lblInterest.Text = dUDI_CV5.Text
                    Dim Total As Double
                    For x As Integer = 0 To GridView11.RowCount - 1
                        GridView11.SetRowCellValue(x, "Amount", FormatNumber(GridView11.GetRowCellValue(x, "Amount"), 2))
                        Total += CDbl(GridView11.GetRowCellValue(x, "Amount"))
                    Next
                    .DataSource = GridControl6.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl6.DataSource, "No")
                    .lblBankV2.DataBindings.Add("Text", GridControl6.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl6.DataSource, "Branch")
                    .lblCheckNumber.DataBindings.Add("Text", GridControl6.DataSource, "Check No")
                    .lblDate.DataBindings.Add("Text", GridControl6.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl6.DataSource, "Amount")
                    .lblRemarks.DataBindings.Add("Text", GridControl6.DataSource, "Remarks")
                    .lblAmountT.Text = FormatNumber(Total, 2)
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & cbxPayeeV5.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            If GridView7.RowCount > 0 Then
                Dim Report As New RptCheckRegistry
                With Report
                    .Name = "Check Registry"

                    .lblSupplier.Text = cbxPayorOthers.Text
                    .lblDocumentDate.Text = dtpDocumentV3.Text
                    .lblDocumentNumber.Text = txtDocumentNumberV3.Text
                    .lblPostingDate.Text = dtpReceivedDateV3.Text
                    .lblReferenceNumber.Text = txtReferenceNumberV3.Text
                    .lblBank.Text = cbxBankV3.Text

                    Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
                    .XrLabel8.Text = "Remarks :"
                    .lblPrincipal.Text = drv("Remarks")
                    .lblPrincipal.SizeF = New SizeF(740, 20)

                    .XrLabel11.Visible = False
                    .lblTerms.Visible = False
                    .XrLabel17.Visible = False
                    .lblInterestRate.Visible = False
                    .XrLabel23.Visible = False
                    .XrLabel19.Visible = False
                    .lblInterest.Visible = False
                    Dim Total As Double
                    For x As Integer = 0 To GridView7.RowCount - 1
                        GridView7.SetRowCellValue(x, "Amount", FormatNumber(GridView7.GetRowCellValue(x, "Amount"), 2))
                        Total += CDbl(GridView7.GetRowCellValue(x, "Amount"))
                    Next
                    .DataSource = GridControl4.DataSource
                    .lblNo.DataBindings.Add("Text", GridControl4.DataSource, "No")
                    .lblBankV2.DataBindings.Add("Text", GridControl4.DataSource, "Bank")
                    .lblBranch.DataBindings.Add("Text", GridControl4.DataSource, "Branch")
                    .lblCheckNumber.DataBindings.Add("Text", GridControl4.DataSource, "Check No")
                    .lblDate.DataBindings.Add("Text", GridControl4.DataSource, "Date")
                    .lblAmount.DataBindings.Add("Text", GridControl4.DataSource, "Amount")
                    .lblRemarks.DataBindings.Add("Text", GridControl4.DataSource, "Remarks")
                    .lblAmountT.Text = FormatNumber(Total, 2)
                    Logs("PDC Management", "Print", "[SENSITIVE] Print PDC of " & cbxPayorOthers.Text, "", "", "", "")
                    .ShowPreview()
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
            GridView9.OptionsPrint.UsePrintStyles = False
            StandardPrinting("POST DATED CHECK LIST", GridControl9)
            Logs("PDC Management", "Print", "[SENSITIVE] Print PDC List", "", "", "", "")
        End If
    End Sub

    Private Sub FrmPDCManagement_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnPayment.Focus()
            btnPayment.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnReplace.Focus()
            btnReplace.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBounce.Focus()
            btnBounce.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnReturn.Focus()
            btnReturn.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            If SuperTabControl1.SelectedTabIndex = 5 Then
                SuperTabControl1.SelectedTab = SuperTabItem5
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                SuperTabControl1.SelectedTab = SuperTabItem4
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                SuperTabControl1.SelectedTab = SuperTabItem3
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                SuperTabControl1.SelectedTab = SuperTabItem2
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                SuperTabControl1.SelectedTab = SuperTabItem1
            End If
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                SuperTabControl1.SelectedTab = SuperTabItem2
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                SuperTabControl1.SelectedTab = SuperTabItem3
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                SuperTabControl1.SelectedTab = SuperTabItem4
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                SuperTabControl1.SelectedTab = SuperTabItem5
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                SuperTabControl1.SelectedTab = SuperTabItem6
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnDue_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    ElseIf GridView3.GetFocusedRowCellValue("Status") = "CLEARED" Then
                        MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    ElseIf GridView3.GetFocusedRowCellValue("Status") = "RETURNED" Then
                        MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If CDate(GridView3.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
                Else
                    MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Dim Official As New FrmOfficialReceipt
                With Official
                    If FrmMain.lblDate.Text.Contains("Disconnected") Then
                        MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    .Tag = 99
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
                    .CreditNumber = cbxApplication.SelectedValue
                    .cbxCash.Enabled = False
                    .cbxCheck.Enabled = False
                    .cbxOnline.Enabled = False
                    .cbxCheck.Checked = True
                    .cbxCheckNumber.Text = GridView3.GetFocusedRowCellValue("Check No")
                    .dtpCheck.Value = GridView3.GetFocusedRowCellValue("Date")
                    .CheckID = GridView3.GetFocusedRowCellValue("ID")
                    .tabList.Visible = False
                    .btnNext.Enabled = False
                    .btnRefresh.Enabled = False
                    .cbxPayee.Enabled = False
                    .cbxCheckNumber.Enabled = False
                    .dtpCheck.Enabled = False
                    .dtpDeposit.Enabled = False
                    .dPaidAmount.Enabled = False
                    .dPaidAmount.Value = GridView3.GetFocusedRowCellValue("Amount")
                    .btnBatchPayment.Enabled = False
                    If .ShowDialog = DialogResult.OK Then
                        LoadData()
                    End If
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                Try
                    If GridView1.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    ElseIf GridView1.GetFocusedRowCellValue("Status") = "CLEARED" Then
                        MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If CDate(GridView1.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
                Else
                    MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
                    Dim drv As DataRowView = DirectCast(cbxAssetNumber.SelectedItem, DataRowView)
                    .From_Check = True
                    .AssetNumber = drv("AssetNumber")
                    .cbxCash.Enabled = False
                    .cbxCheck.Enabled = False
                    .cbxOnline.Enabled = False
                    .cbxCheck.Checked = True
                    .cbxCheckNumber.Text = GridView1.GetFocusedRowCellValue("Check No")
                    .dtpDeposit.Value = GridView1.GetFocusedRowCellValue("Date")
                    .CheckID = GridView1.GetFocusedRowCellValue("ID")
                    .tabList.Visible = False
                    .btnNext.Enabled = False
                    .btnRefresh.Enabled = False
                    .cbxPayee.Enabled = False
                    .cbxCheckNumber.Enabled = False
                    .dtpCheck.Enabled = False
                    .dtpDeposit.Enabled = False
                    .cbxLOE.Enabled = False
                    .cbxAR.Enabled = False
                    .cbxDF.Enabled = False
                    .cbxITL.Enabled = False
                    .cbxRO.Enabled = False
                    .cbxLOE.Checked = False
                    .cbxAR.Checked = False
                    .cbxDF.Checked = False
                    .cbxITL.Checked = False
                    .cbxRO.Checked = True
                    .cbxLA.Enabled = False
                    .cbxLA.Checked = False
                    .cbxCAS.Enabled = False
                    .cbxCAS.Checked = False
                    .dPaidAmount.Enabled = False
                    .dPaidAmount.Value = GridView1.GetFocusedRowCellValue("Amount")

                    If .ShowDialog = DialogResult.OK Then
                        LoadData()
                    End If
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                Try
                    If GridView2.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    ElseIf GridView2.GetFocusedRowCellValue("Status") = "CLEARED" Then
                        MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    ElseIf GridView2.GetFocusedRowCellValue("Status") = "RETURNED" Then
                        MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    ElseIf GridView2.GetFocusedRowCellValue("Status") = "REPLACED" Then
                        MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                If CDate(GridView2.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
                Else
                    MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
                    Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
                    If dPrincipal.Value <= CDbl(GridView2.GetFocusedRowCellValue("Amount")) Then
                        .DFPayPrincipal = True
                        If drv("ForRollOver") = 1 Then
                            MsgBox("This is for Roll Over, please register new set of PDC.", MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If
                    End If
                    .From_Check = True
                    .FromDueFrom = True
                    .AccountsReceivableID = cbxPayor.SelectedValue
                    .MultipleAR = drv("Multiple")
                    If .MultipleAR Then
                        Dim Docs As String = ""
                        Dim DF_List As New DataTable
                        DF_List = DataSource(String.Format("SELECT DocumentNumber FROM due_from WHERE DC_ID = {0} AND `status` = 'ACTIVE';", drv("ID")))
                        For x As Integer = 0 To DF_List.Rows.Count - 1
                            Docs &= "'" & DF_List(x)("DocumentNumber") & "'"
                            If x < DF_List.Rows.Count - 1 Then
                                Docs &= ", "
                            End If
                        Next
                        .AccountsReceivableID_M = Docs
                    End If
                    .AssetNumber = .AccountsReceivableID
                    .BankID = cbxBank.SelectedValue
                    .cbxCash.Enabled = False
                    .cbxCheck.Enabled = False
                    .cbxOnline.Enabled = False
                    .cbxCheck.Checked = True
                    .cbxCheckNumber.Text = GridView2.GetFocusedRowCellValue("Check No")
                    .dtpCheck.Value = GridView2.GetFocusedRowCellValue("Date")
                    .CheckID = GridView2.GetFocusedRowCellValue("ID")
                    .tabList.Visible = False
                    .btnNext.Enabled = False
                    .btnRefresh.Enabled = False
                    .cbxPayee.Enabled = False
                    .cbxCheckNumber.Enabled = False
                    .dtpCheck.Enabled = False
                    .dtpDeposit.Enabled = False
                    .cbxLOE.Enabled = False
                    .cbxAR.Enabled = False
                    .cbxDF.Enabled = False
                    .cbxITL.Enabled = False
                    .cbxRO.Enabled = False
                    .cbxLOE.Checked = False
                    .cbxAR.Checked = False
                    .cbxDF.Checked = False
                    .cbxITL.Checked = False
                    .cbxRO.Checked = False
                    .cbxLA.Enabled = False
                    .cbxLA.Checked = False
                    .cbxCAS.Enabled = False
                    .cbxCAS.Checked = False
                    .dPaidAmount.Enabled = False
                    .dPaidAmount.Value = GridView2.GetFocusedRowCellValue("Amount")

                    If .ShowDialog = DialogResult.OK Then
                        Load_DueFromChecks()
                    End If
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                Try
                    If GridView7.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    ElseIf GridView7.GetFocusedRowCellValue("Status") = "CLEARED" Then
                        MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    ElseIf GridView7.GetFocusedRowCellValue("Status") = "RETURNED" Then
                        MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    ElseIf GridView7.GetFocusedRowCellValue("Status") = "REPLACED" Then
                        MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
                If drv("DueStatus") = "PENDING" Then
                    MsgBox(String.Format("{0} is still for Verification.", cbxPayorOthers.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If CDate(GridView7.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
                Else
                    MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
                    .From_PDC_Others = True
                    .AccountsReceivableID = cbxPayorOthers.SelectedValue
                    .AssetNumber = .AccountsReceivableID
                    .BankID = cbxBankV3.SelectedValue
                    .cbxCash.Enabled = False
                    .cbxCheck.Enabled = False
                    .cbxOnline.Enabled = False
                    .cbxCheck.Checked = True
                    .cbxCheckNumber.Text = GridView7.GetFocusedRowCellValue("Check No")
                    .dtpCheck.Value = GridView7.GetFocusedRowCellValue("Date")
                    .CheckID = GridView7.GetFocusedRowCellValue("ID")
                    .tabList.Visible = False
                    .btnNext.Enabled = False
                    .btnRefresh.Enabled = False
                    .cbxPayee.Enabled = False
                    .cbxCheckNumber.Enabled = False
                    .dtpCheck.Enabled = False
                    .dtpDeposit.Enabled = False
                    .cbxLOE.Enabled = False
                    .cbxAR.Enabled = False
                    .cbxDF.Enabled = False
                    .cbxITL.Enabled = False
                    .cbxRO.Enabled = False
                    .cbxLOE.Checked = False
                    .cbxAR.Checked = False
                    .cbxDF.Checked = False
                    .cbxITL.Checked = False
                    .cbxRO.Checked = False
                    .cbxLA.Enabled = False
                    .cbxLA.Checked = False
                    .cbxCAS.Enabled = False
                    .cbxCAS.Checked = False
                    .dPaidAmount.Enabled = False
                    .dPaidAmount.Value = GridView7.GetFocusedRowCellValue("Amount")

                    If .ShowDialog = DialogResult.OK Then
                        LoadPDCOthers()
                    End If
                End With
            End If
        Catch ex As Exception
            TriggerBugReport("PDC Management - Payment", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnReplace_Click(sender As Object, e As EventArgs) Handles btnReplace.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                Dim drv_B As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
                Dim Replace As New FrmReplaceCheck
                With Replace
                    .From_Credit = True
                    .Buyer = txtBorrower.Text
                    .ContactN = txtContactN_2.Text
                    .AssetNumber = cbxApplication.SelectedValue
                    .ORNumber = ""
                    .Sold_ID = ""
                    .xDate = GridView3.GetFocusedRowCellValue("Date")
                    .Bank = GridView3.GetFocusedRowCellValue("Bank")
                    .Branch = GridView3.GetFocusedRowCellValue("Branch")
                    .dAmount.Value = CDbl(GridView3.GetFocusedRowCellValue("Amount"))
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE check_received SET `status` = 'RETURNED' WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxApplication.SelectedValue, GridView3.GetFocusedRowCellValue("Check No"), GridView3.GetFocusedRowCellValue("ID")))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView3.GetFocusedRowCellValue("Check No"), cbxApplication.SelectedValue), "", "", "", cbxApplication.SelectedValue)
                        LoadData()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                Try
                    If GridView1.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                Dim drv_B As DataRowView = DirectCast(cbxAssetNumber.SelectedItem, DataRowView)
                Dim Replace As New FrmReplaceCheck
                With Replace
                    .Buyer = txtBuyer.Text
                    .ContactN = txtContactN.Text
                    .AssetNumber = cbxAssetNumber.Text.Substring(0, 17)
                    .ORNumber = ""
                    .Sold_ID = ""
                    .xDate = GridView1.GetFocusedRowCellValue("Date")
                    .Bank = GridView1.GetFocusedRowCellValue("Bank")
                    .Branch = GridView1.GetFocusedRowCellValue("Branch")
                    .dAmount.Value = CDbl(GridView1.GetFocusedRowCellValue("Amount"))
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE check_received SET `status` = 'RETURNED' WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxAssetNumber.Text.Substring(0, 17), GridView1.GetFocusedRowCellValue("Check No"), GridView1.GetFocusedRowCellValue("ID")))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView1.GetFocusedRowCellValue("Check No"), cbxAssetNumber.Text.Substring(0, 17)), "", "", "", "")
                        LoadData()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                Try
                    If GridView2.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                Dim Check As New FrmDueCheckRegistry
                With Check
                    .vSave = vSave
                    .vPrint = vPrint
                    .vDelete = vDelete
                    .vUpdate = vUpdate
                    .From_CheckManagement = True
                    .btnDelete.Enabled = False
                    .btnSave.Enabled = True
                    .btnAddC.Enabled = False
                    .btnRemoveC.Enabled = False
                    .btnRefresh.Enabled = False
                    .dtpReceivedDate.Enabled = False
                    .txtReferenceNumber.Enabled = False
                    .dPrincipal.Enabled = False
                    .iTerms_C.Enabled = False
                    .dInterest_T.Enabled = False
                    .dUDI_C.Enabled = False
                    .cbxBank.Enabled = False
                    .cbxPayor.Enabled = False

                    .Payor = cbxPayor.Text
                    .txtDocumentNumber.Text = txtDocumentNumber.Text
                    .DefaultBank = cbxBank.SelectedValue
                    .dtpReceivedDate.Value = dtpReceivedDate.Value
                    .txtReferenceNumber.Text = txtReferenceNumber.Text
                    .dPrincipal.Value = dPrincipal.Value
                    .iTerms_C.Value = iTerms_C.Value
                    .dInterest_T.Value = dInterest_T.Value
                    .dUDI_C.Value = dUDI_C.Value

                    .DT = DataSource(String.Format("SELECT 1 AS 'No', Bank, Branch, '' AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', FORMAT(Amount,2) AS 'Amount', Remarks FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' AND ID = '{1}';", txtDocumentNumber.Text, GridView2.GetFocusedRowCellValue("ID")))
                    .GridControl2.DataSource = .DT
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Replaced - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumber.Text, GridView2.GetFocusedRowCellValue("Check No"), GridView2.GetFocusedRowCellValue("ID"), Reason))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView2.GetFocusedRowCellValue("Check No"), cbxPayor.Text), "", "", "", "")
                        Load_DueFromChecks()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                Try
                    If GridView5.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                Dim Check As New FrmDueCheckRegistry
                With Check
                    .vSave = vSave
                    .vPrint = vPrint
                    .vDelete = vDelete
                    .vUpdate = vUpdate
                    .From_CheckManagement = True
                    .btnDelete.Enabled = False
                    .btnSave.Enabled = True
                    .btnAddC.Enabled = False
                    .btnRemoveC.Enabled = False
                    .btnRefresh.Enabled = False
                    .dtpReceivedDate.Enabled = False
                    .txtReferenceNumber.Enabled = False
                    .dPrincipal.Enabled = False
                    .iTerms_C.Enabled = False
                    .dInterest_T.Enabled = False
                    .dUDI_C.Enabled = False
                    .cbxBank.Enabled = False
                    .cbxPayor.Enabled = False

                    .Payor = cbxPayee.Text
                    .txtDocumentNumber.Text = txtDocumentNumberV2.Text
                    .DefaultBank = cbxBankV2.SelectedValue
                    .dtpReceivedDate.Value = dtpReceivedDateV2.Value
                    .txtReferenceNumber.Text = txtReferenceNumberV2.Text
                    .dPrincipal.Value = dPrincipalV2.Value
                    .iTerms_C.Value = iTerms_CV2.Value
                    .dInterest_T.Value = dInterest_TV2.Value
                    .dUDI_C.Value = dUDI_CV2.Value

                    .DT = DataSource(String.Format("SELECT 1 AS 'No', Bank, Branch, '' AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', FORMAT(Amount,2) AS 'Amount', Remarks FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' AND ID = '{1}';", txtDocumentNumberV2.Text, GridView5.GetFocusedRowCellValue("ID")))
                    .GridControl2.DataSource = .DT
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Replaced - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV2.Text, GridView5.GetFocusedRowCellValue("Check No"), GridView5.GetFocusedRowCellValue("ID"), Reason))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView5.GetFocusedRowCellValue("Check No"), cbxPayee.Text), "", "", "", "")
                        LoadDueToChecks()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                Try
                    If GridView11.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                Dim Check As New FrmDueCheckRegistry
                With Check
                    .vSave = vSave
                    .vPrint = vPrint
                    .vDelete = vDelete
                    .vUpdate = vUpdate
                    .From_CheckManagement = True
                    .btnDelete.Enabled = False
                    .btnSave.Enabled = True
                    .btnAddC.Enabled = False
                    .btnRemoveC.Enabled = False
                    .btnRefresh.Enabled = False
                    .dtpReceivedDate.Enabled = False
                    .txtReferenceNumber.Enabled = False
                    .dPrincipal.Enabled = False
                    .iTerms_C.Enabled = False
                    .dInterest_T.Enabled = False
                    .dUDI_C.Enabled = False
                    .cbxBank.Enabled = False
                    .cbxPayor.Enabled = False

                    .Payor = cbxPayeeV5.Text
                    .txtDocumentNumber.Text = txtDocumentNumberV5.Text
                    .DefaultBank = cbxBankV5.SelectedValue
                    .dtpReceivedDate.Value = dtpReceivedDateV5.Value
                    .txtReferenceNumber.Text = txtReferenceNumberV5.Text
                    .dPrincipal.Value = dPrincipalV5.Value
                    .iTerms_C.Value = iTerms_CV5.Value
                    .dInterest_T.Value = dInterest_TV5.Value
                    .dUDI_C.Value = dUDI_CV5.Value

                    .DT = DataSource(String.Format("SELECT 1 AS 'No', Bank, Branch, '' AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', FORMAT(Amount,2) AS 'Amount', Remarks FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' AND ID = '{1}';", txtDocumentNumberV5.Text, GridView11.GetFocusedRowCellValue("ID")))
                    .GridControl2.DataSource = .DT
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Replaced - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV5.Text, GridView11.GetFocusedRowCellValue("Check No"), GridView11.GetFocusedRowCellValue("ID"), Reason))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView11.GetFocusedRowCellValue("Check No"), cbxPayeeV5.Text), "", "", "", "")
                        LoadLoansPayableChecks()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                Try
                    If GridView7.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                Dim Check As New FrmDueCheckRegistry
                With Check
                    .vSave = vSave
                    .vPrint = vPrint
                    .vDelete = vDelete
                    .vUpdate = vUpdate
                    .From_CheckManagement = True
                    .From_PDC_Others = True
                    .btnDelete.Enabled = False
                    .btnSave.Enabled = True
                    .btnRemoveC.Enabled = False
                    .btnRefresh.Enabled = False
                    .dtpReceivedDate.Enabled = False
                    .txtReferenceNumber.Enabled = False
                    .dPrincipal.Enabled = False
                    .iTerms_C.Enabled = False
                    .dInterest_T.Enabled = False
                    .dUDI_C.Enabled = False
                    .cbxBank.Enabled = False
                    .cbxPayor.Enabled = False

                    .txtRemarks.Visible = True
                    .LabelX2.Visible = True
                    LabelX2.Enabled = False

                    .LabelX3.Visible = False
                    .dPrincipal.Visible = False
                    .LabelX81.Visible = False
                    .iTerms_C.Visible = False
                    .LabelX82.Visible = False
                    .dInterest_T.Visible = False
                    .lblInterest.Visible = False
                    .LabelX89.Visible = False
                    .dUDI_C.Visible = False

                    .Payor = cbxPayorOthers.Text
                    .txtDocumentNumber.Text = txtDocumentNumberV3.Text
                    .DefaultBank = cbxBankV3.SelectedValue
                    .dtpReceivedDate.Value = dtpReceivedDateV3.Value
                    .txtReferenceNumber.Text = txtReferenceNumberV3.Text
                    Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
                    .txtRemarks.Text = drv("Remarks")

                    .DT = DataSource(String.Format("SELECT 1 AS 'No', Bank, Branch, '' AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', FORMAT(Amount,2) AS 'Amount', Remarks FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' AND ID = '{1}';", txtDocumentNumberV3.Text, GridView7.GetFocusedRowCellValue("ID")))
                    .GridControl2.DataSource = .DT
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Replaced - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV3.Text, GridView7.GetFocusedRowCellValue("Check No"), GridView7.GetFocusedRowCellValue("ID"), Reason))
                        Logs("PDC Management", "Replace", String.Format("REPLACED {1} check for {0}", GridView7.GetFocusedRowCellValue("Check No"), cbxPayee.Text), "", "", "", "")
                        LoadPDCOthers()
                        MsgBox("Check Replaced!", MsgBoxStyle.Information, "Info")
                    End If
                    .Dispose()
                End With
            End If
        Catch ex As Exception
            TriggerBugReport("PDC Management - Replace", ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView1RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView1.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                If GridView1.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView1.GetFocusedRowCellValue("Status") = "PAID" Or GridView1.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView1.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView1.GetFocusedRowCellValue("Status") = "ACTIVE" Then
                    btnReturn.Enabled = True
                    If GridView1.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnReturnedNotice.Enabled = False 'True
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView2_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView2.FocusedRowChanged
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView2.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                If GridView2.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView2.GetFocusedRowCellValue("Status") = "PAID" Or GridView2.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView2.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView2.GetFocusedRowCellValue("Status") = "ON HAND" Then
                    btnReturn.Enabled = True
                    If GridView2.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnReturnedNotice.Enabled = False 'True
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView7_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView7.FocusedRowChanged
        If GridView7.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView7.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                If GridView7.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView7.GetFocusedRowCellValue("Status") = "PAID" Or GridView7.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView7.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView7.GetFocusedRowCellValue("Status") = "ON HAND" Then
                    btnReturn.Enabled = True
                    If GridView7.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnReturnedNotice.Enabled = False
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView5_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView5.FocusedRowChanged
        If GridView5.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView5.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                If GridView5.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView5.GetFocusedRowCellValue("Status") = "PAID" Or GridView5.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView5.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView5.GetFocusedRowCellValue("Status") = "ON HAND" Then
                    btnReturn.Enabled = True
                    If GridView5.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnReturnedNotice.Enabled = False 'True
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView11_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView11.FocusedRowChanged
        If GridView11.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView11.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                If GridView11.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView11.GetFocusedRowCellValue("Status") = "PAID" Or GridView11.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView11.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView11.GetFocusedRowCellValue("Status") = "ON HAND" Then
                    btnReturn.Enabled = True
                    If GridView11.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnReturnedNotice.Enabled = False 'True
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnBounce_Click(sender As Object, e As EventArgs) Handles btnBounce.Click
        Dim Bounce As New FrmBouncedReason
        With Bounce
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                If GridView3.GetFocusedRowCellValue("PostStatus") = "POSTED" Then
                Else
                    MsgBox("Payment is not yet posted, bouncing is not allowed.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                .Sold_ID = ""
                .ORNum = ""
                Dim drv_B As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
                .BuyerContact = txtContactN_2.Text
                .FullName = txtBorrower.Text
                .PrefixN = drv_B("Prefix_B")
                .PrefixN = drv_B("LastN_B")
                .Address = drv_B("Address")
                .From_Credit = True
                .AccountNumber = drv_B("AccountNumber")
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
            Else
                Try
                    If GridView1.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                Dim DT_Multiple As DataTable
                If cbxAssetNumber.Text.Substring(0, 17).Contains("V") Then
                    DT_Multiple = DataSource(String.Format("SELECT IF(account_count > 1,TRUE,FALSE) AS 'MultipleA', PlateNum AS 'ROPOA_Ref' FROM ropoa_vehicle WHERE AssetNumber = '{0}'", cbxAssetNumber.Text.Substring(0, 17)))
                Else
                    DT_Multiple = DataSource(String.Format("SELECT IF(account_count > 1,TRUE,FALSE) AS 'MultipleA', TCT AS 'ROPOA_Ref' FROM ropoa_realestate WHERE AssetNumber = '{0}'", cbxAssetNumber.Text.Substring(0, 17)))
                End If
                .Sold_ID = ""
                .MultipleA = DT_Multiple(0)("MultipleA")
                .ROPOA_Ref = DT_Multiple(0)("ROPOA_Ref")
                .ORNum = GridView1.GetFocusedRowCellValue("ORNumber")
                Dim drv_B As DataRowView = DirectCast(cbxAssetNumber.SelectedItem, DataRowView)
                .BuyerContact = txtContactN.Text
                .FullName = txtBuyer.Text
                .PrefixN = drv_B("Prefix_B")
                .PrefixN = drv_B("LastN_B")
                .Address = drv_B("Address")
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                    If cbxAssetNumber.Text.Substring(0, 17).Contains("V") Then
                        With FrmVehicleROPOA
                            .Clear()
                            .LoadSold()
                            .LoadReserved()
                        End With
                    Else
                        With FrmRealEstateROPOA
                            .Clear()
                            .LoadSold()
                            .LoadReserved()
                        End With
                    End If
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView3.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET `status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxApplication.SelectedValue, GridView3.GetFocusedRowCellValue("Check No"), GridView3.GetFocusedRowCellValue("ID")))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView3.GetFocusedRowCellValue("Check No"), cbxApplication.SelectedValue), "", "", "", cbxApplication.SelectedValue)

                    LoadData()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                Try
                    If GridView1.GetFocusedRowCellValue("Check No") = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView1.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET `status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxAssetNumber.Text.Substring(0, 17), GridView1.GetFocusedRowCellValue("Check No"), GridView1.GetFocusedRowCellValue("ID")))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView1.GetFocusedRowCellValue("Check No"), cbxAssetNumber.Text.Substring(0, 17)), "", "", "", "")

                    LoadData()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                Try
                    If GridView2.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView2.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumber.Text, GridView2.GetFocusedRowCellValue("Check No"), GridView2.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView2.GetFocusedRowCellValue("Check No"), cbxPayor.Text), "", "", "", "")

                    Load_DueFromChecks()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                Try
                    If GridView5.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView5.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV2.Text, GridView5.GetFocusedRowCellValue("Check No"), GridView5.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView5.GetFocusedRowCellValue("Check No"), cbxPayee.Text), "", "", "", "")

                    LoadDueToChecks()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                Try
                    If GridView11.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView11.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV5.Text, GridView11.GetFocusedRowCellValue("Check No"), GridView11.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView11.GetFocusedRowCellValue("Check No"), cbxPayeeV5.Text), "", "", "", "")

                    LoadLoansPayableChecks()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                Try
                    If GridView7.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If MsgBoxYes(String.Format("Are you sure you want to return this Check {0}?", GridView7.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Returned - {3}]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND ID = '{2}';", txtDocumentNumberV3.Text, GridView7.GetFocusedRowCellValue("Check No"), GridView7.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Return", String.Format("RETURNED {1} check for {0}", GridView7.GetFocusedRowCellValue("Check No"), cbxPayorOthers.Text), "", "", "", "")

                    LoadPDCOthers()
                    MsgBox("Check Returned!", MsgBoxStyle.Information, "Info")
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("PDC Management - Return", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv_B As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            txtBorrower.Text = ""
            txtContactN_2.Text = ""
            btnPDC.Enabled = False
            GridControl3.DataSource = Nothing
        Else
            txtBorrower.Text = drv_B("FName")
            txtContactN_2.Text = drv_B("Mobile_B")
            btnPDC.Enabled = True
            LoadData()

            Dim SQL As String = "SELECT CONCAT(IF(Prefix_B = '',IF(Gender_B = 'Male','Mr',IF(Gender_B = 'Female' AND Civil_B = 'Single','Ms','Mrs')),Prefix_B), ' ', FirstN_B, ' ', LastN_B) AS 'Name', "
            SQL &= "    CONCAT(IF(Prefix_B = '',IF(Gender_B = 'Male','Mr',IF(Gender_B = 'Female' AND Civil_B = 'Single','Ms','Mrs')),Prefix_B), ' ', LastN_B) AS 'Last Name', "
            SQL &= "    CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), BarangayC_B) AS 'Address', "
            SQL &= "    IFNULL((SELECT citymunDesc FROM city_municipality WHERE citymunCode = `AddressC_B-ID`),'') AS 'City', "
            SQL &= "    IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = CreditNumber AND `status` = 'ACTIVE' AND JVNumber = ''),'Release Date') AS 'Last Payment', "
            SQL &= "    FirstNotice, Face_Amount, TermType "
            SQL &= String.Format(" FROM credit_application WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue)
            DT_Borrower = DataSource(SQL)

            If drv_B("PaymentRequest") = "CLOSED" Then
                MsgBox("Account is already closed!", MsgBoxStyle.Information, "Info")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView3.GetFocusedRowCellValue("Status") = "CLEARED" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnRemove.Enabled = False
                If GridView3.GetFocusedRowCellValue("Remarks").ToString.Contains("[Cleared Check]") Then
                    btnBounce.Enabled = True
                Else
                    btnBounce.Enabled = False
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnRemove.Enabled = False
                End If
                btnReturnedNotice.Enabled = False
            ElseIf GridView3.GetFocusedRowCellValue("Status") = "PAID" Or GridView3.GetFocusedRowCellValue("Status") = "PARTIAL" Then
                btnReplace.Enabled = False
                btnReturn.Enabled = False
                btnHold.Enabled = False
                btnBounce.Enabled = False
                btnRemove.Enabled = False
                btnReturnedNotice.Enabled = False
            Else
                If GridView3.GetFocusedRowCellValue("Remarks").ToString.Contains("[Bounced Check]") Or GridView3.GetFocusedRowCellValue("Status") = "ACTIVE" Then
                    btnReturn.Enabled = True
                    If GridView3.GetFocusedRowCellValue("Hold") = False Then
                        btnHold.Enabled = True
                    Else
                        btnHold.Enabled = False
                    End If
                    btnReplace.Enabled = True
                    If GridView3.GetFocusedRowCellValue("Status") = "ACTIVE" Then
                        btnRemove.Enabled = True
                    Else
                        btnRemove.Enabled = False
                    End If
                Else
                    btnReturn.Enabled = False
                    btnHold.Enabled = False
                    btnReplace.Enabled = False
                    btnRemove.Enabled = False
                    btnReturnedNotice.Enabled = True
                End If
                btnBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        If GridView3.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView3RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView2RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView5_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView5.RowCellStyle
        If GridView5.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView5RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub GridView11_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView11.RowCellStyle
        If GridView11.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView11RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                If MsgBoxYes(String.Format("Are you sure you want to HOLD this Check {0}?", GridView3.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET `Hold` = '1', Remarks = CONCAT(Remarks, ' [Hold Check - {3}]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}' AND `Hold` = 0;", cbxApplication.SelectedValue, GridView3.GetFocusedRowCellValue("Check No"), GridView3.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Hold", String.Format("HOLD {1} check for {0}", GridView3.GetFocusedRowCellValue("Check No"), cbxApplication.SelectedValue), "", "", "", cbxApplication.SelectedValue)

                    LoadData()
                    MsgBox("Check Hold!", MsgBoxStyle.Information, "Info")
                End If
            Else
                Try
                    If GridView1.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                If MsgBoxYes(String.Format("Are you sure you want to HOLD this Check {0}?", GridView1.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET `Hold` = '1', Remarks = CONCAT(Remarks, ' [Hold Check - {3}]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}' AND `Hold` = 0;", cbxAssetNumber.Text.Substring(0, 17), GridView1.GetFocusedRowCellValue("Check No"), GridView1.GetFocusedRowCellValue("ID"), Reason))
                    Logs("PDC Management", "Hold", String.Format("HOLD {1} check for {0}", GridView1.GetFocusedRowCellValue("Check No"), cbxAssetNumber.Text.Substring(0, 17)), "", "", "", "")

                    LoadData()
                    MsgBox("Check Hold!", MsgBoxStyle.Information, "Info")
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("PDC Management - Hold", ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnPayment.PerformClick()
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        btnPayment.PerformClick()
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        btnPayment.PerformClick()
    End Sub

    Private Sub GridView7_DoubleClick(sender As Object, e As EventArgs) Handles GridView7.DoubleClick
        btnPayment.PerformClick()
    End Sub

    Private Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
        btnJournalVoucher.PerformClick()
    End Sub

    Private Sub GridView11_DoubleClick(sender As Object, e As EventArgs) Handles GridView11.DoubleClick
        btnJournalVoucher.PerformClick()
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnLedger.Visible = True
            btnRemove.Visible = True
            btnJournalVoucher.Visible = False
            btnCheckVoucher.Visible = False
            btnReplace.Location = New Point(455 + 113, 3)
            btnReturn.Location = New Point(568 + 113, 3)
            btnRemove.Location = New Point(681 + 113, 3)
            btnLedger.Location = New Point(794 + 113, 3)
            btnPayment.Visible = True
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = False
            btnCheckVoucher.Visible = False
            btnReplace.Location = New Point(455 + 113, 3)
            btnReturn.Location = New Point(568 + 113, 3)
            btnRemove.Location = New Point(681 + 113, 3)
            btnLedger.Location = New Point(794 + 113, 3)
            btnPayment.Visible = True
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = False
            btnCheckVoucher.Visible = False
            btnReplace.Location = New Point(455 + 113, 3)
            btnReturn.Location = New Point(568 + 113, 3)
            btnRemove.Location = New Point(681 + 113, 3)
            btnLedger.Location = New Point(794 + 113, 3)
            btnPayment.Visible = True
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = True
            btnCheckVoucher.Visible = True
            btnJournalVoucher.Location = New Point(342 + 113, 3)
            btnReplace.Location = New Point(568 + 113, 3)
            btnReturn.Location = New Point(681 + 113, 3)
            btnRemove.Location = New Point(794 + 113, 3)
            btnLedger.Location = New Point(907 + 113, 3)
            btnPayment.Visible = False
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
            btnJournalVoucher.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = True
            btnCheckVoucher.Visible = True
            btnJournalVoucher.Location = New Point(342 + 113, 3)
            btnReplace.Location = New Point(568 + 113, 3)
            btnReturn.Location = New Point(681 + 113, 3)
            btnRemove.Location = New Point(794 + 113, 3)
            btnLedger.Location = New Point(907 + 113, 3)
            btnPayment.Visible = False
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
            btnJournalVoucher.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = True
            btnCheckVoucher.Visible = False
            btnPayment.Visible = True
            btnJournalVoucher.Location = New Point(455 + 113, 3)
            btnReplace.Location = New Point(568 + 113, 3)
            btnReturn.Location = New Point(681 + 113, 3)
            btnRemove.Location = New Point(794 + 113, 3)
            btnLedger.Location = New Point(907 + 113, 3)
            btnReturn.Enabled = True
            btnReplace.Enabled = True
            btnPayment.Enabled = True
            btnJournalVoucher.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
            btnLedger.Visible = False
            btnRemove.Visible = False
            btnJournalVoucher.Visible = True
            btnJournalVoucher.Location = New Point(342 + 113, 3)
            btnCheckVoucher.Visible = False
            btnReplace.Location = New Point(455 + 113, 3)
            btnReturn.Location = New Point(568 + 113, 3)
            btnRemove.Location = New Point(681 + 113, 3)
            btnLedger.Location = New Point(794 + 113, 3)
            btnPayment.Visible = False
            btnReturn.Enabled = False
            btnReplace.Enabled = False
            btnPayment.Enabled = False
            'btnJournalVoucher.Enabled = True
            btnJournalVoucher.Enabled = False
        End If
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            MsgBox("Please select credit application first.", MsgBoxStyle.Information, "Info")
            cbxApplication.DroppedDown = True
            Exit Sub
        End If
        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = cbxApplication.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxPayor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayor.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
        If cbxPayor.SelectedIndex = -1 Or cbxPayor.Text = "" Then
            dtpDocument.Value = Date.Now
            txtDocumentNumber.Text = ""
            cbxBank.SelectedIndex = -1
            dtpReceivedDate.Value = Date.Now
            txtReferenceNumber.Text = ""
            dPrincipal.Value = 0
            iTerms_C.Value = 0
            dInterest_T.Value = 0
            dUDI_C.Value = 0

            GridControl2.DataSource = Nothing
        Else
            If drv("Multiple") Then
                DueFrom_Payable = DataObject(String.Format("SELECT SUM(Amount - Paid) FROM due_from WHERE DocumentNumber = '{0}';", drv("ID")))
            Else
                DueFrom_Payable = DataObject(String.Format("SELECT Amount - Paid FROM due_from WHERE DocumentNumber = '{0}';", drv("DocumentNumber")))
            End If
            If DueFrom_Payable > 0 Then
                GridControl2.Enabled = True
            Else
                MsgBox("Due From is already Fully Paid.", MsgBoxStyle.Information, "Info")
                GridControl2.Enabled = False
            End If

            dtpDocument.Value = drv("DocumentDate")
            txtDocumentNumber.Text = drv("DocumentNumber")
            cbxBank.SelectedValue = drv("BankID")
            dtpReceivedDate.Value = drv("ReceivedDate")
            txtReferenceNumber.Text = drv("ReferenceNumber")
            dPrincipal.Value = drv("Principal")
            iTerms_C.Value = drv("Terms")
            dInterest_T.Value = drv("InterestRate")
            dUDI_C.Value = drv("UDI")

            Load_DueFromChecks()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxPayorOthers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayorOthers.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
        If cbxPayorOthers.SelectedIndex = -1 Or cbxPayorOthers.Text = "" Then
            dtpDocumentV3.Value = Date.Now
            txtDocumentNumberV3.Text = ""
            cbxBankV3.SelectedIndex = -1
            dtpReceivedDateV3.Value = Date.Now
            txtReferenceNumberV3.Text = ""

            GridControl4.DataSource = Nothing
            GridControl4.Enabled = True
        Else
            dtpDocumentV3.Value = drv("DocumentDate")
            txtDocumentNumberV3.Text = drv("DocumentNumber")
            cbxBankV3.SelectedValue = drv("BankID")
            dtpReceivedDateV3.Value = drv("ReceivedDate")
            txtReferenceNumberV3.Text = drv("ReferenceNumber")

            LoadPDCOthers()
            If drv("DueStatus") = "PENDING" Then
                MsgBox("PDC Others is still pending, please verify the checks to be able to proceed.", MsgBoxStyle.Information, "Info")
                GridControl4.Enabled = False
            Else
                GridControl4.Enabled = True
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM dc_details WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID")))
            If GridView2.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView2.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET remarks = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), GridView2.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView2.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxPayor.Text, GridView2.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnPayment.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView5.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM dc_details WHERE ID = '{0}';", GridView5.GetFocusedRowCellValue("ID")))
            If GridView5.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView5.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET remarks = '{1}' WHERE ID = '{0}';", GridView5.GetFocusedRowCellValue("ID"), GridView5.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView5.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxPayee.Text, GridView5.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnJournalVoucher.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView7_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView7.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM dc_details WHERE ID = '{0}';", GridView7.GetFocusedRowCellValue("ID")))
            If GridView7.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView7.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET remarks = '{1}' WHERE ID = '{0}';", GridView7.GetFocusedRowCellValue("ID"), GridView7.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView7.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxPayorOthers.Text, GridView7.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnPayment.PerformClick()
            End If
        End If
    End Sub

    Private Sub Load_DueFromChecks()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ROW_NUMBER() OVER() AS 'No', Bank, Branch, CheckNumber AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', Amount, Remarks, Check_Status AS 'Status' FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY IF(Check_Status = 'ON HAND',1,Check_Status), CheckDate, CheckNumber;", txtDocumentNumber.Text))
        GridControl2.DataSource = DT
    End Sub

    Private Sub LoadPDCOthers()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ROW_NUMBER() OVER() AS 'No', Bank, Branch, CheckNumber AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', Amount, Remarks, Check_Status AS 'Status' FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY IF(Check_Status = 'ON HAND',1,Check_Status), CheckDate, CheckNumber;", txtDocumentNumberV3.Text))
        GridControl4.DataSource = DT
    End Sub

    Private Sub LoadDueToChecks()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ROW_NUMBER() OVER() AS 'No', Bank, Branch, CheckNumber AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', Amount, Remarks, Check_Status AS 'Status' FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY IF(Check_Status = 'ON HAND',1,Check_Status), CheckDate, CheckNumber;", txtDocumentNumberV2.Text))
        GridControl5.DataSource = DT
    End Sub

    Private Sub GridView11_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView11.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM dc_details WHERE ID = '{0}';", GridView11.GetFocusedRowCellValue("ID")))
            If GridView11.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks from '{1}' to '{0}'?", GridView11.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE dc_details SET remarks = '{1}' WHERE ID = '{0}';", GridView11.GetFocusedRowCellValue("ID"), GridView11.GetFocusedRowCellValue("Remarks")))
                    Logs("PDC Management", "Remarks", String.Format("UPDATE remarks of {2} for Check Number {3} from {1} to {0}", GridView11.GetFocusedRowCellValue("Remarks"), Old_Remarks, cbxPayeeV5.Text, GridView11.GetFocusedRowCellValue("Check No")), "", "", "", "")
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                btnJournalVoucher.PerformClick()
            End If
        End If
    End Sub

    Private Sub LoadLoansPayableChecks()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ROW_NUMBER() OVER() AS 'No', Bank, Branch, CheckNumber AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', Amount, Remarks, Check_Status AS 'Status' FROM dc_details WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY IF(Check_Status = 'ON HAND',1,Check_Status), CheckDate, CheckNumber;", txtDocumentNumberV5.Text))
        GridControl6.DataSource = DT
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            dtpDocumentV2.Value = Date.Now
            txtDocumentNumberV2.Text = ""
            cbxBankV2.SelectedIndex = -1
            dtpReceivedDateV2.Value = Date.Now
            txtReferenceNumberV2.Text = ""
            dPrincipalV2.Value = 0
            iTerms_CV2.Value = 0
            dInterest_TV2.Value = 0
            dUDI_CV2.Value = 0

            GridControl5.DataSource = Nothing
        Else
            If drv("Multiple") Then
                DueTo_Payable = DataObject(String.Format("SELECT SUM(Amount - Paid) FROM due_to WHERE DC_ID = {0};", drv("ID")))
            Else
                DueTo_Payable = DataObject(String.Format("SELECT Amount - Paid FROM due_to WHERE DocumentNumber = '{0}';", drv("DocumentNumber")))
            End If
            If DueTo_Payable > 0 Then
                GridControl5.Enabled = True
            Else
                MsgBox("Due To is already Fully Paid.", MsgBoxStyle.Information, "Info")
                GridControl5.Enabled = False
            End If

            dtpDocumentV2.Value = drv("DocumentDate")
            txtDocumentNumberV2.Text = drv("DocumentNumber")
            cbxBankV2.SelectedValue = drv("BankID")
            dtpReceivedDateV2.Value = drv("ReceivedDate")
            txtReferenceNumberV2.Text = drv("ReferenceNumber")
            dPrincipalV2.Value = drv("Principal")
            iTerms_CV2.Value = drv("Terms")
            dInterest_TV2.Value = drv("InterestRate")
            dUDI_CV2.Value = drv("UDI")

            LoadDueToChecks()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnJournalVoucher_Click(sender As Object, e As EventArgs) Handles btnJournalVoucher.Click
        If SuperTabControl1.SelectedTabIndex = 3 Then
            Try
                If GridView5.GetFocusedRowCellValue("Check No").ToString = "" Then
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "CLEARED" Then
                    MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "REPLACED" Then
                    MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim JV As New FrmJournalVoucher
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
                Logs("Check Management", "Journal Voucher", "Journal Voucher", "", "", "", "")

                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                If dPrincipalV2.Value <= CDbl(GridView5.GetFocusedRowCellValue("Amount")) Then
                    .DTPayPrincipal = True
                    If drv("ForRollOver") = 1 Then
                        MsgBox("This is for Roll Over, please register new set of PDC.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If

                .From_Check = True
                .DueToID_M = cbxPayee.SelectedValue
                .MultipleDT = drv("Multiple")
                'If .MultipleDT Then
                '    Dim Docs As String = ""
                '    Dim DF_List As New DataTable
                '    DF_List = DataSource(String.Format("SELECT DocumentNumber FROM due_to WHERE DC_ID = {0} AND `status` = 'ACTIVE';", drv("ID")))
                '    For x As Integer = 0 To DF_List.Rows.Count - 1
                '        Docs &= "'" & DF_List(x)("DocumentNumber") & "'"
                '        If x < DF_List.Rows.Count - 1 Then
                '            Docs &= ", "
                '        End If
                '    Next
                '    .DueToID_M = Docs
                'End If

                .CheckID = GridView5.GetFocusedRowCellValue("ID")
                .BankID = cbxBankV2.SelectedValue
                .CheckAmount = GridView5.GetFocusedRowCellValue("Amount")
                .DueToDocumentNumber = txtDocumentNumberV2.Text

                .rExplanation.Text = cbxPayee.Text & " " & txtDocumentNumberV2.Text
                .cbxPayee.Tag = cbxPayee.Text
                If .ShowDialog = DialogResult.OK Then
                    LoadDueToChecks()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            Try
                If GridView11.GetFocusedRowCellValue("Check No").ToString = "" Then
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "CLEARED" Then
                    MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "REPLACED" Then
                    MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim JV As New FrmJournalVoucher
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
                Logs("Check Management", "Journal Voucher", "Journal Voucher", "", "", "", "")

                .From_Check = True
                If dPrincipalV5.Value <= CDbl(GridView11.GetFocusedRowCellValue("Amount")) Then
                    .DTPayPrincipal = True
                    Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                    If drv("ForRollOver") = 1 Then
                        MsgBox("This is for Roll Over, please register new set of PDC.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                .CheckID = GridView11.GetFocusedRowCellValue("ID")
                .BankID = cbxBankV5.SelectedValue
                .CheckAmount = GridView11.GetFocusedRowCellValue("Amount")
                .DueToDocumentNumber = txtDocumentNumberV5.Text
                .rExplanation.Text = cbxPayeeV5.Text & " " & txtDocumentNumberV5.Text
                .cbxPayee.Tag = cbxPayeeV5.Text
                If .ShowDialog = DialogResult.OK Then
                    LoadLoansPayableChecks()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            Try
                If GridView7.GetFocusedRowCellValue("Check No").ToString = "" Then
                    Exit Sub
                ElseIf GridView7.GetFocusedRowCellValue("Status") = "CLEARED" Then
                    MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView7.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView7.GetFocusedRowCellValue("Status") = "REPLACED" Then
                    MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
            If drv("DueStatus") = "PENDING" Then
                MsgBox(String.Format("{0} is still for Verification.", cbxPayorOthers.Text), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim JV As New FrmJournalVoucher
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
                Logs("Check Management", "Journal Voucher", "Journal Voucher", "", "", "", "")

                .From_Check = True
                .CheckID = GridView7.GetFocusedRowCellValue("ID")
                .BankID = cbxBankV3.SelectedValue
                .CheckAmount = GridView7.GetFocusedRowCellValue("Amount")
                .DueToDocumentNumber = txtDocumentNumberV3.Text
                .rExplanation.Text = cbxPayorOthers.Text & " " & txtDocumentNumberV3.Text
                .cbxPayee.Tag = cbxPayorOthers.Text
                If .ShowDialog = DialogResult.OK Then
                    LoadLoansPayableChecks()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
            Try
                If GridView9.GetFocusedRowCellValue("ID").ToString = "" Then
                    Exit Sub
                ElseIf GridView9.GetFocusedRowCellValue("Status") = "CLEARED" Or GridView9.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox(String.Format("Check is already {0}.", GridView9.GetFocusedRowCellValue("Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim JV As New FrmJournalVoucher
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
                Logs("Check Management", "Journal Voucher", "Journal Voucher", "", "", "", "")

                .From_Check = True
                .CheckAmount = GridView9.GetFocusedRowCellValue("Amount")
                Dim Rows As New ArrayList()
                Dim selectedRowHandles As Integer() = GridView9.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    Dim Docs As String = ""
                    Dim Payee As String = ""
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            Rows.Add(GridView9.GetDataRow(selectedRowHandle))
                        End If
                    Next
                    For x As Integer = 0 To selectedRowHandles.Length - 1
                        If Rows(x)("Status") = "CLEARED" Or Rows(x)("Status") = "RETURNED" Then
                            MsgBox(String.Format("Selected check have a {0} status.", Rows(x)("Status")), MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If

                        Docs &= Rows(x)("DC ID")
                        If x < selectedRowHandles.Length - 1 Then
                            Docs &= ", "
                        End If
                    Next
                    .DueToID_M = Docs
                    .MultipleDT = True
                End If
                If .ShowDialog = DialogResult.OK Then
                    btnSearch.PerformClick()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnCheckVoucher.Click
        If SuperTabControl1.SelectedTabIndex = 3 Then
            Try
                If GridView5.GetFocusedRowCellValue("Check No").ToString = "" Then
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "CLEARED" Then
                    MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView5.GetFocusedRowCellValue("Status") = "REPLACED" Then
                    MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim CV As New FrmCheckVoucher
            With CV
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
                Logs("Check Management", "Check Voucher", "Check Voucher", "", "", "", "")

                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                .From_Check = True
                .FromDueTo = True
                .AccountsPayableID_M = cbxPayee.SelectedValue
                .MultipleAP = drv("Multiple")
                If .MultipleAP Then
                    Dim Docs As String = ""
                    Dim DF_List As New DataTable
                    DF_List = DataSource(String.Format("SELECT DocumentNumber FROM due_to WHERE DC_ID = {0} AND `status` = 'ACTIVE';", drv("ID")))
                    For x As Integer = 0 To DF_List.Rows.Count - 1
                        Docs &= "'" & DF_List(x)("DocumentNumber") & "'"
                        If x < DF_List.Rows.Count - 1 Then
                            Docs &= ", "
                        End If
                    Next
                    .AccountsPayableID_M = Docs
                End If
                .AccountNumber = .AccountsPayableID_M

                .CheckID = GridView5.GetFocusedRowCellValue("ID")
                .DefaultBank = cbxBankV2.SelectedValue
                .CheckAmount = GridView5.GetFocusedRowCellValue("Amount")
                .DueToDocumentNumber = txtDocumentNumberV2.Text
                .rExplanation.Text = cbxPayee.Text & " " & txtDocumentNumberV2.Text
                .cbxPayee.Tag = cbxPayee.Text
                If .ShowDialog = DialogResult.OK Then
                    LoadDueToChecks()
                End If
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            Try
                If GridView11.GetFocusedRowCellValue("Check No").ToString = "" Then
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "CLEARED" Then
                    MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "RETURNED" Then
                    MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView11.GetFocusedRowCellValue("Status") = "REPLACED" Then
                    MsgBox("Check is already REPLACED.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try

            Dim CV As New FrmCheckVoucher
            With CV
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
                Logs("Check Management", "Check Voucher", "Check Voucher", "", "", "", "")

                .From_Check = True
                .CheckID = GridView11.GetFocusedRowCellValue("ID")
                .DefaultBank = cbxBankV5.SelectedValue
                .CheckAmount = GridView11.GetFocusedRowCellValue("Amount")
                .DueToDocumentNumber = txtDocumentNumberV5.Text
                .rExplanation.Text = cbxPayee.Text & " " & txtDocumentNumberV5.Text
                .cbxPayee.Tag = cbxPayeeV5.Text
                If .ShowDialog = DialogResult.OK Then
                    LoadLoansPayableChecks()
                End If
            End With
        End If
    End Sub

    Private Sub BtnCheckRegistry_Click(sender As Object, e As EventArgs) Handles btnCheckRegistry.Click
        Dim PDC As New FrmDueCheckRegistry
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint

            .txtRemarks.Visible = True
            .LabelX2.Visible = True

            .LabelX3.Visible = False
            .dPrincipal.Visible = False
            .LabelX81.Visible = False
            .iTerms_C.Visible = False
            .LabelX82.Visible = False
            .dInterest_T.Visible = False
            .lblInterest.Visible = False
            .LabelX89.Visible = False
            .dUDI_C.Visible = False
            .btnDelete.Enabled = False
            .From_PDC_Others = True
            .btnVerify.Visible = True
            If .ShowDialog = DialogResult.OK Then
                LoadOthers()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView7_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView7.RowCellStyle
        If GridView7.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView7RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM (SELECT ID, "
        SQL &= "    AssetNumber AS 'Reference Number',"
        SQL &= "    IF(AssetNumber LIKE 'AN%','ROPA','Credit Application') AS 'From',"
        SQL &= "    IF(AssetNumber LIKE 'ANV%',(SELECT PlateNum FROM ropoa_vehicle R WHERE R.AssetNumber = check_received.AssetNumber ORDER BY ID LIMIT 1),IF(AssetNumber LIKE 'ANR%', (SELECT TCT FROM ropoa_realestate R WHERE R.AssetNumber = check_received.AssetNumber ORDER BY ID LIMIT 1), (SELECT Product FROM credit_application C WHERE C.CreditNumber = check_received.AssetNumber ORDER BY ID LIMIT 1))) AS 'Details',"
        SQL &= "    Buyer AS 'Payee/Payor',"
        SQL &= "    Bank,"
        SQL &= "    Branch,"
        SQL &= "    `Check` AS 'Check No',"
        SQL &= "    DATE_FORMAT(`Date`,'%M %d, %Y') AS 'Date',"
        SQL &= "    `Date` AS 'CheckDate',"
        SQL &= "    Amount,"
        SQL &= "    Amount AS 'Amount_2',"
        SQL &= "    Remarks, `Status`, 0 AS 'DC ID'"
        SQL &= " FROM check_received"
        SQL &= String.Format("  WHERE `status` = 'ACTIVE' AND Checked = 0 AND `Date` <= DATE(NOW()) AND check_type = 'R' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))

        SQL &= " UNION ALL "
        SQL &= " SELECT IF(due_check.DocumentNumber LIKE 'DF%',(SELECT ID FROM due_from WHERE due_from.DocumentNumber = due_check.DocumentNumber),due_check.ID) AS 'ID', "
        SQL &= "    due_check.DocumentNumber AS 'Reference Number',"
        SQL &= "    IF(due_check.DocumentNumber LIKE 'DF%','Due From',IF(due_check.DocumentNumber LIKE 'DT%','Due To','Loans Payable')) AS 'From',"
        SQL &= "    '' AS 'Details',"
        SQL &= "    Payor AS 'Payee/Payor',"
        SQL &= "    dc_details.Bank,"
        SQL &= "    dc_details.Branch,"
        SQL &= "    dc_details.CheckNumber AS 'Check No',"
        SQL &= "    DATE_FORMAT(dc_details.CheckDate,'%M %d, %Y') AS 'Date',"
        SQL &= "    `CheckDate` AS 'CheckDate',"
        SQL &= "    dc_details.Amount AS 'Amount',"
        SQL &= "    dc_details.Amount AS 'Amount_2',"
        SQL &= "    dc_details.Remarks, Check_Status AS 'Status', dc_details.ID AS 'DC ID'"
        SQL &= " FROM due_check INNER JOIN dc_details ON due_check.DocumentNumber = dc_details.DocumentNumber AND dc_details.Status = 'ACTIVE' AND dc_details.Check_Status = 'ON HAND'"
        SQL &= String.Format("  WHERE due_check.`status` = 'ACTIVE' AND dc_details.CheckDate <= DATE(NOW()) AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))

        SQL &= " UNION ALL "
        SQL &= " SELECT PDC_Others.ID, "
        SQL &= "    PDC_Others.DocumentNumber AS 'Reference Number',"
        SQL &= "    'Others' AS 'From',"
        SQL &= "    '' AS 'Details',"
        SQL &= "    Payor AS 'Payee/Payor',"
        SQL &= "    dc_details.Bank,"
        SQL &= "    dc_details.Branch,"
        SQL &= "    dc_details.CheckNumber AS 'Check No',"
        SQL &= "    DATE_FORMAT(dc_details.CheckDate,'%M %d, %Y') AS 'Date',"
        SQL &= "    `CheckDate` AS 'CheckDate',"
        SQL &= "    dc_details.Amount AS 'Amount',"
        SQL &= "    dc_details.Amount AS 'Amount_2',"
        SQL &= "    dc_details.Remarks, Check_Status AS 'Status', 0 AS 'DC ID'"
        SQL &= " FROM pdc_others INNER JOIN dc_details ON PDC_Others.DocumentNumber = dc_details.DocumentNumber AND dc_details.Status = 'ACTIVE' AND dc_details.Check_Status = 'ON HAND'"
        SQL &= String.Format("  WHERE pdc_others.`status` = 'ACTIVE' AND dc_details.CheckDate <= DATE(NOW()) AND Branch_ID IN ({0}) ORDER BY `Date` DESC) A WHERE TRUE", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If txtKeyword.Text.Trim = "" Then
        Else
            If KeywordSearchWildcard Then
                Dim Words As String() = txtKeyword.Text.Trim.Split(New Char() {" "c})
                Dim Key As String
                For Each Key In Words
                    SQL &= String.Format(" AND (`From` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Payee/Payor` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Bank` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Check No` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Date` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Amount` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Amount_2` = '{0}' OR", Key.InsertQuote)
                    SQL &= String.Format(" `CheckDate` LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" DATE_FORMAT(`CheckDate`,'%M %d, %Y') LIKE '%{0}%' OR", Key.InsertQuote)
                    SQL &= String.Format(" `Status` LIKE '%{0}%')", Key.InsertQuote)
                Next
            Else
                Dim Key As String = txtKeyword.Text
                SQL &= String.Format(" AND (`From` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Payee/Payor` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Bank` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Check No` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Date` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Amount` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Amount_2` = '{0}' OR", Key.InsertQuote)
                SQL &= String.Format(" `CheckDate` LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" DATE_FORMAT(`CheckDate`,'%M %d, %Y') LIKE '%{0}%' OR", Key.InsertQuote)
                SQL &= String.Format(" `Status` LIKE '%{0}%')", Key.InsertQuote)
            End If
        End If
        SQL &= " ORDER BY IF(`Status` IN ('ON HAND','ACTIVE'),1,`Status`), `Date`, `Check No`"

        GridControl9.DataSource = DataSource(SQL)
        If GridView9.RowCount > 19 Then
            GridColumn58.Width = 331 - 17
        Else
            GridColumn58.Width = 331
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub GridView9_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView9.RowCellStyle
        If GridView9.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PDC_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            e.Appearance.ForeColor = Color.Black
            If PDC_Status = "" Then
            Else
                Try
                    If PDC_Status = "CLEARED" Or PDC_Status = "PAID" Then
                        e.Appearance.BackColor = Color.LightGreen
                    ElseIf PDC_Status = "BOUNCED" Or PDC_Status = "RETURNED" Then
                        e.Appearance.BackColor = Color.LightCoral
                    End If
                Catch ex As Exception
                    TriggerBugReport("PDC Management - GridView9RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub CbxPayeeV5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayeeV5.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxPayeeV5.SelectedItem, DataRowView)
        If cbxPayeeV5.SelectedIndex = -1 Or cbxPayeeV5.Text = "" Then
            dtpDocumentV5.Value = Date.Now
            txtDocumentNumberV5.Text = ""
            cbxBankV5.SelectedIndex = -1
            dtpReceivedDateV5.Value = Date.Now
            txtReferenceNumberV5.Text = ""
            dPrincipalV5.Value = 0
            iTerms_CV5.Value = 0
            dInterest_TV5.Value = 0
            dUDI_CV5.Value = 0

            GridControl6.DataSource = Nothing
        Else
            dtpDocumentV5.Value = drv("DocumentDate")
            txtDocumentNumberV5.Text = drv("DocumentNumber")
            cbxBankV5.SelectedValue = drv("BankID")
            dtpReceivedDateV5.Value = drv("ReceivedDate")
            txtReferenceNumberV5.Text = drv("ReferenceNumber")
            dPrincipalV5.Value = drv("Principal")
            iTerms_CV5.Value = drv("Terms")
            dInterest_TV5.Value = drv("InterestRate")
            dUDI_CV5.Value = drv("UDI")

            LoadLoansPayableChecks()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPDC_Click(sender As Object, e As EventArgs) Handles btnPDC.Click
        Dim PDC As New FrmPDCReceipt
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .CreditNumber = cbxApplication.SelectedValue
            If .ShowDialog = DialogResult.OK Then
                CbxApplication_SelectedIndexChanged(sender, e)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            txtBorrower.Text = ""
            txtContactN_2.Text = ""
            btnPDC.Enabled = False
            GridControl3.DataSource = Nothing
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Try
                    If GridView3.GetFocusedRowCellValue("Check No").ToString = "" Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                If MsgBoxYes(String.Format("Are you sure you want to remove this Check {0}?", GridView3.GetFocusedRowCellValue("Check No"))) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE check_received SET `status` = 'REMOVED' WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxApplication.SelectedValue, GridView3.GetFocusedRowCellValue("Check No"), GridView3.GetFocusedRowCellValue("ID")))
                    Logs("PDC Management", "Remove", String.Format("REMOVED {1} check for {0}", GridView3.GetFocusedRowCellValue("Check No"), cbxApplication.SelectedValue), "", "", "", cbxApplication.SelectedValue)

                    LoadData()
                    MsgBox("Check Removed!", MsgBoxStyle.Information, "Info")
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("PDC Management - Remove", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnImportPDC_Click(sender As Object, e As EventArgs) Handles btnImportPDC.Click
        Dim PDC As New FrmImportPDC
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            If .ShowDialog = DialogResult.OK Then
                CbxApplication_SelectedIndexChanged(sender, e)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView9_DoubleClick(sender As Object, e As EventArgs) Handles GridView9.DoubleClick
        If GridView9.GetFocusedRowCellValue("From") = "Credit Application" Then
            SuperTabControl1.SelectedTabIndex = 0
            cbxApplication.SelectedValue = GridView9.GetFocusedRowCellValue("Reference Number")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView3.OptionsSelection.MultiSelect = False
            GridView3.FocusedRowHandle = i
        ElseIf GridView9.GetFocusedRowCellValue("From") = "Due From" Then
            SuperTabControl1.SelectedTabIndex = 2
            cbxPayor.SelectedValue = GridView9.GetFocusedRowCellValue("ID")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView2.OptionsSelection.MultiSelect = False
            GridView2.FocusedRowHandle = i
        ElseIf GridView9.GetFocusedRowCellValue("From") = "Due To" Then
            SuperTabControl1.SelectedTabIndex = 3
            cbxPayee.SelectedValue = GridView9.GetFocusedRowCellValue("ID")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView5.RowCount - 1
                If GridView5.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView5.OptionsSelection.MultiSelect = False
            GridView5.FocusedRowHandle = i
        ElseIf GridView9.GetFocusedRowCellValue("From") = "Loans Payable" Then
            SuperTabControl1.SelectedTabIndex = 4
            cbxPayeeV5.SelectedValue = GridView9.GetFocusedRowCellValue("ID")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView11.RowCount - 1
                If GridView11.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView11.OptionsSelection.MultiSelect = False
            GridView11.FocusedRowHandle = i
        ElseIf GridView9.GetFocusedRowCellValue("From") = "Others" Then
            SuperTabControl1.SelectedTabIndex = 5
            cbxPayorOthers.SelectedValue = GridView9.GetFocusedRowCellValue("ID")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView7.RowCount - 1
                If GridView7.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView7.OptionsSelection.MultiSelect = False
            GridView7.FocusedRowHandle = i
        Else
            SuperTabControl1.SelectedTabIndex = 1
            cbxAssetNumber.Text = GridView9.GetFocusedRowCellValue("Reference Number") & " - " & GridView9.GetFocusedRowCellValue("Details")
            Dim i As Integer = 0
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Check No") = GridView9.GetFocusedRowCellValue("Check No") Then
                    i = x
                    Exit For
                End If
            Next
            GridView1.OptionsSelection.MultiSelect = False
            GridView1.FocusedRowHandle = i
        End If
    End Sub

    Private Sub GridView9_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView9.SelectionChanged
        Try
            Dim Rows As New ArrayList()
            Dim selectedRowHandles As Integer() = GridView9.GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim I As Integer
                Dim Docs As String = ""
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(I)
                    If (selectedRowHandle >= 0) Then
                        Rows.Add(GridView9.GetDataRow(selectedRowHandle))
                    End If
                Next
                btnJournalVoucher.Enabled = True
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    If GridView9.GetFocusedRowCellValue("From") = "Due To" Then
                    Else
                        btnJournalVoucher.Enabled = False
                    End If
                Next
            Else
                If GridView9.GetFocusedRowCellValue("From") = "Due To" Then
                    btnJournalVoucher.Enabled = True
                Else
                    btnJournalVoucher.Enabled = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnRenewal_Click(sender As Object, e As EventArgs) Handles btnRenewal.Click
        If cbxPayorOthers.SelectedIndex = -1 Then
            MsgBox("Please select an account for renewal", MsgBoxStyle.Information, "Info")
            cbxPayorOthers.DroppedDown = True
            Exit Sub
        End If

        Dim PDC As New FrmDueCheckRegistry
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint

            .txtRemarks.Visible = True
            .LabelX2.Visible = True

            .LabelX3.Visible = False
            .dPrincipal.Visible = False
            .LabelX81.Visible = False
            .iTerms_C.Visible = False
            .LabelX82.Visible = False
            .dInterest_T.Visible = False
            .lblInterest.Visible = False
            .LabelX89.Visible = False
            .dUDI_C.Visible = False
            .btnDelete.Enabled = False
            .From_PDC_Others = True
            .Renewal = True

            .cbxPayor.Enabled = False
            .cbxPayor.Tag = cbxPayorOthers.Text
            .dtpDocument.Tag = dtpDocumentV3.Value
            .txtDocumentNumber.Tag = txtDocumentNumberV3.Text
            If .ShowDialog = DialogResult.OK Then
                LoadOthers()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnReturnedNotice_Click(sender As Object, e As EventArgs) Handles btnReturnedNotice.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If vPrint Then
            Else
                MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv_B As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            Dim xPath As String = Application.StartupPath & "\Documents\Return Check Notice.doc"
            If drv_B("branch_code").ToString.Contains("-MF") Then
                xPath = Application.StartupPath & "\Documents\Microfinance\Return Check Notice.docx"
            Else
                xPath = Application.StartupPath & "\Documents\Return Check Notice.doc"
            End If
            xPath = Application.StartupPath & "\Documents\Microfinance\Return Check Notice.docx"
            Dim PathName As String = IO.Path.GetFileName(xPath)
            Dim File_Directory As String = String.Format("{0}\{1}\{2}\Documents\{3}", RootFolder, MainFolder, Branch_Code, "Return Check Notice")
            If Not IO.Directory.Exists(File_Directory) Then
                IO.Directory.CreateDirectory(File_Directory)
            End If
            Dim FileName As String = String.Format("{0}\{1}", File_Directory, PathName)
            For x As Integer = 2 To 1000
                If IO.File.Exists(FileName) Then
                    FileName = String.Format("{0}\Return Check Notice of {1} with Check Number {3} ({2}).doc", File_Directory, cbxApplication.Text, x, GridView3.GetFocusedRowCellValue("Check No"))
                End If
            Next
            IO.File.Copy(xPath, FileName)

            Dim WordApp As New word.Application With {
                .Visible = False
            }
            Dim Doc As word.Document = WordApp.Documents.Open(FileName)
            Doc = WordApp.ActiveDocument
            With Doc
                'REPLACE
                .Content.Find.Execute(FindText:="@Date", ReplaceWith:=Format(Date.Now, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithPrefixName", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("Name")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithPrefixLastName", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("Last Name")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithoutCityAddress", ReplaceWith:=DT_Borrower(0)("Address"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@City", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("City")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Amount", ReplaceWith:=FormatNumber(CDbl(GridView3.GetFocusedRowCellValue("Amount")), 2), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Reason", ReplaceWith:=If(GridView3.GetFocusedRowCellValue("Document Number") = "", "", DataObject(String.Format("SELECT Bounce FROM journal_voucher WHERE DocumentNumber = (SELECT JVNumber FROM official_receipt WHERE DocumentNumber = '{0}')", GridView3.GetFocusedRowCellValue("Document Number")))), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@AccountNum", ReplaceWith:=drv_B("AccountNumber"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@BAccountNum", ReplaceWith:=GridView3.GetFocusedRowCellValue("Account Number"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Bank", ReplaceWith:=GridView3.GetFocusedRowCellValue("Bank"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@BBranch", ReplaceWith:=GridView3.GetFocusedRowCellValue("Branch"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@CheckN", ReplaceWith:=GridView3.GetFocusedRowCellValue("Check No"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@CheckDate", ReplaceWith:=Format(CDate(GridView3.GetFocusedRowCellValue("Date")), "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Returned", ReplaceWith:=If(GridView3.GetFocusedRowCellValue("Document Number") = "", "", DataObject(String.Format("SELECT DATE_FORMAT(DocumentDate, '%M %d, %Y') FROM journal_voucher WHERE DocumentNumber = (SELECT JVNumber FROM official_receipt WHERE DocumentNumber = '{0}')", GridView3.GetFocusedRowCellValue("Document Number")))), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Balance", ReplaceWith:="", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@StatementDate", ReplaceWith:="", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@User", ReplaceWith:=UpperCaseFirst(Empl_Name), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Position", ReplaceWith:=UpperCaseFirst(Empl_Position), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Branch", ReplaceWith:=UpperCaseFirst(Branch), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Save()
                .Close()
            End With
            Doc = Nothing

            WordApp.Quit()
            WordApp = Nothing
            Try
                Process.Start(FileName)
            Catch ex As Exception
                Try
                    Process.Start(FileName.Replace("\", "/"))
                Catch ex1 As Exception
                    Process.Start(FileName.Replace("/", "\"))
                End Try
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub IOR_Click(sender As Object, e As EventArgs) Handles iOR.Click
        Try
            If GridView3.GetFocusedRowCellValue("Check No") = "" Then
                Exit Sub
            ElseIf GridView3.GetFocusedRowCellValue("Status") = "CLEARED" Then
                MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView3.GetFocusedRowCellValue("Status") = "RETURNED" Then
                MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If CDate(GridView3.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
        Else
            MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim Official As New FrmOfficialReceipt
        With Official
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .Tag = 99
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
            .CreditNumber = cbxApplication.SelectedValue
            .cbxCash.Enabled = False
            .cbxCheck.Enabled = False
            .cbxOnline.Enabled = False
            .cbxCheck.Checked = True
            .cbxCheckNumber.Text = GridView3.GetFocusedRowCellValue("Check No")
            .dtpCheck.Value = GridView3.GetFocusedRowCellValue("Date")
            .CheckID = GridView3.GetFocusedRowCellValue("ID")
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxPayee.Enabled = False
            .cbxCheckNumber.Enabled = False
            .dtpCheck.Enabled = False
            .dtpDeposit.Enabled = False
            .dPaidAmount.Enabled = False
            .dPaidAmount.Value = GridView3.GetFocusedRowCellValue("Amount")
            .btnBatchPayment.Enabled = False
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub IACR_Click(sender As Object, e As EventArgs) Handles iACR.Click
        Try
            If GridView3.GetFocusedRowCellValue("Check No") = "" Then
                Exit Sub
            ElseIf GridView3.GetFocusedRowCellValue("Status") = "CLEARED" Then
                MsgBox("Check is already CLEARED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView3.GetFocusedRowCellValue("Status") = "RETURNED" Then
                MsgBox("Check is already RETURNED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If CDate(GridView3.GetFocusedRowCellValue("Date")).AddDays(-3) <= Date.Now Then
        Else
            MsgBox("Check Date have not yet reach its due date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim ACR As New FrmAcknowledgement
        With ACR
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .Tag = 99
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
            .AssetNumber = cbxApplication.SelectedValue
            .cbxCash.Enabled = False
            .cbxCheck.Enabled = False
            .cbxOnline.Enabled = False
            .cbxCheck.Checked = True
            .cbxCheckNumber.Text = GridView3.GetFocusedRowCellValue("Check No")
            .dtpDeposit.Value = GridView3.GetFocusedRowCellValue("Date")
            .CheckID = GridView3.GetFocusedRowCellValue("ID")
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxPayee.Enabled = False
            .cbxCheckNumber.Enabled = False
            .dtpCheck.Enabled = False
            .dtpDeposit.Enabled = False
            .cbxLOE.Enabled = False
            .cbxAR.Enabled = False
            .cbxDF.Enabled = False
            .cbxITL.Enabled = False
            .cbxRO.Enabled = False
            .cbxLOE.Checked = False
            .cbxAR.Checked = False
            .cbxDF.Checked = False
            .cbxITL.Checked = False
            .cbxRO.Checked = False
            .cbxLA.Enabled = False
            .cbxLA.Checked = True
            .cbxCAS.Enabled = False
            .cbxCAS.Checked = False
            .dPaidAmount.Enabled = False
            .dPaidAmount.Value = GridView3.GetFocusedRowCellValue("Amount")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If cbxPayorOthers.SelectedIndex = -1 Then
            MsgBox("Please select an account to modify", MsgBoxStyle.Information, "Info")
            cbxPayorOthers.DroppedDown = True
            Exit Sub
        End If

        Dim PDC As New FrmDueCheckRegistry
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            Dim drv As DataRowView = DirectCast(cbxPayorOthers.SelectedItem, DataRowView)
            .cbxPayor.Tag = cbxPayorOthers.Text
            .dtpDocument.Tag = dtpDocumentV3.Value
            .txtDocumentNumber.Tag = txtDocumentNumberV3.Text
            .cbxBank.Tag = cbxBankV3.SelectedValue
            .dtpReceivedDate.Tag = dtpReceivedDateV3.Value
            .txtReferenceNumber.Tag = txtReferenceNumberV3.Text
            .txtRemarks.Text = drv("Remarks")
            .cbxPayor.Enabled = False
            .From_PDC_Others = True
            .ModifyOthers = True

            .txtRemarks.Visible = True
            .LabelX2.Visible = True
            .btnDelete.Enabled = True
            .btnSave.Enabled = False

            .btnVerify.Visible = True
            If drv("DueStatus") = "PENDING" Then
                .btnVerify.Enabled = True
                .txtRemarks.Enabled = True
                .btnAddC.Enabled = True
                .btnRemoveC.Enabled = True
                .dtpReceivedDate.Enabled = True
                .txtReferenceNumber.Enabled = True
            Else
                .btnVerify.Enabled = False
                .txtRemarks.Enabled = False
                .btnAddC.Enabled = False
                .btnRemoveC.Enabled = False
                .btnRefresh.Enabled = False
                .dtpReceivedDate.Enabled = False
                .txtReferenceNumber.Enabled = False
            End If
            If .ShowDialog = DialogResult.OK Then
                LoadOthers()
            End If
            .Dispose()
        End With
    End Sub
End Class