<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddToNotification
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
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.GridControl13 = New DevExpress.XtraGrid.GridControl()
        Me.GridView13 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn120 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn121 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn122 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn123 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn124 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn125 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn126 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn127 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn128 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn129 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn130 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn141 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEx3.SuspendLayout()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnAdd)
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 357)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1174, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1893
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnAdd.Enabled = False
        Me.btnAdd.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = Global.FSFC_System.My.Resources.Resources.Add
        Me.btnAdd.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnAdd.Location = New System.Drawing.Point(5, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(107, 30)
        Me.btnAdd.TabIndex = 1007
        Me.btnAdd.Text = "&Add"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(118, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1020
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
        Me.PanelEx1.Size = New System.Drawing.Size(1174, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1892
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
        Me.lblTitle.Location = New System.Drawing.Point(372, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(408, 26)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "ADD TO NOTIFICATION"
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
        'GridControl13
        '
        Me.GridControl13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl13.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl13.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl13.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl13.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl13.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridControl13.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl13.Location = New System.Drawing.Point(0, 66)
        Me.GridControl13.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl13.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl13.MainView = Me.GridView13
        Me.GridControl13.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridControl13.Name = "GridControl13"
        Me.GridControl13.Size = New System.Drawing.Size(1174, 291)
        Me.GridControl13.TabIndex = 1894
        Me.GridControl13.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView13})
        '
        'GridView13
        '
        Me.GridView13.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView13.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView13.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView13.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView13.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView13.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView13.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView13.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView13.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView13.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.DetailTip.Options.UseFont = True
        Me.GridView13.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView13.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView13.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.Empty.Options.UseBackColor = True
        Me.GridView13.Appearance.Empty.Options.UseFont = True
        Me.GridView13.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView13.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView13.Appearance.EvenRow.Options.UseFont = True
        Me.GridView13.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView13.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView13.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView13.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView13.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView13.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView13.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView13.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView13.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.GridView13.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView13.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView13.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView13.Appearance.FixedLine.Options.UseFont = True
        Me.GridView13.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView13.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView13.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView13.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView13.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView13.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView13.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView13.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView13.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.GridView13.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView13.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView13.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView13.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView13.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView13.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView13.Appearance.GroupButton.Options.UseFont = True
        Me.GridView13.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView13.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView13.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView13.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView13.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView13.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView13.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView13.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView13.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView13.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView13.Appearance.GroupRow.Options.UseFont = True
        Me.GridView13.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView13.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GridView13.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.GridView13.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView13.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView13.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView13.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView13.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView13.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView13.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView13.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView13.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView13.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView13.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView13.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView13.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView13.Appearance.HorzLine.Options.UseFont = True
        Me.GridView13.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView13.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView13.Appearance.OddRow.Options.UseFont = True
        Me.GridView13.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView13.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GridView13.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.GridView13.Appearance.Preview.Options.UseBackColor = True
        Me.GridView13.Appearance.Preview.Options.UseFont = True
        Me.GridView13.Appearance.Preview.Options.UseForeColor = True
        Me.GridView13.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GridView13.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.Row.Options.UseBackColor = True
        Me.GridView13.Appearance.Row.Options.UseFont = True
        Me.GridView13.Appearance.Row.Options.UseForeColor = True
        Me.GridView13.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.GridView13.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView13.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView13.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView13.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView13.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView13.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView13.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView13.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.GridView13.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridView13.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView13.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView13.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView13.Appearance.VertLine.Options.UseFont = True
        Me.GridView13.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView13.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView13.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn120, Me.GridColumn121, Me.GridColumn122, Me.GridColumn123, Me.GridColumn124, Me.GridColumn125, Me.GridColumn126, Me.GridColumn127, Me.GridColumn128, Me.GridColumn129, Me.GridColumn130, Me.GridColumn141})
        Me.GridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView13.GridControl = Me.GridControl13
        Me.GridView13.Name = "GridView13"
        Me.GridView13.OptionsBehavior.Editable = False
        Me.GridView13.OptionsLayout.StoreAllOptions = True
        Me.GridView13.OptionsLayout.StoreAppearance = True
        Me.GridView13.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView13.OptionsView.ColumnAutoWidth = False
        Me.GridView13.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView13.OptionsView.EnableAppearanceOddRow = True
        Me.GridView13.OptionsView.ShowAutoFilterRow = True
        Me.GridView13.OptionsView.ShowFooter = True
        Me.GridView13.OptionsView.ShowGroupPanel = False
        Me.GridView13.PaintStyleName = "Style3D"
        '
        'GridColumn120
        '
        Me.GridColumn120.Caption = "ID"
        Me.GridColumn120.FieldName = "ID"
        Me.GridColumn120.Name = "GridColumn120"
        Me.GridColumn120.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        '
        'GridColumn121
        '
        Me.GridColumn121.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn121.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn121.Caption = "Reference Num"
        Me.GridColumn121.FieldName = "Reference Number"
        Me.GridColumn121.Name = "GridColumn121"
        Me.GridColumn121.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn121.Visible = True
        Me.GridColumn121.VisibleIndex = 1
        Me.GridColumn121.Width = 120
        '
        'GridColumn122
        '
        Me.GridColumn122.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn122.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn122.Caption = "Check From"
        Me.GridColumn122.FieldName = "Check From"
        Me.GridColumn122.Name = "GridColumn122"
        Me.GridColumn122.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn122.Visible = True
        Me.GridColumn122.VisibleIndex = 5
        Me.GridColumn122.Width = 100
        '
        'GridColumn123
        '
        Me.GridColumn123.Caption = "Details"
        Me.GridColumn123.FieldName = "Details"
        Me.GridColumn123.Name = "GridColumn123"
        Me.GridColumn123.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn123.Visible = True
        Me.GridColumn123.VisibleIndex = 9
        Me.GridColumn123.Width = 150
        '
        'GridColumn124
        '
        Me.GridColumn124.Caption = "Payee"
        Me.GridColumn124.FieldName = "Payee"
        Me.GridColumn124.Name = "GridColumn124"
        Me.GridColumn124.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn124.Visible = True
        Me.GridColumn124.VisibleIndex = 0
        Me.GridColumn124.Width = 235
        '
        'GridColumn125
        '
        Me.GridColumn125.Caption = "Bank"
        Me.GridColumn125.FieldName = "Bank"
        Me.GridColumn125.Name = "GridColumn125"
        Me.GridColumn125.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn125.Visible = True
        Me.GridColumn125.VisibleIndex = 6
        Me.GridColumn125.Width = 175
        '
        'GridColumn126
        '
        Me.GridColumn126.Caption = "Branch"
        Me.GridColumn126.FieldName = "Branch"
        Me.GridColumn126.Name = "GridColumn126"
        Me.GridColumn126.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn126.Visible = True
        Me.GridColumn126.VisibleIndex = 7
        Me.GridColumn126.Width = 260
        '
        'GridColumn127
        '
        Me.GridColumn127.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn127.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn127.Caption = "Check Number"
        Me.GridColumn127.FieldName = "Check Number"
        Me.GridColumn127.Name = "GridColumn127"
        Me.GridColumn127.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn127.Visible = True
        Me.GridColumn127.VisibleIndex = 4
        Me.GridColumn127.Width = 110
        '
        'GridColumn128
        '
        Me.GridColumn128.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn128.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn128.Caption = "Due Date"
        Me.GridColumn128.FieldName = "Due Date"
        Me.GridColumn128.Name = "GridColumn128"
        Me.GridColumn128.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn128.Visible = True
        Me.GridColumn128.VisibleIndex = 2
        Me.GridColumn128.Width = 100
        '
        'GridColumn129
        '
        Me.GridColumn129.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn129.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn129.Caption = "Amount"
        Me.GridColumn129.DisplayFormat.FormatString = "n2"
        Me.GridColumn129.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn129.FieldName = "Check Amount"
        Me.GridColumn129.Name = "GridColumn129"
        Me.GridColumn129.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn129.Visible = True
        Me.GridColumn129.VisibleIndex = 3
        Me.GridColumn129.Width = 85
        '
        'GridColumn130
        '
        Me.GridColumn130.Caption = "Remarks"
        Me.GridColumn130.FieldName = "Remarks"
        Me.GridColumn130.Name = "GridColumn130"
        Me.GridColumn130.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn130.Visible = True
        Me.GridColumn130.VisibleIndex = 8
        Me.GridColumn130.Width = 350
        '
        'GridColumn141
        '
        Me.GridColumn141.Caption = "Branch"
        Me.GridColumn141.FieldName = "Company Branch"
        Me.GridColumn141.Name = "GridColumn141"
        Me.GridColumn141.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.GridColumn141.Visible = True
        Me.GridColumn141.VisibleIndex = 10
        Me.GridColumn141.Width = 150
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(1138, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmAddToNotification
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 394)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridControl13)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAddToNotification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelEx3.ResumeLayout(False)
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GridControl13 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView13 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn120 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn121 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn122 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn123 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn124 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn125 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn126 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn127 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn128 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn129 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn130 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn141 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
