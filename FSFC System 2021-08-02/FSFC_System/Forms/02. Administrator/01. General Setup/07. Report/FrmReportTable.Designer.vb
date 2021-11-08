<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReportTable
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
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl4.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl4.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl4.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl4.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl4.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.LookAndFeel.SkinName = "The Asphalt World"
        Me.GridControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl4.MainView = Me.GridView4
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4})
        Me.GridControl4.Size = New System.Drawing.Size(1174, 672)
        Me.GridControl4.TabIndex = 1683
        Me.GridControl4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.GridView4.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.GridView4.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.GridView4.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.GridView4.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.GridView4.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.GridView4.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.GridView4.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.GridView4.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.GridView4.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.DetailTip.Options.UseFont = True
        Me.GridView4.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridView4.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.GridView4.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.Empty.Options.UseBackColor = True
        Me.GridView4.Appearance.Empty.Options.UseFont = True
        Me.GridView4.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView4.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView4.Appearance.EvenRow.Options.UseFont = True
        Me.GridView4.Appearance.EvenRow.Options.UseForeColor = True
        Me.GridView4.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.GridView4.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.GridView4.Appearance.FilterCloseButton.Options.UseFont = True
        Me.GridView4.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.GridView4.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView4.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView4.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FilterPanel.Options.UseBackColor = True
        Me.GridView4.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.GridView4.Appearance.FilterPanel.Options.UseFont = True
        Me.GridView4.Appearance.FilterPanel.Options.UseForeColor = True
        Me.GridView4.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridView4.Appearance.FixedLine.Options.UseFont = True
        Me.GridView4.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView4.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedCell.Options.UseFont = True
        Me.GridView4.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridView4.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView4.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.FocusedRow.Options.UseFont = True
        Me.GridView4.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridView4.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.GridView4.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.FooterPanel.Options.UseBackColor = True
        Me.GridView4.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.GridView4.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView4.Appearance.FooterPanel.Options.UseForeColor = True
        Me.GridView4.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.GroupButton.Options.UseBackColor = True
        Me.GridView4.Appearance.GroupButton.Options.UseBorderColor = True
        Me.GridView4.Appearance.GroupButton.Options.UseFont = True
        Me.GridView4.Appearance.GroupButton.Options.UseForeColor = True
        Me.GridView4.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.GroupFooter.Options.UseBackColor = True
        Me.GridView4.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.GridView4.Appearance.GroupFooter.Options.UseFont = True
        Me.GridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.GridView4.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridView4.Appearance.GroupPanel.Options.UseFont = True
        Me.GridView4.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridView4.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridView4.Appearance.GroupRow.Options.UseFont = True
        Me.GridView4.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GridView4.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.GridView4.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.GridView4.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.GridView4.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView4.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.GridView4.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView4.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView4.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView4.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.GridView4.Appearance.HideSelectionRow.Options.UseFont = True
        Me.GridView4.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.GridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.HorzLine.Options.UseBackColor = True
        Me.GridView4.Appearance.HorzLine.Options.UseFont = True
        Me.GridView4.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.GridView4.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView4.Appearance.OddRow.Options.UseFont = True
        Me.GridView4.Appearance.OddRow.Options.UseForeColor = True
        Me.GridView4.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GridView4.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.GridView4.Appearance.Preview.Options.UseBackColor = True
        Me.GridView4.Appearance.Preview.Options.UseFont = True
        Me.GridView4.Appearance.Preview.Options.UseForeColor = True
        Me.GridView4.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.GridView4.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.Row.Options.UseBackColor = True
        Me.GridView4.Appearance.Row.Options.UseFont = True
        Me.GridView4.Appearance.Row.Options.UseForeColor = True
        Me.GridView4.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.GridView4.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.RowSeparator.Options.UseBackColor = True
        Me.GridView4.Appearance.RowSeparator.Options.UseFont = True
        Me.GridView4.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.GridView4.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.GridView4.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridView4.Appearance.SelectedRow.Options.UseFont = True
        Me.GridView4.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridView4.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.GridView4.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.TopNewRow.Options.UseBackColor = True
        Me.GridView4.Appearance.TopNewRow.Options.UseFont = True
        Me.GridView4.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.GridView4.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.VertLine.Options.UseBackColor = True
        Me.GridView4.Appearance.VertLine.Options.UseFont = True
        Me.GridView4.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.GridView4.Appearance.ViewCaption.Options.UseFont = True
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.GridControl = Me.GridControl4
        Me.GridView4.GroupPanelText = "General Requirements"
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.Editable = False
        Me.GridView4.OptionsLayout.StoreAllOptions = True
        Me.GridView4.OptionsLayout.StoreAppearance = True
        Me.GridView4.OptionsPrint.AutoWidth = False
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.EnableAppearanceEvenRow = True
        Me.GridView4.OptionsView.EnableAppearanceOddRow = True
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        Me.GridView4.OptionsView.ShowGroupPanel = False
        Me.GridView4.PaintStyleName = "Style3D"
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit4.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        Me.RepositoryItemCheckEdit4.ValueChecked = "True"
        Me.RepositoryItemCheckEdit4.ValueUnchecked = "False"
        '
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 672)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1174, 37)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1684
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
        Me.btnCancel.TabIndex = 1010
        Me.btnCancel.Text = "Close"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(5, 4)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1005
        Me.btnPrint.Text = "&Print"
        '
        'FrmReportTable
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 709)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridControl4)
        Me.Controls.Add(Me.PanelEx3)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmReportTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
End Class
