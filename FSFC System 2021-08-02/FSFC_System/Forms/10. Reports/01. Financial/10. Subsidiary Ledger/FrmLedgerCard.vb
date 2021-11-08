Imports DevExpress.XtraReports.UI
Imports word = Microsoft.Office.Interop.Word
Public Class FrmLedgerCard

    Public CreditNumber As String
    Public AccountNumber As String
    Public Product As String
    Public Borrower As String
    Public CreditBranchID As Integer
    Dim BranchAddress As String
    Dim BranchNumber As String
    Public vPrint As Boolean
    Dim DT_Borrower As DataTable
    Dim Payable As Double
    Private Sub FrmLedgerCard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        Dim SQL As String = "SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',  "
        SQL &= "    FORMAT(Face_Amount,2) AS 'Loan Granted', "
        SQL &= "    '' AS 'PickupWalkIn', "
        SQL &= "    '' AS 'CashCheck', "
        SQL &= "    FORMAT(Interest,2) AS 'Interest', "
        SQL &= "    DATE_FORMAT(Released,'%M %d, %Y') AS 'Date Granted', "
        SQL &= "    DATE_FORMAT(LDD,'%M %d, %Y') AS 'Maturity Date',"
        SQL &= "    TermType,"
        SQL &= "    0 AS 'No of Payment',"
        SQL &= "    Terms,"
        SQL &= "    '' AS 'Collection Day',"
        SQL &= "    Marketing AS 'AO',"
        SQL &= "    MarketingNo AS 'AO Number',"
        SQL &= "    CONCAT(Mobile_B, IF(Mobile_B2 = '','',CONCAT('/',Mobile_B2))) AS 'Client Number',"
        SQL &= "    FORMAT(AmountApplied / Terms,2) AS 'Principal',"
        SQL &= "    FORMAT(Interest / Terms,2) AS 'Interest Amourt',"
        SQL &= "    '' AS 'Loan Cycle'"
        SQL &= String.Format(" FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber)
        Dim DT_Details As DataTable = DataSource(SQL)

        Dim DT_BranchDetails As DataTable = DataSource(String.Format("SELECT Address, CONCAT(ContactN1,IF(ContactN2 = '','',CONCAT('/', ContactN2, IF(ContactN3 = '','',CONCAT('/', ContactN3))))) AS 'Contact' FROM branch WHERE ID = {0};", CreditBranchID))
        If DT_BranchDetails.Rows.Count > 0 Then
            BranchAddress = DT_BranchDetails(0)("Address")
            BranchNumber = DT_BranchDetails(0)("Contact")
        End If

        If DT_Details.Rows.Count > 0 Then
            lblClient.Text = Borrower
            lblAddress.Text = DT_Details(0)("Address")
            lblLoanGranted.Text = DT_Details(0)("Loan Granted")
            lblInterest.Text = DT_Details(0)("Interest")
            lblDateGranted.Text = DT_Details(0)("Date Granted")
            lblMaturityDate.Text = DT_Details(0)("Maturity Date")
            lblLoanTerms.Text = DT_Details(0)("Terms")
            lblAccountOfficer.Text = DT_Details(0)("AO")
            lblContactNumber.Text = DT_Details(0)("AO Number")
            lblPrincipal.Text = DT_Details(0)("Principal")
            lblInterestAmort.Text = DT_Details(0)("Interest Amourt")
            lblTOTAL.Text = FormatNumber(CDbl(DT_Details(0)("Principal")) + CDbl(DT_Details(0)("Interest Amourt")), 2)
            lblLoanCycle.Text = DT_Details(0)("Loan Cycle")
            lblAOContact.Text = DT_Details(0)("AO Number")

            If DT_Details(0)("PickupWalkIn") = "Pickup" Then
                cbxPickup.Checked = True
            ElseIf DT_Details(0)("PickupWalkIn") = "Walkin" Then
                cbxWalkIn.Checked = True
            End If

            If DT_Details(0)("CashCheck") = "Cash" Then
                cbxCash.Checked = True
            ElseIf DT_Details(0)("CashCheck") = "Check" Then
                cbxCheck.Checked = True
            End If

            If DT_Details(0)("Collection Day") = "Monday" Then
                cbxMon.Checked = True
            ElseIf DT_Details(0)("Collection Day") = "Tuesday" Then
                cbxTue.Checked = True
            ElseIf DT_Details(0)("Collection Day") = "Wednesday" Then
                cbxWed.Checked = True
            ElseIf DT_Details(0)("Collection Day") = "Thursday" Then
                cbxThu.Checked = True
            ElseIf DT_Details(0)("Collection Day") = "Friday" Then
                cbxFri.Checked = True
            End If

            If DT_Details(0)("TermType") = "Daily" Or DT_Details(0)("TermType") = "Day" Then
                cbxDaily.Checked = True
            ElseIf DT_Details(0)("TermType") = "Weekly" Or DT_Details(0)("TermType") = "Week" Then
                cbxWeekly.Checked = True
            ElseIf DT_Details(0)("TermType") = "Bimonthly" Then
                cbxBimonthly.Checked = True
            ElseIf DT_Details(0)("TermType") = "Monthly" Or DT_Details(0)("TermType") = "Month" Then
                cbxMonthly.Checked = True
            End If
        End If

        Dim SQLv2 As String = "SELECT ROW_NUMBER() OVER() AS 'No',"
        SQLv2 &= "   '' AS 'Sched Date',"
        SQLv2 &= "   DATE_FORMAT(DocumentDate, '%m.%d.%Y') AS 'Actual Payment Date',"
        SQLv2 &= "   Payable AS 'Loan Payment',"
        SQLv2 &= "   LedgerBalance AS 'Loan Balance',"
        SQLv2 &= "   D.UDI AS 'Interest Payment',"
        SQLv2 &= "   IFNULL((SELECT Interest FROM credit_application WHERE CreditNumber = Payee_ID),0) - D.UDI + TotalInterest AS 'Interest Balance',"
        SQLv2 &= "   D.Penalty AS 'Penalty',"
        SQLv2 &= "   IFNULL((SELECT PenaltyPayable FROM accounting_entry WHERE ReferenceN = Payee_ID AND ORNum = M.DocumentNumber AND PenaltyPayable > 0 AND JVNumber = ''),0) AS 'PDI',"
        SQLv2 &= "   '' AS 'No. of  Days Late',"
        SQLv2 &= "   Paid AS 'Total Amount Paid' "
        SQLv2 &= String.Format(" FROM official_receipt M LEFT JOIN (SELECT DocumentNumber, IFNULL(SUM(CASE WHEN PaidFor = 'Penalty' THEN Credit END),0) AS 'Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN Credit END),0) AS 'UDI', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN Credit END),0) AS 'Principal' FROM or_details WHERE `status` = 'ACTIVE' GROUP BY DocumentNumber) D ON M.DocumentNumber = D.DocumentNumber WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = '';", CreditNumber)
        GridControl1.DataSource = DataSource(SQLv2)
        lblNoPayments.Text = GridView1.RowCount
        If GridView1.RowCount > 10 Then
            GridColumn11.Width = 101 - 17
        Else
            GridColumn11.Width = 101
        End If

        SQL = "SELECT CONCAT(IF(Prefix_B = '',IF(Gender_B = 'Male','Mr',IF(Gender_B = 'Female' AND Civil_B = 'Single','Ms','Mrs')),Prefix_B), ' ', FirstN_B, ' ', LastN_B) AS 'Name', "
        SQL &= "    CONCAT(IF(Prefix_B = '',IF(Gender_B = 'Male','Mr',IF(Gender_B = 'Female' AND Civil_B = 'Single','Ms','Mrs')),Prefix_B), ' ', LastN_B) AS 'Last Name', "
        SQL &= "    CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), BarangayC_B) AS 'Address', "
        SQL &= "    IFNULL((SELECT citymunDesc FROM city_municipality WHERE citymunCode = `AddressC_B-ID`),'') AS 'City', "
        SQL &= "    IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = CreditNumber AND `status` = 'ACTIVE' AND JVNumber = ''),'Release Date') AS 'Last Payment', "
        SQL &= "    FirstNotice, Face_Amount, TermType "
        SQL &= String.Format(" FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber)
        DT_Borrower = DataSource(SQL)
        LoadAmortizationBasic(CreditNumber, GridControl3)
        Dim Dues As Object = GetPrincipalInterestDue(CreditNumber, DT_Borrower(0)("Face_Amount"), DT_Borrower(0)("TermType"), Date.Now, GridView3)
        Payable = CDec(Dues(0)) + CDec(Dues(1))
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX155, LabelX2, LabelX4, LabelX6, LabelX8, LabelX10, LabelX12, LabelX14, LabelX16, LabelX18, LabelX29, LabelX20, LabelX24, LabelX26, LabelX28, LabelX32, LabelX30, lblClient, lblAddress, lblLoanGranted, lblContactNumber, lblInterest, lblDateGranted, lblMaturityDate, lblNoPayments, lblLoanTerms, lblAccountOfficer, lblPrincipal, lblInterestAmort, lblTOTAL, lblLoanCycle, lblAOContact})

            GetLabelWithBackgroundFontSettings({LabelX22, LabelX21})

            GetCheckBoxFontSettings({cbxPickup, cbxCash, cbxWalkIn, cbxCheck, cbxDaily, cbxWeekly, cbxBimonthly, cbxMonthly, cbxMon, cbxTue, cbxWed, cbxThu, cbxFri})

            GetButtonFontSettings({btnPrint, btnDemandL, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Ledger Card - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblClient.MouseEnter
        lblClient.ForeColor = OfficialColor2
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblClient.MouseLeave
        lblClient.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblClient.Click
        OpenFormHistory("Ledger Card", lblClient.Text)
    End Sub

    Public Sub LoadAmortizationBasic(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        Dim T_Penalty As Double
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            T_Interest += CDbl(Temp_DT(x)("Interest Income"))
            T_RPPD += CDbl(Temp_DT(x)("RPPD"))
            T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
            T_Penalty += CDbl(Temp_DT(x)("Penalty"))
        Next
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, ), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), 0, 0, 0, 0, Format(T_Penalty, 2), 0)
        Grid.DataSource = Temp_DT
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Dim RightRow As Integer = 0
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If DateValue(Date.Now) >= DateValue(GridView3.GetRowCellValue(x, "Due Date")) Then
                    RightRow = x
                ElseIf x = GridView3.RowCount - 2 And DateValue(Date.Now) < DateValue(GridView3.GetRowCellValue(1, "Due Date")) Then
                    RightRow = 1
                End If
            End If
        Next
        If GridView3.FocusedRowHandle = RightRow Then
        Else
            GridView3.FocusedRowHandle = RightRow
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptLedgerCard
        With Report
            .Name = String.Format("Ledger Card of {0} [{1}]", lblClient.Text, AccountNumber)
            .lblCompanyAddress.Text = BranchAddress
            .lblCompanyNumber.Text = BranchNumber
            .lblProduct.Text = Product
            .lblName.Text = lblClient.Text
            .lblAddress.Text = lblAddress.Text
            .cbxPickup.Checked = cbxWalkIn.Checked
            .cbxWalkin.Checked = cbxCash.Checked
            .cbxCash.Checked = cbxCash.Checked
            .cbxCheck.Checked = cbxCheck.Checked
            .lblLoanGranted.Text = lblLoanGranted.Text
            .lblClientNumber.Text = lblContactNumber.Text
            .lblInterestAmount.Text = lblInterest.Text
            .lblDateGranted.Text = lblDateGranted.Text
            .lblMaturityDate.Text = lblMaturityDate.Text
            .cbxDaily.Checked = cbxDaily.Checked
            .cbxWeekly.Checked = cbxWeekly.Checked
            .cbxSemiMonthly.Checked = cbxBimonthly.Checked
            .cbxMonthly.Checked = cbxMonthly.Checked
            .lblNoOfPayments.Text = lblNoPayments.Text
            .lblLoanTerms.Text = lblLoanTerms.Text
            .cbxMon.Checked = cbxMon.Checked
            .cbxTue.Checked = cbxTue.Checked
            .cbxWed.Checked = cbxWed.Checked
            .cbxThu.Checked = cbxThu.Checked
            .cbxFri.Checked = cbxFri.Checked
            .lblAccountOfficer.Text = lblAccountOfficer.Text
            .lblAONumber.Text = lblAOContact.Text
            .lblPrincipal.Text = lblPrincipal.Text
            .lblInterest.Text = lblInterestAmort.Text
            .lblTotal.Text = lblTOTAL.Text
            .lblLoanCycle.Text = lblLoanCycle.Text

            .DataSource = GridControl1.DataSource
            .lblNo.DataBindings.Add("Text", GridControl1.DataSource, "No")
            .lblSchedDate.DataBindings.Add("Text", GridControl1.DataSource, "Sched Date")
            .lblActualPaymenDate.DataBindings.Add("Text", GridControl1.DataSource, "Actual Payment Date")
            .lblLoanPayment.DataBindings.Add("Text", GridControl1.DataSource, "Loan Payment")
            .lblLoanBalance.DataBindings.Add("Text", GridControl1.DataSource, "Interest Payment")
            .lblInterestPayment.DataBindings.Add("Text", GridControl1.DataSource, "Interest Balance")
            .lblPenalty.DataBindings.Add("Text", GridControl1.DataSource, "Penalty")
            .lblPDI.DataBindings.Add("Text", GridControl1.DataSource, "PDI")
            .lblNoOfDays.DataBindings.Add("Text", GridControl1.DataSource, "No. of  Days Late")
            .lblTotalAmountPaid.DataBindings.Add("Text", GridControl1.DataSource, "Total Amount Paid")
            Logs("Ledger Card", "Print", "[SENSITIVE] Print Ledger Card of " & lblClient.Text, "", "", "", "")

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDemandL_Click(sender As Object, e As EventArgs) Handles btnDemandL.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim xPath As String = Application.StartupPath & "\Documents\Microfinance\First Demand Letter.doc"
        Dim PathName As String = IO.Path.GetFileName(xPath)
        Dim File_Directory As String = String.Format("{0}\{1}\{2}\Documents\{3}", RootFolder, MainFolder, Branch_Code, "Demand Letter")
        If Not IO.Directory.Exists(File_Directory) Then
            IO.Directory.CreateDirectory(File_Directory)
        End If
        Dim FileName As String = String.Format("{0}\{1}", File_Directory, PathName)
        Dim DL As New FrmDemandLetter
        If DT_Borrower(0)("FirstNotice") = "" Then
            DL.cbx1st.Checked = True
            DL.cbx2nd.Enabled = False
            DataObject(String.Format("UPDATE credit_application SET FirstNotice = '{1}' WHERE CreditNumber = '{0}';", CreditNumber, Format(Date.Now, "yyyy-MM-dd")))
            DT_Borrower(0)("FirstNotice") = Date.Now
        Else
            DL.cbx2nd.Checked = True
        End If
        If DL.ShowDialog = DialogResult.OK Then
            If DL.cbx1st.Checked Then
                xPath = Application.StartupPath & "\Documents\Microfinance\First Demand Letter.doc"
            Else
                xPath = Application.StartupPath & "\Documents\Microfinance\Second Demand Letter.doc"
            End If

            FileName = (String.Format("{0}\{1}", File_Directory, PathName))
            For x As Integer = 2 To 1000
                If IO.File.Exists(FileName) Then
                    If DL.cbx1st.Checked Then
                        FileName = String.Format("{0}\First Demand Letter of {1} ({2}).doc", File_Directory, lblClient.Text, x)
                    Else
                        FileName = String.Format("{0}\Second Demand Letter of {1} ({2}).doc", File_Directory, lblClient.Text, x)
                    End If
                End If
            Next
            IO.File.Copy(xPath, FileName)

            Dim WordApp As New word.Application With {
                .Visible = False
            }
            Dim Doc As word.Document = WordApp.Documents.Open(FileName)
            Doc = WordApp.ActiveDocument
            With Doc
                'REPLACE
                .Content.Find.Execute(FindText:="@Date", ReplaceWith:=Format(Date.Now, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithPrefixName", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("Name")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithPrefixLastName", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("Last Name")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@WithoutCityAddress", ReplaceWith:=DT_Borrower(0)("Address"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@City", ReplaceWith:=UpperCaseFirst(DT_Borrower(0)("City")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Amount", ReplaceWith:=FormatNumber(Payable, 2), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@LastPayment", ReplaceWith:=If(DT_Borrower(0)("Last Payment") = "Release Date", DT_Borrower(0)("Last Payment"), Format(CDate(DT_Borrower(0)("Last Payment")), "MMMM dd, yyyy")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                If DL.cbx2nd.Checked = True Then
                    .Content.Find.Execute(FindText:="@FirstNoticeDate", ReplaceWith:=Format(CDate(DT_Borrower(0)("FirstNotice")), "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                End If
                .Save()
                .Close()
            End With
            Doc = Nothing
            WordApp.Quit()
            WordApp = Nothing
            Try
                Process.Start(FileName)
            Catch ex As Exception
                Try
                    Process.Start(FileName.Replace("\", "/"))
                Catch ex1 As Exception
                    Process.Start(FileName.Replace("/", "\"))
                End Try
            End Try
            Logs("Ledger Card", "Print", "[SENSITIVE] Print Demand Letter of " & lblClient.Text, "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub
End Class