Public Class FrmIndustry

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmIndustry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With CbxCategory
            .ValueMember = "ID"
            .DisplayMember = "Category"
            .DataSource = DataSource("SELECT ID, Category FROM tbl_industry_category WHERE `status` = 'ACTIVE';")
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

            GetComboBoxWinFormFontSettings({CbxCategory})

            GetLabelFontSettings({LabelX155, LabelX1, LabelX42})

            GetTextBoxFontSettings({txtIndustry, txtIndustryCode})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Industry - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Industry", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, Industry_Code AS 'Industry Code', Category, Industry FROM tbl_industry WHERE `status` = 'ACTIVE' ORDER BY `Industry`;")
        GridView1.Columns("Industry").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Industry").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 499 - 17
        Else
            GridColumn2.Width = 499
        End If
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtIndustryCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIndustryCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtIndustry.Focus()
        End If
    End Sub

    Private Sub TxtIndustry_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIndustry.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtIndustry_Leave(sender As Object, e As EventArgs) Handles txtIndustry.Leave
        txtIndustry.Text = ReplaceText(txtIndustry.Text.Trim)
    End Sub

    Private Sub TxtIndustryCode_Leave(sender As Object, e As EventArgs) Handles txtIndustryCode.Leave
        txtIndustryCode.Text = ReplaceText(txtIndustryCode.Text.Trim)
    End Sub
    '***LEAVE

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
        CbxCategory.SelectedIndex = -1
        txtIndustry.Focus()
        txtIndustry.Text = ""
        txtIndustryCode.Text = ""
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

        If txtIndustry.Text = "" Then
            MsgBox("Please fill industry field.", MsgBoxStyle.Information, "Info")
            txtIndustry.Focus()
            Exit Sub
        End If
        If txtIndustryCode.Text = "" Then
            MsgBox("Please fill industry code field.", MsgBoxStyle.Information, "Info")
            txtIndustryCode.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM tbl_industry WHERE (`industry` = '{0}' OR industry_code = '{1}') AND `status` = 'ACTIVE'", txtIndustry.Text, txtIndustryCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Either industry name ({0}) or industry code ({1}) already exist, Please check your data.", txtIndustry.Text, txtIndustryCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO tbl_industry SET"
                SQL &= String.Format(" `Category` = '{0}', ", CbxCategory.Text)
                SQL &= String.Format(" `Industry` = '{0}', ", txtIndustry.Text)
                SQL &= String.Format(" industry_code = '{0}'", txtIndustryCode.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Industry", "Save", String.Format("Add new industry {0}", txtIndustry.Text), "", "", "", "")
                DT_Industry = DataSource("SELECT ID, Industry AS 'Nature' FROM tbl_industry WHERE `status` = 'ACTIVE' ORDER BY Industry")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM tbl_industry WHERE (`industry` = '{0}' OR industry_code = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtIndustry.Text, txtIndustryCode.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either industry name ({0}) or industry code ({1}) already exist, Please check your data.", txtIndustry.Text, txtIndustryCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE tbl_industry SET"
                SQL &= String.Format(" `Category` = '{0}', ", CbxCategory.Text)
                SQL &= String.Format(" `Industry` = '{0}', ", txtIndustry.Text)
                SQL &= String.Format(" industry_code = '{0}'", txtIndustryCode.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Industry", "Update", Reason, Changes(), "", "", "")
                DT_Industry = DataSource("SELECT ID, Industry AS 'Nature' FROM tbl_industry WHERE `status` = 'ACTIVE' ORDER BY Industry")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxCategory.Text = CbxCategory.Tag Then
            Else
                Change &= String.Format("Change Industry Category from {0} to {1}. ", CbxCategory.Tag, CbxCategory.Text)
            End If
            If txtIndustry.Text = txtIndustry.Tag Then
            Else
                Change &= String.Format("Change Industry from {0} to {1}. ", txtIndustry.Tag, txtIndustry.Text)
            End If
            If txtIndustryCode.Text = txtIndustryCode.Tag Then
            Else
                Change &= String.Format("Change Industry Code from {0} to {1}. ", txtIndustryCode.Tag, txtIndustryCode.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Industry - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE tbl_industry SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Industry", "Cancel", Reason, String.Format("Cancel industry {0}", txtIndustry.Text), "", "", "")
            DT_Industry = DataSource("SELECT ID, Industry AS 'Nature' FROM tbl_industry WHERE `status` = 'ACTIVE' ORDER BY Industry")
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
        StandardPrinting("INDUSTRY LIST", GridControl1)
        Logs("Industry", "Print", "Print Industry", "", "", "", "")
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
            CbxCategory.Text = .GetFocusedRowCellValue("Category")
            CbxCategory.Tag = .GetFocusedRowCellValue("Category")
            txtIndustry.Text = .GetFocusedRowCellValue("Industry")
            txtIndustry.Tag = .GetFocusedRowCellValue("Industry")
            txtIndustryCode.Text = .GetFocusedRowCellValue("Industry Code")
            txtIndustryCode.Tag = .GetFocusedRowCellValue("Industry Code")
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
End Class