Imports DevExpress.XtraReports.UI
Public Class FrmCollectionCashCount

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim User_EmplID As Integer
    Dim Code As String

    Dim Code_Check As String
    Dim Code_Approve As String
    Dim DT_Cash As DataTable
    Dim DT_Check As DataTable
    Private Sub FrmCollectionCashCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        dtpDocument.Value = Date.Now
        dtpORLastIssued.Value = Date.Now
        dtpORDeposited.Value = Date.Now

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxORLastIssued
            .DisplayMember = "DocumentNumber"
            .ValueMember = "DocumentNumber"
        End With

        With cbxORDeposited
            .DisplayMember = "DocumentNumber"
            .ValueMember = "DocumentNumber"
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'Approved' UNION SELECT 'Cancelled'")
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

        LoadCash("")
        LoadCheckOnline("")
        LoadPassBook("")
        LoadATM("")
        LoadData()

        GetDocumentNumber()
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX25, LabelX26, LabelX18, LabelX2, LabelX3, LabelX4, LabelX5, LabelX6, LabelX14, LabelX12, LabelX10, LabelX9, LabelX8, LabelX7, LabelX32, LabelX21, LabelX43, LabelX33, LabelX19, LabelX29, LabelX24, LabelX22, LabelX34, LabelX23, LabelX20, LabelX35, LabelX17, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelWithBackgroundFontSettings({LabelX15, LabelX1, LabelX28, LabelX13, LabelX16, LabelX38, LabelX36, LabelX31, LabelX27, LabelX30, LabelX37, LabelX17})

            GetTextBoxFontSettings({txtDocumentNumber, txtChecked, txtApproved})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxDisplay, cbxORLastIssued, cbxORDeposited, cbxPreparedBy})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpDocument, dtpORLastIssued, dtpORDeposited})

            GetDoubleInputFontSettings({d1000, d500, d200, d100, d50, d20, d10, d5, d1, d025, d010, d005, dTotalCash, dTotalChecks, dTotalCollection, dShortOver})

            GetIntegerInputFontSettings({i1000, i500, i200, i100, i50, i20, i10, i5, i1, i025, i010, i005, i001})

            GetRickTextBoxFontSettings({rExplanation})

            GetContextMenuBarFontSettings({ContextMenuBar1, ContextMenuBar3})

            GetButtonFontSettings({btnSearch, btnCheckPassbook, btnCheckATM, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnPrint, btnReceive})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Collection Cash Count - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Collection Cash Count", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    TotalCash AS 'Total Cash',"
        SQL &= "    TotalCheck AS 'Total Checks',"
        SQL &= "    TotalCheck + TotalCash AS 'Total Collection',"
        SQL &= "    i1000,"
        SQL &= "    i500,"
        SQL &= "    i200,"
        SQL &= "    i100,"
        SQL &= "    i50,"
        SQL &= "    i20,"
        SQL &= "    i10,"
        SQL &= "    i5,"
        SQL &= "    i1,"
        SQL &= "    i025,"
        SQL &= "    i010,"
        SQL &= "    i005,"
        SQL &= "    i001,"
        SQL &= "    LastORIssued AS 'Last Issued',"
        SQL &= "    LastORDeposited AS 'Last Deposited',"
        SQL &= "    LastORIssuedDate,"
        SQL &= "    LastORDepositedDate,"
        SQL &= "    PreparedID,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By',"
        SQL &= "    Employee(CheckedID) AS 'Checked By', OTAC_Check, OTAC_Approve, User_EmplID, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Voucher_Status = 'PENDING','FOR CHECKING',IF(Voucher_Status = 'CHECKED','FOR APPROVAL',Voucher_Status))) AS 'Voucher_Status', Remarks, "
        SQL &= "    CheckedID, ApprovedID, Employee(ApprovedID) AS 'Approved By', Attach, Branch(Branch_ID) AS 'Branch'"
        SQL &= " FROM collection_cashcount WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim Approved As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Approved" Then
                    Approved = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And Approved = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR voucher_status = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (voucher_status = 'DISAPPROVED' "
                If ForChecking Or ForApproval Or Approved Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If ForApproval Or Approved Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'CHECKED',TRUE)"
                    If Approved Then
                        SQL &= " OR "
                    End If
                End If
                If Approved Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'APPROVED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And Approved = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " voucher_status = 'PENDING'"
                    If ForApproval Or Approved Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " voucher_status = 'CHECKED'"
                    If Approved Then
                        SQL &= " OR "
                    End If
                End If
                If Approved Then
                    SQL &= " voucher_status = 'APPROVED'"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND Branch_ID = '{0}' ORDER BY DocumentNumber DESC ;", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn34.Visible = True
            GridColumn34.VisibleIndex = 9
        End If
        GridView1.Columns("Document Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Document Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 19 Then
            GridColumn28.Width = 405 - 17
        Else
            GridColumn28.Width = 405
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCash(DocumentNumber As String)
        Dim SQL As String
        If DocumentNumber = "" Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    Explanation,"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount', "
            SQL &= "    IF(DepositDate = '','ON HAND','DEPOSITED') AS 'Status' "
            SQL &= " FROM official_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND DepositDate = '' AND Type_Payment = 'Cash' AND Branch_ID = '{0}' AND DocumentDate <= '{1}'", Branch_ID, FormatDatePicker(dtpDocument))
            SQL &= " UNION ALL SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    Explanation,"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount', "
            SQL &= "    IF(DepositDate = '','ON HAND','DEPOSITED') AS 'Status' "
            SQL &= " FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND DepositDate = '' AND Type_Payment = 'Cash' AND Branch_ID = '{0}' AND DocumentDate <= '{1}';", Branch_ID, FormatDatePicker(dtpDocument))

            cbxORLastIssued.DataSource = DataSource(String.Format("SELECT DocumentNumber FROM official_receipt WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Branch_ID = '{0}';", Branch_ID))
            cbxORLastIssued.SelectedIndex = -1

            cbxORDeposited.DataSource = DataSource(String.Format("SELECT DocumentNumber FROM official_receipt WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND CollectionNumber = '' AND Branch_ID = '{0}' AND DepositDate != '';", Branch_ID))
            cbxORDeposited.SelectedIndex = -1
        Else
            SQL = String.Format("SELECT ID, DocumentDate AS 'Document Date', DocumentNumber AS 'Document Number', Explanation, Payor, Amount AS 'Amount',IF(IF(SUBSTRING(DocumentNumber,1,2) = 'OR',(SELECT DepositDate FROM official_receipt WHERE official_receipt.DocumentNumber = ccc_cash.DocumentNumber), (SELECT DepositDate FROM acknowledgement_receipt WHERE acknowledgement_receipt.DocumentNumber = ccc_cash.DocumentNumber)) = '','ON HAND','DEPOSITED') AS 'Status' FROM ccc_cash WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", DocumentNumber)

            cbxORLastIssued.DataSource = DataSource(String.Format("SELECT DocumentNumber FROM official_receipt WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND Branch_ID = '{0}';", Branch_ID))

            cbxORDeposited.DataSource = DataSource(String.Format("SELECT DocumentNumber FROM official_receipt WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND Branch_ID = '{0}' AND DepositDate != '';", Branch_ID))
        End If

        DT_Cash = DataSource(SQL)
        GridControl3.DataSource = DT_Cash

        Dim OnHand As Double
        For x As Integer = 0 To DT_Cash.Rows.Count - 1
            If DT_Cash(x)("Status") = "ON HAND" Then
                OnHand += CDbl(DT_Cash(x)("Amount"))
            End If
        Next
        dShortOver.Value = OnHand - dTotalCash.Value
        If GridView3.RowCount > 9 Then
            GridColumn19.Width = 448 - 17
        Else
            GridColumn19.Width = 448
        End If
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value.ToString.Replace("(", "").Replace(")", "")), 2)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GridView3_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView3.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value.ToString.Replace("(", "").Replace(")", "")), 2)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub LoadCheckOnline(DocumentNumber As String)
        Dim SQL As String
        If DocumentNumber = "" Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    CONCAT(IF(CheckNumber = '',CONCAT('[Deposit Number: ',DepositNumber, '] [Deposit Date: ', DATE_FORMAT(DepositDate, '%M %d, %Y'),']'),CONCAT('[Check Number: ',CheckNumber, '] [Check Date: ', DATE_FORMAT(CheckDate, '%M %d, %Y'),']')), ' ',Explanation) AS 'Explanation',"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount' "
            SQL &= " FROM official_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND IF(Type_Payment='CHECK',DepositDate='',CollectionNumber = '') AND Type_Payment != 'Cash' AND Branch_ID = '{0}' AND DocumentDate <= '{1}'", Branch_ID, FormatDatePicker(dtpDocument))
            SQL &= " UNION ALL SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    CONCAT(IF(CheckNumber = '',CONCAT('[Deposit Number: ',DepositNumber, '] [Deposit Date: ', DATE_FORMAT(DepositDate, '%M %d, %Y'),']'),CONCAT('[Check Number: ',CheckNumber, '] [Check Date: ', DATE_FORMAT(CheckDate, '%M %d, %Y'),']')), ' ',Explanation) AS 'Explanation',"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount AS 'Amount' "
            SQL &= " FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status = 'APPROVED' AND IF(Type_Payment='CHECK',DepositDate='',CollectionNumber = '') AND Type_Payment != 'Cash' AND Branch_ID = '{0}' AND DocumentDate <= '{1}';", Branch_ID, FormatDatePicker(dtpDocument))
        Else
            SQL = String.Format("SELECT ID, DocumentDate AS 'Document Date', DocumentNumber AS 'Document Number', Explanation, Payor, Amount AS 'Amount' FROM ccc_checks WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", DocumentNumber)
        End If
        DT_Check = DataSource(SQL)
        GridControl2.DataSource = DT_Check

        Dim TotalCheckOnline As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            TotalCheckOnline += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
        Next
        dTotalChecks.Value = TotalCheckOnline

        If GridView2.RowCount > 9 Then
            GridColumn17.Width = 481 - 17
        Else
            GridColumn17.Width = 481
        End If
    End Sub

    Private Sub LoadPassBook(DocumentNumber As String)
        Dim SQL As String
        If DocumentNumber = "" Then
            SQL = String.Format("SELECT 'False' AS 'On Hand', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Account Name', CONCAT((SELECT short_name FROM bank_setup WHERE ID = PD_BankID), ' - ',PD_AccountNumber) AS 'Bank - Account Number', IF(PD_ATM = 1,'True','False') AS 'With ATM', '' AS 'Remarks' FROM credit_application WHERE PD_AccountNumber <> '' AND Product LIKE '%SHOWMONEY%' AND PaymentRequest IN ('RELEASED') AND Branch_ID = '{0}';", Branch_ID)
        Else
            SQL = String.Format("SELECT IF(OnHand = 1,'True','False') AS 'On Hand', AccountName AS 'Account Name', BankAccountNumber AS 'Bank - Account Number', IF(WithATM = 1,'True','False') AS 'With ATM', Remarks FROM ccc_passbook WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", DocumentNumber)
        End If
        GridControl4.DataSource = DataSource(SQL)

        If GridView4.RowCount > 8 Then
            GridColumn26.Width = 99 - 17
        Else
            GridColumn26.Width = 99
        End If
    End Sub

    Private Sub LoadATM(DocumentNumber As String)
        Dim SQL As String
        If DocumentNumber = "" Then
            SQL = String.Format("SELECT 'False' AS 'On Hand', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Account Name', CONCAT((SELECT short_name FROM bank_setup WHERE ID = PD_BankID), ' - ',PD_AccountNumber) AS 'Bank - Account Number', '' AS 'Remarks' FROM credit_application WHERE PD_AccountNumber <> '' AND Product LIKE '%PAYDAY%' AND PaymentRequest IN ('RELEASED') AND Branch_ID = '{0}';", Branch_ID)
        Else
            SQL = String.Format("SELECT IF(OnHand = 1,'True','False') AS 'On Hand', AccountName AS 'Account Name', BankAccountNumber AS 'Bank - Account Number', Remarks FROM ccc_atm WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", DocumentNumber)
        End If
        GridControl5.DataSource = DataSource(SQL)

        If GridView5.RowCount > 8 Then
            GridColumn32.Width = 169 - 17
        Else
            GridColumn32.Width = 169
        End If
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
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnAttach.Visible = False
            If btnSave.Text = "&Save" And btnSave.Enabled Then
                btnPrint.Enabled = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnPrint.Enabled = True
            btnAttach.Visible = True
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        i1000.Enabled = True
        i500.Enabled = True
        i200.Enabled = True
        i100.Enabled = True
        i50.Enabled = True
        i20.Enabled = True
        i10.Enabled = True
        i5.Enabled = True
        i1.Enabled = True
        i025.Enabled = True
        i010.Enabled = True
        i005.Enabled = True
        i001.Enabled = True
        cbxORLastIssued.Enabled = True
        dtpORLastIssued.Enabled = True
        cbxORDeposited.Enabled = True
        dtpORDeposited.Enabled = True
        i1000.Value = 0
        i500.Value = 0
        i200.Value = 0
        i100.Value = 0
        i50.Value = 0
        i20.Value = 0
        i10.Value = 0
        i5.Value = 0
        i1.Value = 0
        i025.Value = 0
        i010.Value = 0
        i005.Value = 0
        i001.Value = 0
        LoadCash("")
        LoadCheckOnline("")
        LoadPassBook("")
        LoadATM("")
        btnPrint.Enabled = False
        dtpDocument.Value = Date.Now
        dtpDocument.Enabled = True
        cbxORLastIssued.Text = ""
        cbxORDeposited.Text = ""
        dtpORLastIssued.Value = Date.Now
        dtpORDeposited.Value = Date.Now
        dtpORLastIssued.CustomFormat = ""
        dtpORDeposited.CustomFormat = ""
        rExplanation.Text = ""

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        btnDisapprove.Visible = False

        GetDocumentNumber()
        cbxPreparedBy.SelectedValue = Empl_ID
        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub DtpDocument_ValueChanged(sender As Object, e As EventArgs) Handles dtpDocument.ValueChanged
        GetDocumentNumber()
        LoadCash("")
        LoadCheckOnline("")
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('CCC-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM collection_cashcount WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
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

        If dtpDocument.CustomFormat = "" Or Format(dtpDocument.Value, "yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Please fill Document Date.", MsgBoxStyle.Information, "Info")
            dtpDocument.Focus()
            Exit Sub
        End If
        Dim TotalCash As Double
        For x As Integer = 0 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Status") = "ON HAND" Then
                TotalCash += If(GridView3.GetRowCellValue(x, "Amount").ToString = "", 0, GridView3.GetRowCellValue(x, "Amount"))
            End If
        Next
        If dTotalCash.Value = TotalCash Then
        Else
            If MsgBoxYes("Total Cash ON HAND is not equal with Total Cash Breakdown, are you sure you want to proceed?") = MsgBoxResult.Yes Then

            End If
            'i1000.Focus()
            'Exit Sub
        End If
        For x As Integer = 0 To GridView4.RowCount - 1
            If GridView4.GetRowCellValue(x, "On Hand").ToString = "False" And GridView4.GetRowCellValue(x, "Remarks") = "" Then
                MsgBox(String.Format("Please fill the remarks/reason why the Passbook of {0} for {1} is not on hand.", GridView4.GetRowCellValue(x, "Account Name"), GridView4.GetRowCellValue(x, "Bank - Account Number")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next
        For x As Integer = 0 To GridView5.RowCount - 1
            If GridView5.GetRowCellValue(x, "On Hand").ToString = "False" And GridView5.GetRowCellValue(x, "Remarks") = "" Then
                MsgBox(String.Format("Please fill the remarks/reason why the ATM of {0} for {1} is not on hand.", GridView5.GetRowCellValue(x, "Account Name"), GridView5.GetRowCellValue(x, "Bank - Account Number")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next
        If dShortOver.Value > 0 And rExplanation.Text.Trim = "" Then
            MsgBox("Please fill the remarks/reason why Cash ON HAND is not equal with Total Cash Breakdown.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
            MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If

        Dim Open As String = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(dtpDocument.Value, "yyyy"), Format(dtpDocument.Value, "MMM")))
        If If(Open = "", "Open", Open) = "Open" Then
        Else
            MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Check = Code
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String
                Dim FName As String
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Collection Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalCollection.Text, cbxPreparedBy.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                        End If
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                    AttachmentFiles = New ArrayList()
                    FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Collection Cash Count" & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    GenerateCCC(False, FName, txtChecked.Text, txtApproved.Text)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If
                GetDocumentNumber()

                Dim SQL As String = "INSERT INTO collection_cashcount SET"
                SQL &= String.Format(" DocumentDate = '{0}', ", FormatDatePicker(dtpDocument))
                SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                SQL &= String.Format(" i1000 = '{0}', ", i1000.Value)
                SQL &= String.Format(" i500 = '{0}', ", i500.Value)
                SQL &= String.Format(" i200 = '{0}', ", i200.Value)
                SQL &= String.Format(" i100 = '{0}', ", i100.Value)
                SQL &= String.Format(" i50 = '{0}', ", i50.Value)
                SQL &= String.Format(" i20 = '{0}', ", i20.Value)
                SQL &= String.Format(" i10 = '{0}', ", i10.Value)
                SQL &= String.Format(" i5 = '{0}', ", i5.Value)
                SQL &= String.Format(" i1 = '{0}', ", i1.Value)
                SQL &= String.Format(" i025 = '{0}', ", i025.Value)
                SQL &= String.Format(" i010 = '{0}', ", i010.Value)
                SQL &= String.Format(" i005 = '{0}', ", i005.Value)
                SQL &= String.Format(" i001 = '{0}', ", i001.Value)
                SQL &= String.Format(" TotalCash = '{0}', ", dTotalCash.Value)
                SQL &= String.Format(" TotalCheck = '{0}', ", dTotalChecks.Value)
                SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= " CheckedID = '0', "
                SQL &= " ApprovedID = '0', "
                SQL &= String.Format(" LastORIssued = '{0}', ", cbxORLastIssued.Text)
                SQL &= String.Format(" LastORIssuedDate = '{0}', ", FormatDatePicker(dtpORLastIssued))
                SQL &= String.Format(" LastORDeposited = '{0}', ", cbxORDeposited.Text)
                SQL &= String.Format(" LastORDepositedDate = '{0}', ", FormatDatePicker(dtpORDeposited))
                SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                DataObject(SQL)
                SQL = ""
                'Check and Online Payment
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO ccc_checks SET"
                        SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Document Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Explanation = '{0}', ", GridView2.GetRowCellValue(x, "Explanation").ToString.InsertQuote)
                        SQL &= String.Format(" Payor = '{0}', ", GridView2.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))

                        If GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("ACR") Then
                            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView2.GetRowCellValue(x, "Document Number"))
                        ElseIf GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("OR") Then
                            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView2.GetRowCellValue(x, "Document Number"))
                        End If
                    End If
                Next
                'Cash Payment
                For x As Integer = 0 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO ccc_cash SET"
                        SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(CDate(GridView3.GetRowCellValue(x, "Document Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView3.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Explanation = '{0}', ", GridView3.GetRowCellValue(x, "Explanation").ToString.InsertQuote)
                        SQL &= String.Format(" Payor = '{0}', ", GridView3.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView3.GetRowCellValue(x, "Amount")))

                        If GridView3.GetRowCellValue(x, "Document Number").ToString.Contains("ACR") Then
                            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView3.GetRowCellValue(x, "Document Number"))
                        ElseIf GridView3.GetRowCellValue(x, "Document Number").ToString.Contains("OR") Then
                            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView3.GetRowCellValue(x, "Document Number"))
                        End If
                    End If
                Next
                'PassBook Monitoring
                For x As Integer = 0 To GridView4.RowCount - 1
                    SQL &= "INSERT INTO ccc_passbook SET"
                    SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" OnHand = '{0}', ", If(GridView4.GetRowCellValue(x, "On Hand").ToString = "True", 1, 0))
                    SQL &= String.Format(" AccountName = '{0}', ", GridView4.GetRowCellValue(x, "Account Name"))
                    SQL &= String.Format(" BankAccountNumber = '{0}', ", GridView4.GetRowCellValue(x, "Bank - Account Number"))
                    SQL &= String.Format(" WithATM = '{0}', ", If(GridView4.GetRowCellValue(x, "With ATM").ToString = "True", 1, 0))
                    SQL &= String.Format(" Remarks = '{0}';", GridView4.GetRowCellValue(x, "Remarks"))
                Next
                'ATM Monitoring
                For x As Integer = 0 To GridView5.RowCount - 1
                    SQL &= "INSERT INTO ccc_atm SET"
                    SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" OnHand = '{0}', ", If(GridView5.GetRowCellValue(x, "On Hand").ToString = "True", 1, 0))
                    SQL &= String.Format(" AccountName = '{0}', ", GridView5.GetRowCellValue(x, "Account Name"))
                    SQL &= String.Format(" BankAccountNumber = '{0}', ", GridView5.GetRowCellValue(x, "Bank - Account Number"))
                    SQL &= String.Format(" Remarks = '{0}';", GridView5.GetRowCellValue(x, "Remarks"))
                Next
                If SQL = "" Then
                Else
                    DataObject(SQL)
                End If
                Logs("Collection Cash Count", "Save", "Add new Collection Cash Count.", "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM collection_cashcount WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
                If CancelledID > 0 Then
                    MsgBox("This transaction was recently CANCELLED/DISAPPROVED, modification is not allowed anymore.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor

                Code = GenerateOTAC()
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String
                Dim FName As String
                If txtChecked.Text = "" Then
                    'F O R   C H E C K I N G************************************************************************************************************************
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Collection Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalCollection.Text, cbxPreparedBy.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_Signatory(x)("Phone").ToString = "" Then
                            Else
                                SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_Signatory(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                            End If
                        End If
                    Next
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        GenerateCCC(False, FName, txtChecked.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    'F O R   C H E C K I N G************************************************************************************************************************
                ElseIf txtApproved.Text = "" Then
                    'F O R   A P P R O V A L ***********************************************************************************************************************
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Collection Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalCollection.Text, cbxPreparedBy.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_Signatory(x)("Phone").ToString = "" Then
                            Else
                                SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_Signatory(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                            End If
                        End If
                    Next
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        GenerateCCC(False, FName, txtChecked.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    'F O R   A P P R O V A L ***********************************************************************************************************************
                End If

                Dim SQL As String = "UPDATE collection_cashcount SET"
                SQL &= String.Format(" i1000 = '{0}', ", i1000.Value)
                SQL &= String.Format(" i500 = '{0}', ", i500.Value)
                SQL &= String.Format(" i200 = '{0}', ", i200.Value)
                SQL &= String.Format(" i100 = '{0}', ", i100.Value)
                SQL &= String.Format(" i50 = '{0}', ", i50.Value)
                SQL &= String.Format(" i20 = '{0}', ", i20.Value)
                SQL &= String.Format(" i10 = '{0}', ", i10.Value)
                SQL &= String.Format(" i5 = '{0}', ", i5.Value)
                SQL &= String.Format(" i1 = '{0}', ", i1.Value)
                SQL &= String.Format(" i025 = '{0}', ", i025.Value)
                SQL &= String.Format(" i010 = '{0}', ", i010.Value)
                SQL &= String.Format(" i005 = '{0}', ", i005.Value)
                SQL &= String.Format(" i001 = '{0}', ", i001.Value)
                SQL &= String.Format(" TotalCash = '{0}', ", dTotalCash.Value)
                SQL &= String.Format(" TotalCheck = '{0}', ", dTotalChecks.Value)
                If txtChecked.Text = "" Then
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                ElseIf txtApproved.Text = "" Then
                    SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                End If
                SQL &= String.Format(" LastORIssued = '{0}', ", cbxORLastIssued.Text)
                SQL &= String.Format(" LastORIssuedDate = '{0}', ", FormatDatePicker(dtpORLastIssued))
                SQL &= String.Format(" LastORDeposited = '{0}', ", cbxORDeposited.Text)
                SQL &= String.Format(" LastORDepositedDate = '{0}', ", FormatDatePicker(dtpORDeposited))
                SQL &= String.Format(" Remarks = '{0}' ", rExplanation.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                SQL &= String.Format("UPDATE ccc_checks SET `status` = 'CANCELLED' WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
                SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
                'Check and Online Payment
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO ccc_checks SET"
                        SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Document Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Explanation = '{0}', ", GridView2.GetRowCellValue(x, "Explanation").ToString.InsertQuote)
                        SQL &= String.Format(" PAyor = '{0}', ", GridView2.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))

                        If GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("ACR") Then
                            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView2.GetRowCellValue(x, "Document Number"))
                        ElseIf GridView2.GetRowCellValue(x, "Document Number").ToString.Contains("OR") Then
                            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView2.GetRowCellValue(x, "Document Number"))
                        End If
                    End If
                Next
                SQL &= String.Format("UPDATE ccc_cash SET `status` = 'CANCELLED' WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                'Cash Payment
                For x As Integer = 0 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO ccc_cash SET"
                        SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" DocumentDate = '{0}', ", Format(CDate(GridView3.GetRowCellValue(x, "Document Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView3.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Explanation = '{0}', ", GridView3.GetRowCellValue(x, "Explanation").ToString.InsertQuote)
                        SQL &= String.Format(" Payor = '{0}', ", GridView3.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView3.GetRowCellValue(x, "Amount")))

                        If GridView3.GetRowCellValue(x, "Document Number").ToString.Contains("ACR") Then
                            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView3.GetRowCellValue(x, "Document Number"))
                        ElseIf GridView3.GetRowCellValue(x, "Document Number").ToString.Contains("OR") Then
                            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, GridView3.GetRowCellValue(x, "Document Number"))
                        End If
                    End If
                Next
                'PassBook Monitoring
                SQL &= String.Format("UPDATE ccc_passbook SET `status` = 'CANCELLED' WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                For x As Integer = 0 To GridView4.RowCount - 1
                    SQL &= "INSERT INTO ccc_passbook SET"
                    SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" OnHand = '{0}', ", If(GridView4.GetRowCellValue(x, "On Hand").ToString = "True", 1, 0))
                    SQL &= String.Format(" AccountName = '{0}', ", GridView4.GetRowCellValue(x, "Account Name"))
                    SQL &= String.Format(" BankAccountNumber = '{0}', ", GridView4.GetRowCellValue(x, "Bank - Account Number"))
                    SQL &= String.Format(" WithATM = '{0}', ", If(GridView4.GetRowCellValue(x, "With ATM").ToString = "True", 1, 0))
                    SQL &= String.Format(" Remarks = '{0}';", GridView4.GetRowCellValue(x, "Remarks"))
                Next
                'ATM Monitoring
                SQL &= String.Format("UPDATE ccc_atm SET `status` = 'CANCELLED' WHERE CollectionNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                For x As Integer = 0 To GridView5.RowCount - 1
                    SQL &= "INSERT INTO ccc_atm SET"
                    SQL &= String.Format(" CollectionNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" OnHand = '{0}', ", If(GridView5.GetRowCellValue(x, "On Hand").ToString = "True", 1, 0))
                    SQL &= String.Format(" AccountName = '{0}', ", GridView5.GetRowCellValue(x, "Account Name"))
                    SQL &= String.Format(" BankAccountNumber = '{0}', ", GridView5.GetRowCellValue(x, "Bank - Account Number"))
                    SQL &= String.Format(" Remarks = '{0}';", GridView5.GetRowCellValue(x, "Remarks"))
                Next
                DataObject(SQL)

                Logs("Collection Cash Count", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If i1000.Text = i1000.Tag Then
            Else
                Change &= String.Format("Change Cash P1,000.00 from {0} to {1}. ", i1000.Tag, i1000.Text)
            End If
            If i500.Text = i500.Tag Then
            Else
                Change &= String.Format("Change Cash P500.00 from {0} to {1}. ", i500.Tag, i500.Text)
            End If
            If i200.Text = i200.Tag Then
            Else
                Change &= String.Format("Change Cash P200.00 from {0} to {1}. ", i200.Tag, i200.Text)
            End If
            If i100.Text = i100.Tag Then
            Else
                Change &= String.Format("Change Cash P100.00 from {0} to {1}. ", i100.Tag, i100.Text)
            End If
            If i50.Text = i50.Tag Then
            Else
                Change &= String.Format("Change Cash P50.00 from {0} to {1}. ", i50.Tag, i50.Text)
            End If
            If i20.Text = i20.Tag Then
            Else
                Change &= String.Format("Change Cash P20.00 from {0} to {1}. ", i20.Tag, i20.Text)
            End If
            If i10.Text = i10.Tag Then
            Else
                Change &= String.Format("Change Cash P10.00 from {0} to {1}. ", i10.Tag, i10.Text)
            End If
            If i5.Text = i5.Tag Then
            Else
                Change &= String.Format("Change Cash P5.00 from {0} to {1}. ", i5.Tag, i5.Text)
            End If
            If i1.Text = i1.Tag Then
            Else
                Change &= String.Format("Change Cash P1.00 from {0} to {1}. ", i1.Tag, i1.Text)
            End If
            If i025.Text = i025.Tag Then
            Else
                Change &= String.Format("Change Cash P0.25 from {0} to {1}. ", i025.Tag, i025.Text)
            End If
            If i010.Text = i010.Tag Then
            Else
                Change &= String.Format("Change Cash P0.10 from {0} to {1}. ", i010.Tag, i010.Text)
            End If
            If i005.Text = i005.Tag Then
            Else
                Change &= String.Format("Change Cash P0.05 from {0} to {1}. ", i005.Tag, i005.Text)
            End If
            If i001.Text = i001.Tag Then
            Else
                Change &= String.Format("Change Cash P0.01 from {0} to {1}. ", i001.Tag, i001.Text)
            End If
            If cbxORLastIssued.Text = cbxORLastIssued.Tag Then
            Else
                Change &= String.Format("Change Last OR Issued from {0} to {1}. ", cbxORLastIssued.Tag, cbxORLastIssued.Text)
            End If
            If dtpORLastIssued.Text = dtpORLastIssued.Tag Then
            Else
                Change &= String.Format("Change Last OR Issued Date from {0} to {1}. ", dtpORLastIssued.Tag, dtpORLastIssued.Text)
            End If
            If cbxORDeposited.Text = cbxORDeposited.Tag Then
            Else
                Change &= String.Format("Change Last OR Deposited from {0} to {1}. ", cbxORDeposited.Tag, cbxORDeposited.Text)
            End If
            If dtpORDeposited.Text = dtpORDeposited.Tag Then
            Else
                Change &= String.Format("Change Last OR Deposited Date from {0} to {1}. ", dtpORDeposited.Tag, dtpORDeposited.Text)
            End If
            If rExplanation.Text = rExplanation.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", rExplanation.Tag, rExplanation.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Collection Cash Count - Changes", ex.Message.ToString)
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
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
            i1000.Enabled = True
            i500.Enabled = True
            i200.Enabled = True
            i100.Enabled = True
            i50.Enabled = True
            i20.Enabled = True
            i10.Enabled = True
            i5.Enabled = True
            i1.Enabled = True
            i025.Enabled = True
            i010.Enabled = True
            i005.Enabled = True
            i001.Enabled = True
            cbxORLastIssued.Enabled = True
            dtpORLastIssued.Enabled = True
            cbxORDeposited.Enabled = True
            dtpORDeposited.Enabled = True
            rExplanation.Enabled = True
            btnPrint.Enabled = False
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
            Dim SQL As String = String.Format("UPDATE collection_cashcount SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
            DataObject(SQL)
            Logs("Collection Cash Count", "Cancel", Reason, String.Format("Cancel Collection Cash Count of {0} for {1}.", Branch, dtpDocument.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancel", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GenerateCCC(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptCollectionCashCount
        With Report
            If FName = "Blank" Then
                .Name = "Collection Cash Count"
                .lblAsOf.Text = ""
                .lblDocumentDate.Text = ""
                .lblDocumentNumber.Text = ""

                .i1000.Text = ""
                .i500.Text = ""
                .i200.Text = ""
                .i100.Text = ""
                .i50.Text = ""
                .i20.Text = ""
                .i10.Text = ""
                .i5.Text = ""
                .i1.Text = ""
                .i025.Text = ""
                .i010.Text = ""
                .i005.Text = ""
                .i001.Text = ""

                .d1000.Text = ""
                .d500.Text = ""
                .d200.Text = ""
                .d100.Text = ""
                .d50.Text = ""
                .d20.Text = ""
                .d10.Text = ""
                .d5.Text = ""
                .d1.Text = ""
                .d025.Text = ""
                .d010.Text = ""
                .d005.Text = ""
                .cbxORLastIssued.Text = ""
                .dtpORLastIssued.Text = ""
                .cbxORDeposited.Text = ""
                .dtpORDeposited.Text = ""

                .lblTotalCash.Text = ""
                .lblTotalCheck.Text = ""
                .lblTotalCollection.Text = ""
                .lblShort.Text = ""
                .lblExplanation.Text = ""

                .lblPreparedBy.Text = ""
                .lblCheckedBy.Text = ""
                .lblApprovedBy.Text = ""

                Dim DT As New DataTable
                With DT
                    For x As Integer = 1 To 13
                        .Rows.Add()
                    Next
                End With

                Dim Cash As New SubRptCash With {
                    .DataSource = DT
                }
                .subRpt_Cash.ReportSource = Cash

                Dim Check As New SubRptCash With {
                    .DataSource = DT
                }
                .subRpt_Check.ReportSource = Check

                DT.Rows.RemoveAt(1)
                Dim Passbook As New SubRptPassbook With {
                    .DataSource = DT
                }
                .subRpt_Passbook.ReportSource = Passbook

                Dim ATM As New SubRptATM With {
                    .DataSource = DT
                }
                .subRpt_ATM.ReportSource = ATM

                .ShowPreview()
            Else
                .Name = "Collection Cash Count of " & Branch & " for " & dtpDocument.Text
                .lblAsOf.Text = dtpDocument.Text
                .lblDocumentDate.Text = dtpDocument.Text
                .lblDocumentNumber.Text = txtDocumentNumber.Text

                .i1000.Text = i1000.Text
                .i500.Text = i500.Text
                .i200.Text = i200.Text
                .i100.Text = i100.Text
                .i50.Text = i50.Text
                .i20.Text = i20.Text
                .i10.Text = i10.Text
                .i5.Text = i5.Text
                .i1.Text = i1.Text
                .i025.Text = i025.Text
                .i010.Text = i010.Text
                .i005.Text = i005.Text
                .i001.Text = i001.Text

                .d1000.Text = d1000.Text
                .d500.Text = d500.Text
                .d200.Text = d200.Text
                .d100.Text = d100.Text
                .d50.Text = d50.Text
                .d20.Text = d20.Text
                .d10.Text = d10.Text
                .d5.Text = d5.Text
                .d1.Text = d1.Text
                .d025.Text = d025.Text
                .d010.Text = d010.Text
                .d005.Text = d005.Text
                .cbxORLastIssued.Text = cbxORLastIssued.Text
                .dtpORLastIssued.Text = dtpORLastIssued.Text
                .cbxORDeposited.Text = cbxORDeposited.Text
                .dtpORDeposited.Text = dtpORDeposited.Text

                .lblTotalCash.Text = dTotalCash.Text
                .lblTotalCheck.Text = dTotalChecks.Text
                .lblTotalCollection.Text = dTotalCollection.Text
                .lblShort.Text = dShortOver.Text
                .lblExplanation.Text = rExplanation.Text

                .lblPreparedBy.Text = cbxPreparedBy.Text
                .lblCheckedBy.Text = txtChecked.Text
                .lblApprovedBy.Text = txtApproved.Text

                Dim Cash As New SubRptCash With {
                    .DataSource = GridControl3.DataSource
                }
                .subRpt_Cash.ReportSource = Cash
                With Cash
                    .lblDocumentDate.DataBindings.Add("Text", GridControl3.DataSource, "Document Date")
                    .lblDocumentNumber.DataBindings.Add("Text", GridControl3.DataSource, "Document Number")
                    .lblExplanation.DataBindings.Add("Text", GridControl3.DataSource, "Explanation")
                    .lblPayor.DataBindings.Add("Text", GridControl3.DataSource, "Payor")
                    .lblAmount.DataBindings.Add("Text", GridControl3.DataSource, "Amount")
                End With

                Dim Check As New SubRptCash With {
                    .DataSource = GridControl2.DataSource
                }
                .subRpt_Check.ReportSource = Check
                With Check
                    .lblDocumentDate.DataBindings.Add("Text", GridControl2.DataSource, "Document Date")
                    .lblDocumentNumber.DataBindings.Add("Text", GridControl2.DataSource, "Document Number")
                    .lblExplanation.DataBindings.Add("Text", GridControl2.DataSource, "Explanation")
                    .lblPayor.DataBindings.Add("Text", GridControl2.DataSource, "Payor")
                    .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                End With

                Dim DT_Passbook As DataTable = GridControl4.DataSource
                For x As Integer = 0 To DT_Passbook.Rows.Count - 1
                    DT_Passbook(x)("On Hand") = DT_Passbook(x)("On Hand").ToString = "True"
                    DT_Passbook(x)("With ATM") = DT_Passbook(x)("With ATM").ToString = "True"
                Next

                Dim Passbook As New SubRptPassbook With {
                    .DataSource = DT_Passbook
                }
                .subRpt_Passbook.ReportSource = Passbook
                With Passbook
                    .cbxOnHand.DataBindings.Add("Checked", DT_Passbook, "On Hand")
                    .lblAccountName.DataBindings.Add("Text", DT_Passbook, "Account Name")
                    .lblBank.DataBindings.Add("Text", DT_Passbook, "Bank - Account Number")
                    .cbxATM.DataBindings.Add("Checked", DT_Passbook, "With ATM")
                    .lblRemarks.DataBindings.Add("Text", DT_Passbook, "Remarks")
                End With

                Dim DT_ATM As DataTable = GridControl5.DataSource
                For x As Integer = 0 To DT_ATM.Rows.Count - 1
                    DT_ATM(x)("On Hand") = DT_ATM(x)("On Hand").ToString = "True"
                Next

                Dim ATM As New SubRptATM With {
                    .DataSource = DT_ATM
                }
                .subRpt_ATM.ReportSource = ATM
                With ATM
                    .cbxOnHand.DataBindings.Add("Checked", DT_ATM, "On Hand")
                    .lblAccountName.DataBindings.Add("Text", DT_ATM, "Account Name")
                    .lblBank.DataBindings.Add("Text", DT_ATM, "Bank - Account Number")
                    .lblRemarks.DataBindings.Add("Text", DT_ATM, "Remarks")
                End With

                If Show Then
                    .ShowPreview()
                Else
                    Try
                        .ExportToPdf(FName)
                    Catch ex As Exception
                    End Try
                End If
            End If
        End With
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GenerateCCC(True, "", txtChecked.Text, txtApproved.Text)
            Logs("Collection Cash Count", "Print", "[SENSITIVE] Print Collection Cash Count " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("COLLECTION CASH COUNT LIST", GridControl1)
            Logs("Collection Cash Count", "Print", "[SENSITIVE] Print Collection Cash Count List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

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
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.P Then
            GenerateCCC(False, "Blank", txtChecked.Text, txtApproved.Text)
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

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        i1000.Enabled = False
        i500.Enabled = False
        i200.Enabled = False
        i100.Enabled = False
        i50.Enabled = False
        i20.Enabled = False
        i10.Enabled = False
        i5.Enabled = False
        i1.Enabled = False
        i025.Enabled = False
        i010.Enabled = False
        i005.Enabled = False
        i001.Enabled = False
        cbxORLastIssued.Enabled = False
        dtpORLastIssued.Enabled = False
        cbxORDeposited.Enabled = False
        dtpORDeposited.Enabled = False
        dtpDocument.Enabled = False

        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            dtpDocument.Tag = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            txtDocumentNumber.Tag = .GetFocusedRowCellValue("Document Number")

            i1000.Value = .GetFocusedRowCellValue("i1000")
            i1000.Tag = .GetFocusedRowCellValue("i1000")
            i500.Value = .GetFocusedRowCellValue("i500")
            i500.Tag = .GetFocusedRowCellValue("i500")
            i200.Value = .GetFocusedRowCellValue("i200")
            i200.Tag = .GetFocusedRowCellValue("i200")
            i100.Value = .GetFocusedRowCellValue("i100")
            i100.Tag = .GetFocusedRowCellValue("i100")
            i50.Value = .GetFocusedRowCellValue("i50")
            i50.Tag = .GetFocusedRowCellValue("i50")
            i20.Value = .GetFocusedRowCellValue("i20")
            i20.Tag = .GetFocusedRowCellValue("i20")
            i10.Value = .GetFocusedRowCellValue("i10")
            i10.Tag = .GetFocusedRowCellValue("i10")
            i5.Value = .GetFocusedRowCellValue("i5")
            i5.Tag = .GetFocusedRowCellValue("i5")
            i1.Value = .GetFocusedRowCellValue("i1")
            i1.Tag = .GetFocusedRowCellValue("i1")
            i025.Value = .GetFocusedRowCellValue("i025")
            i025.Tag = .GetFocusedRowCellValue("i025")
            i010.Value = .GetFocusedRowCellValue("i010")
            i010.Tag = .GetFocusedRowCellValue("i010")
            i005.Value = .GetFocusedRowCellValue("i005")
            i005.Tag = .GetFocusedRowCellValue("i005")
            i001.Value = .GetFocusedRowCellValue("i001")
            i001.Tag = .GetFocusedRowCellValue("i001")

            LoadCash(txtDocumentNumber.Text)
            LoadCheckOnline(txtDocumentNumber.Text)
            LoadPassBook(txtDocumentNumber.Text)
            LoadATM(txtDocumentNumber.Text)

            cbxORLastIssued.Text = .GetFocusedRowCellValue("Last Issued")
            cbxORLastIssued.Tag = .GetFocusedRowCellValue("Last Issued")
            If .GetFocusedRowCellValue("LastORIssuedDate") = "" Then
                dtpORLastIssued.CustomFormat = ""
            Else
                dtpORLastIssued.CustomFormat = "MMMM dd, yyyy"
                dtpORLastIssued.Value = .GetFocusedRowCellValue("LastORIssuedDate")
            End If
            dtpORLastIssued.Tag = .GetFocusedRowCellValue("LastORIssuedDate")
            cbxORDeposited.Text = .GetFocusedRowCellValue("Last Deposited")
            cbxORDeposited.Tag = .GetFocusedRowCellValue("Last Deposited")
            If .GetFocusedRowCellValue("LastORDepositedDate") = "" Then
                dtpORDeposited.CustomFormat = ""
            Else
                dtpORDeposited.CustomFormat = "MMMM dd, yyyy"
                dtpORDeposited.Value = .GetFocusedRowCellValue("LastORDepositedDate")
            End If

            rExplanation.Text = .GetFocusedRowCellValue("Remarks")
            rExplanation.Tag = .GetFocusedRowCellValue("Remarks")

            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtChecked.Text = .GetFocusedRowCellValue("Checked By")
            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code_Check = .GetFocusedRowCellValue("OTAC_Check")
            Code_Approve = .GetFocusedRowCellValue("OTAC_Approve")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        If GridView1.GetFocusedRowCellValue("Voucher_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnCheck.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnCheck.Visible = True
                    btnModify.Enabled = True
                    btnDisapprove.Visible = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnModify.Enabled = True
                btnCheck.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CHECKED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnApprove.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnApprove.Visible = True
                    btnModify.Enabled = True
                    btnDisapprove.Visible = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnApprove.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnReceive.Visible = False
            btnModify.Enabled = False
        End If
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpORLastIssued_Click(sender As Object, e As EventArgs) Handles dtpORLastIssued.Click
        dtpORLastIssued.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpORDeposited_Click(sender As Object, e As EventArgs) Handles dtpORDeposited.Click
        dtpORDeposited.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
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

    Private Sub I1000_ValueChanged(sender As Object, e As EventArgs) Handles i1000.ValueChanged
        d1000.Value = i1000.Value * 1000
    End Sub

    Private Sub I500_ValueChanged(sender As Object, e As EventArgs) Handles i500.ValueChanged
        d500.Value = i500.Value * 500
    End Sub

    Private Sub I200_ValueChanged(sender As Object, e As EventArgs) Handles i200.ValueChanged
        d200.Value = i200.Value * 200
    End Sub

    Private Sub I100_ValueChanged(sender As Object, e As EventArgs) Handles i100.ValueChanged
        d100.Value = i100.Value * 100
    End Sub

    Private Sub I50_ValueChanged(sender As Object, e As EventArgs) Handles i50.ValueChanged
        d50.Value = i50.Value * 50
    End Sub

    Private Sub I20_ValueChanged(sender As Object, e As EventArgs) Handles i20.ValueChanged
        d20.Value = i20.Value * 20
    End Sub

    Private Sub I10_ValueChanged(sender As Object, e As EventArgs) Handles i10.ValueChanged
        d10.Value = i10.Value * 10
    End Sub

    Private Sub I5_ValueChanged(sender As Object, e As EventArgs) Handles i5.ValueChanged
        d5.Value = i5.Value * 5
    End Sub

    Private Sub I1_ValueChanged(sender As Object, e As EventArgs) Handles i1.ValueChanged
        d1.Value = i1.Value
    End Sub

    Private Sub I025_ValueChanged(sender As Object, e As EventArgs) Handles i025.ValueChanged
        d025.Value = i025.Value * 0.25
    End Sub

    Private Sub I010_ValueChanged(sender As Object, e As EventArgs) Handles i010.ValueChanged
        d010.Value = i010.Value * 0.1
    End Sub

    Private Sub I005_ValueChanged(sender As Object, e As EventArgs) Handles i005.ValueChanged, i001.ValueChanged
        d005.Value = (i005.Value * 0.05) + (i001.Value * 0.01)
    End Sub

    Private Sub TotalCash(sender As Object, e As EventArgs) Handles d1000.ValueChanged, d500.ValueChanged, d200.ValueChanged, d100.ValueChanged, d50.ValueChanged, d20.ValueChanged, d10.ValueChanged, d5.ValueChanged, d1.ValueChanged, d025.ValueChanged, d010.ValueChanged, d005.ValueChanged
        dTotalCash.Value = d1000.Value + d500.Value + d200.Value + d100.Value + d50.Value + d20.Value + d10.Value + d5.Value + d1.Value + d025.Value + d010.Value + d005.Value
    End Sub

    '***KEYDOWN
    Private Sub I1000_KeyDown(sender As Object, e As KeyEventArgs) Handles i1000.KeyDown
        If e.KeyCode = Keys.Enter Then
            i500.Focus()
        End If
    End Sub

    Private Sub I500_KeyDown(sender As Object, e As KeyEventArgs) Handles i500.KeyDown
        If e.KeyCode = Keys.Enter Then
            i200.Focus()
        End If
    End Sub

    Private Sub I200_KeyDown(sender As Object, e As KeyEventArgs) Handles i200.KeyDown
        If e.KeyCode = Keys.Enter Then
            i100.Focus()
        End If
    End Sub

    Private Sub I(sender As Object, e As KeyEventArgs) Handles i100.KeyDown
        If e.KeyCode = Keys.Enter Then
            i50.Focus()
        End If
    End Sub

    Private Sub I50_KeyDown(sender As Object, e As KeyEventArgs) Handles i50.KeyDown
        If e.KeyCode = Keys.Enter Then
            i20.Focus()
        End If
    End Sub

    Private Sub I20_KeyDown(sender As Object, e As KeyEventArgs) Handles i20.KeyDown
        If e.KeyCode = Keys.Enter Then
            i10.Focus()
        End If
    End Sub

    Private Sub I10_KeyDown(sender As Object, e As KeyEventArgs) Handles i10.KeyDown
        If e.KeyCode = Keys.Enter Then
            i5.Focus()
        End If
    End Sub

    Private Sub I5_KeyDown(sender As Object, e As KeyEventArgs) Handles i5.KeyDown
        If e.KeyCode = Keys.Enter Then
            i1.Focus()
        End If
    End Sub

    Private Sub I1_KeyDown(sender As Object, e As KeyEventArgs) Handles i1.KeyDown
        If e.KeyCode = Keys.Enter Then
            i025.Focus()
        End If
    End Sub

    Private Sub I025_KeyDown(sender As Object, e As KeyEventArgs) Handles i025.KeyDown
        If e.KeyCode = Keys.Enter Then
            i010.Focus()
        End If
    End Sub

    Private Sub I010_KeyDown(sender As Object, e As KeyEventArgs) Handles i010.KeyDown
        If e.KeyCode = Keys.Enter Then
            i005.Focus()
        End If
    End Sub

    Private Sub I005_KeyDown(sender As Object, e As KeyEventArgs) Handles i005.KeyDown
        If e.KeyCode = Keys.Enter Then
            i001.Focus()
        End If
    End Sub

    Private Sub I001_KeyDown(sender As Object, e As KeyEventArgs) Handles i001.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxORLastIssued.Focus()
        End If
    End Sub

    Private Sub CbxORLastIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxORLastIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpORLastIssued.Focus()
        End If
    End Sub

    Private Sub DtpORLastIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORLastIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxORDeposited.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpORLastIssued.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxORDeposited_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxORDeposited.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpORDeposited.Focus()
        End If
    End Sub

    Private Sub DtpORDeposited_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORDeposited.KeyDown
        If e.KeyCode = Keys.Enter Then
            rExplanation.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpORDeposited.CustomFormat = ""
        End If
    End Sub

    Private Sub RExplanation_KeyDown(sender As Object, e As KeyEventArgs) Handles rExplanation.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub RExplanation_Leave(sender As Object, e As EventArgs) Handles rExplanation.Leave
        rExplanation.Text = ReplaceText(rExplanation.Text)
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Collection Cash Count-" & GridView1.GetFocusedRowCellValue("Document Number")
            .CCCNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Collection Count"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Check
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Code = GenerateOTAC()
                            Code_Approve = Code
                            Dim Msg As String = ""
                            Dim EmailTo As String = ""
                            Dim Subject As String = "One Time Authorization Code " & Code
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Collection Cash Count for {1} with the collection amount of {2} prepared by {3}." & vbCrLf, Code, dtpDocument.Text, dTotalCollection.Text, cbxPreparedBy.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Signatory(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Signatory(x)("EmailAdd") = "" Then
                                    Else
                                        EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                                    End If
                                End If
                            Next
                            If EmailTo = "" Then
                            Else
                                Subject = "One Time Authorization Code " & Code
                                AttachmentFiles = New ArrayList()
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                GenerateCCC(False, FName, txtChecked.Text, txtApproved.Text)
                                AttachmentFiles.Add(FName)
                                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                            End If

                            DataObject(String.Format("UPDATE collection_cashcount SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text))
                            Logs("Collection Cash Count", "Check", String.Format("Checked Collection Cash Count for {0} with the collection amount of {1}. [Via OTAC]", dtpDocument, Terms, dTotalCollection.Text), "", "", "", "")
                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you check this Collection Cash Count?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Approve = Code
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Collection Cash Count for {1} with the collection amount of {2} prepared by {3}." & vbCrLf, Code, dtpDocument.Text, dTotalCollection.Text, cbxPreparedBy.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                        End If
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Subject = "One Time Authorization Code " & Code
                    AttachmentFiles = New ArrayList()
                    FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    GenerateCCC(False, FName, txtChecked.Text, txtApproved.Text)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If

                DataObject(String.Format("UPDATE collection_cashcount SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE ID = '{0}';", ID, Empl_ID, Code, txtDocumentNumber.Text))
                Logs("Collection Cash Count", "Check", String.Format("Checked Collection Cash Count for {0} with the collection amount of {1}. [Via OTAC]", dtpDocument, Terms, dTotalCollection.Text), "", "", "", "")
                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Approve
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnApprove.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            DataObject(String.Format("UPDATE collection_cashcount SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue, txtDocumentNumber.Text))
                            Logs("Collection Cash Count", "Approve", String.Format("Approved Collection Cash Count for {0} with the collection amount of {1}. [Via OTAC]", dtpDocument.Text, dTotalCollection.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Collection Cash Count?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE collection_cashcount SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID, txtDocumentNumber.Text))
                Logs("Collection Cash Count", "Approve", String.Format("Approved Collection Cash Count for {0} with the collection amount of {1}. [Via OTAC]", dtpDocument.Text, dTotalCollection.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If MsgBoxYes("Are you sure you want to disapprove this Collection Cash Count?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String = String.Format("UPDATE collection_cashcount SET `voucher_status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
            SQL &= String.Format("UPDATE acknowledgement_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
            SQL &= String.Format("UPDATE official_receipt SET CollectionNumber = '' WHERE CollectionNumber = '{0}';", txtDocumentNumber.Text)
            DataObject(SQL)
            Logs("Collection Cash Count", "Disapprove", Reason, String.Format("Disapprove Collection Cash Count for {0} with Collection Amount {1}.", dtpDocument.Text, dTotalCollection.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub TotalCollection(sender As Object, e As EventArgs) Handles dTotalCash.ValueChanged, dTotalChecks.ValueChanged
        Dim OnHand As Double
        Dim Deposited As Double
        For x As Integer = 0 To DT_Cash.Rows.Count - 1
            If DT_Cash(x)("Status") = "ON HAND" Then
                OnHand += CDbl(DT_Cash(x)("Amount"))
            End If
            If DT_Cash(x)("Status") = "DEPOSITED" Then
                Deposited += CDbl(DT_Cash(x)("Amount"))
            End If
        Next
        dShortOver.Value = OnHand - dTotalCash.Value

        dTotalCollection.Value = dTotalCash.Value + dTotalChecks.Value + Deposited
    End Sub

    Private Sub IAddCash_Click(sender As Object, e As EventArgs) Handles iAddCash.Click
        Dim Collection As New FrmAddCollection
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView3.RowCount - 1
            ExcludeID &= "'" & GridView3.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Collection
            .From_Cash = True
            If ExcludeID = "" Then
            Else
                .ExcludeID = ExcludeID.Substring(0, ExcludeID.Length - 1)
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim selectedRowHandles As Integer() = .GridView3.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    Dim Docs As String = ""
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            DT_Cash.Rows.Add(.GridView3.GetRowCellValue(selectedRowHandle, "ID"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Date"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Number"), .GridView3.GetRowCellValue(selectedRowHandle, "Explanation"), .GridView3.GetRowCellValue(selectedRowHandle, "Payor"), .GridView3.GetRowCellValue(selectedRowHandle, "Amount"), .GridView3.GetRowCellValue(selectedRowHandle, "Status"))
                        End If
                    Next
                Else
                    DT_Cash.Rows.Add(.GridView3.GetFocusedRowCellValue("ID"), .GridView3.GetFocusedRowCellValue("Document Date"), .GridView3.GetFocusedRowCellValue("Document Number"), .GridView3.GetFocusedRowCellValue("Explanation"), .GridView3.GetFocusedRowCellValue("Payor"), .GridView3.GetFocusedRowCellValue("Amount"), .GridView3.GetFocusedRowCellValue("Status"))
                End If
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With

        Dim OnHand As Double
        Dim Deposited As Double
        For x As Integer = 0 To DT_Cash.Rows.Count - 1
            If DT_Cash(x)("Status") = "ON HAND" Then
                OnHand += CDbl(DT_Cash(x)("Amount"))
            End If
            If DT_Cash(x)("Status") = "DEPOSITED" Then
                Deposited += CDbl(DT_Cash(x)("Amount"))
            End If
        Next
        dShortOver.Value = OnHand - dTotalCash.Value
        dTotalCollection.Value = dTotalCash.Value + dTotalChecks.Value + Deposited
        If GridView3.RowCount > 9 Then
            GridColumn19.Width = 448 - 17
        Else
            GridColumn19.Width = 448
        End If
    End Sub

    Private Sub IRemoveCash_Click(sender As Object, e As EventArgs) Handles iRemoveCash.Click
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

Here:
        Dim selectedRowHandles As Integer() = GridView3.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim I As Integer
            'Dim Docs As String
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    DT_Cash.Rows.RemoveAt(selectedRowHandle)
                    GoTo Here
                End If
            Next
        Else
            DT_Cash.Rows.RemoveAt(GridView3.FocusedRowHandle)
        End If

        Dim OnHand As Double
        Dim Deposited As Double
        For x As Integer = 0 To DT_Cash.Rows.Count - 1
            If DT_Cash(x)("Status") = "ON HAND" Then
                OnHand += CDbl(DT_Cash(x)("Amount"))
            End If
            If DT_Cash(x)("Status") = "DEPOSITED" Then
                Deposited += CDbl(DT_Cash(x)("Amount"))
            End If
        Next
        dShortOver.Value = OnHand - dTotalCash.Value
        dTotalCollection.Value = dTotalCash.Value + dTotalChecks.Value + Deposited
        If GridView3.RowCount > 9 Then
            GridColumn19.Width = 448 - 17
        Else
            GridColumn19.Width = 448
        End If
    End Sub

    Private Sub IAddCheck_Click(sender As Object, e As EventArgs) Handles iAddCheck.Click
        Dim Collection As New FrmAddCollection
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView2.RowCount - 1
            ExcludeID &= "'" & GridView2.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Collection
            .From_Cash = False
            If ExcludeID = "" Then
            Else
                .ExcludeID = ExcludeID.Substring(0, ExcludeID.Length - 1)
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim selectedRowHandles As Integer() = .GridView3.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    Dim Docs As String = ""
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            DT_Check.Rows.Add(.GridView3.GetRowCellValue(selectedRowHandle, "ID"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Date"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Number"), .GridView3.GetRowCellValue(selectedRowHandle, "Explanation"), .GridView3.GetRowCellValue(selectedRowHandle, "Payor"), .GridView3.GetRowCellValue(selectedRowHandle, "Amount"))
                        End If
                    Next
                Else
                    DT_Check.Rows.Add(.GridView3.GetFocusedRowCellValue("ID"), .GridView3.GetFocusedRowCellValue("Document Date"), .GridView3.GetFocusedRowCellValue("Document Number"), .GridView3.GetFocusedRowCellValue("Explanation"), .GridView3.GetFocusedRowCellValue("Payor"), .GridView3.GetFocusedRowCellValue("Amount"))
                End If
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            Dim TotalCheckOnline As Double
            For x As Integer = 0 To GridView2.RowCount - 1
                TotalCheckOnline += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
            Next
            dTotalChecks.Value = TotalCheckOnline
            .Dispose()
        End With

        If GridView2.RowCount > 9 Then
            GridColumn17.Width = 481 - 17
        Else
            GridColumn17.Width = 481
        End If
    End Sub

    Private Sub IRemoveCheck_Click(sender As Object, e As EventArgs) Handles iRemoveCheck.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If

Here:
        Dim selectedRowHandles As Integer() = GridView2.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim I As Integer
            'Dim Docs As String
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    DT_Check.Rows.RemoveAt(selectedRowHandle)
                    GoTo Here
                End If
            Next
        Else
            DT_Check.Rows.RemoveAt(GridView2.FocusedRowHandle)
        End If

        Dim TotalCheckOnline As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            TotalCheckOnline += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
        Next
        dTotalChecks.Value = TotalCheckOnline

        If GridView2.RowCount > 9 Then
            GridColumn17.Width = 481 - 17
        Else
            GridColumn17.Width = 481
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub BtnCheckPassbook_Click(sender As Object, e As EventArgs) Handles btnCheckPassbook.Click
        For x As Integer = 0 To GridView4.RowCount - 1
            GridView4.SetRowCellValue(x, "On Hand", True)
        Next
    End Sub

    Private Sub BtnCheckATM_Click(sender As Object, e As EventArgs) Handles btnCheckATM.Click
        For x As Integer = 0 To GridView5.RowCount - 1
            GridView5.SetRowCellValue(x, "On Hand", True)
        Next
    End Sub
End Class