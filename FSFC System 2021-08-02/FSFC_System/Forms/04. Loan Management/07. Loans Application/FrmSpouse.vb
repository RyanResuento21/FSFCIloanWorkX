Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmSpouse

    '**************CoBorrower1 Info
    Dim vRent_S As Double

    Dim vEmpAddress_S As String
    Dim vEmpTelephone_S As String
    Dim vPosition_S As String
    Dim vCasual_S As Boolean
    Dim vTemporary_S As Boolean
    Dim vPermanent_S As Boolean
    Dim vSupervisor_S As String
    Dim vSalary_S As Double

    Dim vBusinessAddress_S As String
    Dim vBusinessTelephone_S As String
    Dim vNatureBusiness_S As String
    Dim vYrsOperation_S As Integer
    Dim vBusinessIncome_S As Double
    Dim vNoEmployees_S As Integer
    Dim vCapital_S As Double
    Dim vArea_S As String
    Dim vOutlet_S As Integer
    Dim vOtherIncome_S As String

    Dim vOtherIncomeD_S As Double
    '**************CoBorrower1 Info

    Public BorrowerID As String
    Public BorrowerName As String
    Public CreditNumber As String
    Public LoanAmount As Double
    Public Borrower_Branch As String = Branch_Code
    Dim ChangeSpousePic As Boolean

    Dim FileName As String
    Dim FirstLoad As Boolean = True
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public SpouseID As String
    Public TotalImage As Integer
    Public FromCreditApplication As Boolean = True
    Private Sub FrmSpouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_S.Size = New Point(255, 254)
        pb_S.Location = New Point(892, 6)
        cbxNatureBusiness_S2.Size = New Point(182, 24)
        cbxNatureBusiness_S2.Location = New Point(142, 125)
        FirstLoad = True

        If TxtFirstN_S.Text = "" Then
            DefaultImage.Image = pb_S.Image.Clone
            DtpBirth_S.Value = Date.Now
            dtpHired_S.Value = Date.Now
            dtpHired_S.CustomFormat = ""
            dtpExpiry_S.Value = Date.Now
            dtpExpiry_S.CustomFormat = ""
            btnID.Enabled = False
        End If

        With CbxPrefix_S
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
        End With

        With cbxSuffix_S
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
        End With

        With CbxPrefix_M
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
        End With

        With cbxSuffix_M
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
        End With

        With cbxAddressC_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxAddressP_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxPlaceBirth_S
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
        End With

        With cbxPosition_S
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
        End With

        With cbxEmployer_S
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
        End With

        With cbxNatureBusiness_S2
            .Properties.LookAndFeel.SkinName = "Blue"
            For x As Integer = 0 To DT_Industry.Rows.Count - 1
                .Properties.Items.Add(DT_Industry(x)("ID"), DT_Industry(x)("Nature"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
        End With
        If TxtFirstN_S.Text = "" Then
            CbxPrefix_S.SelectedIndex = -1
            cbxSuffix_S.SelectedIndex = -1
            CbxPrefix_M.SelectedIndex = -1
            cbxSuffix_M.SelectedIndex = -1
            cbxAddressC_S.SelectedIndex = -1
            cbxAddressP_S.SelectedIndex = -1
            cbxPlaceBirth_S.SelectedIndex = -1
            cbxPosition_S.SelectedIndex = -1
            cbxEmployer_S.SelectedIndex = -1
            If FromCreditApplication Then
                cbxAddressC_S.Text = FrmLoanApplication.cbxAddressC_B.Text
                cbxAddressP_S.Text = FrmLoanApplication.cbxAddressP_B.Text
            Else
                cbxAddressC_S.Text = FrmCreditInvestigation.cbxAddressC_B.Text
            End If
        Else
            If FromCreditApplication Then
                With FrmLoanApplication
                    CbxPrefix_S.Text = .vPrefix_S
                    cbxSuffix_S.Text = .vSuffix_S
                    CbxPrefix_M.Text = .vPrefix_M
                    cbxSuffix_M.Text = .vSuffix_M
                    If .vAddressC_S = "" Then
                        cbxAddressC_S.Text = .cbxAddressC_B.Text
                    Else
                        cbxAddressC_S.Text = .vAddressC_S
                    End If
                    If .vAddressP_S = "" Then
                        cbxAddressP_S.Text = .cbxAddressP_B.Text
                    Else
                        cbxAddressP_S.Text = .vAddressP_S
                    End If
                    cbxPlaceBirth_S.Text = .vPlaceBirth_S
                    cbxEmployer_S.Text = .vEmployer_S
                    cbxPosition_S.Text = .vPosition_S
                End With
            Else
                With FrmCreditInvestigation
                    CbxPrefix_S.Text = .vPrefix_S
                    cbxSuffix_S.Text = .vSuffix_S
                    CbxPrefix_M.Text = .vPrefix_M
                    cbxSuffix_M.Text = .vSuffix_M
                    If .vAddressC_S = "" Then
                        cbxAddressC_S.Text = .cbxAddressC_B.Text
                    Else
                        cbxAddressC_S.Text = .vAddressC_S
                    End If
                    cbxAddressP_S.Text = .vAddressP_S
                    cbxPlaceBirth_S.Text = .vPlaceBirth_S
                    cbxEmployer_S.Text = .vEmployer_S
                    cbxPosition_S.Text = .vPosition_S
                End With
            End If
            cbxNatureBusiness_S2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM credit_application_industry WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}' AND `Type` = 'Spouse'", CreditNumber)))
        End If
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

            GetLabelFontSettings({LabelX2})

            GetLabelFontSettings({LabelX44})

            GetLabelWithBackgroundFontSettings({LabelX41, LabelX89})

            GetLabelFontSettings({LabelX58, LabelX190, LabelX57, LabelX56, LabelX53, LabelX52, LabelX49, LabelX50, LabelX55, LabelX54, LabelX45, LabelX48, LabelX47, LabelX46, LabelX106, LabelX107, LabelX108, LabelX110, LabelX111, LabelX112, LabelX109, LabelX105, LabelX102, LabelX103, LabelX104, LabelX101, LabelX100, LabelX97, LabelX99, LabelX98, LabelX96, LabelX95, LabelX94, LabelX93, LabelX92})

            GetTextBoxFontSettings({txtBusinessName_S, TxtFirstN_S, TxtMiddleN_S, TxtLastN_S, TxtFirstN_M, TxtMiddleN_M, TxtLastN_M, txtNoC_S, txtStreetC_S, txtBarangayC_S, txtNoP_S, txtStreetP_S, txtBarangayP_S, txtCitizenship_S, txtTelephone_S, txtPlus63, txtMobile_S, txtTIN_S, txtSSS_S, txtEmail_S, txtPath_S, txtEmployerAddress_S, txtEmployerTelephone_S, txtSupervisor_S, txtBusinessAddress_S, txtBusinessTelephone_S, txtArea_S, txtOtherIncome_S})

            GetComboBoxFontSettings({CbxPrefix_S, cbxSuffix_S, CbxPrefix_M, cbxSuffix_M, cbxAddressC_S, cbxAddressP_S, cbxPlaceBirth_S, cbxEmployer_S, cbxPosition_S, cbxNatureBusiness_S})

            GetCheckComboBoxFontSettings({cbxNatureBusiness_S2})

            GetCheckBoxFontSettings({cbxMale_S, cbxFemale_S, cbxOwned_S, cbxFree_S, cbxRented_S, cbxCasual_S, cbxTemporary_S, cbxPermanent_S, cbxYearHired_S})

            GetDateTimeInputFontSettings({DtpBirth_S, dtpHired_S, dtpExpiry_S})

            GetIntegerInputFontSettings({iNoEmployees_S, iYrsOperation_S, iOutlet_S})

            GetDoubleInputFontSettings({dOtherIncome_S, dCapital_S, dBusinessIncome_S, dMonthly_S, dRent_S})

            GetButtonFontSettings({btnID, btnBrowse_S, btnDefault, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach})
        Catch ex As Exception
            TriggerBugReport("Spouse - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Spouse", lblTitle.Text)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        With cbxNatureBusiness_S2
            For x As Integer = 0 To .Properties.Items.Count - 1
                .Properties.Items.Item(x).CheckState = CheckState.Unchecked
            Next
        End With

        'CoMaker 1
        CbxPrefix_S.Text = ""
        TxtFirstN_S.Text = ""
        TxtMiddleN_S.Text = ""
        TxtLastN_S.Text = ""
        cbxSuffix_S.Text = ""
        CbxPrefix_M.Text = ""
        TxtFirstN_M.Text = ""
        TxtMiddleN_M.Text = ""
        TxtLastN_M.Text = ""
        cbxSuffix_M.Text = ""
        txtNoC_S.Text = ""
        txtStreetC_S.Text = ""
        txtBarangayC_S.Text = ""
        cbxAddressC_S.Text = ""
        txtNoP_S.Text = ""
        txtStreetP_S.Text = ""
        txtBarangayP_S.Text = ""
        cbxAddressP_S.Text = ""
        DtpBirth_S.CustomFormat = ""
        cbxPlaceBirth_S.Text = ""
        cbxMale_S.Checked = False
        cbxFemale_S.Checked = False
        txtCitizenship_S.Text = ""
        txtTIN_S.Text = ""
        txtTelephone_S.Text = ""
        txtSSS_S.Text = ""
        txtMobile_S.Text = ""
        txtEmail_S.Text = ""
        cbxOwned_S.Checked = False
        cbxFree_S.Checked = False
        cbxRented_S.Checked = False
        Try
            pb_S.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_S.Image = Nothing
        End Try
        cbxEmployer_S.Text = ""
        txtBusinessName_S.Text = ""
        ChangeSpousePic = False
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
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

    '***COBORROWER 1
    Private Sub CbxEmployer_S_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployer_S.TextChanged
        If cbxEmployer_S.Text.Trim = "" Then
            txtEmployerAddress_S.Enabled = False
            txtEmployerTelephone_S.Enabled = False
            cbxPosition_S.Enabled = False
            cbxCasual_S.Enabled = False
            cbxTemporary_S.Enabled = False
            cbxPermanent_S.Enabled = False
            dtpHired_S.Enabled = False
            dtpHired_S.CustomFormat = ""
            txtSupervisor_S.Enabled = False
            dMonthly_S.Enabled = False
            cbxYearHired_S.Enabled = False
            cbxYearHired_S.Checked = False

            vEmpAddress_S = txtEmployerAddress_S.Text
            vEmpTelephone_S = txtEmployerTelephone_S.Text
            vPosition_S = cbxPosition_S.Text
            vCasual_S = cbxCasual_S.Checked
            vTemporary_S = cbxTemporary_S.Checked
            vPermanent_S = cbxPermanent_S.Checked
            vSupervisor_S = txtSupervisor_S.Text
            vSalary_S = dMonthly_S.Value

            txtEmployerAddress_S.Text = ""
            txtEmployerTelephone_S.Text = ""
            cbxPosition_S.Text = ""
            cbxCasual_S.Checked = False
            cbxTemporary_S.Checked = False
            cbxPermanent_S.Checked = False
            txtSupervisor_S.Text = ""
            dMonthly_S.Value = 0
        Else
            txtEmployerAddress_S.Enabled = True
            txtEmployerTelephone_S.Enabled = True
            cbxPosition_S.Enabled = True
            cbxCasual_S.Enabled = True
            cbxTemporary_S.Enabled = True
            cbxPermanent_S.Enabled = True
            dtpHired_S.Enabled = True
            If cbxYearHired_S.Checked Then
                dtpHired_S.CustomFormat = "yyyy"
            Else
                dtpHired_S.CustomFormat = "MMMM dd, yyyy"
            End If
            txtSupervisor_S.Enabled = True
            dMonthly_S.Enabled = True
            cbxYearHired_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vEmpAddress_S = "" And vEmpTelephone_S = "" And vPosition_S = "" And vSupervisor_S = "" And vSalary_S = 0 Then
            Else
                If txtEmployerAddress_S.Text = "" Then
                    txtEmployerAddress_S.Text = vEmpAddress_S
                End If
                If txtEmployerTelephone_S.Text = "" Then
                    txtEmployerTelephone_S.Text = vEmpTelephone_S
                End If
                If cbxPosition_S.Text = "" Then
                    cbxPosition_S.Text = vPosition_S
                End If
                If cbxCasual_S.Checked = False Then
                    cbxCasual_S.Checked = vCasual_S
                End If
                If cbxTemporary_S.Checked = False Then
                    cbxTemporary_S.Checked = vTemporary_S
                End If
                If cbxPermanent_S.Checked = False Then
                    cbxPermanent_S.Checked = vPermanent_S
                End If
                If txtSupervisor_S.Text = "" Then
                    txtSupervisor_S.Text = vSupervisor_S
                End If
                If dMonthly_S.Value = 0 Then
                    dMonthly_S.Value = vSalary_S
                End If
            End If
        End If
    End Sub

    Private Sub TxtBusinessName_S_TextChanged(sender As Object, e As EventArgs) Handles txtBusinessName_S.TextChanged
        If txtBusinessName_S.Text.Trim = "" Then
            txtBusinessAddress_S.Enabled = False
            txtBusinessTelephone_S.Enabled = False
            cbxNatureBusiness_S.Enabled = False
            cbxNatureBusiness_S2.Enabled = False
            iYrsOperation_S.Enabled = False
            dBusinessIncome_S.Enabled = False
            iNoEmployees_S.Enabled = False
            dCapital_S.Enabled = False
            txtArea_S.Enabled = False
            dtpExpiry_S.Enabled = False
            dtpExpiry_S.CustomFormat = ""
            iOutlet_S.Enabled = False
            txtOtherIncome_S.Enabled = False

            vBusinessAddress_S = txtBusinessAddress_S.Text
            vBusinessTelephone_S = txtBusinessTelephone_S.Text
            vNatureBusiness_S = cbxNatureBusiness_S.Text
            vYrsOperation_S = iYrsOperation_S.Value
            vBusinessIncome_S = dBusinessIncome_S.Value
            vNoEmployees_S = iNoEmployees_S.Value
            vCapital_S = dCapital_S.Value
            vArea_S = txtArea_S.Text
            vOutlet_S = iOutlet_S.Value
            vOtherIncome_S = txtOtherIncome_S.Text

            txtBusinessAddress_S.Text = ""
            txtBusinessTelephone_S.Text = ""
            cbxNatureBusiness_S.Text = ""
            iYrsOperation_S.Value = 0
            dBusinessIncome_S.Value = 0
            iNoEmployees_S.Value = 0
            dCapital_S.Value = 0
            txtArea_S.Text = ""
            iOutlet_S.Value = 0
            txtOtherIncome_S.Text = ""
        Else
            txtBusinessAddress_S.Enabled = True
            txtBusinessTelephone_S.Enabled = True
            cbxNatureBusiness_S.Enabled = True
            cbxNatureBusiness_S2.Enabled = True
            iYrsOperation_S.Enabled = True
            dBusinessIncome_S.Enabled = True
            iNoEmployees_S.Enabled = True
            dCapital_S.Enabled = True
            txtArea_S.Enabled = True
            dtpExpiry_S.Enabled = True
            dtpExpiry_S.CustomFormat = "MMMM dd, yyyy"
            iOutlet_S.Enabled = True
            txtOtherIncome_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBusinessAddress_S = "" And vBusinessTelephone_S = "" And vNatureBusiness_S = "" And vYrsOperation_S = 0 And vBusinessIncome_S = 0 And vNoEmployees_S = 0 And vCapital_S = 0 And vArea_S = "" And vOutlet_S = 0 And vOtherIncome_S = "" Then
            Else
                If txtBusinessAddress_S.Text = "" Then
                    txtBusinessAddress_S.Text = vBusinessAddress_S
                End If
                If txtBusinessTelephone_S.Text = "" Then
                    txtBusinessTelephone_S.Text = vBusinessTelephone_S
                End If
                If cbxNatureBusiness_S.Text = "" Then
                    cbxNatureBusiness_S.Text = vNatureBusiness_S
                End If
                If iYrsOperation_S.Value = 0 Then
                    iYrsOperation_S.Value = vYrsOperation_S
                End If
                If dBusinessIncome_S.Value = 0 Then
                    dBusinessIncome_S.Value = vBusinessIncome_S
                End If
                If iNoEmployees_S.Value = 0 Then
                    iNoEmployees_S.Value = vNoEmployees_S
                End If
                If dCapital_S.Value = 0 Then
                    dCapital_S.Value = vCapital_S
                End If
                If txtArea_S.Text = "" Then
                    txtArea_S.Text = vArea_S
                End If
                If iOutlet_S.Value = 0 Then
                    iOutlet_S.Value = vOutlet_S
                End If
                If txtOtherIncome_S.Text = "" Then
                    txtOtherIncome_S.Text = vOtherIncome_S
                End If
            End If
        End If
    End Sub

    Private Sub TxtOtherIncome_S_TextChanged(sender As Object, e As EventArgs) Handles txtOtherIncome_S.TextChanged
        If txtOtherIncome_S.Text.Trim = "" Then
            dOtherIncome_S.Enabled = False

            vOtherIncomeD_S = dOtherIncome_S.Value

            dOtherIncome_S.Value = 0
        Else
            dOtherIncome_S.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vOtherIncomeD_S = 0 Then
            Else
                If dOtherIncome_S.Value = 0 Then
                    dOtherIncome_S.Value = vOtherIncomeD_S
                End If
            End If
        End If
    End Sub

    Private Sub CbxPlaceBirth_S_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlaceBirth_S.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPlaceBirth_S.SelectedItem, DataRowView)
        txtCitizenship_S.Text = DataObject(String.Format("SELECT nationality FROM country WHERE ID = '{0}'", drv("Country ID")))
    End Sub

    '*** LEAVE
    Private Sub CbxPrefix_S_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_S.Leave
        CbxPrefix_S.Text = ReplaceText(CbxPrefix_S.Text.Trim)
    End Sub

    Private Sub TxtFirstN_S_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_S.Leave
        TxtFirstN_S.Text = ReplaceText(TxtFirstN_S.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_S_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_S.Leave
        TxtMiddleN_S.Text = ReplaceText(TxtMiddleN_S.Text.Trim)
    End Sub

    Private Sub TxtLastN_S_Leave(sender As Object, e As EventArgs) Handles TxtLastN_S.Leave
        TxtLastN_S.Text = ReplaceText(TxtLastN_S.Text.Trim)
    End Sub

    Private Sub CbxSuffix_S_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_S.Leave
        cbxSuffix_S.Text = ReplaceText(cbxSuffix_S.Text.Trim)
    End Sub

    Private Sub CbxPrefix_M_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_M.Leave
        CbxPrefix_M.Text = ReplaceText(CbxPrefix_M.Text.Trim)
    End Sub

    Private Sub TxtFirstN_M_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_M.Leave
        TxtFirstN_M.Text = ReplaceText(TxtFirstN_M.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_M_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_M.Leave
        TxtMiddleN_M.Text = ReplaceText(TxtMiddleN_M.Text.Trim)
    End Sub

    Private Sub TxtLastN_M_Leave(sender As Object, e As EventArgs) Handles TxtLastN_M.Leave
        TxtLastN_M.Text = ReplaceText(TxtLastN_M.Text.Trim)
    End Sub

    Private Sub CbxSuffix_M_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_M.Leave
        cbxSuffix_M.Text = ReplaceText(cbxSuffix_M.Text.Trim)
    End Sub

    Private Sub TxtNoC_S_Leave(sender As Object, e As EventArgs) Handles txtNoC_S.Leave
        txtNoC_S.Text = ReplaceText(txtNoC_S.Text.Trim)
    End Sub

    Private Sub TxtStreetC_S_Leave(sender As Object, e As EventArgs) Handles txtStreetC_S.Leave
        txtStreetC_S.Text = ReplaceText(txtStreetC_S.Text.Trim)
    End Sub

    Private Sub TxtBarangayC_S_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_S.Leave
        txtBarangayC_S.Text = ReplaceText(txtBarangayC_S.Text.Trim)
    End Sub

    Private Sub CbxAddressC_S_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_S.Leave
        cbxAddressC_S.Text = ReplaceText(cbxAddressC_S.Text.Trim)
    End Sub

    Private Sub TxtNoP_S_Leave(sender As Object, e As EventArgs) Handles txtNoP_S.Leave
        txtNoP_S.Text = ReplaceText(txtNoP_S.Text.Trim)
    End Sub

    Private Sub TxtStreetP_S_Leave(sender As Object, e As EventArgs) Handles txtStreetP_S.Leave
        txtStreetP_S.Text = ReplaceText(txtStreetP_S.Text.Trim)
    End Sub

    Private Sub TxtBarangayP_S_Leave(sender As Object, e As EventArgs) Handles txtBarangayP_S.Leave
        txtBarangayP_S.Text = ReplaceText(txtBarangayP_S.Text.Trim)
    End Sub

    Private Sub CbxAddressP_S_Leave(sender As Object, e As EventArgs) Handles cbxAddressP_S.Leave
        cbxAddressP_S.Text = ReplaceText(cbxAddressP_S.Text.Trim)
    End Sub

    Private Sub CbxPlaceBirth_S_Leave(sender As Object, e As EventArgs) Handles cbxPlaceBirth_S.Leave
        cbxPlaceBirth_S.Text = ReplaceText(cbxPlaceBirth_S.Text.Trim)
    End Sub

    Private Sub TxtCitizenship_S_Leave(sender As Object, e As EventArgs) Handles txtCitizenship_S.Leave
        txtCitizenship_S.Text = ReplaceText(txtCitizenship_S.Text.Trim)
    End Sub

    Private Sub TxtTIN_S_Leave(sender As Object, e As EventArgs) Handles txtTIN_S.Leave
        txtTIN_S.Text = ReplaceText(txtTIN_S.Text.Trim)
        If (txtTIN_S.Text.Length <> 9 And txtTIN_S.Text.Length > 0) Or (Not IsNumeric(txtTIN_S.Text) And txtTIN_S.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_S.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtTelephone_S.Leave
        txtTelephone_S.Text = ReplaceText(txtTelephone_S.Text.Trim)
    End Sub

    Private Sub TxtSSS_S_Leave(sender As Object, e As EventArgs) Handles txtSSS_S.Leave
        txtSSS_S.Text = ReplaceText(txtSSS_S.Text.Trim)
        If (txtSSS_S.Text.Length <> 10 And txtSSS_S.Text.Length > 0) Or (Not IsNumeric(txtSSS_S.Text) And txtSSS_S.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_S.Focus()
        End If
    End Sub

    Private Sub TxtMobile_S_Leave(sender As Object, e As EventArgs) Handles txtMobile_S.Leave
        txtMobile_S.Text = ReplaceText(txtMobile_S.Text.Trim)
    End Sub

    Private Sub TxtEmail_S_Leave(sender As Object, e As EventArgs) Handles txtEmail_S.Leave
        txtEmail_S.Text = ReplaceText(txtEmail_S.Text.Trim)
    End Sub

    Private Sub CbxEmployer_S_Leave(sender As Object, e As EventArgs) Handles cbxEmployer_S.Leave
        cbxEmployer_S.Text = ReplaceText(cbxEmployer_S.Text.Trim)
    End Sub

    Private Sub TxtEmployerAddress_S_Leave(sender As Object, e As EventArgs) Handles txtEmployerAddress_S.Leave
        txtEmployerAddress_S.Text = ReplaceText(txtEmployerAddress_S.Text.Trim)
    End Sub

    Private Sub TxtEmployerTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtEmployerTelephone_S.Leave
        txtEmployerTelephone_S.Text = ReplaceText(txtEmployerTelephone_S.Text.Trim)
    End Sub

    Private Sub CbxPosition_S_Leave(sender As Object, e As EventArgs) Handles cbxPosition_S.Leave
        cbxPosition_S.Text = ReplaceText(cbxPosition_S.Text.Trim)
    End Sub

    Private Sub TxtSupervisor_S_Leave(sender As Object, e As EventArgs) Handles txtSupervisor_S.Leave
        txtSupervisor_S.Text = ReplaceText(txtSupervisor_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessName_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessName_S.Leave
        txtBusinessName_S.Text = ReplaceText(txtBusinessName_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessAddress_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessAddress_S.Leave
        txtBusinessAddress_S.Text = ReplaceText(txtBusinessAddress_S.Text.Trim)
    End Sub

    Private Sub TxtBusinessTelephone_S_Leave(sender As Object, e As EventArgs) Handles txtBusinessTelephone_S.Leave
        txtBusinessTelephone_S.Text = ReplaceText(txtBusinessTelephone_S.Text.Trim)
    End Sub

    Private Sub CbxNatureBusiness_S_Leave(sender As Object, e As EventArgs) Handles cbxNatureBusiness_S.Leave
        cbxNatureBusiness_S.Text = ReplaceText(cbxNatureBusiness_S.Text.Trim)
    End Sub

    Private Sub TxtArea_S_Leave(sender As Object, e As EventArgs) Handles txtArea_S.Leave
        txtArea_S.Text = ReplaceText(txtArea_S.Text.Trim)
    End Sub

    Private Sub TxtOtherIncome_S_Leave(sender As Object, e As EventArgs) Handles txtOtherIncome_S.Leave
        txtOtherIncome_S.Text = ReplaceText(txtOtherIncome_S.Text.Trim)
    End Sub

    '*** KEYDOWN
    Private Sub CbxPrefix_S_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_S.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_S.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_S.Focus()
        End If
    End Sub

    Private Sub TxtLastN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_S.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_M.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_M_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_M.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_M.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_M.Focus()
        End If
    End Sub

    Private Sub TxtLastN_M_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_M.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_M_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_M.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_S.Focus()
        End If
    End Sub

    Private Sub TxtNoC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_S.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_S.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_S.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoP_S.Focus()
        End If
    End Sub

    Private Sub TxtNoP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetP_S.Focus()
        End If
    End Sub

    Private Sub TxtStreetP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayP_S.Focus()
        End If
    End Sub

    Private Sub TxtBarangayP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressP_S.Focus()
        End If
    End Sub

    Private Sub CbxAddressP_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressP_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_S.Focus()
        End If
    End Sub

    Private Sub DtpBirth_S_Click(sender As Object, e As EventArgs) Handles DtpBirth_S.Click
        DtpBirth_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpBirth_S_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPlaceBirth_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_S.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxPlaceBirth_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPlaceBirth_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMale_S.Focus()
        End If
    End Sub

    Private Sub CbxMale_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMale_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFemale_S.Focus()
        End If
    End Sub

    Private Sub CbxFemale_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFemale_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCitizenship_S.Focus()
        End If
    End Sub

    Private Sub TxtCitizenship_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCitizenship_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_S.Focus()
        End If
    End Sub

    Private Sub TxtTIN_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_S.Focus()
        End If
    End Sub

    Private Sub TxtSSS_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile_S.Focus()
        End If
    End Sub

    Private Sub TxtMobile_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail_S.Focus()
        End If
    End Sub

    Private Sub TxtEmail_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOwned_S.Focus()
        End If
    End Sub

    Private Sub CbxOwned_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOwned_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFree_S.Focus()
        End If
    End Sub

    Private Sub CbxFree_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFree_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRented_S.Focus()
        End If
    End Sub

    Private Sub CbxRented_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRented_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRent_S.Focus()
        End If
    End Sub

    Private Sub DRent_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dRent_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEmployer_S.Focus()
        End If
    End Sub

    Private Sub CbxEmployer_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployer_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerAddress_S.Focus()
        End If
    End Sub

    Private Sub TxtEmployerAddress_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerAddress_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmployerTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtEmployerTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployerTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPosition_S.Focus()
        End If
    End Sub

    Private Sub CbxPosition_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCasual_S.Focus()
        End If
    End Sub

    Private Sub CbxCasual_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCasual_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTemporary_S.Focus()
        End If
    End Sub

    Private Sub CbxTemporary_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTemporary_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPermanent_S.Focus()
        End If
    End Sub

    Private Sub CbxPermanent_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPermanent_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpHired_S.Focus()
        End If
    End Sub

    Private Sub DtpHired_S_Click(sender As Object, e As EventArgs) Handles dtpHired_S.Click
        'dtpHired_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpHired_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHired_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSupervisor_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpHired_S.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtSupervisor_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupervisor_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMonthly_S.Focus()
        End If
    End Sub

    Private Sub DMonthly_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dMonthly_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessName_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessName_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessName_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessAddress_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessAddress_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessAddress_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusinessTelephone_S.Focus()
        End If
    End Sub

    Private Sub TxtBusinessTelephone_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusinessTelephone_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNatureBusiness_S.Focus()
        End If
    End Sub

    Private Sub CbxNatureBusiness_S_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNatureBusiness_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iYrsOperation_S.Focus()
        End If
    End Sub

    Private Sub IYrsOperation_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iYrsOperation_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBusinessIncome_S.Focus()
        End If
    End Sub

    Private Sub DBusinessIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dBusinessIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iNoEmployees_S.Focus()
        End If
    End Sub

    Private Sub BtnNoEmployees_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iNoEmployees_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCapital_S.Focus()
        End If
    End Sub

    Private Sub DCapital_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dCapital_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtArea_S.Focus()
        End If
    End Sub

    Private Sub TxtArea_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArea_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpExpiry_S.Focus()
        End If
    End Sub

    Private Sub DtpExpiry_S_Click(sender As Object, e As EventArgs) Handles dtpExpiry_S.Click
        dtpExpiry_S.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpExpiry_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            iOutlet_S.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpExpiry_S.CustomFormat = ""
        End If
    End Sub

    Private Sub IOutlet_S_KeyDown(sender As Object, e As KeyEventArgs) Handles iOutlet_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOtherIncome_S.Focus()
        End If
    End Sub

    Private Sub TxtOtherIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOtherIncome_S.Focus()
        End If
    End Sub

    Private Sub DOtherIncome_S_KeyDown(sender As Object, e As KeyEventArgs) Handles dOtherIncome_S.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnBrowse_S_Click(sender As Object, e As EventArgs) Handles btnBrowse_S.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_S.Image.Dispose()
                    txtPath_S.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath_S.Text)
                        ResizeImages(TempPB.Image.Clone, pb_S, 650, 500)
                    End Using
                    ChangeSpousePic = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_S_Click(sender As Object, e As MouseEventArgs) Handles pb_S.Click
        Dim Camera As New FrmCamera
        With Camera
            If .ShowDialog = DialogResult.OK Then
                pb_S.Image = .pb_Picture.Image.Clone
                txtPath_S.Text = "From Camera"
            End If
        End With
    End Sub

    'Spouse
    Private Sub CbxMale_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMale_S.CheckedChanged
        If cbxMale_S.Checked = True Then
            cbxFemale_S.Checked = False
        End If
    End Sub

    Private Sub CbxFemale_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFemale_S.CheckedChanged
        If cbxFemale_S.Checked = True Then
            cbxMale_S.Checked = False
        End If
    End Sub

    Private Sub CbxOwned_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOwned_S.CheckedChanged
        If cbxOwned_S.Checked = True Then
            cbxFree_S.Checked = False
            cbxRented_S.Checked = False

            dRent_S.Enabled = False
        End If
    End Sub

    Private Sub CbxFree_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFree_S.CheckedChanged
        If cbxFree_S.Checked = True Then
            cbxOwned_S.Checked = False
            cbxRented_S.Checked = False

            dRent_S.Enabled = False
        End If
    End Sub

    Private Sub CbxRented_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRented_S.CheckedChanged
        If cbxRented_S.Checked = True Then
            cbxFree_S.Checked = False
            cbxOwned_S.Checked = False

            dRent_S.Enabled = True

            dRent_S.Value = vRent_S
        Else
            dRent_S.Enabled = False

            vRent_S = dRent_S.Value
            dRent_S.Value = 0
        End If
    End Sub

    Private Sub CbxCasual_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCasual_S.CheckedChanged
        If cbxCasual_S.Checked = True Then
            cbxTemporary_S.Checked = False
            cbxPermanent_S.Checked = False
        End If
    End Sub

    Private Sub CbxTemporary_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTemporary_S.CheckedChanged
        If cbxTemporary_S.Checked = True Then
            cbxCasual_S.Checked = False
            cbxPermanent_S.Checked = False
        End If
    End Sub

    Private Sub CbxPermanent_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPermanent_S.CheckedChanged
        If cbxPermanent_S.Checked = True Then
            cbxCasual_S.Checked = False
            cbxTemporary_S.Checked = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update"
            btnSave.Enabled = True
            btnModify.Enabled = False
            If FromCreditApplication Then
                btnDelete.Enabled = True
            End If

            PanelEx5.Enabled = True
            PanelEx8.Enabled = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnDelete.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If SpouseID = "" Then
                Else
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    DataObject(String.Format("UPDATE profile_spouse SET `status` = 'DELETED' WHERE SpouseID = '{0}';", SpouseID))
                    DataObject(String.Format("UPDATE profile_borrowerid  SET `status` = 'DELETED' WHERE BorrowerID = '{0}' AND ID_Type = 'S';", BorrowerID))
                    Logs("Spouse", "Delete", Reason, String.Format("Delete Spouse {0}", If(CbxPrefix_S.Text = "", "", CbxPrefix_S.Text & " ") & If(TxtFirstN_S.Text = "", "", TxtFirstN_S.Text & " ") & If(TxtMiddleN_S.Text = "", "", TxtMiddleN_S.Text & " ") & If(TxtLastN_S.Text = "", "", TxtLastN_S.Text & " ") & If(cbxSuffix_S.Text = "", "", cbxSuffix_S.Text)), BorrowerID, If(CbxPrefix_S.Text = "", "", CbxPrefix_S.Text & " ") & If(TxtFirstN_S.Text = "", "", TxtFirstN_S.Text & " ") & If(TxtMiddleN_S.Text = "", "", TxtMiddleN_S.Text & " ") & If(TxtLastN_S.Text = "", "", TxtLastN_S.Text & " ") & If(cbxSuffix_S.Text = "", "", cbxSuffix_S.Text), CreditNumber)
                End If
                Clear()
                If FromCreditApplication Then
                    DataObject(String.Format("UPDATE credit_application SET Prefix_S = '{1}', FirstN_S = '{2}', MiddleN_S = '{3}', LastN_S = '{4}', Suffix_S = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_S.Text, TxtFirstN_S.Text, TxtMiddleN_S.Text, TxtLastN_S.Text, cbxSuffix_S.Text))
                    With FrmLoanApplication
                        .CbxPrefix_S.Text = CbxPrefix_S.Text
                        .TxtFirstN_S.Text = TxtFirstN_S.Text
                        .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                        .TxtLastN_S.Text = TxtLastN_S.Text
                        .cbxSuffix_S.Text = cbxSuffix_S.Text
                        .CbxPrefix_S.Tag = ""
                        .TxtFirstN_S.Tag = ""
                        .TxtMiddleN_S.Tag = ""
                        .TxtLastN_S.Tag = ""
                        .cbxSuffix_S.Tag = ""

                        .vPrefix_S = CbxPrefix_S.Text
                        .vFirstN_S = TxtFirstN_S.Text
                        .vMiddleN_S = TxtMiddleN_S.Text
                        .vLastN_S = TxtLastN_S.Text
                        .vSuffix_S = cbxSuffix_S.Text
                        .vPrefix_M = CbxPrefix_M.Text
                        .vFirstN_M = TxtFirstN_M.Text
                        .vMiddleN_M = TxtMiddleN_M.Text
                        .vLastN_M = TxtLastN_M.Text
                        .vSuffix_M = cbxSuffix_M.Text
                        .vNoC_S = txtNoC_S.Text
                        .vStreetC_S = txtStreetC_S.Text
                        .vBarangayC_S = txtBarangayC_S.Text
                        .vAddressC_S = cbxAddressC_S.Text
                        .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                        .vNoP_S = txtNoP_S.Text
                        .vStreetP_S = txtStreetP_S.Text
                        .vBarangayP_S = txtBarangayP_S.Text
                        .vAddressP_S = cbxAddressP_S.Text
                        .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                        .vBirth_S = DtpBirth_S.Text
                        .vPlaceBirth_S = cbxPlaceBirth_S.Text
                        .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                        .vMale_S = cbxMale_S.Checked
                        .vFemale_S = cbxFemale_S.Checked
                        .vCitizenship_S = txtCitizenship_S.Text
                        .vTIN_S = txtTIN_S.Text
                        .vTelephone_S = txtTelephone_S.Text
                        .vSSS_S = txtSSS_S.Text
                        .vMobile_S = txtMobile_S.Text
                        .vEmail_S = txtEmail_S.Text
                        .vOwned_S = cbxOwned_S.Checked
                        .vFree_S = cbxFree_S.Checked
                        .vRented_S = cbxRented_S.Checked
                        .vRent_S = dRent_S.Value
                        .vEmployer_S = cbxEmployer_S.Text
                        .vEmpAddress_S = txtEmployerAddress_S.Text
                        .vEmpTelephone_S = txtEmployerTelephone_S.Text
                        .vPosition_S = cbxPosition_S.Text
                        .vCasual_S = cbxCasual_S.Checked
                        .vTemporary_S = cbxTemporary_S.Checked
                        .vPermanent_S = cbxPermanent_S.Checked
                        .vHired_S = dtpHired_S.Value
                        .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                        .vSupervisor_S = txtSupervisor_S.Text
                        .vSalary_S = dMonthly_S.Value
                        .vBusinessName_S = txtBusinessName_S.Text
                        .vBusinessAddress_S = txtBusinessAddress_S.Text
                        .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                        .vNatureBusiness_S = cbxNatureBusiness_S.Text
                        .vYrsOperation_S = iYrsOperation_S.Value
                        .vBusinessIncome_S = dBusinessIncome_S.Value
                        .vNoEmployees_S = iNoEmployees_S.Value
                        .vCapital_S = dCapital_S.Value
                        .vArea_S = txtArea_S.Text
                        .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                        .vOutlet_S = iOutlet_S.Value
                        .vOtherIncome_S = txtOtherIncome_S.Text
                        .vOtherIncomeD_S = dOtherIncome_S.Value
                        .ChangePic1 = False
                    End With
                Else
                    DataObject(String.Format("UPDATE credit_investigation SET Prefix_S = '{1}', FirstN_S = '{2}', MiddleN_S = '{3}', LastN_S = '{4}', Suffix_S = '{5}' WHERE CreditNumber = '{0}';", CreditNumber, CbxPrefix_S.Text, TxtFirstN_S.Text, TxtMiddleN_S.Text, TxtLastN_S.Text, cbxSuffix_S.Text))
                    With FrmCreditInvestigation
                        .CbxPrefix_S.Text = CbxPrefix_S.Text
                        .TxtFirstN_S.Text = TxtFirstN_S.Text
                        .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                        .TxtLastN_S.Text = TxtLastN_S.Text
                        .cbxSuffix_S.Text = cbxSuffix_S.Text
                        .CbxPrefix_S.Tag = ""
                        .TxtFirstN_S.Tag = ""
                        .TxtMiddleN_S.Tag = ""
                        .TxtLastN_S.Tag = ""
                        .cbxSuffix_S.Tag = ""

                        .vPrefix_S = CbxPrefix_S.Text
                        .vFirstN_S = TxtFirstN_S.Text
                        .vMiddleN_S = TxtMiddleN_S.Text
                        .vLastN_S = TxtLastN_S.Text
                        .vSuffix_S = cbxSuffix_S.Text
                        .vPrefix_M = CbxPrefix_M.Text
                        .vFirstN_M = TxtFirstN_M.Text
                        .vMiddleN_M = TxtMiddleN_M.Text
                        .vLastN_M = TxtLastN_M.Text
                        .vSuffix_M = cbxSuffix_M.Text
                        .vNoC_S = txtNoC_S.Text
                        .vStreetC_S = txtStreetC_S.Text
                        .vBarangayC_S = txtBarangayC_S.Text
                        .vAddressC_S = cbxAddressC_S.Text
                        .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                        .vNoP_S = txtNoP_S.Text
                        .vStreetP_S = txtStreetP_S.Text
                        .vBarangayP_S = txtBarangayP_S.Text
                        .vAddressP_S = cbxAddressP_S.Text
                        .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                        .vBirth_S = DtpBirth_S.Text
                        .vPlaceBirth_S = cbxPlaceBirth_S.Text
                        .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                        .vMale_S = cbxMale_S.Checked
                        .vFemale_S = cbxFemale_S.Checked
                        .vCitizenship_S = txtCitizenship_S.Text
                        .vTIN_S = txtTIN_S.Text
                        .vTelephone_S = txtTelephone_S.Text
                        .vSSS_S = txtSSS_S.Text
                        .vMobile_S = txtMobile_S.Text
                        .vEmail_S = txtEmail_S.Text
                        .vOwned_S = cbxOwned_S.Checked
                        .vFree_S = cbxFree_S.Checked
                        .vRented_S = cbxRented_S.Checked
                        .vRent_S = dRent_S.Value
                        .vEmployer_S = cbxEmployer_S.Text
                        .vEmpAddress_S = txtEmployerAddress_S.Text
                        .vEmpTelephone_S = txtEmployerTelephone_S.Text
                        .vPosition_S = cbxPosition_S.Text
                        .vCasual_S = cbxCasual_S.Checked
                        .vTemporary_S = cbxTemporary_S.Checked
                        .vPermanent_S = cbxPermanent_S.Checked
                        .vHired_S = dtpHired_S.Value
                        .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                        .vSupervisor_S = txtSupervisor_S.Text
                        .vSalary_S = dMonthly_S.Value
                        .vBusinessName_S = txtBusinessName_S.Text
                        .vBusinessAddress_S = txtBusinessAddress_S.Text
                        .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                        .vNatureBusiness_S = cbxNatureBusiness_S.Text
                        .vYrsOperation_S = iYrsOperation_S.Value
                        .vBusinessIncome_S = dBusinessIncome_S.Value
                        .dSalary_S.Value = dMonthly_S.Value + If(txtBusinessName_S.Text = .txtBusinessName_B.Text, 0, dBusinessIncome_S.Value) + If(txtOtherIncome_S.Text = .txtOtherIncome_B.Text, 0, dOtherIncome_S.Value)
                        .vNoEmployees_S = iNoEmployees_S.Value
                        .vCapital_S = dCapital_S.Value
                        .vArea_S = txtArea_S.Text
                        .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                        .vOutlet_S = iOutlet_S.Value
                        .vOtherIncome_S = txtOtherIncome_S.Text
                        .vOtherIncomeD_S = dOtherIncome_S.Value
                        .ChangePic1 = False
                    End With
                End If

                MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
                If FromCreditApplication Then
                    FrmLoanApplication.LoadData()
                Else
                    FrmCreditInvestigation.LoadData()
                End If
                btnDelete.DialogResult = DialogResult.OK
                btnDelete.PerformClick()
                Cursor = Cursors.Default
                Close()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim CoMaker As New RptCoMakersStatement
        With CoMaker
            .lblLoanNumber.Text = CreditNumber
            .lblAmountWords.Text = ConvertNumberToWords(FrmLoanApplication.dAmountApplied.Value, False, False)
            .lblAmount.Text = FormatNumber(FrmLoanApplication.dAmountApplied.Value, 2)
            .p_CoMaker.Image = pb_S.Image.Clone
            .lblBorrowerID.Text = BorrowerID
            .lblBorrower.Text = BorrowerName
            .lblComaker.Text = If(CbxPrefix_S.Text.Trim = "", "", CbxPrefix_S.Text.Trim & " ") & If(TxtFirstN_S.Text.Trim = "", "", TxtFirstN_S.Text.Trim & " ") & If(TxtMiddleN_S.Text.Trim = "", "", TxtMiddleN_S.Text.Trim & " ") & If(TxtLastN_S.Text.Trim = "", "", TxtLastN_S.Text.Trim & " ") & If(cbxSuffix_S.Text.Trim = "", "", cbxSuffix_S.Text.Trim & " ")
            .lblCompleteAdd.Text = If(txtNoC_S.Text.Trim = "", "", txtNoC_S.Text.Trim & " ") & If(txtStreetC_S.Text.Trim = "", "", txtStreetC_S.Text.Trim & " ") & If(txtBarangayC_S.Text.Trim = "", "", txtBarangayC_S.Text.Trim & " ") & If(cbxAddressC_S.Text.Trim = "", "", cbxAddressC_S.Text.Trim & " ")
            .lblProvincialAdd.Text = If(txtNoP_S.Text.Trim = "", "", txtNoP_S.Text.Trim & " ") & If(txtStreetP_S.Text.Trim = "", "", txtStreetP_S.Text.Trim & " ") & If(txtBarangayP_S.Text.Trim = "", "", txtBarangayP_S.Text.Trim & " ") & If(cbxAddressP_S.Text.Trim = "", "", cbxAddressP_S.Text.Trim & " ")
            .lblBirthDate.Text = DtpBirth_S.Text
            .lblBirthPlace.Text = cbxPlaceBirth_S.Text
            .cbxMale.Checked = cbxMale_S.Checked
            .cbxFemale.Checked = cbxFemale_S.Checked
            .lblCitizenship.Text = txtCitizenship_S.Text
            .lblTIN.Text = txtTIN_S.Text
            .lblTelephone.Text = txtTelephone_S.Text
            .lblSSS.Text = txtSSS_S.Text
            .lblMobile.Text = txtMobile_S.Text
            .lblEmail.Text = txtEmail_S.Text
            .cbxOwned.Checked = cbxOwned_S.Checked
            .cbxFree.Checked = cbxFree_S.Checked
            .cbxRented.Checked = cbxRented_S.Checked
            .lblRent.Text = If(cbxRented_S.Checked, dRent_S.Text & " / month", "")
            .lblEmployer.Text = cbxEmployer_S.Text
            .lblEmployerAddress.Text = txtEmployerAddress_S.Text
            .lblEmployerTel.Text = txtEmployerTelephone_S.Text
            .lblPosition.Text = cbxPosition_S.Text
            .cbxCasual.Checked = cbxCasual_S.Checked
            .cbxTemporary.Checked = cbxTemporary_S.Checked
            .cbxPermanent.Checked = cbxPermanent_S.Checked
            .lblDateHired.Text = dtpHired_S.Text
            .lblSupervisor.Text = txtSupervisor_S.Text
            .lblMonthlyIncome.Text = dMonthly_S.Text
            .lblBusiness.Text = txtBusinessName_S.Text
            .lblBusinessAddress.Text = txtBusinessAddress_S.Text
            .lblBusinessTel.Text = txtBusinessTelephone_S.Text
            .lblNature.Text = cbxNatureBusiness_S.Text
            .lblYearsOperation.Text = iYrsOperation_S.Text
            .lblBusinessIncome.Text = dBusinessIncome_S.Text
            .lblNoEmployees.Text = iNoEmployees_S.Text
            .lblCapital.Text = dCapital_S.Text
            .lblCoverageArea.Text = txtArea_S.Text
            .lblExpiry.Text = dtpExpiry_S.Text
            .lblOutlet.Text = iOutlet_S.Text
            .lblOtherIncome.Text = txtOtherIncome_S.Text
            .lblOtherMonthlyIncome.Text = dOtherIncome_S.Text
            .lblDateSigned.Text = ""
            .lblSignature_1.Text = ""
            .lblSignature_2.Text = ""
            '2nd Copy
            .p_CoMaker_2.Image = pb_S.Image.Clone
            .lblBorrowerID_2.Text = BorrowerID
            .lblComaker_2.Text = If(CbxPrefix_S.Text.Trim = "", "", CbxPrefix_S.Text.Trim & " ") & If(TxtFirstN_S.Text.Trim = "", "", TxtFirstN_S.Text.Trim & " ") & If(TxtMiddleN_S.Text.Trim = "", "", TxtMiddleN_S.Text.Trim & " ") & If(TxtLastN_S.Text.Trim = "", "", TxtLastN_S.Text.Trim & " ") & If(cbxSuffix_S.Text.Trim = "", "", cbxSuffix_S.Text.Trim & " ")
            .lblCompleteAdd_2.Text = If(txtNoC_S.Text.Trim = "", "", txtNoC_S.Text.Trim & " ") & If(txtStreetC_S.Text.Trim = "", "", txtStreetC_S.Text.Trim & " ") & If(txtBarangayC_S.Text.Trim = "", "", txtBarangayC_S.Text.Trim & " ") & If(cbxAddressC_S.Text.Trim = "", "", cbxAddressC_S.Text.Trim & " ")
            .lblProvincialAdd_2.Text = If(txtNoP_S.Text.Trim = "", "", txtNoP_S.Text.Trim & " ") & If(txtStreetP_S.Text.Trim = "", "", txtStreetP_S.Text.Trim & " ") & If(txtBarangayP_S.Text.Trim = "", "", txtBarangayP_S.Text.Trim & " ") & If(cbxAddressP_S.Text.Trim = "", "", cbxAddressP_S.Text.Trim & " ")
            .lblBirthDate_2.Text = DtpBirth_S.Text
            .lblBirthPlace_2.Text = cbxPlaceBirth_S.Text
            .cbxMale_2.Checked = cbxMale_S.Checked
            .cbxFemale_2.Checked = cbxFemale_S.Checked
            .lblCitizenship_2.Text = txtCitizenship_S.Text
            .lblTIN_2.Text = txtTIN_S.Text
            .lblTelephone_2.Text = txtTelephone_S.Text
            .lblSSS_2.Text = txtSSS_S.Text
            .lblMobile_2.Text = txtMobile_S.Text
            .lblEmail_2.Text = txtEmail_S.Text
            .cbxOwned_2.Checked = cbxOwned_S.Checked
            .cbxFree_2.Checked = cbxFree_S.Checked
            .cbxRented_2.Checked = cbxRented_S.Checked
            .lblRent_2.Text = If(cbxRented_S.Checked, dRent_S.Text & " / month", "")
            .lblEmployer_2.Text = cbxEmployer_S.Text
            .lblEmployerAddress_2.Text = txtEmployerAddress_S.Text
            .lblEmployerTel_2.Text = txtEmployerTelephone_S.Text
            .lblPosition_2.Text = cbxPosition_S.Text
            .cbxCasual_2.Checked = cbxCasual_S.Checked
            .cbxTemporary_2.Checked = cbxTemporary_S.Checked
            .cbxPermanent_2.Checked = cbxPermanent_S.Checked
            .lblDateHired_2.Text = dtpHired_S.Text
            .lblSupervisor_2.Text = txtSupervisor_S.Text
            .lblMonthlyIncome_2.Text = dMonthly_S.Text
            .lblBusiness_2.Text = txtBusinessName_S.Text
            .lblBusinessAddress_2.Text = txtBusinessAddress_S.Text
            .lblBusinessTel_2.Text = txtBusinessTelephone_S.Text
            .lblNature_2.Text = cbxNatureBusiness_S.Text
            .lblYearsOperation_2.Text = iYrsOperation_S.Text
            .lblBusinessIncome_2.Text = dBusinessIncome_S.Text
            .lblNoEmployees_2.Text = iNoEmployees_S.Text
            .lblCapital_2.Text = dCapital_S.Text
            .lblCoverageArea_2.Text = txtArea_S.Text
            .lblExpiry_2.Text = dtpExpiry_S.Text
            .lblOutlet_2.Text = iOutlet_S.Text
            .lblOtherIncome_2.Text = txtOtherIncome_S.Text
            .lblOtherMonthlyIncome_2.Text = dOtherIncome_S.Text
            .lblDateSigned_2.Text = ""
            .lblSignature_3.Text = ""
            .lblSignature_4.Text = ""
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.Yes Then
        Else
            If TxtFirstN_S.Text = "" Then
                MsgBox("Please fill the spouse first name.", MsgBoxStyle.Information, "Info")
                TxtFirstN_S.Focus()
                Exit Sub
            End If
            If TxtLastN_S.Text = "" Then
                MsgBox("Please fill the spouse last name.", MsgBoxStyle.Information, "Info")
                TxtLastN_S.Focus()
                Exit Sub
            End If
            If DateValue(DtpBirth_S.Value.AddYears(18)) > DateValue(Date.Now) Then
                If MsgBoxYes("Spouse age is below 18 years old, are you sure you would like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            ElseIf DateValue(DtpBirth_S.Value.AddYears(61)) <= DateValue(Date.Now) Then
                If MsgBoxYes("Spouse age is 61 or above, are you sure you would like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Dim Gender_S As String = ""
            If cbxMale_S.Checked Then
                Gender_S = "Male"
            ElseIf cbxFemale_S.Checked Then
                Gender_S = "Female"
            End If
            Dim House_S As String = ""
            If cbxOwned_S.Checked Then
                House_S = "Owned"
            ElseIf cbxFree_S.Checked Then
                House_S = "Free"
            ElseIf cbxRented_S.Checked Then
                House_S = "Rented"
            End If
            Dim EmplStatus_S As String = ""
            If cbxCasual_S.Checked Then
                EmplStatus_S = "Casual"
            ElseIf cbxTemporary_S.Checked Then
                EmplStatus_S = "Temporary"
            ElseIf cbxPermanent_S.Checked Then
                EmplStatus_S = "Permanent"
            End If

            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    If FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_S.Text = CbxPrefix_S.Text
                            .TxtFirstN_S.Text = TxtFirstN_S.Text
                            .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                            .TxtLastN_S.Text = TxtLastN_S.Text
                            .cbxSuffix_S.Text = cbxSuffix_S.Text

                            .vPrefix_S = CbxPrefix_S.Text
                            .vFirstN_S = TxtFirstN_S.Text
                            .vMiddleN_S = TxtMiddleN_S.Text
                            .vLastN_S = TxtLastN_S.Text
                            .vSuffix_S = cbxSuffix_S.Text
                            .vPrefix_M = CbxPrefix_M.Text
                            .vFirstN_M = TxtFirstN_M.Text
                            .vMiddleN_M = TxtMiddleN_M.Text
                            .vLastN_M = TxtLastN_M.Text
                            .vSuffix_M = cbxSuffix_M.Text
                            .vNoC_S = txtNoC_S.Text
                            .vStreetC_S = txtStreetC_S.Text
                            .vBarangayC_S = txtBarangayC_S.Text
                            .vAddressC_S = cbxAddressC_S.Text
                            .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                            .vNoP_S = txtNoP_S.Text
                            .vStreetP_S = txtStreetP_S.Text
                            .vBarangayP_S = txtBarangayP_S.Text
                            .vAddressP_S = cbxAddressP_S.Text
                            .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                            .vBirth_S = DtpBirth_S.Text
                            .vPlaceBirth_S = cbxPlaceBirth_S.Text
                            .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                            .vMale_S = cbxMale_S.Checked
                            .vFemale_S = cbxFemale_S.Checked
                            .vCitizenship_S = txtCitizenship_S.Text
                            .vTIN_S = txtTIN_S.Text
                            .vTelephone_S = txtTelephone_S.Text
                            .vSSS_S = txtSSS_S.Text
                            .vMobile_S = txtMobile_S.Text
                            .vEmail_S = txtEmail_S.Text
                            .vOwned_S = cbxOwned_S.Checked
                            .vFree_S = cbxFree_S.Checked
                            .vRented_S = cbxRented_S.Checked
                            .vRent_S = dRent_S.Value
                            .pb_Spouse.Image = pb_S.Image.Clone
                            .txtPath_S.Text = txtPath_S.Text
                            .vEmployer_S = cbxEmployer_S.Text
                            .vEmpAddress_S = txtEmployerAddress_S.Text
                            .vEmpTelephone_S = txtEmployerTelephone_S.Text
                            .vPosition_S = cbxPosition_S.Text
                            .vCasual_S = cbxCasual_S.Checked
                            .vTemporary_S = cbxTemporary_S.Checked
                            .vPermanent_S = cbxPermanent_S.Checked
                            .vHired_S = dtpHired_S.Value
                            .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                            .vSupervisor_S = txtSupervisor_S.Text
                            .vSalary_S = dMonthly_S.Value
                            .vBusinessName_S = txtBusinessName_S.Text
                            .vBusinessAddress_S = txtBusinessAddress_S.Text
                            .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                            .vNatureBusiness_S = cbxNatureBusiness_S.Text
                            .vYrsOperation_S = iYrsOperation_S.Value
                            .vBusinessIncome_S = dBusinessIncome_S.Value
                            .vNoEmployees_S = iNoEmployees_S.Value
                            .vCapital_S = dCapital_S.Value
                            .vArea_S = txtArea_S.Text
                            .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                            .vOutlet_S = iOutlet_S.Value
                            .vOtherIncome_S = txtOtherIncome_S.Text
                            .vOtherIncomeD_S = dOtherIncome_S.Value
                            .ChangePic1 = ChangeSpousePic
                            .Industry_S = cbxNatureBusiness_S2
                        End With
                    Else
                        With FrmCreditInvestigation
                            .CbxPrefix_S.Text = CbxPrefix_S.Text
                            .TxtFirstN_S.Text = TxtFirstN_S.Text
                            .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                            .TxtLastN_S.Text = TxtLastN_S.Text
                            .cbxSuffix_S.Text = cbxSuffix_S.Text

                            .vPrefix_S = CbxPrefix_S.Text
                            .vFirstN_S = TxtFirstN_S.Text
                            .vMiddleN_S = TxtMiddleN_S.Text
                            .vLastN_S = TxtLastN_S.Text
                            .vSuffix_S = cbxSuffix_S.Text
                            .vPrefix_M = CbxPrefix_M.Text
                            .vFirstN_M = TxtFirstN_M.Text
                            .vMiddleN_M = TxtMiddleN_M.Text
                            .vLastN_M = TxtLastN_M.Text
                            .vSuffix_M = cbxSuffix_M.Text
                            .vNoC_S = txtNoC_S.Text
                            .vStreetC_S = txtStreetC_S.Text
                            .vBarangayC_S = txtBarangayC_S.Text
                            .vAddressC_S = cbxAddressC_S.Text
                            .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                            .vNoP_S = txtNoP_S.Text
                            .vStreetP_S = txtStreetP_S.Text
                            .vBarangayP_S = txtBarangayP_S.Text
                            .vAddressP_S = cbxAddressP_S.Text
                            .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                            .vBirth_S = DtpBirth_S.Text
                            .vPlaceBirth_S = cbxPlaceBirth_S.Text
                            .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                            .vMale_S = cbxMale_S.Checked
                            .vFemale_S = cbxFemale_S.Checked
                            .vCitizenship_S = txtCitizenship_S.Text
                            .vTIN_S = txtTIN_S.Text
                            .vTelephone_S = txtTelephone_S.Text
                            .vSSS_S = txtSSS_S.Text
                            .vMobile_S = txtMobile_S.Text
                            .vEmail_S = txtEmail_S.Text
                            .vOwned_S = cbxOwned_S.Checked
                            .vFree_S = cbxFree_S.Checked
                            .vRented_S = cbxRented_S.Checked
                            .vRent_S = dRent_S.Value
                            .pb_Spouse.Image = pb_S.Image.Clone
                            .txtPath_S.Text = txtPath_S.Text
                            .vEmployer_S = cbxEmployer_S.Text
                            .vEmpAddress_S = txtEmployerAddress_S.Text
                            .vEmpTelephone_S = txtEmployerTelephone_S.Text
                            .vPosition_S = cbxPosition_S.Text
                            .vCasual_S = cbxCasual_S.Checked
                            .vTemporary_S = cbxTemporary_S.Checked
                            .vPermanent_S = cbxPermanent_S.Checked
                            .vHired_S = dtpHired_S.Value
                            .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                            .vSupervisor_S = txtSupervisor_S.Text
                            .vSalary_S = dMonthly_S.Value
                            .vBusinessName_S = txtBusinessName_S.Text
                            .vBusinessAddress_S = txtBusinessAddress_S.Text
                            .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                            .vNatureBusiness_S = cbxNatureBusiness_S.Text
                            .vYrsOperation_S = iYrsOperation_S.Value
                            .vBusinessIncome_S = dBusinessIncome_S.Value
                            .dSalary_S.Value = dMonthly_S.Value + If(txtBusinessName_S.Text = .txtBusinessName_B.Text, 0, dBusinessIncome_S.Value) + If(txtOtherIncome_S.Text = .txtOtherIncome_B.Text, 0, dOtherIncome_S.Value)
                            .vNoEmployees_S = iNoEmployees_S.Value
                            .vCapital_S = dCapital_S.Value
                            .vArea_S = txtArea_S.Text
                            .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                            .vOutlet_S = iOutlet_S.Value
                            .vOtherIncome_S = txtOtherIncome_S.Text
                            .vOtherIncomeD_S = dOtherIncome_S.Value
                            .ChangePic1 = ChangeSpousePic
                            .Industry_S = cbxNatureBusiness_S2
                        End With
                    End If

                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    If FromCreditApplication Then
                        Close()
                    Else
                        btnSave.DialogResult = DialogResult.Yes
                        btnSave.PerformClick()
                    End If
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    If FromCreditApplication Then
                        With FrmLoanApplication
                            .CbxPrefix_S.Text = CbxPrefix_S.Text
                            .TxtFirstN_S.Text = TxtFirstN_S.Text
                            .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                            .TxtLastN_S.Text = TxtLastN_S.Text
                            .cbxSuffix_S.Text = cbxSuffix_S.Text

                            .vPrefix_S = CbxPrefix_S.Text
                            .vFirstN_S = TxtFirstN_S.Text
                            .vMiddleN_S = TxtMiddleN_S.Text
                            .vLastN_S = TxtLastN_S.Text
                            .vSuffix_S = cbxSuffix_S.Text
                            .vPrefix_M = CbxPrefix_M.Text
                            .vFirstN_M = TxtFirstN_M.Text
                            .vMiddleN_M = TxtMiddleN_M.Text
                            .vLastN_M = TxtLastN_M.Text
                            .vSuffix_M = cbxSuffix_M.Text
                            .vNoC_S = txtNoC_S.Text
                            .vStreetC_S = txtStreetC_S.Text
                            .vBarangayC_S = txtBarangayC_S.Text
                            .vAddressC_S = cbxAddressC_S.Text
                            .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                            .vNoP_S = txtNoP_S.Text
                            .vStreetP_S = txtStreetP_S.Text
                            .vBarangayP_S = txtBarangayP_S.Text
                            .vAddressP_S = cbxAddressP_S.Text
                            .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                            .vBirth_S = DtpBirth_S.Text
                            .vPlaceBirth_S = cbxPlaceBirth_S.Text
                            .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                            .vMale_S = cbxMale_S.Checked
                            .vFemale_S = cbxFemale_S.Checked
                            .vCitizenship_S = txtCitizenship_S.Text
                            .vTIN_S = txtTIN_S.Text
                            .vTelephone_S = txtTelephone_S.Text
                            .vSSS_S = txtSSS_S.Text
                            .vMobile_S = txtMobile_S.Text
                            .vEmail_S = txtEmail_S.Text
                            .vOwned_S = cbxOwned_S.Checked
                            .vFree_S = cbxFree_S.Checked
                            .vRented_S = cbxRented_S.Checked
                            .vRent_S = dRent_S.Value
                            .pb_Spouse.Image = pb_S.Image.Clone
                            .txtPath_S.Text = txtPath_S.Text
                            .vEmployer_S = cbxEmployer_S.Text
                            .vEmpAddress_S = txtEmployerAddress_S.Text
                            .vEmpTelephone_S = txtEmployerTelephone_S.Text
                            .vPosition_S = cbxPosition_S.Text
                            .vCasual_S = cbxCasual_S.Checked
                            .vTemporary_S = cbxTemporary_S.Checked
                            .vPermanent_S = cbxPermanent_S.Checked
                            .vHired_S = dtpHired_S.Value
                            .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                            .vSupervisor_S = txtSupervisor_S.Text
                            .vSalary_S = dMonthly_S.Value
                            .vBusinessName_S = txtBusinessName_S.Text
                            .vBusinessAddress_S = txtBusinessAddress_S.Text
                            .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                            .vNatureBusiness_S = cbxNatureBusiness_S.Text
                            .vYrsOperation_S = iYrsOperation_S.Value
                            .vBusinessIncome_S = dBusinessIncome_S.Value
                            .vNoEmployees_S = iNoEmployees_S.Value
                            .vCapital_S = dCapital_S.Value
                            .vArea_S = txtArea_S.Text
                            .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                            .vOutlet_S = iOutlet_S.Value
                            .vOtherIncome_S = txtOtherIncome_S.Text
                            .vOtherIncomeD_S = dOtherIncome_S.Value
                            .ChangePic1 = ChangeSpousePic
                            .Industry_S = cbxNatureBusiness_S2
                        End With
                    Else
                        With FrmCreditInvestigation
                            .CbxPrefix_S.Text = CbxPrefix_S.Text
                            .TxtFirstN_S.Text = TxtFirstN_S.Text
                            .TxtMiddleN_S.Text = TxtMiddleN_S.Text
                            .TxtLastN_S.Text = TxtLastN_S.Text
                            .cbxSuffix_S.Text = cbxSuffix_S.Text

                            .vPrefix_S = CbxPrefix_S.Text
                            .vFirstN_S = TxtFirstN_S.Text
                            .vMiddleN_S = TxtMiddleN_S.Text
                            .vLastN_S = TxtLastN_S.Text
                            .vSuffix_S = cbxSuffix_S.Text
                            .vPrefix_M = CbxPrefix_M.Text
                            .vFirstN_M = TxtFirstN_M.Text
                            .vMiddleN_M = TxtMiddleN_M.Text
                            .vLastN_M = TxtLastN_M.Text
                            .vSuffix_M = cbxSuffix_M.Text
                            .vNoC_S = txtNoC_S.Text
                            .vStreetC_S = txtStreetC_S.Text
                            .vBarangayC_S = txtBarangayC_S.Text
                            .vAddressC_S = cbxAddressC_S.Text
                            .vAddressC_S_ID = If(cbxAddressC_S.Text = "" Or cbxAddressC_S.SelectedIndex = -1, 0, cbxAddressC_S.SelectedValue)
                            .vNoP_S = txtNoP_S.Text
                            .vStreetP_S = txtStreetP_S.Text
                            .vBarangayP_S = txtBarangayP_S.Text
                            .vAddressP_S = cbxAddressP_S.Text
                            .vAddressP_S_ID = If(cbxAddressP_S.Text = "" Or cbxAddressP_S.SelectedIndex = -1, 0, cbxAddressP_S.SelectedValue)
                            .vBirth_S = DtpBirth_S.Text
                            .vPlaceBirth_S = cbxPlaceBirth_S.Text
                            .vPlaceBirth_S_ID = If(cbxPlaceBirth_S.Text = "" Or cbxPlaceBirth_S.SelectedIndex = -1, 0, cbxPlaceBirth_S.SelectedValue)
                            .vMale_S = cbxMale_S.Checked
                            .vFemale_S = cbxFemale_S.Checked
                            .vCitizenship_S = txtCitizenship_S.Text
                            .vTIN_S = txtTIN_S.Text
                            .vTelephone_S = txtTelephone_S.Text
                            .vSSS_S = txtSSS_S.Text
                            .vMobile_S = txtMobile_S.Text
                            .vEmail_S = txtEmail_S.Text
                            .vOwned_S = cbxOwned_S.Checked
                            .vFree_S = cbxFree_S.Checked
                            .vRented_S = cbxRented_S.Checked
                            .vRent_S = dRent_S.Value
                            .pb_Spouse.Image = pb_S.Image.Clone
                            .txtPath_S.Text = txtPath_S.Text
                            .vEmployer_S = cbxEmployer_S.Text
                            .vEmpAddress_S = txtEmployerAddress_S.Text
                            .vEmpTelephone_S = txtEmployerTelephone_S.Text
                            .vPosition_S = cbxPosition_S.Text
                            .vCasual_S = cbxCasual_S.Checked
                            .vTemporary_S = cbxTemporary_S.Checked
                            .vPermanent_S = cbxPermanent_S.Checked
                            .vHired_S = dtpHired_S.Value
                            .vYearHired_S = If(cbxYearHired_S.Checked, 1, 0)
                            .vSupervisor_S = txtSupervisor_S.Text
                            .vSalary_S = dMonthly_S.Value
                            .vBusinessName_S = txtBusinessName_S.Text
                            .vBusinessAddress_S = txtBusinessAddress_S.Text
                            .vBusinessTelephone_S = txtBusinessTelephone_S.Text
                            .vNatureBusiness_S = cbxNatureBusiness_S.Text
                            .vYrsOperation_S = iYrsOperation_S.Value
                            .vBusinessIncome_S = dBusinessIncome_S.Value
                            .dSalary_S.Value = dMonthly_S.Value + If(txtBusinessName_S.Text = .txtBusinessName_B.Text, 0, dBusinessIncome_S.Value) + If(txtOtherIncome_S.Text = .txtOtherIncome_B.Text, 0, dOtherIncome_S.Value)
                            .vNoEmployees_S = iNoEmployees_S.Value
                            .vCapital_S = dCapital_S.Value
                            .vArea_S = txtArea_S.Text
                            .vExpiry_S = If(dtpExpiry_S.CustomFormat = "", "", dtpExpiry_S.Text)
                            .vOutlet_S = iOutlet_S.Value
                            .vOtherIncome_S = txtOtherIncome_S.Text
                            .vOtherIncomeD_S = dOtherIncome_S.Value
                            .ChangePic1 = ChangeSpousePic
                            .Industry_S = cbxNatureBusiness_S2
                        End With
                    End If

                    If SpouseID = "" Then
                    Else
                        Dim SQL As String = "UPDATE profile_spouse SET"
                        SQL &= String.Format(" Prefix_S = '{0}', ", CbxPrefix_S.Text)
                        SQL &= String.Format(" FirstN_S = '{0}', ", TxtFirstN_S.Text)
                        SQL &= String.Format(" MiddleN_S = '{0}', ", TxtMiddleN_S.Text)
                        SQL &= String.Format(" LastN_S = '{0}', ", TxtLastN_S.Text)
                        SQL &= String.Format(" Suffix_S = '{0}', ", cbxSuffix_S.Text)
                        SQL &= String.Format(" Prefix_M = '{0}', ", CbxPrefix_M.Text)
                        SQL &= String.Format(" FirstN_M = '{0}', ", TxtFirstN_M.Text)
                        SQL &= String.Format(" MiddleN_M = '{0}', ", TxtMiddleN_M.Text)
                        SQL &= String.Format(" LastN_M = '{0}', ", TxtLastN_M.Text)
                        SQL &= String.Format(" Suffix_M = '{0}', ", cbxSuffix_M.Text)
                        SQL &= String.Format(" NoC_S = '{0}', ", txtNoC_S.Text)
                        SQL &= String.Format(" StreetC_S = '{0}', ", txtStreetC_S.Text)
                        SQL &= String.Format(" BarangayC_S = '{0}', ", txtBarangayC_S.Text)
                        SQL &= String.Format(" `AddressC_S-ID` = '{0}', ", ValidateComboBox(cbxAddressC_S))
                        SQL &= String.Format(" AddressC_S = '{0}', ", cbxAddressC_S.Text)
                        SQL &= String.Format(" NoP_S = '{0}', ", txtNoP_S.Text)
                        SQL &= String.Format(" StreetP_S = '{0}', ", txtStreetP_S.Text)
                        SQL &= String.Format(" BarangayP_S = '{0}', ", txtBarangayP_S.Text)
                        SQL &= String.Format(" `AddressP_S-ID` = '{0}', ", ValidateComboBox(cbxAddressP_S))
                        SQL &= String.Format(" AddressP_S = '{0}', ", cbxAddressP_S.Text)
                        SQL &= String.Format(" Birth_S = '{0}', ", FormatDatePicker(DtpBirth_S))
                        SQL &= String.Format(" `PlaceBirth_S-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_S))
                        SQL &= String.Format(" PlaceBirth_S = '{0}', ", cbxPlaceBirth_S.Text)
                        SQL &= String.Format(" Gender_S = '{0}', ", Gender_S)
                        SQL &= String.Format(" Citizenship_S = '{0}', ", txtCitizenship_S.Text)
                        SQL &= String.Format(" TIN_S = '{0}', ", txtTIN_S.Text)
                        SQL &= String.Format(" Telephone_S = '{0}', ", txtTelephone_S.Text)
                        SQL &= String.Format(" SSS_S = '{0}', ", txtSSS_S.Text)
                        SQL &= String.Format(" Mobile_S = '{0}', ", txtMobile_S.Text)
                        SQL &= String.Format(" Email_S = '{0}', ", txtEmail_S.Text)
                        SQL &= String.Format(" House_S = '{0}', ", House_S)
                        SQL &= String.Format(" Rent_S = '{0}', ", dRent_S.Value)
                        SQL &= String.Format(" Employer_S = '{0}', ", cbxEmployer_S.Text)
                        SQL &= String.Format(" EmployerAddress_S = '{0}', ", txtEmployerAddress_S.Text)
                        SQL &= String.Format(" EmployerTelephone_S = '{0}', ", txtEmployerTelephone_S.Text)
                        SQL &= String.Format(" Position_S = '{0}', ", cbxPosition_S.Text)
                        SQL &= String.Format(" EmploymentStat_S = '{0}', ", EmplStatus_S)
                        SQL &= String.Format(" Hired_S = '{0}', ", FormatDatePicker(dtpHired_S))
                        SQL &= String.Format(" Supervisor_S = '{0}', ", txtSupervisor_S.Text)
                        SQL &= String.Format(" Monthly_S = '{0}', ", dMonthly_S.Value)
                        SQL &= String.Format(" BusinessName_S = '{0}', ", txtBusinessName_S.Text)
                        SQL &= String.Format(" BusinessAddress_S = '{0}', ", txtBusinessAddress_S.Text)
                        SQL &= String.Format(" BusinessTelephone_S = '{0}', ", txtBusinessTelephone_S.Text)
                        SQL &= String.Format(" NatureBusiness_S = '{0}', ", cbxNatureBusiness_S.Text)
                        SQL &= String.Format(" YrsOperation_S = '{0}', ", iYrsOperation_S.Value)
                        SQL &= String.Format(" BusinessIncome_S = '{0}', ", dBusinessIncome_S.Value)
                        SQL &= String.Format(" NoEmployees_S = '{0}', ", iNoEmployees_S.Value)
                        SQL &= String.Format(" Capital_S = '{0}', ", dCapital_S.Value)
                        SQL &= String.Format(" Area_S = '{0}', ", txtArea_S.Text)
                        SQL &= String.Format(" Expiry_S = '{0}', ", FormatDatePicker(dtpExpiry_S))
                        SQL &= String.Format(" Outlet_S = '{0}', ", iOutlet_S.Value)
                        SQL &= String.Format(" OtherIncome_S = '{0}', ", txtOtherIncome_S.Text)
                        SQL &= String.Format(" `OtherIncome_S-Amount` = '{0}' ", dOtherIncome_S.Value)
                        SQL &= String.Format(" WHERE SpouseID = '{0}';", SpouseID)

                        SQL &= String.Format("UPDATE credit_application SET Prefix_S = '{0}', FirstN_S = '{1}', MiddleN_S = '{2}', LastN_S = '{3}', Suffix_S = '{4}' WHERE CreditNumber = '{5}';", CbxPrefix_S.Text, TxtFirstN_S.Text, TxtMiddleN_S.Text, TxtLastN_S.Text, cbxSuffix_S.Text, CreditNumber)

                        If txtPath_S.Text <> "" Then
                            SaveImage(pb_S, "Spouse")
                        End If

                        SQL &= String.Format("UPDATE credit_application_industry SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND `Type` = 'Spouse' AND CreditNumber = '{0}';", CreditNumber, "Spouse")
                        For x As Integer = 0 To cbxNatureBusiness_S2.Properties.Items.Count - 1
                            If cbxNatureBusiness_S2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                                SQL &= "INSERT INTO credit_application_industry SET"
                                SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                                SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Value)
                                SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_S2.Properties.Items.Item(x).Description)
                                SQL &= " `Type` = 'Spouse';"
                            End If
                        Next

                        DataObject(SQL)
                        Logs("Spouse", "Update", String.Format("Update Spouse {0}", If(CbxPrefix_S.Text.Trim = "", "", CbxPrefix_S.Text.Trim & " ") & If(TxtFirstN_S.Text.Trim = "", "", TxtFirstN_S.Text.Trim & " ") & If(TxtMiddleN_S.Text.Trim = "", "", TxtMiddleN_S.Text.Trim & " ") & If(TxtLastN_S.Text.Trim = "", "", TxtLastN_S.Text.Trim & " ") & If(cbxSuffix_S.Text.Trim = "", "", cbxSuffix_S.Text.Trim & " ")), Changes(), BorrowerID, If(CbxPrefix_S.Text.Trim = "", "", CbxPrefix_S.Text.Trim & " ") & If(TxtFirstN_S.Text.Trim = "", "", TxtFirstN_S.Text.Trim & " ") & If(TxtMiddleN_S.Text.Trim = "", "", TxtMiddleN_S.Text.Trim & " ") & If(TxtLastN_S.Text.Trim = "", "", TxtLastN_S.Text.Trim & " ") & If(cbxSuffix_S.Text.Trim = "", "", cbxSuffix_S.Text.Trim & " "), CreditNumber)
                        Clear()
                    End If

                    Cursor = Cursors.Default
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    If FromCreditApplication Then
                        Close()
                    Else
                        btnSave.DialogResult = DialogResult.Yes
                        btnSave.PerformClick()
                    End If
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxPrefix_S.Text = CbxPrefix_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Prefix from {0} to {1}. ", CbxPrefix_S.Tag, CbxPrefix_S.Text)
            End If
            If TxtFirstN_S.Text = TxtFirstN_S.Tag Then
            Else
                Change &= String.Format("Change Spouse First Name from {0} to {1}. ", TxtFirstN_S.Tag, TxtFirstN_S.Text)
            End If
            If TxtMiddleN_S.Text = TxtMiddleN_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Middle Name from {0} to {1}. ", TxtMiddleN_S.Tag, TxtMiddleN_S.Text)
            End If
            If TxtLastN_S.Text = TxtLastN_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Last Name from {0} to {1}. ", TxtLastN_S.Tag, TxtLastN_S.Text)
            End If
            If cbxSuffix_S.Text = cbxSuffix_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Suffix from {0} to {1}. ", cbxSuffix_S.Tag, cbxSuffix_S.Text)
            End If
            If CbxPrefix_S.Text = CbxPrefix_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Mother Prefix from {0} to {1}. ", CbxPrefix_S.Tag, CbxPrefix_S.Text)
            End If
            If TxtFirstN_M.Text = TxtFirstN_M.Tag Then
            Else
                Change &= String.Format("Change Spouse Mother First Name from {0} to {1}. ", TxtFirstN_M.Tag, TxtFirstN_M.Text)
            End If
            If TxtMiddleN_M.Text = TxtMiddleN_M.Tag Then
            Else
                Change &= String.Format("Change Spouse Mother Middle Name from {0} to {1}. ", TxtMiddleN_M.Tag, TxtMiddleN_M.Text)
            End If
            If TxtLastN_M.Text = TxtLastN_M.Tag Then
            Else
                Change &= String.Format("Change Spouse Mother Last Name from {0} to {1}. ", TxtLastN_M.Tag, TxtLastN_M.Text)
            End If
            If cbxSuffix_M.Text = cbxSuffix_M.Tag Then
            Else
                Change &= String.Format("Change Spouse Mother Suffix from {0} to {1}. ", cbxSuffix_M.Tag, cbxSuffix_M.Text)
            End If
            If txtNoC_S.Text = txtNoC_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Complete Address No from {0} to {1}. ", txtNoC_S.Tag, txtNoC_S.Text)
            End If
            If txtStreetC_S.Text = txtStreetC_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Complete Address Street from {0} to {1}. ", txtStreetC_S.Tag, txtStreetC_S.Text)
            End If
            If txtBarangayC_S.Text = txtBarangayC_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Complete Address Barangay from {0} to {1}. ", txtBarangayC_S.Tag, txtBarangayC_S.Text)
            End If
            If cbxAddressC_S.Text = cbxAddressC_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Complete Address from {0} to {1}. ", cbxAddressC_S.Tag, cbxAddressC_S.Text)
            End If
            If txtNoP_S.Text = txtNoP_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Provincial Address No  from {0} to {1}. ", txtNoP_S.Tag, txtNoP_S.Text)
            End If
            If txtStreetP_S.Text = txtStreetP_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Provincial Address Street from {0} to {1}. ", txtStreetP_S.Tag, txtStreetP_S.Text)
            End If
            If txtBarangayP_S.Text = txtBarangayP_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Provincial Address Barangay from {0} to {1}. ", txtBarangayP_S.Tag, txtBarangayP_S.Text)
            End If
            If cbxAddressP_S.Text = cbxAddressP_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Provincial Address from {0} to {1}. ", cbxAddressP_S.Tag, cbxAddressP_S.Text)
            End If
            If FormatDatePicker(DtpBirth_S) = DtpBirth_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Birthdate from {0} to {1}. ", DtpBirth_S.Tag, FormatDatePicker(DtpBirth_S))
            End If
            If cbxPlaceBirth_S.Text = cbxPlaceBirth_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Place of Birth from {0} to {1}. ", cbxPlaceBirth_S.Tag, cbxPlaceBirth_S.Text)
            End If
            If cbxMale_S.Tag <> "Male" And cbxMale_S.Checked Then
                Change &= String.Format("Change Spouse Gender from {0} to {1}. ", cbxMale_S.Tag, cbxMale_S.Text)
            ElseIf cbxFemale_S.Tag <> "Female" And cbxFemale_S.Checked Then
                Change &= String.Format("Change Spouse Gender from {0} to {1}. ", cbxFemale_S.Tag, cbxFemale_S.Text)
            End If
            If txtCitizenship_S.Text = txtCitizenship_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Citizenship from {0} to {1}. ", txtCitizenship_S.Tag, txtCitizenship_S.Text)
            End If
            If txtTIN_S.Text = txtTIN_S.Tag Then
            Else
                Change &= String.Format("Change Spouse TIN from {0} to {1}. ", txtTIN_S.Tag, txtTIN_S.Text)
            End If
            If txtTelephone_S.Text = txtTelephone_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Telephone from {0} to {1}. ", txtTelephone_S.Tag, txtTelephone_S.Text)
            End If
            If txtSSS_S.Text = txtSSS_S.Tag Then
            Else
                Change &= String.Format("Change Spouse SSS from {0} to {1}. ", txtSSS_S.Tag, txtSSS_S.Text)
            End If
            If txtMobile_S.Text = txtMobile_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Mobile from {0} to {1}. ", txtMobile_S.Tag, txtMobile_S.Text)
            End If
            If txtEmail_S.Text = txtEmail_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Email from {0} to {1}. ", txtEmail_S.Tag, txtEmail_S.Text)
            End If
            If cbxOwned_S.Tag <> "Owned" And cbxOwned_S.Checked Then
                Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxOwned_S.Tag, cbxOwned_S.Text)
            ElseIf cbxFree_S.Tag <> "Free" And cbxFree_S.Checked Then
                Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxFree_S.Tag, cbxFree_S.Text)
            ElseIf cbxRented_S.Tag <> "Rented" And cbxRented_S.Checked Then
                Change &= String.Format("Change Spouse House from {0} to {1}. ", cbxRented_S.Tag, cbxRented_S.Text)
            End If
            If dRent_S.Value = dRent_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Rent from {0} to {1}. ", dRent_S.Tag, dRent_S.Text)
            End If
            If cbxEmployer_S.Text = cbxEmployer_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Employer from {0} to {1}. ", cbxEmployer_S.Tag, cbxEmployer_S.Text)
            End If
            If txtEmployerAddress_S.Text = txtEmployerAddress_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Employer Address from {0} to {1}. ", txtEmployerAddress_S.Tag, txtEmployerAddress_S.Text)
            End If
            If txtEmployerTelephone_S.Text = txtEmployerTelephone_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Employer Telephone from {0} to {1}. ", txtEmployerTelephone_S.Tag, txtEmployerTelephone_S.Text)
            End If
            If cbxPosition_S.Text = cbxPosition_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Position from {0} to {1}. ", cbxPosition_S.Tag, cbxPosition_S.Text)
            End If
            If cbxCasual_S.Tag.ToString <> "Casual" And cbxCasual_S.Checked Then
                Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxCasual_S.Tag, cbxCasual_S.Text)
            ElseIf cbxTemporary_S.Tag.ToString <> "Temporary" And cbxTemporary_S.Checked Then
                Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxTemporary_S.Tag, cbxTemporary_S.Text)
            ElseIf cbxPermanent_S.Tag.ToString <> "Permanent" And cbxPermanent_S.Checked Then
                Change &= String.Format("Change Spouse Employment Status from {0} to {1}. ", cbxPermanent_S.Tag, cbxPermanent_S.Text)
            End If
            If FormatDatePicker(dtpHired_S) = dtpHired_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Date Hired from {0} to {1}. ", dtpHired_S.Tag, FormatDatePicker(dtpHired_S))
            End If
            If txtSupervisor_S.Text = txtSupervisor_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Supervisor from {0} to {1}. ", txtSupervisor_S.Tag, txtSupervisor_S.Text)
            End If
            If dMonthly_S.Value = dMonthly_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Gross Monthly Income as employed from {0} to {1}. ", dMonthly_S.Tag, dMonthly_S.Text)
            End If
            If txtBusinessName_S.Text = txtBusinessName_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Business Name from {0} to {1}. ", txtBusinessName_S.Tag, txtBusinessName_S.Text)
            End If
            If txtBusinessAddress_S.Text = txtBusinessAddress_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Business Address from {0} to {1}. ", txtBusinessAddress_S.Tag, txtBusinessAddress_S.Text)
            End If
            If txtBusinessTelephone_S.Text = txtBusinessTelephone_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Business Telephone from {0} to {1}. ", txtBusinessTelephone_S.Tag, txtBusinessTelephone_S.Text)
            End If
            If cbxNatureBusiness_S.Text = cbxNatureBusiness_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Nature of Business from {0} to {1}. ", cbxNatureBusiness_S.Tag, cbxNatureBusiness_S.Text)
            End If
            If iYrsOperation_S.Value = iYrsOperation_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Years Operation from {0} to {1}. ", iYrsOperation_S.Tag, iYrsOperation_S.Text)
            End If
            If dBusinessIncome_S.Value = dBusinessIncome_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Business Income from {0} to {1}. ", dBusinessIncome_S.Tag, dBusinessIncome_S.Text)
            End If
            If iNoEmployees_S.Value = iNoEmployees_S.Tag Then
            Else
                Change &= String.Format("Change Spouse No of Employees from {0} to {1}. ", iNoEmployees_S.Tag, iNoEmployees_S.Text)
            End If
            If dCapital_S.Value = dCapital_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Capital from {0} to {1}. ", dCapital_S.Tag, dCapital_S.Text)
            End If
            If txtArea_S.Text = txtArea_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Area from {0} to {1}. ", txtArea_S.Tag, txtArea_S.Text)
            End If
            If FormatDatePicker(dtpExpiry_S) = dtpExpiry_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Business Expiry from {0} to {1}. ", dtpExpiry_S.Tag, FormatDatePicker(dtpExpiry_S))
            End If
            If iOutlet_S.Value = iOutlet_S.Tag Then
            Else
                Change &= String.Format("Change Spouse No of Outlet from {0} to {1}. ", iOutlet_S.Tag, iOutlet_S.Text)
            End If
            If txtOtherIncome_S.Text = txtOtherIncome_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Other Income from {0} to {1}. ", txtOtherIncome_S.Tag, txtOtherIncome_S.Text)
            End If
            If dOtherIncome_S.Value = dOtherIncome_S.Tag Then
            Else
                Change &= String.Format("Change Spouse Other Income Monthly from {0} to {1}. ", dOtherIncome_S.Tag, dOtherIncome_S.Text)
            End If
            If ChangeSpousePic Then
                Change &= "Change Spouse Picture. "
            End If
        Catch ex As Exception
            TriggerBugReport("Spouse - Changes", ex.Message.ToString)
        End Try
        Return Change
    End Function

    Public Sub SaveImage(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER Branch
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER Borrowers
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, SpouseID)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, SpouseID))
        End If
        '********CREATE File
        Try
            Dim xPath As String
            xPath = String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, SpouseID, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Spouse Attachment"
            .Type = "Credit App Attachment Spouse"
            .TotalImage = TotalImage
            .CreditNumber = CreditNumber
            .ID = CreditNumber
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                FrmLoanApplication.TotalImageS = .TotalImage

            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                FrmLoanApplication.TotalImageS = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnID_Click(sender As Object, e As EventArgs) Handles btnID.Click
        Dim ID As New FrmID
        With ID
            .ID_Type = "S"
            .BorrowerID = Me.BorrowerID
            .From_Borrower = False
            .txtTIN.Text = txtTIN_S.Text
            .txtSSS.Text = txtSSS_S.Text
            Dim BorrowerID As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'S'", Me.BorrowerID))
            If BorrowerID.Rows.Count > 0 Then
                .txtGSIS.Text = BorrowerID(0)("GSIS")
                .txtPhilHealth.Text = BorrowerID(0)("PhilHealth")
                .txtSenior.Text = BorrowerID(0)("Senior")
                .txtUMID.Text = BorrowerID(0)("UMID")
                .txtSEC.Text = BorrowerID(0)("SEC")
                .txtDTI.Text = BorrowerID(0)("DTI")
                .txtCDA.Text = BorrowerID(0)("CDA")
                .txtCooperative.Text = BorrowerID(0)("Cooperative")
                .txtDrivers.Text = BorrowerID(0)("Drivers")
                If BorrowerID(0)("dDrivers") = "" Then
                Else
                    .dtpDrivers.Value = BorrowerID(0)("dDrivers")
                End If
                .txtVIN.Text = BorrowerID(0)("VIN")
                If BorrowerID(0)("dVIN") = "" Then
                Else
                    .dtpVIN.Value = BorrowerID(0)("dVIN")
                End If
                .txtPassport.Text = BorrowerID(0)("Passport")
                If BorrowerID(0)("dPassport") = "" Then
                Else
                    .dtpPassport.Value = BorrowerID(0)("dPassport")
                End If
                .txtPRC.Text = BorrowerID(0)("PRC")
                If BorrowerID(0)("dPRC") = "" Then
                Else
                    .dtpPRC.Value = BorrowerID(0)("dPRC")
                End If
                .txtNBI.Text = BorrowerID(0)("NBI")
                If BorrowerID(0)("dNBI") = "" Then
                Else
                    .dtpNBI.Value = BorrowerID(0)("dNBI")
                End If
                .txtPolice.Text = BorrowerID(0)("Police")
                If BorrowerID(0)("dPolice") = "" Then
                Else
                    .dtpPolice.Value = BorrowerID(0)("dPolice")
                End If
                .txtPostal.Text = BorrowerID(0)("Postal")
                If BorrowerID(0)("dPostal") = "" Then
                Else
                    .dtpPostal.Value = BorrowerID(0)("dPostal")
                End If
                .txtBarangay.Text = BorrowerID(0)("Barangay")
                If BorrowerID(0)("dBarangay") = "" Then
                Else
                    .dtpBarangay.Value = BorrowerID(0)("dBarangay")
                End If
                .txtOWWA.Text = BorrowerID(0)("OWWA")
                If BorrowerID(0)("dOWWA") = "" Then
                Else
                    .dtpOWWA.Value = BorrowerID(0)("dOWWA")
                End If
                .txtOFW.Text = BorrowerID(0)("OFW")
                If BorrowerID(0)("dOFW") = "" Then
                Else
                    .dtpOFW.Value = BorrowerID(0)("dOFW")
                End If
                .txtSeaman.Text = BorrowerID(0)("Seaman")
                If BorrowerID(0)("dSeaman") = "" Then
                Else
                    .dtpSeaman.Value = BorrowerID(0)("dSeaman")
                End If
                .txtPNP.Text = BorrowerID(0)("PNP")
                If BorrowerID(0)("dPNP") = "" Then
                Else
                    .dtpPNP.Value = BorrowerID(0)("dPNP")
                End If
                .txtAFP.Text = BorrowerID(0)("AFP")
                If BorrowerID(0)("dAFP") = "" Then
                Else
                    .dtpAFP.Value = BorrowerID(0)("dAFP")
                End If
                .txtHDMF.Text = BorrowerID(0)("HDMF")
                If BorrowerID(0)("dHDMF") = "" Then
                Else
                    .dtpHDMF.Value = BorrowerID(0)("dHDMF")
                End If
                .txtPWD.Text = BorrowerID(0)("PWD")
                If BorrowerID(0)("dPWD") = "" Then
                Else
                    .dtpPWD.Value = BorrowerID(0)("dPWD")
                End If
                .txtDSWD.Text = BorrowerID(0)("DSWD")
                If BorrowerID(0)("dDSWD") = "" Then
                Else
                    .dtpDSWD.Value = BorrowerID(0)("dDSWD")
                End If
                .txtACR.Text = BorrowerID(0)("ACR")
                If BorrowerID(0)("dACR") = "" Then
                Else
                    .dtpACR.Value = BorrowerID(0)("dACR")
                End If
                .txtDTI_Business.Text = BorrowerID(0)("DTI_Business")
                If BorrowerID(0)("dDTI_Business") = "" Then
                Else
                    .dtpDTI_Business.Value = BorrowerID(0)("dDTI_Business")
                End If
                .txtIBP.Text = BorrowerID(0)("IBP")
                If BorrowerID(0)("dIBP") = "" Then
                Else
                    .dtpIBP.Value = BorrowerID(0)("dIBP")
                End If
                .txtFireArms.Text = BorrowerID(0)("FireArms")
                If BorrowerID(0)("dFireArms") = "" Then
                Else
                    .dtpFireArms.Value = BorrowerID(0)("dFireArms")
                End If
                .txtGovernment.Text = BorrowerID(0)("Government")
                If BorrowerID(0)("dGovernment") = "" Then
                Else
                    .dtpGovernment.Value = BorrowerID(0)("dGovernment")
                End If
                .txtDiplomat.Text = BorrowerID(0)("Diplomat")
                If BorrowerID(0)("dDiplomat") = "" Then
                Else
                    .dtpDiplomat.Value = BorrowerID(0)("dDiplomat")
                End If
                .txtNational.Text = BorrowerID(0)("National")
                If BorrowerID(0)("dNational") = "" Then
                Else
                    .dtpNational.Value = BorrowerID(0)("dNational")
                End If
                .txtWork.Text = BorrowerID(0)("Work")
                If BorrowerID(0)("dWork") = "" Then
                Else
                    .dtpWork.Value = BorrowerID(0)("dWork")
                End If
                .txtGOCC.Text = BorrowerID(0)("GOCC")
                If BorrowerID(0)("dGOCC") = "" Then
                Else
                    .dtpGOCC.Value = BorrowerID(0)("dGOCC")
                End If
                .txtPLRA.Text = BorrowerID(0)("PLRA")
                If BorrowerID(0)("dPLRA") = "" Then
                Else
                    .dtpPLRA.Value = BorrowerID(0)("dPLRA")
                End If
                .txtMajor.Text = BorrowerID(0)("Major")
                If BorrowerID(0)("dMajor") = "" Then
                Else
                    .dtpMajor.Value = BorrowerID(0)("dMajor")
                End If
                .txtMedia.Text = BorrowerID(0)("Media")
                If BorrowerID(0)("dMedia") = "" Then
                Else
                    .dtpMedia.Value = BorrowerID(0)("dMedia")
                End If
                .txtStudent.Text = BorrowerID(0)("Student")
                If BorrowerID(0)("dStudent") = "" Then
                Else
                    .dtpStudent.Value = BorrowerID(0)("dStudent")
                End If
                .txtSIRV.Text = BorrowerID(0)("SIRV")
                If BorrowerID(0)("dSIRV") = "" Then
                Else
                    .dtpSIRV.Value = BorrowerID(0)("dSIRV")
                End If

                .TotalImage_TIN = BorrowerID(0)("Attach_TIN")
                .TotalImage_SSS = BorrowerID(0)("Attach_SSS")
                .TotalImage_GSIS = BorrowerID(0)("Attach_GSIS")
                .TotalImage_PhilHealth = BorrowerID(0)("Attach_PhilHealth")
                .TotalImage_Senior = BorrowerID(0)("Attach_Senior")
                .TotalImage_UMID = BorrowerID(0)("Attach_UMID")
                .TotalImage_SEC = BorrowerID(0)("Attach_SEC")
                .TotalImage_DTI = BorrowerID(0)("Attach_DTI")
                .TotalImage_CDA = BorrowerID(0)("Attach_CDA")
                .TotalImage_Cooperative = BorrowerID(0)("Attach_Cooperative")
                .TotalImage_Drivers = BorrowerID(0)("Attach_Drivers")
                .TotalImage_VIN = BorrowerID(0)("Attach_VIN")
                .TotalImage_Passport = BorrowerID(0)("Attach_Passport")
                .TotalImage_PRC = BorrowerID(0)("Attach_PRC")
                .TotalImage_NBI = BorrowerID(0)("Attach_NBI")
                .TotalImage_Police = BorrowerID(0)("Attach_Police")
                .TotalImage_Postal = BorrowerID(0)("Attach_Postal")
                .TotalImage_Barangay = BorrowerID(0)("Attach_Barangay")
                .TotalImage_OWWA = BorrowerID(0)("Attach_OWWA")
                .TotalImage_OFW = BorrowerID(0)("Attach_OFW")
                .TotalImage_Seaman = BorrowerID(0)("Attach_Seaman")
                .TotalImage_PNP = BorrowerID(0)("Attach_PNP")
                .TotalImage_AFP = BorrowerID(0)("Attach_AFP")
                .TotalImage_HDMF = BorrowerID(0)("Attach_HDMF")
                .TotalImage_PWD = BorrowerID(0)("Attach_PWD")
                .TotalImage_DSWD = BorrowerID(0)("Attach_DSWD")
                .TotalImage_ACR = BorrowerID(0)("Attach_ACR")
                .TotalImage_DTI_Business = BorrowerID(0)("Attach_DTI_Business")
                .TotalImage_IBP = BorrowerID(0)("Attach_IBP")
                .TotalImage_FireArms = BorrowerID(0)("Attach_FireArms")
                .TotalImage_Government = BorrowerID(0)("Attach_Government")
                .TotalImage_Diplomat = BorrowerID(0)("Attach_Diplomat")
                .TotalImage_National = BorrowerID(0)("Attach_National")
                .TotalImage_Work = BorrowerID(0)("Attach_Work")
                .TotalImage_GOCC = BorrowerID(0)("Attach_GOCC")
                .TotalImage_PLRA = BorrowerID(0)("Attach_PLRA")
                .TotalImage_Major = BorrowerID(0)("Attach_Major")
                .TotalImage_Media = BorrowerID(0)("Attach_Media")
                .TotalImage_Student = BorrowerID(0)("Attach_Student")
                .TotalImage_SIRV = BorrowerID(0)("Attach_SIRV")
            End If

            .btnAttach_TIN.Enabled = True
            .btnAttach_SSS.Enabled = True
            .btnAttach_GSIS.Enabled = True
            .btnAttach_PhilHealth.Enabled = True
            .btnAttach_Senior.Enabled = True
            .btnAttach_UMID.Enabled = True
            .btnAttach_SEC.Enabled = True
            .btnAttach_DTI.Enabled = True
            .btnAttach_CDA.Enabled = True
            .btnAttach_Cooperative.Enabled = True
            .btnAttach_Drivers.Enabled = True
            .btnAttach_VIN.Enabled = True
            .btnAttach_Passport.Enabled = True
            .btnAttach_PRC.Enabled = True
            .btnAttach_NBI.Enabled = True
            .btnAttach_Police.Enabled = True
            .btnAttach_Postal.Enabled = True
            .btnAttach_Barangay.Enabled = True
            .btnAttach_OWWA.Enabled = True
            .btnAttach_OFW.Enabled = True
            .btnAttach_Seaman.Enabled = True
            .btnAttach_PNP.Enabled = True
            .btnAttach_AFP.Enabled = True
            .btnAttach_HDMF.Enabled = True
            .btnAttach_PWD.Enabled = True
            .btnAttach_DSWD.Enabled = True
            .btnAttach_ACR.Enabled = True
            .btnAttach_DTI_Business.Enabled = True
            .btnAttach_IBP.Enabled = True
            .btnAttach_FireArms.Enabled = True
            .btnAttach_Government.Enabled = True
            .btnAttach_Diplomat.Enabled = True
            .btnAttach_National.Enabled = True
            .btnAttach_Work.Enabled = True
            .btnAttach_GOCC.Enabled = True
            .btnAttach_PLRA.Enabled = True
            .btnAttach_Major.Enabled = True
            .btnAttach_Media.Enabled = True
            .btnAttach_Student.Enabled = True
            .btnAttach_SIRV.Enabled = True

            If .ShowDialog = DialogResult.OK Then
                txtTIN_S.Text = .txtTIN.Text
                txtSSS_S.Text = .txtSSS.Text
                FrmLoanApplication.TIN_S = .txtTIN.Text
                FrmLoanApplication.SSS_S = .txtTIN.Text
                FrmLoanApplication.GSIS_S = .txtGSIS.Text
                FrmLoanApplication.PhilHealth_S = .txtPhilHealth.Text
                FrmLoanApplication.Senior_S = .txtSenior.Text
                FrmLoanApplication.UMID_S = .txtUMID.Text
                FrmLoanApplication.SEC_S = .txtSEC.Text
                FrmLoanApplication.DTI_S = .txtDTI.Text
                FrmLoanApplication.CDA_S = .txtCDA.Text
                FrmLoanApplication.Cooperative_S = .txtCooperative.Text
                FrmLoanApplication.Drivers_S = .txtDrivers.Text
                FrmLoanApplication.dDrivers_S = FormatDatePicker(.dtpDrivers)
                FrmLoanApplication.VIN_S = .txtVIN.Text
                FrmLoanApplication.dVIN_S = FormatDatePicker(.dtpVIN)
                FrmLoanApplication.Passport_S = .txtPassport.Text
                FrmLoanApplication.dPassport_S = FormatDatePicker(.dtpPassport)
                FrmLoanApplication.PRC_S = .txtPRC.Text
                FrmLoanApplication.dPRC_S = FormatDatePicker(.dtpPRC)
                FrmLoanApplication.NBI_S = .txtNBI.Text
                FrmLoanApplication.dNBI_S = FormatDatePicker(.dtpNBI)
                FrmLoanApplication.Police_S = .txtPolice.Text
                FrmLoanApplication.dPolice_S = FormatDatePicker(.dtpPolice)
                FrmLoanApplication.Postal_S = .txtPostal.Text
                FrmLoanApplication.dPostal_S = FormatDatePicker(.dtpPostal)
                FrmLoanApplication.Barangay_S = .txtBarangay.Text
                FrmLoanApplication.dBarangay_S = FormatDatePicker(.dtpBarangay)
                FrmLoanApplication.OWWA_S = .txtOWWA.Text
                FrmLoanApplication.dOWWA_S = FormatDatePicker(.dtpOWWA)
                FrmLoanApplication.OFW_S = .txtOFW.Text
                FrmLoanApplication.dOFW_S = FormatDatePicker(.dtpOFW)
                FrmLoanApplication.Seaman_S = .txtSeaman.Text
                FrmLoanApplication.dSeaman_S = FormatDatePicker(.dtpSeaman)
                FrmLoanApplication.PNP_S = .txtPNP.Text
                FrmLoanApplication.dPNP_S = FormatDatePicker(.dtpPNP)
                FrmLoanApplication.AFP_S = .txtAFP.Text
                FrmLoanApplication.dAFP_S = FormatDatePicker(.dtpAFP)
                FrmLoanApplication.HDMF_S = .txtHDMF.Text
                FrmLoanApplication.dHDMF_S = FormatDatePicker(.dtpHDMF)
                FrmLoanApplication.PWD_S = .txtPWD.Text
                FrmLoanApplication.dPWD_S = FormatDatePicker(.dtpPWD)
                FrmLoanApplication.DSWD_S = .txtDSWD.Text
                FrmLoanApplication.dDSWD_S = FormatDatePicker(.dtpDSWD)
                FrmLoanApplication.ACR_S = .txtACR.Text
                FrmLoanApplication.dACR_S = FormatDatePicker(.dtpACR)
                FrmLoanApplication.DTI_Business_S = .txtDTI_Business.Text
                FrmLoanApplication.dDTI_Business_S = FormatDatePicker(.dtpDTI_Business)
                FrmLoanApplication.IBP_S = .txtIBP.Text
                FrmLoanApplication.dIBP_S = FormatDatePicker(.dtpIBP)
                FrmLoanApplication.FireArms_S = .txtFireArms.Text
                FrmLoanApplication.dFireArms_S = FormatDatePicker(.dtpFireArms)
                FrmLoanApplication.Government_S = .txtGovernment.Text
                FrmLoanApplication.dGovernment_S = FormatDatePicker(.dtpGovernment)
                FrmLoanApplication.Diplomat_S = .txtDiplomat.Text
                FrmLoanApplication.dDiplomat_S = FormatDatePicker(.dtpDiplomat)
                FrmLoanApplication.National_S = .txtNational.Text
                FrmLoanApplication.dNational_S = FormatDatePicker(.dtpNational)
                FrmLoanApplication.Work_S = .txtWork.Text
                FrmLoanApplication.dWork_S = FormatDatePicker(.dtpWork)
                FrmLoanApplication.GOCC_S = .txtGOCC.Text
                FrmLoanApplication.dGOCC_S = FormatDatePicker(.dtpGOCC)
                FrmLoanApplication.PLRA_S = .txtPLRA.Text
                FrmLoanApplication.dPLRA_S = FormatDatePicker(.dtpPLRA)
                FrmLoanApplication.Major_S = .txtMajor.Text
                FrmLoanApplication.dMajor_S = FormatDatePicker(.dtpMajor)
                FrmLoanApplication.Media_S = .txtMedia.Text
                FrmLoanApplication.dMedia_S = FormatDatePicker(.dtpMedia)
                FrmLoanApplication.Student_S = .txtStudent.Text
                FrmLoanApplication.dStudent_S = FormatDatePicker(.dtpStudent)
                FrmLoanApplication.SIRV_S = .txtSIRV.Text
                FrmLoanApplication.dSIRV_S = FormatDatePicker(.dtpSIRV)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        txtPath_S.Text = " "
        ResizeImages(DefaultImage.Image.Clone, pb_S, 650, 500)
    End Sub

    Private Sub CbxYearHired_S_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYearHired_S.CheckedChanged
        If cbxYearHired_S.Checked Then
            dtpHired_S.CustomFormat = "yyyy"
        Else
            dtpHired_S.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub
End Class