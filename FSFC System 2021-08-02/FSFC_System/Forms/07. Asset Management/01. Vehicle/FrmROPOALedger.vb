Public Class FrmROPOALedger

    ReadOnly LedgerCode As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public AssetNumber As String
    Public ROPOA_Status As String
    Public MultipleA As Boolean
    Public ROPOA_Ref As String
    Private Sub FrmROPOA_Ledger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadData()

        If GridView2.RowCount <= 1 And MultipleA Then
            btnDelete.Visible = True
        Else
            btnDelete.Visible = False
        End If

        Dim Sold_Price As Double
        If GridView2.RowCount > 1 Then
            Sold_Price = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", AssetNumber))
            If Sold_Price > 0 Then
                If AssetNumber.Contains("ANV") Then
                    DataObject(String.Format(" UPDATE ropoa_vehicle SET sell_status = '{1}' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE' AND sell_status IN ('SOLD','RESERVED');", ROPOA_Ref, If(CDbl(GridView2.GetRowCellValue(GridView2.RowCount - 1, "Running Balance")) = 0, "SOLD", If(CDbl(GridView2.GetRowCellValue(GridView2.RowCount - 1, "Running Balance")) * 0.8 <= Sold_Price, "SOLD", "RESERVED"))))
                Else
                    DataObject(String.Format(" UPDATE ropoa_realestate SET sell_status = '{1}' WHERE TCT = '{0}' AND `status` = 'ACTIVE' AND sell_status IN ('SOLD','RESERVED');", ROPOA_Ref, If(CDbl(GridView2.GetRowCellValue(GridView2.RowCount - 1, "Running Balance")) = 0, "SOLD", If(CDbl(GridView2.GetRowCellValue(GridView2.RowCount - 1, "Running Balance")) * 0.8 <= Sold_Price, "SOLD", "RESERVED"))))
                End If
            End If
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

            GetButtonFontSettings({btnCancel, btnPrint, btnDelete})
        Catch ex As Exception
            TriggerBugReport("ROPA Ledger - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("ROPA Ledger", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        GridControl2.DataSource = ROPALedger(AssetNumber, True)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView2.OptionsPrint.UsePrintStyles = False
        StandardPrinting("ROPOA LEDGER", GridControl2)
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM accounting_entry WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID")))
            If GridView2.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this ledger from {1} to {0}?", GridView2.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                  DataObject(String.Format("UPDATE accounting_entry SET remarks = '{1}' WHERE ID = '{0}';", GridView2.GetFocusedRowCellValue("ID"), GridView2.GetFocusedRowCellValue("Remarks")))
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("Reference No.").ToString = "" Or GridView2.GetFocusedRowCellValue("Reference No.").ToString.Contains("ACR-") = False Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        'A C K N O W L E D G E M E N T    R E C E I P T ***************************************************************************************
        Dim ACR As New FrmAcknowledgement
        With ACR
            .Tag = 84
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Logs("ROPA Ledger", "Double Click", "Acknowledgement Receipt", "", "", "", "")
            .From_GL = True
            .GL_DocumentNumber = GridView2.GetFocusedRowCellValue("Reference No.")
            If .ShowDialog = DialogResult.OK Then
            End If
            .Dispose()
        End With
        'A C K N O W L E D G E M E N T    R E C E I P T ***************************************************************************************
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String
            If AssetNumber.ToString.Contains("ANV") Then
                SQL = String.Format("UPDATE ropoa_vehicle SET `status` = 'DELETED' WHERE AssetNumber = '{0}';", AssetNumber)
                SQL &= String.Format("UPDATE ropoa_vehicle SET Account_Count = Account_Count - 1 WHERE PlateNum = '{0}';", ROPOA_Ref)
                Logs("ROPO Ledger", "Cancel", Reason, String.Format("Cancel ROPO Vehicle with Asset Number {0}", AssetNumber), "", "", "")
            Else
                SQL = String.Format("UPDATE ropoa_realestate SET `status` = 'DELETED' WHERE AssetNumber = '{0}';", AssetNumber)
                SQL &= String.Format("UPDATE ropoa_realestate SET Account_Count = Account_Count - 1 WHERE TCT = '{0}';", ROPOA_Ref)
                Logs("ROPO Ledger", "Cancel", Reason, String.Format("Cancel ROPO Real Estate with Asset Number {0}", AssetNumber), "", "", "")
            End If
            DataObject(SQL)
            LoadData()
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            btnDelete.DialogResult = DialogResult.OK
            btnDelete.PerformClick()
        End If
    End Sub
End Class