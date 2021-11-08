Imports DevExpress.XtraReports.UI
Public Class FrmCashCount

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
    Dim DT_CV As New DataTable
    Dim DT_PCV As New DataTable
    Dim DT_CAS As New DataTable
    Private Sub FrmCashCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4})
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0
        dAccountability.Value = PettyCash

        dtpDate.Value = Date.Now
        dtpORLastIssued.Value = Date.Now
        dtpORDeposited.Value = Date.Now
        dtpORNotIssued.Value = Date.Now

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'Checked' UNION SELECT 'Cancelled'")
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

        LoadCV(0)
        LoadPettyCash(0)
        LoadCashAdvance(0)

        GetDocumentNumber()
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

            GetLabelFontSettings({LabelX33, LabelX38, LabelX18, LabelX2, LabelX3, LabelX4, LabelX5, LabelX6, LabelX14, LabelX12, LabelX10, LabelX9, LabelX8, LabelX7, LabelX43, LabelX21, LabelX19, LabelX20, LabelX23, LabelX24, LabelX25, LabelX26, LabelX28, LabelX30, LabelX31, LabelX36, LabelX34, LabelX40, LabelX42, LabelX39})

            GetLabelWithBackgroundFontSettings({LabelX15, LabelX1, LabelX13, LabelX16, LabelX17, LabelX35, LabelX27, LabelX29, LabelX37, LabelX32})

            GetCheckBoxFontSettings({cbxAll})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnCheck, btnSearch})

            GetComboBoxFontSettings({cbxDisplay, cbxPreparedBy})

            GetDateTimeInputFontSettings({dtpDate, dtpORLastIssued, dtpORDeposited, dtpORNotIssued, dtpFrom, dtpTo})

            GetTextBoxFontSettings({txtDocumentNumber, txtORLastIssued, txtORDeposited, txtORNotIssued, txtCheckedBy})

            GetDoubleInputFontSettings({d1000, d500, d200, d100, d50, d20, d10, d5, d1, d025, d010, d005, dTotalCash, dTotalChecks, dTotalUnreplenished, dTotalCashAdvances, dTotalFund, dAccountability, dOverage})

            GetIntegerInputFontSettings({i1000, i500, i200, i100, i50, i20, i10, i5, i1, i025, i010, i005, i001})

            GetRickTextBoxFontSettings({rExplanation})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})

            GetContextMenuBarFontSettings({ContextMenuBar2, ContextMenuBar3, ContextMenuBar1})
        Catch ex As Exception
            TriggerBugReport("Cash Count - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Cash Count", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    TotalCash AS 'Total Cash',"
        SQL &= "    TotalCheck AS 'Total Checks',"
        SQL &= "    TotalUnreplenished AS 'Unreplenished',"
        SQL &= "    TotalCashAdvance AS 'Cash Advance',"
        SQL &= "    TotalFundCounted AS 'Fund Counted',"
        SQL &= "    Accountability,"
        SQL &= "    LastORIssued AS 'Last Issued',"
        SQL &= "    LastORDeposited AS 'Last Deposited',"
        SQL &= "    FirstORNotIssued AS 'Not Issued',"
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
        SQL &= "    LastORIssuedDate,"
        SQL &= "    LastORDepositedDate,"
        SQL &= "    FirstORNotIssuedDate,"
        SQL &= "    PreparedID,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By',"
        SQL &= "    Employee(CheckedID) AS 'Checked By', OTAC_Check, User_EmplID, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Voucher_Status = 'PENDING','FOR CHECKING',Voucher_Status)) AS 'Voucher_Status', Remarks, "
        SQL &= "    CheckedID, Branch(Branch_ID) AS 'Branch'"
        SQL &= " FROM cash_count WHERE "
        Dim ForChecking As Boolean
        Dim Checked As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Checked" Then
                    Checked = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And Checked = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR voucher_status = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (voucher_status = 'DISAPPROVED' "
                If ForChecking Or Checked Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If Checked Then
                        SQL &= " OR "
                    End If
                End If
                If Checked Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'CHECKED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And Checked = False Then
            Else
                SQL &= " AND (voucher_status = 'DISAPPROVED' OR"
                If ForChecking Then
                    SQL &= " voucher_status = 'PENDING'"
                    If Checked Then
                        SQL &= " OR "
                    End If
                End If
                If Checked Then
                    SQL &= " voucher_status = 'CHECKED'"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(Trans_Date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND Branch_ID = '{0}' ORDER BY Trans_Date DESC ;", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn31.Visible = True
            GridColumn31.VisibleIndex = 13
        End If
        GridView1.Columns("Date").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Date").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 19 Then
            GridColumn2.Width = 135 - 1
            GridColumn30.Width = 135 - 1
            GridColumn3.Width = 110 - 2
            GridColumn4.Width = 110 - 2
            GridColumn5.Width = 110 - 2
            GridColumn6.Width = 110 - 2
            GridColumn8.Width = 110 - 2
            GridColumn9.Width = 110 - 2
            GridColumn11.Width = 120 - 1
            GridColumn12.Width = 120 - 1
            GridColumn29.Width = 97 - 1
        Else
            GridColumn2.Width = 135
            GridColumn30.Width = 135
            GridColumn3.Width = 110
            GridColumn4.Width = 110
            GridColumn5.Width = 110
            GridColumn6.Width = 110
            GridColumn8.Width = 110
            GridColumn9.Width = 110
            GridColumn11.Width = 120
            GridColumn12.Width = 120
            GridColumn29.Width = 97
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCV(CashCountID As Integer)
        Dim SQL As String
        If CashCountID = 0 Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Date',"
            SQL &= "    DocumentNumber AS 'Document Number',"
            SQL &= "    CONCAT((SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = check_voucher.BankID),'/', CheckNumber) AS 'Bank/Check Number',"
            SQL &= "    Payee AS 'Payor',"
            SQL &= "    Amount "
            SQL &= " FROM check_voucher WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("    AND voucher_status IN ('RECEIVED','APPROVED','CHECKED','PENDING') AND ClearedDate = '' AND Payee_Type = 'RC' AND Branch_ID = '{0}';", Branch_ID)
        Else
            SQL = String.Format("SELECT ID, DATE_FORMAT(`Date`, '%M %d, %Y') AS 'Date', DocumentNumber AS 'Document Number', Bank AS 'Bank/Check Number', Payor, Amount FROM cc_checks WHERE CashCountID = '{0}' AND `status` = 'ACTIVE';", CashCountID)
        End If

        DT_CV = DataSource(SQL)
        GridControl2.DataSource = DT_CV

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            TotalPetty += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
        Next
        dTotalChecks.Value = TotalPetty

        If GridView2.RowCount > 3 Then
            GridColumn17.Width = 450 - 17
        Else
            GridColumn17.Width = 450
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

    Private Sub GridView4_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView4.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value.ToString.Replace("(", "").Replace(")", "")), 2)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub LoadPettyCash(CashCountID As Integer)
        Dim SQL As String
        If CashCountID = 0 Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
            SQL &= "    AccountNumber AS 'Document Number',"
            SQL &= "    CONCAT(IF(ReplenishedID = 0,'',(SELECT CONCAT('[',DocumentNumber,'] ') FROM replenishment_cash WHERE `status` = 'ACTIVE' AND ID = ReplenishedID) ),TRIM(Payee),'/',CONCAT(Particular_1,IF(Particular_2 = '','',CONCAT(', ', Particular_2)),IF(Particular_3 = '','',CONCAT(', ', Particular_3)),IF(Particular_4 = '','',CONCAT(', ', Particular_4)),IF(Particular_5 = '','',CONCAT(', ', Particular_5)),IF(Particular_6 = '','',CONCAT(', ', Particular_6)),IF(Particular_7 = '','',CONCAT(', ', Particular_7)),IF(Particular_8 = '','',CONCAT(', ', Particular_8)),IF(Particular_9 = '','',CONCAT(', ', Particular_9)),IF(Particular_10 = '','',CONCAT(', ', Particular_10)),IF(Particular_11 = '','',CONCAT(', ', Particular_11)),IF(Particular_12 = '','',CONCAT(', ', Particular_12)))) AS 'Payee/Particular',"
            SQL &= "    (Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Amount' "
            SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE'  AND voucher_status = 'RECEIVED'"
            SQL &= String.Format("    AND IF(ReplenishedID = 0,TRUE,(SELECT ReplenishStatus FROM replenishment_cash WHERE `status` = 'ACTIVE' AND ID = ReplenishedID) = 'PENDING') AND Branch_ID = '{0}' ORDER BY `Payee/Particular`;", Branch_ID)
        Else
            SQL = String.Format("SELECT ID, DATE_FORMAT(`Date`, '%M %d, %Y') AS 'Date', DocumentNumber AS 'Document Number', Payee AS 'Payee/Particular', Amount FROM cc_details WHERE CashCountID = '{0}' AND `status` = 'ACTIVE' AND `From` = 'Petty Cash';", CashCountID)
        End If

        DT_PCV = DataSource(SQL)
        GridControl3.DataSource = DT_PCV

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView3.RowCount - 1
            TotalPetty += If(GridView3.GetRowCellValue(x, "Amount").ToString = "", 0, GridView3.GetRowCellValue(x, "Amount"))
        Next
        dTotalUnreplenished.Value = TotalPetty

        If GridView3.RowCount > 15 Then
            GridColumn19.Width = 697 - 17
        Else
            GridColumn19.Width = 697
        End If
    End Sub

    Private Sub LoadCashAdvance(CashCountID As Integer)
        Dim SQL As String
        If CashCountID = 0 Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
            SQL &= "    AccountNumber AS 'Document Number',"
            SQL &= "    CONCAT(TRIM(Employee(Payee_ID)),'/', Purpose) AS 'Payee/Particular',"
            SQL &= "    (Meals + Transportation + BIR + RD + LTO + Notarization + Others) AS 'Amount' "
            SQL &= " FROM cash_advance WHERE `status` = 'ACTIVE' AND Slip_Status = 'RECEIVED' "
            SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000 AND IF(Liquidated = 'Y',IFNULL((SELECT ApprovedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0) = 0,Liquidated = 'N');", Branch_ID)
        Else
            SQL = String.Format("SELECT ID, DATE_FORMAT(`Date`, '%M %d, %Y') AS 'Date', DocumentNumber AS 'Document Number', Payee AS 'Payee/Particular', Amount FROM cc_details WHERE CashCountID = '{0}' AND `status` = 'ACTIVE' AND `From` = 'Cash Advance';", CashCountID)
        End If

        DT_CAS = DataSource(SQL)
        GridControl4.DataSource = DT_CAS

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView4.RowCount - 1
            TotalPetty += If(GridView4.GetRowCellValue(x, "Amount").ToString = "", 0, GridView4.GetRowCellValue(x, "Amount"))
        Next
        dTotalCashAdvances.Value = TotalPetty

        If GridView4.RowCount > 5 Then
            GridColumn26.Width = 697 - 17
        Else
            GridColumn26.Width = 697
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
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                dAccountability.Value = PettyCash
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
        txtORLastIssued.Enabled = True
        dtpORLastIssued.Enabled = True
        txtORDeposited.Enabled = True
        dtpORDeposited.Enabled = True
        txtORNotIssued.Enabled = True
        dtpORNotIssued.Enabled = True
        rExplanation.Enabled = True
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
        LoadCV(0)
        LoadPettyCash(0)
        LoadCashAdvance(0)

        dtpDate.Value = Date.Now
        dtpDate.Enabled = True
        txtORLastIssued.Text = ""
        txtORDeposited.Text = ""
        txtORNotIssued.Text = ""
        dtpORLastIssued.Value = Date.Now
        dtpORDeposited.Value = Date.Now
        dtpORNotIssued.Value = Date.Now
        dtpORLastIssued.CustomFormat = ""
        dtpORDeposited.CustomFormat = ""
        dtpORNotIssued.CustomFormat = ""
        rExplanation.Text = ""

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False

        GetDocumentNumber()
        cbxPreparedBy.SelectedValue = Empl_ID
        If TriggerLoadData Then
            LoadData()
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
        If dtpDate.CustomFormat = "" Or Format(dtpDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Please fill Document Date.", MsgBoxStyle.Information, "Info")
            dtpDate.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Check = Code
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String
                    Dim FName As String
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalFund.Text, cbxPreparedBy.Text)
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
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CC(False, FName, txtCheckedBy.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                GetDocumentNumber()

                Dim SQL As String = "INSERT INTO cash_count SET"
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
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
                SQL &= String.Format(" TotalUnreplenished = '{0}', ", dTotalUnreplenished.Value)
                SQL &= String.Format(" TotalCashAdvance = '{0}', ", dTotalCashAdvances.Value)
                SQL &= String.Format(" TotalFundCounted = '{0}', ", dTotalFund.Value)
                SQL &= String.Format(" Accountability = '{0}', ", dAccountability.Value)
                SQL &= String.Format(" Overage = '{0}', ", dOverage.Value)
                SQL &= String.Format(" LastORIssued = '{0}', ", txtORLastIssued.Text)
                SQL &= String.Format(" LastORIssuedDate = '{0}', ", FormatDatePicker(dtpORLastIssued))
                SQL &= String.Format(" LastORDeposited = '{0}', ", txtORDeposited.Text)
                SQL &= String.Format(" LastORDepositedDate = '{0}', ", FormatDatePicker(dtpORDeposited))
                SQL &= String.Format(" FirstORNotIssued = '{0}', ", txtORNotIssued.Text)
                SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= " CheckedID = '0', "
                SQL &= String.Format(" FirstORNotIssuedDate = '{0}', ", FormatDatePicker(dtpORNotIssued))
                SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                DataObject(SQL)
                ID = DataObject(String.Format("SELECT MAX(ID) FROM cash_count WHERE Trans_Date = '{0}' AND Branch_ID = '{1}';", FormatDatePicker(dtpDate), Branch_ID))
                SQL = ""
                'Check Voucher
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_checks SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank/Check Number").ToString.InsertQuote)
                        SQL &= String.Format(" PAyor = '{0}', ", GridView2.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    End If
                Next
                'Petty Cash
                For x As Integer = 0 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_details SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `From` = '{0}', ", "Petty Cash")
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView3.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView3.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Payee = '{0}', ", GridView3.GetRowCellValue(x, "Payee/Particular").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView3.GetRowCellValue(x, "Amount")))
                    End If
                Next
                'Cash Advance
                For x As Integer = 0 To GridView4.RowCount - 1
                    If GridView4.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_details SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `From` = '{0}', ", "Cash Advance")
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView4.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView4.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Payee = '{0}', ", GridView4.GetRowCellValue(x, "Payee/Particular").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView4.GetRowCellValue(x, "Amount")))
                    End If
                Next
                If SQL = "" Then
                Else
                    DataObject(SQL)
                End If
                Logs("Cash Count", "Save", "Add new Cash Count.", "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor

                Code = GenerateOTAC()
                Code_Check = Code
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String
                    Dim FName As String
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code, dTotalFund.Text, cbxPreparedBy.Text)
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
                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CC(False, FName, txtCheckedBy.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                Dim SQL As String = "UPDATE cash_count SET"
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
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
                SQL &= String.Format(" TotalUnreplenished = '{0}', ", dTotalUnreplenished.Value)
                SQL &= String.Format(" TotalCashAdvance = '{0}', ", dTotalCashAdvances.Value)
                SQL &= String.Format(" TotalFundCounted = '{0}', ", dTotalFund.Value)
                SQL &= String.Format(" Accountability = '{0}', ", dAccountability.Value)
                SQL &= String.Format(" Overage = '{0}', ", dOverage.Value)
                SQL &= String.Format(" LastORIssued = '{0}', ", txtORLastIssued.Text)
                SQL &= String.Format(" LastORIssuedDate = '{0}', ", FormatDatePicker(dtpORLastIssued))
                SQL &= String.Format(" LastORDeposited = '{0}', ", txtORDeposited.Text)
                SQL &= String.Format(" LastORDepositedDate = '{0}', ", FormatDatePicker(dtpORDeposited))
                SQL &= String.Format(" FirstORNotIssued = '{0}', ", txtORNotIssued.Text)
                SQL &= String.Format(" FirstORNotIssuedDate = '{0}', ", FormatDatePicker(dtpORNotIssued))
                If txtCheckedBy.Text = "" Then
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                End If
                SQL &= String.Format(" Remarks = '{0}' ", rExplanation.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                'Check Voucher
                SQL &= String.Format("UPDATE cc_checks SET `status` = 'CANCELLED' WHERE CashCountID = '{0}' AND `status` = 'ACTIVE';", ID)
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_checks SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank/Check Number").ToString.InsertQuote)
                        SQL &= String.Format(" PAyor = '{0}', ", GridView2.GetRowCellValue(x, "Payor").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    End If
                Next
                'Petty Cash
                SQL &= String.Format("UPDATE cc_details SET `status` = 'CANCELLED' WHERE CashCountID = '{0}' AND `status` = 'ACTIVE';", ID)
                For x As Integer = 0 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_details SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `From` = '{0}', ", "Petty Cash")
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView3.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView3.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Payee = '{0}', ", GridView3.GetRowCellValue(x, "Payee/Particular").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView3.GetRowCellValue(x, "Amount")))
                    End If
                Next
                'Cash Advance
                For x As Integer = 0 To GridView4.RowCount - 1
                    If GridView4.GetRowCellValue(x, "ID") > 0 Then
                        SQL &= "INSERT INTO cc_details SET"
                        SQL &= String.Format(" CashCountID = '{0}', ", ID)
                        SQL &= String.Format(" `From` = '{0}', ", "Cash Advance")
                        SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(GridView4.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" DocumentNumber = '{0}', ", GridView4.GetRowCellValue(x, "Document Number"))
                        SQL &= String.Format(" Payee = '{0}', ", GridView4.GetRowCellValue(x, "Payee/Particular").ToString.InsertQuote)
                        SQL &= String.Format(" Amount = '{0}';", CDbl(GridView4.GetRowCellValue(x, "Amount")))
                    End If
                Next
                DataObject(SQL)

                Logs("Cash Count", "Update", Reason, Changes(), "", "", "")
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
            If txtORLastIssued.Text = txtORLastIssued.Tag Then
            Else
                Change &= String.Format("Change Last OR Issued from {0} to {1}. ", txtORLastIssued.Tag, txtORLastIssued.Text)
            End If
            If dtpORLastIssued.Text = dtpORLastIssued.Tag Then
            Else
                Change &= String.Format("Change Last OR Issued Date from {0} to {1}. ", dtpORLastIssued.Tag, dtpORLastIssued.Text)
            End If
            If txtORDeposited.Text = txtORDeposited.Tag Then
            Else
                Change &= String.Format("Change Last OR Deposited from {0} to {1}. ", txtORDeposited.Tag, txtORDeposited.Text)
            End If
            If dtpORDeposited.Text = dtpORDeposited.Tag Then
            Else
                Change &= String.Format("Change Last OR Deposited Date from {0} to {1}. ", dtpORDeposited.Tag, dtpORDeposited.Text)
            End If
            If txtORNotIssued.Text = txtORNotIssued.Tag Then
            Else
                Change &= String.Format("Change First OR not Issued from {0} to {1}. ", txtORNotIssued.Tag, txtORNotIssued.Text)
            End If
            If dtpORNotIssued.Text = dtpORNotIssued.Tag Then
            Else
                Change &= String.Format("Change First OR not Issued Date from {0} to {1}. ", dtpORNotIssued.Tag, dtpORNotIssued.Text)
            End If
            If rExplanation.Text = rExplanation.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", rExplanation.Tag, rExplanation.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Cash Count - Changes", ex.Message.ToString)
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
            txtORLastIssued.Enabled = True
            dtpORLastIssued.Enabled = True
            txtORDeposited.Enabled = True
            dtpORDeposited.Enabled = True
            txtORNotIssued.Enabled = True
            dtpORNotIssued.Enabled = True
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
            Dim SQL As String = String.Format("UPDATE cash_count SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            DataObject(SQL)
            Logs("Cash Count", "Cancel", Reason, String.Format("Cancel Cash Count of {0} for {1}.", Branch & " - " & txtDocumentNumber.Text, dtpDate.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_CC(Show As Boolean, FName As String, CheckedBy As String)
        Dim Report As New RptCashCount
        With Report
            If FName = "Blank" Then
                .Name = "Cash Count"
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

                .dTotalCash.Text = ""
                .dTotalCheck.Text = ""
                .dTotalUnreplenish.Text = ""
                .dTotalCashAdvances.Text = ""
                .dTotalFund.Text = ""
                .dAccountability.Text = ""
                .dOverage.Text = ""
                .txtORLastIssued.Text = ""
                .dtpORLastIssued.Text = ""
                .txtORDeposited.Text = ""
                .dtpORDeposited.Text = ""
                .txtORNotIssued.Text = ""
                .dtpORNotIssued.Text = ""
                .lblRemarks.Text = ""

                .lblPreparedBy.Text = ""
                .lblPreparedPos.Text = ""
                .lblNote.Text = String.Format("I hereby certify that the above fund was counted in presence by {0}, for {1} on {2} and were returned to me INTACT. I further certify that there are no other funds in my possession except for the following :", "__________________________", "___________________", "___________________")

                Dim DT As New DataTable
                For x As Integer = 1 To 18
                    DT.Rows.Add()
                Next

                Dim Checks As New SubRptCheck With {
                    .DataSource = DT
                }
                .subRpt_Check.ReportSource = Checks

                Dim Unreplenished As New SubRptUnreplenished With {
                    .DataSource = DT
                }
                .subRpt_Unreplenished.ReportSource = Unreplenished

                DT.Rows.RemoveAt(1)
                Dim CashAdvance As New SubRptUnreplenished With {
                    .DataSource = DT
                    }
                .subRpt_CashAdvances.ReportSource = CashAdvance

                .ShowPreview()
            Else
                .Name = "Cash Count of " & Branch & " for " & dtpDate.Text
                .lblAsOf.Text = "As of " & dtpDate.Text
                .lblDocumentDate.Text = dtpDate.Text
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

                .dTotalCash.Text = dTotalCash.Text
                .dTotalCheck.Text = dTotalChecks.Text
                .dTotalUnreplenish.Text = dTotalUnreplenished.Text
                .dTotalCashAdvances.Text = dTotalCashAdvances.Text
                .dTotalFund.Text = dTotalFund.Text
                .dAccountability.Text = dAccountability.Text
                .dOverage.Text = dOverage.Text
                .txtORLastIssued.Text = txtORLastIssued.Text
                .dtpORLastIssued.Text = If(dtpORLastIssued.CustomFormat = "", "", dtpORLastIssued.Text)
                .txtORDeposited.Text = txtORDeposited.Text
                .dtpORDeposited.Text = If(dtpORDeposited.CustomFormat = "", "", dtpORDeposited.Text)
                .txtORNotIssued.Text = txtORNotIssued.Text
                .dtpORNotIssued.Text = If(dtpORNotIssued.CustomFormat = "", "", dtpORNotIssued.Text)
                .lblRemarks.Text = rExplanation.Text

                .lblPreparedBy.Text = ""
                .lblPreparedPos.Text = ""
                .lblNote.Text = String.Format("I hereby certify that the above fund was counted in presence by {0}, for {1} on {2} and were returned to me INTACT. I further certify that there are no other funds in my possession except for the following :", cbxPreparedBy.Text, Branch, dtpDate.Text)

                Dim Checks As New SubRptCheck With {
                    .DataSource = GridControl2.DataSource
                }
                .subRpt_Check.ReportSource = Checks
                With Checks
                    .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                    .lblDocumentNumber.DataBindings.Add("Text", GridControl2.DataSource, "Document Number")
                    .lblBank.DataBindings.Add("Text", GridControl2.DataSource, "Bank/Check Number")
                    .lblPayor.DataBindings.Add("Text", GridControl2.DataSource, "Payor")
                    .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                End With

                Dim Unreplenished As New SubRptUnreplenished With {
                    .DataSource = GridControl3.DataSource
                }
                .subRpt_Unreplenished.ReportSource = Unreplenished
                With Unreplenished
                    .lblDate.DataBindings.Add("Text", GridControl3.DataSource, "Date")
                    .lblDocumentNumber.DataBindings.Add("Text", GridControl3.DataSource, "Document Number")
                    .lblPayee.DataBindings.Add("Text", GridControl3.DataSource, "Payee/Particular")
                    .lblAmount.DataBindings.Add("Text", GridControl3.DataSource, "Amount")
                End With

                Dim CashAdvance As New SubRptUnreplenished With {
                    .DataSource = GridControl4.DataSource
                }
                .subRpt_CashAdvances.ReportSource = CashAdvance
                With CashAdvance
                    .lblDate.DataBindings.Add("Text", GridControl4.DataSource, "Date")
                    .lblDocumentNumber.DataBindings.Add("Text", GridControl4.DataSource, "Document Number")
                    .lblPayee.DataBindings.Add("Text", GridControl4.DataSource, "Payee/Particular")
                    .lblAmount.DataBindings.Add("Text", GridControl4.DataSource, "Amount")
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
            Generate_CC(True, "", txtCheckedBy.Text)
            Logs("Petty Cash Count", "Print", "[SENSITIVE] Print Petty Cash Count " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CASH COUNT LIST", GridControl1)
            Logs("Petty Cash Count", "Print", "[SENSITIVE] Print Petty Cash Count List", "", "", "", "")
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
            Generate_CC(False, "Blank", txtCheckedBy.Text)
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
        txtORLastIssued.Enabled = False
        dtpORLastIssued.Enabled = False
        txtORDeposited.Enabled = False
        dtpORDeposited.Enabled = False
        txtORNotIssued.Enabled = False
        dtpORNotIssued.Enabled = False
        rExplanation.Enabled = False
        dtpDate.Enabled = False

        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")

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

            LoadCV(ID)
            LoadPettyCash(ID)
            LoadCashAdvance(ID)

            txtORLastIssued.Text = .GetFocusedRowCellValue("Last Issued")
            txtORLastIssued.Tag = .GetFocusedRowCellValue("Last Issued")
            If .GetFocusedRowCellValue("LastORIssuedDate") = "" Then
                dtpORLastIssued.CustomFormat = ""
            Else
                dtpORLastIssued.CustomFormat = "MMMM dd, yyyy"
                dtpORLastIssued.Value = .GetFocusedRowCellValue("LastORIssuedDate")
            End If
            dtpORLastIssued.Tag = .GetFocusedRowCellValue("LastORIssuedDate")
            txtORDeposited.Text = .GetFocusedRowCellValue("Last Deposited")
            txtORDeposited.Tag = .GetFocusedRowCellValue("Last Deposited")
            If .GetFocusedRowCellValue("LastORDepositedDate") = "" Then
                dtpORDeposited.CustomFormat = ""
            Else
                dtpORDeposited.CustomFormat = "MMMM dd, yyyy"
                dtpORDeposited.Value = .GetFocusedRowCellValue("LastORDepositedDate")
            End If
            dtpORDeposited.Tag = .GetFocusedRowCellValue("LastORDepositedDate")
            txtORNotIssued.Text = .GetFocusedRowCellValue("Not Issued")
            txtORNotIssued.Tag = .GetFocusedRowCellValue("Not Issued")
            If .GetFocusedRowCellValue("FirstORNotIssuedDate") = "" Then
                dtpORNotIssued.CustomFormat = ""
            Else
                dtpORNotIssued.CustomFormat = "MMMM dd, yyyy"
                dtpORNotIssued.Value = .GetFocusedRowCellValue("FirstORNotIssuedDate")
            End If
            dtpORNotIssued.Tag = .GetFocusedRowCellValue("FirstORNotIssuedDate")
            rExplanation.Text = .GetFocusedRowCellValue("Remarks")
            rExplanation.Tag = .GetFocusedRowCellValue("Remarks")

            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtCheckedBy.Text = .GetFocusedRowCellValue("Checked By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code_Check = .GetFocusedRowCellValue("OTAC_Check")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        If GridView1.GetFocusedRowCellValue("Voucher_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnCheck.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnCheck.Visible = True
                    btnModify.Enabled = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnModify.Enabled = True
                btnCheck.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CHECKED" Then
            btnCheck.Visible = False
            btnModify.Enabled = False
        End If
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
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

    Private Sub I100_KeyDown(sender As Object, e As KeyEventArgs) Handles i100.KeyDown
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
            txtORLastIssued.Focus()
        End If
    End Sub

    Private Sub TxtORLastIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles txtORLastIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpORLastIssued.Focus()
        End If
    End Sub

    Private Sub DtpORLastIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORLastIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtORDeposited.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpORLastIssued.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtORDeposited_KeyDown(sender As Object, e As KeyEventArgs) Handles txtORDeposited.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpORDeposited.Focus()
        End If
    End Sub

    Private Sub DtpORDeposited_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORDeposited.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtORNotIssued.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpORDeposited.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtORNotIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles txtORNotIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpORNotIssued.Focus()
        End If
    End Sub

    Private Sub DtpORNotIssued_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORNotIssued.KeyDown
        If e.KeyCode = Keys.Enter Then
            rExplanation.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpORNotIssued.CustomFormat = ""
        End If
    End Sub

    Private Sub RExplanation_KeyDown(sender As Object, e As KeyEventArgs) Handles rExplanation.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    Private Sub DtpORLastIssued_Click(sender As Object, e As EventArgs) Handles dtpORLastIssued.Click
        dtpORLastIssued.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpORDeposited_Click(sender As Object, e As EventArgs) Handles dtpORDeposited.Click
        dtpORDeposited.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpORNotIssued_Click(sender As Object, e As EventArgs) Handles dtpORNotIssued.Click
        dtpORNotIssued.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub TxtORLastIssued_Leave(sender As Object, e As EventArgs) Handles txtORLastIssued.Leave
        txtORLastIssued.Text = ReplaceText(txtORLastIssued.Text)
    End Sub

    Private Sub TxtORDeposited_Leave(sender As Object, e As EventArgs) Handles txtORDeposited.Leave
        txtORDeposited.Text = ReplaceText(txtORDeposited.Text)
    End Sub

    Private Sub TxtORNotIssued_Leave(sender As Object, e As EventArgs) Handles txtORNotIssued.Leave
        txtORNotIssued.Text = ReplaceText(txtORNotIssued.Text)
    End Sub

    Private Sub RExplanation_Leave(sender As Object, e As EventArgs) Handles rExplanation.Leave
        rExplanation.Text = ReplaceText(rExplanation.Text)
    End Sub

    Private Sub TotalFund(sender As Object, e As EventArgs) Handles dTotalCash.ValueChanged, dTotalChecks.ValueChanged, dTotalUnreplenished.ValueChanged, dTotalCashAdvances.ValueChanged
        dTotalFund.Value = dTotalCash.Value + dTotalChecks.Value + dTotalUnreplenished.Value + dTotalCashAdvances.Value
    End Sub

    Private Sub Overage(sender As Object, e As EventArgs) Handles dTotalFund.ValueChanged, dAccountability.ValueChanged
        dOverage.Value = dTotalFund.Value - dAccountability.Value
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
                .btnResend.Visible = True
                .btnAttachments.Visible = True
                .OTP = Code_Check
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            DataObject(String.Format("UPDATE cash_count SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                            Logs("Cash Count", "Check", String.Format("Checked Cash Count for {0} with the total amount of {1}. [Via OTAC]", Branch & " - " & txtDocumentNumber.Text, dTotalFund.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!", MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                ElseIf Result = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Cash Count with the amount of {1} prepared by {2}." & vbCrLf, Code_Check, dTotalFund.Text, cbxPreparedBy.Text)
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
                        Subject = "One Time Authorization Code " & Code_Check & " [" & txtDocumentNumber.Text & "]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CC(False, FName, txtCheckedBy.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    Cursor = Cursors.Default
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to check this Cash Count?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE cash_count SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID, Code))
                Logs("Cash Count", "Check", String.Format("Checked Cash Count for {0} with the total amount of {1}.", Branch & " - " & txtDocumentNumber.Text, dTotalFund.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
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
                    If GridView3.GetRowCellValue(selectedRowHandle, "Payee/Particular").ToString.Contains("[PCR-") Then
                        Exit Sub
                    End If
                    DT_PCV.Rows.RemoveAt(selectedRowHandle)
                    GoTo Here
                End If
            Next
        Else
            If GridView3.GetFocusedRowCellValue("Payee/Particular").ToString.Contains("[PCR-") Then
                MsgBox("Petty Cash is already Replenished, removing is not allowed.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            DT_PCV.Rows.RemoveAt(GridView3.FocusedRowHandle)
        End If

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView3.RowCount - 1
            TotalPetty += If(GridView3.GetRowCellValue(x, "Amount").ToString = "", 0, GridView3.GetRowCellValue(x, "Amount"))
        Next
        dTotalUnreplenished.Value = TotalPetty

        If GridView3.RowCount > 15 Then
            GridColumn19.Width = 697 - 17
        Else
            GridColumn19.Width = 697
        End If
    End Sub

    Private Sub IAddCash_Click(sender As Object, e As EventArgs) Handles iAddCash.Click
        Dim Collection As New FrmAddCashCount
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView3.RowCount - 1
            ExcludeID &= "'" & GridView3.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Collection
            .From_PettyCash = True
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
                            DT_PCV.Rows.Add(.GridView3.GetRowCellValue(selectedRowHandle, "ID"), .GridView3.GetRowCellValue(selectedRowHandle, "Date"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Number"), .GridView3.GetRowCellValue(selectedRowHandle, "Payee/Particular"), .GridView3.GetRowCellValue(selectedRowHandle, "Amount"))
                        End If
                    Next
                Else
                    DT_PCV.Rows.Add(.GridView3.GetFocusedRowCellValue("ID"), .GridView3.GetFocusedRowCellValue("Date"), .GridView3.GetFocusedRowCellValue("Document Number"), .GridView3.GetFocusedRowCellValue("Payee/Particular"), .GridView3.GetFocusedRowCellValue("Amount"))
                End If
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            Dim TotalPetty As Double
            For x As Integer = 0 To GridView3.RowCount - 1
                TotalPetty += If(GridView3.GetRowCellValue(x, "Amount").ToString = "", 0, GridView3.GetRowCellValue(x, "Amount"))
            Next
            dTotalUnreplenished.Value = TotalPetty
            .Dispose()
        End With

        If GridView3.RowCount > 15 Then
            GridColumn19.Width = 697 - 17
        Else
            GridColumn19.Width = 697
        End If
    End Sub

    Private Sub IRemoveCashAdvance_Click(sender As Object, e As EventArgs) Handles iRemoveCashAdvance.Click
        If GridView4.RowCount = 0 Then
            Exit Sub
        End If

Here:
        Dim selectedRowHandles As Integer() = GridView4.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim I As Integer
            'Dim Docs As String
            For I = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(I)
                If (selectedRowHandle >= 0) Then
                    DT_CAS.Rows.RemoveAt(selectedRowHandle)
                    GoTo Here
                End If
            Next
        Else
            DT_CAS.Rows.RemoveAt(GridView4.FocusedRowHandle)
        End If

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView4.RowCount - 1
            TotalPetty += If(GridView4.GetRowCellValue(x, "Amount").ToString = "", 0, GridView4.GetRowCellValue(x, "Amount"))
        Next
        dTotalCashAdvances.Value = TotalPetty

        If GridView4.RowCount > 5 Then
            GridColumn26.Width = 697 - 17
        Else
            GridColumn26.Width = 697
        End If
    End Sub

    Private Sub IAddCashAdvance_Click(sender As Object, e As EventArgs) Handles iAddCashAdvance.Click
        Dim Collection As New FrmAddCashCount
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView4.RowCount - 1
            ExcludeID &= "'" & GridView4.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Collection
            .From_PettyCash = False
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
                            DT_CAS.Rows.Add(.GridView3.GetRowCellValue(selectedRowHandle, "ID"), .GridView3.GetRowCellValue(selectedRowHandle, "Date"), .GridView3.GetRowCellValue(selectedRowHandle, "Document Number"), .GridView3.GetRowCellValue(selectedRowHandle, "Payee/Particular"), .GridView3.GetRowCellValue(selectedRowHandle, "Amount"))
                        End If
                    Next
                Else
                    DT_CAS.Rows.Add(.GridView3.GetFocusedRowCellValue("ID"), .GridView3.GetFocusedRowCellValue("Date"), .GridView3.GetFocusedRowCellValue("Document Number"), .GridView3.GetFocusedRowCellValue("Payee/Particular"), .GridView3.GetFocusedRowCellValue("Amount"))
                End If
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            Dim TotalPetty As Double
            For x As Integer = 0 To GridView4.RowCount - 1
                TotalPetty += If(GridView4.GetRowCellValue(x, "Amount").ToString = "", 0, GridView4.GetRowCellValue(x, "Amount"))
            Next
            dTotalCashAdvances.Value = TotalPetty
            .Dispose()
        End With

        If GridView4.RowCount > 5 Then
            GridColumn26.Width = 697 - 17
        Else
            GridColumn26.Width = 697
        End If
    End Sub

    Private Sub IAddCheckVoucher_Click(sender As Object, e As EventArgs) Handles iAddCheckVoucher.Click
        Dim Collection As New FrmAddCheckVoucher
        Dim ExcludeID As String = ""
        For x As Integer = 0 To GridView2.RowCount - 1
            ExcludeID &= "'" & GridView2.GetRowCellValue(x, "Document Number") & "',"
        Next
        With Collection
            If ExcludeID = "" Then
            Else
                .ExcludeID = ExcludeID.Substring(0, ExcludeID.Length - 1)
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim selectedRowHandles As Integer() = .GridView2.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    Dim Docs As String = ""
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            DT_CV.Rows.Add(.GridView2.GetRowCellValue(selectedRowHandle, "ID"), .GridView2.GetRowCellValue(selectedRowHandle, "Date"), .GridView2.GetRowCellValue(selectedRowHandle, "Document Number"), .GridView2.GetRowCellValue(selectedRowHandle, "Bank/Check Number"), .GridView2.GetRowCellValue(selectedRowHandle, "Payor"), .GridView2.GetRowCellValue(selectedRowHandle, "Amount"))
                        End If
                    Next
                Else
                    DT_CV.Rows.Add(.GridView2.GetFocusedRowCellValue("ID"), .GridView2.GetFocusedRowCellValue("Date"), .GridView2.GetFocusedRowCellValue("Document Number"), .GridView2.GetFocusedRowCellValue("Bank/Check Number"), .GridView2.GetFocusedRowCellValue("Payor"), .GridView2.GetFocusedRowCellValue("Amount"))
                End If
                MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            End If
            Dim TotalPetty As Double
            For x As Integer = 0 To GridView2.RowCount - 1
                TotalPetty += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
            Next
            dTotalChecks.Value = TotalPetty
            .Dispose()
        End With

        If GridView2.RowCount > 3 Then
            GridColumn17.Width = 450 - 17
        Else
            GridColumn17.Width = 450
        End If
    End Sub

    Private Sub IRemoveCheckVoucher_Click(sender As Object, e As EventArgs) Handles iRemoveCheckVoucher.Click
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
                    DT_CV.Rows.RemoveAt(selectedRowHandle)
                    GoTo Here
                End If
            Next
        Else
            DT_CV.Rows.RemoveAt(GridView2.FocusedRowHandle)
        End If

        Dim TotalPetty As Double
        For x As Integer = 0 To GridView2.RowCount - 1
            TotalPetty += If(GridView2.GetRowCellValue(x, "Amount").ToString = "", 0, GridView2.GetRowCellValue(x, "Amount"))
        Next
        dTotalChecks.Value = TotalPetty

        If GridView2.RowCount > 3 Then
            GridColumn17.Width = 450 - 17
        Else
            GridColumn17.Width = 450
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            End If
        End If
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetDocumentNumber()
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('PCC-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM cash_count WHERE branch_id = '{0}' AND YEAR(Trans_Date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        If GridView3.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Payee As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Payee/Particular"))
            If Payee.ToString.Contains("[PCR-") Then
                e.Appearance.ForeColor = Color.SeaGreen
            End If
        End If
    End Sub
End Class