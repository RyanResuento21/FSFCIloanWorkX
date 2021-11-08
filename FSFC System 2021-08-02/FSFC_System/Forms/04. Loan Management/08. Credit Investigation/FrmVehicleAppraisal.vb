
Imports DevExpress.XtraReports.UI
Public Class FrmVehicleAppraisal

    Public BorrowerID As Integer
    Dim FirstLoad As Boolean = True
    ReadOnly TriggerSave As Boolean
    ReadOnly TriggerDelete As Boolean
    Public ChangeCollateral As Boolean
    Public vFuel As String
    Public vMileAge As String
    Public vMake As String
    Public vModel As String
    Public vAppraised As String
    Public vType As String
    Public AssetNumber As String
    Public CreditNumber As String
    Public CINumber As String
    Public CollateralNumber As String
    Public TotalImage As Integer
    Public TotalImage_II As Integer
    Public From_Vehicle As Boolean

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public For_ReApraise As Boolean
    Public AssetNumber_1 As String
    Public AssetNumber_2 As String
    Public AssetNumber_3 As String
    Public AssetNumber_4 As String
    Public AssetNumber_5 As String
    Public SellingPrice As Double
    Dim Exist As DataTable

    Private Sub FrmVehicleAppraisal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        If btnSave.Text = "&Save" Then
            dtpDate.Value = Date.Now
            dtpYear.Value = Date.Now
            dtpRegistered.Value = Date.Now
            GetAppraisal()
        End If

        With cbxFuel
            .DisplayMember = "Fuel"
            .DataSource = Fuel.Copy
            .SelectedIndex = -1
        End With

        With cbxMileAge
            .DisplayMember = "Mileage"
            .DataSource = MileAge.Copy
            .SelectedIndex = -1
        End With

        With cbxMake
            .ValueMember = "ID"
            .DisplayMember = "Make"
            .DataSource = Make.Copy
            .SelectedIndex = -1
        End With

        With cbxType
            .ValueMember = "ID"
            .DisplayMember = "Classification"
            .DataSource = CarClassification.Copy
            .SelectedIndex = -1
        End With

        With cbxModel
            .ValueMember = "ID"
            .DisplayMember = "Model"
            .DataSource = DataSource(String.Format("SELECT ID, Model FROM model_setup WHERE `status` = 'ACTIVE' GROUP BY Model ORDER BY Model;", cbxMake.SelectedValue))
            .SelectedIndex = -1
        End With

        With cbxAppraisedBy
            .ValueMember = "ID"
            .DisplayMember = "CI"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
            .SelectedValue = Empl_ID
        End With

        FirstLoad = False
        If btnSave.Text = "Update" Or From_Vehicle Or For_ReApraise Then
            cbxFuel.Text = vFuel
            cbxMileAge.Text = vMileAge
            cbxMake.Text = vMake
            cbxType.Text = vType
            cbxModel.Text = vModel
            cbxAppraisedBy.Text = vAppraised
        End If

        If CreditNumber = "" Then
            btnRequirements.Visible = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX68})

            GetLabelFontSettings({LabelX67, LabelX33, LabelX65, LabelX155, LabelX64, LabelX66, LabelX43, LabelX3, LabelX6, LabelX9, LabelX1, LabelX57, LabelX7, LabelX10, LabelX70, LabelX4, LabelX63, LabelX11, LabelX2, LabelX5, LabelX8, LabelX13, LabelX69, LabelX56, LabelX15, LabelX18, LabelX21, LabelX24, LabelX27, LabelX30, LabelX38, LabelX37, LabelX36, LabelX35, LabelX34, LabelX128, LabelX19, LabelX22, LabelX25, LabelX28, LabelX31, LabelX45, LabelX44, LabelX42, LabelX41, LabelX40, LabelX20, LabelX23, LabelX26, LabelX29, LabelX32, LabelX50, LabelX49, LabelX48, LabelX47, LabelX46, LabelX128, LabelX39, LabelX54, LabelX55, LabelX62, LabelX61, LabelX52, LabelX51, LabelX53})

            GetLabelFontSettingsDefault({LabelX59, LabelX58, LabelX60, LabelX14, LabelX16, LabelX17})

            GetTextBoxFontSettings({txtSeries, txtPlateNum, txtORNum, txtChassisNum, txtRegistryCert, txtAppraiseNumber, txtLTO, txtEngine, txtSteering, txtClutch, txtHeadLight, txtSignalLight, txtShock, txtUnderchassis, txtUpholstery, txtTempGauge, txtOdometer, txtTransmission, txtTires, txtAcceleration, txtParkLight, txtHorn, txtChassis, txtFrontBumper, txtAmpheres, txtFuel, txtStarter, txtDifferential, txtBrakes, txtWiper, txtBackUp, txtSideMirror, txtBodyFlooring, txtRearBumper, txtOilPressure, txtSpeedometer, txtBodyPaint, txtSource, txtTelephoneNum})

            GetCheckBoxFontSettings({cbxNA})

            GetCheckBoxFontSettingsDefault({cbxEngine_G, cbxSteering_G, cbxClutch_G, cbxHeadLight_G, cbxSignalLight_G, cbxShock_G, cbxUnderchassis_G, cbxUpholstery_G, cbxTempGauge_G, cbxOdometer_G, cbxTransmission_G, cbxAcceleration_G, cbxParkLight_G, cbxHorn_G, cbxChassis_G, cbxFrontBumper_G, cbxAmpheres_G, cbxFuel_G, cbxStarter_G, cbxDifferential_G, cbxBrakes_G, cbxWiper_G, cbxBackUp_G, cbxSideMirror_G, cbxBodyFlooring_G, cbxRearBumper_G, cbxOilPressure_G, cbxSpeedometer_G, cbxBodyPaint_G, cbxEngine_F, cbxSteering_F, cbxClutch_F, cbxHeadLight_F, cbxSignalLight_F, cbxShock_F, cbxUnderchassis_F, cbxUpholstery_F, cbxTempGauge_F, cbxOdometer_F, cbxTransmission_F, cbxAcceleration_F, cbxParkLight_F, cbxHorn_F, cbxChassis_F, cbxFrontBumper_F, cbxAmpheres_F, cbxFuel_F, cbxStarter_F, cbxDifferential_F, cbxBrakes_F, cbxWiper_F, cbxBackUp_F, cbxSideMirror_F, cbxBodyFlooring_F, cbxRearBumper_F, cbxOilPressure_F, cbxSpeedometer_F, cbxBodyPaint_F, cbxEngine_P, cbxSteering_P, cbxClutch_P, cbxHeadLight_P, cbxSignalLight_P, cbxShock_P, cbxUnderchassis_P, cbxUpholstery_P, cbxTempGauge_P, cbxOdometer_P, cbxTransmission_P, cbxAcceleration_P, cbxParkLight_P, cbxHorn_P, cbxChassis_P, cbxFrontBumper_P, cbxAmpheres_P, cbxFuel_P, cbxStarter_P, cbxDifferential_P, cbxBrakes_P, cbxWiper_P, cbxBackUp_P, cbxSideMirror_P, cbxBodyFlooring_P, cbxRearBumper_P, cbxOilPressure_P, cbxSpeedometer_P, cbxBodyPaint_P})

            GetComboBoxFontSettings({cbxAppraisedBy, cbxModel, cbxBodyColor, cbxEngineNumber})

            GetComboBoxWinFormFontSettings({cbxAppraiseFor, cbxMake, cbxType, cbxUsed, cbxTransmission, cbxFuel, cbxMileAge})

            GetDateTimeInputFontSettings({dtpDate, dtpYear, dtpRegistered})

            GetButtonFontSettings({btnHit, btnROPA, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAddImage, btnAttach, btnRequirements})

            GetDoubleInputFontSettings({dGrossWeight, dMileAge, dTires, dSellingPrice, dFairMarketValue, dAppraisedValue})

            GetDoubleInputFontSettingsDefault({dLoanableValue, dLoanablePercent})

            GetIntegerInputFontSettings({iRim})
        Catch ex As Exception
            TriggerBugReport("Vehicle Appraisal - FixUI", ex.Message.ToString)
        End Try
    End Sub

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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        Dim Attach As New FrmAppraiseImage
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
            If .ShowDialog = DialogResult.OK Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    '***CHECK CHANGED
    Private Sub CbxEngine_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEngine_G.CheckedChanged
        If cbxEngine_G.Checked Then
            cbxEngine_F.Checked = False
            cbxEngine_P.Checked = False

            txtEngine.Enabled = True
            txtEngine.Focus()
        Else
            If cbxEngine_F.Checked = False And cbxEngine_P.Checked = False Then
                txtEngine.Text = ""
                txtEngine.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxEngine_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEngine_F.CheckedChanged
        If cbxEngine_F.Checked Then
            cbxEngine_G.Checked = False
            cbxEngine_P.Checked = False

            txtEngine.Enabled = True
            txtEngine.Focus()
        Else
            If cbxEngine_G.Checked = False And cbxEngine_P.Checked = False Then
                txtEngine.Text = ""
                txtEngine.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxEngine_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEngine_P.CheckedChanged
        If cbxEngine_P.Checked Then
            cbxEngine_G.Checked = False
            cbxEngine_F.Checked = False

            txtEngine.Enabled = True
            txtEngine.Focus()
        Else
            If cbxEngine_F.Checked = False And cbxEngine_G.Checked = False Then
                txtEngine.Text = ""
                txtEngine.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSteering_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSteering_G.CheckedChanged
        If cbxSteering_G.Checked Then
            cbxSteering_F.Checked = False
            cbxSteering_P.Checked = False

            txtSteering.Enabled = True
            txtSteering.Focus()
        Else
            If cbxSteering_F.Checked = False And cbxSteering_P.Checked = False Then
                txtSteering.Text = ""
                txtSteering.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSteering_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSteering_F.CheckedChanged
        If cbxSteering_F.Checked Then
            cbxSteering_G.Checked = False
            cbxSteering_P.Checked = False

            txtSteering.Enabled = True
            txtSteering.Focus()
        Else
            If cbxSteering_G.Checked = False And cbxSteering_P.Checked = False Then
                txtSteering.Text = ""
                txtSteering.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSteering_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSteering_P.CheckedChanged
        If cbxSteering_P.Checked Then
            cbxSteering_G.Checked = False
            cbxSteering_F.Checked = False

            txtSteering.Enabled = True
            txtSteering.Focus()
        Else
            If cbxSteering_G.Checked = False And cbxSteering_F.Checked = False Then
                txtSteering.Text = ""
                txtSteering.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxClutch_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxClutch_G.CheckedChanged
        If cbxClutch_G.Checked Then
            cbxClutch_F.Checked = False
            cbxClutch_P.Checked = False

            txtClutch.Enabled = True
            txtClutch.Focus()
        Else
            If cbxClutch_F.Checked = False And cbxClutch_P.Checked = False Then
                txtClutch.Text = ""
                txtClutch.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxClutch_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxClutch_F.CheckedChanged
        If cbxClutch_F.Checked Then
            cbxClutch_G.Checked = False
            cbxClutch_P.Checked = False

            txtClutch.Enabled = True
            txtClutch.Focus()
        Else
            If cbxClutch_G.Checked = False And cbxClutch_P.Checked = False Then
                txtClutch.Text = ""
                txtClutch.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxClutch_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxClutch_P.CheckedChanged
        If cbxClutch_P.Checked Then
            cbxClutch_G.Checked = False
            cbxClutch_F.Checked = False

            txtClutch.Enabled = True
            txtClutch.Focus()
        Else
            If cbxClutch_G.Checked = False And cbxClutch_F.Checked = False Then
                txtClutch.Text = ""
                txtClutch.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHeadLight_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHeadLight_G.CheckedChanged
        If cbxHeadLight_G.Checked Then
            cbxHeadLight_F.Checked = False
            cbxHeadLight_P.Checked = False

            txtHeadLight.Enabled = True
            txtHeadLight.Focus()
        Else
            If cbxHeadLight_F.Checked = False And cbxHeadLight_P.Checked = False Then
                txtHeadLight.Text = ""
                txtHeadLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHeadLight_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHeadLight_F.CheckedChanged
        If cbxHeadLight_F.Checked Then
            cbxHeadLight_G.Checked = False
            cbxHeadLight_P.Checked = False

            txtHeadLight.Enabled = True
            txtHeadLight.Focus()
        Else
            If cbxHeadLight_G.Checked = False And cbxHeadLight_P.Checked = False Then
                txtHeadLight.Text = ""
                txtHeadLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHeadLight_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHeadLight_P.CheckedChanged
        If cbxHeadLight_P.Checked Then
            cbxHeadLight_G.Checked = False
            cbxHeadLight_F.Checked = False

            txtHeadLight.Enabled = True
            txtHeadLight.Focus()
        Else
            If cbxHeadLight_G.Checked = False And cbxHeadLight_F.Checked = False Then
                txtHeadLight.Text = ""
                txtHeadLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSignalLight_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSignalLight_G.CheckedChanged
        If cbxSignalLight_G.Checked Then
            cbxSignalLight_F.Checked = False
            cbxSignalLight_P.Checked = False

            txtSignalLight.Enabled = True
            txtSignalLight.Focus()
        Else
            If cbxSignalLight_F.Checked = False And cbxSignalLight_P.Checked = False Then
                txtSignalLight.Text = ""
                txtSignalLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSignalLight_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSignalLight_F.CheckedChanged
        If cbxSignalLight_F.Checked Then
            cbxSignalLight_G.Checked = False
            cbxSignalLight_P.Checked = False

            txtSignalLight.Enabled = True
            txtSignalLight.Focus()
        Else
            If cbxSignalLight_G.Checked = False And cbxSignalLight_P.Checked = False Then
                txtSignalLight.Text = ""
                txtSignalLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSignalLight_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSignalLight_P.CheckedChanged
        If cbxSignalLight_P.Checked Then
            cbxSignalLight_G.Checked = False
            cbxSignalLight_F.Checked = False

            txtSignalLight.Enabled = True
            txtSignalLight.Focus()
        Else
            If cbxSignalLight_G.Checked = False And cbxSignalLight_F.Checked = False Then
                txtSignalLight.Text = ""
                txtSignalLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxShock_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShock_G.CheckedChanged
        If cbxShock_G.Checked Then
            cbxShock_F.Checked = False
            cbxShock_P.Checked = False

            txtShock.Enabled = True
            txtShock.Focus()
        Else
            If cbxShock_F.Checked = False And cbxShock_P.Checked = False Then
                txtShock.Text = ""
                txtShock.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxShock_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShock_F.CheckedChanged
        If cbxShock_F.Checked Then
            cbxShock_G.Checked = False
            cbxShock_P.Checked = False

            txtShock.Enabled = True
            txtShock.Focus()
        Else
            If cbxShock_G.Checked = False And cbxShock_P.Checked = False Then
                txtShock.Text = ""
                txtShock.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxShock_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShock_P.CheckedChanged
        If cbxShock_P.Checked Then
            cbxShock_G.Checked = False
            cbxShock_F.Checked = False

            txtShock.Enabled = True
            txtShock.Focus()
        Else
            If cbxShock_G.Checked = False And cbxShock_F.Checked = False Then
                txtShock.Text = ""
                txtShock.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUnderchassis_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUnderchassis_G.CheckedChanged
        If cbxUnderchassis_G.Checked Then
            cbxUnderchassis_F.Checked = False
            cbxUnderchassis_P.Checked = False

            txtUnderchassis.Enabled = True
            txtUnderchassis.Focus()
        Else
            If cbxUnderchassis_F.Checked = False And cbxUnderchassis_P.Checked = False Then
                txtUnderchassis.Text = ""
                txtUnderchassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUnderchassis_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUnderchassis_F.CheckedChanged
        If cbxUnderchassis_F.Checked Then
            cbxUnderchassis_G.Checked = False
            cbxUnderchassis_P.Checked = False

            txtUnderchassis.Enabled = True
            txtUnderchassis.Focus()
        Else
            If cbxUnderchassis_G.Checked = False And cbxUnderchassis_P.Checked = False Then
                txtUnderchassis.Text = ""
                txtUnderchassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUnderchassis_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUnderchassis_P.CheckedChanged
        If cbxUnderchassis_P.Checked Then
            cbxUnderchassis_G.Checked = False
            cbxUnderchassis_F.Checked = False

            txtUnderchassis.Enabled = True
            txtUnderchassis.Focus()
        Else
            If cbxUnderchassis_G.Checked = False And cbxUnderchassis_F.Checked = False Then
                txtUnderchassis.Text = ""
                txtUnderchassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUpholstery_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUpholstery_G.CheckedChanged
        If cbxUpholstery_G.Checked Then
            cbxUpholstery_F.Checked = False
            cbxUpholstery_P.Checked = False

            txtUpholstery.Enabled = True
            txtUpholstery.Focus()
        Else
            If cbxUpholstery_F.Checked = False And cbxUpholstery_P.Checked = False Then
                txtUpholstery.Text = ""
                txtUpholstery.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUpholstery_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUpholstery_F.CheckedChanged
        If cbxUpholstery_F.Checked Then
            cbxUpholstery_G.Checked = False
            cbxUpholstery_P.Checked = False

            txtUpholstery.Enabled = True
            txtUpholstery.Focus()
        Else
            If cbxUpholstery_G.Checked = False And cbxUpholstery_P.Checked = False Then
                txtUpholstery.Text = ""
                txtUpholstery.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxUpholstery_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUpholstery_P.CheckedChanged
        If cbxUpholstery_P.Checked Then
            cbxUpholstery_G.Checked = False
            cbxUpholstery_F.Checked = False

            txtUpholstery.Enabled = True
            txtUpholstery.Focus()
        Else
            If cbxUpholstery_G.Checked = False And cbxUpholstery_F.Checked = False Then
                txtUpholstery.Text = ""
                txtUpholstery.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTempGauge_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTempGauge_G.CheckedChanged
        If cbxTempGauge_G.Checked Then
            cbxTempGauge_F.Checked = False
            cbxTempGauge_P.Checked = False

            txtTempGauge.Enabled = True
            txtTempGauge.Focus()
        Else
            If cbxTempGauge_F.Checked = False And cbxTempGauge_P.Checked = False Then
                txtTempGauge.Text = ""
                txtTempGauge.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTempGauge_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTempGauge_F.CheckedChanged
        If cbxTempGauge_F.Checked Then
            cbxTempGauge_G.Checked = False
            cbxTempGauge_P.Checked = False

            txtTempGauge.Enabled = True
            txtTempGauge.Focus()
        Else
            If cbxTempGauge_G.Checked = False And cbxTempGauge_P.Checked = False Then
                txtTempGauge.Text = ""
                txtTempGauge.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTempGauge_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTempGauge_P.CheckedChanged
        If cbxTempGauge_P.Checked Then
            cbxTempGauge_G.Checked = False
            cbxTempGauge_F.Checked = False

            txtTempGauge.Enabled = True
            txtTempGauge.Focus()
        Else
            If cbxTempGauge_G.Checked = False And cbxTempGauge_F.Checked = False Then
                txtTempGauge.Text = ""
                txtTempGauge.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOdometer_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOdometer_G.CheckedChanged
        If cbxOdometer_G.Checked Then
            cbxOdometer_F.Checked = False
            cbxOdometer_P.Checked = False

            txtOdometer.Enabled = True
            txtOdometer.Focus()
        Else
            If cbxOdometer_F.Checked = False And cbxOdometer_P.Checked = False Then
                txtOdometer.Text = ""
                txtOdometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOdometer_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOdometer_F.CheckedChanged
        If cbxOdometer_F.Checked Then
            cbxOdometer_G.Checked = False
            cbxOdometer_P.Checked = False

            txtOdometer.Enabled = True
            txtOdometer.Focus()
        Else
            If cbxOdometer_G.Checked = False And cbxOdometer_P.Checked = False Then
                txtOdometer.Text = ""
                txtOdometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOdometer_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOdometer_P.CheckedChanged
        If cbxOdometer_P.Checked Then
            cbxOdometer_G.Checked = False
            cbxOdometer_F.Checked = False

            txtOdometer.Enabled = True
            txtOdometer.Focus()
        Else
            If cbxOdometer_G.Checked = False And cbxOdometer_F.Checked = False Then
                txtOdometer.Text = ""
                txtOdometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTransmision_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTransmission_G.CheckedChanged
        If cbxTransmission_G.Checked Then
            cbxTransmission_F.Checked = False
            cbxTransmission_P.Checked = False

            txtTransmission.Enabled = True
            txtTransmission.Focus()
        Else
            If cbxTransmission_F.Checked = False And cbxTransmission_P.Checked = False Then
                txtTransmission.Text = ""
                txtTransmission.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTransmission_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTransmission_F.CheckedChanged
        If cbxTransmission_F.Checked Then
            cbxTransmission_G.Checked = False
            cbxTransmission_P.Checked = False

            txtTransmission.Enabled = True
            txtTransmission.Focus()
        Else
            If cbxTransmission_G.Checked = False And cbxTransmission_P.Checked = False Then
                txtTransmission.Text = ""
                txtTransmission.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxTransmission_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTransmission_P.CheckedChanged
        If cbxTransmission_P.Checked Then
            cbxTransmission_G.Checked = False
            cbxTransmission_F.Checked = False

            txtTransmission.Enabled = True
            txtTransmission.Focus()
        Else
            If cbxTransmission_G.Checked = False And cbxTransmission_F.Checked = False Then
                txtTransmission.Text = ""
                txtTransmission.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAcceleration_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAcceleration_G.CheckedChanged
        If cbxAcceleration_G.Checked Then
            cbxAcceleration_F.Checked = False
            cbxAcceleration_P.Checked = False

            txtAcceleration.Enabled = True
            txtAcceleration.Focus()
        Else
            If cbxAcceleration_F.Checked = False And cbxAcceleration_P.Checked = False Then
                txtAcceleration.Text = ""
                txtAcceleration.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAcceleration_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAcceleration_F.CheckedChanged
        If cbxAcceleration_F.Checked Then
            cbxAcceleration_G.Checked = False
            cbxAcceleration_P.Checked = False

            txtAcceleration.Enabled = True
            txtAcceleration.Focus()
        Else
            If cbxAcceleration_G.Checked = False And cbxAcceleration_P.Checked = False Then
                txtAcceleration.Text = ""
                txtAcceleration.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAcceleration_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAcceleration_P.CheckedChanged
        If cbxAcceleration_P.Checked Then
            cbxAcceleration_G.Checked = False
            cbxAcceleration_F.Checked = False

            txtAcceleration.Enabled = True
            txtAcceleration.Focus()
        Else
            If cbxAcceleration_G.Checked = False And cbxAcceleration_F.Checked = False Then
                txtAcceleration.Text = ""
                txtAcceleration.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxParkLight_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxParkLight_G.CheckedChanged
        If cbxParkLight_G.Checked Then
            cbxParkLight_F.Checked = False
            cbxParkLight_P.Checked = False

            txtParkLight.Enabled = True
            txtParkLight.Focus()
        Else
            If cbxParkLight_F.Checked = False And cbxParkLight_P.Checked = False Then
                txtParkLight.Text = ""
                txtParkLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxParkLight_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxParkLight_F.CheckedChanged
        If cbxParkLight_F.Checked Then
            cbxParkLight_G.Checked = False
            cbxParkLight_P.Checked = False

            txtParkLight.Enabled = True
            txtParkLight.Focus()
        Else
            If cbxParkLight_G.Checked = False And cbxParkLight_P.Checked = False Then
                txtParkLight.Text = ""
                txtParkLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxParkLight_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxParkLight_P.CheckedChanged
        If cbxParkLight_P.Checked Then
            cbxParkLight_G.Checked = False
            cbxParkLight_F.Checked = False

            txtParkLight.Enabled = True
            txtParkLight.Focus()
        Else
            If cbxParkLight_G.Checked = False And cbxParkLight_F.Checked = False Then
                txtParkLight.Text = ""
                txtParkLight.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHorn_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHorn_G.CheckedChanged
        If cbxHorn_G.Checked Then
            cbxHorn_F.Checked = False
            cbxHorn_P.Checked = False

            txtHorn.Enabled = True
            txtHorn.Focus()
        Else
            If cbxHorn_F.Checked = False And cbxHorn_P.Checked = False Then
                txtHorn.Text = ""
                txtHorn.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHorn_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHorn_F.CheckedChanged
        If cbxHorn_F.Checked Then
            cbxHorn_G.Checked = False
            cbxHorn_P.Checked = False

            txtHorn.Enabled = True
            txtHorn.Focus()
        Else
            If cbxHorn_G.Checked = False And cbxHorn_P.Checked = False Then
                txtHorn.Text = ""
                txtHorn.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxHorn_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHorn_P.CheckedChanged
        If cbxHorn_P.Checked Then
            cbxHorn_G.Checked = False
            cbxHorn_F.Checked = False

            txtHorn.Enabled = True
            txtHorn.Focus()
        Else
            If cbxHorn_G.Checked = False And cbxHorn_F.Checked = False Then
                txtHorn.Text = ""
                txtHorn.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxChassis_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxChassis_G.CheckedChanged
        If cbxChassis_G.Checked Then
            cbxChassis_F.Checked = False
            cbxChassis_P.Checked = False

            txtChassis.Enabled = True
            txtChassis.Focus()
        Else
            If cbxChassis_F.Checked = False And cbxChassis_P.Checked = False Then
                txtChassis.Text = ""
                txtChassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxChassis_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxChassis_F.CheckedChanged
        If cbxChassis_F.Checked Then
            cbxChassis_G.Checked = False
            cbxChassis_P.Checked = False

            txtChassis.Enabled = True
            txtChassis.Focus()
        Else
            If cbxChassis_G.Checked = False And cbxChassis_P.Checked = False Then
                txtChassis.Text = ""
                txtChassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxChassis_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxChassis_P.CheckedChanged
        If cbxChassis_P.Checked Then
            cbxChassis_G.Checked = False
            cbxChassis_F.Checked = False

            txtChassis.Enabled = True
            txtChassis.Focus()
        Else
            If cbxChassis_G.Checked = False And cbxChassis_F.Checked = False Then
                txtChassis.Text = ""
                txtChassis.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFrontBumper_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFrontBumper_G.CheckedChanged
        If cbxFrontBumper_G.Checked Then
            cbxFrontBumper_F.Checked = False
            cbxFrontBumper_P.Checked = False

            txtFrontBumper.Enabled = True
            txtFrontBumper.Focus()
        Else
            If cbxFrontBumper_F.Checked = False And cbxFrontBumper_P.Checked = False Then
                txtFrontBumper.Text = ""
                txtFrontBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFrontBumper_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFrontBumper_F.CheckedChanged
        If cbxFrontBumper_F.Checked Then
            cbxFrontBumper_G.Checked = False
            cbxFrontBumper_P.Checked = False

            txtFrontBumper.Enabled = True
            txtFrontBumper.Focus()
        Else
            If cbxFrontBumper_G.Checked = False And cbxFrontBumper_P.Checked = False Then
                txtFrontBumper.Text = ""
                txtFrontBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFrontBumper_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFrontBumper_P.CheckedChanged
        If cbxFrontBumper_P.Checked Then
            cbxFrontBumper_G.Checked = False
            cbxFrontBumper_F.Checked = False

            txtFrontBumper.Enabled = True
            txtFrontBumper.Focus()
        Else
            If cbxFrontBumper_G.Checked = False And cbxFrontBumper_F.Checked = False Then
                txtFrontBumper.Text = ""
                txtFrontBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAmpheres_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAmpheres_G.CheckedChanged
        If cbxAmpheres_G.Checked Then
            cbxAmpheres_F.Checked = False
            cbxAmpheres_P.Checked = False

            txtAmpheres.Enabled = True
            txtAmpheres.Focus()
        Else
            If cbxAmpheres_F.Checked = False And cbxAmpheres_P.Checked = False Then
                txtAmpheres.Text = ""
                txtAmpheres.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAmpheres_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAmpheres_F.CheckedChanged
        If cbxAmpheres_F.Checked Then
            cbxAmpheres_G.Checked = False
            cbxAmpheres_P.Checked = False

            txtAmpheres.Enabled = True
            txtAmpheres.Focus()
        Else
            If cbxAmpheres_G.Checked = False And cbxAmpheres_P.Checked = False Then
                txtAmpheres.Text = ""
                txtAmpheres.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxAmpheres_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAmpheres_P.CheckedChanged
        If cbxAmpheres_P.Checked Then
            cbxAmpheres_G.Checked = False
            cbxAmpheres_F.Checked = False

            txtAmpheres.Enabled = True
            txtAmpheres.Focus()
        Else
            If cbxAmpheres_G.Checked = False And cbxAmpheres_F.Checked = False Then
                txtAmpheres.Text = ""
                txtAmpheres.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFuel_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFuel_G.CheckedChanged
        If cbxFuel_G.Checked Then
            cbxFuel_F.Checked = False
            cbxFuel_P.Checked = False

            txtFuel.Enabled = True
            txtFuel.Focus()
        Else
            If cbxFuel_F.Checked = False And cbxFuel_P.Checked = False Then
                txtFuel.Text = ""
                txtFuel.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFuel_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFuel_F.CheckedChanged
        If cbxFuel_F.Checked Then
            cbxFuel_G.Checked = False
            cbxFuel_P.Checked = False

            txtFuel.Enabled = True
            txtFuel.Focus()
        Else
            If cbxFuel_G.Checked = False And cbxFuel_P.Checked = False Then
                txtFuel.Text = ""
                txtFuel.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxFuel_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFuel_P.CheckedChanged
        If cbxFuel_P.Checked Then
            cbxFuel_G.Checked = False
            cbxFuel_F.Checked = False

            txtFuel.Enabled = True
            txtFuel.Focus()
        Else
            If cbxFuel_G.Checked = False And cbxFuel_F.Checked = False Then
                txtFuel.Text = ""
                txtFuel.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxStarter_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxStarter_G.CheckedChanged
        If cbxStarter_G.Checked Then
            cbxStarter_F.Checked = False
            cbxStarter_P.Checked = False

            txtStarter.Enabled = True
            txtStarter.Focus()
        Else
            If cbxStarter_F.Checked = False And cbxStarter_P.Checked = False Then
                txtStarter.Text = ""
                txtStarter.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxStarter_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxStarter_F.CheckedChanged
        If cbxStarter_F.Checked Then
            cbxStarter_G.Checked = False
            cbxStarter_P.Checked = False

            txtStarter.Enabled = True
            txtStarter.Focus()
        Else
            If cbxStarter_G.Checked = False And cbxStarter_P.Checked = False Then
                txtStarter.Text = ""
                txtStarter.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxStarter_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxStarter_P.CheckedChanged
        If cbxStarter_P.Checked Then
            cbxStarter_G.Checked = False
            cbxStarter_F.Checked = False

            txtStarter.Enabled = True
            txtStarter.Focus()
        Else
            If cbxStarter_G.Checked = False And cbxStarter_F.Checked = False Then
                txtStarter.Text = ""
                txtStarter.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxDifferential_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDifferential_G.CheckedChanged
        If cbxDifferential_G.Checked Then
            cbxDifferential_F.Checked = False
            cbxDifferential_P.Checked = False

            txtDifferential.Enabled = True
            txtDifferential.Focus()
        Else
            If cbxDifferential_F.Checked = False And cbxDifferential_P.Checked = False Then
                txtDifferential.Text = ""
                txtDifferential.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxDifferential_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDifferential_F.CheckedChanged
        If cbxDifferential_F.Checked Then
            cbxDifferential_G.Checked = False
            cbxDifferential_P.Checked = False

            txtDifferential.Enabled = True
            txtDifferential.Focus()
        Else
            If cbxDifferential_G.Checked = False And cbxDifferential_P.Checked = False Then
                txtDifferential.Text = ""
                txtDifferential.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxDifferential_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDifferential_P.CheckedChanged
        If cbxDifferential_P.Checked Then
            cbxDifferential_G.Checked = False
            cbxDifferential_F.Checked = False

            txtDifferential.Enabled = True
            txtDifferential.Focus()
        Else
            If cbxDifferential_G.Checked = False And cbxDifferential_F.Checked = False Then
                txtDifferential.Text = ""
                txtDifferential.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBrakes_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBrakes_G.CheckedChanged
        If cbxBrakes_G.Checked Then
            cbxBrakes_F.Checked = False
            cbxBrakes_P.Checked = False

            txtBrakes.Enabled = True
            txtBrakes.Focus()
        Else
            If cbxBrakes_F.Checked = False And cbxBrakes_P.Checked = False Then
                txtBrakes.Text = ""
                txtBrakes.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBrakes_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBrakes_F.CheckedChanged
        If cbxBrakes_F.Checked Then
            cbxBrakes_G.Checked = False
            cbxBrakes_P.Checked = False

            txtBrakes.Enabled = True
            txtBrakes.Focus()
        Else
            If cbxBrakes_G.Checked = False And cbxBrakes_P.Checked = False Then
                txtBrakes.Text = ""
                txtBrakes.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBrakes_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBrakes_P.CheckedChanged
        If cbxBrakes_P.Checked Then
            cbxBrakes_G.Checked = False
            cbxBrakes_F.Checked = False

            txtBrakes.Enabled = True
            txtBrakes.Focus()
        Else
            If cbxBrakes_G.Checked = False And cbxBrakes_F.Checked = False Then
                txtBrakes.Text = ""
                txtBrakes.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxWiper_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWiper_G.CheckedChanged
        If cbxWiper_G.Checked Then
            cbxWiper_F.Checked = False
            cbxWiper_P.Checked = False

            txtWiper.Enabled = True
            txtWiper.Focus()
        Else
            If cbxWiper_F.Checked = False And cbxWiper_P.Checked = False Then
                txtWiper.Text = ""
                txtWiper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxWiper_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWiper_F.CheckedChanged
        If cbxWiper_F.Checked Then
            cbxWiper_G.Checked = False
            cbxWiper_P.Checked = False

            txtWiper.Enabled = True
            txtWiper.Focus()
        Else
            If cbxWiper_G.Checked = False And cbxWiper_P.Checked = False Then
                txtWiper.Text = ""
                txtWiper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxWiper_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWiper_P.CheckedChanged
        If cbxWiper_P.Checked Then
            cbxWiper_G.Checked = False
            cbxWiper_F.Checked = False

            txtWiper.Enabled = True
            txtWiper.Focus()
        Else
            If cbxWiper_G.Checked = False And cbxWiper_F.Checked = False Then
                txtWiper.Text = ""
                txtWiper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBackUp_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBackUp_G.CheckedChanged
        If cbxBackUp_G.Checked Then
            cbxBackUp_F.Checked = False
            cbxBackUp_P.Checked = False

            txtBackUp.Enabled = True
            txtBackUp.Focus()
        Else
            If cbxBackUp_F.Checked = False And cbxBackUp_P.Checked = False Then
                txtBackUp.Text = ""
                txtBackUp.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBackUp_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBackUp_F.CheckedChanged
        If cbxBackUp_F.Checked Then
            cbxBackUp_G.Checked = False
            cbxBackUp_P.Checked = False

            txtBackUp.Enabled = True
            txtBackUp.Focus()
        Else
            If cbxBackUp_G.Checked = False And cbxBackUp_P.Checked = False Then
                txtBackUp.Text = ""
                txtBackUp.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBackUp_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBackUp_P.CheckedChanged
        If cbxBackUp_P.Checked Then
            cbxBackUp_G.Checked = False
            cbxBackUp_F.Checked = False

            txtBackUp.Enabled = True
            txtBackUp.Focus()
        Else
            If cbxBackUp_G.Checked = False And cbxBackUp_F.Checked = False Then
                txtBackUp.Text = ""
                txtBackUp.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSideMirror_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSideMirror_G.CheckedChanged
        If cbxSideMirror_G.Checked Then
            cbxSideMirror_F.Checked = False
            cbxSideMirror_P.Checked = False

            txtSideMirror.Enabled = True
            txtSideMirror.Focus()
        Else
            If cbxSideMirror_F.Checked = False And cbxSideMirror_P.Checked = False Then
                txtSideMirror.Text = ""
                txtSideMirror.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSideMirror_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSideMirror_F.CheckedChanged
        If cbxSideMirror_F.Checked Then
            cbxSideMirror_G.Checked = False
            cbxSideMirror_P.Checked = False

            txtSideMirror.Enabled = True
            txtSideMirror.Focus()
        Else
            If cbxSideMirror_G.Checked = False And cbxSideMirror_P.Checked = False Then
                txtSideMirror.Text = ""
                txtSideMirror.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSideMirror_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSideMirror_P.CheckedChanged
        If cbxSideMirror_P.Checked Then
            cbxSideMirror_G.Checked = False
            cbxSideMirror_F.Checked = False

            txtSideMirror.Enabled = True
            txtSideMirror.Focus()
        Else
            If cbxSideMirror_G.Checked = False And cbxSideMirror_F.Checked = False Then
                txtSideMirror.Text = ""
                txtSideMirror.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyFlooring_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyFlooring_G.CheckedChanged
        If cbxBodyFlooring_G.Checked Then
            cbxBodyFlooring_F.Checked = False
            cbxBodyFlooring_P.Checked = False

            txtBodyFlooring.Enabled = True
            txtBodyFlooring.Focus()
        Else
            If cbxBodyFlooring_F.Checked = False And cbxBodyFlooring_P.Checked = False Then
                txtBodyFlooring.Text = ""
                txtBodyFlooring.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyFlooring_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyFlooring_F.CheckedChanged
        If cbxBodyFlooring_F.Checked Then
            cbxBodyFlooring_G.Checked = False
            cbxBodyFlooring_P.Checked = False

            txtBodyFlooring.Enabled = True
            txtBodyFlooring.Focus()
        Else
            If cbxBodyFlooring_G.Checked = False And cbxBodyFlooring_P.Checked = False Then
                txtBodyFlooring.Text = ""
                txtBodyFlooring.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyFlooring_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyFlooring_P.CheckedChanged
        If cbxBodyFlooring_P.Checked Then
            cbxBodyFlooring_G.Checked = False
            cbxBodyFlooring_F.Checked = False

            txtBodyFlooring.Enabled = True
            txtBodyFlooring.Focus()
        Else
            If cbxBodyFlooring_G.Checked = False And cbxBodyFlooring_F.Checked = False Then
                txtBodyFlooring.Text = ""
                txtBodyFlooring.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxRearBumper_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRearBumper_G.CheckedChanged
        If cbxRearBumper_G.Checked Then
            cbxRearBumper_F.Checked = False
            cbxRearBumper_P.Checked = False

            txtRearBumper.Enabled = True
            txtRearBumper.Focus()
        Else
            If cbxRearBumper_F.Checked = False And cbxRearBumper_P.Checked = False Then
                txtRearBumper.Text = ""
                txtRearBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxRearBumper_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRearBumper_F.CheckedChanged
        If cbxRearBumper_F.Checked Then
            cbxRearBumper_G.Checked = False
            cbxRearBumper_P.Checked = False

            txtRearBumper.Enabled = True
            txtRearBumper.Focus()
        Else
            If cbxRearBumper_G.Checked = False And cbxRearBumper_P.Checked = False Then
                txtRearBumper.Text = ""
                txtRearBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxRearBumper_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRearBumper_P.CheckedChanged
        If cbxRearBumper_P.Checked Then
            cbxRearBumper_G.Checked = False
            cbxRearBumper_F.Checked = False

            txtRearBumper.Enabled = True
            txtRearBumper.Focus()
        Else
            If cbxRearBumper_G.Checked = False And cbxRearBumper_F.Checked = False Then
                txtRearBumper.Text = ""
                txtRearBumper.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOilPressure_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOilPressure_G.CheckedChanged
        If cbxOilPressure_G.Checked Then
            cbxOilPressure_F.Checked = False
            cbxOilPressure_P.Checked = False

            txtOilPressure.Enabled = True
            txtOilPressure.Focus()
        Else
            If cbxOilPressure_F.Checked = False And cbxOilPressure_P.Checked = False Then
                txtOilPressure.Text = ""
                txtOilPressure.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOilPressure_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOilPressure_F.CheckedChanged
        If cbxOilPressure_F.Checked Then
            cbxOilPressure_G.Checked = False
            cbxOilPressure_P.Checked = False

            txtOilPressure.Enabled = True
            txtOilPressure.Focus()
        Else
            If cbxOilPressure_G.Checked = False And cbxOilPressure_P.Checked = False Then
                txtOilPressure.Text = ""
                txtOilPressure.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxOilPressure_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOilPressure_P.CheckedChanged
        If cbxOilPressure_P.Checked Then
            cbxOilPressure_G.Checked = False
            cbxOilPressure_F.Checked = False

            txtOilPressure.Enabled = True
            txtOilPressure.Focus()
        Else
            If cbxOilPressure_G.Checked = False And cbxOilPressure_F.Checked = False Then
                txtOilPressure.Text = ""
                txtOilPressure.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSpeedometer_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSpeedometer_G.CheckedChanged
        If cbxSpeedometer_G.Checked Then
            cbxSpeedometer_F.Checked = False
            cbxSpeedometer_P.Checked = False

            txtSpeedometer.Enabled = True
            txtSpeedometer.Focus()
        Else
            If cbxSpeedometer_F.Checked = False And cbxSpeedometer_P.Checked = False Then
                txtSpeedometer.Text = ""
                txtSpeedometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSpeedometer_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSpeedometer_F.CheckedChanged
        If cbxSpeedometer_F.Checked Then
            cbxSpeedometer_G.Checked = False
            cbxSpeedometer_P.Checked = False

            txtSpeedometer.Enabled = True
            txtSpeedometer.Focus()
        Else
            If cbxSpeedometer_G.Checked = False And cbxSpeedometer_P.Checked = False Then
                txtSpeedometer.Text = ""
                txtSpeedometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxSpeedometer_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSpeedometer_P.CheckedChanged
        If cbxSpeedometer_P.Checked Then
            cbxSpeedometer_G.Checked = False
            cbxSpeedometer_F.Checked = False

            txtSpeedometer.Enabled = True
            txtSpeedometer.Focus()
        Else
            If cbxSpeedometer_G.Checked = False And cbxSpeedometer_F.Checked = False Then
                txtSpeedometer.Text = ""
                txtSpeedometer.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyPaint_G_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyPaint_G.CheckedChanged
        If cbxBodyPaint_G.Checked Then
            cbxBodyPaint_F.Checked = False
            cbxBodyPaint_P.Checked = False

            txtBodyPaint.Enabled = True
            txtBodyPaint.Focus()
        Else
            If cbxBodyPaint_F.Checked = False And cbxBodyPaint_P.Checked = False Then
                txtBodyPaint.Text = ""
                txtBodyPaint.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyPaint_F_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyPaint_F.CheckedChanged
        If cbxBodyPaint_F.Checked Then
            cbxBodyPaint_G.Checked = False
            cbxBodyPaint_P.Checked = False

            txtBodyPaint.Enabled = True
            txtBodyPaint.Focus()
        Else
            If cbxBodyPaint_G.Checked = False And cbxBodyPaint_P.Checked = False Then
                txtBodyPaint.Text = ""
                txtBodyPaint.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxBodyPaint_P_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBodyPaint_P.CheckedChanged
        If cbxBodyPaint_P.Checked Then
            cbxBodyPaint_G.Checked = False
            cbxBodyPaint_F.Checked = False

            txtBodyPaint.Enabled = True
            txtBodyPaint.Focus()
        Else
            If cbxBodyPaint_G.Checked = False And cbxBodyPaint_F.Checked = False Then
                txtBodyPaint.Text = ""
                txtBodyPaint.Enabled = False
            End If
        End If
    End Sub
    '***CHECK CHANGED

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Public Sub Clear()
        cbxEngine_G.Checked = False
        cbxEngine_F.Checked = False
        cbxEngine_P.Checked = False
        txtEngine.Text = ""

        cbxSteering_G.Checked = False
        cbxSteering_F.Checked = False
        cbxSteering_P.Checked = False
        txtSteering.Text = ""

        cbxClutch_G.Checked = False
        cbxClutch_F.Checked = False
        cbxClutch_P.Checked = False
        txtClutch.Text = ""

        cbxHeadLight_G.Checked = False
        cbxHeadLight_F.Checked = False
        cbxHeadLight_P.Checked = False
        txtHeadLight.Text = ""

        cbxSignalLight_G.Checked = False
        cbxSignalLight_F.Checked = False
        cbxSignalLight_P.Checked = False
        txtSignalLight.Text = ""

        cbxShock_G.Checked = False
        cbxShock_F.Checked = False
        cbxShock_P.Checked = False
        txtShock.Text = ""

        cbxUnderchassis_G.Checked = False
        cbxUnderchassis_F.Checked = False
        cbxUnderchassis_P.Checked = False
        txtUnderchassis.Text = ""

        cbxUpholstery_G.Checked = False
        cbxUpholstery_F.Checked = False
        cbxUpholstery_P.Checked = False
        txtUpholstery.Text = ""

        cbxTempGauge_G.Checked = False
        cbxTempGauge_F.Checked = False
        cbxTempGauge_P.Checked = False
        txtTempGauge.Text = ""

        cbxOdometer_G.Checked = False
        cbxOdometer_F.Checked = False
        cbxOdometer_P.Checked = False
        txtOdometer.Text = ""

        cbxTransmission_G.Checked = False
        cbxTransmission_F.Checked = False
        cbxTransmission_P.Checked = False
        txtTransmission.Text = ""

        dTires.Value = 100
        txtTires.Text = ""

        cbxAcceleration_G.Checked = False
        cbxAcceleration_F.Checked = False
        cbxAcceleration_P.Checked = False
        txtAcceleration.Text = ""

        cbxParkLight_G.Checked = False
        cbxParkLight_F.Checked = False
        cbxParkLight_P.Checked = False
        txtParkLight.Text = ""

        cbxHorn_G.Checked = False
        cbxHorn_F.Checked = False
        cbxHorn_P.Checked = False
        txtHorn.Text = ""

        cbxChassis_G.Checked = False
        cbxChassis_F.Checked = False
        cbxChassis_P.Checked = False
        txtChassis.Text = ""

        cbxFrontBumper_G.Checked = False
        cbxFrontBumper_F.Checked = False
        cbxFrontBumper_P.Checked = False
        txtFrontBumper.Text = ""

        cbxAmpheres_G.Checked = False
        cbxAmpheres_F.Checked = False
        cbxAmpheres_P.Checked = False
        txtAmpheres.Text = ""

        cbxFuel_G.Checked = False
        cbxFuel_F.Checked = False
        cbxFuel_P.Checked = False
        txtFuel.Text = ""

        cbxStarter_G.Checked = False
        cbxStarter_F.Checked = False
        cbxStarter_P.Checked = False
        txtStarter.Text = ""

        cbxDifferential_G.Checked = False
        cbxDifferential_F.Checked = False
        cbxDifferential_P.Checked = False
        txtDifferential.Text = ""

        cbxBrakes_G.Checked = False
        cbxBrakes_F.Checked = False
        cbxBrakes_P.Checked = False
        txtBrakes.Text = ""

        cbxWiper_G.Checked = False
        cbxWiper_F.Checked = False
        cbxWiper_P.Checked = False
        txtWiper.Text = ""

        cbxBackUp_G.Checked = False
        cbxBackUp_F.Checked = False
        cbxBackUp_P.Checked = False
        txtBackUp.Text = ""

        cbxSideMirror_G.Checked = False
        cbxSideMirror_F.Checked = False
        cbxSideMirror_P.Checked = False
        txtSideMirror.Text = ""

        cbxBodyFlooring_G.Checked = False
        cbxBodyFlooring_F.Checked = False
        cbxBodyFlooring_P.Checked = False
        txtBodyFlooring.Text = ""

        cbxRearBumper_G.Checked = False
        cbxRearBumper_F.Checked = False
        cbxRearBumper_P.Checked = False
        txtRearBumper.Text = ""

        cbxOilPressure_G.Checked = False
        cbxOilPressure_F.Checked = False
        cbxOilPressure_P.Checked = False
        txtOilPressure.Text = ""

        cbxSpeedometer_G.Checked = False
        cbxSpeedometer_F.Checked = False
        cbxSpeedometer_P.Checked = False
        txtSpeedometer.Text = ""

        cbxBodyPaint_G.Checked = False
        cbxBodyPaint_F.Checked = False
        cbxBodyPaint_P.Checked = False
        txtBodyPaint.Text = ""

        rRemarks.Text = ""
        txtSource.Text = ""
        txtTelephoneNum.Text = ""
        dSellingPrice.Value = 0
        dFairMarketValue.Value = 0
        dAppraisedValue.Value = 0
        dLoanableValue.Value = 0
        iRim.Enabled = True
        btnSave.Text = "&Save"
    End Sub

