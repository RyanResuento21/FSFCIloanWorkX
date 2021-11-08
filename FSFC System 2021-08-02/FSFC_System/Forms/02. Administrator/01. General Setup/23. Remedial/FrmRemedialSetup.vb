Public Class FrmRemedialSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmRemedialSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
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

            GetLabelFontSettings({LabelX155, LabelX2})

            GetTextBoxFontSettings({txtCode, txtRemedial})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Remedial Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Remedial Setup", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, RemedialCode AS 'Code', Remedial FROM remedial_setup WHERE `status` = 'ACTIVE';")
        GridView1.Columns("Remedial").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Remedial").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 998 - 17
        Else
            GridColumn2.Width = 998
        End If
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRemedial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemedial.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '***KEYDOWN

    Private Sub TxtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        txtCode.Text = ReplaceText(txtCode.Text.Trim)
    End Sub

    '***LEAVE
    Private Sub TxtRemedial_Leave(sender As Object, e As EventArgs) Handles txtRemedial.Leave
        txtRemedial.Text = ReplaceText(txtRemedial.Text.Trim)
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
        txtRemedial.Focus()
        txtCode.Text = ""
        txtRemedial.Text = ""
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

        If txtCode.Text = "" Then
            MsgBox("Please fill Code field.", MsgBoxStyle.Information, "Info")
            txtCode.Focus()
            Exit Sub
        End If
        If txtRemedial.Text = "" Then
            MsgBox("Please fill Remedial field.", MsgBoxStyle.Information, "Info")
            txtRemedial.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM remedial_setup WHERE (`Remedial` = '{0}' OR RemedialCode = '{1}') AND `status` = 'ACTIVE'", txtRemedial.Text, txtCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Remedial {0} or Code {1} already exist, Please check your data.", txtRemedial.Text, txtCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO remedial_setup SET"
                SQL &= String.Format(" `RemedialCode` = '{0}', ", txtCode.Text)
                SQL &= String.Format(" `Remedial` = '{0}' ", txtRemedial.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Remedial Setup", "Save", String.Format("Add new Remedial {0}", txtRemedial.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM remedial_setup WHERE (`Remedial` = '{0}' OR RemedialCode = '{2}') AND `status` = 'ACTIVE' AND ID != '{1}'", txtRemedial.Text, ID, txtCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Remedial {0} or Code {1} already exist, Please check your data.", txtRemedial.Text, txtCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE remedial_setup SET"
                SQL &= String.Format(" `RemedialCode` = '{0}', ", txtCode.Text)
                SQL &= String.Format(" `Remedial` = '{0}' ", txtRemedial.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Remedial Setup", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtCode.Text = txtCode.Tag Then
            Else
                Change &= String.Format("Change Code from {0} to {1}. ", txtCode.Tag, txtCode.Text)
            End If
            If txtRemedial.Text = txtRemedial.Tag Then
            Else
                Change &= String.Format("Change Remedial from {0} to {1}. ", txtRemedial.Tag, txtRemedial.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Remedial Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE remedial_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Remedial", "Cancel", Reason, String.Format("Cancel Remedial {0}", txtRemedial.Text), "", "", "")
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
        StandardPrinting("REMEDIAL LIST", GridControl1)
        Logs("Remedial", "Print", "Print Remedial List", "", "", "", "")
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
            txtCode.Text = .GetFocusedRowCellValue("Code")
            txtCode.Tag = .GetFocusedRowCellValue("Code")
            txtRemedial.Text = .GetFocusedRowCellValue("Remedial")
            txtRemedial.Tag = .GetFocusedRowCellValue("Remedial")
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