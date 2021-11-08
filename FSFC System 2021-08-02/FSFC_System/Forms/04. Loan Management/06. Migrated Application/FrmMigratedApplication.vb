Public Class FrmMigratedApplication

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean = True

    Dim PD_BankID As Integer
    Dim PD_AccountNumber As String
    Dim PD_CardNumber As String
    Dim PD_ATM As Boolean

    Dim Last_RPPD As Double
    Public Interest_RPPD As Double = 3
    Public RPPD_Start As Integer = 7
    Dim Product_Payment As String
    Dim Product_UDI As String
    Dim Product_LastPrincipal As String
    Dim Product_AdvancePayment As String
    Dim MortgageID As Integer
    Dim Product_Interest As Double
    Dim Interest_UDI As Double
    Dim Puwake_UDI As Double
    Dim UDI_F As Double
    Dim FA_F As Double
    Dim Puwake_MR As Double
    Dim RPPD_F As Double
    Public From_Application As Boolean
    Dim Monthly_Principal As Double
    Dim Monthly_Interest As Double
    Dim Flag As Boolean
    ReadOnly DueDate As Date
    Public ProductID As Integer
    Public From_OfficialReceipt As Boolean

    Public v_dAmountApplied As Double
    Public v_iTerms_C As Double
    Public v_dInterest_T As Double
    Public v_dRPPDRate_T As Double
    Public v_dtpAvailed As Date
    Public v_dtpFDD As Date
    Public v_dMR_C As Double
    Public v_dPA_C As Double
    Public v_dUDI_C As Double
    Public v_dRPPD_C As Double
    Dim AddPenalty As Boolean
    Private Sub FrmMigratedApplication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        With cbxNatureBusiness_B2
            .Location = New Point(345, 104)
            .Size = New Point(227, 24)
        End With
        Icon = My.Resources.iLoanWorkX_ico
        Firstload = True
        GridColumn15.VisibleIndex = 0
        GridColumn16.VisibleIndex = 1
        GridColumn17.VisibleIndex = 2
        GridColumn18.VisibleIndex = 3
        GridColumn19.VisibleIndex = 4
        GridColumn20.VisibleIndex = 5
        GridColumn21.VisibleIndex = 6
        GridColumn23.VisibleIndex = 7
        GridColumn22.VisibleIndex = 8
        GridColumn24.VisibleIndex = 9
        LoadCompanyMode()

        With cbxProduct
            .ValueMember = "ID"
            .DisplayMember = "Product"
            .DataSource = Products.Copy
            .SelectedIndex = -1
        End With

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_OfficialReceipt = False Then
            dtpAvailed.Value = Date.Now
            dtpFDD.Value = Date.Now
            dtpLastPayment.Value = Date.Now

            LoadBorrower()

            'BusinessCenter
            With cbxBusinessCenter
                .ValueMember = "ID"
                .DisplayMember = "BusinessCenter"
                .DataSource = DT_BusinessCenter.Copy
                .SelectedIndex = -1
            End With

            With cbxTerms
                .DisplayMember = "Terms"
                .DataSource = Terms.Copy
                .SelectedIndex = 2
            End With

            With cbxCI
                .ValueMember = "ID"
                .DisplayMember = "CI"
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
                .SelectedIndex = -1
            End With

            With cbxBank
                .ValueMember = "ID"
                .DisplayMember = "Bank"
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, AccountCode FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", If(Multiple_ID = "", Branch_ID, Multiple_ID) & "," & MFBranch_ID, DefaultBankID))
                If DefaultBankID > 0 Then
                    .Enabled = False
                End If
            End With

            cbxNatureBusiness_B2.Properties.LookAndFeel.SkinName = "Blue"
            For x As Integer = 0 To DT_Industry.Rows.Count - 1
                cbxNatureBusiness_B2.Properties.Items.Add(DT_Industry(x)("ID"), DT_Industry(x)("Nature"), CheckState.Unchecked, True)
            Next
            cbxNatureBusiness_B2.Properties.SeparatorChar = ";"
        End If

        cbxRoundUp.Checked = Round_Up
        If CompanyMode = 0 Then
            dRPPDRate_C.Value = 0
            dRPPDRate_T.Value = 0
        Else
            dRPPDRate_C.Value = Interest_RPPD
            dRPPDRate_T.Value = Interest_RPPD
        End If
        Last_RPPD = Interest_RPPD
        If User_Type = "ADMIN" Then
            cbxRoundUp.Enabled = True
        Else
            cbxRoundUp.Enabled = False
        End If

        Timer_Date.Start()

        Firstload = False

        If From_OfficialReceipt Then
            LoadAmortization()
            btnRefresh.Enabled = False
            cbxProduct.SelectedValue = ProductID
            tabSetup.Visible = False

            dAmountApplied.Value = v_dAmountApplied
            iTerms_C.Value = v_iTerms_C
            dInterest_T.Value = v_dInterest_T
            dRPPDRate_T.Value = v_dRPPDRate_T
            dtpAvailed.Value = v_dtpAvailed
            dtpFDD.Value = v_dtpFDD
            dMR_C.Value = v_dMR_C

            dPA_C.Value = v_dPA_C
            dUDI_C.Value = v_dUDI_C
            dRPPD_C.Value = v_dRPPD_C

            dInterest_N.Value = GridView1.GetRowCellValue(1, "Interest Income")
            dRPPD_N.Value = GridView1.GetRowCellValue(1, "RPPD")
            dPrincipal_N.Value = GridView1.GetRowCellValue(1, "Principal Allocation")
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

            GetLabelFontSettings({LabelX2, LabelX86, LabelX17, LabelX7, LabelX30, LabelX32, LabelX10, LabelX3, LabelX5, LabelX11, LabelX81, LabelX12, lblRPPDRate_C, LabelX9, LabelX8, LabelX22, LabelX4, LabelX82, LabelX89, lblRPPD_C, LabelX14, LabelX6, lblTotalPayment, LabelX92, lblMR_C, LabelX94, LabelX20, LabelX24, LabelX21, LabelX19, LabelX128, lblAvailedV2, LabelX83, lblRPPDRate_Percent, lblInterest, lblRPPDRate_T, LabelX84, lblMR_Slash, LabelX101})

            GetLabelFontSettingsDefault({lblForVerification, lblVerified})

            GetLabelWithBackgroundFontSettings({LabelX13, LabelX15, LabelX16, LabelX23})

            GetCheckBoxFontSettings({cbxCorporate, cbxAuto, cbxRoundUp})

            GetLabelFontSettingsRed({LabelX18})

            GetDoubleInputFontSettings({dAmountApplied, dInterest_C, dInterest_T, dRPPDRate_C, dRPPDRate_T, dPA_C, dPrincipal_B, dUDI_C, dUDI_B, dRPPD_C, dRPPD_B, dPenalty_B, dFA_C, dOutstanding, dTotalPayment, dGMA_C, dGMA_C2, dMR_C, dMR_C2, dNMA_C, dNMA_C2, dInterest_N, dRPPD_N, dPrincipal_N})

            GetIntegerInputFontSettings({iTerms_C, iDue})

            GetDateTimeInputFontSettings({dtpAvailedV2, dtpAvailed, dtpFDD, dtpLastPayment})

            GetTextBoxFontSettings({txtCompleteAdd, txtPlus63, txtMobile, txtEmail, iAccount_2, txtCreditNumber, txtCollateral, txtCVNumber})

            GetButtonFontSettings({btnEdit, btnManual, btnSave, btnRefresh, btnCancel, btnVerify, btnAddC, btnRemoveC, btnPenalty, btnATM})

            GetComboBoxFontSettings({cbxBorrower, cbxProduct, cbxTerms, cbxCI, cbxBank, cbxBusinessCenter})

            GetRickTextBoxFontSettings({rRemarks})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxNatureBusiness_B2})
        Catch ex As Exception
            TriggerBugReport("Migrated Application - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Migrated Application", lblTitle.Text)
    End Sub

    Private Sub LoadBorrower()
        Cursor = Cursors.WaitCursor
        cbxBorrower.ValueMember = "BorrowerID"
        cbxBorrower.DisplayMember = "Name"
        Dim SQL As String

        If cbxCorporate.Checked Then
            SQL = "SELECT"
            SQL &= " CONCAT('[ ', B.BorrowerID, ' ] - ', TradeName) AS 'Name', CONCAT(IF(`No` = '','',CONCAT(No, ', ')), IF(Street = '','',CONCAT(Street, ', ')), IF(Barangay = '','',CONCAT(Barangay, ', ')), Address) AS 'Address',"
            SQL &= " B.*, (SELECT BusinessCenter FROM business_center WHERE ID = B.BusinessID) AS 'BusinessCenter'"
            SQL &= " FROM profile_corporation B"
            SQL &= String.Format("    WHERE FIND_IN_SET(B.Branch_ID,'{0}') AND B.`status` = 'ACTIVE' GROUP BY B.BorrowerID ORDER BY B.TradeName;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT B.BorrowerID, "
            SQL &= "   CONCAT('[ ', B.BorrowerID, ' ] - ', IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')),  IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Name', CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',"
            SQL &= "   B.*, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = B.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = B.BusinessID)) AS 'BusinessCenter',"
            SQL &= "   S.*,"
            SQL &= "   IFNULL(D1.Prefix_D,'') AS 'Prefix_D1',   "
            SQL &= "   IFNULL(D1.FirstN_D,'') AS 'FirstN_D1',   "
            SQL &= "   IFNULL(D1.MiddleN_D,'') AS 'MiddleN_D1',   "
            SQL &= "   IFNULL(D1.LastN_D,'') AS 'LastN_D1',   "
            SQL &= "   IFNULL(D1.Suffix_D,'') AS 'Suffix_D1',   "
            SQL &= "   IFNULL(D1.Birth_D,'') AS 'Birth_D1',   "
            SQL &= "   IFNULL(D1.Grade_D,'') AS 'Grade_D1',   "
            SQL &= "   IFNULL(D1.School_D,'') AS 'School_D1',   "
            SQL &= "   IFNULL(D1.SchoolAddress_D,'') AS 'SchoolAddress_D1',   "
            SQL &= "   IFNULL(D2.Prefix_D,'') AS 'Prefix_D2',   "
            SQL &= "   IFNULL(D2.FirstN_D,'') AS 'FirstN_D2',   "
            SQL &= "   IFNULL(D2.MiddleN_D,'') AS 'MiddleN_D2',   "
            SQL &= "   IFNULL(D2.LastN_D,'') AS 'LastN_D2',   "
            SQL &= "   IFNULL(D2.Suffix_D,'') AS 'Suffix_D2',   "
            SQL &= "   IFNULL(D2.Birth_D,'') AS 'Birth_D2',   "
            SQL &= "   IFNULL(D2.Grade_D,'') AS 'Grade_D2',   "
            SQL &= "   IFNULL(D2.School_D,'') AS 'School_D2',   "
            SQL &= "   IFNULL(D2.SchoolAddress_D,'') AS 'SchoolAddress_D2',   "
            SQL &= "   IFNULL(D3.Prefix_D,'') AS 'Prefix_D3',   "
            SQL &= "   IFNULL(D3.FirstN_D,'') AS 'FirstN_D3',   "
            SQL &= "   IFNULL(D3.MiddleN_D,'') AS 'MiddleN_D3',   "
            SQL &= "   IFNULL(D3.LastN_D,'') AS 'LastN_D3',   "
            SQL &= "   IFNULL(D3.Suffix_D,'') AS 'Suffix_D3',   "
            SQL &= "   IFNULL(D3.Birth_D,'') AS 'Birth_D3',   "
            SQL &= "   IFNULL(D3.Grade_D,'') AS 'Grade_D3',   "
            SQL &= "   IFNULL(D3.School_D,'') AS 'School_D3',   "
            SQL &= "   IFNULL(D3.SchoolAddress_D,'') AS 'SchoolAddress_D3',   "
            SQL &= "   IFNULL(D4.Prefix_D,'') AS 'Prefix_D4',   "
            SQL &= "   IFNULL(D4.FirstN_D,'') AS 'FirstN_D4',   "
            SQL &= "   IFNULL(D4.MiddleN_D,'') AS 'MiddleN_D4',   "
            SQL &= "   IFNULL(D4.LastN_D,'') AS 'LastN_D4',   "
            SQL &= "   IFNULL(D4.Suffix_D,'') AS 'Suffix_D4',   "
            SQL &= "   IFNULL(D4.Birth_D,'') AS 'Birth_D4',   "
            SQL &= "   IFNULL(D4.Grade_D,'') AS 'Grade_D4',   "
            SQL &= "   IFNULL(D4.School_D,'') AS 'School_D4',   "
            SQL &= "   IFNULL(D4.SchoolAddress_D,'') AS 'SchoolAddress_D4' "
            SQL &= " FROM profile_borrower B"
            SQL &= " LEFT JOIN profile_spouse S"
            SQL &= "    ON B.BorrowerID = S.BorrowerID AND S.`status` = 'ACTIVE'"
            SQL &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 1) D1    "
            SQL &= "    ON B.BorrowerID = D1.BorrowerID "
            SQL &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 2) D2    "
            SQL &= "    ON B.BorrowerID = D2.BorrowerID "
            SQL &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 3) D3    "
            SQL &= "    ON B.BorrowerID = D3.BorrowerID "
            SQL &= " LEFT JOIN (SELECT ID, DependentID, BorrowerID, Prefix_D, FirstN_D, MiddleN_D, LastN_D, Suffix_D, Birth_D, Grade_D, School_D, SchoolAddress_D FROM profile_dependent WHERE `status` = 'ACTIVE' AND `Rank` = 4) D4    "
            SQL &= "    ON B.BorrowerID = D4.BorrowerID "
            SQL &= String.Format("    WHERE FIND_IN_SET(B.Branch_ID,'{0}') AND B.`status` = 'ACTIVE' GROUP BY B.BorrowerID ORDER BY B.LastN_B;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        cbxBorrower.DataSource = DataSource(SQL)
        cbxBorrower.SelectedIndex = -1
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxBorrower_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBorrower.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCompleteAdd.Focus()
        End If
    End Sub

    Private Sub TxtCompleteAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompleteAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile.Focus()
        End If
    End Sub

    Private Sub TxtMobile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail.Focus()
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxProduct.Focus()
        End If
    End Sub

    Private Sub CbxProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            iAccount_2.Focus()
        End If
    End Sub

    Private Sub IAccount_2_KeyDown(sender As Object, e As KeyEventArgs) Handles iAccount_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCollateral.Focus()
        End If
    End Sub

    Private Sub TxtCollateral_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCollateral.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmountApplied.Focus()
        End If
    End Sub

    Private Sub DAmountApplied_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmountApplied.KeyDown
        If e.KeyCode = Keys.Enter Then
            iTerms_C.Focus()
        End If
    End Sub

    Private Sub ITerms_C_KeyDown(sender As Object, e As KeyEventArgs) Handles iTerms_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            dInterest_C.Focus()
        End If
    End Sub

    Private Sub DInterest_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dInterest_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dInterest_T.Enabled Then
                dInterest_T.Focus()
            Else
                dRPPDRate_C.Focus()
            End If
        End If
    End Sub

    Private Sub DInterest_T_KeyDown(sender As Object, e As KeyEventArgs) Handles dInterest_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRPPDRate_C.Focus()
        End If
    End Sub

    Private Sub DRPPDRate_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPDRate_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dRPPDRate_T.Enabled Then
                dRPPDRate_T.Focus()
            Else
                dtpAvailed.Focus()
            End If
        End If
    End Sub

    Private Sub DRPPDRate_T_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPDRate_T.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpAvailed.Focus()
        End If
    End Sub

    Private Sub DtpAvailed_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAvailed.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFDD.Focus()
        End If
    End Sub

    Private Sub DtpFDD_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFDD.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpLastPayment.Focus()
        End If
    End Sub

    Private Sub DtpLastPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpLastPayment.KeyDown
        If e.KeyCode = Keys.Enter Then
            If iDue.Enabled Then
                iDue.Focus()
            Else
                dPrincipal_B.Focus()
            End If
        End If
    End Sub

    Private Sub IDue_KeyDown(sender As Object, e As KeyEventArgs) Handles iDue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPrincipal_B.Focus()
        End If
    End Sub

    Private Sub DPrincipal_D_KeyDown(sender As Object, e As KeyEventArgs) Handles dPrincipal_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dUDI_C.Enabled Then
                dUDI_C.Focus()
            Else
                dUDI_B.Focus()
            End If
        End If
    End Sub

    Private Sub DUDI_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dUDI_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            dUDI_B.Focus()
        End If
    End Sub

    Private Sub DUDI_B_KeyDown(sender As Object, e As KeyEventArgs) Handles dUDI_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dRPPD_C.Enabled Then
                dRPPD_C.Focus()
            Else
                dRPPD_B.Focus()
            End If
        End If
    End Sub

    Private Sub DRPPD_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPD_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRPPD_B.Focus()
        End If
    End Sub

    Private Sub DRPPD_D_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPD_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPenalty_B.Focus()
        End If
    End Sub

    Private Sub DPenalty_D_KeyDown(sender As Object, e As KeyEventArgs) Handles dPenalty_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dFA_C.Enabled Then
                dFA_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DFaceAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dFA_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalPayment.Focus()
        End If
    End Sub

    Private Sub DTotalPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalPayment.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dGMA_C.Enabled Then
                dGMA_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DGMA_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMA_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dGMA_C2.Enabled And dGMA_C2.Visible Then
                dGMA_C2.Focus()
            ElseIf dMR_C.Enabled Then
                dMR_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DGMA_C2_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMA_C2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dMR_C.Enabled Then
                dMR_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DMR_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dMR_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dMR_C2.Enabled And dMR_C2.Visible Then
                dMR_C2.Focus()
            ElseIf dNMA_C.Enabled Then
                dNMA_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DMR_C2_KeyDown(sender As Object, e As KeyEventArgs) Handles dMR_C2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dNMA_C.Enabled Then
                dNMA_C.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub DNMA_C_KeyDown(sender As Object, e As KeyEventArgs) Handles dNMA_C.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dNMA_C2.Enabled And dNMA_C2.Visible Then
                dNMA_C2.Focus()
            Else
                cbxBank.Focus()
            End If
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCVNumber.Focus()
        End If
    End Sub

    Private Sub TxtCVNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCVNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCI.Focus()
        End If
    End Sub

    Private Sub CbxCI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            rRemarks.Focus()
        End If
    End Sub

    Private Sub RRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles rRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtCompleteAdd_Leave(sender As Object, e As EventArgs) Handles txtCompleteAdd.Leave
        txtCompleteAdd.Text = ReplaceText(txtCompleteAdd.Text)
    End Sub

    Private Sub TxtMobile_Leave(sender As Object, e As EventArgs) Handles txtMobile.Leave
        txtMobile.Text = ReplaceText(txtMobile.Text)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text)
    End Sub

    Private Sub CbxProduct_Leave(sender As Object, e As EventArgs) Handles cbxProduct.Leave
        cbxProduct.Text = ReplaceText(cbxProduct.Text)
    End Sub

    Private Sub IAccount_2_Leave(sender As Object, e As EventArgs) Handles iAccount_2.Leave
        iAccount_2.Text = ReplaceText(iAccount_2.Text)
    End Sub

    Private Sub TxtCollateral_Leave(sender As Object, e As EventArgs) Handles txtCollateral.Leave
        txtCollateral.Text = ReplaceText(txtCollateral.Text)
    End Sub

    Private Sub TxtCVNumber_Leave(sender As Object, e As EventArgs) Handles txtCVNumber.Leave
        txtCVNumber.Text = ReplaceText(txtCVNumber.Text)
    End Sub

    Private Sub RRemarks_Leave(sender As Object, e As EventArgs) Handles rRemarks.Leave
        rRemarks.Text = ReplaceText(rRemarks.Text)
    End Sub
