Public Class FrmZoomImage

    Public TotalImage As Integer
    Public CurrentImage As Integer
    Public PanelEx As DevComponents.DotNetBar.PanelEx
    Public Type As String
    Private m_PanStartPoint As New Point
    Private _originalSize As Size = Nothing
    Private _scale As Single = 1
    Private _scaleDelta As Single = 0.0005
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keydata As Keys) As Boolean
        Try
            If keydata = Keys.Right Then
                If CurrentImage + 1 > TotalImage Then
                Else
                    CurrentImage += 1
                    Dim b As DevExpress.XtraEditors.PictureEdit = Nothing
                    If Type = "ROPOA VL" Then
                        b = CType(FindControl(FrmVehicleROPOA.PanelEx4, CurrentImage), DevExpress.XtraEditors.PictureEdit)
                    ElseIf Type = "ROPOA RE" Then
                        b = CType(FindControl(FrmRealEstateROPOA.PanelEx4, CurrentImage), DevExpress.XtraEditors.PictureEdit)
                    ElseIf Type = "Attach File" Then
                        b = CType(FindControl(PanelEx, CurrentImage - 1), DevExpress.XtraEditors.PictureEdit)
                    End If
                    pbZoom.Image = b.Image.Clone
                    pBox.Image = pbZoom.Image
                End If
                OnKeyDown(New KeyEventArgs(keydata))
                ProcessCmdKey = True
            ElseIf keydata = Keys.Left Then
                If CurrentImage - 1 <= 0 Then
                Else
                    CurrentImage -= 1
                    Dim b As DevExpress.XtraEditors.PictureEdit = Nothing
                    If Type = "ROPOA Vehicle" Then
                        b = CType(FindControl(FrmVehicleROPOA.PanelEx4, CurrentImage), DevExpress.XtraEditors.PictureEdit)
                    ElseIf Type = "ROPOA RE" Then
                        b = CType(FindControl(FrmRealEstateROPOA.PanelEx4, CurrentImage), DevExpress.XtraEditors.PictureEdit)
                    ElseIf Type = "Attach File" Then
                        b = CType(FindControl(PanelEx, CurrentImage - 1), DevExpress.XtraEditors.PictureEdit)
                    End If
                    pbZoom.Image = b.Image
                    pBox.Image = pbZoom.Image
                End If
                OnKeyDown(New KeyEventArgs(keydata))
                ProcessCmdKey = True
            Else
                ProcessCmdKey = MyBase.ProcessCmdKey(msg, keydata)
            End If
        Catch ex As Exception
            TriggerBugReport("Zoom Image - ProcessCmdKey", ex.Message.ToString)
        End Try
    End Function

    Private Sub FrmZoomImage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub PBox_MouseWheel(sender As Object, e As MouseEventArgs) Handles pBox.MouseWheel
        'if very sensitive mouse, change 0.00005 to something even smaller   
        _scaleDelta = Math.Sqrt(pBox.Width * pBox.Height) * 0.00005

        If e.Delta < 0 Then
            If pBox.Width < 1014 Then Exit Sub 'minimum 500?
            _scale -= _scaleDelta
        ElseIf e.Delta > 0 Then
            _scale += _scaleDelta
        End If

        If e.Delta <> 0 Then _
        pBox.Size = New Size(CInt(Math.Round(_originalSize.Width * _scale)), CInt(Math.Round(_originalSize.Height * _scale)))
    End Sub

    Private Sub FrmZoomImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        pBox.Image = pbZoom.Image

        'init this from here or a method depending on your needs
        If pBox.Image IsNot Nothing Then
            pBox.Size = PanelEx1.Size
            _originalSize = PanelEx1.Size
        End If
    End Sub

    Private Sub PBox_MouseDown(sender As Object, e As MouseEventArgs) Handles pBox.MouseDown
        'Capture the initial point 
        m_PanStartPoint = New Point(e.X, e.Y)
    End Sub

    Private Sub PBox_MouseMove(sender As Object, e As MouseEventArgs) Handles pBox.MouseMove
        'Verify Left Button is pressed while the mouse is moving
        If e.Button = Windows.Forms.MouseButtons.Left Then

            'Here we get the change in coordinates.
            Dim DeltaX As Integer = (m_PanStartPoint.X - e.X)
            Dim DeltaY As Integer = (m_PanStartPoint.Y - e.Y)

            'Then we set the new autoscroll position.
            'ALWAYS pass positive integers to the panels autoScrollPosition method
            PanelEx1.AutoScrollPosition = New Drawing.Point((DeltaX - PanelEx1.AutoScrollPosition.X), (DeltaY - PanelEx1.AutoScrollPosition.Y))
        End If
    End Sub
End Class