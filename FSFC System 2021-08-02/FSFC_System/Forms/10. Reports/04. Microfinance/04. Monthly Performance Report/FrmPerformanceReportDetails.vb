Imports DevExpress.XtraReports.UI
Public Class FrmPerformanceReportDetails

    Public MarketingID As String
    Public Marketing As String
    Public vPrint As Boolean
    Private Sub FrmPerformanceReportDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Performance Report Details - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Performance Report Details", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim DT_Temp As New DataTable
        Dim DateCondition_1 As String = ""
        Dim DateCondition_2 As String = ""
        With FrmPerformanceReport
            If .cbxDisplay.SelectedIndex = 0 Then
                DateCondition_1 = String.Format("DATE(PostingDate) = DATE('{0}')", Format(.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(.dtpFrom.Value, "yyyy-MM-dd")
            ElseIf .cbxDisplay.SelectedIndex = 1 Or .cbxDisplay.SelectedIndex = 2 Or .cbxDisplay.SelectedIndex = 3 Or .cbxDisplay.SelectedIndex = 4 Then
                DateCondition_1 = String.Format("DATE(PostingDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(.dtpFrom.Value, "yyyy-MM-dd"), Format(.dtpTo.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(.dtpTo.Value, "yyyy-MM-dd")
            ElseIf .cbxDisplay.SelectedIndex = 5 Or .cbxDisplay.SelectedIndex = -1 Then
                DateCondition_1 = String.Format("DATE(PostingDate) <= DATE('{0}')", Format(.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(.dtpFrom.Value, "yyyy-MM-dd")
            End If

            SQL = "SELECT credit_application.CreditNumber, CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Borrower',"
            SQL &= "     AccountNumber AS 'PN Number',"
            SQL &= "     Terms,"
            SQL &= "     CONCAT(IF(CEIL(interest_rate / 12) = interest_rate / 12,interest_rate / 12,ROUND(interest_rate / 12,2)),' %') AS 'Interest Rate',"
            SQL &= "     Product,"
            SQL &= "     (AmountApplied + credit_application.Interest) - (IFNULL(Collection.Principal,0) + IFNULL(Collection.Interest,0)) AS 'Outstanding',"
            SQL &= "     IFNULL((PastDue.Payable),0) - (IFNULL(Collection.Principal,0) + IFNULL(Collection.Interest,0)) AS 'Past Due',"
            SQL &= "     Face_Amount AS 'Releases',"
            SQL &= "     IFNULL(Collection.Principal,0) AS 'Principal_4',"
            SQL &= "     IFNULL(Collection.Interest,0) AS 'Interest_4',"
            SQL &= "     IFNULL(Collection.Penalty,0) AS 'Penalties_4'"
            SQL &= " FROM credit_application"
            SQL &= String.Format(" LEFT JOIN (SELECT CreditNUmber, SUM(InterestIncome + PrincipalAllocation) AS 'Payable' FROM credit_schedule WHERE `status` = 'ACTIVE' AND DueDate <= '{0}' AND DueDate != '' GROUP BY CreditNumber) PastDue ON PastDue.CreditNumber = credit_application.CreditNumber", DateCondition_2)
            SQL &= String.Format(" LEFT JOIN (SELECT main.Payee_ID, IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN Credit END),0) AS 'Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN Credit END),0) AS 'Interest', IFNULL(SUM(CASE WHEN PaidFor = 'Penalty' THEN Credit END),0) AS 'Penalty' FROM official_receipt main INNER JOIN or_details details ON main.DocumentNumber = details.DocumentNumber WHERE main.`status` = 'ACTIVE' AND details.`status` = 'ACTIVE' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND {4} GROUP BY Payee_ID) Collection ON credit_application.CreditNumber = Collection.Payee_ID", .cbxBranch.SelectedValue, .cbxAllB.Checked, ValidateComboBox(.cbxBusinessCenter), Multiple_ID, DateCondition_1)
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED') AND MarketingID != '' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND MarketingID = '{4}'", .cbxBranch.SelectedValue, .cbxAllB.Checked, ValidateComboBox(.cbxBusinessCenter), Multiple_ID, MarketingID)
            GridControl1.DataSource = DataSource(SQL)
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptPerformanceReportDetails
        With Report
            Dim DateFilter As String = ""
            With FrmPerformanceReport
                If FrmPerformanceReport.cbxDisplay.SelectedIndex = 0 Then
                    DateFilter = String.Format("For {0}", FrmPerformanceReport.dtpFrom.Text)
                ElseIf FrmPerformanceReport.cbxDisplay.SelectedIndex = 1 Or FrmPerformanceReport.cbxDisplay.SelectedIndex = 2 Or FrmPerformanceReport.cbxDisplay.SelectedIndex = 3 Or FrmPerformanceReport.cbxDisplay.SelectedIndex = 4 Then
                    DateFilter = String.Format("For {0} - {1}", FrmPerformanceReport.dtpFrom.Text, FrmPerformanceReport.dtpTo.Text)
                ElseIf FrmPerformanceReport.cbxDisplay.SelectedIndex = 5 Then
                    DateFilter = String.Format("As of {0}", FrmPerformanceReport.dtpFrom.Text)
                End If
            End With

            .Name = String.Format("Performance Report of {0} {1}", Marketing, DateFilter)
            .lblTitle.Text = String.Format("Performance Report of {0}", Marketing)
            .lblBranch.Text = If(FrmPerformanceReport.cbxAllB.Checked, "ALL BRANCHES", FrmPerformanceReport.cbxBranch.Text)
            .lblAsOf.Text = DateFilter
            .DataSource = GridControl1.DataSource
            .lblBorrower.DataBindings.Add("Text", GridControl1.DataSource, "Borrower")
            .lblPNNumber.DataBindings.Add("Text", GridControl1.DataSource, "PN Number")
            .lblTerms.DataBindings.Add("Text", GridControl1.DataSource, "Terms")
            .lblInterestRate.DataBindings.Add("Text", GridControl1.DataSource, "Interest Rate")
            .lblProduct.DataBindings.Add("Text", GridControl1.DataSource, "Product")
            .lblReleases.DataBindings.Add("Text", GridControl1.DataSource, "Outstanding")
            .lblOutstanding.DataBindings.Add("Text", GridControl1.DataSource, "Past Due")
            .lblPastDue.DataBindings.Add("Text", GridControl1.DataSource, "Releases")
            .lblPrincipal.DataBindings.Add("Text", GridControl1.DataSource, "Principal_4")
            .lblInterest.DataBindings.Add("Text", GridControl1.DataSource, "Interest_4")
            .lblPenalties.DataBindings.Add("Text", GridControl1.DataSource, "Penalties_4")

            .lblReleasesT.DataBindings.Add("Text", GridControl1.DataSource, "Outstanding")
            .lblOutstandingT.DataBindings.Add("Text", GridControl1.DataSource, "Past Due")
            .lblPastDueT.DataBindings.Add("Text", GridControl1.DataSource, "Releases")
            .lblPrincipalT.DataBindings.Add("Text", GridControl1.DataSource, "Principal_4")
            .lblInterestT.DataBindings.Add("Text", GridControl1.DataSource, "Interest_4")
            .lblPenaltiesT.DataBindings.Add("Text", GridControl1.DataSource, "Penalties_4")
            Logs("Performance Report Details", "Print", "[SENSITIVE] Print Performance Report Details", "", "", "", "")

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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView1.DoubleClick
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub ISOA_Click(sender As Object, e As EventArgs) Handles iSOA.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim SOA As New FrmSOA
        With SOA
            .From_JV_DTS = True
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .dtpAsOf.Value = FrmPerformanceReport.dtpFrom.Value
            .cbxCreditApplication.Enabled = False
            .ShowDialog()
        End With
    End Sub
End Class