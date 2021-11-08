Public Class FrmSOAList

    Private Sub FrmSOA_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            TriggerBugReport("SOA List - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT "
        SQL &= "    ID,"
        SQL &= "    `Name`,"
        SQL &= "    CONCAT(`Account`, '-', AccountNumber) AS 'Account Number', AccountNumber,"
        SQL &= "    Collateral,"
        SQL &= "    Principal AS 'Principal',"
        SQL &= "    DATE_FORMAT(Availed,'%b %d, %Y') AS 'Availed Date' "
        SQL &= " FROM"
        SQL &= "    soa_setup "
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Name` ;", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn4.Width = 545 - 17
        Else
            GridColumn4.Width = 545
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

        FrmSOA.iAccount_2.Text = GridView1.GetFocusedRowCellValue("AccountNumber")
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub
End Class