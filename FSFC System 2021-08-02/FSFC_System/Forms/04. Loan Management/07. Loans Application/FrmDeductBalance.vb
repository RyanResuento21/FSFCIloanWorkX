Public Class FrmDeductBalance

    Public DT_Account As New DataTable
    Public AccountNum As New DataTable
    Public AccountNum_2 As New DataTable
    Dim FirstLoad As Boolean
    Public NetProceeds As Double
    Public ApplicationDate As Date
    Private Sub FrmDeductBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        With cbxAccount
            .DisplayMember = "Account Number"
            .ValueMember = "ID"
            .DataSource = AccountNum.Copy
        End With
        If DT_Account.Rows.Count = 0 Then
            DT_Account.Rows.Add(0, "", "", "", "", "", "", "", "", "", "", 0.0)
            btnRemoveC.Enabled = False
        End If
        With RepositoryItemLookUpEdit1
            .DataSource = AccountNum_2.Copy
            .DisplayMember = "Account Number"
            .ValueMember = "Account Number"
        End With
        GridControl2.DataSource = DT_Account
        If DT_Account.Rows.Count = 0 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnSave, btnCancel, btnAddC, btnRemoveC})

            GetComboBoxFontSettings({cbxAccount})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit1})
        Catch ex As Exception
            TriggerBugReport("Deduct Balance - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmDeductBalance_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If GridView2.RowCount > 0 Then
            If GridView2.GetRowCellValue(0, "Account Number") = "" Then
                MsgBox("Please select an account for deduct balance.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this deduct balance?") = MsgBoxResult.Yes Then
Here:
                For x As Integer = 0 To GridView2.RowCount - 1
                    If DateValue(ApplicationDate) > DateValue(GridView2.GetRowCellValue(x, "As Of")) Then
                        If MsgBoxYes(String.Format("As of {0} Date for {1} is {2} day(s) away the Application Date of {3}. Would you like to proceed?", Format(CDate(GridView2.GetRowCellValue(x, "As Of")), "MMMM dd, yyyy"), GridView2.GetRowCellValue(x, "Account Number"), DateDiff(DateInterval.Day, CDate(GridView2.GetRowCellValue(x, "As Of")), ApplicationDate), Format(ApplicationDate, "MMMM dd, yyyy"))) = MsgBoxResult.Yes Then
                        Else
                            DT_Account.Rows.RemoveAt(x)
                            GoTo Here
                        End If
                    End If
                    If GridView2.GetRowCellValue(x, "Credit Number") = "" Then
                        DT_Account.Rows.RemoveAt(x)
                        GoTo Here
                    End If
                Next
                Dim TotalDeduction As Double
                For x As Integer = 0 To GridView2.RowCount - 1
                    TotalDeduction += CDbl(GridView2.GetRowCellValue(x, "Amount"))
                Next
                If TotalDeduction > NetProceeds Then
                    MsgBox("Total Deduct Balance is higher than the net proceeds. Please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If TotalDeduction > 0 Then
                    MsgBox("Successfully added to the credit application - deduct balance computation", MsgBoxStyle.Information, "Info")
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        btnSave.Enabled = True
        DT_Account.Rows.Add(0, "", "", "", "", "", "", "", "", "", "", 0.0)

        If GridView2.RowCount = 10 Then
            btnAddC.Enabled = False
        End If
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        btnAddC.Enabled = True
        DT_Account.Rows.RemoveAt(GridView2.FocusedRowHandle)

        If GridView2.RowCount = 0 Then
            btnRemoveC.Enabled = False
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub CbxAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAccount.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
        With GridView2
            For x As Integer = 0 To .RowCount - 1
                If drv("Credit Number") = .GetRowCellValue(x, "Credit Number") Then
                    MsgBox(String.Format("Account Number {0} is already added to the list, please check your data.", cbxAccount.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next
            .SetRowCellValue(.FocusedRowHandle, "Credit Number", drv("Credit Number"))
            .SetRowCellValue(.FocusedRowHandle, "Loans Receivable", drv("Loans Receivable"))
            .SetRowCellValue(.FocusedRowHandle, "UDI Discount", drv("UDI Discount"))
            .SetRowCellValue(.FocusedRowHandle, "UDI Percent", drv("UDI Percent"))
            .SetRowCellValue(.FocusedRowHandle, "Availed RPPD", drv("Availed RPPD"))
            .SetRowCellValue(.FocusedRowHandle, "Accounts Receivable", drv("Accounts Receivable"))
            .SetRowCellValue(.FocusedRowHandle, "Penalty", drv("Penalty"))
            .SetRowCellValue(.FocusedRowHandle, "As Of", drv("As Of"))
            .SetRowCellValue(.FocusedRowHandle, "Net Payable", drv("Net Payable"))
        End With
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "Account Number" Then
            cbxAccount.Text = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account Number")
            Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
            For x As Integer = 0 To GridView2.RowCount - 1
                If drv("Credit Number") = GridView2.GetRowCellValue(x, "Credit Number") Then
                    Exit Sub
                End If
            Next
            CbxAccount_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "Amount") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
            End Try
        End If
    End Sub
End Class