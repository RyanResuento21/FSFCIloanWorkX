Imports DevExpress.XtraReports.UI
Public Class FrmGeneralLedgerTransaction

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Public AccountCode As String = ""
    Public From_TrialBalance As Boolean
    Public From_BalanceSheet As Boolean
    Public From_IncomeStatement As Boolean
    Dim cbxBranch As Integer
    Dim cbxBusinessCenter As String
    Dim cbxAllB As Boolean
    Dim cbxBook As Integer
    Dim cbxBank As Integer
    Dim cbxAllBank As Boolean
    Dim cbxDisplay As Integer
    Dim cbxAll As Boolean
    Dim dtpFrom As Date
    Dim dtpTo As Date
    Private Sub FrmGeneralLedger_Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_TrialBalance Then
            With FrmTrialBalance
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        ElseIf From_BalanceSheet Then
            With FrmBalanceSheet
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        ElseIf From_IncomeStatement Then
            With FrmIncomeStatement
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        Else
            With FrmGeneralLedger
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        End If
        LoadData()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblORNumber, LabelX9, LabelX1})

            GetTextBoxFontSettings({lblDocumentNumber, lblPostingDate})

            GetRickTextBoxFontSettings({rRemarks})

            GetButtonFontSettings({btnCancel, btnPrint, btnSearch})
        Catch ex As Exception
            TriggerBugReport("General Ledger Transaction - FixUI", ex.Message.ToString)
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
        OpenFormHistory("General Ledger", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    (SELECT Title FROM account_Chart WHERE `Code` = accounting_entry.AccountCode) AS 'Account',"
        SQL &= "    BusinessCenter(BusinessCode) AS 'Business Center',"
        SQL &= "    Department(DepartmentCode) AS 'Department',"
        SQL &= "    IFNULL((CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Debit',"
        SQL &= "    IFNULL((CASE WHEN EntryType = 'CREDIT' THEN Amount END),0) AS 'Credit',"
        SQL &= "    EntryType AS 'Type',"
        SQL &= "    Remarks, AccountCode"
        SQL &= String.Format("    FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND ABS(Amount) > 0 AND IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) = '{0}' AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND ORDate = '{1}' AND IF({2} > 0, BankID = '{2}',TRUE);", lblDocumentNumber.Text, Format(CDate(lblPostingDate.Text), "yyyy-MM-dd"), DefaultBankID)
        GridControl1.DataSource = DataSource(SQL)
        With GridView1
            .Columns("Account").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Account").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Debit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Credit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 8 Then
            GridColumn5.Width = 338 - 17
        Else
            GridColumn5.Width = 338
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim Total_1 As Double
            Dim Total_2 As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                Total_1 += GridView1.GetRowCellValue(selectedRowHandle, "Debit")
                Total_2 += GridView1.GetRowCellValue(selectedRowHandle, "Credit")
            Next
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = FormatNumber(Total_1, 2)
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = FormatNumber(Total_2, 2)
        Else
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
        End If
    End Sub

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
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptGeneralLedgerTransaction
        With Report
            .Name = lblTitle.Text & " - " & lblDocumentNumber.Text
            .lblAsOf.Text = If(dtpFrom = dtpTo Or cbxAll, "", "From " & Format(dtpFrom, "MMMM dd, yyyy") & " To " & Format(dtpTo, "MMMM dd, yyyy"))

            .lblDocument.Text = lblDocumentNumber.Text
            .lblPosting.Text = lblPostingDate.Text
            .lblRemarks.Text = rRemarks.Text

            .DataSource = GridControl1.DataSource
            .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account")
            .lblDepartment.DataBindings.Add("Text", GridControl1.DataSource, "Department")
            .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
            .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
            .lblRemarks.DataBindings.Add("Text", GridControl1.DataSource, "Remarks")
            Logs("General Ledger", "Print", "[SENSITIVE] Print General Ledger - Transaction List", "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Code As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AccountCode"))
            If Code = AccountCode Then
                e.Appearance.ForeColor = Color.SeaGreen
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If btnSearch.DialogResult = DialogResult.OK Then
        Else
            If MsgBox("Are you sure you want to view transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                If lblDocumentNumber.Text.Contains("JV") Then
                    'J O U R N A L   V O U C H E R ***************************************************************************************
                    Dim JV As New FrmJournalVoucher
                    With JV
                        .Tag = 25
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

                        Logs("General Ledger", "Check", "Journal Voucher", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'J O U R N A L   V O U C H E R ***************************************************************************************

                ElseIf lblDocumentNumber.Text.Contains("CV") Then
                    'C H E C K   V O U C H E R ***************************************************************************************
                    Dim CV As New FrmCheckVoucher
                    With CV
                        .Tag = 80
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

                        Logs("General Ledger", "Check", "Check Voucher", "", "", "", "")
                        .From_GeneralLedger = True
                        .AccountNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'C H E C K   V O U C H E R ***************************************************************************************

                ElseIf lblDocumentNumber.Text.Contains("ACR") Then
                    'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************
                    Dim ACR As New FrmAcknowledgement
                    With ACR
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

                        Logs("General Ledger", "Check", "Acknowledgement Receipt", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************

                ElseIf lblDocumentNumber.Text.Contains("AP") Then
                    'A C C O U N T S    P A Y A B L E ***************************************************************************************
                    Dim AP As New FrmAccountsPayable
                    With AP
                        .Tag = 89
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

                        Logs("General Ledger", "Check", "Accounts Payable", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'A C C O U N T S    P A Y A B L E ***************************************************************************************

                ElseIf lblDocumentNumber.Text.Contains("AR") Then
                    'A C C O U N T S    R E C E I V A B L E ***************************************************************************************
                    Dim AR As New FrmAccountsReceivable
                    With AR
                        .Tag = 90
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

                        Logs("General Ledger", "Check", "Accounts Receivable", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'A C C O U N T S   P A Y A B L E ***************************************************************************************
                ElseIf lblDocumentNumber.Text.Contains("OR") Then
                    'O F F I C I A L   R E C E I P T ***************************************************************************************
                    Dim AR As New FrmOfficialReceipt
                    With AR
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

                        Logs("General Ledger", "Check", "Official Receipt", "", "", "", "")
                        .From_GL = True
                        .Skip_FilterLoadData = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .ShowDialog()
                        .Dispose()
                    End With
                    'O F F I C I A L   R E C E I P T ***************************************************************************************

                ElseIf lblDocumentNumber.Text.Contains("DT") Then
                    'D U E   T O  ***************************************************************************************
                    Dim DT As New FrmDueTo
                    With DT
                        .Tag = 101
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

                        Logs("General Ledger", "Check", "Due To", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'D U E   T O  ***************************************************************************************
                ElseIf lblDocumentNumber.Text.Contains("DF") Then
                    'D U E   T O  ***************************************************************************************
                    Dim DF As New FrmDueTo
                    With DF
                        .Tag = 102
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

                        Logs("General Ledger", "Check", "Due From", "", "", "", "")
                        .From_GL = True
                        .GL_DocumentNumber = lblDocumentNumber.Text
                        .Skip_FilterLoadData = True
                        .ShowDialog()
                        .Dispose()
                    End With
                    'D U E   T O  ***************************************************************************************
                End If

            End If
        End If
    End Sub
End Class