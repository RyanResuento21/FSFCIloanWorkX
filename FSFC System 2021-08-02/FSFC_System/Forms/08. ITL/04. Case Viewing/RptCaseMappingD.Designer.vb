<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptCaseMappingD
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblAmount_T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_C = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_C = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_B = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_A = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_A = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranch = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel22 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblAccount_TT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_TT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblNoT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblBranchT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_AT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_AT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_BT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_BT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount_CT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAmount_CT = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAmount_T, Me.lblAccount_T, Me.lblAmount_C, Me.lblAccount_C, Me.lblAmount_B, Me.lblAccount_B, Me.lblAccount_A, Me.lblAmount_A, Me.lblBranch, Me.lblNo})
        Me.Detail.HeightF = 20.00001!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblAmount_T
        '
        Me.lblAmount_T.BackColor = System.Drawing.Color.White
        Me.lblAmount_T.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_T.CanGrow = False
        Me.lblAmount_T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_T.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_T.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 0.00000667572!)
        Me.lblAmount_T.Name = "lblAmount_T"
        Me.lblAmount_T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_T.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_T.StylePriority.UseBackColor = False
        Me.lblAmount_T.StylePriority.UseBorderColor = False
        Me.lblAmount_T.StylePriority.UseBorders = False
        Me.lblAmount_T.StylePriority.UseFont = False
        Me.lblAmount_T.StylePriority.UseForeColor = False
        Me.lblAmount_T.StylePriority.UseTextAlignment = False
        Me.lblAmount_T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount_T
        '
        Me.lblAccount_T.BackColor = System.Drawing.Color.White
        Me.lblAccount_T.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_T.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_T.CanGrow = False
        Me.lblAccount_T.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_T.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_T.LocationFloat = New DevExpress.Utils.PointFloat(745.0!, 0.00000667572!)
        Me.lblAccount_T.Name = "lblAccount_T"
        Me.lblAccount_T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_T.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblAccount_T.StylePriority.UseBackColor = False
        Me.lblAccount_T.StylePriority.UseBorderColor = False
        Me.lblAccount_T.StylePriority.UseBorders = False
        Me.lblAccount_T.StylePriority.UseFont = False
        Me.lblAccount_T.StylePriority.UseForeColor = False
        Me.lblAccount_T.StylePriority.UseTextAlignment = False
        Me.lblAccount_T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_C
        '
        Me.lblAmount_C.BackColor = System.Drawing.Color.White
        Me.lblAmount_C.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_C.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_C.CanGrow = False
        Me.lblAmount_C.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_C.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_C.LocationFloat = New DevExpress.Utils.PointFloat(500.0001!, 0.0!)
        Me.lblAmount_C.Name = "lblAmount_C"
        Me.lblAmount_C.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_C.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_C.StylePriority.UseBackColor = False
        Me.lblAmount_C.StylePriority.UseBorderColor = False
        Me.lblAmount_C.StylePriority.UseBorders = False
        Me.lblAmount_C.StylePriority.UseFont = False
        Me.lblAmount_C.StylePriority.UseForeColor = False
        Me.lblAmount_C.StylePriority.UseTextAlignment = False
        Me.lblAmount_C.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_C.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount_C
        '
        Me.lblAccount_C.BackColor = System.Drawing.Color.White
        Me.lblAccount_C.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_C.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_C.CanGrow = False
        Me.lblAccount_C.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_C.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_C.LocationFloat = New DevExpress.Utils.PointFloat(595.0001!, 0.0!)
        Me.lblAccount_C.Name = "lblAccount_C"
        Me.lblAccount_C.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_C.SizeF = New System.Drawing.SizeF(54.99994!, 20.0!)
        Me.lblAccount_C.StylePriority.UseBackColor = False
        Me.lblAccount_C.StylePriority.UseBorderColor = False
        Me.lblAccount_C.StylePriority.UseBorders = False
        Me.lblAccount_C.StylePriority.UseFont = False
        Me.lblAccount_C.StylePriority.UseForeColor = False
        Me.lblAccount_C.StylePriority.UseTextAlignment = False
        Me.lblAccount_C.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_B
        '
        Me.lblAmount_B.BackColor = System.Drawing.Color.White
        Me.lblAmount_B.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_B.CanGrow = False
        Me.lblAmount_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_B.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_B.LocationFloat = New DevExpress.Utils.PointFloat(350.0001!, 0.0!)
        Me.lblAmount_B.Name = "lblAmount_B"
        Me.lblAmount_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_B.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_B.StylePriority.UseBackColor = False
        Me.lblAmount_B.StylePriority.UseBorderColor = False
        Me.lblAmount_B.StylePriority.UseBorders = False
        Me.lblAmount_B.StylePriority.UseFont = False
        Me.lblAmount_B.StylePriority.UseForeColor = False
        Me.lblAmount_B.StylePriority.UseTextAlignment = False
        Me.lblAmount_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_B.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount_B
        '
        Me.lblAccount_B.BackColor = System.Drawing.Color.White
        Me.lblAccount_B.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_B.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_B.CanGrow = False
        Me.lblAccount_B.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_B.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_B.LocationFloat = New DevExpress.Utils.PointFloat(445.0001!, 0.0!)
        Me.lblAccount_B.Name = "lblAccount_B"
        Me.lblAccount_B.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_B.SizeF = New System.Drawing.SizeF(54.99997!, 20.0!)
        Me.lblAccount_B.StylePriority.UseBackColor = False
        Me.lblAccount_B.StylePriority.UseBorderColor = False
        Me.lblAccount_B.StylePriority.UseBorders = False
        Me.lblAccount_B.StylePriority.UseFont = False
        Me.lblAccount_B.StylePriority.UseForeColor = False
        Me.lblAccount_B.StylePriority.UseTextAlignment = False
        Me.lblAccount_B.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccount_A
        '
        Me.lblAccount_A.BackColor = System.Drawing.Color.White
        Me.lblAccount_A.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_A.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_A.CanGrow = False
        Me.lblAccount_A.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_A.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_A.LocationFloat = New DevExpress.Utils.PointFloat(295.0001!, 0.0!)
        Me.lblAccount_A.Name = "lblAccount_A"
        Me.lblAccount_A.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_A.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblAccount_A.StylePriority.UseBackColor = False
        Me.lblAccount_A.StylePriority.UseBorderColor = False
        Me.lblAccount_A.StylePriority.UseBorders = False
        Me.lblAccount_A.StylePriority.UseFont = False
        Me.lblAccount_A.StylePriority.UseForeColor = False
        Me.lblAccount_A.StylePriority.UseTextAlignment = False
        Me.lblAccount_A.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_A
        '
        Me.lblAmount_A.BackColor = System.Drawing.Color.White
        Me.lblAmount_A.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_A.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_A.CanGrow = False
        Me.lblAmount_A.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_A.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_A.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0.0!)
        Me.lblAmount_A.Name = "lblAmount_A"
        Me.lblAmount_A.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_A.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_A.StylePriority.UseBackColor = False
        Me.lblAmount_A.StylePriority.UseBorderColor = False
        Me.lblAmount_A.StylePriority.UseBorders = False
        Me.lblAmount_A.StylePriority.UseFont = False
        Me.lblAmount_A.StylePriority.UseForeColor = False
        Me.lblAmount_A.StylePriority.UseTextAlignment = False
        Me.lblAmount_A.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_A.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblBranch
        '
        Me.lblBranch.BackColor = System.Drawing.Color.White
        Me.lblBranch.BorderColor = System.Drawing.Color.Black
        Me.lblBranch.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBranch.CanGrow = False
        Me.lblBranch.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranch.ForeColor = System.Drawing.Color.Black
        Me.lblBranch.LocationFloat = New DevExpress.Utils.PointFloat(24.99997!, 0.0!)
        Me.lblBranch.Name = "lblBranch"
        Me.lblBranch.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranch.SizeF = New System.Drawing.SizeF(175.0!, 20.0!)
        Me.lblBranch.StylePriority.UseBackColor = False
        Me.lblBranch.StylePriority.UseBorderColor = False
        Me.lblBranch.StylePriority.UseBorders = False
        Me.lblBranch.StylePriority.UseFont = False
        Me.lblBranch.StylePriority.UseForeColor = False
        Me.lblBranch.StylePriority.UseTextAlignment = False
        Me.lblBranch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblNo
        '
        Me.lblNo.BackColor = System.Drawing.Color.White
        Me.lblNo.BorderColor = System.Drawing.Color.Black
        Me.lblNo.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNo.CanGrow = False
        Me.lblNo.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNo.ForeColor = System.Drawing.Color.Black
        Me.lblNo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblNo.Name = "lblNo"
        Me.lblNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNo.SizeF = New System.Drawing.SizeF(25.0!, 20.0!)
        Me.lblNo.StylePriority.UseBackColor = False
        Me.lblNo.StylePriority.UseBorderColor = False
        Me.lblNo.StylePriority.UseBorders = False
        Me.lblNo.StylePriority.UseFont = False
        Me.lblNo.StylePriority.UseForeColor = False
        Me.lblNo.StylePriority.UseTextAlignment = False
        Me.lblNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 25.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 25.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblTitle, Me.XrLabel13, Me.XrLabel14, Me.XrLabel11, Me.XrLabel12, Me.XrLabel9, Me.XrLabel10, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.lblAccountH, Me.XrLabel1, Me.XrLabel21, Me.XrLabel22, Me.XrLabel8})
        Me.PageHeader.HeightF = 65.00003!
        Me.PageHeader.Name = "PageHeader"
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.White
        Me.lblTitle.BorderColor = System.Drawing.Color.Black
        Me.lblTitle.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblTitle.CanGrow = False
        Me.lblTitle.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTitle.SizeF = New System.Drawing.SizeF(799.9998!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Case Viewing"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel13
        '
        Me.XrLabel13.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel13.BorderColor = System.Drawing.Color.Black
        Me.XrLabel13.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel13.CanGrow = False
        Me.XrLabel13.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel13.ForeColor = System.Drawing.Color.White
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(595.0!, 45.0!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.XrLabel13.StylePriority.UseBackColor = False
        Me.XrLabel13.StylePriority.UseBorderColor = False
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.StylePriority.UseFont = False
        Me.XrLabel13.StylePriority.UseForeColor = False
        Me.XrLabel13.StylePriority.UseTextAlignment = False
        Me.XrLabel13.Text = "Account"
        Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel14
        '
        Me.XrLabel14.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel14.BorderColor = System.Drawing.Color.Black
        Me.XrLabel14.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.CanGrow = False
        Me.XrLabel14.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel14.ForeColor = System.Drawing.Color.White
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 45.0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.XrLabel14.StylePriority.UseBackColor = False
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseFont = False
        Me.XrLabel14.StylePriority.UseForeColor = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Amount"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel11
        '
        Me.XrLabel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel11.BorderColor = System.Drawing.Color.Black
        Me.XrLabel11.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel11.CanGrow = False
        Me.XrLabel11.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel11.ForeColor = System.Drawing.Color.White
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(445.0!, 45.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.XrLabel11.StylePriority.UseBackColor = False
        Me.XrLabel11.StylePriority.UseBorderColor = False
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseForeColor = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Account"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel12
        '
        Me.XrLabel12.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel12.BorderColor = System.Drawing.Color.Black
        Me.XrLabel12.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel12.CanGrow = False
        Me.XrLabel12.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel12.ForeColor = System.Drawing.Color.White
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 45.0!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.XrLabel12.StylePriority.UseBackColor = False
        Me.XrLabel12.StylePriority.UseBorderColor = False
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseForeColor = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = "Amount"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel9
        '
        Me.XrLabel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel9.BorderColor = System.Drawing.Color.Black
        Me.XrLabel9.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel9.CanGrow = False
        Me.XrLabel9.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.ForeColor = System.Drawing.Color.White
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 45.0!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.XrLabel9.StylePriority.UseBackColor = False
        Me.XrLabel9.StylePriority.UseBorderColor = False
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseForeColor = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = "Amount"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(295.0!, 45.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Account"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.White
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 25.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "C. For Levy/Attachment of Real Pro"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel3.BorderColor = System.Drawing.Color.Black
        Me.XrLabel3.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel3.CanGrow = False
        Me.XrLabel3.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.ForeColor = System.Drawing.Color.White
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 25.0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel3.StylePriority.UseBackColor = False
        Me.XrLabel3.StylePriority.UseBorderColor = False
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseForeColor = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "B. For Follow Up"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel2
        '
        Me.XrLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel2.BorderColor = System.Drawing.Color.Black
        Me.XrLabel2.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel2.CanGrow = False
        Me.XrLabel2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.ForeColor = System.Drawing.Color.White
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 25.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(175.0!, 40.0!)
        Me.XrLabel2.StylePriority.UseBackColor = False
        Me.XrLabel2.StylePriority.UseBorderColor = False
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseForeColor = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Branch"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccountH
        '
        Me.lblAccountH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblAccountH.BorderColor = System.Drawing.Color.Black
        Me.lblAccountH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccountH.CanGrow = False
        Me.lblAccountH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountH.ForeColor = System.Drawing.Color.White
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(25.0!, 40.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "No"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.White
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 25.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "A. Scheduled for Execution"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel21
        '
        Me.XrLabel21.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel21.BorderColor = System.Drawing.Color.Black
        Me.XrLabel21.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel21.CanGrow = False
        Me.XrLabel21.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel21.ForeColor = System.Drawing.Color.White
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(745.0!, 44.99999!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.XrLabel21.StylePriority.UseBackColor = False
        Me.XrLabel21.StylePriority.UseBorderColor = False
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.StylePriority.UseFont = False
        Me.XrLabel21.StylePriority.UseForeColor = False
        Me.XrLabel21.StylePriority.UseTextAlignment = False
        Me.XrLabel21.Text = "Account"
        Me.XrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel22
        '
        Me.XrLabel22.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel22.BorderColor = System.Drawing.Color.Black
        Me.XrLabel22.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel22.CanGrow = False
        Me.XrLabel22.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel22.ForeColor = System.Drawing.Color.White
        Me.XrLabel22.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 45.00003!)
        Me.XrLabel22.Name = "XrLabel22"
        Me.XrLabel22.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel22.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.XrLabel22.StylePriority.UseBackColor = False
        Me.XrLabel22.StylePriority.UseBorderColor = False
        Me.XrLabel22.StylePriority.UseBorders = False
        Me.XrLabel22.StylePriority.UseFont = False
        Me.XrLabel22.StylePriority.UseForeColor = False
        Me.XrLabel22.StylePriority.UseTextAlignment = False
        Me.XrLabel22.Text = "Amount"
        Me.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 25.00002!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(150.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "T O T A L"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblAccount_TT, Me.lblAmount_TT, Me.lblNoT, Me.lblBranchT, Me.lblAmount_AT, Me.lblAccount_AT, Me.lblAccount_BT, Me.lblAmount_BT, Me.lblAccount_CT, Me.lblAmount_CT})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblAccount_TT
        '
        Me.lblAccount_TT.BackColor = System.Drawing.Color.White
        Me.lblAccount_TT.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_TT.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_TT.CanGrow = False
        Me.lblAccount_TT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_TT.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_TT.LocationFloat = New DevExpress.Utils.PointFloat(744.9999!, 0.0!)
        Me.lblAccount_TT.Name = "lblAccount_TT"
        Me.lblAccount_TT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_TT.SizeF = New System.Drawing.SizeF(54.99994!, 20.0!)
        Me.lblAccount_TT.StylePriority.UseBackColor = False
        Me.lblAccount_TT.StylePriority.UseBorderColor = False
        Me.lblAccount_TT.StylePriority.UseBorders = False
        Me.lblAccount_TT.StylePriority.UseFont = False
        Me.lblAccount_TT.StylePriority.UseForeColor = False
        Me.lblAccount_TT.StylePriority.UseTextAlignment = False
        Me.lblAccount_TT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_TT
        '
        Me.lblAmount_TT.BackColor = System.Drawing.Color.White
        Me.lblAmount_TT.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_TT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_TT.CanGrow = False
        Me.lblAmount_TT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_TT.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_TT.LocationFloat = New DevExpress.Utils.PointFloat(649.9999!, 0.0!)
        Me.lblAmount_TT.Name = "lblAmount_TT"
        Me.lblAmount_TT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_TT.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_TT.StylePriority.UseBackColor = False
        Me.lblAmount_TT.StylePriority.UseBorderColor = False
        Me.lblAmount_TT.StylePriority.UseBorders = False
        Me.lblAmount_TT.StylePriority.UseFont = False
        Me.lblAmount_TT.StylePriority.UseForeColor = False
        Me.lblAmount_TT.StylePriority.UseTextAlignment = False
        Me.lblAmount_TT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_TT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblNoT
        '
        Me.lblNoT.BackColor = System.Drawing.Color.White
        Me.lblNoT.BorderColor = System.Drawing.Color.Black
        Me.lblNoT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblNoT.CanGrow = False
        Me.lblNoT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoT.ForeColor = System.Drawing.Color.Black
        Me.lblNoT.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblNoT.Name = "lblNoT"
        Me.lblNoT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblNoT.SizeF = New System.Drawing.SizeF(25.0!, 20.0!)
        Me.lblNoT.StylePriority.UseBackColor = False
        Me.lblNoT.StylePriority.UseBorderColor = False
        Me.lblNoT.StylePriority.UseBorders = False
        Me.lblNoT.StylePriority.UseFont = False
        Me.lblNoT.StylePriority.UseForeColor = False
        Me.lblNoT.StylePriority.UseTextAlignment = False
        Me.lblNoT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblBranchT
        '
        Me.lblBranchT.BackColor = System.Drawing.Color.White
        Me.lblBranchT.BorderColor = System.Drawing.Color.Black
        Me.lblBranchT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblBranchT.CanGrow = False
        Me.lblBranchT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBranchT.ForeColor = System.Drawing.Color.Black
        Me.lblBranchT.LocationFloat = New DevExpress.Utils.PointFloat(24.99997!, 0.0!)
        Me.lblBranchT.Name = "lblBranchT"
        Me.lblBranchT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblBranchT.SizeF = New System.Drawing.SizeF(175.0!, 20.0!)
        Me.lblBranchT.StylePriority.UseBackColor = False
        Me.lblBranchT.StylePriority.UseBorderColor = False
        Me.lblBranchT.StylePriority.UseBorders = False
        Me.lblBranchT.StylePriority.UseFont = False
        Me.lblBranchT.StylePriority.UseForeColor = False
        Me.lblBranchT.StylePriority.UseTextAlignment = False
        Me.lblBranchT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblAmount_AT
        '
        Me.lblAmount_AT.BackColor = System.Drawing.Color.White
        Me.lblAmount_AT.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_AT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_AT.CanGrow = False
        Me.lblAmount_AT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_AT.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_AT.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0.0!)
        Me.lblAmount_AT.Name = "lblAmount_AT"
        Me.lblAmount_AT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_AT.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_AT.StylePriority.UseBackColor = False
        Me.lblAmount_AT.StylePriority.UseBorderColor = False
        Me.lblAmount_AT.StylePriority.UseBorders = False
        Me.lblAmount_AT.StylePriority.UseFont = False
        Me.lblAmount_AT.StylePriority.UseForeColor = False
        Me.lblAmount_AT.StylePriority.UseTextAlignment = False
        Me.lblAmount_AT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_AT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount_AT
        '
        Me.lblAccount_AT.BackColor = System.Drawing.Color.White
        Me.lblAccount_AT.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_AT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_AT.CanGrow = False
        Me.lblAccount_AT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_AT.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_AT.LocationFloat = New DevExpress.Utils.PointFloat(295.0!, 0.0!)
        Me.lblAccount_AT.Name = "lblAccount_AT"
        Me.lblAccount_AT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_AT.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblAccount_AT.StylePriority.UseBackColor = False
        Me.lblAccount_AT.StylePriority.UseBorderColor = False
        Me.lblAccount_AT.StylePriority.UseBorders = False
        Me.lblAccount_AT.StylePriority.UseFont = False
        Me.lblAccount_AT.StylePriority.UseForeColor = False
        Me.lblAccount_AT.StylePriority.UseTextAlignment = False
        Me.lblAccount_AT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAccount_BT
        '
        Me.lblAccount_BT.BackColor = System.Drawing.Color.White
        Me.lblAccount_BT.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_BT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_BT.CanGrow = False
        Me.lblAccount_BT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_BT.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_BT.LocationFloat = New DevExpress.Utils.PointFloat(445.0!, 0.0!)
        Me.lblAccount_BT.Name = "lblAccount_BT"
        Me.lblAccount_BT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_BT.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblAccount_BT.StylePriority.UseBackColor = False
        Me.lblAccount_BT.StylePriority.UseBorderColor = False
        Me.lblAccount_BT.StylePriority.UseBorders = False
        Me.lblAccount_BT.StylePriority.UseFont = False
        Me.lblAccount_BT.StylePriority.UseForeColor = False
        Me.lblAccount_BT.StylePriority.UseTextAlignment = False
        Me.lblAccount_BT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_BT
        '
        Me.lblAmount_BT.BackColor = System.Drawing.Color.White
        Me.lblAmount_BT.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_BT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_BT.CanGrow = False
        Me.lblAmount_BT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_BT.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_BT.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 0.0!)
        Me.lblAmount_BT.Name = "lblAmount_BT"
        Me.lblAmount_BT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_BT.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_BT.StylePriority.UseBackColor = False
        Me.lblAmount_BT.StylePriority.UseBorderColor = False
        Me.lblAmount_BT.StylePriority.UseBorders = False
        Me.lblAmount_BT.StylePriority.UseFont = False
        Me.lblAmount_BT.StylePriority.UseForeColor = False
        Me.lblAmount_BT.StylePriority.UseTextAlignment = False
        Me.lblAmount_BT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_BT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount_CT
        '
        Me.lblAccount_CT.BackColor = System.Drawing.Color.White
        Me.lblAccount_CT.BorderColor = System.Drawing.Color.Black
        Me.lblAccount_CT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount_CT.CanGrow = False
        Me.lblAccount_CT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount_CT.ForeColor = System.Drawing.Color.Black
        Me.lblAccount_CT.LocationFloat = New DevExpress.Utils.PointFloat(594.9999!, 0.0!)
        Me.lblAccount_CT.Name = "lblAccount_CT"
        Me.lblAccount_CT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount_CT.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
        Me.lblAccount_CT.StylePriority.UseBackColor = False
        Me.lblAccount_CT.StylePriority.UseBorderColor = False
        Me.lblAccount_CT.StylePriority.UseBorders = False
        Me.lblAccount_CT.StylePriority.UseFont = False
        Me.lblAccount_CT.StylePriority.UseForeColor = False
        Me.lblAccount_CT.StylePriority.UseTextAlignment = False
        Me.lblAccount_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAmount_CT
        '
        Me.lblAmount_CT.BackColor = System.Drawing.Color.White
        Me.lblAmount_CT.BorderColor = System.Drawing.Color.Black
        Me.lblAmount_CT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAmount_CT.CanGrow = False
        Me.lblAmount_CT.Font = New System.Drawing.Font("Century Gothic", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount_CT.ForeColor = System.Drawing.Color.Black
        Me.lblAmount_CT.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 0.0!)
        Me.lblAmount_CT.Name = "lblAmount_CT"
        Me.lblAmount_CT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAmount_CT.SizeF = New System.Drawing.SizeF(95.0!, 20.0!)
        Me.lblAmount_CT.StylePriority.UseBackColor = False
        Me.lblAmount_CT.StylePriority.UseBorderColor = False
        Me.lblAmount_CT.StylePriority.UseBorders = False
        Me.lblAmount_CT.StylePriority.UseFont = False
        Me.lblAmount_CT.StylePriority.UseForeColor = False
        Me.lblAmount_CT.StylePriority.UseTextAlignment = False
        Me.lblAmount_CT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblAmount_CT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo2, Me.XrPageInfo1})
        Me.PageFooter.HeightF = 20.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrPageInfo2
        '
        Me.XrPageInfo2.BackColor = System.Drawing.Color.White
        Me.XrPageInfo2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo2.Format = "{0:dddd, MMMM d, yyyy h:mm tt}"
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(399.9998!, 0.0!)
        Me.XrPageInfo2.Name = "XrPageInfo2"
        Me.XrPageInfo2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo2.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo2.StylePriority.UseBackColor = False
        Me.XrPageInfo2.StylePriority.UseFont = False
        Me.XrPageInfo2.StylePriority.UseTextAlignment = False
        Me.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BackColor = System.Drawing.Color.White
        Me.XrPageInfo1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.XrPageInfo1.StylePriority.UseBackColor = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'rptCaseMapping_D
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel22 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents lblAmount_C As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_C As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_B As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_A As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_A As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranch As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblNoT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblBranchT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_AT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_AT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_BT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_BT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_CT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_CT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount_TT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAmount_TT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
