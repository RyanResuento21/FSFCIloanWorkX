Public Class FrmCamera
    Private WithEvents Cam As New DSCamCapture
    ReadOnly MyPicturesFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

    Private Sub FrmCamera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        cbxDevices.Items.AddRange(Cam.GetCaptureDevices)
        If cbxDevices.Items.Count > 0 Then cbxDevices.SelectedIndex = 0

        For Each sz As String In [Enum].GetNames(GetType(DSCamCapture.FrameSizes))
            cbxFrames.Items.Add(sz.Replace("s", ""))
        Next
        cbxFrames.SelectedIndex = cbxFrames.Items.Count - 1

        btnConnect.Enabled = (cbxDevices.Items.Count > 0)
        If cbxDevices.Items.Count > 0 Then
            btnConnect.PerformClick()
        Else
            btnCapture.Enabled = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If

            GetLabelFontSettings({LabelX4, LabelX1})

            GetComboBoxWinFormFontSettings({cbxDevices, cbxFrames})

            GetButtonFontSettings({btnConnect, btnCapture, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Camera - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxDevices_DropDown(sender As Object, e As EventArgs) Handles cbxDevices.DropDown
        cbxDevices.Items.Clear()
        cbxDevices.Items.AddRange(cam.GetCaptureDevices)
        btnConnect.Enabled = (cbxDevices.Items.Count > 0)
        If cbxDevices.SelectedIndex = -1 And cbxDevices.Items.Count > 0 Then cbxDevices.SelectedIndex = 0
    End Sub

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If Not cam.IsConnected Then
            Dim si As Integer = cbxFrames.SelectedIndex
            Dim SelectedSize As DSCamCapture.FrameSizes = CType(si, DSCamCapture.FrameSizes)
            If cam.ConnectToDevice(cbxDevices.SelectedIndex, 15, pb_B.ClientSize, SelectedSize, pb_B.Handle) Then
                cam.Start()
                btnConnect.Text = "Disconnect"
            End If
        Else
            cam.Dispose()
            btnConnect.Text = "Connect"
        End If
        btnCapture.Enabled = cam.IsConnected
        cbxDevices.Enabled = Not cam.IsConnected
        cbxFrames.Enabled = Not cam.IsConnected
    End Sub

    Private Sub FrmCamera_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        cam.Dispose()
    End Sub

    Private Sub BtnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        cam.SaveImage = True
        cam.TmrSaved.Start()
        If btnCapture.DialogResult = DialogResult.OK Then
        Else
            If MsgBox("Do you want to use this captured photo?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                btnCapture.DialogResult = DialogResult.OK
                btnCapture.PerformClick()
            End If
        End If
    End Sub

    Private Sub Cam_FrameSaved(capImage As System.Drawing.Bitmap, imgPath As String) Handles cam.FrameSaved
        pb_Picture.Image = New Bitmap(capImage)
    End Sub

    Private Sub Pb_B_SizeChanged(sender As Object, e As EventArgs) Handles pb_B.SizeChanged
        cam.ResizeWindow(0, 0, pb_B.ClientSize.Width, pb_B.ClientSize.Height)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmCamera_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class