#Region "Keydown"
    Private Sub CbxMake_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMake.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxType.Focus()
        End If
    End Sub

    Private Sub CbxType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxModel.Focus()
        End If
    End Sub

    Private Sub CbxModel_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxModel.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPlateNum.Focus()
        End If
    End Sub

    Private Sub TxtPlateNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlateNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxTransmission.Focus()
        End If
    End Sub

    Private Sub CbxTransmission_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxTransmission.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFuel.Focus()
        End If
    End Sub

    Private Sub CbxFuel_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFuel.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBodyColor.Focus()
        End If
    End Sub

    Private Sub CbxBodyColor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBodyColor.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpYear.Focus()
        End If
    End Sub

    Private Sub DtpYear_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEngineNumber.Focus()
        End If
    End Sub

    Private Sub CbxMotorNum_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEngineNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtChassisNum.Focus()
        End If
    End Sub

    Private Sub TxtSerialNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtChassisNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRegistryCert.Focus()
        End If
    End Sub

    Private Sub TxtRegistryCert_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRegistryCert.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtORNum.Focus()
        End If
    End Sub

    Private Sub TxtORNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtORNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGrossWeight.Focus()
        End If
    End Sub

    Private Sub LabelX63_MouseClick(sender As Object, e As MouseEventArgs) Handles LabelX63.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If iRim.Enabled = False Then
                iRim.Enabled = True
            Else
                iRim.Enabled = False
            End If
        End If
    End Sub

    Private Sub DGrossWeight_KeyDown(sender As Object, e As KeyEventArgs) Handles dGrossWeight.KeyDown
        If e.KeyCode = Keys.Enter Then
            If iRim.Enabled Then
                iRim.Focus()
            Else
                dMileAge.Focus()
            End If
        End If
    End Sub

    Private Sub IRim_KeyDown(sender As Object, e As KeyEventArgs) Handles iRim.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMileAge.Focus()
        End If
    End Sub

    Private Sub DMileAge_KeyDown(sender As Object, e As KeyEventArgs) Handles dMileAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMileAge.Focus()
        End If
    End Sub

    Private Sub CbxMileAge_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMileAge.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpRegistered.Focus()
        End If
    End Sub

    Private Sub DtpRegistered_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRegistered.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtLTO.Focus()
        End If
    End Sub

    Private Sub TxtLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEngine_G.Focus()
        End If
    End Sub

    Private Sub TxtSource_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSource.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephoneNum.Focus()
        End If
    End Sub

    Private Sub TxtTelephoneNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephoneNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            dSellingPrice.Focus()
        End If
    End Sub

    Private Sub DSellingPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles dSellingPrice.KeyDown
        If e.KeyCode = Keys.Enter Then
            dFairMarketValue.Focus()
        End If
    End Sub

    Private Sub DFairMarketValue_KeyDown(sender As Object, e As KeyEventArgs) Handles dFairMarketValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAppraisedValue.Focus()
        End If
    End Sub

    Private Sub DAppraisedValue_KeyDown(sender As Object, e As KeyEventArgs) Handles dAppraisedValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dLoanablePercent.Focus()
        End If
    End Sub

    Private Sub DLoanablePercent_KeyDown(sender As Object, e As KeyEventArgs) Handles dLoanablePercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leaves"
    Private Sub CbxMake_Leave(sender As Object, e As EventArgs) Handles cbxMake.Leave
        cbxMake.Text = ReplaceText(cbxMake.Text.Trim)
    End Sub

    Private Sub CbxType_Leave(sender As Object, e As EventArgs) Handles cbxType.Leave
        cbxType.Text = ReplaceText(cbxType.Text.Trim)
    End Sub

    Private Sub CbxModel_Leave(sender As Object, e As EventArgs) Handles cbxModel.Leave
        cbxModel.Text = ReplaceText(cbxModel.Text.Trim)
    End Sub

    Private Sub TxtPlateNum_Leave(sender As Object, e As EventArgs) Handles txtPlateNum.Leave
        txtPlateNum.Text = ReplaceText(txtPlateNum.Text.Trim)
    End Sub

    Private Sub CbxTransmission_Leave(sender As Object, e As EventArgs) Handles cbxTransmission.Leave
        cbxTransmission.Text = ReplaceText(cbxTransmission.Text.Trim)
    End Sub

    Private Sub CbxFuel_Leave(sender As Object, e As EventArgs) Handles cbxFuel.Leave
        cbxFuel.Text = ReplaceText(cbxFuel.Text.Trim)
    End Sub

    Private Sub CbxBodyColor_Leave(sender As Object, e As EventArgs) Handles cbxBodyColor.Leave
        cbxBodyColor.Text = ReplaceText(cbxBodyColor.Text.Trim)
    End Sub

    Private Sub CbxMotorNum_Leave(sender As Object, e As EventArgs) Handles cbxEngineNumber.Leave
        cbxEngineNumber.Text = ReplaceText(cbxEngineNumber.Text.Trim)
    End Sub

    Private Sub TxtSerialNum_Leave(sender As Object, e As EventArgs) Handles txtChassisNum.Leave
        txtChassisNum.Text = ReplaceText(txtChassisNum.Text.Trim)
    End Sub

    Private Sub TxtRegistryCert_Leave(sender As Object, e As EventArgs) Handles txtRegistryCert.Leave
        txtRegistryCert.Text = ReplaceText(txtRegistryCert.Text.Trim)
    End Sub

    Private Sub TxtLTO_Leave(sender As Object, e As EventArgs) Handles txtLTO.Leave
        txtLTO.Text = ReplaceText(txtLTO.Text.Trim)
    End Sub

    Private Sub TxtORNum_Leave(sender As Object, e As EventArgs) Handles txtORNum.Leave
        txtORNum.Text = ReplaceText(txtORNum.Text.Trim)
    End Sub

    Private Sub TxtEngine_Leave(sender As Object, e As EventArgs) Handles txtEngine.Leave
        txtEngine.Text = ReplaceText(txtEngine.Text.Trim)
    End Sub

    Private Sub TxtSteering_Leave(sender As Object, e As EventArgs) Handles txtSteering.Leave
        txtSteering.Text = ReplaceText(txtSteering.Text.Trim)
    End Sub

    Private Sub TxtClutch_Leave(sender As Object, e As EventArgs) Handles txtClutch.Leave
        txtClutch.Text = ReplaceText(txtClutch.Text.Trim)
    End Sub

    Private Sub TxtHeadLight_Leave(sender As Object, e As EventArgs) Handles txtHeadLight.Leave
        txtHeadLight.Text = ReplaceText(txtHeadLight.Text.Trim)
    End Sub

    Private Sub TxtSignalLight_Leave(sender As Object, e As EventArgs) Handles txtSignalLight.Leave
        txtSignalLight.Text = ReplaceText(txtSignalLight.Text.Trim)
    End Sub

    Private Sub TxtShock_Leave(sender As Object, e As EventArgs) Handles txtShock.Leave
        txtShock.Text = ReplaceText(txtShock.Text.Trim)
    End Sub

    Private Sub TxtUnderchassis_Leave(sender As Object, e As EventArgs) Handles txtUnderchassis.Leave
        txtUnderchassis.Text = ReplaceText(txtUnderchassis.Text.Trim)
    End Sub

    Private Sub TxtUpholstery_Leave(sender As Object, e As EventArgs) Handles txtUpholstery.Leave
        txtUpholstery.Text = ReplaceText(txtUpholstery.Text.Trim)
    End Sub

    Private Sub TxtTempGauge_Leave(sender As Object, e As EventArgs) Handles txtTempGauge.Leave
        txtTempGauge.Text = ReplaceText(txtTempGauge.Text.Trim)
    End Sub

    Private Sub TxtOdometer_Leave(sender As Object, e As EventArgs) Handles txtOdometer.Leave
        txtOdometer.Text = ReplaceText(txtOdometer.Text.Trim)
    End Sub

    Private Sub TxtTransmission_Leave(sender As Object, e As EventArgs) Handles txtTransmission.Leave
        txtTransmission.Text = ReplaceText(txtTransmission.Text.Trim)
    End Sub

    Private Sub TxtTires_Leave(sender As Object, e As EventArgs) Handles txtTires.Leave
        txtTires.Text = ReplaceText(txtTires.Text.Trim)
    End Sub

    Private Sub TxtAcceleration_Leave(sender As Object, e As EventArgs) Handles txtAcceleration.Leave
        txtAcceleration.Text = ReplaceText(txtAcceleration.Text.Trim)
    End Sub

    Private Sub TxtParkLight_Leave(sender As Object, e As EventArgs) Handles txtParkLight.Leave
        txtParkLight.Text = ReplaceText(txtParkLight.Text.Trim)
    End Sub

    Private Sub TxtHorn_Leave(sender As Object, e As EventArgs) Handles txtHorn.Leave
        txtHorn.Text = ReplaceText(txtHorn.Text.Trim)
    End Sub

    Private Sub TxtChassis_Leave(sender As Object, e As EventArgs) Handles txtChassis.Leave
        txtChassis.Text = ReplaceText(txtChassis.Text.Trim)
    End Sub

    Private Sub TxtFrontBumper_Leave(sender As Object, e As EventArgs) Handles txtFrontBumper.Leave
        txtFrontBumper.Text = ReplaceText(txtFrontBumper.Text.Trim)
    End Sub

    Private Sub TxtAmpheres_Leave(sender As Object, e As EventArgs) Handles txtAmpheres.Leave
        txtAmpheres.Text = ReplaceText(txtAmpheres.Text.Trim)
    End Sub

    Private Sub TxtFuel_Leave(sender As Object, e As EventArgs) Handles txtFuel.Leave
        txtFuel.Text = ReplaceText(txtFuel.Text.Trim)
    End Sub

    Private Sub TxtStarter_Leave(sender As Object, e As EventArgs) Handles txtStarter.Leave
        txtStarter.Text = ReplaceText(txtStarter.Text.Trim)
    End Sub

    Private Sub TxtDifferential_Leave(sender As Object, e As EventArgs) Handles txtDifferential.Leave
        txtDifferential.Text = ReplaceText(txtDifferential.Text.Trim)
    End Sub

    Private Sub TxtBrakes_Leave(sender As Object, e As EventArgs) Handles txtBrakes.Leave
        txtBrakes.Text = ReplaceText(txtBrakes.Text.Trim)
    End Sub

    Private Sub TxtWiper_Leave(sender As Object, e As EventArgs) Handles txtWiper.Leave
        txtWiper.Text = ReplaceText(txtWiper.Text.Trim)
    End Sub

    Private Sub TxtBackUp_Leave(sender As Object, e As EventArgs) Handles txtBackUp.Leave
        txtBackUp.Text = ReplaceText(txtBackUp.Text.Trim)
    End Sub

    Private Sub TxtSideMirror_Leave(sender As Object, e As EventArgs) Handles txtSideMirror.Leave
        txtSideMirror.Text = ReplaceText(txtSideMirror.Text.Trim)
    End Sub

    Private Sub TxtBodyFlooring_Leave(sender As Object, e As EventArgs) Handles txtBodyFlooring.Leave
        txtBodyFlooring.Text = ReplaceText(txtBodyFlooring.Text.Trim)
    End Sub

    Private Sub TxtRearBumper_Leave(sender As Object, e As EventArgs) Handles txtRearBumper.Leave
        txtRearBumper.Text = ReplaceText(txtRearBumper.Text.Trim)
    End Sub

    Private Sub TxtOilPressure_Leave(sender As Object, e As EventArgs) Handles txtOilPressure.Leave
        txtOilPressure.Text = ReplaceText(txtOilPressure.Text.Trim)
    End Sub

    Private Sub TxtSpeedometer_Leave(sender As Object, e As EventArgs) Handles txtSpeedometer.Leave
        txtSpeedometer.Text = ReplaceText(txtSpeedometer.Text.Trim)
    End Sub

    Private Sub TxtBodyPaint_Leave(sender As Object, e As EventArgs) Handles txtBodyPaint.Leave
        txtBodyPaint.Text = ReplaceText(txtBodyPaint.Text.Trim)
    End Sub

    Private Sub RRemarks_Leave(sender As Object, e As EventArgs) Handles rRemarks.Leave
        rRemarks.Text = ReplaceText(rRemarks.Text.Trim)
    End Sub