#End Region

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.Control And e.KeyCode = Keys.U Then
            If iDue.Enabled Then
                dInterest_C.Enabled = False
                dRPPDRate_C.Enabled = False
                iDue.Enabled = False
                dUDI_C.Enabled = False
                dRPPD_C.Enabled = False
                dFA_C.Enabled = False
                dTotalPayment.Enabled = False
                dGMA_C.Enabled = False
                dGMA_C2.Enabled = False
                dMR_C.Enabled = False
                dMR_C2.Enabled = False
                dNMA_C.Enabled = False
                dNMA_C2.Enabled = False
            Else
                dInterest_C.Enabled = True
                dRPPDRate_C.Enabled = True
                iDue.Enabled = True
                dUDI_C.Enabled = True
                dRPPD_C.Enabled = True
                dFA_C.Enabled = True
                dTotalPayment.Enabled = True
                dGMA_C.Enabled = True
                dGMA_C2.Enabled = True
                dMR_C.Enabled = True
                dMR_C2.Enabled = True
                dNMA_C.Enabled = True
                dNMA_C2.Enabled = True
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()

            LoadBorrower()
        End If
    End Sub

    Private Sub Clear()
        Firstload = True
        dtpAvailed.Value = Date.Now
        dtpFDD.Value = Date.Now
        dtpLastPayment.Value = Date.Now
        cbxBorrower.Text = ""
        txtCompleteAdd.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""
        cbxProduct.Text = ""
        iAccount_2.Text = ""
        txtCollateral.Text = ""
        dAmountApplied.Value = 0
        iTerms_C.Value = 0
        dUDI_B.Value = 0
        dRPPD_B.Value = 0
        dPrincipal_B.Value = 0
        dPenalty_B.Value = 0
        dTotalPayment.Value = 0
        txtCVNumber.Text = ""
        rRemarks.Text = ""
        For x As Integer = 0 To cbxNatureBusiness_B2.Properties.Items.Count - 1
            cbxNatureBusiness_B2.Properties.Items.Item(x).CheckState = CheckState.Unchecked
        Next

        PD_BankID = 0
        PD_AccountNumber = ""
        PD_CardNumber = ""
        PD_ATM = False

        lblVerified.Visible = False
        lblForVerification.Visible = True

        GridColumn16.OptionsColumn.AllowEdit = False
        GridColumn17.OptionsColumn.AllowEdit = False
        GridColumn18.OptionsColumn.AllowEdit = False
        GridColumn19.OptionsColumn.AllowEdit = False
        GridColumn20.OptionsColumn.AllowEdit = False
        GridColumn21.OptionsColumn.AllowEdit = False
        GridColumn22.OptionsColumn.AllowEdit = False
        GridColumn23.OptionsColumn.AllowEdit = False
        GridColumn24.OptionsColumn.AllowEdit = False

        Firstload = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK And (From_Application Or From_OfficialReceipt) Then
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If From_OfficialReceipt Then
            If GridView1.RowCount <= 1 Then
                MsgBox("Please fill amortization schedule.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            GoTo HereV3
        End If
        If cbxBorrower.SelectedIndex = -1 Or cbxBorrower.Text = "" Then
            MsgBox("Please select a Borrower.", MsgBoxStyle.Information, "Info")
            cbxBorrower.DroppedDown = True
            Exit Sub
        End If
        If txtMobile.Text = "" And cbxCorporate.Checked = False Or txtMobile.Text.Trim.Length <> 10 Or IsNumeric(txtMobile.Text.Trim) = False Or If(txtMobile.Text.Length > 1, txtMobile.Text.Substring(0, 1) = 0, 0) Then
            MsgBox("Please fill a correct Borrower's Mobile Number field.", MsgBoxStyle.Information, "Info")
            txtMobile.Focus()
            Exit Sub
        End If
        If cbxProduct.SelectedIndex = -1 Or cbxProduct.Text = "" Then
            MsgBox("Please select a product.", MsgBoxStyle.Information, "Info")
            cbxProduct.DroppedDown = True
            Exit Sub
        End If
        If iAccount_2.Text = "" Then
            MsgBox("Please fill Account Number.", MsgBoxStyle.Information, "Info")
            iAccount_2.Focus()
            Exit Sub
        End If
        If dAmountApplied.Value = 0 Then
            MsgBox("Please fill Amount Applied.", MsgBoxStyle.Information, "Info")
            dAmountApplied.Focus()
            Exit Sub
        End If
        If iTerms_C.Value = 0 Then
            MsgBox("Please fill Terms.", MsgBoxStyle.Information, "Info")
            iTerms_C.Focus()
            Exit Sub
        End If
        If cbxTerms.SelectedIndex = -1 Or cbxTerms.Text = "" Then
            MsgBox("Please select a term type.", MsgBoxStyle.Information, "Info")
            cbxTerms.DroppedDown = True
            Exit Sub
        End If
        If DateValue(dtpAvailed.Value) = Date.Now Then
            If MsgBox("Are you sure that Availed Date is today?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If DateValue(dtpLastPayment.Value) = Date.Now Then
            If MsgBox("Are you sure that Last Payment is today?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If DateValue(dtpFDD.Value) < DateValue(dtpAvailed.Value) Then
            If MsgBox("First Due Date is earlier than the Availed Date, Would you like to proceed?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If (DateValue(dtpLastPayment.Value) < DateValue(dtpAvailed.Value) Or DateValue(dtpLastPayment.Value) < DateValue(dtpFDD.Value)) And dFA_C.Value > dTotalPayment.Value Then
            If MsgBox("Last Payment Date is earlier than the Availed Date or First Due Date, Would you like to proceed?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dPrincipal_B.Value = 0 Then
            If MsgBox("Are you sure that the outstanding balance for Principal is 0?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dUDI_B.Value = 0 Then
            If MsgBox("Are you sure that the outstanding balance for UDI is 0?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf dUDI_B.Value > dUDI_C.Value Then
            MsgBox("Outstanding Balance for UDI is greater than its Computed UDI, please check your data.", MsgBoxStyle.Information, "Info")
            dUDI_B.Focus()
            Exit Sub
        End If
        If dRPPD_B.Value = 0 Then
            If MsgBox("Are you sure that the outstanding balance for RPPD is 0?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        ElseIf dRPPD_B.Value > dUDI_C.Value Then
            MsgBox("Outstanding Balance for RPPD is greater than its Computed RPPD, please check your data.", MsgBoxStyle.Information, "Info")
            dRPPD_B.Focus()
            Exit Sub
        End If
        If dPenalty_B.Value = 0 Then
            If MsgBox("Are you sure that the outstanding balance for Penalty is 0?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxBank.SelectedIndex = -1 Or cbxBank.Text = "" Then
            MsgBox("Please select Bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        If txtCVNumber.Text = "" Then
            MsgBox("Please fill CV Number.", MsgBoxStyle.Information, "Info")
            txtCVNumber.Focus()
            Exit Sub
        End If
        Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM accounting_entry WHERE `JVNum` = '{0}' AND `status` = 'ACTIVE' AND YEAR(ORNum) = YEAR('{1}');", txtCVNumber.Text, FormatDatePicker(dtpAvailed)))
        If Exist > 0 Then
            MsgBox(String.Format("CV Number {0} already exist, Please check your data.", txtCVNumber.Text), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If (cbxCI.SelectedIndex = -1 Or cbxCI.Text = "") And (MortgageID = 1 Or MortgageID = 2) Then
            MsgBox("Please select Credit Investigator.", MsgBoxStyle.Information, "Info")
            cbxCI.DroppedDown = True
            Exit Sub
        End If
HereV3:

        Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
        Dim drvP As DataRowView = DirectCast(cbxProduct.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If From_OfficialReceipt Then
                    GoTo Here
                End If
                GetCreditApplication()

                Dim SQL As String = "INSERT INTO credit_application SET"
                SQL &= String.Format(" AmountApplied = '{0}', ", dAmountApplied.Value)
                SQL &= String.Format(" Terms = '{0}', ", iTerms_C.Value)
                SQL &= String.Format(" TermType = '{0}', ", cbxTerms.Text)
                SQL &= String.Format(" product_id = '{0}', ", cbxProduct.SelectedValue)
                SQL &= String.Format(" product = '{0}', ", cbxProduct.Text)
                SQL &= String.Format(" mortgage_id = '{0}', ", MortgageID)
                SQL &= String.Format(" collateral_id = '{0}', ", 0)
                SQL &= String.Format(" collateral = '{0}', ", txtCollateral.Text)
                SQL &= String.Format(" purpose = '{0}', ", "")
                SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" loan_type = '{0}', ", "MIGRATED")
                SQL &= String.Format(" AccountN = '{0}', ", iAccount_2.Text)
                SQL &= String.Format(" CreditNumber = '{0}', ", txtCreditNumber.Text)
                SQL &= String.Format(" interest_rate = '{0}', ", dInterest_T.Value)
                SQL &= String.Format(" rppd_rate = '{0}', ", dRPPDRate_T.Value)
                SQL &= String.Format(" face_amount = '{0}', ", dFA_C.Value)
                SQL &= String.Format(" net_proceeds = '{0}', ", dAmountApplied.Value)
                SQL &= String.Format(" AdvancePayment_Count = '{0}', ", 0)
                SQL &= String.Format(" Note = '{0}', ", "")
                SQL &= String.Format(" Service_Charge = '{0}', ", 0)
                SQL &= String.Format(" Appraisal_Fee = '{0}', ", 0)
                SQL &= String.Format(" CI_Fee = '{0}', ", 0)
                SQL &= String.Format(" Insurance = '{0}', ", 0)
                SQL &= String.Format(" Miscellaneous_Income = '{0}', ", 0)
                SQL &= String.Format(" Advance_Payment = '{0}', ", 0)
                SQL &= String.Format(" Deduct_Balance = '{0}', ", 0)
                SQL &= String.Format(" Interest = '{0}', ", dUDI_C.Value)
                SQL &= String.Format(" RPPD = '{0}', ", dRPPD_C.Value)
                SQL &= String.Format(" GMA = '{0}', ", dGMA_C.Value)
                SQL &= String.Format(" Rebate = '{0}', ", dMR_C.Value)

                If cbxCorporate.Checked Then
                    SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                    SQL &= String.Format(" Prefix_B = '{0}', ", "")
                    SQL &= String.Format(" FirstN_B = '{0}', ", drv("TradeName"))
                    SQL &= String.Format(" MiddleN_B = '{0}', ", "")
                    SQL &= String.Format(" LastN_B = '{0}', ", "")
                    SQL &= String.Format(" Suffix_B = '{0}', ", "")
                    SQL &= String.Format(" Prefix_S = '{0}', ", drv("Prefix_R1"))
                    SQL &= String.Format(" FirstN_S = '{0}', ", drv("FirstN_R1"))
                    SQL &= String.Format(" MiddleN_S = '{0}', ", drv("MiddleN_R1"))
                    SQL &= String.Format(" LastN_S = '{0}', ", drv("LastN_R1"))
                    SQL &= String.Format(" Suffix_S = '{0}', ", drv("Suffix_R1"))
                    SQL &= String.Format(" Prefix_C1 = '{0}', ", drv("Prefix_R2"))
                    SQL &= String.Format(" FirstN_C1 = '{0}', ", drv("FirstN_R2"))
                    SQL &= String.Format(" MiddleN_C1 = '{0}', ", drv("MiddleN_R2"))
                    SQL &= String.Format(" LastN_C1 = '{0}', ", drv("LastN_R2"))
                    SQL &= String.Format(" Suffix_C1 = '{0}', ", drv("Suffix_R2"))
                    SQL &= String.Format(" Prefix_C2 = '{0}', ", drv("Prefix_R3"))
                    SQL &= String.Format(" FirstN_C2 = '{0}', ", drv("FirstN_R3"))
                    SQL &= String.Format(" MiddleN_C2 = '{0}', ", drv("MiddleN_R3"))
                    SQL &= String.Format(" LastN_C2 = '{0}', ", drv("LastN_R3"))
                    SQL &= String.Format(" Suffix_C2 = '{0}', ", drv("Suffix_R3"))
                    SQL &= String.Format(" Prefix_C3 = '{0}', ", drv("Prefix_R4"))
                    SQL &= String.Format(" FirstN_C3 = '{0}', ", drv("FirstN_R4"))
                    SQL &= String.Format(" MiddleN_C3 = '{0}', ", drv("MiddleN_R4"))
                    SQL &= String.Format(" LastN_C3 = '{0}', ", drv("LastN_R4"))
                    SQL &= String.Format(" Suffix_C3 = '{0}', ", drv("Suffix_R4"))
                    SQL &= String.Format(" Prefix_C4 = '{0}', ", drv("Prefix_R5"))
                    SQL &= String.Format(" FirstN_C4 = '{0}', ", drv("FirstN_R5"))
                    SQL &= String.Format(" MiddleN_C4 = '{0}', ", drv("MiddleN_R5"))
                    SQL &= String.Format(" LastN_C4 = '{0}', ", drv("LastN_R5"))
                    SQL &= String.Format(" Suffix_C4 = '{0}', ", drv("Suffix_R5"))
                    SQL &= String.Format(" NoC_B = '{0}', ", drv("No"))
                    SQL &= String.Format(" StreetC_B = '{0}', ", drv("Street"))
                    SQL &= String.Format(" BarangayC_B = '{0}', ", drv("Barangay"))
                    SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", drv("Address-ID"))
                    SQL &= String.Format(" AddressC_B = '{0}', ", drv("Address"))
                    SQL &= String.Format(" NoP_B = '{0}', ", "")
                    SQL &= String.Format(" StreetP_B = '{0}', ", "")
                    SQL &= String.Format(" BarangayP_B = '{0}', ", "")
                    SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", 0)
                    SQL &= String.Format(" AddressP_B = '{0}', ", "")
                    SQL &= String.Format(" Birth_B = '{0}', ", drv("Incorporation"))
                    SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", 0)
                    SQL &= String.Format(" PlaceBirth_B = '{0}', ", "")
                    SQL &= String.Format(" Gender_B = '{0}', ", "")
                    SQL &= String.Format(" Civil_B = '{0}', ", "")
                    SQL &= String.Format(" Citizenship_B = '{0}', ", "")
                    SQL &= String.Format(" TIN_B = '{0}', ", drv("TIN"))
                    SQL &= String.Format(" Telephone_B = '{0}', ", drv("Telephone"))
                    SQL &= String.Format(" SSS_B = '{0}', ", drv("SSS"))
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile.Text)
                    SQL &= String.Format(" Email_B = '{0}', ", txtEmail.Text)
                    SQL &= String.Format(" House_B = '{0}', ", "")
                    SQL &= String.Format(" Rent_B = '{0}', ", 0)

                    SQL &= String.Format(" Prefix_D1 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_D1 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_D1 = '{0}', ", "")
                    SQL &= String.Format(" LastN_D1 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_D1 = '{0}', ", "")
                    SQL &= String.Format(" Birth_D1 = '{0}', ", "")
                    SQL &= String.Format(" Grade_D1 = '{0}', ", "")
                    SQL &= String.Format(" School_D1 = '{0}', ", "")
                    SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_D2 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_D2 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_D2 = '{0}', ", "")
                    SQL &= String.Format(" LastN_D2 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_D2 = '{0}', ", "")
                    SQL &= String.Format(" Birth_D2 = '{0}', ", "")
                    SQL &= String.Format(" Grade_D2 = '{0}', ", "")
                    SQL &= String.Format(" School_D2 = '{0}', ", "")
                    SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_D3 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_D3 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_D3 = '{0}', ", "")
                    SQL &= String.Format(" LastN_D3 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_D3 = '{0}', ", "")
                    SQL &= String.Format(" Birth_D3 = '{0}', ", "")
                    SQL &= String.Format(" Grade_D3 = '{0}', ", "")
                    SQL &= String.Format(" School_D3 = '{0}', ", "")
                    SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_D4 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_D4 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_D4 = '{0}', ", "")
                    SQL &= String.Format(" LastN_D4 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_D4 = '{0}', ", "")
                    SQL &= String.Format(" Birth_D4 = '{0}', ", "")
                    SQL &= String.Format(" Grade_D4 = '{0}', ", "")
                    SQL &= String.Format(" School_D4 = '{0}', ", "")
                    SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", "")

                    SQL &= String.Format(" Employer_B = '{0}', ", "")
                    SQL &= String.Format(" EmployerAddress_B = '{0}', ", "")
                    SQL &= String.Format(" EmployerTelephone_B = '{0}', ", "")
                    SQL &= String.Format(" Position_B = '{0}', ", "")
                    SQL &= String.Format(" EmploymentStat_B = '{0}', ", "")
                    SQL &= String.Format(" Hired_B = '{0}', ", "")
                    SQL &= String.Format(" Supervisor_B = '{0}', ", "")
                    SQL &= String.Format(" Monthly_B = '{0}', ", 0)
                    SQL &= String.Format(" BusinessName_B = '{0}', ", drv("TradeName"))
                    SQL &= String.Format(" BusinessAddress_B = '{0}', ", drv("Address"))
                    SQL &= String.Format(" BusinessTelephone_B = '{0}', ", drv("Telephone"))
                    SQL &= String.Format(" NatureBusiness_B = '{0}', ", "")
                    SQL &= String.Format(" YrsOperation_B = '{0}', ", drv("YearsOperation"))
                    SQL &= String.Format(" BusinessIncome_B = '{0}', ", drv("Gross"))
                    SQL &= String.Format(" NoEmployees_B = '{0}', ", drv("Employees"))
                    SQL &= String.Format(" Capital_B = '{0}', ", 0)
                    SQL &= String.Format(" Area_B = '{0}', ", 0)
                    SQL &= String.Format(" Expiry_B = '{0}', ", "")
                    SQL &= String.Format(" Outlet_B = '{0}', ", 0)
                    SQL &= String.Format(" OtherIncome_B = '{0}', ", "")
                    SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", 0)
                    SQL &= String.Format(" Creditor_1 = '{0}', ", "")
                    SQL &= String.Format(" NatureLoan_1 = '{0}', ", "")
                    SQL &= String.Format(" AmountGranted_1 = '{0}', ", 0)
                    SQL &= String.Format(" Term_1 = '{0}', ", 0)
                    SQL &= String.Format(" Balance_1 = '{0}', ", 0)
                    SQL &= String.Format(" CreditRemarks_1 = '{0}', ", "")
                    SQL &= String.Format(" Creditor_2 = '{0}', ", "")
                    SQL &= String.Format(" NatureLoan_2 = '{0}', ", "")
                    SQL &= String.Format(" AmountGranted_2 = '{0}', ", 0)
                    SQL &= String.Format(" Term_2 = '{0}', ", 0)
                    SQL &= String.Format(" Balance_2 = '{0}', ", 0)
                    SQL &= String.Format(" CreditRemarks_2 = '{0}', ", "")
                    SQL &= String.Format(" Creditor_3 = '{0}', ", "")
                    SQL &= String.Format(" NatureLoan_3 = '{0}', ", "")
                    SQL &= String.Format(" AmountGranted_3 = '{0}', ", 0)
                    SQL &= String.Format(" Term_3 = '{0}', ", 0)
                    SQL &= String.Format(" Balance_3 = '{0}', ", 0)
                    SQL &= String.Format(" CreditRemarks_3 = '{0}', ", "")
                    SQL &= String.Format(" Bank_1 = '{0}', ", "")
                    SQL &= String.Format(" Branch_1 = '{0}', ", "")
                    SQL &= String.Format(" AccountT_1 = '{0}', ", "")
                    SQL &= String.Format(" SA_1 = '{0}', ", "")
                    SQL &= String.Format(" AverageBalance_1 = '{0}', ", 0)
                    SQL &= String.Format(" PresentBalance_1 = '{0}', ", 0)
                    SQL &= String.Format(" Opened_1 = '{0}', ", "")
                    SQL &= String.Format(" BankRemarks_1 = '{0}', ", "")
                    SQL &= String.Format(" Bank_2 = '{0}', ", "")
                    SQL &= String.Format(" Branch_2 = '{0}', ", "")
                    SQL &= String.Format(" AccountT_2 = '{0}', ", "")
                    SQL &= String.Format(" SA_2 = '{0}', ", "")
                    SQL &= String.Format(" AverageBalance_2 = '{0}', ", 0)
                    SQL &= String.Format(" PresentBalance_2 = '{0}', ", 0)
                    SQL &= String.Format(" Opened_2 = '{0}', ", "")
                    SQL &= String.Format(" BankRemarks_2 = '{0}', ", "")
                    SQL &= String.Format(" Bank_3 = '{0}', ", "")
                    SQL &= String.Format(" Branch_3 = '{0}', ", "")
                    SQL &= String.Format(" AccountT_3 = '{0}', ", "")
                    SQL &= String.Format(" SA_3 = '{0}', ", "")
                    SQL &= String.Format(" AverageBalance_3 = '{0}', ", 0)
                    SQL &= String.Format(" PresentBalance_3 = '{0}', ", 0)
                    SQL &= String.Format(" Opened_3 = '{0}', ", "")
                    SQL &= String.Format(" BankRemarks_3 = '{0}', ", "")
                    SQL &= String.Format(" Location_1 = '{0}', ", "")
                    SQL &= String.Format(" TCT_1 = '{0}', ", "")
                    SQL &= String.Format(" Area_1 = '{0}', ", 0)
                    SQL &= String.Format(" Acquired_1 = '{0}', ", "")
                    SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", "")
                    SQL &= String.Format(" Location_2 = '{0}', ", "")
                    SQL &= String.Format(" TCT_2 = '{0}', ", "")
                    SQL &= String.Format(" Area_2 = '{0}', ", 0)
                    SQL &= String.Format(" Acquired_2 = '{0}', ", "")
                    SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", "")
                    SQL &= String.Format(" Location_3 = '{0}', ", "")
                    SQL &= String.Format(" TCT_3 = '{0}', ", "")
                    SQL &= String.Format(" Area_3 = '{0}', ", 0)
                    SQL &= String.Format(" Acquired_3 = '{0}', ", "")
                    SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", "")
                    SQL &= String.Format(" Vehicle_1 = '{0}', ", "")
                    SQL &= String.Format(" Year_1 = '{0}', ", "")
                    SQL &= String.Format(" WhomAcquired_1 = '{0}', ", "")
                    SQL &= String.Format(" WhenAcquired_1 = '{0}', ", "")
                    SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", "")
                    SQL &= String.Format(" Vehicle_2 = '{0}', ", "")
                    SQL &= String.Format(" Year_2 = '{0}', ", "")
                    SQL &= String.Format(" WhomAcquired_2 = '{0}', ", "")
                    SQL &= String.Format(" WhenAcquired_2 = '{0}', ", "")
                    SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", "")
                    SQL &= String.Format(" Vehicle_3 = '{0}', ", "")
                    SQL &= String.Format(" Year_3 = '{0}', ", "")
                    SQL &= String.Format(" WhomAcquired_3 = '{0}', ", "")
                    SQL &= String.Format(" WhenAcquired_3 = '{0}', ", "")
                    SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", "")
                    SQL &= String.Format(" HomeAppliances_1 = '{0}', ", "")
                    SQL &= String.Format(" HomeAppliances_2 = '{0}', ", "")
                    SQL &= String.Format(" Reference_1 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceContact_1 = '{0}', ", "")
                    SQL &= String.Format(" Reference_2 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceContact_2 = '{0}', ", "")
                    SQL &= String.Format(" Reference_3 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", "")
                    SQL &= String.Format(" ReferenceContact_3 = '{0}', ", "")
                    SQL &= String.Format(" CertificateNo = '{0}', ", "")
                    SQL &= String.Format(" PlaceIssue = '{0}', ", "")
                    SQL &= String.Format(" Issue = '{0}', ", "")
                Else
                    SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                    SQL &= String.Format(" Prefix_B = '{0}', ", drv("Prefix_B"))
                    SQL &= String.Format(" FirstN_B = '{0}', ", drv("FirstN_B"))
                    SQL &= String.Format(" MiddleN_B = '{0}', ", drv("MiddleN_B"))
                    SQL &= String.Format(" LastN_B = '{0}', ", drv("LastN_B"))
                    SQL &= String.Format(" Suffix_B = '{0}', ", drv("Suffix_B"))
                    SQL &= String.Format(" Prefix_S = '{0}', ", drv("Prefix_S"))
                    SQL &= String.Format(" FirstN_S = '{0}', ", drv("FirstN_S"))
                    SQL &= String.Format(" MiddleN_S = '{0}', ", drv("MiddleN_S"))
                    SQL &= String.Format(" LastN_S = '{0}', ", drv("LastN_S"))
                    SQL &= String.Format(" Suffix_S = '{0}', ", drv("Suffix_S"))
                    SQL &= String.Format(" Prefix_C1 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_C1 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_C1 = '{0}', ", "")
                    SQL &= String.Format(" LastN_C1 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_C1 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_C2 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_C2 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_C2 = '{0}', ", "")
                    SQL &= String.Format(" LastN_C2 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_C2 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_C3 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_C3 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_C3 = '{0}', ", "")
                    SQL &= String.Format(" LastN_C3 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_C3 = '{0}', ", "")
                    SQL &= String.Format(" Prefix_C4 = '{0}', ", "")
                    SQL &= String.Format(" FirstN_C4 = '{0}', ", "")
                    SQL &= String.Format(" MiddleN_C4 = '{0}', ", "")
                    SQL &= String.Format(" LastN_C4 = '{0}', ", "")
                    SQL &= String.Format(" Suffix_C4 = '{0}', ", "")
                    SQL &= String.Format(" NoC_B = '{0}', ", drv("NoC_B"))
                    SQL &= String.Format(" StreetC_B = '{0}', ", drv("StreetC_B"))
                    SQL &= String.Format(" BarangayC_B = '{0}', ", drv("BarangayC_B"))
                    SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", drv("AddressC_B-ID"))
                    SQL &= String.Format(" AddressC_B = '{0}', ", drv("AddressC_B"))
                    SQL &= String.Format(" NoP_B = '{0}', ", drv("NoP_B"))
                    SQL &= String.Format(" StreetP_B = '{0}', ", drv("StreetP_B"))
                    SQL &= String.Format(" BarangayP_B = '{0}', ", drv("BarangayP_B"))
                    SQL &= String.Format(" `AddressP_B-ID` = '{0}', ", drv("AddressP_B-ID"))
                    SQL &= String.Format(" AddressP_B = '{0}', ", drv("AddressP_B"))
                    SQL &= String.Format(" Birth_B = '{0}', ", drv("Birth_B"))
                    SQL &= String.Format(" `PlaceBirth_B-ID` = '{0}', ", drv("PlaceBirth_B-ID"))
                    SQL &= String.Format(" PlaceBirth_B = '{0}', ", drv("PlaceBirth_B"))
                    SQL &= String.Format(" Gender_B = '{0}', ", drv("Gender_B"))
                    SQL &= String.Format(" Civil_B = '{0}', ", drv("Civil_B"))
                    SQL &= String.Format(" Citizenship_B = '{0}', ", drv("Citizenship_B"))
                    SQL &= String.Format(" TIN_B = '{0}', ", drv("TIN_B"))
                    SQL &= String.Format(" Telephone_B = '{0}', ", drv("Telephone_B"))
                    SQL &= String.Format(" SSS_B = '{0}', ", drv("SSS_B"))
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile.Text)
                    SQL &= String.Format(" Email_B = '{0}', ", txtEmail.Text)
                    SQL &= String.Format(" House_B = '{0}', ", drv("House_B"))
                    SQL &= String.Format(" Rent_B = '{0}', ", drv("Rent_B"))

                    SQL &= String.Format(" Prefix_D1 = '{0}', ", drv("Prefix_D1"))
                    SQL &= String.Format(" FirstN_D1 = '{0}', ", drv("FirstN_D1"))
                    SQL &= String.Format(" MiddleN_D1 = '{0}', ", drv("MiddleN_D1"))
                    SQL &= String.Format(" LastN_D1 = '{0}', ", drv("LastN_D1"))
                    SQL &= String.Format(" Suffix_D1 = '{0}', ", drv("Suffix_D1"))
                    SQL &= String.Format(" Birth_D1 = '{0}', ", drv("Birth_D1"))
                    SQL &= String.Format(" Grade_D1 = '{0}', ", drv("Grade_D1"))
                    SQL &= String.Format(" School_D1 = '{0}', ", drv("School_D1"))
                    SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", drv("SchoolAddress_D1"))
                    SQL &= String.Format(" Prefix_D2 = '{0}', ", drv("Prefix_D2"))
                    SQL &= String.Format(" FirstN_D2 = '{0}', ", drv("FirstN_D2"))
                    SQL &= String.Format(" MiddleN_D2 = '{0}', ", drv("MiddleN_D2"))
                    SQL &= String.Format(" LastN_D2 = '{0}', ", drv("LastN_D2"))
                    SQL &= String.Format(" Suffix_D2 = '{0}', ", drv("Suffix_D2"))
                    SQL &= String.Format(" Birth_D2 = '{0}', ", drv("Birth_D2"))
                    SQL &= String.Format(" Grade_D2 = '{0}', ", drv("Grade_D2"))
                    SQL &= String.Format(" School_D2 = '{0}', ", drv("School_D2"))
                    SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", drv("SchoolAddress_D2"))
                    SQL &= String.Format(" Prefix_D3 = '{0}', ", drv("Prefix_D3"))
                    SQL &= String.Format(" FirstN_D3 = '{0}', ", drv("FirstN_D3"))
                    SQL &= String.Format(" MiddleN_D3 = '{0}', ", drv("MiddleN_D3"))
                    SQL &= String.Format(" LastN_D3 = '{0}', ", drv("LastN_D3"))
                    SQL &= String.Format(" Suffix_D3 = '{0}', ", drv("Suffix_D3"))
                    SQL &= String.Format(" Birth_D3 = '{0}', ", drv("Birth_D3"))
                    SQL &= String.Format(" Grade_D3 = '{0}', ", drv("Grade_D3"))
                    SQL &= String.Format(" School_D3 = '{0}', ", drv("School_D3"))
                    SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", drv("SchoolAddress_D3"))
                    SQL &= String.Format(" Prefix_D4 = '{0}', ", drv("Prefix_D4"))
                    SQL &= String.Format(" FirstN_D4 = '{0}', ", drv("FirstN_D4"))
                    SQL &= String.Format(" MiddleN_D4 = '{0}', ", drv("MiddleN_D4"))
                    SQL &= String.Format(" LastN_D4 = '{0}', ", drv("LastN_D4"))
                    SQL &= String.Format(" Suffix_D4 = '{0}', ", drv("Suffix_D4"))
                    SQL &= String.Format(" Birth_D4 = '{0}', ", drv("Birth_D4"))
                    SQL &= String.Format(" Grade_D4 = '{0}', ", drv("Grade_D4"))
                    SQL &= String.Format(" School_D4 = '{0}', ", drv("School_D4"))
                    SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", drv("SchoolAddress_D4"))

                    SQL &= String.Format(" Employer_B = '{0}', ", drv("Employer_B"))
                    SQL &= String.Format(" EmployerAddress_B = '{0}', ", drv("EmployerAddress_B"))
                    SQL &= String.Format(" EmployerTelephone_B = '{0}', ", drv("EmployerTelephone_B"))
                    SQL &= String.Format(" Position_B = '{0}', ", drv("Position_B"))
                    SQL &= String.Format(" EmploymentStat_B = '{0}', ", drv("EmploymentStat_B"))
                    SQL &= String.Format(" Hired_B = '{0}', ", drv("Hired_B"))
                    SQL &= String.Format(" Supervisor_B = '{0}', ", drv("Supervisor_B"))
                    SQL &= String.Format(" Monthly_B = '{0}', ", drv("Monthly_B"))
                    SQL &= String.Format(" BusinessName_B = '{0}', ", drv("BusinessName_B"))
                    SQL &= String.Format(" BusinessAddress_B = '{0}', ", drv("BusinessAddress_B"))
                    SQL &= String.Format(" BusinessTelephone_B = '{0}', ", drv("BusinessTelephone_B"))
                    SQL &= String.Format(" NatureBusiness_B = '{0}', ", drv("NatureBusiness_B"))
                    SQL &= String.Format(" YrsOperation_B = '{0}', ", drv("YrsOperation_B"))
                    SQL &= String.Format(" BusinessIncome_B = '{0}', ", drv("BusinessIncome_B"))
                    SQL &= String.Format(" NoEmployees_B = '{0}', ", drv("NoEmployees_B"))
                    SQL &= String.Format(" Capital_B = '{0}', ", drv("Capital_B"))
                    SQL &= String.Format(" Area_B = '{0}', ", drv("Area_B"))
                    SQL &= String.Format(" Expiry_B = '{0}', ", drv("Expiry_B"))
                    SQL &= String.Format(" Outlet_B = '{0}', ", drv("Outlet_B"))
                    SQL &= String.Format(" OtherIncome_B = '{0}', ", drv("OtherIncome_B"))
                    SQL &= String.Format(" `OtherIncome_B-Amount` = '{0}', ", drv("OtherIncome_B-Amount"))
                    SQL &= String.Format(" Creditor_1 = '{0}', ", drv("Creditor_1"))
                    SQL &= String.Format(" NatureLoan_1 = '{0}', ", drv("NatureLoan_1"))
                    SQL &= String.Format(" AmountGranted_1 = '{0}', ", drv("AmountGranted_1"))
                    SQL &= String.Format(" Term_1 = '{0}', ", drv("Term_1"))
                    SQL &= String.Format(" Balance_1 = '{0}', ", drv("Balance_1"))
                    SQL &= String.Format(" CreditRemarks_1 = '{0}', ", drv("CreditRemarks_1"))
                    SQL &= String.Format(" Creditor_2 = '{0}', ", drv("Creditor_2"))
                    SQL &= String.Format(" NatureLoan_2 = '{0}', ", drv("NatureLoan_2"))
                    SQL &= String.Format(" AmountGranted_2 = '{0}', ", drv("AmountGranted_2"))
                    SQL &= String.Format(" Term_2 = '{0}', ", drv("Term_2"))
                    SQL &= String.Format(" Balance_2 = '{0}', ", drv("Balance_2"))
                    SQL &= String.Format(" CreditRemarks_2 = '{0}', ", drv("CreditRemarks_2"))
                    SQL &= String.Format(" Creditor_3 = '{0}', ", drv("Creditor_3"))
                    SQL &= String.Format(" NatureLoan_3 = '{0}', ", drv("NatureLoan_3"))
                    SQL &= String.Format(" AmountGranted_3 = '{0}', ", drv("AmountGranted_3"))
                    SQL &= String.Format(" Term_3 = '{0}', ", drv("Term_3"))
                    SQL &= String.Format(" Balance_3 = '{0}', ", drv("Balance_3"))
                    SQL &= String.Format(" CreditRemarks_3 = '{0}', ", drv("CreditRemarks_3"))
                    SQL &= String.Format(" Bank_1 = '{0}', ", drv("Bank_1"))
                    SQL &= String.Format(" Branch_1 = '{0}', ", drv("Branch_1"))
                    SQL &= String.Format(" AccountT_1 = '{0}', ", drv("AccountT_1"))
                    SQL &= String.Format(" SA_1 = '{0}', ", drv("SA_1"))
                    SQL &= String.Format(" AverageBalance_1 = '{0}', ", drv("AverageBalance_1"))
                    SQL &= String.Format(" PresentBalance_1 = '{0}', ", drv("PresentBalance_1"))
                    SQL &= String.Format(" Opened_1 = '{0}', ", drv("Opened_1"))
                    SQL &= String.Format(" BankRemarks_1 = '{0}', ", drv("BankRemarks_1"))
                    SQL &= String.Format(" Bank_2 = '{0}', ", drv("Bank_2"))
                    SQL &= String.Format(" Branch_2 = '{0}', ", drv("Branch_2"))
                    SQL &= String.Format(" AccountT_2 = '{0}', ", drv("AccountT_2"))
                    SQL &= String.Format(" SA_2 = '{0}', ", drv("SA_2"))
                    SQL &= String.Format(" AverageBalance_2 = '{0}', ", drv("AverageBalance_2"))
                    SQL &= String.Format(" PresentBalance_2 = '{0}', ", drv("PresentBalance_2"))
                    SQL &= String.Format(" Opened_2 = '{0}', ", drv("Opened_2"))
                    SQL &= String.Format(" BankRemarks_2 = '{0}', ", drv("BankRemarks_2"))
                    SQL &= String.Format(" Bank_3 = '{0}', ", drv("Bank_3"))
                    SQL &= String.Format(" Branch_3 = '{0}', ", drv("Branch_3"))
                    SQL &= String.Format(" AccountT_3 = '{0}', ", drv("AccountT_3"))
                    SQL &= String.Format(" SA_3 = '{0}', ", drv("SA_3"))
                    SQL &= String.Format(" AverageBalance_3 = '{0}', ", drv("AverageBalance_3"))
                    SQL &= String.Format(" PresentBalance_3 = '{0}', ", drv("PresentBalance_3"))
                    SQL &= String.Format(" Opened_3 = '{0}', ", drv("Opened_3"))
                    SQL &= String.Format(" BankRemarks_3 = '{0}', ", drv("BankRemarks_3"))
                    SQL &= String.Format(" Location_1 = '{0}', ", drv("Location_1"))
                    SQL &= String.Format(" TCT_1 = '{0}', ", drv("TCT_1"))
                    SQL &= String.Format(" Area_1 = '{0}', ", drv("Area_1"))
                    SQL &= String.Format(" Acquired_1 = '{0}', ", drv("Acquired_1"))
                    SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", drv("PropertiesRemarks_1"))
                    SQL &= String.Format(" Location_2 = '{0}', ", drv("Location_2"))
                    SQL &= String.Format(" TCT_2 = '{0}', ", drv("TCT_2"))
                    SQL &= String.Format(" Area_2 = '{0}', ", drv("Area_2"))
                    SQL &= String.Format(" Acquired_2 = '{0}', ", drv("Acquired_2"))
                    SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", drv("PropertiesRemarks_2"))
                    SQL &= String.Format(" Location_3 = '{0}', ", drv("Location_3"))
                    SQL &= String.Format(" TCT_3 = '{0}', ", drv("TCT_3"))
                    SQL &= String.Format(" Area_3 = '{0}', ", drv("Area_3"))
                    SQL &= String.Format(" Acquired_3 = '{0}', ", drv("Acquired_3"))
                    SQL &= String.Format(" PropertiesRemarks_3 = '{0}', ", drv("PropertiesRemarks_3"))
                    SQL &= String.Format(" Vehicle_1 = '{0}', ", drv("Vehicle_1"))
                    SQL &= String.Format(" Year_1 = '{0}', ", drv("Year_1"))
                    SQL &= String.Format(" WhomAcquired_1 = '{0}', ", drv("WhomAcquired_1"))
                    SQL &= String.Format(" WhenAcquired_1 = '{0}', ", drv("WhenAcquired_1"))
                    SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", drv("VehicleRemarks_1"))
                    SQL &= String.Format(" Vehicle_2 = '{0}', ", drv("Vehicle_2"))
                    SQL &= String.Format(" Year_2 = '{0}', ", drv("Year_2"))
                    SQL &= String.Format(" WhomAcquired_2 = '{0}', ", drv("WhomAcquired_2"))
                    SQL &= String.Format(" WhenAcquired_2 = '{0}', ", drv("WhenAcquired_2"))
                    SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", drv("VehicleRemarks_2"))
                    SQL &= String.Format(" Vehicle_3 = '{0}', ", drv("Vehicle_3"))
                    SQL &= String.Format(" Year_3 = '{0}', ", drv("Year_3"))
                    SQL &= String.Format(" WhomAcquired_3 = '{0}', ", drv("WhomAcquired_3"))
                    SQL &= String.Format(" WhenAcquired_3 = '{0}', ", drv("WhenAcquired_3"))
                    SQL &= String.Format(" VehicleRemarks_3 = '{0}', ", drv("VehicleRemarks_3"))
                    SQL &= String.Format(" HomeAppliances_1 = '{0}', ", drv("HomeAppliances_1"))
                    SQL &= String.Format(" HomeAppliances_2 = '{0}', ", drv("HomeAppliances_2"))
                    SQL &= String.Format(" Reference_1 = '{0}', ", drv("Reference_1"))
                    SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", drv("ReferenceAddress_1"))
                    SQL &= String.Format(" ReferenceContact_1 = '{0}', ", drv("ReferenceContact_1"))
                    SQL &= String.Format(" Reference_2 = '{0}', ", drv("Reference_2"))
                    SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", drv("ReferenceAddress_2"))
                    SQL &= String.Format(" ReferenceContact_2 = '{0}', ", drv("ReferenceContact_2"))
                    SQL &= String.Format(" Reference_3 = '{0}', ", drv("Reference_3"))
                    SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", drv("ReferenceAddress_3"))
                    SQL &= String.Format(" ReferenceContact_3 = '{0}', ", drv("ReferenceContact_3"))
                    SQL &= String.Format(" CertificateNo = '{0}', ", drv("CertificateNo"))
                    SQL &= String.Format(" PlaceIssue = '{0}', ", drv("PlaceIssue"))
                    SQL &= String.Format(" Issue = '{0}', ", drv("Issue"))
                End If

                SQL &= String.Format(" `AgentID` = '{0}', ", drv("AgentID"))
                SQL &= String.Format(" Agent = '{0}', ", drv("Agent"))
                SQL &= String.Format(" AgentNo = '{0}', ", drv("AgentNo"))
                SQL &= String.Format(" `MarketingID` = '{0}', ", drv("MarketingID"))
                SQL &= String.Format(" Marketing = '{0}', ", drv("Marketing"))
                SQL &= String.Format(" MarketingNo = '{0}', ", drv("MarketingNo"))
                SQL &= String.Format(" `WalkinID` = '{0}', ", drv("WalkinID"))
                SQL &= String.Format(" WalkIn = '{0}', ", drv("WalkIn"))
                SQL &= String.Format(" WalkIn_Specify = '{0}', ", drv("WalkIn_Specify"))
                SQL &= String.Format(" `DealerID` = '{0}', ", drv("DealerID"))
                SQL &= String.Format(" Dealer = '{0}', ", drv("Dealer"))
                SQL &= String.Format(" DealerNo = '{0}', ", drv("DealerNo"))
                SQL &= String.Format(" application_status = '{0}', ", "APPROVED")
                SQL &= String.Format(" CI_Status = '{0}', ", "APPROVED")
                SQL &= String.Format(" CI_ApprovedDate = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" PaymentRequest = '{0}', ", "RELEASED")
                SQL &= String.Format(" Assigned_CI = '{0}', ", ValidateComboBox(cbxCI))
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" BusinessID = '{0}', ", ValidateComboBox(cbxBusinessCenter))
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= String.Format(" Interest_N = '{0}', ", If(btnEdit.Enabled, 0, dInterest_N.Value))
                SQL &= String.Format(" RPPD_N = '{0}', ", If(btnEdit.Enabled, 0, dRPPD_N.Value))
                SQL &= String.Format(" Principal_N = '{0}', ", If(btnEdit.Enabled, 0, dPrincipal_N.Value))
                SQL &= String.Format(" PD_ATM = '{0}', ", If(PD_ATM, 1, 0))
                SQL &= String.Format(" PD_CardNumber = '{0}', ", PD_CardNumber)
                SQL &= String.Format(" PD_AccountNumber = '{0}', ", PD_AccountNumber)
                SQL &= String.Format(" PD_BankID = '{0}', ", PD_BankID)
                SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text.InsertQuote)

                SQL &= String.Format(" AccountNumber = '{0}', ", iAccount_2.Text)
                SQL &= String.Format(" InsuranceComp = '{0}', ", "")
                SQL &= String.Format(" Coverage = '{0}', ", 0)
                SQL &= String.Format(" Expiry = '{0}', ", "")
                SQL &= String.Format(" Premium = '{0}', ", 0)
                SQL &= String.Format(" CVNum = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" CVNumber = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" Release_Insurance = '{0}', ", "")
                SQL &= String.Format(" Released = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" PN = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" FDD = '{0}', ", FormatDatePicker(dtpFDD))
                SQL &= String.Format(" LDD = '{0}', ", Format(CDate(GridView1.GetRowCellValue(GridView1.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
                SQL &= String.Format(" CI = '{0}', ", cbxCI.Text)
                SQL &= String.Format(" Referred = '{0}', ", drv("Marketing"))
                SQL &= String.Format(" Notes = '{0}', ", "Migrated Application")
                SQL &= String.Format(" Release_Remarks = '{0}', ", rRemarks.Text)

                SQL &= String.Format(" user_code = '{0}';", User_Code)
                For x As Integer = 0 To cbxNatureBusiness_B2.Properties.Items.Count - 1
                    If cbxNatureBusiness_B2.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                        SQL &= "INSERT INTO credit_application_industry SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", txtCreditNumber.Text)
                        SQL &= String.Format(" Industry_ID = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Value)
                        SQL &= String.Format(" Industry = '{0}', ", cbxNatureBusiness_B2.Properties.Items.Item(x).Description)
                        SQL &= " `Type` = 'Borrower';"
                    End If
                Next

                'BORROWER INFORMATION
                If cbxCorporate.Checked Then
                    SQL &= "UPDATE profile_corporation SET"
                    SQL &= String.Format(" Email = '{0}' WHERE BorrowerID = '{1}';", txtEmail.Text, cbxBorrower.SelectedValue)
                Else
                    SQL &= "UPDATE profile_borrower SET"
                    SQL &= String.Format(" Mobile_B = '{0}', ", txtMobile.Text)
                    SQL &= String.Format(" Email_B = '{0}' WHERE BorrowerID = '{1}';", txtEmail.Text, cbxBorrower.SelectedValue)
                End If

                '*************AMORTIZATION SCHEDULE 
Here:
                If From_OfficialReceipt Then
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                    SQL &= " UPDATE credit_application SET "
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                    SQL &= String.Format(" Interest_N = '{0}', ", If(btnEdit.Enabled, 0, dInterest_N.Value))
                    SQL &= String.Format(" RPPD_N = '{0}', ", If(btnEdit.Enabled, 0, dRPPD_N.Value))
                    SQL &= String.Format(" AddPenaltyAmortization = {0}, ", AddPenalty)

                    SQL &= String.Format(" Released = '{0}', ", Format(dtpAvailedV2.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" PN = '{0}', ", Format(dtpAvailedV2.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" FDD = '{0}', ", Format(CDate(GridView1.GetRowCellValue(1, "Due Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" LDD = '{0}', ", Format(CDate(GridView1.GetRowCellValue(GridView1.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" Principal_N = '{0}', MigratedValidation = 1 WHERE CreditNumber = '{1}';", If(btnEdit.Enabled, 0, dPrincipal_N.Value), txtCreditNumber.Text)

                    SQL &= String.Format("UPDATE credit_schedule SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", txtCreditNumber.Text)
                End If
                For x As Integer = 0 To GridView1.RowCount - 2
                    If GridView1.GetRowCellValue(x, "No") = "" Then
                        SQL &= " INSERT INTO credit_schedule SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", txtCreditNumber.Text)
                        SQL &= String.Format(" `No` = '{0}', ", GridView1.GetRowCellValue(x, "No"))
                        SQL &= String.Format(" DueDate = '{0}', ", "")
                        SQL &= String.Format(" Monthly = '{0}', ", 0)
                        SQL &= String.Format(" InterestIncome = '{0}', ", 0)
                        SQL &= String.Format(" RPPD = '{0}', ", 0)
                        SQL &= String.Format(" PrincipalAllocation = '{0}', ", 0)
                        SQL &= String.Format(" Penalty = '{0}', ", 0)
                        SQL &= String.Format(" PenaltyBalance = '{0}', ", If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty Balance")), CDbl(GridView1.GetRowCellValue(x, "Penalty Balance")), 0))
                        SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")))
                        SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")))
                        SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unearn Income")))
                        SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView1.GetRowCellValue(x, "Loans Receivable")))
                    Else
                        SQL &= " INSERT INTO credit_schedule SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", txtCreditNumber.Text)
                        SQL &= String.Format(" `No` = '{0}', ", GridView1.GetRowCellValue(x, "No"))
                        SQL &= String.Format(" DueDate = '{0}', ", Format(DateValue(GridView1.GetRowCellValue(x, "Due Date")), "yyyy-MM-dd"))
                        SQL &= String.Format(" Monthly = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Monthly")))
                        SQL &= String.Format(" Penalty = '{0}', ", If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty")), CDbl(GridView1.GetRowCellValue(x, "Penalty")), 0))
                        SQL &= String.Format(" PenaltyBalance = '{0}', ", If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty Balance")), CDbl(GridView1.GetRowCellValue(x, "Penalty Balance")), 0))
                        SQL &= String.Format(" InterestIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Interest Income")))
                        SQL &= String.Format(" RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "RPPD")))
                        SQL &= String.Format(" PrincipalAllocation = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")))
                        SQL &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")))
                        SQL &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")))
                        SQL &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView1.GetRowCellValue(x, "Unearn Income")))
                        SQL &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView1.GetRowCellValue(x, "Loans Receivable")))
                    End If
                Next
                If From_OfficialReceipt Then
                    GoTo HereV2
                End If
                '*************AMORTIZATION SCHEDULE 

                'CREDIT INVESTIGATION
                If MortgageID = 1 Or MortgageID = 2 Then
                    SQL &= "INSERT INTO credit_investigation SET"
                    SQL &= String.Format(" CINumber = '{0}', ", DataObject(String.Format("SELECT CONCAT('CI', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM credit_investigation WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpAvailed.Value, "yyyyMM"), Format(dtpAvailed.Value, "yyyy-MM-dd"))))
                    SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpAvailed))
                    SQL &= String.Format(" CreditNumber = '{0}', ", txtCreditNumber.Text)
                    SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                    If cbxCorporate.Checked Then
                        SQL &= String.Format(" Prefix_B = '{0}', ", "")
                        SQL &= String.Format(" FirstN_B = '{0}', ", drv("TradeName"))
                        SQL &= String.Format(" MiddleN_B = '{0}', ", "")
                        SQL &= String.Format(" LastN_B = '{0}', ", "")
                        SQL &= String.Format(" Suffix_B = '{0}', ", "")
                        SQL &= String.Format(" NoC_B = '{0}', ", drv("No"))
                        SQL &= String.Format(" StreetC_B = '{0}', ", drv("Street"))
                        SQL &= String.Format(" BarangayC_B = '{0}', ", drv("Barangay"))
                        SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", drv("Address-ID"))
                        SQL &= String.Format(" AddressC_B = '{0}', ", drv("Address"))

                        SQL &= String.Format(" Residence_B = '{0}', ", "")
                        SQL &= String.Format(" House_B = '{0}', ", "")
                        SQL &= String.Format(" Rent_B = '{0}', ", 0)
                        SQL &= String.Format(" AsConfirmed = '{0}', ", "")
                        SQL &= String.Format(" LenghtOfStay = '{0}', ", "")
                        SQL &= String.Format(" Neighborhood = '{0}', ", "")
                        SQL &= String.Format(" Birth_B = '{0}', ", drv("Incorporation"))
                        SQL &= String.Format(" Civil_B = '{0}', ", "")

                        SQL &= String.Format(" Prefix_D1 = '{0}', ", "")
                        SQL &= String.Format(" FirstN_D1 = '{0}', ", "")
                        SQL &= String.Format(" MiddleN_D1 = '{0}', ", "")
                        SQL &= String.Format(" LastN_D1 = '{0}', ", "")
                        SQL &= String.Format(" Suffix_D1 = '{0}', ", "")
                        SQL &= String.Format(" Birth_D1 = '{0}', ", "")
                        SQL &= String.Format(" Grade_D1 = '{0}', ", "")
                        SQL &= String.Format(" School_D1 = '{0}', ", "")
                        SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", "")
                        SQL &= String.Format(" Prefix_D2 = '{0}', ", "")
                        SQL &= String.Format(" FirstN_D2 = '{0}', ", "")
                        SQL &= String.Format(" MiddleN_D2 = '{0}', ", "")
                        SQL &= String.Format(" LastN_D2 = '{0}', ", "")
                        SQL &= String.Format(" Suffix_D2 = '{0}', ", "")
                        SQL &= String.Format(" Birth_D2 = '{0}', ", "")
                        SQL &= String.Format(" Grade_D2 = '{0}', ", "")
                        SQL &= String.Format(" School_D2 = '{0}', ", "")
                        SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", "")
                        SQL &= String.Format(" Prefix_D3 = '{0}', ", "")
                        SQL &= String.Format(" FirstN_D3 = '{0}', ", "")
                        SQL &= String.Format(" MiddleN_D3 = '{0}', ", "")
                        SQL &= String.Format(" LastN_D3 = '{0}', ", "")
                        SQL &= String.Format(" Suffix_D3 = '{0}', ", "")
                        SQL &= String.Format(" Birth_D3 = '{0}', ", "")
                        SQL &= String.Format(" Grade_D3 = '{0}', ", "")
                        SQL &= String.Format(" School_D3 = '{0}', ", "")
                        SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", "")
                        SQL &= String.Format(" Prefix_D4 = '{0}', ", "")
                        SQL &= String.Format(" FirstN_D4 = '{0}', ", "")
                        SQL &= String.Format(" MiddleN_D4 = '{0}', ", "")
                        SQL &= String.Format(" LastN_D4 = '{0}', ", "")
                        SQL &= String.Format(" Suffix_D4 = '{0}', ", "")
                        SQL &= String.Format(" Birth_D4 = '{0}', ", "")
                        SQL &= String.Format(" Grade_D4 = '{0}', ", "")
                        SQL &= String.Format(" School_D4 = '{0}', ", "")
                        SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", "")

                        SQL &= String.Format(" Employer_B = '{0}', ", "")
                        SQL &= String.Format(" EmployerAddress_B = '{0}', ", "")
                        SQL &= String.Format(" Hired_B = '{0}', ", "")
                        SQL &= String.Format(" EmploymentStat_B = '{0}', ", "")
                        SQL &= String.Format(" Position_B = '{0}', ", "")
                        SQL &= String.Format(" Monthly_B = '{0}', ", 0)
                        SQL &= String.Format(" BusinessName_B = '{0}', ", drv("TradeName"))
                        SQL &= String.Format(" BusinessAddress_B = '{0}', ", "")
                        SQL &= String.Format(" BusinessStarted = '{0}', ", "")
                        SQL &= String.Format(" NatureBusiness_B = '{0}', ", "")
                        SQL &= String.Format(" Capital_B = '{0}', ", 0)
                        SQL &= String.Format(" NoEmployees_B = '{0}', ", drv("Employees"))
                        SQL &= String.Format(" BusinessStock = '{0}', ", 0)
                        SQL &= String.Format(" BusinessVehicle = '{0}', ", "")
                        SQL &= String.Format(" BusinessIncome_B = '{0}', ", drv("Gross"))
                        SQL &= String.Format(" BusinessPermit = '{0}', ", "")
                        SQL &= String.Format(" OtherIncome_B = '{0}', ", "")
                        SQL &= String.Format(" OtherIncome_B_Amount = '{0}', ", 0)
                        SQL &= String.Format(" Creditor_1 = '{0}', ", "")
                        SQL &= String.Format(" CreditAddress_1 = '{0}', ", "")
                        SQL &= String.Format(" CreditGranted_1 = '{0}', ", "")
                        SQL &= String.Format(" Term_1 = '{0}', ", 0)
                        SQL &= String.Format(" AmountGranted_1 = '{0}', ", 0)
                        SQL &= String.Format(" Balance_1 = '{0}', ", 0)
                        SQL &= String.Format(" CreditPayment_1 = '{0}', ", 0)
                        SQL &= String.Format(" CreditRemarks_1 = '{0}', ", "")
                        SQL &= String.Format(" Creditor_2 = '{0}', ", "")
                        SQL &= String.Format(" CreditAddress_2 = '{0}', ", "")
                        SQL &= String.Format(" CreditGranted_2 = '{0}', ", "")
                        SQL &= String.Format(" Term_2 = '{0}', ", 0)
                        SQL &= String.Format(" AmountGranted_2 = '{0}', ", 0)
                        SQL &= String.Format(" Balance_2 = '{0}', ", 0)
                        SQL &= String.Format(" CreditPayment_2 = '{0}', ", 0)
                        SQL &= String.Format(" CreditRemarks_2 = '{0}', ", "")

                        SQL &= String.Format(" Bank_1 = '{0}', ", "")
                        SQL &= String.Format(" Branch_1 = '{0}', ", "")
                        SQL &= String.Format(" AccountT_1 = '{0}', ", "")
                        SQL &= String.Format(" SA_1 = '{0}', ", "")
                        SQL &= String.Format(" AverageBalance_1 = '{0}', ", 0)
                        SQL &= String.Format(" Opened_1 = '{0}', ", "")
                        SQL &= String.Format(" Bank_2 = '{0}', ", "")
                        SQL &= String.Format(" Branch_2 = '{0}', ", "")
                        SQL &= String.Format(" AccountT_2 = '{0}', ", "")
                        SQL &= String.Format(" SA_2 = '{0}', ", "")
                        SQL &= String.Format(" AverageBalance_2 = '{0}', ", 0)
                        SQL &= String.Format(" Opened_2 = '{0}', ", "")

                        SQL &= String.Format(" CreditRating = '{0}', ", "")
                        SQL &= String.Format(" RecommendationFor = '{0}', ", "")
                        SQL &= String.Format(" Rec_ApprovedAmount = '{0}', ", dPA_C.Value)
                        SQL &= String.Format(" Rec_ApprovedTerms = '{0}', ", iTerms_C.Value)
                        SQL &= String.Format(" Rec_ApprovedRate = '{0}', ", dInterest_C.Value)
                        SQL &= String.Format(" Rec_PDC = '{0}', ", 1)
                        SQL &= String.Format(" Rec_NoPDC = '{0}', ", 0)
                        SQL &= String.Format(" Rec_Remarks = '{0}', ", "")
                        SQL &= String.Format(" Title = '{0}', ", "")
                        SQL &= String.Format(" CaseNum = '{0}', ", "")
                        SQL &= String.Format(" DateFilled = '{0}', ", "")
                        SQL &= String.Format(" Court = '{0}', ", "")
                        SQL &= String.Format(" CaseNature = '{0}', ", "")
                        SQL &= String.Format(" AmountInvolved = '{0}', ", 0)
                        SQL &= String.Format(" CaseStatus = '{0}', ", "")
                        SQL &= String.Format(" Findings = '{0}', ", "")
                        SQL &= String.Format(" FindingsStat = '{0}', ", "")
                        SQL &= String.Format(" CACPI = '{0}', ", "")

                        SQL &= String.Format(" Location_1 = '{0}', ", "")
                        SQL &= String.Format(" TCT_1 = '{0}', ", "")
                        SQL &= String.Format(" Area_1 = '{0}', ", 0)
                        SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", "")
                        SQL &= String.Format(" Location_2 = '{0}', ", "")
                        SQL &= String.Format(" TCT_2 = '{0}', ", "")
                        SQL &= String.Format(" Area_2 = '{0}', ", 0)
                        SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", "")

                        SQL &= String.Format(" Vehicle_1 = '{0}', ", "")
                        SQL &= String.Format(" Year_1 = '{0}', ", "")
                        SQL &= String.Format(" WhomAcquired_1 = '{0}', ", "")
                        SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", "")
                        SQL &= String.Format(" Vehicle_2 = '{0}', ", "")
                        SQL &= String.Format(" Year_2 = '{0}', ", "")
                        SQL &= String.Format(" WhomAcquired_2 = '{0}', ", "")
                        SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", "")
                    Else
                        SQL &= String.Format(" Prefix_B = '{0}', ", drv("Prefix_B"))
                        SQL &= String.Format(" FirstN_B = '{0}', ", drv("FirstN_B"))
                        SQL &= String.Format(" MiddleN_B = '{0}', ", drv("MiddleN_B"))
                        SQL &= String.Format(" LastN_B = '{0}', ", drv("LastN_B"))
                        SQL &= String.Format(" Suffix_B = '{0}', ", drv("Suffix_B"))
                        SQL &= String.Format(" NoC_B = '{0}', ", drv("NoC_B"))
                        SQL &= String.Format(" StreetC_B = '{0}', ", drv("StreetC_B"))
                        SQL &= String.Format(" BarangayC_B = '{0}', ", drv("BarangayC_B"))
                        SQL &= String.Format(" `AddressC_B-ID` = '{0}', ", drv("AddressC_B-ID"))
                        SQL &= String.Format(" AddressC_B = '{0}', ", drv("AddressC_B"))

                        SQL &= String.Format(" Residence_B = '{0}', ", "")
                        SQL &= String.Format(" House_B = '{0}', ", drv("House_B"))
                        SQL &= String.Format(" Rent_B = '{0}', ", drv("Rent_B"))
                        SQL &= String.Format(" AsConfirmed = '{0}', ", "")
                        SQL &= String.Format(" LenghtOfStay = '{0}', ", "")
                        SQL &= String.Format(" Neighborhood = '{0}', ", "")
                        SQL &= String.Format(" Birth_B = '{0}', ", drv("Birth_B"))
                        SQL &= String.Format(" Civil_B = '{0}', ", drv("Civil_B"))

                        SQL &= String.Format(" Prefix_D1 = '{0}', ", drv("Prefix_D1"))
                        SQL &= String.Format(" FirstN_D1 = '{0}', ", drv("FirstN_D1"))
                        SQL &= String.Format(" MiddleN_D1 = '{0}', ", drv("MiddleN_D1"))
                        SQL &= String.Format(" LastN_D1 = '{0}', ", drv("LastN_D1"))
                        SQL &= String.Format(" Suffix_D1 = '{0}', ", drv("Suffix_D1"))
                        SQL &= String.Format(" Birth_D1 = '{0}', ", drv("Birth_D1"))
                        SQL &= String.Format(" Grade_D1 = '{0}', ", drv("Grade_D1"))
                        SQL &= String.Format(" School_D1 = '{0}', ", drv("School_D1"))
                        SQL &= String.Format(" SchoolAddress_D1 = '{0}', ", drv("SchoolAddress_D1"))
                        SQL &= String.Format(" Prefix_D2 = '{0}', ", drv("Prefix_D2"))
                        SQL &= String.Format(" FirstN_D2 = '{0}', ", drv("FirstN_D2"))
                        SQL &= String.Format(" MiddleN_D2 = '{0}', ", drv("MiddleN_D2"))
                        SQL &= String.Format(" LastN_D2 = '{0}', ", drv("LastN_D2"))
                        SQL &= String.Format(" Suffix_D2 = '{0}', ", drv("Suffix_D2"))
                        SQL &= String.Format(" Birth_D2 = '{0}', ", drv("Birth_D2"))
                        SQL &= String.Format(" Grade_D2 = '{0}', ", drv("Grade_D2"))
                        SQL &= String.Format(" School_D2 = '{0}', ", drv("School_D2"))
                        SQL &= String.Format(" SchoolAddress_D2 = '{0}', ", drv("SchoolAddress_D2"))
                        SQL &= String.Format(" Prefix_D3 = '{0}', ", drv("Prefix_D3"))
                        SQL &= String.Format(" FirstN_D3 = '{0}', ", drv("FirstN_D3"))
                        SQL &= String.Format(" MiddleN_D3 = '{0}', ", drv("MiddleN_D3"))
                        SQL &= String.Format(" LastN_D3 = '{0}', ", drv("LastN_D3"))
                        SQL &= String.Format(" Suffix_D3 = '{0}', ", drv("Suffix_D3"))
                        SQL &= String.Format(" Birth_D3 = '{0}', ", drv("Birth_D3"))
                        SQL &= String.Format(" Grade_D3 = '{0}', ", drv("Grade_D3"))
                        SQL &= String.Format(" School_D3 = '{0}', ", drv("School_D3"))
                        SQL &= String.Format(" SchoolAddress_D3 = '{0}', ", drv("SchoolAddress_D3"))
                        SQL &= String.Format(" Prefix_D4 = '{0}', ", drv("Prefix_D4"))
                        SQL &= String.Format(" FirstN_D4 = '{0}', ", drv("FirstN_D4"))
                        SQL &= String.Format(" MiddleN_D4 = '{0}', ", drv("MiddleN_D4"))
                        SQL &= String.Format(" LastN_D4 = '{0}', ", drv("LastN_D4"))
                        SQL &= String.Format(" Suffix_D4 = '{0}', ", drv("Suffix_D4"))
                        SQL &= String.Format(" Birth_D4 = '{0}', ", drv("Birth_D4"))
                        SQL &= String.Format(" Grade_D4 = '{0}', ", drv("Grade_D4"))
                        SQL &= String.Format(" School_D4 = '{0}', ", drv("School_D4"))
                        SQL &= String.Format(" SchoolAddress_D4 = '{0}', ", drv("SchoolAddress_D4"))

                        SQL &= String.Format(" Employer_B = '{0}', ", drv("Employer_B"))
                        SQL &= String.Format(" EmployerAddress_B = '{0}', ", drv("EmployerAddress_B"))
                        SQL &= String.Format(" Hired_B = '{0}', ", drv("Hired_B"))
                        SQL &= String.Format(" EmploymentStat_B = '{0}', ", drv("EmploymentStat_B"))
                        SQL &= String.Format(" Position_B = '{0}', ", drv("Position_B"))
                        SQL &= String.Format(" Monthly_B = '{0}', ", drv("Monthly_B"))
                        SQL &= String.Format(" BusinessName_B = '{0}', ", drv("BusinessName_B"))
                        SQL &= String.Format(" BusinessAddress_B = '{0}', ", drv("BusinessAddress_B"))
                        SQL &= String.Format(" BusinessStarted = '{0}', ", "")
                        SQL &= String.Format(" NatureBusiness_B = '{0}', ", drv("NatureBusiness_B"))
                        SQL &= String.Format(" Capital_B = '{0}', ", drv("Capital_B"))
                        SQL &= String.Format(" NoEmployees_B = '{0}', ", drv("NoEmployees_B"))
                        SQL &= String.Format(" BusinessStock = '{0}', ", 0)
                        SQL &= String.Format(" BusinessVehicle = '{0}', ", "")
                        SQL &= String.Format(" BusinessIncome_B = '{0}', ", drv("BusinessIncome_B"))
                        SQL &= String.Format(" BusinessPermit = '{0}', ", "")
                        SQL &= String.Format(" OtherIncome_B = '{0}', ", drv("OtherIncome_B"))
                        SQL &= String.Format(" OtherIncome_B_Amount = '{0}', ", drv("OtherIncome_B-Amount"))
                        SQL &= String.Format(" Creditor_1 = '{0}', ", drv("Creditor_1"))
                        SQL &= String.Format(" CreditAddress_1 = '{0}', ", "")
                        SQL &= String.Format(" CreditGranted_1 = '{0}', ", "")
                        SQL &= String.Format(" Term_1 = '{0}', ", drv("Term_1"))
                        SQL &= String.Format(" AmountGranted_1 = '{0}', ", drv("AmountGranted_1"))
                        SQL &= String.Format(" Balance_1 = '{0}', ", drv("Balance_1"))
                        SQL &= String.Format(" CreditPayment_1 = '{0}', ", 0)
                        SQL &= String.Format(" CreditRemarks_1 = '{0}', ", drv("CreditRemarks_1"))
                        SQL &= String.Format(" Creditor_2 = '{0}', ", drv("Creditor_2"))
                        SQL &= String.Format(" CreditAddress_2 = '{0}', ", "")
                        SQL &= String.Format(" CreditGranted_2 = '{0}', ", "")
                        SQL &= String.Format(" Term_2 = '{0}', ", drv("Term_2"))
                        SQL &= String.Format(" AmountGranted_2 = '{0}', ", drv("AmountGranted_2"))
                        SQL &= String.Format(" Balance_2 = '{0}', ", drv("Balance_2"))
                        SQL &= String.Format(" CreditPayment_2 = '{0}', ", 0)
                        SQL &= String.Format(" CreditRemarks_2 = '{0}', ", drv("CreditRemarks_2"))

                        SQL &= String.Format(" Bank_1 = '{0}', ", drv("Bank_1"))
                        SQL &= String.Format(" Branch_1 = '{0}', ", drv("Branch_1"))
                        SQL &= String.Format(" AccountT_1 = '{0}', ", drv("AccountT_1"))
                        SQL &= String.Format(" SA_1 = '{0}', ", drv("SA_1"))
                        SQL &= String.Format(" AverageBalance_1 = '{0}', ", drv("AverageBalance_1"))
                        SQL &= String.Format(" Opened_1 = '{0}', ", drv("Opened_1"))
                        SQL &= String.Format(" Bank_2 = '{0}', ", drv("Bank_2"))
                        SQL &= String.Format(" Branch_2 = '{0}', ", drv("Branch_2"))
                        SQL &= String.Format(" AccountT_2 = '{0}', ", drv("AccountT_2"))
                        SQL &= String.Format(" SA_2 = '{0}', ", drv("SA_2"))
                        SQL &= String.Format(" AverageBalance_2 = '{0}', ", drv("AverageBalance_2"))
                        SQL &= String.Format(" Opened_2 = '{0}', ", drv("Opened_2"))

                        SQL &= String.Format(" CreditRating = '{0}', ", "")
                        SQL &= String.Format(" RecommendationFor = '{0}', ", "")
                        SQL &= String.Format(" Rec_ApprovedAmount = '{0}', ", dAmountApplied.Value)
                        SQL &= String.Format(" Rec_ApprovedTerms = '{0}', ", iTerms_C.Value)
                        SQL &= String.Format(" Rec_ApprovedRate = '{0}', ", dInterest_C.Value)
                        SQL &= String.Format(" Rec_PDC = '{0}', ", 1)
                        SQL &= String.Format(" Rec_NoPDC = '{0}', ", 0)
                        SQL &= String.Format(" Rec_Remarks = '{0}', ", "")
                        SQL &= String.Format(" Title = '{0}', ", "")
                        SQL &= String.Format(" CaseNum = '{0}', ", "")
                        SQL &= String.Format(" DateFilled = '{0}', ", "")
                        SQL &= String.Format(" Court = '{0}', ", "")
                        SQL &= String.Format(" CaseNature = '{0}', ", "")
                        SQL &= String.Format(" AmountInvolved = '{0}', ", 0)
                        SQL &= String.Format(" CaseStatus = '{0}', ", "")
                        SQL &= String.Format(" Findings = '{0}', ", "")
                        SQL &= String.Format(" FindingsStat = '{0}', ", "")
                        SQL &= String.Format(" CACPI = '{0}', ", "")

                        SQL &= String.Format(" Location_1 = '{0}', ", drv("Location_1"))
                        SQL &= String.Format(" TCT_1 = '{0}', ", drv("TCT_1"))
                        SQL &= String.Format(" Area_1 = '{0}', ", drv("Area_1"))
                        SQL &= String.Format(" PropertiesRemarks_1 = '{0}', ", drv("PropertiesRemarks_1"))
                        SQL &= String.Format(" Location_2 = '{0}', ", drv("Location_2"))
                        SQL &= String.Format(" TCT_2 = '{0}', ", drv("TCT_2"))
                        SQL &= String.Format(" Area_2 = '{0}', ", drv("Area_2"))
                        SQL &= String.Format(" PropertiesRemarks_2 = '{0}', ", drv("PropertiesRemarks_2"))

                        SQL &= String.Format(" Vehicle_1 = '{0}', ", drv("Vehicle_1"))
                        SQL &= String.Format(" Year_1 = '{0}', ", drv("Year_1"))
                        SQL &= String.Format(" WhomAcquired_1 = '{0}', ", drv("WhomAcquired_1"))
                        SQL &= String.Format(" VehicleRemarks_1 = '{0}', ", drv("VehicleRemarks_1"))
                        SQL &= String.Format(" Vehicle_2 = '{0}', ", drv("Vehicle_2"))
                        SQL &= String.Format(" Year_2 = '{0}', ", drv("Year_2"))
                        SQL &= String.Format(" WhomAcquired_2 = '{0}', ", drv("WhomAcquired_2"))
                        SQL &= String.Format(" VehicleRemarks_2 = '{0}', ", drv("VehicleRemarks_2"))
                    End If
                    SQL &= String.Format(" OtherProperties = '{0}', ", "")
                    SQL &= String.Format(" Narrative = '{0}', ", "")
                    SQL &= String.Format(" Ex_TotalDisposable = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Living = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Clothing = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Education = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Transportation = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Lights = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Insurance = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Amortization = '{0}', ", 0)
                    SQL &= String.Format(" Ex_Miscellaneous = '{0}', ", 0)
                    SQL &= String.Format(" Ex_TotalExpenses = '{0}', ", 0)
                    SQL &= String.Format(" Ex_NetDisposable = '{0}', ", 0)
                    SQL &= String.Format(" Ex_TMFI = '{0}', ", 0)
                    SQL &= String.Format(" Ex_TMDI = '{0}', ", 0)
                    SQL &= String.Format(" PurposeLoan = '{0}', ", "")
                    SQL &= String.Format(" Others = '{0}', ", "")
                    SQL &= String.Format(" AmountApplied = '{0}', ", dAmountApplied.Value)
                    SQL &= String.Format(" LoanType = '{0}', ", DataObject(String.Format("SELECT Mortgage FROM mortgage_setup WHERE ID = '{0}';", MortgageID)))
                    SQL &= String.Format(" Product = '{0}', ", cbxProduct.Text)
                    SQL &= String.Format(" Collateral = '{0}', ", txtCollateral.Text)
                    SQL &= String.Format(" TotalAppraised = '{0}', ", 0)
                    SQL &= String.Format(" Loanable = '{0}', ", dAmountApplied.Value)
                    SQL &= String.Format(" Branch_ID = '{0}', ", Branch_ID)
                    SQL &= String.Format(" User_Code = '{0}', ", DataObject(String.Format("SELECT User_Code FROM users WHERE empl_id = '{0}';", ValidateComboBox(cbxCI))))
                    SQL &= String.Format(" ci_status = '{0}', ", "APPROVED")
                    SQL &= String.Format(" C1 = '{0}',", "")
                    SQL &= String.Format(" C2 = '{0}',", "")
                    SQL &= String.Format(" C3 = '{0}',", "")
                    SQL &= String.Format(" C4 = '{0}',", "")
                    SQL &= String.Format(" C5 = '{0}',", "")
                    SQL &= String.Format(" C6 = '{0}',", "")
                    SQL &= String.Format(" C7 = '{0}',", "")
                    SQL &= String.Format(" C8 = '{0}',", "")
                    SQL &= String.Format(" C9 = '{0}',", "")
                    SQL &= String.Format(" Branch_Code = '{0}';", Branch_Code)
                End If

                'PAYMENT REQUEST
                SQL &= "INSERT INTO check_received SET"
                SQL &= String.Format(" AssetNumber = '{0}', ", txtCreditNumber.Text)
                SQL &= String.Format(" ORNumber = '{0}', ", "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL &= String.Format(" Sold_ID = '{0}',", "")
                SQL &= String.Format(" Buyer = '{0}', ", cbxBorrower.Text)
                SQL &= String.Format(" DateRequest = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" Bank = '{0}', ", "")
                SQL &= String.Format(" Branch = '{0}', ", "")
                SQL &= String.Format(" `Check` = '{0}', ", "TEMP-" & Branch_ID & Format(Date.Now, "MMddyyyyHHmmss"))
                SQL &= String.Format(" `Date` = '{0}', ", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" Amount = '{0}', ", dAmountApplied.Value)
                SQL &= String.Format(" Remarks = '{0}', ", "Migrated")
                SQL &= " check_type = 'P', "
                SQL &= String.Format(" CVNumber = '{0}',", txtCVNumber.Text)
                SQL &= String.Format(" CVDate = '{0}',", FormatDatePicker(dtpAvailed))
                SQL &= String.Format(" BankID = '{0}',", ValidateComboBox(cbxBank))
                SQL &= String.Format(" branch_id = '{0}',", Branch_ID)
                SQL &= String.Format(" user_code = '{0}';", User_Code)

                Dim drvB As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                'ACCOUNTING ENTRY
                'SQL &= "INSERT INTO accounting_entry SET"
                'SQL &= String.Format(" ORNum = '{0}', ", txtCVNumber.Text)
                'SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpLastPayment))
                'SQL &= String.Format(" ReferenceN = '{0}', ", txtCreditNumber.Text)
                'SQL &= " EntryType = 'DEBIT',"
                'SQL &= " PostStatus = 'POSTED',"
                'SQL &= String.Format(" AccountCode = '{0}', ", drvB("AccountCode")) 'CASH IN BANK
                'SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", drvB("AccountCode")))) 'CASH IN BANK
                'SQL &= String.Format(" Payable = '{0}', ", dTotalPayment.Value)
                'SQL &= String.Format(" Amount = '{0}', ", dTotalPayment.Value)
                'SQL &= " PaidFor = 'CIB', "
                'SQL &= String.Format(" Remarks = '{0}', ", "Migrated Account")
                'SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                'SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" ReferenceN = '{0}', ", txtCreditNumber.Text)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(drvP("mortgage_id") = 1, "420003", If(drvP("mortgage_id") = 1 = 2, "420004", "420007"))) 'Interest Income-Past Due
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drvP("mortgage_id") = 1, "420003", If(drvP("mortgage_id") = 1 = 2, "420004", "420007"))))) 'Interest Income-Past Due
                SQL &= String.Format(" Payable = '{0}', ", dPenalty_B.Value)
                SQL &= String.Format(" PenaltyPayable = '{0}', ", dPenalty_B.Value)
                SQL &= String.Format(" Amount = '{0}', ", 0)
                SQL &= String.Format(" PaidFor = '{0}', ", "Penalty")
                SQL &= String.Format(" Remarks = '{0}', ", "Penalty Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" ReferenceN = '{0}', ", txtCreditNumber.Text)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(drvP("mortgage_id") = 1, "420003", If(drvP("mortgage_id") = 1 = 2, "420004", "420007"))) 'Interest Income-Past Due
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drvP("mortgage_id") = 1, "420003", If(drvP("mortgage_id") = 1 = 2, "420004", "420007"))))) 'Interest Income-Past Due
                SQL &= String.Format(" Payable = '{0}', ", dRPPD_C.Value - dRPPD_B.Value)
                SQL &= String.Format(" Amount = '{0}', ", dRPPD_C.Value - dRPPD_B.Value)
                SQL &= String.Format(" PaidFor = '{0}', ", "RPPD")
                SQL &= String.Format(" Remarks = '{0}', ", "RPPD Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" ReferenceN = '{0}', ", txtCreditNumber.Text)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(drvP("mortgage_id") = 1, "420001", If(drvP("mortgage_id") = 2, "420002", "420006"))) 'Interest Income-Current
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drvP("mortgage_id") = 1, "420001", If(drvP("mortgage_id") = 2, "420002", "420006"))))) 'Interest Income-Current
                SQL &= String.Format(" Payable = '{0}', ", dUDI_C.Value - dUDI_B.Value)
                SQL &= String.Format(" Amount = '{0}', ", dUDI_C.Value - dUDI_B.Value)
                SQL &= String.Format(" PaidFor = '{0}', ", "UDI")
                SQL &= String.Format(" Remarks = '{0}', ", "UDI Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                SQL &= "INSERT INTO accounting_entry SET"
                SQL &= String.Format(" ORNum = '{0}', ", txtCVNumber.Text)
                SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" ReferenceN = '{0}', ", txtCreditNumber.Text)
                SQL &= " EntryType = 'CREDIT',"
                SQL &= " PostStatus = 'POSTED',"
                SQL &= String.Format(" AccountCode = '{0}X', ", If(drvP("mortgage_id") = 1, "112001", If(drvP("mortgage_id") = 2, "112002", "112003"))) 'Loans Receivable
                SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drvP("mortgage_id") = 1, "112001", If(drvP("mortgage_id") = 2, "112002", "112003"))))) 'Loans Receivable
                SQL &= String.Format(" Payable = '{0}', ", dPA_C.Value - dPrincipal_B.Value)
                SQL &= String.Format(" Amount = '{0}', ", dPA_C.Value - dPrincipal_B.Value)
                SQL &= String.Format(" PaidFor = '{0}', ", "Principal")
                SQL &= String.Format(" Remarks = '{0}', ", "Principal Payment - Migrated")
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
HereV2:
                DataObject(SQL)

                If From_OfficialReceipt Then
                    Logs("Amortization Schedule", "Save", String.Format("Validate Amortization Schedule with Credit Number {0}.", txtCreditNumber.Text), "", "", cbxBorrower.SelectedValue, txtCreditNumber.Text)
                Else
                    Logs("Migrated Application", "Save", String.Format("Add new Migrated Application with Credit Number {0}.", txtCreditNumber.Text), "", "", cbxBorrower.SelectedValue, txtCreditNumber.Text)
                End If
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                If From_Application Or From_OfficialReceipt Then
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dtpAvailed.Text = dtpAvailed.Tag Then
            Else
                Change &= String.Format("Change Availed Date from {0} to {1}. ", dtpAvailed.Tag, dtpAvailed.Text)
            End If
            If rRemarks.Text = rRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", rRemarks.Tag, rRemarks.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Migrated Application - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub CbxBorrower_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBorrower.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxBorrower.SelectedIndex = -1 Or cbxBorrower.Text = "" Then
            Clear()
        Else
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            If cbxCorporate.Checked Then
                txtCompleteAdd.Text = drv("Address")
                txtMobile.Text = ""
                txtEmail.Text = drv("Email")
            Else
                txtCompleteAdd.Text = drv("Address")
                txtMobile.Text = drv("Mobile_B")
                txtEmail.Text = drv("Email_B")

                cbxNatureBusiness_B2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Borrower'", drv("BorrowerID"))))
            End If

            cbxBusinessCenter.Text = drv("BusinessCenter").ToString
            cbxBusinessCenter.Tag = drv("BusinessCenter").ToString
        End If
    End Sub

    Private Sub CbxProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProduct.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        PD_BankID = 0
        PD_AccountNumber = ""
        PD_CardNumber = ""
        PD_ATM = False
        Dim drv As DataRowView = DirectCast(cbxProduct.SelectedItem, DataRowView)
        Product_Payment = drv("payment")
        Product_UDI = drv("UDI")
        Product_LastPrincipal = drv("last_principal")
        Product_AdvancePayment = drv("advance_payment")
        cbxTerms.Text = drv("term")
        MortgageID = drv("mortgage_id")
        iTerms_C.Increment = 1
        If cbxProduct.Text.ToUpper.Contains("AGRICULTURE") Then
            dRPPDRate_T.Value = 0
        ElseIf cbxProduct.Text.ToUpper.Contains("FARM EQUIPMENT") Or cbxProduct.Text.ToUpper.Contains("CREDIT LINE") Then
            dRPPDRate_T.Value = 0
            If cbxProduct.Text.ToUpper.Contains("FARM EQUIPMENT") And Branch_Code = "KOR" Then
                iTerms_C.Increment = 6
            End If
        End If

        If cbxProduct.Text.Contains("PAYDAY") Or cbxProduct.Text.Contains("SHOWMONEY") Then
            btnATM.Visible = True
        Else
            btnATM.Visible = False
        End If

        If Product_LastPrincipal = "Yes" Then 'CAR DEALERSHIP LOANS
            If cbxProduct.Text.ToUpper.Contains("DEALER") Then
                lblRPPDRate_C.Visible = False
                lblRPPDRate_Percent.Visible = False
                lblRPPDRate_T.Visible = False
                dRPPDRate_C.Visible = False
                dRPPDRate_T.Visible = False
                lblRPPD_C.Visible = False
                dRPPD_C.Visible = False
                dRPPD_B.Visible = False
            End If
            LabelX92.Visible = False
            dGMA_C.Visible = False
            lblMR_C.Text = "Monthly Interest :"
            LabelX94.Text = "Last Month Amort :"
            If cbxProduct.Text.ToUpper.Contains("FARM EQUIPMENT") And Branch_Code = "KOR" Then
                LabelX94.Text = "Semi Annual Pay :"
            End If
        Else
            If CompanyMode = 0 Then
            Else
                lblRPPDRate_C.Visible = True
                lblRPPDRate_Percent.Visible = True
                lblRPPDRate_T.Visible = True
                dRPPDRate_C.Visible = True
                dRPPDRate_T.Visible = True
                lblRPPD_C.Visible = True
                dRPPD_C.Visible = True
                dRPPD_B.Visible = True

                If dMR_C.Visible = False Then
                    lblMR_C.Visible = True
                    dMR_C.Visible = True
                End If
            End If
            LabelX92.Visible = True
            dGMA_C.Visible = True
            lblMR_C.Text = "Monthly Rebate :"
            LabelX94.Text = "Net Monthly Amort :"
        End If

        If Product_Payment = "Monthly" Then
            dGMA_C2.Visible = False
            dMR_C2.Visible = False
            dNMA_C2.Visible = False
            LabelX84.Visible = False
            lblMR_Slash.Visible = False
            LabelX101.Visible = False
        Else 'Salary and Payday Loan - Kinsinas bayad.
            dGMA_C2.Visible = True
            dMR_C2.Visible = True
            dNMA_C2.Visible = True
            LabelX84.Visible = True
            lblMR_Slash.Visible = True
            LabelX101.Visible = True
        End If

        If drv("max_terms") > 0 Then
            iTerms_C.MaxValue = drv("max_terms")
        Else
            iTerms_C.MaxValue = 1000
        End If

        Product_Interest = drv("interest")
        dInterest_T.Value = Product_Interest * 12
        Interest_UDI = drv("interest") * Identify_Terms(iTerms_C.Value)
        dInterest_C.Value = Interest_UDI
        DtpAvailed_ValueChanged(sender, e)

        lblVerified.Visible = False
        lblForVerification.Visible = True

        dInterest_N.Enabled = False
        dRPPD_N.Enabled = False
        dPrincipal_N.Enabled = False
        btnEdit.Enabled = True
    End Sub

    Private Function Identify_Terms(d As Double)
        If cbxTerms.Text = "DAY" Then
            d /= 30
        End If
        Return d
    End Function

    Private Sub DAmountApplied_ValueChanged(sender As Object, e As EventArgs) Handles dAmountApplied.ValueChanged
        dPA_C.Value = dAmountApplied.Value

        ComputeNMA()
    End Sub

    Private Sub DInterest_C_ValueChanged(sender As Object, e As EventArgs) Handles dInterest_C.ValueChanged
        lblInterest.Visible = True

        ComputeNMA()
    End Sub

    Private Sub DInterest_T_ValueChanged(sender As Object, e As EventArgs) Handles dInterest_T.ValueChanged
        Interest_UDI = dInterest_T.Value / 12
        Product_Interest = dInterest_T.Value / 12
        dInterest_C.Value = Product_Interest * Identify_Terms(iTerms_C.Value)
    End Sub

    Private Sub DRPPDRate_C_ValueChanged(sender As Object, e As EventArgs) Handles dRPPDRate_C.ValueChanged
        ComputeNMA()
    End Sub

    Private Sub DRPPDRate_T_ValueChanged(sender As Object, e As EventArgs) Handles dRPPDRate_T.ValueChanged
        If Firstload Then
            Exit Sub
        End If

        If dRPPDRate_T.Value > 0 Then
            Last_RPPD = dRPPDRate_T.Value
        End If
        Interest_RPPD = dRPPDRate_T.Value
        dRPPDRate_C.Value = (dRPPDRate_T.Value * Identify_Terms(iTerms_C.Value)) / 12
    End Sub

    Private Sub ITerms_C_ValueChanged(sender As Object, e As EventArgs) Handles iTerms_C.ValueChanged
        dInterest_C.Value = Product_Interest * Identify_Terms(iTerms_C.Value)
        If CompanyMode = 0 Then
        Else
            If Math.Ceiling(Identify_Terms(iTerms_C.Value)) < RPPD_Start Then
                'Policy: nga kung 7 ang terms dha ra mag start ang RPPD
                dRPPDRate_C.Value = 0
                dRPPDRate_T.Value = 0
                If Interest_RPPD = 0 Then
                    Interest_RPPD = Last_RPPD
                End If
            ElseIf Math.Ceiling(Identify_Terms(iTerms_C.Value)) < 12 Then
                'Policy: Katong kung 10 ang terms = (3.0 * 10) / 12 = 2.5 (Bag-o nga Interest RPPD)
                dRPPDRate_T.Value = Interest_RPPD
                dRPPDRate_C.Value = (Interest_RPPD * Identify_Terms(iTerms_C.Value)) / 12
            Else
                dRPPDRate_T.Value = Interest_RPPD
                dRPPDRate_C.Value = (Interest_RPPD * Identify_Terms(iTerms_C.Value)) / 12
            End If
        End If

        ComputeNMA()
    End Sub

    Private Sub DMR_C_ValueChanged(sender As Object, e As EventArgs) Handles dMR_C.ValueChanged
        dMR_C2.Value = dMR_C.Value / 2
    End Sub

    Private Sub DGMA_C_ValueChanged(sender As Object, e As EventArgs) Handles dGMA_C.ValueChanged
        dGMA_C2.Value = dGMA_C.Value / 2
    End Sub

    Private Sub ComputeNMA()
        If Firstload Or dAmountApplied.Value = 0 Then
            Exit Sub
        End If

        dUDI_C.Value = dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)
        UDI_F = dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)

        dRPPD_C.Value = Math.Round(dPA_C.Value * (dRPPDRate_C.Value / 100), 2, MidpointRounding.AwayFromZero)
        RPPD_F = dPA_C.Value * (dRPPDRate_C.Value / 100)

        If Product_UDI = "No" Then 'For Payday and Showmoney Loans
            dFA_C.Value = dPA_C.Value + dRPPD_C.Value
            FA_F = dPA_C.Value + dRPPD_C.Value
        Else
            dFA_C.Value = dPA_C.Value + dUDI_C.Value + dRPPD_C.Value
            FA_F = dPA_C.Value + UDI_F + dRPPD_C.Value
        End If

        If Product_LastPrincipal = "Yes" Then 'For Car Loans
            dMR_C.Value = Decimal50(dUDI_C.Value / Identify_Terms(iTerms_C.Value))
        Else
            If dRPPD_C.Value > 0 Then
                If Product_Payment = "Bimonthly" Then 'For Payday and Salary Loans
                    If (SplitDecimal(dRPPD_C.Value / (Identify_Terms(iTerms_C.Value) * 2)) <> 50 And SplitDecimal(dRPPD_C.Value / (Identify_Terms(iTerms_C.Value) * 2)) > 0) Then
                        Puwake_MR = ((FormatNumber(Decimal50(RPPD_F / (Identify_Terms(iTerms_C.Value) * 2)), 2) * (Identify_Terms(iTerms_C.Value) * 2)) - RPPD_F)
                        If dRPPD_C.Value <> (dPA_C.Value * (dRPPDRate_C.Value / 100)) + If(Puwake_MR > 0, Puwake_MR, 0) Then
                            dRPPD_C.Value = (dPA_C.Value * (dRPPDRate_C.Value / 100)) + If(Puwake_MR > 0, Puwake_MR, 0)
                        End If
                    End If
                Else
                    Puwake_MR = ((FormatNumber(Decimal50(RPPD_F / Identify_Terms(iTerms_C.Value)), 2) * Identify_Terms(iTerms_C.Value)) - RPPD_F)
                    If dRPPD_C.Value <> (dPA_C.Value * (dRPPDRate_C.Value / 100)) + If(Puwake_MR > 0, Puwake_MR, 0) Then
                        dRPPD_C.Value = (dPA_C.Value * (dRPPDRate_C.Value / 100)) + If(Puwake_MR > 0, Puwake_MR, 0)
                    End If
                End If
            End If
            dMR_C.Value = Decimal50(dRPPD_C.Value / Identify_Terms(iTerms_C.Value))
        End If
        If Product_UDI = "No" Then 'For Payday and Showmoney Loans
            dFA_C.Value = dPA_C.Value + dRPPD_C.Value
            FA_F = dPA_C.Value + dRPPD_C.Value
        Else
            dFA_C.Value = dPA_C.Value + dUDI_C.Value + dRPPD_C.Value
            FA_F = dPA_C.Value + UDI_F + dRPPD_C.Value
        End If

        If Product_LastPrincipal = "Yes" Then 'For Car Loans
            If dFA_C.Value > 0 Then
                Puwake_UDI = ((FormatNumber(Decimal50(dUDI_C.Value / (Identify_Terms(iTerms_C.Value))), 2) * (Identify_Terms(iTerms_C.Value))) - dUDI_C.Value)
                dUDI_C.Value = (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)) + If(Puwake_UDI > 0, Puwake_UDI, 0)
                dFA_C.Value = dPA_C.Value + dUDI_C.Value + dRPPD_C.Value
            End If
        ElseIf cbxProduct.Text.Contains("CHECK") Then
            dRPPD_C.Value = Math.Ceiling(dRPPD_C.Value)
            dMR_C.Value = dRPPD_C.Value

            dFA_C.Value = dPA_C.Value + dRPPD_C.Value
            FA_F = dPA_C.Value + dRPPD_C.Value
        Else
            If dFA_C.Value > 0 Then
                If Product_Payment = "Bimonthly" Then 'For Payday and Salary Loans
                    Puwake_UDI = ((FormatNumber(Decimal50(FA_F / (Identify_Terms(iTerms_C.Value) * 2)), 2) * (Identify_Terms(iTerms_C.Value) * 2)) - FA_F)
                    If dUDI_C.Value <> (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)) + If(Puwake_UDI > 0, Puwake_UDI, 0) Then
                        If Puwake_MR > 0 And (SplitDecimal(dRPPD_C.Value / (Identify_Terms(iTerms_C.Value) * 2)) <> 50 And SplitDecimal(dRPPD_C.Value / (Identify_Terms(iTerms_C.Value) * 2)) > 0) Then
                            dUDI_C.Value = (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100))
                        Else
                            dUDI_C.Value = (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)) + If(Puwake_UDI > 0, Puwake_UDI, 0)
                        End If
                        If Product_UDI = "No" Then 'For Payday and Showmoney Loans
                            dFA_C.Value = dPA_C.Value + dRPPD_C.Value
                        Else
                            dFA_C.Value = dPA_C.Value + dUDI_C.Value + dRPPD_C.Value
                        End If
                    End If
                Else
                    Puwake_UDI = ((FormatNumber(Decimal50(FA_F / Identify_Terms(iTerms_C.Value)), 2) * Identify_Terms(iTerms_C.Value)) - FA_F)
                    If dUDI_C.Value <> (dPA_C.Value * (dInterest_C.Value / 100)) + If(Puwake_UDI > 0, Puwake_UDI, 0) Then
                        If Puwake_MR > 0 And (SplitDecimal(dRPPD_C.Value / Identify_Terms(iTerms_C.Value)) <> 50 And SplitDecimal(dRPPD_C.Value / Identify_Terms(iTerms_C.Value)) > 0) Then
                            dUDI_C.Value = (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100))
                        Else
                            dUDI_C.Value = (dPA_C.Value * (Math.Round(dInterest_C.Value, 2, MidpointRounding.AwayFromZero) / 100)) + If(Puwake_UDI > 0, Puwake_UDI, 0)
                        End If
                        If Product_UDI = "No" Then 'For Payday and Showmoney Loans
                            dFA_C.Value = dPA_C.Value + dRPPD_C.Value
                        Else
                            dFA_C.Value = dPA_C.Value + dUDI_C.Value + dRPPD_C.Value
                        End If
                    End If
                End If
            End If
        End If

        If cbxProduct.Text.Contains("CHECK") Then
            dGMA_C.Value = Decimal50(dFA_C.Value)
        Else
            dGMA_C.Value = Decimal50(dFA_C.Value / Identify_Terms(iTerms_C.Value))
        End If

        If Product_LastPrincipal = "Yes" Then 'For Car Loans
            If cbxProduct.Text.ToUpper.Contains("FARM EQUIPMENT") And Branch_Code = "KOR" Then 'FOR KORONADAL FARM EQUIPMENT LOAN KAY EVERY 6TH MONTH BAYAD
                dNMA_C.Value = dPA_C.Value / (iTerms_C.Value / 6)
            Else
                dNMA_C.Value = Decimal50(dPA_C.Value + dMR_C.Value)
            End If
        Else
            dNMA_C.Value = Decimal50(dGMA_C.Value - dMR_C.Value)
        End If
    End Sub

    Private Sub DNMA_C_ValueChanged(sender As Object, e As EventArgs) Handles dNMA_C.ValueChanged
        dNMA_C2.Value = dNMA_C.Value / 2
    End Sub

    Private Sub CbxTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxTerms.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        ITerms_C_ValueChanged(sender, e)
    End Sub

    Private Sub DPA_C_ValueChanged(sender As Object, e As EventArgs) Handles dPA_C.ValueChanged
        dPrincipal_B.MaxValue = dPA_C.Value
    End Sub

    Private Sub DPrincipal_B_ValueChanged(sender As Object, e As EventArgs) Handles dPrincipal_B.ValueChanged
        dTotalPayment.Value = dFA_C.Value - (dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value)
        dOutstanding.Value = dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value
    End Sub

    Private Sub DUDI_B_ValueChanged(sender As Object, e As EventArgs) Handles dUDI_B.ValueChanged
        dTotalPayment.Value = dFA_C.Value - (dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value)
        dOutstanding.Value = dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value
    End Sub

    Private Sub DRPPD_B_ValueChanged(sender As Object, e As EventArgs) Handles dRPPD_B.ValueChanged
        dTotalPayment.Value = dFA_C.Value - (dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value)
        dOutstanding.Value = dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value
    End Sub

    Private Sub DtpAvailed_ValueChanged(sender As Object, e As EventArgs) Handles dtpAvailed.ValueChanged
        If Firstload Then
            Exit Sub
        End If

        iDue.Value = dtpAvailed.Value.Day
        If cbxProduct.Text.Contains("CHECK") Then
            iTerms_C.Value = DateDiff(DateInterval.Day, dtpAvailed.Value, DueDate)
        End If
        If From_OfficialReceipt = False Then
            GetCreditApplication()
        End If

        Try
            Dim drv As DataRowView = DirectCast(cbxProduct.SelectedItem, DataRowView)
            If drv("Payment") = "Monthly" Then
                dtpFDD.Value = dtpAvailed.Value.AddMonths(1)
            ElseIf drv("Payment") = "Bimonthly" Then
                dtpFDD.Value = If(Format(dtpAvailed.Value, "dd") >= 6 And Format(dtpAvailed.Value, "dd") <= 20, Format(dtpAvailed.Value, String.Format("MM.{0}.yyyy", Date.DaysInMonth(Format(dtpAvailed.Value, "yyyy"), Format(dtpAvailed.Value, "MM")))), If(Format(dtpAvailed.Value, "dd") >= 1 And Format(dtpAvailed.Value, "dd") <= 5, Format(dtpAvailed.Value, "MM.15.yyyy"), Format(dtpAvailed.Value.AddMonths(1), "MM.15.yyyy")))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetCreditApplication()
        txtCreditNumber.Text = DataObject(String.Format("SELECT CONCAT('CA', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM credit_application WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpAvailed.Value, "yyyyMM"), Format(dtpAvailed.Value, "yyyy-MM-dd")))
    End Sub

    Private Sub DtpLastPayment_Leave(sender As Object, e As EventArgs) Handles dtpLastPayment.Leave
        If (DateValue(dtpLastPayment.Value) < DateValue(dtpAvailed.Value) Or DateValue(dtpLastPayment.Value) < DateValue(dtpFDD.Value)) And dFA_C.Value > dTotalPayment.Value Then
            MsgBox("Last Payment Date is earlier than the Availed Date or First Due Date, Please check your data.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub DtpFDD_Leave(sender As Object, e As EventArgs) Handles dtpFDD.Leave
        If DateValue(dtpFDD.Value) < DateValue(dtpAvailed.Value) Then
            MsgBox("First Due Date is earlier than the Availed Date, Please check your data.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub DFA_C_ValueChanged(sender As Object, e As EventArgs) Handles dFA_C.ValueChanged
        dTotalPayment.Value = dFA_C.Value - (dPrincipal_B.Value + dUDI_B.Value + dRPPD_B.Value)
        lblVerified.Visible = False
        lblForVerification.Visible = True

        dInterest_N.Enabled = False
        dRPPD_N.Enabled = False
        dPrincipal_N.Enabled = False
        btnEdit.Enabled = True
    End Sub

    Private Sub LoadAmortization()
        Cursor = Cursors.WaitCursor
        Try
            If From_OfficialReceipt Then
                Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', FORMAT(Penalty,2) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", txtCreditNumber.Text))
                Dim T_Monthly As Double
                Dim T_Interest As Double
                Dim T_RPPD As Double
                Dim T_Principal As Double
                Dim T_Penalty As Double
                For x As Integer = 1 To Temp_DT.Rows.Count - 1
                    T_Monthly += CDbl(Temp_DT(x)("Monthly"))
                    T_Interest += CDbl(Temp_DT(x)("Interest Income"))
                    T_RPPD += CDbl(Temp_DT(x)("RPPD"))
                    T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
                    T_Penalty += CDbl(Temp_DT(x)("Penalty"))
                Next
                Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
                GridControl1.DataSource = Temp_DT
            Else
                Dim Loans As New FrmLoanApplication
                With Loans
                    .For_Schedule = True
                    .SendToBack()
                    .WindowState = FormWindowState.Minimized
                    .Show()
                    .dAmountApplied.Value = dPA_C.Value
                    .iTerms.Value = iTerms_C.Value
                    .cbxProduct.Text = cbxProduct.Text
                    .dtpDate.Value = Format(dtpAvailed.Value, "yyyy-") & Format(dtpAvailed.Value, "MM-") & iDue.Value
                    .dInterest_T.Value = dInterest_T.Value
                    .dRPPDRate_T.Value = dRPPDRate_T.Value
                    .dRPPD_C.Value = dRPPD_C.Value
                    .dUDI_C.Value = dUDI_C.Value
                    .LoadAmortization(GridControl1, True)
                    .Dispose()
                End With
            End If
            If CompanyMode = 0 Then
            Else
                GridColumn15.VisibleIndex = 0
                GridColumn16.VisibleIndex = 1
                GridColumn17.VisibleIndex = 2
                GridColumn18.VisibleIndex = 3
                GridColumn19.VisibleIndex = 4
                GridColumn20.VisibleIndex = 5
                GridColumn21.VisibleIndex = 6
                GridColumn23.VisibleIndex = 7
                GridColumn22.VisibleIndex = 8
                GridColumn24.VisibleIndex = 9
            End If
        Catch ex As Exception
        End Try

        If GridView1.RowCount > 22 Then
            GridColumn16.Width = 90
            dInterest_N.Location = New Point(286 - 19, 7)
            dRPPD_N.Location = New Point(409 - 19, 7)
            dPrincipal_N.Location = New Point(532 - 19, 7)
        Else
            GridColumn16.Width = 109
            dInterest_N.Location = New Point(286, 7)
            dRPPD_N.Location = New Point(409, 7)
            dPrincipal_N.Location = New Point(532, 7)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 1 Then
            If btnEdit.Enabled Then
                LoadAmortization()
            End If
            If GridView1.RowCount > 2 Then
                Monthly_Principal = GridView1.GetRowCellValue(1, "Principal Allocation")
                Monthly_Interest = GridView1.GetRowCellValue(1, "Interest Income")
            Else
                Monthly_Principal = 0
                Monthly_Interest = 0
            End If
            If btnEdit.Enabled And From_OfficialReceipt = False Then
                dInterest_N.Value = Monthly_Interest
                If Product_Payment = "Monthly" Then
                    dRPPD_N.Value = dMR_C.Value
                Else
                    dRPPD_N.Value = dMR_C2.Value
                End If
                dPrincipal_N.Value = Monthly_Principal
            End If

            If From_OfficialReceipt Then
            Else
                dInterest_N.MaxValue = dUDI_C.Value
                dRPPD_N.MaxValue = dRPPD_C.Value
                dPrincipal_N.MaxValue = dPA_C.Value
            End If

            btnVerify.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            btnVerify.Enabled = True
        Else
            btnVerify.Enabled = False
        End If
    End Sub

    Private Sub LblVerified_VisibleChanged(sender As Object, e As EventArgs) Handles lblVerified.VisibleChanged
        If lblVerified.Visible Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If GridView1.RowCount <= 1 Then
            MsgBox("Please fill amortization schedule.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to Verify this Amortization Schedule?") = MsgBoxResult.Yes Then
            If btnAddC.Enabled Then
                Dim ErrorX As String = ""
                Dim Num As Integer = 1

                Cursor = Cursors.WaitCursor
                If If(IsNumeric(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Principal Allocation")), CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Principal Allocation")), 0) <> If(IsNumeric(GridView1.GetRowCellValue(0, "Outstanding Principal")), CDbl(GridView1.GetRowCellValue(0, "Outstanding Principal")), 0) Then
                    ErrorX &= Num & ".) Total Principal Allocation and Principal Balance is not equal, please check your data. " & vbCrLf
                    Num += 1
                End If
                If If(IsNumeric(GridView1.GetRowCellValue(GridView1.RowCount - 1, "RPPD")), CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "RPPD")), 0) <> If(IsNumeric(GridView1.GetRowCellValue(0, "Total_RPPD")), CDbl(GridView1.GetRowCellValue(0, "Total_RPPD")), 0) Then
                    ErrorX &= Num & ".) Total RPPD Allocation and RPPD Balance is not equal, please check your data. " & vbCrLf
                    Num += 1
                End If
                If If(IsNumeric(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Interest Income")), CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Interest Income")), 0) <> If(IsNumeric(GridView1.GetRowCellValue(0, "Unearn Income")), CDbl(GridView1.GetRowCellValue(0, "Unearn Income")), 0) Then
                    ErrorX &= Num & ".) Total Interest Allocation and Interest Balance is not equal, please check your data. " & vbCrLf
                    Num += 1
                End If
                If If(IsNumeric(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Monthly")), CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Monthly")), 0) <> If(IsNumeric(GridView1.GetRowCellValue(0, "Loans Receivable")), CDbl(GridView1.GetRowCellValue(0, "Loans Receivable")), 0) Then
                    ErrorX &= Num & ".) Total Monthly Amortization and Loans Receivable Balance is not equal, please check your data. " & vbCrLf
                    Num += 1
                End If
                For x As Integer = 0 To GridView1.RowCount - 1
                    If FormatNumber(CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Monthly")), GridView1.GetRowCellValue(x, "Monthly"), 0)), 2) <> FormatNumber(CDbl(CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty")), GridView1.GetRowCellValue(x, "Penalty"), 0)) + CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Interest Income")), GridView1.GetRowCellValue(x, "Interest Income"), 0)) + CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "RPPD")), GridView1.GetRowCellValue(x, "RPPD"), 0)) + CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Principal Allocation")), GridView1.GetRowCellValue(x, "Principal Allocation"), 0))), 2) Then
                        ErrorX &= Num & ".) Monthly Amortization is not equal with Monthly Allocation, Please check your data for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsDate(GridView1.GetRowCellValue(x, "Due Date")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Due Date for row " & x & vbCrLf
                        Num += 1
                    End If
                    If If(IsDate(GridView1.GetRowCellValue(x, "Due Date")), CDate(GridView1.GetRowCellValue(x, "Due Date")), Date.Now.AddYears(1000)) < If(IsDate(GridView1.GetRowCellValue(x - 1, "Due Date")), CDate(GridView1.GetRowCellValue(x - 1, "Due Date")), Date.Now.AddYears(1000)) And x > 1 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Due Date for row " & x & " is earlier than previous Due Date, please check your data." & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Monthly")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Monthly for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Penalty")) = False And GridView1.GetRowCellValue(x, "Penalty").ToString <> "" And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Penalty for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Interest Income")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Interest Income for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "RPPD")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column RPPD for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Principal Allocation")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Principal Allocation for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Outstanding Principal")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Outstanding Principal for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Unearn Income")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Unearn Income for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Total_RPPD")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column RPPD Balance for row " & x & vbCrLf
                        Num += 1
                    End If
                    If IsNumeric(GridView1.GetRowCellValue(x, "Loans Receivable")) = False And x > 0 And x < GridView1.RowCount - 1 Then
                        ErrorX &= Num & ".) Please check your data on column Loans Receivable for row " & x & vbCrLf
                        Num += 1
                    End If
                Next

                Cursor = Cursors.Default
                If ErrorX = "" Then
                    btnManual.Enabled = True
                    btnAddC.Visible = False
                    btnRemoveC.Visible = False
                    btnPenalty.Visible = False
                    cbxAuto.Visible = False
                    GridColumn1.OptionsColumn.AllowEdit = False
                    GridColumn2.OptionsColumn.AllowEdit = False
                    GridColumn16.OptionsColumn.AllowEdit = False
                    GridColumn17.OptionsColumn.AllowEdit = False
                    GridColumn18.OptionsColumn.AllowEdit = False
                    GridColumn19.OptionsColumn.AllowEdit = False
                    GridColumn20.OptionsColumn.AllowEdit = False
                    GridColumn21.OptionsColumn.AllowEdit = False
                    GridColumn22.OptionsColumn.AllowEdit = False
                    GridColumn23.OptionsColumn.AllowEdit = False
                    GridColumn24.OptionsColumn.AllowEdit = False
                Else
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Validation Error Log-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".txt"
                    btnSave.Enabled = False
                    IO.File.AppendAllText(FName, "*** E R R O R   I N   V A L I D A T I O N ***" & vbCrLf & vbCrLf & ErrorX & vbCrLf & vbCrLf & "*** E R R O R   I N   V A L I D A T I O N ***", System.Text.Encoding.UTF8)
                    Process.Start(FName)
                    Exit Sub
                End If
            End If

            lblVerified.Visible = True
            lblForVerification.Visible = False
            btnSave.Enabled = True
            dInterest_N.Enabled = False
            dRPPD_N.Enabled = False
            dPrincipal_N.Enabled = False
            MsgBox("Successfully Verified!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If ((e.Column.FieldName = "Monthly") Or (e.Column.FieldName = "Interest Income") Or (e.Column.FieldName = "RPPD") Or (e.Column.FieldName = "Principal Allocation") Or (e.Column.FieldName = "Outstanding Principal") Or (e.Column.FieldName = "Unearn Income") Or (e.Column.FieldName = "Total_RPPD") Or (e.Column.FieldName = "Loans Receivable") Or (e.Column.FieldName = "Penalty") Or (e.Column.FieldName = "Penalty Balance")) AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
            Try
                If IsNumeric(e.Value) = False Then
                Else
                    e.DisplayText = NegativeParenthesisV2(Convert.ToDecimal(e.Value))
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If From_OfficialReceipt = False Or Flag Or e.RowHandle = 0 Or cbxAuto.Checked = False Then
            Exit Sub
        End If
        'Dim Plus1 As Integer
        Dim Plus1Month As Integer
        Dim TotalInterest As Double
        Dim TotalRPPD As Double
        Dim TotalPrincipal As Double
        Dim TotalPenalty As Double
        Dim TotalMonthly As Double
        For x As Integer = e.RowHandle To GridView1.RowCount - 3
            ' * * * * * * * M O N T H L Y * * * * * * * *
            If e.Column.FieldName = "Due Date" AndAlso (Not Flag) Then
                Flag = True
                Try
                    If Product_Payment = "Bimonthly" Then
                        If GridView1.GetRowCellValue(x - 1, "Due Date").ToString = "" Then
                        Else
                            GridView1.SetRowCellValue(x, "Due Date", If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day <= 15, Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "MM.") & If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 15, Date.DaysInMonth(Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "yyyy"), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "MM")), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddDays(15), "dd")) & Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), ".yyyy"), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddMonths(1), "MM.") & CInt(If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 31, 31 - 16, If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 28, 28 - 13, If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 29, 29 - 14, DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day - 15)))).ToString("D2") & Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddMonths(1), ".yyyy")))
                        End If
                        If x = GridView1.RowCount - 3 Then
                            x += 1
                            GridView1.SetRowCellValue(x, "Due Date", If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day <= 15, Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "MM.") & If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 15, Date.DaysInMonth(Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "yyyy"), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), "MM")), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddDays(15), "dd")) & Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")), ".yyyy"), Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddMonths(1), "MM.") & CInt(If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 31, 31 - 16, If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 28, 28 - 13, If(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day = 29, 29 - 14, DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).Day - 15)))).ToString("D2") & Format(DateValue(GridView1.GetRowCellValue(x - 1, "Due Date")).AddMonths(1), ".yyyy")))
                        End If
                    Else
                        GridView1.SetRowCellValue(x, "Due Date", Format(DateValue(e.Value).AddMonths(Plus1Month), "MM.dd.yyyy"))
                    End If
                    Plus1Month += 1
                Catch ex As Exception
                    Flag = False
                End Try
                Flag = False
            End If
            If e.Column.FieldName = "Monthly" AndAlso (Not Flag) Then
                Flag = True
                GridView1.SetRowCellValue(x, "Monthly", FormatNumber(Convert.ToDecimal(e.Value), 2))
                GridView1.SetRowCellValue(x, "Loans Receivable", CDbl(If(IsNumeric(GridView1.GetRowCellValue(x - 1, "Loans Receivable")), GridView1.GetRowCellValue(x - 1, "Loans Receivable"), 0)) - CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Monthly")), GridView1.GetRowCellValue(x, "Monthly"), 0)))
                Flag = False
            End If
            If e.Column.FieldName = "Penalty" AndAlso (Not Flag) Then
                Flag = True
                GridView1.SetRowCellValue(x, "Penalty", FormatNumber(Convert.ToDecimal(e.Value), 2))
                GridView1.SetRowCellValue(x, "Penalty Balance", CDbl(If(IsNumeric(GridView1.GetRowCellValue(x - 1, "Penalty Balance")), GridView1.GetRowCellValue(x - 1, "Penalty Balance"), 0)) - CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty")), GridView1.GetRowCellValue(x, "Penalty"), 0)))
                Flag = False
            End If
            If e.Column.FieldName = "Interest Income" AndAlso (Not Flag) Then
                Flag = True
                GridView1.SetRowCellValue(x, "Interest Income", FormatNumber(Convert.ToDecimal(e.Value), 2))
                GridView1.SetRowCellValue(x, "Unearn Income", CDbl(If(IsNumeric(GridView1.GetRowCellValue(x - 1, "Unearn Income")), GridView1.GetRowCellValue(x - 1, "Unearn Income"), 0)) - CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Interest Income")), GridView1.GetRowCellValue(x, "Interest Income"), 0)))
                Flag = False
            End If
            If e.Column.FieldName = "RPPD" AndAlso (Not Flag) Then
                Flag = True
                GridView1.SetRowCellValue(x, "RPPD", FormatNumber(Convert.ToDecimal(e.Value), 2))
                GridView1.SetRowCellValue(x, "Total_RPPD", CDbl(If(IsNumeric(GridView1.GetRowCellValue(x - 1, "Total_RPPD")), GridView1.GetRowCellValue(x - 1, "Total_RPPD"), 0)) - CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "RPPD")), GridView1.GetRowCellValue(x, "RPPD"), 0)))
                Flag = False
            End If
            If e.Column.FieldName = "Principal Allocation" AndAlso (Not Flag) Then
                Flag = True
                GridView1.SetRowCellValue(x, "Principal Allocation", FormatNumber(Convert.ToDecimal(e.Value), 2))
                GridView1.SetRowCellValue(x, "Outstanding Principal", CDbl(If(IsNumeric(GridView1.GetRowCellValue(x - 1, "Outstanding Principal")), GridView1.GetRowCellValue(x - 1, "Outstanding Principal"), 0)) - CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Principal Allocation")), GridView1.GetRowCellValue(x, "Principal Allocation"), 0)))
                Flag = False
            End If
        Next
        For x As Integer = 1 To GridView1.RowCount - 3
            TotalInterest += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Interest Income")), GridView1.GetRowCellValue(x, "Interest Income"), 0))
            TotalRPPD += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "RPPD")), GridView1.GetRowCellValue(x, "RPPD"), 0))
            TotalPrincipal += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Principal Allocation")), GridView1.GetRowCellValue(x, "Principal Allocation"), 0))
            TotalPenalty += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty")), GridView1.GetRowCellValue(x, "Penalty"), 0))
            TotalMonthly += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Monthly")), GridView1.GetRowCellValue(x, "Monthly"), 0))
        Next
        For x As Integer = GridView1.RowCount - 3 To GridView1.RowCount - 1
            If x = GridView1.RowCount - 1 Then
                ' * * * * * * * T O T A L * * * * * * * *
                If e.Column.FieldName = "Monthly" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 1, "Monthly", TotalMonthly)
                    Flag = False
                End If
                If e.Column.FieldName = "Penalty" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 1, "Penalty", TotalPenalty)
                    Flag = False
                End If
                If e.Column.FieldName = "Interest Income" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 1, "Interest Income", TotalInterest)
                    Flag = False
                End If
                If e.Column.FieldName = "RPPD" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 1, "RPPD", TotalRPPD)
                    Flag = False
                End If
                If e.Column.FieldName = "Principal Allocation" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 1, "Principal Allocation", TotalPrincipal)
                    Flag = False
                End If
            ElseIf x = GridView1.RowCount - 2 Then
                ' * * * * * * * L A S T    R O W * * * * * * * *
                If e.Column.FieldName = "Monthly" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 2, "Monthly", CDbl(If(IsNumeric(GridView1.GetRowCellValue(0, "Loans Receivable")), GridView1.GetRowCellValue(0, "Loans Receivable"), 0)) - TotalMonthly)
                    Flag = False
                End If
                If e.Column.FieldName = "Penalty" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 2, "Penalty", CDbl(If(IsNumeric(GridView1.GetRowCellValue(0, "Penalty Balance")), GridView1.GetRowCellValue(0, "Penalty Balance"), 0)) - TotalPenalty)
                    Flag = False
                End If
                If e.Column.FieldName = "Interest Income" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 2, "Interest Income", CDbl(If(IsNumeric(GridView1.GetRowCellValue(0, "Unearn Income")), GridView1.GetRowCellValue(0, "Unearn Income"), 0)) - TotalInterest)
                    Flag = False
                End If
                If e.Column.FieldName = "RPPD" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 2, "RPPD", CDbl(If(IsNumeric(GridView1.GetRowCellValue(0, "Total_RPPD")), GridView1.GetRowCellValue(0, "Total_RPPD"), 0)) - TotalRPPD)
                    Flag = False
                End If
                If e.Column.FieldName = "Principal Allocation" AndAlso (Not Flag) Then
                    Flag = True
                    GridView1.SetRowCellValue(GridView1.RowCount - 2, "Principal Allocation", CDbl(If(IsNumeric(GridView1.GetRowCellValue(0, "Outstanding Principal")), GridView1.GetRowCellValue(0, "Outstanding Principal"), 0)) - TotalPrincipal)
                    Flag = False
                End If
                TotalInterest += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Interest Income")), GridView1.GetRowCellValue(x, "Interest Income"), 0))
                TotalRPPD += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "RPPD")), GridView1.GetRowCellValue(x, "RPPD"), 0))
                TotalPrincipal += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Principal Allocation")), GridView1.GetRowCellValue(x, "Principal Allocation"), 0))
                TotalPenalty += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Penalty")), GridView1.GetRowCellValue(x, "Penalty"), 0))
                TotalMonthly += CDbl(If(IsNumeric(GridView1.GetRowCellValue(x, "Monthly")), GridView1.GetRowCellValue(x, "Monthly"), 0))
            End If
        Next
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If MsgBoxYes("Are you sure you want to edit the amortization?") = MsgBoxResult.Yes Then
            dInterest_N.Enabled = True
            dRPPD_N.Enabled = True
            dPrincipal_N.Enabled = True
            btnEdit.Enabled = False

            If From_OfficialReceipt Then
            Else
                If dInterest_N.Value <> Monthly_Interest Then
                    DInterest_N_ValueChanged(sender, e)
                End If
                If dRPPD_N.Value <> dMR_C.Value Then
                    DRPPD_N_ValueChanged(sender, e)
                End If
                If dPrincipal_N.Value <> Monthly_Principal Then
                    DPrincipal_N_ValueChanged(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub DInterest_N_ValueChanged(sender As Object, e As EventArgs) Handles dInterest_N.ValueChanged
        If dInterest_N.Enabled Then
            Dim TotalInterest As Double
            For x As Integer = 1 To GridView1.RowCount - 1
                If x = GridView1.RowCount - 2 Then 'Adjustment
                    GridView1.SetRowCellValue(x, "Interest Income", FormatNumber(CDbl(GridView1.GetRowCellValue(0, "Unearn Income")) - TotalInterest, 2))
                    TotalInterest += GridView1.GetRowCellValue(x, "Interest Income")
                ElseIf x = GridView1.RowCount - 1 Then 'Total
                    GridView1.SetRowCellValue(x, "Interest Income", FormatNumber(TotalInterest, 2))
                Else
                    GridView1.SetRowCellValue(x, "Interest Income", FormatNumber(dInterest_N.Value, 2))
                    TotalInterest += GridView1.GetRowCellValue(x, "Interest Income")
                End If
                If x = GridView1.RowCount - 1 Then 'Total
                Else
                    GridView1.SetRowCellValue(x, "Monthly", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Interest Income")) + CDbl(GridView1.GetRowCellValue(x, "RPPD")) + CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")), 2))
                    GridView1.SetRowCellValue(x, "Unearn Income", FormatNumber(CDbl(GridView1.GetRowCellValue(x - 1, "Unearn Income")) - CDbl(GridView1.GetRowCellValue(x, "Interest Income")), 2))
                    GridView1.SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")) + CDbl(GridView1.GetRowCellValue(x, "Unearn Income")) + CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")), 2))
                End If
            Next
        End If
    End Sub

    Private Sub DRPPD_N_ValueChanged(sender As Object, e As EventArgs) Handles dRPPD_N.ValueChanged
        If dRPPD_N.Enabled Then
            Dim TotalRPPD As Double
            For x As Integer = 1 To GridView1.RowCount - 1
                If x = GridView1.RowCount - 2 Then 'Adjustment
                    GridView1.SetRowCellValue(x, "RPPD", FormatNumber(CDbl(GridView1.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD, 2))
                    TotalRPPD += GridView1.GetRowCellValue(x, "RPPD")
                ElseIf x = GridView1.RowCount - 1 Then 'Total
                    GridView1.SetRowCellValue(x, "RPPD", FormatNumber(TotalRPPD, 2))
                Else
                    GridView1.SetRowCellValue(x, "RPPD", FormatNumber(dRPPD_N.Value, 2))
                    TotalRPPD += GridView1.GetRowCellValue(x, "RPPD")
                End If
                If x = GridView1.RowCount - 1 Then 'Total
                Else
                    GridView1.SetRowCellValue(x, "Monthly", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Interest Income")) + CDbl(GridView1.GetRowCellValue(x, "RPPD")) + CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")), 2))
                    GridView1.SetRowCellValue(x, "Total_RPPD", FormatNumber(CDbl(GridView1.GetRowCellValue(x - 1, "Total_RPPD")) - CDbl(GridView1.GetRowCellValue(x, "RPPD")), 2))
                    GridView1.SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")) + CDbl(GridView1.GetRowCellValue(x, "Unearn Income")) + CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")), 2))
                End If
            Next
        End If
    End Sub

    Private Sub DPrincipal_N_ValueChanged(sender As Object, e As EventArgs) Handles dPrincipal_N.ValueChanged
        If dPrincipal_N.Enabled Then
            Dim TotalPrincipal As Double
            For x As Integer = 1 To GridView1.RowCount - 1
                If x = GridView1.RowCount - 2 Then 'Adjustment
                    GridView1.SetRowCellValue(x, "Principal Allocation", FormatNumber(CDbl(GridView1.GetRowCellValue(0, "Outstanding Principal")) - TotalPrincipal, 2))
                    TotalPrincipal += GridView1.GetRowCellValue(x, "Principal Allocation")
                ElseIf x = GridView1.RowCount - 1 Then 'Total
                    GridView1.SetRowCellValue(x, "Principal Allocation", FormatNumber(TotalPrincipal, 2))
                Else
                    GridView1.SetRowCellValue(x, "Principal Allocation", FormatNumber(dPrincipal_N.Value, 2))
                    TotalPrincipal += GridView1.GetRowCellValue(x, "Principal Allocation")
                End If
                If x = GridView1.RowCount - 1 Then 'Total
                Else
                    GridView1.SetRowCellValue(x, "Monthly", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Interest Income")) + CDbl(GridView1.GetRowCellValue(x, "RPPD")) + CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")), 2))
                    GridView1.SetRowCellValue(x, "Outstanding Principal", FormatNumber(CDbl(GridView1.GetRowCellValue(x - 1, "Outstanding Principal")) - CDbl(GridView1.GetRowCellValue(x, "Principal Allocation")), 2))
                    GridView1.SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(GridView1.GetRowCellValue(x, "Outstanding Principal")) + CDbl(GridView1.GetRowCellValue(x, "Unearn Income")) + CDbl(GridView1.GetRowCellValue(x, "Total_RPPD")), 2))
                End If
            Next
        End If
    End Sub

    Private Sub LoadCompanyMode()
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            lblRPPD_C.Visible = False
            dRPPD_C.Visible = False
            dRPPD_B.Visible = False

            lblMR_C.Visible = False
            dMR_C.Visible = False
            lblMR_Slash.Visible = False
            dMR_C2.Visible = False

            lblRPPDRate_C.Visible = False
            dRPPDRate_C.Visible = False
            lblRPPDRate_Percent.Visible = False
            dRPPDRate_T.Visible = False
            lblRPPDRate_T.Visible = False

            GridColumn19.Visible = False
            GridColumn23.Visible = False
            GridColumn17.Width = 121 + 41
            GridColumn18.Width = 121 + 41
            GridColumn20.Width = 121 + 41
            GridColumn21.Width = 127 + 42
            GridColumn22.Width = 127 + 42
            GridColumn24.Width = 127 + 43

            dRPPD_N.Visible = False
            dInterest_N.Location = New Point(286 + 41, 7)
            dInterest_N.Size = New Point(123 + 41, 23)
            dPrincipal_N.Location = New Point(532 - 38, 7)
            dPrincipal_N.Size = New Point(123 + 41, 23)

            dRPPDRate_T.Value = 0
            dRPPDRate_C.Value = 0
            If Interest_RPPD = 0 Then
                Interest_RPPD = Last_RPPD
            End If

            ComputeNMA()
            If SuperTabControl1.SelectedTabIndex = 1 Then
                LoadAmortization()
            End If
        Else
            lblRPPD_C.Visible = True
            dRPPD_C.Visible = True
            dRPPD_B.Visible = True

            lblMR_C.Visible = True
            dMR_C.Visible = True
            lblMR_Slash.Visible = True
            dMR_C2.Visible = True

            lblRPPDRate_C.Visible = True
            dRPPDRate_C.Visible = True
            lblRPPDRate_Percent.Visible = True
            dRPPDRate_T.Visible = True
            lblRPPDRate_T.Visible = True

            GridColumn19.Visible = True
            GridColumn23.Visible = True
            GridColumn15.VisibleIndex = 0
            GridColumn16.VisibleIndex = 1
            GridColumn17.VisibleIndex = 2
            GridColumn18.VisibleIndex = 3
            GridColumn19.VisibleIndex = 4
            GridColumn20.VisibleIndex = 5
            GridColumn21.VisibleIndex = 6
            GridColumn23.VisibleIndex = 7
            GridColumn22.VisibleIndex = 8
            GridColumn24.VisibleIndex = 9
            GridColumn17.Width = 121
            GridColumn18.Width = 121
            GridColumn20.Width = 121
            GridColumn21.Width = 127
            GridColumn22.Width = 127
            GridColumn24.Width = 127

            dRPPD_N.Visible = True
            dInterest_N.Location = New Point(286, 7)
            dInterest_N.Size = New Point(123, 23)
            dPrincipal_N.Location = New Point(532, 7)
            dPrincipal_N.Size = New Point(123, 23)
            btnEdit.Location = New Point(666, 3)

            dRPPDRate_T.Value = Interest_RPPD
            dRPPDRate_C.Value = (Interest_RPPD * Identify_Terms(iTerms_C.Value)) / 12

            ComputeNMA()
            If SuperTabControl1.SelectedTabIndex = 1 Then
                LoadAmortization()
            End If
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub

    Private Sub BtnATM_Click(sender As Object, e As EventArgs) Handles btnATM.Click
        Dim PayDay As New FrmPayDayDetails
        With PayDay
            .BankID = PD_BankID
            .txtAccountNumber.Text = PD_AccountNumber
            .txtCardNumber.Text = PD_CardNumber
            .cbxYes.Checked = PD_ATM
            If cbxProduct.Text.Contains("SHOWMONEY") Then
                .txtCardNumber.Visible = False
                .LabelX2.Visible = False
                .LabelX14.Visible = True
                .cbxYes.Visible = True
            End If
            If .ShowDialog = DialogResult.OK Then
                PD_BankID = .cbxBank.SelectedValue
                PD_AccountNumber = .txtAccountNumber.Text
                PD_CardNumber = .txtCardNumber.Text
                PD_ATM = .cbxYes.Checked
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxCorporate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCorporate.CheckedChanged
        If Firstload = False Then
            LoadBorrower()
        End If
    End Sub

    Private Sub BtnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click
        If MsgBoxYes("Are you sure you want to edit the amortization manually?") = MsgBoxResult.Yes Then
            If From_OfficialReceipt Then
                Dim Msg As String = ""
                Dim Code As String = GenerateOTAC()
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & iAccount_2.Text & "]"
                Dim EmailTo As String = ""
                Dim BM As DataTable = GetBM(Branch_ID)
                For x As Integer = 0 To BM.Rows.Count - 1
                    Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Manual Entry of Schedule of the Account of {1} [{2}]." & vbCrLf, Code, cbxBorrower.Tag, iAccount_2.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If BM(x)("Phone") = "" Then
                    Else
                        SendSMS(BM(x)("Phone"), Msg.Replace("<br>", " "), True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If BM(x)("EmailAdd") = "" Then
                    Else
                        EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & iAccount_2.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    PrintSchedule(dAmountApplied.Text, v_iTerms_C & " " & cbxTerms.Text, cbxProduct.Text & " " & txtCollateral.Text, "", dtpAvailed.Text, FName, GridControl1)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If

                Dim OTP As New FrmOneTimePassword
                With OTP
                    .OTP = Code
                    If From_OfficialReceipt Then
                        .txtOTP.Text = .OTP
                        .lblBilling.Text = "Auto fill out of OTAC from MIGRATED Accounts."
                    End If
                    If .ShowDialog = DialogResult.OK Then
                    Else
                        Exit Sub
                    End If
                End With
            End If

            GridColumn1.OptionsColumn.AllowEdit = True
            GridColumn2.OptionsColumn.AllowEdit = True
            GridColumn16.OptionsColumn.AllowEdit = True
            GridColumn17.OptionsColumn.AllowEdit = True
            GridColumn18.OptionsColumn.AllowEdit = True
            GridColumn19.OptionsColumn.AllowEdit = True
            GridColumn20.OptionsColumn.AllowEdit = True
            GridColumn21.OptionsColumn.AllowEdit = True
            GridColumn22.OptionsColumn.AllowEdit = True
            GridColumn23.OptionsColumn.AllowEdit = True
            GridColumn24.OptionsColumn.AllowEdit = True
            btnManual.Enabled = False

            btnAddC.Visible = True
            btnRemoveC.Visible = True
            lblAvailedV2.Visible = True
            dtpAvailedV2.Visible = True
            btnPenalty.Visible = True
            cbxAuto.Visible = True
            MsgBox("Columns are now editable, Please fill the correct amortization schedule.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnRemoveC_Click(sender As Object, e As EventArgs) Handles btnRemoveC.Click
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If
        btnAddC.Enabled = True
        Dim DT As DataTable = GridControl1.DataSource
        DT.Rows.RemoveAt(GridView1.RowCount - 1)
        DT.Rows.RemoveAt(GridView1.RowCount - 1)

        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        For x As Integer = 1 To DT.Rows.Count - 1
            T_Monthly += CDbl(DT(x)("Monthly"))
            T_Interest += CDbl(DT(x)("Interest Income"))
            T_RPPD += CDbl(DT(x)("RPPD"))
            T_Principal += CDbl(DT(x)("Principal Allocation"))
        Next
        DT.Rows.Add("", "TOTAL", FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2))

        If GridView1.RowCount = 1 Then
            btnRemoveC.Enabled = False
        End If
    End Sub

    Private Sub BtnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click
        btnRemoveC.Enabled = True
        Dim DT As DataTable = GridControl1.DataSource
        DT.Rows.RemoveAt(GridView1.RowCount - 1)

        DT.Rows.Add(DT(DT.Rows.Count - 1)("No") + 1, Format(CDate(DT(DT.Rows.Count - 1)("Due Date")).AddMonths(1), "MM.dd.yyyy"), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2))

        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        For x As Integer = 1 To DT.Rows.Count - 1
            T_Monthly += CDbl(DT(x)("Monthly"))
            T_Interest += CDbl(DT(x)("Interest Income"))
            T_RPPD += CDbl(DT(x)("RPPD"))
            T_Principal += CDbl(DT(x)("Principal Allocation"))
        Next
        DT.Rows.Add("", "TOTAL", FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2))
    End Sub

    Private Sub BtnPenalty_Click(sender As Object, e As EventArgs) Handles btnPenalty.Click
        If MsgBoxYes("Are you sure you want to add monthly penalty?") = MsgBoxResult.Yes Then
            GridColumn15.VisibleIndex = 0
            GridColumn16.VisibleIndex = 1
            GridColumn17.VisibleIndex = 2
            GridColumn1.VisibleIndex = 3
            GridColumn18.VisibleIndex = 4
            GridColumn19.VisibleIndex = 5
            GridColumn20.VisibleIndex = 6
            GridColumn21.VisibleIndex = 7
            GridColumn23.VisibleIndex = 8
            GridColumn22.VisibleIndex = 9
            GridColumn2.VisibleIndex = 10
            GridColumn24.VisibleIndex = 11

            GridColumn17.Width = 90
            GridColumn1.Width = 90
            GridColumn18.Width = 90
            GridColumn19.Width = 90
            GridColumn20.Width = 90
            GridColumn21.Width = 111
            GridColumn23.Width = 111
            GridColumn22.Width = 111
            GridColumn2.Width = 90
            GridColumn24.Width = 127

            dInterest_N.Size = New Point(90, 23)
            dRPPD_N.Size = New Point(90, 23)
            dPrincipal_N.Size = New Point(90, 23)

            dInterest_N.Location = New Point(286 + 60, 7)
            dRPPD_N.Location = New Point(399 + 37, 7)
            dPrincipal_N.Location = New Point(512 + 13, 7)
            AddPenalty = True
            btnPenalty.Enabled = False
        End If
    End Sub
End Class