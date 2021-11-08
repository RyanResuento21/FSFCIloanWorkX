<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOneTimePassword
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
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnView = New DevComponents.DotNetBar.ButtonX()
        Me.btnAttachments = New DevComponents.DotNetBar.ButtonX()
        Me.btnResend = New DevComponents.DotNetBar.ButtonX()
        Me.btnOpen = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.txtOTP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxShow = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblBilling = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.LabelX11)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(566, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1687
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX11.Location = New System.Drawing.Point(279, 1)
        Me.LabelX11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(283, 61)
        Me.LabelX11.TabIndex = 5
        Me.LabelX11.Text = "ONE TIME AUTHORIZATION CODE"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX11.WordWrap = True
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(6, 1)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.PictureEdit1.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.Appearance.Options.UseFont = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(263, 64)
        Me.PictureEdit1.TabIndex = 3
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnView)
        Me.PanelEx3.Controls.Add(Me.btnAttachments)
        Me.PanelEx3.Controls.Add(Me.btnResend)
        Me.PanelEx3.Controls.Add(Me.btnOpen)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 233)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(566, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1688
        '
        'btnView
        '
        Me.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnView.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnView.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnView.Location = New System.Drawing.Point(455, 4)
        Me.btnView.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(107, 30)
        Me.btnView.TabIndex = 1039
        Me.btnView.Text = "View Attachment"
        Me.btnView.Visible = False
        '
        'btnAttachments
        '
        Me.btnAttachments.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAttachments.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAttachments.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAttachments.Image = Global.FSFC_System.My.Resources.Resources.Upload
        Me.btnAttachments.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAttachments.Location = New System.Drawing.Point(342, 4)
        Me.btnAttachments.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAttachments.Name = "btnAttachments"
        Me.btnAttachments.Size = New System.Drawing.Size(107, 30)
        Me.btnAttachments.TabIndex = 1038
        Me.btnAttachments.Text = "Add Attachment"
        Me.btnAttachments.Visible = False
        '
        'btnResend
        '
        Me.btnResend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnResend.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnResend.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResend.Image = Global.FSFC_System.My.Resources.Resources.Email
        Me.btnResend.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnResend.Location = New System.Drawing.Point(229, 4)
        Me.btnResend.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnResend.Name = "btnResend"
        Me.btnResend.Size = New System.Drawing.Size(107, 30)
        Me.btnResend.TabIndex = 1006
        Me.btnResend.Text = "Send OTAC"
        Me.btnResend.Visible = False
        '
        'btnOpen
        '
        Me.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnOpen.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Image = Global.FSFC_System.My.Resources.Resources.Unlock
        Me.btnOpen.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnOpen.Location = New System.Drawing.Point(3, 4)
        Me.btnOpen.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(107, 30)
        Me.btnOpen.TabIndex = 1000
        Me.btnOpen.Text = "&Open"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(116, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1005
        Me.btnCancel.Text = "Close"
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.txtOTP)
        Me.PanelEx2.Controls.Add(Me.cbxShow)
        Me.PanelEx2.Controls.Add(Me.lblBilling)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx2.Location = New System.Drawing.Point(0, 66)
        Me.PanelEx2.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(566, 167)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.None
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 1689
        '
        'txtOTP
        '
        '
        '
        '
        Me.txtOTP.Border.Class = "TextBoxBorder"
        Me.txtOTP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOTP.Font = New System.Drawing.Font("Century Gothic", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOTP.ForeColor = System.Drawing.Color.Black
        Me.txtOTP.Location = New System.Drawing.Point(6, 10)
        Me.txtOTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOTP.MaxLength = 8
        Me.txtOTP.Name = "txtOTP"
        Me.txtOTP.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOTP.PreventEnterBeep = True
        Me.txtOTP.Size = New System.Drawing.Size(552, 125)
        Me.txtOTP.TabIndex = 1717
        Me.txtOTP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtOTP.WatermarkText = "Code"
        '
        'cbxShow
        '
        Me.cbxShow.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxShow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxShow.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxShow.Location = New System.Drawing.Point(461, 139)
        Me.cbxShow.Name = "cbxShow"
        Me.cbxShow.Size = New System.Drawing.Size(97, 23)
        Me.cbxShow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxShow.TabIndex = 1722
        Me.cbxShow.Text = "Show Code"
        Me.cbxShow.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'lblBilling
        '
        Me.lblBilling.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBilling.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBilling.ForeColor = System.Drawing.Color.Red
        Me.lblBilling.Location = New System.Drawing.Point(6, 139)
        Me.lblBilling.Name = "lblBilling"
        Me.lblBilling.Size = New System.Drawing.Size(263, 23)
        Me.lblBilling.TabIndex = 1721
        Me.lblBilling.Text = "Code will last until 5 minutes ONLY."
        '
        'FrmOneTimePassword
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 270)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmOneTimePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnOpen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents txtOTP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblBilling As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxShow As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnResend As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnView As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAttachments As DevComponents.DotNetBar.ButtonX
End Class
