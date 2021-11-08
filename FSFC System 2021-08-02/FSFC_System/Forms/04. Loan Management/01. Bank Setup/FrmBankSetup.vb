Public Class FrmBankSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmBankSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY ID;")
            .SelectedValue = Branch_ID
        End With

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource("SELECT ID, CONCAT(Bank, ' [', short_name, ']') AS 'Bank' FROM bank_setup WHERE `status` = 'ACTIVE' ORDER BY `Bank`;")
            .SelectedIndex = -1
        End With

        With cbxCashInBank
            .ValueMember = "Code"
            .DisplayMember = "Title"
            .DataSource = DataSource("SELECT `Code`, Title FROM account_chart WHERE Main_ID = 1 AND `status` = 'ACTIVE' ORDER BY `Code`;")
            .SelectedIndex = -1
        End With

        If Branch_ID = 0 And MultipleBranch Then
            cbxBranch.Enabled = True
        Else
            cbxBranch.Enabled = False
        End If
        LoadData()
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

            GetLabelFontSettings({lblBranch, LabelX155, LabelX2, LabelX9, LabelX1, LabelX4, LabelX8, LabelX3, LabelX6, LabelX5, LabelX7})

            GetTextBoxFontSettings({txtBranch, txtAccountNumber, txtCheckingAccount, txtAccountName, txtContactNumber})

            GetComboBoxFontSettings({cbxBranch, cbxBank, cbxCashInBank})

            GetCheckBoxFontSettings({cbxBook1, cbxBook2})

            GetIntegerInputFontSettings({iBank})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Bank Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Bank Setup", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    (SELECT branch FROM branch WHERE ID = Branch_ID) AS 'Company Branch',"
        SQL &= "    (SELECT Bank FROM bank_Setup WHERE ID = BankID) AS 'Bank',"
        SQL &= "    BankID,"
        SQL &= "    Branch, Branch_ID,"
        SQL &= "    FORMAT(Book,0) AS 'Book',"
        SQL &= "    `Code` AS 'CodeID',"
        SQL &= "    CONCAT('BANK', `Code`) AS 'Code',"
        SQL &= "    AccountTitle(AccountCode) AS 'Cash In Bank',"
        SQL &= "    AccountNumber AS 'Account Number',"
        SQL &= "    CheckingAccount AS 'Checking Account',"
        SQL &= "    AccountName AS 'Account Name',"
        SQL &= "    ContactNumber AS 'Contact Number' "
        SQL &= String.Format(" FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY `CodeID`;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Branch_ID = 0 And MultipleBranch Then
            GridColumn2.Visible = True
            GridColumn2.Width = 140
            GridColumn3.Width = 149
            If GridView1.RowCount > 22 Then
                GridColumn4.Width = 240 - 17
            Else
                GridColumn4.Width = 240
            End If
            GridColumn5.Width = 70
            GridColumn6.Width = 130
            GridColumn7.Width = 130
            GridColumn8.Width = 155
            GridColumn9.Width = 125
        Else
            GridColumn2.Visible = False
            GridColumn3.Width = 149 + 10
            If GridView1.RowCount > 22 Then
                GridColumn4.Width = 240 - 17 + 55
            Else
                GridColumn4.Width = 240 + 55
            End If
            GridColumn5.Width = 70 + 15
            GridColumn6.Width = 130 + 15
            GridColumn7.Width = 130 + 15
            GridColumn8.Width = 155 + 15
            GridColumn9.Width = 125 + 15
        End If

        GridView1.Columns("Bank").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Bank").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranch.Focus()
        End If
    End Sub

    Private Sub TxtBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            iBank.Focus()
        End If
    End Sub

    Private Sub IBank_KeyDown(sender As Object, e As KeyEventArgs) Handles iBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCashInBank.Focus()
        End If
    End Sub

    Private Sub CbxCashInBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCashInBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountNumber.Focus()
        End If
    End Sub

    Private Sub TxtAccountNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCheckingAccount.Focus()
        End If
    End Sub

    Private Sub TxtCheckingAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheckingAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountName.Focus()
        End If
    End Sub

    Private Sub TxtAccountName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContactNumber.Focus()
        End If
    End Sub

    Private Sub TxtContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub CbxBank_Leave(sender As Object, e As EventArgs) Handles cbxBank.Leave
        cbxBank.Text = ReplaceText(cbxBank.Text.Trim)
    End Sub

    Private Sub TxtBranch_Leave(sender As Object, e As EventArgs) Handles txtBranch.Leave
        txtBranch.Text = ReplaceText(txtBranch.Text.Trim)
    End Sub

    Private Sub TxtAccountNumber_Leave(sender As Object, e As EventArgs) Handles txtAccountNumber.Leave
        txtAccountNumber.Text = ReplaceText(txtAccountNumber.Text.Trim)
    End Sub

    Private Sub TxtCheckingAccount_Leave(sender As Object, e As EventArgs) Handles txtCheckingAccount.Leave
        txtCheckingAccount.Text = ReplaceText(txtCheckingAccount.Text.Trim)
    End Sub

    Private Sub TxtAccountName_Leave(sender As Object, e As EventArgs) Handles txtAccountName.Leave
        txtAccountName.Text = ReplaceText(txtAccountName.Text.Trim)
    End Sub

    Private Sub TxtContactNumber_Leave(sender As Object, e As EventArgs) Handles txtContactNumber.Leave
        txtContactNumber.Text = ReplaceText(txtContactNumber.Text.Trim)
    End Sub
#End Region

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
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear(True)

            With cbxBank
                .ValueMember = "ID"
                .DisplayMember = "Bank"
                .DataSource = DataSource("SELECT ID, CONCAT(Bank, ' [', short_name, ']') AS 'Bank' FROM bank_setup WHERE `status` = 'ACTIVE' ORDER BY `Bank`;")
                .SelectedIndex = -1
            End With
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        txtBranch.Text = ""
        iBank.Value = DataObject(String.Format("SELECT COUNT(ID) + 1 FROM branch_bank WHERE branch_id = '{0}';", cbxBranch.SelectedValue))
        txtAccountNumber.Text = ""
        txtAccountName.Text = ""
        txtCheckingAccount.Text = ""
        txtContactNumber.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If Branch_ID = 0 And MultipleBranch Then
            cbxBranch.Enabled = True
        Else
            cbxBranch.Enabled = False
        End If

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

        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            MsgBox("Please select bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        If txtBranch.Text = "" Then
            MsgBox("Please fill branch.", MsgBoxStyle.Information, "Info")
            txtBranch.Focus()
            Exit Sub
        End If
        If txtAccountNumber.Text = "" And txtCheckingAccount.Text = "" Then
            MsgBox("Please fill either Savings Account or Current Account.", MsgBoxStyle.Information, "Info")
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If cbxCashInBank.Text = "" And cbxCashInBank.SelectedIndex = -1 Then
            MsgBox("Please select Cash In Bank.", MsgBoxStyle.Information, "Info")
            cbxCashInBank.DroppedDown = True
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM branch_bank WHERE (`Code` = '{0}' OR (AccountNumber = '{1}' AND CheckingAccount = '{3}')) AND `status` = 'ACTIVE' AND branch_id = '{2}';", iBank.Value, txtAccountNumber.Text, Branch_ID, txtCheckingAccount.Text))
                If Exist > 0 Then
                    MsgBox("Either Bank Code or Saving Account or Checking Account already exist, Please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO branch_bank SET"
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format(" Book = '{0}', ", If(cbxBook1.Checked, 1, 2))
                SQL &= String.Format(" `Code` = '{0}', ", iBank.Value)
                SQL &= String.Format(" AccountCode = '{0}', ", cbxCashInBank.SelectedValue)
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" CheckingAccount = '{0}', ", txtCheckingAccount.Text)
                SQL &= String.Format(" ContactNumber = '{0}', ", txtContactNumber.Text)
                SQL &= String.Format(" AccountName = '{0}', ", txtAccountName.Text)
                SQL &= String.Format(" user_id = '{0}', ", User_ID)
                SQL &= String.Format(" branch_id = '{0}';", cbxBranch.SelectedValue)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Bank Setup", "Save", String.Format("Add new bank {0} with saving account {1} and checking account {3} for {2} branch.", cbxBank.Text, txtAccountNumber.Text, cbxBranch.Text, txtCheckingAccount.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM branch_bank WHERE (`Code` = '{0}' OR (AccountNumber = '{1}' AND CheckingAccount = '{3}')) AND `status` = 'ACTIVE' AND ID != '{2}' AND branch_id = '{3}';", iBank.Value, txtAccountNumber.Text, ID, Branch_ID, txtCheckingAccount.Text))
                If Exist > 0 Then
                    MsgBox("Either Bank Code or Saving Account or Checking Account already exist, Please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE branch_bank SET"
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format(" Book = '{0}', ", If(cbxBook1.Checked, 1, 2))
                SQL &= String.Format(" `Code` = '{0}', ", iBank.Value)
                SQL &= String.Format(" AccountCode = '{0}', ", cbxCashInBank.SelectedValue)
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" CheckingAccount = '{0}', ", txtCheckingAccount.Text)
                SQL &= String.Format(" ContactNumber = '{0}', ", txtContactNumber.Text)
                SQL &= String.Format(" AccountName = '{0}' ", txtAccountName.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Bank Setup", "Update", Reason, Changes, "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxBank.Text = cbxBank.Tag Then
            Else
                Change &= String.Format("Change Bank from {0} to {1}. ", cbxBank.Tag, cbxBank.Text)
            End If
            If txtBranch.Text = txtBranch.Tag Then
            Else
                Change &= String.Format("Change Branch from {0} to {1}. ", txtBranch.Tag, txtBranch.Text)
            End If
            If iBank.Value = iBank.Tag Then
            Else
                Change &= String.Format("Change Bank Code from {0} to {1}. ", iBank.Tag, iBank.Value)
            End If
            If cbxCashInBank.SelectedValue = cbxCashInBank.Tag Then
            Else
                Change &= String.Format("Change Cash In Bank from {0} to {1}. ", cbxCashInBank.Tag, cbxCashInBank.SelectedValue)
            End If
            If txtAccountNumber.Text = txtAccountNumber.Tag Then
            Else
                Change &= String.Format("Change Saving Account from {0} to {1}. ", txtAccountNumber.Tag, txtAccountNumber.Text)
            End If
            If txtCheckingAccount.Text = txtCheckingAccount.Tag Then
            Else
                Change &= String.Format("Change Checking Account from {0} to {1}. ", txtCheckingAccount.Tag, txtCheckingAccount.Text)
            End If
            If txtAccountName.Text = txtAccountName.Tag Then
            Else
                Change &= String.Format("Change Account Name from {0} to {1}. ", txtAccountName.Tag, txtAccountName.Text)
            End If
            If txtContactNumber.Text = txtContactNumber.Tag Then
            Else
                Change &= String.Format("Change Contact Number from {0} to {1}. ", txtContactNumber.Tag, txtContactNumber.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Bank Setup - Changes", ex.Message.ToString)
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

        Dim Transactions As DataTable = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Debit', IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' THEN Amount END),0) AS 'Credit' FROM accounting_entry WHERE BankID = '{0}' AND `status` = 'ACTIVE';", ID))
        If Transactions.Rows.Count > 0 Then
            If Transactions(0)("Debit") <> Transactions(0)("Credit") Then
                MsgBox(String.Format("Bank {0} Total Debit is {1} and Total Credit is {2}, deactivating is not allowed on not balanced accounts used by this Bank.", iBank.Tag, FormatNumber(Transactions(0)("Debit"), 2), FormatNumber(Transactions(0)("Credit"), 2)), MsgBoxStyle.Information, "Info")
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
            DataObject(String.Format("UPDATE branch_bank SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Bank Setup", "Cancel", Reason, String.Format("Cancel bank {0} with account number {1};", cbxBank.Text, txtAccountNumber.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("BRANCH BANK LIST", GridControl1)
        Logs("Branch Bank List", "Print", "[SENSITIVE] Print Branch Bank List", "", "", "", "")
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

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False

        cbxBranch.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            cbxBranch.SelectedValue = .GetFocusedRowCellValue("Branch_ID")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")

            txtBranch.Text = .GetFocusedRowCellValue("Branch")
            txtBranch.Tag = .GetFocusedRowCellValue("Branch")

            If .GetFocusedRowCellValue("Book") = 1 Then
                cbxBook1.Checked = True
            Else
                cbxBook2.Checked = True
            End If

            iBank.Value = .GetFocusedRowCellValue("CodeID")
            iBank.Tag = .GetFocusedRowCellValue("CodeID")

            txtAccountNumber.Text = .GetFocusedRowCellValue("Account Number")
            txtAccountNumber.Tag = .GetFocusedRowCellValue("Account Number")

            cbxCashInBank.Text = .GetFocusedRowCellValue("Cash In Bank").ToString
            cbxCashInBank.Tag = .GetFocusedRowCellValue("Cash In Bank").ToString

            txtAccountName.Text = .GetFocusedRowCellValue("Account Name")
            txtAccountName.Tag = .GetFocusedRowCellValue("Account Name")

            txtCheckingAccount.Text = .GetFocusedRowCellValue("Checking Account")
            txtCheckingAccount.Tag = .GetFocusedRowCellValue("Checking Account")

            txtContactNumber.Text = .GetFocusedRowCellValue("Contact Number")
            txtContactNumber.Tag = .GetFocusedRowCellValue("Contact Number")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        iBank.Value = DataObject(String.Format("SELECT COUNT(ID) + 1 FROM branch_bank WHERE branch_id = '{0}';", cbxBranch.SelectedValue))
    End Sub

    Private Sub CbxBook1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBook1.CheckedChanged
        If cbxBook1.Checked Then
            cbxBook2.Checked = False
        End If

        If cbxBook1.Checked = False And cbxBook2.Checked = False Then
            cbxBook1.Checked = True
        End If
    End Sub

    Private Sub CbxBook2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBook2.CheckedChanged
        If cbxBook2.Checked Then
            cbxBook1.Checked = False
        End If

        If cbxBook1.Checked = False And cbxBook2.Checked = False Then
            cbxBook1.Checked = True
        End If
    End Sub
End Class