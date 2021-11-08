Public Class FrmRequirements

    Public CreditNumber As String
    Public BorrowerID As String
    Public TotalImage As Integer
    Public DocID As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public ID As Integer

    Private Sub FrmRequirements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        dtpReceived.Value = Date.Now

        If txtDocument.Text.ToUpper.Contains("VALID ID") Or txtDocument.Text.ToUpper.Contains("VALID I.D.") Or txtDocument.Text.ToUpper.Contains("2X2") Then
            Dim TotalID As Integer = DataObject(String.Format("SELECT IF(Attach_TIN > 0,1,0) + IF(Attach_SSS > 0,1,0) + IF(Attach_GSIS > 0,1,0) + IF(Attach_PhilHealth > 0,1,0) + IF(Attach_Senior > 0,1,0) + IF(Attach_UMID > 0,1,0) + IF(Attach_SEC > 0,1,0) + IF(Attach_DTI > 0,1,0) + IF(Attach_CDA > 0,1,0) + IF(Attach_Cooperative > 0,1,0) + IF(Attach_Drivers > 0,1,0) + IF(Attach_VIN > 0,1,0) + IF(Attach_Passport > 0,1,0) + IF(Attach_PRC > 0,1,0) + IF(Attach_NBI > 0,1,0) + IF(Attach_Police > 0,1,0) + IF(Attach_Postal > 0,1,0) + IF(Attach_Barangay > 0,1,0) + IF(Attach_OWWA > 0,1,0) + IF(Attach_OFW > 0,1,0) + IF(Attach_Seaman > 0,1,0) + IF(Attach_PNP > 0,1,0) + IF(Attach_AFP > 0,1,0) + IF(Attach_HDMF > 0,1,0) + IF(Attach_PWD > 0,1,0) + IF(Attach_DSWD > 0,1,0) + IF(Attach_ACR > 0,1,0) + IF(Attach_DTI_Business > 0,1,0) + IF(Attach_IBP > 0,1,0) + IF(Attach_FireArms > 0,1,0) + IF(Attach_Government > 0,1,0) + IF(Attach_Diplomat > 0,1,0) + IF(Attach_National > 0,1,0) + IF(Attach_Work > 0,1,0) + IF(Attach_GOCC > 0,1,0) + IF(Attach_PLRA > 0,1,0) + IF(Attach_Major > 0,1,0) + IF(Attach_Media > 0,1,0) + IF(Attach_Student > 0,1,0) + IF(Attach_SIRV > 0,1,0) FROM profile_borrowerid WHERE ID_Type = 'B' AND `status` = 'ACTIVE' AND BorrowerID = '{0}' LIMIT 1;", BorrowerID))
            If TotalID > 0 Then
                btnSave.Enabled = True
            End If
        End If

        If txtDocument.Text.ToUpper.Contains("PDC") Or txtDocument.Text.ToUpper.Contains("POST DATED CHECK") Then
            btnPDC.Visible = True
            Dim Checks_Amount As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM check_received WHERE (`status` != 'ACTIVE' OR `status` != 'PENDING') AND check_type = 'R' AND AssetNumber = '{0}';", CreditNumber))
            Dim TotalPayable As Double = DataObject(String.Format("SELECT (gma - rebate) * (Terms - AdvancePayment_Count) FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
            If Checks_Amount >= TotalPayable Then
                cbxComplete.Enabled = True
            Else
                cbxComplete.Enabled = False
            End If
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX13, LabelX10, LabelX1})

            GetTextBoxFontSettings({txtDocument, txtRemarks})

            GetCheckBoxFontSettings({cbxComplete, cbxIncomplete})

            GetDateTimeInputFontSettings({dtpReceived})

            GetButtonFontSettings({btnAttach, btnPDC, btnSave, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Requirements - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Requirements-" & DocID
            .Type = DocID
            .TotalImage = TotalImage
            .CreditNumber = CreditNumber
            .ID = CreditNumber
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                btnSave.Enabled = True
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub FrmRequirements_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    'LEAVE
    Private Sub CbxComplete_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxComplete.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxIncomplete.Focus()
        End If
    End Sub

    Private Sub CbxIncomplete_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxIncomplete.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub CbxComplete_CheckedChanged(sender As Object, e As EventArgs) Handles cbxComplete.CheckedChanged
        If cbxComplete.Checked Then
            cbxIncomplete.Checked = False
        End If
    End Sub

    Private Sub CbxIncomplete_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIncomplete.CheckedChanged
        If cbxIncomplete.Checked Then
            cbxComplete.Checked = False
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            dtpReceived.Value = Date.Now
            txtRemarks.Text = ""
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If cbxComplete.Checked = False And cbxIncomplete.Checked = False Then
                MsgBox("Please select either this document is fully complete or not.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE submit_documents SET "
                SQL &= String.Format("doc_id = '{0}', ", DocID)
                SQL &= String.Format("document = '{0}', ", txtDocument.Text)
                SQL &= String.Format("Attach = '{0}', ", TotalImage)
                SQL &= String.Format("date_received = '{0}', ", Format(dtpReceived.Value, "yyyy-MM-dd"))
                SQL &= String.Format("is_complete = '{0}', ", If(cbxComplete.Checked, "YES", "NO"))
                SQL &= String.Format("received_code = '{0}', ", User_Code)
                SQL &= String.Format("received_by = '{0}', ", Empl_Name)
                SQL &= String.Format("remarks = '{0}'", txtRemarks.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                Logs("Requirements Attach", "Update", String.Format("Update documents/attachment for {0}", txtDocument.Text), "", "", "", CreditNumber)
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged
        If txtDocument.Text.ToUpper.Contains("INSURANCE") Then
            If txtRemarks.Text.ToUpper.Contains("DEDUCTED") And TotalImage = 0 Then
                btnSave.Enabled = True
            ElseIf TotalImage = 0 Then
                'btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Sub BtnPDC_Click(sender As Object, e As EventArgs) Handles btnPDC.Click
        Dim PDC As New FrmPDCReceipt
        With PDC
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .CreditNumber = CreditNumber
            If .ShowDialog = DialogResult.OK Then
                Dim Checks_Amount As Double = DataObject(String.Format("SELECT SUM(Amount) FROM check_received WHERE (`status` != 'ACTIVE' OR `status` != 'PENDING') AND check_type = 'R' AND AssetNumber = '{0}';", CreditNumber))
                Dim TotalPayable As Double = DataObject(String.Format("SELECT (gma - rebate) * (Terms - AdvancePayment_Count) FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
                If Checks_Amount >= TotalPayable Then
                    cbxComplete.Enabled = True
                Else
                    cbxComplete.Enabled = False
                End If
                btnSave.Enabled = True
            End If
            .Dispose()
        End With
    End Sub
End Class