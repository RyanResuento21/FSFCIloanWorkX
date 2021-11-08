Public Class FrmROPOABuyer 

    Public ID As Integer
    Public AssetNumber As String

    Public vPrefix As String
    Public vSuffix As String
    Public vAddress As String
    Private Sub FrmROPOA_Buyer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With CbxPrefix_B
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .Text = vPrefix
        End With

        With cbxSuffix_B
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .Text = vSuffix
        End With

        With cbxAddressC_B
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .Text = vAddress
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX6, LabelX4})

            GetLabelWithBackgroundFontSettings({LabelX3})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtNoC_B, txtStreetC_B, txtBarangayC_B, txtPlus63, txtContact_B})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxAddressC_B})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("ROPA Buyer - FixUI", ex.Message.ToString)
        End Try
    End Sub

    '***Keydown
    Private Sub CbxPrefix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_B.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_B.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_B.Focus()
        End If
    End Sub

    Private Sub TxtLastN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_B.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_B.Focus()
        End If
    End Sub

    Private Sub TxtNoC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_B.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_B.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_B.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_B.Focus()
        End If
    End Sub

    Private Sub TxtContact_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    '***Leave
    Private Sub CbxPrefix_B_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_B.Leave
        CbxPrefix_B.Text = ReplaceText(CbxPrefix_B.Text)
    End Sub

    Private Sub TxtFirstN_B_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_B.Leave
        TxtFirstN_B.Text = ReplaceText(TxtFirstN_B.Text)
    End Sub

    Private Sub TxtMiddleN_B_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_B.Leave
        TxtMiddleN_B.Text = ReplaceText(TxtMiddleN_B.Text)
    End Sub

    Private Sub TxtLastN_B_Leave(sender As Object, e As EventArgs) Handles TxtLastN_B.Leave
        TxtLastN_B.Text = ReplaceText(TxtLastN_B.Text)
    End Sub

    Private Sub CbxSuffix_B_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_B.Leave
        cbxSuffix_B.Text = ReplaceText(cbxSuffix_B.Text)
    End Sub

    Private Sub TxtNoC_B_Leave(sender As Object, e As EventArgs) Handles txtNoC_B.Leave
        txtNoC_B.Text = ReplaceText(txtNoC_B.Text)
    End Sub

    Private Sub TxtStreetC_B_Leave(sender As Object, e As EventArgs) Handles txtStreetC_B.Leave
        txtStreetC_B.Text = ReplaceText(txtStreetC_B.Text)
    End Sub

    Private Sub TxtBarangayC_B_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_B.Leave
        txtBarangayC_B.Text = ReplaceText(txtBarangayC_B.Text)
    End Sub

    Private Sub CbxAddressC_B_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_B.Leave
        cbxAddressC_B.Text = ReplaceText(cbxAddressC_B.Text)
    End Sub

    Private Sub TxtMobile_B_Leave(sender As Object, e As EventArgs)
        txtContact_B.Text = ReplaceText(txtContact_B.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmROPOA_Buer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
            If TxtFirstN_B.Text = "" Then
                MsgBox("Please fill Buyer's First Name field.", MsgBoxStyle.Information, "Info")
                TxtFirstN_B.Focus()
                Exit Sub
            End If
            If TxtLastN_B.Text = "" Then
                MsgBox("Please fill Buyer's Last Name field.", MsgBoxStyle.Information, "Info")
                TxtLastN_B.Focus()
                Exit Sub
            End If

            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE sold_ropoa SET"
                SQL &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" NoC_B = '{0}', ", txtNoC_B.Text)
                SQL &= String.Format(" StreetC_B = '{0}', ", txtStreetC_B.Text)
                SQL &= String.Format(" BarangayC_B = '{0}', ", txtBarangayC_B.Text)
                SQL &= String.Format(" AddressC_B = '{0}', ", cbxAddressC_B.Text)
                SQL &= String.Format(" Contact_N = '{0}' WHERE ID = '{1}';", txtContact_B.Text, ID)

                DataObject(SQL)
                Logs("Buyer Info", "Update", String.Format("Update buyer info for asset number {0}", AssetNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")

                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxPrefix_B.Text = CbxPrefix_B.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", CbxPrefix_B.Tag, CbxPrefix_B.Text)
            End If
            If TxtFirstN_B.Text = TxtFirstN_B.Tag Then
            Else
                Change &= String.Format("Change First Name from {0} to {1}. ", TxtFirstN_B.Tag, TxtFirstN_B.Text)
            End If
            If TxtMiddleN_B.Text = TxtMiddleN_B.Tag Then
            Else
                Change &= String.Format("Change Middle Name from {0} to {1}. ", TxtMiddleN_B.Tag, TxtMiddleN_B.Text)
            End If
            If TxtLastN_B.Text = TxtLastN_B.Tag Then
            Else
                Change &= String.Format("Change Last Name from {0} to {1}. ", TxtLastN_B.Tag, TxtLastN_B.Text)
            End If
            If cbxSuffix_B.Text = cbxSuffix_B.Tag Then
            Else
                Change &= String.Format("Change Suffix from {0} to {1}. ", cbxSuffix_B.Tag, cbxSuffix_B.Text)
            End If
            If txtNoC_B.Text = txtNoC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address No from {0} to {1}. ", txtNoC_B.Tag, txtNoC_B.Text)
            End If
            If txtStreetC_B.Text = txtStreetC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address Street from {0} to {1}. ", txtStreetC_B.Tag, txtStreetC_B.Text)
            End If
            If txtBarangayC_B.Text = txtBarangayC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address Barangay from {0} to {1}. ", txtBarangayC_B.Tag, txtBarangayC_B.Text)
            End If
            If cbxAddressC_B.Text = cbxAddressC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address from {0} to {1}. ", cbxAddressC_B.Tag, cbxAddressC_B.Text)
            End If
            If txtContact_B.Text = txtContact_B.Tag Then
            Else
                Change &= String.Format("Change Contact from {0} to {1}. ", txtContact_B.Tag, txtContact_B.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("ROPA Buyer - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function
End Class