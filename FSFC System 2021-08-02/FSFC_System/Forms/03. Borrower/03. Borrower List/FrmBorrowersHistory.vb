Imports DevExpress.XtraCharts
Public Class FrmBorrowersHistory

    Public BorrowerID As String
    Dim Borrower_DT As DataTable
    Dim iCompN As Integer
    Dim iIncN As Integer

    Dim iPendingN As Integer
    Dim iApprovedN As Integer
    Dim iDisapprovedN As Integer

    Dim iForRelease As Integer
    Dim iOngoing As Integer
    Dim iClosed As Integer
    Public SameBranch As Boolean
    Public Corporate As Boolean
    Private Sub FrmBorrowersHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FixPictureEdit(pb_B, 255, 256, 6, 7, False)
        c1.Location = New Point(843, 38)
        c1.Size = New Point(312, 291)
        pFaceAmount.Location = New Point(569, 202)
        pFaceAmount.Size = New Point(268, 127)
        pb_B.Location = New Point(6, 7)
        pb_B.Size = New Point(273, 322)

        If Corporate Then
            Borrower_DT = DataSource(String.Format("SELECT TradeName FROM profile_corporation WHERE BorrowerID = '{0}'", BorrowerID))
            Try
                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                With TempPB
                    .Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Borrower_DT(0)("branch_code"), BorrowerID, "Borrower.jpg"))
                    ResizeImages(.Image.Clone, FrmBorrower.pb_B, 650, 500)
                    .Dispose()
                End With
            Catch ex As Exception
            End Try
            LabelX43.Text = "Trade Name :"
            With TxtFirstN_B
                .Location = New Point(415, 7)
                .Size = New Point(740, 23)
                .Text = Borrower_DT(0)("TradeName")
            End With

            CbxPrefix_B.Visible = False
            TxtMiddleN_B.Visible = False
            TxtLastN_B.Visible = False
            cbxSuffix_B.Visible = False
        Else
            Borrower_DT = DataSource(String.Format("SELECT Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B FROM profile_borrower WHERE BorrowerID = '{0}'", BorrowerID))
            Try
                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                With TempPB
                    .Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Borrower_DT(0)("branch_code"), BorrowerID, "Borrower.jpg"))
                    ResizeImages(.Image.Clone, FrmBorrower.pb_B, 650, 500)
                    .Dispose()
                End With
            Catch ex As Exception
            End Try

            CbxPrefix_B.Text = Borrower_DT(0)("Prefix_B")
            TxtFirstN_B.Text = Borrower_DT(0)("FirstN_B")
            TxtMiddleN_B.Text = Borrower_DT(0)("MiddleN_B")
            TxtLastN_B.Text = Borrower_DT(0)("LastN_B")
            cbxSuffix_B.Text = Borrower_DT(0)("Suffix_B")
        End If

        Dim SQL As String = "SELECT"
        SQL &= String.Format("    COUNT(CASE WHEN is_complete = 'YES' THEN D.ID END) AS 'Complete',", BorrowerID)
        SQL &= String.Format("    COUNT(CASE WHEN is_complete = 'NO' THEN D.ID END) AS 'Incomplete',", BorrowerID)
        SQL &= "    COUNT(CASE WHEN C.application_status = 'PENDING' THEN C.ID END) AS 'Pending',"
        SQL &= "    COUNT(CASE WHEN C.application_status = 'APPROVED' THEN C.ID END) AS 'Approved',"
        SQL &= "    COUNT(CASE WHEN C.application_status = 'DISAPPROVED' THEN C.ID END) AS 'Disapproved',"
        SQL &= "    COUNT(CASE WHEN C.PaymentRequest = 'APPROVED REQUEST' THEN C.ID END) AS 'For Release',"
        SQL &= "    COUNT(CASE WHEN C.PaymentRequest = 'RELEASED' THEN C.ID END) AS 'Ongoing',"
        SQL &= "    COUNT(CASE WHEN C.PaymentRequest = 'CLOSED' THEN C.ID END) AS 'Closed'"
        SQL &= String.Format(" FROM credit_application C LEFT JOIN (SELECT ID, is_complete, BorrowerID FROM submit_documents WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}') D ON D.BorrowerID = C.BorrowerID", BorrowerID)
        SQL &= String.Format("    WHERE C.`status` = 'ACTIVE' AND C.BorrowerID = '{0}';", BorrowerID)

        Dim History As DataTable = DataSource(SQL)
        If History.Rows.Count > 0 Then
            '***Submitted Requirements
            iCompN = History(0)("Complete")
            iIncN = History(0)("Incomplete")

            lblCompN.Text = FormatNumber(iCompN, 0)
            lblIncN.Text = FormatNumber(iIncN, 0)

            lblCompP.Text = FormatNumber((iCompN / (iCompN + iIncN)) * 100, 2) & " %"
            lblIncP.Text = FormatNumber((iIncN / (iCompN + iIncN)) * 100, 2) & " %"

            '***Total Number of Application
            iPendingN = History(0)("Pending")
            iApprovedN = History(0)("Approved")
            iDisapprovedN = History(0)("Disapproved")

            lblPendingN.Text = FormatNumber(iPendingN, 0)
            lblApprovedN.Text = FormatNumber(iApprovedN, 0)
            lblDisapprovedN.Text = FormatNumber(iDisapprovedN, 0)

            lblPendingP.Text = FormatNumber((iPendingN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"
            lblApprovedP.Text = FormatNumber((iApprovedN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"
            lblDisapprovedP.Text = FormatNumber((iDisapprovedN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"

            '***Total Number of Accounts
            iForRelease = History(0)("For Release")
            iOngoing = History(0)("Ongoing")
            iClosed = History(0)("Closed")

            lblForReleaseN.Text = FormatNumber(iForRelease, 0)
            lblOngoingN.Text = FormatNumber(iOngoing, 0)
            lblClosedN.Text = FormatNumber(iClosed, 0)

            lblForReleaseP.Text = FormatNumber((iForRelease / (iForRelease + iOngoing + iClosed)) * 100, 2) & " %"
            lblOngoingP.Text = FormatNumber((iOngoing / (iForRelease + iOngoing + iClosed)) * 100, 2) & " %"
            lblClosedP.Text = FormatNumber((iClosed / (iForRelease + iOngoing + iClosed)) * 100, 2) & " %"
        End If

        SQL = "SELECT "
        SQL &= "    C.ID,"
        SQL &= "    C.Product,"
        SQL &= "    C.AccountNumber AS 'Account Number',"
        SQL &= "    DATE_FORMAT(Released,'%M %d, %Y') AS 'Date Granted',"
        SQL &= "    C.Terms,"
        SQL &= "    CONCAT(FORMAT(C.Interest_Rate, 2), '%') AS 'Interest',"
        If SameBranch Then
            SQL &= "    FORMAT(C.AmountApplied, 2) AS 'Principal',"
            SQL &= "    FORMAT(C.Net_Proceeds, 2) AS 'Net Proceeds',"
            SQL &= "    FORMAT(C.GMA, 2) AS 'GMA',"
        Else
            SQL &= "    '-' AS 'Principal',"
            SQL &= "    '-' AS 'Net Proceeds',"
            SQL &= "    '-' AS 'GMA',"
        End If
        SQL &= "    IFNULL((SELECT GROUP_CONCAT(Collateral) FROM credit_investigation WHERE credit_investigation.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE'),'') AS 'Collateral',"
        SQL &= "    C.CI AS 'CI',"
        SQL &= "    IF(PaymentRequest = 'CLOSED','CLOSED','ONGOING') AS 'Account Status',"
        SQL &= "    LastAccountStatus AS 'Account Remedial',"
        SQL &= "    Branch(Branch_ID) AS 'Branch'"
        SQL &= String.Format("  FROM credit_application C WHERE `status` = 'ACTIVE' AND C.BorrowerID = '{0}'; ", BorrowerID)
        GridControl1.DataSource = DataSource(SQL)

        If SameBranch Then
            pFaceAmount.Text = DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Face_Amount),0),2) FROM credit_application WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND Application_Status = 'APPROVED' AND PaymentRequest IN ('CLOSED','RELEASED');", BorrowerID))
        Else
            pFaceAmount.Text = "-"
        End If

        PieChartPayment(c1)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX43, LabelX2, LabelX14, LabelX13, LabelX26, LabelX25, LabelX11, LabelX10, LabelX6, LabelX16, LabelX15, LabelX15, lblPendingN, lblApprovedN, lblDisapprovedN, lblPendingP, lblApprovedP, lblDisapprovedP, LabelX29, LabelX28, LabelX5, lblForReleaseN, lblOngoingN, lblClosedN, lblForReleaseP, lblOngoingP, lblClosedP, LabelX17, LabelX12, lblCompN, lblIncN, lblCompP, lblIncP})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B})

            GetButtonFontSettings({btnCancel})

            GetGroupControlFontSettings({gApplication, gAccounts, gRequirements})

            GetLabelFontSettingsDashboardTitle({LabelX155})

            GetLabelFontSettingsDashboardPanel({pFaceAmount})
        Catch ex As Exception
            TriggerBugReport("Borrower History - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose1) = MsgBoxResult.Yes Then
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub PieChartPayment(Chart As ChartControl)
        Dim Payment As New DataTable
        Dim DT As DataTable = DataSource(String.Format("SELECT FORMAT(IFNULL(SUM((CASE WHEN EntryType = 'DEBIT' THEN Amount END)),0),2) AS 'DEBIT', FORMAT(IFNULL(SUM((CASE WHEN EntryType = 'CREDIT' THEN Amount END)),0),2) AS 'CREDIT' FROM accounting_entry LEFT JOIN (SELECT BorrowerID, CreditNumber FROM credit_application WHERE BorrowerID = '{0}') B ON B.CreditNumber = accounting_entry.ReferenceN WHERE `status` = 'ACTIVE' AND MotherCode = '111000' AND BorrowerID = '{0}';", BorrowerID))
        Dim V_Payments As Double
        Dim V_Payables As Double
        If DT.Rows.Count > 0 Then
            V_Payments = DT(0)("DEBIT")
            V_Payables = DT(0)("CREDIT")
        End If
        V_Payables = NegativeNotAllowed(V_Payables - V_Payments)

        With Payment
            .Columns.Add("Payments")
            .Columns.Add("Payable")
            .Rows.Add("Payments", V_Payments)
            .Rows.Add("Payable", V_Payables)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Payments vs Payables", ViewType.Pie)

            For x As Integer = 0 To Payment.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Payment(x)("Payments"), Payment(x)("Payable")))
            Next

            ' Add the series to the chart.
            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Borrower History - PieChartPayment", ex.Message.ToString)
        End Try
    End Sub
End Class