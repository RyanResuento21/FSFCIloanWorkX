
Imports DevExpress.XtraReports.UI
Public Class FrmPurchaseSched

    Public Months As Integer
    Public xDate As Date
    Public Amount As Double
    Public TotalPayable As Double
    Dim Flag As Boolean
    Public Buyer As String
    Public ContactN As String
    Public AssetNumber As String
    Public ORNumber As String
    ReadOnly DT As New DataTable
    Public Replace As Boolean
    Public DefaultBank As String
    Public DefaultBranch As String
    Public BankID As Integer
    Public Sold_ID As String
    Public From_Reserve As Boolean

    Private Sub FrmPurchaseSched_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Dim Checks As New DataTable

        With DT
            .Columns.Add("No")
            .Columns.Add("Bank")
            .Columns.Add("Branch")
            .Columns.Add("Check No")
            .Columns.Add("Date")
            .Columns.Add("Amount")
            .Columns.Add("Remarks")
        End With
        If Replace = False Or From_Reserve Then
            Checks = DataSource(String.Format("SELECT ROW_NUMBER() OVER() AS 'No', Bank, Branch, `Check` AS 'Check No', DATE_FORMAT(`Date`,'%m.%d.%Y') AS 'Date', Amount, Remarks FROM check_received WHERE AssetNumber = '{0}' AND ORNumber = '{1}' AND `status` = 'PENDING' AND Sold_ID = '';", AssetNumber, ORNumber))
        End If
        If Checks.Rows.Count > 0 Then
            GridControl2.DataSource = Checks
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnAddC.Enabled = False
            btnRemoveC.Enabled = False
            btnCancel.DialogResult = DialogResult.OK
        Else
            LoadData()
        End If

        With RepositoryItemLookUpEdit1
            .DataSource = DataSource("SELECT ID, Bank, short_name AS 'Short Name' FROM bank_setup WHERE `status` = 'ACTIVE';")
            .DisplayMember = "Short Name"
            .ValueMember = "Short Name"
        End With

        If TotalPayable = 0 Then
        Else
            btnAddC.Enabled = False
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

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel, btnPrint, btnAddC, btnRemoveC})
        Catch ex As Exception
            TriggerBugReport("Purchase Sched - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("ROPOA PDC", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        DT.Rows.Clear()
        For x As Integer = 0 To Months - 1
            If Replace Then
                DT.Rows.Add(x + 1, DefaultBank, DefaultBranch, "", Format(xDate.AddMonths(x), "MM.dd.yyyy"), FormatNumber(Amount, 2), "")
            Else
                DT.Rows.Add(x + 1, "", "", "", Format(xDate.AddMonths(x), "MM.dd.yyyy"), FormatNumber(Amount, 2), "")
            End If
        Next

        GridControl2.DataSource = DT
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmPurchaseSched_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim Plus1 As Integer = 0
        Dim Plus1Month As Integer = 0
        For x As Integer = e.RowHandle To GridView2.RowCount - 1
            If e.Column.FieldName = "Bank" AndAlso (Not Flag) Then
                Flag = True
                GridView2.SetRowCellValue(x, "Bank", e.Value)
                Flag = False
            End If
            If e.Column.FieldName = "Branch" AndAlso (Not Flag) Then
                Flag = True
                GridView2.SetRowCellValue(x, "Branch", e.Value)
                Flag = False
            End If
            If e.Column.FieldName = "Check No" AndAlso (Not Flag) Then
                Flag = True
                Try
                    GridView2.SetRowCellValue(x, "Check No", (e.Value + Plus1).ToString.PadLeft((e.Value + Plus1).ToString.Length + CountLeadingZeros(e.Value.ToString), "0"))
                Catch ex As Exception
                End Try
                Plus1 += 1
                Flag = False
            End If
            If e.Column.FieldName = "Date" AndAlso (Not Flag) Then
                Flag = True
                Try
                    GridView2.SetRowCellValue(x, "Date", Format(DateValue(e.Value).AddMonths(Plus1Month), "MM.dd.yyyy"))
                Catch ex As Exception
                End Try
                Plus1Month += 1
                Flag = False
            End If
        Next
    End Sub

    Public Function CountLeadingZeros(input As String) As String
        Dim count As Integer = 0
        For Each c As Char In input
            If c = "0"c Then
                count += 1
            Else
                Exit For
            End If
        Next
        Return count
    End Function

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("Purchase Sched - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        ElseIf (e.Column.FieldName = "Date") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = Format(DateValue(e.Value), "MM.dd.yyyy")
            Catch ex As Exception
                TriggerBugReport("Purchase Sched - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If GridView2.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim Report As New RptPDCReceipt
            With Report
                .Name = "PDC Receipt"
                .lblBorrower.Text = Buyer
                .lblBorrower2.Text = Buyer
                .lblContactN.Text = ContactN

                Dim Total As Double
                For x As Integer = 0 To GridView2.RowCount - 1
                    GridView2.SetRowCellValue(x, "Amount", FormatNumber(GridView2.GetRowCellValue(x, "Amount"), 2))
                    Total += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                Next
                .DataSource = GridControl2.DataSource
                .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                .lblBank.DataBindings.Add("Text", GridControl2.DataSource, "Bank")
                .lblBranch.DataBindings.Add("Text", GridControl2.DataSource, "Branch")
                .lblCheckN.DataBindings.Add("Text", GridControl2.DataSource, "Check No")
                .lblCheckD.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                .lblAmount.DataBindings.Add("Text", GridControl2.DataSource, "Amount")
                .lblRemarksC.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
                .lblTotal.Text = FormatNumber(Total, 2)

                .lblConfirmedD.Text = Format(Date.Now, "MM.dd.yyyy")
                .lblReceivedBy.Text = Empl_Name
                .lblReceivedD.Text = Format(Date.Now, "MM.dd.yyyy")
                .ShowPreview()
            End With
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For x As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(x, "Bank") = "" Then
                MsgBox(String.Format("Please select Bank at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If GridView2.GetRowCellValue(x, "Branch") = "" Then
                MsgBox(String.Format("Please fill Branch at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            For y As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Check No") = GridView2.GetRowCellValue(y, "Check No") And x <> y Then
                    MsgBox(String.Format("Duplication of Check Number found at row {0} and row {1}, please check your data.", x + 1, y + 1), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next
            If GridView2.GetRowCellValue(x, "Check No") = "" Then
                MsgBox(String.Format("Please fill Check No at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If GridView2.GetRowCellValue(x, "Date") = "" Then
                MsgBox(String.Format("Please fill Date at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If CDbl(GridView2.GetRowCellValue(x, "Amount")) = 0 Then
                MsgBox(String.Format("Please fill Amount at row {0}", x + 1), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Next

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this checks?") = MsgBoxResult.Yes Then
                btnSave.DialogResult = DialogResult.OK
                Cursor = Cursors.WaitCursor

                Dim SQL As String
                For x As Integer = 0 To GridView2.RowCount - 1
                    SQL = "INSERT INTO check_received SET"
                    SQL &= String.Format(" AssetNumber = '{0}', ", AssetNumber)
                    SQL &= String.Format(" ORNumber = '{0}', ", ORNumber)
                    SQL &= String.Format(" Sold_ID = '{0}',", Sold_ID)
                    SQL &= String.Format(" Buyer = '{0}', ", Buyer)
                    SQL &= String.Format(" Bank = '{0}', ", GridView2.GetRowCellValue(x, "Bank"))
                    SQL &= String.Format(" Branch = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Branch")))
                    SQL &= String.Format(" `Check` = '{0}', ", GridView2.GetRowCellValue(x, "Check No"))
                    SQL &= String.Format(" `Date` = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                    SQL &= String.Format(" Remarks = '{0}', ", ReplaceText(GridView2.GetRowCellValue(x, "Remarks")))
                    If Replace Or From_Reserve Then
                        SQL &= " `status` = 'ACTIVE', "
                    Else
                        SQL &= " `status` = 'PENDING', "
                    End If
                    SQL &= String.Format(" BankID = '{0}', ", BankID)
                    SQL &= String.Format(" branch_id = '{0}',", Branch_ID)
                    SQL &= String.Format(" user_code = '{0}' ", User_Code)
                    DataObject(SQL)
                Next

                Logs("ROPOA PDC", "Save", String.Format("Received {1} checks for {0}", AssetNumber, GridView2.RowCount), "", "", "", "")
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnPrint.PerformClick()
                btnSave.PerformClick()
            Else
                btnSave.DialogResult = DialogResult.None
            End If
        End If
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        DT.Rows.Add(GridView2.RowCount + 1, "", "", "", Format(xDate.AddMonths(GridView2.RowCount), "MM.dd.yyyy"), FormatNumber(TotalPayable / GridView2.RowCount, 2), "")
        For x As Integer = 0 To GridView2.RowCount - 1
            Try
                If x = GridView2.RowCount - 1 Then
                    GridView2.SetRowCellValue(GridView2.RowCount - 1, "Amount", Amount * (Months - (GridView2.RowCount - 1)))
                Else
                    GridView2.SetRowCellValue(x, "Amount", Amount)
                End If
            Catch ex As Exception
                TriggerBugReport("Purchase Sched - Add C", ex.Message.ToString)
            End Try
        Next
        If GridView2.RowCount = Months And TotalPayable = 0 Then
            btnAddC.Enabled = False
        End If
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        If GridView2.RowCount = 0 Then
            Exit Sub
        End If
        btnAddC.Enabled = True
        DT.Rows.RemoveAt(GridView2.RowCount - 1)
        For x As Integer = 0 To GridView2.RowCount - 1
            Try
                If x = GridView2.RowCount - 1 Then
                    GridView2.SetRowCellValue(GridView2.RowCount - 1, "Amount", Amount * (Months - (GridView2.RowCount - 1)))
                Else
                    GridView2.SetRowCellValue(x, "Amount", Amount)
                End If
            Catch ex As Exception
                TriggerBugReport("Purchase Sched - Remove C", ex.Message.ToString)
            End Try
        Next
        If GridView2.RowCount = 1 Then
            btnRemoveC.Enabled = False
        End If
    End Sub
End Class