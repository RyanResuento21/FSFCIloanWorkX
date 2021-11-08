Public Class FrmEarlySettlement
    Public From_Payment As Boolean
    Public Terms As Integer
    Public UDI As Double
    Public From_DeductBalance As Boolean
    Public UDI_Percent As Double
    Public Updated As Boolean
    Public LR As Double
    Public AsOf As Date
    Public Availed As Boolean
    Public BalanceRPPD As Double
    Public MF As Boolean
    Public CreditNumber As String
    Private Sub FrmEarlySettlement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_DeductBalance Then
            btnEarly.PerformClick()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettingsDefaultSize({LabelX81, LabelX88, LabelX2, LabelX3, LabelX4})

            GetIntegerInputFontSettingsDefault({iTerm})

            GetDoubleInputFontSettingsDefault({dLR, dRPPD, dUDI, dTP})

            GetButtonFontSettings({btnEarly, btnCancel, btnEarlySettlementList})
        Catch ex As Exception
            TriggerBugReport("Early Settlement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub DLR_ValueChanged(sender As Object, e As EventArgs) Handles dLR.ValueChanged
        dTP.Value = dLR.Value - (dRPPD.Value + dUDI.Value)
    End Sub

    Private Sub DRPPD_ValueChanged(sender As Object, e As EventArgs) Handles dRPPD.ValueChanged
        dTP.Value = dLR.Value - (dRPPD.Value + dUDI.Value)
    End Sub

    Private Sub DUDI_ValueChanged(sender As Object, e As EventArgs) Handles dUDI.ValueChanged
        dTP.Value = dLR.Value - (dRPPD.Value + dUDI.Value)
    End Sub

    Private Sub FrmEarlySettlement_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub ITerm_ValueChanged(sender As Object, e As EventArgs) Handles iTerm.ValueChanged
        Try
            If From_Payment Then
                If Updated Then
                    dLR.Value = LR
                Else
                    dLR.Value = LR
                End If

                'GIBALIK LANG SA NAKU KAY ANG KANI SA KARAAN PARA SA BOHOL KAY ANG BAG.O PARA SA TACLOBAN FOR DISCUSS PA UNSAON PAG COMPUTE JUD ANG RPPD
                dRPPD.Value = CDbl(GridView3.GetRowCellValue(iTerm.Value - 1, "Total_RPPD")) + If(DateValue(AsOf) <= If(iTerm.Value - 1 > 0, DateValue(GridView3.GetRowCellValue(iTerm.Value - 1, "Due Date")), DateValue(GridView3.GetRowCellValue(iTerm.Value, "Due Date"))), CDbl(If(iTerm.Value > 1, GridView3.GetRowCellValue(iTerm.Value - 1, "RPPD"), 0)), 0)
                If dRPPD.Value > BalanceRPPD Then
                    dRPPD.Value = BalanceRPPD
                End If
                Dim Factor As Double
                Dim Remaining As Double = Terms - iTerm.Value
                'Remaining = Terms
                Factor = Terms * (Terms + 1)
                dUDI.Value = UDI * FormatNumber(((Remaining * (Remaining + 1)) / Factor), 4)
                UDI_Percent = FormatNumber(((Remaining * (Remaining + 1)) / Factor), 4) * 100
                If MF Then
                    UDI_Percent = 100
                    Dim RPPD_Remaining As Double
                    Dim UDI_Remaining As Double
                    For x As Integer = (GridView3.RowCount - 2) - Remaining To GridView3.RowCount - 2
                        RPPD_Remaining += If(IsNumeric(GridView3.GetRowCellValue(x, "RPPD")), GridView3.GetRowCellValue(x, "RPPD"), 0)
                        UDI_Remaining += If(IsNumeric(GridView3.GetRowCellValue(x, "Interest Income")), GridView3.GetRowCellValue(x, "Interest Income"), 0)
                    Next
                    If UDI_Remaining > UDI Then
                        dUDI.Value = UDI
                    Else
                        dUDI.Value = UDI_Remaining
                    End If
                    If RPPD_Remaining > dRPPD.Value Then
                    Else
                        dRPPD.Value = RPPD_Remaining
                    End If
                End If
            Else
                Dim Factor As Double
                Dim Remaining As Double
                With FrmLoanApplication
                    dLR.Value = .GridView3.GetRowCellValue(iTerm.Value - 1, "Loans Receivable")
                    dRPPD.Value = .GridView3.GetRowCellValue(iTerm.Value - 1, "Total_RPPD")
                    Remaining = .iTerms.Value - iTerm.Value
                    Factor = .iTerms.Value * (.iTerms.Value + 1)
                End With
                dUDI.Value = FrmLoanApplication.dUDI_C.Value * FormatNumber(((Remaining * (Remaining + 1)) / Factor), 4)
                UDI_Percent = FormatNumber(((Remaining * (Remaining + 1)) / Factor), 4) * 100
                If MF Then
                    UDI_Percent = 100
                    Dim RPPD_Remaining As Double
                    Dim UDI_Remaining As Double
                    For x As Integer = (GridView3.RowCount - 2) - Remaining To GridView3.RowCount - 2
                        RPPD_Remaining += If(IsNumeric(GridView3.GetRowCellValue(x, "RPPD")), GridView3.GetRowCellValue(x, "RPPD"), 0)
                        UDI_Remaining += If(IsNumeric(GridView3.GetRowCellValue(x, "Interest Income")), GridView3.GetRowCellValue(x, "Interest Income"), 0)
                    Next
                    If UDI_Remaining > UDI Then
                        dUDI.Value = UDI
                    Else
                        dUDI.Value = UDI_Remaining
                    End If
                    If RPPD_Remaining > dRPPD.Value Then
                    Else
                        dRPPD.Value = RPPD_Remaining
                    End If
                End If
            End If
            dUDI.Value = FormatNumber(dUDI.Value, 0)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnEarly_Click(sender As Object, e As EventArgs) Handles btnEarly.Click
        If iTerm.Value = 0 Then
            MsgBox("Please check the terms field.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim OR_WithDTSNoJV As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') FROM official_receipt WHERE DTS = 1 AND DTS_JVNumber = '' AND Payee_ID = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        If OR_WithDTSNoJV <> "" Then
            MsgBox(String.Format("Account still have DTS OR of {0} that is not yet reversed using the Journal Voucher, early settlement might result in a different computation.", OR_WithDTSNoJV), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnEarly.DialogResult = DialogResult.OK Then
        Else
            If From_DeductBalance Then
                'PARA DLI NA MU ASK OF QUESTION ANG MESSAGEBOX
                btnEarly.DialogResult = DialogResult.OK
                btnEarly.PerformClick()
            Else
                If MsgBox("Are you sure you want to early settlement this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    If From_Payment Then

                    Else
                        With FrmSOA
                            .cbxRebate.Checked = True
                            .dtpRebate.Value = DateValue(FrmLoanApplication.GridView3.GetRowCellValue(iTerm.Value - 1, "Due Date"))
                            .dRebate.Value = dRPPD.Value + dUDI.Value

                            Dim Factor As Double
                            Dim Remaining As Double = FrmLoanApplication.iTerms.Value - iTerm.Value
                            Factor = FrmLoanApplication.iTerms.Value * (FrmLoanApplication.iTerms.Value + 1)
                            .UDI_Amount = FormatNumber(((Remaining * (Remaining + 1)) / Factor), 4)
                            .UDI_Amount = .UDI_Amount * 100
                        End With
                    End If
                    btnEarly.DialogResult = DialogResult.OK
                    btnEarly.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub BtnEarlySettlementList_Click(sender As Object, e As EventArgs) Handles btnEarlySettlementList.Click
        Dim List As New FrmEarlySettlementList
        With List
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim History As New FrmEarlySettlementHistory
        With History
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class