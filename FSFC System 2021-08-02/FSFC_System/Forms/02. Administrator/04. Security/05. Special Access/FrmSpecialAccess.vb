Public Class FrmSpecialAccess

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean = True
    Private Sub FrmSpecialAccess_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxForm
            .ValueMember = "ID"
            .DisplayMember = "Form"
            .DataSource = DataSource("SELECT ID, CONCAT('[', module, '] ', IF(`group` = '','',CONCAT('(',`group`,') ')), form) AS 'Form' FROM form_setup WHERE `status` = 'ACTIVE' ORDER BY order_id;")
            .SelectedIndex = -1
        End With

        Dim DT_Position As DataTable = DataSource("SELECT ID, `Position` FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")

        Dim DT_Department As DataTable = DataSource("SELECT ID, Department FROM department_setup WHERE `status` = 'ACTIVE' ORDER BY `Department`;")

        With cbxP01
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP02
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP03
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP04
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP05
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP06
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP07
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP08
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP09
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP10
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP11
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxP12
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxD01
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxD02
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxD03
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxD04
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxD05
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        LoadData()
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

            GetLabelFontSettings({LabelX155, LabelX16, LabelX1, LabelX3, LabelX4, LabelX5, LabelX6, LabelX7, LabelX8, LabelX9, LabelX10, LabelX12, LabelX13, LabelX14})

            GetTextBoxFontSettings({txtAccess})

            GetCheckBoxFontSettings({cbxWith, cbxWithout})

            GetComboBoxFontSettings({cbxForm, cbxP01, cbxP02, cbxP03, cbxP04, cbxP05, cbxP06, cbxP07, cbxP08, cbxP09, cbxP10, cbxP11, cbxP12, cbxD01, cbxD02, cbxD03, cbxD04, cbxD05})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelWithBackgroundFontSettings({LabelX2, LabelX15})
        Catch ex As Exception
            TriggerBugReport("Special ACcess - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Signatory List", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, FormID, (SELECT CONCAT('[', module, '] ', IF(`group` = '','',CONCAT('(',`group`,') ')), form) AS 'Form' FROM form_setup WHERE ID = FormID) AS 'Form', Access, WithAccess, If(WithAccess=1,'With','Without') AS 'WithAccessN',"
        SQL &= "     P01, `Position`(P01) AS 'Position 01',"
        SQL &= "     P02, `Position`(P02) AS 'Position 02',"
        SQL &= "     P03, `Position`(P03) AS 'Position 03',"
        SQL &= "     P04, `Position`(P04) AS 'Position 04',"
        SQL &= "     P05, `Position`(P05) AS 'Position 05',"
        SQL &= "     P06, `Position`(P06) AS 'Position 06',"
        SQL &= "     P07, `Position`(P07) AS 'Position 07',"
        SQL &= "     P08, `Position`(P08) AS 'Position 08',"
        SQL &= "     P09, `Position`(P09) AS 'Position 09',"
        SQL &= "     P10, `Position`(P10) AS 'Position 10',"
        SQL &= "     P11, `Position`(P11) AS 'Position 11',"
        SQL &= "     P12, `Position`(P12) AS 'Position 12',"
        SQL &= "     D01, `DepartmentV2`(D01) AS 'Department 01',"
        SQL &= "     D02, `DepartmentV2`(D02) AS 'Department 02',"
        SQL &= "     D03, `DepartmentV2`(D03) AS 'Department 03',"
        SQL &= "     D04, `DepartmentV2`(D04) AS 'Department 04',"
        SQL &= "     D05, `DepartmentV2`(D05) AS 'Department 05' FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Access").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Access").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub TxtAccess_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccess.KeyDown, cbxP01.KeyDown, cbxP02.KeyDown, cbxP03.KeyDown, cbxP04.KeyDown, cbxP05.KeyDown, cbxP06.KeyDown, cbxP07.KeyDown, cbxP08.KeyDown, cbxP09.KeyDown, cbxP10.KeyDown, cbxP11.KeyDown, cbxP12.KeyDown, cbxD01.KeyDown, cbxD02.KeyDown, cbxD03.KeyDown, cbxD04.KeyDown, cbxD05.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

    Private Sub TxtAccess_Leave(sender As Object, e As EventArgs) Handles txtAccess.Leave
        txtAccess.Text = ReplaceText(txtAccess.Text.Trim)
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        cbxForm.SelectedIndex = -1
        txtAccess.Text = ""
        cbxWith.Checked = True
        cbxP01.SelectedIndex = -1
        cbxD01.SelectedIndex = -1
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Function CheckExist(SelectedValue As Integer, Level As Integer)
        Dim Exist As Boolean
        If SelectedValue = cbxP11.SelectedValue And Level <> 11 And cbxP11.Enabled Then
            MsgBox("Selected Position is the same with Position 11.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP10.SelectedValue And Level <> 10 And cbxP10.Enabled Then
            MsgBox("Selected Position is the same with Position 10.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP09.SelectedValue And Level <> 9 And cbxP09.Enabled Then
            MsgBox("Selected Position is the same with Position 9.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP08.SelectedValue And Level <> 8 And Level <> 8 And cbxP08.Enabled Then
            MsgBox("Selected Position is the same with Position 8.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP07.SelectedValue And Level <> 7 And cbxP07.Enabled Then
            MsgBox("Selected Position is the same with Position 7.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP06.SelectedValue And Level <> 6 And cbxP06.Enabled Then
            MsgBox("Selected Position is the same with Position 6.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP05.SelectedValue And Level <> 5 And cbxP05.Enabled Then
            MsgBox("Selected Position is the same with Position 5.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP04.SelectedValue And Level <> 4 And cbxP04.Enabled Then
            MsgBox("Selected Position is the same with Position 4.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP03.SelectedValue And Level <> 3 And cbxP03.Enabled Then
            MsgBox("Selected Position is the same with Position 3.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP02.SelectedValue And Level <> 2 And cbxP02.Enabled Then
            MsgBox("Selected Position is the same with Position 2.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxP01.SelectedValue Then
            MsgBox("Selected Position is the same with Position 1.", MsgBoxStyle.Information, "Info")
            Exist = True
        End If
        Return Exist
    End Function

    Private Sub CbxP01_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP01.SelectedIndexChanged
        If cbxP01.SelectedIndex = -1 Or cbxP01.Text = "" Then
            cbxP02.Enabled = False
            cbxP02.SelectedIndex = -1
        Else
            cbxP02.Enabled = True
            cbxP02.Focus()
        End If
    End Sub

    Private Sub CbxP02_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP02.SelectedIndexChanged
        If cbxP02.SelectedIndex = -1 Or cbxP02.Text = "" Then
            cbxP03.Enabled = False
            cbxP03.SelectedIndex = -1
        Else
            If CheckExist(cbxP02.SelectedValue, 2) Then
                cbxP02.SelectedIndex = -1
                Exit Sub
            End If
            cbxP03.Enabled = True
            cbxP03.Focus()
        End If
    End Sub

    Private Sub CbxP03_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP03.SelectedIndexChanged
        If cbxP03.SelectedIndex = -1 Or cbxP03.Text = "" Then
            cbxP04.Enabled = False
            cbxP04.SelectedIndex = -1
        Else
            If CheckExist(cbxP03.SelectedValue, 3) Then
                cbxP03.SelectedIndex = -1
                Exit Sub
            End If
            cbxP04.Enabled = True
            cbxP04.Focus()
        End If
    End Sub

    Private Sub CbxP04_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP04.SelectedIndexChanged
        If cbxP04.SelectedIndex = -1 Or cbxP04.Text = "" Then
            cbxP05.Enabled = False
            cbxP05.SelectedIndex = -1
        Else
            If CheckExist(cbxP04.SelectedValue, 4) Then
                cbxP04.SelectedIndex = -1
                Exit Sub
            End If
            cbxP05.Enabled = True
            cbxP05.Focus()
        End If
    End Sub

    Private Sub CbxP05_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP05.SelectedIndexChanged
        If cbxP05.SelectedIndex = -1 Or cbxP05.Text = "" Then
            cbxP06.Enabled = False
            cbxP06.SelectedIndex = -1
        Else
            If CheckExist(cbxP05.SelectedValue, 5) Then
                cbxP05.SelectedIndex = -1
                Exit Sub
            End If
            cbxP06.Enabled = True
            cbxP06.Focus()
        End If
    End Sub

    Private Sub CbxP06_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP06.SelectedIndexChanged
        If cbxP06.SelectedIndex = -1 Or cbxP06.Text = "" Then
            cbxP07.Enabled = False
            cbxP07.SelectedIndex = -1
        Else
            If CheckExist(cbxP06.SelectedValue, 6) Then
                cbxP06.SelectedIndex = -1
                Exit Sub
            End If
            cbxP07.Enabled = True
            cbxP07.Focus()
        End If
    End Sub

    Private Sub CbxP07_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP07.SelectedIndexChanged
        If cbxP07.SelectedIndex = -1 Or cbxP07.Text = "" Then
            cbxP08.Enabled = False
            cbxP08.SelectedIndex = -1
        Else
            If CheckExist(cbxP07.SelectedValue, 7) Then
                cbxP07.SelectedIndex = -1
                Exit Sub
            End If
            cbxP08.Enabled = True
            cbxP08.Focus()
        End If
    End Sub

    Private Sub CbxP08_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP08.SelectedIndexChanged
        If cbxP08.SelectedIndex = -1 Or cbxP08.Text = "" Then
            cbxP09.Enabled = False
            cbxP09.SelectedIndex = -1
        Else
            If CheckExist(cbxP08.SelectedValue, 8) Then
                cbxP08.SelectedIndex = -1
                Exit Sub
            End If
            cbxP09.Enabled = True
            cbxP09.Focus()
        End If
    End Sub

    Private Sub CbxP09_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP09.SelectedIndexChanged
        If cbxP09.SelectedIndex = -1 Or cbxP09.Text = "" Then
            cbxP10.Enabled = False
            cbxP10.SelectedIndex = -1
        Else
            If CheckExist(cbxP09.SelectedValue, 9) Then
                cbxP09.SelectedIndex = -1
                Exit Sub
            End If
            cbxP10.Enabled = True
            cbxP10.Focus()
        End If
    End Sub

    Private Sub CbxP10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP10.SelectedIndexChanged
        If cbxP10.SelectedIndex = -1 Or cbxP10.Text = "" Then
            cbxP11.Enabled = False
            cbxP11.SelectedIndex = -1
        Else
            If CheckExist(cbxP10.SelectedValue, 10) Then
                cbxP10.SelectedIndex = -1
                Exit Sub
            End If
            cbxP11.Enabled = True
            cbxP11.Focus()
        End If
    End Sub

    Private Sub CbxP11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP11.SelectedIndexChanged
        If cbxP11.SelectedIndex = -1 Or cbxP11.Text = "" Then
            cbxP12.Enabled = False
            cbxP12.SelectedIndex = -1
        Else
            If CheckExist(cbxP11.SelectedValue, 11) Then
                cbxP11.SelectedIndex = -1
                Exit Sub
            End If
            cbxP12.Enabled = True
            cbxP12.Focus()
        End If
    End Sub

    Private Sub CbxP12_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxP12.SelectedIndexChanged
        If cbxP12.SelectedIndex = -1 Or cbxP12.Text = "" Then
        Else
            If CheckExist(cbxP12.SelectedValue, 12) Then
                cbxP12.SelectedIndex = -1
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CbxP01_TextChanged(sender As Object, e As EventArgs) Handles cbxP01.TextChanged
        If cbxP01.Text = "" Then
            CbxP01_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP02_TextChanged(sender As Object, e As EventArgs) Handles cbxP02.TextChanged
        If cbxP02.Text = "" Then
            CbxP02_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP03_TextChanged(sender As Object, e As EventArgs) Handles cbxP03.TextChanged
        If cbxP03.Text = "" Then
            CbxP03_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP04_TextChanged(sender As Object, e As EventArgs) Handles cbxP04.TextChanged
        If cbxP04.Text = "" Then
            CbxP04_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP05_TextChanged(sender As Object, e As EventArgs) Handles cbxP05.TextChanged
        If cbxP05.Text = "" Then
            CbxP05_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP06_TextChanged(sender As Object, e As EventArgs) Handles cbxP06.TextChanged
        If cbxP06.Text = "" Then
            CbxP06_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP07_TextChanged(sender As Object, e As EventArgs) Handles cbxP07.TextChanged
        If cbxP07.Text = "" Then
            CbxP07_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP08_TextChanged(sender As Object, e As EventArgs) Handles cbxP08.TextChanged
        If cbxP08.Text = "" Then
            CbxP08_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP09_TextChanged(sender As Object, e As EventArgs) Handles cbxP09.TextChanged
        If cbxP09.Text = "" Then
            CbxP09_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP10_TextChanged(sender As Object, e As EventArgs) Handles cbxP10.TextChanged
        If cbxP10.Text = "" Then
            CbxP10_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxP11_TextChanged(sender As Object, e As EventArgs) Handles cbxP11.TextChanged
        If cbxP11.Text = "" Then
            CbxP11_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Function CheckExistDepartment(SelectedValue As Integer, Level As Integer)
        Dim Exist As Boolean
        If SelectedValue = cbxD04.SelectedValue And Level <> 4 And cbxD04.Enabled Then
            MsgBox("Selected Department is the same with Department 4.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxD03.SelectedValue And Level <> 3 And cbxD03.Enabled Then
            MsgBox("Selected Department is the same with Department 3.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxD02.SelectedValue And Level <> 2 And cbxD02.Enabled Then
            MsgBox("Selected Department is the same with Department 2.", MsgBoxStyle.Information, "Info")
            Exist = True
        ElseIf SelectedValue = cbxD01.SelectedValue Then
            MsgBox("Selected Department is the same with Department 1.", MsgBoxStyle.Information, "Info")
            Exist = True
        End If
        Return Exist
    End Function

    Private Sub CbxD01_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxD01.SelectedIndexChanged
        If cbxD01.SelectedIndex = -1 Or cbxD01.Text = "" Then
            cbxD02.Enabled = False
            cbxD02.SelectedIndex = -1
        Else
            cbxD02.Enabled = True
            cbxD02.Focus()
        End If
    End Sub

    Private Sub CbxD02_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxD02.SelectedIndexChanged
        If cbxD02.SelectedIndex = -1 Or cbxD02.Text = "" Then
            cbxD03.Enabled = False
            cbxD03.SelectedIndex = -1
        Else
            If CheckExistDepartment(cbxD02.SelectedValue, 2) Then
                cbxD02.SelectedIndex = -1
                Exit Sub
            End If
            cbxD03.Enabled = True
            cbxD03.Focus()
        End If
    End Sub

    Private Sub CbxD03_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxD03.SelectedIndexChanged
        If cbxD03.SelectedIndex = -1 Or cbxD03.Text = "" Then
            cbxD04.Enabled = False
            cbxD04.SelectedIndex = -1
        Else
            If CheckExistDepartment(cbxD03.SelectedValue, 3) Then
                cbxD03.SelectedIndex = -1
                Exit Sub
            End If
            cbxD04.Enabled = True
            cbxD04.Focus()
        End If
    End Sub

    Private Sub CbxD04_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxD04.SelectedIndexChanged
        If cbxD04.SelectedIndex = -1 Or cbxD04.Text = "" Then
            cbxD05.Enabled = False
            cbxD05.SelectedIndex = -1
        Else
            If CheckExistDepartment(cbxD04.SelectedValue, 4) Then
                cbxD04.SelectedIndex = -1
                Exit Sub
            End If
            cbxD05.Enabled = True
            cbxD05.Focus()
        End If
    End Sub

    Private Sub CbxD05_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxD05.SelectedIndexChanged
        If cbxD05.SelectedIndex = -1 Or cbxD05.Text = "" Then
        Else
            If CheckExistDepartment(cbxD05.SelectedValue, 5) Then
                cbxD05.SelectedIndex = -1
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CbxD01_TextChanged(sender As Object, e As EventArgs) Handles cbxD01.TextChanged
        If cbxD01.Text = "" Then
            CbxD01_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxD02_TextChanged(sender As Object, e As EventArgs) Handles cbxD02.TextChanged
        If cbxD02.Text = "" Then
            CbxD02_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxD03_TextChanged(sender As Object, e As EventArgs) Handles cbxD03.TextChanged
        If cbxD03.Text = "" Then
            CbxD03_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxD04_TextChanged(sender As Object, e As EventArgs) Handles cbxD04.TextChanged
        If cbxD04.Text = "" Then
            CbxD04_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub CbxD05_TextChanged(sender As Object, e As EventArgs) Handles cbxD05.TextChanged
        If cbxD05.Text = "" Then
            CbxD05_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If If(cbxWith.Checked, 1, 0) = cbxWith.Tag Then
            Else
                Change &= String.Format("Change With Access from {0} to {1}. ", If(cbxWith.Tag = 1, "With", "Without"), If(cbxWith.Checked, "With", "Without"))
            End If
            If cbxForm.Text = cbxForm.Tag Then
            Else
                Change &= String.Format("Change Form from {0} to {1}. ", cbxForm.Tag, cbxForm.Text)
            End If
            If txtAccess.Text = txtAccess.Tag Then
            Else
                Change &= String.Format("Change Access from {0} to {1}. ", txtAccess.Tag, txtAccess.Text)
            End If
            If cbxP01.Text = cbxP01.Tag Then
            Else
                Change &= String.Format("Change Position 1 from {0} to {1}. ", cbxP01.Tag, cbxP01.Text)
            End If
            If cbxP02.Text = cbxP02.Tag Then
            Else
                Change &= String.Format("Change Position 2 from {0} to {1}. ", cbxP02.Tag, cbxP02.Text)
            End If
            If cbxP03.Text = cbxP03.Tag Then
            Else
                Change &= String.Format("Change Position 3 from {0} to {1}. ", cbxP03.Tag, cbxP03.Text)
            End If
            If cbxP04.Text = cbxP04.Tag Then
            Else
                Change &= String.Format("Change Position 4 from {0} to {1}. ", cbxP04.Tag, cbxP04.Text)
            End If
            If cbxP05.Text = cbxP05.Tag Then
            Else
                Change &= String.Format("Change Position 5 from {0} to {1}. ", cbxP05.Tag, cbxP05.Text)
            End If
            If cbxP06.Text = cbxP06.Tag Then
            Else
                Change &= String.Format("Change Position 6 from {0} to {1}. ", cbxP06.Tag, cbxP06.Text)
            End If
            If cbxP07.Text = cbxP07.Tag Then
            Else
                Change &= String.Format("Change Position 7 from {0} to {1}. ", cbxP07.Tag, cbxP07.Text)
            End If
            If cbxP08.Text = cbxP08.Tag Then
            Else
                Change &= String.Format("Change Position 8 from {0} to {1}. ", cbxP08.Tag, cbxP08.Text)
            End If
            If cbxP09.Text = cbxP09.Tag Then
            Else
                Change &= String.Format("Change Position 9 from {0} to {1}. ", cbxP09.Tag, cbxP09.Text)
            End If
            If cbxP10.Text = cbxP10.Tag Then
            Else
                Change &= String.Format("Change Position 10 from {0} to {1}. ", cbxP10.Tag, cbxP10.Text)
            End If
            If cbxP11.Text = cbxP11.Tag Then
            Else
                Change &= String.Format("Change Position 11 from {0} to {1}. ", cbxP11.Tag, cbxP11.Text)
            End If
            If cbxP12.Text = cbxP12.Tag Then
            Else
                Change &= String.Format("Change Position 12 from {0} to {1}. ", cbxP12.Tag, cbxP12.Text)
            End If
            If cbxD01.Text = cbxD01.Tag Then
            Else
                Change &= String.Format("Change Department 1 from {0} to {1}. ", cbxD01.Tag, cbxD01.Text)
            End If
            If cbxD02.Text = cbxD02.Tag Then
            Else
                Change &= String.Format("Change Department 2 from {0} to {1}. ", cbxD02.Tag, cbxD02.Text)
            End If
            If cbxD03.Text = cbxD03.Tag Then
            Else
                Change &= String.Format("Change Department 3 from {0} to {1}. ", cbxD03.Tag, cbxD03.Text)
            End If
            If cbxD04.Text = cbxD04.Tag Then
            Else
                Change &= String.Format("Change Department 4 from {0} to {1}. ", cbxD04.Tag, cbxD04.Text)
            End If
            If cbxD05.Text = cbxD05.Tag Then
            Else
                Change &= String.Format("Change Department 5 from {0} to {1}. ", cbxD05.Tag, cbxD05.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Special Access - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

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
            'btnDelete.Enabled = True
            PanelEx10.Enabled = True
            If User_Type = "ADMIN" Then
                cbxForm.Enabled = True
                txtAccess.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE special_access SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            DT_SpecialAccess = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, P01, P02, P03, P04, P05, P06, P07, P08, P09, P10, P11, P12 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
            DT_SpecialAccessDepartment = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, D01, D02, D03, D04, D05 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("SPECIAL ACCESS LIST", GridControl1)
        Logs("Signatory List", "Print", "[SENSITIVE] Print Signatory List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
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
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            cbxForm.SelectedValue = .GetFocusedRowCellValue("FormID")
            cbxForm.Tag = .GetFocusedRowCellValue("Form")
            txtAccess.Text = .GetFocusedRowCellValue("Access")
            txtAccess.Tag = .GetFocusedRowCellValue("Access")
            If .GetFocusedRowCellValue("WithAccess") Then
                cbxWith.Checked = True
            Else
                cbxWithout.Checked = True
            End If
            cbxWith.Tag = .GetFocusedRowCellValue("WithAccess")
            cbxP01.SelectedValue = .GetFocusedRowCellValue("P01")
            cbxP01.Tag = .GetFocusedRowCellValue("Position 01")
            cbxP02.SelectedValue = .GetFocusedRowCellValue("P02")
            cbxP02.Tag = .GetFocusedRowCellValue("Position 02")
            cbxP03.SelectedValue = .GetFocusedRowCellValue("P03")
            cbxP03.Tag = .GetFocusedRowCellValue("Position 03")
            cbxP04.SelectedValue = .GetFocusedRowCellValue("P04")
            cbxP04.Tag = .GetFocusedRowCellValue("Position 04")
            cbxP05.SelectedValue = .GetFocusedRowCellValue("P05")
            cbxP05.Tag = .GetFocusedRowCellValue("Position 05")
            cbxP06.SelectedValue = .GetFocusedRowCellValue("P06")
            cbxP06.Tag = .GetFocusedRowCellValue("Position 06")
            cbxP07.SelectedValue = .GetFocusedRowCellValue("P07")
            cbxP07.Tag = .GetFocusedRowCellValue("Position 07")
            cbxP08.SelectedValue = .GetFocusedRowCellValue("P08")
            cbxP08.Tag = .GetFocusedRowCellValue("Position 08")
            cbxP09.SelectedValue = .GetFocusedRowCellValue("P09")
            cbxP09.Tag = .GetFocusedRowCellValue("Position 09")
            cbxP10.SelectedValue = .GetFocusedRowCellValue("P10")
            cbxP10.Tag = .GetFocusedRowCellValue("Position 10")
            cbxP11.SelectedValue = .GetFocusedRowCellValue("P11")
            cbxP11.Tag = .GetFocusedRowCellValue("Position 11")
            cbxP12.SelectedValue = .GetFocusedRowCellValue("P12")
            cbxP12.Tag = .GetFocusedRowCellValue("Position 12")

            cbxD01.SelectedValue = .GetFocusedRowCellValue("D01")
            cbxD01.Tag = .GetFocusedRowCellValue("Department 01")
            cbxD02.SelectedValue = .GetFocusedRowCellValue("D02")
            cbxD02.Tag = .GetFocusedRowCellValue("Department 02")
            cbxD03.SelectedValue = .GetFocusedRowCellValue("D03")
            cbxD03.Tag = .GetFocusedRowCellValue("Department 03")
            cbxD04.SelectedValue = .GetFocusedRowCellValue("D04")
            cbxD04.Tag = .GetFocusedRowCellValue("Department 04")
            cbxD05.SelectedValue = .GetFocusedRowCellValue("D05")
            cbxD05.Tag = .GetFocusedRowCellValue("Department 05")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxForm.SelectedIndex = -1 Or cbxForm.Text = "" Then
            MsgBox("Please select form field.", MsgBoxStyle.Information, "Info")
            cbxForm.DroppedDown = True
            Exit Sub
        End If
        If txtAccess.Text = "" Then
            MsgBox("Please fill access field.", MsgBoxStyle.Information, "Info")
            txtAccess.Focus()
            Exit Sub
        End If
        If (cbxP01.SelectedIndex = -1 Or cbxP01.Text = "") And (cbxD01.SelectedIndex = -1 Or cbxD01.Text = "") Then
            MsgBox("Please add Position/Department to access.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM special_access WHERE access = '{0}' AND `status` = 'ACTIVE'", txtAccess.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("access {0} already exist, Please check your data.", txtAccess.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO special_access SET"
                SQL &= String.Format(" FormID = '{0}', ", cbxForm.SelectedValue)
                SQL &= String.Format(" Access = '{0}', ", txtAccess.Text)
                SQL &= String.Format(" WithAccess = {0}, ", If(cbxWith.Checked, 1, 0))
                SQL &= String.Format(" P01 = {0}, ", ValidateComboBox(cbxP01))
                SQL &= String.Format(" P02 = {0}, ", ValidateComboBox(cbxP02))
                SQL &= String.Format(" P03 = {0}, ", ValidateComboBox(cbxP03))
                SQL &= String.Format(" P04 = {0}, ", ValidateComboBox(cbxP04))
                SQL &= String.Format(" P05 = {0}, ", ValidateComboBox(cbxP05))
                SQL &= String.Format(" P06 = {0}, ", ValidateComboBox(cbxP06))
                SQL &= String.Format(" P07 = {0}, ", ValidateComboBox(cbxP07))
                SQL &= String.Format(" P08 = {0}, ", ValidateComboBox(cbxP08))
                SQL &= String.Format(" P09 = {0}, ", ValidateComboBox(cbxP09))
                SQL &= String.Format(" P10 = {0}, ", ValidateComboBox(cbxP10))
                SQL &= String.Format(" P11 = {0}, ", ValidateComboBox(cbxP11))
                SQL &= String.Format(" P12 = {0}, ", ValidateComboBox(cbxP12))
                SQL &= String.Format(" D01 = {0}, ", ValidateComboBox(cbxD01))
                SQL &= String.Format(" D02 = {0}, ", ValidateComboBox(cbxD02))
                SQL &= String.Format(" D03 = {0}, ", ValidateComboBox(cbxD03))
                SQL &= String.Format(" D04 = {0}, ", ValidateComboBox(cbxD04))
                SQL &= String.Format(" D05 = {0};", ValidateComboBox(cbxD05))
                DataObject(SQL)
                Cursor = Cursors.Default

                DT_SpecialAccess = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, P01, P02, P03, P04, P05, P06, P07, P08, P09, P10, P11, P12 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
                DT_SpecialAccessDepartment = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, D01, D02, D03, D04, D05 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
                Logs("Special Access", "Save", String.Format("Add new access {0}", txtAccess.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM special_access WHERE access = '{0}' AND `status` = 'ACTIVE' AND ID != '{1}'", txtAccess.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("access {0} already exist, Please check your data.", txtAccess.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE special_access SET"
                SQL &= String.Format(" FormID = '{0}', ", cbxForm.SelectedValue)
                SQL &= String.Format(" Access = '{0}', ", txtAccess.Text)
                SQL &= String.Format(" WithAccess = {0}, ", If(cbxWith.Checked, 1, 0))
                SQL &= String.Format(" P01 = {0}, ", ValidateComboBox(cbxP01))
                SQL &= String.Format(" P02 = {0}, ", ValidateComboBox(cbxP02))
                SQL &= String.Format(" P03 = {0}, ", ValidateComboBox(cbxP03))
                SQL &= String.Format(" P04 = {0}, ", ValidateComboBox(cbxP04))
                SQL &= String.Format(" P05 = {0}, ", ValidateComboBox(cbxP05))
                SQL &= String.Format(" P06 = {0}, ", ValidateComboBox(cbxP06))
                SQL &= String.Format(" P07 = {0}, ", ValidateComboBox(cbxP07))
                SQL &= String.Format(" P08 = {0}, ", ValidateComboBox(cbxP08))
                SQL &= String.Format(" P09 = {0}, ", ValidateComboBox(cbxP09))
                SQL &= String.Format(" P10 = {0}, ", ValidateComboBox(cbxP10))
                SQL &= String.Format(" P11 = {0}, ", ValidateComboBox(cbxP11))
                SQL &= String.Format(" P12 = {0}, ", ValidateComboBox(cbxP12))
                SQL &= String.Format(" D01 = {0}, ", ValidateComboBox(cbxD01))
                SQL &= String.Format(" D02 = {0}, ", ValidateComboBox(cbxD02))
                SQL &= String.Format(" D03 = {0}, ", ValidateComboBox(cbxD03))
                SQL &= String.Format(" D04 = {0}, ", ValidateComboBox(cbxD04))
                SQL &= String.Format(" D05 = {0}  ", ValidateComboBox(cbxD05))
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                DT_SpecialAccess = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, P01, P02, P03, P04, P05, P06, P07, P08, P09, P10, P11, P12 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
                DT_SpecialAccessDepartment = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, D01, D02, D03, D04, D05 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
                Logs("Special Access", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub CbxWith_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWith.CheckedChanged
        If cbxWith.Checked Then
            cbxWithout.Checked = False
        End If

        If cbxWith.Checked = False And cbxWithout.Checked = False Then
            cbxWith.Checked = True
        End If
    End Sub

    Private Sub CbxWithout_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWithout.CheckedChanged
        If cbxWithout.Checked Then
            cbxWith.Checked = False
        End If

        If cbxWith.Checked = False And cbxWithout.Checked = False Then
            cbxWith.Checked = True
        End If
    End Sub
End Class