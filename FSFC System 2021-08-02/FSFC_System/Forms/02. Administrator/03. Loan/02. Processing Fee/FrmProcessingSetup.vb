Public Class FrmProcessingSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim ServiceCode As Double
    Private Sub FrmProcessingSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        SuperTabControl1.SelectedTab = tabList

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY branchID;")
            .SelectedValue = Branch_ID
        End With

        With cbxBranch_2
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY branchID;")
            .SelectedValue = Branch_ID
        End With

        With txtProcessing
            .ValueMember = "ID"
            .DisplayMember = "processing_fee"
            .DataSource = DataSource("SELECT ID, processing_fee, processing_code FROM processing_fee WHERE `status` = 'ACTIVE' GROUP BY processing_fee ORDER BY processing_fee;")
            .SelectedIndex = -1
        End With
        LoadData()
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX6, LabelX3, LabelX4, LabelX5})

            GetTextBoxFontSettings({txtCode})

            GetComboBoxFontSettings({cbxBranch, txtProcessing, cbxBranch_2, cbxProduct, cbxProcessing})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAddProcessing, btnRemoveProcessing})

            GetTabControlFontSettings({SuperTabControl1})

            GetDoubleInputFontSettings({dAmount_2})
        Catch ex As Exception
            TriggerBugReport("Processing Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Additional Charges", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource(String.Format("SELECT ID, processing_fee AS 'Processing Fee', processing_code AS 'Processing Code', branch_id, (SELECT branch FROM branch WHERE ID = branch_id) AS 'Branch' FROM processing_fee WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `Branch`,`Processing Fee`;", IIf(Branch_ID = 0, "%", Branch_ID)))
        GridView1.Columns("Processing Fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Processing Fee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCode.Focus()
        End If
    End Sub

    Private Sub TxtProcessing_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcessing.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCode.Focus()
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub CbxBranch_Leave(sender As Object, e As EventArgs) Handles cbxBranch.Leave
        cbxBranch.Text = ReplaceText(cbxBranch.Text.Trim)
    End Sub

    Private Sub TxtProcessing_Leave(sender As Object, e As EventArgs) Handles txtProcessing.Leave
        txtProcessing.Text = ReplaceText(txtProcessing.Text.Trim)
    End Sub

    Private Sub TxtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        txtCode.Text = ReplaceText(txtCode.Text.Trim)
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
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = False
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
        cbxBranch.Enabled = True
        cbxBranch.SelectedValue = Branch_ID
        txtProcessing.Text = ""
        txtCode.Text = ""
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

        If txtProcessing.Text = "" Then
            MsgBox("Please fill additional charges field.", MsgBoxStyle.Information, "Info")
            txtProcessing.Focus()
            Exit Sub
        End If
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM processing_fee WHERE (processing_fee = '{0}' OR processing_code = '{1}')  AND `status` = 'ACTIVE' AND branch_id LIKE '{2}'", txtProcessing.Text, txtCode.Text, cbxBranch.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Additional Charges ({0}) or Charge Code ({1}) already exist, Please check your data.", txtProcessing.Text, txtCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO processing_fee SET"
                SQL &= String.Format(" `processing_fee` = '{0}',", txtProcessing.Text)
                SQL &= String.Format(" processing_code = '{0}',", txtCode.Text)
                SQL &= String.Format(" user_id = '{0}',", User_ID)
                SQL &= String.Format(" branch_id = '{0}'", cbxBranch.SelectedValue)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Additional Charges", "Save", String.Format("Add new Additional Charges {0}", txtProcessing.Text), "", "", "", "")
                Clear(True)
                cbxProcessing.DataSource = DataSource("SELECT ID, CONCAT(processing_fee, ' [',processing_code,']') AS 'processing_fee', processing_code, default_amount FROM processing_fee WHERE `status` = 'ACTIVE' ORDER BY processing_fee;")
                txtProcessing.DataSource = DataSource("SELECT ID, processing_fee, processing_code FROM processing_fee WHERE `status` = 'ACTIVE' GROUP BY processing_fee ORDER BY processing_fee;")
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM processing_fee WHERE (processing_fee = '{0}' OR processing_code = '{1}') AND `status` = 'ACTIVE' AND branch_id LIKE '{3}' AND ID != '{2}'", txtProcessing.Text, txtCode.Text, ID, cbxBranch.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Additional Charges ({0}) or Charges Code ({1}) already exist, Please check your data.", txtProcessing.Text, txtCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE processing_fee SET"
                SQL &= String.Format(" `processing_fee` = '{0}',", txtProcessing.Text)
                SQL &= String.Format(" processing_code = '{0}'", txtCode.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Additional Charges", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                cbxProcessing.DataSource = DataSource("SELECT ID, CONCAT(processing_fee, ' [',processing_code,']') AS 'processing_fee', processing_code, default_amount FROM processing_fee WHERE `status` = 'ACTIVE' ORDER BY processing_fee;")
                txtProcessing.DataSource = DataSource("SELECT ID, processing_fee, processing_code FROM processing_fee WHERE `status` = 'ACTIVE' GROUP BY processing_fee ORDER BY processing_fee;")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtProcessing.Text = txtProcessing.Tag Then
            Else
                Change &= String.Format("Change Additional Charges from {0} to {1}. ", txtProcessing.Tag, txtProcessing.Text)
            End If
            If txtCode.Text = txtCode.Tag Then
            Else
                Change &= String.Format("Change Charges Code from {0} to {1}. ", txtCode.Tag, txtCode.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Processing Setup - Changes", ex.Message.ToString)
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
            cbxBranch.Enabled = False
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
            DataObject(String.Format("UPDATE processing_fee SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Additional Charges", "Cancel", Reason, String.Format("Cancel Additional Charges {0}", txtProcessing.Text), "", "", "")
            Clear(True)
            cbxProcessing.DataSource = DataSource("SELECT ID, CONCAT(processing_fee, ' [',processing_code,']') AS 'processing_fee', processing_code, default_amount FROM processing_fee WHERE `status` = 'ACTIVE' ORDER BY processing_fee;")
            txtProcessing.DataSource = DataSource("SELECT ID, processing_fee, processing_code FROM processing_fee WHERE `status` = 'ACTIVE' GROUP BY processing_fee ORDER BY processing_fee;")
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
        StandardPrinting("PROCESSING LIST", GridControl1)
        Logs("Processing", "Print", "Print Processing List", "", "", "", "")
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
            cbxBranch.Text = .GetFocusedRowCellValue("Branch")
            txtProcessing.Text = .GetFocusedRowCellValue("Processing Fee")
            txtProcessing.Tag = .GetFocusedRowCellValue("Processing Fee")
            txtCode.Text = .GetFocusedRowCellValue("Processing Code")
            txtCode.Tag = .GetFocusedRowCellValue("Processing Code")
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

    Private Sub BtnAddProcessing_Click(sender As Object, e As EventArgs) Handles btnAddProcessing.Click
        If cbxProduct.Text = "" Or cbxProduct.SelectedIndex = -1 Then
            MsgBox("Please select product first.", MsgBoxStyle.Information, "Info")
            cbxProduct.DroppedDown = True
            Exit Sub
        End If
        If cbxProcessing.Text = "" Then
            MsgBox("Please select Additional Charges first.", MsgBoxStyle.Information, "Info")
            cbxProcessing.DroppedDown = True
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure want to add this Additional Charges {1} for product {0}?", cbxProduct.Text, cbxProcessing.Text)) = MsgBoxResult.Yes Then
            Dim drv As DataRowView = DirectCast(cbxProcessing.SelectedItem, DataRowView)

            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Processing Fee") = drv("processing_code") Then
                    MsgBox(String.Format("Additional Charges {0} already exist in {1}.", drv("processing_code"), cbxProduct.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next

            ServiceCode = DataObject(String.Format("SELECT IFNULL(MAX(ID),0) + 1 FROM processing_setup WHERE Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

            With GridView2
                .AddNewRow()
                .SetFocusedRowCellValue("processing_code", CInt(Branch_ID).ToString("D3") & "-" & CInt(ServiceCode).ToString("D5"))
                .SetFocusedRowCellValue("Processing Fee", drv("processing_code"))
                .SetFocusedRowCellValue("Default Amount", dAmount_2.Value)
            End With

            Dim SQL As String = "INSERT INTO processing_setup SET "
            SQL &= String.Format(" processing_code = '{0}', ", GridView2.GetFocusedRowCellValue("processing_code"))
            SQL &= String.Format(" product_id = '{0}', ", cbxProduct.SelectedValue)
            SQL &= String.Format(" fee = '{0}', ", GridView2.GetFocusedRowCellValue("Processing Fee"))
            SQL &= String.Format(" amount = '{0}', ", GridView2.GetFocusedRowCellValue("Default Amount"))
            SQL &= " add_tariff = 'NO', "
            SQL &= String.Format(" branch_id = '{0}'", Branch_ID)
            DataObject(SQL)
            Logs("Processing Setup", "Add", "", String.Format("Add new Additional Charges {0} for product {1}", cbxProcessing.Text, cbxProduct.Text), "", "", "")
            cbxProduct_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub BtnRemoveProcessing_Click(sender As Object, e As EventArgs) Handles btnRemoveProcessing.Click
        If cbxProduct.Text = "" Or cbxProduct.SelectedIndex = -1 Then
            MsgBox("Please select product first.", MsgBoxStyle.Information, "Info")
            cbxProduct.DroppedDown = True
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure want to remove this Additional Charges {1} for product {0}?", cbxProduct.Text, GridView2.GetFocusedRowCellValue("Processing Fee"))) = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE processing_setup SET `status` = 'INACTIVE' WHERE processing_code = '{0}'", GridView2.GetFocusedRowCellValue("processing_code")))
            Logs("Additional Charges", "Remove", "", String.Format("Remove Additional Charges {0} for product {1}", GridView2.GetFocusedRowCellValue("Processing Fee"), cbxProduct.Text), "", "", "")
            cbxProduct_SelectedIndexChanged(sender, e)
            MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxProcessing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProcessing.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If
    End Sub

    Private Sub CbxProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProduct.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridControl2.DataSource = DataSource(String.Format("SELECT processing_code, fee AS 'Processing Fee', amount AS 'Default Amount' FROM processing_setup WHERE `status` = 'ACTIVE' AND product_id = '{0}' ORDER BY `Processing Fee`;", cbxProduct.SelectedValue))
        GridView2.Columns("Processing Fee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Processing Fee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
    End Sub

    Private Sub CbxBranch_2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch_2.SelectedIndexChanged
        If cbxBranch_2.SelectedIndex = -1 Or cbxBranch_2.Text = "" Then
            cbxProduct.Text = ""
            cbxProduct.Enabled = False
            cbxProcessing.Text = ""
            cbxProcessing.Enabled = False
            Exit Sub
        Else
            cbxProduct.Enabled = True
            cbxProcessing.Enabled = True
        End If

        With cbxProduct
            .ValueMember = "ID"
            .DisplayMember = "product"
            .DataSource = DataSource(String.Format("SELECT ID, product FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY product;", cbxBranch_2.SelectedValue))
            .SelectedIndex = -1
        End With

        With cbxProcessing
            .ValueMember = "ID"
            .DisplayMember = "processing_fee"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(processing_fee, ' [',processing_code,']') AS 'processing_fee', processing_code FROM processing_fee WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY processing_fee;", cbxBranch_2.SelectedValue))
            .SelectedIndex = -1
        End With
    End Sub
End Class