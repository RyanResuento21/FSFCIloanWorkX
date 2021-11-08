<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmZoomImage
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
        Me.pbZoom = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.pBox = New System.Windows.Forms.PictureBox()
        CType(Me.pbZoom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.pBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbZoom
        '
        Me.pbZoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbZoom.Location = New System.Drawing.Point(0, 0)
        Me.pbZoom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.pbZoom.Name = "pbZoom"
        Me.pbZoom.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.pbZoom.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.pbZoom.Properties.Appearance.Options.UseBackColor = True
        Me.pbZoom.Properties.Appearance.Options.UseFont = True
        Me.pbZoom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.pbZoom.Properties.NullText = "No Image"
        Me.pbZoom.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pbZoom.Size = New System.Drawing.Size(1008, 729)
        Me.pbZoom.TabIndex = 1428
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.pBox)
        Me.PanelEx1.Controls.Add(Me.pbZoom)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(1008, 729)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1688
        '
        'pBox
        '
        Me.pBox.Location = New System.Drawing.Point(0, 0)
        Me.pBox.Name = "pBox"
        Me.pBox.Size = New System.Drawing.Size(1008, 729)
        Me.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pBox.TabIndex = 1429
        Me.pBox.TabStop = False
        '
        'FrmZoomImage
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimizeBox = False
        Me.Name = "FrmZoomImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbZoom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.pBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbZoom As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pBox As System.Windows.Forms.PictureBox
End Class
