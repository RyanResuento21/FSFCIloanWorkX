Imports DevExpress.XtraReports.UI
Public Class FrmCollectionReport

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_Cancelled As New DataTable
    Private Sub FrmCollectionReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

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

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxCheckedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedIndex = -1
        End With

        With cbxNotedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedIndex = -1
        End With

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX40, LabelX42, LabelX41, LabelX2, LabelX9, LabelX8, LabelX12})

            GetLabelFontSettingsWithTopBorder({lblPosition, lblPositionChecked, lblPositionNoted})

            GetLabelWithBackgroundFontSettingsNoBorder({LabelX7, LabelX6, LabelX4, LabelX3, LabelX5})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxOR, cbxACR, cbxCancelled})

            GetComboBoxFontSettings({cbxBranch, cbxBook, cbxBank, cbxDisplay, cbxPreparedBy, cbxCheckedBy, cbxNotedBy})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Collection Report - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Collection Report", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = ""
        If cbxACR.Checked Or cbxOR.Checked Then
            SQL = "SELECT * FROM  ("
        End If
        If cbxACR.Checked Then
            SQL &= " SELECT "
            SQL &= "      DocumentNumber AS 'Document Number',"
            SQL &= "      Payee AS 'Issued To',"
            SQL &= "      '' AS 'Account Number',"
            SQL &= "      IF(Type_Payment = 'CASH', Amount, 0) AS 'Cash Amount',"
            SQL &= "      IF(Type_Payment = 'CHECK', Amount, 0) AS 'Check Amount',"
            SQL &= "      IF(Type_Payment = 'ONLINE', Amount, 0) AS 'Online Amount',"
            SQL &= "      CheckNumber AS 'Check Number',"
            SQL &= "      DATE_FORMAT(CheckDate,'%b %d, %Y') AS 'Check Date',"
            SQL &= "      0 AS 'Loans',"
            SQL &= "      Amount AS 'Amount', PostingDate, Payee_ID, Payee_Type, JVNumber"
            SQL &= " FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status = 'APPROVED'"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({2}),Branch_ID = '{1}') AND IF('{3}' = 'True',TRUE,IF('{4}' = 0,Book(BankID) = '{5}',BankID = '{4}'))", cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

            If cbxOR.Checked Then
                SQL &= " UNION ALL "
            Else
                SQL &= ") A ORDER BY `Document Number`"
            End If
        End If

        If cbxOR.Checked Then
            SQL &= " SELECT "
            SQL &= "      DocumentNumber AS 'Document Number',"
            SQL &= "      Payee AS 'Issued To',"
            SQL &= "      AccountNumber(Payee_ID) AS 'Account Number',"
            SQL &= "      IF(Type_Payment = 'CASH', Amount, 0) AS 'Cash Amount',"
            SQL &= "      IF(Type_Payment = 'CHECK', Amount, 0) AS 'Check Amount',"
            SQL &= "      IF(Type_Payment = 'ONLINE', Amount, 0) AS 'Online Amount',"
            SQL &= "      CheckNumber AS 'Check Number',"
            SQL &= "      DATE_FORMAT(CheckDate,'%b %d, %Y') AS 'Check Date',"
            SQL &= "      IFNULL((SELECT SUM(Credit) FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = official_receipt.DocumentNumber AND `status` = 'ACTIVE' AND PaidFor IN ('Penalty','RPPD','UDI','Principal')),0) AS 'Loans',"
            SQL &= "      IFNULL(Amount - (SELECT SUM(Credit) FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = official_receipt.DocumentNumber AND `status` = 'ACTIVE' AND PaidFor IN ('Penalty','RPPD','UDI','Principal')),0) AS 'Amount', PostingDate, Payee_ID, '' AS Payee_Type, JVNumber"
            SQL &= " FROM official_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status = 'APPROVED'"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({2}),Branch_ID = '{1}') AND IF('{3}' = 'True',TRUE,IF('{4}' = 0,Book(BankID) = '{5}',BankID = '{4}'))", cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

            'FOR CHECK VOUCHER FOR DEDUCT BALANCE AND ADVANCE AMORTIZATIONS
            SQL &= " UNION ALL "

            SQL &= " SELECT "
            SQL &= "      DocumentNumber AS 'Document Number',"
            SQL &= "      Payee AS 'Issued To',"
            SQL &= "      AccountNumber(Payee_ID) AS 'Account Number',"
            SQL &= "      0 AS 'Cash Amount',"
            SQL &= "      (SELECT Deduct_Balance + Advance_Payment FROM credit_application WHERE CreditNumber = Payee_ID) AS 'Check Amount',"
            SQL &= "      0 AS 'Online Amount',"
            SQL &= "      CheckNumber AS 'Check Number',"
            SQL &= "      DATE_FORMAT(CheckDate,'%b %d, %Y') AS 'Check Date',"
            SQL &= "      IFNULL((SELECT Deduct_Balance + Advance_Payment FROM credit_application WHERE CreditNumber = Payee_ID),0) AS 'Loans',"
            SQL &= "      0 AS 'Amount', PostingDate, Payee_ID, Payee_Type, JVNumber"
            SQL &= " FROM check_voucher WHERE `status` = 'ACTIVE' AND Voucher_Status = 'APPROVED' AND Payee_Type = 'C' AND (SELECT Deduct_Balance + Advance_Payment FROM credit_application WHERE CreditNumber = Payee_ID) > 0"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({2}),Branch_ID = '{1}') AND IF('{3}' = 'True',TRUE,IF('{4}' = 0,Book(BankID) = '{5}',BankID = '{4}'))) A ORDER BY `Document Number`", cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        End If

        If SQL = "" Then
        Else
            Dim DT_TEMP As DataTable = DataSource(SQL)
            Dim DT As DataTable = DT_TEMP.Copy
            DT.Rows.Clear()
            For x As Integer = 0 To DT_TEMP.Rows.Count - 1
                If DT_TEMP(x)("JVNumber") = "" Then
                    DT.Rows.Add(DT_TEMP(x)("Document Number"), DT_TEMP(x)("Issued To"), DT_TEMP(x)("Account Number"), DT_TEMP(x)("Cash Amount"), DT_TEMP(x)("Check Amount"), DT_TEMP(x)("Online Amount"), DT_TEMP(x)("Check Number"), DT_TEMP(x)("Check Date"), DT_TEMP(x)("Loans"), DT_TEMP(x)("Amount"), DT_TEMP(x)("PostingDate"), DT_TEMP(x)("Payee_ID"), DT_TEMP(x)("Payee_Type"), DT_TEMP(x)("JVNumber"))
                End If
            Next
            GridControl2.DataSource = DT.Copy
            Dim Cash As Double
            Dim Check As Double
            Dim Online As Double
            Dim Loan As Double
            Dim Amount As Double
            For x As Integer = 0 To DT.Rows.Count - 1
                Cash += DT(x)("Cash Amount")
                Check += DT(x)("Check Amount")
                Online += DT(x)("Online Amount")
                Loan += DT(x)("Loans")
                Amount += DT(x)("Amount")
            Next
            DT.Rows.Add("", "", "T O T A L", Cash, Check, Online, "", "", Loan, Amount, "", "", "", "")

            If cbxCancelled.Checked Then
                Cash = 0
                Check = 0
                Online = 0
                Loan = 0
                Amount = 0
                DT.Rows.Add("", "", "", 0, 0, 0, "", "", 0, 0, "", "", "", "")
                DT_Cancelled = DT.Copy
                DT_Cancelled.Rows.Clear()
                For x As Integer = 0 To DT_TEMP.Rows.Count - 1
                    If DT_TEMP(x)("JVNumber") <> "" Then
                        DT_Cancelled.Rows.Add(DT_TEMP(x)("Document Number"), DT_TEMP(x)("Issued To"), DT_TEMP(x)("Account Number"), DT_TEMP(x)("Cash Amount"), DT_TEMP(x)("Check Amount"), DT_TEMP(x)("Online Amount"), DT_TEMP(x)("Check Number"), DT_TEMP(x)("Check Date"), DT_TEMP(x)("Loans"), DT_TEMP(x)("Amount"), DT_TEMP(x)("PostingDate"), DT_TEMP(x)("Payee_ID"), DT_TEMP(x)("Payee_Type"), DT_TEMP(x)("JVNumber"))
                        DT.Rows.Add(DT_TEMP(x)("Document Number"), DT_TEMP(x)("Issued To"), DT_TEMP(x)("Account Number"), DT_TEMP(x)("Cash Amount"), DT_TEMP(x)("Check Amount"), DT_TEMP(x)("Online Amount"), DT_TEMP(x)("Check Number"), DT_TEMP(x)("Check Date"), DT_TEMP(x)("Loans"), DT_TEMP(x)("Amount"), DT_TEMP(x)("PostingDate"), DT_TEMP(x)("Payee_ID"), DT_TEMP(x)("Payee_Type"), DT_TEMP(x)("JVNumber"))

                        Cash += DT_TEMP(x)("Cash Amount")
                        Check += DT_TEMP(x)("Check Amount")
                        Online += DT_TEMP(x)("Online Amount")
                        Loan += DT_TEMP(x)("Loans")
                        Amount += DT_TEMP(x)("Amount")
                    End If
                Next
                DT.Rows.Add("", "", "TOTAL CANCELLED", Cash, Check, Online, "", "", Loan, Amount, "", "", "", "")
            End If
            GridControl1.DataSource = DT
        End If

        If GridView1.RowCount > 14 Then
            GridColumn2.Width = 244 - 17

            LabelX7.Size = New Point(773 - 17, 23)

            LabelX6.Location = New Point(773 - 17, 137)
            LabelX4.Location = New Point(993 - 17, 115)
            LabelX3.Location = New Point(993 - 17, 137)
            LabelX5.Location = New Point(1077 - 17, 137)
        Else
            GridColumn2.Width = 244 - 1

            LabelX7.Size = New Point(773 - 1, 23)

            LabelX6.Location = New Point(773 - 1, 137)
            LabelX4.Location = New Point(993 - 1, 115)
            LabelX3.Location = New Point(993 - 1, 137)
            LabelX5.Location = New Point(1077 - 1, 137)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        'If GridView1.RowCount > 0 Then
        '    Dim JVNumber As String = GridView1.GetRowCellDisplayText(e.RowHandle, GridView1.Columns("JVNumber"))
        '    If JVNumber <> "DELETED" Then
        '        e.Appearance.ForeColor = OfficialColor2 'Color.Red
        '    End If
        'End If
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
        Dim Report As New RptCollectionReport
        With Report
            .Name = String.Format("Collection Report of {0}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text))
            .lblBank.Text = If(cbxAllBank.Checked, "", cbxBank.Text)
            .lblAsOf.Text = If(dtpFrom.Value = dtpTo.Value Or cbxAll.Checked, "", "From " & dtpFrom.Text & " To " & dtpTo.Text)

            .DataSource = GridControl2.DataSource
            .lblDocumentNumber.DataBindings.Add("Text", GridControl2.DataSource, "Document Number")
            .lblIssuedTo.DataBindings.Add("Text", GridControl2.DataSource, "Issued To")
            .lblAccountNumber.DataBindings.Add("Text", GridControl2.DataSource, "Account Number")
            .lblCash.DataBindings.Add("Text", GridControl2.DataSource, "Cash Amount")
            .lblCheck.DataBindings.Add("Text", GridControl2.DataSource, "Check Amount")
            .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Online Amount")
            .lblCheckNumber.DataBindings.Add("Text", GridControl2.DataSource, "Check Number")
            .lblCheckDate.DataBindings.Add("Text", GridControl2.DataSource, "Check Date")
            .lblLoans.DataBindings.Add("Text", GridControl2.DataSource, "Loans")
            .lblOthers.DataBindings.Add("Text", GridControl2.DataSource, "Amount")

            If GridView1.RowCount > 0 Then
                If cbxCancelled.Checked Then
                    .lblCashT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Cash Amount"), 2)
                    .lblCheckT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Check Amount"), 2)
                    .lblAmountT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Online Amount"), 2)
                    .lblLoansT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Loans"), 2)
                    .lblOthersT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Amount"), 2)

                    .XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Left
                    .subRptCollectionReport.Visible = True
                    Dim SubRpt As New SubRptCollectionReport With {
                        .DataSource = DT_Cancelled
                    }
                    .subRptCollectionReport.ReportSource = SubRpt
                    SubRpt.lblDocumentNumber.DataBindings.Add("Text", DT_Cancelled, "Document Number")
                    SubRpt.lblIssuedTo.DataBindings.Add("Text", DT_Cancelled, "Issued To")
                    SubRpt.lblAccountNumber.DataBindings.Add("Text", DT_Cancelled, "Account Number")
                    SubRpt.lblCash.DataBindings.Add("Text", DT_Cancelled, "Cash Amount")
                    SubRpt.lblCheck.DataBindings.Add("Text", DT_Cancelled, "Check Amount")
                    SubRpt.lblAmount.DataBindings.Add("Text", DT_Cancelled, "Online Amount")
                    SubRpt.lblCheckNumber.DataBindings.Add("Text", DT_Cancelled, "Check Number")
                    SubRpt.lblCheckDate.DataBindings.Add("Text", DT_Cancelled, "Check Date")
                    SubRpt.lblLoans.DataBindings.Add("Text", DT_Cancelled, "Loans")
                    SubRpt.lblOthers.DataBindings.Add("Text", DT_Cancelled, "Amount")

                    SubRpt.lblCashT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Cash Amount"), 2)
                    SubRpt.lblCheckT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Check Amount"), 2)
                    SubRpt.lblAmountT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Online Amount"), 2)
                    SubRpt.lblLoansT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Loans"), 2)
                    SubRpt.lblOthersT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Amount"), 2)
                Else
                    If GridView1.GetRowCellValue(GridView1.RowCount - 1, "Account Number").ToString = "TOTAL CANCELLED" Then
                        .lblCashT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Cash Amount"), 2)
                        .lblCheckT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Check Amount"), 2)
                        .lblAmountT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Online Amount"), 2)
                        .lblLoansT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Loans"), 2)
                        .lblOthersT.Text = FormatNumber(GridView1.GetRowCellValue((GridView1.RowCount - 3) - DT_Cancelled.Rows.Count, "Amount"), 2)
                    Else
                        .lblCashT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Cash Amount"), 2)
                        .lblCheckT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Check Amount"), 2)
                        .lblAmountT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Online Amount"), 2)
                        .lblLoansT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Loans"), 2)
                        .lblOthersT.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Amount"), 2)
                    End If
                End If
            End If

            Dim DT_Data As New DataTable
            Dim PreviousFrom As String = Format(dtpFrom.Value, "yyyy-MM-dd")
            Dim PreviousTo As String = Format(dtpTo.Value, "yyyy-MM-dd")
            If cbxDisplay.SelectedIndex = 0 Then
                PreviousFrom = Format(dtpFrom.Value.AddDays(-1), "yyyy-MM-dd")
                PreviousTo = Format(dtpTo.Value.AddDays(-1), "yyyy-MM-dd")
            ElseIf cbxDisplay.SelectedIndex = 1 Then
                PreviousFrom = Format(dtpFrom.Value.AddDays(-7), "yyyy-MM-dd")
                PreviousTo = Format(dtpTo.Value.AddDays(-7), "yyyy-MM-dd")
            ElseIf cbxDisplay.SelectedIndex = 2 Then
                PreviousFrom = Format(dtpFrom.Value.AddMonths(-1), "yyyy-MM-dd")
                PreviousTo = Format(dtpTo.Value.AddMonths(-1), "yyyy-MM-dd")
            ElseIf cbxDisplay.SelectedIndex = 3 Then
                PreviousFrom = Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd")
                PreviousTo = Format(dtpTo.Value.AddYears(-1), "yyyy-MM-dd")
            End If

            DT_Data = DataSource(String.Format("CALL CollectionReport_PrintDetails({0},{1},'{2}',{3},{4},{5},'{6}','{7}','{8}','{9}',{10})", cbxAllB.Checked, ValidateComboBox(cbxBranch), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook), FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo), PreviousFrom, PreviousTo, cbxAll.Checked))

            If DT_Data.Rows.Count > 0 Then
                .lblCurrent_C.Text = DT_Data(0)("Principal")
                .lblCurrent_P.Text = DT_Data(0)("Past Due")
                .lblCurrent_C2.Text = DT_Data(0)("UDI")
                .lblCurrent_P2.Text = DT_Data(0)("RPPD")

                .lblReturnedCheck_C.Text = DT_Data(0)("Returned Check")
                .lblReturnedCheck_P.Text = DT_Data(0)("Returned Check Past Due")
                .lblReturnedCheck_C2.Text = DT_Data(0)("Returned Check UDI")
                .lblReturnedCheck_P2.Text = DT_Data(0)("Returned Check RPPD")

                .lblCancelled_C.Text = DT_Data(0)("Cancelled")
                .lblCancelled_P.Text = DT_Data(0)("Cancelled Past Due")
                .lblCancelled_C2.Text = DT_Data(0)("Cancelled UDI")
                .lblCancelled_P2.Text = DT_Data(0)("Cancelled RPPD")

                If cbxAll.Checked Or cbxDisplay.SelectedIndex = 4 Then
                Else
                    .lblPrevious_C.Text = DT_Data(0)("Principal P")
                    .lblPrevious_P.Text = DT_Data(0)("Past Due P")
                    .lblPrevious_C2.Text = DT_Data(0)("UDI P")
                    .lblPrevious_P2.Text = DT_Data(0)("RPPD P")
                End If

                .lblCurrent_T.Text = FormatNumber(.lblCurrent_C.Text + .lblCurrent_P.Text, 2)
                .lblPrevious_T.Text = FormatNumber(.lblPrevious_C.Text + .lblPrevious_P.Text, 2)
                .lblReturnedCheck_T.Text = FormatNumber(.lblReturnedCheck_C.Text + .lblReturnedCheck_P.Text, 2)
                .lblCancelled_T.Text = FormatNumber(.lblCancelled_C.Text + .lblCancelled_P.Text, 2)

                .lblTotal_C.Text = FormatNumber(.lblCurrent_C.Text + .lblPrevious_C.Text, 2)
                .lblTotal_P.Text = FormatNumber(.lblCurrent_P.Text + .lblPrevious_P.Text, 2)
                .lblTotal_T.Text = FormatNumber(.lblTotal_C.Text + .lblTotal_P.Text, 2)

                .lblCurrent_T2.Text = FormatNumber(.lblCurrent_C2.Text + .lblCurrent_P2.Text, 2)
                .lblPrevious_T2.Text = FormatNumber(.lblPrevious_C2.Text + .lblPrevious_P2.Text, 2)
                .lblReturnedCheck_T2.Text = FormatNumber(.lblReturnedCheck_C2.Text + .lblReturnedCheck_P2.Text, 2)
                .lblCancelled_T2.Text = FormatNumber(.lblCancelled_C2.Text + .lblCancelled_P2.Text, 2)

                .lblTotal_C2.Text = FormatNumber(.lblCurrent_C2.Text + .lblPrevious_C2.Text, 2)
                .lblTotal_P2.Text = FormatNumber(.lblCurrent_P2.Text + .lblPrevious_P2.Text, 2)
                .lblTotal_T2.Text = FormatNumber(.lblTotal_C2.Text + .lblTotal_P2.Text, 2)
            End If

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblPosition.Text = lblPosition.Text
            .lblCheckedBy.Text = cbxCheckedBy.Text
            .lblPositionChecked.Text = lblPositionChecked.Text
            .lblNotedBy.Text = cbxNotedBy.Text
            .lblPositionNoted.Text = lblPositionNoted.Text
            Logs("Collection Report", "Print", "[SENSITIVE] Print Collection Report", "", "", "", "")

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

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
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
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
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
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxPreparedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPreparedBy.SelectedIndexChanged
        If cbxPreparedBy.SelectedIndex = -1 Or cbxPreparedBy.Text = "" Then
            lblPosition.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
            lblPosition.Text = drv("Position")
        End If
    End Sub

    Private Sub CbxCheckedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCheckedBy.SelectedIndexChanged
        If cbxCheckedBy.SelectedIndex = -1 Or cbxCheckedBy.Text = "" Then
            lblPositionChecked.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxCheckedBy.SelectedItem, DataRowView)
            lblPositionChecked.Text = drv("Position")
        End If
    End Sub

    Private Sub CbxNotedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNotedBy.SelectedIndexChanged
        If cbxNotedBy.SelectedIndex = -1 Or cbxNotedBy.Text = "" Then
            lblPositionNoted.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxNotedBy.SelectedItem, DataRowView)
            lblPositionNoted.Text = drv("Position")
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
        StandardPrinting("COLLECTION REPORT", GridControl1)
        Logs("Collection Report", "Print", "[SENSITIVE] Print Collection Report", "", "", "", "")
        Cursor = Cursors.Default
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

    Private Sub CbxAllB_CheckedChanged_1(sender As Object, e As EventArgs) Handles cbxAllB.CheckedChanged
        If cbxAllB.Checked Then
            cbxBranch.Enabled = False
            cbxBranch.SelectedIndex = -1
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
        End If
    End Sub

    Private Sub IOfficialReceipt_Click(sender As Object, e As EventArgs) Handles iOfficialReceipt.Click
        Try
            If GridView1.GetFocusedRowCellValue("Payee_ID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Document Number").ToString.Contains("OR-") Then
            Dim Official As New FrmOfficialReceipt
            With Official
                .Tag = 99
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Collection Report", "Official Receipt", "Open Official Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        Else
            MsgBox("Document is from the Acknowledgement Receipt", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IAcknowledgementReceipt_Click(sender As Object, e As EventArgs) Handles iAcknowledgementReceipt.Click
        Try
            If GridView1.GetFocusedRowCellValue("Payee_ID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Document Number").ToString.Contains("ACR-") Then
            Dim Official As New FrmAcknowledgement
            With Official
                .Tag = 84
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Collection Report", "Acknowledgement Receipt", "Open Acknowledgement Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        Else
            MsgBox("Document is from the Official Receipt", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IAccountLedger_Click(sender As Object, e As EventArgs) Handles iAccountLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("Payee_ID") = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Document Number").ToString.Contains("ACR-") And GridView1.GetFocusedRowCellValue("Payee_Type") <> "LA" Then
                MsgBox("Transaction is not loans related.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmAccountLedger
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("Payee_ID")
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub CbxOR_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOR.CheckedChanged, cbxACR.CheckedChanged, cbxCancelled.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub
End Class