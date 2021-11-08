Public Class FrmSupplier

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean = True
    Private Sub FrmSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Firstload = True
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxWithholding
            .DisplayMember = "ATC_Corporate"
            .ValueMember = "ID"
            .DataSource = DT_Withholding_Corporate.Copy
        End With

        GenerateCode()
        LoadData()
        Firstload = False
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

            GetLabelFontSettings({LabelX2, LabelX1, LabelX3, LabelX4, LabelX5, LabelX32, LabelX8, LabelX14, LabelX6, LabelX9, LabelX7, lblWithholdingNature})

            GetTextBoxFontSettings({txtSupplier, txtAddress, txtTIN, txtContactNumber, txtContactPerson, txtEmail, txtCode})

            GetCheckBoxFontSettings({cbxIndividual, cbxCorporate, cbxCOD, cbx30D, cbx60D, cbx90D, cbxOthersT, cbxVat, cbxNonVat, cbxTaxExempt, cbxOthers, cbxGoods, cbxServices})

            GetComboBoxFontSettings({cbxWithholding})

            GetDoubleInputFontSettings({dTax})

            GetIntegerInputFontSettings({iOthersD})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Supplier - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Supplier Setup", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    IF(SupplierType = 1, 'INDIVIDUAL','CORPORATE') AS 'Supplier Type',"
        SQL &= "    CodeS, Supplier,"
        SQL &= "    Address,"
        SQL &= "    TIN AS 'TIN Number',"
        SQL &= "    ContactNumber AS 'Contact Number',"
        SQL &= "    ContactPerson AS 'Contact Person',"
        SQL &= "    EmailAddress AS 'Email Address',"
        SQL &= "    IF(VAT = 1,'VAT',IF(VAT = 2,'OTHERS',IF(VAT = 3,'INCOME TAX EXEMPT','NON-VAT'))) AS 'VAT',"
        SQL &= "    IF(`Type` = 1,'GOODS',IF(`Type` = 3,'GOODS AND SERVICES','SERVICES')) AS 'Type',"
        SQL &= "    Type_Tax AS 'Tax',"
        SQL &= "    IF(Terms = 0,'C.O.D.',CONCAT(Terms, ' Days')) AS 'Terms',"
        SQL &= "    Withholding_ATC(Withholding,SupplierType) AS 'Withholding',"
        SQL &= "    BRANCH(branch_id) AS 'Branch'"
        SQL &= String.Format("  FROM supplier_setup WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY Supplier;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn8.Visible = True
            GridColumn8.VisibleIndex = 12
        End If
        GridView1.Columns("Supplier").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Supplier").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn3.Width = 320 - 17
        Else
            GridColumn3.Width = 320
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub TxtSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplier.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAddress.Focus()
        End If
    End Sub

    Private Sub TxtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN.Focus()
        End If
    End Sub

    Private Sub TxtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContactNumber.Focus()
        End If
    End Sub

    Private Sub TxtContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContactPerson.Focus()
        End If
    End Sub

    Private Sub TxtContactPerson_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactPerson.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail.Focus()
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxVat.Focus()
        End If
    End Sub

    Private Sub CbxWithholding_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWithholding.KeyDown
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

    Private Sub GenerateCode()
        txtCode.Text = DataObject(String.Format("SELECT IFNULL(MAX(CodeS),0) + 1 FROM supplier_setup WHERE Branch_ID = '{0}'", Branch_ID))
        txtCode.Text = CInt(txtCode.Text).ToString("D6")
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        GenerateCode()
        PanelEx10.Enabled = True
        txtSupplier.Text = ""
        txtAddress.Text = ""
        txtTIN.Text = ""
        txtContactNumber.Text = ""
        txtContactPerson.Text = ""
        txtEmail.Text = ""
        cbxVat.Checked = True
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

        If txtSupplier.Text = "" Then
            MsgBox("Please fill supplier name.", MsgBoxStyle.Information, "Info")
            txtSupplier.Focus()
            Exit Sub
        End If
        If cbxWithholding.Text = "" Or cbxWithholding.SelectedIndex = -1 Then
            If MsgBoxYes("You haven't select any withholding tax type for this supplier, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                cbxWithholding.DroppedDown = True
            End If
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM supplier_setup WHERE Supplier = '{0}' AND `status` = 'ACTIVE' AND branch_id = '{1}';", txtSupplier.Text.Trim.InsertQuote, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Supplier {0} already exist, Please check your data.", txtSupplier.Text.Trim.InsertQuote), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                GenerateCode()

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO supplier_setup SET"
                SQL &= String.Format(" `CodeS` = '{0}', ", txtCode.Text)
                SQL &= String.Format(" SupplierType = '{0}', ", If(cbxIndividual.Checked, 1, 2))
                SQL &= String.Format(" Supplier = '{0}', ", txtSupplier.Text.Trim.InsertQuote)
                SQL &= String.Format(" Address = '{0}', ", txtAddress.Text.Trim.InsertQuote)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text.Trim.InsertQuote)
                SQL &= String.Format(" ContactNumber = '{0}', ", txtContactNumber.Text.Trim.InsertQuote)
                SQL &= String.Format(" ContactPerson = '{0}', ", txtContactPerson.Text.Trim.InsertQuote)
                SQL &= String.Format(" EmailAddress = '{0}', ", txtEmail.Text.Trim.InsertQuote)
                SQL &= String.Format(" VAT = '{0}', ", If(cbxVat.Checked, 1, If(cbxOthers.Checked, 2, If(cbxOthers.Checked, 3, 0))))
                SQL &= String.Format(" `Type` = '{0}', ", If(cbxGoods.Checked And cbxServices.Checked, 3, If(cbxGoods.Checked, 1, 2)))
                SQL &= String.Format(" `Terms` = '{0}', ", If(cbxCOD.Checked, 0, If(cbx30D.Checked, 30, If(cbx60D.Checked, 60, If(cbx90D.Checked, 90, If(cbxOthersT.Checked, iOthersD.Value, 0))))))
                SQL &= String.Format(" Type_Tax = '{0}', ", dTax.Value)
                SQL &= String.Format(" Withholding = '{0}', ", ValidateComboBox(cbxWithholding))
                SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)

                Logs("Supplier Setup", "Save", String.Format("Add new Supplier {0}", txtSupplier.Text.Trim.InsertQuote), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM supplier_setup WHERE Supplier = '{0}' AND `status` = 'ACTIVE' AND ID != '{1}' AND branch_id = '{2}';", txtSupplier.Text.Trim.InsertQuote, ID, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Supplier {0} already exist, Please check your data.", txtSupplier.Text.Trim.InsertQuote), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE supplier_setup SET"
                SQL &= String.Format(" SupplierType = '{0}', ", If(cbxIndividual.Checked, 1, 2))
                SQL &= String.Format(" Supplier = '{0}', ", txtSupplier.Text.Trim.InsertQuote)
                SQL &= String.Format(" Address = '{0}', ", txtAddress.Text.Trim.InsertQuote)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text.Trim.InsertQuote)
                SQL &= String.Format(" ContactNumber = '{0}', ", txtContactNumber.Text.Trim.InsertQuote)
                SQL &= String.Format(" ContactPerson = '{0}', ", txtContactPerson.Text.Trim.InsertQuote)
                SQL &= String.Format(" EmailAddress = '{0}', ", txtEmail.Text.Trim.InsertQuote)
                SQL &= String.Format(" VAT = '{0}', ", If(cbxVat.Checked, 1, If(cbxOthers.Checked, 2, If(cbxOthers.Checked, 3, 0))))
                SQL &= String.Format(" `Type` = '{0}', ", If(cbxGoods.Checked And cbxServices.Checked, 3, If(cbxGoods.Checked, 1, 2)))
                SQL &= String.Format(" `Terms` = '{0}', ", If(cbxCOD.Checked, 0, If(cbx30D.Checked, 30, If(cbx60D.Checked, 60, If(cbx90D.Checked, 90, If(cbxOthersT.Checked, iOthersD.Value, 0))))))
                SQL &= String.Format(" Withholding = '{0}', ", ValidateComboBox(cbxWithholding))
                SQL &= String.Format(" Type_Tax = '{0}' ", dTax.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Supplier Setup", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If If(cbxIndividual.Checked, "INDIVIDUAL", "CORPORATE") = cbxIndividual.Tag Then
            Else
                Change &= String.Format("Change Supplier Type from {0} to {1}. ", cbxIndividual.Tag, If(cbxIndividual.Checked, "INDIVIDUAL", "CORPORATE"))
            End If
            If txtSupplier.Text = txtSupplier.Tag Then
            Else
                Change &= String.Format("Change Supplier from {0} to {1}. ", txtSupplier.Tag.ToString.Trim.InsertQuote, txtSupplier.Text.Trim.InsertQuote)
            End If
            If txtAddress.Text = txtAddress.Tag Then
            Else
                Change &= String.Format("Change Address from {0} to {1}. ", txtAddress.Tag.ToString.Trim.InsertQuote, txtAddress.Text.Trim.InsertQuote)
            End If
            If txtTIN.Text = txtTIN.Tag Then
            Else
                Change &= String.Format("Change TIN Number from {0} to {1}. ", txtTIN.Tag.ToString.Trim.InsertQuote, txtTIN.Text.Trim.InsertQuote)
            End If
            If txtContactNumber.Text = txtContactNumber.Tag Then
            Else
                Change &= String.Format("Change Contact Number from {0} to {1}. ", txtContactNumber.Tag.ToString.Trim.InsertQuote, txtContactNumber.Text.Trim.InsertQuote)
            End If
            If txtContactPerson.Text = txtContactPerson.Tag Then
            Else
                Change &= String.Format("Change Contact Person from {0} to {1}. ", txtContactPerson.Tag.ToString.Trim.InsertQuote, txtContactPerson.Text.Trim.InsertQuote)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmail.Tag.ToString.Trim.InsertQuote, txtEmail.Text.Trim.InsertQuote)
            End If
            If If(cbxVat.Checked, "VAT", If(cbxOthers.Checked, "OTHERS", If(cbxTaxExempt.Checked, "INCOME TAX EXEMPT", "NON-VAT"))) = cbxVat.Tag Then
            Else
                Change &= String.Format("Change Tax Registration Type from {0} to {1}. ", cbxVat.Tag, If(cbxVat.Checked, "VAT", If(cbxOthers.Checked, "OTHERS", If(cbxTaxExempt.Checked, "INCOME TAX EXEMPT", "NON-VAT"))))
            End If
            If If(cbxGoods.Checked And cbxServices.Checked, "GOODS AND SERVICES", If(cbxGoods.Checked, "GOODS", "SERVICES")) = cbxGoods.Tag Then
            Else
                Change &= String.Format("Change Product Type from {0} to {1}. ", cbxGoods.Tag, If(cbxGoods.Checked And cbxServices.Checked, "GOODS AND SERVICES", If(cbxGoods.Checked, "GOODS", "SERVICES")))
            End If
            If dTax.Text = dTax.Tag Then
            Else
                Change &= String.Format("Change Tax from {0} to {1}. ", dTax.Tag, dTax.Text)
            End If
            If If(cbxCOD.Checked, "C.O.D.", If(cbx30D.Checked, "30 Days", If(cbx60D.Checked, "60 Days", If(cbx90D.Checked, "90 Days", If(cbxOthersT.Checked, iOthersD.Value & " Days", ""))))) = cbxCOD.Tag Then
            Else
                Change &= String.Format("Change Terms from {0} to {1}. ", cbxCOD.Tag, If(cbxCOD.Checked, "C.O.D.", If(cbx30D.Checked, "30 Days", If(cbx60D.Checked, "60 Days", If(cbx90D.Checked, "90 Days", If(cbxOthersT.Checked, iOthersD.Value & " Days", ""))))))
            End If
            If cbxWithholding.Text = cbxWithholding.Tag Then
            Else
                Change &= String.Format("Change Withholding Tax Type from {0} to {1}. ", cbxWithholding.Tag, cbxWithholding.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Supplier - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE supplier_setup SET `status` = 'DELETED' WHERE ID = '{0}';", ID))
            Logs("Supplier Setup", "Cancel", Reason, String.Format("Cancel Supplier {0}.", txtSupplier.Text.Trim.InsertQuote), "", "", "")
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
        StandardPrinting("SUPPLIER LIST", GridControl1)
        Logs("Supplier", "Print", "[SENSITIVE] Print Supplier List", "", "", "", "")
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
            cbxIndividual.Tag = .GetFocusedRowCellValue("Supplier Type")
            If .GetFocusedRowCellValue("Supplier Type") = "INDIVIDUAL" Then
                cbxIndividual.Checked = True
            Else
                cbxCorporate.Checked = True
            End If
            txtCode.Text = .GetFocusedRowCellValue("CodeS")
            txtSupplier.Text = .GetFocusedRowCellValue("Supplier")
            txtSupplier.Tag = .GetFocusedRowCellValue("Supplier")
            txtAddress.Text = .GetFocusedRowCellValue("Address")
            txtAddress.Tag = .GetFocusedRowCellValue("Address")
            txtTIN.Text = .GetFocusedRowCellValue("TIN Number")
            txtTIN.Tag = .GetFocusedRowCellValue("TIN Number")
            txtContactNumber.Text = .GetFocusedRowCellValue("Contact Number")
            txtContactNumber.Tag = .GetFocusedRowCellValue("Contact Number")
            txtContactPerson.Text = .GetFocusedRowCellValue("Contact Person")
            txtContactPerson.Tag = .GetFocusedRowCellValue("Contact Person")
            txtEmail.Text = .GetFocusedRowCellValue("Email Address")
            txtEmail.Tag = .GetFocusedRowCellValue("Email Address")
            If .GetFocusedRowCellValue("VAT") = "VAT" Then
                cbxVat.Checked = True
            ElseIf .GetFocusedRowCellValue("VAT") = "OTHERS" Then
                cbxOthers.Checked = True
            ElseIf .GetFocusedRowCellValue("VAT") = "INCOME TAX EXEMPT" Then
                cbxTaxExempt.Checked = True
            Else
                cbxNonVat.Checked = True
            End If
            cbxVat.Tag = .GetFocusedRowCellValue("VAT")
            If .GetFocusedRowCellValue("Type") = "GOODS AND SERVICES" Then
                cbxGoods.Checked = True
                cbxServices.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "GOODS" Then
                cbxGoods.Checked = True
            Else
                cbxServices.Checked = True
            End If
            cbxGoods.Tag = .GetFocusedRowCellValue("Type")
            dTax.Text = .GetFocusedRowCellValue("Tax")
            dTax.Tag = .GetFocusedRowCellValue("Tax")
            cbxCOD.Tag = .GetFocusedRowCellValue("Terms")
            If .GetFocusedRowCellValue("Terms") = "C.O.D." Then
                cbxCOD.Checked = True
            ElseIf .GetFocusedRowCellValue("Terms") = "30 Days" Then
                cbx30D.Checked = True
            ElseIf .GetFocusedRowCellValue("Terms") = "60 Days" Then
                cbx60D.Checked = True
            ElseIf .GetFocusedRowCellValue("Terms") = "90 Days" Then
                cbx90D.Checked = True
            Else
                cbxOthersT.Checked = True
                iOthersD.Value = .GetFocusedRowCellValue("Terms").ToString.Replace(" Days", "")
            End If
            cbxWithholding.Text = .GetFocusedRowCellValue("Withholding").ToString
            cbxWithholding.Tag = .GetFocusedRowCellValue("Withholding").ToString
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Dim DT_Branch As New DataTable
        'DT_Branch = DataSource("SELECT DISTINCT branch_id FROM supplier_setup ORDER BY branch_id;")
        'Dim DT_PerBranch As New DataTable
        'Dim SQL As String
        'For x As Integer = 0 To DT_Branch.Rows.Count - 1
        '    DT_PerBranch = DataSource(String.Format("SELECT LPAD(ROW_NUMBER() OVER (),6,'0') AS 'Codev2', supplier_setup.* FROM supplier_setup WHERE Branch_ID = {0};", DT_Branch(x)("branch_id")))
        '    For y As Integer = 0 To DT_PerBranch.Rows.Count - 1
        '        DataSource(String.Format("UPDATE supplier_setup SET CodeS = '{1}' WHERE ID = {0};", DT_PerBranch(y)("ID"), DT_PerBranch(y)("Codev2")))
        '    Next
        'Next
        'LoadData()

        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxVat_CheckedChanged(sender As Object, e As EventArgs) Handles cbxVat.CheckedChanged
        If cbxVat.Checked Then
            cbxNonVat.Checked = False
            cbxTaxExempt.Checked = False
            cbxOthers.Checked = False
        End If

        If cbxVat.Checked = False And cbxNonVat.Checked = False And cbxOthers.Checked = False And cbxTaxExempt.Checked = False Then
            cbxVat.Checked = True
        End If
    End Sub

    Private Sub CbxNonVat_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNonVat.CheckedChanged
        If cbxNonVat.Checked Then
            cbxVat.Checked = False
            cbxTaxExempt.Checked = False
            cbxOthers.Checked = False

            dTax.Value = 0
        End If

        If cbxVat.Checked = False And cbxNonVat.Checked = False And cbxOthers.Checked = False And cbxTaxExempt.Checked = False Then
            cbxVat.Checked = True
        End If
    End Sub

    Private Sub CbxOthers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOthers.CheckedChanged
        If cbxOthers.Checked Then
            cbxVat.Checked = False
            cbxNonVat.Checked = False
            cbxTaxExempt.Checked = False

            cbxWithholding.Text = "NA"
        End If

        If cbxVat.Checked = False And cbxNonVat.Checked = False And cbxOthers.Checked = False And cbxTaxExempt.Checked = False Then
            cbxVat.Checked = True
        End If
    End Sub

    Private Sub CbxTaxExempt_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTaxExempt.CheckedChanged
        If cbxTaxExempt.Checked Then
            cbxVat.Checked = False
            cbxNonVat.Checked = False
            cbxOthers.Checked = False

            cbxWithholding.Text = "NA"
        End If

        If cbxVat.Checked = False And cbxNonVat.Checked = False And cbxOthers.Checked = False And cbxTaxExempt.Checked = False Then
            cbxVat.Checked = True
        End If
    End Sub

    Private Sub ProductType_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGoods.CheckedChanged, cbxServices.CheckedChanged
        If cbxGoods.Checked = False And cbxServices.Checked = False Then
            cbxGoods.Checked = True
        End If
    End Sub

    Private Sub CbxCOD_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCOD.CheckedChanged
        If cbxCOD.Checked Then
            cbx30D.Checked = False
            cbx60D.Checked = False
            cbx90D.Checked = False
            cbxOthersT.Checked = False
        End If

        If cbxCOD.Checked = False And cbx30D.Checked = False And cbx60D.Checked = False And cbx90D.Checked = False And cbxOthersT.Checked = False Then
            cbx30D.Checked = True
        End If
    End Sub

    Private Sub Cbx30D_CheckedChanged(sender As Object, e As EventArgs) Handles cbx30D.CheckedChanged
        If cbx30D.Checked Then
            cbxCOD.Checked = False
            cbx60D.Checked = False
            cbx90D.Checked = False
            cbxOthersT.Checked = False
        End If

        If cbxCOD.Checked = False And cbx30D.Checked = False And cbx60D.Checked = False And cbx90D.Checked = False And cbxOthersT.Checked = False Then
            cbx30D.Checked = True
        End If
    End Sub

    Private Sub Cbx60D_CheckedChanged(sender As Object, e As EventArgs) Handles cbx60D.CheckedChanged
        If cbx60D.Checked Then
            cbxCOD.Checked = False
            cbx30D.Checked = False
            cbx90D.Checked = False
            cbxOthersT.Checked = False
        End If

        If cbxCOD.Checked = False And cbx30D.Checked = False And cbx60D.Checked = False And cbx90D.Checked = False And cbxOthersT.Checked = False Then
            cbx30D.Checked = True
        End If
    End Sub

    Private Sub Cbx90D_CheckedChanged(sender As Object, e As EventArgs) Handles cbx90D.CheckedChanged
        If cbx90D.Checked Then
            cbxCOD.Checked = False
            cbx30D.Checked = False
            cbx60D.Checked = False
            cbxOthersT.Checked = False
        End If

        If cbxCOD.Checked = False And cbx30D.Checked = False And cbx60D.Checked = False And cbx90D.Checked = False And cbxOthersT.Checked = False Then
            cbx30D.Checked = True
        End If
    End Sub

    Private Sub CbxOthersT_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOthersT.CheckedChanged
        If cbxOthersT.Checked Then
            cbxCOD.Checked = False
            cbx30D.Checked = False
            cbx60D.Checked = False
            cbx90D.Checked = False

            iOthersD.Enabled = True
        Else
            iOthersD.Enabled = False
            iOthersD.Value = 1
        End If

        If cbxCOD.Checked = False And cbx30D.Checked = False And cbx60D.Checked = False And cbx90D.Checked = False And cbxOthersT.Checked = False Then
            cbx30D.Checked = True
        End If
    End Sub

    Private Sub CbxIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIndividual.CheckedChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxIndividual.Checked Then
            cbxCorporate.Checked = False
            txtSupplier.WatermarkText = "Name"
            txtAddress.WatermarkText = "Address"
            txtContactNumber.WatermarkText = "Contact Number"

            With cbxWithholding
                .DisplayMember = "ATC_Individual"
                .ValueMember = "ID"
                .DataSource = DT_Withholding_Individual.Copy
            End With
        End If

        If cbxIndividual.Checked = False And cbxCorporate.Checked = False Then
            cbxCorporate.Checked = True
        End If
    End Sub

    Private Sub CbxCorporate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCorporate.CheckedChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxCorporate.Checked Then
            cbxIndividual.Checked = False
            txtSupplier.WatermarkText = "Company Name"
            txtAddress.WatermarkText = "Company Address"
            txtContactNumber.WatermarkText = "Company Number"

            With cbxWithholding
                .DisplayMember = "ATC_Corporate"
                .ValueMember = "ID"
                .DataSource = DT_Withholding_Corporate.Copy
            End With
        End If

        If cbxIndividual.Checked = False And cbxCorporate.Checked = False Then
            cbxCorporate.Checked = True
        End If
    End Sub

    Private Sub CbxWithholding_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxWithholding.SelectedIndexChanged
        If cbxWithholding.SelectedIndex = -1 Or cbxWithholding.Text = "" Then
            lblWithholdingNature.Text = ""
            dTax.Value = 0
        Else
            Dim drv As DataRowView = DirectCast(cbxWithholding.SelectedItem, DataRowView)
            lblWithholdingNature.Text = drv("Nature")
            dTax.Value = drv("Tax")
        End If
    End Sub

    Private Sub CbxWithholding_TextChanged(sender As Object, e As EventArgs) Handles cbxWithholding.TextChanged
        If cbxWithholding.Text = "" Then
            lblWithholdingNature.Text = ""
        End If
    End Sub

    Private Sub BtnWithholding_Click(sender As Object, e As EventArgs) Handles btnWithholding.Click
        Dim Withholding As New FrmWithholdingSetup
        With Withholding
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class