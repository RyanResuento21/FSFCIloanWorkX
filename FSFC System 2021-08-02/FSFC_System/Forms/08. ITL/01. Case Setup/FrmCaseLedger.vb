Public Class FrmCaseLedger

    ReadOnly ID As Integer
    Public CaseNumber As String
    Public CaseID As Integer
    Public CategoryID As Integer
    Private Sub FrmCaseLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpDate.Value = Date.Now

        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX14, LabelX43, LabelX3, LabelX15, LabelX1, LabelX16, LabelX7, LabelX2, LabelX6, LabelX24, LabelX5, LabelX8, LabelX4, LabelX9, LabelX10})

            GetLabelWithBackgroundFontSettings({lblTaxes, lblAttorneysFee, lblOthers, LabelX12})

            GetTextBoxFontSettings({txtReference, txtDefendant, txtCollateral, txtCaseNumber, txtAccountNumber, txtMobileNumber})

            GetCheckBoxFontSettings({cbxAdd, cbxDeduct})

            GetComboBoxFontSettings({cbxTransaction})

            GetDateTimeInputFontSettings({dtpDate, dtpDateFilled, dtpDueRP})

            GetRickTextBoxFontSettings({txtRemarks})

            GetDoubleInputFontSettings({dAmount, dTaxes, dAttorneysFee, dOthers, dBookValue, dDecisionValue})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})

            GetGroupControlFontSettings({GroupControl2})
        Catch ex As Exception
            TriggerBugReport("Case Ledger - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Case Ledger", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT "
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(IF(ORDate = '',TimeStamp,ORDate), '%M %d, %Y') AS 'Date',"
        SQL &= "    IF(PaidFor = 'Balance Transferred',PaidFor,AccountTitleCode(AccountCode)) AS 'Transaction',"
        SQL &= "    Remarks,"
        SQL &= "    IF(CVNumber = '',IF(ORNum = '',IF(CVNum = '',IF(JVNum = '','',JVNum),CVNum),ORNum),CVNumber) AS 'Reference Number',"
        SQL &= "    IF(EntryType = 'DEBIT',IF(AccountTitleCode(AccountCode) LIKE '%Items in Litigation%','Add',''),IF(AccountTitleCode(AccountCode) LIKE '%Items in Litigation%' AND EntryType = 'CREDIT','Deduct','')) AS 'Type',"
        SQL &= "    Amount AS 'Amount',"
        SQL &= "    '' AS 'Running Balance', timestamp, "
        SQL &= "    PostStatus"
        SQL &= String.Format("  FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND ReferenceN = '{0}' AND MotherCode != '111000' AND IF(EntryType = 'DEBIT',MotherCode != '217200',TRUE) ORDER BY DATE(`Date`), ID;", CaseNumber)
        Dim DT As DataTable = DataSource(SQL)
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
                DT(x)("Running Balance") = FormatNumber(CDbl(DT(x)("Amount")), 2)
            Else
                If DT(x)("Type") = "Add" Then
                    DT(x)("Running Balance") = FormatNumber(CDbl(DT(x - 1)("Running Balance")) + CDbl(DT(x)("Amount")), 2)
                ElseIf DT(x)("Type") = "Deduct" Then
                    If CDbl(DT(x - 1)("Running Balance")) >= CDbl(DT(x)("Amount")) Then
                        DT(x)("Running Balance") = FormatNumber(CDbl(DT(x - 1)("Running Balance")) - CDbl(DT(x)("Amount")), 2)
                    Else
                        DT(x)("Running Balance") = FormatNumber(0, 2)
                    End If
                Else
                    DT(x)("Running Balance") = FormatNumber(CDbl(DT(x - 1)("Running Balance")), 2)
                End If
            End If
        Next

        GridControl2.DataSource = DT
    End Sub

#Region "Keydown"
    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTransaction.Focus()
        End If
    End Sub

    Private Sub CbxTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTransaction.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference.Focus()
        End If
    End Sub

    Private Sub TxtReference_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dTaxes.Visible Then
                dTaxes.Focus()
            Else
                cbxAdd.Focus()
            End If
        End If
    End Sub

    Private Sub DTaxes_KeyDown(sender As Object, e As KeyEventArgs) Handles dTaxes.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAttorneysFee.Focus()
        End If
    End Sub

    Private Sub DAttorneysFee_KeyDown(sender As Object, e As KeyEventArgs) Handles dAttorneysFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOthers.Focus()
        End If
    End Sub

    Private Sub DOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles dOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAdd.Focus()
        End If
    End Sub

    Private Sub CbxAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leaves"
    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = ReplaceText(txtReference.Text)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub
#End Region

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
            FrmMain.BtnReport_Click(sender, e)
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
            'Clear()
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
        cbxTransaction.Text = ""
        txtRemarks.Text = ""
        txtReference.Text = ""
        dTaxes.Value = 0
        dAttorneysFee.Value = 0
        dOthers.Value = 0
        dAmount.Value = 0
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        LoadData()
    End Sub

    Private Sub CbxTransaction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTransaction.SelectedIndexChanged
        lblTaxes.Visible = False
        lblAttorneysFee.Visible = False
        lblOthers.Visible = False
        dTaxes.Visible = False
        dAttorneysFee.Visible = False
        dOthers.Visible = False
        dAmount.Enabled = True

        If cbxTransaction.Text.ToUpper = "BALANCE TRANSFERRED" Then
            cbxAdd.Checked = True
            cbxAdd.Enabled = False
            cbxDeduct.Enabled = False
        ElseIf cbxTransaction.Text.ToUpper = "PAYMENT" Then
            cbxAdd.Checked = False
            cbxAdd.Enabled = False
            cbxDeduct.Checked = True
            cbxDeduct.Enabled = False
        ElseIf cbxTransaction.Text.ToUpper = "CHARGES" Then
            cbxAdd.Checked = False
            cbxAdd.Enabled = False
            cbxDeduct.Checked = False
            cbxDeduct.Enabled = False

            lblTaxes.Visible = True
            lblAttorneysFee.Visible = True
            lblOthers.Visible = True
            dTaxes.Visible = True
            dAttorneysFee.Visible = True
            dOthers.Visible = True
            dAmount.Enabled = False
        Else
            cbxAdd.Enabled = True
            cbxDeduct.Enabled = True
        End If
    End Sub

    Private Sub CbxTransaction_TextChanged(sender As Object, e As EventArgs) Handles cbxTransaction.TextChanged
        If cbxTransaction.Text = "" Then
            lblTaxes.Visible = False
            lblAttorneysFee.Visible = False
            lblOthers.Visible = False
            dTaxes.Visible = False
            dAttorneysFee.Visible = False
            dOthers.Visible = False
            dAmount.Enabled = True
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbxTransaction.Text = "" Then
            MsgBox("Please select transaction.", MsgBoxStyle.Information, "Info")
            cbxTransaction.DroppedDown = True
            Exit Sub
        End If
        If txtReference.Text = "" Then
            MsgBox("Please fill reference number field.", MsgBoxStyle.Information, "Info")
            txtReference.Focus()
            Exit Sub
        End If

        If dAmount.Value = 0 And cbxTransaction.Text <> "Charges" Then
            If cbxTransaction.Text.ToUpper = "BALANCE TRANSFERRED" Then
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

        If cbxTransaction.Text.ToUpper = "BALANCE TRANSFERRED" Then
            If DataObject(String.Format("SELECT INFULL(ID,0) FROM case_ledger WHERE Transaction = 'Balance Transferred' AND `status` = 'ACTIVE' AND CaseID = '{0}';", CaseID)) > 0 Then
                MsgBox("This case already have a Balance Transferred Amount. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        Dim Type As String = ""
        If cbxAdd.Checked Then
            Type = "Add"
        ElseIf cbxDeduct.Checked Then
            Type = "Deduct"
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                If cbxTransaction.Text = "Payment" Then

                End If

                Dim SQL As String = "INSERT INTO case_ledger SET"
                SQL &= String.Format(" CaseID = '{0}', ", CaseID)
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" Transaction = '{0}', ", cbxTransaction.Text)
                SQL &= String.Format(" remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" reference_number = '{0}', ", txtReference.Text)
                SQL &= String.Format(" type = '{0}', ", Type)
                SQL &= String.Format(" amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" taxes = '{0}', ", dTaxes.Value)
                SQL &= String.Format(" attorneys_fee = '{0}', ", dAttorneysFee.Value)
                SQL &= String.Format(" others = '{0}', ", dOthers.Value)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" CategoryID = '{0}', ", CategoryID)
                SQL &= String.Format(" user_code = '{0}';", User_Code)
                DataObject(SQL)

                Logs("Case Ledger", "Save", String.Format("Add new transaction {0} for Case {1}", cbxTransaction.Text, CaseNumber), "", "", "", CaseNumber)
                Clear()
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE case_ledger SET"
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" Transaction = '{0}', ", cbxTransaction.Text)
                SQL &= String.Format(" remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" reference_number = '{0}', ", txtReference.Text)
                SQL &= String.Format(" type = '{0}', ", Type)
                SQL &= String.Format(" amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" taxes = '{0}', ", dTaxes.Value)
                SQL &= String.Format(" attorneys_fee = '{0}', ", dAttorneysFee.Value)
                SQL &= String.Format(" others = '{0}' ", dOthers.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Case Ledger", "Update", String.Format("Update transaction {0} for Case {1}", cbxTransaction.Text, CaseNumber), Changes(), "", "", CaseNumber)
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
            If dTaxes.Value = dTaxes.Tag Then
            Else
                Change &= String.Format("Change Taxes from {0} to {1}. ", dTaxes.Tag, dTaxes.Text)
            End If
            If dAttorneysFee.Value = dAttorneysFee.Tag Then
            Else
                Change &= String.Format("Change Attorney from {0} to {1}. ", dAttorneysFee.Tag, dAttorneysFee.Text)
            End If
            If dOthers.Value = dOthers.Tag Then
            Else
                Change &= String.Format("Change Other from {0} to {1}. ", dOthers.Tag, dOthers.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Case Ledger - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update"
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE case_ledger SET `status` = 'DELETED' WHERE ID = '{0}';", ID))
            Logs("Case Ledger", "Cancel", Reason, String.Format("Cancel Case Ledger transaction {0} with reference {1} for Case {2}", cbxTransaction.Text, txtReference.Text, CaseNumber), "", "", CaseNumber)
            Clear()
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        GridView2.OptionsPrint.UsePrintStyles = False
        StandardPrinting(String.Format("CASE LEDGER FOR {0}", CaseNumber), GridControl2)
        Logs("Case Ledger", "Print", "[SENSITIVE] Print Case Ledger " & CaseNumber, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub
End Class