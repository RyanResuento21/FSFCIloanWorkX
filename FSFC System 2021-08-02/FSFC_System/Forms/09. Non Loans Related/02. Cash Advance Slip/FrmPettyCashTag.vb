Public Class FrmPettyCashTag

    Public AccountNumber As String
    Public PayeeID As Integer
    Public Amount As Double
    Private Sub FrmPettyCashTag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = "SELECT ID, AccountNumber, DATE_FORMAT(Trans_Date,'%M %d, %Y') AS 'Date', Purpose, Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12 AS 'Total Amount' "
        SQL &= String.Format("  FROM petty_cash WHERE Payee_Type = 'E' AND Payee_ID = '{0}' AND `status` = 'ACTIVE' ORDER BY AccountNumber DESC; ", PayeeID)
        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn3.Width = 340 - 17
        Else
            GridColumn3.Width = 340
        End If

        If GridView1.RowCount = 0 Then
            MsgBox("No petty cash to tag this cash advance", MsgBoxStyle.Information, "Info")
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
            TriggerBugReport("Petty Cash Tag - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Petty Cash Tag", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim PettyCashAmount As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Total Amount"))
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

        If MsgBoxYes(String.Format("Are you sure you want to tag the cash advance {0} to petty cash {1} as liquidation?", AccountNumber, GridView1.GetFocusedRowCellValue("AccountNumber"))) = MsgBoxResult.Yes Then
            Dim SQL As String = String.Format(" UPDATE cash_advance SET Liquidated = 'Y' WHERE AccountNumber = '{0}';", AccountNumber)
            SQL &= String.Format(" UPDATE petty_cash SET Payee_Type = 'C', Payee = CONCAT(Payee, '[', '{0}' ,']'), CANumber = '{0}' WHERE ID = '{1}';", AccountNumber, GridView1.GetFocusedRowCellValue("ID"))
            DataObject(SQL)
            Logs("Petty Cash Tag", "Liquidate", String.Format("Tag Cash Advance {0} to Petty Cash {1} as liquidation.", AccountNumber, GridView1.GetFocusedRowCellValue("AccountNumber")), "", "", "", "")
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