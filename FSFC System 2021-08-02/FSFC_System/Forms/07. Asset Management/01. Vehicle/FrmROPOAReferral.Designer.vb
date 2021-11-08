<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmROPOAReferral
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.cbxDealer = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtDealersContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxDealerName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxMarketing = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtMarketingContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxMarketingName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxAgent = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtAgentContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxAgentName = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx1
        '
        Me.PanelEx1.AutoScroll = True
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.cbxDealer)
        Me.PanelEx1.Controls.Add(Me.txtDealersContact)
        Me.PanelEx1.Controls.Add(Me.cbxDealerName)
        Me.PanelEx1.Controls.Add(Me.cbxMarketing)
        Me.PanelEx1.Controls.Add(Me.txtMarketingContact)
        Me.PanelEx1.Controls.Add(Me.cbxMarketingName)
        Me.PanelEx1.Controls.Add(Me.cbxAgent)
        Me.PanelEx1.Controls.Add(Me.txtAgentContact)
        Me.PanelEx1.Controls.Add(Me.cbxAgentName)
        Me.PanelEx1.Controls.Add(Me.LabelX3)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx1.Location = New System.Drawing.Point(0, 66)
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(696, 137)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1689
        '
        'cbxDealer
        '
        Me.cbxDealer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDealer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDealer.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDealer.Location = New System.Drawing.Point(9, 100)
        Me.cbxDealer.Name = "cbxDealer"
        Me.cbxDealer.Size = New System.Drawing.Size(100, 23)
        Me.cbxDealer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDealer.TabIndex = 1743
        Me.cbxDealer.Text = "Dealer "
        '
        'txtDealersContact
        '
        '
        '
        '
        Me.txtDealersContact.Border.Class = "TextBoxBorder"
        Me.txtDealersContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDealersContact.Enabled = False
        Me.txtDealersContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDealersContact.Location = New System.Drawing.Point(446, 100)
        Me.txtDealersContact.MaxLength = 70
        Me.txtDealersContact.Name = "txtDealersContact"
        Me.txtDealersContact.PreventEnterBeep = True
        Me.txtDealersContact.Size = New System.Drawing.Size(233, 23)
        Me.txtDealersContact.TabIndex = 1745
        Me.txtDealersContact.WatermarkText = "Contact No."
        '
        'cbxDealerName
        '
        Me.cbxDealerName.Enabled = False
        Me.cbxDealerName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDealerName.FormattingEnabled = True
        Me.cbxDealerName.Location = New System.Drawing.Point(116, 100)
        Me.cbxDealerName.MaxLength = 70
        Me.cbxDealerName.Name = "cbxDealerName"
        Me.cbxDealerName.Size = New System.Drawing.Size(324, 25)
        Me.cbxDealerName.TabIndex = 1744
        '
        'cbxMarketing
        '
        Me.cbxMarketing.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxMarketing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMarketing.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMarketing.Location = New System.Drawing.Point(9, 69)
        Me.cbxMarketing.Name = "cbxMarketing"
        Me.cbxMarketing.Size = New System.Drawing.Size(100, 23)
        Me.cbxMarketing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMarketing.TabIndex = 1740
        Me.cbxMarketing.Text = "Employee "
        '
        'txtMarketingContact
        '
        '
        '
        '
        Me.txtMarketingContact.Border.Class = "TextBoxBorder"
        Me.txtMarketingContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMarketingContact.Enabled = False
        Me.txtMarketingContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketingContact.Location = New System.Drawing.Point(446, 69)
        Me.txtMarketingContact.MaxLength = 70
        Me.txtMarketingContact.Name = "txtMarketingContact"
        Me.txtMarketingContact.PreventEnterBeep = True
        Me.txtMarketingContact.Size = New System.Drawing.Size(233, 23)
        Me.txtMarketingContact.TabIndex = 1742
        Me.txtMarketingContact.WatermarkText = "Contact No."
        '
        'cbxMarketingName
        '
        Me.cbxMarketingName.Enabled = False
        Me.cbxMarketingName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxMarketingName.FormattingEnabled = True
        Me.cbxMarketingName.Location = New System.Drawing.Point(116, 69)
        Me.cbxMarketingName.MaxLength = 70
        Me.cbxMarketingName.Name = "cbxMarketingName"
        Me.cbxMarketingName.Size = New System.Drawing.Size(324, 25)
        Me.cbxMarketingName.TabIndex = 1741
        '
        'cbxAgent
        '
        Me.cbxAgent.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAgent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAgent.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAgent.Location = New System.Drawing.Point(9, 38)
        Me.cbxAgent.Name = "cbxAgent"
        Me.cbxAgent.Size = New System.Drawing.Size(100, 23)
        Me.cbxAgent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAgent.TabIndex = 1737
        Me.cbxAgent.Text = "Agent "
        '
        'txtAgentContact
        '
        '
        '
        '
        Me.txtAgentContact.Border.Class = "TextBoxBorder"
        Me.txtAgentContact.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAgentContact.Enabled = False
        Me.txtAgentContact.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgentContact.Location = New System.Drawing.Point(446, 38)
        Me.txtAgentContact.MaxLength = 70
        Me.txtAgentContact.Name = "txtAgentContact"
        Me.txtAgentContact.PreventEnterBeep = True
        Me.txtAgentContact.Size = New System.Drawing.Size(233, 23)
        Me.txtAgentContact.TabIndex = 1739
        Me.txtAgentContact.WatermarkText = "Contact No."
        '
        'cbxAgentName
        '
        Me.cbxAgentName.Enabled = False
        Me.cbxAgentName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAgentName.FormattingEnabled = True
        Me.cbxAgentName.Location = New System.Drawing.Point(116, 38)
        Me.cbxAgentName.MaxLength = 70
        Me.cbxAgentName.Name = "cbxAgentName"
        Me.cbxAgentName.Size = New System.Drawing.Size(324, 25)
        Me.cbxAgentName.TabIndex = 1738
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.White
        Me.LabelX3.Location = New System.Drawing.Point(9, 9)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(670, 23)
        Me.LabelX3.TabIndex = 1736
        Me.LabelX3.Text = "Referral Information"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnSave)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 203)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(696, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1688
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(116, 4)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(28, 28)
        Me.btnSave.Location = New System.Drawing.Point(3, 4)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 1000
        Me.btnSave.Text = "Update"
        '
        'PanelEx2
        '
        Me.PanelEx2.AutoScroll = True
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.PictureEdit1)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEx2.Location = New System.Drawing.Point(0, 0)
        Me.PanelEx2.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(696, 66)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 1687
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
        'FrmROPOA_Referral
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmROPOAReferral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents cbxDealer As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtDealersContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxDealerName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxMarketing As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtMarketingContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxMarketingName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxAgent As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtAgentContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxAgentName As SergeUtils.EasyCompletionComboBox
End Class
