Public Class FrmWithholdingSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmWithholdingSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            GetLabelFontSettings({LabelX2, LabelX6, LabelX7, LabelX1})

            GetTextBoxFontSettings({txtNature, txtIndividual, txtCorporate})

            GetCheckBoxFontSettings({cbxIndividual, cbxCorporate})

            GetDoubleInputFontSettings({dTax})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Withholding Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Withholding Tax Type", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    Nature AS 'Nature of Income Payment',"
        SQL &= "    FORMAT(Tax,2) AS 'Tax Rate',"
        SQL &= "    `Type`,"
        SQL &= "    ATC_Individual AS 'Individual ATC',"
        SQL &= "    ATC_Corporate AS 'Corporate ATC'"
        SQL &= " FROM withholding_tax WHERE `status` = 'ACTIVE' ORDER BY ATC_Individual, ATC_Corporate;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Nature of Income Payment").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Nature of Income Payment").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 835 - 17
        Else
            GridColumn2.Width = 835
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub TxtNature_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNature.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTax.Focus()
        End If
    End Sub

    Private Sub DTax_KeyDown(sender As Object, e As KeyEventArgs) Handles dTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtIndividual.Enabled Then
                txtIndividual.Focus()
            ElseIf txtCorporate.Enabled Then
                txtCorporate.Focus()
            End If
        End If
    End Sub

    Private Sub TxtIndividual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIndividual.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCorporate.Enabled Then
                txtCorporate.Focus()
            Else
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCorporate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorporate.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
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
        txtNature.Text = ""
        dTax.Value = 0
        cbxIndividual.Checked = True
        txtIndividual.Text = ""
        cbxCorporate.Checked = True
        txtCorporate.Text = ""
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

        If txtNature.Text = "" Then
            MsgBox("Please fill Nature of Income Payment.", MsgBoxStyle.Information, "Info")
            txtNature.Focus()
            Exit Sub
        End If
        If cbxIndividual.Checked And txtIndividual.Text = "" Then
            MsgBox("Please fill Individual ATC.", MsgBoxStyle.Information, "Info")
            txtIndividual.Focus()
            Exit Sub
        End If
        If cbxCorporate.Checked And txtCorporate.Text = "" Then
            MsgBox("Please fill Corporate ATC.", MsgBoxStyle.Information, "Info")
            txtCorporate.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM withholding_tax WHERE (ATC_Individual = '{0}' OR ATC_Corporate = '{1}') AND `status` = 'ACTIVE';", txtIndividual.Text.Trim.InsertQuote, txtCorporate.Text.Trim.InsertQuote))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Individual ATC {0} or Corporate ATC {1} for Withholding Tax Type already exist, Please check your data.", txtIndividual.Text.Trim.InsertQuote, txtCorporate.Text.Trim.InsertQuote), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO withholding_tax SET"
                SQL &= String.Format(" Nature = '{0}', ", txtNature.Text.Trim.InsertQuote)
                SQL &= String.Format(" Tax = '{0}', ", dTax.Value)
                SQL &= String.Format(" Type = '{0}', ", If(cbxIndividual.Checked And cbxCorporate.Checked, 3, If(cbxIndividual.Checked, 1, 2)))
                SQL &= String.Format(" ATC_Individual = '{0}', ", txtIndividual.Text.Trim.InsertQuote)
                SQL &= String.Format(" ATC_Corporate = '{0}';", txtCorporate.Text.Trim.InsertQuote)
                DataObject(SQL)

                Logs("Withholding Tax Type", "Save", String.Format("Add new Withholding Tax type {0}", txtNature.Text.Trim.InsertQuote), "", "", "", "")
                DT_Withholding_Individual = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (1,3) ORDER BY ATC_Individual;")
                DT_Withholding_Corporate = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (2,3) ORDER BY ATC_Corporate;")
                If cbxIndividual.Checked Then
                    With FrmSupplier.cbxWithholding
                        .DataSource = DT_Withholding_Individual.Copy
                        .DisplayMember = "ATC_Individual"
                        .ValueMember = "ID"
                    End With
                Else
                    With FrmSupplier.cbxWithholding
                        .DataSource = DT_Withholding_Corporate.Copy
                        .DisplayMember = "ATC_Corporate"
                        .ValueMember = "ID"
                    End With
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM withholding_tax WHERE (ATC_Individual = '{0}' OR ATC_Corporate = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}';", txtIndividual.Text.Trim.InsertQuote, txtCorporate.Text.Trim.InsertQuote, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Individual ATC {0} or Corporate ATC {1} for Withholding Tax Type already exist, Please check your data.", txtIndividual.Text.Trim.InsertQuote, txtCorporate.Text.Trim.InsertQuote), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE withholding_tax SET"
                SQL &= String.Format(" Nature = '{0}', ", txtNature.Text.Trim.InsertQuote)
                SQL &= String.Format(" Tax = '{0}', ", dTax.Value)
                SQL &= String.Format(" Type = '{0}', ", If(cbxIndividual.Checked And cbxCorporate.Checked, 3, If(cbxIndividual.Checked, 1, 2)))
                SQL &= String.Format(" ATC_Individual = '{0}', ", txtIndividual.Text.Trim.InsertQuote)
                SQL &= String.Format(" ATC_Corporate = '{0}'", txtCorporate.Text.Trim.InsertQuote)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Withholding Tax Type", "Update", Reason, Changes(), "", "", "")
                DT_Withholding_Individual = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (1,3) ORDER BY ATC_Individual;")
                DT_Withholding_Corporate = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (2,3) ORDER BY ATC_Corporate;")
                If cbxIndividual.Checked Then
                    With FrmSupplier.cbxWithholding
                        .DataSource = DT_Withholding_Individual.Copy
                        .DisplayMember = "ATC_Individual"
                        .ValueMember = "ID"
                    End With
                Else
                    With FrmSupplier.cbxWithholding
                        .DataSource = DT_Withholding_Corporate.Copy
                        .DisplayMember = "ATC_Corporate"
                        .ValueMember = "ID"
                    End With
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtNature.Text = txtNature.Tag Then
            Else
                Change &= String.Format("Change Nature from {0} to {1}. ", txtNature.Tag.ToString.Trim.InsertQuote, txtNature.Text.Trim.InsertQuote)
            End If
            If dTax.Text = dTax.Tag Then
            Else
                Change &= String.Format("Change Tax Rate from {0} to {1}. ", dTax.Tag, dTax.Text)
            End If
            If txtIndividual.Text = txtIndividual.Tag Then
            Else
                Change &= String.Format("Change Individual ATC from {0} to {1}. ", txtIndividual.Tag.ToString.Trim.InsertQuote, txtIndividual.Text.Trim.InsertQuote)
            End If
            If txtCorporate.Text = txtCorporate.Tag Then
            Else
                Change &= String.Format("Change Corporate ATC from {0} to {1}. ", txtCorporate.Tag.ToString.Trim.InsertQuote, txtCorporate.Text.Trim.InsertQuote)
            End If
        Catch ex As Exception
            TriggerBugReport("Withholding Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE withholding_tax SET `status` = 'DELETED' WHERE ID = '{0}';", ID))
            Logs("Withholding Tax Type", "Delete", Reason, String.Format("Delete Withholding Tax Type {0}.", txtNature.Text.Trim.InsertQuote), "", "", "")
            DT_Withholding_Individual = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (1,3) ORDER BY ATC_Individual;")
            DT_Withholding_Corporate = DataSource("SELECT ID, Nature, Tax, ATC_Individual, ATC_Corporate FROM withholding_tax WHERE `status` = 'ACTIVE' AND `Type` IN (2,3) ORDER BY ATC_Corporate;")
            If cbxIndividual.Checked Then
                With FrmSupplier.cbxWithholding
                    .DataSource = DT_Withholding_Individual.Copy
                    .DisplayMember = "ATC_Individual"
                    .ValueMember = "ID"
                End With
            Else
                With FrmSupplier.cbxWithholding
                    .DataSource = DT_Withholding_Corporate.Copy
                    .DisplayMember = "ATC_Corporate"
                    .ValueMember = "ID"
                End With
            End If
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
        StandardPrinting("WITHHOLDING TAX LIST", GridControl1)
        Logs("Withholding Setup", "Print", "[SENSITIVE] Print Withholding List", "", "", "", "")
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
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
            txtNature.Text = .GetFocusedRowCellValue("Nature of Income Payment")
            txtNature.Tag = .GetFocusedRowCellValue("Nature of Income Payment")
            dTax.Value = .GetFocusedRowCellValue("Tax Rate")
            dTax.Tag = .GetFocusedRowCellValue("Tax Rate")
            If .GetFocusedRowCellValue("Type") = 3 Then
                cbxIndividual.Checked = True
                cbxCorporate.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = 1 Then
                cbxIndividual.Checked = True
                cbxCorporate.Checked = False
            Else
                cbxIndividual.Checked = False
                cbxCorporate.Checked = True
            End If
            txtIndividual.Text = .GetFocusedRowCellValue("Individual ATC")
            txtIndividual.Tag = .GetFocusedRowCellValue("Individual ATC")
            txtCorporate.Text = .GetFocusedRowCellValue("Corporate ATC")
            txtCorporate.Tag = .GetFocusedRowCellValue("Corporate ATC")
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

    Private Sub CbxIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIndividual.CheckedChanged
        If cbxIndividual.Checked Then
            txtIndividual.Enabled = True
        Else
            txtIndividual.Enabled = False
            txtIndividual.Text = ""
        End If
    End Sub

    Private Sub CbxCorporate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCorporate.CheckedChanged
        If cbxCorporate.Checked Then
            txtCorporate.Enabled = True
        Else
            txtCorporate.Enabled = False
            txtCorporate.Text = ""
        End If
    End Sub
End Class