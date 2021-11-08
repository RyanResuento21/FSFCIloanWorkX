Public Class FrmTariff

    Public Principal As Double
    Dim xFrom As Double
    Dim xTo As Double
    Dim xCharge As Double
    Dim TariffCode As Double
    Public FromBranch As Boolean
    Public FromBranchID As String
    Private Sub FrmTariff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        If User_Type.ToUpper = "ADMIN" Then
            btnModify.Enabled = True
        Else
            btnModify.Enabled = False
        End If
        If FromBranch Then
            GridControl1.DataSource = DataSource(String.Format("CALL Login_GetTariff('{0}')", FromBranchID))
        Else
            GridControl1.DataSource = Tariff
        End If
        If GridView1.RowCount = 0 Then
            btnDefault.Visible = True
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetButtonFontSettings({btnModify, btnAdd, btnDefault, btnDelete, btnClose})
        Catch ex As Exception
            TriggerBugReport("Tariff - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim vFrom As Double = View.GetRowCellValue(e.RowHandle, View.Columns("From"))
            Dim vTo As Double = View.GetRowCellValue(e.RowHandle, View.Columns("To"))
            If Principal >= vFrom And Principal <= vTo Then
                e.Appearance.BackColor = Color.Lime
                e.Appearance.BackColor2 = Color.Lime
                e.Appearance.ForeColor = Color.Black
            End If
        Catch ex As Exception
            TriggerBugReport("Tariff - GridView1RowCellSetyle", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnClose.Focus()
            btnClose.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnAdd.Enabled = True
            btnDelete.Enabled = True

            GridView1.OptionsBehavior.Editable = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE tariff_setup SET `status` = 'DELETED' WHERE ID = '{0}'", GridView1.GetFocusedRowCellValue("ID")))
            Logs("Tariff", "Cancel", Reason, String.Format("Cancel Tariff {0}", GridView1.GetFocusedRowCellValue("From") & " - " & GridView1.GetFocusedRowCellValue("To") & " (Charge Amount: " & GridView1.GetFocusedRowCellValue("Charge") & ")"), "", "", "")
            Tariff = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', Format(`To`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', tariff_code AS 'Code' FROM tariff_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `from` * 1", If(Branch_ID = 0, "5", Branch_ID)))
            GridControl1.DataSource = Tariff
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If (e.Column.FieldName = "From" Or e.Column.FieldName = "To" Or e.Column.FieldName = "Charge") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("Tariff - GridView1CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim SQL As String
        If e.Column.FieldName = "From" Then
            If xFrom <> GridView1.GetFocusedRowCellValue("From") Then 'And (xFrom > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE tariff_setup SET "
                SQL &= String.Format(" `from` = '{0}'", GridView1.GetFocusedRowCellValue("From"))
                SQL &= String.Format(" WHERE tariff_code = '{0}'", GridView1.GetFocusedRowCellValue("Code"))
                DataObject(SQL)
                Logs("Tariff", "Change", "", String.Format("Change Tariff Column (FROM) from {0} to {1}", xFrom, GridView1.GetFocusedRowCellValue("From")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "To" Then
            If xTo <> GridView1.GetFocusedRowCellValue("To") Then 'And (xTo > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE tariff_setup SET "
                SQL &= String.Format(" `to` = '{0}'", GridView1.GetFocusedRowCellValue("To"))
                SQL &= String.Format(" WHERE tariff_code = '{0}'", GridView1.GetFocusedRowCellValue("Code"))
                DataObject(SQL)
                Logs("Tariff", "Change", "", String.Format("Change Tariff Column (TO) from {0} to {1}", xTo, GridView1.GetFocusedRowCellValue("To")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "Charge" Then
            If xCharge <> GridView1.GetFocusedRowCellValue("Charge") Then 'And (xCharge > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE tariff_setup SET "
                SQL &= String.Format(" `charge` = '{0}'", GridView1.GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" WHERE tariff_code = '{0}'", GridView1.GetFocusedRowCellValue("Code"))
                DataObject(SQL)
                Logs("Tariff", "Change", "", String.Format("Change Tariff Column (CHARGE) from {0} to {1}", xCharge, GridView1.GetFocusedRowCellValue("Charge")), "", "", "")
            End If
        End If
        Tariff = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', Format(`To`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', tariff_code AS 'Code' FROM tariff_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `from` * 1", If(Branch_ID = 0, "5", Branch_ID)))
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Try
            If e.Column.FieldName = "From" Then
                xFrom = GridView1.GetFocusedRowCellValue("From")
                xTo = 0
                xCharge = 0
            ElseIf e.Column.FieldName = "To" Then
                xFrom = 0
                xTo = GridView1.GetFocusedRowCellValue("To")
                xCharge = 0
            ElseIf e.Column.FieldName = "Charge" Then
                xFrom = 0
                xTo = 0
                xCharge = GridView1.GetFocusedRowCellValue("Charge")
            End If
        Catch ex As Exception
            TriggerBugReport("Tariff - CellValueChanging", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridView1.AddNewRow()
        If TariffCode = 0 Then
            TariffCode = DataObject(String.Format("SELECT IFNULL(MAX(ID) + 1,1) FROM tariff_setup WHERE branch_id LIKE '{0}'", If(Branch_ID = 0, "%", Branch_ID)))
        Else
            TariffCode += 1
        End If
        With GridView1
            If .RowCount > 2 Then
                Dim DiffFrom As Double = .GetRowCellValue(.RowCount - 2, "From") - .GetRowCellValue(.RowCount - 3, "From")
                Dim DiffTo As Double = .GetRowCellValue(.RowCount - 2, "To") - .GetRowCellValue(.RowCount - 3, "To")
                Dim DiffCharge As Double = .GetRowCellValue(.RowCount - 2, "Charge") - .GetRowCellValue(.RowCount - 3, "Charge")
                .SetFocusedRowCellValue("ID", TariffCode)
                .SetFocusedRowCellValue("From", .GetRowCellValue(.RowCount - 2, "From") + DiffFrom)
                .SetFocusedRowCellValue("To", .GetRowCellValue(.RowCount - 2, "To") + DiffTo)
                .SetFocusedRowCellValue("Charge", .GetRowCellValue(.RowCount - 2, "Charge") + DiffCharge)
                .SetFocusedRowCellValue("Code", Branch_ID.ToString("D3") & "-" & CInt(TariffCode).ToString("D5"))
            Else
                .SetFocusedRowCellValue("ID", TariffCode)
                .SetFocusedRowCellValue("From", 0)
                .SetFocusedRowCellValue("To", 0)
                .SetFocusedRowCellValue("Charge", 0)
                .SetFocusedRowCellValue("Code", Branch_ID.ToString("D3") & "-" & CInt(TariffCode).ToString("D5"))
            End If

            Dim SQL As String = "INSERT INTO tariff_setup SET "
            SQL &= String.Format(" tariff_code = '{0}', ", .GetFocusedRowCellValue("Code"))
            SQL &= String.Format(" `from` = '{0}', ", .GetFocusedRowCellValue("From"))
            SQL &= String.Format(" `to` = '{0}', ", .GetFocusedRowCellValue("To"))
            SQL &= String.Format(" `charge` = '{0}', ", .GetFocusedRowCellValue("Charge"))
            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
            DataObject(SQL)
            Logs("Tariff", "Add", "", String.Format("Add Tariff {0}", .GetFocusedRowCellValue("From") & " - " & .GetFocusedRowCellValue("To") & " (Charge Amount: " & .GetFocusedRowCellValue("Charge") & ")"), "", "", "")
            Tariff = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', Format(`To`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', tariff_code AS 'Code' FROM tariff_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `from` * 1", If(Branch_ID = 0, "5", Branch_ID)))
        End With
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        If MsgBoxYes("Are you sure you want to setup the default tariff?") = MsgBoxResult.Yes Then
            Dim CopyTariff As DataTable = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', Format(`To`,2) AS 'To', FORMAT(Charge,2) AS 'Charge' FROM tariff_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `from` * 1", 5))
            Dim SQL As String = ""
            For x As Integer = 0 To CopyTariff.Rows.Count - 1
                SQL &= "INSERT INTO tariff_setup SET "
                SQL &= String.Format(" tariff_code = '{0}', ", CInt(If(FromBranch, FromBranchID, Branch_ID)).ToString("D3") & "-" & CInt(x + 1).ToString("D5"))
                SQL &= String.Format(" `from` = '{0}', ", CDbl(CopyTariff(x)("From")))
                SQL &= String.Format(" `to` = '{0}', ", CDbl(CopyTariff(x)("To")))
                SQL &= String.Format(" `charge` = '{0}', ", CDbl(CopyTariff(x)("Charge")))
                SQL &= String.Format(" branch_id = '{0}';", If(FromBranch, FromBranchID, Branch_ID))
            Next
            If SQL = "" Then
                MsgBox("No Tariff to copy from other branch.", MsgBoxStyle.Information, "Info")
            Else
                DataObject(SQL)
                Logs("Tariff", "Default", "", "Copy default tariff", "", "", "")
                Tariff = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', Format(`To`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', tariff_code AS 'Code' FROM tariff_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}' ORDER BY `from` * 1", If(Branch_ID = 0, "5", Branch_ID)))
                GridControl1.DataSource = Tariff
                btnDefault.Visible = False
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub
End Class