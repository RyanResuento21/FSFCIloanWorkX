Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmAttachFileV2

    Public AllowOveright As Boolean = True
    Public Type As String
    Public AssetNumber As String
    Public BorrowerNumber As String
    Public AgentNumber As String
    Public DealerNumber As String
    Public CreditNumber As String
    Public CRNumber As String
    Public CINumber As String
    Public ID As String
    Public FolderName As String
    Public TotalImage As Integer
    Public TotalImageII As Integer

    'NonLoans
    Public CANumber As String
    Public LiqNumber As String
    Public PCVNumber As String
    Public JENumber As String
    Public JVNumber As String
    Public CVNumber As String
    Public ARNumber As String
    Public CaseNumber As String
    Public APNumber As String
    Public ARNumberv2 As String
    Public DTNumber As String
    Public DFNumber As String
    Public RepNumber As String
    Public CCCNumber As String
    Public LPNumber As String
    Dim FileName As String
    '****BORROWER ID'S****'
    Public ID_Type = "B"

    '****BORROWER ID'S****'
    Private Sub FrmAttachFile_v2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(pbMain, 622, 515, 538, 0, False)
        PanelEx4.Size = New Point(538, 515)

        If TotalImage > 0 Then
            btnDelete.Enabled = True
            btnPrint.Enabled = True
        End If
        For x As Integer = 0 To TotalImage - 1
            Dim pB As New DevExpress.XtraEditors.PictureEdit
            With pB
                If AllowOveright Then
                Else
                    .Properties.ContextMenuStrip = New ContextMenuStrip()
                End If
                .Properties.NullText = "No Image"
                .Size = New Size(233, 185)
                PanelEx4.Controls.Add(pB)
                .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                If x Mod 2 = 0 Then
                    .Location = New Point(14, 15 + (192 * If(x >= 2, (Math.Ceiling(x / 2)), 0)))
                Else
                    .Location = New Point(269, 15 + (192 * If(x >= 2, (Math.Ceiling(x / 2) - 1), 0)))
                End If
                .Tag = x
                .BorderStyle = BorderStyle.FixedSingle
                AddHandler .Click, AddressOf Pb_Click
                AddHandler .ImageChanged, AddressOf pb_ImageChanged
                .BringToFront()
            End With
            Dim Path As String
            If AssetNumber <> "" Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName, "Image" & x & ".jpg")
            ElseIf BorrowerNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName, "Image" & x & ".jpg")
            ElseIf AgentNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Agents\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DealerNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CreditNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CINumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Investigation\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName, "Image" & x & ".jpg")
            ElseIf CANumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName, "Image" & x & ".jpg")
            ElseIf LiqNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName, "Image" & x & ".jpg")
            ElseIf PCVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf JENumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName, "Image" & x & ".jpg")
            ElseIf JVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf ARNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CaseNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\CASE\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName, "Image" & x & ".jpg")
            ElseIf APNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName, "Image" & x & ".jpg")
            ElseIf ARNumberv2 <> "" Then
                Path = String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName, "Image" & x & ".jpg")
            ElseIf RepNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DTNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Due To\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DFNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Due From\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName, "Image" & x & ".jpg")
            ElseIf LPNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CCCNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CRNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName, "Image" & x & ".jpg")
            Else
                Path = String.Format("{0}\{1}\{2}\Attachments\{3}\{4}", RootFolder, MainFolder, Branch_Code, FolderName, "Image" & x & ".jpg")
            End If
            If IO.File.Exists(Path) Then
                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                With TempPB
                    .Image = Image.FromFile(Path)
                    ResizeImages(.Image.Clone, pB, 850, 700)
                    If x = 0 Then
                        ResizeImages(.Image.Clone, pbMain, 850, 700)
                        pbMain.Tag = pB.Tag
                    End If
                    .Dispose()
                End With
            End If
        Next

        TotalImageII = TotalImage
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetButtonFontSettings({btnBrowse, btnSave, btnRefresh, btnCancel, btnDelete, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Attach File - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            OFD.Multiselect = True
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    PanelEx4.AutoScroll = False
                    For Each sFile As String In OFD.FileNames
                        Dim F_Info As New IO.FileInfo(sFile)
                        If F_Info.Length / 1024 > 1024 Then
                            MsgBox(String.Format("Selected File {0} have a size of {1}KB. Please limit up to 1024KB only.", sFile, CInt(F_Info.Length / 1000)), MsgBoxStyle.Information, "Info")
                            GoTo Here
                        End If
                        Dim pB As New DevExpress.XtraEditors.PictureEdit
                        With pB
                            .Properties.NullText = "No Image"
                            .Size = New Size(233, 185)
                            PanelEx4.Controls.Add(pB)
                            .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                            If TotalImage Mod 2 = 0 Then
                                .Location = New Point(14, 15 + (192 * If(TotalImage >= 2, (Math.Ceiling(TotalImage / 2)), 0)))
                            Else
                                .Location = New Point(269, 15 + (192 * If(TotalImage >= 2, (Math.Ceiling(TotalImage / 2) - 1), 0)))
                            End If
                            .Tag = TotalImage
                            .BorderStyle = BorderStyle.FixedSingle
                            AddHandler .Click, AddressOf Pb_Click
                            AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                            .BringToFront()
                        End With
                        Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                        With TempPB
                            .Image = Image.FromFile(sFile)
                            ResizeImages(.Image.Clone, pB, 850, 700)
                            If TotalImage = 0 Then
                                ResizeImages(.Image.Clone, pbMain, 850, 700)
                            End If
                            .Dispose()
                        End With
                        TotalImage += 1
Here:
                    Next
                    btnSave.Enabled = True
                    PanelEx4.AutoScroll = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_Click(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
            pbMain.Image = b.Image.Clone
            pbMain.Tag = b.Tag
        End If
    End Sub

    Private Sub Pb_ImageChanged(sender As Object, e As EventArgs)
        Try
            If CType(sender, DevExpress.XtraEditors.PictureEdit).Image Is Nothing Then
                Dim ChangeTag As Boolean = False
                Dim TempTotal As Integer = TotalImage

                Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
                PanelEx4.Controls.Remove(b)
                TempTotal -= 1
                ChangeTag = True
                TotalImage = TempTotal

                If ChangeTag Then
                    btnSave.Enabled = True
                    Dim Z As Integer = TotalImage - 1
                    If TotalImage = 0 Then
                        btnSave.Enabled = False
                    End If
                    For Each PBox As DevExpress.XtraEditors.PictureEdit In PanelEx4.Controls
                        With PBox
                            .Tag = Z
                            .Size = New Point(233, 185)
                            If Z Mod 2 = 0 Then
                                .Location = New Point(14, 15 + (192 * If(Z >= 2, (Math.Ceiling(Z / 2)), 0)))
                            Else
                                .Location = New Point(269, 15 + (192 * If(Z >= 2, (Math.Ceiling(Z / 2) - 1), 0)))
                            End If
                        End With
                        Z -= 1
                    Next
                End If
            End If
        Catch ex As Exception
            TriggerBugReport("Attach File - ImageChanged", ex.Message.ToString)
        End Try
    End Sub

    Private Sub PbMain_Click(sender As Object, e As MouseEventArgs) Handles pbMain.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
            If IsNothing(b.Image) Then
                Exit Sub
            End If
            Dim Zoom As New FrmZoomImage
            With Zoom
                .TotalImage = TotalImage
                .Type = "Attach File"
                .PanelEx = PanelEx4
                .CurrentImage = b.Tag + 1
                .pbZoom.Image = b.Image.Clone
                .ShowDialog()
                If b.Tag = .CurrentImage Then
                    b.Image = .pbZoom.Image.Clone
                End If
                .Dispose()
            End With
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
        ElseIf e.Control And e.KeyCode = Keys.W Then
            btnBrowse.Focus()
            btnBrowse.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.W Then
            btnBrowse.Focus()
            btnBrowse.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keydata As Keys) As Boolean
        If keydata = Keys.Right Then
            btnNext.PerformClick()
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        ElseIf keydata = Keys.Left Then
            btnBack.PerformClick()
            OnKeyDown(New KeyEventArgs(keydata))
            ProcessCmdKey = True
        Else
            ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
        End If
    End Function

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this attachment?") = MsgBoxResult.Yes Then
                For x As Integer = 0 To TotalImage - 1
                    Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                    SaveImage(pb, "Image" & x)
                Next
                If TotalImage < TotalImageII Then
                    For x As Integer = TotalImage To TotalImageII - 1
                        Dim xPath As String
                        If AssetNumber <> "" Then
                            xPath = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf BorrowerNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf AgentNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Agents\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DealerNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CreditNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CINumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Investigation\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CANumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName, "Image" & x & ".jpg")
                        ElseIf LiqNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf PCVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf JENumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName, "Image" & x & ".jpg")
                        ElseIf JVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf ARNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CaseNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\CASE\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf APNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf ARNumberv2 <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName, "Image" & x & ".jpg")
                        ElseIf RepNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DTNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Due To\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DFNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Due From\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf LPNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CCCNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CRNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName, "Image" & x & ".jpg")
                        Else
                            xPath = String.Format("{0}\{1}\{2}\Attachments\{3}\{4}", RootFolder, MainFolder, Branch_Code, FolderName, "Image" & x & ".jpg")
                        End If
                        If IO.File.Exists(xPath) Then
                            Try
                                IO.File.Delete(xPath)
                            Catch ex As Exception
                                TriggerBugReport("Attach File - Fix UI", ex.Message.ToString)
                            End Try
                        End If
                    Next
                End If
                If Type = "Repricing" Then
                    DataObject(String.Format("UPDATE tbl_repricing SET attachment = '{1}' WHERE repricing_code = '{0}'", ID, TotalImage))
                ElseIf Type = "Purchase VE" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET Attach = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Purchase RE" Then
                    DataObject(String.Format("UPDATE ropoa_realestate SET Attach = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "ROPOA Online Payment" Then
                    DataObject(String.Format("UPDATE check_received SET Attach = '{1}' WHERE ID = '{0}'", ID, TotalImage))
                ElseIf Type = "Borrower's Attachment I" Then
                    DataObject(String.Format("UPDATE profile_borrower SET Attach = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage))
                ElseIf Type = "Borrower's Attachment C" Then
                    DataObject(String.Format("UPDATE profile_corporation SET Attach = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage))
                ElseIf Type = "Agent's Attachment" Then
                    DataObject(String.Format("UPDATE profile_agent SET Attach = '{1}' WHERE AgentID = '{0}'", ID, TotalImage))
                ElseIf Type = "Dealer's Attachment" Then
                    DataObject(String.Format("UPDATE profile_dealer SET Attach = '{1}' WHERE DealerID = '{0}'", ID, TotalImage))
                    '*************** I D E N T I F I C A T I O N S *********************'
                    '*************** I D E N T I F I C A T I O N S *********************'
                    '*************** I D E N T I F I C A T I O N S *********************'
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment TIN" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_TIN = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SSS" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SSS = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GSIS" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_GSIS = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PhilHealth" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PhilHealth = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Senior" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Senior = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment UMID" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_UMID = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SEC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SEC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DTI = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment CDA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_CDA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Cooperative" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Cooperative = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Drivers" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Drivers = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment VIN" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_VIN = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Passport" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Passport = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PRC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PRC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment NBI" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_NBI = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Police" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Police = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Postal" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Postal = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Barangay" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Barangay = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OWWA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_OWWA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OFW" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_OFW = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Seaman" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Seaman = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PNP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PNP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment AFP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_AFP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment HDMF" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_HDMF = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PWD" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PWD = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DSWD" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DSWD = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment ACR" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_ACR = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI_Business" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DTI_Business = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment IBP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_IBP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment FireArms" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_FireArms = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Government" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Government = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Diplomat" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Diplomat = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment National" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_National = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Work" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Work = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GOCC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_GOCC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PLRA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PLRA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Major" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Major = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Media" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Media = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Student" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Student = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SIRV" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SIRV = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                    '*************** I D E N T I F I C A T I O N S *********************'

                    '*************** C R E D I T   A P P L I C A T I O N ***************'
                ElseIf Type = "Credit App Attachment" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment CoMaker 1" Then
                    DataObject(String.Format("UPDATE credit_application_comaker SET Attach = '{1}' WHERE CoMakerID = '{0}' AND `Rank` = 1 AND `status` = 'ACTIVE'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment CoMaker 2" Then
                    DataObject(String.Format("UPDATE credit_application_comaker SET Attach = '{1}' WHERE CoMakerID = '{0}' AND `Rank` = 2 AND `status` = 'ACTIVE'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment Spouse" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_S = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CA Approval" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Approval = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CA Crecomm Approval" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Crecomm = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Payment Release" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Releasing = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))

                    '*************** C R E D I T   I N V E S T I G A T I O N ***************'
                ElseIf Type = "CI Attachment" Then
                    DataObject(String.Format("UPDATE credit_investigation SET Attach = '{1}' WHERE CINumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CI Approval" Then
                    DataObject(String.Format("UPDATE credit_investigation SET Attach_Approval = '{1}' WHERE CINumber = '{0}'", ID, TotalImage))

                    '*************** O T H E R S ***************'
                ElseIf Type = "VE Attachment" Then
                    DataObject(String.Format("UPDATE appraise_ve SET Attach_2 = '{1}' WHERE appraise_num = '{0}'", ID, TotalImage))
                ElseIf Type = "VE Attachment 1" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET Attach_2 = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))

                    '*************** N O N   L O A N S ***************'
                ElseIf Type = "Cash Advance" Then
                    DataObject(String.Format("UPDATE cash_advance SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Liquidation" Then
                    DataObject(String.Format("UPDATE liquidation_main SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Petty Cash" Then
                    DataObject(String.Format("UPDATE petty_cash SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Journal Entry" Then
                    DataObject(String.Format("UPDATE journal_entry SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Journal Voucher" Then
                    DataObject(String.Format("UPDATE journal_voucher SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Check Voucher" Then
                    DataObject(String.Format("UPDATE check_voucher SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Official Receipt" Then
                    DataObject(String.Format("UPDATE official_receipt SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Acknowledgement Receipt" Then
                    DataObject(String.Format("UPDATE acknowledgement_receipt SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Case" Then
                    DataObject(String.Format("UPDATE case_main SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Accounts Payable" Then
                    DataObject(String.Format("UPDATE accounts_payable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Accounts Receivable" Then
                    DataObject(String.Format("UPDATE accounts_receivable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Replenishment" Then
                    DataObject(String.Format("UPDATE replenishment_cash SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Due To" Then
                    DataObject(String.Format("UPDATE due_to SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Due From" Then
                    DataObject(String.Format("UPDATE due_from SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Loans Payable" Then
                    DataObject(String.Format("UPDATE loans_payable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Collection Count" Then
                    DataObject(String.Format("UPDATE collection_cashcount SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                End If
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            Else
                btnSave.DialogResult = DialogResult.None
            End If
        End If
    End Sub

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
        If AssetNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf BorrowerNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Borrowers", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Borrowers", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Borrowers\{3}", RootFolder, MainFolder, Branch_Code, BorrowerNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Borrowers\{3}", RootFolder, MainFolder, Branch_Code, BorrowerNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf AgentNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Agents", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Agents", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Agents\{3}", RootFolder, MainFolder, Branch_Code, AgentNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Agents\{3}", RootFolder, MainFolder, Branch_Code, AgentNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Agents\{3}\{4}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Agents\{3}\{4}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Agents\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf DealerNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Dealers", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Dealers", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Dealers\{3}", RootFolder, MainFolder, Branch_Code, DealerNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Dealers\{3}", RootFolder, MainFolder, Branch_Code, DealerNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Dealers\{3}\{4}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Dealers\{3}\{4}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CreditNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, CreditNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, CreditNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CINumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Investigation", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Investigation", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Investigation\{3}", RootFolder, MainFolder, Branch_Code, CINumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Investigation\{3}", RootFolder, MainFolder, Branch_Code, CINumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Investigation\{3}\{4}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Investigation\{3}\{4}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Investigation\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CANumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Cash Advance", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Cash Advance", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Cash Advance\{3}", RootFolder, MainFolder, Branch_Code, CANumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Cash Advance\{3}", RootFolder, MainFolder, Branch_Code, CANumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CRNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Credit Released", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Credit Released", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Credit Released\{3}", RootFolder, MainFolder, Branch_Code, CRNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Credit Released\{3}", RootFolder, MainFolder, Branch_Code, CRNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf LiqNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Liquidation of Expenses", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Liquidation of Expenses", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}", RootFolder, MainFolder, Branch_Code, LiqNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}", RootFolder, MainFolder, Branch_Code, LiqNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf PCVNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Petty Cash", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Petty Cash", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Petty Cash\{3}", RootFolder, MainFolder, Branch_Code, PCVNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Petty Cash\{3}", RootFolder, MainFolder, Branch_Code, PCVNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf JENumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Entry", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Entry", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Entry\{3}", RootFolder, MainFolder, Branch_Code, JENumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Entry\{3}", RootFolder, MainFolder, Branch_Code, JENumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf JVNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Voucher", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Voucher", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Voucher\{3}", RootFolder, MainFolder, Branch_Code, JVNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Voucher\{3}", RootFolder, MainFolder, Branch_Code, JVNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CVNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Check Voucher", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Check Voucher", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Check Voucher\{3}", RootFolder, MainFolder, Branch_Code, CVNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Check Voucher\{3}", RootFolder, MainFolder, Branch_Code, CVNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf ARNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Acknowledgement Receipt", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Acknowledgement Receipt", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}", RootFolder, MainFolder, Branch_Code, ARNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}", RootFolder, MainFolder, Branch_Code, ARNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf APNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Payable", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Accounts Payable", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Payable\{3}", RootFolder, MainFolder, Branch_Code, APNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Accounts Payable\{3}", RootFolder, MainFolder, Branch_Code, APNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf ARNumberv2 <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Receivable", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Accounts Receivable", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Receivable\{3}", RootFolder, MainFolder, Branch_Code, ARNumberv2)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Receivable Payable\{3}", RootFolder, MainFolder, Branch_Code, ARNumberv2))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf RepNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Replenishment", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Replenishment", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Replenishment\{3}", RootFolder, MainFolder, Branch_Code, RepNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Replenishment\{3}", RootFolder, MainFolder, Branch_Code, RepNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CaseNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\CASE", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\CASE", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\CASE\{3}", RootFolder, MainFolder, Branch_Code, CaseNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\CASE\{3}", RootFolder, MainFolder, Branch_Code, CaseNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\CASE\{3}\{4}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\CASE\{3}\{4}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\CASE\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf DTNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due To", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due To", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due To\{3}", RootFolder, MainFolder, Branch_Code, DTNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due To\{3}", RootFolder, MainFolder, Branch_Code, DTNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due To\{3}\{4}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due To\{3}\{4}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Due To\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf DFNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due From", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due From", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due From\{3}", RootFolder, MainFolder, Branch_Code, DFNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due From\{3}", RootFolder, MainFolder, Branch_Code, DFNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Due From\{3}\{4}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Due From\{3}\{4}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Due From\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf LPNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Loans Payable", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Loans Payable", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Loans Payable\{3}", RootFolder, MainFolder, Branch_Code, LPNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Loans Payable\{3}", RootFolder, MainFolder, Branch_Code, LPNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        ElseIf CCCNumber <> "" Then
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Collection Cash Count", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Collection Cash Count", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Collection Cash Count\{3}", RootFolder, MainFolder, Branch_Code, CCCNumber)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Collection Cash Count\{3}", RootFolder, MainFolder, Branch_Code, CCCNumber))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        Else
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Attachments", RootFolder, MainFolder, Branch_Code)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Attachments", RootFolder, MainFolder, Branch_Code))
            End If
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Attachments\{3}", RootFolder, MainFolder, Branch_Code, FolderName)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Attachments\{3}", RootFolder, MainFolder, Branch_Code, FolderName))
            End If
            Try
                Dim xPath As String = String.Format("{0}\{1}\{2}\Attachments\{3}\{4}", RootFolder, MainFolder, Branch_Code, FolderName, FileName)
                If IO.File.Exists(xPath) Then
                    IO.File.Delete(xPath)
                End If
                pBox.Image.Save(xPath, ImageFormat.Jpeg)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        For x As Integer = 0 To TotalImageII - 1
            Dim pB As New DevExpress.XtraEditors.PictureEdit
            With pB
                .Properties.NullText = "No Image"
                .Size = New Size(233, 185)
                PanelEx4.Controls.Add(pB)
                .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                If x Mod 2 = 0 Then
                    .Location = New Point(14, 15 + (192 * If(x >= 2, (Math.Ceiling(x / 2)), 0)))
                Else
                    .Location = New Point(269, 15 + (192 * If(x >= 2, (Math.Ceiling(x / 2) - 1), 0)))
                End If
                .Tag = x
                .BorderStyle = BorderStyle.FixedSingle
                AddHandler .Click, AddressOf Pb_Click
                AddHandler .ImageChanged, AddressOf pb_ImageChanged
                .BringToFront()
            End With
            Dim Path As String
            If AssetNumber <> "" Then
                Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName, "Image" & x & ".jpg")
            ElseIf BorrowerNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName, "Image" & x & ".jpg")
            ElseIf AgentNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Agents\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DealerNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CreditNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CINumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Investigation\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName, "Image" & x & ".jpg")
            ElseIf CANumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName, "Image" & x & ".jpg")
            ElseIf CRNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName, "Image" & x & ".jpg")
            ElseIf LiqNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName, "Image" & x & ".jpg")
            ElseIf PCVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf JENumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName, "Image" & x & ".jpg")
            ElseIf JVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CVNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName, "Image" & x & ".jpg")
            ElseIf ARNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName, "Image" & x & ".jpg")
            ElseIf APNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName, "Image" & x & ".jpg")
            ElseIf ARNumberv2 <> "" Then
                Path = String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName, "Image" & x & ".jpg")
            ElseIf RepNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CaseNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\CASE\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DTNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Due To\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName, "Image" & x & ".jpg")
            ElseIf DFNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Due From\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName, "Image" & x & ".jpg")
            ElseIf LPNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName, "Image" & x & ".jpg")
            ElseIf CCCNumber <> "" Then
                Path = String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName, "Image" & x & ".jpg")
            Else
                Path = String.Format("{0}\{1}\{2}\Attachments\{3}\{4}", RootFolder, MainFolder, Branch_Code, FolderName, "Image" & x & ".jpg")
            End If
            If IO.File.Exists(Path) Then
                Dim TempPB As New DevExpress.XtraEditors.PictureEdit
                With TempPB
                    .Image = Image.FromFile(Path)
                    ResizeImages(.Image.Clone, pB, 850, 700)
                    If x = 0 Then
                        ResizeImages(.Image.Clone, pbMain, 850, 700)
                    End If
                    .Dispose()
                End With
            End If
        Next
        TotalImage = TotalImageII
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.DialogResult = DialogResult.Yes Then
        Else
            If MsgBoxYes("Are you sure you want to delete this whole attachment?") = MsgBoxResult.Yes Then
                TotalImage = 0
                If TotalImage < TotalImageII Then
                    For x As Integer = TotalImage To TotalImageII - 1
                        Dim xPath As String
                        If AssetNumber <> "" Then
                            xPath = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AssetNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf BorrowerNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, BorrowerNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf AgentNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Agents\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, AgentNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DealerNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Dealers\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DealerNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CreditNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CreditNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CINumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Investigation\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CINumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CANumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Cash Advance\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CANumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CRNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Credit Released\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CRNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf LiqNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Liquidation of Expenses\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LiqNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf PCVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Petty Cash\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, PCVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf JENumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Journal Entry\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JENumber, FolderName, "Image" & x & ".jpg")
                        ElseIf JVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Journal Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, JVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CVNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Check Voucher\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CVNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf ARNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Acknowledgement Receipt\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf APNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Accounts Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, APNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf ARNumberv2 <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Accounts Receivable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ARNumberv2, FolderName, "Image" & x & ".jpg")
                        ElseIf RepNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Replenishment\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, RepNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CaseNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\CASE\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CaseNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DTNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Due To\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DTNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf DFNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Due From\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, DFNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf LPNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Loans Payable\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, LPNumber, FolderName, "Image" & x & ".jpg")
                        ElseIf CCCNumber <> "" Then
                            xPath = String.Format("{0}\{1}\{2}\Collection Cash Count\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, CCCNumber, FolderName, "Image" & x & ".jpg")
                        Else
                            xPath = String.Format("{0}\{1}\{2}\Attachments\{3}\{4}", RootFolder, MainFolder, Branch_Code, FolderName, "Image" & x & ".jpg")
                        End If
                        If IO.File.Exists(xPath) Then
                            Try
                                IO.File.Delete(xPath)
                            Catch ex As Exception
                                TriggerBugReport(" - Fix UI", ex.Message.ToString)
                            End Try
                        End If
                    Next
                End If

                If Type = "Repricing" Then
                    DataObject(String.Format("UPDATE tbl_repricing SET attachment = '{1}' WHERE repricing_code = '{0}'", ID, TotalImage))
                ElseIf Type = "Purchase VE" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET Attach = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Purchase RE" Then
                    DataObject(String.Format("UPDATE ropoa_realestate SET Attach = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "ROPOA Online Payment" Then
                    DataObject(String.Format("UPDATE check_received SET Attach = '{1}' WHERE ID = '{0}'", ID, TotalImage))
                ElseIf Type = "Borrower's Attachment I" Then
                    DataObject(String.Format("UPDATE profile_borrower SET Attach = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage))
                ElseIf Type = "Borrower's Attachment C" Then
                    DataObject(String.Format("UPDATE profile_corporation SET Attach = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage))
                ElseIf Type = "Agent's Attachment" Then
                    DataObject(String.Format("UPDATE profile_agent SET Attach = '{1}' WHERE AgentID = '{0}'", ID, TotalImage))
                ElseIf Type = "Dealer's Attachment" Then
                    DataObject(String.Format("UPDATE profile_dealer SET Attach = '{1}' WHERE DealerID = '{0}'", ID, TotalImage))
                    '*************** I D E N T I F I C A T I O N S *********************'
                    '*************** I D E N T I F I C A T I O N S *********************'
                    '*************** I D E N T I F I C A T I O N S *********************'
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment TIN" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_TIN = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SSS" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SSS = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GSIS" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_GSIS = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PhilHealth" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PhilHealth = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Senior" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Senior = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment UMID" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_UMID = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SEC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SEC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DTI = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment CDA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_CDA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Cooperative" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Cooperative = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Drivers" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Drivers = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment VIN" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_VIN = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Passport" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Passport = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PRC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PRC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment NBI" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_NBI = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Police" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Police = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Postal" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Postal = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Barangay" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Barangay = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OWWA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_OWWA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment OFW" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_OFW = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Seaman" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Seaman = '{1}' WHERE BorrowerID = '{0}'", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PNP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PNP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment AFP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_AFP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment HDMF" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_HDMF = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PWD" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PWD = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DSWD" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DSWD = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment ACR" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_ACR = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment DTI_Business" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_DTI_Business = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment IBP" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_IBP = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment FireArms" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_FireArms = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Government" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Government = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Diplomat" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Diplomat = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment National" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_National = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Work" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Work = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment GOCC" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_GOCC = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment PLRA" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_PLRA = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Major" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Major = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Media" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Media = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment Student" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_Student = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                ElseIf Type = If(ID_Type = "B", "Borrower", If(ID_Type = "S", "Spouse", ID_Type)) & "'s Attachment SIRV" Then
                    DataObject(String.Format("UPDATE profile_borrowerid SET Attach_SIRV = '{1}' WHERE BorrowerID = '{0}' AND ID_Type = '{2}';", ID, TotalImage, ID_Type))
                    '*************** I D E N T I F I C A T I O N S *********************'

                    '*************** C R E D I T   A P P L I C A T I O N ***************'
                ElseIf Type = "Credit App Attachment" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment CoMaker 1" Then
                    DataObject(String.Format("UPDATE credit_application_comaker SET Attach = '{1}' WHERE CoMakerID = '{0}' AND `Rank` = 1 AND `status` = 'ACTIVE'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment CoMaker 2" Then
                    DataObject(String.Format("UPDATE credit_application_comaker SET Attach = '{1}' WHERE CoMakerID = '{0}' AND `Rank` = 2 AND `status` = 'ACTIVE'", ID, TotalImage))
                ElseIf Type = "Credit App Attachment Spouse" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_S = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CA Approval" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Approval = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CA Crecomm Approval" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Crecomm = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Credit Released" Then
                    DataObject(String.Format("UPDATE credit_application SET Attach_Releasing = '{1}' WHERE CreditNumber = '{0}'", ID, TotalImage))

                    '*************** C R E D I T   I N V E S T I G A T I O N ***************'
                ElseIf Type = "CI Attachment" Then
                    DataObject(String.Format("UPDATE credit_investigation SET Attach = '{1}' WHERE CINumber = '{0}'", ID, TotalImage))
                ElseIf Type = "CI Approval" Then
                    DataObject(String.Format("UPDATE credit_investigation SET Attach_Approval = '{1}' WHERE CINumber = '{0}'", ID, TotalImage))

                    '*************** O T H E R S ***************'
                ElseIf Type = "VE Attachment" Then
                    DataObject(String.Format("UPDATE appraise_ve SET Attach_2 = '{1}' WHERE appraise_num = '{0}'", ID, TotalImage))
                ElseIf Type = "VE Attachment 1" Then
                    DataObject(String.Format("UPDATE ropoa_vehicle SET Attach_2 = '{1}' WHERE AssetNumber = '{0}'", ID, TotalImage))

                    '*************** N O N   L O A N S ***************'
                ElseIf Type = "Cash Advance" Then
                    DataObject(String.Format("UPDATE cash_advance SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Liquidation" Then
                    DataObject(String.Format("UPDATE liquidation_main SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Petty Cash" Then
                    DataObject(String.Format("UPDATE petty_cash SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Journal Entry" Then
                    DataObject(String.Format("UPDATE journal_entry SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Journal Voucher" Then
                    DataObject(String.Format("UPDATE journal_voucher SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Check Voucher" Then
                    DataObject(String.Format("UPDATE check_voucher SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Official Receipt" Then
                    DataObject(String.Format("UPDATE official_receipt SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Acknowledgement Receipt" Then
                    DataObject(String.Format("UPDATE acknowledgement_receipt SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Accounts Payable" Then
                    DataObject(String.Format("UPDATE accounts_payable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Accounts Receivable" Then
                    DataObject(String.Format("UPDATE accounts_receivable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Replenishment" Then
                    DataObject(String.Format("UPDATE replenishment_cash SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Case" Then
                    DataObject(String.Format("UPDATE case_main SET Attach = '{1}' WHERE AccountNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Due To" Then
                    DataObject(String.Format("UPDATE due_to SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Due From" Then
                    DataObject(String.Format("UPDATE due_from SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Loans Payable" Then
                    DataObject(String.Format("UPDATE loans_payable SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                ElseIf Type = "Collection Count" Then
                    DataObject(String.Format("UPDATE collection_cashcount SET Attach = '{1}' WHERE DocumentNumber = '{0}'", ID, TotalImage))
                End If
                MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                btnDelete.DialogResult = DialogResult.Yes
                btnDelete.PerformClick()
            Else
                btnDelete.DialogResult = DialogResult.None
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim Report As New RptAttachFile
        With Report
            .Name = "Image"
            .XrPictureBox1.Image = pbMain.Image.Clone
            .ShowPreview()
        End With
    End Sub
End Class