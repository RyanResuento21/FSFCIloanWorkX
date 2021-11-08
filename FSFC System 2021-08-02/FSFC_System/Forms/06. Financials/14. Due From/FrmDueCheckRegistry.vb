Imports DevExpress.XtraReports.UI
Public Class FrmDueCheckRegistry

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Public DefaultBank As Integer
    Public DT As New DataTable
    Dim Flag As Boolean = False
    Public Payor As String
    Public From_CheckManagement As Boolean
    Public RollOver As Boolean
    Public From_PDC_Others As Boolean
    Public ModifyOthers As Boolean
    Public Renewal As Boolean
    Public Multiple As Boolean
    Public DC_DocumentNumber As String
    Public DocumentNumberM As String
    Private Sub FrmDueCheckRegistry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
            If DefaultBankID > 0 Then
                .Enabled = False
            End If
            .SelectedValue = DefaultBank
            If .SelectedIndex = -1 Then
                .Enabled = True
            End If
        End With

        If From_CheckManagement Then
        Else
            DT = DataSource("SELECT 0 AS 'No', '' AS 'Bank', '' AS 'Branch', '' AS 'Check No', '' AS 'Date', 0.0 AS 'Amount', '' AS 'Remarks', '' AS 'check_status' LIMIT 0")
        End If

        If txtDocumentNumber.Text.Substring(0, 2) = "DF" Or From_PDC_Others Then
            With RepositoryItemLookUpEdit1
                .DataSource = DataSource("SELECT ID, Bank, short_name AS 'Short Name' FROM bank_setup WHERE `status` = 'ACTIVE';")
                .DisplayMember = "Short Name"
                .ValueMember = "Short Name"
            End With
        Else
            With RepositoryItemLookUpEdit1
                .DataSource = DataSource(String.Format("SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
                .DisplayMember = "Bank"
                .ValueMember = "Bank"
            End With
        End If

        dtpDocument.Value = Date.Now
        dtpReceivedDate.Value = Date.Now

        If (From_PDC_Others And Renewal = False) And From_CheckManagement = False Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('PDC-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM pdc_others WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
            GridControl2.DataSource = DT
        End If

        LoadPayor()

        FirstLoad = False

        If ModifyOthers Then
            cbxPayor.Text = cbxPayor.Tag
            cbxBank.SelectedValue = cbxBank.Tag
            dtpDocument.Value = dtpDocument.Tag
            dtpReceivedDate.Value = dtpDocument.Tag
            txtDocumentNumber.Text = txtDocumentNumber.Tag
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            cbxBank.Enabled = False
        End If

        LoadChecks(False)

        If Renewal Then
            cbxPayor.Text = cbxPayor.Tag
            dtpDocument.Value = dtpDocument.Tag
            txtDocumentNumber.Text = txtDocumentNumber.Tag
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            GridControl2.DataSource = DT
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblPayor, LabelX1, LabelX2, LabelX18, LabelX10, LabelX6, LabelX9, LabelX3, LabelX81, LabelX82, lblInterest, LabelX89})

            GetButtonFontSettings({btnAddC, btnRemoveC, btnVerify, btnSave, btnRefresh, btnCancel, btnDelete, btnPrint})

            GetComboBoxFontSettings({cbxPayor, cbxBank})

            GetDateTimeInputFontSettings({dtpDocument, dtpReceivedDate})

            GetDoubleInputFontSettings({dInterest_T, dUDI_C, dPrincipal})

            GetIntegerInputFontSettings({iTerms_C})

            GetTextBoxFontSettings({txtRemarks, txtDocumentNumber, txtReferenceNumber})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit1})

            GetRepositoryDateFontSettings({RepositoryItemDateEdit1})

            GetRepositoryCalcFontSettings({RepositoryItemCalcEdit1})
        Catch ex As Exception
            TriggerBugReport("Due Check Registry - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Check Registry", lblTitle.Text)
    End Sub

    Public Sub LoadPayor()
        cbxPayor.ValueMember = "ID"
        cbxPayor.DisplayMember = "Payor"
        Dim SQL As String = " SELECT "
        SQL &= "    ID,"
        SQL &= "    Branch AS 'Payor',"
        SQL &= "    'B' AS 'Type'"
        SQL &= " FROM branch WHERE `status` = 'ACTIVE'"
        If From_PDC_Others Then
            GoTo Here
        End If
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    Supplier,"
        SQL &= "    'S' AS 'Type'"
        SQL &= String.Format(" FROM supplier_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
Here:
        cbxPayor.DataSource = DataSource(SQL)
        cbxPayor.Text = Payor
    End Sub

    Private Sub CbxPayor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayor.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpReceivedDate.Focus()
        End If
    End Sub

    Private Sub DtpReceivedDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpReceivedDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceNumber.Focus()
        End If
    End Sub

    Private Sub TxtReferenceNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtRemarks.Visible Then
                txtRemarks.Focus()
            Else
                iTerms_C.Focus()
            End If
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub ITerms_C_KeyDown(sender As Object, e As KeyEventArgs) Handles iTerms_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            dInterest_T.Focus()
        End If
    End Sub

    Private Sub DInterest_T_KeyDown(sender As Object, e As KeyEventArgs) Handles dInterest_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            dUDI_C.Focus()
        End If
    End Sub

    Private Sub DUDI_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dUDI_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddC.Focus()
        End If
    End Sub

    Private Sub DInterest_T_ValueChanged(sender As Object, e As EventArgs) Handles dInterest_T.ValueChanged
        LoadChecks(True)
    End Sub

    Private Sub DPrincipal_ValueChanged(sender As Object, e As EventArgs) Handles dPrincipal.ValueChanged
        LoadChecks(True)
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        DT.Rows.Add(GridView2.RowCount + 1, "", "", "", Format(dtpReceivedDate.Value.AddMonths(GridView2.RowCount), "MM.dd.yyyy"), If(From_PDC_Others, 0, dUDI_C.Value / iTerms_C.Value), "", "")
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If
        btnAddC.Enabled = True
        DT.Rows.RemoveAt(GridView2.RowCount - 1)

        If GridView2.RowCount <= 1 Then
            btnRemoveC.Enabled = False
        End If
    End Sub

    Private Sub LoadChecks(AutoSuggest As Boolean)
        If FirstLoad Or From_CheckManagement Or If(txtDocumentNumber.Text.Substring(0, 2) = "DF", 0, cbxBank.SelectedIndex = -1) Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        If btnSave.Enabled = False And AutoSuggest = False Then
            DT = DataSource(String.Format("SELECT ROW_NUMBER() OVER() AS 'No', Bank, Branch, CheckNumber AS 'Check No', DATE_FORMAT(CheckDate,'%m.%d.%Y') AS 'Date', Amount, Remarks, check_status FROM dc_details WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE' ORDER BY CheckDate;", Multiple, DC_DocumentNumber, txtDocumentNumber.Text))
            GridControl2.DataSource = DT
        Else
            dUDI_C.Value = dPrincipal.Value * (((dInterest_T.Value / 12) * iTerms_C.Value) / 100)
            DT.Rows.Clear()
            For x As Integer = 0 To iTerms_C.Value - 1
                DT.Rows.Add(x + 1, If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "", cbxBank.Text), If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "", drv("Branch")), "", Format(dtpReceivedDate.Value.AddMonths(x), "MM.dd.yyyy"), CDbl(dUDI_C.Value / iTerms_C.Value), "", "")
            Next
            DT.Rows.Add(iTerms_C.Value + 1, If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "", cbxBank.Text), If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "", drv("Branch")), "", Format(dtpReceivedDate.Value.AddMonths(DT.Rows.Count), "MM.dd.yyyy"), CDbl(dPrincipal.Value), "", "")

            GridControl2.DataSource = DT
        End If
    End Sub

    Private Sub ITerms_C_ValueChanged(sender As Object, e As EventArgs) Handles iTerms_C.ValueChanged
        LoadChecks(True)
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim Plus1 As Integer = 0
        Dim Plus1Month As Integer = 0
        For x As Integer = e.RowHandle To GridView2.RowCount - 1
            If e.Column.FieldName = "Bank" AndAlso (Not Flag) Then
                Flag = True
                GridView2.SetRowCellValue(x, "Bank", e.Value)
                Flag = False
            End If
            If e.Column.FieldName = "Branch" AndAlso (Not Flag) Then
                Flag = True
                GridView2.SetRowCellValue(x, "Branch", e.Value)
                Flag = False
            End If
            If e.Column.FieldName = "Check No" AndAlso (Not Flag) Then
                Flag = True
                Try
                    GridView2.SetRowCellValue(x, "Check No", (e.Value + Plus1).ToString.PadLeft((e.Value + Plus1).ToString.Length + CountLeadingZeros(e.Value.ToString), "0"))
                Catch ex As Exception
                End Try
                Plus1 += 1
                Flag = False
            End If
            If e.Column.FieldName = "Date" AndAlso (Not Flag) Then
                Flag = True
                Try
                    GridView2.SetRowCellValue(x, "Date", Format(DateValue(e.Value).AddMonths(Plus1Month), "MM.dd.yyyy"))
                Catch ex As Exception
                End Try
                Plus1Month += 1
                Flag = False
            End If
        Next
    End Sub

    Public Function CountLeadingZeros(input As String) As String
        Dim count As Integer = 0
        For Each c As Char In input
            If c = "0"c Then
                count += 1
            Else
                Exit For
            End If
        Next
        Return count
    End Function

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        PanelEx10.Enabled = True
        dtpDocument.Value = Date.Now
        dtpReceivedDate.Value = Date.Now
        btnSave.Enabled = True
        btnDelete.Enabled = False
        cbxPayor.SelectedIndex = -1
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        dInterest_T.Value = 7.5
        txtReferenceNumber.Text = ""
        dPrincipal.Value = 0
        iTerms_C.Value = 0

        btnAddC.Enabled = False
        btnRemoveC.Enabled = False
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If GridView2.RowCount > 0 Then
            Dim Report As New RptCheckRegistry
            With Report
                .Name = "Check Registry"

                .lblSupplier.Text = cbxPayor.Text
                .lblDocumentDate.Text = dtpDocument.Text
                .lblDocumentNumber.Text = txtDocumentNumber.Text
                .lblPostingDate.Text = dtpReceivedDate.Text
                .lblReferenceNumber.Text = txtReferenceNumber.Text
                .lblBank.Text = cbxBank.Text
                .lblPrincipal.Text = dPrincipal.Text
                .lblTerms.Text = iTerms_C.Text
                .lblInterestRate.Text = dInterest_T.Text
                .lblInterest.Text = dUDI_C.Text
                If From_PDC_Others Then
                    .XrLabel8.Text = "Remarks :"
                    .lblPrincipal.Text = txtRemarks.Text
                    .lblPrincipal.SizeF = New SizeF(740, 20)

                    .XrLabel11.Visible = False
                    .lblTerms.Visible = False
                    .XrLabel17.Visible = False
                    .lblInterestRate.Visible = False
                    .XrLabel23.Visible = False
                    .XrLabel19.Visible = False
                    .lblInterest.Visible = False
                End If
                'Dim Total As Double
                'For x As Integer = 0 To GridView2.RowCount - 1
                'GridView2.SetRowCellValue(x, "Amount", FormatNumber(GridView2.GetRowCellValue(x, "Amount"), 2))
                'Total = Total + CDbl(GridView2.GetRowCellValue(x, "Amount"))
                'Next
                .DataSource = GridControl2.DataSource
                .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                .lblBankV2.DataBindings.Add("Text", GridControl2.DataSource, "Bank")
                .lblBranch.DataBindings.Add("Text", GridControl2.DataSource, "Branch")
                .lblCheckNumber.DataBindings.Add("Text", GridControl2.DataSource, "Check No")
                .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                .lblRemarks.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
                .lblAmountT.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                Logs("Check Registry", "Print", "[SENSITIVE] Print Check Registry of " & cbxPayor.Text, "", "", "", "")
                .ShowPreview()
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If GridView2.RowCount = 0 Then
            MsgBox("Please add checks before saving.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
                MsgBox("Please select bank.", MsgBoxStyle.Information, "Info")
                cbxBank.DroppedDown = True
                Exit Sub
            End If

            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Bank") = "" Then
                    MsgBox(String.Format("Please select Bank at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Branch") = "" Then
                    MsgBox(String.Format("Please fill Branch at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                For y As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Check No") = GridView2.GetRowCellValue(y, "Check No") And x <> y Then
                        MsgBox(String.Format("Duplication of Check Number found at row {0} and row {1}, please check your data.", x + 1, y + 1), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Next
                If GridView2.GetRowCellValue(x, "Check No") = "" Then
                    MsgBox(String.Format("Please fill Check No at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Date") = "" Then
                    MsgBox(String.Format("Please fill Date at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If CDbl(GridView2.GetRowCellValue(x, "Amount")) = 0 Then
                    MsgBox(String.Format("Please fill Amount at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next
            If (From_PDC_Others And Renewal = False) And From_CheckManagement = False Then
                txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('PDC-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM pdc_others WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
            End If

            If MsgBoxYes("Are you sure you want to save this checks?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""

                If From_CheckManagement Then
                    GoTo Here
                End If
                If From_PDC_Others And Renewal = False Then
                    SQL = "INSERT INTO pdc_others SET"
                    SQL &= String.Format(" Payorid = '{0}', ", cbxPayor.SelectedValue)
                    SQL &= String.Format(" Payor = '{0}', ", cbxPayor.Text)
                    SQL &= String.Format(" DocumentDate = '{0}', ", FormatDatePicker(dtpDocument))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" ReceivedDate = '{0}', ", FormatDatePicker(dtpReceivedDate))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    If btnVerify.Visible Then
                        SQL &= " DueStatus = 'PENDING', "
                    End If
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                    GoTo Here
                ElseIf From_PDC_Others And Renewal Then
                    SQL = "UPDATE pdc_others SET"
                    SQL &= String.Format(" ReceivedDate = '{0}', ", FormatDatePicker(dtpReceivedDate))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" BankID = '{0}' ", cbxBank.SelectedValue)
                    SQL &= String.Format(" WHERE DocumentNumber = '{0}';", txtDocumentNumber.Text)
                    GoTo Here
                End If
                If RollOver Then
                    SQL &= String.Format("UPDATE due_check SET `status` = 'ROLL OVER' WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE';", Multiple, DC_DocumentNumber, txtDocumentNumber.Text)
                    SQL &= String.Format("UPDATE dc_details SET `check_status` = 'RETURNED', Remarks = CONCAT(Remarks, ' [Roll Over]') WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}');", Multiple, DC_DocumentNumber, txtDocumentNumber.Text)
                    Logs("Check Registry", "Roll Over", String.Format("Roll Over Due From for {0} with Document Number {1}.", cbxPayor.Text, txtDocumentNumber.Text), "", "", "", txtDocumentNumber.Text)
                End If
                SQL &= "INSERT INTO due_check SET"
                SQL &= String.Format(" Payor = '{0}', ", cbxPayor.Text)
                SQL &= String.Format(" DocumentDate = '{0}', ", FormatDatePicker(dtpDocument))
                SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                SQL &= String.Format(" ReceivedDate = '{0}', ", FormatDatePicker(dtpReceivedDate))
                SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Principal = '{0}', ", dPrincipal.Value)
                SQL &= String.Format(" Terms = '{0}', ", iTerms_C.Value)
                SQL &= String.Format(" InterestRate = '{0}', ", dInterest_T.Value)
                SQL &= String.Format(" UDI = '{0}', ", dUDI_C.Value)
                If btnVerify.Visible Then
                    SQL &= " DueStatus = 'PENDING', "
                End If
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Multiple = {0}, ", Multiple)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
Here:
                For x As Integer = 0 To GridView2.RowCount - 1
                    SQL &= "INSERT INTO dc_details SET"
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                    SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                    SQL &= String.Format(" CheckNumber = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                    SQL &= String.Format(" CheckDate = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" Remarks = '{0}';", ReplaceText(GridView2.GetRowCellValue(x, "Remarks")))
                Next
                DataObject(SQL)
                If Multiple Then
                    SQL = ""
                    If txtDocumentNumber.Text.Contains("DF-") Then
                        SQL = "UPDATE due_from SET"
                        SQL &= String.Format(" DC_ID = '{0}' ", DataObject(String.Format("SELECT ID FROM due_check WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)))
                        SQL &= String.Format(" WHERE ID IN ({0});", DocumentNumberM)
                    ElseIf txtDocumentNumber.Text.Contains("DT-") Then
                        SQL = "UPDATE due_to SET"
                        SQL &= String.Format(" DC_ID = '{0}' ", DataObject(String.Format("SELECT ID FROM due_check WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)))
                        SQL &= String.Format(" WHERE ID IN ({0});", DocumentNumberM)
                    End If
                    DataObject(SQL)
                End If

                Logs("Check Registry", "Save", String.Format("Check Registry for {0} with Document Number {1}.", cbxPayor.Text, txtDocumentNumber.Text), "", "", "", txtDocumentNumber.Text)

                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnPrint.PerformClick()
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        For x As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(x, "check_status") = "CLEARED" Then
                MsgBox("List of checks already have a CLEARED CHECK transaction, cancel is not allowed", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next
        If btnDelete.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                If ModifyOthers Then
                    DataObject(String.Format("UPDATE pdc_others SET `status` = 'CANCELLED' WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE'; UPDATE dc_details SET `status` = 'CANCELLED' WHERE check_status = 'ON HAND' AND IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE';", Multiple, DC_DocumentNumber, txtDocumentNumber.Text))
                Else
                    DataObject(String.Format("UPDATE due_check SET `status` = 'CANCELLED' WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE'; UPDATE dc_details SET `status` = 'CANCELLED' WHERE check_status = 'ON HAND' AND IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}') AND `status` = 'ACTIVE';", Multiple, DC_DocumentNumber, txtDocumentNumber.Text))
                End If
                Logs("Check Registry", "Cancel", String.Format("Cancel Check Registry for {0} with Document Number {1}.", cbxPayor.Text, txtDocumentNumber.Text), "", "", "", txtDocumentNumber.Text)
                btnDelete.DialogResult = DialogResult.OK
                btnDelete.PerformClick()
                MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub TxtReferenceNumber_Leave(sender As Object, e As EventArgs) Handles txtReferenceNumber.Leave
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            MsgBox("Please select bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If

        If btnVerify.DialogResult = DialogResult.OK Then
        Else
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Bank") = "" Then
                    MsgBox(String.Format("Please select Bank at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Branch") = "" Then
                    MsgBox(String.Format("Please fill Branch at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                For y As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Check No") = GridView2.GetRowCellValue(y, "Check No") And x <> y Then
                        MsgBox(String.Format("Duplication of Check Number found at row {0} and row {1}, please check your data.", x + 1, y + 1), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Next
                If GridView2.GetRowCellValue(x, "Check No") = "" Then
                    MsgBox(String.Format("Please fill Check No at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If GridView2.GetRowCellValue(x, "Date") = "" Then
                    MsgBox(String.Format("Please fill Date at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If CDbl(GridView2.GetRowCellValue(x, "Amount")) = 0 Then
                    MsgBox(String.Format("Please fill Amount at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next

            If MsgBoxYes(String.Format("Are you sure you want to Verify this Due {0}?", If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "From", "To"))) = MsgBoxResult.Yes Then
                Dim Verify As New FrmDueToVerify
                With Verify
                    '.LabelX1.Text = If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "DUE FROM VERIFY", "DUE TO VERIFY")
                    If .ShowDialog = DialogResult.OK Then
                        If ModifyOthers Then
                            Dim SQL As String = "UPDATE pdc_others SET"
                            SQL &= String.Format(" ReceivedDate = '{0}', ", FormatDatePicker(dtpReceivedDate))
                            SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" VerifyID = '{0}', ", ValidateComboBox(.cbxReceiver))
                            SQL &= String.Format(" VerifyDate = '{0}', ", Format(.dtpReceived.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" VerifyRemarks = '{0}', ", .txtRemarks.Text)
                            SQL &= " DueStatus = 'VERIFIED',"
                            SQL &= String.Format(" Remarks = '{0}' ", txtRemarks.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", txtDocumentNumber.Text)

                            SQL &= String.Format(" UPDATE dc_details SET `status` = 'CANCELLED' WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}');", Multiple, DC_DocumentNumber, txtDocumentNumber.Text)
                            For x As Integer = 0 To GridView2.RowCount - 1
                                SQL &= "INSERT INTO dc_details SET"
                                SQL &= String.Format(" DocumentNumber = '{0}',", If(Multiple, DC_DocumentNumber, txtDocumentNumber.Text))
                                SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                                SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                                SQL &= String.Format(" CheckNumber = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                                SQL &= String.Format(" CheckDate = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                                SQL &= String.Format(" Remarks = '{0}';", ReplaceText(GridView2.GetRowCellValue(x, "Remarks")))
                            Next
                            DataObject(SQL)
                        Else
                            Dim SQL As String = "UPDATE due_check SET"
                            SQL &= String.Format(" ReceivedDate = '{0}', ", FormatDatePicker(dtpReceivedDate))
                            SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                            SQL &= String.Format(" Principal = '{0}', ", dPrincipal.Value)
                            SQL &= String.Format(" Terms = '{0}', ", iTerms_C.Value)
                            SQL &= String.Format(" InterestRate = '{0}', ", dInterest_T.Value)
                            SQL &= String.Format(" UDI = '{0}', ", dUDI_C.Value)
                            SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                            SQL &= String.Format(" VerifyID = '{0}', ", ValidateComboBox(.cbxReceiver))
                            SQL &= String.Format(" VerifyDate = '{0}', ", Format(.dtpReceived.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" VerifyRemarks = '{0}', ", .txtRemarks.Text)
                            SQL &= " DueStatus = 'VERIFIED' "
                            SQL &= String.Format(" WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}');", Multiple, DC_DocumentNumber, txtDocumentNumber.Text)
                            SQL &= String.Format(" UPDATE dc_details SET `status` = 'CANCELLED' WHERE IF({0},DocumentNumber = '{1}',DocumentNumber = '{2}');", Multiple, DC_DocumentNumber, txtDocumentNumber.Text)
                            For x As Integer = 0 To GridView2.RowCount - 1
                                SQL &= "INSERT INTO dc_details SET"
                                SQL &= String.Format(" DocumentNumber = '{0}',", If(Multiple, DC_DocumentNumber, txtDocumentNumber.Text))
                                SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                                SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                                SQL &= String.Format(" CheckNumber = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                                SQL &= String.Format(" CheckDate = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                                SQL &= String.Format(" Remarks = '{0}';", ReplaceText(GridView2.GetRowCellValue(x, "Remarks")))
                            Next
                            DataObject(SQL)
                        End If
                        Logs("Check Registry", "Verify", String.Format("Verify Due {2} {0} with the total amount of {1}.", txtDocumentNumber.Text, dPrincipal.Text, If(txtDocumentNumber.Text.Substring(0, 2) = "DF", "From", "To")), "", "", "", "")

                        MsgBox("Successfully Verified!", MsgBoxStyle.Information, "Info")
                        btnPrint.PerformClick()
                        btnVerify.DialogResult = DialogResult.OK
                        btnVerify.PerformClick()
                    End If
                    .Dispose()
                End With
            End If
        End If
    End Sub
End Class