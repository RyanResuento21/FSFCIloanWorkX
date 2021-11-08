Imports DevExpress.XtraReports.UI
Public Class FrmFinancialPlan

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT As DataTable
    Dim Code As String

    Dim Code_Check As String
    Dim Code_Approve As String
    Private Sub FrmFinancialPlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpYear.Value = Date.Now
        If dtpYear.Value.Year > 2021 Then
            cbxBS.Checked = True
        End If

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
        If Date.Now.Month > 6 Then
            cbx1st.Checked = False
            cbx2nd.Checked = True
        End If
        cbxBranch.SelectedValue = Branch_ID
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX2, LabelIssued, LabelX5, LabelX12, LabelX34, LabelX1})

            GetLabelWithBackgroundFontSettings({LabelX19, LabelX4})

            GetCheckBoxFontSettings({cbx1st, cbx2nd, cbxBS, cbxIS})

            GetButtonFontSettings({btnSave, btnCancel, btnPrint, btnCheck, btnApprove})

            GetComboBoxFontSettings({cbxBranch, cbxPreparedBy})

            GetDateTimeInputFontSettings({dtpYear})

            GetDoubleInputFontSettings({dJanT, dFebT, dMarT, dAprT, dMayT, dJunT, dTotalT})

            GetTextBoxFontSettings({txtChecked, txtApproved})

            GetLabelHeaderFontSettings({lblTitle})
        Catch ex As Exception
            TriggerBugReport("Financial Plan - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Financial Plan", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = " SELECT "
        If CompanyMode = 0 Then
            SQL &= "    IFNULL(F.ID,0) AS 'ID',"
            SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name',"
            SQL &= "    A.Code AS 'Mother Code',"
            SQL &= "    IFNULL(SUM(F.M01),0) AS 'Jan',"
            SQL &= "    IFNULL(SUM(F.M02),0) AS 'Feb',"
            SQL &= "    IFNULL(SUM(F.M03),0) AS 'Mar',"
            SQL &= "    IFNULL(SUM(F.M04),0) AS 'Apr',"
            SQL &= "    IFNULL(SUM(F.M05),0) AS 'May',"
            SQL &= "    IFNULL(SUM(F.M06),0) AS 'Jun',"
            SQL &= "    IFNULL(F.M01 + F.M02 + F.M03 + F.M04 + F.M05 + F.M06,0) AS 'Total', IFNULL(F.AccountType,0) AS 'AccountType', A.Type_ID,"
            SQL &= "    Employee(PreparedID) AS 'Prepared By', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', IFNULL(OTAC_Check,'') AS 'OTAC_Check', IFNULL(OTAC_Approve,'') AS 'OTAC_Approve', IFNULL(FP_Status,'') AS 'FP_Status'"
            SQL &= String.Format(" FROM account_chart A LEFT JOIN financial_plan F ON F.MotherCode = A.`Code` AND F.`Year` = '{0}' AND BranchID = '{1}' AND F.`status` = 'ACTIVE' AND F.Half = '{2}' WHERE A.`status` = 'ACTIVE' AND Main_ID = 0 GROUP BY Code", Format(dtpYear.Value, "yyyy"), cbxBranch.SelectedValue, If(cbx1st.Checked, 1, 2))
            If cbxBS.Checked And cbxIS.Checked = False Then
                SQL &= "  AND A.Type_ID < 4"
            ElseIf cbxBS.Checked = False And cbxIS.Checked Then
                SQL &= "  AND A.Type_ID > 3"
            End If
            SQL &= "    ORDER BY A.Code ;"
        Else
            SQL &= "    IFNULL(F.ID,0) AS 'ID',"
            SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name',"
            SQL &= "    A.MotherCode AS 'Mother Code',"
            SQL &= "    IFNULL(F.M01,0) AS 'Jan',"
            SQL &= "    IFNULL(F.M02,0) AS 'Feb',"
            SQL &= "    IFNULL(F.M03,0) AS 'Mar',"
            SQL &= "    IFNULL(F.M04,0) AS 'Apr',"
            SQL &= "    IFNULL(F.M05,0) AS 'May',"
            SQL &= "    IFNULL(F.M06,0) AS 'Jun',"
            SQL &= "    IFNULL(F.M01 + F.M02 + F.M03 + F.M04 + F.M05 + F.M06,0) AS 'Total', IFNULL(F.AccountType,0) AS 'AccountType', A.Type_ID,"
            SQL &= "    Employee(PreparedID) AS 'Prepared By', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', IFNULL(OTAC_Check,'') AS 'OTAC_Check', IFNULL(OTAC_Approve,'') AS 'OTAC_Approve', IFNULL(FP_Status,'') AS 'FP_Status'"
            SQL &= String.Format(" FROM account_chart A LEFT JOIN financial_plan F ON F.AccountCode = A.`Code` AND F.`Year` = '{0}' AND BranchID = '{1}' AND F.`status` = 'ACTIVE' AND F.Half = '{2}' WHERE A.`status` = 'ACTIVE' AND Main_ID > 0", Format(dtpYear.Value, "yyyy"), cbxBranch.SelectedValue, If(cbx1st.Checked, 1, 2))
            If cbxBS.Checked And cbxIS.Checked = False Then
                SQL &= "  AND A.Type_ID < 4"
            ElseIf cbxBS.Checked = False And cbxIS.Checked Then
                SQL &= "  AND A.Type_ID > 3"
            End If
            SQL &= "    ORDER BY A.Code ;"
        End If

        DT = DataSource(SQL)
        GridControl1.DataSource = DT
        ID = DataObject(String.Format("SELECT ID FROM financial_plan WHERE BranchID = '{0}' AND `Year` = '{1}' AND Half = {2} AND `status` = 'ACTIVE' AND IF(({3} AND {4}) OR ({3} = FALSE AND {4} = FALSE),TRUE,IF({3},AccountType < 4,IF({4},AccountType > 3,TRUE))) LIMIT 1;", cbxBranch.SelectedValue, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2), cbxBS.Checked, cbxIS.Checked))
        Dim RowCheck As Integer = 0
        If ID > 0 Then
            For x As Integer = 0 To DT.Rows.Count - 1
                If DT(x)("ID") > 0 Then
                    RowCheck = x
                    Exit For
                End If
            Next
        End If
        txtChecked.Text = DT(RowCheck)("Checked By")
        txtApproved.Text = DT(RowCheck)("Approved By")
        Code_Check = DT(RowCheck)("OTAC_Check")
        Code_Approve = DT(RowCheck)("OTAC_Approve")

        Dim vJanT As Double
        Dim vFebT As Double
        Dim vMarT As Double
        Dim vAprT As Double
        Dim vMayT As Double
        Dim vJunT As Double
        Dim vTotal As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            vJanT += CDbl(GridView1.GetRowCellValue(x, "Jan"))
            vFebT += CDbl(GridView1.GetRowCellValue(x, "Feb"))
            vMarT += CDbl(GridView1.GetRowCellValue(x, "Mar"))
            vAprT += CDbl(GridView1.GetRowCellValue(x, "Apr"))
            vMayT += CDbl(GridView1.GetRowCellValue(x, "May"))
            vJunT += CDbl(GridView1.GetRowCellValue(x, "Jun"))
            vTotal += CDbl(GridView1.GetRowCellValue(x, "Total"))
        Next
        dJanT.Value = vJanT
        dFebT.Value = vFebT
        dMarT.Value = vMarT
        dAprT.Value = vAprT
        dMayT.Value = vMayT
        dJunT.Value = vJunT
        dTotalT.Value = vTotal

        If ID = 0 Then
            btnSave.Text = "&Save"
            cbxPreparedBy.SelectedValue = Empl_ID

            btnCheck.Enabled = False
            btnApprove.Enabled = False
            GridView1.OptionsBehavior.Editable = True
        Else
            btnSave.Text = "Update"
            cbxPreparedBy.Text = DT(RowCheck)("Prepared By")

            If GridView1.GetRowCellValue(RowCheck, "FP_Status") = "PENDING" Then
                btnCheck.Enabled = True
                btnApprove.Enabled = False
                GridView1.OptionsBehavior.Editable = True
            ElseIf GridView1.GetRowCellValue(RowCheck, "FP_Status") = "CHECKED" Then
                btnCheck.Enabled = False
                btnApprove.Enabled = True
                GridView1.OptionsBehavior.Editable = True
            Else
                btnCheck.Enabled = False
                btnApprove.Enabled = False
                GridView1.OptionsBehavior.Editable = False
            End If
        End If

        If GridView1.RowCount > 19 Then
            GridColumn2.Width = 368 - 17
        Else
            GridColumn2.Width = 368 - 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        With GridView1
            If e.Column.FieldName = "Jan" Or e.Column.FieldName = "Feb" Or e.Column.FieldName = "Mar" Or e.Column.FieldName = "Apr" Or e.Column.FieldName = "May" Or e.Column.FieldName = "Jun" Then
                If .GetRowCellValue(.FocusedRowHandle, "Jan").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Jan")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Jan", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Feb").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Feb")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Feb", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Mar").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Mar")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Mar", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Apr").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Apr")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Apr", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "May").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("May")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "May", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Jun").ToString = "" Or IsNumeric(.GetFocusedRowCellValue("Jun")) = False Then
                    .SetRowCellValue(.FocusedRowHandle, "Jun", 0)
                End If
                .SetFocusedRowCellValue("Total", CDbl(.GetFocusedRowCellValue("Jan")) + CDbl(.GetFocusedRowCellValue("Feb")) + CDbl(.GetFocusedRowCellValue("Mar")) + CDbl(.GetFocusedRowCellValue("Apr")) + CDbl(.GetFocusedRowCellValue("May")) + CDbl(.GetFocusedRowCellValue("Jun")))
            End If

            If e.Column.FieldName = "Jan" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Jan"))
                Next
                dJanT.Value = Total
            ElseIf e.Column.FieldName = "Feb" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Feb"))
                Next
                dFebT.Value = Total
            ElseIf e.Column.FieldName = "Mar" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Mar"))
                Next
                dMarT.Value = Total
            ElseIf e.Column.FieldName = "Apr" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Apr"))
                Next
                dAprT.Value = Total
            ElseIf e.Column.FieldName = "May" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "May"))
                Next
                dMayT.Value = Total
            ElseIf e.Column.FieldName = "Jun" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Jun"))
                Next
                dJunT.Value = Total
            ElseIf e.Column.FieldName = "Total" Then
                Dim Total As Double
                For x As Integer = 0 To .RowCount - 1
                    Total += CDbl(.GetRowCellValue(x, "Total"))
                Next
                dTotalT.Value = Total
            End If
        End With
    End Sub

    Private Sub Cbx1st_CheckedChanged(sender As Object, e As EventArgs) Handles cbx1st.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbx1st.Checked Then
            cbx2nd.Checked = False

            GridColumn3.Caption = "Jan"
            GridColumn4.Caption = "Feb"
            GridColumn5.Caption = "Mar"
            GridColumn6.Caption = "Apr"
            GridColumn7.Caption = "May"
            GridColumn8.Caption = "Jun"

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

            GridColumn3.Caption = "Jul"
            GridColumn4.Caption = "Aug"
            GridColumn5.Caption = "Sep"
            GridColumn6.Caption = "Oct"
            GridColumn7.Caption = "Nov"
            GridColumn8.Caption = "Dec"

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

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                Code = GenerateOTAC()
                Code_Check = Code
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String
                    Dim FName As String
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Financial Plan of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalT.Text, cbxPreparedBy.Text)
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
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                For x As Integer = 0 To GridView1.RowCount - 1
                    SQL &= "INSERT INTO financial_plan SET "
                    SQL &= String.Format(" AccountCode = '{0}',", GridView1.GetRowCellValue(x, "Account Code"))
                    SQL &= String.Format(" MotherCode = '{0}',", GridView1.GetRowCellValue(x, "Mother Code"))
                    SQL &= String.Format(" BranchID = '{0}',", cbxBranch.SelectedValue)
                    SQL &= String.Format(" `Year` = '{0}',", Format(dtpYear.Value, "yyyy"))
                    SQL &= String.Format(" M01 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Jan")))
                    SQL &= String.Format(" M02 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Feb")))
                    SQL &= String.Format(" M03 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Mar")))
                    SQL &= String.Format(" M04 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Apr")))
                    SQL &= String.Format(" M05 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "May")))
                    SQL &= String.Format(" M06 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Jun")))
                    SQL &= String.Format(" Half = '{0}',", If(cbx1st.Checked, 1, 2))
                    SQL &= String.Format(" AccountType = '{0}',", GridView1.GetRowCellValue(x, "Type_ID"))
                    SQL &= String.Format(" `PreparedID` = '{0}',", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    SQL &= String.Format(" OTAC_Check = '{0}';", Code)
                Next
                DataObject(SQL)
                Logs("Financial Plan", "Save", "Save Financial Plan", String.Format("Save Financial Plan for {0}", cbxBranch.Text), "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String
                    Dim FName As String
                    If txtChecked.Text = "" Then
                        'F O R   C H E C K I N G************************************************************************************************************************
                        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                            If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                                Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Financial Plan of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalT.Text, cbxPreparedBy.Text)
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
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Financial Plan of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalT.Text, cbxPreparedBy.Text)
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
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                Dim SQL As String = ""
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "AccountType") = 0 Then
                        SQL &= "INSERT INTO financial_plan SET "
                        SQL &= String.Format(" AccountCode = '{0}',", GridView1.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}',", GridView1.GetRowCellValue(x, "Mother Code"))
                        SQL &= String.Format(" BranchID = '{0}',", cbxBranch.SelectedValue)
                        SQL &= String.Format(" `Year` = '{0}',", Format(dtpYear.Value, "yyyy"))
                        SQL &= String.Format(" M01 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Jan")))
                        SQL &= String.Format(" M02 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Feb")))
                        SQL &= String.Format(" M03 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Mar")))
                        SQL &= String.Format(" M04 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Apr")))
                        SQL &= String.Format(" M05 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "May")))
                        SQL &= String.Format(" M06 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Jun")))
                        SQL &= String.Format(" Half = '{0}',", If(cbx1st.Checked, 1, 2))
                        SQL &= String.Format(" AccountType = '{0}',", GridView1.GetRowCellValue(x, "Type_ID"))
                        SQL &= String.Format(" `PreparedID` = '{0}',", cbxPreparedBy.SelectedValue)
                        SQL &= " CheckedID = '0', "
                        If txtChecked.Text = "" Then
                            SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                        ElseIf txtApproved.Text = "" Then
                            SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                        End If
                        SQL &= " ApprovedID = '0';"
                    Else
                        SQL &= "UPDATE financial_plan SET "
                        SQL &= String.Format(" M01 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Jan")))
                        SQL &= String.Format(" M02 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Feb")))
                        SQL &= String.Format(" M03 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Mar")))
                        SQL &= String.Format(" M04 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "Apr")))
                        SQL &= String.Format(" M05 = '{0}',", CDbl(GridView1.GetRowCellValue(x, "May")))
                        If txtChecked.Text = "" Then
                            SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                        ElseIf txtApproved.Text = "" Then
                            SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                        End If
                        SQL &= String.Format(" M06 = '{0}'", CDbl(GridView1.GetRowCellValue(x, "Jun")))
                        SQL &= String.Format(" WHERE `Year` = '{1}' AND AccountCode = '{2}' AND BranchID = '{3}' AND Half = '{4}';", GridView1.GetRowCellValue(x, "ID"), Format(dtpYear.Value, "yyyy"), GridView1.GetRowCellValue(x, "Account Code"), cbxBranch.SelectedValue, If(cbx1st.Checked, 1, 2))
                    End If
                Next
                DataObject(SQL)
                Logs("Financial Plan", "Update", String.Format("Update Financial Plan for {0}", cbxBranch.Text), Changes(), "", "", "")

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
        Dim Report As New RptFinancialPlan
        With Report
            .Name = String.Format("Financial Plan of {0} - {1} {2}", cbxBranch.Text, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, "1st Half", "2nd Half"))
            .lblAsOf.Text = Format(Date.Now, "MMMM dd, yyyy")

            .lblYear.Text = Format(dtpYear.Value, "yyyy")
            .cbx1st.Checked = cbx1st.Checked
            .cbx2nd.Checked = cbx2nd.Checked

            .DataSource = GridControl1.DataSource
            If cbx1st.Checked Then
                .lblJanH.Text = "Jan"
                .lblFebH.Text = "Feb"
                .lblMarH.Text = "Mar"
                .lblAprH.Text = "Apr"
                .lblMayH.Text = "May"
                .lblJunH.Text = "Jun"
            Else
                .lblJanH.Text = "Jul"
                .lblFebH.Text = "Aug"
                .lblMarH.Text = "Sep"
                .lblAprH.Text = "Oct"
                .lblMayH.Text = "Nov"
                .lblJunH.Text = "Dec"
            End If
            .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
            .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
            .lblJan.DataBindings.Add("Text", GridControl1.DataSource, "Jan")
            .lblFeb.DataBindings.Add("Text", GridControl1.DataSource, "Feb")
            .lblMar.DataBindings.Add("Text", GridControl1.DataSource, "Mar")
            .lblApr.DataBindings.Add("Text", GridControl1.DataSource, "Apr")
            .lblMay.DataBindings.Add("Text", GridControl1.DataSource, "May")
            .lblJun.DataBindings.Add("Text", GridControl1.DataSource, "Jun")
            .lblTotal.DataBindings.Add("Text", GridControl1.DataSource, "Total")
            .lblJanT.Text = dJanT.Text
            .lblFebT.Text = dFebT.Text
            .lblMarT.Text = dMarT.Text
            .lblAprT.Text = dAprT.Text
            .lblMayT.Text = dMayT.Text
            .lblJunT.Text = dJunT.Text
            .lblTotalT.Text = dTotalT.Text

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
        If cbxBS.Checked = False Then
            MsgBox("Balance Sheet Accounts must be shown for checking.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxIS.Checked = False Then
            MsgBox("Income Statement Accounts must be shown for checking.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Signatory As Boolean = False
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
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                            If Auto_Notification Then
                                Dim Msg As String = ""
                                Dim EmailTo As String = ""
                                Dim Subject As String = "One Time Authorization Code " & Code
                                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                                    If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                                        Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Financial Plan of {1} with the total amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalT.Text, cbxPreparedBy.Text)
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
                            End If
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                            DataObject(String.Format("UPDATE financial_plan SET `FP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE BranchID = '{0}' AND Year = '{3}' AND Half = '{4}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue, .cbxProvider.SelectedValue, Code, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                            Logs("Financial Plan", "Check", String.Format("Checked Financial Plan of {0} with the total amount of {1}.", cbxBranch.Text, dTotalT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                        End If
                        LoadData()
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you check this Financial Plan?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Approve = Code
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & cbxBranch.Text & "-" & Format(dtpYear.Value, "yyyy-") & If(cbx1st.Checked, "1stHalf", "2ndHalf") & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Financial Plan of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxBranch.Text, dTotalT.Text, cbxPreparedBy.Text)
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
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE financial_plan SET `FP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}' WHERE BranchID = '{0}' AND Year = '{3}' AND Half = '{4}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue, Empl_ID, Code, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                Logs("Financial Plan", "Check", String.Format("Checked Financial Plan of {0} with the total amount of {1}.", cbxBranch.Text, dTotalT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If cbxBS.Checked = False Then
            MsgBox("Balance Sheet Accounts must be shown for checking.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxIS.Checked = False Then
            MsgBox("Income Statement Accounts must be shown for checking.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Signatory As Boolean = False
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
                            DataObject(String.Format("UPDATE financial_plan SET `FP_Status` = 'APPROVED', ApprovedID = '{1}' WHERE BranchID = '{0}' AND Year = '{2}' AND Half = '{3}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue, .cbxProvider.SelectedValue, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                            Logs("Financial Plan", "Approve", String.Format("Approved Financial Plan of {0} with the total amount of {1}.", cbxBranch.Text, dTotalT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            LoadData()
                        End If
                        .Dispose()
                    End With
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Financial Plan?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE financial_plan SET `FP_Status` = 'APPROVED', ApprovedID = '{1}' WHERE BranchID = '{0}' AND Year = '{2}' AND Half = '{3}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue, Empl_ID, Format(dtpYear.Value, "yyyy"), If(cbx1st.Checked, 1, 2)))
                Logs("Financial Plan", "Approve", String.Format("Approved Financial Plan of {0} with the total amount of {1}.", cbxBranch.Text, dTotalT.Text), "", "", "", "")

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
        Logs("Financial Plan", "Print", String.Format("[SENSITIVE] Print Financial Plan of {0} for Year {1} and {2} half.", cbxBranch.Text, dtpYear.Value, If(cbx1st.Checked, "1st", "2nd")), "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBS_IS_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBS.CheckedChanged, cbxIS.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub
End Class