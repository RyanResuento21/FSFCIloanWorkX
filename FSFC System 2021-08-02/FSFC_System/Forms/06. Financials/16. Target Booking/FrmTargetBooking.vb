Imports DevExpress.XtraReports.UI
Public Class FrmTargetBooking

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT As New DataTable
    Dim Code As String
    Dim Code_Check As String
    Dim Code_Approve As String
    Private Sub FrmTargetBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpYear.Value = Date.Now

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
            .SelectedIndex = -1
            If Branch_ID = 0 And MultipleBranch Then
            Else
                .Enabled = False
            End If
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        FirstLoad = False
        cbxBranch.SelectedValue = Branch_ID
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelIssued, LabelX5, LabelX12, LabelX34})

            GetLabelWithBackgroundFontSettings({lblTotal, LabelX4})

            GetCheckBoxFontSettings({cbx1st, cbx2nd})

            GetButtonFontSettings({btnSave, btnCancel, btnPrint, btnCheck, btnApprove})

            GetComboBoxFontSettings({cbxBranch, cbxPreparedBy})

            GetDateTimeInputFontSettings({dtpYear})

            GetTextBoxFontSettings({txtChecked, txtApproved})

            GetDoubleInputFontSettings({dJanBT, dJanTT, dFebBT, dFebTT, dMarBT, dMarTT, dAprBT, dAprTT, dMayBT, dMayTT, dJunBT, dJunTT, dTotalBT, dTotalTT})
        Catch ex As Exception
            TriggerBugReport("Target Booking - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Target Booking", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = " SELECT "
        SQL &= "    IFNULL(F.ID,0) AS 'ID',"
        SQL &= "    A.ID AS 'ProductID',"
        SQL &= "    A.Product,"
        SQL &= "    IFNULL(SUM(F.M01B),0) AS 'Booking_1',"
        SQL &= "    IFNULL(SUM(F.M01T),0) AS 'Threshold_1',"
        SQL &= "    IFNULL(SUM(F.M02B),0) AS 'Booking_2',"
        SQL &= "    IFNULL(SUM(F.M02T),0) AS 'Threshold_2',"
        SQL &= "    IFNULL(SUM(F.M03B),0) AS 'Booking_3',"
        SQL &= "    IFNULL(SUM(F.M03T),0) AS 'Threshold_3',"
        SQL &= "    IFNULL(SUM(F.M04B),0) AS 'Booking_4',"
        SQL &= "    IFNULL(SUM(F.M04T),0) AS 'Threshold_4',"
        SQL &= "    IFNULL(SUM(F.M05B),0) AS 'Booking_5',"
        SQL &= "    IFNULL(SUM(F.M05T),0) AS 'Threshold_5',"
        SQL &= "    IFNULL(SUM(F.M06B),0) AS 'Booking_6',"
        SQL &= "    IFNULL(SUM(F.M06T),0) AS 'Threshold_6',"
        SQL &= "    IFNULL(F.M01B + F.M02B + F.M03B + F.M04B + F.M05B + F.M06B,0) AS 'Booking_T',"
        SQL &= "    IFNULL(F.M01T + F.M02T + F.M03T + F.M04T + F.M05T + F.M06T,0) AS 'Threshold_T',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', IFNULL(OTAC_Check,'') AS 'OTAC_Check', IFNULL(OTAC_Approve,'') AS 'OTAC_Approve', IFNULL(FP_Status,'') AS 'FP_Status'"
        SQL &= String.Format(" FROM product_setup A LEFT JOIN target_booking F ON ProductID = A.ID AND F.`Year` = '{0}' AND BranchID = '{1}' AND F.`status` = 'ACTIVE' AND F.Half = '{2}' WHERE A.`status` = 'ACTIVE' AND A.Branch_ID = '{1}' GROUP BY A.ID", Format(dtpYear.Value, "yyyy"), cbxBranch.SelectedValue, If(cbx1st.Checked, 1, 2))
        SQL &= "    ORDER BY A.Code ;"

        DT = DataSource(SQL)
        GridControl1.DataSource = DT
        If DT.Rows.Count > 0 Then
            ID = DT(0)("ID")
            txtChecked.Text = DT(0)("Checked By")
            txtApproved.Text = DT(0)("Approved By")
            Code_Check = DT(0)("OTAC_Check")
            Code_Approve = DT(0)("OTAC_Approve")
        Else
            ID = 0
            txtChecked.Text = ""
            txtApproved.Text = ""
            Code_Check = ""
            Code_Approve = ""
        End If

        Dim vJanT As Double
        Dim vFebT As Double
        Dim vMarT As Double
        Dim vAprT As Double
        Dim vMayT As Double
        Dim vJunT As Double
        Dim vTotal As Double

        Dim vJanTT As Double
        Dim vFebTT As Double
        Dim vMarTT As Double
        Dim vAprTT As Double
        Dim vMayTT As Double
        Dim vJunTT As Double
        Dim vTotalT As Double
        For x As Integer = 0 To BandedGridView1.RowCount - 1
            With BandedGridView1
                vJanT += CDbl(.GetRowCellValue(x, "Booking_1"))
                vFebT += CDbl(.GetRowCellValue(x, "Booking_2"))
                vMarT += CDbl(.GetRowCellValue(x, "Booking_3"))
                vAprT += CDbl(.GetRowCellValue(x, "Booking_4"))
                vMayT += CDbl(.GetRowCellValue(x, "Booking_5"))
                vJunT += CDbl(.GetRowCellValue(x, "Booking_6"))
                vTotal += CDbl(.GetRowCellValue(x, "Booking_T"))

                vJanTT += CDbl(.GetRowCellValue(x, "Threshold_1"))
                vFebTT += CDbl(.GetRowCellValue(x, "Threshold_2"))
                vMarTT += CDbl(.GetRowCellValue(x, "Threshold_3"))
                vAprTT += CDbl(.GetRowCellValue(x, "Threshold_4"))
                vMayTT += CDbl(.GetRowCellValue(x, "Threshold_5"))
                vJunTT += CDbl(.GetRowCellValue(x, "Threshold_6"))
                vTotalT += CDbl(.GetRowCellValue(x, "Threshold_T"))
            End With
        Next
        dJanBT.Value = vJanT
        dFebBT.Value = vFebT
        dMarBT.Value = vMarT
        dAprBT.Value = vAprT
        dMayBT.Value = vMayT
        dJunBT.Value = vJunT
        dTotalBT.Value = vTotal

        dJanTT.Value = vJanTT
        dFebTT.Value = vFebTT
        dMarTT.Value = vMarTT
        dAprTT.Value = vAprTT
        dMayTT.Value = vMayTT
        dJunTT.Value = vJunTT
        dTotalTT.Value = vTotalT

        If ID = 0 Then
            btnSave.Text = "&Save"
            cbxPreparedBy.SelectedValue = Empl_ID

            btnCheck.Enabled = False
            btnApprove.Enabled = False
            BandedGridView1.OptionsBehavior.Editable = True
        Else
            btnSave.Text = "Update"
            cbxPreparedBy.Text = DT(0)("Prepared By")

            If BandedGridView1.GetRowCellValue(0, "FP_Status") = "PENDING" Then
                btnCheck.Enabled = True
                btnApprove.Enabled = False
                BandedGridView1.OptionsBehavior.Editable = True
            ElseIf BandedGridView1.GetRowCellValue(0, "FP_Status") = "CHECKED" Then
                btnCheck.Enabled = False
                btnApprove.Enabled = True
                BandedGridView1.OptionsBehavior.Editable = True
            Else
                btnCheck.Enabled = False
                btnApprove.Enabled = False
                BandedGridView1.OptionsBehavior.Editable = False
            End If
        End If

        If BandedGridView1.RowCount > 18 Then
            BandedGridColumn1.Width = 167 - 17
            lblTotal.Size = New Point(171 - 17, 19)
            dJanBT.Location = New Point(182 - 17, 6)
            dJanTT.Location = New Point(252 - 17, 6)
            dFebBT.Location = New Point(322 - 17, 6)
            dFebTT.Location = New Point(392 - 17, 6)
            dMarBT.Location = New Point(462 - 17, 6)
            dMarTT.Location = New Point(532 - 17, 6)
            dAprBT.Location = New Point(601 - 17, 6)
            dAprTT.Location = New Point(672 - 17, 6)
            dMayBT.Location = New Point(742 - 17, 6)
            dMayTT.Location = New Point(812 - 17, 6)
            dJunBT.Location = New Point(882 - 17, 6)
            dJunTT.Location = New Point(952 - 17, 6)
            dTotalBT.Location = New Point(1022 - 17, 6)
            dTotalTT.Location = New Point(1092 - 17, 6)
        Else
            BandedGridColumn1.Width = 167
            lblTotal.Size = New Point(171, 19)
            dJanBT.Location = New Point(182, 6)
            dJanTT.Location = New Point(252, 6)
            dFebBT.Location = New Point(322, 6)
            dFebTT.Location = New Point(392, 6)
            dMarBT.Location = New Point(462, 6)
            dMarTT.Location = New Point(532, 6)
            dAprBT.Location = New Point(601, 6)
            dAprTT.Location = New Point(672, 6)
            dMayBT.Location = New Point(742, 6)
            dMayTT.Location = New Point(812, 6)
            dJunBT.Location = New Point(882, 6)
            dJunTT.Location = New Point(952, 6)
            dTotalBT.Location = New Point(1022, 6)
            dTotalTT.Location = New Point(1092, 6)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BandedGridView1.CellValueChanged
        With BandedGridView1
            If e.Column.FieldName = "Booking_1" Or e.Column.FieldName = "Booking_2" Or e.Column.FieldName = "Booking_3" Or e.Column.FieldName = "Booking_4" Or e.Column.FieldName = "Booking_5" Or e.Column.FieldName = "Booking_6" Or e.Column.FieldName = "Threshold_1" Or e.Column.FieldName = "Threshold_2" Or e.Column.FieldName = "Threshold_3" Or e.Column.FieldName = "Threshold_4" Or e.Column.FieldName = "Threshold_5" Or e.Column.FieldName = "Threshold_6" Then
                If .GetRowCellValue(.FocusedRowHandle, "Booking_1").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_1")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_1", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Booking_2").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_2")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_2", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Booking_3").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_3")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_3", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Booking_4").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_4")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_4", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Booking_5").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_5")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_5", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Booking_6").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Booking_6")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Booking_6", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_1").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_1")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_1", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_2").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_2")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_2", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_3").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_3")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_3", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_4").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_4")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_4", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_5").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_5")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_5", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Threshold_6").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Threshold_6")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Threshold_6", 0)
                End If
                If IsNumeric(.GetFocusedRowCellValue("Booking_1")) And IsNumeric(.GetFocusedRowCellValue("Booking_2")) And IsNumeric(.GetFocusedRowCellValue("Booking_3")) And IsNumeric(.GetFocusedRowCellValue("Booking_4")) And IsNumeric(.GetFocusedRowCellValue("Booking_5")) And IsNumeric(.GetFocusedRowCellValue("Booking_6")) Then
                    .SetFocusedRowCellValue("Booking_T", CDbl(.GetFocusedRowCellValue("Booking_1")) + CDbl(.GetFocusedRowCellValue("Booking_2")) + CDbl(.GetFocusedRowCellValue("Booking_3")) + CDbl(.GetFocusedRowCellValue("Booking_4")) + CDbl(.GetFocusedRowCellValue("Booking_5")) + CDbl(.GetFocusedRowCellValue("Booking_6")))
                End If
                If IsNumeric(.GetFocusedRowCellValue("Threshold_1")) And IsNumeric(.GetFocusedRowCellValue("Threshold_2")) And IsNumeric(.GetFocusedRowCellValue("Threshold_3")) And IsNumeric(.GetFocusedRowCellValue("Threshold_4")) And IsNumeric(.GetFocusedRowCellValue("Threshold_5")) And IsNumeric(.GetFocusedRowCellValue("Threshold_6")) Then
                    .SetFocusedRowCellValue("Threshold_T", CDbl(.GetFocusedRowCellValue("Threshold_1")) + CDbl(.GetFocusedRowCellValue("Threshold_2")) + CDbl(.GetFocusedRowCellValue("Threshold_3")) + CDbl(.GetFocusedRowCellValue("Threshold_4")) + CDbl(.GetFocusedRowCellValue("Threshold_5")) + CDbl(.GetFocusedRowCellValue("Threshold_6")))
                End If
            End If

            If e.Column.FieldName = "Booking_1" And IsNumeric(.GetFocusedRowCellValue("Booking_1")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_1"))
                Next
                dJanBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_2" And IsNumeric(.GetFocusedRowCellValue("Booking_2")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_2"))
                Next
                dFebBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_3" And IsNumeric(.GetFocusedRowCellValue("Booking_3")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_3"))
                Next
                dMarBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_4" And IsNumeric(.GetFocusedRowCellValue("Booking_4")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_4"))
                Next
                dAprBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_5" And IsNumeric(.GetFocusedRowCellValue("Booking_5")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_5"))
                Next
                dMayBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_6" And IsNumeric(.GetFocusedRowCellValue("Booking_6")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_6"))
                Next
                dJunBT.Value = Total
            ElseIf e.Column.FieldName = "Booking_T" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Booking_T"))
                Next
                dTotalBT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_1" And IsNumeric(.GetFocusedRowCellValue("Threshold_1")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_1"))
                Next
                dJanTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_2" And IsNumeric(.GetFocusedRowCellValue("Threshold_2")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_2"))
                Next
                dFebTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_3" And IsNumeric(.GetFocusedRowCellValue("Threshold_3")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_3"))
                Next
                dMarTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_4" And IsNumeric(.GetFocusedRowCellValue("Threshold_4")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_4"))
                Next
                dAprTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_5" And IsNumeric(.GetFocusedRowCellValue("Threshold_5")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_5"))
                Next
                dMayTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_6" And IsNumeric(.GetFocusedRowCellValue("Threshold_6")) Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_6"))
                Next
                dJunTT.Value = Total
            ElseIf e.Column.FieldName = "Threshold_T" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Threshold_T"))
                Next
                dTotalTT.Value = Total
            End If
        End With
    End Sub

    Private Sub Cbx1st_CheckedChanged(sender As Object, e As EventArgs) Handles cbx1st.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbx1st.Checked Then
            cbx2nd.Checked = False
            gridBand1.Caption = "January"
            gridBand4.Caption = "Febuary"
            gridBand7.Caption = "March"
            gridBand10.Caption = "April"
            gridBand13.Caption = "May"
            gridBand16.Caption = "June"

            LoadData()
        End If

        If cbx1st.Checked = False And cbx2nd.Checked = False Then
            cbx1st.Checked = True
        End If
    End Sub

    Private Sub Cbx2nd_CheckedChanged(sender As Object, e As EventArgs) Handles cbx2nd.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbx2nd.Checked Then
            cbx1st.Checked = False
            gridBand1.Caption = "July"
            gridBand4.Caption = "August"
            gridBand7.Caption = "September"
            gridBand10.Caption = "October"
            gridBand13.Caption = "November"
            gridBand16.Caption = "December"

            LoadData()
        End If

        If cbx1st.Checked = False And cbx2nd.Checked = False Then
            cbx1st.Checked = True
        End If
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxBranch.SelectedValue = Branch_ID Then
            btnSave.Enabled = True
        Else
            If User_Type = "ADMIN" Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If
        End If
        LoadData()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If
        With BandedGridView1
            For x As Integer = 0 To .RowCount - 1
                If CDbl(.GetRowCellValue(x, "Booking_1")) > CDbl(.GetRowCellValue(x, "Threshold_1")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand1.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf CDbl(.GetRowCellValue(x, "Booking_2")) > CDbl(.GetRowCellValue(x, "Threshold_2")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand4.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf CDbl(.GetRowCellValue(x, "Booking_3")) > CDbl(.GetRowCellValue(x, "Threshold_3")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand7.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf CDbl(.GetRowCellValue(x, "Booking_4")) > CDbl(.GetRowCellValue(x, "Threshold_4")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand10.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf CDbl(.GetRowCellValue(x, "Booking_5")) > CDbl(.GetRowCellValue(x, "Threshold_5")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand13.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf CDbl(.GetRowCellValue(x, "Booking_6")) > CDbl(.GetRowCellValue(x, "Threshold_6")) Then
                    MsgBox(String.Format("Threshold is lower than the Booking Target for Product {0} and month of {1}", .GetRowCellValue(x, "Product"), gridBand16.Caption), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Next
        End With

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                Code = GenerateOTAC()
                Code_Check = Code
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Target Booking of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalBT.Text, cbxPreparedBy.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                        End If
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Subject = "One Time Authorization Code " & Code
                    AttachmentFiles = New ArrayList()
                    FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    GenerateFP(False, FName, txtChecked.Text, txtApproved.Text)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If

                For x As Integer = 0 To BandedGridView1.RowCount - 1
                    SQL &= "INSERT INTO target_booking SET "
                    With BandedGridView1
                        SQL &= String.Format(" ProductID = '{0}',", .GetRowCellValue(x, "ProductID"))
                        SQL &= String.Format(" BranchID = '{0}',", cbxBranch.SelectedValue)
                        SQL &= String.Format(" `Year` = '{0}',", Format(dtpYear.Value, "yyyy"))
                        SQL &= String.Format(" M01B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_1")))
                        SQL &= String.Format(" M02B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_2")))
                        SQL &= String.Format(" M03B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_3")))
                        SQL &= String.Format(" M04B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_4")))
                        SQL &= String.Format(" M05B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_5")))
                        SQL &= String.Format(" M06B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_6")))
                        SQL &= String.Format(" M01T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_1")))
                        SQL &= String.Format(" M02T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_2")))
                        SQL &= String.Format(" M03T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_3")))
                        SQL &= String.Format(" M04T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_4")))
                        SQL &= String.Format(" M05T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_5")))
                        SQL &= String.Format(" M06T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_6")))
                    End With
                    SQL &= String.Format(" Half = '{0}',", If(cbx1st.Checked, 1, 2))
                    SQL &= String.Format(" `PreparedID` = '{0}',", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    SQL &= String.Format(" OTAC_Check = '{0}';", Code)
                Next
                DataObject(SQL)
                Logs("Target Booking", "Save", "Save Target Booking", String.Format("Save Target Booking for {0}", cbxBranch.Text), "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Code = GenerateOTAC()
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code & " [UPDATE]"
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                If txtChecked.Text = "" Then
                    'F O R   C H E C K I N G************************************************************************************************************************
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Target Booking of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalBT.Text, cbxPreparedBy.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_Signatory(x)("Phone") = "" Then
                            Else
                                SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_Signatory(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                            End If
                        End If
                    Next
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [UPDATE]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        GenerateFP(False, FName, txtChecked.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    'F O R   C H E C K I N G************************************************************************************************************************
                ElseIf txtApproved.Text = "" Then
                    'F O R   A P P R O V A L ***********************************************************************************************************************
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Target Booking of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalBT.Text, cbxPreparedBy.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_Signatory(x)("Phone") = "" Then
                            Else
                                SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_Signatory(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                            End If
                        End If
                    Next
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [UPDATE]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        GenerateFP(False, FName, txtChecked.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    'F O R   A P P R O V A L ***********************************************************************************************************************
                End If

                Dim SQL As String = ""
                For x As Integer = 0 To BandedGridView1.RowCount - 1
                    SQL &= "UPDATE target_booking SET "
                    With BandedGridView1
                        SQL &= String.Format(" M01B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_1")))
                        SQL &= String.Format(" M02B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_2")))
                        SQL &= String.Format(" M03B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_3")))
                        SQL &= String.Format(" M04B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_4")))
                        SQL &= String.Format(" M05B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_5")))
                        SQL &= String.Format(" M06B = '{0}',", CDbl(.GetRowCellValue(x, "Booking_6")))
                        SQL &= String.Format(" M01T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_1")))
                        SQL &= String.Format(" M02T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_2")))
                        SQL &= String.Format(" M03T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_3")))
                        SQL &= String.Format(" M04T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_4")))
                        SQL &= String.Format(" M05T = '{0}',", CDbl(.GetRowCellValue(x, "Threshold_5")))
                    End With
                    If txtChecked.Text = "" Then
                        SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    ElseIf txtApproved.Text = "" Then
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                    End If
                    SQL &= String.Format(" M06T = '{0}'", CDbl(BandedGridView1.GetRowCellValue(x, "Threshold_6")))
                    SQL &= String.Format(" WHERE `Year` = '{1}' AND ProductID = '{2}' AND BranchID = '{3}' AND Half = '{4}';", BandedGridView1.GetRowCellValue(x, "ID"), Format(dtpYear.Value, "yyyy"), BandedGridView1.GetRowCellValue(x, "ProductID"), cbxBranch.SelectedValue, If(cbx1st.Checked, 1, 2))
                Next
                DataObject(SQL)
                Logs("Target Booking", "Update", String.Format("Update Target Booking for {0}", cbxBranch.Text), Changes(), "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Return Change
    End Function

    Private Sub GenerateFP(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptTargetBooking
        With Report
            .Name = String.Format("Target Booking of {0} - {1} {2}", cbxBranch.Text, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, "1st Half", "2nd Half"))
            .lblAsOf.Text = Format(Date.Now, "MMMM dd, yyyy")

            .lblYear.Text = Format(dtpYear.Value, "yyyy")
            .cbx1st.Checked = cbx1st.Checked
            .cbx2nd.Checked = cbx2nd.Checked

            .DataSource = GridControl1.DataSource
            If cbx1st.Checked Then
                .lblJanH.Text = "January"
                .lblFebH.Text = "Febuary"
                .lblMarH.Text = "March"
                .lblAprH.Text = "April"
                .lblMayH.Text = "May"
                .lblJunH.Text = "June"
            Else
                .lblJanH.Text = "July"
                .lblFebH.Text = "August"
                .lblMarH.Text = "September"
                .lblAprH.Text = "October"
                .lblMayH.Text = "November"
                .lblJunH.Text = "December"
            End If
            .lblProduct.DataBindings.Add("Text", GridControl1.DataSource, "Product")
            .lblBooking_1.DataBindings.Add("Text", GridControl1.DataSource, "Booking_1")
            .lblBooking_2.DataBindings.Add("Text", GridControl1.DataSource, "Booking_2")
            .lblBooking_3.DataBindings.Add("Text", GridControl1.DataSource, "Booking_3")
            .lblBooking_4.DataBindings.Add("Text", GridControl1.DataSource, "Booking_4")
            .lblBooking_5.DataBindings.Add("Text", GridControl1.DataSource, "Booking_5")
            .lblBooking_6.DataBindings.Add("Text", GridControl1.DataSource, "Booking_6")
            .lblBooking_T.DataBindings.Add("Text", GridControl1.DataSource, "Booking_T")
            .lblThreshold_1.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_1")
            .lblThreshold_2.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_2")
            .lblThreshold_3.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_3")
            .lblThreshold_4.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_4")
            .lblThreshold_5.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_5")
            .lblThreshold_6.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_6")
            .lblThreshold_T.DataBindings.Add("Text", GridControl1.DataSource, "Threshold_T")
            .lblBooking_1T.Text = dJanBT.Text
            .lblBooking_2T.Text = dFebBT.Text
            .lblBooking_3T.Text = dMarBT.Text
            .lblBooking_4T.Text = dAprBT.Text
            .lblBooking_5T.Text = dMayBT.Text
            .lblBooking_6T.Text = dJunBT.Text
            .lblBooking_TT.Text = dTotalBT.Text
            .lblThreshold_1T.Text = dJanTT.Text
            .lblThreshold_2T.Text = dFebTT.Text
            .lblThreshold_3T.Text = dMarTT.Text
            .lblThreshold_4T.Text = dAprTT.Text
            .lblThreshold_5T.Text = dMayTT.Text
            .lblThreshold_6T.Text = dJunTT.Text
            .lblThreshold_TT.Text = dTotalTT.Text

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblCheckedBy.Text = CheckedBy
            .lblApprovedBy.Text = ApprovedBy
            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
    End Sub

    Private Sub DtpYear_ValueChanged(sender As Object, e As EventArgs) Handles dtpYear.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Check
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Code = GenerateOTAC()
                            Code_Approve = Code
                            Dim Msg As String = ""
                            Dim EmailTo As String = ""
                            Dim Subject As String = "One Time Authorization Code " & Code
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Target Booking of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalBT.Text, cbxPreparedBy.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Signatory(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Signatory(x)("EmailAdd") = "" Then
                                    Else
                                        EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                                    End If
                                End If
                            Next
                            If EmailTo = "" Then
                            Else
                                Subject = "One Time Authorization Code " & Code
                                AttachmentFiles = New ArrayList()
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                GenerateFP(False, FName, txtChecked.Text, txtApproved.Text)
                                AttachmentFiles.Add(FName)
                                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                            End If

                            DataObject(String.Format("UPDATE target_booking SET `FP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE BranchID = '{0}' AND Year = '{3}' AND Half = '{4}';", cbxBranch.SelectedValue, .cbxProvider.SelectedValue, Code, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                            Logs("Target Booking", "Check", String.Format("Checked Target Booking of {0} with the total amount of {1}.", cbxBranch.Text, dTotalBT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                        End If
                        LoadData()
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you check this Target Booking?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Approve = Code
                Dim Msg As String = ""
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                    If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Target Booking of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalBT.Text, cbxPreparedBy.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_Signatory(x)("Phone") = "" Then
                        Else
                            SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_Signatory(x)("EmailAdd") = "" Then
                        Else
                            EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                        End If
                    End If
                Next
                If EmailTo = "" Then
                Else
                    Subject = "One Time Authorization Code " & Code
                    AttachmentFiles = New ArrayList()
                    FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    GenerateFP(False, FName, txtChecked.Text, txtApproved.Text)
                    AttachmentFiles.Add(FName)
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If

                DataObject(String.Format("UPDATE target_booking SET `FP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE BranchID = '{0}' AND Year = '{3}' AND Half = '{4}';", cbxBranch.SelectedValue, Empl_ID, Code, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                Logs("Target Booking", "Check", String.Format("Checked Target Booking of {0} with the total amount of {1}.", cbxBranch.Text, dTotalBT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code_Approve
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnApprove.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            DataObject(String.Format("UPDATE target_booking SET `FP_Status` = 'APPROVED', ApprovedID = '{1}' WHERE BranchID = '{0}' AND Year = '{2}' AND Half = '{3}';", cbxBranch.SelectedValue, .cbxProvider.SelectedValue, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                            Logs("Target Booking", "Approve", String.Format("Approved Target Booking of {0} with the total amount of {1}.", cbxBranch.Text, dTotalBT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            LoadData()
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Target Booking?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE target_booking SET `FP_Status` = 'APPROVED', ApprovedID = '{1}' WHERE BranchID = '{0}' AND Year = '{2}' AND Half = '{3}';", cbxBranch.SelectedValue, Empl_ID, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                Logs("Target Booking", "Approve", String.Format("Approved Target Booking of {0} with the total amount of {1}.", cbxBranch.Text, dTotalBT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                LoadData()
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
        GenerateFP(True, "", txtChecked.Text, txtApproved.Text)
        Logs("Target Booking", "Print", "[SENSITIVE] Print Target Booking of " & cbxBranch.Text & " for Year " & dtpYear.Text & " " & If(cbx1st.Checked, "1st Half", "2nd Half"), "", "", "", "")
        Cursor = Cursors.Default
    End Sub
End Class