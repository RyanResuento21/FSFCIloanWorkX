Public Class FrmUpdateEmployer

    Public CreditNumber As String
    Public Product As String
    Dim FirstLoad As Boolean

    Private Sub FrmUpdateEmployer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxEmployer_B
            .ValueMember = "ID"
            .DisplayMember = "Employer"
            If Product.Contains("FSFC") Then
                .DataSource = DataSource("SELECT ID, CONCAT('FSFC ', Branch) AS 'Employer', Address AS 'EmployerAddress_B', ContactN1 AS 'EmployerTelephone_B' FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
            ElseIf Product.Contains("SISTER") Then
                .DataSource = DataSource("SELECT ID, CONCAT((SELECT company_code FROM company WHERE ID = SisterID), ' ', Branch) AS 'Employer', CONCAT(IF(`No` = '','',CONCAT(`No`, ', ')), IF(Street = '','',CONCAT(Street, ', ')), IF(Brgy = '','',CONCAT(Brgy, ', ')), IF(City = '','',CONCAT(City, ', ')), IF(Province = '','',Province), '') AS 'EmployerAddress_B', Telephone AS 'EmployerTelephone_B' FROM sister_company WHERE `status` = 'ACTIVE' ORDER BY `Employer`;")
            End If
            .Text = .Tag
        End With
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX22, LabelX23, LabelX24})

            GetTextBoxFontSettings({txtEmployerAddress_B, txtEmployerTelephone_B})

            GetComboBoxFontSettings({cbxEmployer_B})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Update Employer - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxEmployer_B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmployer_B.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxEmployer_B.SelectedIndex > -1 Then
            Dim drv As DataRowView = DirectCast(cbxEmployer_B.SelectedItem, DataRowView)
            txtEmployerAddress_B.Text = drv("EmployerAddress_B")
            txtEmployerTelephone_B.Text = drv("EmployerTelephone_B")
        End If
    End Sub

    Private Sub CbxEmployer_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployer_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerAddress_B.Focus()
        End If
    End Sub

    Private Sub TxtEmployerAddress_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerAddress_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerTelephone_B.Focus()
        End If
    End Sub

    Private Sub TxtEmployerTelephone_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerTelephone_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub CbxEmployer_B_Leave(sender As Object, e As EventArgs) Handles cbxEmployer_B.Leave
        cbxEmployer_B.Text = ReplaceText(cbxEmployer_B.Text.Trim)
    End Sub

    Private Sub TxtEmployerAddress_B_Leave(sender As Object, e As EventArgs) Handles txtEmployerAddress_B.Leave
        txtEmployerAddress_B.Text = ReplaceText(txtEmployerAddress_B.Text.Trim)
    End Sub

    Private Sub TxtEmployerTelephone_B_Leave(sender As Object, e As EventArgs) Handles txtEmployerTelephone_B.Leave
        txtEmployerTelephone_B.Text = ReplaceText(txtEmployerTelephone_B.Text.Trim)
    End Sub

    Private Sub FrmUpdateEmployer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If cbxEmployer_B.Text = "" Then
                If MsgBox("Employer is empty, would you like to proceed?.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    cbxEmployer_B.Focus()
                    Exit Sub
                End If
            End If

            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE credit_application SET"
                SQL &= String.Format(" Employer_B = '{0}', ", cbxEmployer_B.Text)
                SQL &= String.Format(" Employer_B_ID = '{0}', ", ValidateComboBox(cbxEmployer_B))
                SQL &= String.Format(" EmployerAddress_B = '{0}', ", txtEmployerAddress_B.Text)
                SQL &= String.Format(" EmployerTelephone_B = '{0}' ", txtEmployerTelephone_B.Text)
                SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)
                DataObject(SQL)
                Logs("Update Employer", "Update", String.Format("Update Employer Details for Credit Number {0}", CreditNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxEmployer_B.Text = cbxEmployer_B.Tag Then
            Else
                Change &= String.Format("Change Employer from {0} to {1}. ", cbxEmployer_B.Tag, cbxEmployer_B.Text)
            End If
            If txtEmployerAddress_B.Text = txtEmployerAddress_B.Tag Then
            Else
                Change &= String.Format("Change Employer Address from {0} to {1}. ", txtEmployerAddress_B.Tag, txtEmployerAddress_B.Text)
            End If
            If txtEmployerTelephone_B.Text = txtEmployerTelephone_B.Tag Then
            Else
                Change &= String.Format("Change Employer Telephone from {0} to {1}. ", txtEmployerTelephone_B.Tag, txtEmployerTelephone_B.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Update Employer - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub CbxEmployer_B_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployer_B.TextChanged
        If cbxEmployer_B.Text = "" Then
            txtEmployerAddress_B.Text = ""
            txtEmployerTelephone_B.Text = ""
        End If
    End Sub
End Class