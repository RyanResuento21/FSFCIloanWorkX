Public Class FrmRequirementSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmRequirementSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        With cbxProduct
            .DisplayMember = "product"
            .DataSource = DataSource(String.Format("SELECT DISTINCT product FROM product_setup WHERE `status` = 'ACTIVE' ORDER BY product;"))
            .SelectedIndex = -1
        End With
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX3, LabelX4})

            GetTextBoxFontSettings({txtDocument, txtRemarks})

            GetComboBoxFontSettings({cbxProduct})

            GetCheckBoxFontSettings({cbxGen, cbxForProduct, cbxYes, cbxNo, cbxYesM, cbxNoM})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Requirement Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Requirement", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, doc_name AS 'Document', Remarks, IF(is_genreq = 'YES','GENERAL REQUIREMENT',product_code) AS 'Type', is_married AS 'For Married', product_code, Mandatory FROM document_setup WHERE `status` = 'ACTIVE' ORDER BY doc_name;")
        GridView1.Columns("Document").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Document").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtDocument_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDocument.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxGen.Focus()
        End If
    End Sub

    Private Sub CbxGen_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGen.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxForProduct.Focus()
        End If
    End Sub

    Private Sub CbxForProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxForProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxProduct.Focus()
        End If
    End Sub

    Private Sub CbxProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxYes.Focus()
        End If
    End Sub

    Private Sub CbxYes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxYes.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNo.Focus()
        End If
    End Sub

    Private Sub CbxNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtDocument_Leave(sender As Object, e As EventArgs) Handles txtDocument.Leave
        txtDocument.Text = ReplaceText(txtDocument.Text.Trim)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text.Trim)
    End Sub
    '***LEAVE

    Private Sub CbxGen_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGen.CheckedChanged
        If cbxGen.Checked Then
            cbxForProduct.Checked = False
        End If
    End Sub

    Private Sub CbxForProduct_CheckedChanged(sender As Object, e As EventArgs) Handles cbxForProduct.CheckedChanged
        If cbxForProduct.Checked Then
            cbxGen.Checked = False
            cbxProduct.Enabled = True
        Else
            cbxProduct.Enabled = False
            cbxProduct.Text = ""
        End If
    End Sub

    Private Sub CbxYes_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYes.CheckedChanged
        If cbxYes.Checked Then
            cbxNo.Checked = False
        End If

        If cbxYes.Checked = False And cbxNo.Checked = False Then
            cbxYes.Checked = True
        End If
    End Sub

    Private Sub CbxNo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNo.CheckedChanged
        If cbxNo.Checked Then
            cbxYes.Checked = False
        End If

        If cbxYes.Checked = False And cbxNo.Checked = False Then
            cbxYes.Checked = True
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
        txtDocument.Text = ""
        txtRemarks.Text = ""
        cbxGen.Checked = True
        cbxYes.Checked = True
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

        If txtDocument.Text.Trim = "" Then
            MsgBox("Please fill document field.", MsgBoxStyle.Information, "Info")
            txtDocument.Focus()
            Exit Sub
        End If
        If cbxGen.Checked = False And cbxForProduct.Checked = False Then
            MsgBox("Please select type.", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf cbxForProduct.Checked And cbxProduct.Text = "" Then
            MsgBox("Please select product.", MsgBoxStyle.Information, "Info")
            cbxProduct.DroppedDown = True
            Exit Sub
        End If
        If cbxYes.Checked = False And cbxNo.Checked = False Then
            MsgBox("Please select for married.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM document_setup WHERE (doc_name = '{0}' AND IF('{1}' = 'YES',is_genreq = 'YES',product_code = '{1}')) AND `status` = 'ACTIVE';", txtDocument.Text, If(cbxGen.Checked, "YES", cbxProduct.Text)))
                If Exist > 0 Then
                    MsgBox(String.Format("Document ({0}) already exist for {1}, Please check your data.", txtDocument.Text, If(cbxGen.Checked, "GENERAL REQUIREMENT", cbxProduct.Text)), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO document_setup SET"
                SQL &= String.Format(" doc_name = '{0}', ", txtDocument.Text.Trim)
                SQL &= String.Format(" remarks = '{0}',", txtRemarks.Text.Trim)
                SQL &= String.Format(" is_genreq = '{0}', ", If(cbxGen.Checked, "YES", "NO"))
                SQL &= String.Format(" is_married = '{0}',", If(cbxYes.Checked, "YES", "NO"))
                SQL &= String.Format(" mandatory = '{0}',", If(cbxYesM.Checked, "YES", "NO"))
                SQL &= String.Format(" product_code = '{0}'", cbxProduct.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Requirement", "Save", String.Format("Add new requirement {0}", txtDocument.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM document_setup WHERE (doc_name = '{0}' AND IF('{1}' = 'YES',is_genreq = 'YES',product_code = '{1}')) AND `status` = 'ACTIVE' AND ID != '{2}';", txtDocument.Text, If(cbxGen.Checked, "YES", cbxProduct.Text), ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Document ({0}) already exist for {1}, Please check your data.", txtDocument.Text, If(cbxGen.Checked, "GENERAL REQUIREMENT", cbxProduct.Text)), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE document_setup SET"
                SQL &= String.Format(" doc_name = '{0}', ", txtDocument.Text.Trim)
                SQL &= String.Format(" remarks = '{0}',", txtRemarks.Text.Trim)
                SQL &= String.Format(" is_genreq = '{0}', ", If(cbxGen.Checked, "YES", "NO"))
                SQL &= String.Format(" is_married = '{0}',", If(cbxYes.Checked, "YES", "NO"))
                SQL &= String.Format(" mandatory = '{0}',", If(cbxYesM.Checked, "YES", "NO"))
                SQL &= String.Format(" product_code = '{0}'", cbxProduct.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Requirement", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtDocument.Text = txtDocument.Tag Then
            Else
                Change &= String.Format("Change Document from {0} to {1}. ", txtDocument.Tag, txtDocument.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks Code from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
            If cbxGen.Tag <> "YES" And cbxGen.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", cbxProduct.Tag, "GENERAL REQUIREMENT")
            ElseIf cbxProduct.Tag = "" And cbxForProduct.Checked Then
                Change &= String.Format("Change Type from {0} to {1}. ", "GENERAL REQUIREMENT", cbxProduct.Text)
            End If
            If cbxYes.Tag <> "YES" And cbxYes.Checked Then
                Change &= String.Format("Change For Married ONLY from {0} to {1}. ", cbxYes.Tag, cbxYes.Text)
            ElseIf cbxNo.Tag <> "NO" And cbxNo.Checked Then
                Change &= String.Format("Change For Married ONLY from {0} to {1}. ", cbxNo.Tag, cbxNo.Text)
            End If
            If cbxYesM.Tag <> "YES" And cbxYesM.Checked Then
                Change &= String.Format("Change Mandatory from {0} to {1}. ", cbxYesM.Tag, cbxYesM.Text)
            ElseIf cbxNoM.Tag <> "NO" And cbxNoM.Checked Then
                Change &= String.Format("Change Mandatory from {0} to {1}. ", cbxNoM.Tag, cbxNoM.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Requirement Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE document_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Requirement", "Cancel", Reason, String.Format("Cancel Requirement {0}", txtDocument.Text), "", "", "")
            Clear(True)
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
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
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("REQUIREMENT LIST", GridControl1)
        Logs("Requirement", "Print", "Print Requirement List", "", "", "", "")
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
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
            txtDocument.Text = .GetFocusedRowCellValue("Document")
            txtDocument.Tag = .GetFocusedRowCellValue("Document")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            If .GetFocusedRowCellValue("Type") = "GENERAL REQUIREMENT" Then
                cbxGen.Checked = True
                cbxProduct.Tag = ""
            Else
                cbxForProduct.Checked = True
                cbxProduct.Text = .GetFocusedRowCellValue("Type")
                cbxProduct.Tag = .GetFocusedRowCellValue("Type")
            End If
            cbxGen.Tag = .GetFocusedRowCellValue("Type")
            If .GetFocusedRowCellValue("For Married") = "YES" Then
                cbxYes.Checked = True
            Else
                cbxNo.Checked = True
            End If
            cbxYes.Tag = .GetFocusedRowCellValue("For Married")
            cbxNo.Tag = .GetFocusedRowCellValue("For Married")

            If .GetFocusedRowCellValue("Mandatory") = "YES" Then
                cbxYesM.Checked = True
            Else
                cbxNoM.Checked = True
            End If
            cbxYesM.Tag = .GetFocusedRowCellValue("Mandatory")
            cbxNoM.Tag = .GetFocusedRowCellValue("Mandatory")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxYesM_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYesM.CheckedChanged
        If cbxYesM.Checked Then
            cbxNoM.Checked = False
        End If

        If cbxYesM.Checked = False And cbxNoM.Checked = False Then
            cbxYesM.Checked = True
        End If
    End Sub

    Private Sub CbxNoM_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNoM.CheckedChanged
        If cbxNoM.Checked Then
            cbxYesM.Checked = False
        End If

        If cbxYesM.Checked = False And cbxNoM.Checked = False Then
            cbxYesM.Checked = True
        End If
    End Sub
End Class