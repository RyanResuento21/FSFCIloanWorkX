Imports DevExpress.XtraReports.UI
Public Class FrmPDCReceipt

    ReadOnly ID As String
    Dim ContactN As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public CreditNumber As String
    Public From_Replace As Boolean
    Public From_CreditPayment As Boolean
    Dim Flag As Boolean = False
    Dim DT As New DataTable
    Dim FirstLoad As Boolean = True
    Dim NMA As Double
    Dim ORNumber As String
    Public Checks As Integer
    Dim Terms As Integer
    ReadOnly Amount As Double
    ReadOnly TotalPayable As Double
    Public DefaultBank As String
    Public DefaultBranch As String
    Public From_PaymentRelease As Boolean
    Private Sub FrmPDC_Receiptvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpDate.Value = Date.Now

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Code`;", Branch_ID))
        End With
        Dim DefaultBank As String = DataObject(String.Format("SELECT BankID FROM check_received WHERE AssetNumber = '{0}' AND `status` != 'DELETED';", CreditNumber))
        If DefaultBank = "" Then
        Else
            cbxBank.SelectedValue = DefaultBank
        End If

        With DT
            .Columns.Add("No")
            .Columns.Add("Payee")
            .Columns.Add("Bank")
            .Columns.Add("Branch")
            .Columns.Add("Check No")
            .Columns.Add("Date")
            .Columns.Add("Amount")
            .Columns.Add("Account Number")
            .Columns.Add("Remarks")
        End With

        btnAddC.Enabled = False
        btnRemoveC.Enabled = False

        With RepositoryItemLookUpEdit1
            .DataSource = DataSource("SELECT ID, Bank, short_name AS 'Short Name' FROM bank_setup WHERE `status` = 'ACTIVE';")
            .DisplayMember = "Short Name"
            .ValueMember = "Short Name"
        End With

        cbxApplication.ValueMember = "CreditNumber"
        cbxApplication.DisplayMember = "Name"
        FirstLoad = False
        LoadApplication()
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

            GetLabelFontSettings({LabelX155, LabelX7, LabelX1, LabelX2})

            GetTextBoxFontSettings({txtPayee})

            GetLabelFontSettingsDefault({LabelX4, lblNMA})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit1})

            GetComboBoxFontSettings({cbxApplication, cbxBank})

            GetDateTimeInputFontSettings({dtpDate})

            GetButtonFontSettings({btnAddC, btnRemoveC, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})
        Catch ex As Exception
            TriggerBugReport("PDC Receipt - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("PDC Receipt", lblTitle.Text)
    End Sub

    Private Sub LoadApplication()
        Dim SQL As String = "SELECT CreditNumber, "
        SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), LastN_B) AS 'Name', CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), LastN_B) AS 'FullN', Mobile_B, (GMA - REBATE) AS 'NMA', Terms - AdvancePayment_Count AS 'Terms', AdvancePayment_Count"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("  WHERE CreditNumber = '{0}';", CreditNumber)
        cbxApplication.DataSource = DataSource(SQL)
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        DT.Rows.Add(GridView2.RowCount + 1, txtPayee.Text, "", "", "", Format(dtpDate.Value.AddMonths(GridView2.RowCount + 1), "MM.dd.yyyy"), NMA, "")
        If GridView2.RowCount = Terms Then
            btnAddC.Enabled = False
        End If
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If
        btnAddC.Enabled = True
        DT.Rows.RemoveAt(GridView2.RowCount - 1)
        If GridView2.RowCount = 1 Then
            btnRemoveC.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text.Trim = "" Then
                MsgBox("Please select credit application.", MsgBoxStyle.Information, "Info")
                cbxApplication.DroppedDown = True
                Exit Sub
            End If
            If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
                MsgBox("Please select bank.", MsgBoxStyle.Information, "Info")
                cbxBank.DroppedDown = True
                Exit Sub
            End If

            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Payee") = "" Then
                    MsgBox(String.Format("Please fill a payee at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
                If GridView2.GetRowCellValue(x, "Account Number") = "" Then
                    MsgBox(String.Format("Please fill Account Number at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next

            If MsgBoxYes("Are you sure you want to save this checks?") = MsgBoxResult.Yes Then
                Dim SQL As String
                ORNumber = "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss")
                If cbxApplication.Enabled = False And From_Replace = False Then
                    SQL = String.Format(" UPDATE check_received SET `status` = 'CANCELLED' WHERE `status` = 'PENDING' AND AssetNumber = '{0}';", cbxApplication.SelectedValue)
                    DataObject(SQL)
                End If

                Dim Booked As Boolean = If(DataObject(String.Format("SELECT ID FROM credit_application WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED');", CreditNumber)) = Nothing, False, True)

                For x As Integer = 0 To GridView2.RowCount - 1
                    If Booked Then
                        Dim Exist As Integer = If(DataObject(String.Format("SELECT ID FROM check_received WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` NOT IN ('PENDING','CANCELLED','DELETED','RETURNED','REMOVED') AND Bank = '{2}' AND `Date` = '{3}' AND Amount = '{4}';", cbxApplication.SelectedValue, GridView2.GetRowCellValue(x, "Check No"), GridView2.GetRowCellValue(x, "Bank"), Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"), CDbl(GridView2.GetRowCellValue(x, "Amount")))) = Nothing, 0, 1)
                        If Exist = 1 Then
                            Continue For
                        End If
                    End If
                    Cursor = Cursors.WaitCursor
                    SQL = "INSERT INTO check_received SET"
                    SQL &= String.Format(" AssetNumber = '{0}', ", cbxApplication.SelectedValue)
                    SQL &= String.Format(" ORNumber = '{0}', ", ORNumber)
                    SQL &= String.Format(" Sold_ID = '{0}',", "")
                    SQL &= String.Format(" Buyer = '{0}', ", GridView2.GetRowCellValue(x, "Payee"))
                    SQL &= String.Format(" DateRequest = '{0}', ", FormatDatePicker(dtpDate))
                    SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                    SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                    SQL &= String.Format(" `Check` = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                    SQL &= String.Format(" `Date` = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" AccountNum = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Account Number")))
                    SQL &= String.Format(" Remarks = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Remarks").ToString))
                    If From_Replace Or Booked Or From_PaymentRelease Then
                    Else
                        SQL &= " `status` = 'PENDING', "
                    End If
                    SQL &= String.Format(" BankID = '{0}',", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}',", Branch_ID)
                    SQL &= String.Format(" user_code = '{0}';", User_Code)
                    DataObject(SQL)
                    Cursor = Cursors.Default
                Next

                Logs("PDC Receipt", "Save", String.Format("Received {1} checks from {2} for {0}", cbxApplication.SelectedValue, GridView2.RowCount, txtPayee.Text), "", "", "", CreditNumber)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnPrint.PerformClick()
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If GridView2.RowCount > 0 Then
            Dim Report As New RptPDCReceipt
            With Report
                .Name = "PDC Receipt"
                .lblBorrower.Text = txtPayee.Text
                .lblBorrower2.Text = txtPayee.Text
                .lblContactN.Text = If(ContactN = "", "", "+63" & ContactN)
                Dim Total As Double
                For x As Integer = 0 To GridView2.RowCount - 1
                    GridView2.SetRowCellValue(x, "Amount", FormatNumber(GridView2.GetRowCellValue(x, "Amount"), 2))
                    Total += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                Next
                .DataSource = GridControl2.DataSource
                .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                .lblBank.DataBindings.Add("Text", GridControl2.DataSource, "Bank")
                .lblBranch.DataBindings.Add("Text", GridControl2.DataSource, "Branch")
                .lblCheckN.DataBindings.Add("Text", GridControl2.DataSource, "Check No")
                .lblCheckD.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                .lblRemarksC.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
                .lblTotal.Text = FormatNumber(Total, 2)

                .lblConfirmedD.Text = Format(Date.Now, "MM.dd.yyyy")
                .lblReceivedBy.Text = Empl_Name
                .lblReceivedD.Text = Format(Date.Now, "MM.dd.yyyy")
                .ShowPreview()
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
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
            DataObject(String.Format("UPDATE check_received SET `status` = 'DELETED' WHERE AssetNumber = '{0}' AND check_type = 'R';", cbxApplication.SelectedValue))
            Logs("PDC Receipt", "Cancel", Reason, String.Format("Cancel PDC Receipt {0}", cbxApplication.SelectedValue), "", "", CreditNumber)
            Clear()
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Clear()
        Else
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            txtPayee.Text = drv("FullN")
            ContactN = drv("Mobile_B")
            NMA = drv("NMA")
            lblNMA.Text = "P " & FormatNumber(NMA, 2)
            If From_Replace Then
                Terms = 1
            ElseIf From_CreditPayment Then
                Terms = drv("Terms")
                Checks = drv("Terms")
            Else
                Terms = drv("Terms")
            End If

            btnAddC.Enabled = True
            btnRemoveC.Enabled = True
            LoadChecks()
        End If
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            GridControl2.DataSource = Nothing
            Clear()
        End If
    End Sub

    Public Sub LoadChecks()
        DT.Rows.Clear()
        Dim DT_Schedule As DataTable = DataSource(String.Format("SELECT GREATEST(Monthly - RPPD,0) AS 'Monthly', DueDate FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND Monthly > 0 ORDER BY DueDate;", cbxApplication.SelectedValue))
        If cbxApplication.Enabled Or From_CreditPayment Then
            If DT_Schedule.Rows.Count > 0 Then
                For x As Integer = 0 To DT_Schedule.Rows.Count - 1
                    DT.Rows.Add(x + 1, txtPayee.Text, "", "", "", Format(CDate(DT_Schedule(x)("DueDate")), "MM.dd.yyyy"), CDbl(DT_Schedule(x)("Monthly")), "", "")
                Next
            Else
                For x As Integer = 0 To Checks - If(From_CreditPayment, 1, 0)
                    DT.Rows.Add(x + 1, txtPayee.Text, "", "", "", Format(Date.Now.AddMonths(x + 1), "MM.dd.yyyy"), NMA, "", "")
                Next
            End If
        Else
            If From_Replace Then
                For x As Integer = 0 To Checks - 1
                    DT.Rows.Add(x + 1, txtPayee.Text, DefaultBank, DefaultBranch, "", Format(Date.Now.AddMonths(x + 1), "MM.dd.yyyy"), NMA, "", "")
                Next
            ElseIf DT_Schedule.Rows.Count > 0 Then
                For x As Integer = 0 To DT_Schedule.Rows.Count - 1
                    DT.Rows.Add(x + 1, txtPayee.Text, "", "", "", Format(CDate(DT_Schedule(x)("DueDate")), "MM.dd.yyyy"), CDbl(DT_Schedule(x)("Monthly")), "", "")
                Next
            Else
                DT = DataSource(String.Format("SELECT ROW_NUMBER() OVER() AS 'No', Buyer AS 'Payee', Bank, Branch, `Check`  AS 'Check No', DATE_FORMAT(`Date`,'%m.%d.%Y') AS 'Date', FORMAT(Amount,2) AS 'Amount', AccountNum AS 'Account Number', Remarks FROM check_received WHERE AssetNumber = '{0}' AND `status` NOT IN ('DELETED','CANCELLED','RETURNED','REMOVED') AND check_type = 'R';", cbxApplication.SelectedValue))
                If DT.Rows.Count = 0 Then
                    For x As Integer = 0 To Terms - 1
                        DT.Rows.Add(x + 1, txtPayee.Text, "", "", "", Format(Date.Now.AddMonths(x + 1), "MM.dd.yyyy"), NMA, "", "")
                    Next
                Else
                    For x As Integer = 0 To DT.Rows.Count - 1
                        If DT(x)("Bank") = "" Then
                            DT(x)("Bank") = Bank
                            DT(x)("Branch") = Branch
                        End If
                    Next
                End If
            End If
        End If

        GridControl2.DataSource = DT
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
            End Try
        ElseIf (e.Column.FieldName = "Date") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = Format(DateValue(e.Value), "MM.dd.yyyy")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim Plus1 As Integer
        Dim Plus1Month As Integer
        Dim ShowMessage As Boolean = True
        For x As Integer = e.RowHandle To GridView2.RowCount - 1
            If e.Column.FieldName = "Payee" AndAlso (Not Flag) Then
                Flag = True
                GridView2.SetRowCellValue(x, "Payee", e.Value)
                Flag = False
            End If
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
            If e.Column.FieldName = "Account Number" Then
                If GridView2.GetRowCellValue(x, "Account Number").ToString.Length > 20 Then
                    If ShowMessage Then
                        MsgBox("Maximum characters allowed for Account Number is 20 only.", MsgBoxStyle.Information, "Info")
                        ShowMessage = False
                    End If
                    If GridView2.GetRowCellValue(x, "Account Number") = e.Value.ToString.Substring(0, 20) Then
                        Continue For
                    End If
                    GridView2.SetRowCellValue(x, "Account Number", e.Value.ToString.Substring(0, 20))
                Else
                    If GridView2.GetRowCellValue(x, "Account Number") = e.Value Then
                        Continue For
                    End If
                    If e.Value.ToString.Length > 20 Then
                        GridView2.SetRowCellValue(x, "Account Number", e.Value.ToString.Substring(0, 20))
                    Else
                        GridView2.SetRowCellValue(x, "Account Number", e.Value)
                    End If
                End If
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

    Private Sub TxtPayee_Leave(sender As Object, e As EventArgs) Handles txtPayee.Leave
        txtPayee.Text = ReplaceText(txtPayee.Text)
    End Sub

    Private Sub CbxApplication_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxApplication.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPayee.Focus()
        End If
    End Sub

    Private Sub TxtPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
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
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        txtPayee.Text = ""
        cbxBank.SelectedIndex = -1
        ContactN = ""
        NMA = 0
        lblNMA.Text = "P 0.00"

        btnAddC.Enabled = False
        btnRemoveC.Enabled = False
    End Sub

    Private Sub TxtPayee_TextChanged(sender As Object, e As EventArgs) Handles txtPayee.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadChecks()
    End Sub
End Class