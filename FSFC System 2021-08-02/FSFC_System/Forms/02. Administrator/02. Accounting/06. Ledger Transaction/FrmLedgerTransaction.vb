Public Class FrmLedgerTransaction

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmLedgerTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2})

            GetTextBoxFontSettings({txtTransaction, txtTransactionCode})

            GetCheckBoxFontSettings({cbxRE, cbxVE})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Ledger Transaction - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Transaction", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, Transaction_Code AS 'Transaction Code', `Transaction`, `Type` AS 'For' FROM ledger_transaction WHERE `status` = 'ACTIVE' ORDER BY `Transaction`;")
        GridView1.Columns("Transaction").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Transaction").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 632
        Else
            GridColumn2.Width = 649
        End If
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransaction.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTransactionCode.Focus()
        End If
    End Sub

    Private Sub TxtTransactionCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTransactionCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtTransaction_Leave(sender As Object, e As EventArgs) Handles txtTransaction.Leave
        txtTransaction.Text = ReplaceText(txtTransaction.Text.Trim)
    End Sub

    Private Sub TxtTransactionCode_Leave(sender As Object, e As EventArgs) Handles txtTransactionCode.Leave
        txtTransactionCode.Text = ReplaceText(txtTransactionCode.Text.Trim)
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
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        txtTransaction.Text = ""
        txtTransactionCode.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtTransaction.Text = "" Then
            MsgBox("Please fill transaction field.", MsgBoxStyle.Information, "Info")
            txtTransaction.Focus()
            Exit Sub
        End If
        If txtTransactionCode.Text = "" Then
            MsgBox("Please fill transaction code field.", MsgBoxStyle.Information, "Info")
            txtTransactionCode.Focus()
            Exit Sub
        End If
        Dim Type As String = "RE & VE"
        If cbxRE.Checked And cbxVE.Checked Then
            Type = "RE & VE"
        ElseIf cbxRE.Checked Then
            Type = "RE"
        ElseIf cbxVE.Checked Then
            Type = "VE"
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ledger_transaction WHERE (`Transaction` = '{0}' OR Transaction_code = '{1}') AND `status` = 'ACTIVE'", txtTransaction.Text, txtTransactionCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Either transaction name ({0}) or transaction code ({1}) already exist, Please check your data.", txtTransaction.Text, txtTransactionCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO ledger_transaction SET"
                SQL &= String.Format(" `Transaction` = '{0}', ", txtTransaction.Text)
                SQL &= String.Format(" Transaction_code = '{0}', ", txtTransactionCode.Text)
                SQL &= String.Format(" `Type` = '{0}' ", Type)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Transaction", "Save", String.Format("Add new transaction {0}", txtTransaction.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ledger_transaction WHERE (`Transaction` = '{0}' OR Transaction_code = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtTransaction.Text, txtTransactionCode.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either transaction name ({0}) or transaction code ({1}) already exist, Please check your data.", txtTransaction.Text, txtTransactionCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE ledger_transaction SET"
                SQL &= String.Format(" `Transaction` = '{0}', ", txtTransaction.Text)
                SQL &= String.Format(" Transaction_code = '{0}', ", txtTransactionCode.Text)
                SQL &= String.Format(" `Type` = '{0}' ", Type)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Transaction", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtTransaction.Text = txtTransaction.Tag Then
            Else
                Change &= String.Format("Change Transaction from {0} to {1}. ", txtTransaction.Tag, txtTransaction.Text)
            End If
            If txtTransactionCode.Text = txtTransactionCode.Tag Then
            Else
                Change &= String.Format("Change Transaction Code from {0} to {1}. ", txtTransactionCode.Tag, txtTransactionCode.Text)
            End If
            If cbxRE.Tag <> "RE & VE" And cbxRE.Checked And cbxVE.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxRE.Tag, "RE & VE")
            ElseIf cbxRE.Tag <> "RE" And cbxRE.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxRE.Tag, "RE")
            ElseIf cbxVE.Tag <> "VE" And cbxVE.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxVE.Tag, "VE")
            End If
        Catch ex As Exception
            TriggerBugReport("Ledger Transaction - Changes", ex.Message.ToString)
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

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE ledger_transaction SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Transaction", "Cancel", Reason, String.Format("Cancel transaction {0}", txtTransaction.Text), "", "", "")
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
        StandardPrinting("LEDGER TRANSACTION LIST", GridControl1)
        Logs("Ledger Transaction List", "Print", "Print Ledger Transaction List", "", "", "", "")
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
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            txtTransaction.Text = .GetFocusedRowCellValue("Transaction")
            txtTransaction.Tag = .GetFocusedRowCellValue("Transaction")
            txtTransactionCode.Text = .GetFocusedRowCellValue("Transaction Code")
            txtTransactionCode.Tag = .GetFocusedRowCellValue("Transaction Code")
            cbxRE.Tag = .GetFocusedRowCellValue("For")
            cbxVE.Tag = .GetFocusedRowCellValue("For")
            If .GetFocusedRowCellValue("For") = "RE & VE" Then
                cbxRE.Checked = True
                cbxVE.Checked = True
            ElseIf .GetFocusedRowCellValue("For") = "RE" Then
                cbxRE.Checked = True
                cbxVE.Checked = False
            ElseIf .GetFocusedRowCellValue("For") = "VE" Then
                cbxRE.Checked = False
                cbxVE.Checked = True
            End If
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

    Private Sub CbxRE_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRE.CheckedChanged
        If cbxRE.Checked = False And cbxVE.Checked = False Then
            cbxRE.Checked = True
        End If
    End Sub

    Private Sub CbxVE_CheckedChanged(sender As Object, e As EventArgs) Handles cbxVE.CheckedChanged
        If cbxRE.Checked = False And cbxVE.Checked = False Then
            cbxRE.Checked = True
        End If
    End Sub
End Class