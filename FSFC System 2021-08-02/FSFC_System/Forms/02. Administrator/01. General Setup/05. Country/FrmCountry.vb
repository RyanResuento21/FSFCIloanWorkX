Public Class FrmCountry

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmCountry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX3, LabelX5})

            GetTextBoxFontSettings({txtCountry, txtNationality, txtISO, txtISO3, txtPhoneCode})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Country - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Country", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    ID,"
        SQL &= "    Country,"
        SQL &= "    Nationality,"
        SQL &= "    ISO,"
        SQL &= "    ISO3 AS 'ISO 3', "
        SQL &= "    phonecode AS 'Phone Code'"
        SQL &= "    FROM country WHERE `status` = 'ACTIVE' ORDER BY country;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Country").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Country").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 506
        Else
            GridColumn2.Width = 523
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub TxtCountry_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCountry.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNationality.Focus()
        End If
    End Sub

    Private Sub TxtNationality_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNationality.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtISO.Focus()
        End If
    End Sub

    Private Sub TxtISO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtISO.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtISO3.Focus()
        End If
    End Sub

    Private Sub TxtISO3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtISO3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPhoneCode.Focus()
        End If
    End Sub

    Private Sub TxtPhoneCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPhoneCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtCountry_Leave(sender As Object, e As EventArgs) Handles txtCountry.Leave
        txtCountry.Text = ReplaceText(txtCountry.Text.Trim)
    End Sub

    Private Sub TxtNationality_Leave(sender As Object, e As EventArgs) Handles txtNationality.Leave
        txtNationality.Text = ReplaceText(txtNationality.Text.Trim)
    End Sub

    Private Sub TxtISO_Leave(sender As Object, e As EventArgs) Handles txtISO.Leave
        txtISO.Text = ReplaceText(txtISO.Text.Trim)
        If txtISO.Text.Length > 2 Then
            MsgBox("ISO will only accept maximum of 2 characters.", MsgBoxStyle.Information, "Info")
            txtISO.Focus()
        End If
    End Sub

    Private Sub TxtISO3_Leave(sender As Object, e As EventArgs) Handles txtISO3.Leave
        txtISO3.Text = ReplaceText(txtISO3.Text.Trim)
        If txtISO3.Text.Length > 3 Then
            MsgBox("ISO will only accept maximum of 3 characters.", MsgBoxStyle.Information, "Info")
            txtISO3.Focus()
        End If
    End Sub

    Private Sub TxtPhoneCode_Leave(sender As Object, e As EventArgs) Handles txtPhoneCode.Leave
        txtPhoneCode.Text = ReplaceText(txtPhoneCode.Text.Trim)
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
        txtCountry.Text = ""
        txtNationality.Text = ""
        txtISO.Text = ""
        txtISO3.Text = ""
        txtPhoneCode.Text = ""
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

        If txtCountry.Text = "" Then
            MsgBox("Please fill country name field.", MsgBoxStyle.Information, "Info")
            txtCountry.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM country WHERE country = '{0}' AND `status` = 'ACTIVE'", txtCountry.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Country {0} already exist, Please check your data.", txtCountry.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO country SET"
                SQL &= String.Format(" Country = '{0}', ", txtCountry.Text)
                SQL &= String.Format(" Nationality = '{0}', ", txtNationality.Text)
                SQL &= String.Format(" ISO = '{0}', ", txtISO.Text)
                SQL &= String.Format(" ISO3 = '{0}', ", txtISO3.Text)
                SQL &= String.Format(" phonecode = '{0}' ", txtPhoneCode.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Country", "Save", String.Format("Add new country {0}", txtCountry.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM country WHERE country = '{0}' AND `status` = 'ACTIVE' AND ID != '{1}'", txtCountry.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Country {0} already exist, Please check your data.", txtCountry.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE country SET"
                SQL &= String.Format(" Country = '{0}', ", txtCountry.Text)
                SQL &= String.Format(" Nationality = '{0}', ", txtNationality.Text)
                SQL &= String.Format(" ISO = '{0}', ", txtISO.Text)
                SQL &= String.Format(" ISO3 = '{0}', ", txtISO3.Text)
                SQL &= String.Format(" phonecode = '{0}' ", txtPhoneCode.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Country", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtCountry.Text = txtCountry.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", txtCountry.Tag, txtCountry.Text)
            End If
            If txtNationality.Text = txtNationality.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", txtNationality.Tag, txtNationality.Text)
            End If
            If txtISO.Text = txtISO.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", txtISO.Tag, txtISO.Text)
            End If
            If txtISO3.Text = txtISO3.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", txtISO3.Tag, txtISO3.Text)
            End If
            If txtPhoneCode.Text = txtPhoneCode.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", txtPhoneCode.Tag, txtPhoneCode.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Country - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE country SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Country", "Cancel", Reason, String.Format("Cancel country {0}", txtCountry.Text), "", "", "")
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
        StandardPrinting("COUNTRY LIST", GridControl1)
        Logs("Country", "Print", "Print Country List", "", "", "", "")
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
            txtCountry.Text = .GetFocusedRowCellValue("Country")
            txtCountry.Tag = .GetFocusedRowCellValue("Country")
            txtNationality.Text = .GetFocusedRowCellValue("Nationality")
            txtNationality.Tag = .GetFocusedRowCellValue("Nationality")
            txtISO.Text = .GetFocusedRowCellValue("ISO")
            txtISO.Tag = .GetFocusedRowCellValue("ISO")
            txtISO3.Text = .GetFocusedRowCellValue("ISO 3")
            txtISO3.Tag = .GetFocusedRowCellValue("ISO 3")
            txtPhoneCode.Text = .GetFocusedRowCellValue("Phone Code")
            txtPhoneCode.Tag = .GetFocusedRowCellValue("Phone Code")
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