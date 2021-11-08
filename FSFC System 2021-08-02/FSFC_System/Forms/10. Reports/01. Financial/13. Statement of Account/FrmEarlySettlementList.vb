Public Class FrmEarlySettlementList

    Private Sub FrmEarlySettlementList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
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
            GetLabelHeaderFontSettings({LabelX11})
        Catch ex As Exception
            TriggerBugReport("Early Settlement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT "
        SQL &= "  AccountNumber(CreditNumber) AS 'AccountNumber',"
        SQL &= "  CreditNumber,"
        SQL &= "  Borrower_Credit(CreditNumber) AS 'Borrower',"
        SQL &= "  LR,"
        SQL &= "  UDI_Discount,"
        SQL &= "  AvailedRPPD,"
        SQL &= "  AR,"
        SQL &= "  Penalty,"
        SQL &= "  DATE_FORMAT(AsOf, '%M %d, %Y') AS 'AsOf'"
        SQL &= " FROM credit_earlysettlement "
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND BranchID = '{0}' AND early_status = 'PENDING' ORDER BY `AsOf` DESC ;", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn9.Width = 245 - 17
        Else
            GridColumn9.Width = 245
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class