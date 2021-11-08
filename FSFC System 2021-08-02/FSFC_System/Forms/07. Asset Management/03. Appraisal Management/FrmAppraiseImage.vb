Imports System.Drawing.Imaging
Public Class FrmAppraiseImage

    Public TotalImage As Integer
    Public AppraiseNumber As String
    Dim RopoaBranchCode As String
    Public ID As String
    Dim FileName As String
    Dim FirstLoad As Boolean
    Public From_ROPOA As Boolean
    Private Sub FrmAppraiseImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel, btnAddImages})
        Catch ex As Exception
            TriggerBugReport("Appraise Image - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub PassData()
        Try
            For x As Integer = 1 To TotalImage
                ClearPictureEdit(PanelEx4, x)
            Next
            TotalImage = 0
            For x As Integer = 1 To Max_Image_VE
                Dim pB As New DevExpress.XtraEditors.PictureEdit
                With pB
                    If x Mod 5 = 1 Then
                        .Properties.NullText = "Front"
                    ElseIf x Mod 5 = 2 Then
                        .Properties.NullText = "Back"
                    ElseIf x Mod 5 = 3 Then
                        .Properties.NullText = "Interior"
                    ElseIf x Mod 5 = 4 Then
                        .Properties.NullText = "Engine"
                    ElseIf x Mod 5 = 0 Then
                        .Properties.NullText = "Odometer"
                    End If
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
                    FirstLoad = True
                    .BringToFront()
                End With
                Dim Path As String
                If From_ROPOA Then
                    Path = String.Format("{0}\{1}\Asset\{2}\{3}\{4}\{5}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber, pB.Properties.NullText & x & ".jpg")
                Else
                    Path = String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, RopoaBranchCode, ID, AppraiseNumber, pB.Properties.NullText & x & ".jpg")
                End If
                If IO.File.Exists(Path) Then
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(Path)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
                End If
                FirstLoad = False
            Next
        Catch ex As Exception
            TriggerBugReport("Appraised Image - PassData", ex.Message.ToString)
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
                .Type = "ATTACH VL"
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
                    If pb.Image Is Nothing Then
                    Else
                        ResizeImages(pb.Image.Clone, pb, 850, 700)
                    End If
                    If From_ROPOA Then
                        SaveImage(pb, pb.Properties.NullText & x)
                    Else
                        SaveImage_CI(pb, pb.Properties.NullText & x)
                    End If
                Next
                DataObject(String.Format("UPDATE appraise_ve SET `Attach` = '{1}' WHERE appraise_num = '{0}'", AppraiseNumber, TotalImage))
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

    Private Sub BtnAddImages_Click(sender As Object, e As EventArgs) Handles btnAddImages.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Image File|*.jpg;*.jpeg;*.png",
            .Multiselect = True
        }
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                TotalImage = 0
                Dim x As Integer = 1
                For Each sFile As String In OFD.FileNames
                    If x = 6 Then 'PARA DLI RA MANOBRA ANG I UPLOAD
                        Exit Sub
                    End If
                    ClearPictureEdit(PanelEx4, x)
                    Dim pB As New DevExpress.XtraEditors.PictureEdit
                    With pB
                        If x Mod 5 = 1 Then
                            .Properties.NullText = "Front"
                        ElseIf x Mod 5 = 2 Then
                            .Properties.NullText = "Back"
                        ElseIf x Mod 5 = 3 Then
                            .Properties.NullText = "Interior"
                        ElseIf x Mod 5 = 4 Then
                            .Properties.NullText = "Engine"
                        ElseIf x Mod 5 = 0 Then
                            .Properties.NullText = "Odometer"
                        End If
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
                        FirstLoad = True
                        .BringToFront()
                    End With
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(sFile)
                        ResizeImages(TempPB.Image.Clone, pB, 850, 700)
                    End Using
                    x += 1
                    FirstLoad = False
                Next
            Catch ex As Exception
                PanelEx4.AutoScroll = True
                MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub
End Class