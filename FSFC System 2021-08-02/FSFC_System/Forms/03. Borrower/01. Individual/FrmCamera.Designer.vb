<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCamera
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pb_B = New DevExpress.XtraEditors.PictureEdit()
        Me.btnCapture = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.pb_Picture = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnConnect = New DevComponents.DotNetBar.ButtonX()
        Me.cbxDevices = New System.Windows.Forms.ComboBox()
        Me.cbxFrames = New System.Windows.Forms.ComboBox()
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Picture.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb_B
        '
        Me.pb_B.EditValue = Global.FSFC_System.My.Resources.Resources.Avatar
        Me.pb_B.Location = New System.Drawing.Point(0, 0)
        Me.pb_B.Name = "pb_B"
        Me.pb_B.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pb_B.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pb_B.Properties.Appearance.Options.UseBackColor = True
        Me.pb_B.Properties.Appearance.Options.UseFont = True
        Me.pb_B.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pb_B.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_B.Size = New System.Drawing.Size(640, 480)
        Me.pb_B.TabIndex = 1
        '
        'btnCapture
        '
        Me.btnCapture.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCapture.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCapture.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapture.Image = Global.FSFC_System.My.Resources.Resources.Photo
        Me.btnCapture.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCapture.Location = New System.Drawing.Point(753, 309)
        Me.btnCapture.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(107, 30)
        Me.btnCapture.TabIndex = 1000
        Me.btnCapture.Text = "Capture"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(860, 309)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'pb_Picture
        '
        Me.pb_Picture.EditValue = Global.FSFC_System.My.Resources.Resources.Avatar
        Me.pb_Picture.Location = New System.Drawing.Point(646, 0)
        Me.pb_Picture.Name = "pb_Picture"
        Me.pb_Picture.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pb_Picture.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pb_Picture.Properties.Appearance.Options.UseBackColor = True
        Me.pb_Picture.Properties.Appearance.Options.UseFont = True
        Me.pb_Picture.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pb_Picture.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pb_Picture.Size = New System.Drawing.Size(320, 240)
        Me.pb_Picture.TabIndex = 1685
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(646, 246)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(85, 25)
        Me.LabelX4.TabIndex = 1687
        Me.LabelX4.Text = "Devices :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(646, 277)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(85, 25)
        Me.LabelX1.TabIndex = 1689
        Me.LabelX1.Text = "Frame Sizes :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnConnect
        '
        Me.btnConnect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConnect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnConnect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.Image = Global.FSFC_System.My.Resources.Resources.Connect
        Me.btnConnect.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnConnect.Location = New System.Drawing.Point(646, 309)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(107, 30)
        Me.btnConnect.TabIndex = 1692
        Me.btnConnect.Text = "Connect"
        '
        'cbxDevices
        '
        Me.cbxDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDevices.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDevices.FormattingEnabled = True
        Me.cbxDevices.Location = New System.Drawing.Point(737, 246)
        Me.cbxDevices.Name = "cbxDevices"
        Me.cbxDevices.Size = New System.Drawing.Size(229, 25)
        Me.cbxDevices.TabIndex = 1693
        '
        'cbxFrames
        '
        Me.cbxFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFrames.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxFrames.FormattingEnabled = True
        Me.cbxFrames.Location = New System.Drawing.Point(737, 277)
        Me.cbxFrames.Name = "cbxFrames"
        Me.cbxFrames.Size = New System.Drawing.Size(229, 25)
        Me.cbxFrames.TabIndex = 1694
        '
        'FrmCamera
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 482)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxFrames)
        Me.Controls.Add(Me.cbxDevices)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.pb_Picture)
        Me.Controls.Add(Me.pb_B)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCamera"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pb_B.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Picture.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pb_B As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnCapture As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pb_Picture As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnConnect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxDevices As System.Windows.Forms.ComboBox
    Friend WithEvents cbxFrames As System.Windows.Forms.ComboBox
End Class
