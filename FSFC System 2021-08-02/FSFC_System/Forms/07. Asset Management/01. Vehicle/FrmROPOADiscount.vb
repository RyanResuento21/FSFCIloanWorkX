Public Class FrmROPOADiscount 

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public ROPOA_Type As String = "Vehicle"
    Public TotalImage As Integer
    Dim Trigger_D As Boolean = True
    Public TransactionNo As String
    Public MultipleA As Boolean
    Public ROPOA_Ref As String
    Private Sub FrmROPOA_Discount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        dDiscount.MaxValue = dBalance.Value
        dtpDate.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, LabelX2, lblMake, LabelX3, lblType, LabelX4, lblModel})

            GetLabelFontSettingsDefaultSize({LabelX15, LabelX5, LabelX9, LabelX13, LabelX6, LabelX11, LabelX10})

            GetLabelFontSettingsDefault({LabelX7, LabelX8})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtAssetNumber, txtMake, txtAccountName, txtType, txtModel, txtAccountNo})

            GetTextBoxFontSettingsDefault({txtRemarks})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B})

            GetDoubleInputFontSettingsDefault({dPrice, dSoldPrice, dDiscount, dDiscountP, dDiscounted, dROPOA_Value, dBalance})

            GetDateTimeInputFontSettingsDefault({dtpDate})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel, btnAttach})
        Catch ex As Exception
            TriggerBugReport("ROPA Discount - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("ROPOA Discount", lblTitle.Text)
    End Sub

    Private Sub FrmROPOA_Discount_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            dDiscount.Value = 0
            dtpDate.Value = Date.Now
            txtRemarks.Text = ""
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Purchase-" & txtAssetNumber.Text
            .TotalImage = TotalImage
            .AssetNumber = txtAssetNumber.Text
            .ID = txtAssetNumber.Text
            If ROPOA_Type = "Vehicle" Then
                .Type = "Purchase VE"
            Else
                .Type = "Purchase RE"
            End If

        End With
        Dim Result = Attach.ShowDialog
        If Result = DialogResult.OK Then
            TotalImage = Attach.TotalImage
            With FrmVehicleROPOA
                If ROPOA_Type = "Vehicle" Then
                    If .lblSold.Visible = True And .lblSold.Text = "SOLD" Then
                        .GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = True And .lblSold.Text = "SCRAP" Then
                        .GridView4.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = False Then
                        .GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                    End If
                Else
                    If .lblSold.Visible = True And .lblSold.Text = "SOLD" Then
                        FrmRealEstateROPOA.GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = False Then
                        FrmRealEstateROPOA.GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                    End If
                End If
            End With
        ElseIf Result = DialogResult.Yes Then
            TotalImage = Attach.TotalImage
            With FrmVehicleROPOA
                If ROPOA_Type = "Vehicle" Then
                    If .lblSold.Visible = True And .lblSold.Text = "SOLD" Then
                        .GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = True And .lblSold.Text = "SCRAP" Then
                        .GridView4.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = False Then
                        .GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                    End If
                Else
                    If .lblSold.Visible = True And .lblSold.Text = "SOLD" Then
                        FrmRealEstateROPOA.GridView3.SetFocusedRowCellValue("Attach", TotalImage)
                    ElseIf .lblSold.Visible = False Then
                        FrmRealEstateROPOA.GridView2.SetFocusedRowCellValue("Attach", TotalImage)
                    End If
                End If
            End With
        End If
        Attach.Dispose()
    End Sub

    Private Sub DDiscount_ValueChanged(sender As Object, e As EventArgs) Handles dDiscount.ValueChanged
        dDiscounted.Value = dSoldPrice.Value - dDiscount.Value
    End Sub

    Private Sub DDiscountP_ValueChanged(sender As Object, e As EventArgs) Handles dDiscountP.ValueChanged
        If Trigger_D Then
            dDiscount.Value = dSoldPrice.Value * (dDiscountP.Value / 100)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If dDiscount.Value = 0 Then
            MsgBox("Discount is zero, please check your data.", MsgBoxStyle.Information, "Info")
            dDiscount.Focus()
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to save this transaction?") = MsgBoxResult.Yes Then
            Dim LedgerCode As String
            Dim SQL_II As String
            If dROPOA_Value.Value > 0 Then
                LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                SQL_II = "INSERT INTO ledger_ropoa SET"
                SQL_II &= String.Format(" ropoa_type = '{0}', ", ROPOA_Type)
                SQL_II &= String.Format(" trans_date = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL_II &= " trans_id = '0', "
                SQL_II &= String.Format(" `reference_number` = '{0}', ", Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL_II &= " `transaction` = 'Discount', "
                SQL_II &= " `type` = '', "
                SQL_II &= String.Format(" Remarks = '{0}', ", txtRemarks.Text & String.Format("[{0}% worth {1} discount. Sold Price from {2} to {3}.]", dDiscountP.Value, dDiscount.Text, dSoldPrice.Text, dDiscounted.Text))
                SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                SQL_II &= String.Format(" ORNum = '{0}', ", Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL_II &= String.Format(" Sold_ID = '{0}', ", TransactionNo)
                SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(MultipleA, ROPOA_Ref, ""))
                SQL_II &= " approve_status = 'PENDING', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '',"
                'For multiple lain'2 og asset number
                If MultipleA Then
                    Dim DT As DataTable
                    If ROPOA_Type = "Vehicle" Then
                        DT = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',PlateNum FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", ROPOA_Ref))
                    Else
                        DT = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',TCT FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", ROPOA_Ref))
                    End If
                    Dim Distribute As New FrmAccountDistribute With {
                        .DT_Account = DT,
                        .Amount = dDiscount.Value
                    }
                    If ROPOA_Type = "Vehicle" Then
                        Distribute.Info = "[" & txtMake.Text & "][" & txtModel.Text & "][" & ROPOA_Ref & "]"
                    Else
                        Distribute.Info = "[" & ROPOA_Ref & "][" & txtType.Text & "][" & txtModel.Text & "]"
                    End If
                    If Distribute.ShowDialog = DialogResult.OK Then
                        For y As Integer = 0 To Distribute.DT_Account.Rows.Count - 1
                            For z As Integer = 0 To DT.Rows.Count - 1
                                If DT(z)("AccountNo") = Distribute.DT_Account(y)("AccountNo") Then
                                    DT(z)("Amount") = Distribute.DT_Account(y)("Amount")
                                End If
                            Next
                        Next
                    Else
                        For y As Integer = 0 To DT.Rows.Count - 1
                            DT(y)("Amount") = dDiscount.Value / DT.Rows.Count
                        Next
                    End If

                    Dim SQL_III As String
                    For y As Integer = 0 To DT.Rows.Count - 1
                        SQL_III = ""
                        SQL_III &= String.Format(" amount = '{0}', ", DT(y)("Amount"))
                        SQL_III &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                        SQL_III &= String.Format(" asset_number = '{0}';", DT(y)("AssetNumber"))
                      DataObject(SQL_II & SQL_III)
                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                    Next
                Else
                    SQL_II &= String.Format(" amount = '{0}', ", dDiscount.Value)
                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                    SQL_II &= String.Format(" asset_number = '{0}';", txtAssetNumber.Text)
                  DataObject(SQL_II)
                End If
            Else
                'IF ROPOA VALUE IS ZERO NA
                LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                SQL_II = "INSERT INTO ledger_ropoa SET"
                SQL_II &= String.Format(" ropoa_type = '{0}', ", ROPOA_Type)
                SQL_II &= String.Format(" trans_date = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                SQL_II &= " trans_id = '0', "
                SQL_II &= String.Format(" `reference_number` = '{0}', ", Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL_II &= " `transaction` = 'Discount', "
                SQL_II &= " `type` = '', "
                SQL_II &= String.Format(" Remarks = '{0}', ", txtRemarks.Text & String.Format("[{0}% worth {1} discount. Sold Price from {2} to {3}.]", dDiscountP.Value, dDiscount.Text, dSoldPrice.Text, dDiscounted.Text))
                SQL_II &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL_II &= String.Format(" user_code = '{0}', ", User_Code)
                SQL_II &= String.Format(" ORNum = '{0}', ", Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL_II &= String.Format(" Sold_ID = '{0}', ", TransactionNo)
                SQL_II &= String.Format(" ropoa_ref = '{0}', ", If(MultipleA, ROPOA_Ref, ""))
                SQL_II &= " approve_status = 'PENDING', approved_by_code = '', approved_by = '', approved_date = CURRENT_TIMESTAMP, approved_remarks = '',"
                'For multiple lain'2 og asset number
                If MultipleA Then
                    Dim DT As DataTable
                    If ROPOA_Type = "Vehicle" Then
                        DT = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',PlateNum FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND PlateNum = '{0}';", ROPOA_Ref))
                    Else
                        DT = DataSource(String.Format("SELECT AssetNumber,AccountNo,0.00 AS 'Amount',TCT FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND TCT = '{0}';", ROPOA_Ref))
                    End If
                    Dim Distribute As New FrmAccountDistribute With {
                        .DT_Account = DT,
                        .Amount = dDiscount.Value
                    }
                    If ROPOA_Type = "Vehicle" Then
                        Distribute.Info = "[" & txtMake.Text & "][" & txtModel.Text & "][" & ROPOA_Ref & "]"
                    Else
                        Distribute.Info = "[" & ROPOA_Ref & "][" & txtType.Text & "][" & txtModel.Text & "]"
                    End If
                    If Distribute.ShowDialog = DialogResult.OK Then
                        For y As Integer = 0 To Distribute.DT_Account.Rows.Count - 1
                            For z As Integer = 0 To DT.Rows.Count - 1
                                If DT(z)("AccountNo") = Distribute.DT_Account(y)("AccountNo") Then
                                    DT(z)("Amount") = Distribute.DT_Account(y)("Amount")
                                End If
                            Next
                        Next
                    Else
                        For y As Integer = 0 To DT.Rows.Count - 1
                            DT(y)("Amount") = dDiscount.Value / DT.Rows.Count
                        Next
                    End If

                    Dim SQL_III As String
                    For y As Integer = 0 To DT.Rows.Count - 1
                        SQL_III = ""
                        SQL_III &= String.Format(" amount = '{0}', ", DT(y)("Amount"))
                        SQL_III &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                        SQL_III &= String.Format(" asset_number = '{0}';", DT(y)("AssetNumber"))
                      DataObject(SQL_II & SQL_III)
                        LedgerCode = DataObject(String.Format("SELECT CONCAT('L', LPAD({0},3,'0'), '-', LPAD(COUNT(ID) + 1,8,'0')) FROM ledger_ropoa WHERE branch_id = '{0}'", Branch_ID))
                    Next
                Else
                    SQL_II &= String.Format(" amount = '{0}', ", dDiscount.Value)
                    SQL_II &= String.Format(" ledger_code = '{0}', ", LedgerCode)
                    SQL_II &= String.Format(" asset_number = '{0}';", txtAssetNumber.Text)
                  DataObject(SQL_II)
                End If
            End If

            Logs("ROPOA Discount", "Save", String.Format("Discount Request for ROPOA {0} [{1} | {2} | {3} | {4}].", ROPOA_Type, txtAssetNumber.Text, txtMake.Text, txtType.Text, txtModel.Text), "", "", "", "")
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub DDiscount_Leave(sender As Object, e As EventArgs) Handles dDiscount.Leave
        Trigger_D = False
        dDiscountP.Value = (dDiscount.Value / dSoldPrice.Value) * 100
        Trigger_D = True
    End Sub
End Class