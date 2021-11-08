<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class RptTrialBalance
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.lblDifference = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancial = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblCode = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialH2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAccountH = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.lblDifference_T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTotalH = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblFinancialT = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_1T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_2T = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblActual_3T = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.lblAsOf = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDifference, Me.lblActual_3, Me.lblActual_2, Me.lblActual_1, Me.lblFinancial, Me.lblAccount, Me.lblCode})
        Me.Detail.HeightF = 20.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'lblDifference
        '
        Me.lblDifference.BackColor = System.Drawing.Color.White
        Me.lblDifference.BorderColor = System.Drawing.Color.Black
        Me.lblDifference.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDifference.CanGrow = False
        Me.lblDifference.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDifference.ForeColor = System.Drawing.Color.Black
        Me.lblDifference.LocationFloat = New DevExpress.Utils.PointFloat(719.9999!, 0.0!)
        Me.lblDifference.Name = "lblDifference"
        Me.lblDifference.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDifference.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblDifference.StylePriority.UseBackColor = False
        Me.lblDifference.StylePriority.UseBorderColor = False
        Me.lblDifference.StylePriority.UseBorders = False
        Me.lblDifference.StylePriority.UseFont = False
        Me.lblDifference.StylePriority.UseForeColor = False
        Me.lblDifference.StylePriority.UseTextAlignment = False
        Me.lblDifference.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDifference.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_3
        '
        Me.lblActual_3.BackColor = System.Drawing.Color.White
        Me.lblActual_3.BorderColor = System.Drawing.Color.Black
        Me.lblActual_3.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_3.CanGrow = False
        Me.lblActual_3.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_3.ForeColor = System.Drawing.Color.Black
        Me.lblActual_3.LocationFloat = New DevExpress.Utils.PointFloat(640.0!, 0.0!)
        Me.lblActual_3.Name = "lblActual_3"
        Me.lblActual_3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_3.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_3.StylePriority.UseBackColor = False
        Me.lblActual_3.StylePriority.UseBorderColor = False
        Me.lblActual_3.StylePriority.UseBorders = False
        Me.lblActual_3.StylePriority.UseFont = False
        Me.lblActual_3.StylePriority.UseForeColor = False
        Me.lblActual_3.StylePriority.UseTextAlignment = False
        Me.lblActual_3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_3.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_2
        '
        Me.lblActual_2.BackColor = System.Drawing.Color.White
        Me.lblActual_2.BorderColor = System.Drawing.Color.Black
        Me.lblActual_2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_2.CanGrow = False
        Me.lblActual_2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_2.ForeColor = System.Drawing.Color.Black
        Me.lblActual_2.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 0.0!)
        Me.lblActual_2.Name = "lblActual_2"
        Me.lblActual_2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_2.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_2.StylePriority.UseBackColor = False
        Me.lblActual_2.StylePriority.UseBorderColor = False
        Me.lblActual_2.StylePriority.UseBorders = False
        Me.lblActual_2.StylePriority.UseFont = False
        Me.lblActual_2.StylePriority.UseForeColor = False
        Me.lblActual_2.StylePriority.UseTextAlignment = False
        Me.lblActual_2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_2.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_1
        '
        Me.lblActual_1.BackColor = System.Drawing.Color.White
        Me.lblActual_1.BorderColor = System.Drawing.Color.Black
        Me.lblActual_1.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_1.CanGrow = False
        Me.lblActual_1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_1.ForeColor = System.Drawing.Color.Black
        Me.lblActual_1.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 0.0!)
        Me.lblActual_1.Name = "lblActual_1"
        Me.lblActual_1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_1.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_1.StylePriority.UseBackColor = False
        Me.lblActual_1.StylePriority.UseBorderColor = False
        Me.lblActual_1.StylePriority.UseBorders = False
        Me.lblActual_1.StylePriority.UseFont = False
        Me.lblActual_1.StylePriority.UseForeColor = False
        Me.lblActual_1.StylePriority.UseTextAlignment = False
        Me.lblActual_1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_1.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblFinancial
        '
        Me.lblFinancial.BackColor = System.Drawing.Color.White
        Me.lblFinancial.BorderColor = System.Drawing.Color.Black
        Me.lblFinancial.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancial.CanGrow = False
        Me.lblFinancial.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancial.ForeColor = System.Drawing.Color.Black
        Me.lblFinancial.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.lblFinancial.Name = "lblFinancial"
        Me.lblFinancial.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancial.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblFinancial.StylePriority.UseBackColor = False
        Me.lblFinancial.StylePriority.UseBorderColor = False
        Me.lblFinancial.StylePriority.UseBorders = False
        Me.lblFinancial.StylePriority.UseFont = False
        Me.lblFinancial.StylePriority.UseForeColor = False
        Me.lblFinancial.StylePriority.UseTextAlignment = False
        Me.lblFinancial.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFinancial.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblAccount
        '
        Me.lblAccount.BackColor = System.Drawing.Color.White
        Me.lblAccount.BorderColor = System.Drawing.Color.Black
        Me.lblAccount.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblAccount.CanGrow = False
        Me.lblAccount.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccount.ForeColor = System.Drawing.Color.Black
        Me.lblAccount.LocationFloat = New DevExpress.Utils.PointFloat(60.0!, 0.0!)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccount.SizeF = New System.Drawing.SizeF(340.0!, 20.0!)
        Me.lblAccount.StylePriority.UseBackColor = False
        Me.lblAccount.StylePriority.UseBorderColor = False
        Me.lblAccount.StylePriority.UseBorders = False
        Me.lblAccount.StylePriority.UseFont = False
        Me.lblAccount.StylePriority.UseForeColor = False
        Me.lblAccount.StylePriority.UseTextAlignment = False
        Me.lblAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'lblCode
        '
        Me.lblCode.BackColor = System.Drawing.Color.White
        Me.lblCode.BorderColor = System.Drawing.Color.Black
        Me.lblCode.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblCode.CanGrow = False
        Me.lblCode.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Black
        Me.lblCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblCode.SizeF = New System.Drawing.SizeF(60.0!, 20.0!)
        Me.lblCode.StylePriority.UseBackColor = False
        Me.lblCode.StylePriority.UseBorderColor = False
        Me.lblCode.StylePriority.UseBorders = False
        Me.lblCode.StylePriority.UseFont = False
        Me.lblCode.StylePriority.UseForeColor = False
        Me.lblCode.StylePriority.UseTextAlignment = False
        Me.lblCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.XrPageInfo2.LocationFloat = New DevExpress.Utils.PointFloat(399.9999!, 0.0!)
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
        'XrLabel8
        '
        Me.XrLabel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel8.BorderColor = System.Drawing.Color.Black
        Me.XrLabel8.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel8.CanGrow = False
        Me.XrLabel8.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.White
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 40.0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(240.0!, 20.0!)
        Me.XrLabel8.StylePriority.UseBackColor = False
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseBorders = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Actual As Of"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFinancialH2
        '
        Me.lblFinancialH2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFinancialH2.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialH2.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialH2.CanGrow = False
        Me.lblFinancialH2.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialH2.ForeColor = System.Drawing.Color.White
        Me.lblFinancialH2.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 40.0!)
        Me.lblFinancialH2.Name = "lblFinancialH2"
        Me.lblFinancialH2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialH2.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblFinancialH2.StylePriority.UseBackColor = False
        Me.lblFinancialH2.StylePriority.UseBorderColor = False
        Me.lblFinancialH2.StylePriority.UseBorders = False
        Me.lblFinancialH2.StylePriority.UseFont = False
        Me.lblFinancialH2.StylePriority.UseForeColor = False
        Me.lblFinancialH2.StylePriority.UseTextAlignment = False
        Me.lblFinancialH2.Text = "Financial Plan"
        Me.lblFinancialH2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel6.BorderColor = System.Drawing.Color.Black
        Me.XrLabel6.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel6.CanGrow = False
        Me.XrLabel6.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.ForeColor = System.Drawing.Color.White
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(640.0!, 60.0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.XrLabel6.StylePriority.UseBackColor = False
        Me.XrLabel6.StylePriority.UseBorderColor = False
        Me.XrLabel6.StylePriority.UseBorders = False
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseForeColor = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "August 08, 2018"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel5.BorderColor = System.Drawing.Color.Black
        Me.XrLabel5.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel5.CanGrow = False
        Me.XrLabel5.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.ForeColor = System.Drawing.Color.White
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 60.0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.XrLabel5.StylePriority.UseBackColor = False
        Me.XrLabel5.StylePriority.UseBorderColor = False
        Me.XrLabel5.StylePriority.UseBorders = False
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseForeColor = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "August 08, 2018"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel4
        '
        Me.XrLabel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel4.BorderColor = System.Drawing.Color.Black
        Me.XrLabel4.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel4.CanGrow = False
        Me.XrLabel4.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.ForeColor = System.Drawing.Color.White
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 60.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.XrLabel4.StylePriority.UseBackColor = False
        Me.XrLabel4.StylePriority.UseBorderColor = False
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseForeColor = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "August 08, 2018"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFinancialH
        '
        Me.lblFinancialH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblFinancialH.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialH.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialH.CanGrow = False
        Me.lblFinancialH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialH.ForeColor = System.Drawing.Color.White
        Me.lblFinancialH.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 60.0!)
        Me.lblFinancialH.Name = "lblFinancialH"
        Me.lblFinancialH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialH.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.lblFinancialH.StylePriority.UseBackColor = False
        Me.lblFinancialH.StylePriority.UseBorderColor = False
        Me.lblFinancialH.StylePriority.UseBorders = False
        Me.lblFinancialH.StylePriority.UseFont = False
        Me.lblFinancialH.StylePriority.UseForeColor = False
        Me.lblFinancialH.StylePriority.UseTextAlignment = False
        Me.lblFinancialH.Text = "August 08, 2018"
        Me.lblFinancialH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.lblAccountH.LocationFloat = New DevExpress.Utils.PointFloat(59.99997!, 60.0!)
        Me.lblAccountH.Name = "lblAccountH"
        Me.lblAccountH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAccountH.SizeF = New System.Drawing.SizeF(340.0!, 35.0!)
        Me.lblAccountH.StylePriority.UseBackColor = False
        Me.lblAccountH.StylePriority.UseBorderColor = False
        Me.lblAccountH.StylePriority.UseBorders = False
        Me.lblAccountH.StylePriority.UseFont = False
        Me.lblAccountH.StylePriority.UseForeColor = False
        Me.lblAccountH.StylePriority.UseTextAlignment = False
        Me.lblAccountH.Text = "Account Title"
        Me.lblAccountH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel10
        '
        Me.XrLabel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel10.BorderColor = System.Drawing.Color.Black
        Me.XrLabel10.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel10.CanGrow = False
        Me.XrLabel10.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel10.ForeColor = System.Drawing.Color.White
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 60.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(60.0!, 35.0!)
        Me.XrLabel10.StylePriority.UseBackColor = False
        Me.XrLabel10.StylePriority.UseBorderColor = False
        Me.XrLabel10.StylePriority.UseBorders = False
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseForeColor = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = "Account Code"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.lblDifference_T, Me.lblTotalH, Me.lblFinancialT, Me.lblActual_1T, Me.lblActual_2T, Me.lblActual_3T})
        Me.ReportFooter.HeightF = 20.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'lblDifference_T
        '
        Me.lblDifference_T.BackColor = System.Drawing.Color.White
        Me.lblDifference_T.BorderColor = System.Drawing.Color.Black
        Me.lblDifference_T.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblDifference_T.CanGrow = False
        Me.lblDifference_T.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDifference_T.ForeColor = System.Drawing.Color.Black
        Me.lblDifference_T.LocationFloat = New DevExpress.Utils.PointFloat(719.9999!, 0.0!)
        Me.lblDifference_T.Name = "lblDifference_T"
        Me.lblDifference_T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblDifference_T.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblDifference_T.StylePriority.UseBackColor = False
        Me.lblDifference_T.StylePriority.UseBorderColor = False
        Me.lblDifference_T.StylePriority.UseBorders = False
        Me.lblDifference_T.StylePriority.UseFont = False
        Me.lblDifference_T.StylePriority.UseForeColor = False
        Me.lblDifference_T.StylePriority.UseTextAlignment = False
        Me.lblDifference_T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblDifference_T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblTotalH
        '
        Me.lblTotalH.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTotalH.BorderColor = System.Drawing.Color.Black
        Me.lblTotalH.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblTotalH.CanGrow = False
        Me.lblTotalH.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalH.ForeColor = System.Drawing.Color.White
        Me.lblTotalH.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
        Me.lblTotalH.Name = "lblTotalH"
        Me.lblTotalH.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblTotalH.SizeF = New System.Drawing.SizeF(400.0!, 20.0!)
        Me.lblTotalH.StylePriority.UseBackColor = False
        Me.lblTotalH.StylePriority.UseBorderColor = False
        Me.lblTotalH.StylePriority.UseBorders = False
        Me.lblTotalH.StylePriority.UseFont = False
        Me.lblTotalH.StylePriority.UseForeColor = False
        Me.lblTotalH.StylePriority.UseTextAlignment = False
        Me.lblTotalH.Text = "T O T A L"
        Me.lblTotalH.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblFinancialT
        '
        Me.lblFinancialT.BackColor = System.Drawing.Color.White
        Me.lblFinancialT.BorderColor = System.Drawing.Color.Black
        Me.lblFinancialT.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblFinancialT.CanGrow = False
        Me.lblFinancialT.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinancialT.ForeColor = System.Drawing.Color.Black
        Me.lblFinancialT.LocationFloat = New DevExpress.Utils.PointFloat(400.0!, 0.0!)
        Me.lblFinancialT.Name = "lblFinancialT"
        Me.lblFinancialT.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblFinancialT.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblFinancialT.StylePriority.UseBackColor = False
        Me.lblFinancialT.StylePriority.UseBorderColor = False
        Me.lblFinancialT.StylePriority.UseBorders = False
        Me.lblFinancialT.StylePriority.UseFont = False
        Me.lblFinancialT.StylePriority.UseForeColor = False
        Me.lblFinancialT.StylePriority.UseTextAlignment = False
        Me.lblFinancialT.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblFinancialT.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_1T
        '
        Me.lblActual_1T.BackColor = System.Drawing.Color.White
        Me.lblActual_1T.BorderColor = System.Drawing.Color.Black
        Me.lblActual_1T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_1T.CanGrow = False
        Me.lblActual_1T.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_1T.ForeColor = System.Drawing.Color.Black
        Me.lblActual_1T.LocationFloat = New DevExpress.Utils.PointFloat(480.0!, 0.0!)
        Me.lblActual_1T.Name = "lblActual_1T"
        Me.lblActual_1T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_1T.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_1T.StylePriority.UseBackColor = False
        Me.lblActual_1T.StylePriority.UseBorderColor = False
        Me.lblActual_1T.StylePriority.UseBorders = False
        Me.lblActual_1T.StylePriority.UseFont = False
        Me.lblActual_1T.StylePriority.UseForeColor = False
        Me.lblActual_1T.StylePriority.UseTextAlignment = False
        Me.lblActual_1T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_1T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_2T
        '
        Me.lblActual_2T.BackColor = System.Drawing.Color.White
        Me.lblActual_2T.BorderColor = System.Drawing.Color.Black
        Me.lblActual_2T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_2T.CanGrow = False
        Me.lblActual_2T.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_2T.ForeColor = System.Drawing.Color.Black
        Me.lblActual_2T.LocationFloat = New DevExpress.Utils.PointFloat(560.0!, 0.0!)
        Me.lblActual_2T.Name = "lblActual_2T"
        Me.lblActual_2T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_2T.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_2T.StylePriority.UseBackColor = False
        Me.lblActual_2T.StylePriority.UseBorderColor = False
        Me.lblActual_2T.StylePriority.UseBorders = False
        Me.lblActual_2T.StylePriority.UseFont = False
        Me.lblActual_2T.StylePriority.UseForeColor = False
        Me.lblActual_2T.StylePriority.UseTextAlignment = False
        Me.lblActual_2T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_2T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'lblActual_3T
        '
        Me.lblActual_3T.BackColor = System.Drawing.Color.White
        Me.lblActual_3T.BorderColor = System.Drawing.Color.Black
        Me.lblActual_3T.Borders = CType((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.lblActual_3T.CanGrow = False
        Me.lblActual_3T.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActual_3T.ForeColor = System.Drawing.Color.Black
        Me.lblActual_3T.LocationFloat = New DevExpress.Utils.PointFloat(640.0!, 0.0!)
        Me.lblActual_3T.Name = "lblActual_3T"
        Me.lblActual_3T.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblActual_3T.SizeF = New System.Drawing.SizeF(80.0!, 20.0!)
        Me.lblActual_3T.StylePriority.UseBackColor = False
        Me.lblActual_3T.StylePriority.UseBorderColor = False
        Me.lblActual_3T.StylePriority.UseBorders = False
        Me.lblActual_3T.StylePriority.UseFont = False
        Me.lblActual_3T.StylePriority.UseForeColor = False
        Me.lblActual_3T.StylePriority.UseTextAlignment = False
        Me.lblActual_3T.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.lblActual_3T.XlsxFormatString = "#,##0.00_);(#,##0.00)"
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.lblTitle, Me.lblAsOf, Me.XrLabel6, Me.lblAccountH, Me.lblFinancialH, Me.XrLabel4, Me.XrLabel5, Me.XrLabel10, Me.lblFinancialH2, Me.XrLabel8})
        Me.PageHeader.HeightF = 95.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.XrLabel1.BorderColor = System.Drawing.Color.Black
        Me.XrLabel1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel1.CanGrow = False
        Me.XrLabel1.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.ForeColor = System.Drawing.Color.White
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(719.9999!, 60.0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(80.0!, 35.0!)
        Me.XrLabel1.StylePriority.UseBackColor = False
        Me.XrLabel1.StylePriority.UseBorderColor = False
        Me.XrLabel1.StylePriority.UseBorders = False
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseForeColor = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Variance"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        Me.lblTitle.SizeF = New System.Drawing.SizeF(800.0!, 20.0!)
        Me.lblTitle.StylePriority.UseBackColor = False
        Me.lblTitle.StylePriority.UseBorderColor = False
        Me.lblTitle.StylePriority.UseBorders = False
        Me.lblTitle.StylePriority.UseFont = False
        Me.lblTitle.StylePriority.UseForeColor = False
        Me.lblTitle.StylePriority.UseTextAlignment = False
        Me.lblTitle.Text = "Trial Balance"
        Me.lblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'lblAsOf
        '
        Me.lblAsOf.BackColor = System.Drawing.Color.White
        Me.lblAsOf.BorderColor = System.Drawing.Color.Black
        Me.lblAsOf.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.lblAsOf.CanGrow = False
        Me.lblAsOf.Font = New System.Drawing.Font("Century Gothic", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAsOf.ForeColor = System.Drawing.Color.Black
        Me.lblAsOf.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 20.0!)
        Me.lblAsOf.Name = "lblAsOf"
        Me.lblAsOf.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.lblAsOf.SizeF = New System.Drawing.SizeF(799.9999!, 15.0!)
        Me.lblAsOf.StylePriority.UseBackColor = False
        Me.lblAsOf.StylePriority.UseBorderColor = False
        Me.lblAsOf.StylePriority.UseBorders = False
        Me.lblAsOf.StylePriority.UseFont = False
        Me.lblAsOf.StylePriority.UseForeColor = False
        Me.lblAsOf.StylePriority.UseTextAlignment = False
        Me.lblAsOf.Text = "As of August 08, 2018"
        Me.lblAsOf.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'rptTrialBalance
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.ReportFooter, Me.PageHeader})
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccountH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialH2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancial As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblCode As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents lblTotalH As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblFinancialT As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_1T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_2T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblActual_3T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents lblTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblAsOf As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDifference As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents lblDifference_T As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo2 As DevExpress.XtraReports.UI.XRPageInfo
End Class
