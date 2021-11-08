
Imports DevExpress.XtraReports.UI
Public Class FrmRealEstateAppraisal

    Public BorrowerID As Integer
    Dim FirstLoad As Boolean = True
    ReadOnly TriggerSave As Boolean
    ReadOnly TriggerDelete As Boolean
    Public vAppraised As String
    Public AssetNumber As String
    Public CreditNumber As String
    Public CINumber As String
    Public CollateralNumber As String
    Public TotalImage As Integer
    Public From_RealEstate As Boolean
    Public ChangeCollateral As Boolean

    ReadOnly ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public For_ReApraise As Boolean
    Dim DT_Pictures As New DataTable
    Public AssetNumber_1 As String
    Public AssetNumber_2 As String
    Public AssetNumber_3 As String
    Public AssetNumber_4 As String
    Public AssetNumber_5 As String
    Public SellingPrice As Double

    Private Sub FrmRealEstateAppraisal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True

        If btnSave.Text = "&Save" Then
            dtpDate.Value = Date.Now
            dtpAsOf.Value = Date.Now
            GetAppraisal()
        End If

        With cbxAppraisedBy
            .ValueMember = "ID"
            .DisplayMember = "CI"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
            .SelectedValue = Empl_ID
        End With

        FirstLoad = False
        If btnSave.Text = "Update" Or From_RealEstate Or For_ReApraise Then
            cbxAppraisedBy.Text = vAppraised
        End If

        If CreditNumber = "" Then
            btnRequirements.Visible = False
        End If

        Positioning()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX65, LabelX155, LabelX64, LabelX66, LabelX43, lblLandSQM_1, lblLandSQM_2, lblLandSQM_3, lblLandSQM_4, lblLandSQM_5, lblLandCons_1, lblLandCons_2, lblLandCons_3, lblLandCons_4, lblLandCons_5, lblLandPhp_1, lblLandPhp_2, lblLandPhp_3, lblLandPhp_4, lblLandPhp_5, lblImprovement, LabelX128, LabelX25, LabelX26, LabelX27, LabelX28, LabelX29, LabelX54, LabelX42, LabelX46, LabelX30, LabelX31, LabelX32, LabelX39, LabelX40, LabelX33, LabelX34, LabelX35, LabelX44, LabelX36, LabelX37, LabelX38, LabelX41, lblImprovementSQM_1, lblImprovementCons_1, lblImprovementPhp_1, lblImprovementSQM_2, lblImprovementCons_2, lblImprovementPhp_2, lblImprovementSQM_3, lblImprovementCons_3, lblImprovementPhp_3, lblImprovementSQM_4, lblImprovementCons_4, lblImprovementPhp_4, lblImprovementSQM_5, lblImprovementCons_5, lblImprovementPhp_5, lblMachine, lblMachineSQM_1, lblMachineCons_1, lblMachinePhp_1, lblMachineSQM_2, lblMachineCons_2, lblMachinePhp_2, lblMachineSQM_3, lblMachineCons_3, lblMachinePhp_3, lblMachineSQM_4, lblMachineCons_4, lblMachinePhp_4, lblMachineSQM_5, lblMachineCons_5, lblMachinePhp_5, lblPrevailing, lblZonal, lblPrevailingPhp, lblZonalPhp})

            GetLabelFontSettingsRed({lblMachinePhp_T, lblImprovementPhp_T, lblLandPhp_T})

            GetLabelFontSettingsDefault({lblTotalPhp, lblPhp, lblRecommended, lblPercent})

            GetLabelWithBackgroundFontSettings({LabelX131, LabelX20, LabelX55, LabelX21, LabelX22, LabelX23, LabelX24})

            GetTextBoxFontSettings({txtAppraiseNumber, txtLand, txtLandRemarks_1, txtLandRemarks_2, txtLandRemarks_3, txtLandRemarks_4, txtLandRemarks_5, txtImprovements, txtTCT, txtLot, txtRegisteredOwner, txtRegistryOfDeeds, txtCoordinates, txtOthers, txtStorey, txtFrame, txtWalling, txtPartitions, txtRoofings, txtBeams, txtCeilings, txtFlooring, txtDoors, txtWindows, txtTandB, txtYearConstructed, txtFloorArea, txtValueWords, txtImprovementRemarks_1, txtImprovementRemarks_2, txtImprovementRemarks_3, txtImprovementRemarks_4, txtImprovementRemarks_5, txtMachineRemarks_1, txtMachineRemarks_2, txtMachineRemarks_3, txtMachineRemarks_4, txtMachineRemarks_5})

            GetCheckBoxFontSettings({cbxResidential, cbxCommercial, cbxAgricultural, cbxTourism, cbxIndustrial, cbxCondominium, cbxOthers, cbxBaseMarket})

            GetCheckBoxFontSettingsRed({cbxVacant})

            GetComboBoxFontSettings({cbxAppraisedBy})

            GetComboBoxWinFormFontSettings({cbxAppraiseFor})

            GetDateTimeInputFontSettings({dtpDate, dtpAsOf})

            GetButtonFontSettings({btnROPA, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAddImage, btnRequirements, btnMap})

            GetDoubleInputFontSettings({dLandArea, dLandPrice_1, dLandTotal_1, dLandArea_2, dLandPrice_2, dLandTotal_2, dLandArea_3, dLandPrice_3, dLandTotal_3, dLandArea_4, dLandPrice_4, dLandTotal_4, dLandArea_5, dLandPrice_5, dLandTotal_5, dLandTotal_T, dImprovementArea_1, dImprovementPrice_1, dImprovementTotal_1, dImprovementArea_2, dImprovementPrice_2, dImprovementTotal_2, dImprovementArea_3, dImprovementPrice_3, dImprovementTotal_3, dImprovementArea_4, dImprovementPrice_4, dImprovementTotal_4, dImprovementArea_5, dImprovementPrice_5, dImprovementTotal_5, dImprovementTotal_T, dMachineArea_1, dMachinePrice_1, dMachineTotal_1, dMachineArea_2, dMachinePrice_2, dMachineTotal_2, dMachineArea_3, dMachinePrice_3, dMachineTotal_3, dMachineArea_4, dMachinePrice_4, dMachineTotal_4, dMachineArea_5, dMachinePrice_5, dMachineTotal_5, dMachineTotal_T, dPrevailingSellingPrice, dTotalAmount, dZonalValuation, dArea, dRecommendedAmount, dFairMarketValue, dAppraisedValue, dRecommendedPercent})
        Catch ex As Exception
            TriggerBugReport("Real Estate Appraisal - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        Dim Attach As New FrmAppraiseImageRE
        With Attach
            .AppraiseNumber = txtAppraiseNumber.Text
            If cbxAppraiseFor.Text = "ROPOA" Then
                .ID = AssetNumber
                .From_ROPOA = True
            Else
                .ID = CreditNumber
                .From_ROPOA = False
            End If
            .TotalImage = TotalImage
            .TotalImage_II = TotalImage
            Dim Classification As String = ""
            If cbxResidential.Checked Then
                Classification = cbxResidential.Text
            ElseIf cbxCommercial.Checked Then
                Classification = cbxCommercial.Text
            ElseIf cbxAgricultural.Checked Then
                Classification = cbxAgricultural.Text
            ElseIf cbxTourism.Checked Then
                Classification = cbxTourism.Text
            ElseIf cbxIndustrial.Checked Then
                Classification = cbxIndustrial.Text
            ElseIf cbxCondominium.Checked Then
                Classification = cbxCondominium.Text
            ElseIf cbxOthers.Checked Then
                Classification = cbxOthers.Text
            End If

            .DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", Classification))
            If .ShowDialog = DialogResult.OK Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        GetAppraisal()

        dLandArea.Value = 0
        dLandPrice_1.Value = 0
        txtLandRemarks_1.Text = ""
        dLandArea_2.Value = 0
        dLandPrice_2.Value = 0
        txtLandRemarks_2.Text = ""
        dLandArea_3.Value = 0
        dLandPrice_3.Value = 0
        txtLandRemarks_3.Text = ""
        dLandPrice_3.Value = 0
        txtMachine.Text = ""
        dLandTotal_4.Value = 0
        txtImprovements.Text = ""
        dPrevailingSellingPrice.Value = 0
        dZonalValuation.Value = 0
        If For_ReApraise Then
        Else
            If txtTCT.Enabled Then
                txtTCT.Text = ""
            End If
            txtLot.Text = ""
            If dArea.Enabled Then
                dArea.Value = 0
            End If
            txtRegisteredOwner.Text = ""
            txtRegistryOfDeeds.Text = ""
            rLocation.Text = ""
            txtCoordinates.Text = ""
        End If
        cbxVacant.Checked = True
        cbxResidential.Checked = False
        cbxCommercial.Checked = False
        cbxAgricultural.Checked = False
        cbxTourism.Checked = False
        cbxIndustrial.Checked = False
        cbxOthers.Checked = False
        txtStorey.Text = ""
        txtFrame.Text = ""
        txtWalling.Text = ""
        txtPartitions.Text = ""
        txtRoofings.Text = ""
        txtBeams.Text = ""
        txtCeilings.Text = ""
        txtFlooring.Text = ""
        txtDoors.Text = ""
        txtWindows.Text = ""
        txtTandB.Text = ""
        txtYearConstructed.Text = ""
        txtFloorArea.Text = ""
        rRemarks.Text = ""
        dAppraisedValue.Value = 0
        dtpAsOf.Value = Date.Now

        btnSave.Text = "&Save"
    End Sub

#Region "KEYDOWN"
    Private Sub ControlsKeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown, txtAppraiseNumber.KeyDown, cbxAppraiseFor.KeyDown, cbxAppraisedBy.KeyDown, txtLand.KeyDown, dLandArea.KeyDown, dLandPrice_1.KeyDown, dLandTotal_1.KeyDown, txtLandRemarks_1.KeyDown, btnAddLand_1.KeyDown, dLandArea_2.KeyDown, dLandPrice_2.KeyDown, dLandTotal_2.KeyDown, txtLandRemarks_2.KeyDown, btnAddLand_2.KeyDown, btnRemoveLand_2.KeyDown, dLandArea_3.KeyDown, dLandPrice_3.KeyDown, dLandTotal_3.KeyDown, txtLandRemarks_3.KeyDown, btnAddLand_3.KeyDown, btnRemoveLand_3.KeyDown, dLandArea_4.KeyDown, dLandPrice_4.KeyDown, dLandTotal_4.KeyDown, txtLandRemarks_4.KeyDown, btnAddLand_4.KeyDown, btnRemoveLand_4.KeyDown, dLandArea_5.KeyDown, dLandPrice_5.KeyDown, dLandTotal_5.KeyDown, txtLandRemarks_5.KeyDown, btnRemoveLand_5.KeyDown, txtImprovements.KeyDown, dImprovementArea_1.KeyDown, dImprovementPrice_1.KeyDown, dImprovementTotal_1.KeyDown, txtImprovementRemarks_1.KeyDown, btnAddImprovement_1.KeyDown, dImprovementArea_2.KeyDown, dImprovementPrice_2.KeyDown, dImprovementTotal_2.KeyDown, txtImprovementRemarks_2.KeyDown, btnAddImprovement_2.KeyDown, btnRemoveImprovement_2.KeyDown, dImprovementArea_3.KeyDown, dImprovementPrice_3.KeyDown, dImprovementTotal_3.KeyDown, txtImprovementRemarks_3.KeyDown, btnAddImprovement_3.KeyDown, btnRemoveImprovement_3.KeyDown, dImprovementArea_4.KeyDown, dImprovementPrice_4.KeyDown, dImprovementTotal_4.KeyDown, txtImprovementRemarks_4.KeyDown, btnAddImprovement_4.KeyDown, btnRemoveImprovement_4.KeyDown, dImprovementArea_5.KeyDown, dImprovementPrice_5.KeyDown, dImprovementTotal_5.KeyDown, txtImprovementRemarks_5.KeyDown, btnRemoveImprovement_5.KeyDown, txtMachine.KeyDown, dMachineArea_1.KeyDown, dMachinePrice_1.KeyDown, dMachineTotal_1.KeyDown, txtMachineRemarks_1.KeyDown, btnAddMachine_1.KeyDown, dMachineArea_2.KeyDown, dMachinePrice_2.KeyDown, dMachineTotal_2.KeyDown, txtMachineRemarks_2.KeyDown, btnAddMachine_2.KeyDown, btnRemoveMachine_2.KeyDown, dMachineArea_3.KeyDown, dMachinePrice_3.KeyDown, dMachineTotal_3.KeyDown, txtMachineRemarks_3.KeyDown, btnAddMachine_3.KeyDown, btnRemoveMachine_3.KeyDown, dMachineArea_4.KeyDown, dMachinePrice_4.KeyDown, dMachineTotal_4.KeyDown, txtMachineRemarks_4.KeyDown, btnAddMachine_4.KeyDown, btnRemoveMachine_4.KeyDown, dMachineArea_5.KeyDown, dMachinePrice_5.KeyDown, dMachineTotal_5.KeyDown, txtMachineRemarks_5.KeyDown, btnRemoveMachine_5.KeyDown, dPrevailingSellingPrice.KeyDown, dZonalValuation.KeyDown, txtTCT.KeyDown, txtLot.KeyDown, dArea.KeyDown, txtRegisteredOwner.KeyDown, txtRegistryOfDeeds.KeyDown, rLocation.KeyDown, txtCoordinates.KeyDown, cbxVacant.KeyDown, cbxResidential.KeyDown, cbxCommercial.KeyDown, cbxAgricultural.KeyDown, cbxTourism.KeyDown, cbxIndustrial.KeyDown, cbxCondominium.KeyDown, cbxOthers.KeyDown, txtOthers.KeyDown, txtStorey.KeyDown, txtRoofings.KeyDown, txtFlooring.KeyDown, txtTandB.KeyDown, txtFrame.KeyDown, txtBeams.KeyDown, txtDoors.KeyDown, txtYearConstructed.KeyDown, txtWalling.KeyDown, txtCeilings.KeyDown, txtWindows.KeyDown, txtFloorArea.KeyDown, txtPartitions.KeyDown, rRemarks.KeyDown, dFairMarketValue.KeyDown, cbxBaseMarket.KeyDown, dAppraisedValue.KeyDown, txtValueWords.KeyDown, dtpAsOf.KeyDown, dRecommendedAmount.KeyDown, dRecommendedPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtTCT_Leave(sender As Object, e As EventArgs) Handles txtTCT.Leave
        txtTCT.Text = ReplaceText(txtTCT.Text.Trim)
    End Sub

    Private Sub TxtLot_Leave(sender As Object, e As EventArgs) Handles txtLot.Leave
        txtLot.Text = ReplaceText(txtLot.Text.Trim)
    End Sub

    Private Sub TxtRegisteredOwner_Leave(sender As Object, e As EventArgs) Handles txtRegisteredOwner.Leave
        txtRegisteredOwner.Text = ReplaceText(txtRegisteredOwner.Text.Trim)
    End Sub

    Private Sub TxtRegistryOfDeeds_Leave(sender As Object, e As EventArgs) Handles txtRegistryOfDeeds.Leave
        txtRegistryOfDeeds.Text = ReplaceText(txtRegistryOfDeeds.Text.Trim)
    End Sub

    Private Sub RLocation_Leave(sender As Object, e As EventArgs) Handles rLocation.Leave
        rLocation.Text = ReplaceText(rLocation.Text.Trim)
    End Sub

    Private Sub TxtCoordinates_Leave(sender As Object, e As EventArgs) Handles txtCoordinates.Leave
        'txtCoordinates.Text = ReplaceText(txtCoordinates.Text)
        'If txtCoordinates.Text = "" Then
        'Else
        '    If txtCoordinates.Text.Contains(",") = False Or txtCoordinates.Text.Trim.Length < 3 Or ContainsAlphabet(txtCoordinates.Text) Or ContainsSpecial(txtCoordinates.Text) Then
        '        MsgBox("Please fill a valid coordinates with Latitude and Longitude values.", MsgBoxStyle.Information, "Info")
        '        txtCoordinates.Focus()
        '    End If
        'End If
    End Sub

    Private Sub TxtStorey_Leave(sender As Object, e As EventArgs) Handles txtStorey.Leave
        txtStorey.Text = ReplaceText(txtStorey.Text.Trim)
    End Sub

    Private Sub TxtRoofings_Leave(sender As Object, e As EventArgs) Handles txtRoofings.Leave
        txtRoofings.Text = ReplaceText(txtRoofings.Text.Trim)
    End Sub

    Private Sub TxtFlooring_Leave(sender As Object, e As EventArgs) Handles txtFlooring.Leave
        txtFlooring.Text = ReplaceText(txtFlooring.Text.Trim)
    End Sub

    Private Sub TxtTandB_Leave(sender As Object, e As EventArgs) Handles txtTandB.Leave
        txtTandB.Text = ReplaceText(txtTandB.Text.Trim)
    End Sub

    Private Sub TxtFrame_Leave(sender As Object, e As EventArgs) Handles txtFrame.Leave
        txtFrame.Text = ReplaceText(txtFrame.Text.Trim)
    End Sub

    Private Sub TxtBeams_Leave(sender As Object, e As EventArgs) Handles txtBeams.Leave
        txtBeams.Text = ReplaceText(txtBeams.Text.Trim)
    End Sub

    Private Sub TxtDoors_Leave(sender As Object, e As EventArgs) Handles txtDoors.Leave
        txtDoors.Text = ReplaceText(txtDoors.Text.Trim)
    End Sub

    Private Sub TxtYearConstructed_Leave(sender As Object, e As EventArgs) Handles txtYearConstructed.Leave
        txtYearConstructed.Text = ReplaceText(txtYearConstructed.Text.Trim)
    End Sub

    Private Sub TxtWalling_Leave(sender As Object, e As EventArgs) Handles txtWalling.Leave
        txtWalling.Text = ReplaceText(txtWalling.Text.Trim)
    End Sub

    Private Sub TxtCeilings_Leave(sender As Object, e As EventArgs) Handles txtCeilings.Leave
        txtCeilings.Text = ReplaceText(txtCeilings.Text.Trim)
    End Sub

    Private Sub TxtWindows_Leave(sender As Object, e As EventArgs) Handles txtWindows.Leave
        txtWindows.Text = ReplaceText(txtWindows.Text.Trim)
    End Sub

    Private Sub TxtFloorArea_Leave(sender As Object, e As EventArgs) Handles txtFloorArea.Leave
        txtFloorArea.Text = ReplaceText(txtFloorArea.Text.Trim)
    End Sub

    Private Sub TxtPartitions_Leave(sender As Object, e As EventArgs) Handles txtPartitions.Leave
        txtPartitions.Text = ReplaceText(txtPartitions.Text.Trim)
    End Sub

    Private Sub RRemarks_Leave(sender As Object, e As EventArgs) Handles rRemarks.Leave
        rRemarks.Text = ReplaceText(rRemarks.Text.Trim)
    End Sub

    Private Sub TxtValueWords_Leave(sender As Object, e As EventArgs) Handles txtValueWords.Leave
        txtValueWords.Text = ReplaceText(txtValueWords.Text.Trim)
    End Sub
#End Region

    Private Sub DLandTotal_1_Result(sender As Object, e As EventArgs) Handles dLandArea.ValueChanged, dLandPrice_1.ValueChanged
        dLandTotal_1.Value = dLandArea.Value * dLandPrice_1.Value
    End Sub

    Private Sub DLandTotal_2_Result(sender As Object, e As EventArgs) Handles dLandArea_2.ValueChanged, dLandPrice_2.ValueChanged
        dLandTotal_2.Value = dLandArea_2.Value * dLandPrice_2.Value
    End Sub

    Private Sub DLandTotal_3_Result(sender As Object, e As EventArgs) Handles dLandArea_3.ValueChanged, dLandPrice_3.ValueChanged
        dLandTotal_3.Value = dLandArea_3.Value * dLandPrice_3.Value
    End Sub

    Private Sub DLandTotal_4_Result(sender As Object, e As EventArgs) Handles dLandArea_4.ValueChanged, dLandPrice_4.ValueChanged
        dLandTotal_4.Value = dLandArea_4.Value * dLandPrice_4.Value
    End Sub

    Private Sub DLandTotal_5_Result(sender As Object, e As EventArgs) Handles dLandArea_5.ValueChanged, dLandPrice_5.ValueChanged
        dLandTotal_5.Value = dLandArea_5.Value * dLandPrice_5.Value
    End Sub

    Private Sub DLandTotal_T_ValueChanged(sender As Object, e As EventArgs) Handles dLandTotal_1.ValueChanged, dLandTotal_2.ValueChanged, dLandTotal_3.ValueChanged, dLandTotal_4.ValueChanged, dLandTotal_5.ValueChanged
        dLandTotal_T.Value = dLandTotal_1.Value + dLandTotal_2.Value + dLandTotal_3.Value + dLandTotal_4.Value + dLandTotal_5.Value
    End Sub

    Private Sub DImprovementTotal_1_Result(sender As Object, e As EventArgs) Handles dImprovementArea_1.ValueChanged, dImprovementPrice_1.ValueChanged
        dImprovementTotal_1.Value = dImprovementArea_1.Value * dImprovementPrice_1.Value
    End Sub

    Private Sub DImprovementTotal_2_Result(sender As Object, e As EventArgs) Handles dImprovementArea_2.ValueChanged, dImprovementPrice_2.ValueChanged
        dImprovementTotal_2.Value = dImprovementArea_2.Value * dImprovementPrice_2.Value
    End Sub

    Private Sub DImprovementTotal_3_Result(sender As Object, e As EventArgs) Handles dImprovementArea_3.ValueChanged, dImprovementPrice_3.ValueChanged
        dImprovementTotal_3.Value = dImprovementArea_3.Value * dImprovementPrice_3.Value
    End Sub

    Private Sub DImprovementTotal_4_Result(sender As Object, e As EventArgs) Handles dImprovementArea_4.ValueChanged, dImprovementPrice_4.ValueChanged
        dImprovementTotal_4.Value = dImprovementArea_4.Value * dImprovementPrice_4.Value
    End Sub

    Private Sub DImprovementTotal_5_Result(sender As Object, e As EventArgs) Handles dImprovementArea_5.ValueChanged, dImprovementPrice_5.ValueChanged
        dImprovementTotal_5.Value = dImprovementArea_5.Value * dImprovementPrice_5.Value
    End Sub

    Private Sub DImprovementTotal_T_ValueChanged(sender As Object, e As EventArgs) Handles dImprovementTotal_1.ValueChanged, dImprovementTotal_2.ValueChanged, dImprovementTotal_3.ValueChanged, dImprovementTotal_4.ValueChanged, dImprovementTotal_5.ValueChanged
        dImprovementTotal_T.Value = dImprovementTotal_1.Value + dImprovementTotal_2.Value + dImprovementTotal_3.Value + dImprovementTotal_4.Value + dImprovementTotal_5.Value
    End Sub

    Private Sub DMachineTotal_1_Result(sender As Object, e As EventArgs) Handles dMachineArea_1.ValueChanged, dMachinePrice_1.ValueChanged
        dMachineTotal_1.Value = dMachineArea_1.Value * dMachinePrice_1.Value
    End Sub

    Private Sub DMachineTotal_2_Result(sender As Object, e As EventArgs) Handles dMachineArea_2.ValueChanged, dMachinePrice_2.ValueChanged
        dMachineTotal_2.Value = dMachineArea_2.Value * dMachinePrice_2.Value
    End Sub

    Private Sub DMachineTotal_3_Result(sender As Object, e As EventArgs) Handles dMachineArea_3.ValueChanged, dMachinePrice_3.ValueChanged
        dMachineTotal_3.Value = dMachineArea_3.Value * dMachinePrice_3.Value
    End Sub

    Private Sub DMachineTotal_4_Result(sender As Object, e As EventArgs) Handles dMachineArea_4.ValueChanged, dMachinePrice_4.ValueChanged
        dMachineTotal_4.Value = dMachineArea_4.Value * dMachinePrice_4.Value
    End Sub

    Private Sub DMachineTotal_5_Result(sender As Object, e As EventArgs) Handles dMachineArea_5.ValueChanged, dMachinePrice_5.ValueChanged
        dMachineTotal_5.Value = dMachineArea_5.Value * dMachinePrice_5.Value
    End Sub

    Private Sub DMachineTotal_T_ValueChanged(sender As Object, e As EventArgs) Handles dMachineTotal_1.ValueChanged, dMachineTotal_2.ValueChanged, dMachineTotal_3.ValueChanged, dMachineTotal_4.ValueChanged, dMachineTotal_5.ValueChanged
        dMachineTotal_T.Value = dMachineTotal_1.Value + dMachineTotal_2.Value + dMachineTotal_3.Value + dMachineTotal_4.Value + dMachineTotal_5.Value
    End Sub

    Private Sub TotalAmount(sender As Object, e As EventArgs) Handles dLandTotal_T.ValueChanged, dImprovementTotal_T.ValueChanged, dMachineTotal_T.ValueChanged
        dTotalAmount.Value = dLandTotal_T.Value + dImprovementTotal_T.Value + dMachineTotal_T.Value
    End Sub

    Private Sub CbxVacant_CheckedChanged(sender As Object, e As EventArgs) Handles cbxVacant.CheckedChanged
        If cbxVacant.Checked = True Or btnROPA.Visible Then
            txtStorey.Enabled = False
            txtFrame.Enabled = False
            txtWalling.Enabled = False
            txtPartitions.Enabled = False
            txtRoofings.Enabled = False
            txtBeams.Enabled = False
            txtCeilings.Enabled = False
            txtFlooring.Enabled = False
            txtDoors.Enabled = False
            txtWindows.Enabled = False
            txtTandB.Enabled = False
            txtYearConstructed.Enabled = False
            txtFloorArea.Enabled = False
        Else
            txtStorey.Enabled = True
            txtFrame.Enabled = True
            txtWalling.Enabled = True
            txtPartitions.Enabled = True
            txtRoofings.Enabled = True
            txtBeams.Enabled = True
            txtCeilings.Enabled = True
            txtFlooring.Enabled = True
            txtDoors.Enabled = True
            txtWindows.Enabled = True
            txtTandB.Enabled = True
            txtYearConstructed.Enabled = True
            txtFloorArea.Enabled = True
        End If
    End Sub

    Private Sub DTotalAmount_ValueChanged(sender As Object, e As EventArgs) Handles dTotalAmount.ValueChanged
        dAppraisedValue.Value = dTotalAmount.Value
        txtValueWords.Text = ConvertNumberToWords(dAppraisedValue.Value, False, False)
    End Sub

    Private Sub DRecommendedPercent_ValueChanged(sender As Object, e As EventArgs) Handles dRecommendedPercent.ValueChanged
        dRecommendedAmount.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dRecommendedPercent.Value / 100)
    End Sub

    Private Sub DFairMarketValue_ValueChanged(sender As Object, e As EventArgs) Handles dFairMarketValue.ValueChanged
        dAppraisedValue.Value = dFairMarketValue.Value * (AppraisedPercent / 100)
    End Sub

    Private Sub DValue_ValueChanged(sender As Object, e As EventArgs) Handles dAppraisedValue.ValueChanged
        dRecommendedAmount.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dRecommendedPercent.Value / 100)
        If dAppraisedValue.Value > 0 Then
            btnSave.Enabled = True
            txtValueWords.Text = ConvertNumberToWords(dAppraisedValue.Value, False, False)
        Else
            btnSave.Enabled = False
            txtValueWords.Text = ""
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnDelete.DialogResult = DialogResult.Abort Then
            Close()
        Else
            If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE appraise_re SET `status` = 'DELETED' WHERE appraise_num = '{0}'", txtAppraiseNumber.Text)
                If ChangeCollateral Then
                    SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                    SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                End If
                DataObject(SQL)
                Logs("Appraise RE", "Cancel", Reason, String.Format("Cancel appraisal for {0} for {1}", txtTCT.Text & " [" & dArea.Text & "sqm]", cbxAppraiseFor.Text), "", "", CreditNumber)
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")

                btnDelete.DialogResult = DialogResult.Abort
                btnDelete.PerformClick()
            Else
                btnDelete.DialogResult = DialogResult.None
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxAppraisedBy.Text = "" Or cbxAppraisedBy.SelectedIndex = -1 Then
            MsgBox("Please select appraised by.", MsgBoxStyle.Information, "Info")
            cbxAppraisedBy.Focus()
            cbxAppraisedBy.DroppedDown = True
            Exit Sub
        End If
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            Dim Classification As String = ""
            If cbxResidential.Checked Then
                Classification = "Residential"
            ElseIf cbxCommercial.Checked Then
                Classification = "Commercial"
            ElseIf cbxAgricultural.Checked Then
                Classification = "Agricultural"
            ElseIf cbxTourism.Checked Then
                Classification = "Tourism"
            ElseIf cbxIndustrial.Checked Then
                Classification = "Industrial"
            ElseIf cbxCondominium.Checked Then
                Classification = "Condominium"
            ElseIf cbxOthers.Checked Then
                Classification = txtOthers.Text
            End If

            If btnSave.Text = "&Save" Then
                If AssetNumber = "" Then
                Else
                    For x As Integer = 0 To FrmCreditInvestigation.GridView2.RowCount - 1
                        If AssetNumber = FrmCreditInvestigation.GridView2.GetRowCellValue(x, "AssetNumber") And For_ReApraise = False Then
                            MsgBox(String.Format("Asset Number {0} already exist in the appraisal list, please check your data.", AssetNumber), MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If
                    Next
                End If
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    GetAppraisal()
                    Dim SQL As String = "INSERT INTO appraise_re SET"
                    SQL &= String.Format(" appraise_num = '{0}', ", txtAppraiseNumber.Text)
                    SQL &= String.Format(" appraise_date = '{0}', ", FormatDatePicker(dtpDate))
                    SQL &= String.Format(" appraise_by = '{0}', ", cbxAppraisedBy.SelectedValue)
                    SQL &= String.Format(" asset_number = '{0}', ", AssetNumber)
                    SQL &= String.Format(" credit_number = '{0}', ", CreditNumber)
                    SQL &= String.Format(" appraise = '{0}', ", cbxAppraiseFor.Text)
                    SQL &= String.Format(" Land = '{0}', ", txtLand.Text)
                    SQL &= String.Format(" land_area = '{0}', ", dLandArea.Value)
                    SQL &= String.Format(" land_price = '{0}', ", dLandPrice_1.Value)
                    SQL &= String.Format(" land_remarks_1 = '{0}', ", txtLandRemarks_1.Text)
                    SQL &= String.Format(" land_area_2 = '{0}', ", dLandArea_2.Value)
                    SQL &= String.Format(" land_price_2 = '{0}', ", dLandPrice_2.Value)
                    SQL &= String.Format(" land_remarks_2 = '{0}', ", txtLandRemarks_2.Text)
                    SQL &= String.Format(" land_area_3 = '{0}', ", dLandArea_3.Value)
                    SQL &= String.Format(" land_price_3 = '{0}', ", dLandPrice_3.Value)
                    SQL &= String.Format(" land_remarks_3 = '{0}', ", txtLandRemarks_3.Text)
                    SQL &= String.Format(" land_area_4 = '{0}', ", dLandArea_4.Value)
                    SQL &= String.Format(" land_price_4 = '{0}', ", dLandPrice_4.Value)
                    SQL &= String.Format(" land_remarks_4 = '{0}', ", txtLandRemarks_4.Text)
                    SQL &= String.Format(" land_area_5 = '{0}', ", dLandArea_5.Value)
                    SQL &= String.Format(" land_price_5 = '{0}', ", dLandPrice_5.Value)
                    SQL &= String.Format(" land_remarks_5 = '{0}', ", txtLandRemarks_5.Text)
                    SQL &= String.Format(" Machine = '{0}', ", txtMachine.Text)
                    SQL &= String.Format(" machine_area = '{0}', ", dMachineArea_1.Value)
                    SQL &= String.Format(" machine_price = '{0}', ", dMachinePrice_1.Value)
                    SQL &= String.Format(" machine_remarks_1 = '{0}', ", txtMachineRemarks_1.Text)
                    SQL &= String.Format(" machine_area_2 = '{0}', ", dMachineArea_2.Value)
                    SQL &= String.Format(" machine_price_2 = '{0}', ", dMachinePrice_2.Value)
                    SQL &= String.Format(" machine_remarks_2 = '{0}', ", txtMachineRemarks_2.Text)
                    SQL &= String.Format(" machine_area_3 = '{0}', ", dMachineArea_3.Value)
                    SQL &= String.Format(" machine_price_3 = '{0}', ", dMachinePrice_3.Value)
                    SQL &= String.Format(" machine_remarks_3 = '{0}', ", txtMachineRemarks_3.Text)
                    SQL &= String.Format(" machine_area_4 = '{0}', ", dMachineArea_4.Value)
                    SQL &= String.Format(" machine_price_4 = '{0}', ", dMachinePrice_4.Value)
                    SQL &= String.Format(" machine_remarks_4 = '{0}', ", txtMachineRemarks_4.Text)
                    SQL &= String.Format(" machine_area_5 = '{0}', ", dMachineArea_5.Value)
                    SQL &= String.Format(" machine_price_5 = '{0}', ", dMachinePrice_5.Value)
                    SQL &= String.Format(" machine_remarks_5 = '{0}', ", txtMachineRemarks_5.Text)
                    SQL &= String.Format(" Improvement = '{0}', ", txtImprovements.Text)
                    SQL &= String.Format(" improvement_area = '{0}', ", dImprovementArea_1.Value)
                    SQL &= String.Format(" improvement_price = '{0}', ", dImprovementPrice_1.Value)
                    SQL &= String.Format(" improvement_remarks_1 = '{0}', ", txtImprovementRemarks_1.Text)
                    SQL &= String.Format(" improvement_area_2 = '{0}', ", dImprovementArea_2.Value)
                    SQL &= String.Format(" improvement_price_2 = '{0}', ", dImprovementPrice_2.Value)
                    SQL &= String.Format(" improvement_remarks_2 = '{0}', ", txtImprovementRemarks_2.Text)
                    SQL &= String.Format(" improvement_area_3 = '{0}', ", dImprovementArea_3.Value)
                    SQL &= String.Format(" improvement_price_3 = '{0}', ", dImprovementPrice_3.Value)
                    SQL &= String.Format(" improvement_remarks_3 = '{0}', ", txtImprovementRemarks_3.Text)
                    SQL &= String.Format(" improvement_area_4 = '{0}', ", dImprovementArea_4.Value)
                    SQL &= String.Format(" improvement_price_4 = '{0}', ", dImprovementPrice_4.Value)
                    SQL &= String.Format(" improvement_remarks_4 = '{0}', ", txtImprovementRemarks_4.Text)
                    SQL &= String.Format(" improvement_area_5 = '{0}', ", dImprovementArea_5.Value)
                    SQL &= String.Format(" improvement_price_5 = '{0}', ", dImprovementPrice_5.Value)
                    SQL &= String.Format(" improvement_remarks_5 = '{0}', ", txtImprovementRemarks_5.Text)
                    SQL &= String.Format(" prevailing_selling = '{0}', ", dPrevailingSellingPrice.Value)
                    SQL &= String.Format(" rounded_to = '{0}', ", dZonalValuation.Value)
                    SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                    SQL &= String.Format(" lot_block = '{0}', ", txtLot.Text)
                    SQL &= String.Format(" area_sqm = '{0}', ", dArea.Value)
                    SQL &= String.Format(" registered_owner = '{0}', ", txtRegisteredOwner.Text)
                    SQL &= String.Format(" registry_deeds = '{0}', ", txtRegistryOfDeeds.Text)
                    SQL &= String.Format(" location = '{0}', ", rLocation.Text)
                    SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                    SQL &= String.Format(" vacant_lot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                    SQL &= String.Format(" classification = '{0}', ", Classification)
                    SQL &= String.Format(" Storey_R = '{0}', ", txtStorey.Text)
                    SQL &= String.Format(" Roofing_R = '{0}', ", txtRoofings.Text)
                    SQL &= String.Format(" Flooring_R = '{0}', ", txtFlooring.Text)
                    SQL &= String.Format(" TandB_R = '{0}', ", txtTandB.Text)
                    SQL &= String.Format(" Frame_R = '{0}', ", txtFrame.Text)
                    SQL &= String.Format(" Beams_R = '{0}', ", txtBeams.Text)
                    SQL &= String.Format(" Doors_R = '{0}', ", txtDoors.Text)
                    SQL &= String.Format(" YearConstructed_R = '{0}', ", txtYearConstructed.Text)
                    SQL &= String.Format(" Walling_R = '{0}', ", txtWalling.Text)
                    SQL &= String.Format(" Ceiling_R = '{0}', ", txtCeilings.Text)
                    SQL &= String.Format(" Windows_R = '{0}', ", txtWindows.Text)
                    SQL &= String.Format(" FloorArea_R = '{0}', ", txtFloorArea.Text)
                    SQL &= String.Format(" Partitions_R = '{0}', ", txtPartitions.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                    SQL &= String.Format(" market_value = '{0}', ", dFairMarketValue.Value)
                    SQL &= String.Format(" appraised_value = '{0}', ", dAppraisedValue.Value)
                    SQL &= String.Format(" as_of = '{0}', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" loanable_value = '{0}', ", dRecommendedAmount.Value)
                    SQL &= String.Format(" loanable_percent = '{0}', ", dRecommendedPercent.Value)
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    If cbxAppraiseFor.Text = "Credit Investigation" And For_ReApraise = False Then
                        If CINumber = "" Then
                            SQL &= " `status` = 'PENDING', "
                        Else
                            SQL &= " `status` = 'ACTIVE', "
                        End If
                        CollateralNumber = DataObject(String.Format("SELECT CONCAT('CRE', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM appraise_re WHERE branch_id = '{0}' AND YEAR(`appraise_date`) = YEAR('{2}') AND MONTH(`appraise_date`) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                    ElseIf For_ReApraise Then
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                    End If
                    If btnROPA.Visible Then
                        SQL &= String.Format(" AppraiseSellingPrice = '{0}',", SellingPrice)
                    End If
                    SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                    SQL &= String.Format(" user_code = '{0}';", User_Code)

                    If ChangeCollateral Then
                        SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                        SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                    End If
                    If cbxAppraiseFor.Text = "Credit Investigation" And For_ReApraise = False Then
                        SQL &= "INSERT INTO collateral_re SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                        SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                        SQL &= String.Format(" Location = '{0}', ", rLocation.Text)
                        SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                        SQL &= String.Format(" `Area` = '{0}', ", dArea.Value)
                        SQL &= String.Format(" Classification = '{0}', ", Classification)
                        SQL &= String.Format(" VacantLot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                        SQL &= String.Format(" Storey = '{0}', ", txtStorey.Text)
                        SQL &= String.Format(" Roofings = '{0}', ", txtRoofings.Text)
                        SQL &= String.Format(" Flooring = '{0}', ", txtFlooring.Text)
                        SQL &= String.Format(" TandB = '{0}', ", txtTandB.Text)
                        SQL &= String.Format(" Frame = '{0}', ", txtFrame.Text)
                        SQL &= String.Format(" Beams = '{0}', ", txtBeams.Text)
                        SQL &= String.Format(" Doors = '{0}', ", txtDoors.Text)
                        SQL &= String.Format(" YearConstructed = '{0}', ", txtYearConstructed.Text)
                        SQL &= String.Format(" Walling = '{0}', ", txtWalling.Text)
                        SQL &= String.Format(" `Ceiling` = '{0}', ", txtCeilings.Text)
                        SQL &= String.Format(" Windows = '{0}', ", txtWindows.Text)
                        SQL &= String.Format(" FloorArea = '{0}', ", txtFloorArea.Text)
                        SQL &= String.Format(" `Partitions` = '{0}', ", txtPartitions.Text)
                        SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                        SQL &= String.Format(" Img = '{0}', ", TotalImage)
                        If CINumber = "" Then
                            SQL &= " `status` = 'PENDING', "
                        Else
                            SQL &= " `status` = 'ACTIVE', "
                            SQL &= String.Format(" CINumber = '{0}', ", CINumber)
                        End If
                        SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                        SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                        SQL &= String.Format(" User_Code = '{0}' ", User_Code)
                    End If

                    DataObject(SQL)
                    Logs("Appraise RE", "Save", String.Format("Appraise RE {0} for {1}", txtTCT.Text & " [" & dArea.Text & "sqm]", cbxAppraiseFor.Text), "", "", "", CreditNumber)
                    'Clear()
                    Cursor = Cursors.Default
                    MsgBox("Successfully Appraised!", MsgBoxStyle.Information, "Info")

                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                Else
                    btnSave.DialogResult = DialogResult.None
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE appraise_re SET"
                    SQL &= String.Format(" appraise_by = '{0}', ", cbxAppraisedBy.SelectedValue)
                    SQL &= String.Format(" Land = '{0}', ", txtLand.Text)
                    SQL &= String.Format(" land_area = '{0}', ", dLandArea.Value)
                    SQL &= String.Format(" land_price = '{0}', ", dLandPrice_1.Value)
                    SQL &= String.Format(" land_remarks_1 = '{0}', ", txtLandRemarks_1.Text)
                    SQL &= String.Format(" land_area_2 = '{0}', ", dLandArea_2.Value)
                    SQL &= String.Format(" land_price_2 = '{0}', ", dLandPrice_2.Value)
                    SQL &= String.Format(" land_remarks_2 = '{0}', ", txtLandRemarks_2.Text)
                    SQL &= String.Format(" land_area_3 = '{0}', ", dLandArea_3.Value)
                    SQL &= String.Format(" land_price_3 = '{0}', ", dLandPrice_3.Value)
                    SQL &= String.Format(" land_remarks_3 = '{0}', ", txtLandRemarks_3.Text)
                    SQL &= String.Format(" land_area_4 = '{0}', ", dLandArea_4.Value)
                    SQL &= String.Format(" land_price_4 = '{0}', ", dLandPrice_4.Value)
                    SQL &= String.Format(" land_remarks_4 = '{0}', ", txtLandRemarks_4.Text)
                    SQL &= String.Format(" land_area_5 = '{0}', ", dLandArea_5.Value)
                    SQL &= String.Format(" land_price_5 = '{0}', ", dLandPrice_5.Value)
                    SQL &= String.Format(" land_remarks_5 = '{0}', ", txtLandRemarks_5.Text)
                    SQL &= String.Format(" Machine = '{0}', ", txtMachine.Text)
                    SQL &= String.Format(" machine_area = '{0}', ", dMachineArea_1.Value)
                    SQL &= String.Format(" machine_price = '{0}', ", dMachinePrice_1.Value)
                    SQL &= String.Format(" machine_remarks_1 = '{0}', ", txtMachineRemarks_1.Text)
                    SQL &= String.Format(" machine_area_2 = '{0}', ", dMachineArea_2.Value)
                    SQL &= String.Format(" machine_price_2 = '{0}', ", dMachinePrice_2.Value)
                    SQL &= String.Format(" machine_remarks_2 = '{0}', ", txtMachineRemarks_2.Text)
                    SQL &= String.Format(" machine_area_3 = '{0}', ", dMachineArea_3.Value)
                    SQL &= String.Format(" machine_price_3 = '{0}', ", dMachinePrice_3.Value)
                    SQL &= String.Format(" machine_remarks_3 = '{0}', ", txtMachineRemarks_3.Text)
                    SQL &= String.Format(" machine_area_4 = '{0}', ", dMachineArea_4.Value)
                    SQL &= String.Format(" machine_price_4 = '{0}', ", dMachinePrice_4.Value)
                    SQL &= String.Format(" machine_remarks_4 = '{0}', ", txtMachineRemarks_4.Text)
                    SQL &= String.Format(" machine_area_5 = '{0}', ", dMachineArea_5.Value)
                    SQL &= String.Format(" machine_price_5 = '{0}', ", dMachinePrice_5.Value)
                    SQL &= String.Format(" machine_remarks_5 = '{0}', ", txtMachineRemarks_5.Text)
                    SQL &= String.Format(" Improvement = '{0}', ", txtImprovements.Text)
                    SQL &= String.Format(" improvement_area = '{0}', ", dImprovementArea_1.Value)
                    SQL &= String.Format(" improvement_price = '{0}', ", dImprovementPrice_1.Value)
                    SQL &= String.Format(" improvement_remarks_1 = '{0}', ", txtImprovementRemarks_1.Text)
                    SQL &= String.Format(" improvement_area_2 = '{0}', ", dImprovementArea_2.Value)
                    SQL &= String.Format(" improvement_price_2 = '{0}', ", dImprovementPrice_2.Value)
                    SQL &= String.Format(" improvement_remarks_2 = '{0}', ", txtImprovementRemarks_2.Text)
                    SQL &= String.Format(" improvement_area_3 = '{0}', ", dImprovementArea_3.Value)
                    SQL &= String.Format(" improvement_price_3 = '{0}', ", dImprovementPrice_3.Value)
                    SQL &= String.Format(" improvement_remarks_3 = '{0}', ", txtImprovementRemarks_3.Text)
                    SQL &= String.Format(" improvement_area_4 = '{0}', ", dImprovementArea_4.Value)
                    SQL &= String.Format(" improvement_price_4 = '{0}', ", dImprovementPrice_4.Value)
                    SQL &= String.Format(" improvement_remarks_4 = '{0}', ", txtImprovementRemarks_4.Text)
                    SQL &= String.Format(" improvement_area_5 = '{0}', ", dImprovementArea_5.Value)
                    SQL &= String.Format(" improvement_price_5 = '{0}', ", dImprovementPrice_5.Value)
                    SQL &= String.Format(" improvement_remarks_5 = '{0}', ", txtImprovementRemarks_5.Text)
                    SQL &= String.Format(" prevailing_selling = '{0}', ", dPrevailingSellingPrice.Value)
                    SQL &= String.Format(" rounded_to = '{0}', ", dZonalValuation.Value)
                    SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                    SQL &= String.Format(" lot_block = '{0}', ", txtLot.Text)
                    SQL &= String.Format(" area_sqm = '{0}', ", dArea.Value)
                    SQL &= String.Format(" registered_owner = '{0}', ", txtRegisteredOwner.Text)
                    SQL &= String.Format(" registry_deeds = '{0}', ", txtRegistryOfDeeds.Text)
                    SQL &= String.Format(" location = '{0}', ", rLocation.Text)
                    SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                    SQL &= String.Format(" vacant_lot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                    SQL &= String.Format(" classification = '{0}', ", Classification)
                    SQL &= String.Format(" Storey_R = '{0}', ", txtStorey.Text)
                    SQL &= String.Format(" Roofing_R = '{0}', ", txtRoofings.Text)
                    SQL &= String.Format(" Flooring_R = '{0}', ", txtFlooring.Text)
                    SQL &= String.Format(" TandB_R = '{0}', ", txtTandB.Text)
                    SQL &= String.Format(" Frame_R = '{0}', ", txtFrame.Text)
                    SQL &= String.Format(" Beams_R = '{0}', ", txtBeams.Text)
                    SQL &= String.Format(" Doors_R = '{0}', ", txtDoors.Text)
                    SQL &= String.Format(" YearConstructed_R = '{0}', ", txtYearConstructed.Text)
                    SQL &= String.Format(" Walling_R = '{0}', ", txtWalling.Text)
                    SQL &= String.Format(" Ceiling_R = '{0}', ", txtCeilings.Text)
                    SQL &= String.Format(" Windows_R = '{0}', ", txtWindows.Text)
                    SQL &= String.Format(" FloorArea_R = '{0}', ", txtFloorArea.Text)
                    SQL &= String.Format(" Partitions_R = '{0}', ", txtPartitions.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                    SQL &= String.Format(" market_value = '{0}', ", dFairMarketValue.Value)
                    SQL &= String.Format(" appraised_value = '{0}', ", dAppraisedValue.Value)
                    SQL &= String.Format(" as_of = '{0}', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" loanable_value = '{0}', ", dRecommendedAmount.Value)
                    If btnROPA.Visible Then
                        SQL &= String.Format(" AppraiseSellingPrice = '{0}',", SellingPrice)
                    End If
                    SQL &= String.Format(" loanable_percent = '{0}' ", dRecommendedPercent.Value)
                    SQL &= String.Format(" WHERE appraise_num = '{0}';", txtAppraiseNumber.Text)

                    If ChangeCollateral Then
                        SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                        SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                    End If
                    If cbxAppraiseFor.Text = "Credit Investigation" Then
                        SQL &= "UPDATE collateral_re SET"
                        SQL &= String.Format(" TCT = '{0}', ", txtTCT.Text)
                        SQL &= String.Format(" Location = '{0}', ", rLocation.Text)
                        SQL &= String.Format(" Coordinates = '{0}', ", txtCoordinates.Text)
                        SQL &= String.Format(" `Area` = '{0}', ", dArea.Value)
                        SQL &= String.Format(" Classification = '{0}', ", Classification)
                        SQL &= String.Format(" VacantLot = '{0}', ", If(cbxVacant.Checked, "YES", "NO"))
                        SQL &= String.Format(" Storey = '{0}', ", txtStorey.Text)
                        SQL &= String.Format(" Roofings = '{0}', ", txtRoofings.Text)
                        SQL &= String.Format(" Flooring = '{0}', ", txtFlooring.Text)
                        SQL &= String.Format(" TandB = '{0}', ", txtTandB.Text)
                        SQL &= String.Format(" Frame = '{0}', ", txtFrame.Text)
                        SQL &= String.Format(" Beams = '{0}', ", txtBeams.Text)
                        SQL &= String.Format(" Doors = '{0}', ", txtDoors.Text)
                        SQL &= String.Format(" YearConstructed = '{0}', ", txtYearConstructed.Text)
                        SQL &= String.Format(" Walling = '{0}', ", txtWalling.Text)
                        SQL &= String.Format(" `Ceiling` = '{0}', ", txtCeilings.Text)
                        SQL &= String.Format(" Windows = '{0}', ", txtWindows.Text)
                        SQL &= String.Format(" FloorArea = '{0}', ", txtFloorArea.Text)
                        SQL &= String.Format(" `Partitions` = '{0}', ", txtPartitions.Text)
                        SQL &= String.Format(" Remarks = '{0}' ", rRemarks.Text)
                        SQL &= String.Format(" WHERE CollateralNumber = '{0}';", CollateralNumber)
                    End If

                    DataObject(SQL)
                    Logs("Appraise RE", "Update", String.Format("Update Appraise RE {0} for {1}", txtTCT.Text & " [" & dArea.Text & "sqm]", cbxAppraiseFor.Text), Changes, "", "", CreditNumber)
                    Cursor = Cursors.Default
                    MsgBox("Successfully Update Appraisal!", MsgBoxStyle.Information, "Info")

                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                Else
                    btnSave.DialogResult = DialogResult.None
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxAppraisedBy.Text = cbxAppraisedBy.Tag Then
            Else
                Change &= String.Format("Change Appraised By from {0} to {1}. ", cbxAppraisedBy.Tag, cbxAppraisedBy.Text)
            End If
            If cbxAppraiseFor.Text = "Credit Investigation" Then
                If txtTCT.Text = txtTCT.Tag Then
                Else
                    Change &= String.Format("Change TCT from {0} to {1}. ", txtTCT.Tag, txtTCT.Text)
                End If
                If rLocation.Text = rLocation.Tag Then
                Else
                    Change &= String.Format("Change Location from {0} to {1}. ", rLocation.Tag, rLocation.Text)
                End If
                If dArea.Value = dArea.Tag Then
                Else
                    Change &= String.Format("Change Area from {0} to {1}. ", dArea.Tag, dArea.Text)
                End If
                If cbxResidential.Tag <> "Residential" And cbxResidential.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxResidential.Tag, cbxResidential.Text)
                ElseIf cbxCommercial.Tag <> "Commercial" And cbxCommercial.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxCommercial.Tag, cbxCommercial.Text)
                ElseIf cbxAgricultural.Tag <> "Agricultural" And cbxAgricultural.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxAgricultural.Tag, cbxAgricultural.Text)
                ElseIf cbxTourism.Tag <> "Tourism" And cbxTourism.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxTourism.Tag, cbxTourism.Text)
                ElseIf cbxIndustrial.Tag <> "Industrial" And cbxIndustrial.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxIndustrial.Tag, cbxIndustrial.Text)
                ElseIf cbxCondominium.Tag <> "Condominium" And cbxCondominium.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxCondominium.Tag, cbxCondominium.Text)
                ElseIf cbxOthers.Tag <> "Others" And cbxOthers.Checked Then
                    Change &= String.Format("Change Classification from {0} to {1}. ", cbxOthers.Tag, txtOthers.Text)
                End If
                If If(cbxVacant.Checked, "YES", "NO") = If(cbxVacant.Tag, "YES", "NO") Then
                Else
                    Change &= String.Format("Change Vacant Lot from {0} to {1}. ", If(cbxVacant.Tag, "YES", "NO"), If(cbxVacant.Checked, "YES", "NO"))
                End If
                If txtStorey.Text = txtStorey.Tag Then
                Else
                    Change &= String.Format("Change Storey from {0} to {1}. ", txtStorey.Tag, txtStorey.Text)
                End If
                If txtRoofings.Text = txtRoofings.Tag Then
                Else
                    Change &= String.Format("Change Roofing from {0} to {1}. ", txtRoofings.Tag, txtRoofings.Text)
                End If
                If txtFlooring.Text = txtFlooring.Tag Then
                Else
                    Change &= String.Format("Change Flooring from {0} to {1}. ", txtFlooring.Tag, txtFlooring.Text)
                End If
                If txtTandB.Text = txtTandB.Tag Then
                Else
                    Change &= String.Format("Change T and B from {0} to {1}. ", txtTandB.Tag, txtTandB.Text)
                End If
                If txtFrame.Text = txtFrame.Tag Then
                Else
                    Change &= String.Format("Change Frame from {0} to {1}. ", txtFrame.Tag, txtFrame.Text)
                End If
                If txtBeams.Text = txtBeams.Tag Then
                Else
                    Change &= String.Format("Change Beam from {0} to {1}. ", txtBeams.Tag, txtBeams.Text)
                End If
                If txtDoors.Text = txtDoors.Tag Then
                Else
                    Change &= String.Format("Change Door from {0} to {1}. ", txtDoors.Tag, txtDoors.Text)
                End If
                If txtYearConstructed.Text.Trim = txtYearConstructed.Tag Then
                Else
                    Change &= String.Format("Change Year Constructed from {0} to {1}. ", txtYearConstructed.Tag, txtYearConstructed.Text.Trim)
                End If
                If txtWalling.Text = txtWalling.Tag Then
                Else
                    Change &= String.Format("Change Walling from {0} to {1}. ", txtWalling.Tag, txtWalling.Text)
                End If
                If txtCeilings.Text = txtCeilings.Tag Then
                Else
                    Change &= String.Format("Change Ceiling from {0} to {1}. ", txtCeilings.Tag, txtCeilings.Text)
                End If
                If txtWindows.Text = txtWindows.Tag Then
                Else
                    Change &= String.Format("Change Window from {0} to {1}. ", txtWindows.Tag, txtWindows.Text)
                End If
                If txtFloorArea.Text = txtFloorArea.Tag Then
                Else
                    Change &= String.Format("Change Floor from {0} to {1}. ", txtFloorArea.Tag, txtFloorArea.Text)
                End If
                If txtPartitions.Text = txtPartitions.Tag Then
                Else
                    Change &= String.Format("Change Partition from {0} to {1}. ", txtPartitions.Tag, txtPartitions.Text)
                End If
                If rRemarks.Text = rRemarks.Tag Then
                Else
                    Change &= String.Format("Change Remarks from {0} to {1}. ", rRemarks.Tag, rRemarks.Text)
                End If
            End If
            If txtLand.Text = txtLand.Tag Then
            Else
                Change &= String.Format("Change Land from {0} to {1}. ", txtLand.Tag, txtLand.Text)
            End If
            If dLandArea.Value = dLandArea.Tag Then
            Else
                Change &= String.Format("Change Land Area 1 from {0} to {1}. ", dLandArea.Tag, dLandArea.Value)
            End If
            If dLandPrice_1.Value = dLandPrice_1.Tag Then
            Else
                Change &= String.Format("Change Land Price 1 from {0} to {1}. ", dLandPrice_1.Tag, dLandPrice_1.Value)
            End If
            If txtLandRemarks_1.Text = txtLandRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Land Remarks 1 from {0} to {1}. ", txtLandRemarks_1.Tag, txtLandRemarks_1.Text)
            End If
            If dLandArea_2.Value = dLandArea_2.Tag Then
            Else
                Change &= String.Format("Change Land Area 2 from {0} to {1}. ", dLandArea_2.Tag, dLandArea_2.Value)
            End If
            If dLandPrice_2.Value = dLandPrice_2.Tag Then
            Else
                Change &= String.Format("Change Land Price 2 from {0} to {1}. ", dLandPrice_2.Tag, dLandPrice_2.Value)
            End If
            If txtLandRemarks_2.Text = txtLandRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Land Remarks 2 from {0} to {1}. ", txtLandRemarks_2.Tag, txtLandRemarks_2.Text)
            End If
            If dLandArea_3.Value = dLandArea_3.Tag Then
            Else
                Change &= String.Format("Change Land Area 3 from {0} to {1}. ", dLandArea_3.Tag, dLandArea_3.Value)
            End If
            If dLandPrice_3.Value = dLandPrice_3.Tag Then
            Else
                Change &= String.Format("Change Land Price 3 from {0} to {1}. ", dLandPrice_3.Tag, dLandPrice_3.Value)
            End If
            If txtLandRemarks_3.Text = txtLandRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Land Remarks 3 from {0} to {1}. ", txtLandRemarks_3.Tag, txtLandRemarks_3.Text)
            End If
            If dLandArea_4.Value = dLandArea_4.Tag Then
            Else
                Change &= String.Format("Change Land Area 4 from {0} to {1}. ", dLandArea_4.Tag, dLandArea_4.Value)
            End If
            If dLandPrice_4.Value = dLandPrice_4.Tag Then
            Else
                Change &= String.Format("Change Land Price 4 from {0} to {1}. ", dLandPrice_4.Tag, dLandPrice_4.Value)
            End If
            If txtLandRemarks_4.Text = txtLandRemarks_4.Tag Then
            Else
                Change &= String.Format("Change Land Remarks 4 from {0} to {1}. ", txtLandRemarks_4.Tag, txtLandRemarks_4.Text)
            End If
            If dLandArea_5.Value = dLandArea_5.Tag Then
            Else
                Change &= String.Format("Change Land Area 5 from {0} to {1}. ", dLandArea_5.Tag, dLandArea_5.Value)
            End If
            If dLandPrice_5.Value = dLandPrice_5.Tag Then
            Else
                Change &= String.Format("Change Land Price 5 from {0} to {1}. ", dLandPrice_5.Tag, dLandPrice_5.Value)
            End If
            If txtLandRemarks_5.Text = txtLandRemarks_5.Tag Then
            Else
                Change &= String.Format("Change Land Remarks 5 from {0} to {1}. ", txtLandRemarks_5.Tag, txtLandRemarks_5.Text)
            End If
            If txtMachine.Text = txtMachine.Tag Then
            Else
                Change &= String.Format("Change Machine from {0} to {1}. ", txtMachine.Tag, txtMachine.Text)
            End If
            If dMachineArea_1.Value = dMachineArea_1.Tag Then
            Else
                Change &= String.Format("Change Machine Area 1 from {0} to {1}. ", dMachineArea_1.Tag, dMachineArea_1.Value)
            End If
            If dMachinePrice_1.Value = dMachinePrice_1.Tag Then
            Else
                Change &= String.Format("Change Machine Price 1 from {0} to {1}. ", dMachinePrice_1.Tag, dMachinePrice_1.Value)
            End If
            If txtMachineRemarks_1.Text = txtMachineRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Machine Remarks 1 from {0} to {1}. ", txtMachineRemarks_1.Tag, txtMachineRemarks_1.Text)
            End If
            If dMachineArea_2.Value = dMachineArea_2.Tag Then
            Else
                Change &= String.Format("Change Machine Area 2 from {0} to {1}. ", dMachineArea_2.Tag, dMachineArea_2.Value)
            End If
            If dMachinePrice_2.Value = dMachinePrice_2.Tag Then
            Else
                Change &= String.Format("Change Machine Price 2 from {0} to {1}. ", dMachinePrice_2.Tag, dMachinePrice_2.Value)
            End If
            If txtMachineRemarks_2.Text = txtMachineRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Machine Remarks 2 from {0} to {1}. ", txtMachineRemarks_2.Tag, txtMachineRemarks_2.Text)
            End If
            If dMachineArea_3.Value = dMachineArea_3.Tag Then
            Else
                Change &= String.Format("Change Machine Area 3 from {0} to {1}. ", dMachineArea_3.Tag, dMachineArea_3.Value)
            End If
            If dMachinePrice_3.Value = dMachinePrice_3.Tag Then
            Else
                Change &= String.Format("Change Machine Price 3 from {0} to {1}. ", dMachinePrice_3.Tag, dMachinePrice_3.Value)
            End If
            If txtMachineRemarks_3.Text = txtMachineRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Machine Remarks 3 from {0} to {1}. ", txtMachineRemarks_3.Tag, txtMachineRemarks_3.Text)
            End If
            If dMachineArea_4.Value = dMachineArea_4.Tag Then
            Else
                Change &= String.Format("Change Machine Area 4 from {0} to {1}. ", dMachineArea_4.Tag, dMachineArea_4.Value)
            End If
            If dMachinePrice_4.Value = dMachinePrice_4.Tag Then
            Else
                Change &= String.Format("Change Machine Price 4 from {0} to {1}. ", dMachinePrice_4.Tag, dMachinePrice_4.Value)
            End If
            If txtMachineRemarks_4.Text = txtMachineRemarks_4.Tag Then
            Else
                Change &= String.Format("Change Machine Remarks 4 from {0} to {1}. ", txtMachineRemarks_4.Tag, txtMachineRemarks_4.Text)
            End If
            If dMachineArea_5.Value = dMachineArea_5.Tag Then
            Else
                Change &= String.Format("Change Machine Area 5 from {0} to {1}. ", dMachineArea_5.Tag, dMachineArea_5.Value)
            End If
            If dMachinePrice_5.Value = dMachinePrice_5.Tag Then
            Else
                Change &= String.Format("Change Machine Price 5 from {0} to {1}. ", dMachinePrice_5.Tag, dMachinePrice_5.Value)
            End If
            If txtMachineRemarks_5.Text = txtMachineRemarks_5.Tag Then
            Else
                Change &= String.Format("Change Machine Remarks 5 from {0} to {1}. ", txtMachineRemarks_5.Tag, txtMachineRemarks_5.Text)
            End If
            If txtImprovements.Text = txtImprovements.Tag Then
            Else
                Change &= String.Format("Change Improvements from {0} to {1}. ", txtImprovements.Tag, txtImprovements.Text)
            End If
            If dImprovementArea_1.Value = dImprovementArea_1.Tag Then
            Else
                Change &= String.Format("Change Improvement Area 1 from {0} to {1}. ", dImprovementArea_1.Tag, dImprovementArea_1.Value)
            End If
            If dImprovementPrice_1.Value = dImprovementPrice_1.Tag Then
            Else
                Change &= String.Format("Change Improvement Price 1 from {0} to {1}. ", dImprovementPrice_1.Tag, dImprovementPrice_1.Value)
            End If
            If txtImprovementRemarks_5.Text = txtImprovementRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Improvement Remarks 1 from {0} to {1}. ", txtImprovementRemarks_1.Tag, txtImprovementRemarks_1.Text)
            End If
            If dImprovementArea_2.Value = dImprovementArea_2.Tag Then
            Else
                Change &= String.Format("Change Improvement Area 2 from {0} to {1}. ", dImprovementArea_2.Tag, dImprovementArea_2.Value)
            End If
            If dImprovementPrice_2.Value = dImprovementPrice_2.Tag Then
            Else
                Change &= String.Format("Change Improvement Price 2 from {0} to {1}. ", dImprovementPrice_2.Tag, dImprovementPrice_2.Value)
            End If
            If txtImprovementRemarks_2.Text = txtImprovementRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Improvement Remarks 2 from {0} to {1}. ", txtImprovementRemarks_2.Tag, txtImprovementRemarks_2.Text)
            End If
            If dImprovementArea_3.Value = dImprovementArea_3.Tag Then
            Else
                Change &= String.Format("Change Improvement Area 3 from {0} to {1}. ", dImprovementArea_3.Tag, dImprovementArea_3.Value)
            End If
            If dImprovementPrice_3.Value = dImprovementPrice_3.Tag Then
            Else
                Change &= String.Format("Change Improvement Price 3 from {0} to {1}. ", dImprovementPrice_3.Tag, dImprovementPrice_3.Value)
            End If
            If txtImprovementRemarks_3.Text = txtImprovementRemarks_3.Tag Then
            Else
                Change &= String.Format("Change Improvement Remarks 3 from {0} to {1}. ", txtImprovementRemarks_3.Tag, txtImprovementRemarks_3.Text)
            End If
            If dImprovementArea_4.Value = dImprovementArea_4.Tag Then
            Else
                Change &= String.Format("Change Improvement Area 4 from {0} to {1}. ", dImprovementArea_4.Tag, dImprovementArea_4.Value)
            End If
            If dImprovementPrice_4.Value = dImprovementPrice_4.Tag Then
            Else
                Change &= String.Format("Change Improvement Price 4 from {0} to {1}. ", dImprovementPrice_4.Tag, dImprovementPrice_4.Value)
            End If
            If txtImprovementRemarks_4.Text = txtImprovementRemarks_4.Tag Then
            Else
                Change &= String.Format("Change Improvement Remarks 4 from {0} to {1}. ", txtImprovementRemarks_4.Tag, txtImprovementRemarks_4.Text)
            End If
            If dImprovementArea_5.Value = dImprovementArea_5.Tag Then
            Else
                Change &= String.Format("Change Improvement Area 5 from {0} to {1}. ", dImprovementArea_5.Tag, dImprovementArea_5.Value)
            End If
            If dImprovementPrice_5.Value = dImprovementPrice_5.Tag Then
            Else
                Change &= String.Format("Change Improvement Price 5 from {0} to {1}. ", dImprovementPrice_5.Tag, dImprovementPrice_5.Value)
            End If
            If txtImprovementRemarks_5.Text = txtImprovementRemarks_5.Tag Then
            Else
                Change &= String.Format("Change Improvement Remarks 5 from {0} to {1}. ", txtImprovementRemarks_5.Tag, txtImprovementRemarks_5.Text)
            End If
            If dPrevailingSellingPrice.Value = dPrevailingSellingPrice.Tag Then
            Else
                Change &= String.Format("Change Prevailing Selling Price from {0} to {1}. ", dPrevailingSellingPrice.Tag, dPrevailingSellingPrice.Value)
            End If
            If dZonalValuation.Value = dZonalValuation.Tag Then
            Else
                Change &= String.Format("Change Zonal Valuation from {0} to {1}. ", dZonalValuation.Tag, dZonalValuation.Value)
            End If
            If txtTCT.Text = txtTCT.Tag Then
            Else
                Change &= String.Format("Change TCT from {0} to {1}. ", txtTCT.Tag, txtTCT.Text)
            End If
            If txtLot.Text = txtLot.Tag Then
            Else
                Change &= String.Format("Change Block/Lot from {0} to {1}. ", txtLot.Tag, txtLot.Text)
            End If
            If dArea.Value = dArea.Tag Then
            Else
                Change &= String.Format("Change Area from {0} to {1}. ", dArea.Tag, dArea.Value)
            End If
            If txtRegisteredOwner.Text = txtRegisteredOwner.Tag Then
            Else
                Change &= String.Format("Change Registered Owner/s from {0} to {1}. ", txtRegisteredOwner.Tag, txtRegisteredOwner.Text)
            End If
            If txtRegistryOfDeeds.Text = txtRegistryOfDeeds.Tag Then
            Else
                Change &= String.Format("Change Registry of Deeds from {0} to {1}. ", txtRegistryOfDeeds.Tag, txtRegistryOfDeeds.Text)
            End If
            If rLocation.Text = rLocation.Tag Then
            Else
                Change &= String.Format("Change Location from {0} to {1}. ", rLocation.Tag, rLocation.Text)
            End If
            If cbxVacant.Tag <> "YES" And cbxVacant.Checked Then
                Change &= String.Format("Change Vacant Lot from NO to YES. ", cbxVacant.Tag, cbxVacant.Text)
            ElseIf cbxVacant.Tag <> "NO" And cbxVacant.Checked = False Then
                Change &= String.Format("Change Vacant Lot from YES to NO. ", cbxVacant.Tag, cbxVacant.Text)
            End If
            If cbxResidential.Tag <> "Residential" And cbxResidential.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxResidential.Tag, cbxResidential.Text)
            ElseIf cbxCommercial.Tag <> "Commercial" And cbxCommercial.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxCommercial.Tag, cbxCommercial.Text)
            ElseIf cbxAgricultural.Tag <> "Agricultural" And cbxAgricultural.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxAgricultural.Tag, cbxAgricultural.Text)
            ElseIf cbxTourism.Tag <> "Tourism" And cbxTourism.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxTourism.Tag, cbxTourism.Text)
            ElseIf cbxIndustrial.Tag <> "Industrial" And cbxIndustrial.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxIndustrial.Tag, cbxIndustrial.Text)
            ElseIf cbxCondominium.Tag <> "Condominium" And cbxCondominium.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxCondominium.Tag, cbxCondominium.Text)
            ElseIf cbxOthers.Tag <> "Others" And cbxOthers.Checked Then
                Change &= String.Format("Change Classification from {0} to {1}. ", cbxOthers.Tag, txtOthers.Text)
            End If
            If txtStorey.Text = txtStorey.Tag Then
            Else
                Change &= String.Format("Change Storey from {0} to {1}. ", txtStorey.Tag, txtStorey.Text)
            End If
            If txtRoofings.Text = txtRoofings.Tag Then
            Else
                Change &= String.Format("Change Roofings from {0} to {1}. ", txtRoofings.Tag, txtRoofings.Text)
            End If
            If txtFlooring.Text = txtFlooring.Tag Then
            Else
                Change &= String.Format("Change Flooring from {0} to {1}. ", txtFlooring.Tag, txtFlooring.Text)
            End If
            If txtTandB.Text = txtTandB.Tag Then
            Else
                Change &= String.Format("Change T and B from {0} to {1}. ", txtTandB.Tag, txtTandB.Text)
            End If
            If txtFrame.Text = txtFrame.Tag Then
            Else
                Change &= String.Format("Change Frame from {0} to {1}. ", txtFrame.Tag, txtFrame.Text)
            End If
            If txtBeams.Text = txtBeams.Tag Then
            Else
                Change &= String.Format("Change Beams from {0} to {1}. ", txtBeams.Tag, txtBeams.Text)
            End If
            If txtDoors.Text = txtDoors.Tag Then
            Else
                Change &= String.Format("Change Doors from {0} to {1}. ", txtDoors.Tag, txtDoors.Text)
            End If
            If txtYearConstructed.Text = txtYearConstructed.Tag Then
            Else
                Change &= String.Format("Change Year Constructed from {0} to {1}. ", txtYearConstructed.Tag, txtYearConstructed.Text)
            End If
            If txtWalling.Text = txtWalling.Tag Then
            Else
                Change &= String.Format("Change Walling from {0} to {1}. ", txtWalling.Tag, txtWalling.Text)
            End If
            If txtCeilings.Text = txtCeilings.Tag Then
            Else
                Change &= String.Format("Change Ceilings from {0} to {1}. ", txtCeilings.Tag, txtCeilings.Text)
            End If
            If txtWindows.Text = txtWindows.Tag Then
            Else
                Change &= String.Format("Change Windows from {0} to {1}. ", txtWindows.Tag, txtWindows.Text)
            End If
            If txtFloorArea.Text = txtFloorArea.Tag Then
            Else
                Change &= String.Format("Change Floor Area from {0} to {1}. ", txtFloorArea.Tag, txtFloorArea.Text)
            End If
            If txtPartitions.Text = txtPartitions.Tag Then
            Else
                Change &= String.Format("Change Partitions from {0} to {1}. ", txtPartitions.Tag, txtPartitions.Text)
            End If
            If rRemarks.Text = rRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", rRemarks.Tag, rRemarks.Text)
            End If
            If dFairMarketValue.Value = dFairMarketValue.Tag Then
            Else
                Change &= String.Format("Change Market Value from {0} to {1}. ", dFairMarketValue.Tag, dFairMarketValue.Value)
            End If
            If dAppraisedValue.Value = dAppraisedValue.Tag Then
            Else
                Change &= String.Format("Change Appraised Value from {0} to {1}. ", dAppraisedValue.Tag, dAppraisedValue.Value)
            End If
            If FormatDatePicker(dtpAsOf) = Format(DateValue(dtpAsOf.Tag), "yyyy-MM-dd") Then
            Else
                Change &= String.Format("Change As Of from {0} to {1}. ", dtpAsOf.Tag, FormatDatePicker(dtpAsOf))
            End If
            If dRecommendedAmount.Value = dRecommendedAmount.Tag Then
            Else
                Change &= String.Format("Change Loanable Amount from {0} to {1}. ", dRecommendedAmount.Tag, dRecommendedAmount.Value)
            End If
            If dRecommendedPercent.Value = dRecommendedPercent.Tag Then
            Else
                Change &= String.Format("Change Loanable Percent from {0} to {1}. ", dRecommendedPercent.Tag, dRecommendedPercent.Value)
            End If

            If cbxAppraiseFor.Text = "ROPOA" Then
            Else
                If dRecommendedAmount.Value = dRecommendedAmount.Tag Then
                Else
                    Change &= String.Format("Change Loanable Value from {0} to {1}. ", dRecommendedAmount.Tag, dRecommendedAmount.Value)
                End If
                If dRecommendedPercent.Value = dRecommendedPercent.Tag Then
                Else
                    Change &= String.Format("Change Loanable Percent from {0} to {1}. ", dRecommendedPercent.Tag, dRecommendedPercent.Value)
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("Real Estate Appraisal - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub CbxResidential_CheckedChanged(sender As Object, e As EventArgs) Handles cbxResidential.CheckedChanged
        If cbxResidential.Checked Then
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxCommercial_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCommercial.CheckedChanged
        If cbxCommercial.Checked Then
            cbxResidential.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxAgricultural_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgricultural.CheckedChanged
        If cbxAgricultural.Checked Then
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxTourism_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTourism.CheckedChanged
        If cbxTourism.Checked Then
            cbxAgricultural.Checked = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxIndustrial_CheckedChanged(sender As Object, e As EventArgs) Handles cbxIndustrial.CheckedChanged
        If cbxIndustrial.Checked Then
            cbxAgricultural.Checked = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxTourism.Checked = False
            cbxCondominium.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxCondominium_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCondominium.CheckedChanged
        If cbxCondominium.Checked Then
            txtOthers.Enabled = False
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxOthers.Checked = False
            txtOthers.Enabled = False
        End If
    End Sub

    Private Sub CbxOthers_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOthers.CheckedChanged
        If cbxOthers.Checked Then
            cbxResidential.Checked = False
            cbxCommercial.Checked = False
            cbxAgricultural.Checked = False
            cbxTourism.Checked = False
            cbxIndustrial.Checked = False
            cbxCondominium.Checked = False
            txtOthers.Enabled = True
        End If
    End Sub

    Private Sub FrmRealEstateAppraisal_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetAppraisal()
    End Sub

    Private Sub GetAppraisal()
        txtAppraiseNumber.Text = DataObject(String.Format("SELECT CONCAT('APR', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM appraise_re WHERE branch_id = '{0}' AND YEAR(appraise_date) = YEAR('{2}') AND MONTH(appraise_date) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
    End Sub

    Private Sub CbxAppraiseFor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAppraiseFor.SelectedIndexChanged
        If cbxAppraiseFor.Text = "ROPOA" Then
            lblRecommended.Visible = False
            lblPhp.Visible = False
            dRecommendedAmount.Visible = False
            dRecommendedPercent.Visible = False
            lblPercent.Visible = False
        Else
            lblRecommended.Visible = True
            lblPhp.Visible = True
            dRecommendedAmount.Visible = True
            dRecommendedPercent.Visible = True
            lblPercent.Visible = True
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
            btnDelete.Enabled = True
            btnPrint.Enabled = False

            PanelEx1.Enabled = True
            PanelEx2.Enabled = True
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptAppraisalRE
        With Report
            .Name = txtAppraiseNumber.Text
            .lblDate.Text = dtpDate.Text
            .lblAppaiseNum.Text = txtAppraiseNumber.Text
            .lblAppraiseFor.Text = cbxAppraiseFor.Text
            .lblAppraisedBy.Text = cbxAppraisedBy.Text

            .lblLand.Text = txtLand.Text

            .dLandArea.Text = dLandArea.Text
            .dPrice_1.Text = dLandPrice_1.Text
            .dTotal_1.Text = "PHP " & dLandTotal_1.Text
            .lblRemarks_1.Text = txtLandRemarks_1.Text

            .dLandArea_2.Text = dLandArea_2.Text
            .dPrice_2.Text = dLandPrice_2.Text
            .dTotal_2.Text = "PHP " & dLandTotal_2.Text
            .lblRemarks_2.Text = txtLandRemarks_2.Text

            .dLandArea_3.Text = dLandArea_3.Text
            .dPrice_3.Text = dLandPrice_3.Text
            .dTotal_3.Text = "PHP " & dLandTotal_3.Text
            .lblRemarks_3.Text = txtLandRemarks_3.Text

            .dLandArea_4.Text = dLandArea_4.Text
            .dPrice_4.Text = dLandPrice_4.Text
            .dTotal_4.Text = "PHP " & dLandTotal_4.Text
            .lblRemarks_4.Text = txtLandRemarks_4.Text

            .dLandArea_5.Text = dLandArea_5.Text
            .dPrice_5.Text = dLandPrice_5.Text
            .dTotal_5.Text = "PHP " & dLandTotal_5.Text
            .lblRemarks_5.Text = txtLandRemarks_5.Text
            .dLandTotal_T.Text = "PHP " & dLandTotal_T.Text

            .lblImprovements.Text = txtImprovements.Text

            .dImprovementArea_1.Text = dImprovementArea_1.Text
            .dImprovementPrice_1.Text = dImprovementPrice_1.Text
            .dImprovementTotal_1.Text = "PHP " & dImprovementTotal_1.Text
            .lblImprovementRemarks_1.Text = txtImprovementRemarks_1.Text

            .dImprovementArea_2.Text = dImprovementArea_2.Text
            .dImprovementPrice_2.Text = dImprovementPrice_2.Text
            .dImprovementTotal_2.Text = "PHP " & dImprovementTotal_2.Text
            .lblImprovementRemarks_2.Text = txtImprovementRemarks_2.Text

            .dImprovementArea_3.Text = dImprovementArea_3.Text
            .dImprovementPrice_3.Text = dImprovementPrice_3.Text
            .dImprovementTotal_3.Text = "PHP " & dImprovementTotal_3.Text
            .lblImprovementRemarks_3.Text = txtImprovementRemarks_3.Text

            .dImprovementArea_4.Text = dImprovementArea_4.Text
            .dImprovementPrice_4.Text = dImprovementPrice_4.Text
            .dImprovementTotal_4.Text = "PHP " & dImprovementTotal_4.Text
            .lblImprovementRemarks_4.Text = txtImprovementRemarks_4.Text

            .dImprovementArea_5.Text = dImprovementArea_5.Text
            .dImprovementPrice_5.Text = dImprovementPrice_5.Text
            .dImprovementTotal_5.Text = "PHP " & dImprovementTotal_5.Text
            .lblImprovementRemarks_5.Text = txtImprovementRemarks_5.Text
            .dImprovementTotal_T.Text = "PHP " & dImprovementTotal_T.Text

            .lblMachine.Text = txtMachine.Text

            .dMachineArea_1.Text = dMachineArea_1.Text
            .dMachinePrice_1.Text = dMachinePrice_1.Text
            .dMachineTotal_1.Text = "PHP " & dMachineTotal_1.Text
            .lblMachineRemarks_1.Text = txtMachineRemarks_1.Text

            .dMachineArea_2.Text = dMachineArea_2.Text
            .dMachinePrice_2.Text = dMachinePrice_2.Text
            .dMachineTotal_2.Text = "PHP " & dMachineTotal_2.Text
            .lblMachineRemarks_2.Text = txtMachineRemarks_2.Text

            .dMachineArea_3.Text = dMachineArea_3.Text
            .dMachinePrice_3.Text = dMachinePrice_3.Text
            .dMachineTotal_3.Text = "PHP " & dMachineTotal_3.Text
            .lblMachineRemarks_3.Text = txtMachineRemarks_3.Text

            .dMachineArea_4.Text = dMachineArea_4.Text
            .dMachinePrice_4.Text = dMachinePrice_4.Text
            .dMachineTotal_4.Text = "PHP " & dMachineTotal_4.Text
            .lblMachineRemarks_4.Text = txtMachineRemarks_4.Text

            .dMachineArea_5.Text = dMachineArea_5.Text
            .dMachinePrice_5.Text = dMachinePrice_5.Text
            .dMachineTotal_5.Text = "PHP " & dMachineTotal_5.Text
            .lblMachineRemarks_5.Text = txtMachineRemarks_5.Text
            .dMachineTotal_T.Text = "PHP " & dMachineTotal_T.Text

            .dTotalAmount.Text = "PHP " & dTotalAmount.Text
            .dPrevailingSellingPrice.Text = "PHP " & dPrevailingSellingPrice.Text
            .dZonalValuation.Text = "PHP " & dZonalValuation.Text

            .txtTCT.Text = txtTCT.Text
            .txtLot.Text = txtLot.Text
            .dArea.Text = dArea.Text
            .txtRegisteredOwner.Text = txtRegisteredOwner.Text
            .txtRegistryOfDeeds.Text = txtRegistryOfDeeds.Text
            .txtLocation.Text = rLocation.Text
            .cbxVacantLot.Checked = cbxVacant.Checked
            .cbxResidential.Checked = cbxResidential.Checked
            .cbxCommercial.Checked = cbxCommercial.Checked
            .cbxAgricultural.Checked = cbxAgricultural.Checked
            .cbxTourism.Checked = cbxTourism.Checked
            .cbxIndustrial.Checked = cbxIndustrial.Checked
            .cbxOthers.Checked = cbxOthers.Checked
            .lblStorey_R.Text = txtStorey.Text
            .lblRoofings_R.Text = txtRoofings.Text
            .lblFloorings_R.Text = txtFlooring.Text
            .lblTandB_R.Text = txtTandB.Text
            .lblFrames_R.Text = txtFrame.Text
            .lblBeams_R.Text = txtBeams.Text
            .lblDoors_R.Text = txtDoors.Text
            .lblYear_R.Text = txtYearConstructed.Text
            .lblWalling_R.Text = txtWalling.Text
            .lblCeiling_R.Text = txtCeilings.Text
            .lblWindows_R.Text = txtWindows.Text
            .lblFloorArea_R.Text = txtFloorArea.Text
            .lblPartitions_R.Text = txtPartitions.Text
            .lblRemarks.Text = rRemarks.Text
            FormRestriction(64)
            If allow_Print Then
                .dAppraisedValue.Text = "Php " & dAppraisedValue.Text
                .txtValueWords.Text = txtValueWords.Text
                .lblAsOf.Text = dtpAsOf.Text
            Else
                .dAppraisedValue.Text = ""
                .txtValueWords.Text = ""
                .lblAsOf.Text = ""
            End If

            If cbxAppraiseFor.Text = "ROPOA" Then
                .lblRecommended.Visible = False
                .lblRecommendedPHP.Visible = False
                .dRecommendedAmount.Visible = False
                .dRecommendedPercent.Visible = False
            Else
                .dRecommendedAmount.Text = "Php " & dRecommendedAmount.Text
                .dRecommendedPercent.Text = dRecommendedPercent.Text & "%"
                .lblRecommended.Visible = True
                .lblRecommendedPHP.Visible = True
                .dRecommendedAmount.Visible = True
                .dRecommendedPercent.Visible = True
            End If

            Dim xPos As Integer = 1
            If TotalImage > 0 Then
                DT_Pictures = DataSource(String.Format("SELECT Picture FROM re_classification WHERE IF('{0}' NOT IN ('Residential','Commercial','Agricultural','Tourism','Industrial','Condominium'),Classification = 'Others',Classification = '{0}') AND `status` = 'ACTIVE';", If(cbxResidential.Checked, "Residential", If(cbxCommercial.Checked, "Commercial", If(cbxAgricultural.Checked, "Agricultural", If(cbxTourism.Checked, "Tourism", If(cbxIndustrial.Checked, "Industrial", If(cbxCondominium.Checked, "Condominium", "txtOthers"))))))))
                Dim PathX As String = ""
                If cbxAppraiseFor.Text = "ROPOA" Then
                    PathX = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, Branch_Code, If(CreditNumber = "", AssetNumber, CreditNumber), txtAppraiseNumber.Text)
                Else
                    PathX = String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, If(CreditNumber = "", AssetNumber, CreditNumber), "RE Appraise")
                End If
                If IO.Directory.Exists(PathX) Then
                    Dim files() As String = IO.Directory.GetFiles(PathX)
                    For Each file As String In files
                        Dim pB As New XRPictureBox With {
                            .Size = New System.Drawing.Size(375, 235),
                            .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                            .Borders = DevExpress.XtraPrinting.BorderSide.All
                        }
                        '***ADD LABEL***'
                        Dim lblImage As New XRLabel With {
                            .SizeF = New Size(375, 10),
                            .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        }
                        '***ADD LABEL***'
                        If xPos Mod 2 = 0 Then
                            pB.Location = New Point(412.5, 1000 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                            lblImage.Location = New Point(412.5, (1000 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                        Else
                            pB.Location = New Point(12.5, 1000 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0))
                            lblImage.Location = New Point(12.5, (1000 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 245), 0)) - 10)
                        End If
                        Dim Path As String = file.ToString
                        If IO.File.Exists(Path) Then
                            Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                            Try
                                TempPB.Image = Image.FromFile(Path)
                            Catch ex As Exception
                                TriggerBugReport("Real Estate Appraisal - Print", ex.Message.ToString)
                            End Try
                            pB.Image = TempPB.Image.Clone
                            TempPB.Dispose()
                            .Detail.Controls.Add(pB)
                            .Detail.Controls.Add(lblImage)
                            xPos += 1
                        End If
                    Next
                End If
            End If
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub FrmRealEstateAppraisal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If btnAddImage.Enabled = True Then
            If cbxAppraiseFor.Text = "ROPOA" Then
                FrmAppraisalManagement.GridView4.SetFocusedRowCellValue("Attach", TotalImage)
            Else
                FrmAppraisalManagement.GridView3.SetFocusedRowCellValue("Attach", TotalImage)
            End If
        End If
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .Tag = 63
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            End If
            .For_Viewing = True
            .CreditNumber = CreditNumber
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxBaseMarket_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBaseMarket.CheckedChanged
        dRecommendedAmount.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dRecommendedPercent.Value / 100)
    End Sub

    Private Sub BtnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        If txtCoordinates.Text <> "" Then
            Process.Start(txtCoordinates.Text)
        ElseIf rLocation.Text <> "" Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", rLocation.Text))
        Else
            MsgBox("Location and Google Map are empty.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub TxtLandRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtLandRemarks_1.Leave
        txtLandRemarks_1.Text = ReplaceText(txtLandRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtLandRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtLandRemarks_2.Leave
        txtLandRemarks_2.Text = ReplaceText(txtLandRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtLandRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtLandRemarks_3.Leave
        txtLandRemarks_3.Text = ReplaceText(txtLandRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtLandRemarks_4_Leave(sender As Object, e As EventArgs) Handles txtLandRemarks_4.Leave
        txtLandRemarks_4.Text = ReplaceText(txtLandRemarks_4.Text.Trim)
    End Sub

    Private Sub TxtLandRemarks_5_Leave(sender As Object, e As EventArgs) Handles txtLandRemarks_5.Leave
        txtLandRemarks_5.Text = ReplaceText(txtLandRemarks_5.Text.Trim)
    End Sub

    Private Sub TxtImprovementRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtImprovementRemarks_1.Leave
        txtImprovementRemarks_1.Text = ReplaceText(txtImprovementRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtImprovementRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtImprovementRemarks_2.Leave
        txtImprovementRemarks_2.Text = ReplaceText(txtImprovementRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtImprovementRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtImprovementRemarks_3.Leave
        txtImprovementRemarks_3.Text = ReplaceText(txtImprovementRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtImprovementRemarks_4_Leave(sender As Object, e As EventArgs) Handles txtImprovementRemarks_4.Leave
        txtImprovementRemarks_4.Text = ReplaceText(txtImprovementRemarks_4.Text.Trim)
    End Sub

    Private Sub TxtImprovementRemarks_5_Leave(sender As Object, e As EventArgs) Handles txtImprovementRemarks_5.Leave
        txtImprovementRemarks_5.Text = ReplaceText(txtImprovementRemarks_5.Text.Trim)
    End Sub

    Private Sub TxtMachineRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtMachineRemarks_1.Leave
        txtMachineRemarks_1.Text = ReplaceText(txtMachineRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtMachineRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtMachineRemarks_2.Leave
        txtMachineRemarks_2.Text = ReplaceText(txtMachineRemarks_2.Text.Trim)
    End Sub

    Private Sub TxtMachineRemarks_3_Leave(sender As Object, e As EventArgs) Handles txtMachineRemarks_3.Leave
        txtMachineRemarks_3.Text = ReplaceText(txtMachineRemarks_3.Text.Trim)
    End Sub

    Private Sub TxtMachineRemarks_4_Leave(sender As Object, e As EventArgs) Handles txtMachineRemarks_4.Leave
        txtMachineRemarks_4.Text = ReplaceText(txtMachineRemarks_4.Text.Trim)
    End Sub

    Private Sub TxtMachineRemarks_5_Leave(sender As Object, e As EventArgs) Handles txtMachineRemarks_5.Leave
        txtMachineRemarks_5.Text = ReplaceText(txtMachineRemarks_5.Text.Trim)
    End Sub

    Private Sub TxtMachine_Leave(sender As Object, e As EventArgs) Handles txtMachine.Leave
        txtMachine.Text = ReplaceText(txtMachine.Text.Trim)
    End Sub

    Private Sub TxtImprovements_Leave(sender As Object, e As EventArgs) Handles txtImprovements.Leave
        txtImprovements.Text = ReplaceText(txtImprovements.Text.Trim)
    End Sub

    Private Sub TxtLand_Leave(sender As Object, e As EventArgs) Handles txtLand.Leave
        txtLand.Text = ReplaceText(txtLand.Text.Trim)
    End Sub

    Private Sub Positioning()
        '******* L O C A T I O N ********************************************************************************************************
        Dim ImrpovementPos As Integer = 116
        If dLandArea_2.Visible Then
            ImrpovementPos -= 29
        End If
        If dLandArea_3.Visible Then
            ImrpovementPos -= 29
        End If
        If dLandArea_4.Visible Then
            ImrpovementPos -= 29
        End If
        If dLandArea_5.Visible Then
            ImrpovementPos -= 29
        End If
        Dim MachinePos As Integer = 116
        If dImprovementArea_2.Visible Then
            MachinePos -= 29
        End If
        If dImprovementArea_3.Visible Then
            MachinePos -= 29
        End If
        If dImprovementArea_4.Visible Then
            MachinePos -= 29
        End If
        If dImprovementArea_5.Visible Then
            MachinePos -= 29
        End If
        Dim TotalPos As Integer = 116
        If dMachineArea_2.Visible Then
            TotalPos -= 29
        End If
        If dMachineArea_3.Visible Then
            TotalPos -= 29
        End If
        If dMachineArea_4.Visible Then
            TotalPos -= 29
        End If
        If dMachineArea_5.Visible Then
            TotalPos -= 29
        End If

        lblLandPhp_T.Location = New Point(708, 180 - ImrpovementPos)
        dLandTotal_T.Location = New Point(755, 180 - ImrpovementPos)
        lblImprovement.Location = New Point(10, 209 - ImrpovementPos)
        txtImprovements.Location = New Point(184, 209 - ImrpovementPos)
        dImprovementArea_1.Location = New Point(184, 240 - ImrpovementPos)
        lblImprovementSQM_1.Location = New Point(360, 240 - ImrpovementPos)
        dImprovementPrice_1.Location = New Point(439, 240 - ImrpovementPos)
        lblImprovementCons_1.Location = New Point(615, 240 - ImrpovementPos)
        lblImprovementPhp_1.Location = New Point(708, 240 - ImrpovementPos)
        dImprovementTotal_1.Location = New Point(755, 240 - ImrpovementPos)
        txtImprovementRemarks_1.Location = New Point(931, 240 - ImrpovementPos)
        btnAddImprovement_1.Location = New Point(1188, 240 - ImrpovementPos)

        dImprovementArea_2.Location = New Point(184, 269 - ImrpovementPos)
        lblImprovementSQM_2.Location = New Point(360, 269 - ImrpovementPos)
        dImprovementPrice_2.Location = New Point(439, 269 - ImrpovementPos)
        lblImprovementCons_2.Location = New Point(615, 269 - ImrpovementPos)
        lblImprovementPhp_2.Location = New Point(708, 269 - ImrpovementPos)
        dImprovementTotal_2.Location = New Point(755, 269 - ImrpovementPos)
        txtImprovementRemarks_2.Location = New Point(931, 269 - ImrpovementPos)
        btnAddImprovement_2.Location = New Point(1188, 269 - ImrpovementPos)
        btnRemoveImprovement_2.Location = New Point(1226, 269 - ImrpovementPos)

        dImprovementArea_3.Location = New Point(184, 298 - ImrpovementPos)
        lblImprovementSQM_3.Location = New Point(360, 298 - ImrpovementPos)
        dImprovementPrice_3.Location = New Point(439, 298 - ImrpovementPos)
        lblImprovementCons_3.Location = New Point(615, 298 - ImrpovementPos)
        lblImprovementPhp_3.Location = New Point(708, 298 - ImrpovementPos)
        dImprovementTotal_3.Location = New Point(755, 298 - ImrpovementPos)
        txtImprovementRemarks_3.Location = New Point(931, 298 - ImrpovementPos)
        btnAddImprovement_3.Location = New Point(1188, 298 - ImrpovementPos)
        btnRemoveImprovement_3.Location = New Point(1226, 298 - ImrpovementPos)

        dImprovementArea_4.Location = New Point(184, 327 - ImrpovementPos)
        lblImprovementSQM_4.Location = New Point(360, 327 - ImrpovementPos)
        dImprovementPrice_4.Location = New Point(439, 327 - ImrpovementPos)
        lblImprovementCons_4.Location = New Point(615, 327 - ImrpovementPos)
        lblImprovementPhp_4.Location = New Point(708, 327 - ImrpovementPos)
        dImprovementTotal_4.Location = New Point(755, 327 - ImrpovementPos)
        txtImprovementRemarks_4.Location = New Point(931, 327 - ImrpovementPos)
        btnAddImprovement_4.Location = New Point(1188, 327 - ImrpovementPos)
        btnRemoveImprovement_4.Location = New Point(1226, 327 - ImrpovementPos)

        dImprovementArea_5.Location = New Point(184, 356 - ImrpovementPos)
        lblImprovementSQM_5.Location = New Point(360, 356 - ImrpovementPos)
        dImprovementPrice_5.Location = New Point(439, 356 - ImrpovementPos)
        lblImprovementCons_5.Location = New Point(615, 356 - ImrpovementPos)
        lblImprovementPhp_5.Location = New Point(708, 356 - ImrpovementPos)
        dImprovementTotal_5.Location = New Point(755, 356 - ImrpovementPos)
        txtImprovementRemarks_5.Location = New Point(931, 356 - ImrpovementPos)
        btnRemoveImprovement_5.Location = New Point(1188, 356 - ImrpovementPos)
        lblImprovementPhp_T.Location = New Point(708, 385 - (ImrpovementPos + MachinePos))
        dImprovementTotal_T.Location = New Point(755, 385 - (ImrpovementPos + MachinePos))

        lblMachine.Location = New Point(3, 413 - (ImrpovementPos + MachinePos))
        txtMachine.Location = New Point(184, 414 - (ImrpovementPos + MachinePos))
        dMachineArea_1.Location = New Point(184, 444 - (ImrpovementPos + MachinePos))
        lblMachineSQM_1.Location = New Point(360, 444 - (ImrpovementPos + MachinePos))
        dMachinePrice_1.Location = New Point(439, 444 - (ImrpovementPos + MachinePos))
        lblMachineCons_1.Location = New Point(615, 444 - (ImrpovementPos + MachinePos))
        lblMachinePhp_1.Location = New Point(708, 444 - (ImrpovementPos + MachinePos))
        dMachineTotal_1.Location = New Point(755, 444 - (ImrpovementPos + MachinePos))
        txtMachineRemarks_1.Location = New Point(931, 444 - (ImrpovementPos + MachinePos))
        btnAddMachine_1.Location = New Point(1188, 444 - (ImrpovementPos + MachinePos))

        dMachineArea_2.Location = New Point(184, 473 - (ImrpovementPos + MachinePos))
        lblMachineSQM_2.Location = New Point(360, 473 - (ImrpovementPos + MachinePos))
        dMachinePrice_2.Location = New Point(439, 473 - (ImrpovementPos + MachinePos))
        lblMachineCons_2.Location = New Point(615, 473 - (ImrpovementPos + MachinePos))
        lblMachinePhp_2.Location = New Point(708, 473 - (ImrpovementPos + MachinePos))
        dMachineTotal_2.Location = New Point(755, 473 - (ImrpovementPos + MachinePos))
        txtMachineRemarks_2.Location = New Point(931, 473 - (ImrpovementPos + MachinePos))
        btnAddMachine_2.Location = New Point(1188, 473 - (ImrpovementPos + MachinePos))
        btnRemoveMachine_2.Location = New Point(1226, 473 - (ImrpovementPos + MachinePos))

        dMachineArea_3.Location = New Point(184, 502 - (ImrpovementPos + MachinePos))
        lblMachineSQM_3.Location = New Point(360, 502 - (ImrpovementPos + MachinePos))
        dMachinePrice_3.Location = New Point(439, 502 - (ImrpovementPos + MachinePos))
        lblMachineCons_3.Location = New Point(615, 502 - (ImrpovementPos + MachinePos))
        lblMachinePhp_3.Location = New Point(708, 502 - (ImrpovementPos + MachinePos))
        dMachineTotal_3.Location = New Point(755, 502 - (ImrpovementPos + MachinePos))
        txtMachineRemarks_3.Location = New Point(931, 502 - (ImrpovementPos + MachinePos))
        btnAddMachine_3.Location = New Point(1188, 502 - (ImrpovementPos + MachinePos))
        btnRemoveMachine_3.Location = New Point(1226, 502 - (ImrpovementPos + MachinePos))

        dMachineArea_4.Location = New Point(184, 531 - (ImrpovementPos + MachinePos))
        lblMachineSQM_4.Location = New Point(360, 531 - (ImrpovementPos + MachinePos))
        dMachinePrice_4.Location = New Point(439, 531 - (ImrpovementPos + MachinePos))
        lblMachineCons_4.Location = New Point(615, 531 - (ImrpovementPos + MachinePos))
        lblMachinePhp_4.Location = New Point(708, 531 - (ImrpovementPos + MachinePos))
        dMachineTotal_4.Location = New Point(755, 531 - (ImrpovementPos + MachinePos))
        txtMachineRemarks_4.Location = New Point(931, 531 - (ImrpovementPos + MachinePos))
        btnAddMachine_4.Location = New Point(1188, 531 - (ImrpovementPos + MachinePos))
        btnRemoveMachine_4.Location = New Point(1226, 531 - (ImrpovementPos + MachinePos))

        dMachineArea_5.Location = New Point(184, 560 - (ImrpovementPos + MachinePos))
        lblMachineSQM_5.Location = New Point(360, 560 - (ImrpovementPos + MachinePos))
        dMachinePrice_5.Location = New Point(439, 560 - (ImrpovementPos + MachinePos))
        lblMachineCons_5.Location = New Point(615, 560 - (ImrpovementPos + MachinePos))
        lblMachinePhp_5.Location = New Point(708, 560 - (ImrpovementPos + MachinePos))
        dMachineTotal_5.Location = New Point(755, 560 - (ImrpovementPos + MachinePos))
        txtMachineRemarks_5.Location = New Point(931, 560 - (ImrpovementPos + MachinePos))
        btnRemoveMachine_5.Location = New Point(1188, 560 - (ImrpovementPos + MachinePos))
        lblMachinePhp_T.Location = New Point(708, 589 - (ImrpovementPos + MachinePos + TotalPos))
        dMachineTotal_T.Location = New Point(755, 589 - (ImrpovementPos + MachinePos + TotalPos))

        lblTotalPhp.Location = New Point(708, 618 - (ImrpovementPos + MachinePos + TotalPos))
        dTotalAmount.Location = New Point(755, 618 - (ImrpovementPos + MachinePos + TotalPos))
        lblTOTAL.Location = New Point(4, 618 - (ImrpovementPos + MachinePos + TotalPos))
        lblPrevailing.Location = New Point(184, 618 - (ImrpovementPos + MachinePos + TotalPos))
        lblPrevailingPhp.Location = New Point(484, 618 - (ImrpovementPos + MachinePos + TotalPos))
        dPrevailingSellingPrice.Location = New Point(531, 618 - (ImrpovementPos + MachinePos + TotalPos))
        lblROUNDED.Location = New Point(4, 649 - (ImrpovementPos + MachinePos + TotalPos))
        lblZonal.Location = New Point(184, 649 - (ImrpovementPos + MachinePos + TotalPos))
        lblZonalPhp.Location = New Point(484, 647 - (ImrpovementPos + MachinePos + TotalPos))
        dZonalValuation.Location = New Point(531, 647 - (ImrpovementPos + MachinePos + TotalPos))
        lblHidden.Location = New Point(1210, 663 - (ImrpovementPos + MachinePos + TotalPos))
        PanelEx1.AutoScroll = True
        '******* L O C A T I O N ********************************************************************************************************
    End Sub

    Private Sub BtnAddLand_1_Click(sender As Object, e As EventArgs) Handles btnAddLand_1.Click
        PanelEx1.AutoScroll = False
        btnAddLand_1.Visible = False

        dLandArea_2.Visible = True
        lblLandSQM_2.Visible = True
        dLandPrice_2.Visible = True
        lblLandCons_2.Visible = True
        lblLandPhp_2.Visible = True
        dLandTotal_2.Visible = True
        txtLandRemarks_2.Visible = True
        btnAddLand_2.Visible = True
        btnRemoveLand_2.Visible = True

        Positioning()
        PanelEx1.AutoScroll = True
    End Sub

    Private Sub BtnAddLand_2_Click(sender As Object, e As EventArgs) Handles btnAddLand_2.Click
        PanelEx1.AutoScroll = False
        btnAddLand_2.Visible = False
        btnRemoveLand_2.Visible = False

        dLandArea_3.Visible = True
        lblLandSQM_3.Visible = True
        dLandPrice_3.Visible = True
        lblLandCons_3.Visible = True
        lblLandPhp_3.Visible = True
        dLandTotal_3.Visible = True
        txtLandRemarks_3.Visible = True
        btnAddLand_3.Visible = True
        btnRemoveLand_3.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddLand_3_Click(sender As Object, e As EventArgs) Handles btnAddLand_3.Click
        PanelEx1.AutoScroll = False
        btnAddLand_3.Visible = False
        btnRemoveLand_3.Visible = False

        dLandArea_4.Visible = True
        lblLandSQM_4.Visible = True
        dLandPrice_4.Visible = True
        lblLandCons_4.Visible = True
        lblLandPhp_4.Visible = True
        dLandTotal_4.Visible = True
        txtLandRemarks_4.Visible = True
        btnAddLand_4.Visible = True
        btnRemoveLand_4.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddLand_4_Click(sender As Object, e As EventArgs) Handles btnAddLand_4.Click
        PanelEx1.AutoScroll = False
        btnAddLand_4.Visible = False
        btnRemoveLand_4.Visible = False

        dLandArea_5.Visible = True
        lblLandSQM_5.Visible = True
        dLandPrice_5.Visible = True
        lblLandCons_5.Visible = True
        lblLandPhp_5.Visible = True
        dLandTotal_5.Visible = True
        txtLandRemarks_5.Visible = True
        btnRemoveLand_5.Visible = True

        Positioning()
    End Sub

    Private Sub BtnRemoveLand_2_Click(sender As Object, e As EventArgs) Handles btnRemoveLand_2.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dLandArea_2.Visible = False
            lblLandSQM_2.Visible = False
            dLandPrice_2.Visible = False
            lblLandCons_2.Visible = False
            lblLandPhp_2.Visible = False
            dLandTotal_2.Visible = False
            txtLandRemarks_2.Visible = False
            btnAddLand_2.Visible = False
            btnRemoveLand_2.Visible = False

            dLandArea_2.Value = 0
            dLandPrice_2.Value = 0
            dLandTotal_2.Value = 0
            txtLandRemarks_2.Text = ""

            btnAddLand_1.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveLand_3_Click(sender As Object, e As EventArgs) Handles btnRemoveLand_3.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dLandArea_3.Visible = False
            lblLandSQM_3.Visible = False
            dLandPrice_3.Visible = False
            lblLandCons_3.Visible = False
            lblLandPhp_3.Visible = False
            dLandTotal_3.Visible = False
            txtLandRemarks_3.Visible = False
            btnAddLand_3.Visible = False
            btnRemoveLand_3.Visible = False

            dLandArea_3.Value = 0
            dLandPrice_3.Value = 0
            dLandTotal_3.Value = 0
            txtLandRemarks_3.Text = ""

            btnAddLand_2.Visible = True
            btnRemoveLand_2.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveLand_4_Click(sender As Object, e As EventArgs) Handles btnRemoveLand_4.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dLandArea_4.Visible = False
            lblLandSQM_4.Visible = False
            dLandPrice_4.Visible = False
            lblLandCons_4.Visible = False
            lblLandPhp_4.Visible = False
            dLandTotal_4.Visible = False
            txtLandRemarks_4.Visible = False
            btnAddLand_4.Visible = False
            btnRemoveLand_4.Visible = False

            dLandArea_4.Value = 0
            dLandPrice_4.Value = 0
            dLandTotal_4.Value = 0
            txtLandRemarks_4.Text = ""

            btnAddLand_3.Visible = True
            btnRemoveLand_3.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveLand_5_Click(sender As Object, e As EventArgs) Handles btnRemoveLand_5.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dLandArea_5.Visible = False
            lblLandSQM_5.Visible = False
            dLandPrice_5.Visible = False
            lblLandCons_5.Visible = False
            lblLandPhp_5.Visible = False
            dLandTotal_5.Visible = False
            txtLandRemarks_5.Visible = False
            btnRemoveLand_5.Visible = False

            dLandArea_5.Value = 0
            dLandPrice_5.Value = 0
            dLandTotal_5.Value = 0
            txtLandRemarks_5.Text = ""

            btnAddLand_4.Visible = True
            btnRemoveLand_4.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnAddImprovement_1_Click(sender As Object, e As EventArgs) Handles btnAddImprovement_1.Click
        PanelEx1.AutoScroll = False
        btnAddImprovement_1.Visible = False

        dImprovementArea_2.Visible = True
        lblImprovementSQM_2.Visible = True
        dImprovementPrice_2.Visible = True
        lblImprovementCons_2.Visible = True
        lblImprovementPhp_2.Visible = True
        dImprovementTotal_2.Visible = True
        txtImprovementRemarks_2.Visible = True
        btnAddImprovement_2.Visible = True
        btnRemoveImprovement_2.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddImprovement_2_Click(sender As Object, e As EventArgs) Handles btnAddImprovement_2.Click
        PanelEx1.AutoScroll = False
        btnAddImprovement_2.Visible = False
        btnRemoveImprovement_2.Visible = False

        dImprovementArea_3.Visible = True
        lblImprovementSQM_3.Visible = True
        dImprovementPrice_3.Visible = True
        lblImprovementCons_3.Visible = True
        lblImprovementPhp_3.Visible = True
        dImprovementTotal_3.Visible = True
        txtImprovementRemarks_3.Visible = True
        btnAddImprovement_3.Visible = True
        btnRemoveImprovement_3.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddImprovement_3_Click(sender As Object, e As EventArgs) Handles btnAddImprovement_3.Click
        PanelEx1.AutoScroll = False
        btnAddImprovement_3.Visible = False
        btnRemoveImprovement_3.Visible = False

        dImprovementArea_4.Visible = True
        lblImprovementSQM_4.Visible = True
        dImprovementPrice_4.Visible = True
        lblImprovementCons_4.Visible = True
        lblImprovementPhp_4.Visible = True
        dImprovementTotal_4.Visible = True
        txtImprovementRemarks_4.Visible = True
        btnAddImprovement_4.Visible = True
        btnRemoveImprovement_4.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddImprovement_4_Click(sender As Object, e As EventArgs) Handles btnAddImprovement_4.Click
        PanelEx1.AutoScroll = False
        btnAddImprovement_4.Visible = False
        btnRemoveImprovement_4.Visible = False

        dImprovementArea_5.Visible = True
        lblImprovementSQM_5.Visible = True
        dImprovementPrice_5.Visible = True
        lblImprovementCons_5.Visible = True
        lblImprovementPhp_5.Visible = True
        dImprovementTotal_5.Visible = True
        txtImprovementRemarks_5.Visible = True
        btnRemoveImprovement_5.Visible = True

        Positioning()
    End Sub

    Private Sub BtnRemoveImprovement_2_Click(sender As Object, e As EventArgs) Handles btnRemoveImprovement_2.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dImprovementArea_2.Visible = False
            lblImprovementSQM_2.Visible = False
            dImprovementPrice_2.Visible = False
            lblImprovementCons_2.Visible = False
            lblImprovementPhp_2.Visible = False
            dImprovementTotal_2.Visible = False
            txtImprovementRemarks_2.Visible = False
            btnAddImprovement_2.Visible = False
            btnRemoveImprovement_2.Visible = False

            dImprovementArea_2.Value = 0
            dImprovementPrice_2.Value = 0
            dImprovementTotal_2.Value = 0
            txtImprovementRemarks_2.Text = ""

            btnAddImprovement_1.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveImprovement_3_Click(sender As Object, e As EventArgs) Handles btnRemoveImprovement_3.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dImprovementArea_3.Visible = False
            lblImprovementSQM_3.Visible = False
            dImprovementPrice_3.Visible = False
            lblImprovementCons_3.Visible = False
            lblImprovementPhp_3.Visible = False
            dImprovementTotal_3.Visible = False
            txtImprovementRemarks_3.Visible = False
            btnAddImprovement_3.Visible = False
            btnRemoveImprovement_3.Visible = False

            dImprovementArea_3.Value = 0
            dImprovementPrice_3.Value = 0
            dImprovementTotal_3.Value = 0
            txtImprovementRemarks_3.Text = ""

            btnAddImprovement_2.Visible = True
            btnRemoveImprovement_2.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveImprovement_4_Click(sender As Object, e As EventArgs) Handles btnRemoveImprovement_4.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dImprovementArea_4.Visible = False
            lblImprovementSQM_4.Visible = False
            dImprovementPrice_4.Visible = False
            lblImprovementCons_4.Visible = False
            lblImprovementPhp_4.Visible = False
            dImprovementTotal_4.Visible = False
            txtImprovementRemarks_4.Visible = False
            btnAddImprovement_4.Visible = False
            btnRemoveImprovement_4.Visible = False

            dImprovementArea_4.Value = 0
            dImprovementPrice_4.Value = 0
            dImprovementTotal_4.Value = 0
            txtImprovementRemarks_4.Text = ""

            btnAddImprovement_3.Visible = True
            btnRemoveImprovement_3.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveImprovement_5_Click(sender As Object, e As EventArgs) Handles btnRemoveImprovement_5.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dImprovementArea_5.Visible = False
            lblImprovementSQM_5.Visible = False
            dImprovementPrice_5.Visible = False
            lblImprovementCons_5.Visible = False
            lblImprovementPhp_5.Visible = False
            dImprovementTotal_5.Visible = False
            txtImprovementRemarks_5.Visible = False
            btnRemoveImprovement_5.Visible = False

            dImprovementArea_5.Value = 0
            dImprovementPrice_5.Value = 0
            dImprovementTotal_5.Value = 0
            txtImprovementRemarks_5.Text = ""

            btnAddImprovement_4.Visible = True
            btnRemoveImprovement_4.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnAddMachine_1_Click(sender As Object, e As EventArgs) Handles btnAddMachine_1.Click
        PanelEx1.AutoScroll = False
        btnAddMachine_1.Visible = False

        dMachineArea_2.Visible = True
        lblMachineSQM_2.Visible = True
        dMachinePrice_2.Visible = True
        lblMachineCons_2.Visible = True
        lblMachinePhp_2.Visible = True
        dMachineTotal_2.Visible = True
        txtMachineRemarks_2.Visible = True
        btnAddMachine_2.Visible = True
        btnRemoveMachine_2.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddMachine_2_Click(sender As Object, e As EventArgs) Handles btnAddMachine_2.Click
        PanelEx1.AutoScroll = False
        btnAddMachine_2.Visible = False
        btnRemoveMachine_2.Visible = False

        dMachineArea_3.Visible = True
        lblMachineSQM_3.Visible = True
        dMachinePrice_3.Visible = True
        lblMachineCons_3.Visible = True
        lblMachinePhp_3.Visible = True
        dMachineTotal_3.Visible = True
        txtMachineRemarks_3.Visible = True
        btnAddMachine_3.Visible = True
        btnRemoveMachine_3.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddMachine_3_Click(sender As Object, e As EventArgs) Handles btnAddMachine_3.Click
        PanelEx1.AutoScroll = False
        btnAddMachine_3.Visible = False
        btnRemoveMachine_3.Visible = False

        dMachineArea_4.Visible = True
        lblMachineSQM_4.Visible = True
        dMachinePrice_4.Visible = True
        lblMachineCons_4.Visible = True
        lblMachinePhp_4.Visible = True
        dMachineTotal_4.Visible = True
        txtMachineRemarks_4.Visible = True
        btnAddMachine_4.Visible = True
        btnRemoveMachine_4.Visible = True

        Positioning()
    End Sub

    Private Sub BtnAddMachine_4_Click(sender As Object, e As EventArgs) Handles btnAddMachine_4.Click
        PanelEx1.AutoScroll = False
        btnAddMachine_4.Visible = False
        btnRemoveMachine_4.Visible = False

        dMachineArea_5.Visible = True
        lblMachineSQM_5.Visible = True
        dMachinePrice_5.Visible = True
        lblMachineCons_5.Visible = True
        lblMachinePhp_5.Visible = True
        dMachineTotal_5.Visible = True
        txtMachineRemarks_5.Visible = True
        btnRemoveMachine_5.Visible = True

        Positioning()
    End Sub

    Private Sub BtnRemoveMachine_2_Click(sender As Object, e As EventArgs) Handles btnRemoveMachine_2.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dMachineArea_2.Visible = False
            lblMachineSQM_2.Visible = False
            dMachinePrice_2.Visible = False
            lblMachineCons_2.Visible = False
            lblMachinePhp_2.Visible = False
            dMachineTotal_2.Visible = False
            txtMachineRemarks_2.Visible = False
            btnAddMachine_2.Visible = False
            btnRemoveMachine_2.Visible = False

            dMachineArea_2.Value = 0
            dMachinePrice_2.Value = 0
            dMachineTotal_2.Value = 0
            txtMachineRemarks_2.Text = ""

            btnAddMachine_1.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveMachine_3_Click(sender As Object, e As EventArgs) Handles btnRemoveMachine_3.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dMachineArea_3.Visible = False
            lblMachineSQM_3.Visible = False
            dMachinePrice_3.Visible = False
            lblMachineCons_3.Visible = False
            lblMachinePhp_3.Visible = False
            dMachineTotal_3.Visible = False
            txtMachineRemarks_3.Visible = False
            btnAddMachine_3.Visible = False
            btnRemoveMachine_3.Visible = False

            dMachineArea_3.Value = 0
            dMachinePrice_3.Value = 0
            dMachineTotal_3.Value = 0
            txtMachineRemarks_3.Text = ""

            btnAddMachine_2.Visible = True
            btnRemoveMachine_2.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveMachine_4_Click(sender As Object, e As EventArgs) Handles btnRemoveMachine_4.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dMachineArea_4.Visible = False
            lblMachineSQM_4.Visible = False
            dMachinePrice_4.Visible = False
            lblMachineCons_4.Visible = False
            lblMachinePhp_4.Visible = False
            dMachineTotal_4.Visible = False
            txtMachineRemarks_4.Visible = False
            btnAddMachine_4.Visible = False
            btnRemoveMachine_4.Visible = False

            dMachineArea_4.Value = 0
            dMachinePrice_4.Value = 0
            dMachineTotal_4.Value = 0
            txtMachineRemarks_4.Text = ""

            btnAddMachine_3.Visible = True
            btnRemoveMachine_3.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnRemoveMachine_5_Click(sender As Object, e As EventArgs) Handles btnRemoveMachine_5.Click
        If MsgBox("Are you sure you want to delete this row?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.Yes Then
            PanelEx1.AutoScroll = False
            dMachineArea_5.Visible = False
            lblMachineSQM_5.Visible = False
            dMachinePrice_5.Visible = False
            lblMachineCons_5.Visible = False
            lblMachinePhp_5.Visible = False
            dMachineTotal_5.Visible = False
            txtMachineRemarks_5.Visible = False
            btnRemoveMachine_5.Visible = False

            dMachineArea_5.Value = 0
            dMachinePrice_5.Value = 0
            dMachineTotal_5.Value = 0
            txtMachineRemarks_5.Text = ""

            btnAddMachine_4.Visible = True
            btnRemoveMachine_4.Visible = True

            Positioning()
        End If
    End Sub

    Private Sub BtnROPA_Click(sender As Object, e As EventArgs) Handles btnROPA.Click
        Dim CollateralROPA As New FrmCollateralROPA
        With CollateralROPA
            .ROPA = "RE"
            .AssetNumber_1 = AssetNumber_1
            .AssetNumber_2 = AssetNumber_2
            .AssetNumber_3 = AssetNumber_3
            .AssetNumber_4 = AssetNumber_4
            .AssetNumber_5 = AssetNumber_5
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String = "SELECT"
                SQL &= "   IFNULL(Land,'') AS 'Land',"
                SQL &= "   IFNULL(land_area,0) AS 'Land Area',"
                SQL &= "   IFNULL(land_price,0) AS 'Land Price',"
                SQL &= "   IFNULL(land_price * land_area,0) AS 'Land Total',"
                SQL &= "   IFNULL(land_remarks_1,'') AS 'Land Remarks',"
                SQL &= "   IFNULL(land_area_2,0) AS 'Land Area 2',"
                SQL &= "   IFNULL(land_price_2,0) AS 'Land Price 2',"
                SQL &= "   IFNULL(land_price_2 * land_area_2,0) AS 'Land Total 2',"
                SQL &= "   IFNULL(land_remarks_2,'') AS 'Land Remarks 2',"
                SQL &= "   IFNULL(land_area_3,0) AS 'Land Area 3',"
                SQL &= "   IFNULL(land_price_3,0) AS 'Land Price 3',"
                SQL &= "   IFNULL(land_price_3 * land_area_3,0) AS 'Land Total 3',"
                SQL &= "   IFNULL(land_remarks_3,'') AS 'Land Remarks 3',"
                SQL &= "   IFNULL(land_area_4,0) AS 'Land Area 4',"
                SQL &= "   IFNULL(land_price_4,0) AS 'Land Price 4',"
                SQL &= "   IFNULL(land_price_4 * land_area_4,0) AS 'Land Total 4',"
                SQL &= "   IFNULL(land_remarks_4,'') AS 'Land Remarks 4',"
                SQL &= "   IFNULL(land_area_5,0) AS 'Land Area 5',"
                SQL &= "   IFNULL(land_price_5,0) AS 'Land Price 5',"
                SQL &= "   IFNULL(land_price_5 * land_area_5,0) AS 'Land Total 5',"
                SQL &= "   IFNULL(land_remarks_5,'') AS 'Land Remarks 5',"
                SQL &= "   IFNULL(Machine,'') AS 'Machine',"
                SQL &= "   IFNULL(Machine_area,0) AS 'Machine Area',"
                SQL &= "   IFNULL(Machine_price,0) AS 'Machine Price',"
                SQL &= "   IFNULL(Machine_price * Machine_area,0) AS 'Machine Total',"
                SQL &= "   IFNULL(Machine_remarks_1,'') AS 'Machine Remarks',"
                SQL &= "   IFNULL(Machine_area_2,0) AS 'Machine Area 2',"
                SQL &= "   IFNULL(Machine_price_2,0) AS 'Machine Price 2',"
                SQL &= "   IFNULL(Machine_price_2 * Machine_area_2,0) AS 'Machine Total 2',"
                SQL &= "   IFNULL(Machine_remarks_2,'') AS 'Machine Remarks 2',"
                SQL &= "   IFNULL(Machine_area_3,0) AS 'Machine Area 3',"
                SQL &= "   IFNULL(Machine_price_3,0) AS 'Machine Price 3',"
                SQL &= "   IFNULL(Machine_price_3 * Machine_area_3,0) AS 'Machine Total 3',"
                SQL &= "   IFNULL(Machine_remarks_3,'') AS 'Machine Remarks 3',"
                SQL &= "   IFNULL(Machine_area_4,0) AS 'Machine Area 4',"
                SQL &= "   IFNULL(Machine_price_4,0) AS 'Machine Price 4',"
                SQL &= "   IFNULL(Machine_price_4 * Machine_area_4,0) AS 'Machine Total 4',"
                SQL &= "   IFNULL(Machine_remarks_4,'') AS 'Machine Remarks 4',"
                SQL &= "   IFNULL(Machine_area_5,0) AS 'Machine Area 5',"
                SQL &= "   IFNULL(Machine_price_5,0) AS 'Machine Price 5',"
                SQL &= "   IFNULL(Machine_price_5 * Machine_area_5,0) AS 'Machine Total 5',"
                SQL &= "   IFNULL(Machine_remarks_5,'') AS 'Machine Remarks 5',"
                SQL &= "   IFNULL(Improvement,'') AS 'Improvement',"
                SQL &= "   IFNULL(Improvement_area,0) AS 'Improvement Area',"
                SQL &= "   IFNULL(Improvement_price,0) AS 'Improvement Price',"
                SQL &= "   IFNULL(Improvement_price * Improvement_area,0) AS 'Improvement Total',"
                SQL &= "   IFNULL(Improvement_remarks_1,'') AS 'Improvement Remarks',"
                SQL &= "   IFNULL(Improvement_area_2,0) AS 'Improvement Area 2',"
                SQL &= "   IFNULL(Improvement_price_2,0) AS 'Improvement Price 2',"
                SQL &= "   IFNULL(Improvement_price_2 * Improvement_area_2,0) AS 'Improvement Total 2',"
                SQL &= "   IFNULL(Improvement_remarks_2,'') AS 'Improvement Remarks 2',"
                SQL &= "   IFNULL(Improvement_area_3,0) AS 'Improvement Area 3',"
                SQL &= "   IFNULL(Improvement_price_3,0) AS 'Improvement Price 3',"
                SQL &= "   IFNULL(Improvement_price_3 * Improvement_area_3,0) AS 'Improvement Total 3',"
                SQL &= "   IFNULL(Improvement_remarks_3,'') AS 'Improvement Remarks 3',"
                SQL &= "   IFNULL(Improvement_area_4,0) AS 'Improvement Area 4',"
                SQL &= "   IFNULL(Improvement_price_4,0) AS 'Improvement Price 4',"
                SQL &= "   IFNULL(Improvement_price_4 * Improvement_area_4,0) AS 'Improvement Total 4',"
                SQL &= "   IFNULL(Improvement_remarks_4,'') AS 'Improvement Remarks 4',"
                SQL &= "   IFNULL(Improvement_area_5,0) AS 'Improvement Area 5',"
                SQL &= "   IFNULL(Improvement_price_5,0) AS 'Improvement Price 5',"
                SQL &= "   IFNULL(Improvement_price_5 * Improvement_area_5,0) AS 'Improvement Total 5',"
                SQL &= "   IFNULL(Improvement_remarks_5,'') AS 'Improvement Remarks 5',"
                SQL &= "   IFNULL((land_price * land_area) + (land_price_2 * land_area_2) + (land_price_3 * land_area_3) + (land_price_4 * land_area_4) + (land_price_5 * land_area_5) + (machine_price * machine_area) + (machine_price_2 * machine_area_2) + (machine_price_3 * machine_area_3) + (machine_price_4 * machine_area_4) + (machine_price_5 * machine_area_5) + (improvement_price * improvement_area) + (improvement_price_2 * improvement_area_2) + (improvement_price_3 * improvement_area_3) + (improvement_price_4 * improvement_area_4) + (improvement_price_5 * improvement_area_5),0) AS 'Total',"
                SQL &= "   IFNULL(prevailing_selling,0) AS 'Prevailing Selling Price',"
                SQL &= "   IFNULL(rounded_to,0) AS 'Zonal Valuation',"
                SQL &= "   R.TCT               AS 'TCT No.',"
                SQL &= "   IFNULL(lot_block,'')         AS 'Lot / Block No.',"
                SQL &= "   R.Area AS 'Area SQ.M.',"
                SQL &= "   IFNULL(registered_owner,'')  AS 'Registered Owner',"
                SQL &= "   IFNULL(registry_deeds,'')    AS 'Registry of Deeds',"
                SQL &= "   R.Location,"
                SQL &= "   R.Coordinates,"
                SQL &= "   R.vacantlot        AS 'Vacant Lot',"
                SQL &= "   R.Classification,"
                SQL &= "   R.Storey          AS 'Storey',"
                SQL &= "   R.Roofings         AS 'Roofing',"
                SQL &= "   R.FLooring        AS 'Flooring',"
                SQL &= "   R.TandB           AS 'T and B',"
                SQL &= "   R.Frame           AS 'Frame',"
                SQL &= "   R.Beams           AS 'Beams',"
                SQL &= "   R.Doors           AS 'Door',"
                SQL &= "   R.YearConstructed AS 'Year Constructed',"
                SQL &= "   R.Walling         AS 'Walling',"
                SQL &= "   R.Ceiling         AS 'Ceiling',"
                SQL &= "   R.Windows         AS 'Windows',"
                SQL &= "   R.FloorArea       AS 'Floor Area',"
                SQL &= "   R.Partitions      AS 'Partitions',"
                SQL &= "   R.Remarks           AS 'Remarks',"
                SQL &= "   IFNULL(market_value,0) AS 'Market Value',"
                SQL &= "   IFNULL(appraised_value,0) AS 'Appraised Value',"
                SQL &= "   IFNULL(as_of,'')             AS 'As of',"
                SQL &= "   IFNULL(loanable_value,0) AS 'Loanable Value',"
                SQL &= "   IFNULL(loanable_percent,0) AS 'Loanable Percent', R.Attach"
                SQL &= " FROM ropoa_realestate R LEFT JOIN appraise_re A ON R.AssetNumber = A.Asset_Number"
                SQL &= String.Format("   WHERE R.AssetNumber= '{0}' ORDER BY A.appraise_date DESC LIMIT 1", .GridView1.GetFocusedRowCellValue("Asset Number"))

                Dim DT As DataTable = DataSource(SQL)
                If DT.Rows.Count > 0 Then
                    SellingPrice = .GridView1.GetFocusedRowCellValue("Price")
                    AssetNumber = .GridView1.GetFocusedRowCellValue("Asset Number")
                    txtLand.Text = DT(0)("Land")
                    txtLand.Tag = DT(0)("Land")

                    dLandArea.Value = DT(0)("Land Area")
                    dLandArea.Tag = DT(0)("Land Area")
                    dLandPrice_1.Value = DT(0)("Land Price")
                    dLandPrice_1.Tag = DT(0)("Land Price")
                    dLandTotal_1.Value = DT(0)("Land Total")
                    dLandTotal_1.Tag = DT(0)("Land Total")
                    txtLandRemarks_1.Text = DT(0)("Land Remarks")
                    txtLandRemarks_1.Tag = DT(0)("Land Remarks")

                    If CDbl(DT(0)("Land Total 2")) > 0 Then
                        dLandArea_2.Visible = True
                        lblLandSQM_2.Visible = True
                        dLandPrice_2.Visible = True
                        lblLandCons_2.Visible = True
                        lblLandPhp_2.Visible = True
                        dLandTotal_2.Visible = True
                        txtLandRemarks_2.Visible = True
                        btnAddLand_2.Visible = True
                        btnRemoveLand_2.Visible = True
                    End If
                    dLandArea_2.Value = DT(0)("Land Area 2")
                    dLandArea_2.Tag = DT(0)("Land Area 2")
                    dLandPrice_2.Value = DT(0)("Land Price 2")
                    dLandPrice_2.Tag = DT(0)("Land Price 2")
                    dLandTotal_2.Value = DT(0)("Land Total 2")
                    dLandTotal_2.Tag = DT(0)("Land Total 2")
                    txtLandRemarks_2.Text = DT(0)("Land Remarks 2")
                    txtLandRemarks_2.Tag = DT(0)("Land Remarks 2")

                    If CDbl(DT(0)("Land Total 3")) > 0 Then
                        dLandArea_3.Visible = True
                        lblLandSQM_3.Visible = True
                        dLandPrice_3.Visible = True
                        lblLandCons_3.Visible = True
                        lblLandPhp_3.Visible = True
                        dLandTotal_3.Visible = True
                        txtLandRemarks_3.Visible = True
                        btnAddLand_3.Visible = True
                        btnRemoveLand_3.Visible = True
                    End If
                    dLandArea_3.Value = DT(0)("Land Area 3")
                    dLandArea_3.Tag = DT(0)("Land Area 3")
                    dLandPrice_3.Value = DT(0)("Land Price 3")
                    dLandPrice_3.Tag = DT(0)("Land Price 3")
                    dLandTotal_3.Value = DT(0)("Land Total 3")
                    dLandTotal_3.Tag = DT(0)("Land Total 3")
                    txtLandRemarks_3.Text = DT(0)("Land Remarks 3")
                    txtLandRemarks_3.Tag = DT(0)("Land Remarks 3")

                    If CDbl(DT(0)("Land Total 4")) > 0 Then
                        dLandArea_4.Visible = True
                        lblLandSQM_4.Visible = True
                        dLandPrice_4.Visible = True
                        lblLandCons_4.Visible = True
                        lblLandPhp_4.Visible = True
                        dLandTotal_4.Visible = True
                        txtLandRemarks_4.Visible = True
                        btnAddLand_4.Visible = True
                        btnRemoveLand_4.Visible = True
                    End If
                    dLandArea_4.Value = DT(0)("Land Area 4")
                    dLandArea_4.Tag = DT(0)("Land Area 4")
                    dLandPrice_4.Value = DT(0)("Land Price 4")
                    dLandPrice_4.Tag = DT(0)("Land Price 4")
                    dLandTotal_4.Value = DT(0)("Land Total 4")
                    dLandTotal_4.Tag = DT(0)("Land Total 4")
                    txtLandRemarks_4.Text = DT(0)("Land Remarks 4")
                    txtLandRemarks_4.Tag = DT(0)("Land Remarks 4")

                    If CDbl(DT(0)("Land Total 5")) > 0 Then
                        dLandArea_5.Visible = True
                        lblLandSQM_5.Visible = True
                        dLandPrice_5.Visible = True
                        lblLandCons_5.Visible = True
                        lblLandPhp_5.Visible = True
                        dLandTotal_5.Visible = True
                        txtLandRemarks_5.Visible = True
                        btnRemoveLand_5.Visible = True
                    End If
                    dLandArea_5.Value = DT(0)("Land Area 5")
                    dLandArea_5.Tag = DT(0)("Land Area 5")
                    dLandPrice_5.Value = DT(0)("Land Price 5")
                    dLandPrice_5.Tag = DT(0)("Land Price 5")
                    dLandTotal_5.Value = DT(0)("Land Total 5")
                    dLandTotal_5.Tag = DT(0)("Land Total 5")
                    txtLandRemarks_5.Text = DT(0)("Land Remarks 5")
                    txtLandRemarks_5.Tag = DT(0)("Land Remarks 5")

                    txtMachine.Text = DT(0)("Machine")
                    txtMachine.Tag = DT(0)("Machine")

                    dMachineArea_1.Value = DT(0)("Machine Area")
                    dMachineArea_1.Tag = DT(0)("Machine Area")
                    dMachinePrice_1.Value = DT(0)("Machine Price")
                    dMachinePrice_1.Tag = DT(0)("Machine Price")
                    dMachineTotal_1.Value = DT(0)("Machine Total")
                    dMachineTotal_1.Tag = DT(0)("Machine Total")
                    txtMachineRemarks_1.Text = DT(0)("Machine Remarks")
                    txtMachineRemarks_1.Tag = DT(0)("Machine Remarks")

                    If CDbl(DT(0)("Machine Total 2")) > 0 Then
                        dMachineArea_2.Visible = True
                        lblMachineSQM_2.Visible = True
                        dMachinePrice_2.Visible = True
                        lblMachineCons_2.Visible = True
                        lblMachinePhp_2.Visible = True
                        dMachineTotal_2.Visible = True
                        txtMachineRemarks_2.Visible = True
                        btnAddMachine_2.Visible = True
                        btnRemoveMachine_2.Visible = True
                    End If
                    dMachineArea_2.Value = DT(0)("Machine Area 2")
                    dMachineArea_2.Tag = DT(0)("Machine Area 2")
                    dMachinePrice_2.Value = DT(0)("Machine Price 2")
                    dMachinePrice_2.Tag = DT(0)("Machine Price 2")
                    dMachineTotal_2.Value = DT(0)("Machine Total 2")
                    dMachineTotal_2.Tag = DT(0)("Machine Total 2")
                    txtMachineRemarks_2.Text = DT(0)("Machine Remarks 2")
                    txtMachineRemarks_2.Tag = DT(0)("Machine Remarks 2")

                    If CDbl(DT(0)("Machine Total 3")) > 0 Then
                        dMachineArea_3.Visible = True
                        lblMachineSQM_3.Visible = True
                        dMachinePrice_3.Visible = True
                        lblMachineCons_3.Visible = True
                        lblMachinePhp_3.Visible = True
                        dMachineTotal_3.Visible = True
                        txtMachineRemarks_3.Visible = True
                        btnAddMachine_3.Visible = True
                        btnRemoveMachine_3.Visible = True
                    End If
                    dMachineArea_3.Value = DT(0)("Machine Area 3")
                    dMachineArea_3.Tag = DT(0)("Machine Area 3")
                    dMachinePrice_3.Value = DT(0)("Machine Price 3")
                    dMachinePrice_3.Tag = DT(0)("Machine Price 3")
                    dMachineTotal_3.Value = DT(0)("Machine Total 3")
                    dMachineTotal_3.Tag = DT(0)("Machine Total 3")
                    txtMachineRemarks_3.Text = DT(0)("Machine Remarks 3")
                    txtMachineRemarks_3.Tag = DT(0)("Machine Remarks 3")

                    If CDbl(DT(0)("Machine Total 4")) > 0 Then
                        dMachineArea_4.Visible = True
                        lblMachineSQM_4.Visible = True
                        dMachinePrice_4.Visible = True
                        lblMachineCons_4.Visible = True
                        lblMachinePhp_4.Visible = True
                        dMachineTotal_4.Visible = True
                        txtMachineRemarks_4.Visible = True
                        btnAddMachine_4.Visible = True
                        btnRemoveMachine_4.Visible = True
                    End If
                    dMachineArea_4.Value = DT(0)("Machine Area 4")
                    dMachineArea_4.Tag = DT(0)("Machine Area 4")
                    dMachinePrice_4.Value = DT(0)("Machine Price 4")
                    dMachinePrice_4.Tag = DT(0)("Machine Price 4")
                    dMachineTotal_4.Value = DT(0)("Machine Total 4")
                    dMachineTotal_4.Tag = DT(0)("Machine Total 4")
                    txtMachineRemarks_4.Text = DT(0)("Machine Remarks 4")
                    txtMachineRemarks_4.Tag = DT(0)("Machine Remarks 4")

                    If CDbl(DT(0)("Machine Total 5")) > 0 Then
                        dMachineArea_5.Visible = True
                        lblMachineSQM_5.Visible = True
                        dMachinePrice_5.Visible = True
                        lblMachineCons_5.Visible = True
                        lblMachinePhp_5.Visible = True
                        dMachineTotal_5.Visible = True
                        txtMachineRemarks_5.Visible = True
                        btnRemoveMachine_5.Visible = True
                    End If
                    dMachineArea_5.Value = DT(0)("Machine Area 5")
                    dMachineArea_5.Tag = DT(0)("Machine Area 5")
                    dMachinePrice_5.Value = DT(0)("Machine Price 5")
                    dMachinePrice_5.Tag = DT(0)("Machine Price 5")
                    dMachineTotal_5.Value = DT(0)("Machine Total 5")
                    dMachineTotal_5.Tag = DT(0)("Machine Total 5")
                    txtMachineRemarks_5.Text = DT(0)("Machine Remarks 5")
                    txtMachineRemarks_5.Tag = DT(0)("Machine Remarks 5")

                    txtImprovements.Text = DT(0)("Improvement")
                    txtImprovements.Tag = DT(0)("Improvement")

                    dImprovementArea_1.Value = DT(0)("Improvement Area")
                    dImprovementArea_1.Tag = DT(0)("Improvement Area")
                    dImprovementPrice_1.Value = DT(0)("Improvement Price")
                    dImprovementPrice_1.Tag = DT(0)("Improvement Price")
                    dImprovementTotal_1.Value = DT(0)("Improvement Total")
                    dImprovementTotal_1.Tag = DT(0)("Improvement Total")
                    txtImprovementRemarks_1.Text = DT(0)("Improvement Remarks")
                    txtImprovementRemarks_1.Tag = DT(0)("Improvement Remarks")

                    If CDbl(DT(0)("Improvement Total 2")) > 0 Then
                        dImprovementArea_2.Visible = True
                        lblImprovementSQM_2.Visible = True
                        dImprovementPrice_2.Visible = True
                        lblImprovementCons_2.Visible = True
                        lblImprovementPhp_2.Visible = True
                        dImprovementTotal_2.Visible = True
                        txtImprovementRemarks_2.Visible = True
                        btnAddImprovement_2.Visible = True
                        btnRemoveImprovement_2.Visible = True
                    End If
                    dImprovementArea_2.Value = DT(0)("Improvement Area 2")
                    dImprovementArea_2.Tag = DT(0)("Improvement Area 2")
                    dImprovementPrice_2.Value = DT(0)("Improvement Price 2")
                    dImprovementPrice_2.Tag = DT(0)("Improvement Price 2")
                    dImprovementTotal_2.Value = DT(0)("Improvement Total 2")
                    dImprovementTotal_2.Tag = DT(0)("Improvement Total 2")
                    txtImprovementRemarks_2.Text = DT(0)("Improvement Remarks 2")
                    txtImprovementRemarks_2.Tag = DT(0)("Improvement Remarks 2")

                    If CDbl(DT(0)("Improvement Total 3")) > 0 Then
                        dImprovementArea_3.Visible = True
                        lblImprovementSQM_3.Visible = True
                        dImprovementPrice_3.Visible = True
                        lblImprovementCons_3.Visible = True
                        lblImprovementPhp_3.Visible = True
                        dImprovementTotal_3.Visible = True
                        txtImprovementRemarks_3.Visible = True
                        btnAddImprovement_3.Visible = True
                        btnRemoveImprovement_3.Visible = True
                    End If
                    dImprovementArea_3.Value = DT(0)("Improvement Area 3")
                    dImprovementArea_3.Tag = DT(0)("Improvement Area 3")
                    dImprovementPrice_3.Value = DT(0)("Improvement Price 3")
                    dImprovementPrice_3.Tag = DT(0)("Improvement Price 3")
                    dImprovementTotal_3.Value = DT(0)("Improvement Total 3")
                    dImprovementTotal_3.Tag = DT(0)("Improvement Total 3")
                    txtImprovementRemarks_3.Text = DT(0)("Improvement Remarks 3")
                    txtImprovementRemarks_3.Tag = DT(0)("Improvement Remarks 3")

                    If CDbl(DT(0)("Improvement Total 4")) > 0 Then
                        dImprovementArea_4.Visible = True
                        lblImprovementSQM_4.Visible = True
                        dImprovementPrice_4.Visible = True
                        lblImprovementCons_4.Visible = True
                        lblImprovementPhp_4.Visible = True
                        dImprovementTotal_4.Visible = True
                        txtImprovementRemarks_4.Visible = True
                        btnAddImprovement_4.Visible = True
                        btnRemoveImprovement_4.Visible = True
                    End If
                    dImprovementArea_4.Value = DT(0)("Improvement Area 4")
                    dImprovementArea_4.Tag = DT(0)("Improvement Area 4")
                    dImprovementPrice_4.Value = DT(0)("Improvement Price 4")
                    dImprovementPrice_4.Tag = DT(0)("Improvement Price 4")
                    dImprovementTotal_4.Value = DT(0)("Improvement Total 4")
                    dImprovementTotal_4.Tag = DT(0)("Improvement Total 4")
                    txtImprovementRemarks_4.Text = DT(0)("Improvement Remarks 4")
                    txtImprovementRemarks_4.Tag = DT(0)("Improvement Remarks 4")

                    If CDbl(DT(0)("Improvement Total 5")) > 0 Then
                        dImprovementArea_5.Visible = True
                        lblImprovementSQM_5.Visible = True
                        dImprovementPrice_5.Visible = True
                        lblImprovementCons_5.Visible = True
                        lblImprovementPhp_5.Visible = True
                        dImprovementTotal_5.Visible = True
                        txtImprovementRemarks_5.Visible = True
                        btnRemoveImprovement_5.Visible = True
                    End If
                    dImprovementArea_5.Value = DT(0)("Improvement Area 5")
                    dImprovementArea_5.Tag = DT(0)("Improvement Area 5")
                    dImprovementPrice_5.Value = DT(0)("Improvement Price 5")
                    dImprovementPrice_5.Tag = DT(0)("Improvement Price 5")
                    dImprovementTotal_5.Value = DT(0)("Improvement Total 5")
                    dImprovementTotal_5.Tag = DT(0)("Improvement Total 5")
                    txtImprovementRemarks_5.Text = DT(0)("Improvement Remarks 5")
                    txtImprovementRemarks_5.Tag = DT(0)("Improvement Remarks 5")

                    dTotalAmount.Value = DT(0)("Total")
                    dTotalAmount.Tag = DT(0)("Total")
                    dPrevailingSellingPrice.Value = DT(0)("Prevailing Selling Price")
                    dPrevailingSellingPrice.Tag = DT(0)("Prevailing Selling Price")
                    dZonalValuation.Value = DT(0)("Zonal Valuation")
                    dZonalValuation.Tag = DT(0)("Zonal Valuation")
                    txtTCT.Text = DT(0)("TCT No.")
                    txtTCT.Tag = DT(0)("TCT No.")
                    txtLot.Text = DT(0)("Lot / Block No.")
                    txtLot.Tag = DT(0)("Lot / Block No.")
                    dArea.Value = DT(0)("Area SQ.M.")
                    dArea.Tag = DT(0)("Area SQ.M.")
                    txtRegisteredOwner.Text = DT(0)("Registered Owner")
                    txtRegisteredOwner.Tag = DT(0)("Registered Owner")
                    txtRegistryOfDeeds.Text = DT(0)("Registry of Deeds")
                    txtRegistryOfDeeds.Tag = DT(0)("Registry of Deeds")
                    rLocation.Text = DT(0)("Location")
                    rLocation.Tag = DT(0)("Location")
                    txtCoordinates.Text = DT(0)("Coordinates")
                    txtCoordinates.Tag = DT(0)("Coordinates")
                    cbxVacant.Checked = If(DT(0)("Vacant Lot") = "YES", True, False)
                    cbxVacant.Tag = If(DT(0)("Vacant Lot") = "YES", True, False)
                    If DT(0)("Classification") = "Residential" Then
                        cbxResidential.Checked = True
                    ElseIf DT(0)("Classification") = "Commercial" Then
                        cbxCommercial.Checked = True
                    ElseIf DT(0)("Classification") = "Agricultural" Then
                        cbxAgricultural.Checked = True
                    ElseIf DT(0)("Classification") = "Tourism" Then
                        cbxTourism.Checked = True
                    ElseIf DT(0)("Classification") = "Industrial" Then
                        cbxIndustrial.Checked = True
                    ElseIf DT(0)("Classification") = "Condominium" Then
                        cbxCondominium.Checked = True
                    Else
                        cbxOthers.Checked = True
                        txtOthers.Text = DT(0)("Classification")
                    End If
                    cbxResidential.Tag = DT(0)("Classification")
                    cbxCommercial.Tag = DT(0)("Classification")
                    cbxAgricultural.Tag = DT(0)("Classification")
                    cbxTourism.Tag = DT(0)("Classification")
                    cbxIndustrial.Tag = DT(0)("Classification")
                    cbxCondominium.Tag = DT(0)("Classification")
                    cbxOthers.Tag = DT(0)("Classification")

                    txtStorey.Text = DT(0)("Storey")
                    txtStorey.Tag = DT(0)("Storey")
                    txtRoofings.Text = DT(0)("Roofing")
                    txtRoofings.Tag = DT(0)("Roofing")
                    txtFlooring.Text = DT(0)("Flooring")
                    txtFlooring.Tag = DT(0)("Flooring")
                    txtTandB.Text = DT(0)("T and B")
                    txtTandB.Tag = DT(0)("T and B")
                    txtFrame.Text = DT(0)("Frame")
                    txtFrame.Tag = DT(0)("Frame")
                    txtBeams.Text = DT(0)("Beams")
                    txtBeams.Tag = DT(0)("Beams")
                    txtDoors.Text = DT(0)("Door")
                    txtDoors.Tag = DT(0)("Door")
                    txtYearConstructed.Text = DT(0)("Year Constructed")
                    txtYearConstructed.Tag = DT(0)("Year Constructed")
                    txtWalling.Text = DT(0)("Walling")
                    txtWalling.Tag = DT(0)("Walling")
                    txtCeilings.Text = DT(0)("Ceiling")
                    txtCeilings.Tag = DT(0)("Ceiling")
                    txtWindows.Text = DT(0)("Windows")
                    txtWindows.Tag = DT(0)("Windows")
                    txtFloorArea.Text = DT(0)("Floor Area")
                    txtFloorArea.Tag = DT(0)("Floor Area")
                    txtPartitions.Text = DT(0)("Partitions")
                    txtPartitions.Tag = DT(0)("Partitions")
                    rRemarks.Text = DT(0)("Remarks")
                    rRemarks.Tag = DT(0)("Remarks")
                    dFairMarketValue.Value = DT(0)("Market Value")
                    dFairMarketValue.Tag = DT(0)("Market Value")
                    dAppraisedValue.Value = DT(0)("Appraised Value")
                    dAppraisedValue.Tag = DT(0)("Appraised Value")
                    If DT(0)("As of") = "" Then
                        dtpAsOf.CustomFormat = ""
                    Else
                        dtpAsOf.CustomFormat = "MMMM dd, yyyy"
                        dtpAsOf.Value = CDate(DT(0)("As of"))
                    End If
                    dtpAsOf.Tag = DT(0)("As of")
                End If
            End If
            .Dispose()
        End With
    End Sub
End Class