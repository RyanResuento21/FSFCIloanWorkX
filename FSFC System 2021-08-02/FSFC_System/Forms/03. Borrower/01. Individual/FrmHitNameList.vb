Public Class FrmHitNameList

    Private Sub FrmHitNameList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            TriggerBugReport("Hit Name List - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim SQL As String = "SELECT ID,"
        SQL &= "  BorrowerID,"
        SQL &= "  FirstN_B,"
        SQL &= "  MiddleN_B,"
        SQL &= "  LastN_B,"
        SQL &= "  Suffix_B,"
        SQL &= "  DATE_FORMAT(Birth_B,'%b %d, %Y') AS 'Birth Date',"
        SQL &= "  PlaceBirth_B,"
        SQL &= "  TIN_B"
        SQL &= " FROM profile_borrower "
        With FrmBorrower
            SQL &= String.Format(" WHERE ((FirstN_B LIKE '%{0}%' AND LastN_B LIKE '%{1}%') OR (Birth_B LIKE '%{2}%' AND LastN_B LIKE '%{1}%') OR (PlaceBirth_B = '{3}' AND LastN_B LIKE '%{1}%')) AND `status` = 'ACTIVE';", .TxtFirstN_B.Text, .TxtLastN_B.Text, FormatDatePicker(.DtpBirth_B), If(.cbxPlaceBirth_B.Text = "", "FALSE", .cbxPlaceBirth_B.Text))
        End With

        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("PlaceBirth_B").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("PlaceBirth_B").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn8.Width = 290 - 17
        Else
            GridColumn8.Width = 290
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