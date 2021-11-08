Public Class FrmEmailAddress

    Private Sub FrmEmailAddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = "SELECT * FROM ("
        SQL &= " SELECT EmailAdd, CONCAT(IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), last_name) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND EmailAdd != '' AND EmailAdd LIKE '%@%'"
        SQL &= "    UNION ALL"
        SQL &= " SELECT Email_B, CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), LastN_B) AS 'Name' FROM profile_borrower WHERE `status` = 'ACTIVE' AND Email_B != '' AND Email_B LIKE '%@%'"
        SQL &= "    UNION ALL"
        SQL &= " SELECT Email_C, CONCAT(IF(FirstN_C = '','',CONCAT(FirstN_C, ' ')), IF(MiddleN_C = '','',CONCAT(MiddleN_C, ' ')), LastN_C) AS 'Name' FROM credit_application_comaker WHERE `status` = 'ACTIVE' AND Email_C != '' AND Email_C LIKE '%@%') A"
        SQL &= " GROUP BY `EmailAdd` ORDER BY `EmailAdd`;"
        With cbxEmailAdd
            .DisplayMember = "EmailAdd"
            .DataSource = DataSource(SQL)
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX23})

            GetComboBoxFontSettings({cbxEmailAdd})

            GetButtonFontSettings({btnAdd, btnAdd, btnRemove, btnSend, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Email Address - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSend.Focus()
            btnSend.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnRemove.Focus()
            btnRemove.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cbxEmailAdd.Text.Contains("@") Then
        Else
            MsgBox("Please fill a correct email address.", MsgBoxStyle.Information, "Info")
            cbxEmailAdd.Focus()
            Exit Sub
        End If
        If cbxEmailAdd.Text = "" Then
            MsgBox("Please fill a correct email address.", MsgBoxStyle.Information, "Info")
            cbxEmailAdd.Focus()
            Exit Sub
        End If
        For x As Integer = 0 To GridView1.RowCount - 1
            If GridView1.GetRowCellValue(x, "Email Address") = cbxEmailAdd.Text Then
                MsgBox("Email Address is already added at the list.", MsgBoxStyle.Information, "Info")
                cbxEmailAdd.Focus()
                Exit Sub
            End If
        Next

        If MsgBoxYes("Are you sure you want to add this email address to the receiver list?") = MsgBoxResult.Yes Then
            Dim Temp_DT As New DataTable
            If GridView1.RowCount > 0 Then
                Temp_DT = GridControl1.DataSource
            Else
                Temp_DT.Columns.Add("Email Address")
                Temp_DT.Columns.Add("Name")
            End If

            If cbxEmailAdd.SelectedIndex = -1 Then
                Temp_DT.Rows.Add(cbxEmailAdd.Text, "")
            Else
                Dim drv_B As DataRowView = DirectCast(cbxEmailAdd.SelectedItem, DataRowView)
                Temp_DT.Rows.Add(cbxEmailAdd.Text, drv_B("Name"))
            End If
            GridControl1.DataSource = Temp_DT
            cbxEmailAdd.Text = ""
            MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
            If GridView1.RowCount > 0 Then
                btnSend.Enabled = True
                btnRemove.Enabled = True
            Else
                btnSend.Enabled = False
                btnRemove.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxEmailAdd_Leave(sender As Object, e As EventArgs) Handles cbxEmailAdd.Leave
        cbxEmailAdd.Text = ReplaceText(cbxEmailAdd.Text)
    End Sub

    Private Sub CbxEmailAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmailAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If btnSend.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to send this to this receiver(s)?") = MsgBoxResult.Yes Then
                btnSend.DialogResult = DialogResult.OK
                btnSend.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If MsgBoxYes("Are you sure you want to add this email address from the receiver list?") = MsgBoxResult.Yes Then
            Dim Temp_DT As DataTable = GridControl1.DataSource
            Temp_DT.Rows.RemoveAt(GridView1.FocusedRowHandle)
            GridControl1.DataSource = Temp_DT
            MsgBox("Successfully Removed", MsgBoxStyle.Information, "Info")
        End If

        If GridView1.RowCount > 0 Then
            btnSend.Enabled = True
            btnRemove.Enabled = True
        Else
            btnSend.Enabled = False
            btnRemove.Enabled = False
        End If
    End Sub
End Class