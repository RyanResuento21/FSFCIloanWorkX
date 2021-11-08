<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAdvanceSearchAppraisal
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
        Me.btnSearch = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.txtKeyword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblTo = New DevComponents.DotNetBar.LabelX()
        Me.lblAge = New DevComponents.DotNetBar.LabelX()
        Me.cbxAppraisedBy = New SergeUtils.EasyCompletionComboBox()
        Me.LabelX155 = New DevComponents.DotNetBar.LabelX()
        Me.iFrom = New DevComponents.Editors.DoubleInput()
        Me.iTo = New DevComponents.Editors.DoubleInput()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnSearch)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 200)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(645, 38)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1060
        '
        'btnSearch
        '
        Me.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnSearch.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.FSFC_System.My.Resources.Resources.Search
        Me.btnSearch.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnSearch.Location = New System.Drawing.Point(3, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 30)
        Me.btnSearch.TabIndex = 1005
        Me.btnSearch.Text = "&Search"
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
        Me.PanelEx1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 7)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(645, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1059
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
        Me.LabelX11.Location = New System.Drawing.Point(278, 20)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(355, 26)
        Me.LabelX11.TabIndex = 6
        Me.LabelX11.Text = "ADVANCED SEARCH"
        Me.LabelX11.TextAlignment = System.Drawing.StringAlignment.Center
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
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(13, 76)
        Me.LabelX17.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(115, 23)
        Me.LabelX17.TabIndex = 1425
        Me.LabelX17.Text = "Keyword :"
        Me.LabelX17.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtKeyword
        '
        '
        '
        '
        Me.txtKeyword.Border.Class = "TextBoxBorder"
        Me.txtKeyword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtKeyword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKeyword.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeyword.Location = New System.Drawing.Point(132, 76)
        Me.txtKeyword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.PreventEnterBeep = True
        Me.txtKeyword.Size = New System.Drawing.Size(434, 23)
        Me.txtKeyword.TabIndex = 1424
        Me.txtKeyword.WatermarkText = "Please fill any keyword to search."
        '
        'lblTo
        '
        Me.lblTo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTo.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTo.Location = New System.Drawing.Point(328, 137)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(42, 23)
        Me.lblTo.TabIndex = 1438
        Me.lblTo.Text = "to"
        Me.lblTo.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblAge
        '
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblAge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAge.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAge.Location = New System.Drawing.Point(10, 137)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(117, 23)
        Me.lblAge.TabIndex = 1437
        Me.lblAge.Text = "Appraised Value :"
        Me.lblAge.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cbxAppraisedBy
        '
        Me.cbxAppraisedBy.DisplayMember = "PREFIX"
        Me.cbxAppraisedBy.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cbxAppraisedBy.FormattingEnabled = True
        Me.cbxAppraisedBy.Items.AddRange(New Object() {"Today", "This Week", "This Month", "This Year", "Range"})
        Me.cbxAppraisedBy.Location = New System.Drawing.Point(132, 106)
        Me.cbxAppraisedBy.Name = "cbxAppraisedBy"
        Me.cbxAppraisedBy.Size = New System.Drawing.Size(434, 25)
        Me.cbxAppraisedBy.TabIndex = 1439
        Me.cbxAppraisedBy.ValueMember = "ID"
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
        Me.LabelX155.Location = New System.Drawing.Point(13, 106)
        Me.LabelX155.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX155.Name = "LabelX155"
        Me.LabelX155.Size = New System.Drawing.Size(113, 23)
        Me.LabelX155.TabIndex = 1440
        Me.LabelX155.Text = "Appraised By :"
        Me.LabelX155.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'iFrom
        '
        '
        '
        '
        Me.iFrom.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iFrom.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iFrom.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iFrom.ForeColor = System.Drawing.Color.Black
        Me.iFrom.Increment = 1.0R
        Me.iFrom.Location = New System.Drawing.Point(132, 137)
        Me.iFrom.MaxValue = 999999999.0R
        Me.iFrom.MinValue = 0.0R
        Me.iFrom.Name = "iFrom"
        Me.iFrom.ShowUpDown = True
        Me.iFrom.Size = New System.Drawing.Size(190, 23)
        Me.iFrom.TabIndex = 1441
        '
        'iTo
        '
        '
        '
        '
        Me.iTo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.iTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iTo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.iTo.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.iTo.ForeColor = System.Drawing.Color.Black
        Me.iTo.Increment = 1.0R
        Me.iTo.Location = New System.Drawing.Point(376, 137)
        Me.iTo.MaxValue = 999999999.0R
        Me.iTo.MinValue = 0.0R
        Me.iTo.Name = "iTo"
        Me.iTo.ShowUpDown = True
        Me.iTo.Size = New System.Drawing.Size(190, 23)
        Me.iTo.TabIndex = 1442
        '
        'FrmAdvanceSearchAppraisal
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 238)
        Me.ControlBox = False
        Me.Controls.Add(Me.iTo)
        Me.Controls.Add(Me.iFrom)
        Me.Controls.Add(Me.cbxAppraisedBy)
        Me.Controls.Add(Me.LabelX155)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.LabelX17)
        Me.Controls.Add(Me.txtKeyword)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAdvanceSearchAppraisal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnSearch As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtKeyword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblTo As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAge As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbxAppraisedBy As SergeUtils.EasyCompletionComboBox
    Friend WithEvents LabelX155 As DevComponents.DotNetBar.LabelX
    Friend WithEvents iFrom As DevComponents.Editors.DoubleInput
    Friend WithEvents iTo As DevComponents.Editors.DoubleInput
End Class
