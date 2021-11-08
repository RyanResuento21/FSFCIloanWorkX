Imports DevExpress.XtraReports.UI
Public Class FrmSalaryLoanPayment

    Dim Firstload As Boolean
    Private Sub FrmSalaryLoanPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxPayor
            .DisplayMember = "Employer"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, CONCAT('FSFC ', Branch) AS 'Employer', 'Main' AS 'Type' FROM branch WHERE `status` = 'ACTIVE' UNION ALL SELECT ID, CONCAT((SELECT company_code FROM company WHERE ID = SisterID), ' ', Branch) AS 'Employer', 'Sister' AS 'Type' FROM sister_company WHERE `status` = 'ACTIVE' ORDER BY `Employer`;")
            .SelectedIndex = -1
        End With
        Firstload = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX2, LabelX1})

            GetLabelWithBackgroundFontSettings({LabelX19})

            GetCheckBoxFontSettings({cbxForceAvailed, cbxMonthly})

            GetButtonFontSettings({btnFill, btnLedger, btnValidate, btnSave, btnCancel, btnPrint})

            GetComboBoxFontSettings({cbxPayor})

            GetDoubleInputFontSettings({dAmount})

            GetLabelHeaderFontSettings({LabelX11})
        Catch ex As Exception
            TriggerBugReport("Salary Loan Payment - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub CbxPayor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayor.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
        Dim SQL As String = " SELECT ID,"
        SQL &= "     credit_application.CreditNumber,"
        SQL &= "     IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Payor',"
        SQL &= "     AccountNumber AS 'Account Number',"
        SQL &= "     (AmountApplied + Interest) - (SELECT IFNULL(SUM(CASE WHEN PaidFor = 'UDI' OR PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Payment' FROM accounting_entry WHERE `status` = 'ACTIVE' AND ReferenceN = credit_application.CreditNumber) AS 'Balance', "
        SQL &= "     (GMA - Rebate) / 2 AS 'NMA', "
        SQL &= "     (GMA - Rebate) / 2 AS 'Amount', BusinessCenterCode(BusinessID) AS 'BusinessCode', AmountApplied, Interest, Terms, Mortgage_ID, RPPD, Face_Amount, BankID, Rebate, Product, Product_ID, (SELECT IF(product_setup.UDI = 'Yes',TRUE,FALSE) FROM product_setup WHERE product_setup.ID = Product_ID) AS 'with_Interest', (SELECT Payment FROM product_setup WHERE product_setup.ID = Product_ID) AS 'Product_Payment', 0 AS 'Availed', 0 AS 'dRPPD_P', 0 AS 'TotalRPPD_Payable', 0 AS 'TotalRPPD', IF((Loan_Type = 'MIGRATED' OR Loan_Type = 'RESTRUCTURE') AND MigratedValidation = 0,'FOR VALIDATION',PaymentRequest) AS 'PaymentRequest'"
        SQL &= " FROM credit_application "
        SQL &= String.Format(" WHERE product LIKE '%{1}%' AND `status` = 'ACTIVE' AND PaymentRequest = 'RELEASED' AND Employer_B_ID = {0} AND Branch_ID = '{2}';", cbxPayor.SelectedValue, If(drv("Type") = "Main", "FSFC", "SISTER"), Branch_ID)
        GridControl1.DataSource = DataSource(SQL)

        Dim Total As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            Total += CDbl(GridView1.GetRowCellValue(x, "Amount"))
        Next
        dTotal.Value = Total
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.FocusedRowHandle < 0 Then
            Exit Sub
        End If

        If e.Column.FieldName = "Amount" Then
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Amount").ToString = "" Then
                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Amount", 0)
            End If
            Dim Total As Double
            For x As Integer = 0 To GridView1.RowCount - 1
                Total += CDbl(GridView1.GetRowCellValue(x, "Amount"))
            Next
            dTotal.Value = Total
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If dTotal.Value = 0 Then
                MsgBox("Please fill amount on each payor.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If dTotal.Value > dAmount.Value Then
                MsgBox("Total is not equal with Entered Amount, Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If MsgBoxYes("Are you sure you want to pay this salary loan?") = MsgBoxResult.Yes Then
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub CbxPayor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayor.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        Dim Report As New RptSalaryLoanPayment
        With Report
            .Name = String.Format("Billing Statement of {0} {1}", cbxPayor.Text, Format(Date.Now, "MMMM dd, yyyy"))
            .lblAsOf.Text = Format(Date.Now, "MMMM dd, yyyy")

            .lblBranch.Text = cbxPayor.Text

            .DataSource = GridControl1.DataSource
            .lblPayor.DataBindings.Add("Text", GridControl1.DataSource, "Payor")
            .lblAccountNumber.DataBindings.Add("Text", GridControl1.DataSource, "Account Number")
            .lblBalance.DataBindings.Add("Text", GridControl1.DataSource, "Balance")
            .lblNMA.DataBindings.Add("Text", GridControl1.DataSource, "NMA")
            Dim BalanceT As Double
            Dim NMAT As Double
            For x As Integer = 0 To GridView1.RowCount - 1
                BalanceT += GridView1.GetRowCellValue(x, "Balance")
                NMAT += GridView1.GetRowCellValue(x, "NMA")
            Next
            .lblBalanceT.Text = FormatNumber(BalanceT, 2)
            .lblNMAT.Text = FormatNumber(NMAT, 2)

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxMonthly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMonthly.CheckedChanged
        If cbxMonthly.Checked Then
            For x As Integer = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(x, "Amount", CDbl(GridView1.GetRowCellValue(x, "NMA")) * 2)
            Next
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(x, "Amount", CDbl(GridView1.GetRowCellValue(x, "NMA")) * 1)
            Next
        End If
    End Sub

    Private Sub BtnFill_Click(sender As Object, e As EventArgs) Handles btnFill.Click
        dAmount.Value = dTotal.Value
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnLedger.PerformClick()
    End Sub

    Private Sub CbxForceAvailed_CheckedChanged(sender As Object, e As EventArgs) Handles cbxForceAvailed.CheckedChanged
        If cbxForceAvailed.Checked Then
            GridColumn4.OptionsColumn.AllowEdit = False
            cbxMonthly.Enabled = False
            cbxMonthly.Checked = False
            For x As Integer = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(x, "Amount", CDbl(GridView1.GetRowCellValue(x, "NMA")))
            Next
            btnFill.PerformClick()
        Else
            GridColumn4.OptionsColumn.AllowEdit = True
            cbxMonthly.Enabled = True
        End If
    End Sub

    Private Sub BtnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("PaymentRequest") <> "FOR VALIDATION" Then
                MsgBox("Account is not for validation.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Schedule As New FrmMigratedApplication
        With Schedule
            .btnAddC.Visible = True
            .btnRemoveC.Visible = True
            .btnManual.Visible = True
            .From_OfficialReceipt = True
            .dtpAvailedV2.Value = GridView1.GetFocusedRowCellValue("Released")
            .ProductID = GridView1.GetFocusedRowCellValue("Product_ID")
            .v_dAmountApplied = GridView1.GetFocusedRowCellValue("AmountApplied")
            .v_iTerms_C = GridView1.GetFocusedRowCellValue("Terms")
            .v_dInterest_T = GridView1.GetFocusedRowCellValue("Interest_Rate")
            .v_dRPPDRate_T = GridView1.GetFocusedRowCellValue("RPPD_Rate")
            .v_dtpAvailed = GridView1.GetFocusedRowCellValue("Released")
            .v_dtpFDD = GridView1.GetFocusedRowCellValue("FDD")
            .v_dMR_C = GridView1.GetFocusedRowCellValue("Rebate")

            .v_dPA_C = GridView1.GetFocusedRowCellValue("AmountApplied")
            .v_dUDI_C = GridView1.GetFocusedRowCellValue("Interest")
            .v_dRPPD_C = GridView1.GetFocusedRowCellValue("RPPD")
            .txtCreditNumber.Text = GridView1.GetFocusedRowCellValue("CreditNumber")
            .lblTitle.Text = "AMORTIZATION SCHEDULE"
            .vSave = True
            If .ShowDialog() = DialogResult.OK Then
                cbxPayor_SelectedIndexChanged(sender, e)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PaymentRequest"))
            If Status = "" Then
            Else
                Try
                    If Status = "FOR VALIDATION" Then
                        e.Appearance.ForeColor = Color.IndianRed
                    End If
                Catch ex As Exception
                    TriggerBugReport("Salary Loan Payment - GridView1RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub
End Class