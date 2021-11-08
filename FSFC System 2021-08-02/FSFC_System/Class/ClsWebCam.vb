Imports System.Runtime.InteropServices


Public Enum VideoStatus
    Disconnected
    Playing
    Stopped
End Enum

Public Enum ImageFormats
    BMP
    PNG
    GIF
    JPEG
    TIFF
End Enum

Public Class WebCamVFW

#Region "Api/constants"

#Region " Structures "
    Private Structure VIDEOHDR
        Dim lpData As Integer '// address of video buffer  
        Dim dwBufferLength As Integer '// size, in bytes, of the Data buffer  
        Dim dwBytesUsed As Integer '// see below  
        Dim dwTimeCaptured As Integer '// see below  
        Dim dwUser As Integer '// user-specific data  
        Dim dwFlags As Integer '// see below  
        <VBFixedArray(3)> Dim dwReserved() As Integer '// reserved; do not use}  
    End Structure

    Private Structure BITMAPINFOHEADER
        Dim biSize As Integer
        Dim biWidth As Integer
        Dim biHeight As Integer
        Dim biPlanes As Short
        Dim biBitCount As Short
        Dim biCompression As Integer
        Dim biSizeImage As Integer
        Dim biXPelsPerMeter As Integer
        Dim biYPelsPerMeter As Integer
        Dim biClrUsed As Integer
        Dim biClrImportant As Integer
    End Structure
    Private Structure BITMAPINFO
        Dim bmiHeader As BITMAPINFOHEADER
        Dim bmiColors() As Integer
    End Structure

    Private Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure
    Private Structure RECTAPI
        Dim Left As Integer
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
    End Structure

    Private Structure CAPSTATUS
        Dim uiImageWidth As Integer                    '// Width of the  image  
        Dim uiImageHeight As Integer                   '// Height of the image  
        Dim fLiveWindow As Integer                     '// Now Previewing video?  
        Dim fOverlayWindow As Integer                  '// Now Overlaying  video?  
        Dim fScale As Integer                          '// Scale image to client?  
        Dim ptScroll As POINTAPI                       '// Scroll position  
        Dim fUsingDefaultPalette As Integer            '// Using default driver palette?  
        Dim fAudioHardware As Integer                  '// Audio hardware present?  
        Dim fCapFileExists As Integer                  '// Does capture file exist?  
        Dim dwCurrentVideoFrame As Integer             '// # of video frames cap'td  
        Dim dwCurrentVideoFramesDropped As Integer     '// # of video frames dropped  
        Dim dwCurrentWaveSamples As Integer            '// # of wave samples  cap'td  
        Dim dwCurrentTimeElapsedMS As Integer          '// Elapsed capture duration  
        Dim hPalCurrent As Integer                     '// Current palette in use  
        Dim fCapturingNow As Integer                   '// Capture in  progress?  
        Dim dwReturn As Integer                        '// Error value after any operation  
        Dim wNumVideoAllocated As Integer              '// Actual number of  video buffers  
        Dim wNumAudioAllocated As Integer              '// Actual number of audio buffers  
    End Structure
#End Region

#Region " Constants "

    Private Const WS_CHILD As Integer = &H40000000
    Private Const WS_VISIBLE As Integer = &H10000000
    Private Const SWP_NOMOVE As Integer = &H2
    Private Const SWP_NOZORDER As Integer = &H4
    Private Const WM_USER As Integer = &H400
    Private Const WM_CAP_START As Integer = WM_USER
    Private Const WM_CAP_DRIVER_CONNECT As Integer = WM_USER + 10
    Private Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_USER + 11
    Private Const WM_CAP_DRIVER_GET_CAPS As Integer = WM_USER + 14
    Private Const WM_CAP_FILE_SET_CAPTURE_FILEA As Integer = WM_USER + 20
    Private Const WM_CAP_EDIT_COPY As Integer = WM_USER + 30
    Private Const WM_CAP_DLG_VIDEOFORMAT As Integer = WM_USER + 41
    Private Const WM_CAP_DLG_VIDEOSOURCE As Integer = WM_USER + 42
    Private Const WM_CAP_DLG_VIDEODISPLAY As Integer = WM_USER + 43
    Private Const WM_CAP_SET_VIDEOFORMAT As Integer = WM_USER + 45
    Private Const WM_CAP_SET_PREVIEW As Integer = WM_USER + 50
    Private Const WM_CAP_SET_PREVIEWRATE As Integer = WM_USER + 52
    Private Const WM_CAP_SET_SCALE As Integer = WM_USER + 53
    Private Const WM_CAP_GET_STATUS As Integer = WM_CAP_START + 54
    Private Const WM_CAP_GET_FRAME As Integer = WM_USER + 60
    Private Const WM_CAP_SEQUENCE As Integer = WM_USER + 62
    Private Const WM_CAP_SET_SEQUENCE_SETUP As Integer = WM_USER + 64
    Private Const WM_CAP_STOP As Integer = WM_USER + 68
