Public Class FrmCaseSubcategory

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmCaseSubcategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        With cbxCategory
            .ValueMember = "ID"
            .DisplayMember = "Category"
            .DataSource = DataSource("SELECT ID, Category FROM case_category WHERE `status` = 'ACTIVE' ORDER BY `Rank`;")
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX12})

            GetTextBoxFontSettings({txtSubCategory, txtDate})

            GetComboBoxWinFormFontSettings({cbxCategory})

            GetIntegerInputFontSettings({iRank})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Case SubCategory - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Case SubCategory", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, (SELECT Category FROM case_category WHERE ID = CategoryID) AS 'Category', SubCategory, IFNULL(Date_Label,'') AS 'Date Label', `Rank` FROM case_subcategory WHERE `status` = 'ACTIVE' ORDER BY (SELECT `Rank` FROM case_category WHERE ID = CategoryID), `Rank`;")
        GridView1.Columns("Category").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Category").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub CbxCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSubCategory.Focus()
        End If
    End Sub

    Private Sub TxtSubCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDate.Focus()
        End If
    End Sub

    Private Sub TxtDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            iRank.Focus()
        End If
    End Sub

    Private Sub IRank_KeyDown(sender As Object, e As KeyEventArgs) Handles iRank.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtSubCategory_Leave(sender As Object, e As EventArgs) Handles txtSubCategory.Leave
        txtSubCategory.Text = ReplaceText(txtSubCategory.Text.Trim)
    End Sub

    Private Sub TxtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        txtDate.Text = ReplaceText(txtDate.Text.Trim)
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
        cbxCategory.Enabled = True
        txtSubCategory.Focus()
        txtSubCategory.Text = ""
        txtDate.Text = ""
        iRank.MaxValue = DataObject(String.Format("SELECT COUNT(`Rank`) + 1 FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = '{0}';", cbxCategory.SelectedValue))
        iRank.Value = iRank.MaxValue
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

        If cbxCategory.SelectedIndex = -1 Then
            MsgBox("Please select Category.", MsgBoxStyle.Information, "Info")
            cbxCategory.DroppedDown = True
            Exit Sub
        End If
        If txtSubCategory.Text = "" Then
            MsgBox("Please fill SubCategory.", MsgBoxStyle.Information, "Info")
            txtSubCategory.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM case_subcategory WHERE (`SubCategory` = '{0}' AND CategoryID = '{1}') AND `status` = 'ACTIVE'", txtSubCategory.Text, cbxCategory.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("SubCategory {0} already exist in {1}, Please check your data.", txtSubCategory.Text, cbxCategory.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE case_subcategory SET `Rank` = `Rank` + 1 WHERE `status` = 'ACTIVE' AND CategoryID = '{1}' AND `Rank` >= {0};", iRank.Value, cbxCategory.SelectedValue)
                SQL &= "INSERT INTO case_subcategory SET"
                SQL &= String.Format(" `SubCategory` = '{0}', ", txtSubCategory.Text)
                SQL &= String.Format(" `Date_Label` = '{0}', ", txtDate.Text)
                SQL &= String.Format(" `CategoryID` = '{0}', ", cbxCategory.SelectedValue)
                SQL &= String.Format(" `Rank` = '{0}';", iRank.Value)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Case SubCategory", "Save", String.Format("Add new Subcategory {0} for {0}", txtSubCategory.Text, cbxCategory.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM case_subcategory WHERE (`SubCategory` = '{0}' AND CategoryID = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}';", txtSubCategory.Text, cbxCategory.SelectedValue, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("SubCategory {0} already exist in {1}, Please check your data.", txtSubCategory.Text, cbxCategory.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Exist = DataObject(String.Format("SELECT ID FROM case_subcategory WHERE (`Rank` = '{0}' AND CategoryID = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}';", iRank.Value, cbxCategory.SelectedValue, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Rank {0} already exist in {1}, Please check your data.", txtSubCategory.Text, cbxCategory.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE case_subcategory SET"
                SQL &= String.Format(" `SubCategory` = '{0}', ", txtSubCategory.Text)
                SQL &= String.Format(" `Date_Label` = '{0}', ", txtDate.Text)
                SQL &= String.Format(" `Rank` = '{0}' ", iRank.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Case SubCategory", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtSubCategory.Text = txtSubCategory.Tag Then
            Else
                Change &= String.Format("Change SubCategory from {0} to {1}. ", txtSubCategory.Tag, txtSubCategory.Text)
            End If
            If txtDate.Text = txtDate.Tag Then
            Else
                Change &= String.Format("Change Date from {0} to {1}. ", txtDate.Tag, txtDate.Text)
            End If
            If iRank.Value = iRank.Tag Then
            Else
                Change &= String.Format("Change Rank from {0} to {1}. ", iRank.Tag, iRank.Value)
            End If
        Catch ex As Exception
            TriggerBugReport("Case Sub Category - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE case_subcategory SET `Rank` = `Rank` - 1 WHERE `status` = 'ACTIVE' AND `Rank` >= {1} AND CategoryID = '{2}'; UPDATE case_subcategory SET `status` = 'DELETED' WHERE ID = '{0}';", ID, iRank.Value, cbxCategory.SelectedValue))
            Logs("Case SubCategory", "Cancel", Reason, String.Format("Cancel SubCategory {0}", txtSubCategory.Text), "", "", "")
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
        StandardPrinting("CASE SUBCATEGORY LIST", GridControl1)
        Logs("Case Subcategory", "Print", "Print Case Subcategory List", "", "", "", "")
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
            cbxCategory.Text = .GetFocusedRowCellValue("Category")
            cbxCategory.Tag = .GetFocusedRowCellValue("Category")
            cbxCategory.Enabled = False
            txtSubCategory.Text = .GetFocusedRowCellValue("SubCategory")
            txtSubCategory.Tag = .GetFocusedRowCellValue("SubCategory")
            txtDate.Text = .GetFocusedRowCellValue("Date Label")
            txtDate.Tag = .GetFocusedRowCellValue("Date Label")
            iRank.Value = .GetFocusedRowCellValue("Rank")
            iRank.Tag = .GetFocusedRowCellValue("Rank")
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

    Private Sub CbxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategory.SelectedIndexChanged
        With iRank
            .MaxValue = DataObject(String.Format("SELECT COUNT(`Rank`) + 1 FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = '{0}';", cbxCategory.SelectedValue))
            .Value = .MaxValue
        End With
    End Sub
End Class