Public Class FrmAppraisalManagement

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmAppraisalManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5, GridView6})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        cbxDisplay.SelectedIndex = 0
        LoadData()

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

            GetLabelFontSettings({LabelX155, LabelX10, LabelX1})

            GetComboBoxFontSettings({cbxDisplay})

            GetCheckBoxFontSettings({cbxAll, cbxAdvanced})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnPrint, btnCancel, btnHide, btnShow})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Appraisal Management - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Appraisal Management", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String

        If SuperTabControl1.SelectedTabIndex = 0 Or SuperTabControl1.SelectedTabIndex = 1 Then
            SQL = "SELECT"
            SQL &= "    A.appraise_num AS 'Appraise Number',"
            SQL &= "    DATE_FORMAT(A.appraise_date,'%m.%d.%Y') AS 'Date',"
            SQL &= "    appraise_by, (SELECT CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) FROM employee_setup WHERE ID = A.appraise_by) AS 'Appraised By', "
            If SuperTabControl1.SelectedTabIndex = 0 Then
                SQL &= "    credit_number AS 'Credit Number',"
                SQL &= "    Borrower_Credit(credit_number) AS 'Borrower',"
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                SQL &= "    asset_number AS 'Asset Number',"
            End If
            SQL &= "    R.Make,"
            SQL &= "    R.Type,"
            SQL &= "    R.Used,"
            SQL &= "    R.Model,"
            SQL &= "    R.PlateNum AS 'Plate Num',"
            SQL &= "    A.`Engine`,"
            SQL &= "    A.Engine_R AS 'Engine Remarks',"
            SQL &= "    A.Steering,"
            SQL &= "    A.Steering_R AS 'Steering Remarks',"
            SQL &= "    A.Clutch,"
            SQL &= "    A.Clutch_R AS 'Clutch Remarks',"
            SQL &= "    A.HeadLight AS 'Head Light',"
            SQL &= "    A.HeadLight_R AS 'Head Light Remarks',"
            SQL &= "    A.SignalLight AS 'Signal Light',"
            SQL &= "    A.SignalLight_R AS 'Signal Light Remarks',"
            SQL &= "    A.Shock,"
            SQL &= "    A.Shock_R AS 'Shock Remarks',"
            SQL &= "    A.Underchassis,"
            SQL &= "    A.Underchassis_R AS 'Underchassis Remarks',"
            SQL &= "    A.Upholstery,"
            SQL &= "    A.Upholstery_R AS 'Upholstery Remarks',"
            SQL &= "    A.TempGauge AS 'Temp Gauge',"
            SQL &= "    A.TempGauge_R AS 'Temp Gauge Remarks',"
            SQL &= "    A.Odometer AS 'Odometer',"
            SQL &= "    A.Odometer_R AS 'Odometer Remarks',"
            SQL &= "    A.Transmission AS 'Transmission',"
            SQL &= "    A.Transmission_R AS 'Transmission Remarks',"
            SQL &= "    A.Tires,"
            SQL &= "    A.Tires_R AS 'Tires Remarks',"
            SQL &= "    A.Acceleration,"
            SQL &= "    A.Acceleration_R AS 'Acceleration Remarks',"
            SQL &= "    A.ParkLight AS 'Park Light',"
            SQL &= "    A.ParkLight_R AS 'Park Light Remarks',"
            SQL &= "    A.Horn,"
            SQL &= "    A.Horn_R AS 'Horn Remarks',"
            SQL &= "    A.Chassis,"
            SQL &= "    A.Chassis_R AS 'Chassis Remarks',"
            SQL &= "    A.FrontBumper AS 'Front Bumper',"
            SQL &= "    A.FrontBumper_R AS 'Front Bumper Remarks',"
            SQL &= "    A.Ampheres,"
            SQL &= "    A.Ampheres_R AS 'Ampheres Remarks',"
            SQL &= "    A.Fuel,"
            SQL &= "    A.Fuel_R AS 'Fuel Remarks',"
            SQL &= "    A.Starter,"
            SQL &= "    A.Starter_R AS 'Starter Remarks',"
            SQL &= "    A.Differential,"
            SQL &= "    A.Differential_R AS 'Differential Remarks',"
            SQL &= "    A.Brakes,"
            SQL &= "    A.Brakes_R AS 'Brakes Remarks',"
            SQL &= "    A.Wiper,"
            SQL &= "    A.Wiper_R AS 'Wiper Remarks',"
            SQL &= "    A.`BackUp` AS 'Back Up',"
            SQL &= "    A.BackUp_R AS 'Back Up Remarks',"
            SQL &= "    A.SideMirror AS 'Side Mirror',"
            SQL &= "    A.SideMirror_R AS 'Side Mirror Remarks',"
            SQL &= "    A.BodyFlooring AS 'Body Flooring',"
            SQL &= "    A.BodyFlooring_R AS 'Body Flooring Remarks',"
            SQL &= "    A.RearBumper AS 'Rear Bumper',"
            SQL &= "    A.RearBumper_R AS 'Rear Bumper Remarks',"
            SQL &= "    A.OilPressure AS 'Oil Pressure',"
            SQL &= "    A.OilPressure_R AS 'Oil Pressure Remarks',"
            SQL &= "    A.Speedometer,"
            SQL &= "    A.Speedometer_R AS 'Speedometer Remarks',"
            SQL &= "    A.BodyPaint AS 'Body Paint',"
            SQL &= "    A.BodyPaint_R AS 'Body Paint Remarks',"
            SQL &= "    A.Remarks AS 'Appraiser Remarks',"
            SQL &= "    A.Source,"
            SQL &= "    A.telephone_num AS 'Telephone Num',"
            SQL &= "    A.selling_price AS 'Selling Price',"
            SQL &= "    A.market_value AS 'Market Value',"
            SQL &= "    A.appraised_value AS 'Appraised Value',"
            SQL &= "    A.loanable_value AS 'Loanable Value',"
            SQL &= "    A.loanable_percent AS 'Loanable Percent',"
            SQL &= "    `Attach`, Attach_2, BaseMarket,Branch_ID"
            If SuperTabControl1.SelectedTabIndex = 0 Then
                SQL &= String.Format("  FROM appraise_ve A LEFT JOIN (SELECT Make, `Type`, Used, Model, PlateNum, CreditNumber, CollateralNumber FROM collateral_ve WHERE CINumber != '' AND `status` = 'ACTIVE') R ON R.CreditNumber = A.credit_number AND R.CollateralNumber = A.CollateralNumber WHERE A.`status` = 'ACTIVE' AND appraise = 'Credit Investigation' AND IF({1},TRUE,FIND_IN_SET(A.Branch_ID,'{0}'))", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxAdvanced.Checked)
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                SQL &= String.Format("  FROM appraise_ve A LEFT JOIN (SELECT Make, `Type`, Used, Model, PlateNum, AssetNumber FROM ropoa_vehicle) R ON R.AssetNumber = A.asset_number WHERE A.`status` = 'ACTIVE' AND appraise = 'ROPOA' AND IF({1},TRUE,FIND_IN_SET(A.Branch_ID,'{0}'))", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxAdvanced.Checked)
            End If
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("  AND DATE(A.appraise_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            If cbxAdvanced.Checked Then
                With FrmAdvanceSearchAppraisal
                    If .txtKeyword.Text.Trim = "" Then
                    Else
                        Dim Words As String() = .txtKeyword.Text.Trim.Split(New Char() {" "c})
                        If KeywordSearchWildcard Then
                            Dim Key As String
                            For Each Key In Words
                                SQL &= String.Format(" AND (R.Make LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" R.Type LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" R.Used LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" R.Model LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" R.PlateNum LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Remarks LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Source LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.telephone_num LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.selling_price LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.market_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.appraised_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.loanable_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.loanable_percent LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" BaseMarket LIKE '%{0}%')", Key)
                            Next
                        Else
                            Dim key As String = .txtKeyword.Text
                            SQL &= String.Format(" AND (R.Make LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" R.Type LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" R.Used LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" R.Model LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" R.PlateNum LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Remarks LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Source LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.telephone_num LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.selling_price LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.market_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.appraised_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.loanable_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.loanable_percent LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" BaseMarket LIKE '%{0}%')", key)
                        End If
                    End If
                    If .cbxAppraisedBy.SelectedIndex = -1 Then
                    Else
                        SQL &= String.Format(" AND appraise_by = '{0}'", .cbxAppraisedBy.SelectedValue)
                    End If
                    If .iFrom.Value > 0 Or .iTo.Value > 0 Then
                        SQL &= String.Format(" AND (A.appraised_value BETWEEN {0} AND {1})", .iFrom.Value, .iTo.Value)
                    End If
                End With
            End If

            If SuperTabControl1.SelectedTabIndex = 0 Then
                SQL &= " AND appraise = 'Credit Investigation'"
                SQL &= " ORDER BY `Appraise Number` DESC;"
                GridControl2.DataSource = DataSource(SQL)
                GridView2.Columns("Appraise Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                GridView2.Columns("Appraise Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

                If GridView2.RowCount > 19 Then
                    GridColumn259.Width = 239 - 17
                Else
                    GridColumn259.Width = 239
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                SQL &= " AND appraise = 'ROPOA'"
                SQL &= " ORDER BY `Appraise Number` DESC;"
                GridControl1.DataSource = DataSource(SQL)
                GridView1.Columns("Appraise Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                GridView1.Columns("Appraise Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

                If GridView1.RowCount > 19 Then
                    GridColumn260.Width = 239 - 17
                Else
                    GridColumn260.Width = 239
                End If
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Then
            SQL = "SELECT"
            SQL &= "    appraise_num AS 'Appraise Number',"
            SQL &= "    DATE_FORMAT(appraise_date,'%m.%d.%Y') AS 'Date',"
            SQL &= "    appraise_by, (SELECT CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) FROM employee_setup WHERE ID = appraise_by) AS 'Appraised By', "
            If SuperTabControl1.SelectedTabIndex = 2 Then
                SQL &= "    credit_number AS 'Credit Number',"
                SQL &= "    Borrower_Credit(credit_number) AS 'Borrower',"
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                SQL &= "    asset_number AS 'Asset Number',"
            End If
            SQL &= "   Land,"
            SQL &= "   A.land_area AS 'Land Area',"
            SQL &= "   A.land_price AS 'Land Price',"
            SQL &= "   A.land_price * land_area AS 'Land Total',"
            SQL &= "   land_remarks_1 AS 'Land Remarks',"
            SQL &= "   A.land_area_2 AS 'Land Area 2',"
            SQL &= "   A.land_price_2 AS 'Land Price 2',"
            SQL &= "   A.land_price_2 * land_area_2 AS 'Land Total 2',"
            SQL &= "   land_remarks_2 AS 'Land Remarks 2',"
            SQL &= "   A.land_area_3 AS 'Land Area 3',"
            SQL &= "   A.land_price_3 AS 'Land Price 3',"
            SQL &= "   A.land_price_3 * land_area_3 AS 'Land Total 3',"
            SQL &= "   land_remarks_3 AS 'Land Remarks 3',"
            SQL &= "   A.land_area_4 AS 'Land Area 4',"
            SQL &= "   A.land_price_4 AS 'Land Price 4',"
            SQL &= "   A.land_price_4 * land_area_4 AS 'Land Total 4',"
            SQL &= "   land_remarks_4 AS 'Land Remarks 4',"
            SQL &= "   A.land_area_5 AS 'Land Area 5',"
            SQL &= "   A.land_price_5 AS 'Land Price 5',"
            SQL &= "   A.land_price_5 * land_area_5 AS 'Land Total 5',"
            SQL &= "   (A.land_price * land_area) + (A.land_price_2 * land_area_2) + (A.land_price_3 * land_area_3) + (A.land_price_4 * land_area_4) + (A.land_price_5 * land_area_5) AS 'Land SuperTotal',"
            SQL &= "   land_remarks_5 AS 'Land Remarks 5',"
            SQL &= "   Machine,"
            SQL &= "   A.Machine_area AS 'Machine Area',"
            SQL &= "   A.Machine_price AS 'Machine Price',"
            SQL &= "   A.Machine_price * Machine_area AS 'Machine Total',"
            SQL &= "   Machine_remarks_1 AS 'Machine Remarks',"
            SQL &= "   A.Machine_area_2 AS 'Machine Area 2',"
            SQL &= "   A.Machine_price_2 AS 'Machine Price 2',"
            SQL &= "   A.Machine_price_2 * Machine_area_2 AS 'Machine Total 2',"
            SQL &= "   Machine_remarks_2 AS 'Machine Remarks 2',"
            SQL &= "   A.Machine_area_3 AS 'Machine Area 3',"
            SQL &= "   A.Machine_price_3 AS 'Machine Price 3',"
            SQL &= "   A.Machine_price_3 * Machine_area_3 AS 'Machine Total 3',"
            SQL &= "   Machine_remarks_3 AS 'Machine Remarks 3',"
            SQL &= "   A.Machine_area_4 AS 'Machine Area 4',"
            SQL &= "   A.Machine_price_4 AS 'Machine Price 4',"
            SQL &= "   A.Machine_price_4 * Machine_area_4 AS 'Machine Total 4',"
            SQL &= "   Machine_remarks_4 AS 'Machine Remarks 4',"
            SQL &= "   A.Machine_area_5 AS 'Machine Area 5',"
            SQL &= "   A.Machine_price_5 AS 'Machine Price 5',"
            SQL &= "   A.Machine_price_5 * Machine_area_5 AS 'Machine Total 5',"
            SQL &= "   (A.Machine_price * Machine_area) + (A.Machine_price_2 * Machine_area_2) + (A.Machine_price_3 * Machine_area_3) + (A.Machine_price_4 * Machine_area_4) + (A.Machine_price_5 * Machine_area_5) AS 'Machine SuperTotal',"
            SQL &= "   Machine_remarks_5 AS 'Machine Remarks 5',"
            SQL &= "   Improvement,"
            SQL &= "   A.Improvement_area AS 'Improvement Area',"
            SQL &= "   A.Improvement_price AS 'Improvement Price',"
            SQL &= "   A.Improvement_price * Improvement_area AS 'Improvement Total',"
            SQL &= "   Improvement_remarks_1 AS 'Improvement Remarks',"
            SQL &= "   A.Improvement_area_2 AS 'Improvement Area 2',"
            SQL &= "   A.Improvement_price_2 AS 'Improvement Price 2',"
            SQL &= "   A.Improvement_price_2 * Improvement_area_2 AS 'Improvement Total 2',"
            SQL &= "   Improvement_remarks_2 AS 'Improvement Remarks 2',"
            SQL &= "   A.Improvement_area_3 AS 'Improvement Area 3',"
            SQL &= "   A.Improvement_price_3 AS 'Improvement Price 3',"
            SQL &= "   A.Improvement_price_3 * Improvement_area_3 AS 'Improvement Total 3',"
            SQL &= "   Improvement_remarks_3 AS 'Improvement Remarks 3',"
            SQL &= "   A.Improvement_area_4 AS 'Improvement Area 4',"
            SQL &= "   A.Improvement_price_4 AS 'Improvement Price 4',"
            SQL &= "   A.Improvement_price_4 * Improvement_area_4 AS 'Improvement Total 4',"
            SQL &= "   Improvement_remarks_4 AS 'Improvement Remarks 4',"
            SQL &= "   A.Improvement_area_5 AS 'Improvement Area 5',"
            SQL &= "   A.Improvement_price_5 AS 'Improvement Price 5',"
            SQL &= "   A.Improvement_price_5 * Improvement_area_5 AS 'Improvement Total 5',"
            SQL &= "   (A.Improvement_price * Improvement_area) + (A.Improvement_price_2 * Improvement_area_2) + (A.Improvement_price_3 * Improvement_area_3) + (A.Improvement_price_4 * Improvement_area_4) + (A.Improvement_price_5 * Improvement_area_5) AS 'Improvement SuperTotal',"
            SQL &= "   Improvement_remarks_5 AS 'Improvement Remarks 5',"
            SQL &= "   (A.land_price * A.land_area) + (A.land_price_2 * land_area_2) + (A.land_price_3 * land_area_3) + (A.land_price_4 * land_area_4) + (A.land_price_5 * land_area_5) + (A.machine_price * A.machine_area) + (A.machine_price_2 * machine_area_2) + (A.machine_price_3 * machine_area_3) + (A.machine_price_4 * machine_area_4) + (A.machine_price_5 * machine_area_5) + (A.improvement_price * A.improvement_area) + (A.improvement_price_2 * improvement_area_2) + (A.improvement_price_3 * improvement_area_3) + (A.improvement_price_4 * improvement_area_4) + (A.improvement_price_5 * improvement_area_5) AS 'Total',"
            SQL &= "    prevailing_selling AS 'Prevailing Selling Price',"
            SQL &= "    rounded_to AS 'Zonal Valuation',"
            SQL &= "    TCT AS 'TCT No.',"
            SQL &= "    lot_block AS 'Lot / Block No.',"
            SQL &= "    area_sqm AS 'Area SQ.M.',"
            SQL &= "    registered_owner AS 'Registered Owner',"
            SQL &= "    registry_deeds AS 'Registry of Deeds',"
            SQL &= "    Location,"
            SQL &= "    Coordinates,"
            SQL &= "    vacant_lot AS 'Vacant Lot',"
            SQL &= "    Classification,"
            SQL &= "    Storey_R AS 'Storey',"
            SQL &= "    Roofing_R AS 'Roofing',"
            SQL &= "    FLooring_R AS 'Flooring',"
            SQL &= "    TandB_R AS 'T and B',"
            SQL &= "    Frame_R AS 'Frame',"
            SQL &= "    Beams_R AS 'Beams',"
            SQL &= "    Doors_R AS 'Door',"
            SQL &= "    YearConstructed_R AS 'Year Constructed',"
            SQL &= "    Walling_R AS 'Walling',"
            SQL &= "    Ceiling_R AS 'Ceiling',"
            SQL &= "    Windows_R AS 'Windows',"
            SQL &= "    FloorArea_R AS 'Floor Area',"
            SQL &= "    Partitions_R AS 'Partitions',"
            SQL &= "    Remarks AS 'Remarks',"
            SQL &= "    market_value AS 'Market Value',"
            SQL &= "    appraised_value AS 'Appraised Value',"
            SQL &= "    DATE_FORMAT(as_of,'%m.%d.%Y') AS 'As of',"
            SQL &= "    loanable_value AS 'Loanable Value',"
            SQL &= "    loanable_percent AS 'Loanable Percent',"
            SQL &= "    `Attach`,Branch_ID"
            SQL &= String.Format("  FROM appraise_re A WHERE `status` = 'ACTIVE' AND IF({1},TRUE,Branch_ID IN ({0}))", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxAdvanced.Checked)
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(appraise_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            If cbxAdvanced.Checked Then
                With FrmAdvanceSearchAppraisal
                    If .txtKeyword.Text.Trim = "" Then
                    Else
                        Dim Words As String() = .txtKeyword.Text.Trim.Split(New Char() {" "c})
                        If KeywordSearchWildcard Then
                            Dim Key As String
                            For Each Key In Words
                                SQL &= String.Format(" AND (Land LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_area LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_price LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" land_remarks_1 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_area_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_price_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" land_remarks_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_area_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_price_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" land_remarks_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_area_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_price_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" land_remarks_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_area_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.land_price_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" land_remarks_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_area LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_price LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine_remarks_1 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_area_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_price_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine_remarks_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_area_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_price_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine_remarks_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_area_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_price_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine_remarks_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_area_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Machine_price_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Machine_remarks_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_area LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_price LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement_remarks_1 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_area_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_price_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement_remarks_2 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_area_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_price_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement_remarks_3 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_area_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_price_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement_remarks_4 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_area_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" A.Improvement_price_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Improvement_remarks_5 LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" prevailing_selling LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" rounded_to LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" TCT LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" lot_block LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" area_sqm LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" registered_owner LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" registry_deeds LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Location LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Coordinates LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" vacant_lot LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Classification LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Storey_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Roofing_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" FLooring_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" TandB_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Frame_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Beams_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Doors_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" YearConstructed_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Walling_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Ceiling_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Windows_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" FloorArea_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Partitions_R LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" Remarks LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" market_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" appraised_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" loanable_value LIKE '%{0}%' OR", Key)
                                SQL &= String.Format(" loanable_percent LIKE '%{0}%')", Key)
                            Next
                        Else
                            Dim key As String = .txtKeyword.Text
                            SQL &= String.Format(" AND (Land LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_area LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_price LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" land_remarks_1 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_area_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_price_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" land_remarks_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_area_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_price_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" land_remarks_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_area_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_price_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" land_remarks_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_area_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.land_price_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" land_remarks_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_area LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_price LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine_remarks_1 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_area_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_price_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine_remarks_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_area_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_price_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine_remarks_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_area_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_price_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine_remarks_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_area_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Machine_price_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Machine_remarks_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_area LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_price LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement_remarks_1 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_area_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_price_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement_remarks_2 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_area_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_price_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement_remarks_3 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_area_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_price_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement_remarks_4 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_area_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" A.Improvement_price_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Improvement_remarks_5 LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" prevailing_selling LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" rounded_to LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" TCT LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" lot_block LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" area_sqm LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" registered_owner LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" registry_deeds LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Location LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Coordinates LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" vacant_lot LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Classification LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Storey_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Roofing_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" FLooring_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" TandB_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Frame_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Beams_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Doors_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" YearConstructed_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Walling_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Ceiling_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Windows_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" FloorArea_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Partitions_R LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" Remarks LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" market_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" appraised_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" loanable_value LIKE '%{0}%' OR", key)
                            SQL &= String.Format(" loanable_percent LIKE '%{0}%')", key)
                        End If
                    End If
                    If .cbxAppraisedBy.SelectedIndex = -1 Then
                    Else
                        SQL &= String.Format(" AND appraise_by = '{0}'", .cbxAppraisedBy.SelectedValue)
                    End If
                    If .iFrom.Value > 0 Or .iTo.Value > 0 Then
                        SQL &= String.Format(" AND (appraised_value BETWEEN {0} AND {1})", .iFrom.Value, .iTo.Value)
                    End If
                End With
            End If

            If SuperTabControl1.SelectedTabIndex = 2 Then
                SQL &= " AND appraise = 'Credit Investigation'"
                SQL &= " ORDER BY `Appraise Number` DESC;"
                GridControl3.DataSource = DataSource(SQL)
                GridView3.Columns("Appraise Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                GridView3.Columns("Appraise Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

                If GridView3.RowCount > 19 Then
                    GridColumn261.Width = 225 - 17
                Else
                    GridColumn261.Width = 225
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                SQL &= " AND appraise = 'ROPOA'"
                SQL &= " ORDER BY `Appraise Number` DESC;"
                GridControl4.DataSource = DataSource(SQL)
                GridView4.Columns("Appraise Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                GridView4.Columns("Appraise Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

                If GridView4.RowCount > 19 Then
                    GridColumn262.Width = 225 - 17
                Else
                    GridColumn262.Width = 225
                End If
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            SQL = "SELECT"
            SQL &= "    AssetNumber AS 'Asset Number',"
            SQL &= "    Make,"
            SQL &= "    `Type`,"
            SQL &= "    Model,"
            SQL &= "    PlateNum AS 'Plate Number',"
            SQL &= "    IFNULL(Borrower (AccountID), '') AS 'Account Name',"
            SQL &= "    AccountNo AS 'Account Number',"
            SQL &= "    IFNULL(AppraisedBy,'') AS 'Appraised By',"
            SQL &= "    IFNULL(DATE_FORMAT(appraise_date,'%M %d, %Y'),'') AS 'Last Appraise',"
            SQL &= "    IFNULL(DATEDIFF(DATE(NOW()),appraise_date),0) AS 'Days Ago' "
            SQL &= String.Format("  FROM ropoa_vehicle R LEFT JOIN (SELECT MAX(appraise_date) AS 'appraise_date', asset_number, IFNULL(Employee(Appraise_By),'') AS 'AppraisedBy' FROM appraise_ve WHERE appraise = 'ROPOA' AND `status` = 'ACTIVE' GROUP BY Asset_Number) A ON R.`AssetNumber` = A.asset_number WHERE `status` = 'ACTIVE' AND sell_status = 'SELL' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(appraise_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            GridControl5.DataSource = DataSource(SQL)
            GridView5.Columns("Account Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView5.Columns("Account Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView5.RowCount > 19 Then
                GridColumn270.Width = 181 - 8
                GridColumn273.Width = 181 - 9
            Else
                GridColumn270.Width = 181
                GridColumn273.Width = 181
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            SQL = "SELECT"
            SQL &= "    AssetNumber AS 'Asset Number',"
            SQL &= "    TCT,"
            SQL &= "    Location,"
            SQL &= "    IFNULL(Borrower (AccountID), '') AS 'Account Name',"
            SQL &= "    AccountNo AS 'Account Number',"
            SQL &= "    IFNULL(AppraisedBy,'') AS 'Appraised By',"
            SQL &= "    IFNULL(DATE_FORMAT(appraise_date,'%M %d, %Y'),'') AS 'Last Appraise',"
            SQL &= "    IFNULL(DATEDIFF(DATE(NOW()),appraise_date),0) AS 'Days Ago' "
            SQL &= String.Format("  FROM ropoa_realestate R LEFT JOIN (SELECT MAX(appraise_date) AS 'appraise_date', asset_number, IFNULL(Employee(Appraise_By),'') AS 'AppraisedBy' FROM appraise_re WHERE appraise = 'ROPOA' AND `status` = 'ACTIVE' GROUP BY Asset_Number) A ON R.`AssetNumber` = A.asset_number WHERE `status` = 'ACTIVE' AND sell_status = 'SELL' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(appraise_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            GridControl6.DataSource = DataSource(SQL)
            GridView6.Columns("Account Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView6.Columns("Account Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView6.RowCount > 19 Then
                GridColumn278.Width = 181 - 8
                GridColumn281.Width = 181 - 9
            Else
                GridColumn278.Width = 181
                GridColumn281.Width = 181
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If cbxAdvanced.Checked Then
            With FrmAdvanceSearchAppraisal
                .ShowDialog()
            End With
        Else
            LoadData()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("VL CREDIT APPRAISAL LIST", GridControl2)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print VL CREDIT APPRAISAL List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA VL APPRAISAL LIST", GridControl1)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print VL APPRAISAL List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            GridView3.OptionsPrint.UsePrintStyles = False
            StandardPrinting("RE CREDIT APPRAISAL LIST", GridControl3)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print RE CREDIT APPRAISAL List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            GridView4.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA RE APPRAISAL LIST", GridControl4)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print RE APPRAISAL List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            GridView5.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA VL FOR APPRAISAL LIST", GridControl5)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print VL FOR APPRAISAL List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            GridView6.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA RE FOR APPRAISAL LIST", GridControl6)
            Logs("Appraisal Management", "Print", "[SENSITIVE] Print RE FOR APPRAISAL List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnHide_Click(sender As Object, e As EventArgs) Handles btnHide.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GridColumn5.Visible = False
            GridColumn7.Visible = False
            GridColumn78.Visible = False
            GridColumn80.Visible = False
            GridColumn82.Visible = False
            GridColumn84.Visible = False
            GridColumn86.Visible = False
            GridColumn88.Visible = False
            GridColumn90.Visible = False
            GridColumn92.Visible = False
            GridColumn94.Visible = False
            GridColumn96.Visible = False
            GridColumn98.Visible = False
            GridColumn100.Visible = False
            GridColumn102.Visible = False
            GridColumn104.Visible = False
            GridColumn106.Visible = False
            GridColumn108.Visible = False
            GridColumn110.Visible = False
            GridColumn112.Visible = False
            GridColumn114.Visible = False
            GridColumn116.Visible = False
            GridColumn118.Visible = False
            GridColumn120.Visible = False
            GridColumn122.Visible = False
            GridColumn124.Visible = False
            GridColumn126.Visible = False
            GridColumn128.Visible = False
            GridColumn130.Visible = False
            GridColumn132.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            GridColumn12.Visible = False
            GridColumn14.Visible = False
            GridColumn16.Visible = False
            GridColumn18.Visible = False
            GridColumn20.Visible = False
            GridColumn22.Visible = False
            GridColumn24.Visible = False
            GridColumn26.Visible = False
            GridColumn28.Visible = False
            GridColumn30.Visible = False
            GridColumn32.Visible = False
            GridColumn34.Visible = False
            GridColumn36.Visible = False
            GridColumn38.Visible = False
            GridColumn40.Visible = False
            GridColumn42.Visible = False
            GridColumn44.Visible = False
            GridColumn46.Visible = False
            GridColumn48.Visible = False
            GridColumn50.Visible = False
            GridColumn52.Visible = False
            GridColumn54.Visible = False
            GridColumn56.Visible = False
            GridColumn58.Visible = False
            GridColumn60.Visible = False
            GridColumn62.Visible = False
            GridColumn64.Visible = False
            GridColumn66.Visible = False
            GridColumn68.Visible = False
            GridColumn70.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            GridColumn159.Visible = False
            GridColumn161.Visible = False
            GridColumn163.Visible = False
            GridColumn165.Visible = False
            GridColumn167.Visible = False
            GridColumn169.Visible = False
            GridColumn171.Visible = False
            GridColumn173.Visible = False
            GridColumn175.Visible = False
            GridColumn177.Visible = False
            GridColumn179.Visible = False
            GridColumn181.Visible = False
            GridColumn183.Visible = False
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            GridColumn209.Visible = False
            GridColumn211.Visible = False
            GridColumn213.Visible = False
            GridColumn215.Visible = False
            GridColumn217.Visible = False
            GridColumn219.Visible = False
            GridColumn221.Visible = False
            GridColumn223.Visible = False
            GridColumn225.Visible = False
            GridColumn227.Visible = False
            GridColumn229.Visible = False
            GridColumn231.Visible = False
            GridColumn233.Visible = False
        End If
    End Sub

    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GridColumn5.Visible = True
            GridColumn7.Visible = True
            GridColumn78.Visible = True
            GridColumn80.Visible = True
            GridColumn82.Visible = True
            GridColumn84.Visible = True
            GridColumn86.Visible = True
            GridColumn88.Visible = True
            GridColumn90.Visible = True
            GridColumn92.Visible = True
            GridColumn94.Visible = True
            GridColumn96.Visible = True
            GridColumn98.Visible = True
            GridColumn100.Visible = True
            GridColumn102.Visible = True
            GridColumn104.Visible = True
            GridColumn106.Visible = True
            GridColumn108.Visible = True
            GridColumn110.Visible = True
            GridColumn112.Visible = True
            GridColumn114.Visible = True
            GridColumn116.Visible = True
            GridColumn118.Visible = True
            GridColumn120.Visible = True
            GridColumn122.Visible = True
            GridColumn124.Visible = True
            GridColumn126.Visible = True
            GridColumn128.Visible = True
            GridColumn130.Visible = True
            GridColumn132.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            GridColumn12.Visible = True
            GridColumn14.Visible = True
            GridColumn16.Visible = True
            GridColumn18.Visible = True
            GridColumn20.Visible = True
            GridColumn22.Visible = True
            GridColumn24.Visible = True
            GridColumn26.Visible = True
            GridColumn28.Visible = True
            GridColumn30.Visible = True
            GridColumn32.Visible = True
            GridColumn34.Visible = True
            GridColumn36.Visible = True
            GridColumn38.Visible = True
            GridColumn40.Visible = True
            GridColumn42.Visible = True
            GridColumn44.Visible = True
            GridColumn46.Visible = True
            GridColumn48.Visible = True
            GridColumn50.Visible = True
            GridColumn52.Visible = True
            GridColumn54.Visible = True
            GridColumn56.Visible = True
            GridColumn58.Visible = True
            GridColumn60.Visible = True
            GridColumn62.Visible = True
            GridColumn64.Visible = True
            GridColumn66.Visible = True
            GridColumn68.Visible = True
            GridColumn70.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            GridColumn159.Visible = True
            GridColumn161.Visible = True
            GridColumn163.Visible = True
            GridColumn165.Visible = True
            GridColumn167.Visible = True
            GridColumn169.Visible = True
            GridColumn171.Visible = True
            GridColumn173.Visible = True
            GridColumn175.Visible = True
            GridColumn177.Visible = True
            GridColumn179.Visible = True
            GridColumn181.Visible = True
            GridColumn183.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            GridColumn209.Visible = True
            GridColumn211.Visible = True
            GridColumn213.Visible = True
            GridColumn215.Visible = True
            GridColumn217.Visible = True
            GridColumn219.Visible = True
            GridColumn221.Visible = True
            GridColumn223.Visible = True
            GridColumn225.Visible = True
            GridColumn227.Visible = True
            GridColumn229.Visible = True
            GridColumn231.Visible = True
            GridColumn233.Visible = True
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Appraise Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmVehicleAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            Dim DT As DataTable = DataSource(String.Format("SELECT Make, `Type`, Used, Model, Series, PlateNum, Transmission, Fuel, BodyColor, `Year`, EngineNum, ChassisNum, RegistryCert, ORNum, GrossWeight, RimHoles, MileAge, MileAgeType, DateRegistered, LTO FROM ropoa_vehicle WHERE AssetNumber = '{0}';", GridView1.GetFocusedRowCellValue("Asset Number")))
            If DT.Rows.Count > 0 Then
                .TotalImage_II = GridView1.GetFocusedRowCellValue("Attach_2")
                .btnSave.Text = "Update"
                .dtpDate.Value = GridView1.GetFocusedRowCellValue("Date")
                .txtAppraiseNumber.Text = GridView1.GetFocusedRowCellValue("Appraise Number")
                .vAppraised = GridView1.GetFocusedRowCellValue("Appraised By")
                .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
                .cbxAppraiseFor.Text = "ROPOA"
                .vMake = DT(0)("Make")
                .vType = DT(0)("Type")
                .cbxUsed.Text = DT(0)("Used")
                .vModel = DT(0)("Model")
                .txtSeries.Text = DT(0)("Series")
                .txtPlateNum.Text = DT(0)("PlateNum")
                .cbxTransmission.Text = DT(0)("Transmission")
                .vFuel = DT(0)("Fuel")
                .cbxBodyColor.Text = DT(0)("BodyColor")
                If DT(0)("Year") = "" Then
                    .dtpYear.CustomFormat = ""
                Else
                    .dtpYear.CustomFormat = "     yyyy"
                    .dtpYear.Value = CDate(DT(0)("Year") & "-01-01")
                End If
                .cbxEngineNumber.Text = DT(0)("EngineNum")
                .txtChassisNum.Text = DT(0)("ChassisNum")
                .txtRegistryCert.Text = DT(0)("RegistryCert")
                .txtORNum.Text = DT(0)("ORNum")
                .dGrossWeight.Value = DT(0)("GrossWeight")
                .iRim.Value = CInt(DT(0)("RimHoles"))
                .dMileAge.Value = CDbl(DT(0)("MileAge"))
                .vMileAge = DT(0)("MileAgeType")
                If DT(0)("DateRegistered") = "" Then
                    .cbxNA.Checked = True
                    .dtpRegistered.CustomFormat = ""
                Else
                    .cbxNA.Checked = False
                    .dtpRegistered.CustomFormat = "MMMM dd, yyyy"
                    .dtpRegistered.Value = DT(0)("DateRegistered")
                End If
                .txtLTO.Text = DT(0)("LTO")

                'Enabled False
                .PanelEx4.Enabled = False
                .PanelEx1.Enabled = False
                'Engine
                If GridView1.GetFocusedRowCellValue("Engine") = "G" Then
                    .cbxEngine_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Engine") = "F" Then
                    .cbxEngine_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Engine") = "P" Then
                    .cbxEngine_P.Checked = True
                End If
                .txtEngine.Text = GridView1.GetFocusedRowCellValue("Engine Remarks")
                .txtEngine.Tag = GridView1.GetFocusedRowCellValue("Engine Remarks")
                .cbxEngine_G.Tag = GridView1.GetFocusedRowCellValue("Engine")
                .cbxEngine_F.Tag = GridView1.GetFocusedRowCellValue("Engine")
                .cbxEngine_P.Tag = GridView1.GetFocusedRowCellValue("Engine")
                'Steering
                If GridView1.GetFocusedRowCellValue("Steering") = "G" Then
                    .cbxSteering_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Steering") = "F" Then
                    .cbxSteering_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Steering") = "P" Then
                    .cbxSteering_P.Checked = True
                End If
                .txtSteering.Text = GridView1.GetFocusedRowCellValue("Steering Remarks")
                .txtSteering.Tag = GridView1.GetFocusedRowCellValue("Steering Remarks")
                .cbxSteering_G.Tag = GridView1.GetFocusedRowCellValue("Steering")
                .cbxSteering_F.Tag = GridView1.GetFocusedRowCellValue("Steering")
                .cbxSteering_P.Tag = GridView1.GetFocusedRowCellValue("Steering")
                'Clutch
                If GridView1.GetFocusedRowCellValue("Clutch") = "G" Then
                    .cbxClutch_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Clutch") = "F" Then
                    .cbxClutch_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Clutch") = "P" Then
                    .cbxClutch_P.Checked = True
                End If
                .txtClutch.Text = GridView1.GetFocusedRowCellValue("Clutch Remarks")
                .txtClutch.Tag = GridView1.GetFocusedRowCellValue("Clutch Remarks")
                .cbxClutch_G.Tag = GridView1.GetFocusedRowCellValue("Clutch")
                .cbxClutch_F.Tag = GridView1.GetFocusedRowCellValue("Clutch")
                .cbxClutch_P.Tag = GridView1.GetFocusedRowCellValue("Clutch")
                'Head Light
                If GridView1.GetFocusedRowCellValue("Head Light") = "G" Then
                    .cbxHeadLight_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Head Light") = "F" Then
                    .cbxHeadLight_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Head Light") = "P" Then
                    .cbxHeadLight_P.Checked = True
                End If
                .txtHeadLight.Text = GridView1.GetFocusedRowCellValue("Head Light Remarks")
                .txtHeadLight.Tag = GridView1.GetFocusedRowCellValue("Head Light Remarks")
                .cbxHeadLight_G.Tag = GridView1.GetFocusedRowCellValue("Head Light")
                .cbxHeadLight_F.Tag = GridView1.GetFocusedRowCellValue("Head Light")
                .cbxHeadLight_P.Tag = GridView1.GetFocusedRowCellValue("Head Light")
                'Signal Light
                If GridView1.GetFocusedRowCellValue("Signal Light") = "G" Then
                    .cbxSignalLight_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Signal Light") = "F" Then
                    .cbxSignalLight_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Signal Light") = "P" Then
                    .cbxSignalLight_P.Checked = True
                End If
                .txtSignalLight.Text = GridView1.GetFocusedRowCellValue("Signal Light Remarks")
                .txtSignalLight.Tag = GridView1.GetFocusedRowCellValue("Signal Light Remarks")
                .cbxSignalLight_G.Tag = GridView1.GetFocusedRowCellValue("Signal Light")
                .cbxSignalLight_F.Tag = GridView1.GetFocusedRowCellValue("Signal Light")
                .cbxSignalLight_P.Tag = GridView1.GetFocusedRowCellValue("Signal Light")
                'Shock
                If GridView1.GetFocusedRowCellValue("Shock") = "G" Then
                    .cbxShock_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Shock") = "F" Then
                    .cbxShock_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Shock") = "P" Then
                    .cbxShock_P.Checked = True
                End If
                .txtShock.Text = GridView1.GetFocusedRowCellValue("Shock Remarks")
                .txtShock.Tag = GridView1.GetFocusedRowCellValue("Shock Remarks")
                .cbxShock_G.Tag = GridView1.GetFocusedRowCellValue("Shock")
                .cbxShock_F.Tag = GridView1.GetFocusedRowCellValue("Shock")
                .cbxShock_P.Tag = GridView1.GetFocusedRowCellValue("Shock")
                'Underchassis
                If GridView1.GetFocusedRowCellValue("Underchassis") = "G" Then
                    .cbxUnderchassis_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Underchassis") = "F" Then
                    .cbxUnderchassis_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Underchassis") = "P" Then
                    .cbxUnderchassis_P.Checked = True
                End If
                .txtUnderchassis.Text = GridView1.GetFocusedRowCellValue("Underchassis Remarks")
                .txtUnderchassis.Tag = GridView1.GetFocusedRowCellValue("Underchassis Remarks")
                .cbxUnderchassis_G.Tag = GridView1.GetFocusedRowCellValue("Underchassis")
                .cbxUnderchassis_F.Tag = GridView1.GetFocusedRowCellValue("Underchassis")
                .cbxUnderchassis_P.Tag = GridView1.GetFocusedRowCellValue("Underchassis")
                'Upholstery
                If GridView1.GetFocusedRowCellValue("Upholstery") = "G" Then
                    .cbxUpholstery_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Upholstery") = "F" Then
                    .cbxUpholstery_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Upholstery") = "P" Then
                    .cbxUpholstery_P.Checked = True
                End If
                .txtUpholstery.Text = GridView1.GetFocusedRowCellValue("Upholstery Remarks")
                .txtUpholstery.Tag = GridView1.GetFocusedRowCellValue("Upholstery Remarks")
                .cbxUpholstery_G.Tag = GridView1.GetFocusedRowCellValue("Upholstery")
                .cbxUpholstery_F.Tag = GridView1.GetFocusedRowCellValue("Upholstery")
                .cbxUpholstery_P.Tag = GridView1.GetFocusedRowCellValue("Upholstery")
                'Temp Gauge
                If GridView1.GetFocusedRowCellValue("Temp Gauge") = "G" Then
                    .cbxTempGauge_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Temp Gauge") = "F" Then
                    .cbxTempGauge_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Temp Gauge") = "P" Then
                    .cbxTempGauge_P.Checked = True
                End If
                .txtTempGauge.Text = GridView1.GetFocusedRowCellValue("Temp Gauge Remarks")
                .txtTempGauge.Tag = GridView1.GetFocusedRowCellValue("Temp Gauge Remarks")
                .cbxTempGauge_G.Tag = GridView1.GetFocusedRowCellValue("Temp Gauge")
                .cbxTempGauge_F.Tag = GridView1.GetFocusedRowCellValue("Temp Gauge")
                .cbxTempGauge_P.Tag = GridView1.GetFocusedRowCellValue("Temp Gauge")
                'Odometer
                If GridView1.GetFocusedRowCellValue("Odometer") = "G" Then
                    .cbxOdometer_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Odometer") = "F" Then
                    .cbxOdometer_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Odometer") = "P" Then
                    .cbxOdometer_P.Checked = True
                End If
                .txtOdometer.Text = GridView1.GetFocusedRowCellValue("Odometer Remarks")
                .txtOdometer.Tag = GridView1.GetFocusedRowCellValue("Odometer Remarks")
                .cbxOdometer_G.Tag = GridView1.GetFocusedRowCellValue("Odometer")
                .cbxOdometer_F.Tag = GridView1.GetFocusedRowCellValue("Odometer")
                .cbxOdometer_P.Tag = GridView1.GetFocusedRowCellValue("Odometer")
                'Transmission
                If GridView1.GetFocusedRowCellValue("Transmission") = "G" Then
                    .cbxTransmission_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Transmission") = "F" Then
                    .cbxTransmission_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Transmission") = "P" Then
                    .cbxTransmission_P.Checked = True
                End If
                .txtTransmission.Text = GridView1.GetFocusedRowCellValue("Transmission Remarks")
                .txtTransmission.Tag = GridView1.GetFocusedRowCellValue("Transmission Remarks")
                .cbxTransmission_G.Tag = GridView1.GetFocusedRowCellValue("Transmission")
                .cbxTransmission_F.Tag = GridView1.GetFocusedRowCellValue("Transmission")
                .cbxTransmission_P.Tag = GridView1.GetFocusedRowCellValue("Transmission")
                'Tires
                .dTires.Value = CDbl(GridView1.GetFocusedRowCellValue("Tires"))
                .dTires.Tag = CDbl(GridView1.GetFocusedRowCellValue("Tires"))
                .txtTires.Text = GridView1.GetFocusedRowCellValue("Tires Remarks")
                .txtTires.Tag = GridView1.GetFocusedRowCellValue("Tires Remarks")
                'Acceleration
                If GridView1.GetFocusedRowCellValue("Acceleration") = "G" Then
                    .cbxAcceleration_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Acceleration") = "F" Then
                    .cbxAcceleration_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Acceleration") = "P" Then
                    .cbxAcceleration_P.Checked = True
                End If
                .txtAcceleration.Text = GridView1.GetFocusedRowCellValue("Acceleration Remarks")
                .txtAcceleration.Tag = GridView1.GetFocusedRowCellValue("Acceleration Remarks")
                .cbxAcceleration_G.Tag = GridView1.GetFocusedRowCellValue("Acceleration")
                .cbxAcceleration_F.Tag = GridView1.GetFocusedRowCellValue("Acceleration")
                .cbxAcceleration_P.Tag = GridView1.GetFocusedRowCellValue("Acceleration")
                'Parklight
                If GridView1.GetFocusedRowCellValue("Park Light") = "G" Then
                    .cbxParkLight_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Park Light") = "F" Then
                    .cbxParkLight_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Park Light") = "P" Then
                    .cbxParkLight_P.Checked = True
                End If
                .txtParkLight.Text = GridView1.GetFocusedRowCellValue("Park Light Remarks")
                .txtParkLight.Tag = GridView1.GetFocusedRowCellValue("Park Light Remarks")
                .cbxParkLight_G.Tag = GridView1.GetFocusedRowCellValue("Park Light")
                .cbxParkLight_F.Tag = GridView1.GetFocusedRowCellValue("Park Light")
                .cbxParkLight_P.Tag = GridView1.GetFocusedRowCellValue("Park Light")
                'Horn
                If GridView1.GetFocusedRowCellValue("Horn") = "G" Then
                    .cbxHorn_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Horn") = "F" Then
                    .cbxHorn_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Horn") = "P" Then
                    .cbxHorn_P.Checked = True
                End If
                .txtHorn.Text = GridView1.GetFocusedRowCellValue("Horn Remarks")
                .txtHorn.Tag = GridView1.GetFocusedRowCellValue("Horn Remarks")
                .cbxHorn_G.Tag = GridView1.GetFocusedRowCellValue("Horn")
                .cbxHorn_F.Tag = GridView1.GetFocusedRowCellValue("Horn")
                .cbxHorn_P.Tag = GridView1.GetFocusedRowCellValue("Horn")
                'Chassis
                If GridView1.GetFocusedRowCellValue("Chassis") = "G" Then
                    .cbxChassis_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Chassis") = "F" Then
                    .cbxChassis_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Chassis") = "P" Then
                    .cbxChassis_P.Checked = True
                End If
                .txtChassis.Text = GridView1.GetFocusedRowCellValue("Chassis Remarks")
                .txtChassis.Tag = GridView1.GetFocusedRowCellValue("Chassis Remarks")
                .cbxChassis_G.Tag = GridView1.GetFocusedRowCellValue("Chassis")
                .cbxChassis_F.Tag = GridView1.GetFocusedRowCellValue("Chassis")
                .cbxChassis_P.Tag = GridView1.GetFocusedRowCellValue("Chassis")
                'Front Bumper
                If GridView1.GetFocusedRowCellValue("Front Bumper") = "G" Then
                    .cbxFrontBumper_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Front Bumper") = "F" Then
                    .cbxFrontBumper_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Front Bumper") = "P" Then
                    .cbxFrontBumper_P.Checked = True
                End If
                .txtFrontBumper.Text = GridView1.GetFocusedRowCellValue("Front Bumper Remarks")
                .txtFrontBumper.Tag = GridView1.GetFocusedRowCellValue("Front Bumper Remarks")
                .cbxFrontBumper_G.Tag = GridView1.GetFocusedRowCellValue("Front Bumper")
                .cbxFrontBumper_F.Tag = GridView1.GetFocusedRowCellValue("Front Bumper")
                .cbxFrontBumper_P.Tag = GridView1.GetFocusedRowCellValue("Front Bumper")
                'Ampheres
                If GridView1.GetFocusedRowCellValue("Ampheres") = "G" Then
                    .cbxAmpheres_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Ampheres") = "F" Then
                    .cbxAmpheres_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Ampheres") = "P" Then
                    .cbxAmpheres_P.Checked = True
                End If
                .txtAmpheres.Text = GridView1.GetFocusedRowCellValue("Ampheres Remarks")
                .txtAmpheres.Tag = GridView1.GetFocusedRowCellValue("Ampheres Remarks")
                .cbxAmpheres_G.Tag = GridView1.GetFocusedRowCellValue("Ampheres")
                .cbxAmpheres_F.Tag = GridView1.GetFocusedRowCellValue("Ampheres")
                .cbxAmpheres_P.Tag = GridView1.GetFocusedRowCellValue("Ampheres")
                'Fuel
                If GridView1.GetFocusedRowCellValue("Fuel") = "G" Then
                    .cbxFuel_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Fuel") = "F" Then
                    .cbxFuel_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Fuel") = "P" Then
                    .cbxFuel_P.Checked = True
                End If
                .txtFuel.Text = GridView1.GetFocusedRowCellValue("Fuel Remarks")
                .txtFuel.Tag = GridView1.GetFocusedRowCellValue("Fuel Remarks")
                .cbxFuel_G.Tag = GridView1.GetFocusedRowCellValue("Fuel")
                .cbxFuel_F.Tag = GridView1.GetFocusedRowCellValue("Fuel")
                .cbxFuel_P.Tag = GridView1.GetFocusedRowCellValue("Fuel")
                'Starter
                If GridView1.GetFocusedRowCellValue("Starter") = "G" Then
                    .cbxStarter_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Starter") = "F" Then
                    .cbxStarter_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Starter") = "P" Then
                    .cbxStarter_P.Checked = True
                End If
                .txtStarter.Text = GridView1.GetFocusedRowCellValue("Starter Remarks")
                .txtStarter.Tag = GridView1.GetFocusedRowCellValue("Starter Remarks")
                .cbxStarter_G.Tag = GridView1.GetFocusedRowCellValue("Starter")
                .cbxStarter_F.Tag = GridView1.GetFocusedRowCellValue("Starter")
                .cbxStarter_P.Tag = GridView1.GetFocusedRowCellValue("Starter")
                'Differential
                If GridView1.GetFocusedRowCellValue("Differential") = "G" Then
                    .cbxDifferential_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Differential") = "F" Then
                    .cbxDifferential_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Differential") = "P" Then
                    .cbxDifferential_P.Checked = True
                End If
                .txtDifferential.Text = GridView1.GetFocusedRowCellValue("Differential Remarks")
                .txtDifferential.Tag = GridView1.GetFocusedRowCellValue("Differential Remarks")
                .cbxDifferential_G.Tag = GridView1.GetFocusedRowCellValue("Differential")
                .cbxDifferential_F.Tag = GridView1.GetFocusedRowCellValue("Differential")
                .cbxDifferential_P.Tag = GridView1.GetFocusedRowCellValue("Differential")
                'Brakes
                If GridView1.GetFocusedRowCellValue("Brakes") = "G" Then
                    .cbxBrakes_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Brakes") = "F" Then
                    .cbxBrakes_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Brakes") = "P" Then
                    .cbxBrakes_P.Checked = True
                End If
                .txtBrakes.Text = GridView1.GetFocusedRowCellValue("Brakes Remarks")
                .txtBrakes.Tag = GridView1.GetFocusedRowCellValue("Brakes Remarks")
                .cbxBrakes_G.Tag = GridView1.GetFocusedRowCellValue("Brakes")
                .cbxBrakes_F.Tag = GridView1.GetFocusedRowCellValue("Brakes")
                .cbxBrakes_P.Tag = GridView1.GetFocusedRowCellValue("Brakes")
                'Wiper
                If GridView1.GetFocusedRowCellValue("Wiper") = "G" Then
                    .cbxWiper_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Wiper") = "F" Then
                    .cbxWiper_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Wiper") = "P" Then
                    .cbxWiper_P.Checked = True
                End If
                .txtWiper.Text = GridView1.GetFocusedRowCellValue("Wiper Remarks")
                .txtWiper.Tag = GridView1.GetFocusedRowCellValue("Wiper Remarks")
                .cbxWiper_G.Tag = GridView1.GetFocusedRowCellValue("Wiper")
                .cbxWiper_F.Tag = GridView1.GetFocusedRowCellValue("Wiper")
                .cbxWiper_P.Tag = GridView1.GetFocusedRowCellValue("Wiper")
                'Backup
                If GridView1.GetFocusedRowCellValue("Back Up") = "G" Then
                    .cbxBackUp_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Back Up") = "F" Then
                    .cbxBackUp_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Back Up") = "P" Then
                    .cbxBackUp_P.Checked = True
                End If
                .txtBackUp.Text = GridView1.GetFocusedRowCellValue("Back Up Remarks")
                .txtBackUp.Tag = GridView1.GetFocusedRowCellValue("Back Up Remarks")
                .cbxBackUp_G.Tag = GridView1.GetFocusedRowCellValue("Back Up")
                .cbxBackUp_F.Tag = GridView1.GetFocusedRowCellValue("Back Up")
                .cbxBackUp_P.Tag = GridView1.GetFocusedRowCellValue("Back Up")
                'SideMirror
                If GridView1.GetFocusedRowCellValue("Side Mirror") = "G" Then
                    .cbxSideMirror_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Side Mirror") = "F" Then
                    .cbxSideMirror_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Side Mirror") = "P" Then
                    .cbxSideMirror_P.Checked = True
                End If
                .txtSideMirror.Text = GridView1.GetFocusedRowCellValue("Side Mirror Remarks")
                .txtSideMirror.Tag = GridView1.GetFocusedRowCellValue("Side Mirror Remarks")
                .cbxSideMirror_G.Tag = GridView1.GetFocusedRowCellValue("Side Mirror")
                .cbxSideMirror_F.Tag = GridView1.GetFocusedRowCellValue("Side Mirror")
                .cbxSideMirror_P.Tag = GridView1.GetFocusedRowCellValue("Side Mirror")
                'Body Flooring
                If GridView1.GetFocusedRowCellValue("Body Flooring") = "G" Then
                    .cbxBodyFlooring_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Body Flooring") = "F" Then
                    .cbxBodyFlooring_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Body Flooring") = "P" Then
                    .cbxBodyFlooring_P.Checked = True
                End If
                .txtBodyFlooring.Text = GridView1.GetFocusedRowCellValue("Body Flooring Remarks")
                .txtBodyFlooring.Tag = GridView1.GetFocusedRowCellValue("Body Flooring Remarks")
                .cbxBodyFlooring_G.Tag = GridView1.GetFocusedRowCellValue("Body Flooring")
                .cbxBodyFlooring_F.Tag = GridView1.GetFocusedRowCellValue("Body Flooring")
                .cbxBodyFlooring_P.Tag = GridView1.GetFocusedRowCellValue("Body Flooring")
                'Rear Bumper
                If GridView1.GetFocusedRowCellValue("Rear Bumper") = "G" Then
                    .cbxRearBumper_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Rear Bumper") = "F" Then
                    .cbxRearBumper_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Rear Bumper") = "P" Then
                    .cbxRearBumper_P.Checked = True
                End If
                .txtRearBumper.Text = GridView1.GetFocusedRowCellValue("Rear Bumper Remarks")
                .txtRearBumper.Tag = GridView1.GetFocusedRowCellValue("Rear Bumper Remarks")
                .cbxRearBumper_G.Tag = GridView1.GetFocusedRowCellValue("Rear Bumper")
                .cbxRearBumper_F.Tag = GridView1.GetFocusedRowCellValue("Rear Bumper")
                .cbxRearBumper_P.Tag = GridView1.GetFocusedRowCellValue("Rear Bumper")
                'Oil Pressure
                If GridView1.GetFocusedRowCellValue("Oil Pressure") = "G" Then
                    .cbxOilPressure_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Oil Pressure") = "F" Then
                    .cbxOilPressure_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Oil Pressure") = "P" Then
                    .cbxOilPressure_P.Checked = True
                End If
                .txtOilPressure.Text = GridView1.GetFocusedRowCellValue("Oil Pressure Remarks")
                .txtOilPressure.Tag = GridView1.GetFocusedRowCellValue("Oil Pressure Remarks")
                .cbxOilPressure_G.Tag = GridView1.GetFocusedRowCellValue("Oil Pressure")
                .cbxOilPressure_F.Tag = GridView1.GetFocusedRowCellValue("Oil Pressure")
                .cbxOilPressure_P.Tag = GridView1.GetFocusedRowCellValue("Oil Pressure")
                'Speedometer
                If GridView1.GetFocusedRowCellValue("Speedometer") = "G" Then
                    .cbxSpeedometer_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Speedometer") = "F" Then
                    .cbxSpeedometer_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Speedometer") = "P" Then
                    .cbxSpeedometer_P.Checked = True
                End If
                .txtSpeedometer.Text = GridView1.GetFocusedRowCellValue("Speedometer Remarks")
                .txtSpeedometer.Tag = GridView1.GetFocusedRowCellValue("Speedometer Remarks")
                .cbxSpeedometer_G.Tag = GridView1.GetFocusedRowCellValue("Speedometer")
                .cbxSpeedometer_F.Tag = GridView1.GetFocusedRowCellValue("Speedometer")
                .cbxSpeedometer_P.Tag = GridView1.GetFocusedRowCellValue("Speedometer")
                'Body Paint
                If GridView1.GetFocusedRowCellValue("Body Paint") = "G" Then
                    .cbxBodyPaint_G.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Body Paint") = "F" Then
                    .cbxBodyPaint_F.Checked = True
                ElseIf GridView1.GetFocusedRowCellValue("Body Paint") = "P" Then
                    .cbxBodyPaint_P.Checked = True
                End If
                .cbxBodyPaint_G.Tag = GridView1.GetFocusedRowCellValue("Body Paint")
                .cbxBodyPaint_F.Tag = GridView1.GetFocusedRowCellValue("Body Paint")
                .cbxBodyPaint_P.Tag = GridView1.GetFocusedRowCellValue("Body Paint")
                .txtBodyPaint.Text = GridView1.GetFocusedRowCellValue("Body Paint Remarks")
                .txtBodyPaint.Tag = GridView1.GetFocusedRowCellValue("Body Paint Remarks")

                .rRemarks.Text = GridView1.GetFocusedRowCellValue("Appraiser Remarks")
                .rRemarks.Tag = GridView1.GetFocusedRowCellValue("Appraiser Remarks")
                .txtSource.Text = GridView1.GetFocusedRowCellValue("Source")
                .txtSource.Tag = GridView1.GetFocusedRowCellValue("Source")
                .txtTelephoneNum.Text = GridView1.GetFocusedRowCellValue("Telephone Num")
                .txtTelephoneNum.Tag = GridView1.GetFocusedRowCellValue("Telephone Num")
                .dSellingPrice.Value = CDbl(GridView1.GetFocusedRowCellValue("Selling Price"))
                .dSellingPrice.Tag = CDbl(GridView1.GetFocusedRowCellValue("Selling Price"))
                .dFairMarketValue.Value = CDbl(GridView1.GetFocusedRowCellValue("Market Value"))
                .dFairMarketValue.Tag = CDbl(GridView1.GetFocusedRowCellValue("Market Value"))
                .dAppraisedValue.Value = CDbl(GridView1.GetFocusedRowCellValue("Appraised Value"))
                .dAppraisedValue.Tag = CDbl(GridView1.GetFocusedRowCellValue("Appraised Value"))

                If GridView1.GetFocusedRowCellValue("Branch_ID") = Branch_ID Then
                    .btnModify.Enabled = True
                    .btnAddImage.Enabled = True
                    .btnAttach.Enabled = True
                Else
                    .btnPrint.Enabled = False
                End If
                .btnRefresh.Enabled = False
                .btnSave.Enabled = False
                .PanelEx2.Enabled = False
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End If
        End With
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Try
            If GridView2.GetFocusedRowCellValue("Appraise Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmVehicleAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            Dim DT As DataTable = DataSource(String.Format("SELECT Make, `Type`, Used, Model, Series, PlateNum, Transmission, Fuel, BodyColor, `Year`, EngineNum, ChassisNum, RegistryCert, ORNum, GrossWeight, RimHoles, MileAge, MileAgeType, DateRegistered, LTO FROM collateral_ve WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetFocusedRowCellValue("Credit Number")))
            If DT.Rows.Count > 0 Then
                .TotalImage_II = GridView2.GetFocusedRowCellValue("Attach_2")
                .btnSave.Text = "Update"
                .dtpDate.Value = GridView2.GetFocusedRowCellValue("Date")
                .txtAppraiseNumber.Text = GridView2.GetFocusedRowCellValue("Appraise Number")
                .vAppraised = GridView2.GetFocusedRowCellValue("Appraised By")
                .CreditNumber = GridView2.GetFocusedRowCellValue("Credit Number")
                .cbxAppraiseFor.Text = "Credit Application"
                .vMake = DT(0)("Make")
                .vType = DT(0)("Type")
                .cbxUsed.Text = DT(0)("Used")
                .vModel = DT(0)("Model")
                .txtSeries.Text = DT(0)("Series")
                .txtPlateNum.Text = DT(0)("PlateNum")
                .cbxTransmission.Text = DT(0)("Transmission")
                .vFuel = DT(0)("Fuel")
                .cbxBodyColor.Text = DT(0)("BodyColor")
                If DT(0)("Year") = "" Then
                    .dtpYear.CustomFormat = ""
                Else
                    .dtpYear.CustomFormat = "     yyyy"
                    .dtpYear.Value = CDate(DT(0)("Year") & "-01-01")
                End If
                .cbxEngineNumber.Text = DT(0)("EngineNum")
                .txtChassisNum.Text = DT(0)("ChassisNum")
                .txtRegistryCert.Text = DT(0)("RegistryCert")
                .txtORNum.Text = DT(0)("ORNum")
                .dGrossWeight.Value = DT(0)("GrossWeight")
                .iRim.Value = CInt(DT(0)("RimHoles"))
                .dMileAge.Value = CDbl(DT(0)("MileAge"))
                .vMileAge = DT(0)("MileAgeType")
                If DT(0)("DateRegistered") = "" Then
                    .cbxNA.Checked = True
                    .dtpRegistered.CustomFormat = ""
                Else
                    .cbxNA.Checked = False
                    .dtpRegistered.CustomFormat = "MMMM dd, yyyy"
                    .dtpRegistered.Value = DT(0)("DateRegistered")
                End If
                .txtLTO.Text = DT(0)("LTO")

                'Enabled False
                .PanelEx4.Enabled = False
                .PanelEx1.Enabled = False
                'Engine
                If GridView2.GetFocusedRowCellValue("Engine") = "G" Then
                    .cbxEngine_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Engine") = "F" Then
                    .cbxEngine_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Engine") = "P" Then
                    .cbxEngine_P.Checked = True
                End If
                .txtEngine.Text = GridView2.GetFocusedRowCellValue("Engine Remarks")
                .txtEngine.Tag = GridView2.GetFocusedRowCellValue("Engine Remarks")
                .cbxEngine_G.Tag = GridView2.GetFocusedRowCellValue("Engine")
                .cbxEngine_F.Tag = GridView2.GetFocusedRowCellValue("Engine")
                .cbxEngine_P.Tag = GridView2.GetFocusedRowCellValue("Engine")
                'Steering
                If GridView2.GetFocusedRowCellValue("Steering") = "G" Then
                    .cbxSteering_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Steering") = "F" Then
                    .cbxSteering_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Steering") = "P" Then
                    .cbxSteering_P.Checked = True
                End If
                .txtSteering.Text = GridView2.GetFocusedRowCellValue("Steering Remarks")
                .txtSteering.Tag = GridView2.GetFocusedRowCellValue("Steering Remarks")
                .cbxSteering_G.Tag = GridView2.GetFocusedRowCellValue("Steering")
                .cbxSteering_F.Tag = GridView2.GetFocusedRowCellValue("Steering")
                .cbxSteering_P.Tag = GridView2.GetFocusedRowCellValue("Steering")
                'Clutch
                If GridView2.GetFocusedRowCellValue("Clutch") = "G" Then
                    .cbxClutch_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Clutch") = "F" Then
                    .cbxClutch_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Clutch") = "P" Then
                    .cbxClutch_P.Checked = True
                End If
                .txtClutch.Text = GridView2.GetFocusedRowCellValue("Clutch Remarks")
                .txtClutch.Tag = GridView2.GetFocusedRowCellValue("Clutch Remarks")
                .cbxClutch_G.Tag = GridView2.GetFocusedRowCellValue("Clutch")
                .cbxClutch_F.Tag = GridView2.GetFocusedRowCellValue("Clutch")
                .cbxClutch_P.Tag = GridView2.GetFocusedRowCellValue("Clutch")
                'Head Light
                If GridView2.GetFocusedRowCellValue("Head Light") = "G" Then
                    .cbxHeadLight_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Head Light") = "F" Then
                    .cbxHeadLight_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Head Light") = "P" Then
                    .cbxHeadLight_P.Checked = True
                End If
                .txtHeadLight.Text = GridView2.GetFocusedRowCellValue("Head Light Remarks")
                .txtHeadLight.Tag = GridView2.GetFocusedRowCellValue("Head Light Remarks")
                .cbxHeadLight_G.Tag = GridView2.GetFocusedRowCellValue("Head Light")
                .cbxHeadLight_F.Tag = GridView2.GetFocusedRowCellValue("Head Light")
                .cbxHeadLight_P.Tag = GridView2.GetFocusedRowCellValue("Head Light")
                'Signal Light
                If GridView2.GetFocusedRowCellValue("Signal Light") = "G" Then
                    .cbxSignalLight_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Signal Light") = "F" Then
                    .cbxSignalLight_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Signal Light") = "P" Then
                    .cbxSignalLight_P.Checked = True
                End If
                .txtSignalLight.Text = GridView2.GetFocusedRowCellValue("Signal Light Remarks")
                .txtSignalLight.Tag = GridView2.GetFocusedRowCellValue("Signal Light Remarks")
                .cbxSignalLight_G.Tag = GridView2.GetFocusedRowCellValue("Signal Light")
                .cbxSignalLight_F.Tag = GridView2.GetFocusedRowCellValue("Signal Light")
                .cbxSignalLight_P.Tag = GridView2.GetFocusedRowCellValue("Signal Light")
                'Shock
                If GridView2.GetFocusedRowCellValue("Shock") = "G" Then
                    .cbxShock_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Shock") = "F" Then
                    .cbxShock_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Shock") = "P" Then
                    .cbxShock_P.Checked = True
                End If
                .txtShock.Text = GridView2.GetFocusedRowCellValue("Shock Remarks")
                .txtShock.Tag = GridView2.GetFocusedRowCellValue("Shock Remarks")
                .cbxShock_G.Tag = GridView2.GetFocusedRowCellValue("Shock")
                .cbxShock_F.Tag = GridView2.GetFocusedRowCellValue("Shock")
                .cbxShock_P.Tag = GridView2.GetFocusedRowCellValue("Shock")
                'Underchassis
                If GridView2.GetFocusedRowCellValue("Underchassis") = "G" Then
                    .cbxUnderchassis_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Underchassis") = "F" Then
                    .cbxUnderchassis_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Underchassis") = "P" Then
                    .cbxUnderchassis_P.Checked = True
                End If
                .txtUnderchassis.Text = GridView2.GetFocusedRowCellValue("Underchassis Remarks")
                .txtUnderchassis.Tag = GridView2.GetFocusedRowCellValue("Underchassis Remarks")
                .cbxUnderchassis_G.Tag = GridView2.GetFocusedRowCellValue("Underchassis")
                .cbxUnderchassis_F.Tag = GridView2.GetFocusedRowCellValue("Underchassis")
                .cbxUnderchassis_P.Tag = GridView2.GetFocusedRowCellValue("Underchassis")
                'Upholstery
                If GridView2.GetFocusedRowCellValue("Upholstery") = "G" Then
                    .cbxUpholstery_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Upholstery") = "F" Then
                    .cbxUpholstery_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Upholstery") = "P" Then
                    .cbxUpholstery_P.Checked = True
                End If
                .txtUpholstery.Text = GridView2.GetFocusedRowCellValue("Upholstery Remarks")
                .txtUpholstery.Tag = GridView2.GetFocusedRowCellValue("Upholstery Remarks")
                .cbxUpholstery_G.Tag = GridView2.GetFocusedRowCellValue("Upholstery")
                .cbxUpholstery_F.Tag = GridView2.GetFocusedRowCellValue("Upholstery")
                .cbxUpholstery_P.Tag = GridView2.GetFocusedRowCellValue("Upholstery")
                'Temp Gauge
                If GridView2.GetFocusedRowCellValue("Temp Gauge") = "G" Then
                    .cbxTempGauge_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Temp Gauge") = "F" Then
                    .cbxTempGauge_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Temp Gauge") = "P" Then
                    .cbxTempGauge_P.Checked = True
                End If
                .txtTempGauge.Text = GridView2.GetFocusedRowCellValue("Temp Gauge Remarks")
                .txtTempGauge.Tag = GridView2.GetFocusedRowCellValue("Temp Gauge Remarks")
                .cbxTempGauge_G.Tag = GridView2.GetFocusedRowCellValue("Temp Gauge")
                .cbxTempGauge_F.Tag = GridView2.GetFocusedRowCellValue("Temp Gauge")
                .cbxTempGauge_P.Tag = GridView2.GetFocusedRowCellValue("Temp Gauge")
                'Odometer
                If GridView2.GetFocusedRowCellValue("Odometer") = "G" Then
                    .cbxOdometer_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Odometer") = "F" Then
                    .cbxOdometer_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Odometer") = "P" Then
                    .cbxOdometer_P.Checked = True
                End If
                .txtOdometer.Text = GridView2.GetFocusedRowCellValue("Odometer Remarks")
                .txtOdometer.Tag = GridView2.GetFocusedRowCellValue("Odometer Remarks")
                .cbxOdometer_G.Tag = GridView2.GetFocusedRowCellValue("Odometer")
                .cbxOdometer_F.Tag = GridView2.GetFocusedRowCellValue("Odometer")
                .cbxOdometer_P.Tag = GridView2.GetFocusedRowCellValue("Odometer")
                'Transmission
                If GridView2.GetFocusedRowCellValue("Transmission") = "G" Then
                    .cbxTransmission_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Transmission") = "F" Then
                    .cbxTransmission_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Transmission") = "P" Then
                    .cbxTransmission_P.Checked = True
                End If
                .txtTransmission.Text = GridView2.GetFocusedRowCellValue("Transmission Remarks")
                .txtTransmission.Tag = GridView2.GetFocusedRowCellValue("Transmission Remarks")
                .cbxTransmission_G.Tag = GridView2.GetFocusedRowCellValue("Transmission")
                .cbxTransmission_F.Tag = GridView2.GetFocusedRowCellValue("Transmission")
                .cbxTransmission_P.Tag = GridView2.GetFocusedRowCellValue("Transmission")
                'Tires
                .dTires.Value = CDbl(GridView2.GetFocusedRowCellValue("Tires"))
                .dTires.Tag = CDbl(GridView2.GetFocusedRowCellValue("Tires"))
                .txtTires.Text = GridView2.GetFocusedRowCellValue("Tires Remarks")
                .txtTires.Tag = GridView2.GetFocusedRowCellValue("Tires Remarks")
                'Acceleration
                If GridView2.GetFocusedRowCellValue("Acceleration") = "G" Then
                    .cbxAcceleration_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Acceleration") = "F" Then
                    .cbxAcceleration_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Acceleration") = "P" Then
                    .cbxAcceleration_P.Checked = True
                End If
                .txtAcceleration.Text = GridView2.GetFocusedRowCellValue("Acceleration Remarks")
                .txtAcceleration.Tag = GridView2.GetFocusedRowCellValue("Acceleration Remarks")
                .cbxAcceleration_G.Tag = GridView2.GetFocusedRowCellValue("Acceleration")
                .cbxAcceleration_F.Tag = GridView2.GetFocusedRowCellValue("Acceleration")
                .cbxAcceleration_P.Tag = GridView2.GetFocusedRowCellValue("Acceleration")
                'Parklight
                If GridView2.GetFocusedRowCellValue("Park Light") = "G" Then
                    .cbxParkLight_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Park Light") = "F" Then
                    .cbxParkLight_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Park Light") = "P" Then
                    .cbxParkLight_P.Checked = True
                End If
                .txtParkLight.Text = GridView2.GetFocusedRowCellValue("Park Light Remarks")
                .txtParkLight.Tag = GridView2.GetFocusedRowCellValue("Park Light Remarks")
                .cbxParkLight_G.Tag = GridView2.GetFocusedRowCellValue("Park Light")
                .cbxParkLight_F.Tag = GridView2.GetFocusedRowCellValue("Park Light")
                .cbxParkLight_P.Tag = GridView2.GetFocusedRowCellValue("Park Light")
                'Horn
                If GridView2.GetFocusedRowCellValue("Horn") = "G" Then
                    .cbxHorn_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Horn") = "F" Then
                    .cbxHorn_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Horn") = "P" Then
                    .cbxHorn_P.Checked = True
                End If
                .txtHorn.Text = GridView2.GetFocusedRowCellValue("Horn Remarks")
                .txtHorn.Tag = GridView2.GetFocusedRowCellValue("Horn Remarks")
                .cbxHorn_G.Tag = GridView2.GetFocusedRowCellValue("Horn")
                .cbxHorn_F.Tag = GridView2.GetFocusedRowCellValue("Horn")
                .cbxHorn_P.Tag = GridView2.GetFocusedRowCellValue("Horn")
                'Chassis
                If GridView2.GetFocusedRowCellValue("Chassis") = "G" Then
                    .cbxChassis_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Chassis") = "F" Then
                    .cbxChassis_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Chassis") = "P" Then
                    .cbxChassis_P.Checked = True
                End If
                .txtChassis.Text = GridView2.GetFocusedRowCellValue("Chassis Remarks")
                .txtChassis.Tag = GridView2.GetFocusedRowCellValue("Chassis Remarks")
                .cbxChassis_G.Tag = GridView2.GetFocusedRowCellValue("Chassis")
                .cbxChassis_F.Tag = GridView2.GetFocusedRowCellValue("Chassis")
                .cbxChassis_P.Tag = GridView2.GetFocusedRowCellValue("Chassis")
                'Front Bumper
                If GridView2.GetFocusedRowCellValue("Front Bumper") = "G" Then
                    .cbxFrontBumper_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Front Bumper") = "F" Then
                    .cbxFrontBumper_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Front Bumper") = "P" Then
                    .cbxFrontBumper_P.Checked = True
                End If
                .txtFrontBumper.Text = GridView2.GetFocusedRowCellValue("Front Bumper Remarks")
                .txtFrontBumper.Tag = GridView2.GetFocusedRowCellValue("Front Bumper Remarks")
                .cbxFrontBumper_G.Tag = GridView2.GetFocusedRowCellValue("Front Bumper")
                .cbxFrontBumper_F.Tag = GridView2.GetFocusedRowCellValue("Front Bumper")
                .cbxFrontBumper_P.Tag = GridView2.GetFocusedRowCellValue("Front Bumper")
                'Ampheres
                If GridView2.GetFocusedRowCellValue("Ampheres") = "G" Then
                    .cbxAmpheres_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Ampheres") = "F" Then
                    .cbxAmpheres_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Ampheres") = "P" Then
                    .cbxAmpheres_P.Checked = True
                End If
                .txtAmpheres.Text = GridView2.GetFocusedRowCellValue("Ampheres Remarks")
                .txtAmpheres.Tag = GridView2.GetFocusedRowCellValue("Ampheres Remarks")
                .cbxAmpheres_G.Tag = GridView2.GetFocusedRowCellValue("Ampheres")
                .cbxAmpheres_F.Tag = GridView2.GetFocusedRowCellValue("Ampheres")
                .cbxAmpheres_P.Tag = GridView2.GetFocusedRowCellValue("Ampheres")
                'Fuel
                If GridView2.GetFocusedRowCellValue("Fuel") = "G" Then
                    .cbxFuel_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Fuel") = "F" Then
                    .cbxFuel_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Fuel") = "P" Then
                    .cbxFuel_P.Checked = True
                End If
                .txtFuel.Text = GridView2.GetFocusedRowCellValue("Fuel Remarks")
                .txtFuel.Tag = GridView2.GetFocusedRowCellValue("Fuel Remarks")
                .cbxFuel_G.Tag = GridView2.GetFocusedRowCellValue("Fuel")
                .cbxFuel_F.Tag = GridView2.GetFocusedRowCellValue("Fuel")
                .cbxFuel_P.Tag = GridView2.GetFocusedRowCellValue("Fuel")
                'Starter
                If GridView2.GetFocusedRowCellValue("Starter") = "G" Then
                    .cbxStarter_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Starter") = "F" Then
                    .cbxStarter_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Starter") = "P" Then
                    .cbxStarter_P.Checked = True
                End If
                .txtStarter.Text = GridView2.GetFocusedRowCellValue("Starter Remarks")
                .txtStarter.Tag = GridView2.GetFocusedRowCellValue("Starter Remarks")
                .cbxStarter_G.Tag = GridView2.GetFocusedRowCellValue("Starter")
                .cbxStarter_F.Tag = GridView2.GetFocusedRowCellValue("Starter")
                .cbxStarter_P.Tag = GridView2.GetFocusedRowCellValue("Starter")
                'Differential
                If GridView2.GetFocusedRowCellValue("Differential") = "G" Then
                    .cbxDifferential_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Differential") = "F" Then
                    .cbxDifferential_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Differential") = "P" Then
                    .cbxDifferential_P.Checked = True
                End If
                .txtDifferential.Text = GridView2.GetFocusedRowCellValue("Differential Remarks")
                .txtDifferential.Tag = GridView2.GetFocusedRowCellValue("Differential Remarks")
                .cbxDifferential_G.Tag = GridView2.GetFocusedRowCellValue("Differential")
                .cbxDifferential_F.Tag = GridView2.GetFocusedRowCellValue("Differential")
                .cbxDifferential_P.Tag = GridView2.GetFocusedRowCellValue("Differential")
                'Brakes
                If GridView2.GetFocusedRowCellValue("Brakes") = "G" Then
                    .cbxBrakes_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Brakes") = "F" Then
                    .cbxBrakes_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Brakes") = "P" Then
                    .cbxBrakes_P.Checked = True
                End If
                .txtBrakes.Text = GridView2.GetFocusedRowCellValue("Brakes Remarks")
                .txtBrakes.Tag = GridView2.GetFocusedRowCellValue("Brakes Remarks")
                .cbxBrakes_G.Tag = GridView2.GetFocusedRowCellValue("Brakes")
                .cbxBrakes_F.Tag = GridView2.GetFocusedRowCellValue("Brakes")
                .cbxBrakes_P.Tag = GridView2.GetFocusedRowCellValue("Brakes")
                'Wiper
                If GridView2.GetFocusedRowCellValue("Wiper") = "G" Then
                    .cbxWiper_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Wiper") = "F" Then
                    .cbxWiper_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Wiper") = "P" Then
                    .cbxWiper_P.Checked = True
                End If
                .txtWiper.Text = GridView2.GetFocusedRowCellValue("Wiper Remarks")
                .txtWiper.Tag = GridView2.GetFocusedRowCellValue("Wiper Remarks")
                .cbxWiper_G.Tag = GridView2.GetFocusedRowCellValue("Wiper")
                .cbxWiper_F.Tag = GridView2.GetFocusedRowCellValue("Wiper")
                .cbxWiper_P.Tag = GridView2.GetFocusedRowCellValue("Wiper")
                'Backup
                If GridView2.GetFocusedRowCellValue("Back Up") = "G" Then
                    .cbxBackUp_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Back Up") = "F" Then
                    .cbxBackUp_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Back Up") = "P" Then
                    .cbxBackUp_P.Checked = True
                End If
                .txtBackUp.Text = GridView2.GetFocusedRowCellValue("Back Up Remarks")
                .txtBackUp.Tag = GridView2.GetFocusedRowCellValue("Back Up Remarks")
                .cbxBackUp_G.Tag = GridView2.GetFocusedRowCellValue("Back Up")
                .cbxBackUp_F.Tag = GridView2.GetFocusedRowCellValue("Back Up")
                .cbxBackUp_P.Tag = GridView2.GetFocusedRowCellValue("Back Up")
                'SideMirror
                If GridView2.GetFocusedRowCellValue("Side Mirror") = "G" Then
                    .cbxSideMirror_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Side Mirror") = "F" Then
                    .cbxSideMirror_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Side Mirror") = "P" Then
                    .cbxSideMirror_P.Checked = True
                End If
                .txtSideMirror.Text = GridView2.GetFocusedRowCellValue("Side Mirror Remarks")
                .txtSideMirror.Tag = GridView2.GetFocusedRowCellValue("Side Mirror Remarks")
                .cbxSideMirror_G.Tag = GridView2.GetFocusedRowCellValue("Side Mirror")
                .cbxSideMirror_F.Tag = GridView2.GetFocusedRowCellValue("Side Mirror")
                .cbxSideMirror_P.Tag = GridView2.GetFocusedRowCellValue("Side Mirror")
                'Body Flooring
                If GridView2.GetFocusedRowCellValue("Body Flooring") = "G" Then
                    .cbxBodyFlooring_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Body Flooring") = "F" Then
                    .cbxBodyFlooring_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Body Flooring") = "P" Then
                    .cbxBodyFlooring_P.Checked = True
                End If
                .txtBodyFlooring.Text = GridView2.GetFocusedRowCellValue("Body Flooring Remarks")
                .txtBodyFlooring.Tag = GridView2.GetFocusedRowCellValue("Body Flooring Remarks")
                .cbxBodyFlooring_G.Tag = GridView2.GetFocusedRowCellValue("Body Flooring")
                .cbxBodyFlooring_F.Tag = GridView2.GetFocusedRowCellValue("Body Flooring")
                .cbxBodyFlooring_P.Tag = GridView2.GetFocusedRowCellValue("Body Flooring")
                'Rear Bumper
                If GridView2.GetFocusedRowCellValue("Rear Bumper") = "G" Then
                    .cbxRearBumper_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Rear Bumper") = "F" Then
                    .cbxRearBumper_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Rear Bumper") = "P" Then
                    .cbxRearBumper_P.Checked = True
                End If
                .txtRearBumper.Text = GridView2.GetFocusedRowCellValue("Rear Bumper Remarks")
                .txtRearBumper.Tag = GridView2.GetFocusedRowCellValue("Rear Bumper Remarks")
                .cbxRearBumper_G.Tag = GridView2.GetFocusedRowCellValue("Rear Bumper")
                .cbxRearBumper_F.Tag = GridView2.GetFocusedRowCellValue("Rear Bumper")
                .cbxRearBumper_P.Tag = GridView2.GetFocusedRowCellValue("Rear Bumper")
                'Oil Pressure
                If GridView2.GetFocusedRowCellValue("Oil Pressure") = "G" Then
                    .cbxOilPressure_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Oil Pressure") = "F" Then
                    .cbxOilPressure_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Oil Pressure") = "P" Then
                    .cbxOilPressure_P.Checked = True
                End If
                .txtOilPressure.Text = GridView2.GetFocusedRowCellValue("Oil Pressure Remarks")
                .txtOilPressure.Tag = GridView2.GetFocusedRowCellValue("Oil Pressure Remarks")
                .cbxOilPressure_G.Tag = GridView2.GetFocusedRowCellValue("Oil Pressure")
                .cbxOilPressure_F.Tag = GridView2.GetFocusedRowCellValue("Oil Pressure")
                .cbxOilPressure_P.Tag = GridView2.GetFocusedRowCellValue("Oil Pressure")
                'Speedometer
                If GridView2.GetFocusedRowCellValue("Speedometer") = "G" Then
                    .cbxSpeedometer_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Speedometer") = "F" Then
                    .cbxSpeedometer_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Speedometer") = "P" Then
                    .cbxSpeedometer_P.Checked = True
                End If
                .txtSpeedometer.Text = GridView2.GetFocusedRowCellValue("Speedometer Remarks")
                .txtSpeedometer.Tag = GridView2.GetFocusedRowCellValue("Speedometer Remarks")
                .cbxSpeedometer_G.Tag = GridView2.GetFocusedRowCellValue("Speedometer")
                .cbxSpeedometer_F.Tag = GridView2.GetFocusedRowCellValue("Speedometer")
                .cbxSpeedometer_P.Tag = GridView2.GetFocusedRowCellValue("Speedometer")
                'Body Paint
                If GridView2.GetFocusedRowCellValue("Body Paint") = "G" Then
                    .cbxBodyPaint_G.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Body Paint") = "F" Then
                    .cbxBodyPaint_F.Checked = True
                ElseIf GridView2.GetFocusedRowCellValue("Body Paint") = "P" Then
                    .cbxBodyPaint_P.Checked = True
                End If
                .cbxBodyPaint_G.Tag = GridView2.GetFocusedRowCellValue("Body Paint")
                .cbxBodyPaint_F.Tag = GridView2.GetFocusedRowCellValue("Body Paint")
                .cbxBodyPaint_P.Tag = GridView2.GetFocusedRowCellValue("Body Paint")
                .txtBodyPaint.Text = GridView2.GetFocusedRowCellValue("Body Paint Remarks")
                .txtBodyPaint.Tag = GridView2.GetFocusedRowCellValue("Body Paint Remarks")

                .rRemarks.Text = GridView2.GetFocusedRowCellValue("Appraiser Remarks")
                .rRemarks.Tag = GridView2.GetFocusedRowCellValue("Appraiser Remarks")
                .txtSource.Text = GridView2.GetFocusedRowCellValue("Source")
                .txtSource.Tag = GridView2.GetFocusedRowCellValue("Source")
                .txtTelephoneNum.Text = GridView2.GetFocusedRowCellValue("Telephone Num")
                .txtTelephoneNum.Tag = GridView2.GetFocusedRowCellValue("Telephone Num")
                .dSellingPrice.Value = CDbl(GridView2.GetFocusedRowCellValue("Selling Price"))
                .dSellingPrice.Tag = CDbl(GridView2.GetFocusedRowCellValue("Selling Price"))
                .dFairMarketValue.Value = CDbl(GridView2.GetFocusedRowCellValue("Market Value"))
                .dFairMarketValue.Tag = CDbl(GridView2.GetFocusedRowCellValue("Market Value"))
                .dAppraisedValue.Value = CDbl(GridView2.GetFocusedRowCellValue("Appraised Value"))
                .dAppraisedValue.Tag = CDbl(GridView2.GetFocusedRowCellValue("Appraised Value"))
                .dLoanableValue.Value = CDbl(GridView2.GetFocusedRowCellValue("Loanable Value"))
                .dLoanableValue.Tag = CDbl(GridView2.GetFocusedRowCellValue("Loanable Value"))
                .dLoanablePercent.Value = CDbl(GridView2.GetFocusedRowCellValue("Loanable Percent"))
                .dLoanablePercent.Tag = CDbl(GridView2.GetFocusedRowCellValue("Loanable Percent"))
                .cbxBaseMarket.Checked = GridView2.GetFocusedRowCellValue("BaseMarket")

                If GridView2.GetFocusedRowCellValue("Branch_ID") = Branch_ID Then
                    .btnAddImage.Enabled = True
                    .btnAttach.Enabled = True
                Else
                    .btnPrint.Enabled = False
                    .btnRequirements.Enabled = False
                End If
                .btnModify.Enabled = False
                .btnRefresh.Enabled = False
                .btnSave.Enabled = False
                .PanelEx2.Enabled = False
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End If
        End With
    End Sub

    Private Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
        Try
            If GridView5.GetFocusedRowCellValue("Asset Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmVehicleAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            Dim SQL As String = "SELECT"
            SQL &= "    Make,"
            SQL &= "    `Type`,"
            SQL &= "    `Used`,"
            SQL &= "    Model,"
            SQL &= "    Series,"
            SQL &= "    PlateNum AS 'Plate Number',"
            SQL &= "    Transmission,"
            SQL &= "    Fuel,"
            SQL &= "    BodyColor AS 'Body Color',"
            SQL &= "    TRIM(`Year`) AS 'Year',"
            SQL &= "    EngineNum AS 'Engine Number',"
            SQL &= "    ChassisNum AS 'Chassis Number',"
            SQL &= "    RegistryCert AS 'Registry Certificate',"
            SQL &= "    ORNum AS 'OR Number',"
            SQL &= "    GrossWeight AS 'Gross Weight',"
            SQL &= "    RimHoles AS 'Rim Holes',"
            SQL &= "    MileAge,"
            SQL &= "    MileAgeType,"
            SQL &= "    IF(DateRegistered = '','',DATE_FORMAT(DateRegistered,'%b %d, %Y')) AS 'Last Registered',"
            SQL &= "    LTO AS 'LTO Office',"
            SQL &= "    Remarks,"
            SQL &= "    `Condition`,"
            SQL &= "    `ConditionReason` AS 'Reason'"
            SQL &= String.Format(" FROM ropoa_vehicle WHERE AssetNumber = '{0}';", GridView5.GetFocusedRowCellValue("Asset Number"))

            Dim DT As DataTable  = DataSource(SQL)
            .From_Vehicle = True
            .AssetNumber = GridView5.GetFocusedRowCellValue("Asset Number")
            .cbxAppraiseFor.Text = "ROPOA"
            .vMake = DT(0)("Make")
            .vType = DT(0)("Type")
            .cbxUsed.Text = DT(0)("Used")
            .vModel = DT(0)("Model")
            .txtSeries.Text = DT(0)("Series")
            .txtPlateNum.Text = DT(0)("Plate Number")
            .cbxTransmission.Text = DT(0)("Transmission")
            .vFuel = DT(0)("Fuel")
            .cbxBodyColor.Text = DT(0)("Body Color")
            If DT(0)("Year") = "" Then
                .dtpYear.CustomFormat = ""
            Else
                .dtpYear.CustomFormat = "     yyyy"
                .dtpYear.Value = DT(0)("Year") & "-01-01"
            End If
            .cbxEngineNumber.Text = DT(0)("Engine Number")
            .txtChassisNum.Text = DT(0)("Chassis Number")
            .txtRegistryCert.Text = DT(0)("Registry Certificate")
            .txtORNum.Text = DT(0)("OR Number")
            .dGrossWeight.Value = DT(0)("Gross Weight")
            .iRim.Value = DT(0)("Rim Holes")
            .dMileAge.Value = DT(0)("MileAge")
            .vMileAge = DT(0)("MileAgeType")
            If DT(0)("Last Registered") = "" Then
                .cbxNA.Checked = True
                .dtpRegistered.CustomFormat = ""
                .dtpRegistered.Tag = ""
            Else
                .cbxNA.Checked = False
                .dtpRegistered.CustomFormat = "MMMM dd, yyyy"
                .dtpRegistered.Value = DT(0)("Last Registered")
            End If
            .txtLTO.Text = DT(0)("LTO Office")

            'Enabled False
            .PanelEx1.Enabled = False
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        Try
            If GridView3.GetFocusedRowCellValue("Appraise Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmRealEstateAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            .btnSave.Text = "Update"
            .dtpDate.Value = GridView3.GetFocusedRowCellValue("Date")
            .txtAppraiseNumber.Text = GridView3.GetFocusedRowCellValue("Appraise Number")
            .CreditNumber = GridView3.GetFocusedRowCellValue("Credit Number")
            .vAppraised = GridView3.GetFocusedRowCellValue("Appraised By")
            .cbxAppraiseFor.Text = "Credit Investigation"

            .txtLand.Text = GridView3.GetFocusedRowCellValue("Land")
            .txtLand.Tag = GridView3.GetFocusedRowCellValue("Land")

            .dLandArea.Value = GridView3.GetFocusedRowCellValue("Land Area")
            .dLandArea.Tag = GridView3.GetFocusedRowCellValue("Land Area")
            .dLandPrice_1.Value = GridView3.GetFocusedRowCellValue("Land Price")
            .dLandPrice_1.Tag = GridView3.GetFocusedRowCellValue("Land Price")
            .dLandTotal_1.Value = GridView3.GetFocusedRowCellValue("Land Total")
            .dLandTotal_1.Tag = GridView3.GetFocusedRowCellValue("Land Total")
            .txtLandRemarks_1.Text = GridView3.GetFocusedRowCellValue("Land Remarks")
            .txtLandRemarks_1.Tag = GridView3.GetFocusedRowCellValue("Land Remarks")

            If CDbl(GridView3.GetFocusedRowCellValue("Land Area 2")) > 0 Then
                .dLandArea_2.Visible = True
                .lblLandSQM_2.Visible = True
                .dLandPrice_2.Visible = True
                .lblLandCons_2.Visible = True
                .lblLandPhp_2.Visible = True
                .dLandTotal_2.Visible = True
                .txtLandRemarks_2.Visible = True
                .btnAddLand_2.Visible = True
                .btnRemoveLand_2.Visible = True
            End If
            .dLandArea_2.Value = GridView3.GetFocusedRowCellValue("Land Area 2")
            .dLandArea_2.Tag = GridView3.GetFocusedRowCellValue("Land Area 2")
            .dLandPrice_2.Value = GridView3.GetFocusedRowCellValue("Land Price 2")
            .dLandPrice_2.Tag = GridView3.GetFocusedRowCellValue("Land Price 2")
            .dLandTotal_2.Value = GridView3.GetFocusedRowCellValue("Land Total 2")
            .dLandTotal_2.Tag = GridView3.GetFocusedRowCellValue("Land Total 2")
            .txtLandRemarks_2.Text = GridView3.GetFocusedRowCellValue("Land Remarks 2")
            .txtLandRemarks_2.Tag = GridView3.GetFocusedRowCellValue("Land Remarks 2")

            If CDbl(GridView3.GetFocusedRowCellValue("Land Area 3")) > 0 Then
                .dLandArea_3.Visible = True
                .lblLandSQM_3.Visible = True
                .dLandPrice_3.Visible = True
                .lblLandCons_3.Visible = True
                .lblLandPhp_3.Visible = True
                .dLandTotal_3.Visible = True
                .txtLandRemarks_3.Visible = True
                .btnAddLand_3.Visible = True
                .btnRemoveLand_3.Visible = True
            End If
            .dLandArea_3.Value = GridView3.GetFocusedRowCellValue("Land Area 3")
            .dLandArea_3.Tag = GridView3.GetFocusedRowCellValue("Land Area 3")
            .dLandPrice_3.Value = GridView3.GetFocusedRowCellValue("Land Price 3")
            .dLandPrice_3.Tag = GridView3.GetFocusedRowCellValue("Land Price 3")
            .dLandTotal_3.Value = GridView3.GetFocusedRowCellValue("Land Total 3")
            .dLandTotal_3.Tag = GridView3.GetFocusedRowCellValue("Land Total 3")
            .txtLandRemarks_3.Text = GridView3.GetFocusedRowCellValue("Land Remarks 3")
            .txtLandRemarks_3.Tag = GridView3.GetFocusedRowCellValue("Land Remarks 3")

            If CDbl(GridView3.GetFocusedRowCellValue("Land Area 4")) > 0 Then
                .dLandArea_4.Visible = True
                .lblLandSQM_4.Visible = True
                .dLandPrice_4.Visible = True
                .lblLandCons_4.Visible = True
                .lblLandPhp_4.Visible = True
                .dLandTotal_4.Visible = True
                .txtLandRemarks_4.Visible = True
                .btnAddLand_4.Visible = True
                .btnRemoveLand_4.Visible = True
            End If
            .dLandArea_4.Value = GridView3.GetFocusedRowCellValue("Land Area 4")
            .dLandArea_4.Tag = GridView3.GetFocusedRowCellValue("Land Area 4")
            .dLandPrice_4.Value = GridView3.GetFocusedRowCellValue("Land Price 4")
            .dLandPrice_4.Tag = GridView3.GetFocusedRowCellValue("Land Price 4")
            .dLandTotal_4.Value = GridView3.GetFocusedRowCellValue("Land Total 4")
            .dLandTotal_4.Tag = GridView3.GetFocusedRowCellValue("Land Total 4")
            .txtLandRemarks_4.Text = GridView3.GetFocusedRowCellValue("Land Remarks 4")
            .txtLandRemarks_4.Tag = GridView3.GetFocusedRowCellValue("Land Remarks 4")

            If CDbl(GridView3.GetFocusedRowCellValue("Land Area 5")) > 0 Then
                .dLandArea_5.Visible = True
                .lblLandSQM_5.Visible = True
                .dLandPrice_5.Visible = True
                .lblLandCons_5.Visible = True
                .lblLandPhp_5.Visible = True
                .dLandTotal_5.Visible = True
                .txtLandRemarks_5.Visible = True
                .btnRemoveLand_5.Visible = True
            End If
            .dLandArea_5.Value = GridView3.GetFocusedRowCellValue("Land Area 5")
            .dLandArea_5.Tag = GridView3.GetFocusedRowCellValue("Land Area 5")
            .dLandPrice_5.Value = GridView3.GetFocusedRowCellValue("Land Price 5")
            .dLandPrice_5.Tag = GridView3.GetFocusedRowCellValue("Land Price 5")
            .dLandTotal_5.Value = GridView3.GetFocusedRowCellValue("Land Total 5")
            .dLandTotal_5.Tag = GridView3.GetFocusedRowCellValue("Land Total 5")
            .txtLandRemarks_5.Text = GridView3.GetFocusedRowCellValue("Land Remarks 5")
            .txtLandRemarks_5.Tag = GridView3.GetFocusedRowCellValue("Land Remarks 5")

            .txtMachine.Text = GridView3.GetFocusedRowCellValue("Machine")
            .txtMachine.Tag = GridView3.GetFocusedRowCellValue("Machine")

            .dMachineArea_1.Value = GridView3.GetFocusedRowCellValue("Machine Area")
            .dMachineArea_1.Tag = GridView3.GetFocusedRowCellValue("Machine Area")
            .dMachinePrice_1.Value = GridView3.GetFocusedRowCellValue("Machine Price")
            .dMachinePrice_1.Tag = GridView3.GetFocusedRowCellValue("Machine Price")
            .dMachineTotal_1.Value = GridView3.GetFocusedRowCellValue("Machine Total")
            .dMachineTotal_1.Tag = GridView3.GetFocusedRowCellValue("Machine Total")
            .txtMachineRemarks_1.Text = GridView3.GetFocusedRowCellValue("Machine Remarks")
            .txtMachineRemarks_1.Tag = GridView3.GetFocusedRowCellValue("Machine Remarks")

            If CDbl(GridView3.GetFocusedRowCellValue("Machine Area 2")) > 0 Then
                .dMachineArea_2.Visible = True
                .lblMachineSQM_2.Visible = True
                .dMachinePrice_2.Visible = True
                .lblMachineCons_2.Visible = True
                .lblMachinePhp_2.Visible = True
                .dMachineTotal_2.Visible = True
                .txtMachineRemarks_2.Visible = True
                .btnAddMachine_2.Visible = True
                .btnRemoveMachine_2.Visible = True
            End If
            .dMachineArea_2.Value = GridView3.GetFocusedRowCellValue("Machine Area 2")
            .dMachineArea_2.Tag = GridView3.GetFocusedRowCellValue("Machine Area 2")
            .dMachinePrice_2.Value = GridView3.GetFocusedRowCellValue("Machine Price 2")
            .dMachinePrice_2.Tag = GridView3.GetFocusedRowCellValue("Machine Price 2")
            .dMachineTotal_2.Value = GridView3.GetFocusedRowCellValue("Machine Total 2")
            .dMachineTotal_2.Tag = GridView3.GetFocusedRowCellValue("Machine Total 2")
            .txtMachineRemarks_2.Text = GridView3.GetFocusedRowCellValue("Machine Remarks 2")
            .txtMachineRemarks_2.Tag = GridView3.GetFocusedRowCellValue("Machine Remarks 2")

            If CDbl(GridView3.GetFocusedRowCellValue("Machine Area 3")) > 0 Then
                .dMachineArea_3.Visible = True
                .lblMachineSQM_3.Visible = True
                .dMachinePrice_3.Visible = True
                .lblMachineCons_3.Visible = True
                .lblMachinePhp_3.Visible = True
                .dMachineTotal_3.Visible = True
                .txtMachineRemarks_3.Visible = True
                .btnAddMachine_3.Visible = True
                .btnRemoveMachine_3.Visible = True
            End If
            .dMachineArea_3.Value = GridView3.GetFocusedRowCellValue("Machine Area 3")
            .dMachineArea_3.Tag = GridView3.GetFocusedRowCellValue("Machine Area 3")
            .dMachinePrice_3.Value = GridView3.GetFocusedRowCellValue("Machine Price 3")
            .dMachinePrice_3.Tag = GridView3.GetFocusedRowCellValue("Machine Price 3")
            .dMachineTotal_3.Value = GridView3.GetFocusedRowCellValue("Machine Total 3")
            .dMachineTotal_3.Tag = GridView3.GetFocusedRowCellValue("Machine Total 3")
            .txtMachineRemarks_3.Text = GridView3.GetFocusedRowCellValue("Machine Remarks 3")
            .txtMachineRemarks_3.Tag = GridView3.GetFocusedRowCellValue("Machine Remarks 3")

            If CDbl(GridView3.GetFocusedRowCellValue("Machine Area 4")) > 0 Then
                .dMachineArea_4.Visible = True
                .lblMachineSQM_4.Visible = True
                .dMachinePrice_4.Visible = True
                .lblMachineCons_4.Visible = True
                .lblMachinePhp_4.Visible = True
                .dMachineTotal_4.Visible = True
                .txtMachineRemarks_4.Visible = True
                .btnAddMachine_4.Visible = True
                .btnRemoveMachine_4.Visible = True
            End If
            .dMachineArea_4.Value = GridView3.GetFocusedRowCellValue("Machine Area 4")
            .dMachineArea_4.Tag = GridView3.GetFocusedRowCellValue("Machine Area 4")
            .dMachinePrice_4.Value = GridView3.GetFocusedRowCellValue("Machine Price 4")
            .dMachinePrice_4.Tag = GridView3.GetFocusedRowCellValue("Machine Price 4")
            .dMachineTotal_4.Value = GridView3.GetFocusedRowCellValue("Machine Total 4")
            .dMachineTotal_4.Tag = GridView3.GetFocusedRowCellValue("Machine Total 4")
            .txtMachineRemarks_4.Text = GridView3.GetFocusedRowCellValue("Machine Remarks 4")
            .txtMachineRemarks_4.Tag = GridView3.GetFocusedRowCellValue("Machine Remarks 4")

            If CDbl(GridView3.GetFocusedRowCellValue("Machine Area 5")) > 0 Then
                .dMachineArea_5.Visible = True
                .lblMachineSQM_5.Visible = True
                .dMachinePrice_5.Visible = True
                .lblMachineCons_5.Visible = True
                .lblMachinePhp_5.Visible = True
                .dMachineTotal_5.Visible = True
                .txtMachineRemarks_5.Visible = True
                .btnRemoveMachine_5.Visible = True
            End If
            .dMachineArea_5.Value = GridView3.GetFocusedRowCellValue("Machine Area 5")
            .dMachineArea_5.Tag = GridView3.GetFocusedRowCellValue("Machine Area 5")
            .dMachinePrice_5.Value = GridView3.GetFocusedRowCellValue("Machine Price 5")
            .dMachinePrice_5.Tag = GridView3.GetFocusedRowCellValue("Machine Price 5")
            .dMachineTotal_5.Value = GridView3.GetFocusedRowCellValue("Machine Total 5")
            .dMachineTotal_5.Tag = GridView3.GetFocusedRowCellValue("Machine Total 5")
            .txtMachineRemarks_5.Text = GridView3.GetFocusedRowCellValue("Machine Remarks 5")
            .txtMachineRemarks_5.Tag = GridView3.GetFocusedRowCellValue("Machine Remarks 5")

            .txtImprovements.Text = GridView3.GetFocusedRowCellValue("Improvement")
            .txtImprovements.Tag = GridView3.GetFocusedRowCellValue("Improvement")

            .dImprovementArea_1.Value = GridView3.GetFocusedRowCellValue("Improvement Area")
            .dImprovementArea_1.Tag = GridView3.GetFocusedRowCellValue("Improvement Area")
            .dImprovementPrice_1.Value = GridView3.GetFocusedRowCellValue("Improvement Price")
            .dImprovementPrice_1.Tag = GridView3.GetFocusedRowCellValue("Improvement Price")
            .dImprovementTotal_1.Value = GridView3.GetFocusedRowCellValue("Improvement Total")
            .dImprovementTotal_1.Tag = GridView3.GetFocusedRowCellValue("Improvement Total")
            .txtImprovementRemarks_1.Text = GridView3.GetFocusedRowCellValue("Improvement Remarks")
            .txtImprovementRemarks_1.Tag = GridView3.GetFocusedRowCellValue("Improvement Remarks")

            If CDbl(GridView3.GetFocusedRowCellValue("Improvement Area 2")) > 0 Then
                .dImprovementArea_2.Visible = True
                .lblImprovementSQM_2.Visible = True
                .dImprovementPrice_2.Visible = True
                .lblImprovementCons_2.Visible = True
                .lblImprovementPhp_2.Visible = True
                .dImprovementTotal_2.Visible = True
                .txtImprovementRemarks_2.Visible = True
                .btnAddImprovement_2.Visible = True
                .btnRemoveImprovement_2.Visible = True
            End If
            .dImprovementArea_2.Value = GridView3.GetFocusedRowCellValue("Improvement Area 2")
            .dImprovementArea_2.Tag = GridView3.GetFocusedRowCellValue("Improvement Area 2")
            .dImprovementPrice_2.Value = GridView3.GetFocusedRowCellValue("Improvement Price 2")
            .dImprovementPrice_2.Tag = GridView3.GetFocusedRowCellValue("Improvement Price 2")
            .dImprovementTotal_2.Value = GridView3.GetFocusedRowCellValue("Improvement Total 2")
            .dImprovementTotal_2.Tag = GridView3.GetFocusedRowCellValue("Improvement Total 2")
            .txtImprovementRemarks_2.Text = GridView3.GetFocusedRowCellValue("Improvement Remarks 2")
            .txtImprovementRemarks_2.Tag = GridView3.GetFocusedRowCellValue("Improvement Remarks 2")

            If CDbl(GridView3.GetFocusedRowCellValue("Improvement Area 3")) > 0 Then
                .dImprovementArea_3.Visible = True
                .lblImprovementSQM_3.Visible = True
                .dImprovementPrice_3.Visible = True
                .lblImprovementCons_3.Visible = True
                .lblImprovementPhp_3.Visible = True
                .dImprovementTotal_3.Visible = True
                .txtImprovementRemarks_3.Visible = True
                .btnAddImprovement_3.Visible = True
                .btnRemoveImprovement_3.Visible = True
            End If
            .dImprovementArea_3.Value = GridView3.GetFocusedRowCellValue("Improvement Area 3")
            .dImprovementArea_3.Tag = GridView3.GetFocusedRowCellValue("Improvement Area 3")
            .dImprovementPrice_3.Value = GridView3.GetFocusedRowCellValue("Improvement Price 3")
            .dImprovementPrice_3.Tag = GridView3.GetFocusedRowCellValue("Improvement Price 3")
            .dImprovementTotal_3.Value = GridView3.GetFocusedRowCellValue("Improvement Total 3")
            .dImprovementTotal_3.Tag = GridView3.GetFocusedRowCellValue("Improvement Total 3")
            .txtImprovementRemarks_3.Text = GridView3.GetFocusedRowCellValue("Improvement Remarks 3")
            .txtImprovementRemarks_3.Tag = GridView3.GetFocusedRowCellValue("Improvement Remarks 3")

            If CDbl(GridView3.GetFocusedRowCellValue("Improvement Area 4")) > 0 Then
                .dImprovementArea_4.Visible = True
                .lblImprovementSQM_4.Visible = True
                .dImprovementPrice_4.Visible = True
                .lblImprovementCons_4.Visible = True
                .lblImprovementPhp_4.Visible = True
                .dImprovementTotal_4.Visible = True
                .txtImprovementRemarks_4.Visible = True
                .btnAddImprovement_4.Visible = True
                .btnRemoveImprovement_4.Visible = True
            End If
            .dImprovementArea_4.Value = GridView3.GetFocusedRowCellValue("Improvement Area 4")
            .dImprovementArea_4.Tag = GridView3.GetFocusedRowCellValue("Improvement Area 4")
            .dImprovementPrice_4.Value = GridView3.GetFocusedRowCellValue("Improvement Price 4")
            .dImprovementPrice_4.Tag = GridView3.GetFocusedRowCellValue("Improvement Price 4")
            .dImprovementTotal_4.Value = GridView3.GetFocusedRowCellValue("Improvement Total 4")
            .dImprovementTotal_4.Tag = GridView3.GetFocusedRowCellValue("Improvement Total 4")
            .txtImprovementRemarks_4.Text = GridView3.GetFocusedRowCellValue("Improvement Remarks 4")
            .txtImprovementRemarks_4.Tag = GridView3.GetFocusedRowCellValue("Improvement Remarks 4")

            If CDbl(GridView3.GetFocusedRowCellValue("Improvement Area 5")) > 0 Then
                .dImprovementArea_5.Visible = True
                .lblImprovementSQM_5.Visible = True
                .dImprovementPrice_5.Visible = True
                .lblImprovementCons_5.Visible = True
                .lblImprovementPhp_5.Visible = True
                .dImprovementTotal_5.Visible = True
                .txtImprovementRemarks_5.Visible = True
                .btnRemoveImprovement_5.Visible = True
            End If
            .dImprovementArea_5.Value = GridView3.GetFocusedRowCellValue("Improvement Area 5")
            .dImprovementArea_5.Tag = GridView3.GetFocusedRowCellValue("Improvement Area 5")
            .dImprovementPrice_5.Value = GridView3.GetFocusedRowCellValue("Improvement Price 5")
            .dImprovementPrice_5.Tag = GridView3.GetFocusedRowCellValue("Improvement Price 5")
            .dImprovementTotal_5.Value = GridView3.GetFocusedRowCellValue("Improvement Total 5")
            .dImprovementTotal_5.Tag = GridView3.GetFocusedRowCellValue("Improvement Total 5")
            .txtImprovementRemarks_5.Text = GridView3.GetFocusedRowCellValue("Improvement Remarks 5")
            .txtImprovementRemarks_5.Tag = GridView3.GetFocusedRowCellValue("Improvement Remarks 5")

            .dTotalAmount.Value = GridView3.GetFocusedRowCellValue("Total")
            .dTotalAmount.Tag = GridView3.GetFocusedRowCellValue("Total")
            .dPrevailingSellingPrice.Value = GridView3.GetFocusedRowCellValue("Prevailing Selling Price")
            .dPrevailingSellingPrice.Tag = GridView3.GetFocusedRowCellValue("Prevailing Selling Price")
            .dZonalValuation.Value = GridView3.GetFocusedRowCellValue("Zonal Valuation")
            .dZonalValuation.Tag = GridView3.GetFocusedRowCellValue("Zonal Valuation")
            .txtTCT.Text = GridView3.GetFocusedRowCellValue("TCT No.")
            .txtTCT.Tag = GridView3.GetFocusedRowCellValue("TCT No.")
            .txtLot.Text = GridView3.GetFocusedRowCellValue("Lot / Block No.")
            .txtLot.Tag = GridView3.GetFocusedRowCellValue("Lot / Block No.")
            .dArea.Value = GridView3.GetFocusedRowCellValue("Area SQ.M.")
            .dArea.Tag = GridView3.GetFocusedRowCellValue("Area SQ.M.")
            .txtRegisteredOwner.Text = GridView3.GetFocusedRowCellValue("Registered Owner")
            .txtRegisteredOwner.Tag = GridView3.GetFocusedRowCellValue("Registered Owner")
            .txtRegistryOfDeeds.Text = GridView3.GetFocusedRowCellValue("Registry of Deeds")
            .txtRegistryOfDeeds.Tag = GridView3.GetFocusedRowCellValue("Registry of Deeds")
            .rLocation.Text = GridView3.GetFocusedRowCellValue("Location")
            .rLocation.Tag = GridView3.GetFocusedRowCellValue("Location")
            .txtCoordinates.Text = GridView3.GetFocusedRowCellValue("Coordinates")
            .txtCoordinates.Tag = GridView3.GetFocusedRowCellValue("Coordinates")
            .cbxVacant.Checked = If(GridView3.GetFocusedRowCellValue("Vacant Lot") = "YES", True, False)
            .cbxVacant.Tag = If(GridView3.GetFocusedRowCellValue("Vacant Lot") = "YES", True, False)
            If GridView3.GetFocusedRowCellValue("Classification") = "Residential" Then
                .cbxResidential.Checked = True
            ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Commercial" Then
                .cbxCommercial.Checked = True
            ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                .cbxAgricultural.Checked = True
            ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Tourism" Then
                .cbxTourism.Checked = True
            ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Industrial" Then
                .cbxIndustrial.Checked = True
            ElseIf GridView3.GetFocusedRowCellValue("Classification") = "Condominium" Then
                .cbxCondominium.Checked = True
            Else
                .cbxOthers.Checked = True
                .txtOthers.Text = GridView3.GetFocusedRowCellValue("Classification")
            End If
            .cbxResidential.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxCommercial.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxAgricultural.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxTourism.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxIndustrial.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxCondominium.Tag = GridView3.GetFocusedRowCellValue("Classification")
            .cbxOthers.Tag = GridView3.GetFocusedRowCellValue("Classification")

            .txtStorey.Text = GridView3.GetFocusedRowCellValue("Storey")
            .txtStorey.Tag = GridView3.GetFocusedRowCellValue("Storey")
            .txtRoofings.Text = GridView3.GetFocusedRowCellValue("Roofing")
            .txtRoofings.Tag = GridView3.GetFocusedRowCellValue("Roofing")
            .txtFlooring.Text = GridView3.GetFocusedRowCellValue("Flooring")
            .txtFlooring.Tag = GridView3.GetFocusedRowCellValue("Flooring")
            .txtTandB.Text = GridView3.GetFocusedRowCellValue("T and B")
            .txtTandB.Tag = GridView3.GetFocusedRowCellValue("T and B")
            .txtFrame.Text = GridView3.GetFocusedRowCellValue("Frame")
            .txtFrame.Tag = GridView3.GetFocusedRowCellValue("Frame")
            .txtBeams.Text = GridView3.GetFocusedRowCellValue("Beams")
            .txtBeams.Tag = GridView3.GetFocusedRowCellValue("Beams")
            .txtDoors.Text = GridView3.GetFocusedRowCellValue("Door")
            .txtDoors.Tag = GridView3.GetFocusedRowCellValue("Door")
            .txtYearConstructed.Text = GridView3.GetFocusedRowCellValue("Year Constructed")
            .txtYearConstructed.Tag = GridView3.GetFocusedRowCellValue("Year Constructed")
            .txtWalling.Text = GridView3.GetFocusedRowCellValue("Walling")
            .txtWalling.Tag = GridView3.GetFocusedRowCellValue("Walling")
            .txtCeilings.Text = GridView3.GetFocusedRowCellValue("Ceiling")
            .txtCeilings.Tag = GridView3.GetFocusedRowCellValue("Ceiling")
            .txtWindows.Text = GridView3.GetFocusedRowCellValue("Windows")
            .txtWindows.Tag = GridView3.GetFocusedRowCellValue("Windows")
            .txtFloorArea.Text = GridView3.GetFocusedRowCellValue("Floor Area")
            .txtFloorArea.Tag = GridView3.GetFocusedRowCellValue("Floor Area")
            .txtPartitions.Text = GridView3.GetFocusedRowCellValue("Partitions")
            .txtPartitions.Tag = GridView3.GetFocusedRowCellValue("Partitions")
            .rRemarks.Text = GridView3.GetFocusedRowCellValue("Remarks")
            .rRemarks.Tag = GridView3.GetFocusedRowCellValue("Remarks")
            .dFairMarketValue.Value = GridView3.GetFocusedRowCellValue("Market Value")
            .dFairMarketValue.Tag = GridView3.GetFocusedRowCellValue("Market Value")
            .dAppraisedValue.Value = GridView3.GetFocusedRowCellValue("Appraised Value")
            .dAppraisedValue.Tag = GridView3.GetFocusedRowCellValue("Appraised Value")
            If GridView3.GetFocusedRowCellValue("As of") = "" Then
                .dtpAsOf.CustomFormat = ""
            Else
                .dtpAsOf.CustomFormat = "MMMM dd, yyyy"
                .dtpAsOf.Value = CDate(GridView3.GetFocusedRowCellValue("As of"))
            End If
            .dtpAsOf.Tag = GridView3.GetFocusedRowCellValue("As of")
            .dRecommendedAmount.Value = GridView3.GetFocusedRowCellValue("Loanable Value")
            .dRecommendedAmount.Tag = GridView3.GetFocusedRowCellValue("Loanable Value")
            .dRecommendedPercent.Value = GridView3.GetFocusedRowCellValue("Loanable Percent")
            .dRecommendedPercent.Tag = GridView3.GetFocusedRowCellValue("Loanable Percent")
            .TotalImage = GridView3.GetFocusedRowCellValue("Attach")

            If GridView3.GetFocusedRowCellValue("Branch_ID") = Branch_ID Then
                .btnAddImage.Enabled = True
            Else
                .btnPrint.Enabled = False
            End If
            .btnModify.Enabled = False
            .btnRefresh.Enabled = False
            .btnSave.Enabled = False
            .PanelEx4.Enabled = False
            .PanelEx1.Enabled = False
            .PanelEx2.Enabled = False
            .btnMap.Location = .btnRequirements.Location
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView4_DoubleClick(sender As Object, e As EventArgs) Handles GridView4.DoubleClick
        Try
            If GridView4.GetFocusedRowCellValue("Appraise Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmRealEstateAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            .btnSave.Text = "Update"
            .dtpDate.Value = GridView4.GetFocusedRowCellValue("Date")
            .txtAppraiseNumber.Text = GridView4.GetFocusedRowCellValue("Appraise Number")
            .AssetNumber = GridView4.GetFocusedRowCellValue("Asset Number")
            .vAppraised = GridView4.GetFocusedRowCellValue("Appraised By")
            .cbxAppraiseFor.Text = "ROPOA"

            .txtLand.Text = GridView4.GetFocusedRowCellValue("Land")
            .txtLand.Tag = GridView4.GetFocusedRowCellValue("Land")

            .dLandArea.Value = GridView4.GetFocusedRowCellValue("Land Area")
            .dLandArea.Tag = GridView4.GetFocusedRowCellValue("Land Area")
            .dLandPrice_1.Value = GridView4.GetFocusedRowCellValue("Land Price")
            .dLandPrice_1.Tag = GridView4.GetFocusedRowCellValue("Land Price")
            .dLandTotal_1.Value = GridView4.GetFocusedRowCellValue("Land Total")
            .dLandTotal_1.Tag = GridView4.GetFocusedRowCellValue("Land Total")
            .txtLandRemarks_1.Text = GridView4.GetFocusedRowCellValue("Land Remarks")
            .txtLandRemarks_1.Tag = GridView4.GetFocusedRowCellValue("Land Remarks")

            If CDbl(GridView4.GetFocusedRowCellValue("Land Area 2")) > 0 Then
                .dLandArea_2.Visible = True
                .lblLandSQM_2.Visible = True
                .dLandPrice_2.Visible = True
                .lblLandCons_2.Visible = True
                .lblLandPhp_2.Visible = True
                .dLandTotal_2.Visible = True
                .txtLandRemarks_2.Visible = True
                .btnAddLand_2.Visible = True
                .btnRemoveLand_2.Visible = True
            End If
            .dLandArea_2.Value = GridView4.GetFocusedRowCellValue("Land Area 2")
            .dLandArea_2.Tag = GridView4.GetFocusedRowCellValue("Land Area 2")
            .dLandPrice_2.Value = GridView4.GetFocusedRowCellValue("Land Price 2")
            .dLandPrice_2.Tag = GridView4.GetFocusedRowCellValue("Land Price 2")
            .dLandTotal_2.Value = GridView4.GetFocusedRowCellValue("Land Total 2")
            .dLandTotal_2.Tag = GridView4.GetFocusedRowCellValue("Land Total 2")
            .txtLandRemarks_2.Text = GridView4.GetFocusedRowCellValue("Land Remarks 2")
            .txtLandRemarks_2.Tag = GridView4.GetFocusedRowCellValue("Land Remarks 2")

            If CDbl(GridView4.GetFocusedRowCellValue("Land Area 3")) > 0 Then
                .dLandArea_3.Visible = True
                .lblLandSQM_3.Visible = True
                .dLandPrice_3.Visible = True
                .lblLandCons_3.Visible = True
                .lblLandPhp_3.Visible = True
                .dLandTotal_3.Visible = True
                .txtLandRemarks_3.Visible = True
                .btnAddLand_3.Visible = True
                .btnRemoveLand_3.Visible = True
            End If
            .dLandArea_3.Value = GridView4.GetFocusedRowCellValue("Land Area 3")
            .dLandArea_3.Tag = GridView4.GetFocusedRowCellValue("Land Area 3")
            .dLandPrice_3.Value = GridView4.GetFocusedRowCellValue("Land Price 3")
            .dLandPrice_3.Tag = GridView4.GetFocusedRowCellValue("Land Price 3")
            .dLandTotal_3.Value = GridView4.GetFocusedRowCellValue("Land Total 3")
            .dLandTotal_3.Tag = GridView4.GetFocusedRowCellValue("Land Total 3")
            .txtLandRemarks_3.Text = GridView4.GetFocusedRowCellValue("Land Remarks 3")
            .txtLandRemarks_3.Tag = GridView4.GetFocusedRowCellValue("Land Remarks 3")

            If CDbl(GridView4.GetFocusedRowCellValue("Land Area 4")) > 0 Then
                .dLandArea_4.Visible = True
                .lblLandSQM_4.Visible = True
                .dLandPrice_4.Visible = True
                .lblLandCons_4.Visible = True
                .lblLandPhp_4.Visible = True
                .dLandTotal_4.Visible = True
                .txtLandRemarks_4.Visible = True
                .btnAddLand_4.Visible = True
                .btnRemoveLand_4.Visible = True
            End If
            .dLandArea_4.Value = GridView4.GetFocusedRowCellValue("Land Area 4")
            .dLandArea_4.Tag = GridView4.GetFocusedRowCellValue("Land Area 4")
            .dLandPrice_4.Value = GridView4.GetFocusedRowCellValue("Land Price 4")
            .dLandPrice_4.Tag = GridView4.GetFocusedRowCellValue("Land Price 4")
            .dLandTotal_4.Value = GridView4.GetFocusedRowCellValue("Land Total 4")
            .dLandTotal_4.Tag = GridView4.GetFocusedRowCellValue("Land Total 4")
            .txtLandRemarks_4.Text = GridView4.GetFocusedRowCellValue("Land Remarks 4")
            .txtLandRemarks_4.Tag = GridView4.GetFocusedRowCellValue("Land Remarks 4")

            If CDbl(GridView4.GetFocusedRowCellValue("Land Area 5")) > 0 Then
                .dLandArea_5.Visible = True
                .lblLandSQM_5.Visible = True
                .dLandPrice_5.Visible = True
                .lblLandCons_5.Visible = True
                .lblLandPhp_5.Visible = True
                .dLandTotal_5.Visible = True
                .txtLandRemarks_5.Visible = True
                .btnRemoveLand_5.Visible = True
            End If
            .dLandArea_5.Value = GridView4.GetFocusedRowCellValue("Land Area 5")
            .dLandArea_5.Tag = GridView4.GetFocusedRowCellValue("Land Area 5")
            .dLandPrice_5.Value = GridView4.GetFocusedRowCellValue("Land Price 5")
            .dLandPrice_5.Tag = GridView4.GetFocusedRowCellValue("Land Price 5")
            .dLandTotal_5.Value = GridView4.GetFocusedRowCellValue("Land Total 5")
            .dLandTotal_5.Tag = GridView4.GetFocusedRowCellValue("Land Total 5")
            .txtLandRemarks_5.Text = GridView4.GetFocusedRowCellValue("Land Remarks 5")
            .txtLandRemarks_5.Tag = GridView4.GetFocusedRowCellValue("Land Remarks 5")

            .txtMachine.Text = GridView4.GetFocusedRowCellValue("Machine")
            .txtMachine.Tag = GridView4.GetFocusedRowCellValue("Machine")

            .dMachineArea_1.Value = GridView4.GetFocusedRowCellValue("Machine Area")
            .dMachineArea_1.Tag = GridView4.GetFocusedRowCellValue("Machine Area")
            .dMachinePrice_1.Value = GridView4.GetFocusedRowCellValue("Machine Price")
            .dMachinePrice_1.Tag = GridView4.GetFocusedRowCellValue("Machine Price")
            .dMachineTotal_1.Value = GridView4.GetFocusedRowCellValue("Machine Total")
            .dMachineTotal_1.Tag = GridView4.GetFocusedRowCellValue("Machine Total")
            .txtMachineRemarks_1.Text = GridView4.GetFocusedRowCellValue("Machine Remarks")
            .txtMachineRemarks_1.Tag = GridView4.GetFocusedRowCellValue("Machine Remarks")

            If CDbl(GridView4.GetFocusedRowCellValue("Machine Area 2")) > 0 Then
                .dMachineArea_2.Visible = True
                .lblMachineSQM_2.Visible = True
                .dMachinePrice_2.Visible = True
                .lblMachineCons_2.Visible = True
                .lblMachinePhp_2.Visible = True
                .dMachineTotal_2.Visible = True
                .txtMachineRemarks_2.Visible = True
                .btnAddMachine_2.Visible = True
                .btnRemoveMachine_2.Visible = True
            End If
            .dMachineArea_2.Value = GridView4.GetFocusedRowCellValue("Machine Area 2")
            .dMachineArea_2.Tag = GridView4.GetFocusedRowCellValue("Machine Area 2")
            .dMachinePrice_2.Value = GridView4.GetFocusedRowCellValue("Machine Price 2")
            .dMachinePrice_2.Tag = GridView4.GetFocusedRowCellValue("Machine Price 2")
            .dMachineTotal_2.Value = GridView4.GetFocusedRowCellValue("Machine Total 2")
            .dMachineTotal_2.Tag = GridView4.GetFocusedRowCellValue("Machine Total 2")
            .txtMachineRemarks_2.Text = GridView4.GetFocusedRowCellValue("Machine Remarks 2")
            .txtMachineRemarks_2.Tag = GridView4.GetFocusedRowCellValue("Machine Remarks 2")

            If CDbl(GridView4.GetFocusedRowCellValue("Machine Area 3")) > 0 Then
                .dMachineArea_3.Visible = True
                .lblMachineSQM_3.Visible = True
                .dMachinePrice_3.Visible = True
                .lblMachineCons_3.Visible = True
                .lblMachinePhp_3.Visible = True
                .dMachineTotal_3.Visible = True
                .txtMachineRemarks_3.Visible = True
                .btnAddMachine_3.Visible = True
                .btnRemoveMachine_3.Visible = True
            End If
            .dMachineArea_3.Value = GridView4.GetFocusedRowCellValue("Machine Area 3")
            .dMachineArea_3.Tag = GridView4.GetFocusedRowCellValue("Machine Area 3")
            .dMachinePrice_3.Value = GridView4.GetFocusedRowCellValue("Machine Price 3")
            .dMachinePrice_3.Tag = GridView4.GetFocusedRowCellValue("Machine Price 3")
            .dMachineTotal_3.Value = GridView4.GetFocusedRowCellValue("Machine Total 3")
            .dMachineTotal_3.Tag = GridView4.GetFocusedRowCellValue("Machine Total 3")
            .txtMachineRemarks_3.Text = GridView4.GetFocusedRowCellValue("Machine Remarks 3")
            .txtMachineRemarks_3.Tag = GridView4.GetFocusedRowCellValue("Machine Remarks 3")

            If CDbl(GridView4.GetFocusedRowCellValue("Machine Area 4")) > 0 Then
                .dMachineArea_4.Visible = True
                .lblMachineSQM_4.Visible = True
                .dMachinePrice_4.Visible = True
                .lblMachineCons_4.Visible = True
                .lblMachinePhp_4.Visible = True
                .dMachineTotal_4.Visible = True
                .txtMachineRemarks_4.Visible = True
                .btnAddMachine_4.Visible = True
                .btnRemoveMachine_4.Visible = True
            End If
            .dMachineArea_4.Value = GridView4.GetFocusedRowCellValue("Machine Area 4")
            .dMachineArea_4.Tag = GridView4.GetFocusedRowCellValue("Machine Area 4")
            .dMachinePrice_4.Value = GridView4.GetFocusedRowCellValue("Machine Price 4")
            .dMachinePrice_4.Tag = GridView4.GetFocusedRowCellValue("Machine Price 4")
            .dMachineTotal_4.Value = GridView4.GetFocusedRowCellValue("Machine Total 4")
            .dMachineTotal_4.Tag = GridView4.GetFocusedRowCellValue("Machine Total 4")
            .txtMachineRemarks_4.Text = GridView4.GetFocusedRowCellValue("Machine Remarks 4")
            .txtMachineRemarks_4.Tag = GridView4.GetFocusedRowCellValue("Machine Remarks 4")

            If CDbl(GridView4.GetFocusedRowCellValue("Machine Area 5")) > 0 Then
                .dMachineArea_5.Visible = True
                .lblMachineSQM_5.Visible = True
                .dMachinePrice_5.Visible = True
                .lblMachineCons_5.Visible = True
                .lblMachinePhp_5.Visible = True
                .dMachineTotal_5.Visible = True
                .txtMachineRemarks_5.Visible = True
                .btnRemoveMachine_5.Visible = True
            End If
            .dMachineArea_5.Value = GridView4.GetFocusedRowCellValue("Machine Area 5")
            .dMachineArea_5.Tag = GridView4.GetFocusedRowCellValue("Machine Area 5")
            .dMachinePrice_5.Value = GridView4.GetFocusedRowCellValue("Machine Price 5")
            .dMachinePrice_5.Tag = GridView4.GetFocusedRowCellValue("Machine Price 5")
            .dMachineTotal_5.Value = GridView4.GetFocusedRowCellValue("Machine Total 5")
            .dMachineTotal_5.Tag = GridView4.GetFocusedRowCellValue("Machine Total 5")
            .txtMachineRemarks_5.Text = GridView4.GetFocusedRowCellValue("Machine Remarks 5")
            .txtMachineRemarks_5.Tag = GridView4.GetFocusedRowCellValue("Machine Remarks 5")

            .txtImprovements.Text = GridView4.GetFocusedRowCellValue("Improvement")
            .txtImprovements.Tag = GridView4.GetFocusedRowCellValue("Improvement")

            .dImprovementArea_1.Value = GridView4.GetFocusedRowCellValue("Improvement Area")
            .dImprovementArea_1.Tag = GridView4.GetFocusedRowCellValue("Improvement Area")
            .dImprovementPrice_1.Value = GridView4.GetFocusedRowCellValue("Improvement Price")
            .dImprovementPrice_1.Tag = GridView4.GetFocusedRowCellValue("Improvement Price")
            .dImprovementTotal_1.Value = GridView4.GetFocusedRowCellValue("Improvement Total")
            .dImprovementTotal_1.Tag = GridView4.GetFocusedRowCellValue("Improvement Total")
            .txtImprovementRemarks_1.Text = GridView4.GetFocusedRowCellValue("Improvement Remarks")
            .txtImprovementRemarks_1.Tag = GridView4.GetFocusedRowCellValue("Improvement Remarks")

            If CDbl(GridView4.GetFocusedRowCellValue("Improvement Area 2")) > 0 Then
                .dImprovementArea_2.Visible = True
                .lblImprovementSQM_2.Visible = True
                .dImprovementPrice_2.Visible = True
                .lblImprovementCons_2.Visible = True
                .lblImprovementPhp_2.Visible = True
                .dImprovementTotal_2.Visible = True
                .txtImprovementRemarks_2.Visible = True
                .btnAddImprovement_2.Visible = True
                .btnRemoveImprovement_2.Visible = True
            End If
            .dImprovementArea_2.Value = GridView4.GetFocusedRowCellValue("Improvement Area 2")
            .dImprovementArea_2.Tag = GridView4.GetFocusedRowCellValue("Improvement Area 2")
            .dImprovementPrice_2.Value = GridView4.GetFocusedRowCellValue("Improvement Price 2")
            .dImprovementPrice_2.Tag = GridView4.GetFocusedRowCellValue("Improvement Price 2")
            .dImprovementTotal_2.Value = GridView4.GetFocusedRowCellValue("Improvement Total 2")
            .dImprovementTotal_2.Tag = GridView4.GetFocusedRowCellValue("Improvement Total 2")
            .txtImprovementRemarks_2.Text = GridView4.GetFocusedRowCellValue("Improvement Remarks 2")
            .txtImprovementRemarks_2.Tag = GridView4.GetFocusedRowCellValue("Improvement Remarks 2")

            If CDbl(GridView4.GetFocusedRowCellValue("Improvement Area 3")) > 0 Then
                .dImprovementArea_3.Visible = True
                .lblImprovementSQM_3.Visible = True
                .dImprovementPrice_3.Visible = True
                .lblImprovementCons_3.Visible = True
                .lblImprovementPhp_3.Visible = True
                .dImprovementTotal_3.Visible = True
                .txtImprovementRemarks_3.Visible = True
                .btnAddImprovement_3.Visible = True
                .btnRemoveImprovement_3.Visible = True
            End If
            .dImprovementArea_3.Value = GridView4.GetFocusedRowCellValue("Improvement Area 3")
            .dImprovementArea_3.Tag = GridView4.GetFocusedRowCellValue("Improvement Area 3")
            .dImprovementPrice_3.Value = GridView4.GetFocusedRowCellValue("Improvement Price 3")
            .dImprovementPrice_3.Tag = GridView4.GetFocusedRowCellValue("Improvement Price 3")
            .dImprovementTotal_3.Value = GridView4.GetFocusedRowCellValue("Improvement Total 3")
            .dImprovementTotal_3.Tag = GridView4.GetFocusedRowCellValue("Improvement Total 3")
            .txtImprovementRemarks_3.Text = GridView4.GetFocusedRowCellValue("Improvement Remarks 3")
            .txtImprovementRemarks_3.Tag = GridView4.GetFocusedRowCellValue("Improvement Remarks 3")

            If CDbl(GridView4.GetFocusedRowCellValue("Improvement Area 4")) > 0 Then
                .dImprovementArea_4.Visible = True
                .lblImprovementSQM_4.Visible = True
                .dImprovementPrice_4.Visible = True
                .lblImprovementCons_4.Visible = True
                .lblImprovementPhp_4.Visible = True
                .dImprovementTotal_4.Visible = True
                .txtImprovementRemarks_4.Visible = True
                .btnAddImprovement_4.Visible = True
                .btnRemoveImprovement_4.Visible = True
            End If
            .dImprovementArea_4.Value = GridView4.GetFocusedRowCellValue("Improvement Area 4")
            .dImprovementArea_4.Tag = GridView4.GetFocusedRowCellValue("Improvement Area 4")
            .dImprovementPrice_4.Value = GridView4.GetFocusedRowCellValue("Improvement Price 4")
            .dImprovementPrice_4.Tag = GridView4.GetFocusedRowCellValue("Improvement Price 4")
            .dImprovementTotal_4.Value = GridView4.GetFocusedRowCellValue("Improvement Total 4")
            .dImprovementTotal_4.Tag = GridView4.GetFocusedRowCellValue("Improvement Total 4")
            .txtImprovementRemarks_4.Text = GridView4.GetFocusedRowCellValue("Improvement Remarks 4")
            .txtImprovementRemarks_4.Tag = GridView4.GetFocusedRowCellValue("Improvement Remarks 4")

            If CDbl(GridView4.GetFocusedRowCellValue("Improvement Area 5")) > 0 Then
                .dImprovementArea_5.Visible = True
                .lblImprovementSQM_5.Visible = True
                .dImprovementPrice_5.Visible = True
                .lblImprovementCons_5.Visible = True
                .lblImprovementPhp_5.Visible = True
                .dImprovementTotal_5.Visible = True
                .txtImprovementRemarks_5.Visible = True
                .btnRemoveImprovement_5.Visible = True
            End If
            .dImprovementArea_5.Value = GridView4.GetFocusedRowCellValue("Improvement Area 5")
            .dImprovementArea_5.Tag = GridView4.GetFocusedRowCellValue("Improvement Area 5")
            .dImprovementPrice_5.Value = GridView4.GetFocusedRowCellValue("Improvement Price 5")
            .dImprovementPrice_5.Tag = GridView4.GetFocusedRowCellValue("Improvement Price 5")
            .dImprovementTotal_5.Value = GridView4.GetFocusedRowCellValue("Improvement Total 5")
            .dImprovementTotal_5.Tag = GridView4.GetFocusedRowCellValue("Improvement Total 5")
            .txtImprovementRemarks_5.Text = GridView4.GetFocusedRowCellValue("Improvement Remarks 5")
            .txtImprovementRemarks_5.Tag = GridView4.GetFocusedRowCellValue("Improvement Remarks 5")
            .dTotalAmount.Value = GridView4.GetFocusedRowCellValue("Total")
            .dTotalAmount.Tag = GridView4.GetFocusedRowCellValue("Total")
            .dPrevailingSellingPrice.Value = GridView4.GetFocusedRowCellValue("Prevailing Selling Price")
            .dPrevailingSellingPrice.Tag = GridView4.GetFocusedRowCellValue("Prevailing Selling Price")
            .dZonalValuation.Value = GridView4.GetFocusedRowCellValue("Zonal Valuation")
            .dZonalValuation.Tag = GridView4.GetFocusedRowCellValue("Zonal Valuation")
            .txtTCT.Text = GridView4.GetFocusedRowCellValue("TCT No.")
            .txtTCT.Tag = GridView4.GetFocusedRowCellValue("TCT No.")
            .txtLot.Text = GridView4.GetFocusedRowCellValue("Lot / Block No.")
            .txtLot.Tag = GridView4.GetFocusedRowCellValue("Lot / Block No.")
            .dArea.Value = GridView4.GetFocusedRowCellValue("Area SQ.M.")
            .dArea.Tag = GridView4.GetFocusedRowCellValue("Area SQ.M.")
            .txtRegisteredOwner.Text = GridView4.GetFocusedRowCellValue("Registered Owner")
            .txtRegisteredOwner.Tag = GridView4.GetFocusedRowCellValue("Registered Owner")
            .txtRegistryOfDeeds.Text = GridView4.GetFocusedRowCellValue("Registry of Deeds")
            .txtRegistryOfDeeds.Tag = GridView4.GetFocusedRowCellValue("Registry of Deeds")
            .rLocation.Text = GridView4.GetFocusedRowCellValue("Location")
            .rLocation.Tag = GridView4.GetFocusedRowCellValue("Location")
            .txtCoordinates.Text = GridView4.GetFocusedRowCellValue("Coordinates")
            .txtCoordinates.Tag = GridView4.GetFocusedRowCellValue("Coordinates")
            .cbxVacant.Checked = If(GridView4.GetFocusedRowCellValue("Vacant Lot") = "YES", True, False)
            .cbxVacant.Tag = If(GridView4.GetFocusedRowCellValue("Vacant Lot") = "YES", True, False)
            If GridView4.GetFocusedRowCellValue("Classification") = "Residential" Then
                .cbxResidential.Checked = True
            ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Commercial" Then
                .cbxCommercial.Checked = True
            ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Agricultural" Then
                .cbxAgricultural.Checked = True
            ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Tourism" Then
                .cbxTourism.Checked = True
            ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Industrial" Then
                .cbxIndustrial.Checked = True
            ElseIf GridView4.GetFocusedRowCellValue("Classification") = "Condominium" Then
                .cbxCondominium.Checked = True
            Else
                .cbxOthers.Checked = True
                .txtOthers.Text = GridView4.GetFocusedRowCellValue("Classification")
            End If
            .cbxResidential.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxCommercial.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxAgricultural.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxTourism.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxIndustrial.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxCondominium.Tag = GridView4.GetFocusedRowCellValue("Classification")
            .cbxOthers.Tag = GridView4.GetFocusedRowCellValue("Classification")

            .txtStorey.Text = GridView4.GetFocusedRowCellValue("Storey")
            .txtStorey.Tag = GridView4.GetFocusedRowCellValue("Storey")
            .txtRoofings.Text = GridView4.GetFocusedRowCellValue("Roofing")
            .txtRoofings.Tag = GridView4.GetFocusedRowCellValue("Roofing")
            .txtFlooring.Text = GridView4.GetFocusedRowCellValue("Flooring")
            .txtFlooring.Tag = GridView4.GetFocusedRowCellValue("Flooring")
            .txtTandB.Text = GridView4.GetFocusedRowCellValue("T and B")
            .txtTandB.Tag = GridView4.GetFocusedRowCellValue("T and B")
            .txtFrame.Text = GridView4.GetFocusedRowCellValue("Frame")
            .txtFrame.Tag = GridView4.GetFocusedRowCellValue("Frame")
            .txtBeams.Text = GridView4.GetFocusedRowCellValue("Beams")
            .txtBeams.Tag = GridView4.GetFocusedRowCellValue("Beams")
            .txtDoors.Text = GridView4.GetFocusedRowCellValue("Door")
            .txtDoors.Tag = GridView4.GetFocusedRowCellValue("Door")
            .txtYearConstructed.Text = GridView4.GetFocusedRowCellValue("Year Constructed")
            .txtYearConstructed.Tag = GridView4.GetFocusedRowCellValue("Year Constructed")
            .txtWalling.Text = GridView4.GetFocusedRowCellValue("Walling")
            .txtWalling.Tag = GridView4.GetFocusedRowCellValue("Walling")
            .txtCeilings.Text = GridView4.GetFocusedRowCellValue("Ceiling")
            .txtCeilings.Tag = GridView4.GetFocusedRowCellValue("Ceiling")
            .txtWindows.Text = GridView4.GetFocusedRowCellValue("Windows")
            .txtWindows.Tag = GridView4.GetFocusedRowCellValue("Windows")
            .txtFloorArea.Text = GridView4.GetFocusedRowCellValue("Floor Area")
            .txtFloorArea.Tag = GridView4.GetFocusedRowCellValue("Floor Area")
            .txtPartitions.Text = GridView4.GetFocusedRowCellValue("Partitions")
            .txtPartitions.Tag = GridView4.GetFocusedRowCellValue("Partitions")
            .rRemarks.Text = GridView4.GetFocusedRowCellValue("Remarks")
            .rRemarks.Tag = GridView4.GetFocusedRowCellValue("Remarks")
            .dFairMarketValue.Value = GridView4.GetFocusedRowCellValue("Market Value")
            .dFairMarketValue.Tag = GridView4.GetFocusedRowCellValue("Market Value")
            .dAppraisedValue.Value = GridView4.GetFocusedRowCellValue("Appraised Value")
            .dAppraisedValue.Tag = GridView4.GetFocusedRowCellValue("Appraised Value")
            If GridView4.GetFocusedRowCellValue("As of") = "" Then
                .dtpAsOf.CustomFormat = ""
            Else
                .dtpAsOf.CustomFormat = "MMMM dd, yyyy"
                .dtpAsOf.Value = CDate(GridView4.GetFocusedRowCellValue("As of"))
            End If
            .dtpAsOf.Tag = GridView4.GetFocusedRowCellValue("As of")
            .dRecommendedAmount.Value = GridView4.GetFocusedRowCellValue("Loanable Value")
            .dRecommendedAmount.Tag = GridView4.GetFocusedRowCellValue("Loanable Value")
            .dRecommendedPercent.Value = GridView4.GetFocusedRowCellValue("Loanable Percent")
            .dRecommendedPercent.Tag = GridView4.GetFocusedRowCellValue("Loanable Percent")
            .TotalImage = GridView4.GetFocusedRowCellValue("Attach")

            If GridView4.GetFocusedRowCellValue("Branch_ID") = Branch_ID Then
                .btnModify.Enabled = True
                .btnAddImage.Enabled = True
            Else
                .btnPrint.Enabled = False
            End If
            .btnRefresh.Enabled = False
            .btnSave.Enabled = False
            .PanelEx4.Enabled = False
            .PanelEx1.Enabled = False
            .PanelEx2.Enabled = False
            .btnMap.Location = .btnRequirements.Location
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView6_DoubleClick(sender As Object, e As EventArgs) Handles GridView6.DoubleClick
        Try
            If GridView6.GetFocusedRowCellValue("Asset Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Appraise As New FrmRealEstateAppraisal
        With Appraise
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            'Pass Value
            .From_RealEstate = True
            Dim SQL As String = "SELECT "
            SQL &= "    TCT AS 'TCT Number',"
            SQL &= "    Location,"
            SQL &= "    `Area` AS 'Area',"
            SQL &= "    Classification,"
            SQL &= "    VacantLot AS 'Vacant Lot',"
            SQL &= "    Storey AS 'Storeys',"
            SQL &= "    Roofings,"
            SQL &= "    Flooring AS 'Floorings',"
            SQL &= "    TandB AS 'T and B',"
            SQL &= "    Frame,"
            SQL &= "    Beams,"
            SQL &= "    Doors,"
            SQL &= "    YearConstructed AS 'Yr Constructed',"
            SQL &= "    Walling AS 'Wallings',"
            SQL &= "    `Ceiling` AS 'Ceilings',"
            SQL &= "    Windows,"
            SQL &= "    FloorArea AS 'Floor Area',"
            SQL &= "    `Partitions`,"
            SQL &= "    Remarks, Coordinates"
            SQL &= String.Format(" FROM ropoa_realestate WHERE AssetNumber = '{0}';", GridView6.GetFocusedRowCellValue("Asset Number"))
            Dim DT As DataTable = DataSource(SQL)
            .AssetNumber = GridView6.GetFocusedRowCellValue("Asset Number")
            .cbxAppraiseFor.Text = "ROPOA"

            .txtTCT.Text = DT(0)("TCT Number")
            .txtTCT.Enabled = False
            .dArea.Text = DT(0)("Area")
            .dArea.Enabled = False
            .rLocation.Text = DT(0)("Location")
            .txtCoordinates.Text = DT(0)("Coordinates")
            .cbxVacant.Checked = If(DT(0)("Vacant Lot") = "Yes", True, False)
            If DT(0)("Classification") = "Residential" Then
                .cbxResidential.Checked = True
            ElseIf DT(0)("Classification") = "Commercial" Then
                .cbxCommercial.Checked = True
            ElseIf DT(0)("Classification") = "Agricultural" Then
                .cbxAgricultural.Checked = True
            ElseIf DT(0)("Classification") = "Tourism" Then
                .cbxTourism.Checked = True
            ElseIf DT(0)("Classification") = "Industrial" Then
                .cbxIndustrial.Checked = True
            ElseIf DT(0)("Classification") = "Condominium" Then
                .cbxCondominium.Checked = True
            Else
                .cbxOthers.Checked = True
                .txtOthers.Text = DT(0)("Classification")
            End If
            .txtStorey.Text = DT(0)("Storeys")
            .txtRoofings.Text = DT(0)("Roofings")
            .txtFlooring.Text = DT(0)("Floorings")
            .txtTandB.Text = DT(0)("T and B")
            .txtFrame.Text = DT(0)("Frame")
            .txtBeams.Text = DT(0)("Beams")
            .txtDoors.Text = DT(0)("Doors")
            .txtYearConstructed.Text = DT(0)("Yr Constructed")
            .txtWalling.Text = DT(0)("Wallings")
            .txtCeilings.Text = DT(0)("Ceilings")
            .txtWindows.Text = DT(0)("Windows")
            .txtFloorArea.Text = DT(0)("Floor Area")
            .txtPartitions.Text = DT(0)("Partitions")
            .rRemarks.Text = DT(0)("Remarks")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Or SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Then
            btnHide.Visible = True
            btnShow.Visible = True
        Else
            btnHide.Visible = False
            btnShow.Visible = False
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView2_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView2_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView3_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView3.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView3_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView4_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView4.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView4_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView5_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView5.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView5_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView6_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView6.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView6_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub CbxAdvanced_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdvanced.CheckedChanged
        btnSearch.PerformClick()
    End Sub
End Class