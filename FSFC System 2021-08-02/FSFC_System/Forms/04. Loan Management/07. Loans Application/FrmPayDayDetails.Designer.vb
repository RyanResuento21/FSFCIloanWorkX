<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPayDayDetails
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
        Me.txtAccountNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.cbxBank = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.txtCardNumber = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbxYes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3.SuspendLayout()
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
        Me.PanelEx3.Location = New System.Drawing.Point(0, 111)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(540, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 57
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(125, 3)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 50
        Me.btnCancel.Text = "Close"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Image = Global.FSFC_System.My.Resources.Resources.Save
        Me.btnSave.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSave.Location = New System.Drawing.Point(12, 3)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(107, 30)
        Me.btnSave.TabIndex = 40
        Me.btnSave.Text = "&Save"
        '
        'txtAccountNumber
        '
        '
        '
        '
        Me.txtAccountNumber.Border.Class = "TextBoxBorder"
        Me.txtAccountNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAccountNumber.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountNumber.Location = New System.Drawing.Point(148, 45)
        Me.txtAccountNumber.MaxLength = 50
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.PreventEnterBeep = True
        Me.txtAccountNumber.Size = New System.Drawing.Size(378, 23)
        Me.txtAccountNumber.TabIndex = 10
        Me.txtAccountNumber.WatermarkText = "Account Number"
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
        Me.LabelX1.Location = New System.Drawing.Point(12, 45)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(130, 23)
        Me.LabelX1.TabIndex = 1021
        Me.LabelX1.Text = "Account Number :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxBank
        '
        Me.cbxBank.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBank.FormattingEnabled = True
        Me.cbxBank.Location = New System.Drawing.Point(148, 13)
        Me.cbxBank.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxBank.MaxLength = 35
        Me.cbxBank.Name = "cbxBank"
        Me.cbxBank.Size = New System.Drawing.Size(378, 25)
        Me.cbxBank.TabIndex = 5
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX155.Location = New System.Drawing.Point(12, 15)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(130, 23)
        Me.LabelX155.TabIndex = 1019
        Me.LabelX155.Text = "Bank :"
        Me.LabelX155.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtCardNumber
        '
        '
        '
        '
        Me.txtCardNumber.Border.Class = "TextBoxBorder"
        Me.txtCardNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCardNumber.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardNumber.Location = New System.Drawing.Point(148, 74)
        Me.txtCardNumber.MaxLength = 50
        Me.txtCardNumber.Name = "txtCardNumber"
        Me.txtCardNumber.PreventEnterBeep = True
        Me.txtCardNumber.Size = New System.Drawing.Size(378, 23)
        Me.txtCardNumber.TabIndex = 15
        Me.txtCardNumber.WatermarkText = "Card Number"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(12, 74)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(130, 23)
        Me.LabelX2.TabIndex = 1023
        Me.LabelX2.Text = "Card Number :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxYes
        '
        Me.cbxYes.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbxYes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxYes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxYes.Location = New System.Drawing.Point(148, 74)
        Me.cbxYes.Name = "cbxYes"
        Me.cbxYes.Size = New System.Drawing.Size(71, 23)
        Me.cbxYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxYes.TabIndex = 1025
        Me.cbxYes.Text = "Yes"
        Me.cbxYes.Visible = False
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX14.Location = New System.Drawing.Point(12, 75)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(130, 23)
        Me.LabelX14.TabIndex = 1024
        Me.LabelX14.Text = "With ATM :"
        Me.LabelX14.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX14.Visible = False
        '
        'FrmPayDayDetails
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxYes)
        Me.Controls.Add(Me.txtCardNumber)
        Me.Controls.Add(Me.txtAccountNumber)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.cbxBank)
        Me.Controls.Add(Me.LabelX155)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.LabelX14)
        Me.Controls.Add(Me.LabelX2)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmPayDayDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtAccountNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxBank As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCardNumber As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxYes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
End Class
