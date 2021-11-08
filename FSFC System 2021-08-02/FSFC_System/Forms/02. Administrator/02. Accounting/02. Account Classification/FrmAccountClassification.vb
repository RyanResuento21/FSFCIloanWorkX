Public Class FrmAccountClassification

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmAccountClassification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxType
            .DisplayMember = "Type"
            .ValueMember = "Code"
            .DataSource = DataSource("SELECT ID, `Code`, `Type` FROM account_type WHERE `status` = 'ACTIVE' ORDER BY `Code`;")
            .SelectedIndex = -1
        End With
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

            GetLabelFontSettings({LabelX155, LabelX2, LabelX1, LabelX3})

            GetTextBoxFontSettings({txtClassification, txtTypeCode, txtClassificationCode})

            GetComboBoxFontSettings({cbxType})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Account Classification - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Account Classification", lblTitle.Text)
    End Sub

    Private Sub DefaultCode()
        If FirstLoad Or cbxType.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxType.SelectedItem, DataRowView)
        txtClassificationCode.Text = DataObject(String.Format("SELECT COUNT(`Code`) FROM account_classification WHERE `status` = 'ACTIVE' AND type_id = '{0}';", drv("ID")))
    End Sub

    Private Sub CbxType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxType.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        DefaultCode()
        txtTypeCode.Text = cbxType.SelectedValue
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, type_id, (SELECT `Type` FROM account_type WHERE ID = type_id) AS 'Account Type', `Code`, `Classification` AS 'Account Classification' FROM account_classification WHERE `status` = 'ACTIVE' ORDER BY (SELECT `Code` FROM account_type WHERE ID = type_id), `Code`;")
        GridView1.Columns("Account Type").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Account Type").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub CbxType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtClassification.Focus()
        End If
    End Sub

    Private Sub TxtClassification_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClassification.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtClassificationCode.Focus()
        End If
    End Sub

    Private Sub TxtClassificationCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClassificationCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtClassification_Leave(sender As Object, e As EventArgs) Handles txtClassification.Leave
        txtClassification.Text = ReplaceText(txtClassification.Text.Trim)
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
        cbxType.Enabled = True
        txtClassification.Text = ""
        txtClassificationCode.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
        DefaultCode()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxType.Text = "" Or cbxType.SelectedIndex = -1 Then
            MsgBox("Please select account type.", MsgBoxStyle.Information, "Info")
            cbxType.DroppedDown = True
            Exit Sub
        End If
        If txtClassification.Text = "" Then
            MsgBox("Please fill Classification.", MsgBoxStyle.Information, "Info")
            txtClassification.Focus()
            Exit Sub
        End If
        If txtClassificationCode.Text = "" Then
            MsgBox("Please fill Classification Code.", MsgBoxStyle.Information, "Info")
            txtClassificationCode.Focus()
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxType.SelectedItem, DataRowView)

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM account_classification WHERE (`Classification` = '{0}' OR `Code` = '{1}') AND type_id = '{2}' AND `status` = 'ACTIVE'", txtClassification.Text, txtClassificationCode.Text, drv("ID")))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Account Classification ({0}) or Code ({1}) already exist, Please check your data.", txtClassification.Text, txtClassificationCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO account_classification SET"
                SQL &= String.Format(" `type_id` = '{0}', ", drv("ID"))
                SQL &= String.Format(" `Classification` = '{0}', ", txtClassification.Text)
                SQL &= String.Format(" `Code` = '{0}' ", txtClassificationCode.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Account Classification", "Save", String.Format("Add new account classification {0}", txtClassification.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                txtClassification.Focus()
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM account_classification WHERE (`Classification` = '{0}' OR `Code` = '{1}') AND type_id = '{3}' AND `status` = 'ACTIVE' AND ID != '{2}';", txtClassification.Text, txtClassificationCode.Text, ID, drv("ID")))
                If Exist > 0 Then
                    MsgBox(String.Format("Either Account Classification ({0}) or Code ({1}) already exist, Please check your data.", txtClassification.Text, txtClassificationCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE account_classification SET"
                SQL &= String.Format(" `Classification` = '{0}', ", txtClassification.Text)
                SQL &= String.Format(" `Code` = '{0}' ", txtClassificationCode.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Account Classification", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtClassification.Text = txtClassification.Tag Then
            Else
                Change &= String.Format("Change Account Classification from {0} to {1}. ", txtClassification.Tag, txtClassification.Text)
            End If
            If txtClassificationCode.Text = txtClassificationCode.Tag Then
            Else
                Change &= String.Format("Change Code from {0} to {1}. ", txtClassificationCode.Tag, txtClassificationCode.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Account Classification - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE account_classification SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Account Classification", "Cancel", Reason, String.Format("Cancel account classification {0}", txtClassification.Text), "", "", "")
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
        StandardPrinting("ACCOUNT CLASSIFICATION LIST", GridControl1)
        Logs("Account Classification", "Print", "Print Account Classification List", "", "", "", "")
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
            cbxType.Enabled = False
            cbxType.SelectedValue = .GetFocusedRowCellValue("type_id")
            txtClassification.Text = .GetFocusedRowCellValue("Account Classification")
            txtClassification.Tag = .GetFocusedRowCellValue("Account Classification")
            txtClassificationCode.Text = .GetFocusedRowCellValue("Code")
            txtClassificationCode.Tag = .GetFocusedRowCellValue("Code")
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