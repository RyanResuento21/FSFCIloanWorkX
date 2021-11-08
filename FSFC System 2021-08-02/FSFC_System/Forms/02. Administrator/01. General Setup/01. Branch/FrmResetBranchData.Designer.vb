<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmResetBranchData
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
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnHistory = New DevComponents.DotNetBar.ButtonX()
        Me.btnReset = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.txtRemarks = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbx2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbx1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbx3 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbx4 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnHistory)
        Me.PanelEx3.Controls.Add(Me.btnReset)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 216)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(736, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1686
        '
        'btnHistory
        '
        Me.btnHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnHistory.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHistory.Image = Global.FSFC_System.My.Resources.Resources.Check
        Me.btnHistory.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnHistory.Location = New System.Drawing.Point(229, 3)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(107, 30)
        Me.btnHistory.TabIndex = 1011
        Me.btnHistory.Text = "Reset History"
        '
        'btnReset
        '
        Me.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnReset.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = Global.FSFC_System.My.Resources.Resources.Delete
        Me.btnReset.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnReset.Location = New System.Drawing.Point(3, 3)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(107, 30)
        Me.btnReset.TabIndex = 1000
        Me.btnReset.Text = "&Reset"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(116, 3)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1005
        Me.btnCancel.Text = "Close"
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.btnLogs)
        Me.PanelEx1.Controls.Add(Me.lblTitle)
        Me.PanelEx1.Controls.Add(Me.PictureEdit1)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx1.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(736, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1685
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(700, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1032
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(278, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(387, 26)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "RESET BRANCH DATA"
        Me.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(9, 1)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
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
        'txtRemarks
        '
        '
        '
        '
        Me.txtRemarks.Border.Class = "TextBoxBorder"
        Me.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.ForeColor = System.Drawing.Color.Black
        Me.txtRemarks.Location = New System.Drawing.Point(9, 181)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtRemarks.MaxLength = 150
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PreventEnterBeep = True
        Me.txtRemarks.Size = New System.Drawing.Size(715, 23)
        Me.txtRemarks.TabIndex = 1690
        Me.txtRemarks.WatermarkColor = System.Drawing.Color.Silver
        Me.txtRemarks.WatermarkText = "Remarks"
        '
        'cbx2
        '
        Me.cbx2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbx2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbx2.Checked = True
        Me.cbx2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx2.CheckValue = "Y"
        Me.cbx2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx2.Location = New System.Drawing.Point(9, 102)
        Me.cbx2.Name = "cbx2"
        Me.cbx2.Size = New System.Drawing.Size(698, 20)
        Me.cbx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbx2.TabIndex = 1689
        Me.cbx2.Tag = "Credit Application and Accounting Entries"
        Me.cbx2.Text = "2. Credit Application and Accounting Entries"
        Me.cbx2.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'cbx1
        '
        Me.cbx1.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbx1.Checked = True
        Me.cbx1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx1.CheckValue = "Y"
        Me.cbx1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx1.Location = New System.Drawing.Point(9, 76)
        Me.cbx1.Name = "cbx1"
        Me.cbx1.Size = New System.Drawing.Size(698, 20)
        Me.cbx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbx1.TabIndex = 1688
        Me.cbx1.Tag = "Profile"
        Me.cbx1.Text = "1. Profile"
        Me.cbx1.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'cbx3
        '
        Me.cbx3.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbx3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbx3.Checked = True
        Me.cbx3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx3.CheckValue = "Y"
        Me.cbx3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx3.Location = New System.Drawing.Point(9, 128)
        Me.cbx3.Name = "cbx3"
        Me.cbx3.Size = New System.Drawing.Size(698, 20)
        Me.cbx3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbx3.TabIndex = 1691
        Me.cbx3.Tag = "Non Loans Data"
        Me.cbx3.Text = "3. Non Loans Data"
        Me.cbx3.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'cbx4
        '
        Me.cbx4.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbx4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbx4.Checked = True
        Me.cbx4.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbx4.CheckValue = "Y"
        Me.cbx4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx4.Location = New System.Drawing.Point(9, 154)
        Me.cbx4.Name = "cbx4"
        Me.cbx4.Size = New System.Drawing.Size(698, 20)
        Me.cbx4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbx4.TabIndex = 1692
        Me.cbx4.Tag = "ROPA Data"
        Me.cbx4.Text = "4. ROPA Data"
        Me.cbx4.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'FrmResetBranchData
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbx4)
        Me.Controls.Add(Me.cbx3)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.cbx2)
        Me.Controls.Add(Me.cbx1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmResetBranchData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnReset As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtRemarks As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbx2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbx1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbx3 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbx4 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnHistory As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
