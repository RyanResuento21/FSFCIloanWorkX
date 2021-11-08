Public Class FrmLedgerApproved

    Public Reference As String
    Public Transaction As String
    Public Amount As String
    Public AssetNumber As String
    Public LedgerCode As String
    Public Remarks As String
    Public SellingP As Double
    Public MultipleA As Boolean
    Public TransactioNo As String

    Public Type As String
    Private Sub FrmLedger_Approved_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        lblTransaction.Text = Transaction
        lblAssetNumber.Text = AssetNumber
        lblReferenceNo.Text = Reference
        lblAmount.Text = Amount

        dtpDate.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, lblTransaction, LabelX4, lblAssetNumber, LabelX14, LabelX16, LabelX8, lblReferenceNo, LabelX6, lblAmount})

            GetDateTimeInputFontSettings({dtpDate})

            GetRickTextBoxFontSettings({txtRemarks})

            GetButtonFontSettings({btnApproved, btnDisapproved, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Ledger Approved - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        If MsgBoxYes("Are you sure you want to approve this transaction?") = MsgBoxResult.Yes Then
            Dim SQL As String = "UPDATE ledger_ropoa SET approve_status = 'APPROVED',"
            SQL &= String.Format("    approved_by_code = '{0}',", User_Code)
            SQL &= String.Format("    approved_by = '{0}',", Empl_Name)
            SQL &= String.Format("    approved_date = '{0}',", Format(dtpDate.Value, "yyyy-MM-dd HH:mm:ss"))
            SQL &= String.Format("    approved_remarks = '{0}'", txtRemarks.Text)
            SQL &= String.Format(" WHERE ledger_code = '{0}';", LedgerCode)
            If AssetNumber.Contains("V") Then
                If Transaction = "Transportation Equipment" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'RECLASSIFIED', reserve_reason = '{1}' WHERE AssetNumber = '{0}'", AssetNumber, Remarks))
                ElseIf Transaction = "Reverse Reclassification" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE AssetNumber = '{0}'", AssetNumber))
                End If
            Else
                If Transaction = "Land" Then
                    DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'RECLASSIFIED', reserve_reason = '{1}' WHERE AssetNumber = '{0}'", AssetNumber, Remarks))
                ElseIf Transaction = "Reverse Reclassification" Then
                    DataObject(String.Format("UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE AssetNumber = '{0}'", AssetNumber))
                End If
            End If
            If Transaction = "Discount" Then
                If MultipleA Then
                    SQL &= String.Format("UPDATE sold_ropoa SET Amount = '{1}' WHERE transaction_no = '{0}' AND `status` = 'ACTIVE';", TransactioNo, SellingP - CDbl(lblAmount.Text))
                Else
                    SQL &= String.Format("UPDATE sold_ropoa SET Amount = '{1}' WHERE asset_no = '{0}' AND `status` = 'ACTIVE';", AssetNumber, SellingP - CDbl(lblAmount.Text))
                End If
            End If
            If Transaction.ToUpper = "Impairment Loss".ToUpper And Type = "Deduct" And lblAssetNumber.Text.Contains("V") Then
                Dim ROPOA_Ref As String = DataObject(String.Format("SELECT PlateNum FROM ropoa_vehicle WHERE AssetNumber = '{0}';", AssetNumber))
                If CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber))) - CDbl(lblAmount.Text) <= 0 Then
                    If MsgBoxYes("This transaction will set the ROPOA to scrap for the reason that the book value will be zero. Would you like to proceed?") = MsgBoxResult.Yes Then
                        SQL &= String.Format("UPDATE ropoa_vehicle SET price = 0, sell_status = 'SCRAP' WHERE PlateNum = '{0}';", ROPOA_Ref)
                    Else
                        Exit Sub
                    End If
                End If
            End If

            DataObject(SQL)
            If Transaction.ToUpper = "Impairment Loss".ToUpper And Type = "Deduct" And lblAssetNumber.Text.Contains("V") Then
                If CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber))) - CDbl(lblAmount.Text) <= 0 Then
                    FrmVehicleROPOA.LoadData()
                    FrmVehicleROPOA.LoadScrap()
                End If
            End If
            If AssetNumber.Contains("V") And Transaction = "Discount" Then
                FrmVehicleROPOA.LoadReserved()
            ElseIf AssetNumber.Contains("R") And Transaction = "Discount" Then
                FrmRealEstateROPOA.LoadReserved()
            End If
            Logs("Ledger Approve", "Approve", "Approved Transaction", String.Format("Approved ledger transaction {0} with reference {1} for ropoa {2}", Transaction, Reference, AssetNumber), "", "", "")
            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub BtnDisapproved_Click(sender As Object, e As EventArgs) Handles btnDisapproved.Click
        If MsgBoxYes("Are you sure you want to disapprove this transaction?") = MsgBoxResult.Yes Then
            Dim SQL As String = "UPDATE ledger_ropoa SET approve_status = 'DISAPPROVED',"
            SQL &= String.Format("    approved_by_code = '{0}',", User_Code)
            SQL &= String.Format("    approved_by = '{0}',", Empl_Name)
            SQL &= String.Format("    approved_date = '{0}',", Format(dtpDate.Value, "yyyy-MM-dd HH:mm:ss"))
            SQL &= String.Format("    approved_remarks = '{0}'", txtRemarks.Text)
            SQL &= String.Format(" WHERE ledger_code = '{0}'", LedgerCode)
            DataObject(SQL)
            Logs("Ledger Approve", "Disapprove", "Disapproved Transaction", String.Format("Disapproved ledger transaction {0} with reference {1} for ropoa {2}", Transaction, Reference, AssetNumber), "", "", "")
            MsgBox("Successfully Disapproved!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnApproved.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub FrmLedger_Approved_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.A Then
            btnApproved.Focus()
            btnApproved.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDisapproved.Focus()
            btnDisapproved.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class