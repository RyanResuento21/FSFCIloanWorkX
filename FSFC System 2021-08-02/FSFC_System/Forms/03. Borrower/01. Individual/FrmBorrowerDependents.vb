Public Class FrmBorrowerDependents

    '*** D A T A   S T O R A G E ***'
    Dim vMiddleN_1 As String
    Dim vLastN_1 As String
    Dim vSuffix_1 As String
    Dim vGrade_1 As String
    Dim vSchool_1 As String
    Dim vSchoolAddress_1 As String

    Dim vPrefix_2 As String
    Dim vFirstN_2 As String
    Dim vMiddleN_2 As String
    Dim vLastN_2 As String
    Dim vSuffix_2 As String
    Dim vGrade_2 As String
    Dim vSchool_2 As String
    Dim vSchoolAddress_2 As String

    Dim vPrefix_3 As String
    Dim vFirstN_3 As String
    Dim vMiddleN_3 As String
    Dim vLastN_3 As String
    Dim vSuffix_3 As String
    Dim vGrade_3 As String
    Dim vSchool_3 As String
    Dim vSchoolAddress_3 As String

    Dim vPrefix_4 As String
    Dim vFirstN_4 As String
    Dim vMiddleN_4 As String
    Dim vLastN_4 As String
    Dim vSuffix_4 As String
    Dim vGrade_4 As String
    Dim vSchool_4 As String
    Dim vSchoolAddress_4 As String
    '*** D A T A   S T O R A G E ***'
    Private Sub FrmBorrowerDependents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        With CbxPrefix_1
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_2
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_3
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_4
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_1
            .ValueMember = "ID"
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_2
            .ValueMember = "ID"
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_3
            .ValueMember = "ID"
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_4
            .ValueMember = "ID"
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With FrmBorrower
            CbxPrefix_1.Text = .Prefix_1
            cbxSuffix_1.Text = .Suffix_1
            CbxPrefix_2.Text = .Prefix_2
            cbxSuffix_2.Text = .Suffix_2
            CbxPrefix_3.Text = .Prefix_3
            cbxSuffix_3.Text = .Suffix_3
            CbxPrefix_4.Text = .Prefix_4
            cbxSuffix_4.Text = .Suffix_4
            If .Birth_1 = "" Then
                DtpBirth_1.Value = Date.Now
                DtpBirth_1.CustomFormat = ""
            Else
                DtpBirth_1.Value = .Birth_1
            End If
            If .Birth_2 = "" Then
                DtpBirth_2.Value = Date.Now
                DtpBirth_2.CustomFormat = ""
            Else
                DtpBirth_2.Value = .Birth_2
            End If
            If .Birth_3 = "" Then
                DtpBirth_3.Value = Date.Now
                DtpBirth_3.CustomFormat = ""
            Else
                DtpBirth_3.Value = .Birth_3
            End If
            If .Birth_4 = "" Then
                DtpBirth_4.Value = Date.Now
                DtpBirth_4.CustomFormat = ""
            Else
                DtpBirth_4.Value = .Birth_4
            End If
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelWithBackgroundFontSettings({LabelX4, LabelX1, LabelX2})

            GetTextBoxFontSettings({TxtFirstN_1, TxtMiddleN_1, TxtLastN_1, txtGrade_1, txtSchool_1, txtSchoolAddress_1, TxtFirstN_2, TxtMiddleN_2, TxtLastN_2, txtGrade_2, txtSchool_2, txtSchoolAddress_2, TxtFirstN_3, TxtMiddleN_3, TxtLastN_3, txtGrade_3, txtSchool_3, txtSchoolAddress_3, TxtFirstN_4, TxtMiddleN_4, TxtLastN_4, txtGrade_4, txtSchool_4, txtSchoolAddress_4})

            GetComboBoxFontSettings({CbxPrefix_1, cbxSuffix_1, CbxPrefix_2, cbxSuffix_2, CbxPrefix_3, cbxSuffix_3, CbxPrefix_4, cbxSuffix_4})

            GetButtonFontSettings({btnDone, btnRefresh, btnCancel})

            GetDateTimeInputFontSettings({DtpBirth_1, DtpBirth_2, DtpBirth_3, DtpBirth_4})
        Catch ex As Exception
            TriggerBugReport("Borrower Dependent - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            '1st Row
            TxtFirstN_1.Text = ""
            TxtMiddleN_1.Text = ""
            TxtLastN_1.Text = ""
            cbxSuffix_1.Text = ""
            DtpBirth_1.CustomFormat = ""
            txtGrade_1.Text = ""
            txtSchool_1.Text = ""
            txtSchoolAddress_1.Text = ""
            '2nd Row
            TxtFirstN_2.Text = ""
            TxtMiddleN_2.Text = ""
            TxtLastN_2.Text = ""
            cbxSuffix_2.Text = ""
            DtpBirth_2.CustomFormat = ""
            txtGrade_2.Text = ""
            txtSchool_2.Text = ""
            txtSchoolAddress_2.Text = ""
            '3rd Row
            TxtFirstN_3.Text = ""
            TxtMiddleN_3.Text = ""
            TxtLastN_3.Text = ""
            cbxSuffix_3.Text = ""
            DtpBirth_3.CustomFormat = ""
            txtGrade_3.Text = ""
            txtSchool_3.Text = ""
            txtSchoolAddress_3.Text = ""
            '4th Row
            TxtFirstN_4.Text = ""
            TxtMiddleN_4.Text = ""
            TxtLastN_4.Text = ""
            cbxSuffix_4.Text = ""
            DtpBirth_4.CustomFormat = ""
            txtGrade_4.Text = ""
            txtSchool_4.Text = ""
            txtSchoolAddress_4.Text = ""
        End If
    End Sub

#Region "Leaves"
    Private Sub CbxPrefix_1_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_1.Leave
        CbxPrefix_1.Text = ReplaceText(CbxPrefix_1.Text)
    End Sub

    Private Sub TxtFirstN_1_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_1.Leave
        TxtFirstN_1.Text = ReplaceText(TxtFirstN_1.Text)
    End Sub

    Private Sub TxtMiddleN_1_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_1.Leave
        TxtMiddleN_1.Text = ReplaceText(TxtMiddleN_1.Text)
    End Sub

    Private Sub TxtLastN_1_Leave(sender As Object, e As EventArgs) Handles TxtLastN_1.Leave
        TxtLastN_1.Text = ReplaceText(TxtLastN_1.Text)
    End Sub

    Private Sub CbxSuffix_1_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_1.Leave
        cbxSuffix_1.Text = ReplaceText(cbxSuffix_1.Text)
    End Sub

    Private Sub TxtGrade_1_Leave(sender As Object, e As EventArgs) Handles txtGrade_1.Leave
        txtGrade_1.Text = ReplaceText(txtGrade_1.Text)
    End Sub

    Private Sub TxtSchool_1_Leave(sender As Object, e As EventArgs) Handles txtSchool_1.Leave
        txtSchool_1.Text = ReplaceText(txtSchool_1.Text)
    End Sub

    Private Sub TxtSchoolAddress_1_Leave(sender As Object, e As EventArgs) Handles txtSchoolAddress_1.Leave
        txtSchoolAddress_1.Text = ReplaceText(txtSchoolAddress_1.Text)
    End Sub

    Private Sub CbxPrefix_2_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_2.Leave
        CbxPrefix_2.Text = ReplaceText(CbxPrefix_2.Text)
    End Sub

    Private Sub TxtFirstN_2_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_2.Leave
        TxtFirstN_2.Text = ReplaceText(TxtFirstN_2.Text)
    End Sub

    Private Sub TxtMiddleN_2_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_2.Leave
        TxtMiddleN_2.Text = ReplaceText(TxtMiddleN_2.Text)
    End Sub

    Private Sub TxtLastN_2_Leave(sender As Object, e As EventArgs) Handles TxtLastN_2.Leave
        TxtLastN_2.Text = ReplaceText(TxtLastN_2.Text)
    End Sub

    Private Sub CbxSuffix_2_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_2.Leave
        cbxSuffix_2.Text = ReplaceText(cbxSuffix_2.Text)
    End Sub

    Private Sub TxtGrade_2_Leave(sender As Object, e As EventArgs) Handles txtGrade_2.Leave
        txtGrade_2.Text = ReplaceText(txtGrade_2.Text)
    End Sub

    Private Sub TxtSchool_2_Leave(sender As Object, e As EventArgs) Handles txtSchool_2.Leave
        txtSchool_2.Text = ReplaceText(txtSchool_2.Text)
    End Sub

    Private Sub TxtSchoolAddress_2_Leave(sender As Object, e As EventArgs) Handles txtSchoolAddress_2.Leave
        txtSchoolAddress_2.Text = ReplaceText(txtSchoolAddress_2.Text)
    End Sub

    Private Sub CbxPrefix_3_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_3.Leave
        CbxPrefix_3.Text = ReplaceText(CbxPrefix_3.Text)
    End Sub

    Private Sub TxtFirstN_3_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_3.Leave
        TxtFirstN_3.Text = ReplaceText(TxtFirstN_3.Text)
    End Sub

    Private Sub TxtMiddleN_3_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_3.Leave
        TxtMiddleN_3.Text = ReplaceText(TxtMiddleN_3.Text)
    End Sub

    Private Sub TxtLastN_3_Leave(sender As Object, e As EventArgs) Handles TxtLastN_3.Leave
        TxtLastN_3.Text = ReplaceText(TxtLastN_3.Text)
    End Sub

    Private Sub CbxSuffix_3_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_3.Leave
        cbxSuffix_3.Text = ReplaceText(cbxSuffix_3.Text)
    End Sub

    Private Sub TxtGrade_3_Leave(sender As Object, e As EventArgs) Handles txtGrade_3.Leave
        txtGrade_3.Text = ReplaceText(txtGrade_3.Text)
    End Sub

    Private Sub TxtSchool_3_Leave(sender As Object, e As EventArgs) Handles txtSchool_3.Leave
        txtSchool_3.Text = ReplaceText(txtSchool_3.Text)
    End Sub

    Private Sub TxtSchoolAddress_3_Leave(sender As Object, e As EventArgs) Handles txtSchoolAddress_3.Leave
        txtSchoolAddress_3.Text = ReplaceText(txtSchoolAddress_3.Text)
    End Sub

    Private Sub CbxPrefix_4_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_4.Leave
        CbxPrefix_4.Text = ReplaceText(CbxPrefix_4.Text)
    End Sub

    Private Sub TxtFirstN_4_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_4.Leave
        TxtFirstN_4.Text = ReplaceText(TxtFirstN_4.Text)
    End Sub

    Private Sub TxtMiddleN_4_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_4.Leave
        TxtMiddleN_4.Text = ReplaceText(TxtMiddleN_4.Text)
    End Sub

    Private Sub TxtLastN_4_Leave(sender As Object, e As EventArgs) Handles TxtLastN_4.Leave
        TxtLastN_4.Text = ReplaceText(TxtLastN_4.Text)
    End Sub

    Private Sub CbxSuffix_4_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_4.Leave
        cbxSuffix_4.Text = ReplaceText(cbxSuffix_4.Text)
    End Sub

    Private Sub TxtGrade_4_Leave(sender As Object, e As EventArgs) Handles txtGrade_4.Leave
        txtGrade_4.Text = ReplaceText(txtGrade_4.Text)
    End Sub

    Private Sub TxtSchool_4_Leave(sender As Object, e As EventArgs) Handles txtSchool_4.Leave
        txtSchool_4.Text = ReplaceText(txtSchool_4.Text)
    End Sub

    Private Sub TxtSchoolAddress_4_Leave(sender As Object, e As EventArgs) Handles txtSchoolAddress_4.Leave
        txtSchoolAddress_4.Text = ReplaceText(txtSchoolAddress_4.Text)
    End Sub
#End Region

    Private Sub Name_1_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_1.TextChanged
        If TxtFirstN_1.Text.Trim = "" Then
            DtpBirth_1.CustomFormat = ""
            TxtMiddleN_1.Enabled = False
            TxtLastN_1.Enabled = False
            cbxSuffix_1.Enabled = False
            DtpBirth_1.Enabled = False
            txtGrade_1.Enabled = False
            txtSchool_1.Enabled = False
            txtSchoolAddress_1.Enabled = False
            CbxPrefix_2.Enabled = False
            TxtFirstN_2.Enabled = False

            vMiddleN_1 = TxtMiddleN_1.Text
            vLastN_1 = TxtLastN_1.Text
            vSuffix_1 = cbxSuffix_1.Text
            vGrade_1 = txtGrade_1.Text
            vSchool_1 = txtSchool_1.Text
            vSchoolAddress_1 = txtSchoolAddress_1.Text
            vPrefix_2 = CbxPrefix_2.Text
            vFirstN_2 = TxtFirstN_2.Text

            TxtMiddleN_1.Text = ""
            TxtLastN_1.Text = ""
            cbxSuffix_1.Text = ""
            txtGrade_1.Text = ""
            txtSchool_1.Text = ""
            txtSchoolAddress_1.Text = ""
            CbxPrefix_2.Text = ""
            TxtFirstN_2.Text = ""
        Else
            DtpBirth_1.CustomFormat = "MMM. dd, yyyy"
            TxtMiddleN_1.Enabled = True
            TxtLastN_1.Enabled = True
            cbxSuffix_1.Enabled = True
            DtpBirth_1.Enabled = True
            txtGrade_1.Enabled = True
            txtSchool_1.Enabled = True
            txtSchoolAddress_1.Enabled = True
            CbxPrefix_2.Enabled = True
            TxtFirstN_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vMiddleN_1 = "" And vLastN_1 = "" And vSuffix_1 = "" And vGrade_1 = "" And vSchool_1 = "" And vSchoolAddress_1 = "" And vPrefix_2 = "" And vFirstN_2 = "" Then
            Else

                If TxtMiddleN_1.Text = "" Then
                    TxtMiddleN_1.Text = vMiddleN_1
                End If
                If TxtLastN_1.Text = "" Then
                    TxtLastN_1.Text = vLastN_1
                End If
                If cbxSuffix_1.Text = "" Then
                    cbxSuffix_1.Text = vSuffix_1
                End If
                If txtGrade_1.Text = "" Then
                    txtGrade_1.Text = vGrade_1
                End If
                If txtSchool_1.Text = "" Then
                    txtSchool_1.Text = vSchool_1
                End If
                If txtSchoolAddress_1.Text = "" Then
                    txtSchoolAddress_1.Text = vSchoolAddress_1
                End If
                If CbxPrefix_2.Text = "" Then
                    CbxPrefix_2.Text = vPrefix_2
                End If
                If TxtFirstN_2.Text = "" Then
                    TxtFirstN_2.Text = vFirstN_2
                End If
            End If
        End If
    End Sub

    Private Sub Name_2_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_2.TextChanged
        If TxtFirstN_2.Text.Trim = "" Then
            DtpBirth_2.CustomFormat = ""
            TxtMiddleN_2.Enabled = False
            TxtLastN_2.Enabled = False
            cbxSuffix_2.Enabled = False
            DtpBirth_2.Enabled = False
            txtGrade_2.Enabled = False
            txtSchool_2.Enabled = False
            txtSchoolAddress_2.Enabled = False
            CbxPrefix_3.Enabled = False
            TxtFirstN_3.Enabled = False

            vMiddleN_2 = TxtMiddleN_2.Text
            vLastN_2 = TxtLastN_2.Text
            vSuffix_2 = cbxSuffix_2.Text
            vGrade_2 = txtGrade_2.Text
            vSchool_2 = txtSchool_2.Text
            vSchoolAddress_2 = txtSchoolAddress_2.Text
            vPrefix_3 = CbxPrefix_3.Text
            vFirstN_3 = TxtFirstN_3.Text

            TxtMiddleN_2.Text = ""
            TxtLastN_2.Text = ""
            cbxSuffix_2.Text = ""
            txtGrade_2.Text = ""
            txtSchool_2.Text = ""
            txtSchoolAddress_2.Text = ""
            CbxPrefix_3.Text = ""
            TxtFirstN_3.Text = ""
        Else
            DtpBirth_2.CustomFormat = "MMM. dd, yyyy"
            TxtMiddleN_2.Enabled = True
            TxtLastN_2.Enabled = True
            cbxSuffix_2.Enabled = True
            DtpBirth_2.Enabled = True
            txtGrade_2.Enabled = True
            txtSchool_2.Enabled = True
            txtSchoolAddress_2.Enabled = True
            CbxPrefix_3.Enabled = True
            TxtFirstN_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vMiddleN_2 = "" And vLastN_2 = "" And vSuffix_2 = "" And vGrade_2 = "" And vSchool_2 = "" And vSchoolAddress_2 = "" And vPrefix_3 = "" And vFirstN_3 = "" Then
            Else
                If TxtMiddleN_2.Text = "" Then
                    TxtMiddleN_2.Text = vMiddleN_2
                End If
                If TxtLastN_2.Text = "" Then
                    TxtLastN_2.Text = vLastN_2
                End If
                If cbxSuffix_2.Text = "" Then
                    cbxSuffix_2.Text = vSuffix_2
                End If
                If txtGrade_2.Text = "" Then
                    txtGrade_2.Text = vGrade_2
                End If
                If txtSchool_2.Text = "" Then
                    txtSchool_2.Text = vSchool_2
                End If
                If txtSchoolAddress_2.Text = "" Then
                    txtSchoolAddress_2.Text = vSchoolAddress_2
                End If
                If CbxPrefix_3.Text = "" Then
                    CbxPrefix_3.Text = vPrefix_3
                End If
                If TxtFirstN_3.Text = "" Then
                    TxtFirstN_3.Text = vFirstN_3
                End If
            End If
        End If
    End Sub

    Private Sub Name_3_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_3.TextChanged
        If TxtFirstN_3.Text.Trim = "" Then
            DtpBirth_3.CustomFormat = ""
            TxtMiddleN_3.Enabled = False
            TxtLastN_3.Enabled = False
            cbxSuffix_3.Enabled = False
            DtpBirth_3.Enabled = False
            txtGrade_3.Enabled = False
            txtSchool_3.Enabled = False
            txtSchoolAddress_3.Enabled = False
            CbxPrefix_4.Enabled = False
            TxtFirstN_4.Enabled = False

            vMiddleN_3 = TxtMiddleN_3.Text
            vLastN_3 = TxtLastN_3.Text
            vSuffix_3 = cbxSuffix_3.Text
            vGrade_3 = txtGrade_3.Text
            vSchool_3 = txtSchool_3.Text
            vSchoolAddress_3 = txtSchoolAddress_3.Text
            vPrefix_4 = CbxPrefix_4.Text
            vFirstN_4 = TxtFirstN_4.Text

            TxtMiddleN_3.Text = ""
            TxtLastN_3.Text = ""
            cbxSuffix_3.Text = ""
            txtGrade_3.Text = ""
            txtSchool_3.Text = ""
            txtSchoolAddress_3.Text = ""
            CbxPrefix_4.Text = ""
            TxtFirstN_4.Text = ""
        Else
            DtpBirth_3.CustomFormat = "MMM. dd, yyyy"
            TxtMiddleN_3.Enabled = True
            TxtLastN_3.Enabled = True
            cbxSuffix_3.Enabled = True
            DtpBirth_3.Enabled = True
            txtGrade_3.Enabled = True
            txtSchool_3.Enabled = True
            txtSchoolAddress_3.Enabled = True
            CbxPrefix_4.Enabled = True
            TxtFirstN_4.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vMiddleN_3 = "" And vLastN_3 = "" And vSuffix_3 = "" And vGrade_3 = "" And vSchool_3 = "" And vSchoolAddress_3 = "" And vPrefix_4 = "" And vFirstN_4 = "" Then
            Else
                If TxtMiddleN_3.Text = "" Then
                    TxtMiddleN_3.Text = vMiddleN_3
                End If
                If TxtLastN_3.Text = "" Then
                    TxtLastN_3.Text = vLastN_3
                End If
                If cbxSuffix_3.Text = "" Then
                    cbxSuffix_3.Text = vSuffix_3
                End If
                If txtGrade_3.Text = "" Then
                    txtGrade_3.Text = vGrade_3
                End If
                If txtSchool_3.Text = "" Then
                    txtSchool_3.Text = vSchool_3
                End If
                If txtSchoolAddress_3.Text = "" Then
                    txtSchoolAddress_3.Text = vSchoolAddress_3
                End If
                If CbxPrefix_4.Text = "" Then
                    CbxPrefix_4.Text = vPrefix_4
                End If
                If TxtFirstN_4.Text = "" Then
                    TxtFirstN_4.Text = vFirstN_4
                End If
            End If
        End If
    End Sub

    Private Sub Name_4_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_4.TextChanged
        If TxtFirstN_4.Text.Trim = "" Then
            DtpBirth_4.CustomFormat = ""
            TxtMiddleN_4.Enabled = False
            TxtLastN_4.Enabled = False
            cbxSuffix_4.Enabled = False
            DtpBirth_4.Enabled = False
            txtGrade_4.Enabled = False
            txtSchool_4.Enabled = False
            txtSchoolAddress_4.Enabled = False

            vMiddleN_4 = TxtMiddleN_4.Text
            vLastN_4 = TxtLastN_4.Text
            vSuffix_4 = cbxSuffix_4.Text
            vGrade_4 = txtGrade_4.Text
            vSchool_4 = txtSchool_4.Text
            vSchoolAddress_4 = txtSchoolAddress_4.Text

            TxtMiddleN_4.Text = ""
            TxtLastN_4.Text = ""
            cbxSuffix_4.Text = ""
            txtGrade_4.Text = ""
            txtSchool_4.Text = ""
            txtSchoolAddress_4.Text = ""
        Else
            DtpBirth_4.CustomFormat = "MMM. dd, yyyy"
            TxtMiddleN_4.Enabled = True
            TxtLastN_4.Enabled = True
            cbxSuffix_4.Enabled = True
            DtpBirth_4.Enabled = True
            txtGrade_4.Enabled = True
            txtSchool_4.Enabled = True
            txtSchoolAddress_4.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vMiddleN_4 = "" And vLastN_4 = "" And vSuffix_4 = "" And vGrade_4 = "" And vSchool_4 = "" And vSchoolAddress_4 = "" Then
            Else
                If TxtMiddleN_4.Text = "" Then
                    TxtMiddleN_4.Text = vMiddleN_4
                End If
                If TxtLastN_4.Text = "" Then
                    TxtLastN_4.Text = vLastN_4
                End If
                If cbxSuffix_4.Text = "" Then
                    cbxSuffix_4.Text = vSuffix_4
                End If
                If txtGrade_4.Text = "" Then
                    txtGrade_4.Text = vGrade_4
                End If
                If txtSchool_4.Text = "" Then
                    txtSchool_4.Text = vSchool_4
                End If
                If txtSchoolAddress_4.Text = "" Then
                    txtSchoolAddress_4.Text = vSchoolAddress_4
                End If
            End If
        End If
    End Sub

#Region "Keydown"
    Private Sub TxtFirstN_1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_1.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_1.Focus()
        End If
    End Sub

    Private Sub TxtLastN_1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_1.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_1.Focus()
        End If
    End Sub

    Private Sub DtpBirth_1_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGrade_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_1.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGrade_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrade_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchool_1.Focus()
        End If
    End Sub

    Private Sub TxtSchool_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchool_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchoolAddress_1.Focus()
        End If
    End Sub

    Private Sub TxtSchoolAddress_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchoolAddress_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_2.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_2.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_2.Focus()
        End If
    End Sub

    Private Sub TxtLastN_2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_2.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_2.Focus()
        End If
    End Sub

    Private Sub DtpBirth_2_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGrade_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_2.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGrade_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrade_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchool_2.Focus()
        End If
    End Sub

    Private Sub TxtSchool_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchool_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchoolAddress_2.Focus()
        End If
    End Sub

    Private Sub TxtSchoolAddress_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchoolAddress_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_3.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_3.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_3.Focus()
        End If
    End Sub

    Private Sub TxtLastN_3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_3.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_3.Focus()
        End If
    End Sub

    Private Sub DtpBirth_3_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGrade_3.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_3.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGrade_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrade_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchool_3.Focus()
        End If
    End Sub

    Private Sub TxtSchool_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchool_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchoolAddress_3.Focus()
        End If
    End Sub

    Private Sub TxtSchoolAddress_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchoolAddress_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_4.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_4.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_4.Focus()
        End If
    End Sub

    Private Sub TxtLastN_4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_4.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_4_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_4.Focus()
        End If
    End Sub

    Private Sub DtpBirth_4_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGrade_4.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_4.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtGrade_4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrade_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchool_4.Focus()
        End If
    End Sub

    Private Sub TxtSchool_4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchool_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSchoolAddress_4.Focus()
        End If
    End Sub

    Private Sub TxtSchoolAddress_4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSchoolAddress_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnDone.Focus()
        End If
    End Sub
#End Region

    Private Sub FrmBorrowerDependents_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnDone.Focus()
            btnDone.PerformClick()
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

    Private Sub BtnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
            With FrmBorrower
                .Prefix_1 = CbxPrefix_1.Text
                .FirstN_1 = TxtFirstN_1.Text
                .MiddleN_1 = TxtMiddleN_1.Text
                .LastN_1 = TxtLastN_1.Text
                .Suffix_1 = cbxSuffix_1.Text
                .Birth_1 = FormatDatePicker(DtpBirth_1)
                .Grade_1 = txtGrade_1.Text
                .School_1 = txtSchool_1.Text
                .SchoolAddress_1 = txtSchoolAddress_1.Text
                .Prefix_2 = CbxPrefix_2.Text
                .FirstN_2 = TxtFirstN_2.Text
                .MiddleN_2 = TxtMiddleN_2.Text
                .LastN_2 = TxtLastN_2.Text
                .Suffix_2 = cbxSuffix_2.Text
                .Birth_2 = FormatDatePicker(DtpBirth_2)
                .Grade_2 = txtGrade_2.Text
                .School_2 = txtSchool_2.Text
                .SchoolAddress_2 = txtSchoolAddress_2.Text
                .Prefix_3 = CbxPrefix_3.Text
                .FirstN_3 = TxtFirstN_3.Text
                .MiddleN_3 = TxtMiddleN_3.Text
                .LastN_3 = TxtLastN_3.Text
                .Suffix_3 = cbxSuffix_3.Text
                .Birth_3 = FormatDatePicker(DtpBirth_3)
                .Grade_3 = txtGrade_3.Text
                .School_3 = txtSchool_3.Text
                .SchoolAddress_3 = txtSchoolAddress_3.Text
                .Prefix_4 = CbxPrefix_4.Text
                .FirstN_4 = TxtFirstN_4.Text
                .MiddleN_4 = TxtMiddleN_4.Text
                .LastN_4 = TxtLastN_4.Text
                .Suffix_4 = cbxSuffix_4.Text
                .Birth_4 = FormatDatePicker(DtpBirth_4)
                .Grade_4 = txtGrade_4.Text
                .School_4 = txtSchool_4.Text
                .SchoolAddress_4 = txtSchoolAddress_4.Text
            End With

            Close()
        End If
    End Sub

    Private Sub DtpBirth_1_Click(sender As Object, e As EventArgs) Handles DtpBirth_1.Click
        DtpBirth_1.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpBirth_2_Click(sender As Object, e As EventArgs) Handles DtpBirth_2.Click
        DtpBirth_2.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpBirth_3_Click(sender As Object, e As EventArgs) Handles DtpBirth_3.Click
        DtpBirth_3.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpBirth_4_Click(sender As Object, e As EventArgs) Handles DtpBirth_4.Click
        DtpBirth_4.CustomFormat = "MMM. dd, yyyy"
    End Sub
End Class