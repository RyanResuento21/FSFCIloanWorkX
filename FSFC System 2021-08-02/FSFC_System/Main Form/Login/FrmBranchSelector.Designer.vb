<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBranchSelector
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnSelect = New DevComponents.DotNetBar.ButtonX()
        Me.cbxBranchV2 = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.cbxRegion = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cbxProvince = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.cbxBranchV2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxRegion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbxProvince.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(197, 202)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        '
        'btnSelect
        '
        Me.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSelect.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Image = Global.FSFC_System.My.Resources.Resources.Selected
        Me.btnSelect.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSelect.Location = New System.Drawing.Point(84, 202)
        Me.btnSelect.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(107, 30)
        Me.btnSelect.TabIndex = 15
        Me.btnSelect.Text = "Select"
        '
        'cbxBranchV2
        '
        Me.cbxBranchV2.Location = New System.Drawing.Point(84, 77)
        Me.cbxBranchV2.Name = "cbxBranchV2"
        Me.cbxBranchV2.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchV2.Properties.Appearance.Options.UseFont = True
        Me.cbxBranchV2.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchV2.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbxBranchV2.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchV2.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbxBranchV2.Properties.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchV2.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbxBranchV2.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxBranchV2.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbxBranchV2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.Options.UseFont = True
        Me.cbxBranchV2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.cbxBranchV2.Properties.DropDownRows = 15
        Me.cbxBranchV2.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cbxBranchV2.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbxBranchV2.Properties.PopupSizeable = False
        Me.cbxBranchV2.Size = New System.Drawing.Size(581, 26)
        Me.cbxBranchV2.TabIndex = 5
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(0, 76)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(78, 25)
        Me.LabelX4.TabIndex = 46
        Me.LabelX4.Text = "Branch : "
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.White
        Me.LabelX1.Location = New System.Drawing.Point(84, 107)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(581, 23)
        Me.LabelX1.TabIndex = 1791
        Me.LabelX1.Text = "Filter"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.LabelX2.Location = New System.Drawing.Point(0, 135)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(78, 25)
        Me.LabelX2.TabIndex = 1793
        Me.LabelX2.Text = "Region :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxRegion
        '
        Me.cbxRegion.Location = New System.Drawing.Point(84, 136)
        Me.cbxRegion.Name = "cbxRegion"
        Me.cbxRegion.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRegion.Properties.Appearance.Options.UseFont = True
        Me.cbxRegion.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRegion.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbxRegion.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRegion.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbxRegion.Properties.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRegion.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbxRegion.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxRegion.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbxRegion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        SerializableAppearanceObject2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject2.Options.UseFont = True
        Me.cbxRegion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.cbxRegion.Properties.DropDownRows = 15
        Me.cbxRegion.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cbxRegion.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbxRegion.Properties.PopupSizeable = False
        Me.cbxRegion.Size = New System.Drawing.Size(581, 26)
        Me.cbxRegion.TabIndex = 10
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
        Me.LabelX3.Location = New System.Drawing.Point(0, 167)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(78, 25)
        Me.LabelX3.TabIndex = 1795
        Me.LabelX3.Text = "Province :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxProvince
        '
        Me.cbxProvince.Location = New System.Drawing.Point(84, 168)
        Me.cbxProvince.Name = "cbxProvince"
        Me.cbxProvince.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProvince.Properties.Appearance.Options.UseFont = True
        Me.cbxProvince.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProvince.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cbxProvince.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProvince.Properties.AppearanceDropDown.Options.UseFont = True
        Me.cbxProvince.Properties.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProvince.Properties.AppearanceFocused.Options.UseFont = True
        Me.cbxProvince.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxProvince.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cbxProvince.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        SerializableAppearanceObject3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject3.Options.UseFont = True
        Me.cbxProvince.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "", Nothing, Nothing, True)})
        Me.cbxProvince.Properties.DropDownRows = 13
        Me.cbxProvince.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.cbxProvince.Properties.LookAndFeel.UseDefaultLookAndFeel = False
        Me.cbxProvince.Properties.PopupSizeable = False
        Me.cbxProvince.Size = New System.Drawing.Size(581, 26)
        Me.cbxProvince.TabIndex = 15
        '
        'PictureEdit1
        '
        Me.PictureEdit1.Location = New System.Drawing.Point(0, 0)
        Me.PictureEdit1.Margin = New System.Windows.Forms.Padding(3, 9, 3, 9)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.PictureEdit1.Properties.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.PictureEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureEdit1.Properties.Appearance.Options.UseFont = True
        Me.PictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(263, 64)
        Me.PictureEdit1.TabIndex = 1796
        '
        'FrmBranchSelector
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.cbxProvince)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.cbxRegion)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.cbxBranchV2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBranchSelector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.cbxBranchV2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxRegion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbxProvince.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSelect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbxBranchV2 As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxRegion As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxProvince As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
End Class
