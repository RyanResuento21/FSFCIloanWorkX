<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddRequirement
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
        Me.btnSelect = New DevComponents.DotNetBar.ButtonX()
        Me.cbxDocument = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.cbxNo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbxYes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cbxProduct = New SergeUtils.EasyCompletionComboBox()
        Me.cbxForProduct = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbxGen = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtRemarks = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnSelect)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 138)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(786, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 56
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
        'btnSelect
        '
        Me.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSelect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Image = Global.FSFC_System.My.Resources.Resources.Selected
        Me.btnSelect.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSelect.Location = New System.Drawing.Point(12, 3)
        Me.btnSelect.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 30)
        Me.btnSelect.TabIndex = 40
        Me.btnSelect.Text = "&Select"
        '
        'cbxDocument
        '
        Me.cbxDocument.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxDocument.FormattingEnabled = True
        Me.cbxDocument.Location = New System.Drawing.Point(125, 11)
        Me.cbxDocument.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxDocument.MaxLength = 35
        Me.cbxDocument.Name = "cbxDocument"
        Me.cbxDocument.Size = New System.Drawing.Size(605, 25)
        Me.cbxDocument.TabIndex = 83
        '
        'LabelX155
        '
        Me.LabelX155.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX155.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX155.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX155.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX155.Location = New System.Drawing.Point(12, 13)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(107, 23)
        Me.LabelX155.TabIndex = 84
        Me.LabelX155.Text = "Document :"
        Me.LabelX155.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxNo
        '
        Me.cbxNo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxNo.Enabled = False
        Me.cbxNo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxNo.Location = New System.Drawing.Point(172, 101)
        Me.cbxNo.Name = "cbxNo"
        Me.cbxNo.Size = New System.Drawing.Size(41, 23)
        Me.cbxNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxNo.TabIndex = 1016
        Me.cbxNo.Text = "No"
        Me.cbxNo.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'cbxYes
        '
        Me.cbxYes.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxYes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxYes.Checked = True
        Me.cbxYes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxYes.CheckValue = "Y"
        Me.cbxYes.Enabled = False
        Me.cbxYes.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxYes.Location = New System.Drawing.Point(125, 101)
        Me.cbxYes.Name = "cbxYes"
        Me.cbxYes.Size = New System.Drawing.Size(41, 23)
        Me.cbxYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxYes.TabIndex = 1015
        Me.cbxYes.Text = "Yes"
        Me.cbxYes.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(-28, 102)
        Me.LabelX3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(147, 23)
        Me.LabelX3.TabIndex = 1019
        Me.LabelX3.Text = "For Married Only :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxProduct
        '
        Me.cbxProduct.Enabled = False
        Me.cbxProduct.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProduct.FormattingEnabled = True
        Me.cbxProduct.Location = New System.Drawing.Point(417, 73)
        Me.cbxProduct.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cbxProduct.MaxLength = 35
        Me.cbxProduct.Name = "cbxProduct"
        Me.cbxProduct.Size = New System.Drawing.Size(220, 25)
        Me.cbxProduct.TabIndex = 1014
        '
        'cbxForProduct
        '
        Me.cbxForProduct.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxForProduct.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxForProduct.Enabled = False
        Me.cbxForProduct.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxForProduct.Location = New System.Drawing.Point(304, 72)
        Me.cbxForProduct.Name = "cbxForProduct"
        Me.cbxForProduct.Size = New System.Drawing.Size(120, 23)
        Me.cbxForProduct.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxForProduct.TabIndex = 1013
        Me.cbxForProduct.Text = "B. For Product"
        Me.cbxForProduct.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(-28, 72)
        Me.LabelX2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(147, 23)
        Me.LabelX2.TabIndex = 1018
        Me.LabelX2.Text = "Type :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxGen
        '
        Me.cbxGen.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.cbxGen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbxGen.Checked = True
        Me.cbxGen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxGen.CheckValue = "Y"
        Me.cbxGen.Enabled = False
        Me.cbxGen.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxGen.Location = New System.Drawing.Point(125, 72)
        Me.cbxGen.Name = "cbxGen"
        Me.cbxGen.Size = New System.Drawing.Size(182, 23)
        Me.cbxGen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbxGen.TabIndex = 1012
        Me.cbxGen.Text = "A. General Requirement"
        Me.cbxGen.TextColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        'txtRemarks
        '
        '
        '
        '
        Me.txtRemarks.Border.Class = "TextBoxBorder"
        Me.txtRemarks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRemarks.Enabled = False
        Me.txtRemarks.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(125, 43)
        Me.txtRemarks.MaxLength = 255
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.PreventEnterBeep = True
        Me.txtRemarks.Size = New System.Drawing.Size(605, 23)
        Me.txtRemarks.TabIndex = 1011
        Me.txtRemarks.WatermarkText = "eg. Should be compared with the payslip to check if the salary is really deposite" &
    "d to the declared ATM account (bank)."
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(-28, 43)
        Me.LabelX1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(147, 23)
        Me.LabelX1.TabIndex = 1017
        Me.LabelX1.Text = "Remarks :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'FrmAddRequirement
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 175)
        Me.ControlBox = False
        Me.Controls.Add(Me.cbxNo)
        Me.Controls.Add(Me.cbxYes)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.cbxProduct)
        Me.Controls.Add(Me.cbxForProduct)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cbxGen)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.cbxDocument)
        Me.Controls.Add(Me.LabelX155)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAddRequirement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSelect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxDocument As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxNo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cbxYes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxProduct As SergeUtils.EasyCompletionComboBox
    Friend WithEvents cbxForProduct As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxGen As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtRemarks As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
