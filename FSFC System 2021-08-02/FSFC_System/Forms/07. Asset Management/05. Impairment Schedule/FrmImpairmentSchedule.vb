Public Class FrmImpairmentSchedule

    Public Type As String = "VL"
    Private Sub FrmImpairmentSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        dtpFrom.Value = Date.Now
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, lblAssetN, LabelX5, lblPlateN, LabelX7, lblAccountN, LabelX15, LabelX36, LabelX2, lblCOS})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetDoubleInputFontSettings({dImpairment})

            GetIntegerInputFontSettings({iMonths})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Impairment Schedule - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Impairment Schedule", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            If MsgBoxYes("Closing the form would set the default for the ROPOA equally divided by the number of months. Would you like to continue?") = MsgBoxResult.Yes Then
                Dim SQL As String = String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE AssetNumber = '{0}' AND ReferenceN = '{1}' AND AccountN = '{2}' AND impairment_status = 'PENDING';", lblAssetN.Text, lblPlateN.Text, lblAccountN.Text)
                For x As Integer = 0 To GridView1.RowCount - 1
                    SQL &= "INSERT INTO tbl_impairment SET "
                    SQL &= String.Format("    AssetNumber = '{0}', ", lblAssetN.Text)
                    SQL &= String.Format("    ReferenceN = '{0}', ", lblPlateN.Text)
                    SQL &= String.Format("    AccountN = '{0}', ", lblAccountN.Text)
                    SQL &= String.Format("    Months = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Month")), "yyyy-MM-dd"))
                    SQL &= String.Format("    Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format("    user_code = '{0}', ", User_Code)
                    SQL &= String.Format("    branch_id = '{0}', ", Branch_ID)
                    If CDate(GridView1.GetRowCellValue(x, "Month")) <= Date.Now Then
                        SQL &= "              impairment_status = 'POSTED', "
                    End If
                    SQL &= String.Format("    `Type` = '{0}';", Type)
                Next
                DataObject(SQL)
                Logs("Impairment Schedule", "Save", String.Format("Schedule of ROPOA for Asset Number {0} from {1} to {2} with monthly amount {3}", lblAssetN.Text, Format(dtpFrom.Value, "MM.dd.yyyy"), Format(dtpTo.Value, "MM.dd.yyyy"), FormatNumber(dImpairment.Value / iMonths.Value, 2)), "", "", "", "")
                Close()
            End If
        End If
    End Sub

    Private Sub FrmImpairmentSchedule_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DImpairment_KeyDown(sender As Object, e As KeyEventArgs) Handles dImpairment.KeyDown
        If e.KeyCode = Keys.Enter Then
            iMonths.Focus()
        End If
    End Sub

    Private Sub IMonths_KeyDown(sender As Object, e As KeyEventArgs) Handles iMonths.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFrom.Focus()
        End If
    End Sub

    Private Sub DtpFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim SQL As String = String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE AssetNumber = '{0}' AND ReferenceN = '{1}' AND AccountN = '{2}' AND impairment_status = 'PENDING';", lblAssetN.Text, lblPlateN.Text, lblAccountN.Text)
                For x As Integer = 0 To GridView1.RowCount - 1
                    SQL &= "INSERT INTO tbl_impairment SET "
                    SQL &= String.Format("    AssetNumber = '{0}', ", lblAssetN.Text)
                    SQL &= String.Format("    ReferenceN = '{0}', ", lblPlateN.Text)
                    SQL &= String.Format("    AccountN = '{0}', ", lblAccountN.Text)
                    SQL &= String.Format("    Months = '{0}', ", Format(CDate(GridView1.GetRowCellValue(x, "Month")), "yyyy-MM-dd"))
                    SQL &= String.Format("    Amount = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format("    user_code = '{0}', ", User_Code)
                    SQL &= String.Format("    branch_id = '{0}', ", Branch_ID)
                    If CDate(GridView1.GetRowCellValue(x, "Month")) <= Date.Now Then
                        SQL &= "              impairment_status = 'POSTED', "
                    End If
                    SQL &= String.Format("    `Type` = '{0}';", Type)
                Next
                DataObject(SQL)
                Logs("Impairment Schedule", "Save", String.Format("Schedule of ROPOA for Asset Number {0} from {1} to {2} with monthly amount {3}", lblAssetN.Text, Format(dtpFrom.Value, "MM.dd.yyyy"), Format(dtpTo.Value, "MM.dd.yyyy"), FormatNumber(dImpairment.Value / iMonths.Value, 2)), "", "", "", "")
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub IMonths_ValueChanged(sender As Object, e As EventArgs) Handles iMonths.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddMonths(iMonths.Value)
        Compute()
    End Sub

    Private Sub DtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddMonths(iMonths.Value)
        Compute()
    End Sub

    Private Sub Compute()
        Dim DT As New DataTable
        With DT
            .Columns.Add("Month")
            .Columns.Add("Amount")
            For x As Integer = 0 To iMonths.Value - 1
                .Rows.Add(Format(dtpFrom.Value.AddMonths(x), "MMMM dd, yyyy"), FormatNumber(dImpairment.Value / iMonths.Value, 2))
            Next
        End With
        Dim Amount As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            Amount += DT(x)("Amount")
        Next
        If Amount <> dImpairment.Value Then
            DT(DT.Rows.Count - 1)("Amount") = FormatNumber(dImpairment.Value - (FormatNumber((dImpairment.Value / iMonths.Value), 2) * (iMonths.Value - 1)), 2)
        End If

        GridControl1.DataSource = DT
    End Sub

    Private Sub DImpairment_ValueChanged(sender As Object, e As EventArgs) Handles dImpairment.ValueChanged
        Compute()
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim Total As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            Total += CDbl(GridView1.GetRowCellValue(x, "Amount"))
        Next
        If Total = dImpairment.Value Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub
End Class