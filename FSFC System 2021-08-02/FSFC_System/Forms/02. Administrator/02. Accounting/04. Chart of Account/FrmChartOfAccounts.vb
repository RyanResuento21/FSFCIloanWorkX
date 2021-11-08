Public Class FrmChartOfAccounts

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_D As New DataTable
    Dim DT_C As New DataTable
    Private Sub FrmChartOfAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5, GridView6})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Line1.Location = New Point(107, 546)
        Line3.Location = New Point(107, 511)
        Line4.BringToFront()
        Line4.Location = New Point(135, 511)
        Line2.Location = New Point(139, 531)
        Line5.Location = New Point(165, 511)
        Line6.Location = New Point(169, 521)

        DT_D.Columns.Add("ID")
        DT_D.Columns.Add("Description")
        DT_C.Columns.Add("ID")
        DT_C.Columns.Add("Description")

        SuperTabControl1.SelectedTab = tabChart
        GridControl2.DataSource = DataSource("SELECT ID, `Code`, `Type` AS 'Account Type' FROM account_type WHERE `status` = 'ACTIVE' ORDER BY `Code`;")
        GridControl3.DataSource = DataSource("SELECT ID, (SELECT `Type` FROM account_type WHERE ID = Type_ID) AS 'Account Type', `Code`, Classification AS 'Account Classification' FROM account_classification WHERE `status` = 'ACTIVE';")
        GridControl6.DataSource = DataSource("SELECT ID, `Code`, `Group` AS 'Account Group' FROM account_group WHERE `status` = 'ACTIVE' ORDER BY `Code`;")

        With cbxType
            .DisplayMember = "Type"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Code`, `Type` FROM account_type WHERE `status` = 'ACTIVE' ORDER BY `Code`;")
            .SelectedIndex = -1
        End With

        With cbxAccount
            .DisplayMember = "Title"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Code`, Title FROM account_chart WHERE `status` = 'ACTIVE' AND Main_ID = 0 ORDER BY `Code` DESC;")
            .SelectedIndex = -1
        End With

        With cbxGroup
            .DisplayMember = "Group"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Code`, `Group` FROM account_group WHERE `status` = 'ACTIVE' ORDER BY `Code`;")
            .SelectedIndex = -1
        End With

        FirstLoad = False
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

            GetLabelFontSettings({LabelX5, LabelX3, LabelX15, LabelX2, LabelX9, LabelX17, xlblAccountNumber, LabelX10, LabelX19, LabelX1, LabelX12, LabelX13, LabelX14})

            GetTextBoxFontSettings({txtT, txtC, txtG, txtAccountNumber, txtTitle})

            GetComboBoxFontSettings({cbxType, cbxClassification, cbxGroup, cbxAccount})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAdd_D, btnRemove_D, btnAdd_C, btnRemove_C})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetRickTextBoxFontSettings({rDescription, rDescription_D, rDescription_C, rNote})

            GetCheckBoxFontSettings({cbxMotherAccount, cbxRequired})

            GetLabelFontSettingsRed({LabelX18})
        Catch ex As Exception
            TriggerBugReport("Chart of Accounts - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Chart of Account", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    `Type`,"
        SQL &= "    Classification,"
        SQL &= "    `Group`,"
        SQL &= "    IF(Main_ID > 0,(SELECT `Code` FROM account_chart C WHERE C.ID = account_chart.Main_ID),`Code`) AS 'Code',"
        SQL &= "    IF(Main_ID > 0,(SELECT Title FROM account_chart C WHERE C.ID = account_chart.Main_ID),Title) AS 'Mother Account',"
        SQL &= "    IF(Main_ID = 0,'',`Code`) AS 'Sub-Account Code',"
        SQL &= "    IF(Main_ID = 0,'',Title) AS 'Sub-Account',"
        SQL &= "    IF(Description = '' AND Main_ID > 0,(SELECT Description FROM account_chart C WHERE C.ID = account_chart.Main_ID),Description) AS 'Description',"
        SQL &= "    Note,"
        SQL &= "    Main_ID,"
        SQL &= "    classification_id,"
        SQL &= "    group_id,"
        SQL &= "    RequiredRemarks, ContraAccount, AdjunctAccount, Status, "
        SQL &= String.Format("    Branch(BranchTagged) AS 'Branch Tagged', BranchTagged, (SELECT BankID FROM account_bank WHERE AccountID = account_chart.ID AND BranchID = '{0}' AND `status` = 'ACTIVE') AS 'BankTagged',", Branch_ID)
        SQL &= "    type_id"
        If CompanyMode = 0 Then
            SQL &= " FROM account_chart WHERE `status` IN ('ACTIVE','DEACTIVATE') AND Main_ID = 0 AND AdjunctAccount = 0 ORDER BY `Code`, `Sub-Account Code`;"
            GridColumn24.Visible = False
            GridColumn23.Visible = False
            GridColumn25.Visible = False
            GridColumn15.Caption = "Account Title"
            iTag.Visible = False
            iAdjunct.Visible = False
            iBank.Visible = False
        Else
            SQL &= " FROM account_chart WHERE `status` IN ('ACTIVE','DEACTIVATE') ORDER BY `Code`, `Sub-Account Code`;"
            GridColumn24.Visible = True
            GridColumn23.Visible = True
            GridColumn25.Visible = True
            GridColumn2.VisibleIndex = 0
            GridColumn3.VisibleIndex = 1
            GridColumn21.VisibleIndex = 2
            GridColumn4.VisibleIndex = 3
            GridColumn15.VisibleIndex = 4
            GridColumn24.VisibleIndex = 5
            GridColumn23.VisibleIndex = 6
            GridColumn16.VisibleIndex = 7
            GridColumn17.VisibleIndex = 8
            GridColumn25.VisibleIndex = 9
            GridColumn15.Caption = "Mother Account"
            iTag.Visible = True
            iAdjunct.Visible = True
            iBank.Visible = True
        End If
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Mother Account").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Mother Account").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)

                Dim Default_Type As Integer = cbxType.SelectedIndex
                With cbxType
                    .DisplayMember = "Type"
                    .ValueMember = "Code"
                    .DataSource = DataSource("SELECT ID, `Code`, `Type` FROM account_type WHERE `status` = 'ACTIVE' ORDER BY `Code`;")
                    .SelectedIndex = Default_Type
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        ID = 0
        txtAccountNumber.Text = ""
        txtTitle.Text = ""
        cbxMotherAccount.Checked = False
        cbxMotherAccount.Enabled = True
        rDescription.Text = ""
        rDescription_D.Text = ""
        rDescription_C.Text = ""
        rNote.Text = ""
        DT_D.Rows.Clear()
        DT_C.Rows.Clear()
        GridControl4.DataSource = Nothing
        GridControl5.DataSource = Nothing
        cbxType.Enabled = True
        cbxClassification.Enabled = True
        cbxGroup.Enabled = True
        txtAccountNumber.Enabled = True
        cbxAccount.Enabled = True

        With cbxAccount
            .DisplayMember = "Title"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Code`, Title FROM account_chart WHERE `status` = 'ACTIVE' AND Main_ID = 0 ORDER BY `Code` DESC;")
            .SelectedIndex = -1
        End With
        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabSetup
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabSetup
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabChart
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

            lblGreen.Visible = False
            lblRed.Visible = False
            lblBlue.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            btnBack.Enabled = True
            btnAdd.Enabled = False
            btnNext.Enabled = True
            If ID = 0 Then
                btnModify.Enabled = False
                btnSave.Enabled = True
                btnDelete.Enabled = False
            End If

            lblGreen.Visible = False
            lblRed.Visible = False
            lblBlue.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            btnBack.Enabled = True
            btnNext.Enabled = False
            If ID = 0 Then
                btnSave.Enabled = False
                btnDelete.Enabled = False
            End If

            lblGreen.Visible = True
            lblRed.Visible = True
            lblBlue.Visible = True
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
        StandardPrinting("CHART OF ACCOUNT", GridControl1)
        Logs("Chart of Account", "Print", "Print Chart of Account List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

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

        If cbxMotherAccount.Tag = True Then
            Dim Subs As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM account_chart WHERE Main_ID = {0} AND `status` = 'ACTIVE';", ID))
            If Subs > 0 Then
                MsgBox(String.Format("Account {0} have {1} active sub accounts, delete is not allowed.", txtTitle.Tag, Subs), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        Dim Transactions As DataTable = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Debit', IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' THEN Amount END),0) AS 'Credit' FROM accounting_entry WHERE AccountCode = '{0}' AND `status` = 'ACTIVE';", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Tag))
        If Transactions.Rows.Count > 0 Then
            If Transactions(0)("Debit") <> Transactions(0)("Credit") Then
                MsgBox(String.Format("Account {0} Total Debit is {1} and Total Credit is {2}, deactivating is not allowed on not balanced accounts.", txtTitle.Tag, FormatNumber(Transactions(0)("Debit"), 2), FormatNumber(Transactions(0)("Credit"), 2)), MsgBoxStyle.Information, "Info")
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
            DataObject(String.Format("UPDATE account_chart SET `status` = 'DELETED', `Code` = CONCAT(`Code`, 'X') WHERE ID = '{0}'", ID))
            Logs("Chart of Account", "Cancel", Reason, String.Format(String.Format("Cancel Chart of Account {0}", txtTitle.Text)), "", "", "")
            Clear(True)
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
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxType.SelectedItem, DataRowView)
        With cbxClassification
            .DisplayMember = "Classification"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, `Code`, Classification FROM account_classification WHERE `status` = 'ACTIVE' AND type_id = '{0}' ORDER BY `Code`; ", cbxType.SelectedValue))
        End With
        txtT.Text = drv("Code")
    End Sub

    Private Sub CbxClassification_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxClassification.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxClassification.SelectedItem, DataRowView)
        Try
            txtC.Text = drv("Code")
        Catch ex As Exception
            txtC.Text = ""
        End Try
    End Sub

    '*KEYDOWN
    Private Sub CbxType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxClassification.Focus()
        End If
    End Sub

    Private Sub CbxClassification_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxClassification.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxGroup.Focus()
        End If
    End Sub

    Private Sub CbxGroup_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGroup.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountNumber.Focus()
        End If
    End Sub

    Private Sub TxtAccountNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTitle.Focus()
        End If
    End Sub

    Private Sub TxtTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAccount.Focus()
        End If
    End Sub

    Private Sub CbxAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            rDescription.Focus()
        End If
    End Sub

    Private Sub RDescription_KeyDown(sender As Object, e As KeyEventArgs) Handles rDescription.KeyDown
        If e.Control And e.KeyCode = Keys.Enter Then
            rDescription_D.Focus()
        End If
    End Sub

    Private Sub RDescription_D_KeyDown(sender As Object, e As KeyEventArgs) Handles rDescription_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd_D.Focus()
            btnAdd_D.PerformClick()
            rDescription_D.Focus()
        End If
    End Sub

    Private Sub RDescription_C_KeyDown(sender As Object, e As KeyEventArgs) Handles rDescription_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd_C.Focus()
            btnAdd_C.PerformClick()
            rDescription_C.Focus()
        End If
    End Sub

    Private Sub RNote_KeyDown(sender As Object, e As KeyEventArgs) Handles rNote.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    '**LEAVE
    Private Sub CbxType_Leave(sender As Object, e As EventArgs) Handles cbxType.Leave
        cbxType.Text = ReplaceText(cbxType.Text)
    End Sub

    Private Sub CbxClassification_Leave(sender As Object, e As EventArgs) Handles cbxClassification.Leave
        cbxClassification.Text = ReplaceText(cbxClassification.Text)
    End Sub

    Private Sub CbxGroup_Leave(sender As Object, e As EventArgs) Handles cbxGroup.Leave
        cbxGroup.Text = ReplaceText(cbxGroup.Text)
    End Sub

    Private Sub TxtAccountNumber_Leave(sender As Object, e As EventArgs) Handles txtAccountNumber.Leave
        txtAccountNumber.Text = ReplaceText(txtAccountNumber.Text)
        If IsNumeric(txtAccountNumber.Text) = False Then
        Else
            txtAccountNumber.Text = CInt(txtAccountNumber.Text).ToString("D3")
        End If
    End Sub

    Private Sub TxtTitle_Leave(sender As Object, e As EventArgs) Handles txtTitle.Leave
        txtTitle.Text = ReplaceText(txtTitle.Text)
    End Sub

    Private Sub CbxAccount_Leave(sender As Object, e As EventArgs) Handles cbxAccount.Leave
        cbxAccount.Text = ReplaceText(cbxAccount.Text)
    End Sub

    Private Sub RDescription_Leave(sender As Object, e As EventArgs) Handles rDescription.Leave
        rDescription.Text = ReplaceTextWithQuote(rDescription.Text)
    End Sub

    Private Sub RDescription_D_Leave(sender As Object, e As EventArgs) Handles rDescription_D.Leave
        rDescription_D.Text = ReplaceTextWithQuote(rDescription_D.Text)
    End Sub

    Private Sub RDescription_C_Leave(sender As Object, e As EventArgs) Handles rDescription_C.Leave
        rDescription_C.Text = ReplaceTextWithQuote(rDescription_C.Text)
    End Sub

    Private Sub RNote_Leave(sender As Object, e As EventArgs) Handles rNote.Leave
        rNote.Text = ReplaceTextWithQuote(rNote.Text)
    End Sub

    Private Sub CbxTheSame_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMotherAccount.CheckedChanged
        If cbxMotherAccount.Checked Then
            cbxAccount.Enabled = False
            cbxAccount.Text = ""
        Else
            cbxAccount.Enabled = True
            cbxAccount.DroppedDown = True
            If cbxAccount.Items.Count > 0 Then
                cbxAccount.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub BtnAdd_D_Click(sender As Object, e As EventArgs) Handles btnAdd_D.Click
        If rDescription_D.Text = "" Then
            MsgBox("Please fill the Description for Debit.", MsgBoxStyle.Information, "Info")
            rDescription_D.Focus()
            Exit Sub
        End If
        btnRemove_D.Enabled = True
        DT_D.Rows.Add(0, rDescription_D.Text.Trim)
        GridControl4.DataSource = DT_D
        rDescription_D.Text = ""
    End Sub

    Private Sub BtnRemove_D_Click(sender As Object, e As EventArgs) Handles btnRemove_D.Click
        If GridView4.RowCount = 0 Then
            Exit Sub
        End If
        DT_D.Rows.RemoveAt(GridView4.FocusedRowHandle)

        If GridView4.RowCount = 1 Then
            btnRemove_D.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_C_Click(sender As Object, e As EventArgs) Handles btnAdd_C.Click
        If rDescription_C.Text = "" Then
            MsgBox("Please fill the Description for Credit.", MsgBoxStyle.Information, "Info")
            rDescription_C.Focus()
            Exit Sub
        End If
        btnRemove_C.Enabled = True
        DT_C.Rows.Add(0, rDescription_C.Text.Trim)
        GridControl5.DataSource = DT_C
        rDescription_C.Text = ""
    End Sub

    Private Sub BtnRemove_C_Click(sender As Object, e As EventArgs) Handles btnRemove_C.Click
        If GridView5.RowCount = 0 Then
            Exit Sub
        End If
        DT_C.Rows.RemoveAt(GridView5.FocusedRowHandle)

        If GridView5.RowCount = 1 Then
            btnRemove_C.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxType.SelectedIndex = -1 Or cbxType.Text.Trim = "" Then
            MsgBox("Please select Account Type.", MsgBoxStyle.Information, "Info")
            cbxType.DroppedDown = True
            Exit Sub
        End If
        If (cbxClassification.Text = "" Or cbxClassification.SelectedIndex = -1) And cbxClassification.Items.Count > 0 Then
            MsgBox("Please select Account Classification.", MsgBoxStyle.Information, "Info")
            cbxClassification.DroppedDown = True
            Exit Sub
        End If
        If (cbxGroup.SelectedIndex = -1 Or cbxGroup.Text.Trim = "") And cbxClassification.Items.Count > 0 Then
            MsgBox("Please select Account Group.", MsgBoxStyle.Information, "Info")
            cbxGroup.DroppedDown = True
            Exit Sub
        End If
        If txtAccountNumber.Text = "" Then
            MsgBox("Please fill the Account Number.", MsgBoxStyle.Information, "Info")
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If IsNumeric(txtAccountNumber.Text) = False Then
            MsgBox("Please fill a correct Account Number", MsgBoxStyle.Information, "Info")
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If txtTitle.Text = "" Then
            MsgBox("Please fill the Account Title.", MsgBoxStyle.Information, "Info")
            txtTitle.Focus()
            Exit Sub
        End If
        If cbxMotherAccount.Checked = False And (cbxAccount.SelectedIndex = -1 Or cbxAccount.Text = "") Then
            MsgBox("Please fill select the mother account..", MsgBoxStyle.Information, "Info")
            cbxAccount.DroppedDown = True
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM account_chart WHERE (`Code` = '{0}' OR Title = '{1}') AND `status` = 'ACTIVE';", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text, txtTitle.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Account Code ({0}) or Account Title ({1}) already exist, Please check your data.", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text, txtTitle.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL_II As String = ""
                Dim SQL As String = " INSERT INTO account_chart SET "
                SQL &= String.Format(" `Code` = '{0}',", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                SQL &= String.Format(" RequiredRemarks = '{0}',", cbxRequired.Checked)
                SQL &= String.Format(" type_id = '{0}',", cbxType.SelectedValue)
                SQL &= String.Format(" `Type` = '{0}',", cbxType.Text)
                SQL &= String.Format(" classification_id = '{0}',", ValidateComboBox(cbxClassification))
                SQL &= String.Format(" Classification = '{0}',", cbxClassification.Text)
                SQL &= String.Format(" group_id = '{0}',", ValidateComboBox(cbxGroup))
                SQL &= String.Format(" `Group` = '{0}',", cbxGroup.Text)
                SQL &= String.Format(" Title = '{0}',", txtTitle.Text)
                SQL &= String.Format(" Description = '{0}',", rDescription.Text.Trim.InsertQuote)
                SQL &= String.Format(" Note = '{0}',", rNote.Text.InsertQuote)
                If cbxAccount.SelectedIndex = -1 Or cbxAccount.Text = "" Then
                Else
                    SQL &= String.Format(" MotherCode = '{0}',", drv("Code"))
                End If
                SQL &= String.Format(" Main_ID = '{0}'; ", If(cbxMotherAccount.Checked, 0, cbxAccount.SelectedValue))
                DataObject(SQL)
                Dim AccountID As Integer = DataObject(String.Format("SELECT MAX(ID) FROM account_chart WHERE `Code` = '{0}';", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text))
                For x As Integer = 0 To GridView4.RowCount - 1
                    SQL_II &= " INSERT INTO account_debit SET"
                    SQL_II &= String.Format(" account_id = '{0}', ", AccountID)
                    SQL_II &= String.Format(" Description = '{0}';", GridView4.GetRowCellValue(x, "Description").ToString.InsertQuote)
                Next
                For x As Integer = 0 To GridView5.RowCount - 1
                    SQL_II &= " INSERT INTO account_credit SET"
                    SQL_II &= String.Format(" account_id = '{0}', ", AccountID)
                    SQL_II &= String.Format(" Description = '{0}';", GridView5.GetRowCellValue(x, "Description").ToString.InsertQuote)
                Next
                If SQL_II = "" Then
                Else
                    DataObject(SQL_II)
                End If
                Cursor = Cursors.Default

                Clear(True)
                txtAccountNumber.Focus()
                Logs("Chart of Accounts", "Save", String.Format("Save Chart of Account with Account Number {0} and Account Title {1}.", txtT.Text & txtC.Text & txtAccountNumber.Text, txtTitle.Text), "", "", "", "")
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM account_chart WHERE (`Code` = '{0}' OR Title = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}';", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text, txtTitle.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Account Code ({0}) or Account Title ({1}) already exist, Please check your data.", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text, txtTitle.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL_II As String = ""
                Dim SQL As String = " UPDATE account_chart SET "
                SQL &= String.Format(" `Code` = '{0}',", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                SQL &= String.Format(" RequiredRemarks = '{0}',", cbxRequired.Checked)
                SQL &= String.Format(" Title = '{0}',", txtTitle.Text)
                SQL &= String.Format(" Description = '{0}',", rDescription.Text.Trim.InsertQuote)
                SQL &= String.Format(" Note = '{0}',", rNote.Text.InsertQuote)
                If cbxAccount.SelectedIndex = -1 Or cbxAccount.Text = "" Then
                    SQL &= " MotherCode = '',"
                Else
                    SQL &= String.Format(" MotherCode = '{0}',", drv("Code"))
                End If
                SQL &= String.Format(" Main_ID = '{0}' WHERE ID = '{1}'; ", If(cbxMotherAccount.Checked, 0, cbxAccount.SelectedValue), ID)
                If xlblAccountNumber.Tag = txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text Then
                Else
                    Dim Result As DialogResult = MsgBox(String.Format("Would you like to update the saved transactions of Account Code {0} to Account Code {1}?", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text), MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNoCancel, "Info")
                    If Result = DialogResult.Yes Then
                        SQL &= String.Format(" UPDATE accounting_entry SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE acr_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE ap_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE ar_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE billing_entry SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE branch_bank SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE cv_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE df_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE dt_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE financial_plan SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE jv_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE lp_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                        SQL &= String.Format(" UPDATE or_details SET AccountCode = '{1}' WHERE AccountCode = '{0}';", xlblAccountNumber.Tag, txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text)
                    ElseIf Result = DialogResult.Cancel Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
                DataObject(SQL)
                Dim AccountID As Integer = DataObject(String.Format("SELECT MAX(ID) FROM account_chart WHERE `Code` = '{0}';", txtT.Text & txtC.Text & txtG.Text & txtAccountNumber.Text))
                DataObject(String.Format("UPDATE account_debit SET `status` = 'CANCELLED' WHERE account_id ='{0}'; UPDATE account_credit SET `status` = 'CANCELLED' WHERE account_id ='{0}';", ID))
                For x As Integer = 0 To GridView4.RowCount - 1
                    SQL_II &= " INSERT INTO account_debit SET"
                    SQL_II &= String.Format(" account_id = '{0}', ", AccountID)
                    SQL_II &= String.Format(" Description = '{0}';", GridView4.GetRowCellValue(x, "Description").ToString.InsertQuote)
                Next
                For x As Integer = 0 To GridView5.RowCount - 1
                    SQL_II &= " INSERT INTO account_credit SET"
                    SQL_II &= String.Format(" account_id = '{0}', ", AccountID)
                    SQL_II &= String.Format(" Description = '{0}';", GridView5.GetRowCellValue(x, "Description").ToString.InsertQuote)
                Next
                If SQL_II = "" Then
                Else
                    DataObject(SQL_II)
                End If
                Cursor = Cursors.Default

                Clear(True)
                Logs("Chart of Accounts", "Update", Reason, Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtAccountNumber.Text = txtAccountNumber.Tag Then
            Else
                Change &= String.Format("Change Account Number from {0} to {1}. ", txtT.Text & txtC.Text & txtAccountNumber.Tag, txtT.Text & txtC.Text & txtAccountNumber.Text)
            End If
            If cbxRequired.Checked = cbxRequired.Tag Then
            Else
                Change &= String.Format("Change Required Remarks from {0} to {1}. ", cbxRequired.Tag, cbxRequired.Checked)
            End If
            If txtTitle.Text = txtTitle.Tag Then
            Else
                Change &= String.Format("Change Account Title from {0} to {1}. ", txtTitle.Tag, txtTitle.Text)
            End If
            If cbxMotherAccount.Checked = cbxMotherAccount.Tag Then
            Else
                Change &= String.Format("Change Account The Same with from {0} to {1}. ", cbxMotherAccount.Tag, cbxMotherAccount.Checked)
            End If
            If cbxAccount.Text = cbxAccount.Tag Then
            Else
                Change &= String.Format("Change Account The Same with from {0} to {1}. ", cbxAccount.Tag, cbxAccount.Text)
            End If
            If rDescription.Text = rDescription.Tag Then
            Else
                Change &= String.Format("Change Account Description with from {0} to {1}. ", rDescription.Tag.ToString.InsertQuote, rDescription.Text.InsertQuote)
            End If
            If rNote.Text = rNote.Tag Then
            Else
                Change &= String.Format("Change Note with from {0} to {1}. ", rNote.Tag.ToString.InsertQuote, rNote.Text.InsertQuote)
            End If
        Catch ex As Exception
            TriggerBugReport("Chart of Account - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

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
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            cbxType.Enabled = False
            cbxClassification.Enabled = False
            cbxGroup.Enabled = False
            cbxType.SelectedValue = .GetFocusedRowCellValue("type_id")
            cbxClassification.SelectedValue = .GetFocusedRowCellValue("classification_id")
            cbxGroup.SelectedValue = .GetFocusedRowCellValue("group_id")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Code").ToString.Substring(3)
            txtAccountNumber.Tag = .GetFocusedRowCellValue("Code").ToString.Substring(3)
            xlblAccountNumber.Tag = .GetFocusedRowCellValue("Sub-Account Code").ToString
            cbxRequired.Checked = .GetFocusedRowCellValue("RequiredRemarks")
            cbxRequired.Tag = .GetFocusedRowCellValue("RequiredRemarks")
            If .GetFocusedRowCellValue("Main_ID") > 0 Then
                cbxMotherAccount.Checked = False
                cbxMotherAccount.Tag = False
                cbxAccount.SelectedValue = .GetFocusedRowCellValue("Main_ID")
                cbxAccount.Tag = cbxAccount.Text
                txtAccountNumber.Text = .GetFocusedRowCellValue("Sub-Account Code").ToString.Substring(3)
                txtAccountNumber.Tag = .GetFocusedRowCellValue("Sub-Account Code").ToString.Substring(3)
                txtTitle.Text = .GetFocusedRowCellValue("Sub-Account")
                txtTitle.Tag = .GetFocusedRowCellValue("Sub-Account")
            Else
                cbxMotherAccount.Checked = True
                cbxMotherAccount.Tag = True
                cbxAccount.Text = ""
                cbxAccount.Tag = cbxAccount.Text
                txtTitle.Text = .GetFocusedRowCellValue("Mother Account")
                txtTitle.Tag = .GetFocusedRowCellValue("Mother Account")
            End If
            If User_Type <> "ADMIN" Then
                txtAccountNumber.Enabled = False
                cbxAccount.Enabled = False
            Else
                txtAccountNumber.Enabled = True
                cbxAccount.Enabled = True
            End If
            If .GetFocusedRowCellValue("Main_ID") = 0 Then
                txtAccountNumber.Enabled = False
                cbxMotherAccount.Enabled = False
            Else
                txtAccountNumber.Enabled = True
                cbxMotherAccount.Enabled = True
            End If
            rDescription.Text = .GetFocusedRowCellValue("Description")
            rDescription.Tag = .GetFocusedRowCellValue("Description")
            rNote.Text = .GetFocusedRowCellValue("Note")
            rNote.Tag = .GetFocusedRowCellValue("Note")
        End With
        DT_D = DataSource(String.Format("SELECT ID, Description FROM account_debit WHERE `status` = 'ACTIVE' AND account_id = {0};", ID))
        DT_C = DataSource(String.Format("SELECT ID, Description FROM account_credit WHERE `status` = 'ACTIVE' AND account_id = {0};", ID))
        GridControl4.DataSource = DT_D
        GridControl5.DataSource = DT_C

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxGroup.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxGroup.SelectedItem, DataRowView)
        txtG.Text = drv("Code")
    End Sub

    Private Sub CbxClassification_TextChanged(sender As Object, e As EventArgs) Handles cbxClassification.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxClassification.Text = "" Then
            txtC.Text = 0
        End If
    End Sub

    Private Sub CbxGroup_TextChanged(sender As Object, e As EventArgs) Handles cbxGroup.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxGroup.Text = "" Then
            txtG.Text = 0
        End If
    End Sub

    Private Sub ITag_Click(sender As Object, e As EventArgs) Handles iTag.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Tag As New FrmBranchTagged
        With Tag
            If GridView1.GetFocusedRowCellValue("Branch Tagged").ToString = "" Then
            Else
                .BranchTagged = GridView1.GetFocusedRowCellValue("BranchTagged")
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String = String.Format("UPDATE account_chart SET BranchTagged = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), If(.cbxBranch.SelectedIndex = -0 Or .cbxBranch.Text = "", 999, .cbxBranch.SelectedValue))
                DataObject(SQL)
                Logs("Chart of Accounts", "Branch Tag", String.Format("Branch Tagging for {0}.", GridView1.GetFocusedRowCellValue("Sub-Account")), "", "", "", "")
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IContra_Click(sender As Object, e As EventArgs) Handles iContra.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("ContraAccount") = 1 Then
            If MsgBoxYes("Account is already set as Contra Account, would you like to reset this account?") = MsgBoxResult.Yes Then
                Dim SQL As String = String.Format("UPDATE account_chart SET ContraAccount = 0 WHERE IF(Main_ID = 0,Main_ID = '{0}' OR ID = '{0}',ID = '{0}');", GridView1.GetFocusedRowCellValue("ID"))
                DataObject(SQL)
                Logs("Chart of Accounts", "Contra Account", String.Format("Reset Contra Account for {0}.", GridView1.GetFocusedRowCellValue("Mother Account")), "", "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        Else
            If MsgBoxYes("Are you sure you want to set this Account as Contra Account?") = MsgBoxResult.Yes Then
                Dim SQL As String = String.Format("UPDATE account_chart SET ContraAccount = 1 WHERE IF(Main_ID = 0,Main_ID = '{0}' OR ID = '{0}',ID = '{0}');", GridView1.GetFocusedRowCellValue("ID"))
                DataObject(SQL)
                Logs("Chart of Accounts", "Contra Account", String.Format("Contra Account for {0}.", GridView1.GetFocusedRowCellValue("Mother Account")), "", "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End If
    End Sub

    Private Sub IAdjunct_Click(sender As Object, e As EventArgs) Handles iAdjunct.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("AdjunctAccount") = 1 Then
            If MsgBoxYes("Account is already set as Adjunct Account, would you like to reset this account?") = MsgBoxResult.Yes Then
                Dim SQL As String = String.Format("UPDATE account_chart SET AdjunctAccount = 0, AdjunctMain = 0 WHERE IF(Main_ID = 0,ID = '{0}',Main_ID = '{0}');", If(GridView1.GetFocusedRowCellValue("Main_ID") = 0, GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Main_ID")))
                DataObject(SQL)
                Logs("Chart of Accounts", "Adjunct Account", String.Format("Reset Adjunct Account for {0}.", GridView1.GetFocusedRowCellValue("Mother Account")), "", "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        Else
            If MsgBoxYes("Are you sure you want to set this Account as Adjunct Account?") = MsgBoxResult.Yes Then
                Dim Tag As New FrmSelectGL
                With Tag
                    .btnAdd.Text = "Save"
                    .From_Adjunct = True
                    .AccountID = If(GridView1.GetFocusedRowCellValue("Main_ID") = 0, GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Main_ID"))
                    .AdjunctAccount = If(GridView1.GetFocusedRowCellValue("Main_ID") = 0, GridView1.GetFocusedRowCellValue("Mother Account"), GridView1.GetFocusedRowCellValue("Sub-Account"))
                    .cbxAccount.Focus()
                    If .ShowDialog = DialogResult.OK Then
                        Dim SQL As String = String.Format("UPDATE account_chart SET AdjunctAccount = 1, AdjunctMain = {1} WHERE IF(Main_ID = 0,ID = '{0}',Main_ID = '{0}');", If(GridView1.GetFocusedRowCellValue("Main_ID") = 0, GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Main_ID")), .cbxAccount.SelectedValue)
                        DataObject(SQL)
                        Logs("Chart of Accounts", "Adjunct Account", String.Format("Adjunct Account for {0}.", GridView1.GetFocusedRowCellValue("Mother Account")), "", "", "", "")
                        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                        LoadData()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub IBank_Click(sender As Object, e As EventArgs) Handles iBank.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Tag As New FrmBankTagged
        With Tag
            If GridView1.GetFocusedRowCellValue("BankTagged").ToString = "" Then
            Else
                .Bank = GridView1.GetFocusedRowCellValue("BankTagged")
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String
                If GridView1.GetFocusedRowCellValue("BankTagged").ToString = "" Then
                    SQL = String.Format("INSERT INTO account_bank SET AccountID = '{0}', BankID = '{1}', BranchID = '{2}';", GridView1.GetFocusedRowCellValue("ID"), ValidateComboBox(.cbxBank), Branch_ID)
                Else
                    SQL = String.Format("UPDATE account_bank SET `status` = IF({2} = 0,'CANCELLED','ACTIVE'), BankID = IF({2} = 0,0,{2}) WHERE AccountID = '{0}' AND BranchID = '{1}';", GridView1.GetFocusedRowCellValue("ID"), Branch_ID, ValidateComboBox(.cbxBank))
                End If
                DataObject(SQL)
                Logs("Chart of Accounts", "Bank Tag", String.Format("Bank Tagging for {0}.", GridView1.GetFocusedRowCellValue("Sub-Account")), "", "", "", "")
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IActivate_Click(sender As Object, e As EventArgs) Handles iActivate.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Main_ID") = 0 And iActivate.Text = "Deactivate" Then
            MsgBox("Only Sub-Accounts are allowed to be deactivated.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If iActivate.Text = "Deactivate" Then
            Dim Transactions As DataTable = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Debit', IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' THEN Amount END),0) AS 'Credit' FROM accounting_entry WHERE AccountCode = '{0}' AND `status` = 'ACTIVE';", GridView1.GetFocusedRowCellValue("Sub-Account Code")))
            If Transactions.Rows.Count > 0 Then
                If Transactions(0)("Debit") <> Transactions(0)("Credit") Then
                    MsgBox(String.Format("Account {0} Total Debit is {1} and Total Credit is {2}, deactivating is not allowed on not balanced accounts.", GridView1.GetFocusedRowCellValue("Sub-Account"), FormatNumber(Transactions(0)("Debit"), 2), FormatNumber(Transactions(0)("Credit"), 2)), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        End If
        If MsgBoxYes(String.Format("Are you sure you want to {0} {1}?", iActivate.Text.ToUpper, GridView1.GetFocusedRowCellValue("Sub-Account"))) = MsgBoxResult.Yes Then
            Dim SQL As String = String.Format("UPDATE account_chart SET `status` = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), If(iActivate.Text = "Activate", "ACTIVE", "DEACTIVATE"))
            DataObject(SQL)
            Logs("Chart of Accounts", iActivate.Text, String.Format("Account {0} is {1}d.", GridView1.GetFocusedRowCellValue("Sub-Account"), iActivate.Text.ToUpper), "", "", "", "")
            MsgBox("Successfully " & iActivate.Text & "d", MsgBoxStyle.Information, "Info")
            LoadData()
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Status") = "ACTIVE" Then
            iActivate.Text = "Deactivate"
        Else
            iActivate.Text = "Activate"
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
                Dim Contra As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("ContraAccount"))
                Dim Adjunct As Boolean = View.GetRowCellValue(e.RowHandle, View.Columns("AdjunctAccount"))
                If Status = "ACTIVE" And Adjunct = False And Contra = False Then
                    e.Appearance.ForeColor = Color.Black
                ElseIf Status = "ACTIVE" And Adjunct = True Then
                    e.Appearance.ForeColor = Color.DarkGoldenrod
                ElseIf Status = "ACTIVE" And Contra = True Then
                    e.Appearance.ForeColor = Color.DarkBlue
                Else
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class