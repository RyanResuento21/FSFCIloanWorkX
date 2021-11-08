Imports DevExpress.XtraReports.UI
Public Class FrmMonatorium

    Dim DT_Temp As New DataTable
    Public Original_Amortization As New DataTable
    Public CreditNumber As String
    Public Daily As Boolean
    Public Weekly As Boolean
    Public Bimonthly As Boolean
    Public Borrower As String
    Dim Trigger_Send As Integer
    Dim Code As String

    Public From_Showmoney As Boolean
    Public InterestRate As Double
    Dim DT_Details As New DataTable
    Private Sub FrmMonatorium_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Code = GenerateOTAC()
        GridColumn15.VisibleIndex = 0
        GridColumn16.VisibleIndex = 1
        GridColumn17.VisibleIndex = 2
        GridColumn18.VisibleIndex = 3
        GridColumn19.VisibleIndex = 4
        GridColumn20.VisibleIndex = 5
        GridColumn21.VisibleIndex = 6
        GridColumn23.VisibleIndex = 7
        GridColumn22.VisibleIndex = 8
        GridColumn24.VisibleIndex = 9
        DT_Details = DataSource(String.Format("SELECT FORMAT(AmountApplied,2) AS 'Amount Applied', Terms, TermType, Product, Collateral, Purpose, DATE_FORMAT(trans_date,'%M %d, %Y') AS 'Date' FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))

        If lblTitle.Text = "TERM EXTENSION" Then
            btnDelete.Visible = True
        End If

        With dtpStart
            .Value = CDate(Original_Amortization(1)("Due Date"))
            .MinDate = CDate(Original_Amortization(1)("Due Date"))
            .MaxDate = CDate(Original_Amortization(Original_Amortization.Rows.Count - 2)("Due Date"))
            If .Value > CDate(Original_Amortization(Original_Amortization.Rows.Count - 2)("Due Date")) Then
                .Value = CDate(Original_Amortization(Original_Amortization.Rows.Count - 2)("Due Date"))
            End If
        End With
        LoadAmortization()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX81, LabelX47, LabelX9, LabelX2})

            GetIntegerInputFontSettings({iTerms_C})

            GetComboBoxWinFormFontSettings({cbxType})

            GetDateTimeInputFontSettings({dtpStart})

            GetButtonFontSettings({btnSave, btnCancel, btnPrint, btnResend, btnDelete})
        Catch ex As Exception
            TriggerBugReport("Moratorium - FixUI", ex.Message.ToString)
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
        OpenFormHistory(lblTitle.Text, lblTitle.Text)
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
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub ITerms_C_ValueChanged(sender As Object, e As EventArgs) Handles iTerms_C.ValueChanged
        If iTerms_C.Value > 3 Then
            If MsgBoxYes(String.Format("Max terms allowed for {0} is up to 3 terms ONLY, would you like to proceed?", lblTitle.Text.ToLower)) = MsgBoxResult.Yes Then
                LoadAmortization()
            End If
        Else
            LoadAmortization()
        End If
    End Sub

    Private Sub LoadAmortization()
        Cursor = Cursors.WaitCursor
        Try
            DT_Temp = Original_Amortization.Copy
            DT_Temp.Rows.Clear()
            Dim Rows_Added As Integer = 0
            If Bimonthly Then 'BIMONTHLY ***************************************************************************************************
                For x As Integer = 0 To Original_Amortization.Rows.Count - 1
                    If x = 0 Or x = Original_Amortization.Rows.Count - 1 Then
                        DT_Temp.Rows.Add(Original_Amortization(x)("No"), Original_Amortization(x)("Due Date"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                    Else
                        If dtpStart.Value.Month <= CDate(Original_Amortization(x)("Due Date")).Month And dtpStart.Value.Year <= CDate(Original_Amortization(x)("Due Date")).Year And Rows_Added = 0 Then
                            For y As Integer = 0 To iTerms_C.Value - 1
                                DT_Temp.Rows.Add(x + (Rows_Added * 2), Format(dtpStart.Value.AddMonths(Rows_Added), "MM.15.yyyy"), 0.0, 0.0, 0.0, 0.0, Original_Amortization(x - 1)("Outstanding Principal"), Original_Amortization(x - 1)("Total_RPPD"), Original_Amortization(x - 1)("Unearn Income"), Original_Amortization(x - 1)("Loans Receivable"))
                                If Bimonthly Then
                                    DT_Temp.Rows.Add(x + (Rows_Added * 2) + 1, Format(dtpStart.Value.AddMonths(Rows_Added), String.Format("MM.{0}.yyyy", Date.DaysInMonth(Format(dtpStart.Value.AddMonths(Rows_Added), "yyyy"), Format(dtpStart.Value.AddMonths(Rows_Added), "MM")))), 0, 0, 0, 0, Original_Amortization(x - 1)("Outstanding Principal"), Original_Amortization(x - 1)("Total_RPPD"), Original_Amortization(x - 1)("Unearn Income"), Original_Amortization(x - 1)("Loans Receivable"))
                                End If
                                Rows_Added = y + 1
                            Next
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + (Rows_Added * 2), Format(CDate(Original_Amortization(x)("Due Date")).AddMonths(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        Else
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + (Rows_Added * 2), Format(CDate(Original_Amortization(x)("Due Date")).AddMonths(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        End If
                    End If
                Next
            ElseIf Daily Then 'DAILY ***************************************************************************************************
                For x As Integer = 0 To Original_Amortization.Rows.Count - 1
                    If x = 0 Or x = Original_Amortization.Rows.Count - 1 Then
                        DT_Temp.Rows.Add(Original_Amortization(x)("No"), Original_Amortization(x)("Due Date"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                    Else
                        If dtpStart.Value.Month <= CDate(Original_Amortization(x)("Due Date")).Month And dtpStart.Value.Year <= CDate(Original_Amortization(x)("Due Date")).Year And Rows_Added = 0 Then
                            For y As Integer = 0 To iTerms_C.Value - 1
                                DT_Temp.Rows.Add(x + y, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(y), "MM.dd.yyyy"), 0.0, 0.0, 0.0, 0.0, Original_Amortization(x - 1)("Outstanding Principal"), Original_Amortization(x - 1)("Total_RPPD"), Original_Amortization(x - 1)("Unearn Income"), Original_Amortization(x - 1)("Loans Receivable"))
                                Rows_Added = y + 1
                            Next
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        Else
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        End If
                    End If
                Next
            ElseIf Weekly Then 'Weekly ***************************************************************************************************
                For x As Integer = 0 To Original_Amortization.Rows.Count - 1
                    If x = 0 Or x = Original_Amortization.Rows.Count - 1 Then
                        DT_Temp.Rows.Add(Original_Amortization(x)("No"), Original_Amortization(x)("Due Date"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                    Else
                        If dtpStart.Value.Month <= CDate(Original_Amortization(x)("Due Date")).Month And dtpStart.Value.Year <= CDate(Original_Amortization(x)("Due Date")).Year And Rows_Added = 0 Then
                            For y As Integer = 0 To iTerms_C.Value - 1
                                DT_Temp.Rows.Add(x + y, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(y * 7), "MM.dd.yyyy"), 0.0, 0.0, 0.0, 0.0, Original_Amortization(x - 1)("Outstanding Principal"), Original_Amortization(x - 1)("Total_RPPD"), Original_Amortization(x - 1)("Unearn Income"), Original_Amortization(x - 1)("Loans Receivable"))
                                Rows_Added = y + 1
                            Next
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(Rows_Added * 7), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        Else
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddDays(Rows_Added * 7), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        End If
                    End If
                Next
            Else 'MONTHLY *****************************************************************************************************************
                For x As Integer = 0 To Original_Amortization.Rows.Count - 1
                    If x = 0 Or x = Original_Amortization.Rows.Count - 1 Then
                        DT_Temp.Rows.Add(Original_Amortization(x)("No"), Original_Amortization(x)("Due Date"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                    Else
                        If dtpStart.Value.Month <= CDate(Original_Amortization(x)("Due Date")).Month And dtpStart.Value.Year <= CDate(Original_Amortization(x)("Due Date")).Year And Rows_Added = 0 Then
                            For y As Integer = 0 To iTerms_C.Value - 1
                                DT_Temp.Rows.Add(x + y, Format(CDate(Original_Amortization(x)("Due Date")).AddMonths(y), "MM.dd.yyyy"), 0.0, 0.0, 0.0, 0.0, Original_Amortization(x - 1)("Outstanding Principal"), Original_Amortization(x - 1)("Total_RPPD"), Original_Amortization(x - 1)("Unearn Income"), Original_Amortization(x - 1)("Loans Receivable"))
                                Rows_Added = y + 1
                            Next
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddMonths(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        Else
                            DT_Temp.Rows.Add(Original_Amortization(x)("No") + Rows_Added, Format(CDate(Original_Amortization(x)("Due Date")).AddMonths(Rows_Added), "MM.dd.yyyy"), Original_Amortization(x)("Monthly"), Original_Amortization(x)("Interest Income"), Original_Amortization(x)("RPPD"), Original_Amortization(x)("Principal Allocation"), Original_Amortization(x)("Outstanding Principal"), Original_Amortization(x)("Total_RPPD"), Original_Amortization(x)("Unearn Income"), Original_Amortization(x)("Loans Receivable"))
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            TriggerBugReport("Moratorium - LoadAmortization", ex.Message.ToString)
        End Try

        If GridView1.RowCount > 22 Then
            GridColumn16.Width = 92
        Else
            GridColumn16.Width = 109
        End If
        GridControl1.DataSource = DT_Temp.Copy
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        LoadAmortization()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            If Trigger_Send = 0 Then
                SendOTAC()
                Trigger_Send = 1
                btnResend.Enabled = True
            End If
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                Else
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End With
            Dim SQL As String = " UPDATE credit_application SET "
            If Bimonthly Then
                SQL &= String.Format(" Terms = {0},", (GridView1.RowCount - 2) / 2)
            Else
                SQL &= String.Format(" Terms = {0},", GridView1.RowCount - 2)
            End If
            SQL &= String.Format(" LDD = '{0}'", Format(CDate(GridView1.GetRowCellValue(GridView1.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
            SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)

            SQL &= String.Format("UPDATE credit_schedule SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", CreditNumber)
            For x As Integer = 0 To GridView1.RowCount - 2
                If GridView1.GetRowCellValue(x, "No") = "" Then
                    SQL &= " INSERT INTO credit_schedule SET"
                    SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                    SQL &= String.Format(" `No` = '{0}', ", GridView1.GetRowCellValue(x, "No"))
                    SQL &= String.Format(" DueDate = '{0}', ", "")
                    SQL &= String.Format(" Monthly = '{0}', ", 0)
                    SQL &= String.Format(" InterestIncome = '{0}', ", 0)
                    SQL &= String.Format(" RPPD = '{0}', ", 0)
                    SQL &= String.Format(" PrincipalAllocation = '{0}', ", 0)
                    SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")))
                    SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")))
                    SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unearn Income")))
                    SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView1.GetRowCellValue(x, "Loans Receivable")))
                Else
                    SQL &= " INSERT INTO credit_schedule SET"
                    SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                    SQL &= String.Format(" `No` = '{0}', ", GridView1.GetRowCellValue(x, "No"))
                    SQL &= String.Format(" DueDate = '{0}', ", Format(DateValue(GridView1.GetRowCellValue(x, "Due Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Monthly = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Monthly")))
                    SQL &= String.Format(" InterestIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Interest Income")))
                    SQL &= String.Format(" RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD")))
                    SQL &= String.Format(" PrincipalAllocation = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")))
                    SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")))
                    SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")))
                    SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unearn Income")))
                    SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView1.GetRowCellValue(x, "Loans Receivable")))
                End If
            Next
            DataObject(SQL)
            Logs(lblTitle.Text, "Save", String.Format("Add {1} for Credit Number {0}.", CreditNumber, lblTitle.Text.ToLower), "", "", "", CreditNumber)
            Cursor = Cursors.Default
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            btnSave.DialogResult = DialogResult.OK
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub BtnResend_Click(sender As Object, e As EventArgs) Handles btnResend.Click
        If MsgBox("Are you sure you want to RESEND the OTAC?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            SendOTAC()
            MsgBox("Successfully Resend!" & mEmail, MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub SendOTAC()
        '********* SEND OTAC TO APPROVER FOR MORATORIUM ************************************************************
        Dim Msg As String = ""
        Dim FName_Original As String
        Dim FName_New As String
        Dim EmailTo As String = ""
        Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
        Dim BM As DataTable = GetBM(Branch_ID)
        For x As Integer = 0 To BM.Rows.Count - 1
            Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the {2} of the Account of {1}." & vbCrLf, Code, Borrower, If(lblTitle.Text = "TERM EXTENSION", If(btnDelete.Visible And btnDelete.Enabled = False, "Cancellation of Term Extension", "Term Extension"), "Moratorium"))
            Msg &= "Thank you!"
            '******* SEND SMS *********************************************************************************
            If BM(x)("Phone") = "" Then
            Else
                SendSMS(BM(x)("Phone"), Msg.Replace("<br>", " "), True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If BM(x)("EmailAdd") = "" Then
            Else
                EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
            End If
        Next
        If EmailTo = "" Then
        Else
            AttachmentFiles = New ArrayList()
            FName_Original = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Borrower & "[" & CreditNumber & "] Original Amortization-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            Print_Original(False, FName_Original)
            AttachmentFiles.Add(FName_Original)
            FName_New = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & Borrower & "[" & CreditNumber & "] New Amortization-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            Print_New(False, FName_New)
            AttachmentFiles.Add(FName_New)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
        End If
        '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Cursor = Cursors.WaitCursor
        Try
            DT_Temp = Original_Amortization.Copy
Here:
            For x As Integer = 1 To DT_Temp.Rows.Count - 1
                If CDbl(DT_Temp(x)("Monthly")) = 0 Then
                    DT_Temp.Rows.RemoveAt(x)
                    GoTo Here
                End If
            Next
            For x As Integer = 1 To DT_Temp.Rows.Count - 2
                DT_Temp(x)("No") = x
            Next
            iTerms_C.Enabled = False
            dtpStart.Enabled = False
            btnDelete.Enabled = False
        Catch ex As Exception
            TriggerBugReport("Moratorium - Delete", ex.Message.ToString)
        End Try

        If GridView1.RowCount > 22 Then
            GridColumn16.Width = 92
        Else
            GridColumn16.Width = 109
        End If
        GridControl1.DataSource = DT_Temp.Copy
        Cursor = Cursors.Default
    End Sub

    Private Sub Print_Original(Show As Boolean, FName As String)
        Dim Report As New RptAmortizationSchedule
        With Report
            .Name = "Amortization Scheduling"
            .lblAmountApplied.Text = DT_Details(0)("Amount Applied")
            .lblTerms.Text = DT_Details(0)("Terms") & " " & DT_Details(0)("TermType")
            .lblProduct.Text = DT_Details(0)("Product") & " [" & DT_Details(0)("Collateral") & "]"
            .lblPurpose.Text = DT_Details(0)("Purpose")
            .lblDate.Text = DT_Details(0)("Date")

            .DataSource = Original_Amortization
            .lblNo.DataBindings.Add("Text", Original_Amortization, "No")
            .lblDue.DataBindings.Add("Text", Original_Amortization, "Due Date")
            .lblMonthly.DataBindings.Add("Text", Original_Amortization, "Monthly")
            .lblInterest.DataBindings.Add("Text", Original_Amortization, "Interest Income")
            .lblRPPD.DataBindings.Add("Text", Original_Amortization, "RPPD")
            .lblPrincipal.DataBindings.Add("Text", Original_Amortization, "Principal Allocation")
            .lblOutstanding.DataBindings.Add("Text", Original_Amortization, "Outstanding Principal")
            .lblUnearn.DataBindings.Add("Text", Original_Amortization, "Unearn Income")
            .lblRPPD_2.DataBindings.Add("Text", Original_Amortization, "Total_RPPD")
            .lblLoansReceivable.DataBindings.Add("Text", Original_Amortization, "Loans Receivable")
            If CompanyMode = 0 Then
                .XrLabel15.Text = "Interest"
                .XrLabel11.Visible = False
                .XrLabel14.Visible = False

                .lblRPPD.Visible = False
                .lblRPPD_2.Visible = False

                .XrLabel9.SizeF = New SizeF(115 + 45, 30)
                .XrLabel10.SizeF = New SizeF(115 + 35, 30)
                .XrLabel12.SizeF = New SizeF(115 + 35, 30)
                .XrLabel13.SizeF = New SizeF(115 + 35, 30)
                .XrLabel15.SizeF = New SizeF(115 + 35, 30)
                .XrLabel16.SizeF = New SizeF(115 + 45, 30)

                .XrLabel10.Location = New Point(130 + 160, 135)
                .XrLabel12.Location = New Point(130 + 310, 135)
                .XrLabel13.Location = New Point(130 + 460, 135)
                .XrLabel15.Location = New Point(130 + 610, 135)
                .XrLabel16.Location = New Point(130 + 760, 135)

                .lblMonthly.SizeF = New SizeF(115 + 45, 30)
                .lblInterest.SizeF = New SizeF(115 + 35, 30)
                .lblPrincipal.SizeF = New SizeF(115 + 35, 30)
                .lblOutstanding.SizeF = New SizeF(115 + 35, 30)
                .lblUnearn.SizeF = New SizeF(115 + 35, 30)
                .lblLoansReceivable.SizeF = New SizeF(115 + 45, 30)

                .lblInterest.Location = New Point(130 + 160, 0)
                .lblPrincipal.Location = New Point(130 + 310, 0)
                .lblOutstanding.Location = New Point(130 + 460, 0)
                .lblUnearn.Location = New Point(130 + 610, 0)
                .lblLoansReceivable.Location = New Point(130 + 760, 0)
            End If
            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
    End Sub

    Private Sub Print_New(Show As Boolean, FName As String)
        Dim Report As New RptAmortizationSchedule
        With Report
            .Name = "Amortization Scheduling"
            .lblAmountApplied.Text = DT_Details(0)("Amount Applied")
            .lblTerms.Text = DT_Details(0)("Terms") & " " & DT_Details(0)("TermType")
            .lblProduct.Text = DT_Details(0)("Product") & " [" & DT_Details(0)("Collateral") & "]"
            .lblPurpose.Text = DT_Details(0)("Purpose")
            .lblDate.Text = DT_Details(0)("Date")

            .DataSource = GridControl1.DataSource
            .lblNo.DataBindings.Add("Text", GridControl1.DataSource, "No")
            .lblDue.DataBindings.Add("Text", GridControl1.DataSource, "Due Date")
            .lblMonthly.DataBindings.Add("Text", GridControl1.DataSource, "Monthly")
            .lblInterest.DataBindings.Add("Text", GridControl1.DataSource, "Interest Income")
            .lblRPPD.DataBindings.Add("Text", GridControl1.DataSource, "RPPD")
            .lblPrincipal.DataBindings.Add("Text", GridControl1.DataSource, "Principal Allocation")
            .lblOutstanding.DataBindings.Add("Text", GridControl1.DataSource, "Outstanding Principal")
            .lblUnearn.DataBindings.Add("Text", GridControl1.DataSource, "Unearn Income")
            .lblRPPD_2.DataBindings.Add("Text", GridControl1.DataSource, "Total_RPPD")
            .lblLoansReceivable.DataBindings.Add("Text", GridControl1.DataSource, "Loans Receivable")
            If CompanyMode = 0 Then
                .XrLabel15.Text = "Interest"
                .XrLabel11.Visible = False
                .XrLabel14.Visible = False

                .lblRPPD.Visible = False
                .lblRPPD_2.Visible = False

                .XrLabel9.SizeF = New SizeF(115 + 45, 30)
                .XrLabel10.SizeF = New SizeF(115 + 35, 30)
                .XrLabel12.SizeF = New SizeF(115 + 35, 30)
                .XrLabel13.SizeF = New SizeF(115 + 35, 30)
                .XrLabel15.SizeF = New SizeF(115 + 35, 30)
                .XrLabel16.SizeF = New SizeF(115 + 45, 30)

                .XrLabel10.Location = New Point(130 + 160, 135)
                .XrLabel12.Location = New Point(130 + 310, 135)
                .XrLabel13.Location = New Point(130 + 460, 135)
                .XrLabel15.Location = New Point(130 + 610, 135)
                .XrLabel16.Location = New Point(130 + 760, 135)

                .lblMonthly.SizeF = New SizeF(115 + 45, 30)
                .lblInterest.SizeF = New SizeF(115 + 35, 30)
                .lblPrincipal.SizeF = New SizeF(115 + 35, 30)
                .lblOutstanding.SizeF = New SizeF(115 + 35, 30)
                .lblUnearn.SizeF = New SizeF(115 + 35, 30)
                .lblLoansReceivable.SizeF = New SizeF(115 + 45, 30)

                .lblInterest.Location = New Point(130 + 160, 0)
                .lblPrincipal.Location = New Point(130 + 310, 0)
                .lblOutstanding.Location = New Point(130 + 460, 0)
                .lblUnearn.Location = New Point(130 + 610, 0)
                .lblLoansReceivable.Location = New Point(130 + 760, 0)
            End If
            If Show Then
                Logs(lblTitle.Text, "Print", "[SENSITIVE] Print " & lblTitle.Text & " for " & CreditNumber, "", "", "", "")
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        Print_New(True, "")
        Cursor = Cursors.Default
    End Sub
End Class