<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPerformanceReportDetails
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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblTitle = New DevComponents.DotNetBar.LabelX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.PanelEx3 = New DevComponents.DotNetBar.PanelEx()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrint = New DevComponents.DotNetBar.ButtonX()
        Me.ContextMenuBar3 = New DevComponents.DotNetBar.ContextMenuBar()
        Me.ButtonItem5 = New DevComponents.DotNetBar.ButtonItem()
        Me.iLedger = New DevComponents.DotNetBar.ButtonItem()
        Me.iSOA = New DevComponents.DotNetBar.ButtonItem()
        Me.btnLogs = New DevComponents.DotNetBar.ButtonX()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx3.SuspendLayout()
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.ContextMenuBar3.SetContextMenuEx(Me.GridControl1, Me.ButtonItem5)
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GridControl1.EmbeddedNavigator.Appearance.ForeColor = System.Drawing.Color.Black
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GridControl1.EmbeddedNavigator.Appearance.Options.UseForeColor = True
        Me.GridControl1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 66)
        Me.GridControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GridControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GridControl1.MainView = Me.BandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GridControl1.Size = New System.Drawing.Size(1167, 595)
        Me.GridControl1.TabIndex = 1764
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.BandedGridView1})
        '
        'BandedGridView1
        '
        Me.BandedGridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.ColumnFilterButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = True
        Me.BandedGridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.CustomizationFormHint.Options.UseFont = True
        Me.BandedGridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.DetailTip.Options.UseFont = True
        Me.BandedGridView1.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.Empty.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Empty.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Empty.Options.UseFont = True
        Me.BandedGridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.EvenRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.EvenRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.FilterCloseButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.FilterPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FixedLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FixedLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedCell.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.FocusedRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Italic)
        Me.BandedGridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.FooterPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.GroupButton.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupButton.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupFooter.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.GroupRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.GroupRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.BandedGridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.HideSelectionRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.HorzLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.HorzLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.OddRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.OddRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.OddRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.BandedGridView1.Appearance.Preview.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Preview.ForeColor = System.Drawing.Color.Navy
        Me.BandedGridView1.Appearance.Preview.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Preview.Options.UseFont = True
        Me.BandedGridView1.Appearance.Preview.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.BandedGridView1.Appearance.Row.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.Row.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.Row.Options.UseFont = True
        Me.BandedGridView1.Appearance.Row.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.RowSeparator.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.RowSeparator.Options.UseFont = True
        Me.BandedGridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BandedGridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.SelectedRow.Options.UseForeColor = True
        Me.BandedGridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.TopNewRow.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.TopNewRow.Options.UseFont = True
        Me.BandedGridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.BandedGridView1.Appearance.VertLine.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.VertLine.Options.UseBackColor = True
        Me.BandedGridView1.Appearance.VertLine.Options.UseFont = True
        Me.BandedGridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.BandedGridView1.Appearance.ViewCaption.Options.UseFont = True
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand2, Me.gridBand5, Me.gridBand6})
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn4, Me.BandedGridColumn7, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11, Me.BandedGridColumn3, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn8})
        Me.BandedGridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.BandedGridView1.GridControl = Me.GridControl1
        Me.BandedGridView1.GroupPanelText = "General Requirements"
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsBehavior.Editable = False
        Me.BandedGridView1.OptionsLayout.StoreAllOptions = True
        Me.BandedGridView1.OptionsLayout.StoreAppearance = True
        Me.BandedGridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.BandedGridView1.OptionsSelection.MultiSelect = True
        Me.BandedGridView1.OptionsView.ColumnAutoWidth = False
        Me.BandedGridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.BandedGridView1.OptionsView.EnableAppearanceOddRow = True
        Me.BandedGridView1.OptionsView.ShowAutoFilterRow = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand2.AppearanceHeader.Options.UseFont = True
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Borrower"
        Me.gridBand2.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.RowCount = 2
        Me.gridBand2.VisibleIndex = 0
        Me.gridBand2.Width = 199
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn1.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn1.Caption = " "
        Me.BandedGridColumn1.FieldName = "Borrower"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 199
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand5.AppearanceHeader.Options.UseFont = True
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.gridBand5.Caption = "Details"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn5)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 1
        Me.gridBand5.Width = 665
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn3.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn3.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn3.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn3.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn3.Caption = "PN Number"
        Me.BandedGridColumn3.FieldName = "PN Number"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 100
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn5.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn5.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn5.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn5.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn5.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn5.Caption = "Terms"
        Me.BandedGridColumn5.FieldName = "Terms"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 50
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn6.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn6.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn6.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn6.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn6.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn6.Caption = "Interest Rate"
        Me.BandedGridColumn6.FieldName = "Interest Rate"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn6.Visible = True
        Me.BandedGridColumn6.Width = 85
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn8.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn8.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn8.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn8.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn8.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn8.Caption = "Product"
        Me.BandedGridColumn8.FieldName = "Product"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 110
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn7.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn7.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn7.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn7.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn7.Caption = "Releases"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "Releases"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 100
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn2.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn2.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn2.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn2.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn2.Caption = "Outstanding"
        Me.BandedGridColumn2.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn2.FieldName = "Outstanding"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 105
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn4.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn4.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn4.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn4.Caption = "Past Due"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "Past Due"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 115
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 9.75!, System.Drawing.FontStyle.Bold)
        Me.gridBand6.AppearanceHeader.Options.UseFont = True
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Collections"
        Me.gridBand6.Columns.Add(Me.BandedGridColumn9)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn10)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn11)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 2
        Me.gridBand6.Width = 285
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn9.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn9.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn9.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn9.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn9.Caption = "Principal"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "Principal_4"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 95
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn10.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn10.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn10.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn10.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn10.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn10.Caption = "Interest"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "Interest_4"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 95
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.AppearanceCell.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn11.AppearanceCell.Options.UseFont = True
        Me.BandedGridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn11.AppearanceHeader.Font = New System.Drawing.Font("Roboto", 8.25!)
        Me.BandedGridColumn11.AppearanceHeader.ForeColor = System.Drawing.Color.Black
        Me.BandedGridColumn11.AppearanceHeader.Options.UseFont = True
        Me.BandedGridColumn11.AppearanceHeader.Options.UseForeColor = True
        Me.BandedGridColumn11.Caption = "Penalties"
        Me.BandedGridColumn11.DisplayFormat.FormatString = "n2"
        Me.BandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn11.FieldName = "Penalties_4"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn11.Visible = True
        Me.BandedGridColumn11.Width = 95
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.Appearance.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.Appearance.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceDisabled.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceFocused.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RepositoryItemCheckEdit1.AppearanceReadOnly.Options.UseFont = True
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "True"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "False"
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
        Me.PanelEx1.Size = New System.Drawing.Size(1167, 66)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 1763
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
        Me.lblTitle.Location = New System.Drawing.Point(320, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(591, 26)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "PERFORMANCE REPORT OF "
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
        'PanelEx3
        '
        Me.PanelEx3.AutoScroll = True
        Me.PanelEx3.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx3.Controls.Add(Me.btnCancel)
        Me.PanelEx3.Controls.Add(Me.btnPrint)
        Me.PanelEx3.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelEx3.Location = New System.Drawing.Point(0, 661)
        Me.PanelEx3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PanelEx3.Name = "PanelEx3"
        Me.PanelEx3.Size = New System.Drawing.Size(1167, 38)
        Me.PanelEx3.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx3.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.BackColor2.Color = System.Drawing.Color.White
        Me.PanelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx3.Style.GradientAngle = 90
        Me.PanelEx3.TabIndex = 1765
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = Global.FSFC_System.My.Resources.Resources.Cancel
        Me.btnCancel.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnCancel.Location = New System.Drawing.Point(6, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(107, 30)
        Me.btnCancel.TabIndex = 1005
        Me.btnCancel.Text = "Close"
        '
        'btnPrint
        '
        Me.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnPrint.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Image = Global.FSFC_System.My.Resources.Resources.Print
        Me.btnPrint.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnPrint.Location = New System.Drawing.Point(119, 4)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(107, 30)
        Me.btnPrint.TabIndex = 1010
        Me.btnPrint.Text = "&Print"
        '
        'ContextMenuBar3
        '
        Me.ContextMenuBar3.AntiAlias = True
        Me.ContextMenuBar3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuBar3.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem5})
        Me.ContextMenuBar3.Location = New System.Drawing.Point(526, 337)
        Me.ContextMenuBar3.Name = "ContextMenuBar3"
        Me.ContextMenuBar3.Size = New System.Drawing.Size(114, 25)
        Me.ContextMenuBar3.Stretch = True
        Me.ContextMenuBar3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ContextMenuBar3.TabIndex = 1766
        Me.ContextMenuBar3.TabStop = False
        Me.ContextMenuBar3.Text = "ContextMenuBar3"
        '
        'ButtonItem5
        '
        Me.ButtonItem5.AutoExpandOnClick = True
        Me.ButtonItem5.Name = "ButtonItem5"
        Me.ButtonItem5.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.iLedger, Me.iSOA})
        '
        'iLedger
        '
        Me.iLedger.Name = "iLedger"
        Me.iLedger.Text = "Account Ledger"
        '
        'iSOA
        '
        Me.iSOA.Name = "iSOA"
        Me.iSOA.Text = "Statement of Account"
        '
        'btnLogs
        '
        Me.btnLogs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLogs.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.btnLogs.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnLogs.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Image = Global.FSFC_System.My.Resources.Resources.History
        Me.btnLogs.ImageFixedSize = New System.Drawing.Size(32, 32)
        Me.btnLogs.Location = New System.Drawing.Point(1131, 0)
        Me.btnLogs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(36, 66)
        Me.btnLogs.TabIndex = 1033
        Me.btnLogs.Tooltip = "Transaction Logs"
        '
        'FrmPerformanceReportDetails
        '
        Me.Appearance.BackColor = System.Drawing.Color.White
        Me.Appearance.ForeColor = System.Drawing.Color.Black
        Me.Appearance.Options.UseBackColor = True
        Me.Appearance.Options.UseFont = True
        Me.Appearance.Options.UseForeColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 699)
        Me.ControlBox = False
        Me.Controls.Add(Me.ContextMenuBar3)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.PanelEx3)
        Me.Controls.Add(Me.PanelEx1)
        Me.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmPerformanceReportDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx3.ResumeLayout(False)
        CType(Me.ContextMenuBar3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblTitle As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents PanelEx3 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrint As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents ContextMenuBar3 As DevComponents.DotNetBar.ContextMenuBar
    Friend WithEvents ButtonItem5 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iLedger As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents iSOA As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents btnLogs As DevComponents.DotNetBar.ButtonX
End Class