#End Region

#Region " Declares "
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Short, lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, ByRef lParam As CAPSTATUS) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, ByRef lParam As BITMAPINFO) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function DestroyWindow(hWnd As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function GetDesktopWindow() As IntPtr
    End Function
    <DllImport("gdi32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function BitBlt(hdcDest As IntPtr, nXDest As Integer, nYDest As Integer, nWidth As Integer, nHeight As Integer, hdcSrc As IntPtr, nXSrc As Integer, nYSrc As Integer, dwRop As Integer) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function GetDC(hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function GetWindowDC(hWnd As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function ReleaseDC(hWnd As IntPtr, hDC As IntPtr) As Integer
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function ShowWindow(hwnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function SetWindowPos(hWnd As IntPtr, hWndInsertAfter As IntPtr, x As Integer, y As Integer, cx As Integer, cy As Integer, wFlags As Integer) As Integer
    End Function

    <DllImport("avicap32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function capCreateCaptureWindow(lpszWindowName As String, dwStyle As Integer, x As Integer, y As Integer, nWidth As Integer, nHeight As Short, hWndParent As IntPtr, nID As Integer) As IntPtr
    End Function
    <DllImport("avicap32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
    Private Shared Function capGetDriverDescription(wDriver As Short, lpszName As String, cbName As Integer, lpszVer As String, cbVer As Integer) As Boolean
    End Function

#End Region

#End Region

#Region " Private variables "
    Private Shared ReadOnly _deviceName As String = "DefaultDevice"
    Private Shared _deviceID As Short = -1
    Private Shared _hWnd As IntPtr = IntPtr.Zero
    Private Shared _hwndParent As IntPtr = GetDesktopWindow()
    Private Shared ReadOnly _deviceList As New List(Of [String])
    Private Shared ReadOnly _FPS As Integer = 33
    Private Shared _Visible As Boolean
    Private Shared _OutputRect As New Rectangle(0, 0, 640, 480)
    Private Shared _CaptureRect As New Rectangle(0, 0, 640, 480)
    Private Shared _status As VideoStatus = VideoStatus.Disconnected
#End Region

#Region " Properties "
    Public Shared Property OutputRectangle() As Rectangle
        Get
            Return _OutputRect
        End Get
        Set(value As Rectangle)
            _OutputRect = value
        End Set
    End Property
    Public Shared ReadOnly Property Status() As VideoStatus
        Get
            Return _status
        End Get
    End Property
    Public Shared Property Visible() As Boolean
        Get
            Return _Visible
        End Get
        Set(value As Boolean)
            If value = _Visible Then Return
            _Visible = value
            If _hWnd.Equals(IntPtr.Zero) Then Return
            If _Visible Then
                ShowWindow(_hWnd, 5)
            Else
                ShowWindow(_hWnd, 0)
            End If
        End Set
    End Property
#End Region

#Region " Public methods "
    Public Shared Function Init(Optional width As Integer = -1, _
                                Optional height As Integer = -1, _
                                Optional parentControl As Control = Nothing) As Boolean
        If Not GetDeviceList() Then
            MessageBox.Show("No camera detected.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If parentControl IsNot Nothing Then
                _hwndParent = parentControl.Handle
                _OutputRect = parentControl.ClientRectangle
            End If
            If width > -1 Then _OutputRect.Width = width
            If height > -1 Then _OutputRect.Height = height
            _deviceID = 0
            _status = VideoStatus.Stopped
        End If
        Return _deviceList.Count > 0
    End Function

    Public Shared Function PlayVideo() As Boolean
        If _hWnd.Equals(IntPtr.Zero) Then
            _hWnd = capCreateCaptureWindow(_deviceName, WS_VISIBLE Or WS_CHILD,
                             _OutputRect.Left, _OutputRect.Top,
                             _OutputRect.Width, _OutputRect.Height,
                             _hwndParent, 0)
            If _hWnd.Equals(IntPtr.Zero) Then Return False
        End If
        If SendMessage(_hWnd, WM_CAP_DRIVER_CONNECT, _deviceID, 0) Then '_deviceList.Count > 0 Then
            SendMessage(_hWnd, WM_CAP_SET_PREVIEWRATE, _FPS, 0)
            SendMessage(_hWnd, WM_CAP_SET_SCALE, 1, 0)
            Dim bi As New BITMAPINFO
            With bi.bmiHeader
                .biSize = Marshal.SizeOf(bi.bmiHeader)
                .biWidth = _OutputRect.Width
                .biHeight = _OutputRect.Height
                .biPlanes = 1
                .biBitCount = 24
            End With
            SendMessage(_hWnd, WM_CAP_SET_VIDEOFORMAT, Marshal.SizeOf(bi), bi)
            SetWindowPos(_hWnd, 0, 0, 0, _OutputRect.Width, _OutputRect.Height, SWP_NOMOVE Or SWP_NOZORDER)

            Visible = True
            ShowPreview(True)
            _status = VideoStatus.Playing
            Return True
        End If
    End Function

    Public Shared Function ResumePlay() As Boolean
        If _hWnd.Equals(IntPtr.Zero) Then Return False
        If SendMessage(_hWnd, WM_CAP_DRIVER_CONNECT, _deviceID, 0) Then
            SendMessage(_hWnd, WM_CAP_SET_PREVIEWRATE, _FPS, 0)
            ShowPreview(True)
            SendMessage(_hWnd, WM_CAP_SET_SCALE, 1, 0)
            _status = VideoStatus.Playing
            Return True
        End If
    End Function

    Public Shared Function StopVideo() As Boolean
        If _hWnd.Equals(IntPtr.Zero) Then Return True
        ShowPreview(False)
        _status = VideoStatus.Stopped
        Return True
    End Function

    Public Shared Function CloseVideo() As Boolean
        If SendMessage(_hWnd, WM_CAP_DRIVER_DISCONNECT, 0, 0) Then
            If Not _hWnd.Equals(IntPtr.Zero) Then
                DestroyWindow(_hWnd)
                _hWnd = IntPtr.Zero
                _status = VideoStatus.Disconnected
            End If
        End If
    End Function

    Public Shared Sub ShowFormatDialog()
        If _hWnd.Equals(IntPtr.Zero) Then Return
        ShowPreview(False)
        SendMessage(_hWnd, WM_CAP_DLG_VIDEOFORMAT, 0, 0)
        ShowPreview(True)
    End Sub

    Public Shared Sub ShowDeviceDialog()
        If _hWnd.Equals(IntPtr.Zero) Then Return
        ShowPreview(False)
        SendMessage(_hWnd, WM_CAP_DLG_VIDEOSOURCE, 0, 0)
        ShowPreview(True)
    End Sub

    Public Shared Sub ShowDisplayDialog()
        If _hWnd.Equals(IntPtr.Zero) Then Return
        ShowPreview(False)
        SendMessage(_hWnd, WM_CAP_DLG_VIDEODISPLAY, 0, 0)
        ShowPreview(True)
    End Sub

    Public Shared Function GetFrame() As Bitmap
        If _status <> VideoStatus.Disconnected Then
            Dim srcPic As Graphics = Graphics.FromHwnd(_hWnd)
            Dim srcBmp As New Bitmap(_OutputRect.Width, _OutputRect.Height, srcPic)
            Dim srcMem As Graphics = Graphics.FromImage(srcBmp)

            Dim HDC1 As IntPtr = srcPic.GetHdc
            Dim HDC2 As IntPtr = srcMem.GetHdc

            BitBlt(HDC2, 0, 0, _OutputRect.Width, _OutputRect.Height, HDC1, 0, 0, 13369376)

            Dim bmp As Bitmap = CType(srcBmp.Clone(), Bitmap)

            'Clean Up 
            srcPic.ReleaseHdc()
            srcMem.ReleaseHdc()
            srcBmp.Dispose()
            srcPic.Dispose()
            srcMem.Dispose()
            Return bmp
        End If
        Return Nothing
    End Function
#End Region

#Region " Private methods "

    Private Shared Sub ShowPreview(fShow As Boolean)
        If _hWnd.Equals(IntPtr.Zero) Then Return
        If Not fShow Then SendMessage(_hWnd, WM_CAP_STOP, 0, 0)
        SendMessage(_hWnd, WM_CAP_SET_PREVIEW, fShow, 0)

    End Sub
    Private Shared Function GetDeviceList() As Boolean
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim x As Integer
        _deviceList.Clear()
        Do
            If capGetDriverDescription(x, strName, 100, strVer, 100) Then
                _deviceList.Add(strName.Trim(" ", Chr(0)))
            Else
                Exit Do
            End If
            x += 1
        Loop
        Return _deviceList.Count > 0
    End Function
#End Region
End Class

