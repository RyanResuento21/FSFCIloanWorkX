Public Class FrmCheckVoucherTag

    Public AccountNumber As String
    Public PayeeID As Integer
    Public Amount As Double
    Public vBranchID As String

    Private Sub FrmCheckVoucherTag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = String.Format("SELECT ID, DocumentNumber, DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'DocumentDate', Explanation, Amount, ReceivedBy, ReceivedDate, Voucher_Status FROM check_voucher WHERE Payee_Type = 'E' AND Payee_ID = '{0}' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING','CHECKED','APPROVED','RECEIVED') ORDER BY DocumentNumber; ", PayeeID, vBranchID)
        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn3.Width = 340 - 17
        Else
            GridColumn3.Width = 340
        End If

        If GridView1.RowCount = 0 Then
            MsgBox("No check voucher to tag this cash advance", MsgBoxStyle.Information, "Info")
            Close()
        End If
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

            GetButtonFontSettings({btnLiquidate, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Check Voucher Tag - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Check Voucher Tag", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PettyCashAmount As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Amount"))
            If PettyCashAmount = Amount Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            Else
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Regular)
            End If
        End If
    End Sub

    Private Sub FrmPettyCashTag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnLiquidate.Focus()
            btnLiquidate.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnLiquidate_Click(sender As Object, e As EventArgs) Handles btnLiquidate.Click
        If btnLiquidate.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure you want to tag the cash advance {0} to check voucher {1}?", AccountNumber, GridView1.GetFocusedRowCellValue("DocumentNumber"))) = MsgBoxResult.Yes Then
            If Amount <> GridView1.GetFocusedRowCellValue("Amount") Then
                If MsgBoxYes(String.Format("Amount is not equal! Cash advance amount is P{0} and Check Voucher amount is P{1}, would you like to proceed?", FormatNumber(Amount, 2), FormatNumber(GridView1.GetFocusedRowCellValue("Amount")), 2)) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim SQL As String = String.Format(" UPDATE cash_advance SET CVNumber = '{1}', slip_status = IF('{2}' = 'RECEIVED','RECEIVED','APPROVED'), ReceivedID = IF('{2}' = 'RECEIVED',Payee_ID,0), ReceivedDate = '{3}' WHERE AccountNumber = '{0}';", AccountNumber, GridView1.GetFocusedRowCellValue("DocumentNumber"), GridView1.GetFocusedRowCellValue("Voucher_Status"), GridView1.GetFocusedRowCellValue("ReceivedDate"))
            SQL &= String.Format(" UPDATE check_voucher SET Payee_Type = 'A', Payee_ID = '{0}', Payee = CONCAT(Payee, ' [', '{0}' ,']') WHERE ID = '{1}';", AccountNumber, GridView1.GetFocusedRowCellValue("ID"))
            DataObject(SQL)
            Logs("Check Voucher Tag", "Tag", String.Format("Tag Cash Advance {0} to Check Voucher {1}.", AccountNumber, GridView1.GetFocusedRowCellValue("DocumentNumber")), "", "", "", "")
            MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
            btnLiquidate.DialogResult = DialogResult.OK
            btnLiquidate.PerformClick()
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        btnLiquidate.PerformClick()
    End Sub
End Class