Public Class FrmROPOAReferral 

    Public ID As Integer
    Public AssetNumber As String
    Dim FirstLoad As Boolean
    Public vAgent As Integer
    Public vMarketing As Integer
    Public vDealer As Integer
    Private Sub FrmROPOA_Referral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxAgentName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' ORDER BY `Name` DESC;", Branch_ID))
            If cbxAgent.Checked Then
                .SelectedValue = vAgent
                FirstLoad = False
                CbxAgentName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxMarketingName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource("SELECT ID, emp_code, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), IF(Last_Name = '','',Last_Name)) AS 'Name', Phone FROM employee_setup WHERE `status` = 'ACTIVE' ORDER BY `Name`;")
            If cbxMarketing.Checked Then
                .SelectedValue = vMarketing
                FirstLoad = False
                CbxMarketingName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxDealerName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_dealer WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY `Name` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If cbxDealer.Checked Then
                .SelectedValue = vDealer
                FirstLoad = False
                CbxDealerName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelWithBackgroundFontSettings({LabelX3})

            GetTextBoxFontSettings({txtAgentContact, txtMarketingContact, txtDealersContact})

            GetCheckBoxFontSettings({cbxAgent, cbxMarketing, cbxDealer})

            GetComboBoxFontSettings({cbxAgentName, cbxMarketingName, cbxDealerName})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("ROPA Refereral - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxAgent_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgent.CheckedChanged
        If cbxAgent.Checked Then
            cbxAgentName.Enabled = True
            txtAgentContact.Enabled = True
            cbxMarketing.Checked = False
            cbxDealer.Checked = False
        Else
            cbxAgentName.Enabled = False
            cbxAgentName.Text = ""
            txtAgentContact.Enabled = False
            txtAgentContact.Text = ""
        End If
    End Sub

    Private Sub CbxMarketing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarketing.CheckedChanged
        If cbxMarketing.Checked Then
            cbxMarketingName.Enabled = True
            txtMarketingContact.Enabled = True
            cbxAgent.Checked = False
            cbxDealer.Checked = False
        Else
            cbxMarketingName.Enabled = False
            cbxMarketingName.Text = ""
            txtMarketingContact.Enabled = False
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxDealer_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDealer.CheckedChanged
        If cbxDealer.Checked Then
            cbxDealerName.Enabled = True
            txtDealersContact.Enabled = True
            cbxAgent.Checked = False
            cbxMarketing.Checked = False
        Else
            cbxDealerName.Enabled = False
            cbxDealerName.Text = ""
            txtDealersContact.Enabled = False
            txtDealersContact.Text = ""
        End If
    End Sub

    Private Sub CbxAgentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAgentName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAgentName.SelectedIndex = -1 Or cbxAgentName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxAgentName.SelectedItem, DataRowView)
            txtAgentContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxMarketingName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMarketingName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxMarketingName.SelectedIndex = -1 Or cbxMarketingName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxMarketingName.SelectedItem, DataRowView)
            txtMarketingContact.Text = drv("Phone")
        End If
    End Sub

    Private Sub CbxDealerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDealerName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxDealerName.SelectedIndex = -1 Or cbxDealerName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxDealerName.SelectedItem, DataRowView)
            txtDealersContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxAgent_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgent.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgentName.Focus()
        End If
    End Sub

    Private Sub CbxAgentName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAgentContact.Focus()
        End If
    End Sub

    Private Sub TxtAgentContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAgentContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketing.Focus()
        End If
    End Sub

    Private Sub CbxMarketing_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketing.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketingName.Focus()
        End If
    End Sub

    Private Sub CbxMarketingName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketingName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMarketingContact.Focus()
        End If
    End Sub

    Private Sub TxtMarketingContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarketingContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealer.Focus()
        End If
    End Sub

    Private Sub CbxDealer_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealer.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealerName.Focus()
        End If
    End Sub

    Private Sub CbxDealerName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDealersContact.Focus()
        End If
    End Sub

    Private Sub TxtDealersContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDealersContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmROPOA_Referral_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
            Dim Referral As String = ""
            Dim Referral_ID As Integer = 0
            If cbxAgent.Checked Then
                Referral = "A"
                Referral_ID = ValidateComboBox(cbxAgentName)
            ElseIf cbxMarketing.Checked Then
                Referral = "M"
                Referral_ID = ValidateComboBox(cbxMarketingName)
            ElseIf cbxDealer.Checked Then
                Referral = "D"
                Referral_ID = ValidateComboBox(cbxDealerName)
            End If

            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE sold_ropoa SET"
                SQL &= String.Format(" Referral = '{0}', ", Referral)
                SQL &= String.Format(" Referral_ID = '{0}' ", Referral_ID)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                DataObject(SQL)
                Logs("ROPOA Referral", "Update", String.Format("Update ROPOA Referral Information for Asset Number {0}", AssetNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")

                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxAgentName.Text = cbxAgentName.Tag Then
            Else
                Change &= String.Format("Change Agent from {0} to {1}. ", cbxAgentName.Tag, cbxAgentName.Text)
            End If
            If cbxMarketingName.Text = cbxMarketingName.Tag Then
            Else
                Change &= String.Format("Change Marketing from {0} to {1}. ", cbxMarketingName.Tag, cbxMarketingName.Text)
            End If
            If cbxDealerName.Text = cbxDealerName.Tag Then
            Else
                Change &= String.Format("Change Dealer from {0} to {1}. ", cbxDealerName.Tag, cbxDealerName.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("ROPA Referral - Changes", ex.Message.ToString)
        End Try
        Return Change
    End Function
End Class