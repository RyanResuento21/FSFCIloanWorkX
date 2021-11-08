Public Class FrmEarlySettlementHistory

    Private Sub FrmEarlySettlementHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = String.Format("SELECT Borrower_Credit(CreditNumber) AS 'Borrower', AccountNumber(CreditNumber) AS 'Account Number', LR, UDI_Discount, AvailedRPPD, AR, Penalty, DATE_FORMAT(AsOF, '%M %d, %Y') AS 'As Of', `Status`, early_status, ORNumber FROM credit_earlysettlement WHERE BranchID = {0} ORDER BY AsOf DESC ", Branch_ID)

        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 27 Then
            GridColumn1.Width = 175 - 17
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnCancel})
        Catch ex As Exception
            TriggerBugReport("Early Settlement History - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmResetBranchHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class