Public Class FrmProvinceSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True

    Private Sub FrmProvinceSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxCountry
            .ValueMember = "ID"
            .DisplayMember = "Country"
            .DataSource = DataSource("SELECT ID, Country FROM country WHERE `status` = 'ACTIVE';")
            FirstLoad = False
            .Text = "PHILIPPINES"
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2})

            GetTextBoxFontSettings({txtProvince})

            GetComboBoxFontSettings({cbxCountry, cbxRegion})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Province Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Province", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    ID,"
        SQL &= "    (SELECT country FROM country WHERE ID = CountryID) AS 'Country',"
        SQL &= "    (SELECT regDesc FROM region WHERE region.regCode = province.regCode) AS 'Region',"
        SQL &= "    provDesc AS 'Province'"
        SQL &= "    FROM province WHERE `status` = 'ACTIVE' ORDER BY `Country`, `Region`, `Province`;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Country").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Country").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 382 - 6
            GridColumn3.Width = 382 - 6
            GridColumn4.Width = 382 - 5
        Else
            GridColumn2.Width = 382
            GridColumn3.Width = 382
            GridColumn4.Width = 382
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxCountry_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCountry.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRegion.Focus()
        End If
    End Sub

    Private Sub CbxRegion_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRegion.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProvince.Focus()
        End If
    End Sub

    Private Sub TxtProvince_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProvince.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtProvince_Leave(sender As Object, e As EventArgs) Handles txtProvince.Leave
        txtProvince.Text = ReplaceText(txtProvince.Text.Trim)
    End Sub
#End Region

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
        cbxCountry.Text = "PHILIPPINES"
        txtProvince.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxCountry.SelectedIndex = -1 Or cbxCountry.Text = "" Then
            MsgBox("Please select Country.", MsgBoxStyle.Information, "Info")
            cbxCountry.DroppedDown = True
            Exit Sub
        End If
        If cbxRegion.SelectedIndex = -1 Or cbxRegion.Text = "" Then
            MsgBox("Please select Region.", MsgBoxStyle.Information, "Info")
            cbxRegion.DroppedDown = True
            Exit Sub
        End If
        If txtProvince.Text = "" Then
            MsgBox("Please fill Province.", MsgBoxStyle.Information, "Info")
            txtProvince.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM province WHERE provDESC = '{0}' AND regCode = '{1}' AND `status` = 'ACTIVE'", txtProvince.Text, cbxRegion.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("Province {0} already exist in Region {1}, Please check your data.", txtProvince.Text, cbxRegion.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO `province` SET"
                SQL &= String.Format(" CountryID = '{0}', ", cbxCountry.SelectedValue)
                SQL &= String.Format(" regCode = '{0}', ", cbxRegion.SelectedValue)
                SQL &= String.Format(" provDESC = '{0}', ", txtProvince.Text)
                SQL &= String.Format(" provCode = '{0}';", DataObject("SELECT MAX(provCode) + 1 FROM province"))
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Province", "Save", String.Format("Add new province {0}", txtProvince.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM province WHERE provDESC = '{0}' AND regCode = '{1}' AND `status` = 'ACTIVE' AND ID != '{2}'", txtProvince.Text, cbxRegion.SelectedValue, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Province {0} already exist in Region {1}, Please check your data.", txtProvince.Text, cbxRegion.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE province SET"
                SQL &= String.Format(" CountryID = '{0}', ", cbxCountry.SelectedValue)
                SQL &= String.Format(" regCode = '{0}', ", cbxRegion.SelectedValue)
                SQL &= String.Format(" provDESC = '{0}' ", txtProvince.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Province", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxCountry.Text = cbxCountry.Tag Then
            Else
                Change &= String.Format("Change Country from {0} to {1}. ", cbxCountry.Tag, cbxCountry.Text)
            End If
            If cbxRegion.Text = cbxRegion.Tag Then
            Else
                Change &= String.Format("Change Region from {0} to {1}. ", cbxRegion.Tag, cbxRegion.Text)
            End If
            If txtProvince.Text = txtProvince.Tag Then
            Else
                Change &= String.Format("Change Province from {0} to {1}. ", txtProvince.Tag, txtProvince.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Province Setup - Changes", ex.Message.ToString)
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
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
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
            DataObject(String.Format("UPDATE province SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Province", "Cancel", Reason, String.Format("Cancel province {0}", txtProvince.Text), "", "", "")
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
        StandardPrinting("PROVINCE LIST", GridControl1)
        Logs("Province", "Print", "Print Province List", "", "", "", "")
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
            cbxCountry.Text = .GetFocusedRowCellValue("Country")
            cbxCountry.Tag = .GetFocusedRowCellValue("Country")
            cbxRegion.Text = .GetFocusedRowCellValue("Region")
            cbxRegion.Tag = .GetFocusedRowCellValue("Region")
            txtProvince.Text = .GetFocusedRowCellValue("Province")
            txtProvince.Tag = .GetFocusedRowCellValue("Province")
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

    Private Sub CbxCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCountry.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxRegion
            .DisplayMember = "Region"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT regCode AS 'ID', regDesc AS 'Region' FROM region WHERE `status` = 'ACTIVE' AND countryID = '{0}' ORDER BY regDESC;", cbxCountry.SelectedValue))
            .Text = ""
        End With
    End Sub
End Class