#End Region

    Private Sub DSellingPrice_ValueChanged(sender As Object, e As EventArgs) Handles dSellingPrice.ValueChanged
        dFairMarketValue.Value = dSellingPrice.Value
    End Sub

    Private Sub DLoanablePercent_ValueChanged(sender As Object, e As EventArgs) Handles dLoanablePercent.ValueChanged
        dLoanableValue.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dLoanablePercent.Value / 100)
    End Sub

    Private Sub DFairMarketValue_ValueChanged(sender As Object, e As EventArgs) Handles dFairMarketValue.ValueChanged
        dAppraisedValue.Value = dFairMarketValue.Value * (AppraisedPercent / 100)
        If dFairMarketValue.Value > 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
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
                Dim SQL As String = String.Format("UPDATE appraise_ve SET `status` = 'DELETED' WHERE appraise_num = '{0}'", txtAppraiseNumber.Text)
                If cbxAppraiseFor.Text = "Credit Investigation" Then

                End If
                If ChangeCollateral Then
                    SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                    SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                End If
                DataObject(SQL)
                Logs("Appraise VE", "Cancel", Reason, String.Format("Cancel appraisal for {0} for {1}", cbxMake.Text & " [" & txtPlateNum.Text & "]", cbxAppraiseFor.Text), "", "", CreditNumber)
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
        If cbxAppraiseFor.Text = "Credit Investigation" Then
            If cbxMake.Text = "" Or cbxMake.SelectedIndex = -1 Then
                MsgBox("Please select maker.", MsgBoxStyle.Information, "Info")
                cbxMake.DroppedDown = True
                Exit Sub
            End If
            If cbxType.Text = "" Or cbxType.SelectedIndex = -1 Then
                MsgBox("Please select type.", MsgBoxStyle.Information, "Info")
                cbxType.DroppedDown = True
                Exit Sub
            End If
            If cbxModel.Text = "" Then
                If MsgBoxYes("Model is empty, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    cbxModel.DroppedDown = True
                    Exit Sub
                End If
            End If
            If txtPlateNum.Text = "" Then
                MsgBox("Please fill Plate Number field.", MsgBoxStyle.Information, "Info")
                txtPlateNum.Focus()
                Exit Sub
            End If
            If cbxTransmission.Text = "" Or cbxTransmission.SelectedIndex = -1 Then
                MsgBox("Please select transmission.", MsgBoxStyle.Information, "Info")
                cbxTransmission.DroppedDown = True
                Exit Sub
            End If
            If cbxFuel.Text = "" Or cbxFuel.SelectedIndex = -1 Then
                MsgBox("Please select fuel.", MsgBoxStyle.Information, "Info")
                cbxFuel.DroppedDown = True
                Exit Sub
            End If
            Cursor = Cursors.WaitCursor
            Exist = DataSource(String.Format("SELECT Borrower_Credit(CreditNumber) AS 'Borrower', CINumber, Make, `Type`, Model, Series, PlateNum, Transmission, Fuel, BodyColor, `Year`, EngineNum, ChassisNum, RegistryCert, ORNum FROM collateral_ve WHERE `status` = 'ACTIVE' AND (IF(Make = '{0}',0,0) + IF(`Type` = '{1}',0,0) + IF(Model = '{2}',0,0) + IF(REGEXP_REPLACE(PlateNum, '[^\\\\x20-\\\\x7E]', '') = REGEXP_REPLACE('{3}', '[^\\\\x20-\\\\x7E]', ''),1,0) + IF(ChassisNum = '{4}',1,0) + IF(RegistryCert = '{5}',1,0) + IF(ORNum = '{6}',1,0)) + IF(Borrower_Credit(CreditNumber) = Borrower_Credit('{7}'),1,0) >= 3;", cbxMake.Text, cbxType.Text, cbxModel.Text, txtPlateNum.Text, txtChassisNum.Text, txtRegistryCert.Text, txtORNum.Text, CreditNumber))
            Cursor = Cursors.Default
            If Exist.Rows.Count > 0 Then
                btnHit.Visible = True
                If MsgBoxYes("ROPA might already attached as collateral in other account(s), would you like to continue?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                btnHit.Visible = False
            End If
        End If
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            Dim vEngine As String = If(cbxEngine_G.Checked, "G", If(cbxEngine_F.Checked, "F", If(cbxEngine_P.Checked, "P", "")))
            Dim vSteering As String = If(cbxSteering_G.Checked, "G", If(cbxSteering_F.Checked, "F", If(cbxSteering_P.Checked, "P", "")))
            Dim vClutch As String = If(cbxClutch_G.Checked, "G", If(cbxClutch_F.Checked, "F", If(cbxClutch_P.Checked, "P", "")))
            Dim vHeadLight As String = If(cbxHeadLight_G.Checked, "G", If(cbxHeadLight_F.Checked, "F", If(cbxHeadLight_P.Checked, "P", "")))
            Dim vSignalLight As String = If(cbxSignalLight_G.Checked, "G", If(cbxSignalLight_F.Checked, "F", If(cbxSignalLight_P.Checked, "P", "")))
            Dim vShock As String = If(cbxShock_G.Checked, "G", If(cbxShock_F.Checked, "F", If(cbxShock_P.Checked, "P", "")))
            Dim vUnderchassis As String = If(cbxUnderchassis_G.Checked, "G", If(cbxUnderchassis_F.Checked, "F", If(cbxUnderchassis_P.Checked, "P", "")))
            Dim vUpholstery As String = If(cbxUpholstery_G.Checked, "G", If(cbxUpholstery_F.Checked, "F", If(cbxUpholstery_P.Checked, "P", "")))
            Dim vTempGauge As String = If(cbxTempGauge_G.Checked, "G", If(cbxTempGauge_F.Checked, "F", If(cbxTempGauge_P.Checked, "P", "")))
            Dim vOdometer As String = If(cbxOdometer_G.Checked, "G", If(cbxOdometer_F.Checked, "F", If(cbxOdometer_P.Checked, "P", "")))
            Dim vTransmission As String = If(cbxTransmission_G.Checked, "G", If(cbxTransmission_F.Checked, "F", If(cbxTransmission_P.Checked, "P", "")))
            Dim vAcceleration As String = If(cbxAcceleration_G.Checked, "G", If(cbxAcceleration_F.Checked, "F", If(cbxAcceleration_P.Checked, "P", "")))
            Dim vParkLight As String = If(cbxParkLight_G.Checked, "G", If(cbxParkLight_F.Checked, "F", If(cbxParkLight_P.Checked, "P", "")))
            Dim vHorn As String = If(cbxHorn_G.Checked, "G", If(cbxHorn_F.Checked, "F", If(cbxHorn_P.Checked, "P", "")))
            Dim vChassis As String = If(cbxChassis_G.Checked, "G", If(cbxChassis_F.Checked, "F", If(cbxChassis_P.Checked, "P", "")))
            Dim vFrontBumper As String = If(cbxFrontBumper_G.Checked, "G", If(cbxFrontBumper_F.Checked, "F", If(cbxFrontBumper_P.Checked, "P", "")))
            Dim vAmpheres As String = If(cbxAmpheres_G.Checked, "G", If(cbxAmpheres_F.Checked, "F", If(cbxAmpheres_P.Checked, "P", "")))
            Dim vFuel As String = If(cbxFuel_G.Checked, "G", If(cbxFuel_F.Checked, "F", If(cbxFuel_P.Checked, "P", "")))
            Dim vStarter As String = If(cbxStarter_G.Checked, "G", If(cbxStarter_F.Checked, "F", If(cbxStarter_P.Checked, "P", "")))
            Dim vDifferential As String = If(cbxDifferential_G.Checked, "G", If(cbxDifferential_F.Checked, "F", If(cbxDifferential_P.Checked, "P", "")))
            Dim vBrakes As String = If(cbxBrakes_G.Checked, "G", If(cbxBrakes_F.Checked, "F", If(cbxBrakes_P.Checked, "P", "")))
            Dim vWiper As String = If(cbxWiper_G.Checked, "G", If(cbxWiper_F.Checked, "F", If(cbxWiper_P.Checked, "P", "")))
            Dim vBackUp As String = If(cbxBackUp_G.Checked, "G", If(cbxBackUp_F.Checked, "F", If(cbxBackUp_P.Checked, "P", "")))
            Dim vSideMirror As String = If(cbxSideMirror_G.Checked, "G", If(cbxSideMirror_F.Checked, "F", If(cbxSideMirror_P.Checked, "P", "")))
            Dim vBodyFlooring As String = If(cbxBodyFlooring_G.Checked, "G", If(cbxBodyFlooring_F.Checked, "F", If(cbxBodyFlooring_P.Checked, "P", "")))
            Dim vRearBumper As String = If(cbxRearBumper_G.Checked, "G", If(cbxRearBumper_F.Checked, "F", If(cbxRearBumper_P.Checked, "P", "")))
            Dim vOilPressure As String = If(cbxOilPressure_G.Checked, "G", If(cbxOilPressure_F.Checked, "F", If(cbxOilPressure_P.Checked, "P", "")))
            Dim vSpeedometer As String = If(cbxSpeedometer_G.Checked, "G", If(cbxSpeedometer_F.Checked, "F", If(cbxSpeedometer_P.Checked, "P", "")))
            Dim vBodyPaint As String = If(cbxBodyPaint_G.Checked, "G", If(cbxBodyPaint_F.Checked, "F", If(cbxBodyPaint_P.Checked, "P", "")))

            If btnSave.Text = "&Save" Then
                If AssetNumber = "" Then
                Else
                    For x As Integer = 0 To FrmCreditInvestigation.GridView1.RowCount - 1
                        If AssetNumber = FrmCreditInvestigation.GridView1.GetRowCellValue(x, "AssetNumber") And For_ReApraise = False Then
                            MsgBox(String.Format("Asset Number {0} already exist in the appraisal list, please check your data.", AssetNumber), MsgBoxStyle.Information, "Info")
                            Exit Sub
                        End If
                    Next
                End If
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    GetAppraisal()
                    Dim SQL As String = "INSERT INTO appraise_ve SET"
                    SQL &= String.Format(" appraise_num = '{0}', ", txtAppraiseNumber.Text)
                    SQL &= String.Format(" appraise_date = '{0}', ", FormatDatePicker(dtpDate))
                    SQL &= String.Format(" appraise_by = '{0}', ", cbxAppraisedBy.SelectedValue)
                    SQL &= String.Format(" asset_number = '{0}', ", AssetNumber)
                    SQL &= String.Format(" credit_number = '{0}', ", CreditNumber)
                    SQL &= String.Format(" appraise = '{0}', ", cbxAppraiseFor.Text)
                    SQL &= String.Format(" `Engine` = '{0}', ", vEngine)
                    SQL &= String.Format(" Engine_R = '{0}', ", txtEngine.Text)
                    SQL &= String.Format(" Steering = '{0}', ", vSteering)
                    SQL &= String.Format(" Steering_R = '{0}', ", txtSteering.Text)
                    SQL &= String.Format(" Clutch = '{0}', ", vClutch)
                    SQL &= String.Format(" Clutch_R = '{0}', ", txtClutch.Text)
                    SQL &= String.Format(" HeadLight = '{0}', ", vHeadLight)
                    SQL &= String.Format(" HeadLight_R = '{0}', ", txtHeadLight.Text)
                    SQL &= String.Format(" SignalLight = '{0}', ", vSignalLight)
                    SQL &= String.Format(" SignalLight_R = '{0}', ", txtSignalLight.Text)
                    SQL &= String.Format(" Shock = '{0}', ", vShock)
                    SQL &= String.Format(" Shock_R = '{0}', ", txtShock.Text)
                    SQL &= String.Format(" Underchassis = '{0}', ", vUnderchassis)
                    SQL &= String.Format(" Underchassis_R = '{0}', ", txtUnderchassis.Text)
                    SQL &= String.Format(" Upholstery = '{0}', ", vUpholstery)
                    SQL &= String.Format(" Upholstery_R = '{0}', ", txtUpholstery.Text)
                    SQL &= String.Format(" TempGauge = '{0}', ", vTempGauge)
                    SQL &= String.Format(" TempGauge_R = '{0}', ", txtTempGauge.Text)
                    SQL &= String.Format(" Odometer = '{0}', ", vOdometer)
                    SQL &= String.Format(" Odometer_R = '{0}', ", txtOdometer.Text)
                    SQL &= String.Format(" Transmission = '{0}', ", vTransmission)
                    SQL &= String.Format(" Transmission_R = '{0}', ", txtTransmission.Text)
                    SQL &= String.Format(" Tires = '{0}', ", dTires.Value)
                    SQL &= String.Format(" Tires_R = '{0}', ", txtTires.Text)
                    SQL &= String.Format(" Acceleration = '{0}', ", vAcceleration)
                    SQL &= String.Format(" Acceleration_R = '{0}', ", txtAcceleration.Text)
                    SQL &= String.Format(" ParkLight = '{0}', ", vParkLight)
                    SQL &= String.Format(" ParkLight_R = '{0}', ", txtParkLight.Text)
                    SQL &= String.Format(" Horn = '{0}', ", vHorn)
                    SQL &= String.Format(" Horn_R = '{0}', ", txtHorn.Text)
                    SQL &= String.Format(" Chassis = '{0}', ", vChassis)
                    SQL &= String.Format(" Chassis_R = '{0}', ", txtChassis.Text)
                    SQL &= String.Format(" FrontBumper = '{0}', ", vFrontBumper)
                    SQL &= String.Format(" FrontBumper_R = '{0}', ", txtFrontBumper.Text)
                    SQL &= String.Format(" Ampheres = '{0}', ", vAmpheres)
                    SQL &= String.Format(" Ampheres_R = '{0}', ", txtAmpheres.Text)
                    SQL &= String.Format(" Fuel = '{0}', ", vFuel)
                    SQL &= String.Format(" Fuel_R = '{0}', ", txtFuel.Text)
                    SQL &= String.Format(" Starter = '{0}', ", vStarter)
                    SQL &= String.Format(" Starter_R = '{0}', ", txtStarter.Text)
                    SQL &= String.Format(" Differential = '{0}', ", vDifferential)
                    SQL &= String.Format(" Differential_R = '{0}', ", txtDifferential.Text)
                    SQL &= String.Format(" Brakes = '{0}', ", vBrakes)
                    SQL &= String.Format(" Brakes_R = '{0}', ", txtBrakes.Text)
                    SQL &= String.Format(" Wiper = '{0}', ", vWiper)
                    SQL &= String.Format(" Wiper_R = '{0}', ", txtWiper.Text)
                    SQL &= String.Format(" `BackUp` = '{0}', ", vBackUp)
                    SQL &= String.Format(" BackUp_R = '{0}', ", txtBackUp.Text)
                    SQL &= String.Format(" SideMirror = '{0}', ", vSideMirror)
                    SQL &= String.Format(" SideMirror_R = '{0}', ", txtSideMirror.Text)
                    SQL &= String.Format(" BodyFlooring = '{0}', ", vBodyFlooring)
                    SQL &= String.Format(" BodyFlooring_R = '{0}', ", txtBodyFlooring.Text)
                    SQL &= String.Format(" RearBumper = '{0}', ", vRearBumper)
                    SQL &= String.Format(" RearBumper_R = '{0}', ", txtRearBumper.Text)
                    SQL &= String.Format(" OilPressure = '{0}', ", vOilPressure)
                    SQL &= String.Format(" OilPressure_R = '{0}', ", txtOilPressure.Text)
                    SQL &= String.Format(" Speedometer = '{0}', ", vSpeedometer)
                    SQL &= String.Format(" Speedometer_R = '{0}', ", txtSpeedometer.Text)
                    SQL &= String.Format(" BodyPaint = '{0}', ", vBodyPaint)
                    SQL &= String.Format(" BodyPaint_R = '{0}', ", txtBodyPaint.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                    SQL &= String.Format(" Source = '{0}', ", txtSource.Text)
                    SQL &= String.Format(" telephone_num = '{0}', ", txtTelephoneNum.Text)
                    SQL &= String.Format(" selling_price = '{0}', ", dSellingPrice.Value)
                    SQL &= String.Format(" market_value = '{0}', ", dFairMarketValue.Value)
                    SQL &= String.Format(" appraised_value = '{0}', ", dAppraisedValue.Value)
                    SQL &= String.Format(" loanable_value = '{0}', ", dLoanableValue.Value)
                    SQL &= String.Format(" loanable_percent = '{0}', ", dLoanablePercent.Value)
                    SQL &= String.Format(" BaseMarket = '{0}', ", If(cbxBaseMarket.Checked, 1, 0))
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    If btnROPA.Visible Then
                        SQL &= String.Format(" AppraiseSellingPrice = '{0}',", SellingPrice)
                    End If
                    If cbxAppraiseFor.Text = "Credit Investigation" And For_ReApraise = False Then
                        If CINumber = "" Then
                            SQL &= " `status` = 'PENDING', "
                        Else
                            SQL &= " `status` = 'ACTIVE', "
                        End If
                        CollateralNumber = DataObject(String.Format("SELECT CONCAT('CVE', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM appraise_ve WHERE branch_id = '{0}' AND YEAR(`appraise_date`) = YEAR('{2}') AND MONTH(`appraise_date`) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                    ElseIf For_ReApraise Then
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                    End If
                    SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                    SQL &= String.Format(" user_code = '{0}';", User_Code)
                    If ChangeCollateral Then
                        SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                        SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                    End If
                    If cbxAppraiseFor.Text = "Credit Investigation" And For_ReApraise = False Then
                        SQL &= "INSERT INTO collateral_ve SET"
                        SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber)
                        SQL &= String.Format(" CollateralNumber = '{0}', ", CollateralNumber)
                        SQL &= String.Format(" Make = '{0}', ", cbxMake.Text)
                        SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                        SQL &= String.Format(" `Used` = '{0}', ", cbxUsed.Text)
                        SQL &= String.Format(" Model = '{0}', ", cbxModel.Text)
                        SQL &= String.Format(" Series = '{0}', ", txtSeries.Text)
                        SQL &= String.Format(" PlateNum = '{0}', ", txtPlateNum.Text)
                        SQL &= String.Format(" Transmission = '{0}', ", cbxTransmission.Text)
                        SQL &= String.Format(" Fuel = '{0}', ", cbxFuel.Text)
                        SQL &= String.Format(" BodyColor = '{0}', ", cbxBodyColor.Text)
                        SQL &= String.Format(" `Year` = '{0}', ", If(dtpYear.CustomFormat = "", "", dtpYear.Text))
                        SQL &= String.Format(" EngineNum = '{0}', ", cbxEngineNumber.Text)
                        SQL &= String.Format(" ChassisNum = '{0}', ", txtChassisNum.Text)
                        SQL &= String.Format(" RegistryCert = '{0}', ", txtRegistryCert.Text)
                        SQL &= String.Format(" ORNum = '{0}', ", txtORNum.Text)
                        SQL &= String.Format(" GrossWeight = '{0}', ", dGrossWeight.Value)
                        SQL &= String.Format(" RimHoles = '{0}', ", iRim.Value)
                        SQL &= String.Format(" MileAge = '{0}', ", dMileAge.Value)
                        SQL &= String.Format(" MileAgeType = '{0}', ", cbxMileAge.Text)
                        SQL &= String.Format(" DateRegistered = '{0}', ", FormatDatePicker(dtpRegistered))
                        SQL &= String.Format(" LTO = '{0}', ", txtLTO.Text)
                        SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                        SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                        SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                        If CINumber = "" Then
                            SQL &= " `status` = 'PENDING', "
                        Else
                            SQL &= " `status` = 'ACTIVE', "
                            SQL &= String.Format(" CINumber = '{0}', ", CINumber)
                        End If
                        SQL &= String.Format(" User_Code = '{0}';", User_Code)
                    End If

                    DataObject(SQL)
                    Logs("Appraise VE", "Save", String.Format("Appraise VE {0} for {1}", cbxMake.Text & " [" & txtPlateNum.Text & "]", cbxAppraiseFor.Text), "", "", "", CreditNumber)
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
                    Dim SQL As String = "UPDATE appraise_ve SET"
                    SQL &= String.Format(" appraise_by = '{0}', ", cbxAppraisedBy.SelectedValue)
                    SQL &= String.Format(" `Engine` = '{0}', ", vEngine)
                    SQL &= String.Format(" Engine_R = '{0}', ", txtEngine.Text)
                    SQL &= String.Format(" Steering = '{0}', ", vSteering)
                    SQL &= String.Format(" Steering_R = '{0}', ", txtSteering.Text)
                    SQL &= String.Format(" Clutch = '{0}', ", vClutch)
                    SQL &= String.Format(" Clutch_R = '{0}', ", txtClutch.Text)
                    SQL &= String.Format(" HeadLight = '{0}', ", vHeadLight)
                    SQL &= String.Format(" HeadLight_R = '{0}', ", txtHeadLight.Text)
                    SQL &= String.Format(" SignalLight = '{0}', ", vSignalLight)
                    SQL &= String.Format(" SignalLight_R = '{0}', ", txtSignalLight.Text)
                    SQL &= String.Format(" Shock = '{0}', ", vShock)
                    SQL &= String.Format(" Shock_R = '{0}', ", txtShock.Text)
                    SQL &= String.Format(" Underchassis = '{0}', ", vUnderchassis)
                    SQL &= String.Format(" Underchassis_R = '{0}', ", txtUnderchassis.Text)
                    SQL &= String.Format(" Upholstery = '{0}', ", vUpholstery)
                    SQL &= String.Format(" Upholstery_R = '{0}', ", txtUpholstery.Text)
                    SQL &= String.Format(" TempGauge = '{0}', ", vTempGauge)
                    SQL &= String.Format(" TempGauge_R = '{0}', ", txtTempGauge.Text)
                    SQL &= String.Format(" Odometer = '{0}', ", vOdometer)
                    SQL &= String.Format(" Odometer_R = '{0}', ", txtOdometer.Text)
                    SQL &= String.Format(" Transmission = '{0}', ", vTransmission)
                    SQL &= String.Format(" Transmission_R = '{0}', ", txtTransmission.Text)
                    SQL &= String.Format(" Tires = '{0}', ", dTires.Value)
                    SQL &= String.Format(" Tires_R = '{0}', ", txtTires.Text)
                    SQL &= String.Format(" Acceleration = '{0}', ", vAcceleration)
                    SQL &= String.Format(" Acceleration_R = '{0}', ", txtAcceleration.Text)
                    SQL &= String.Format(" ParkLight = '{0}', ", vParkLight)
                    SQL &= String.Format(" ParkLight_R = '{0}', ", txtParkLight.Text)
                    SQL &= String.Format(" Horn = '{0}', ", vHorn)
                    SQL &= String.Format(" Horn_R = '{0}', ", txtHorn.Text)
                    SQL &= String.Format(" Chassis = '{0}', ", vChassis)
                    SQL &= String.Format(" Chassis_R = '{0}', ", txtChassis.Text)
                    SQL &= String.Format(" FrontBumper = '{0}', ", vFrontBumper)
                    SQL &= String.Format(" FrontBumper_R = '{0}', ", txtFrontBumper.Text)
                    SQL &= String.Format(" Ampheres = '{0}', ", vAmpheres)
                    SQL &= String.Format(" Ampheres_R = '{0}', ", txtAmpheres.Text)
                    SQL &= String.Format(" Fuel = '{0}', ", vFuel)
                    SQL &= String.Format(" Fuel_R = '{0}', ", txtFuel.Text)
                    SQL &= String.Format(" Starter = '{0}', ", vStarter)
                    SQL &= String.Format(" Starter_R = '{0}', ", txtStarter.Text)
                    SQL &= String.Format(" Differential = '{0}', ", vDifferential)
                    SQL &= String.Format(" Differential_R = '{0}', ", txtDifferential.Text)
                    SQL &= String.Format(" Brakes = '{0}', ", vBrakes)
                    SQL &= String.Format(" Brakes_R = '{0}', ", txtBrakes.Text)
                    SQL &= String.Format(" Wiper = '{0}', ", vWiper)
                    SQL &= String.Format(" Wiper_R = '{0}', ", txtWiper.Text)
                    SQL &= String.Format(" `BackUp` = '{0}', ", vBackUp)
                    SQL &= String.Format(" BackUp_R = '{0}', ", txtBackUp.Text)
                    SQL &= String.Format(" SideMirror = '{0}', ", vSideMirror)
                    SQL &= String.Format(" SideMirror_R = '{0}', ", txtSideMirror.Text)
                    SQL &= String.Format(" BodyFlooring = '{0}', ", vBodyFlooring)
                    SQL &= String.Format(" BodyFlooring_R = '{0}', ", txtBodyFlooring.Text)
                    SQL &= String.Format(" RearBumper = '{0}', ", vRearBumper)
                    SQL &= String.Format(" RearBumper_R = '{0}', ", txtRearBumper.Text)
                    SQL &= String.Format(" OilPressure = '{0}', ", vOilPressure)
                    SQL &= String.Format(" OilPressure_R = '{0}', ", txtOilPressure.Text)
                    SQL &= String.Format(" Speedometer = '{0}', ", vSpeedometer)
                    SQL &= String.Format(" Speedometer_R = '{0}', ", txtSpeedometer.Text)
                    SQL &= String.Format(" BodyPaint = '{0}', ", vBodyPaint)
                    SQL &= String.Format(" BodyPaint_R = '{0}', ", txtBodyPaint.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", rRemarks.Text)
                    SQL &= String.Format(" Source = '{0}', ", txtSource.Text)
                    SQL &= String.Format(" telephone_num = '{0}', ", txtTelephoneNum.Text)
                    SQL &= String.Format(" selling_price = '{0}', ", dSellingPrice.Value)
                    SQL &= String.Format(" market_value = '{0}', ", dFairMarketValue.Value)
                    SQL &= String.Format(" appraised_value = '{0}', ", dAppraisedValue.Value)
                    SQL &= String.Format(" loanable_value = '{0}', ", dLoanableValue.Value)
                    SQL &= String.Format(" BaseMarket = '{0}', ", If(cbxBaseMarket.Checked, 1, 0))
                    If btnROPA.Visible Then
                        SQL &= String.Format(" AppraiseSellingPrice = '{0}',", SellingPrice)
                    End If
                    SQL &= String.Format(" loanable_percent = '{0}' ", dLoanablePercent.Value)
                    SQL &= String.Format(" WHERE appraise_num = '{0}';", txtAppraiseNumber.Text)

                    If ChangeCollateral Then
                        SQL &= String.Format(" UPDATE credit_investigation SET ChangeCollateral = 0, CI_Status = 'PENDING' WHERE CINumber = '{0}';", CINumber)
                        SQL &= String.Format(" UPDATE credit_application SET CI_Status = 'ONGOING' WHERE CreditNumber = '{0}';", CreditNumber)
                    End If
                    If cbxAppraiseFor.Text = "Credit Investigation" Then
                        SQL &= "UPDATE collateral_ve SET"
                        SQL &= String.Format(" Make = '{0}', ", cbxMake.Text)
                        SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                        SQL &= String.Format(" `Used` = '{0}', ", cbxUsed.Text)
                        SQL &= String.Format(" Model = '{0}', ", cbxModel.Text)
                        SQL &= String.Format(" Series = '{0}', ", txtSeries.Text)
                        SQL &= String.Format(" PlateNum = '{0}', ", txtPlateNum.Text)
                        SQL &= String.Format(" Transmission = '{0}', ", cbxTransmission.Text)
                        SQL &= String.Format(" Fuel = '{0}', ", cbxFuel.Text)
                        SQL &= String.Format(" BodyColor = '{0}', ", cbxBodyColor.Text)
                        SQL &= String.Format(" `Year` = '{0}', ", If(dtpYear.CustomFormat = "", "", dtpYear.Text))
                        SQL &= String.Format(" EngineNum = '{0}', ", cbxEngineNumber.Text)
                        SQL &= String.Format(" ChassisNum = '{0}', ", txtChassisNum.Text)
                        SQL &= String.Format(" RegistryCert = '{0}', ", txtRegistryCert.Text)
                        SQL &= String.Format(" ORNum = '{0}', ", txtORNum.Text)
                        SQL &= String.Format(" GrossWeight = '{0}', ", dGrossWeight.Value)
                        SQL &= String.Format(" RimHoles = '{0}', ", iRim.Value)
                        SQL &= String.Format(" MileAge = '{0}', ", dMileAge.Value)
                        SQL &= String.Format(" MileAgeType = '{0}', ", cbxMileAge.Text)
                        SQL &= String.Format(" DateRegistered = '{0}', ", FormatDatePicker(dtpRegistered))
                        SQL &= String.Format(" LTO = '{0}', ", txtLTO.Text)
                        SQL &= String.Format(" Remarks = '{0}' ", rRemarks.Text)
                        SQL &= String.Format(" WHERE CollateralNumber = '{0}';", CollateralNumber)
                    End If

                    DataObject(SQL)
                    Logs("Appraise VE", "Update", String.Format("Update Appraisal for VE {0} for {1}", cbxMake.Text & " [" & txtPlateNum.Text & "]", cbxAppraiseFor.Text), Changes, "", "", CreditNumber)
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
                If cbxMake.Text = cbxMake.Tag Then
                Else
                    Change &= String.Format("Change Make from {0} to {1}. ", cbxMake.Tag, cbxMake.Text)
                End If
                If cbxType.Text = cbxType.Tag Then
                Else
                    Change &= String.Format("Change Type from {0} to {1}. ", cbxType.Tag, cbxType.Text)
                End If
                If cbxUsed.Text = cbxUsed.Tag Then
                Else
                    Change &= String.Format("Change Used from {0} to {1}. ", cbxUsed.Tag, cbxUsed.Text)
                End If
                If cbxModel.Text = cbxModel.Tag Then
                Else
                    Change &= String.Format("Change Model from {0} to {1}. ", cbxModel.Tag, cbxModel.Text)
                End If
                If txtSeries.Text = txtSeries.Tag Then
                Else
                    Change &= String.Format("Change Series from {0} to {1}. ", txtSeries.Tag, txtSeries.Text)
                End If
                If txtPlateNum.Text = txtPlateNum.Tag Then
                Else
                    Change &= String.Format("Change Plate Number from {0} to {1}. ", txtPlateNum.Tag, txtPlateNum.Text)
                End If
                If cbxTransmission.Text = cbxTransmission.Tag Then
                Else
                    Change &= String.Format("Change Transmission from {0} to {1}. ", cbxTransmission.Tag, cbxTransmission.Text)
                End If
                If cbxFuel.Text = cbxFuel.Tag Then
                Else
                    Change &= String.Format("Change Fuel from {0} to {1}. ", cbxFuel.Tag, cbxFuel.Text)
                End If
                If cbxBodyColor.Text = cbxBodyColor.Tag Then
                Else
                    Change &= String.Format("Change Body Color from {0} to {1}. ", cbxBodyColor.Tag, cbxBodyColor.Text)
                End If
                If dtpYear.Text.Trim = dtpYear.Tag Then
                Else
                    Change &= String.Format("Change Year from {0} to {1}. ", dtpYear.Tag, dtpYear.Text.Trim)
                End If
                If cbxEngineNumber.Text = cbxEngineNumber.Tag Then
                Else
                    Change &= String.Format("Change Engine Number from {0} to {1}. ", cbxEngineNumber.Tag, cbxEngineNumber.Text)
                End If
                If txtChassis.Text = txtChassis.Tag Then
                Else
                    Change &= String.Format("Change Chassis Number from {0} to {1}. ", txtChassis.Tag, txtChassis.Text)
                End If
                If txtRegistryCert.Text = txtRegistryCert.Tag Then
                Else
                    Change &= String.Format("Change Registry Certificate from {0} to {1}. ", txtRegistryCert.Tag, txtRegistryCert.Text)
                End If
                If txtORNum.Text = txtORNum.Tag Then
                Else
                    Change &= String.Format("Change OR Number from {0} to {1}. ", txtORNum.Tag, txtORNum.Text)
                End If
                If dGrossWeight.Value = dGrossWeight.Tag Then
                Else
                    Change &= String.Format("Change Gross Weight from {0} to {1}. ", dGrossWeight.Tag, dGrossWeight.Text)
                End If
                If iRim.Value = iRim.Tag Then
                Else
                    Change &= String.Format("Change Rim Holes from {0} to {1}. ", iRim.Tag, iRim.Text)
                End If
                If dMileAge.Value = dMileAge.Tag Then
                Else
                    Change &= String.Format("Change Mile Age from {0} to {1}. ", dMileAge.Tag, dMileAge.Text)
                End If
                If cbxMileAge.Text = cbxMileAge.Tag Then
                Else
                    Change &= String.Format("Change Mile Age Type from {0} to {1}. ", cbxMileAge.Tag, cbxMileAge.Text)
                End If
                If Format(dtpRegistered.Value, "MMMM dd, yyyy") = dtpRegistered.Tag Then
                Else
                    Change &= String.Format("Change Last Date Registered from {0} to {1}. ", dtpRegistered.Tag, Format(dtpRegistered.Value, "MMMM dd, yyyy"))
                End If
                If txtLTO.Text = txtLTO.Tag Then
                Else
                    Change &= String.Format("Change LTO Office from {0} to {1}. ", txtLTO.Tag, txtLTO.Text)
                End If
                If rRemarks.Text = rRemarks.Tag Then
                Else
                    Change &= String.Format("Change Remarks from {0} to {1}. ", rRemarks.Tag, rRemarks.Text)
                End If
            End If

            'Engine
            If cbxEngine_G.Tag <> "G" And cbxEngine_G.Checked Then
                Change &= String.Format("Change Engine from {0} to {1}. ", cbxEngine_G.Tag, cbxEngine_G.Text)
            ElseIf cbxEngine_F.Tag <> "F" And cbxEngine_F.Checked Then
                Change &= String.Format("Change Engine from {0} to {1}. ", cbxEngine_F.Tag, cbxEngine_F.Text)
            ElseIf cbxEngine_P.Tag <> "P" And cbxEngine_P.Checked Then
                Change &= String.Format("Change Engine from {0} to {1}. ", cbxEngine_P.Tag, cbxEngine_P.Text)
            End If
            If txtEngine.Text = txtEngine.Tag Then
            Else
                Change &= String.Format("Change Engine Remarks from {0} to {1}. ", txtEngine.Tag, txtEngine.Text)
            End If

            'Steering
            If cbxSteering_G.Tag <> "G" And cbxSteering_G.Checked Then
                Change &= String.Format("Change Steering from {0} to {1}. ", cbxSteering_G.Tag, cbxSteering_G.Text)
            ElseIf cbxSteering_F.Tag <> "F" And cbxSteering_F.Checked Then
                Change &= String.Format("Change Steering from {0} to {1}. ", cbxSteering_F.Tag, cbxSteering_F.Text)
            ElseIf cbxSteering_P.Tag <> "P" And cbxSteering_P.Checked Then
                Change &= String.Format("Change Steering from {0} to {1}. ", cbxSteering_P.Tag, cbxSteering_P.Text)
            End If
            If txtSteering.Text = txtSteering.Tag Then
            Else
                Change &= String.Format("Change Steering Remarks from {0} to {1}. ", txtSteering.Tag, txtSteering.Text)
            End If

            'Clutch
            If cbxClutch_G.Tag <> "G" And cbxClutch_G.Checked Then
                Change &= String.Format("Change Clutch from {0} to {1}. ", cbxClutch_G.Tag, cbxClutch_G.Text)
            ElseIf cbxClutch_F.Tag <> "F" And cbxClutch_F.Checked Then
                Change &= String.Format("Change Clutch from {0} to {1}. ", cbxClutch_F.Tag, cbxClutch_F.Text)
            ElseIf cbxClutch_P.Tag <> "P" And cbxClutch_P.Checked Then
                Change &= String.Format("Change Clutch from {0} to {1}. ", cbxClutch_P.Tag, cbxClutch_P.Text)
            End If
            If txtClutch.Text = txtClutch.Tag Then
            Else
                Change &= String.Format("Change Clutch Remarks from {0} to {1}. ", txtClutch.Tag, txtClutch.Text)
            End If

            'Head Light
            If cbxHeadLight_G.Tag <> "G" And cbxHeadLight_G.Checked Then
                Change &= String.Format("Change Head Light from {0} to {1}. ", cbxHeadLight_G.Tag, cbxHeadLight_G.Text)
            ElseIf cbxHeadLight_F.Tag <> "F" And cbxHeadLight_F.Checked Then
                Change &= String.Format("Change Head Light from {0} to {1}. ", cbxHeadLight_F.Tag, cbxHeadLight_F.Text)
            ElseIf cbxHeadLight_P.Tag <> "P" And cbxHeadLight_P.Checked Then
                Change &= String.Format("Change Head Light from {0} to {1}. ", cbxHeadLight_P.Tag, cbxHeadLight_P.Text)
            End If
            If txtHeadLight.Text = txtHeadLight.Tag Then
            Else
                Change &= String.Format("Change Head Light Remarks from {0} to {1}. ", txtHeadLight.Tag, txtHeadLight.Text)
            End If

            'Signal Light
            If cbxSignalLight_G.Tag <> "G" And cbxSignalLight_G.Checked Then
                Change &= String.Format("Change Signal Light from {0} to {1}. ", cbxSignalLight_G.Tag, cbxSignalLight_G.Text)
            ElseIf cbxSignalLight_F.Tag <> "F" And cbxSignalLight_F.Checked Then
                Change &= String.Format("Change Signal Light from {0} to {1}. ", cbxSignalLight_F.Tag, cbxSignalLight_F.Text)
            ElseIf cbxSignalLight_P.Tag <> "P" And cbxSignalLight_P.Checked Then
                Change &= String.Format("Change Signal Light from {0} to {1}. ", cbxSignalLight_P.Tag, cbxSignalLight_P.Text)
            End If
            If txtSignalLight.Text = txtSignalLight.Tag Then
            Else
                Change &= String.Format("Change Signal Light Remarks from {0} to {1}. ", txtSignalLight.Tag, txtSignalLight.Text)
            End If

            'Shock
            If cbxShock_G.Tag <> "G" And cbxShock_G.Checked Then
                Change &= String.Format("Change Shock from {0} to {1}. ", cbxShock_G.Tag, cbxShock_G.Text)
            ElseIf cbxShock_F.Tag <> "F" And cbxShock_F.Checked Then
                Change &= String.Format("Change Shock from {0} to {1}. ", cbxShock_F.Tag, cbxShock_F.Text)
            ElseIf cbxShock_P.Tag <> "P" And cbxShock_P.Checked Then
                Change &= String.Format("Change Shock from {0} to {1}. ", cbxShock_P.Tag, cbxShock_P.Text)
            End If
            If txtShock.Text = txtShock.Tag Then
            Else
                Change &= String.Format("Change Shock Remarks from {0} to {1}. ", txtShock.Tag, txtShock.Text)
            End If

            'Underchassis
            If cbxUnderchassis_G.Tag <> "G" And cbxUnderchassis_G.Checked Then
                Change &= String.Format("Change Underchassis from {0} to {1}. ", cbxUnderchassis_G.Tag, cbxUnderchassis_G.Text)
            ElseIf cbxUnderchassis_F.Tag <> "F" And cbxUnderchassis_F.Checked Then
                Change &= String.Format("Change Underchassis from {0} to {1}. ", cbxUnderchassis_F.Tag, cbxUnderchassis_F.Text)
            ElseIf cbxUnderchassis_P.Tag <> "P" And cbxUnderchassis_P.Checked Then
                Change &= String.Format("Change Underchassis from {0} to {1}. ", cbxUnderchassis_P.Tag, cbxUnderchassis_P.Text)
            End If
            If txtUnderchassis.Text = txtUnderchassis.Tag Then
            Else
                Change &= String.Format("Change Underchassis Remarks from {0} to {1}. ", txtUnderchassis.Tag, txtUnderchassis.Text)
            End If

            'Upholstery
            If cbxUpholstery_G.Tag <> "G" And cbxUpholstery_G.Checked Then
                Change &= String.Format("Change Upholstery from {0} to {1}. ", cbxUpholstery_G.Tag, cbxUpholstery_G.Text)
            ElseIf cbxUpholstery_F.Tag <> "F" And cbxUpholstery_F.Checked Then
                Change &= String.Format("Change Upholstery from {0} to {1}. ", cbxUpholstery_F.Tag, cbxUpholstery_F.Text)
            ElseIf cbxUpholstery_P.Tag <> "P" And cbxUpholstery_P.Checked Then
                Change &= String.Format("Change Upholstery from {0} to {1}. ", cbxUpholstery_P.Tag, cbxUpholstery_P.Text)
            End If
            If txtUpholstery.Text = txtUpholstery.Tag Then
            Else
                Change &= String.Format("Change Upholstery Remarks from {0} to {1}. ", txtUpholstery.Tag, txtUpholstery.Text)
            End If

            'Temp Gauge
            If cbxTempGauge_G.Tag <> "G" And cbxTempGauge_G.Checked Then
                Change &= String.Format("Change Temp Gauge from {0} to {1}. ", cbxTempGauge_G.Tag, cbxTempGauge_G.Text)
            ElseIf cbxTempGauge_F.Tag <> "F" And cbxTempGauge_F.Checked Then
                Change &= String.Format("Change Temp Gauge from {0} to {1}. ", cbxTempGauge_F.Tag, cbxTempGauge_F.Text)
            ElseIf cbxTempGauge_P.Tag <> "P" And cbxTempGauge_P.Checked Then
                Change &= String.Format("Change Temp Gauge from {0} to {1}. ", cbxTempGauge_P.Tag, cbxTempGauge_P.Text)
            End If
            If txtTempGauge.Text = txtTempGauge.Tag Then
            Else
                Change &= String.Format("Change Temp Gauge Remarks from {0} to {1}. ", txtTempGauge.Tag, txtTempGauge.Text)
            End If

            'Odometer
            If cbxOdometer_G.Tag <> "G" And cbxOdometer_G.Checked Then
                Change &= String.Format("Change Odometer from {0} to {1}. ", cbxOdometer_G.Tag, cbxOdometer_G.Text)
            ElseIf cbxOdometer_F.Tag <> "F" And cbxOdometer_F.Checked Then
                Change &= String.Format("Change Odometer from {0} to {1}. ", cbxOdometer_F.Tag, cbxOdometer_F.Text)
            ElseIf cbxOdometer_P.Tag <> "P" And cbxOdometer_P.Checked Then
                Change &= String.Format("Change Odometer from {0} to {1}. ", cbxOdometer_P.Tag, cbxOdometer_P.Text)
            End If
            If txtOdometer.Text = txtOdometer.Tag Then
            Else
                Change &= String.Format("Change Odometer Remarks from {0} to {1}. ", txtOdometer.Tag, txtOdometer.Text)
            End If

            'Transmission
            If cbxTransmission_G.Tag <> "G" And cbxTransmission_G.Checked Then
                Change &= String.Format("Change Transmission from {0} to {1}. ", cbxTransmission_G.Tag, cbxTransmission_G.Text)
            ElseIf cbxTransmission_F.Tag <> "F" And cbxTransmission_F.Checked Then
                Change &= String.Format("Change Transmission from {0} to {1}. ", cbxTransmission_F.Tag, cbxTransmission_F.Text)
            ElseIf cbxTransmission_P.Tag <> "P" And cbxTransmission_P.Checked Then
                Change &= String.Format("Change Transmission from {0} to {1}. ", cbxTransmission_P.Tag, cbxTransmission_P.Text)
            End If
            If txtTransmission.Text = txtTransmission.Tag Then
            Else
                Change &= String.Format("Change Transmission Remarks from {0} to {1}. ", txtTransmission.Tag, txtTransmission.Text)
            End If

            'Tires
            If dTires.Value = dTires.Tag Then
            Else
                Change &= String.Format("Change Tire Depth from {0} to {1}. ", dTires.Tag, dTires.Value)
            End If
            If txtTires.Text = txtTires.Tag Then
            Else
                Change &= String.Format("Change Tire Remarks from {0} to {1}. ", txtTires.Tag, txtTires.Text)
            End If

            'Acceleration
            If cbxAcceleration_G.Tag <> "G" And cbxAcceleration_G.Checked Then
                Change &= String.Format("Change Acceleration from {0} to {1}. ", cbxAcceleration_G.Tag, cbxAcceleration_G.Text)
            ElseIf cbxAcceleration_F.Tag <> "F" And cbxAcceleration_F.Checked Then
                Change &= String.Format("Change Acceleration from {0} to {1}. ", cbxAcceleration_F.Tag, cbxAcceleration_F.Text)
            ElseIf cbxAcceleration_P.Tag <> "P" And cbxAcceleration_P.Checked Then
                Change &= String.Format("Change Acceleration from {0} to {1}. ", cbxAcceleration_P.Tag, cbxAcceleration_P.Text)
            End If
            If txtAcceleration.Text = txtAcceleration.Tag Then
            Else
                Change &= String.Format("Change Acceleration Remarks from {0} to {1}. ", txtAcceleration.Tag, txtAcceleration.Text)
            End If

            'Park Light
            If cbxParkLight_G.Tag <> "G" And cbxParkLight_G.Checked Then
                Change &= String.Format("Change Park Light from {0} to {1}. ", cbxParkLight_G.Tag, cbxParkLight_G.Text)
            ElseIf cbxParkLight_F.Tag <> "F" And cbxParkLight_F.Checked Then
                Change &= String.Format("Change Park Light from {0} to {1}. ", cbxParkLight_F.Tag, cbxParkLight_F.Text)
            ElseIf cbxParkLight_P.Tag <> "P" And cbxParkLight_P.Checked Then
                Change &= String.Format("Change Park Light from {0} to {1}. ", cbxParkLight_P.Tag, cbxParkLight_P.Text)
            End If
            If txtParkLight.Text = txtParkLight.Tag Then
            Else
                Change &= String.Format("Change Park Light Remarks from {0} to {1}. ", txtParkLight.Tag, txtParkLight.Text)
            End If

            'Horn
            If cbxHorn_G.Tag <> "G" And cbxHorn_G.Checked Then
                Change &= String.Format("Change Horn from {0} to {1}. ", cbxHorn_G.Tag, cbxHorn_G.Text)
            ElseIf cbxHorn_F.Tag <> "F" And cbxHorn_F.Checked Then
                Change &= String.Format("Change Horn from {0} to {1}. ", cbxHorn_F.Tag, cbxHorn_F.Text)
            ElseIf cbxHorn_P.Tag <> "P" And cbxHorn_P.Checked Then
                Change &= String.Format("Change Horn from {0} to {1}. ", cbxHorn_P.Tag, cbxHorn_P.Text)
            End If
            If txtHorn.Text = txtHorn.Tag Then
            Else
                Change &= String.Format("Change Horn Remarks from {0} to {1}. ", txtHorn.Tag, txtHorn.Text)
            End If

            'Chassis
            If cbxChassis_G.Tag <> "G" And cbxChassis_G.Checked Then
                Change &= String.Format("Change Chassis from {0} to {1}. ", cbxChassis_G.Tag, cbxChassis_G.Text)
            ElseIf cbxChassis_F.Tag <> "F" And cbxChassis_F.Checked Then
                Change &= String.Format("Change Chassis from {0} to {1}. ", cbxChassis_F.Tag, cbxChassis_F.Text)
            ElseIf cbxChassis_P.Tag <> "P" And cbxChassis_P.Checked Then
                Change &= String.Format("Change Chassis from {0} to {1}. ", cbxChassis_P.Tag, cbxChassis_P.Text)
            End If
            If txtChassis.Text = txtChassis.Tag Then
            Else
                Change &= String.Format("Change Chassis Remarks from {0} to {1}. ", txtChassis.Tag, txtChassis.Text)
            End If

            'Front Bumper
            If cbxFrontBumper_G.Tag <> "G" And cbxFrontBumper_G.Checked Then
                Change &= String.Format("Change Front Bumper from {0} to {1}. ", cbxFrontBumper_G.Tag, cbxFrontBumper_G.Text)
            ElseIf cbxFrontBumper_F.Tag <> "F" And cbxFrontBumper_F.Checked Then
                Change &= String.Format("Change Front Bumper from {0} to {1}. ", cbxFrontBumper_F.Tag, cbxFrontBumper_F.Text)
            ElseIf cbxFrontBumper_P.Tag <> "P" And cbxFrontBumper_P.Checked Then
                Change &= String.Format("Change Front Bumper from {0} to {1}. ", cbxFrontBumper_P.Tag, cbxFrontBumper_P.Text)
            End If
            If txtFrontBumper.Text = txtFrontBumper.Tag Then
            Else
                Change &= String.Format("Change Front Bumper Remarks from {0} to {1}. ", txtFrontBumper.Tag, txtFrontBumper.Text)
            End If

            'Ampheres
            If cbxAmpheres_G.Tag <> "G" And cbxAmpheres_G.Checked Then
                Change &= String.Format("Change Ampheres from {0} to {1}. ", cbxAmpheres_G.Tag, cbxAmpheres_G.Text)
            ElseIf cbxAmpheres_F.Tag <> "F" And cbxAmpheres_F.Checked Then
                Change &= String.Format("Change Ampheres from {0} to {1}. ", cbxAmpheres_F.Tag, cbxAmpheres_F.Text)
            ElseIf cbxAmpheres_P.Tag <> "P" And cbxAmpheres_P.Checked Then
                Change &= String.Format("Change Ampheres from {0} to {1}. ", cbxAmpheres_P.Tag, cbxAmpheres_P.Text)
            End If
            If txtAmpheres.Text = txtAmpheres.Tag Then
            Else
                Change &= String.Format("Change Ampheres Remarks from {0} to {1}. ", txtAmpheres.Tag, txtAmpheres.Text)
            End If

            'Fuel
            If cbxFuel_G.Tag <> "G" And cbxFuel_G.Checked Then
                Change &= String.Format("Change Fuel from {0} to {1}. ", cbxFuel_G.Tag, cbxFuel_G.Text)
            ElseIf cbxFuel_F.Tag <> "F" And cbxFuel_F.Checked Then
                Change &= String.Format("Change Fuel from {0} to {1}. ", cbxFuel_F.Tag, cbxFuel_F.Text)
            ElseIf cbxFuel_P.Tag <> "P" And cbxFuel_P.Checked Then
                Change &= String.Format("Change Fuel from {0} to {1}. ", cbxFuel_P.Tag, cbxFuel_P.Text)
            End If
            If txtFuel.Text = txtFuel.Tag Then
            Else
                Change &= String.Format("Change Fuel Remarks from {0} to {1}. ", txtFuel.Tag, txtFuel.Text)
            End If

            'Starter
            If cbxStarter_G.Tag <> "G" And cbxStarter_G.Checked Then
                Change &= String.Format("Change Starter from {0} to {1}. ", cbxStarter_G.Tag, cbxStarter_G.Text)
            ElseIf cbxStarter_F.Tag <> "F" And cbxStarter_F.Checked Then
                Change &= String.Format("Change Starter from {0} to {1}. ", cbxStarter_F.Tag, cbxStarter_F.Text)
            ElseIf cbxStarter_P.Tag <> "P" And cbxStarter_P.Checked Then
                Change &= String.Format("Change Starter from {0} to {1}. ", cbxStarter_P.Tag, cbxStarter_P.Text)
            End If
            If txtStarter.Text = txtStarter.Tag Then
            Else
                Change &= String.Format("Change Starter Remarks from {0} to {1}. ", txtStarter.Tag, txtStarter.Text)
            End If

            'Differential
            If cbxDifferential_G.Tag <> "G" And cbxDifferential_G.Checked Then
                Change &= String.Format("Change Differential from {0} to {1}. ", cbxDifferential_G.Tag, cbxDifferential_G.Text)
            ElseIf cbxDifferential_F.Tag <> "F" And cbxDifferential_F.Checked Then
                Change &= String.Format("Change Differential from {0} to {1}. ", cbxDifferential_F.Tag, cbxDifferential_F.Text)
            ElseIf cbxDifferential_P.Tag <> "P" And cbxDifferential_P.Checked Then
                Change &= String.Format("Change Differential from {0} to {1}. ", cbxDifferential_P.Tag, cbxDifferential_P.Text)
            End If
            If txtDifferential.Text = txtDifferential.Tag Then
            Else
                Change &= String.Format("Change Differential Remarks from {0} to {1}. ", txtDifferential.Tag, txtDifferential.Text)
            End If

            'Brakes
            If cbxBrakes_G.Tag <> "G" And cbxBrakes_G.Checked Then
                Change &= String.Format("Change Brakes from {0} to {1}. ", cbxBrakes_G.Tag, cbxBrakes_G.Text)
            ElseIf cbxBrakes_F.Tag <> "F" And cbxBrakes_F.Checked Then
                Change &= String.Format("Change Brakes from {0} to {1}. ", cbxBrakes_F.Tag, cbxBrakes_F.Text)
            ElseIf cbxBrakes_P.Tag <> "P" And cbxBrakes_P.Checked Then
                Change &= String.Format("Change Brakes from {0} to {1}. ", cbxBrakes_P.Tag, cbxBrakes_P.Text)
            End If
            If txtBrakes.Text = txtBrakes.Tag Then
            Else
                Change &= String.Format("Change Brakes Remarks from {0} to {1}. ", txtBrakes.Tag, txtBrakes.Text)
            End If

            'Wiper
            If cbxWiper_G.Tag <> "G" And cbxWiper_G.Checked Then
                Change &= String.Format("Change Wiper from {0} to {1}. ", cbxWiper_G.Tag, cbxWiper_G.Text)
            ElseIf cbxWiper_F.Tag <> "F" And cbxWiper_F.Checked Then
                Change &= String.Format("Change Wiper from {0} to {1}. ", cbxWiper_F.Tag, cbxWiper_F.Text)
            ElseIf cbxWiper_P.Tag <> "P" And cbxWiper_P.Checked Then
                Change &= String.Format("Change Wiper from {0} to {1}. ", cbxWiper_P.Tag, cbxWiper_P.Text)
            End If
            If txtWiper.Text = txtWiper.Tag Then
            Else
                Change &= String.Format("Change Wiper Remarks from {0} to {1}. ", txtWiper.Tag, txtWiper.Text)
            End If

            'BackUp
            If cbxBackUp_G.Tag <> "G" And cbxBackUp_G.Checked Then
                Change &= String.Format("Change Back Up from {0} to {1}. ", cbxBackUp_G.Tag, cbxBackUp_G.Text)
            ElseIf cbxBackUp_F.Tag <> "F" And cbxBackUp_F.Checked Then
                Change &= String.Format("Change Back Up from {0} to {1}. ", cbxBackUp_F.Tag, cbxBackUp_F.Text)
            ElseIf cbxBackUp_P.Tag <> "P" And cbxBackUp_P.Checked Then
                Change &= String.Format("Change Back Up from {0} to {1}. ", cbxBackUp_P.Tag, cbxBackUp_P.Text)
            End If
            If txtBackUp.Text = txtBackUp.Tag Then
            Else
                Change &= String.Format("Change Back Up Remarks from {0} to {1}. ", txtBackUp.Tag, txtBackUp.Text)
            End If

            'Side Mirror
            If cbxSideMirror_G.Tag <> "G" And cbxSideMirror_G.Checked Then
                Change &= String.Format("Change Side Mirror from {0} to {1}. ", cbxSideMirror_G.Tag, cbxSideMirror_G.Text)
            ElseIf cbxSideMirror_F.Tag <> "F" And cbxSideMirror_F.Checked Then
                Change &= String.Format("Change Side Mirror from {0} to {1}. ", cbxSideMirror_F.Tag, cbxSideMirror_F.Text)
            ElseIf cbxSideMirror_P.Tag <> "P" And cbxSideMirror_P.Checked Then
                Change &= String.Format("Change Side Mirror from {0} to {1}. ", cbxSideMirror_P.Tag, cbxSideMirror_P.Text)
            End If
            If txtSideMirror.Text = txtSideMirror.Tag Then
            Else
                Change &= String.Format("Change Side Mirror Remarks from {0} to {1}. ", txtSideMirror.Tag, txtSideMirror.Text)
            End If

            'Body Flooring
            If cbxBodyFlooring_G.Tag <> "G" And cbxBodyFlooring_G.Checked Then
                Change &= String.Format("Change Body Flooring from {0} to {1}. ", cbxBodyFlooring_G.Tag, cbxBodyFlooring_G.Text)
            ElseIf cbxBodyFlooring_F.Tag <> "F" And cbxBodyFlooring_F.Checked Then
                Change &= String.Format("Change Body Flooring from {0} to {1}. ", cbxBodyFlooring_F.Tag, cbxBodyFlooring_F.Text)
            ElseIf cbxBodyFlooring_P.Tag <> "P" And cbxBodyFlooring_P.Checked Then
                Change &= String.Format("Change Body Flooring from {0} to {1}. ", cbxBodyFlooring_P.Tag, cbxBodyFlooring_P.Text)
            End If
            If txtBodyFlooring.Text = txtBodyFlooring.Tag Then
            Else
                Change &= String.Format("Change Body Flooring Remarks from {0} to {1}. ", txtBodyFlooring.Tag, txtBodyFlooring.Text)
            End If

            'Rear Bumper
            If cbxRearBumper_G.Tag <> "G" And cbxRearBumper_G.Checked Then
                Change &= String.Format("Change Rear Bumper from {0} to {1}. ", cbxRearBumper_G.Tag, cbxRearBumper_G.Text)
            ElseIf cbxRearBumper_F.Tag <> "F" And cbxRearBumper_F.Checked Then
                Change &= String.Format("Change Rear Bumper from {0} to {1}. ", cbxRearBumper_F.Tag, cbxRearBumper_F.Text)
            ElseIf cbxRearBumper_P.Tag <> "P" And cbxRearBumper_P.Checked Then
                Change &= String.Format("Change Rear Bumper from {0} to {1}. ", cbxRearBumper_P.Tag, cbxRearBumper_P.Text)
            End If
            If txtRearBumper.Text = txtRearBumper.Tag Then
            Else
                Change &= String.Format("Change Rear Bumper Remarks from {0} to {1}. ", txtRearBumper.Tag, txtRearBumper.Text)
            End If

            'Oil Pressure
            If cbxOilPressure_G.Tag <> "G" And cbxOilPressure_G.Checked Then
                Change &= String.Format("Change Oil Pressure from {0} to {1}. ", cbxOilPressure_G.Tag, cbxOilPressure_G.Text)
            ElseIf cbxOilPressure_F.Tag <> "F" And cbxOilPressure_F.Checked Then
                Change &= String.Format("Change Oil Pressure from {0} to {1}. ", cbxOilPressure_F.Tag, cbxOilPressure_F.Text)
            ElseIf cbxOilPressure_P.Tag <> "P" And cbxOilPressure_P.Checked Then
                Change &= String.Format("Change Oil Pressure from {0} to {1}. ", cbxOilPressure_P.Tag, cbxOilPressure_P.Text)
            End If
            If txtOilPressure.Text = txtOilPressure.Tag Then
            Else
                Change &= String.Format("Change Oil Pressure Remarks from {0} to {1}. ", txtOilPressure.Tag, txtOilPressure.Text)
            End If

            'Speedometer
            If cbxSpeedometer_G.Tag <> "G" And cbxSpeedometer_G.Checked Then
                Change &= String.Format("Change Speedometer from {0} to {1}. ", cbxSpeedometer_G.Tag, cbxSpeedometer_G.Text)
            ElseIf cbxSpeedometer_F.Tag <> "F" And cbxSpeedometer_F.Checked Then
                Change &= String.Format("Change Speedometer from {0} to {1}. ", cbxSpeedometer_F.Tag, cbxSpeedometer_F.Text)
            ElseIf cbxSpeedometer_P.Tag <> "P" And cbxSpeedometer_P.Checked Then
                Change &= String.Format("Change Speedometer from {0} to {1}. ", cbxSpeedometer_P.Tag, cbxSpeedometer_P.Text)
            End If
            If txtSpeedometer.Text = txtSpeedometer.Tag Then
            Else
                Change &= String.Format("Change Speedometer Remarks from {0} to {1}. ", txtSpeedometer.Tag, txtSpeedometer.Text)
            End If

            'Body Paint
            If cbxBodyPaint_G.Tag <> "G" And cbxBodyPaint_G.Checked Then
                Change &= String.Format("Change Body Paint from {0} to {1}. ", cbxBodyPaint_G.Tag, cbxBodyPaint_G.Text)
            ElseIf cbxBodyPaint_F.Tag <> "F" And cbxBodyPaint_F.Checked Then
                Change &= String.Format("Change Body Paint from {0} to {1}. ", cbxBodyPaint_F.Tag, cbxBodyPaint_F.Text)
            ElseIf cbxBodyPaint_P.Tag <> "P" And cbxBodyPaint_P.Checked Then
                Change &= String.Format("Change Body Paint from {0} to {1}. ", cbxBodyPaint_P.Tag, cbxBodyPaint_P.Text)
            End If
            If txtBodyPaint.Text = txtBodyPaint.Tag Then
            Else
                Change &= String.Format("Change Body Paint Remarks from {0} to {1}. ", txtBodyPaint.Tag, txtBodyPaint.Text)
            End If

            If rRemarks.Text = rRemarks.Tag Then
            Else
                Change &= String.Format("Change Appraisers Remarks Remarks from {0} to {1}. ", rRemarks.Tag, rRemarks.Text)
            End If
            If txtSource.Text = txtSource.Tag Then
            Else
                Change &= String.Format("Change Source from {0} to {1}. ", txtSource.Tag, txtSource.Text)
            End If
            If txtTelephoneNum.Text = txtTelephoneNum.Tag Then
            Else
                Change &= String.Format("Change Source Telephone from {0} to {1}. ", txtTelephoneNum.Tag, txtTelephoneNum.Text)
            End If
            If dSellingPrice.Value = dSellingPrice.Tag Then
            Else
                Change &= String.Format("Change Selling Price from {0} to {1}. ", dSellingPrice.Tag, dSellingPrice.Value)
            End If
            If dFairMarketValue.Value = dFairMarketValue.Tag Then
            Else
                Change &= String.Format("Change Market Value from {0} to {1}. ", dFairMarketValue.Tag, dFairMarketValue.Value)
            End If
            If dAppraisedValue.Value = dAppraisedValue.Tag Then
            Else
                Change &= String.Format("Change Appraised Value from {0} to {1}. ", dAppraisedValue.Tag, dAppraisedValue.Value)
            End If
            If cbxAppraiseFor.Text = "ROPOA" Then
            Else
                If dLoanableValue.Value = dLoanableValue.Tag Then
                Else
                    Change &= String.Format("Change Loanable Value from {0} to {1}. ", dLoanableValue.Tag, dLoanableValue.Value)
                End If
                If dLoanablePercent.Value = dLoanablePercent.Tag Then
                Else
                    Change &= String.Format("Change Loanable Percent from {0} to {1}. ", dLoanablePercent.Tag, dLoanablePercent.Value)
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("Vehicle Appraisal - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub CbxMake_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMake.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        'cbxModel.ValueMember = "ID"
        'cbxModel.DisplayMember = "Model"
        'cbxModel.DataSource = DataSource(String.Format("SELECT ID, Model FROM model_setup WHERE make_id = '{0}' AND `status` = 'ACTIVE' ORDER BY Model;", cbxMake.SelectedValue))
        'cbxModel.SelectedIndex = -1
    End Sub

    Private Sub CbxAppraiseFor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAppraiseFor.SelectedIndexChanged
        If cbxAppraiseFor.Text = "ROPOA" Then
            LabelX59.Visible = False
            LabelX58.Visible = False
            dLoanableValue.Visible = False
            dLoanablePercent.Visible = False
            LabelX60.Visible = False
        Else
            LabelX59.Visible = True
            LabelX58.Visible = True
            dLoanableValue.Visible = True
            dLoanablePercent.Visible = True
            LabelX60.Visible = True
        End If
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetAppraisal()
    End Sub

    Private Sub GetAppraisal()
        txtAppraiseNumber.Text = DataObject(String.Format("SELECT CONCAT('APV', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM appraise_ve WHERE branch_id = '{0}' AND YEAR(appraise_date) = YEAR('{2}') AND MONTH(appraise_date) = MONTH('{2}');", Branch_ID, Format(dtpDate.Value, "yyyyMM"), Format(dtpDate.Value, "yyyy-MM-dd")))
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

            PanelEx2.Enabled = True
            If cbxAppraiseFor.Text = "Credit Investigation" Then
                PanelEx1.Enabled = True
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
        Dim Report As New RptAppraisalVE
        With Report
            .Name = txtAppraiseNumber.Text
            .lblDate.Text = dtpDate.Text
            .lblAppaiseNum.Text = txtAppraiseNumber.Text
            .lblAppraiseFor.Text = cbxAppraiseFor.Text
            .lblAppraisedBy.Text = cbxAppraisedBy.Text
            .lblMake.Text = cbxMake.Text
            .lblType.Text = cbxType.Text
            .lblEngine.Text = cbxModel.Text & " " & txtSeries.Text
            .lblPlateNumber.Text = txtPlateNum.Text
            .lblTransmission.Text = cbxTransmission.Text
            .lblGasoline.Text = cbxFuel.Text
            .lblBodyColor.Text = cbxBodyColor.Text
            .lblYear.Text = dtpYear.Text.Trim
            .lblMotorNumber.Text = cbxEngineNumber.Text
            .lblSerialNumber.Text = txtChassisNum.Text
            .lblRegCertNumber.Text = txtRegistryCert.Text
            .lblORNumber.Text = txtORNum.Text
            .lblGrossWeight.Text = dGrossWeight.Text & " kgs"
            .lblRim.Text = iRim.Value
            .lblMileAge.Text = cbxMileAge.Text
            .cbxEngine_G.Checked = cbxEngine_G.Checked
            .cbxEngine_F.Checked = cbxEngine_F.Checked
            .cbxEngine_P.Checked = cbxEngine_P.Checked
            .txtEngine.Text = txtEngine.Text
            .cbxSteering_G.Checked = cbxSteering_G.Checked
            .cbxSteering_F.Checked = cbxSteering_F.Checked
            .cbxSteering_P.Checked = cbxSteering_P.Checked
            .txtSteering.Text = txtSteering.Text
            .cbxClutch_G.Checked = cbxClutch_G.Checked
            .cbxClutch_F.Checked = cbxClutch_F.Checked
            .cbxClutch_P.Checked = cbxClutch_P.Checked
            .txtClutch.Text = txtClutch.Text
            .cbxHeadLight_G.Checked = cbxHeadLight_G.Checked
            .cbxHeadLight_F.Checked = cbxHeadLight_F.Checked
            .cbxHeadLight_P.Checked = cbxHeadLight_P.Checked
            .txtHeadLight.Text = txtHeadLight.Text
            .cbxSignalLight_G.Checked = cbxSignalLight_G.Checked
            .cbxSignalLight_F.Checked = cbxSignalLight_F.Checked
            .cbxSignalLight_P.Checked = cbxSignalLight_P.Checked
            .txtSignalLight.Text = txtSignalLight.Text
            .cbxShock_G.Checked = cbxShock_G.Checked
            .cbxShock_F.Checked = cbxShock_F.Checked
            .cbxShock_P.Checked = cbxShock_P.Checked
            .txtShock.Text = txtShock.Text
            .cbxUnderchassis_G.Checked = cbxUnderchassis_G.Checked
            .cbxUnderchassis_F.Checked = cbxUnderchassis_F.Checked
            .cbxUnderchassis_P.Checked = cbxUnderchassis_P.Checked
            .txtUnderchassis.Text = txtUnderchassis.Text
            .cbxUpholstery_G.Checked = cbxUpholstery_G.Checked
            .cbxUpholstery_F.Checked = cbxUpholstery_F.Checked
            .cbxUpholstery_P.Checked = cbxUpholstery_P.Checked
            .txtUpholstery.Text = txtUpholstery.Text
            .cbxTempGauge_G.Checked = cbxTempGauge_G.Checked
            .cbxTempGauge_F.Checked = cbxTempGauge_F.Checked
            .cbxTempGauge_P.Checked = cbxTempGauge_P.Checked
            .txtTempGauge.Text = txtTempGauge.Text
            .cbxOdometer_G.Checked = cbxOdometer_G.Checked
            .cbxOdometer_F.Checked = cbxOdometer_F.Checked
            .cbxOdometer_P.Checked = cbxOdometer_P.Checked
            .txtOdometer.Text = txtOdometer.Text
            .cbxTransmission_G.Checked = cbxTransmission_G.Checked
            .cbxTransmission_F.Checked = cbxTransmission_F.Checked
            .cbxTransmission_P.Checked = cbxTransmission_P.Checked
            .txtTransmission.Text = txtTransmission.Text
            .dTires.Text = dTires.Text & "%"
            .txtTires.Text = txtTires.Text
            .cbxAcceleration_G.Checked = cbxAcceleration_G.Checked
            .cbxAcceleration_F.Checked = cbxAcceleration_F.Checked
            .cbxAcceleration_P.Checked = cbxAcceleration_P.Checked
            .txtAcceleration.Text = txtAcceleration.Text
            .cbxParkLight_G.Checked = cbxParkLight_G.Checked
            .cbxParkLight_F.Checked = cbxParkLight_F.Checked
            .cbxParkLight_P.Checked = cbxParkLight_P.Checked
            .txtParkLight.Text = txtParkLight.Text
            .cbxHorn_G.Checked = cbxHorn_G.Checked
            .cbxHorn_F.Checked = cbxHorn_F.Checked
            .cbxHorn_P.Checked = cbxHorn_P.Checked
            .txtHorn.Text = txtHorn.Text
            .cbxChassis_G.Checked = cbxChassis_G.Checked
            .cbxChassis_F.Checked = cbxChassis_F.Checked
            .cbxChassis_P.Checked = cbxChassis_P.Checked
            .txtChassis.Text = txtChassis.Text
            .cbxFrontBumper_G.Checked = cbxFrontBumper_G.Checked
            .cbxFrontBumper_F.Checked = cbxFrontBumper_F.Checked
            .cbxFrontBumper_P.Checked = cbxFrontBumper_P.Checked
            .txtFrontBumper.Text = txtFrontBumper.Text
            .cbxAmpheres_G.Checked = cbxAmpheres_G.Checked
            .cbxAmpheres_F.Checked = cbxAmpheres_F.Checked
            .cbxAmpheres_P.Checked = cbxAmpheres_P.Checked
            .txtAmpheres.Text = txtAmpheres.Text
            .cbxFuel_G.Checked = cbxFuel_G.Checked
            .cbxFuel_F.Checked = cbxFuel_F.Checked
            .cbxFuel_P.Checked = cbxFuel_P.Checked
            .txtFuel.Text = txtFuel.Text
            .cbxStarter_G.Checked = cbxStarter_G.Checked
            .cbxStarter_F.Checked = cbxStarter_F.Checked
            .cbxStarter_P.Checked = cbxStarter_P.Checked
            .txtStarter.Text = txtStarter.Text
            .cbxDifferential_G.Checked = cbxDifferential_G.Checked
            .cbxDifferential_F.Checked = cbxDifferential_F.Checked
            .cbxDifferential_P.Checked = cbxDifferential_P.Checked
            .txtDifferential.Text = txtDifferential.Text
            .cbxBrakes_G.Checked = cbxBrakes_G.Checked
            .cbxBrakes_F.Checked = cbxBrakes_F.Checked
            .cbxBrakes_P.Checked = cbxBrakes_P.Checked
            .txtBrakes.Text = txtBrakes.Text
            .cbxWiper_G.Checked = cbxWiper_G.Checked
            .cbxWiper_F.Checked = cbxWiper_F.Checked
            .cbxWiper_P.Checked = cbxWiper_P.Checked
            .txtWiper.Text = txtWiper.Text
            .cbxBackUp_G.Checked = cbxBackUp_G.Checked
            .cbxBackUp_F.Checked = cbxBackUp_F.Checked
            .cbxBackUp_P.Checked = cbxBackUp_P.Checked
            .txtBackUp.Text = txtBackUp.Text
            .cbxSideMirror_G.Checked = cbxSideMirror_G.Checked
            .cbxSideMirror_F.Checked = cbxSideMirror_F.Checked
            .cbxSideMirror_P.Checked = cbxSideMirror_P.Checked
            .txtSideMirror.Text = txtSideMirror.Text
            .cbxBodyFlooring_G.Checked = cbxBodyFlooring_G.Checked
            .cbxBodyFlooring_F.Checked = cbxBodyFlooring_F.Checked
            .cbxBodyFlooring_P.Checked = cbxBodyFlooring_P.Checked
            .txtBodyFlooring.Text = txtBodyFlooring.Text
            .cbxRearBumper_G.Checked = cbxRearBumper_G.Checked
            .cbxRearBumper_F.Checked = cbxRearBumper_F.Checked
            .cbxRearBumper_P.Checked = cbxRearBumper_P.Checked
            .txtRearBumper.Text = txtRearBumper.Text
            .cbxOilPressure_G.Checked = cbxOilPressure_G.Checked
            .cbxOilPressure_F.Checked = cbxOilPressure_F.Checked
            .cbxOilPressure_P.Checked = cbxOilPressure_P.Checked
            .txtOilPressure.Text = txtOilPressure.Text
            .cbxSpeedometer_G.Checked = cbxSpeedometer_G.Checked
            .cbxSpeedometer_F.Checked = cbxSpeedometer_F.Checked
            .cbxSpeedometer_P.Checked = cbxSpeedometer_P.Checked
            .txtSpeedometer.Text = txtSpeedometer.Text
            .cbxBodyPaint_G.Checked = cbxBodyPaint_G.Checked
            .cbxBodyPaint_F.Checked = cbxBodyPaint_F.Checked
            .cbxBodyPaint_P.Checked = cbxBodyPaint_P.Checked
            .txtBodyPaint.Text = txtBodyPaint.Text
            .txtAppraisersRemarks.Text = rRemarks.Text
            .txtSource.Text = txtSource.Text
            .txtTelNo.Text = txtTelephoneNum.Text
            FormRestriction(64)
            If allow_Print Then
                .txtSellingPrice.Text = "Php " & dSellingPrice.Text
                .txtMarketValue.Text = "Php " & dFairMarketValue.Text
                .txtAppraisedValue.Text = "Php " & dAppraisedValue.Text
            Else
                .txtSellingPrice.Text = ""
                .txtMarketValue.Text = ""
                .txtAppraisedValue.Text = ""
            End If
            If cbxAppraiseFor.Text = "ROPOA" Then
                .lblLoanable.Visible = False
                .txtLoanble.Visible = False
                .txtLoanableP.Visible = False
            Else
                .txtLoanble.Text = "Php " & dLoanableValue.Text
                .txtLoanableP.Text = dLoanablePercent.Text & "%"
                .lblLoanable.Visible = True
                .txtLoanble.Visible = True
                .txtLoanableP.Visible = True
            End If

            Dim xPos As Integer = 1
            If TotalImage > 0 Then
                For x As Integer = 1 To TotalImage
                    Dim pB_Dev As New DevExpress.XtraEditors.PictureEdit
                    If x Mod 5 = 1 Then
                        pB_Dev.Properties.NullText = "Front"
                    ElseIf x Mod 5 = 2 Then
                        pB_Dev.Properties.NullText = "Back"
                    ElseIf x Mod 5 = 3 Then
                        pB_Dev.Properties.NullText = "Interior"
                    ElseIf x Mod 5 = 4 Then
                        pB_Dev.Properties.NullText = "Engine"
                    ElseIf x Mod 5 = 0 Then
                        pB_Dev.Properties.NullText = "Odometer"
                    End If

                    Dim pB As New XRPictureBox With {
                        .Size = New Size(375, 250),
                        .Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage,
                        .Borders = DevExpress.XtraPrinting.BorderSide.All
                    }
                    '***ADD LABEL***'
                    Dim lblImage As New XRLabel With {
                        .Text = pB_Dev.Properties.NullText.ToString,
                        .SizeF = New Size(375, 15),
                        .Font = New Font(OfficialFont, 8, FontStyle.Bold),
                        .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    }
                    '***ADD LABEL***'
                    If xPos Mod 2 = 0 Then
                        pB.Location = New Point(412.5, 770 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                        lblImage.Location = New Point(412.5, (770 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                    Else
                        pB.Location = New Point(12.5, 770 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0))
                        lblImage.Location = New Point(12.5, (770 + If(xPos > 2, (Math.Ceiling((xPos - 2) / 2) * 265), 0)) - 15)
                    End If
                    Dim Path As String
                    If cbxAppraiseFor.Text = "ROPOA" Then
                        Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, If(CreditNumber = "", AssetNumber, CreditNumber), txtAppraiseNumber.Text, pB_Dev.Properties.NullText & x & ".jpg")
                    Else
                        Path = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, If(CreditNumber = "", AssetNumber, CreditNumber), txtAppraiseNumber.Text, pB_Dev.Properties.NullText & x & ".jpg")
                    End If
                    If IO.File.Exists(Path) Then
                        Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                        Try
                            TempPB.Image = Image.FromFile(Path)
                        Catch ex As Exception
                            TriggerBugReport("Vehicle Appraisal - Print", ex.Message.ToString)
                        End Try
                        pB.Image = TempPB.Image
                        .Detail.Controls.Add(pB)
                        .Detail.Controls.Add(lblImage)
                        TempPB.Dispose()
                        xPos += 1
                    End If
                Next
            Else
            End If

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        If cbxNA.Checked Then
            dtpRegistered.Enabled = False
            dtpRegistered.CustomFormat = ""
        Else
            dtpRegistered.Enabled = True
            dtpRegistered.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnAttach_Click_1(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "ROPOA Attachments" & txtAppraiseNumber.Text
            .TotalImage = TotalImage_II
            .AssetNumber = AssetNumber
            .ID = txtAppraiseNumber.Text
            .Type = "VE Attachment"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Or Result = DialogResult.Yes Then
                TotalImage_II = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub DAppraisedValue_ValueChanged(sender As Object, e As EventArgs) Handles dAppraisedValue.ValueChanged
        dLoanableValue.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dLoanablePercent.Value / 100)
        If dAppraisedValue.Value > 0 Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
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
        dLoanableValue.Value = If(cbxBaseMarket.Checked, dFairMarketValue.Value, dAppraisedValue.Value) * (dLoanablePercent.Value / 100)
    End Sub

    Private Sub CbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If cbxType.Text.ToUpper.Contains("TRUCK") Or cbxType.Text.ToUpper.Contains("Dropside") Then
            iRim.Enabled = True
        Else
            iRim.Enabled = False
        End If
    End Sub

    Private Sub BtnROPA_Click(sender As Object, e As EventArgs) Handles btnROPA.Click
        Dim CollateralROPA As New FrmCollateralROPA
        With CollateralROPA
            .ROPA = "VL"
            .AssetNumber_1 = AssetNumber_1
            .AssetNumber_2 = AssetNumber_2
            .AssetNumber_3 = AssetNumber_3
            .AssetNumber_4 = AssetNumber_4
            .AssetNumber_5 = AssetNumber_5
            If .ShowDialog = DialogResult.OK Then
                Dim DT As DataTable = DataSource(String.Format("SELECT Make, `Type`, Used, Model, Series, PlateNum, C.Transmission, C.Fuel, BodyColor, `Year`, EngineNum, ChassisNum, RegistryCert, ORNum, GrossWeight, RimHoles, MileAge, MileAgeType, DateRegistered, LTO, IFNULL(A.`Engine`,'') 'Engine', IFNULL(A.Engine_R,'') 'Engine Remarks', IFNULL(A.Steering,'') 'Steering', IFNULL(A.Steering_R,'') 'Steering Remarks', IFNULL(A.Clutch,'') 'Clutch', IFNULL(A.Clutch_R,'') 'Clutch Remarks', IFNULL(A.HeadLight,'') 'Head Light', IFNULL(A.HeadLight_R,'') 'Head Light Remarks', IFNULL(A.SignalLight,'') 'Signal Light', IFNULL(A.SignalLight_R,'') 'Signal Light Remarks', IFNULL(A.Shock,'') 'Shock', IFNULL(A.Shock_R,'') 'Shock Remarks', IFNULL(A.Underchassis,'') 'Underchassis', IFNULL(A.Underchassis_R,'') 'Underchassis Remarks', IFNULL(A.Upholstery,'') 'Upholstery', IFNULL(A.Upholstery_R,'') 'Upholstery Remarks', IFNULL(A.TempGauge,'') 'Temp Gauge', IFNULL(A.TempGauge_R,'') 'Temp Gauge Remarks', IFNULL(A.Odometer,'') 'Odometer', IFNULL(A.Odometer_R,'') 'Odometer Remarks', IFNULL(A.Transmission,'') 'Transmission', IFNULL(A.Transmission_R,'') 'Transmission Remarks', IFNULL(A.Tires,0) 'Tires', IFNULL(A.Tires_R,'') 'Tires Remarks', IFNULL(A.Acceleration,'') 'Acceleration', IFNULL(A.Acceleration_R,'') 'Acceleration Remarks', IFNULL(A.ParkLight,'') 'Park Light', IFNULL(A.ParkLight_R,'') 'Park Light Remarks', IFNULL(A.Horn,'') 'Horn', IFNULL(A.Horn_R,'') 'Horn Remarks', IFNULL(A.Chassis,'') 'Chassis', IFNULL(A.Chassis_R,'') 'Chassis Remarks', IFNULL(A.FrontBumper,'') 'Front Bumper', IFNULL(A.FrontBumper_R,'') 'Front Bumper Remarks', IFNULL(A.Ampheres,'') 'Ampheres', IFNULL(A.Ampheres_R,'') 'Ampheres Remarks', IFNULL(A.Fuel,'') 'Fuel', IFNULL(A.Fuel_R,'') 'Fuel Remarks', IFNULL(A.Starter,'') 'Starter', IFNULL(A.Starter_R,'') 'Starter Remarks', IFNULL(A.Differential,'') 'Differential', IFNULL(A.Differential_R,'') 'Differential Remarks', IFNULL(A.Brakes,'') 'Brakes', IFNULL(A.Brakes_R,'') 'Brakes Remarks', IFNULL(A.Wiper,'') 'Wiper', IFNULL(A.Wiper_R,'') 'Wiper Remarks', IFNULL(A.`BackUp`,'') 'Back Up', IFNULL(A.BackUp_R,'') 'Back Up Remarks', IFNULL(A.SideMirror,'') 'Side Mirror', IFNULL(A.SideMirror_R,'') 'Side Mirror Remarks', IFNULL(A.BodyFlooring,'') 'Body Flooring', IFNULL(A.BodyFlooring_R,'') 'Body Flooring Remarks', IFNULL(A.RearBumper,'') 'Rear Bumper', IFNULL(A.RearBumper_R,'') 'Rear Bumper Remarks', IFNULL(A.OilPressure,'') 'Oil Pressure', IFNULL(A.OilPressure_R,'') 'Oil Pressure Remarks', IFNULL(A.Speedometer,'') 'Speedometer', IFNULL(A.Speedometer_R,'') 'Speedometer Remarks', IFNULL(A.BodyPaint,'') 'Body Paint', IFNULL(A.BodyPaint_R,'') 'Body Paint Remarks', IFNULL(A.Remarks,'') 'Appraiser Remarks', IFNULL(A.Source,'') 'Source', IFNULL(A.telephone_num,'') 'Telephone Num', IFNULL(A.selling_price,0) 'Selling Price', IFNULL(A.market_value,0) 'Market Value', IFNULL(A.appraised_value,0) 'Appraised Value', IFNULL(A.loanable_value,0) 'Loanable Value', IFNULL(A.loanable_percent,0) 'Loanable Percent', IFNULL(A.BaseMarket,0) 'BaseMarket' FROM ropoa_vehicle C LEFT JOIN appraise_ve A ON C.AssetNumber = A.Asset_Number WHERE C.AssetNumber = '{0}' ORDER BY A.appraise_date DESC LIMIT 1;", .GridView1.GetFocusedRowCellValue("Asset Number")))
                If DT.Rows.Count > 0 Then
                    SellingPrice = .GridView1.GetFocusedRowCellValue("Price")
                    AssetNumber = .GridView1.GetFocusedRowCellValue("Asset Number")
                    cbxMake.Text = DT(0)("Make")
                    cbxType.Text = DT(0)("Type")
                    cbxUsed.Text = DT(0)("Used")
                    cbxModel.Text = DT(0)("Model")
                    txtSeries.Text = DT(0)("Series")
                    txtPlateNum.Text = DT(0)("PlateNum")
                    cbxTransmission.Text = DT(0)("Transmission")
                    cbxFuel.Text = DT(0)("Fuel")
                    cbxBodyColor.Text = DT(0)("BodyColor")
                    If DT(0)("Year") = "" Then
                        dtpYear.CustomFormat = ""
                    Else
                        dtpYear.CustomFormat = "     yyyy"
                        dtpYear.Value = CDate(DT(0)("Year") & "-01-01")
                    End If
                    cbxEngineNumber.Text = DT(0)("EngineNum")
                    txtChassisNum.Text = DT(0)("ChassisNum")
                    txtRegistryCert.Text = DT(0)("RegistryCert")
                    txtORNum.Text = DT(0)("ORNum")
                    dGrossWeight.Value = DT(0)("GrossWeight")
                    iRim.Value = CInt(DT(0)("RimHoles"))
                    dMileAge.Value = CDbl(DT(0)("MileAge"))
                    vMileAge = DT(0)("MileAgeType")
                    If DT(0)("DateRegistered") = "" Then
                        cbxNA.Checked = True
                        dtpRegistered.CustomFormat = ""
                    Else
                        cbxNA.Checked = False
                        dtpRegistered.CustomFormat = "MMMM dd, yyyy"
                        dtpRegistered.Value = DT(0)("DateRegistered")
                    End If
                    txtLTO.Text = DT(0)("LTO")

                    'Enabled False
                    PanelEx1.Enabled = False
                    'Engine
                    If DT(0)("Engine") = "G" Then
                        cbxEngine_G.Checked = True
                    ElseIf DT(0)("Engine") = "F" Then
                        cbxEngine_F.Checked = True
                    ElseIf DT(0)("Engine") = "P" Then
                        cbxEngine_P.Checked = True
                    End If
                    txtEngine.Text = DT(0)("Engine Remarks")
                    'Steering
                    If DT(0)("Steering") = "G" Then
                        cbxSteering_G.Checked = True
                    ElseIf DT(0)("Steering") = "F" Then
                        cbxSteering_F.Checked = True
                    ElseIf DT(0)("Steering") = "P" Then
                        cbxSteering_P.Checked = True
                    End If
                    txtSteering.Text = DT(0)("Steering Remarks")
                    'Clutch
                    If DT(0)("Clutch") = "G" Then
                        cbxClutch_G.Checked = True
                    ElseIf DT(0)("Clutch") = "F" Then
                        cbxClutch_F.Checked = True
                    ElseIf DT(0)("Clutch") = "P" Then
                        cbxClutch_P.Checked = True
                    End If
                    txtClutch.Text = DT(0)("Clutch Remarks")
                    'Head Light
                    If DT(0)("Head Light") = "G" Then
                        cbxHeadLight_G.Checked = True
                    ElseIf DT(0)("Head Light") = "F" Then
                        cbxHeadLight_F.Checked = True
                    ElseIf DT(0)("Head Light") = "P" Then
                        cbxHeadLight_P.Checked = True
                    End If
                    txtHeadLight.Text = DT(0)("Head Light Remarks")
                    'Signal Light
                    If DT(0)("Signal Light") = "G" Then
                        cbxSignalLight_G.Checked = True
                    ElseIf DT(0)("Signal Light") = "F" Then
                        cbxSignalLight_F.Checked = True
                    ElseIf DT(0)("Signal Light") = "P" Then
                        cbxSignalLight_P.Checked = True
                    End If
                    txtSignalLight.Text = DT(0)("Signal Light Remarks")
                    'Shock
                    If DT(0)("Shock") = "G" Then
                        cbxShock_G.Checked = True
                    ElseIf DT(0)("Shock") = "F" Then
                        cbxShock_F.Checked = True
                    ElseIf DT(0)("Shock") = "P" Then
                        cbxShock_P.Checked = True
                    End If
                    txtShock.Text = DT(0)("Shock Remarks")
                    'Underchassis
                    If DT(0)("Underchassis") = "G" Then
                        cbxUnderchassis_G.Checked = True
                    ElseIf DT(0)("Underchassis") = "F" Then
                        cbxUnderchassis_F.Checked = True
                    ElseIf DT(0)("Underchassis") = "P" Then
                        cbxUnderchassis_P.Checked = True
                    End If
                    txtUnderchassis.Text = DT(0)("Underchassis Remarks")
                    'Upholstery
                    If DT(0)("Upholstery") = "G" Then
                        cbxUpholstery_G.Checked = True
                    ElseIf DT(0)("Upholstery") = "F" Then
                        cbxUpholstery_F.Checked = True
                    ElseIf DT(0)("Upholstery") = "P" Then
                        cbxUpholstery_P.Checked = True
                    End If
                    txtUpholstery.Text = DT(0)("Upholstery Remarks")
                    'Temp Gauge
                    If DT(0)("Temp Gauge") = "G" Then
                        cbxTempGauge_G.Checked = True
                    ElseIf DT(0)("Temp Gauge") = "F" Then
                        cbxTempGauge_F.Checked = True
                    ElseIf DT(0)("Temp Gauge") = "P" Then
                        cbxTempGauge_P.Checked = True
                    End If
                    txtTempGauge.Text = DT(0)("Temp Gauge Remarks")
                    'Odometer
                    If DT(0)("Odometer") = "G" Then
                        cbxOdometer_G.Checked = True
                    ElseIf DT(0)("Odometer") = "F" Then
                        cbxOdometer_F.Checked = True
                    ElseIf DT(0)("Odometer") = "P" Then
                        cbxOdometer_P.Checked = True
                    End If
                    txtOdometer.Text = DT(0)("Odometer Remarks")
                    'Transmission
                    If DT(0)("Transmission1") = "G" Then
                        cbxTransmission_G.Checked = True
                    ElseIf DT(0)("Transmission1") = "F" Then
                        cbxTransmission_F.Checked = True
                    ElseIf DT(0)("Transmission1") = "P" Then
                        cbxTransmission_P.Checked = True
                    End If
                    txtTransmission.Text = DT(0)("Transmission Remarks")
                    'Tires
                    dTires.Value = CDbl(DT(0)("Tires"))
                    'Acceleration
                    If DT(0)("Acceleration") = "G" Then
                        cbxAcceleration_G.Checked = True
                    ElseIf DT(0)("Acceleration") = "F" Then
                        cbxAcceleration_F.Checked = True
                    ElseIf DT(0)("Acceleration") = "P" Then
                        cbxAcceleration_P.Checked = True
                    End If
                    txtAcceleration.Text = DT(0)("Acceleration Remarks")
                    'Parklight
                    If DT(0)("Park Light") = "G" Then
                        cbxParkLight_G.Checked = True
                    ElseIf DT(0)("Park Light") = "F" Then
                        cbxParkLight_F.Checked = True
                    ElseIf DT(0)("Park Light") = "P" Then
                        cbxParkLight_P.Checked = True
                    End If
                    txtParkLight.Text = DT(0)("Park Light Remarks")
                    'Horn
                    If DT(0)("Horn") = "G" Then
                        cbxHorn_G.Checked = True
                    ElseIf DT(0)("Horn") = "F" Then
                        cbxHorn_F.Checked = True
                    ElseIf DT(0)("Horn") = "P" Then
                        cbxHorn_P.Checked = True
                    End If
                    txtHorn.Text = DT(0)("Horn Remarks")
                    'Chassis
                    If DT(0)("Chassis") = "G" Then
                        cbxChassis_G.Checked = True
                    ElseIf DT(0)("Chassis") = "F" Then
                        cbxChassis_F.Checked = True
                    ElseIf DT(0)("Chassis") = "P" Then
                        cbxChassis_P.Checked = True
                    End If
                    txtChassis.Text = DT(0)("Chassis Remarks")
                    'Front Bumper
                    If DT(0)("Front Bumper") = "G" Then
                        cbxFrontBumper_G.Checked = True
                    ElseIf DT(0)("Front Bumper") = "F" Then
                        cbxFrontBumper_F.Checked = True
                    ElseIf DT(0)("Front Bumper") = "P" Then
                        cbxFrontBumper_P.Checked = True
                    End If
                    txtFrontBumper.Text = DT(0)("Front Bumper Remarks")
                    'Ampheres
                    If DT(0)("Ampheres") = "G" Then
                        cbxAmpheres_G.Checked = True
                    ElseIf DT(0)("Ampheres") = "F" Then
                        cbxAmpheres_F.Checked = True
                    ElseIf DT(0)("Ampheres") = "P" Then
                        cbxAmpheres_P.Checked = True
                    End If
                    txtAmpheres.Text = DT(0)("Ampheres Remarks")
                    'Fuel
                    If DT(0)("Fuel1") = "G" Then
                        cbxFuel_G.Checked = True
                    ElseIf DT(0)("Fuel1") = "F" Then
                        cbxFuel_F.Checked = True
                    ElseIf DT(0)("Fuel1") = "P" Then
                        cbxFuel_P.Checked = True
                    End If
                    txtFuel.Text = DT(0)("Fuel Remarks")
                    'Starter
                    If DT(0)("Starter") = "G" Then
                        cbxStarter_G.Checked = True
                    ElseIf DT(0)("Starter") = "F" Then
                        cbxStarter_F.Checked = True
                    ElseIf DT(0)("Starter") = "P" Then
                        cbxStarter_P.Checked = True
                    End If
                    txtStarter.Text = DT(0)("Starter Remarks")
                    'Differential
                    If DT(0)("Differential") = "G" Then
                        cbxDifferential_G.Checked = True
                    ElseIf DT(0)("Differential") = "F" Then
                        cbxDifferential_F.Checked = True
                    ElseIf DT(0)("Differential") = "P" Then
                        cbxDifferential_P.Checked = True
                    End If
                    txtDifferential.Text = DT(0)("Differential Remarks")
                    'Brakes
                    If DT(0)("Brakes") = "G" Then
                        cbxBrakes_G.Checked = True
                    ElseIf DT(0)("Brakes") = "F" Then
                        cbxBrakes_F.Checked = True
                    ElseIf DT(0)("Brakes") = "P" Then
                        cbxBrakes_P.Checked = True
                    End If
                    txtBrakes.Text = DT(0)("Brakes Remarks")
                    'Wiper
                    If DT(0)("Wiper") = "G" Then
                        cbxWiper_G.Checked = True
                    ElseIf DT(0)("Wiper") = "F" Then
                        cbxWiper_F.Checked = True
                    ElseIf DT(0)("Wiper") = "P" Then
                        cbxWiper_P.Checked = True
                    End If
                    txtWiper.Text = DT(0)("Wiper Remarks")
                    'Backup
                    If DT(0)("Back Up") = "G" Then
                        cbxBackUp_G.Checked = True
                    ElseIf DT(0)("Back Up") = "F" Then
                        cbxBackUp_F.Checked = True
                    ElseIf DT(0)("Back Up") = "P" Then
                        cbxBackUp_P.Checked = True
                    End If
                    txtBackUp.Text = DT(0)("Back Up Remarks")
                    'SideMirror
                    If DT(0)("Side Mirror") = "G" Then
                        cbxSideMirror_G.Checked = True
                    ElseIf DT(0)("Side Mirror") = "F" Then
                        cbxSideMirror_F.Checked = True
                    ElseIf DT(0)("Side Mirror") = "P" Then
                        cbxSideMirror_P.Checked = True
                    End If
                    txtSideMirror.Text = DT(0)("Side Mirror Remarks")
                    'Body Flooring
                    If DT(0)("Body Flooring") = "G" Then
                        cbxBodyFlooring_G.Checked = True
                    ElseIf DT(0)("Body Flooring") = "F" Then
                        cbxBodyFlooring_F.Checked = True
                    ElseIf DT(0)("Body Flooring") = "P" Then
                        cbxBodyFlooring_P.Checked = True
                    End If
                    txtBodyFlooring.Text = DT(0)("Body Flooring Remarks")
                    'Rear Bumper
                    If DT(0)("Rear Bumper") = "G" Then
                        cbxRearBumper_G.Checked = True
                    ElseIf DT(0)("Rear Bumper") = "F" Then
                        cbxRearBumper_F.Checked = True
                    ElseIf DT(0)("Rear Bumper") = "P" Then
                        cbxRearBumper_P.Checked = True
                    End If
                    txtRearBumper.Text = DT(0)("Rear Bumper Remarks")
                    'Oil Pressure
                    If DT(0)("Oil Pressure") = "G" Then
                        cbxOilPressure_G.Checked = True
                    ElseIf DT(0)("Oil Pressure") = "F" Then
                        cbxOilPressure_F.Checked = True
                    ElseIf DT(0)("Oil Pressure") = "P" Then
                        cbxOilPressure_P.Checked = True
                    End If
                    txtOilPressure.Text = DT(0)("Oil Pressure Remarks")
                    'Speedometer
                    If DT(0)("Speedometer") = "G" Then
                        cbxSpeedometer_G.Checked = True
                    ElseIf DT(0)("Speedometer") = "F" Then
                        cbxSpeedometer_F.Checked = True
                    ElseIf DT(0)("Speedometer") = "P" Then
                        cbxSpeedometer_P.Checked = True
                    End If
                    txtSpeedometer.Text = DT(0)("Speedometer Remarks")
                    'Body Paint
                    If DT(0)("Body Paint") = "G" Then
                        cbxBodyPaint_G.Checked = True
                    ElseIf DT(0)("Body Paint") = "F" Then
                        cbxBodyPaint_F.Checked = True
                    ElseIf DT(0)("Body Paint") = "P" Then
                        cbxBodyPaint_P.Checked = True
                    End If
                    txtBodyPaint.Text = DT(0)("Body Paint Remarks")

                    rRemarks.Text = DT(0)("Appraiser Remarks")
                    txtSource.Text = DT(0)("Source")
                    txtTelephoneNum.Text = DT(0)("Telephone Num")
                    dSellingPrice.Value = CDbl(DT(0)("Selling Price"))
                    dFairMarketValue.Value = CDbl(DT(0)("Market Value"))
                    dAppraisedValue.Value = CDbl(DT(0)("Appraised Value"))
                    cbxBaseMarket.Checked = DT(0)("BaseMarket")
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnHit_Click(sender As Object, e As EventArgs) Handles btnHit.Click
        Dim Table As New FrmReportTable
        With Table
            .GridView4.Columns.Clear()
            .GridControl4.DataSource = Exist
            .ExistValue = {cbxMake.Text, cbxType.Text, cbxModel.Text, txtPlateNum.Text, txtChassisNum.Text, txtRegistryCert.Text, txtORNum.Text}
            .Title = "Vehicle Hit List"
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class