<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCreditReferral
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
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.cbxDealer = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtDealersContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxDealerName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxWalkIn = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtWalkInOthers = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxWalkInType = New SergeUtils.EasyCompletionComboBox()
        Me.cbxMarketing = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtMarketingContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxMarketingName = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX188 = New DevComponents.DotNetBar.LabelX()
        Me.cbxAgent = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtAgentContact = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxAgentName = New SergeUtils.EasyCompletionComboBox()
        Me.cbxAgentV2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtAgentContactV2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbxAgentNameV2 = New SergeUtils.EasyCompletionComboBox()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.PanelEx3.Location = New System.Drawing.Point(0, 256)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(796, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1690
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
        Me.PanelEx2.Size = New System.Drawing.Size(796, 66)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 1689
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
        'cbxDealer
        '
        Me.cbxDealer.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxDealer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxDealer.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDealer.Location = New System.Drawing.Point(9, 221)
        Me.cbxDealer.Name = "cbxDealer"
        Me.cbxDealer.Size = New System.Drawing.Size(135, 23)
        Me.cbxDealer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxDealer.TabIndex = 65
        Me.cbxDealer.Text = "Dealer :"
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
        Me.txtDealersContact.Location = New System.Drawing.Point(502, 221)
        Me.txtDealersContact.MaxLength = 70
        Me.txtDealersContact.Name = "txtDealersContact"
        Me.txtDealersContact.PreventEnterBeep = True
        Me.txtDealersContact.Size = New System.Drawing.Size(286, 23)
        Me.txtDealersContact.TabIndex = 75
        Me.txtDealersContact.WatermarkText = "Contact No."
        '
        'cbxDealerName
        '
        Me.cbxDealerName.Enabled = False
        Me.cbxDealerName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDealerName.FormattingEnabled = True
        Me.cbxDealerName.Location = New System.Drawing.Point(150, 221)
        Me.cbxDealerName.MaxLength = 70
        Me.cbxDealerName.Name = "cbxDealerName"
        Me.cbxDealerName.Size = New System.Drawing.Size(346, 25)
        Me.cbxDealerName.TabIndex = 70
        '
        'cbxWalkIn
        '
        Me.cbxWalkIn.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxWalkIn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxWalkIn.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxWalkIn.Location = New System.Drawing.Point(9, 190)
        Me.cbxWalkIn.Name = "cbxWalkIn"
        Me.cbxWalkIn.Size = New System.Drawing.Size(135, 23)
        Me.cbxWalkIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxWalkIn.TabIndex = 50
        Me.cbxWalkIn.Text = "Walk In :"
        '
        'txtWalkInOthers
        '
        '
        '
        '
        Me.txtWalkInOthers.Border.Class = "TextBoxBorder"
        Me.txtWalkInOthers.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtWalkInOthers.Enabled = False
        Me.txtWalkInOthers.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWalkInOthers.Location = New System.Drawing.Point(502, 190)
        Me.txtWalkInOthers.MaxLength = 70
        Me.txtWalkInOthers.Name = "txtWalkInOthers"
        Me.txtWalkInOthers.PreventEnterBeep = True
        Me.txtWalkInOthers.Size = New System.Drawing.Size(286, 23)
        Me.txtWalkInOthers.TabIndex = 60
        Me.txtWalkInOthers.WatermarkText = "Please specify."
        '
        'cbxWalkInType
        '
        Me.cbxWalkInType.Enabled = False
        Me.cbxWalkInType.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxWalkInType.FormattingEnabled = True
        Me.cbxWalkInType.Location = New System.Drawing.Point(150, 190)
        Me.cbxWalkInType.MaxLength = 70
        Me.cbxWalkInType.Name = "cbxWalkInType"
        Me.cbxWalkInType.Size = New System.Drawing.Size(346, 25)
        Me.cbxWalkInType.TabIndex = 55
        '
        'cbxMarketing
        '
        Me.cbxMarketing.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxMarketing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxMarketing.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMarketing.Location = New System.Drawing.Point(9, 159)
        Me.cbxMarketing.Name = "cbxMarketing"
        Me.cbxMarketing.Size = New System.Drawing.Size(135, 23)
        Me.cbxMarketing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxMarketing.TabIndex = 35
        Me.cbxMarketing.Text = "Accounts Officer :"
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
        Me.txtMarketingContact.Location = New System.Drawing.Point(502, 159)
        Me.txtMarketingContact.MaxLength = 70
        Me.txtMarketingContact.Name = "txtMarketingContact"
        Me.txtMarketingContact.PreventEnterBeep = True
        Me.txtMarketingContact.Size = New System.Drawing.Size(286, 23)
        Me.txtMarketingContact.TabIndex = 45
        Me.txtMarketingContact.WatermarkText = "Contact No."
        '
        'cbxMarketingName
        '
        Me.cbxMarketingName.Enabled = False
        Me.cbxMarketingName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxMarketingName.FormattingEnabled = True
        Me.cbxMarketingName.Location = New System.Drawing.Point(150, 159)
        Me.cbxMarketingName.MaxLength = 70
        Me.cbxMarketingName.Name = "cbxMarketingName"
        Me.cbxMarketingName.Size = New System.Drawing.Size(346, 25)
        Me.cbxMarketingName.TabIndex = 40
        '
        'LabelX188
        '
        Me.LabelX188.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX188.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX188.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX188.ForeColor = System.Drawing.Color.White
        Me.LabelX188.Location = New System.Drawing.Point(9, 75)
        Me.LabelX188.Name = "LabelX188"
        Me.LabelX188.Size = New System.Drawing.Size(779, 16)
        Me.LabelX188.TabIndex = 1703
        Me.LabelX188.Text = "How did you learn about us?"
        Me.LabelX188.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cbxAgent
        '
        Me.cbxAgent.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAgent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAgent.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAgent.Location = New System.Drawing.Point(9, 97)
        Me.cbxAgent.Name = "cbxAgent"
        Me.cbxAgent.Size = New System.Drawing.Size(135, 23)
        Me.cbxAgent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAgent.TabIndex = 5
        Me.cbxAgent.Text = "Agent 1 :"
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
        Me.txtAgentContact.Location = New System.Drawing.Point(502, 97)
        Me.txtAgentContact.MaxLength = 70
        Me.txtAgentContact.Name = "txtAgentContact"
        Me.txtAgentContact.PreventEnterBeep = True
        Me.txtAgentContact.Size = New System.Drawing.Size(286, 23)
        Me.txtAgentContact.TabIndex = 15
        Me.txtAgentContact.WatermarkText = "Contact No."
        '
        'cbxAgentName
        '
        Me.cbxAgentName.Enabled = False
        Me.cbxAgentName.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAgentName.FormattingEnabled = True
        Me.cbxAgentName.Location = New System.Drawing.Point(150, 97)
        Me.cbxAgentName.MaxLength = 70
        Me.cbxAgentName.Name = "cbxAgentName"
        Me.cbxAgentName.Size = New System.Drawing.Size(346, 25)
        Me.cbxAgentName.TabIndex = 10
        '
        'cbxAgentV2
        '
        Me.cbxAgentV2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxAgentV2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxAgentV2.Enabled = False
        Me.cbxAgentV2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAgentV2.Location = New System.Drawing.Point(9, 128)
        Me.cbxAgentV2.Name = "cbxAgentV2"
        Me.cbxAgentV2.Size = New System.Drawing.Size(135, 23)
        Me.cbxAgentV2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxAgentV2.TabIndex = 20
        Me.cbxAgentV2.Text = "Agent 2 :"
        '
        'txtAgentContactV2
        '
        '
        '
        '
        Me.txtAgentContactV2.Border.Class = "TextBoxBorder"
        Me.txtAgentContactV2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAgentContactV2.Enabled = False
        Me.txtAgentContactV2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgentContactV2.Location = New System.Drawing.Point(502, 128)
        Me.txtAgentContactV2.MaxLength = 70
        Me.txtAgentContactV2.Name = "txtAgentContactV2"
        Me.txtAgentContactV2.PreventEnterBeep = True
        Me.txtAgentContactV2.Size = New System.Drawing.Size(286, 23)
        Me.txtAgentContactV2.TabIndex = 30
        Me.txtAgentContactV2.WatermarkText = "Contact No."
        '
        'cbxAgentNameV2
        '
        Me.cbxAgentNameV2.Enabled = False
        Me.cbxAgentNameV2.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAgentNameV2.FormattingEnabled = True
        Me.cbxAgentNameV2.Location = New System.Drawing.Point(150, 128)
        Me.cbxAgentNameV2.MaxLength = 70
        Me.cbxAgentNameV2.Name = "cbxAgentNameV2"
        Me.cbxAgentNameV2.Size = New System.Drawing.Size(346, 25)
        Me.cbxAgentNameV2.TabIndex = 25
        '
        'FrmCreditReferral
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 293)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxAgentV2)
        Me.Controls.Add(Me.txtAgentContactV2)
        Me.Controls.Add(Me.cbxAgentNameV2)
        Me.Controls.Add(Me.cbxDealer)
        Me.Controls.Add(Me.txtDealersContact)
        Me.Controls.Add(Me.cbxDealerName)
        Me.Controls.Add(Me.cbxWalkIn)
        Me.Controls.Add(Me.txtWalkInOthers)
        Me.Controls.Add(Me.cbxWalkInType)
        Me.Controls.Add(Me.cbxMarketing)
        Me.Controls.Add(Me.txtMarketingContact)
        Me.Controls.Add(Me.cbxMarketingName)
        Me.Controls.Add(Me.LabelX188)
        Me.Controls.Add(Me.cbxAgent)
        Me.Controls.Add(Me.txtAgentContact)
        Me.Controls.Add(Me.cbxAgentName)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmCreditReferral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents cbxDealer As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtDealersContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxDealerName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxWalkIn As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtWalkInOthers As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxWalkInType As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxMarketing As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtMarketingContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxMarketingName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX188 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAgent As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtAgentContact As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxAgentName As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxAgentV2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtAgentContactV2 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbxAgentNameV2 As SergeUtils.EasyCompletionComboBox
End Class
