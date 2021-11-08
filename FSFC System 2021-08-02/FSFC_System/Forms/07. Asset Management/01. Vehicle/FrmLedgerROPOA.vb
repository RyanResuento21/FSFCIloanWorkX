Public Class FrmLedgerROPOA 

    Dim LedgerCode As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public ROPOA_Type As String
    Public AssetNumber As String
    Public ROPOA_Status As String
    Public MultipleA As Boolean
    Public ROPOA_Ref As String

    Private Sub FrmLedger_ROPOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpDate.Value = Date.Now
        With cbxTransaction
            .ValueMember = "ID"
            .DisplayMember = "Transaction"
            If ROPOA_Type = "Vehicle" Then
                .DataSource = DataSource("SELECT ID, `Transaction` FROM ledger_transaction WHERE `status` = 'ACTIVE' AND `Type` IN ('RE & VE','VE') ORDER BY `Transaction`;")
            Else
                .DataSource = DataSource("SELECT ID, `Transaction` FROM ledger_transaction WHERE `status` = 'ACTIVE' AND `Type` IN ('RE & VE','RE') ORDER BY `Transaction`;")
            End If
            .SelectedIndex = -1
        End With

        SuperTabControl1.SelectedTab = tabList_2

        If User_Type <> "ADMIN" And ROPOA_Status <> "Sell" Then
            tabSetup.Visible = False
            btnAdd.Enabled = False
            btnBack.Enabled = False
        End If
        If vUpdate Then
            GridColumn3.OptionsColumn.AllowEdit = True
        End If
        If GridView2.RowCount = 0 Then
            If ROPOA_Type = "Vehicle" Then
                dtpDate.Value = FrmVehicleROPOA.dtpDate.Value
            Else
                dtpDate.Value = FrmRealEstateROPOA.dtpDate.Value
            End If
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX14, LabelX43, LabelX16, LabelX3, LabelX1, LabelX15})

            GetTextBoxFontSettings({txtReference})

            GetCheckBoxFontSettings({cbxAdd, cbxDeduct})

            GetComboBoxFontSettings({cbxTransaction})

            GetDateTimeInputFontSettings({dtpDate})

            GetDoubleInputFontSettings({dAmount})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnApproved})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Ledger ROPA - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Ledger", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ledger_code, ropoa_type, DATE_FORMAT(trans_date,'%b.%d.%Y') AS 'Date', `Transaction`, Remarks, reference_number AS 'Reference No.', IF(`Type` = 'Gain' OR `Type` = 'Loss' OR `Type` = 'Deleted','',IF(`Type` = 'R Gain', 'Add',IF(`Type` = 'R Loss', 'Add', `Type`))) AS 'Type', Amount, 0 AS 'Total', approve_status AS 'Approved Status', `timestamp`, 1 AS 'Start', trans_date FROM ledger_ropoa WHERE `status` = 'ACTIVE' AND asset_number = '{0}' AND approve_status != 'DISAPPROVED' AND `Transaction` = 'Balance Transferred' UNION ALL SELECT ID, ledger_code, ropoa_type, DATE_FORMAT(trans_date,'%b.%d.%Y') AS 'Date', `Transaction`, Remarks, reference_number AS 'Reference No.', IF(`Type` = 'Gain' OR `Type` = 'Loss' OR `Type` = 'Deleted','',IF(`Type` = 'R Gain', 'Add',IF(`Type` = 'R Loss', 'Add', `Type`))) AS 'Type', Amount, 0 AS 'Total', approve_status AS 'Approved Status', `timestamp`, 2 AS 'Start', trans_date FROM ledger_ropoa WHERE `status` = 'ACTIVE' AND asset_number = '{0}' AND approve_status != 'DISAPPROVED' AND `Transaction` != 'Balance Transferred' ORDER BY `trans_date` ASC, `Start`, ledger_code;", AssetNumber))
        Dim Gain As Double
        Dim DateFrom As Date
        Dim DateTo As Date
        For x As Integer = 0 To DT.Rows.Count - 1
            If DT(x)("Transaction") = "Gain on Sale" Then
                If DateFrom = Nothing Then
                    DateFrom = DT(x)("timestamp")
                End If
                Gain += CDbl(DT(x)("Amount"))
                DateTo = DT(x)("timestamp")
            End If

            If x = 0 Then
                If DT(x)("Type") = "Add" And DT(x)("Approved Status") = "APPROVED" Then
                    DT(x)("Total") = FormatNumber(CDbl(DT(x)("Amount")), 2)
                ElseIf DT(x)("Type") = "Deduct" And DT(x)("Approved Status") = "APPROVED" Then
                    DT(x)("Total") = FormatNumber(0 - CDbl(DT(x)("Amount")), 2)
                Else
                    DT(x)("Total") = FormatNumber(0, 2)
                End If
            Else
                If DT(x)("Type") = "Add" And DT(x)("Approved Status") = "APPROVED" Then
                    If Gain > 0 And DT(x)("timestamp") >= DateFrom And Gain >= CDbl(DT(x)("Amount")) Then
                        DT(x)("Total") = FormatNumber(0, 2)
                    ElseIf Gain > 0 And DT(x)("timestamp") >= DateFrom And Gain < CDbl(DT(x)("Amount")) Then
                        DT(x)("Total") = FormatNumber(CDbl(DT(x)("Amount")) - Gain, 2)
                    Else
                        DT(x)("Total") = FormatNumber(CDbl(DT(x - 1)("Total")) + CDbl(DT(x)("Amount")), 2)
                    End If

                    If Gain > 0 And DT(x)("Transaction") = "Reverse Gain on Sale" And DT(x)("timestamp") >= DateFrom Then
                        Gain -= CDbl(DT(x)("Amount"))
                    End If
                ElseIf DT(x)("Type") = "Deduct" And DT(x)("Approved Status") = "APPROVED" Then
                    DT(x)("Total") = FormatNumber(CDbl(DT(x - 1)("Total")) - CDbl(DT(x)("Amount")), 2)
                Else
                    If DT(x)("Transaction") = "Loss on Sale" Then
                        DT(x)("Total") = FormatNumber(0, 2)
                    Else
                        DT(x)("Total") = FormatNumber(CDbl(DT(x - 1)("Total")), 2)
                    End If
                End If
            End If
        Next

        GridControl2.DataSource = DT
        GridView2.Columns("Remarks").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Remarks").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
    End Sub

    '***KEYDOWN
    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTransaction.Focus()
        End If
    End Sub

    Private Sub CbxTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTransaction.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference.Focus()
        End If
    End Sub

    Private Sub TxtReference_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAdd.Focus()
        End If
    End Sub

    Private Sub CbxAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDeduct.Focus()
        End If
    End Sub

    Private Sub CbxDeduct_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDeduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text.Trim)
    End Sub

    Private Sub CbxTransaction_Leave(sender As Object, e As EventArgs) Handles cbxTransaction.Leave
        cbxTransaction.Text = ReplaceText(cbxTransaction.Text.Trim)
    End Sub

    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = ReplaceText(txtReference.Text.Trim)
    End Sub
    '***LEAVE

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList_2
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
            btnRefresh.Enabled = True
            btnModify.Enabled = False
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear()
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        PanelEx10.Enabled = True
        dtpDate.Value = Date.Now
        txtRemarks.Text = ""
        txtReference.Text = ""
        dAmount.Value = 0
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        LoadData()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If User_Type = "ADMIN" Then
            If cbxTransaction.Text = "" Then
                MsgBox("Please select transaction.", MsgBoxStyle.Information, "Info")
                cbxTransaction.DroppedDown = True
                Exit Sub
            End If
        Else
            If cbxTransaction.Text = "" Or cbxTransaction.SelectedIndex = -1 Then
                MsgBox("Please select transaction.", MsgBoxStyle.Information, "Info")
                cbxTransaction.DroppedDown = True
                Exit Sub
            End If
        End If
        If txtReference.Text = "" And cbxTransaction.Text.ToUpper <> "Note".ToUpper Then
            MsgBox("Please fill reference number field.", MsgBoxStyle.Information, "Info")
            txtReference.Focus()
            Exit Sub
        End If
        If cbxAdd.Checked = False And cbxDeduct.Checked = False And cbxTransaction.Text.ToUpper <> "Note".ToUpper Then
            If MsgBoxYes("You haven't set type of ledger, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxTransaction.Text.ToUpper = "Balance Transferred".ToUpper Then
            Dim BalanceT_Stat As String
            If btnSave.Text = "&Save" Then
                BalanceT_Stat = DataObject(String.Format("SELECT approve_status FROM ledger_ropoa WHERE `Transaction` = 'Balance Transferred' AND (approve_status = 'APPROVED' OR approve_status = 'PENDING') AND `status` = 'ACTIVE' AND asset_number = '{0}'", AssetNumber))
            Else
                BalanceT_Stat = DataObject(String.Format("SELECT approve_status FROM ledger_ropoa WHERE `Transaction` = 'Balance Transferred' AND (approve_status = 'APPROVED' OR approve_status = 'PENDING') AND `status` = 'ACTIVE' AND asset_number = '{0}' AND ledger_code != '{1}'", AssetNumber, LedgerCode))
            End If
            If BalanceT_Stat = "APPROVED" Then
                MsgBox("ROPOA Already have an approved balance transfer.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf BalanceT_Stat = "PENDING" Then
                MsgBox("ROPOA Already have an balance transfer waiting for approval.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        If cbxTransaction.Text.ToUpper = "Note".ToUpper Then
            If txtRemarks.Text = "" Then
                MsgBox("Please fill the remarks for notes purposes.", MsgBoxStyle.Information, "Info")
                txtRemarks.Focus()
                Exit Sub
            End If
        End If

        If dAmount.Value = 0 Then
            If cbxTransaction.Text.ToUpper = "Balance Transferred".ToUpper Then
                MsgBox("Balance Transferred cannot be zero in amount, please fill amount field.", MsgBoxStyle.Information, "Info")
                dAmount.Focus()
                Exit Sub
            Else
                If MsgBoxYes("You haven't set amount, would you like to proceed?") = MsgBoxResult.No Then
                    dAmount.Focus()
                    Exit Sub
                End If
            End If
        End If

        Dim Type As String = ""
        If cbxAdd.Checked Then
            Type = "Add"
        ElseIf cbxDeduct.Checked Then
            Type = "Deduct"
        End If

        Dim ApproveStat As String = "APPROVED"
        Dim ApproveDate As String = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
        If dAmount.Value >= AmountLimit And cbxTransaction.Text.ToUpper <> "Note".ToUpper Then
            ApproveStat = "PENDING"
            ApproveDate = "0000-00-00 00:00:00"
        End If

        If cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper And cbxDeduct.Checked And ROPOA_Type = "Vehicle" And FrmVehicleROPOA.lblSold.Text <> "SCRAP" Then
            If CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber))) - dAmount.Value < 0 Then
                MsgBox("Impairment Loss is higher than the book value, please check your data.", MsgBoxStyle.Information, "Info")
                dAmount.Focus()
                Exit Sub
            End If
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ledger_ropoa WHERE `reference_number` = '{0}' AND `status` = 'ACTIVE' AND asset_number = '{1}'", txtReference.Text, AssetNumber))
                If Exist > 0 And cbxTransaction.Text.ToUpper <> "Note".ToUpper Then
                    MsgBox(String.Format("Reference number {0} already exist, Please check your data.", txtReference.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))

                Dim SQL As String = "INSERT INTO ledger_ropoa SET"
                SQL &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                SQL &= String.Format(" asset_number = '{0}', ", AssetNumber)
                SQL &= String.Format(" ropoa_type = '{0}', ", ROPOA_Type)
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" trans_id = '{0}', ", ValidateComboBox(cbxTransaction))
                SQL &= String.Format(" `transaction` = '{0}', ", cbxTransaction.Text)
                SQL &= String.Format(" remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" `reference_number` = '{0}', ", txtReference.Text)
                SQL &= String.Format(" `type` = '{0}', ", Type)
                SQL &= String.Format(" amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" user_code = '{0}', ", User_Code)
                SQL &= String.Format(" approve_status = '{0}', ", ApproveStat)
                SQL &= String.Format(" ropoa_ref = '{0}', ", If(MultipleA, ROPOA_Ref, ""))
                SQL &= " approved_by_code = '', "
                SQL &= " approved_by = '', "
                SQL &= String.Format(" approved_date = '{0}', ", ApproveDate)
                SQL &= " approved_remarks = '', entry_type = 'Manual';"

                'INSERT ACCOUNTING ENTRY ********************************************************************************************
                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" JVNum = '{0}', ", txtReference.Text)
                SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", AssetNumber)
                SQL &= " EntryType = 'DEBIT',"
                SQL &= String.Format(" AccountCode = '{0}', ", If(ROPOA_Type = "Vehicle", "126002", "126001")) 'ROPOA ENTRY
                SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(ROPOA_Type = "Vehicle", "126002", "126001")))) 'ROPOA ENTRY
                SQL &= String.Format(" Payable = '{0}', ", dAmount.Value)
                SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" PaidFor = '{0}', ", "ROPOA")
                SQL &= String.Format(" Remarks = '{0}', ", "ROPOA")
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                'INSERT ACCOUNTING ENTRY ********************************************************************************************

                If ApproveStat = "APPROVED" And cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper And cbxDeduct.Checked And ROPOA_Type = "Vehicle" And FrmVehicleROPOA.lblSold.Text <> "SCRAP" Then
                    If CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber))) - dAmount.Value <= 0 Then
                        If MsgBoxYes("This transaction will set the ROPOA to scrap for the reason that the book value will be zero. Would you like to proceed?") = MsgBoxResult.Yes Then
                            SQL &= String.Format("UPDATE ropoa_vehicle SET price = 0, sell_status = 'SCRAP' WHERE PlateNum = '{0}';", ROPOA_Ref)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                DataObject(SQL)
                If ApproveStat = "APPROVED" And cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper And cbxDeduct.Checked And ROPOA_Type = "Vehicle" And FrmVehicleROPOA.lblSold.Text <> "SCRAP" Then
                    With FrmVehicleROPOA
                        .LoadData()
                        .LoadScrap()
                    End With
                End If

                Logs("Ledger", "Save", String.Format("Add new transaction {0} for ropoa {1}", cbxTransaction.Text, AssetNumber), "", "", "", "")
                Clear()
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ledger_ropoa WHERE `reference_number` = '{0}' AND `status` = 'ACTIVE' AND ledger_code != '{1}' AND asset_number = '{2}'", txtReference.Text, LedgerCode, AssetNumber))
                If Exist > 0 And cbxTransaction.Text.ToUpper <> "Note".ToUpper Then
                    MsgBox(String.Format("Reference number {0} already exist, Please check your data.", txtReference.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim SQL As String = "UPDATE ledger_ropoa SET"
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" trans_id = '{0}', ", ValidateComboBox(cbxTransaction))
                SQL &= String.Format(" `transaction` = '{0}', ", cbxTransaction.Text)
                SQL &= String.Format(" remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" `reference_number` = '{0}', ", txtReference.Text)
                SQL &= String.Format(" `type` = '{0}', ", Type)
                SQL &= String.Format(" amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" approve_status = '{0}', ", ApproveStat)
                SQL &= String.Format(" ropoa_ref = '{0}', ", If(MultipleA, ROPOA_Ref, ""))
                SQL &= " approved_by_code = '', "
                SQL &= " approved_by = '', "
                SQL &= String.Format(" approved_date = '{0}', ", ApproveDate)
                SQL &= " approved_remarks = '' "
                SQL &= String.Format(" WHERE ledger_code = '{0}';", LedgerCode)

                'INSERT ACCOUNTING ENTRY ********************************************************************************************
                SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE JVNum = '{0}' AND ReferenceN = '{1}' AND Amount = '{2}';", txtReference.Tag, AssetNumber, CDbl(dAmount.Tag))
                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" JVNum = '{0}', ", txtReference.Text)
                SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" ReferenceN = '{0}', ", AssetNumber)
                SQL &= " EntryType = 'DEBIT',"
                SQL &= String.Format(" AccountCode = '{0}', ", If(ROPOA_Type = "Vehicle", "126002", "126001")) 'ROPOA ENTRY
                SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(ROPOA_Type = "Vehicle", "126002", "126001"))))  'ROPOA ENTRY
                SQL &= String.Format(" Payable = '{0}', ", dAmount.Value)
                SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" PaidFor = '{0}', ", "ROPOA")
                SQL &= String.Format(" Remarks = '{0}', ", "ROPOA")
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                'INSERT ACCOUNTING ENTRY ********************************************************************************************

                If ApproveStat = "APPROVED" And cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper And cbxDeduct.Checked And ROPOA_Type = "Vehicle" And FrmVehicleROPOA.lblSold.Text <> "SCRAP" Then
                    If CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber))) - dAmount.Value <= 0 Then
                        If MsgBoxYes("This transaction will set the ROPOA to scrap for the reason that the book value will be zero. Would you like to proceed?") = MsgBoxResult.Yes Then
                            SQL &= String.Format("UPDATE ropoa_vehicle SET price = 0, sell_status = 'SCRAP' WHERE PlateNum = '{0}';", ROPOA_Ref)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                DataObject(SQL)
                If ApproveStat = "APPROVED" And cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper And cbxDeduct.Checked And ROPOA_Type = "Vehicle" And FrmVehicleROPOA.lblSold.Text <> "SCRAP" Then
                    With FrmVehicleROPOA
                        .LoadData()
                        .LoadScrap()
                    End With
                End If

                Logs("Ledger", "Update", String.Format("Update transaction {0} for ropoa {1}", cbxTransaction.Text, AssetNumber), Changes(), "", "", "")
                Clear()
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If Format(dtpDate.Value, "MMM.dd.yyyy") = dtpDate.Tag Then
            Else
                Change &= String.Format("Change Date from {0} to {1}. ", dtpDate.Tag, FormatDatePicker(dtpDate))
            End If
            If cbxTransaction.Text = cbxTransaction.Tag Then
            Else
                Change &= String.Format("Change Transaction from {0} to {1}. ", cbxTransaction.Tag, cbxTransaction.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
            If txtReference.Text = txtReference.Tag Then
            Else
                Change &= String.Format("Change Reference from {0} to {1}. ", txtReference.Tag, txtReference.Text)
            End If
            If cbxAdd.Tag <> "Add" And cbxAdd.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxAdd.Tag, cbxAdd.Text)
            ElseIf cbxDeduct.Tag <> "Deduct" And cbxDeduct.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxDeduct.Tag, cbxDeduct.Text)
            End If
            If dAmount.Value = dAmount.Tag Then
            Else
                Change &= String.Format("Change Amount from {0} to {1}. ", dAmount.Tag, dAmount.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Ledger ROPA - Changes", ex.Message.ToString)
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

            DataObject(String.Format("UPDATE ledger_ropoa SET `status` = 'DELETED' WHERE ledger_code = '{0}'", LedgerCode))
            Logs("Ledger", "Cancel", Reason, String.Format("Cancel ledger transaction {0} with reference {1} for ropoa {2}", cbxTransaction.Text, txtReference.Text, AssetNumber), "", "", "")
            Clear()
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim phf As DevExpress.XtraPrinting.PageHeaderFooter = FrmROPOARepricing.PrintingSys.PageHeaderFooter
        With phf
            .Header.Content.Clear()
            .Header.Content.AddRange(New String() {"[Image 0]", "ROPOA LEDGER", AssetNumber})
            .Footer.Content.Clear()
            .Footer.Content.AddRange(New String() {"", "", "Page : [Page # of Pages #]"})
            .Footer.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
        End With

        With FrmROPOARepricing
            .PrintingSys.Component = GridControl2
            .PrintingSys.CreateDocument()

            .PrintingSys.ShowPreview()
        End With
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        If User_Type <> "ADMIN" And ROPOA_Status <> "Sell" Then
            Exit Sub
        End If
        With GridView2
            If .GetFocusedRowCellValue("Approved Status") = "APPROVED" Then
                If MsgBoxYes("Transaction is already APPROVED, changes might change the transaction status and will require an approval again, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            PanelEx10.Enabled = False
            LedgerCode = .GetFocusedRowCellValue("ledger_code")
            dtpDate.Text = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            cbxTransaction.Text = .GetFocusedRowCellValue("Transaction")
            cbxTransaction.Tag = .GetFocusedRowCellValue("Transaction")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            txtReference.Text = .GetFocusedRowCellValue("Reference No.")
            txtReference.Tag = .GetFocusedRowCellValue("Reference No.")
            cbxAdd.Checked = False
            cbxDeduct.Checked = False
            If .GetFocusedRowCellValue("Type") = "Add" Then
                cbxAdd.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "Deduct" Then
                cbxDeduct.Checked = True
            End If
            cbxAdd.Tag = .GetFocusedRowCellValue("Type")
            cbxDeduct.Tag = .GetFocusedRowCellValue("Type")
            dAmount.Value = .GetFocusedRowCellValue("Amount")
            dAmount.Tag = .GetFocusedRowCellValue("Amount")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd.CheckedChanged
        If cbxAdd.Checked Then
            cbxDeduct.Checked = False
        End If
    End Sub

    Private Sub CbxDeduct_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct.CheckedChanged
        If cbxDeduct.Checked Then
            cbxAdd.Checked = False
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Approved Status"))
            Dim Transaction As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Transaction"))
            If Status = "PENDING" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            Else
                e.Appearance.ForeColor = Color.Black
            End If
            If Transaction.ToUpper = "Note".ToUpper Then
                e.Appearance.ForeColor = Color.Blue
            End If
            'End If
        End If
    End Sub

    Private Sub BtnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        Dim Approved As New FrmLedgerApproved
        With Approved
            .LedgerCode = GridView2.GetFocusedRowCellValue("ledger_code")
            .Reference = GridView2.GetFocusedRowCellValue("Reference No.")
            .Amount = GridView2.GetFocusedRowCellValue("Amount")
            .AssetNumber = AssetNumber
            .Transaction = GridView2.GetFocusedRowCellValue("Transaction")
            .Remarks = GridView2.GetFocusedRowCellValue("Remarks")
            .Type = GridView2.GetFocusedRowCellValue("Type")
            If GridView2.GetFocusedRowCellValue("Transaction") = "Discount" Then
                Dim MultipleA As Boolean = DataObject(String.Format("SELECT IF(account_count > 1,TRUE,FALSE) FROM {1} WHERE AssetNumber = '{0}';", AssetNumber, If(ROPOA_Type = "Vehicle", "ropoa_vehicle", "ropoa_realestate")))
                If MultipleA Then
                    .TransactioNo = DataObject(String.Format("SELECT SOLD_ID FROM ledger_ropoa WHERE ledger_code = '{0}'", GridView2.GetFocusedRowCellValue("ledger_code")))
                    .SellingP = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE transaction_no = '{0}' AND `status` = 'ACTIVE'", Approved.TransactioNo))
                Else
                    .SellingP = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE asset_no = '{0}' AND `status` = 'ACTIVE'", AssetNumber))
                End If
                .MultipleA = MultipleA
            End If
            If .ShowDialog = DialogResult.OK Then
                Close()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxTransaction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTransaction.SelectedIndexChanged
        If cbxTransaction.Text.ToUpper = "Balance Transferred".ToUpper Then
            cbxAdd.Checked = True
            cbxAdd.Enabled = False
            cbxDeduct.Enabled = False
        ElseIf cbxTransaction.Text.ToUpper = "Note".ToUpper Then
            cbxAdd.Checked = False
            cbxAdd.Enabled = False
            cbxDeduct.Checked = False
            cbxDeduct.Enabled = False
        ElseIf cbxTransaction.Text.ToUpper = "Impairment Loss".ToUpper Then
            cbxAdd.Enabled = True
            cbxDeduct.Checked = True
            cbxDeduct.Enabled = True
        Else
            cbxAdd.Enabled = True
            cbxDeduct.Enabled = True
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM ledger_ropoa WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID")))
            If GridView2.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this from {1} ledger to {0}?", GridView2.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                  DataObject(String.Format("UPDATE ledger_ropoa SET remarks = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), GridView2.GetFocusedRowCellValue("Remarks")))
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub
End Class