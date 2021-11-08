Public Class FrmAddCashCount

    Public From_PettyCash As Boolean
    Public ExcludeID As String
    Private Sub FrmAddCashCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        GetGridAppearance({GridView3})
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String
        If From_PettyCash Then
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
            SQL &= "    AccountNumber AS 'Document Number',"
            SQL &= "    CONCAT(TRIM(Payee),'/',CONCAT(Particular_1,IF(Particular_2 = '','',CONCAT(', ', Particular_2)),IF(Particular_3 = '','',CONCAT(', ', Particular_3)),IF(Particular_4 = '','',CONCAT(', ', Particular_4)),IF(Particular_5 = '','',CONCAT(', ', Particular_5)),IF(Particular_6 = '','',CONCAT(', ', Particular_6)),IF(Particular_7 = '','',CONCAT(', ', Particular_7)),IF(Particular_8 = '','',CONCAT(', ', Particular_8)),IF(Particular_9 = '','',CONCAT(', ', Particular_9)),IF(Particular_10 = '','',CONCAT(', ', Particular_10)),IF(Particular_11 = '','',CONCAT(', ', Particular_11)),IF(Particular_12 = '','',CONCAT(', ', Particular_12)))) AS 'Payee/Particular',"
            SQL &= "    (Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Amount' "
            SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE'  AND voucher_status = 'RECEIVED'"
            SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}' AND AccountNumber NOT IN ({1});", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
        Else
            SQL = "SELECT"
            SQL &= "    ID,"
            SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
            SQL &= "    AccountNumber AS 'Document Number',"
            SQL &= "    CONCAT(TRIM(Employee(Payee_ID)),'/', Purpose) AS 'Payee/Particular',"
            SQL &= "    (Meals + Transportation + BIR + RD + LTO + Notarization + Others) AS 'Amount' "
            SQL &= " FROM cash_advance WHERE `status` = 'ACTIVE' AND Slip_Status = 'RECEIVED' "
            SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000 AND IF(Liquidated = 'Y',IFNULL((SELECT ApprovedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0) = 0,Liquidated = 'N') AND AccountNumber NOT IN ({1});", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
        End If
        GridControl3.DataSource = DataSource(SQL)
        If GridView3.RowCount > 0 Then
            btnAdd.Enabled = True
        End If

        If GridView3.RowCount > 9 Then
            GridColumn19.Width = 741 - 17
        Else
            GridColumn19.Width = 741
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetButtonFontSettings({btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add Cash Count - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.DialogResult = DialogResult.OK Then
        Else
            If MsgBox("Are you sure you want to add this cash count?", MsgBoxStyle.YesNo, "Info") Then
                btnAdd.DialogResult = DialogResult.OK
                btnAdd.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        btnAdd.PerformClick()
    End Sub
End Class