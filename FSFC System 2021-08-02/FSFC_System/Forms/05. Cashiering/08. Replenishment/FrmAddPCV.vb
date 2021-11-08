Public Class FrmAddPCV

    Public ExcludeID As String
    Private Sub FrmAddPCV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = "SELECT * FROM ( SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_1) AS 'Particulars',"
        SQL &= "    Amount_1 AS 'Amount', 1 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_2) AS 'Particulars',"
        SQL &= "    Amount_2 AS 'Amount', 2 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_3) AS 'Particulars',"
        SQL &= "    Amount_3 AS 'Amount', 3 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_4) AS 'Particulars',"
        SQL &= "    Amount_4 AS 'Amount', 4 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_5) AS 'Particulars',"
        SQL &= "    Amount_5 AS 'Amount', 5 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_6) AS 'Particulars',"
        SQL &= "    Amount_6 AS 'Amount', 6 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_7) AS 'Particulars',"
        SQL &= "    Amount_7 AS 'Amount', 7 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_8) AS 'Particulars',"
        SQL &= "    Amount_8 AS 'Amount', 8 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_9) AS 'Particulars',"
        SQL &= "    Amount_9 AS 'Amount', 9 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_10) AS 'Particulars',"
        SQL &= "    Amount_10 AS 'Amount', 10 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_11) AS 'Particulars',"
        SQL &= "    Amount_11 AS 'Amount', 11 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}'", Branch_ID)

        SQL &= " UNION ALL SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(Trans_Date, '%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Document Number',"
        SQL &= "    CONCAT(TRIM(Payee),'/',Particular_12) AS 'Particulars',"
        SQL &= "    Amount_12 AS 'Amount', 12 AS 'Sort'"
        SQL &= " FROM petty_cash WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED'"
        SQL &= String.Format("    AND ReplenishedID = 0 AND Branch_ID = '{0}') A WHERE Amount > 0 AND `Document Number` NOT IN ({1}) ORDER BY `Document Number`, `Sort`", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
        GridControl2.DataSource = DataSource(SQL)
        If GridView2.RowCount > 0 Then
            btnAdd.Enabled = True
        End If

        If GridView2.RowCount > 9 Then
            GridColumn19.Width = 760 - 17
        Else
            GridColumn19.Width = 760
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add PCV - FixUI", ex.Message.ToString)
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
            If MsgBox("Are you sure you want to add this collection?", MsgBoxStyle.YesNo, "Info") Then
                btnAdd.DialogResult = DialogResult.OK
                btnAdd.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        btnAdd.PerformClick()
    End Sub
End Class