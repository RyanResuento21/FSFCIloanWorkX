Public Class FrmAddCheckVoucher

    Public ExcludeID As String
    Private Sub FrmAddCheckVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        GetGridAppearance({GridView2})
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DATE_FORMAT(DocumentDate, '%M %d, %Y') AS 'Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    CONCAT((SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = check_voucher.BankID),'/', CheckNumber) AS 'Bank/Check Number',"
        SQL &= "    Payee AS 'Payor',"
        SQL &= "    Amount "
        SQL &= " FROM check_voucher WHERE `status` = 'ACTIVE' "
        SQL &= String.Format("    AND voucher_status IN ('RECEIVED','APPROVED','CHECKED','PENDING') AND ClearedDate = '' AND Payee_Type = 'RC' AND Branch_ID = '{0}' AND DocumentNumber NOT IN ({1});", Branch_ID, If(ExcludeID = "", 1, ExcludeID))
        GridControl2.DataSource = DataSource(SQL)
        If GridView2.RowCount > 0 Then
            btnAdd.Enabled = True
        End If

        If GridView2.RowCount > 9 Then
            GridColumn17.Width = 450 - 17
        Else
            GridColumn17.Width = 450
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
            TriggerBugReport("Add Check Voucher - FixUI", ex.Message.ToString)
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

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        btnAdd.PerformClick()
    End Sub
End Class