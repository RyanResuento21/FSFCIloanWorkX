Public Class FrmPasswordSettings

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmPasswordSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        iPWLength.Value = PWLength
        iPWAge.Value = PWAge
        iPWNotify.Value = PWNotifyExpire
        cbxPWCase.Checked = PWCase
        cbxPWSpecial.Checked = PWSpecial
        cbxPWNumeric.Checked = PWNumeric
        cbxPWForceChange.Checked = PWForceChange
        iAccountThreshold.Value = AccountThreshold
        iAccountLockDuration.Value = AccountLockDuration
        cbxAccountReset.Checked = AccountReset
        iOTACLength.Value = OTACLength
        cbxOTACwithAlphabet.Checked = OTACwithAlphabet
        cbxOTACCaseSensitive.Checked = OTACCaseSensitive
        iOTACDuration.Value = OTACDuration

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

            GetLabelFontSettings({LabelX1, LabelX2, LabelX3, LabelX4, LabelX5, LabelX13, LabelX12, LabelX15, LabelX14, LabelX11, LabelX10, LabelX17, LabelX20, LabelX21})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckBoxFontSettings({cbxPWCase, cbxPWSpecial, cbxPWNumeric, cbxAccountReset, cbxOTACwithAlphabet, cbxOTACCaseSensitive, cbxPWForceChange})

            GetLabelFontSettingsRed({LabelX31, LabelX9, LabelX16, LabelX18, LabelX19})

            GetIntegerInputFontSettings({iPWLength, iPWAge, iAccountThreshold, iAccountLockDuration, iOTACLength, iOTACDuration, iPWNotify})

            GetLabelWithBackgroundFontSettings({LabelX6, LabelX7, LabelX8})
        Catch ex As Exception
            TriggerBugReport("Password Settings - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Security Settings", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    PWLength,"
        SQL &= "    PWAge,"
        SQL &= "    PWNotifyAge,"
        SQL &= "    IF(PWCase = 1,'YES','NO') AS 'PWCase',"
        SQL &= "    IF(PWSpecial,'YES','NO') AS 'PWSpecial',"
        SQL &= "    IF(PWNumeric,'YES','NO') AS 'PWNumeric',"
        SQL &= "    IF(PWForceChange,'YES','NO') AS 'PWForceChange',"
        SQL &= "    AccountThreshold,"
        SQL &= "    AccountLockDuration,"
        SQL &= "    IF(AccountReset,'YES','NO') AS 'AccountReset',"
        SQL &= "    OTACLength,"
        SQL &= "    IF(OTACwithAlphabet,'YES','NO') AS 'OTACwithAlphabet',"
        SQL &= "    IF(OTACCaseSensitive,'YES','NO') AS 'OTACCaseSensitive',"
        SQL &= "    OTACDuration,"
        SQL &= "    (SELECT Employee(empl_id) FROM users WHERE ID = user_id) AS 'Updated By', Status"
        SQL &= " FROM security_settings"
        SQL &= " WHERE `status` IN ('ACTIVE','INACTIVE') ORDER BY ID DESC;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("PWLength").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("PWLength").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub Enter_KeyDown(sender As Object, e As KeyEventArgs) Handles iPWLength.KeyDown, iPWAge.KeyDown, cbxPWCase.KeyDown, cbxPWSpecial.KeyDown, cbxPWNumeric.KeyDown, iAccountThreshold.KeyDown, iAccountLockDuration.KeyDown, cbxAccountReset.KeyDown, iOTACLength.KeyDown, cbxOTACwithAlphabet.KeyDown, cbxOTACCaseSensitive.KeyDown, iOTACDuration.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
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
            btnSave.Enabled = True
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnSave.Enabled = False
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
        iPWLength.Value = PWLength
        iPWAge.Value = PWAge
        iPWNotify.Value = PWNotifyExpire
        cbxPWCase.Checked = PWCase
        cbxPWSpecial.Checked = PWSpecial
        cbxPWNumeric.Checked = PWNumeric
        cbxPWForceChange.Checked = PWForceChange
        iAccountThreshold.Value = AccountThreshold
        iAccountLockDuration.Value = AccountLockDuration
        cbxAccountReset.Checked = AccountReset
        iOTACLength.Value = OTACLength
        cbxOTACwithAlphabet.Checked = OTACwithAlphabet
        cbxOTACCaseSensitive.Checked = OTACCaseSensitive
        iOTACDuration.Value = OTACDuration

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

        If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE security_settings SET `status` = 'INACTIVE' WHERE `status` = 'ACTIVE';"))
            Dim SQL As String = "INSERT INTO security_settings SET"
            SQL &= String.Format(" PWLength = {0},", iPWLength.Value)
            SQL &= String.Format(" PWAge = {0},", iPWAge.Value)
            SQL &= String.Format(" PWNotifyAge = {0},", iPWNotify.Value)
            SQL &= String.Format(" PWCase = {0},", If(cbxPWCase.Checked, 1, 0))
            SQL &= String.Format(" PWSpecial = {0},", If(cbxPWSpecial.Checked, 1, 0))
            SQL &= String.Format(" PWNumeric = {0},", If(cbxPWNumeric.Checked, 1, 0))
            SQL &= String.Format(" PWForceChange = {0},", If(cbxPWForceChange.Checked, 1, 0))
            SQL &= String.Format(" AccountThreshold = {0},", iAccountThreshold.Value)
            SQL &= String.Format(" AccountLockDuration = {0},", iAccountLockDuration.Value)
            SQL &= String.Format(" AccountReset = {0},", If(cbxAccountReset.Checked, 1, 0))
            SQL &= String.Format(" OTACLength = {0},", iOTACLength.Value)
            SQL &= String.Format(" OTACwithAlphabet = {0},", If(cbxOTACwithAlphabet.Checked, 1, 0))
            SQL &= String.Format(" OTACCaseSensitive = {0},", If(cbxOTACCaseSensitive.Checked, 1, 0))
            SQL &= String.Format(" OTACDuration = {0},", iOTACDuration.Value)
            SQL &= String.Format(" user_id = {0};", User_ID)
            DataObject(SQL)

            PWLength = iPWLength.Value
            PWAge = iPWAge.Value
            PWNotifyExpire = iPWNotify.Value
            PWCase = cbxPWCase.Checked
            PWSpecial = cbxPWSpecial.Checked
            PWNumeric = cbxPWNumeric.Checked
            PWForceChange = cbxPWForceChange.Checked
            AccountThreshold = iAccountThreshold.Value
            AccountLockDuration = iAccountLockDuration.Value
            AccountReset = cbxAccountReset.Checked
            OTACLength = iOTACLength.Value
            OTACwithAlphabet = cbxOTACwithAlphabet.Checked
            OTACCaseSensitive = cbxOTACCaseSensitive.Checked
            OTACDuration = iOTACDuration.Value

            Cursor = Cursors.Default

            Logs("Security Settings", "Save", String.Format("Save new security settings - {0}", Empl_Name), "", "", "", "")
            LoadData()
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
        End If
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

    Private Sub CbxOTACwithAlphabet_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOTACwithAlphabet.CheckedChanged
        If cbxOTACwithAlphabet.Checked Then
            cbxOTACCaseSensitive.Enabled = True
        Else
            cbxOTACCaseSensitive.Enabled = False
            cbxOTACCaseSensitive.Checked = False
        End If
    End Sub

    Private Sub IPWAge_ValueChanged(sender As Object, e As EventArgs) Handles iPWAge.ValueChanged
        If iPWAge.Value > 0 Then
            LabelX20.Enabled = True
            iPWNotify.Enabled = True
            LabelX19.Enabled = True
        Else
            LabelX20.Enabled = False
            iPWNotify.Enabled = False
            LabelX19.Enabled = False
            iPWNotify.Value = 0
        End If
    End Sub

    Private Sub IPWNotify_ValueChanged(sender As Object, e As EventArgs) Handles iPWNotify.ValueChanged
        If iPWNotify.Value > iPWAge.Value Then
            iPWNotify.Value = iPWAge.Value
        End If
    End Sub
End Class