Public Class FrmReferredBorrowers

    Public AgentID As String
    Public Agent As String
    Public From_Agent As Boolean
    Private Sub FrmReferredBorrowers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Dim SQL As String = "SELECT ID,"
        SQL &= "   IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Borrower',"
        SQL &= "   CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'Account Number',"
        SQL &= "   FORMAT(AmountApplied, 2) AS 'Amount Applied',"
        SQL &= "   Terms,"
        SQL &= "   Product,"
        SQL &= "   FORMAT(Face_Amount,2) AS 'Face Amount' "
        If From_Agent Then
            SQL &= String.Format(" FROM credit_application WHERE AgentID = '{0}' AND Branch_ID IN ({1}) AND `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED');", AgentID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL &= String.Format(" FROM credit_application WHERE DealerID = '{0}' AND Branch_ID IN ({1}) AND `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED');", AgentID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 18 Then
            GridColumn2.Width = 276 - 17
        Else
            GridColumn2.Width = 276
        End If
        With GridView1
            .Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Amount Applied").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Amount Applied").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Face Amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Referred Borrowers - FixUI", ex.Message.ToString)
        End Try
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting(String.Format("List of Referred Borrowers of {0}", Agent), GridControl1)
    End Sub
End Class