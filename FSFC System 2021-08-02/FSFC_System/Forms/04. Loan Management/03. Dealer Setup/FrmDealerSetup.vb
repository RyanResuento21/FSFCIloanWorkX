Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmDealerSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim TotalImage As Integer = 0
    Dim FileName As String
    Dim ChangeDealerPic As Boolean = False
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Private Sub FrmDealerSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_D.Size = New Point(255, 227)
        pb_D.Location = New Point(892, 6)
        FirstLoad = True
        GetDealer()
        DefaultImage.Image = pb_D.Image.Clone

        With CbxPrefix_D
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_D
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxAddressC_D
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        pb_D.Properties.ContextMenuStrip = New ContextMenuStrip()
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

            GetLabelFontSettings({LabelX155, LabelX4, LabelX1, LabelX6, LabelX8, LabelX9, LabelX17, LabelX12, LabelX15, LabelX16, LabelX13})

            GetTextBoxFontSettings({txtDealerID, TxtFirstN_D, TxtMiddleN_D, TxtLastN_D, txtTradeName, txtNoC_D, txtStreetC_D, txtBarangayC_D, txtTelephone_D, txtPlus63, txtMobile_D, txtEmail_D, txtWebsite_D, txtTIN_D, txtSSS_D, txtFax_D, txtPath_D})

            GetComboBoxFontSettings({CbxPrefix_D, cbxSuffix_D, cbxAddressC_D})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach, btnBrowse_D})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckBoxFontSettings({cbxCar})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetLabelWithBackgroundFontSettings({LabelX3})
        Catch ex As Exception
            TriggerBugReport("Dealer Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Dealer", lblTitle.Text)
    End Sub

    Private Sub GetDealer()
        txtDealerID.Text = DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', 'D', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_dealer WHERE branch_id = '{0}';", Branch_ID))
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DealerID AS 'Dealer ID',"
        SQL &= "    Prefix,"
        SQL &= "    FirstN,"
        SQL &= "    MiddleN,"
        SQL &= "    LastN,"
        SQL &= "    Suffix,"
        SQL &= "    CONCAT(IF(Prefix = '','',CONCAT(Prefix, ' ')), IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',CONCAT(LastN, ' ')), Suffix) AS 'Dealer Name',"
        SQL &= "    TradeName AS 'Trade Name',"
        SQL &= "    CarDealer AS 'Car Dealer',"
        SQL &= "    NoC,"
        SQL &= "    StreetC,"
        SQL &= "    BarangayC,"
        SQL &= "    AddressC,"
        SQL &= "    CONCAT(IF(NoC = '','',CONCAT(NoC, ' ')), IF(StreetC = '','',CONCAT(StreetC, ' ')), IF(BarangayC = '','',CONCAT(BarangayC, ' ')), AddressC) AS 'Complete Address',"
        SQL &= "    Telephone,"
        SQL &= "    Mobile,"
        SQL &= "    Email,"
        SQL &= "    Website,"
        SQL &= "    TIN,"
        SQL &= "    SSS,"
        SQL &= "    Fax,"
        SQL &= "    branch_code, Attach, Branch(Branch_ID) AS 'Branch'"
        SQL &= String.Format("    FROM profile_dealer WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY dealerID DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn18.Visible = True
            GridColumn18.VisibleIndex = 11
        End If
        GridView1.Columns("Dealer Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Dealer Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn13.Width = 323
        Else
            GridColumn13.Width = 340
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
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

    Public Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        GetDealer()
        TotalImage = 0
        txtPath_D.Text = ""
        CbxPrefix_D.Text = ""
        TxtFirstN_D.Text = ""
        TxtMiddleN_D.Text = ""
        TxtLastN_D.Text = ""
        cbxSuffix_D.Text = ""
        txtTradeName.Text = ""
        cbxCar.Checked = False
        txtNoC_D.Text = ""
        txtStreetC_D.Text = ""
        txtBarangayC_D.Text = ""
        cbxAddressC_D.Text = ""
        txtTIN_D.Text = ""
        txtTelephone_D.Text = ""
        txtSSS_D.Text = ""
        txtMobile_D.Text = ""
        txtEmail_D.Text = ""
        txtWebsite_D.Text = ""
        txtFax_D.Text = ""
        Try
            pb_D.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_D.Image = Nothing
        End Try
        btnSave.Enabled = True
        btnSave.Text = "&Save"
        btnDelete.Enabled = False
        btnModify.Enabled = False
        btnAttach.Enabled = False
        ChangeDealerPic = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnBrowse_D_Click(sender As Object, e As EventArgs) Handles btnBrowse_D.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_D.Image.Dispose()
                    txtPath_D.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath_D.Text)
                        ResizeImages(TempPB.Image.Clone, pb_D, 650, 500)
                    End Using

                    ChangeDealerPic = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_D_Click(sender As Object, e As MouseEventArgs) Handles pb_D.Click
        Dim Camera As New FrmCamera
        With Camera
            If .ShowDialog = DialogResult.OK Then
                pb_D.Image = .pb_Picture.Image.Clone
                txtPath_D.Text = "From Camera"
            End If
        End With
    End Sub

#Region "Keydown"
    Private Sub CbxPrefix_D_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_D.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_D.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_D.Focus()
        End If
    End Sub

    Private Sub TxtLastN_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_D.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_D_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTradeName.Focus()
        End If
    End Sub

    Private Sub TxtTradeName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTradeName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_D.Focus()
        End If
    End Sub

    Private Sub TxtNoC_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_D.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_D.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_D.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_D_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone_D.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile_D.Focus()
        End If
    End Sub

    Private Sub TxtMobile_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail_D.Focus()
        End If
    End Sub

    Private Sub TxtEmail_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWebsite_D.Focus()
        End If
    End Sub

    Private Sub TxtWebsite_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWebsite_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_D.Focus()
        End If
    End Sub

    Private Sub TxtTIN_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_D.Focus()
        End If
    End Sub

    Private Sub TxtSSS_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFax_D.Focus()
        End If
    End Sub

    Private Sub TxtFax_D_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFax_D.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub CbxPrefix_D_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_D.Leave
        CbxPrefix_D.Text = ReplaceText(CbxPrefix_D.Text.Trim)
    End Sub

    Private Sub TxtFirstN_D_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_D.Leave
        TxtFirstN_D.Text = ReplaceText(TxtFirstN_D.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_D_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_D.Leave
        TxtMiddleN_D.Text = ReplaceText(TxtMiddleN_D.Text.Trim)
    End Sub

    Private Sub TxtLastN_D_Leave(sender As Object, e As EventArgs) Handles TxtLastN_D.Leave
        TxtLastN_D.Text = ReplaceText(TxtLastN_D.Text.Trim)
    End Sub

    Private Sub CbxSuffix_D_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_D.Leave
        cbxSuffix_D.Text = ReplaceText(cbxSuffix_D.Text.Trim)
    End Sub

    Private Sub TxtTradeName_Leave(sender As Object, e As EventArgs) Handles txtTradeName.Leave
        txtTradeName.Text = ReplaceText(txtTradeName.Text.Trim)
    End Sub

    Private Sub TxtNoC_D_Leave(sender As Object, e As EventArgs) Handles txtNoC_D.Leave
        txtNoC_D.Text = ReplaceText(txtNoC_D.Text.Trim)
    End Sub

    Private Sub TxtStreetC_D_Leave(sender As Object, e As EventArgs) Handles txtStreetC_D.Leave
        txtStreetC_D.Text = ReplaceText(txtStreetC_D.Text.Trim)
    End Sub

    Private Sub TxtBarangayC_D_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_D.Leave
        txtBarangayC_D.Text = ReplaceText(txtBarangayC_D.Text.Trim)
    End Sub

    Private Sub CbxAddressC_D_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_D.Leave
        cbxAddressC_D.Text = ReplaceText(cbxAddressC_D.Text.Trim)
    End Sub

    Private Sub TxtTelephone_D_Leave(sender As Object, e As EventArgs) Handles txtTelephone_D.Leave
        txtTelephone_D.Text = ReplaceText(txtTelephone_D.Text.Trim)
    End Sub

    Private Sub TxtMobile_D_Leave(sender As Object, e As EventArgs) Handles txtMobile_D.Leave
        txtMobile_D.Text = ReplaceText(txtMobile_D.Text.Trim)
    End Sub

    Private Sub TxtEmail_D_Leave(sender As Object, e As EventArgs) Handles txtEmail_D.Leave
        txtEmail_D.Text = ReplaceText(txtEmail_D.Text.Trim)
    End Sub

    Private Sub TxtWebsite_D_Leave(sender As Object, e As EventArgs) Handles txtWebsite_D.Leave
        txtWebsite_D.Text = ReplaceText(txtWebsite_D.Text.Trim)
    End Sub

    Private Sub TxtTIN_D_Leave(sender As Object, e As EventArgs) Handles txtTIN_D.Leave
        txtTIN_D.Text = ReplaceText(txtTIN_D.Text.Trim)
    End Sub

    Private Sub TxtSSS_D_Leave(sender As Object, e As EventArgs) Handles txtSSS_D.Leave
        txtSSS_D.Text = ReplaceText(txtSSS_D.Text.Trim)
    End Sub

    Private Sub TxtFax_D_Leave(sender As Object, e As EventArgs) Handles txtFax_D.Leave
        txtFax_D.Text = ReplaceText(txtFax_D.Text.Trim)
    End Sub
#End Region

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
            btnPrint.Enabled = True
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
            DataObject(String.Format("UPDATE profile_dealer SET `status` = 'DELETED' WHERE DealerID = '{0}'", txtDealerID.Text))
            Logs("Dealer", "Cancel", Reason, String.Format("Cancel Dealer {0}", txtTradeName.Text), "", "", "")
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
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Dim Report As New RptDealerProfile
            With Report
                .Name = txtDealerID.Text
                .p_Borrower.Image = pb_D.Image.Clone
                .lblBorrowerID.Text = txtDealerID.Text
                .lblBorrower.Text = If(CbxPrefix_D.Text.Trim = "", "", CbxPrefix_D.Text.Trim & " ") & If(TxtFirstN_D.Text.Trim = "", "", TxtFirstN_D.Text.Trim & " ") & If(TxtMiddleN_D.Text.Trim = "", "", TxtMiddleN_D.Text.Trim & " ") & If(TxtLastN_D.Text.Trim = "", "", TxtLastN_D.Text.Trim & " ") & cbxSuffix_D.Text.Trim
                .lblCompleteAdd.Text = If(txtNoC_D.Text.Trim = "", "", txtNoC_D.Text.Trim & " ") & If(txtStreetC_D.Text.Trim = "", "", txtStreetC_D.Text.Trim & " ") & If(txtBarangayC_D.Text.Trim = "", "", txtBarangayC_D.Text.Trim & " ") & If(cbxAddressC_D.Text.Trim = "", "", cbxAddressC_D.Text.Trim & " ")
                .lblTradeN.Text = txtTradeName.Text
                .cbxCar.Checked = cbxCar.Checked
                .lblTelephone.Text = txtTelephone_D.Text
                .lblMobile.Text = txtMobile_D.Text
                .lblEmail.Text = txtEmail_D.Text
                .lblWebsite.Text = txtWebsite_D.Text
                .lblTIN.Text = txtTIN_D.Text
                .lblSSS.Text = txtSSS_D.Text
                .lblFaxNo.Text = txtFax_D.Text
                .lblEmail.Text = txtEmail_D.Text
                Logs("Dealer Profile", "Print", "[SENSITIVE] Print Dealer Profile of " & If(CbxPrefix_D.Text.Trim = "", "", CbxPrefix_D.Text.Trim & " ") & If(TxtFirstN_D.Text.Trim = "", "", TxtFirstN_D.Text.Trim & " ") & If(TxtMiddleN_D.Text.Trim = "", "", TxtMiddleN_D.Text.Trim & " ") & If(TxtLastN_D.Text.Trim = "", "", TxtLastN_D.Text.Trim & " ") & cbxSuffix_D.Text.Trim, "", "", "", "")

                .ShowPreview()
            End With
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Dealer List", GridControl1)
            Logs("Dealer Profile", "Print", "[SENSITIVE] Print Dealer Profile", "", "", "", "")
        End If
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
        ElseIf e.Control And e.KeyCode = Keys.X Then
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If TxtFirstN_D.Text = "" Then
            MsgBox("Please fill dealer first name.", MsgBoxStyle.Information, "Info")
            TxtFirstN_D.Focus()
            Exit Sub
        End If
        If TxtLastN_D.Text = "" Then
            MsgBox("Please fill dealer last name.", MsgBoxStyle.Information, "Info")
            TxtLastN_D.Focus()
            Exit Sub
        End If

        Dim BorrowerN As String
        Dim CarDealer As String
        If cbxCar.Checked Then
            CarDealer = "YES"
        Else
            CarDealer = "NO"
        End If
        BorrowerN = If(CbxPrefix_D.Text = "", "", CbxPrefix_D.Text & " ") & If(TxtFirstN_D.Text = "", "", TxtFirstN_D.Text & " ") & If(TxtMiddleN_D.Text = "", "", TxtMiddleN_D.Text & " ") & If(TxtLastN_D.Text = "", "", TxtLastN_D.Text & " ") & cbxSuffix_D.Text
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_dealer WHERE (FirstN = '{0}' AND LastN = '{1}' AND Suffix = '{2}') AND `status` = 'ACTIVE' AND Branch_ID = '{3}'", TxtFirstN_D.Text, TxtLastN_D.Text, cbxSuffix_D.Text, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Dealer {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                GetDealer()

                Dim SQL As String = "INSERT INTO profile_dealer SET"
                SQL &= String.Format(" DealerID = '{0}', ", txtDealerID.Text)
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_D.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_D.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_D.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_D.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_D.Text)
                SQL &= String.Format(" TradeName = '{0}', ", txtTradeName.Text)
                SQL &= String.Format(" CarDealer = '{0}', ", CarDealer)
                SQL &= String.Format(" NoC = '{0}', ", txtNoC_D.Text)
                SQL &= String.Format(" StreetC = '{0}', ", txtStreetC_D.Text)
                SQL &= String.Format(" BarangayC = '{0}', ", txtBarangayC_D.Text)
                SQL &= String.Format(" `AddressC-ID` = '{0}', ", ValidateComboBox(cbxAddressC_D))
                SQL &= String.Format(" AddressC = '{0}', ", cbxAddressC_D.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone_D.Text)
                SQL &= String.Format(" Mobile = '{0}', ", txtMobile_D.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail_D.Text)
                SQL &= String.Format(" Website = '{0}', ", txtWebsite_D.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_D.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_D.Text)
                SQL &= String.Format(" Fax = '{0}', ", txtFax_D.Text)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= String.Format(" user_code = '{0}';", User_Code)
                DataObject(SQL)
                If txtPath_D.Text <> "" Then
                    SaveImage(pb_D, "Dealer")
                End If
                Cursor = Cursors.Default

                Logs("Dealer", "Save", String.Format("Add new Dealer {0}", BorrowerN), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_dealer WHERE (FirstN = '{0}' AND LastN = '{1}' AND Suffix = '{2}') AND `status` = 'ACTIVE' AND DealerID != '{3}' AND Branch_ID = '{4}'", TxtFirstN_D.Text, TxtLastN_D.Text, cbxSuffix_D.Text, txtDealerID.Text, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Dealer {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE profile_dealer SET"
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_D.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_D.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_D.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_D.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_D.Text)
                SQL &= String.Format(" TradeName = '{0}', ", txtTradeName.Text)
                SQL &= String.Format(" CarDealer = '{0}', ", CarDealer)
                SQL &= String.Format(" NoC = '{0}', ", txtNoC_D.Text)
                SQL &= String.Format(" StreetC = '{0}', ", txtStreetC_D.Text)
                SQL &= String.Format(" BarangayC = '{0}', ", txtBarangayC_D.Text)
                SQL &= String.Format(" `AddressC-ID` = '{0}', ", ValidateComboBox(cbxAddressC_D))
                SQL &= String.Format(" AddressC = '{0}', ", cbxAddressC_D.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone_D.Text)
                SQL &= String.Format(" Mobile = '{0}', ", txtMobile_D.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail_D.Text)
                SQL &= String.Format(" Website = '{0}', ", txtWebsite_D.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_D.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_D.Text)
                SQL &= String.Format(" Fax = '{0}' ", txtFax_D.Text)
                SQL &= String.Format(" WHERE DealerID = '{0}';", txtDealerID.Text)
                DataObject(SQL)
                If txtPath_D.Text <> "" Then
                    SaveImage(pb_D, "Dealer")
                End If
                Cursor = Cursors.Default

                Logs("Agent", "Update", String.Format("Update agent {0}", BorrowerN), Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxPrefix_D.Text = CbxPrefix_D.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", CbxPrefix_D.Tag, CbxPrefix_D.Text)
            End If
            If TxtFirstN_D.Text = TxtFirstN_D.Tag Then
            Else
                Change &= String.Format("Change First Name from {0} to {1}. ", TxtFirstN_D.Tag, TxtFirstN_D.Text)
            End If
            If TxtMiddleN_D.Text = TxtMiddleN_D.Tag Then
            Else
                Change &= String.Format("Change Middle Name from {0} to {1}. ", TxtMiddleN_D.Tag, TxtMiddleN_D.Text)
            End If
            If TxtLastN_D.Text = TxtLastN_D.Tag Then
            Else
                Change &= String.Format("Change Last Name from {0} to {1}. ", TxtLastN_D.Tag, TxtLastN_D.Text)
            End If
            If cbxSuffix_D.Text = cbxSuffix_D.Tag Then
            Else
                Change &= String.Format("Change Suffix from {0} to {1}. ", cbxSuffix_D.Tag, cbxSuffix_D.Text)
            End If
            If txtTradeName.Text = txtTradeName.Tag Then
            Else
                Change &= String.Format("Change Trade Name from {0} to {1}. ", txtTradeName.Tag, txtTradeName.Text)
            End If
            If txtNoC_D.Text = txtNoC_D.Tag Then
            Else
                Change &= String.Format("Change Complete Address No from {0} to {1}. ", txtNoC_D.Tag, txtNoC_D.Text)
            End If
            If txtStreetC_D.Text = txtStreetC_D.Tag Then
            Else
                Change &= String.Format("Change Complete Address Street from {0} to {1}. ", txtStreetC_D.Tag, txtStreetC_D.Text)
            End If
            If txtBarangayC_D.Text = txtBarangayC_D.Tag Then
            Else
                Change &= String.Format("Change Complete Address Barangay from {0} to {1}. ", txtBarangayC_D.Tag, txtBarangayC_D.Text)
            End If
            If cbxAddressC_D.Text = cbxAddressC_D.Tag Then
            Else
                Change &= String.Format("Change Complete Address from {0} to {1}. ", cbxAddressC_D.Tag, cbxAddressC_D.Text)
            End If
            If txtTelephone_D.Text = txtTelephone_D.Tag Then
            Else
                Change &= String.Format("Change Telephone from {0} to {1}. ", txtTelephone_D.Tag, txtTelephone_D.Text)
            End If
            If txtMobile_D.Text = txtMobile_D.Tag Then
            Else
                Change &= String.Format("Change Mobile from {0} to {1}. ", txtMobile_D.Tag, txtMobile_D.Text)
            End If
            If txtEmail_D.Text = txtEmail_D.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmail_D.Tag, txtEmail_D.Text)
            End If
            If txtWebsite_D.Text = txtWebsite_D.Tag Then
            Else
                Change &= String.Format("Change Website from {0} to {1}. ", txtWebsite_D.Tag, txtWebsite_D.Text)
            End If
            If txtTIN_D.Text = txtTIN_D.Tag Then
            Else
                Change &= String.Format("Change TIN from {0} to {1}. ", txtTIN_D.Tag, txtTIN_D.Text)
            End If
            If txtSSS_D.Text = txtSSS_D.Tag Then
            Else
                Change &= String.Format("Change SSS from {0} to {1}. ", txtSSS_D.Tag, txtSSS_D.Text)
            End If
            If txtFax_D.Text = txtFax_D.Tag Then
            Else
                Change &= String.Format("Change Fax from {0} to {1}. ", txtFax_D.Tag, txtFax_D.Text)
            End If
            If ChangeDealerPic Then
                Change &= "Change Dealer Picture. "
            End If
        Catch ex As Exception
            TriggerBugReport("Dealer Setup - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Public Sub SaveImage(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER Branch
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER Agent
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Dealers", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Dealers", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER Agent
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Dealers\{3}", RootFolder, MainFolder, Branch_Code, txtDealerID.Text)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Dealers\{3}", RootFolder, MainFolder, Branch_Code, txtDealerID.Text))
        End If
        '********CREATE File
        Try
            Dim xPath As String = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}", RootFolder, MainFolder, Branch_Code, txtDealerID.Text, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
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
            txtDealerID.Text = .GetFocusedRowCellValue("Dealer ID")
            txtDealerID.Tag = .GetFocusedRowCellValue("Dealer ID")
            CbxPrefix_D.Text = .GetFocusedRowCellValue("Prefix")
            CbxPrefix_D.Tag = .GetFocusedRowCellValue("Prefix")
            TxtFirstN_D.Text = .GetFocusedRowCellValue("FirstN")
            TxtFirstN_D.Tag = .GetFocusedRowCellValue("FirstN")
            TxtMiddleN_D.Text = .GetFocusedRowCellValue("MiddleN")
            TxtMiddleN_D.Tag = .GetFocusedRowCellValue("MiddleN")
            TxtLastN_D.Text = .GetFocusedRowCellValue("LastN")
            TxtLastN_D.Tag = .GetFocusedRowCellValue("LastN")
            cbxSuffix_D.Text = .GetFocusedRowCellValue("Suffix")
            cbxSuffix_D.Tag = .GetFocusedRowCellValue("Suffix")
            txtTradeName.Text = .GetFocusedRowCellValue("Trade Name")
            txtTradeName.Tag = .GetFocusedRowCellValue("Trade Name")
            If .GetFocusedRowCellValue("Car Dealer") = "YES" Then
                cbxCar.Checked = True
            Else
                cbxCar.Checked = False
            End If
            cbxCar.Tag = .GetFocusedRowCellValue("Car Dealer")
            txtNoC_D.Text = .GetFocusedRowCellValue("NoC")
            txtNoC_D.Tag = .GetFocusedRowCellValue("NoC")
            txtStreetC_D.Text = .GetFocusedRowCellValue("StreetC")
            txtStreetC_D.Tag = .GetFocusedRowCellValue("StreetC")
            txtBarangayC_D.Text = .GetFocusedRowCellValue("BarangayC")
            txtBarangayC_D.Tag = .GetFocusedRowCellValue("BarangayC")
            cbxAddressC_D.Text = .GetFocusedRowCellValue("AddressC")
            cbxAddressC_D.Tag = .GetFocusedRowCellValue("AddressC")
            txtTelephone_D.Text = .GetFocusedRowCellValue("Telephone")
            txtTelephone_D.Tag = .GetFocusedRowCellValue("Telephone")
            txtMobile_D.Text = .GetFocusedRowCellValue("Mobile")
            txtMobile_D.Tag = .GetFocusedRowCellValue("Mobile")
            txtEmail_D.Text = .GetFocusedRowCellValue("Email")
            txtEmail_D.Tag = .GetFocusedRowCellValue("Email")
            txtWebsite_D.Text = .GetFocusedRowCellValue("Website")
            txtWebsite_D.Tag = .GetFocusedRowCellValue("Website")
            txtTIN_D.Text = .GetFocusedRowCellValue("TIN")
            txtTIN_D.Tag = .GetFocusedRowCellValue("TIN")
            txtSSS_D.Text = .GetFocusedRowCellValue("SSS")
            txtSSS_D.Tag = .GetFocusedRowCellValue("SSS")
            txtFax_D.Text = .GetFocusedRowCellValue("Fax")
            txtFax_D.Tag = .GetFocusedRowCellValue("Fax")
            btnAttach.Enabled = True
            TotalImage = .GetFocusedRowCellValue("Attach")
        End With

        Try
            Using TempPB As New DevExpress.XtraEditors.PictureEdit
                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Dealers\{3}\{4}", RootFolder, MainFolder, GridView1.GetFocusedRowCellValue("branch_code"), GridView1.GetFocusedRowCellValue("Dealer ID"), "Dealer.jpg"))
                ResizeImages(TempPB.Image.Clone, pb_D, 650, 500)
            End Using
        Catch ex As Exception
        End Try
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            .Type = "Dealer's Attachment"
            .TotalImage = TotalImage
            .DealerNumber = txtDealerID.Text
            .ID = txtDealerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                GridView1.SetFocusedRowCellValue("Attach", TotalImage)
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                GridView1.SetFocusedRowCellValue("Attach", TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IReferred_Click(sender As Object, e As EventArgs) Handles iReferred.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Referred As New FrmReferredBorrowers
        With Referred
            .Agent = GridView1.GetFocusedRowCellValue("Dealer Name")
            .AgentID = GridView1.GetFocusedRowCellValue("Dealer ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class