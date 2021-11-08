Public Class FrmReassignCI

    Public CreditNumber As String
    Dim FirstLoad As Boolean
    Public AssignedBranch As Boolean
    Public Borrower As String
    Private Sub FrmReassignCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstLoad = True
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxOutsourceBranch
            .ValueMember = "branchID"
            .DisplayMember = "branch"
            .DataSource = DataSource(String.Format("SELECT branchID, branch FROM branch WHERE `status` = 'ACTIVE' AND ID != '{0}' ORDER BY Microfinance, branchID * 1;", If(AssignedBranch, "", Branch_ID)))
            If FrmLoanApplication.GridView5.GetFocusedRowCellValue("OutsourceCI") = "" Then
                .SelectedIndex = -1
                cbxOutsource.Checked = False
            Else
                cbxOutsource.Checked = True
                If AssignedBranch = False Then
                    cbxCI.Enabled = False
                End If
                .Enabled = True
                .SelectedValue = FrmLoanApplication.GridView5.GetFocusedRowCellValue("OutsourceCI")
            End If
        End With
        If AssignedBranch Then
            cbxOutsource.Enabled = False
            cbxOutsourceBranch.Enabled = False
        End If

        With cbxCI
            .ValueMember = "ID"
            .DisplayMember = "CI"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", If(cbxOutsource.Checked, cbxOutsourceBranch.SelectedValue, Branch_ID)))
            .SelectedValue = FrmLoanApplication.GridView5.GetFocusedRowCellValue("assigned_CI")
            .Tag = .Text
            If cbxOutsource.Checked And .SelectedIndex <> -1 And AssignedBranch = False Then
                MsgBox(String.Format("Credit Application is already assigned to {0}. Re assign of branch is not allowed.", .Text), MsgBoxStyle.Information, "Info")
                cbxCI.Enabled = False
                cbxOutsourceBranch.Enabled = False
                btnSave.Enabled = False
            End If
        End With

        rNote.Text = FrmLoanApplication.GridView5.GetFocusedRowCellValue("RejectReason")
        rNote.Tag = rNote.Text
        FirstLoad = False
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

            GetLabelFontSettings({LabelX66, LabelX2})

            GetComboBoxFontSettings({cbxOutsourceBranch, cbxCI})

            GetCheckBoxFontSettings({cbxOutsource})

            GetRickTextBoxFontSettings({rNote})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Reassign CI - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Reassign CI", lblTitle.Text)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If cbxOutsource.Checked And (cbxOutsourceBranch.SelectedIndex = -1 Or cbxOutsourceBranch.Text = "") Then
            MsgBox("Please select Branch who will CI.", MsgBoxStyle.Information, "Info")
            cbxOutsourceBranch.DroppedDown = True
            Exit Sub
        End If
        If (cbxCI.SelectedIndex = -1 Or cbxCI.Text = "") And cbxOutsource.Checked = False Then
            MsgBox("Please select assigned Credit Investigator.", MsgBoxStyle.Information, "Info")
            cbxCI.DroppedDown = True
            Exit Sub
        End If
        If MsgBoxYes(String.Format("Are you sure you want to assign {0} to investigate this credit application?", cbxCI.Text)) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            Dim Note As New FrmReason
            If Note.ShowDialog = DialogResult.OK Then
                Reason = Note.txtReason.Text
            Else
                Exit Sub
            End If
            Note.Dispose()

            DataObject(String.Format("UPDATE credit_application SET Assigned_CI = '{2}', RejectReason = '{1}', OutsourceCI = '{3}' WHERE CreditNumber = '{0}'", CreditNumber, rNote.Text.Trim, ValidateComboBox(cbxCI), If(cbxOutsource.Checked, cbxOutsourceBranch.SelectedValue, "")))
            Logs("Reassign CI", "Save", Reason.Trim, String.Format("Reassign CI from {0} to {1}{3} for Credit Number {2}.", cbxCI.Tag, cbxCI.Text, CreditNumber, If(rNote.Tag = rNote.Text, "", String.Format(", Change CI Note from {0} to {1}", rNote.Tag, rNote.Text))), "", "", CreditNumber)
            If cbxOutsource.Checked And AssignedBranch = False Then
                Dim Msg As String = ""
                Dim Subject As String = String.Format("Request to Credit Investigate {0} [{1}].", Borrower, Branch)
                Dim EmailTo As String = ""
                Dim BM As DataTable = GetBM(cbxOutsourceBranch.SelectedValue)
                For x As Integer = 0 To BM.Rows.Count - 1
                    Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                    Msg &= String.Format("{0} Branch is requesting your Branch to Credit Investigate the application of {1}" & vbCrLf, Branch, Borrower)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If BM(x)("Phone") = "" Then
                    Else
                        SendSMS(BM(x)("Phone"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If BM(x)("EmailAdd") = "" Then
                    Else
                        EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                    End If
                Next
                If EmailTo = "" Then
                Else
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If
            End If
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            btnSave.DialogResult = DialogResult.OK
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub RNote_Leave(sender As Object, e As EventArgs) Handles rNote.Leave
        rNote.Text = ReplaceText(rNote.Text)
    End Sub

    Private Sub CbxCI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            rNote.Focus()
        End If
    End Sub

    Private Sub RNote_KeyDown(sender As Object, e As KeyEventArgs) Handles rNote.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub CbxCI_TextChanged(sender As Object, e As EventArgs) Handles cbxCI.TextChanged
        If cbxCI.Tag = cbxCI.Text And cbxOutsource.Checked = False Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub CbxOutsource_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOutsource.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If
        If cbxOutsource.Checked Then
            cbxOutsourceBranch.Enabled = True
            cbxOutsourceBranch.SelectedIndex = -1

            cbxCI.Enabled = False
        Else
            cbxOutsourceBranch.Enabled = False
            cbxOutsourceBranch.SelectedIndex = -1

            With cbxCI
                .Enabled = True
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
                .Text = ""
                If FrmLoanApplication.GridView5.GetFocusedRowCellValue("assigned_CI") > 0 Then
                    .SelectedValue = FrmLoanApplication.GridView5.GetFocusedRowCellValue("assigned_CI")
                End If
            End With
        End If
    End Sub

    Private Sub CbxOutsourceBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOutsourceBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxCI
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", cbxOutsourceBranch.SelectedValue))
            .Text = ""
            If FrmLoanApplication.GridView5.GetFocusedRowCellValue("assigned_CI") > 0 Then
                .SelectedValue = FrmLoanApplication.GridView5.GetFocusedRowCellValue("assigned_CI")
            End If
        End With
    End Sub
End Class