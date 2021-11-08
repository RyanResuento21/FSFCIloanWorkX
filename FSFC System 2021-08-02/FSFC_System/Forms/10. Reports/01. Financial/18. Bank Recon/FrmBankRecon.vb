Imports DevExpress.XtraReports.UI
Public Class FrmBankRecon

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DateCondition_1 As String
    ReadOnly DateCondition_2 As String
    Dim DateCondition_3 As String

    Private Sub FrmBankRecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        dtpC.Value = Date.Now
        dtpD.Value = Date.Now

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND ID IN ({0}) ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            .SelectedValue = Branch_ID
            If Branch_ID = 0 And MultipleBranch Then
            Else
                cbxAllB.Visible = False
                .Enabled = False
            End If
        End With

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxReviewedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedIndex = -1
        End With

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, LabelX4, LabelX40, lblFrom, LabelX41, LabelX9, LabelX5, LabelX6, LabelX7, LabelX24, LabelX19, lblPreparePosition, lblReviewPosition})

            GetLabelWithBackgroundFontSettings({LabelX15, LabelX2, LabelX3, LabelX8, LabelX10, LabelX11, LabelX13, LabelX14, LabelX16, LabelX17, LabelX18})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay, cbxPreparedBy, cbxReviewedBy})

            GetDoubleInputFontSettings({dCRBook, dCRBank, dCDBook, dCDBank, dGJBook, dGJBank, dTotalBook, dTotalBank, dAdjustedBook, dAdjustedBank, dAdjustedTotal})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpC, dtpD})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Bank Recon - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Bank Recon", lblTitle.Text)
    End Sub

    Private Sub DAdjustedBook_ValueChanged(sender As Object, e As EventArgs) Handles dAdjustedBook.ValueChanged, dAdjustedBook.ValueChanged
        dAdjustedTotal.Value = dAdjustedBank.Value - dAdjustedBook.Value
    End Sub

    Private Sub Book_ValueChanged(sender As Object, e As EventArgs) Handles dCRBook.ValueChanged, dCDBook.ValueChanged, dGJBook.ValueChanged
        dTotalBook.Value = dCRBook.Value + dCDBook.Value + dGJBook.Value
    End Sub

    Private Sub Bank_ValueChanged(sender As Object, e As EventArgs) Handles dCRBank.ValueChanged, dCDBank.ValueChanged, dGJBank.ValueChanged
        dTotalBank.Value = dCRBank.Value + dCDBank.Value + dGJBank.Value
    End Sub

    Public Sub LoadData()
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(DepositDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            LabelX9.Text = "Unadjusted Balance for " & Format(dtpFrom.Value, "MMMM dd, yyyy")
            LabelX18.Text = "   Adjusted Balance for " & Format(dtpFrom.Value, "MMMM dd, yyyy")
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(DepositDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            LabelX9.Text = "Unadjusted Balance from " & Format(dtpFrom.Value, "MMMM dd, yyyy") & " to " & Format(dtpTo.Value, "MMMM dd, yyyy")
            LabelX18.Text = "   Adjusted Balance from " & Format(dtpFrom.Value, "MMMM dd, yyyy") & " to " & Format(dtpTo.Value, "MMMM dd, yyyy")
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateCondition_1 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(DepositDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            LabelX9.Text = "Unadjusted Balance as of " & Format(dtpFrom.Value, "MMMM dd, yyyy")
            LabelX18.Text = "   Adjusted Balance as of " & Format(dtpFrom.Value, "MMMM dd, yyyy")
        End If

        Dim SQL As String = "SELECT IFNULL(SUM(Debit),0) FROM ( SELECT"
        SQL &= "      SUM(D.Debit) AS 'Debit'"
        SQL &= "    FROM acknowledgement_receipt M"
        SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, Debit, Credit FROM acr_details WHERE `status` = 'ACTIVE') D "
        SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
        SQL &= "    WHERE M.`status` = 'ACTIVE' "
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= "    AND M.Voucher_Status IN ('APPROVED','PENDING','CHECKED')"
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

        SQL &= " UNION ALL"

        SQL &= " SELECT "
        SQL &= "      SUM(Debit) AS 'Debit'"
        SQL &= "    FROM official_receipt M"
        SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, Debit, Credit FROM or_details WHERE `status` = 'ACTIVE') D "
        SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
        SQL &= "    WHERE M.`status` = 'ACTIVE' "
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= "    AND M.Voucher_Status IN ('APPROVED','PENDING','CHECKED')"
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))) A;", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        dCRBook.Value = DataObject(SQL)

        SQL = " SELECT IFNULL(SUM(Debit),0) AS 'Debit'"
        SQL &= "    FROM check_voucher M"
        SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, IF(`Type` = 'D', Amount, 0) AS 'Debit', IF(`Type` = 'C', Amount, 0) AS 'Credit', Remarks FROM cv_details WHERE `status` = 'ACTIVE') D "
        SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
        SQL &= "    WHERE M.`status` = 'ACTIVE' "
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= "    AND M.Voucher_Status IN ('APPROVED','PENDING','CHECKED','RECEIVED') AND IF(M.Payee_Type = 'C',M.Voucher_Status = 'RECEIVED',TRUE)"
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'));", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        dCDBook.Value = DataObject(SQL)

        SQL = " SELECT IFNULL(SUM(Debit),0) AS 'Debit'"
        SQL &= "    FROM journal_voucher M"
        SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, Debit, Credit, Remarks FROM jv_details WHERE `status` = 'ACTIVE') D "
        SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
        SQL &= "    WHERE M.`status` = 'ACTIVE' "
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= "    AND M.Voucher_Status IN ('APPROVED','PENDING','CHECKED')"
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}')) ORDER BY PostingDate;", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        dGJBook.Value = DataObject(SQL)

        LoadDeposit()
        LoadOutstanding()
        LoadReturned()
    End Sub

    Public Sub LoadDeposit()
        Cursor = Cursors.WaitCursor

        Dim SQL As String = String.Format("SELECT DATE_FORMAT(ORDate,'%M %d, %Y') AS 'ORDate', DocumentNumber, Type_Payment AS 'MOP', Payee, Amount, DATE_FORMAT(DepositDate,'%M %d, %Y') AS 'DepositDate' FROM official_receipt WHERE Type_Payment = 'CHECK' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) AND `status` = 'ACTIVE' AND ClearDate = '' AND DepositDate != '' AND {2}", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_3), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        SQL &= " UNION ALL"
        SQL &= String.Format(" SELECT DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'ORDate', DocumentNumber, Type_Payment AS 'MOP', Payee, Amount, DATE_FORMAT(DepositDate,'%M %d, %Y') AS 'DepositDate' FROM acknowledgement_receipt WHERE Type_Payment = 'CHECK' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) AND `status` = 'ACTIVE' AND ClearDate = '' AND DepositDate != '' AND {2};", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_3.Replace("ORDate", "PostingDate")), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 9 Then
            GridColumn4.Width = 443 - 17
        Else
            GridColumn4.Width = 443
        End If

        Cursor = Cursors.Default
    End Sub

    Public Sub LoadOutstanding()
        Cursor = Cursors.WaitCursor

        Dim SQL As String = String.Format("SELECT DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'CVDate', DocumentNumber, Payee, Amount FROM check_voucher WHERE IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) AND `status` = 'ACTIVE' AND ClearedDate = '' AND {2}", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1.Replace("ORDate", "PostingDate")), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        GridControl2.DataSource = DataSource(SQL)

        Cursor = Cursors.Default
    End Sub

    Public Sub LoadReturned()
        Cursor = Cursors.WaitCursor

        Dim SQL As String = String.Format("SELECT DATE_FORMAT(ORDate,'%M %d, %Y') AS 'ORDate', DocumentNumber, DATE_FORMAT((SELECT PostingDate FROM journal_voucher WHERE DocumentNumber = JVNumber),'%M %d, %Y') AS 'JVDate', JVNumber, Payee, Amount FROM official_receipt WHERE Type_Payment = 'CHECK' AND `status` = 'ACTIVE' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) AND JVNumber != '' AND {2}", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        SQL &= " UNION ALL"
        SQL &= String.Format(" SELECT DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'ORDate', DocumentNumber, DATE_FORMAT((SELECT PostingDate FROM journal_voucher WHERE DocumentNumber = JVNumber),'%M %d, %Y') AS 'JVDate', JVNumber, Payee, Amount FROM acknowledgement_receipt WHERE Type_Payment = 'CHECK' AND `status` = 'ACTIVE' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) AND JVNumber != '' AND {2}", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1.Replace("ORDate", "PostingDate")), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        GridControl3.DataSource = DataSource(SQL)

        Cursor = Cursors.Default
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptBankRecon
        With Report
            Dim DateFilter As String = ""
            If cbxDisplay.SelectedIndex = 0 Then
                DateFilter = String.Format("For {0}", dtpFrom.Text)
            ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                DateFilter = String.Format("As of {0}", dtpFrom.Text)
            End If

            .Name = String.Format("Bank Recon of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
            .lblBranch.Text = "FIRST STANDARD FINANCE CORPORATION - " & If(cbxAllB.Checked, "All Branch", cbxBranch.Text)
            .lblAsOf.Text = DateFilter

            .lblUnadjusted.Text = LabelX9.Text
            .lblCRBook.Text = dCRBook.Text
            .lblCDBook.Text = dCDBook.Text
            .lblGJBook.Text = dGJBook.Text
            .lblTotalBook.Text = dTotalBook.Text
            .lblCRBank.Text = dCRBank.Text
            .lblCDBank.Text = dCDBank.Text
            .lblGJBank.Text = dGJBank.Text
            .lblTotalBank.Text = dTotalBank.Text

            Dim Deposit As New SubRptDeposit With {
                .DataSource = GridControl1.DataSource
            }
            .subRpt_Deposit.ReportSource = Deposit
            With Deposit
                .lblORDate.DataBindings.Add("Text", GridControl1.DataSource, "ORDate")
                .lblDocumentNo.DataBindings.Add("Text", GridControl1.DataSource, "DocumentNumber")
                .lblMOP.DataBindings.Add("Text", GridControl1.DataSource, "MOP")
                .lblBorrower.DataBindings.Add("Text", GridControl1.DataSource, "Payee")
                .lblAmount.DataBindings.Add("Text", GridControl1.DataSource, "Amount")
                .lblDateDeposited.DataBindings.Add("Text", GridControl1.DataSource, "DepositDate")
            End With

            Dim Outstanding As New SubRptOutstanding With {
                .DataSource = GridControl2.DataSource
            }
            .subRpt_Outstanding.ReportSource = Outstanding
            With Outstanding
                .lblCVDate.DataBindings.Add("Text", GridControl2.DataSource, "CVDate")
                .lblDocumentNo.DataBindings.Add("Text", GridControl2.DataSource, "DocumentNumber")
                .lblMOP.DataBindings.Add("Text", GridControl2.DataSource, "MOP")
                .lblBorrower.DataBindings.Add("Text", GridControl2.DataSource, "Payee")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
            End With

            .lblC.Text = LabelX11.Text & " " & dtpC.Text
            .lblD.Text = LabelX13.Text & " " & dtpD.Text

            Dim Returned As New SubRptReturned With {
                .DataSource = GridControl3.DataSource
            }
            .subRpt_Returned.ReportSource = Returned
            With Returned
                .lblORDate.DataBindings.Add("Text", GridControl3.DataSource, "ORDate")
                .lblDocumentNo.DataBindings.Add("Text", GridControl3.DataSource, "DocumentNumber")
                .lblJVDate.DataBindings.Add("Text", GridControl3.DataSource, "JVDate")
                .lblJVNumber.DataBindings.Add("Text", GridControl3.DataSource, "JVNumber")
                .lblBorrower.DataBindings.Add("Text", GridControl3.DataSource, "Payee")
                .lblAmount.DataBindings.Add("Text", GridControl3.DataSource, "Amount")
            End With

            Dim Unrecorded As New SubRptUnrecorded With {
                .DataSource = GridControl4.DataSource
            }
            .subRpt_Unrecorded.ReportSource = Unrecorded
            With Unrecorded
                .lblDate.DataBindings.Add("Text", GridControl4.DataSource, "Date")
                .lblDocumentNo.DataBindings.Add("Text", GridControl4.DataSource, "DocumentNumber")
                .lblORDate.DataBindings.Add("Text", GridControl4.DataSource, "ORDate")
                .lblBorrower.DataBindings.Add("Text", GridControl4.DataSource, "Particulars")
                .lblAmount.DataBindings.Add("Text", GridControl4.DataSource, "Amount")
            End With

            Dim Others As New SubRptUnrecorded With {
                .DataSource = GridControl5.DataSource
            }
            .subRpt_Other.ReportSource = Others
            With Others
                .lblDate.DataBindings.Add("Text", GridControl5.DataSource, "Date")
                .lblDocumentNo.DataBindings.Add("Text", GridControl5.DataSource, "DocumentNumber")
                .lblORDate.DataBindings.Add("Text", GridControl5.DataSource, "ORDate")
                .lblBorrower.DataBindings.Add("Text", GridControl5.DataSource, "Particulars")
                .lblAmount.DataBindings.Add("Text", GridControl5.DataSource, "Amount")
            End With

            .lblAdjusted.Text = LabelX18.Text
            .lblAdjustedBook.Text = dAdjustedBook.Text
            .lblAdjustedBank.Text = dAdjustedBank.Text
            .lblAdjustedTotalBank.Text = dAdjustedTotal.Text
            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblPreparedPos.Text = lblPreparePosition.Text
            .lblReviewedBy.Text = cbxReviewedBy.Text
            .lblReviewedPos.Text = lblReviewPosition.Text

            Logs("Bank Recon", "Print", "[SENSITIVE] Print Bank Recon", "", "", "", "")

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If

        LoadData()
    End Sub

    Private Sub CbxAllB_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllB.CheckedChanged
        If cbxAllB.Checked Then
            cbxBranch.Enabled = False
            cbxBranch.SelectedIndex = -1
            cbxBusinessCenter.Enabled = False
            cbxBusinessCenter.Text = ""
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
            cbxBusinessCenter.Enabled = True
        End If
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("CASH FLOW", GridControl1)
        Logs("Cash Flow", "Print", "[SENSITIVE] Print Cash Flow", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        With cbxBusinessCenter
            .DataSource = DataSource(String.Format("SELECT ID, BusinessCode, BusinessCenter FROM business_center WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue))
            If .Items.Count > 0 Then
                .Enabled = True
            Else
                .Enabled = False
            End If
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            cbxBusinessCenter.Text = ""
            cbxBusinessCenter.Enabled = False
        End If
    End Sub

    Private Sub CbxBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBook.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) AND Book = '{2}' ORDER BY `Code`;", Branch_ID, DefaultBankID, cbxBook.SelectedValue))
        End With
    End Sub

    Private Sub CbxAllBank_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllBank.CheckedChanged
        If cbxAllBank.Checked Then
            cbxBook.Enabled = False
            cbxBook.SelectedIndex = -1
            cbxBank.Enabled = False
            cbxBank.Text = ""
        Else
            cbxBook.Enabled = True
            cbxBook.SelectedIndex = 0
            cbxBank.Enabled = True
        End If
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 5
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            dtpFrom.Value = Date.Now
            lblFrom.Text = "As Of :"
            LabelX41.Visible = False
            dtpTo.Visible = False
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub CbxPreparedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPreparedBy.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxPreparedBy.SelectedIndex = -1 Then
            lblPreparePosition.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
            lblPreparePosition.Text = drv("Position")
        End If
    End Sub

    Private Sub CbxReviewedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxReviewedBy.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxReviewedBy.SelectedIndex = -1 Then
            lblReviewPosition.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxReviewedBy.SelectedItem, DataRowView)
            lblReviewPosition.Text = drv("Position")
        End If
    End Sub

    Private Sub CbxReviewedBy_TextChanged(sender As Object, e As EventArgs) Handles cbxReviewedBy.TextChanged
        If cbxReviewedBy.Text = "" Then
            lblReviewPosition.Text = ""
        End If
    End Sub
End Class