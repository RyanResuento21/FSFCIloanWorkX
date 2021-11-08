Public Class FrmTransactionLogsPerForm

    Public Form As String
    Public Sub_Form As String
    Private Sub FrmTransactionLogsPerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            GetLabelHeaderFontSettings({lblTitle})
        Catch ex As Exception
            TriggerBugReport("Transaction Log Per Form - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    Button,"
        SQL &= "    Reason,"
        If Sub_Form = "" Then
            SQL &= "    Changes,"
        Else
            SQL &= "    CONCAT('[',Form,'] ', Changes) AS 'Changes',"
        End If
        SQL &= "    DATE_FORMAT(DATE(`Timestamp`),'%M %d, %Y') AS 'Date',"
        SQL &= "    TIME_FORMAT(TIME(`Timestamp`),'%r') AS 'Time',"
        SQL &= "    Computer,"
        SQL &= "    ip_address  AS 'IP Address',"
        SQL &= "    Username,"
        SQL &= "    Employee,"
        SQL &= "    Branch"
        SQL &= " FROM transaction_logs"
        SQL &= String.Format("    WHERE Branch_ID IN ({0}) AND Form IN ('{1}','{2}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), Form, Sub_Form)
        SQL &= " ORDER BY `timestamp` DESC"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Changes").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Changes").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn5.Width = 339 - 17
        Else
            GridColumn5.Width = 339
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FrmTransactionLogs_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class