Imports System.Drawing.Imaging
Public Class FrmAppraiseImageRE

    Public TotalImage As Integer = 5
    Public TotalImage_II As Integer = 5
    Public AppraiseNumber As String
    Dim RopoaBranchCode As String
    Public ID As String
    Dim FileName As String
    Dim FirstLoad As Boolean
    Dim AddImage As Boolean
    Public From_ROPOA As Boolean
    Public DT_Pictures As DataTable
    Private Sub FrmAppraiseImage_RE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        RopoaBranchCode = Branch_Code
        PassData()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetButtonFontSettings({btnAddImage, btnSave, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Appraise Image RE - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub PassData()
        Try
            PanelEx4.Controls.Clear()
            TotalImage = 0
            Dim PathX As String = ""
            If From_ROPOA Then
                PathX = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber)
            Else
                PathX = String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber)
            End If
            If IO.Directory.Exists(PathX) Then
                Dim files() As String = IO.Directory.GetFiles(PathX)
                For Each file As String In files
                    ' Do work, example
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        .Properties.Appearance.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
                        .Size = New Size(200, 150)
                        PanelEx4.Controls.Add(pB)
                        .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        If TotalImage >= 5 Then
                            If TotalImage >= 10 Then
                                If TotalImage >= 15 Then
                                    If TotalImage >= 20 Then
                                        If TotalImage >= 25 Then
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * TotalImage), 3)
                        End If
                        TotalImage += 1
                        .Visible = True
                        .Tag = TotalImage
                        .BorderStyle = BorderStyle.FixedSingle
                        AddHandler .Click, AddressOf Pb_Click
                        AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                        .BringToFront()
                    End With
                    Dim Path As String = file.ToString
                    If IO.File.Exists(Path) Then
                        Using TempPB As New DevExpress.XtraEditors.PictureEdit
                            TempPB.Image = Image.FromFile(Path)
                            ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                        End Using
                    End If
                Next
            Else
            End If
        Catch ex As Exception
            TriggerBugReport("Appraise Image RE - PassData", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Pb_Click(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
            If b.Image Is Nothing Then
                Exit Sub
            End If
            Dim Zoom As New FrmZoomImage
            With Zoom
                .TotalImage = TotalImage
                .Type = "ATTACH RE"
                .CurrentImage = b.Tag
                .pbZoom.Image = b.Image
                .ShowDialog()
                If b.Tag = .CurrentImage Then
                    b.Image = .pbZoom.Image
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
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAddImage.Focus()
            btnAddImage.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            PassData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this attachment(s)?") = MsgBoxResult.Yes Then
                For x As Integer = 1 To TotalImage
                    Dim pb As DevExpress.XtraEditors.PictureEdit = CType(FindControl(PanelEx4, x), DevExpress.XtraEditors.PictureEdit)
                    If x > 5 Then
                        If pb.Image Is Nothing Then
                        Else
                            ResizeImages(pb.Image.Clone, pb, 850, 700)
                            If From_ROPOA Then
                                SaveImage(pb, "Image" & x)
                            Else
                                saveImage_CI(pb, "Image" & x)
                            End If
                        End If
                    Else
                        If pb.Image Is Nothing Then
                        Else
                            If From_ROPOA Then
                                SaveImage(pb, pb.Properties.NullText & x)
                            Else
                                saveImage_CI(pb, pb.Properties.NullText & x)
                            End If
                        End If
                    End If
                Next
                DataObject(String.Format("UPDATE appraise_re SET `Attach` = '{1}' WHERE appraise_num = '{0}'", AppraiseNumber, TotalImage))
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
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, RopoaBranchCode))
        End If
        '********CREATE FOLDER Borrowers
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, RopoaBranchCode)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, RopoaBranchCode))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, RopoaBranchCode, ID)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, RopoaBranchCode, ID))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber))
        End If
        '********CREATE File
        Try
            Dim xPath As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SaveImage_CI(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER 
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER 
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER 
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, ID)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}", RootFolder, MainFolder, Branch_Code, ID))
        End If
        '********CREATE FOLDER 
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, ID, AppraiseNumber)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Application\{3}\{4}", RootFolder, MainFolder, Branch_Code, ID, AppraiseNumber))
        End If
        '********CREATE File
        Try
            Dim xPath As String = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, ID, AppraiseNumber, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAddImage_Click(sender As Object, e As EventArgs) Handles btnAddImage.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Image File|*.jpg;*.jpeg;*.png",
            .Multiselect = True
        }
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                AddImage = True
                PanelEx4.AutoScroll = False
                For Each sFile As String In OFD.FileNames
                    Dim F_Info As New IO.FileInfo(sFile)
                    If F_Info.Length / 1024 > 1024 Then
                        MsgBox(String.Format("Selected File {0} have a size of {1}KB. Please limit up to 1024KB only.", sFile, CInt(F_Info.Length / 1000)), MsgBoxStyle.Information, "Info")
                        GoTo Here
                    End If
                    If TotalImage = Max_Image Then
                        MsgBox(String.Format("Maximum image to attach is up to {0} images only.", Max_Image), MsgBoxStyle.Information, "Info")
                        PanelEx4.AutoScroll = True
                        Exit Sub
                    End If
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        .Properties.Appearance.Font = New Font(OfficialFont, 8.5, FontStyle.Regular)
                        .Properties.NullText = "No Image"
                        .Size = New Size(200, 150)
                        PanelEx4.Controls.Add(pB)
                        .Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                        If TotalImage >= 5 Then
                            If TotalImage >= 10 Then
                                If TotalImage >= 15 Then
                                    If TotalImage >= 20 Then
                                        If TotalImage >= 25 Then
                                            If TotalImage >= 30 Then
                                                If TotalImage >= 35 Then
                                                    If TotalImage >= 40 Then
                                                        If TotalImage >= 45 Then
                                                            If TotalImage >= 50 Then
                                                                .Location = New Point(3 + (230 * (TotalImage - 50)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            Else
                                                                .Location = New Point(3 + (230 * (TotalImage - 45)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                            End If
                                                        Else
                                                            .Location = New Point(3 + (230 * (TotalImage - 40)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                        End If
                                                    Else
                                                        .Location = New Point(3 + (230 * (TotalImage - 35)), 3 + 156 + 156 + 156 + 156 + 156 + 156 + 156)
                                                    End If
                                                Else
                                                    .Location = New Point(3 + (230 * (TotalImage - 30)), 3 + 156 + 156 + 156 + 156 + 156 + 156)
                                                End If
                                            Else
                                                .Location = New Point(3 + (230 * (TotalImage - 25)), 3 + 156 + 156 + 156 + 156 + 156)
                                            End If
                                        Else
                                            .Location = New Point(3 + (230 * (TotalImage - 20)), 3 + 156 + 156 + 156 + 156)
                                        End If
                                    Else
                                        .Location = New Point(3 + (230 * (TotalImage - 15)), 3 + 156 + 156 + 156)
                                    End If
                                Else
                                    .Location = New Point(3 + (230 * (TotalImage - 10)), 3 + 156 + 156)
                                End If
                            Else
                                .Location = New Point(3 + (230 * (TotalImage - 5)), 3 + 156)
                            End If
                        Else
                            .Location = New Point(3 + (230 * TotalImage), 3)
                        End If
                        TotalImage += 1
                        .Visible = True
                        .Tag = TotalImage
                        .BorderStyle = BorderStyle.FixedSingle
                        AddHandler .Click, AddressOf Pb_Click
                        AddHandler .ImageChanged, AddressOf Pb_ImageChanged
                        .BringToFront()
                    End With
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(sFile)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
Here:
                Next
                PanelEx4.AutoScroll = True
            Catch ex As Exception
                PanelEx4.AutoScroll = True
                MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

    Private Sub Pb_ImageChanged(sender As Object, e As EventArgs)
        If FirstLoad Then
            Exit Sub
        End If
        If CType(sender, DevExpress.XtraEditors.PictureEdit).Properties.NullText <> "No Image" Then
            Try
            Catch ex As Exception
                TriggerBugReport("Appraise Image RE - ImageChanged", ex.Message.ToString)
            End Try
        Else
            Try
                If CType(sender, DevExpress.XtraEditors.PictureEdit).Image Is Nothing Then
                    Dim ChangeTag As Boolean = False
                    Dim TempTotal As Integer = TotalImage
                    PanelEx4.AutoScroll = False
                    Dim b As DevExpress.XtraEditors.PictureEdit = CType(sender, DevExpress.XtraEditors.PictureEdit)
                    PanelEx4.Controls.Remove(b)
                    TempTotal -= 1
                    ChangeTag = True
                    TotalImage = TempTotal

                    If ChangeTag Then
                        Dim Z As Integer = TotalImage
                        For Each PBox As DevExpress.XtraEditors.PictureEdit In PanelEx4.Controls
                            PBox.Tag = Z
                            Z -= 1
                            If Z >= 5 Then
                                If Z >= 10 Then
                                    If Z >= 15 Then
                                        If Z >= 20 Then
                                        Else
                                            PBox.Location = New Point(3 + (230 * (Z - 15)), 3 + 156 + 156 + 156)
                                        End If
                                    Else
                                        PBox.Location = New Point(3 + (230 * (Z - 10)), 3 + 156 + 156)
                                    End If
                                Else
                                    PBox.Location = New Point(3 + (230 * (Z - 5)), 3 + 156)
                                End If
                            Else
                            End If
                        Next
                    End If
                    PanelEx4.AutoScroll = True
                End If
            Catch ex As Exception
                TriggerBugReport("Appraise Image RE - ImageChanged", ex.Message.ToString)
            End Try
        End If
    End Sub
End Class