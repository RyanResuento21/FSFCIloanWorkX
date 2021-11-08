Public Class FrmServiceCharge

    Public Principal As Double
    Public Renewal As Boolean
    Dim xFrom As Double
    Dim xTo As Double
    Dim xCharge As Double
    Dim ServiceCode As Double
    Private Sub FrmServiceCharge_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        If User_Type.ToUpper = "ADMIN" Then
            btnModify.Enabled = True
            btnModify_2.Enabled = True
        Else
            btnModify.Enabled = False
            btnModify_2.Enabled = False
        End If
        GridControl1.DataSource = ServiceNew
        GridControl2.DataSource = ServiceRenew
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetButtonFontSettings({btnModify, btnAdd, btnDelete, btnClose, btnModify_2, btnAdd_2, btnDelete_2, btnClose_2})
        Catch ex As Exception
            TriggerBugReport("Service Charge - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If Renewal Then
            Exit Sub
        End If
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
            TriggerBugReport("Service Charge - RowCellStyle", ex.Message.ToString)
        End Try
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If Renewal = False Then
            Exit Sub
        End If
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
            TriggerBugReport("Service Charge - RowCellStyle", ex.Message.ToString)
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

    Private Sub BtnClose_2_Click(sender As Object, e As EventArgs) Handles btnClose_2.Click
        btnClose.PerformClick()
    End Sub

    Private Sub BtnModify_2_Click(sender As Object, e As EventArgs) Handles btnModify_2.Click
        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnAdd_2.Enabled = True
            btnDelete_2.Enabled = True

            GridView2.OptionsBehavior.Editable = True
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

            DataObject(String.Format("UPDATE service_charge SET `status` = 'DELETED' WHERE ID = '{0}'", GridView1.GetFocusedRowCellValue("ID")))
            Logs("Service Charge New", "Cancel", Reason, String.Format("Cancel Service Charge {0}", GridView1.GetFocusedRowCellValue("From") & " - " & GridView1.GetFocusedRowCellValue("To") & " (Charge Amount: " & GridView1.GetFocusedRowCellValue("Charge") & ")"), "", "", "")
            ServiceNew = DataSource(String.Format("SELECT ID, (`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'NEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            GridControl1.DataSource = ServiceNew
            MsgBox("Successfully Cancel", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnDelete_2_Click(sender As Object, e As EventArgs) Handles btnDelete_2.Click
        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE service_charge SET `status` = 'DELETED' WHERE ID = '{0}'", GridView2.GetFocusedRowCellValue("ID")))
            Logs("Service Charge Renew", "Cancel", Reason, String.Format("Cancel Service Charge Renew {0}", GridView2.GetFocusedRowCellValue("From") & " - " & GridView2.GetFocusedRowCellValue("To") & " (Charge Amount: " & GridView2.GetFocusedRowCellValue("Charge") & ")"), "", "", "")
            ServiceRenew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'RENEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            GridControl2.DataSource = ServiceRenew
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If (e.Column.FieldName = "From" Or e.Column.FieldName = "To" Or e.Column.FieldName = "Charge") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("Service Charge - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GridView2_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView2.CustomColumnDisplayText
        If (e.Column.FieldName = "From" Or e.Column.FieldName = "To" Or e.Column.FieldName = "Charge") AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                e.DisplayText = FormatNumber(Convert.ToDecimal(e.Value), 2)
            Catch ex As Exception
                TriggerBugReport("Service Charge - CustomColumnDisplayText", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim SQL As String
        If e.Column.FieldName = "From" Then
            If xFrom <> GridView1.GetFocusedRowCellValue("From") Then 'And (xFrom > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `from` = '{0}'", GridView1.GetFocusedRowCellValue("From"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView1.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge New Column (FROM) from {0} to {1}", xFrom, GridView1.GetFocusedRowCellValue("From")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "To" Then
            If xTo <> GridView1.GetFocusedRowCellValue("To") Then 'And (xTo > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `to` = '{0}'", GridView1.GetFocusedRowCellValue("To"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView1.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge New Column (TO) from {0} to {1}", xTo, GridView1.GetFocusedRowCellValue("To")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "Charge" Then
            If xCharge <> GridView1.GetFocusedRowCellValue("Charge") Then 'And (xCharge > 0 And GridView1.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `charge` = '{0}'", GridView1.GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView1.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge New Column (CHARGE) from {0} to {1}", xCharge, GridView1.GetFocusedRowCellValue("Charge")), "", "", "")
            End If
        End If
        ServiceNew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'NEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
    End Sub

    Private Sub GridView1_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
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
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim SQL As String
        If e.Column.FieldName = "From" Then
            If xFrom <> GridView2.GetFocusedRowCellValue("From") Then 'And (xFrom > 0 And GridView2.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `from` = '{0}'", GridView2.GetFocusedRowCellValue("From"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView2.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge Renew Column (FROM) from {0} to {1}", xFrom, GridView2.GetFocusedRowCellValue("From")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "To" Then
            If xTo <> GridView2.GetFocusedRowCellValue("To") Then 'And (xTo > 0 And GridView2.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `to` = '{0}'", GridView2.GetFocusedRowCellValue("To"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView2.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge Renew Column (TO) from {0} to {1}", xTo, GridView2.GetFocusedRowCellValue("To")), "", "", "")
            End If
        ElseIf e.Column.FieldName = "Charge" Then
            If xCharge <> GridView2.GetFocusedRowCellValue("Charge") Then 'And (xCharge > 0 And GridView2.RowCount > 2) Then
                SQL = "UPDATE service_charge SET "
                SQL &= String.Format(" `charge` = '{0}'", GridView2.GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" WHERE service_code = '{0}'", GridView2.GetFocusedRowCellValue("ServiceCode"))
                DataObject(SQL)
                'DataObject(SQL)
                Logs("Service Charge", "Change", "", String.Format("Change Service Charge Renew Column (CHARGE) from {0} to {1}", xCharge, GridView2.GetFocusedRowCellValue("Charge")), "", "", "")
            End If
        End If
        ServiceRenew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'RENEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
    End Sub

    Private Sub GridView2_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
        If e.Column.FieldName = "From" Then
            xFrom = GridView2.GetFocusedRowCellValue("From")
            xTo = 0
            xCharge = 0
        ElseIf e.Column.FieldName = "To" Then
            xFrom = 0
            xTo = GridView2.GetFocusedRowCellValue("To")
            xCharge = 0
        ElseIf e.Column.FieldName = "Charge" Then
            xFrom = 0
            xTo = 0
            xCharge = GridView2.GetFocusedRowCellValue("Charge")
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridView1.AddNewRow()
        If ServiceCode = 0 Then
            ServiceCode = DataObject(String.Format("SELECT IFNULL(MAX(ID),0) + 1 FROM service_charge WHERE branch_id LIKE '{0}'", IIf(Branch_ID = 0, "%", Branch_ID)))
        Else
            ServiceCode += 1
        End If
        With GridView1
            If .RowCount > 2 Then
                Dim DiffFrom As Double = .GetRowCellValue(.RowCount - 2, "From") - .GetRowCellValue(.RowCount - 3, "From")
                Dim DiffTo As Double = .GetRowCellValue(.RowCount - 2, "To") - .GetRowCellValue(.RowCount - 3, "To")
                Dim DiffCharge As Double = .GetRowCellValue(.RowCount - 2, "Charge") - .GetRowCellValue(.RowCount - 3, "Charge")
                .SetFocusedRowCellValue("ID", ServiceCode)
                .SetFocusedRowCellValue("From", .GetRowCellValue(.RowCount - 2, "From") + DiffFrom)
                .SetFocusedRowCellValue("To", .GetRowCellValue(.RowCount - 2, "To") + DiffTo)
                .SetFocusedRowCellValue("Charge", .GetRowCellValue(.RowCount - 2, "Charge") + DiffCharge)
                .SetFocusedRowCellValue("Update", "New")
                .SetFocusedRowCellValue("ServiceCode", CInt(Branch_ID).ToString("D3") & "-" & CInt(ServiceCode).ToString("D5"))

                Dim SQL As String = "INSERT INTO service_charge SET "
                SQL &= String.Format(" service_code = '{0}', ", .GetFocusedRowCellValue("ServiceCode"))
                SQL &= String.Format(" `from` = '{0}', ", .GetFocusedRowCellValue("From"))
                SQL &= String.Format(" `to` = '{0}', ", .GetFocusedRowCellValue("To"))
                SQL &= String.Format(" `charge` = '{0}', `type` = 'NEW', ", .GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)
                Logs("Service Charge New", "Add", "", String.Format("ADD Service Charge New {0}", .GetFocusedRowCellValue("From") & " - " & .GetFocusedRowCellValue("To") & " (Charge Amount: " & .GetFocusedRowCellValue("Charge") & ")"), "", "", "")
                ServiceNew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'NEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            Else
                .SetFocusedRowCellValue("ID", ServiceCode)
                .SetFocusedRowCellValue("From", 0)
                .SetFocusedRowCellValue("To", 0)
                .SetFocusedRowCellValue("Charge", 0)
                .SetFocusedRowCellValue("Update", "New")
                .SetFocusedRowCellValue("ServiceCode", CInt(Branch_ID).ToString("D3") & "-" & CInt(ServiceCode).ToString("D5"))

                Dim SQL As String = "INSERT INTO service_charge SET "
                SQL &= String.Format(" service_code = '{0}', ", .GetFocusedRowCellValue("ServiceCode"))
                SQL &= String.Format(" `from` = '{0}', ", .GetFocusedRowCellValue("From"))
                SQL &= String.Format(" `to` = '{0}', ", .GetFocusedRowCellValue("To"))
                SQL &= String.Format(" `charge` = '{0}', `type` = 'NEW', ", .GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)
                Logs("Service Charge New", "Add", "", String.Format("ADD Service Charge New {0}", .GetFocusedRowCellValue("From") & " - " & .GetFocusedRowCellValue("To") & " (Charge Amount: " & .GetFocusedRowCellValue("Charge") & ")"), "", "", "")
                ServiceNew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'NEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            End If
        End With
    End Sub

    Private Sub BtnAdd_2_Click(sender As Object, e As EventArgs) Handles btnAdd_2.Click
        GridView2.AddNewRow()
        If ServiceCode = 0 Then
            ServiceCode = DataObject(String.Format("SELECT IFNULL(MAX(ID),0) + 1 FROM service_charge WHERE branch_id LIKE '{0}'", IIf(Branch_ID = 0, "%", Branch_ID)))
        Else
            ServiceCode += 1
        End If
        With GridView2
            If .RowCount > 2 Then
                Dim DiffFrom As Double
                Dim DiffTo As Double
                Dim DiffCharge As Double
                DiffFrom = .GetRowCellValue(.RowCount - 2, "From") - .GetRowCellValue(.RowCount - 3, "From")
                DiffTo = .GetRowCellValue(.RowCount - 2, "To") - .GetRowCellValue(.RowCount - 3, "To")
                DiffCharge = .GetRowCellValue(.RowCount - 2, "Charge") - .GetRowCellValue(.RowCount - 3, "Charge")
                .SetFocusedRowCellValue("ID", ServiceCode)
                .SetFocusedRowCellValue("From", .GetRowCellValue(.RowCount - 2, "From") + DiffFrom)
                .SetFocusedRowCellValue("To", .GetRowCellValue(.RowCount - 2, "To") + DiffTo)
                .SetFocusedRowCellValue("Charge", .GetRowCellValue(.RowCount - 2, "Charge") + DiffCharge)
                .SetFocusedRowCellValue("ServiceCode", CInt(Branch_ID).ToString("D3") & "-" & CInt(ServiceCode).ToString("D5"))

                Dim SQL As String = "INSERT INTO service_charge SET "
                SQL &= String.Format(" service_code = '{0}', ", .GetFocusedRowCellValue("ServiceCode"))
                SQL &= String.Format(" `from` = '{0}', ", .GetFocusedRowCellValue("From"))
                SQL &= String.Format(" `to` = '{0}', ", .GetFocusedRowCellValue("To"))
                SQL &= String.Format(" `charge` = '{0}', `type` = 'RENEW', ", .GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)
                Logs("Service Charge Renew", "Add", "", String.Format("ADD Service Charge Renew {0}", .GetFocusedRowCellValue("From") & " - " & .GetFocusedRowCellValue("To") & " (Charge Amount: " & .GetFocusedRowCellValue("Charge") & ")"), "", "", "")
                ServiceRenew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'RENEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            Else
                .SetFocusedRowCellValue("ID", ServiceCode)
                .SetFocusedRowCellValue("From", 0)
                .SetFocusedRowCellValue("To", 0)
                .SetFocusedRowCellValue("Charge", 0)
                .SetFocusedRowCellValue("ServiceCode", CInt(Branch_ID).ToString("D3") & "-" & CInt(ServiceCode).ToString("D5"))

                Dim SQL As String = "INSERT INTO service_charge SET "
                SQL &= String.Format(" service_code = '{0}', ", .GetFocusedRowCellValue("ServiceCode"))
                SQL &= String.Format(" `from` = '{0}', ", .GetFocusedRowCellValue("From"))
                SQL &= String.Format(" `to` = '{0}', ", .GetFocusedRowCellValue("To"))
                SQL &= String.Format(" `charge` = '{0}', `type` = 'RENEW', ", .GetFocusedRowCellValue("Charge"))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)
                Logs("Service Charge Renew", "Add", "", String.Format("ADD Service Charge Renew {0}", .GetFocusedRowCellValue("From") & " - " & .GetFocusedRowCellValue("To") & " (Charge Amount: " & .GetFocusedRowCellValue("Charge") & ")"), "", "", "")
                ServiceRenew = DataSource(String.Format("SELECT ID, FORMAT(`from`,2) AS 'From', FORMAT(`to`,2) AS 'To', FORMAT(Charge,2) AS 'Charge', service_code AS 'ServiceCode' FROM service_charge WHERE `status` = 'ACTIVE' AND `Type` = 'RENEW' AND branch_id LIKE '{0}' ORDER BY `from` * 1", IIf(Branch_ID = 0, "5", Branch_ID)))
            End If
        End With
    End Sub
End Class