Imports DevExpress.XtraReports.UI
Public Class FrmPerformanceReport

    Public vPrint As Boolean
    Dim FirstLoad As Boolean

    Private Sub FrmPerformanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 5

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND FIND_IN_SET(ID,'{0}') ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            .SelectedValue = Branch_ID
            If Branch_ID = 0 And MultipleBranch Then
            Else
                cbxAllB.Visible = False
                .Enabled = False
            End If
        End With

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With
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

            GetLabelFontSettings({LabelX1, LabelX40, lblFrom, LabelX41})

            GetCheckBoxFontSettings({cbxAllB, cbxAll})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Performance Report - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Performance Report", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim DT_Temp As New DataTable
        Dim DateCondition_1 As String = ""
        Dim DateCondition_2 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(PostingDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpFrom.Value, "yyyy-MM-dd")
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(PostingDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpTo.Value, "yyyy-MM-dd")
        ElseIf cbxDisplay.SelectedIndex = 5 Or cbxDisplay.SelectedIndex = -1 Then
            DateCondition_1 = String.Format("DATE(PostingDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpFrom.Value, "yyyy-MM-dd")
        End If

        SQL = "SELECT MarketingID, (SELECT CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name' FROM employee_setup WHERE emp_code = MarketingID LIMIT 1) AS 'Account Officer',"
        SQL &= "     SUM(AmountApplied + credit_application.Interest) - SUM(IFNULL(Collection.Principal,0) + IFNULL(Collection.Interest,0)) AS 'Outstanding_1',"
        SQL &= "     COUNT(CASE WHEN PaymentRequest = 'RELEASED' THEN credit_application.CreditNumber END) AS 'Client_1',"
        SQL &= "     IFNULL(SUM(PastDue.Payable),0) - (IFNULL(Collection.Principal,0) + IFNULL(Collection.Interest,0)) AS 'Amount_2',"
        SQL &= "     0 AS 'Ratio_2',"
        SQL &= "     COUNT(CASE WHEN (IFNULL(PastDue.Payable,0) - (IFNULL(Collection.Principal,0) + IFNULL(Collection.Interest,0))) > 0 THEN ID END) AS 'Client_2',"
        SQL &= "     SUM(Face_Amount) AS 'Amount_3',"
        SQL &= "     COUNT(DISTINCT credit_application.CreditNumber) AS 'Release_3',"
        SQL &= "     IFNULL(Collection.Principal,0) AS 'Principal_4',"
        SQL &= "     IFNULL(Collection.Interest,0) AS 'Interest_4',"
        SQL &= "     IFNULL(Collection.Penalty,0) AS 'Penalties_4'"
        SQL &= " FROM credit_application"
        SQL &= String.Format(" LEFT JOIN (SELECT CreditNUmber, SUM(InterestIncome + PrincipalAllocation) AS 'Payable' FROM credit_schedule WHERE `status` = 'ACTIVE' AND DueDate <= '{0}' AND DueDate != '' GROUP BY CreditNumber) PastDue ON PastDue.CreditNumber = credit_application.CreditNumber", DateCondition_2)
        SQL &= String.Format(" LEFT JOIN (SELECT main.Payee_ID, IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN Credit END),0) AS 'Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN Credit END),0) AS 'Interest', IFNULL(SUM(CASE WHEN PaidFor = 'Penalty' THEN Credit END),0) AS 'Penalty' FROM official_receipt main INNER JOIN or_details details ON main.DocumentNumber = details.DocumentNumber WHERE main.`status` = 'ACTIVE' AND details.`status` = 'ACTIVE' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND {4} GROUP BY Payee_ID) Collection ON credit_application.CreditNumber = Collection.Payee_ID", cbxBranch.SelectedValue, cbxAllB.Checked, ValidateComboBox(cbxBusinessCenter), Multiple_ID, DateCondition_1)
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED') AND MarketingID != '' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') GROUP BY MarketingID ORDER BY `Account Officer`", cbxBranch.SelectedValue, cbxAllB.Checked, ValidateComboBox(cbxBusinessCenter), Multiple_ID)
        GridControl1.DataSource = DataSource(SQL)
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
        Dim Report As New RptPerformanceReport
        With Report
            Dim DateFilter As String = ""
            If cbxDisplay.SelectedIndex = 0 Then
                DateFilter = String.Format("For {0}", dtpFrom.Text)
            ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                DateFilter = String.Format("As of {0}", dtpFrom.Text)
            End If

            .Name = String.Format("Performance Report per Account Officer of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblAsOf.Text = DateFilter
            .DataSource = GridControl1.DataSource
            .lblAccountOfficer.DataBindings.Add("Text", GridControl1.DataSource, "Account Officer")
            .lblOutstanding_1.DataBindings.Add("Text", GridControl1.DataSource, "Outstanding_1")
            .lblClients_1.DataBindings.Add("Text", GridControl1.DataSource, "Client_1")
            .lblAmount_2.DataBindings.Add("Text", GridControl1.DataSource, "Amount_2")
            .lblRatio_2.DataBindings.Add("Text", GridControl1.DataSource, "Ratio_2")
            .lblClient_2.DataBindings.Add("Text", GridControl1.DataSource, "Client_2")
            .lblAmount_3.DataBindings.Add("Text", GridControl1.DataSource, "Amount_3")
            .lblReleases_3.DataBindings.Add("Text", GridControl1.DataSource, "Release_3")
            .lblPrincipal_4.DataBindings.Add("Text", GridControl1.DataSource, "Principal_4")
            .lblInterest_4.DataBindings.Add("Text", GridControl1.DataSource, "Interest_4")
            .lblPenalties_4.DataBindings.Add("Text", GridControl1.DataSource, "Penalties_4")

            .lblOutstanding_1T.DataBindings.Add("Text", GridControl1.DataSource, "Outstanding_1")
            .lblClients_1T.DataBindings.Add("Text", GridControl1.DataSource, "Client_1")
            .lblAmount_2T.DataBindings.Add("Text", GridControl1.DataSource, "Amount_2")
            .lblRatio_2T.DataBindings.Add("Text", GridControl1.DataSource, "Ratio_2")
            .lblClient_2T.DataBindings.Add("Text", GridControl1.DataSource, "Client_2")
            .lblAmount_3T.DataBindings.Add("Text", GridControl1.DataSource, "Amount_3")
            .lblReleases_3T.DataBindings.Add("Text", GridControl1.DataSource, "Release_3")
            .lblPrincipal_4T.DataBindings.Add("Text", GridControl1.DataSource, "Principal_4")
            .lblInterest_4T.DataBindings.Add("Text", GridControl1.DataSource, "Interest_4")
            .lblPenalties_4T.DataBindings.Add("Text", GridControl1.DataSource, "Penalties_4")
            Logs("Performance Report", "Print", "[SENSITIVE] Print Performance Report", "", "", "", "")

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
        BandedGridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting(lblTitle.Text, GridControl1)
        Logs("Performance Report", "Print", "[SENSITIVE] Print Performance Report", "", "", "", "")
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

    Private Sub IDetails_Click(sender As Object, e As EventArgs) Handles iDetails.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("MarketingID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Details As New FrmPerformanceReportDetails
        With Details
            .MarketingID = BandedGridView1.GetFocusedRowCellValue("MarketingID")
            .Marketing = BandedGridView1.GetFocusedRowCellValue("Account Officer").ToString
            .lblTitle.Text = "PERFORMANCE REPORT OF " & BandedGridView1.GetFocusedRowCellValue("Account Officer").ToString
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class